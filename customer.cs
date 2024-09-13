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
   public class customer : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action15") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_15_012( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action16") == 0 )
         {
            A16CustomerManagerGivenName = GetPar( "CustomerManagerGivenName");
            A9CustomerManagerLastName = GetPar( "CustomerManagerLastName");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_16_012( A16CustomerManagerGivenName, A9CustomerManagerLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action25") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_25_014( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action26") == 0 )
         {
            A24CustomerLocationReceptionistGi = GetPar( "CustomerLocationReceptionistGi");
            A25CustomerLocationReceptionistLa = GetPar( "CustomerLocationReceptionistLa");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_26_014( A24CustomerLocationReceptionistGi, A25CustomerLocationReceptionistLa) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A78CustomerTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerTypeId"), "."), 18, MidpointRounding.ToEven));
            n78CustomerTypeId = false;
            AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A78CustomerTypeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A55Supplier_AgbId = (short)(Math.Round(NumberUtil.Val( GetPar( "Supplier_AgbId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A55Supplier_AgbId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_35") == 0 )
         {
            A64Supplier_GenId = (short)(Math.Round(NumberUtil.Val( GetPar( "Supplier_GenId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_35( A64Supplier_GenId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_37") == 0 )
         {
            A98AmenitiesId = (short)(Math.Round(NumberUtil.Val( GetPar( "AmenitiesId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_37( A98AmenitiesId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_38") == 0 )
         {
            A99AmenitiesTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "AmenitiesTypeId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_38( A99AmenitiesTypeId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_manager") == 0 )
         {
            gxnrGridlevel_manager_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_receptionist") == 0 )
         {
            gxnrGridlevel_receptionist_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_supplier_agb") == 0 )
         {
            gxnrGridlevel_supplier_agb_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_supplier_gen") == 0 )
         {
            gxnrGridlevel_supplier_gen_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_amenities") == 0 )
         {
            gxnrGridlevel_amenities_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylelevel_locations") == 0 )
         {
            gxnrFreestylelevel_locations_newrow_invoke( ) ;
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
               AV7CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7CustomerId", StringUtil.LTrimStr( (decimal)(AV7CustomerId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CustomerId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Customer", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCustomerKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_manager_newrow_invoke( )
      {
         nRC_GXsfl_78 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_78"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_78_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_78_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_78_idx = GetPar( "sGXsfl_78_idx");
         A93CustomerLastLine = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerLastLine"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_manager_newrow( ) ;
         /* End function gxnrGridlevel_manager_newrow_invoke */
      }

      protected void gxnrGridlevel_receptionist_newrow_invoke( )
      {
         nRC_GXsfl_129 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_129"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_129_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_129_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_129_idx = GetPar( "sGXsfl_129_idx");
         A94CustomerLocationLastLine = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerLocationLastLine"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_receptionist_newrow( ) ;
         /* End function gxnrGridlevel_receptionist_newrow_invoke */
      }

      protected void gxnrGridlevel_supplier_agb_newrow_invoke( )
      {
         nRC_GXsfl_143 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_143"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_143_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_143_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_143_idx = GetPar( "sGXsfl_143_idx");
         edtSupplier_AgbId_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtSupplier_AgbId_Internalname, "Horizontalalignment", edtSupplier_AgbId_Horizontalalignment, !bGXsfl_143_Refreshing);
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_supplier_agb_newrow( ) ;
         /* End function gxnrGridlevel_supplier_agb_newrow_invoke */
      }

      protected void gxnrGridlevel_supplier_gen_newrow_invoke( )
      {
         nRC_GXsfl_156 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_156"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_156_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_156_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_156_idx = GetPar( "sGXsfl_156_idx");
         edtSupplier_GenId_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtSupplier_GenId_Internalname, "Horizontalalignment", edtSupplier_GenId_Horizontalalignment, !bGXsfl_156_Refreshing);
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_supplier_gen_newrow( ) ;
         /* End function gxnrGridlevel_supplier_gen_newrow_invoke */
      }

      protected void gxnrGridlevel_amenities_newrow_invoke( )
      {
         nRC_GXsfl_168 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_168"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_168_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_168_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_168_idx = GetPar( "sGXsfl_168_idx");
         edtAmenitiesId_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtAmenitiesId_Internalname, "Horizontalalignment", edtAmenitiesId_Horizontalalignment, !bGXsfl_168_Refreshing);
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_amenities_newrow( ) ;
         /* End function gxnrGridlevel_amenities_newrow_invoke */
      }

      protected void gxnrFreestylelevel_locations_newrow_invoke( )
      {
         nRC_GXsfl_97 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_97"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_97_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_97_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_97_idx = GetPar( "sGXsfl_97_idx");
         A95CustomerLastLineLocation = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerLastLineLocation"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylelevel_locations_newrow( ) ;
         /* End function gxnrFreestylelevel_locations_newrow_invoke */
      }

      public customer( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customer( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_CustomerId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CustomerId = aP1_CustomerId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCustomerManagerGender = new GXCombobox();
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
            return "customer_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Customer.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerId_Internalname, context.GetMessage( "Id", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCustomerId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9") : context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerKvkNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerKvkNumber_Internalname, context.GetMessage( "Kvk Number", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerKvkNumber_Internalname, A41CustomerKvkNumber, StringUtil.RTrim( context.localUtil.Format( A41CustomerKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerKvkNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Customer.htm");
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
         GxWebStd.gx_label_element( context, edtCustomerName_Internalname, context.GetMessage( "Name", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, A3CustomerName, StringUtil.RTrim( context.localUtil.Format( A3CustomerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerPostalAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerPostalAddress_Internalname, context.GetMessage( "Postal Address", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCustomerPostalAddress_Internalname, A4CustomerPostalAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A4CustomerPostalAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtCustomerPostalAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerEmail_Internalname, context.GetMessage( "Email", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerEmail_Internalname, A5CustomerEmail, StringUtil.RTrim( context.localUtil.Format( A5CustomerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A5CustomerEmail, "", "", "", edtCustomerEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerVisitingAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerVisitingAddress_Internalname, context.GetMessage( "Visiting Address", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCustomerVisitingAddress_Internalname, A6CustomerVisitingAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A6CustomerVisitingAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtCustomerVisitingAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerPhone_Internalname, context.GetMessage( "Phone", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A7CustomerPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerPhone_Internalname, StringUtil.RTrim( A7CustomerPhone), StringUtil.RTrim( context.localUtil.Format( A7CustomerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCustomerPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerVatNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerVatNumber_Internalname, context.GetMessage( "Vat Number", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerVatNumber_Internalname, A14CustomerVatNumber, StringUtil.RTrim( context.localUtil.Format( A14CustomerVatNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerVatNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerVatNumber_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcustomertypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcustomertypeid_Internalname, context.GetMessage( "Customer Type", ""), "", "", lblTextblockcustomertypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_customertypeid.SetProperty("Caption", Combo_customertypeid_Caption);
         ucCombo_customertypeid.SetProperty("Cls", Combo_customertypeid_Cls);
         ucCombo_customertypeid.SetProperty("DataListProc", Combo_customertypeid_Datalistproc);
         ucCombo_customertypeid.SetProperty("DataListProcParametersPrefix", Combo_customertypeid_Datalistprocparametersprefix);
         ucCombo_customertypeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_customertypeid.SetProperty("DropDownOptionsData", AV26CustomerTypeId_Data);
         ucCombo_customertypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_customertypeid_Internalname, "COMBO_CUSTOMERTYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerTypeId_Internalname, context.GetMessage( "Customer Type Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A78CustomerTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A78CustomerTypeId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerTypeId_Visible, edtCustomerTypeId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_manager_title_Internalname, context.GetMessage( "Manager", ""), "", "", lblTablevel_manager_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Customer.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Manager") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"panel2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_manager_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_manager_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_manager( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"title3"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_locations_title_Internalname, context.GetMessage( "Locations", ""), "", "", lblTablevel_locations_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Customer.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Locations") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"panel3"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_locations_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableintermediatelevel_locations_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Freestylelevel_locations( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         ClassString = "BtnDefault ButtonWizard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "", context.GetMessage( "GXM_previous", ""), bttBtnwizardprevious_Jsonclick, 7, context.GetMessage( "GXM_previous", ""), "", StyleString, ClassString, bttBtnwizardprevious_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11012_client"+"'", TempTags, "", 2, "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'',0)\"";
         ClassString = "Button ButtonWizard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnwizardnext_Internalname, "", context.GetMessage( "GXM_next", ""), bttBtnwizardnext_Jsonclick, 7, context.GetMessage( "GXM_next", ""), "", StyleString, ClassString, bttBtnwizardnext_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e12012_client"+"'", TempTags, "", 2, "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Customer.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_customertypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombocustomertypeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ComboCustomerTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCombocustomertypeid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27ComboCustomerTypeId), "ZZZ9") : context.localUtil.Format( (decimal)(AV27ComboCustomerTypeId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocustomertypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocustomertypeid_Visible, edtavCombocustomertypeid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Customer.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* User Defined Control */
         ucCombo_supplier_agbid.SetProperty("Caption", Combo_supplier_agbid_Caption);
         ucCombo_supplier_agbid.SetProperty("Cls", Combo_supplier_agbid_Cls);
         ucCombo_supplier_agbid.SetProperty("IsGridItem", Combo_supplier_agbid_Isgriditem);
         ucCombo_supplier_agbid.SetProperty("HasDescription", Combo_supplier_agbid_Hasdescription);
         ucCombo_supplier_agbid.SetProperty("DataListProc", Combo_supplier_agbid_Datalistproc);
         ucCombo_supplier_agbid.SetProperty("DataListProcParametersPrefix", Combo_supplier_agbid_Datalistprocparametersprefix);
         ucCombo_supplier_agbid.SetProperty("EmptyItem", Combo_supplier_agbid_Emptyitem);
         ucCombo_supplier_agbid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_supplier_agbid.SetProperty("DropDownOptionsData", AV25Supplier_AgbId_Data);
         ucCombo_supplier_agbid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplier_agbid_Internalname, "COMBO_SUPPLIER_AGBIDContainer");
         /* User Defined Control */
         ucCombo_supplier_genid.SetProperty("Caption", Combo_supplier_genid_Caption);
         ucCombo_supplier_genid.SetProperty("Cls", Combo_supplier_genid_Cls);
         ucCombo_supplier_genid.SetProperty("IsGridItem", Combo_supplier_genid_Isgriditem);
         ucCombo_supplier_genid.SetProperty("HasDescription", Combo_supplier_genid_Hasdescription);
         ucCombo_supplier_genid.SetProperty("DataListProc", Combo_supplier_genid_Datalistproc);
         ucCombo_supplier_genid.SetProperty("DataListProcParametersPrefix", Combo_supplier_genid_Datalistprocparametersprefix);
         ucCombo_supplier_genid.SetProperty("EmptyItem", Combo_supplier_genid_Emptyitem);
         ucCombo_supplier_genid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_supplier_genid.SetProperty("DropDownOptionsData", AV18Supplier_GenId_Data);
         ucCombo_supplier_genid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplier_genid_Internalname, "COMBO_SUPPLIER_GENIDContainer");
         /* User Defined Control */
         ucCombo_amenitiesid.SetProperty("Caption", Combo_amenitiesid_Caption);
         ucCombo_amenitiesid.SetProperty("Cls", Combo_amenitiesid_Cls);
         ucCombo_amenitiesid.SetProperty("IsGridItem", Combo_amenitiesid_Isgriditem);
         ucCombo_amenitiesid.SetProperty("HasDescription", Combo_amenitiesid_Hasdescription);
         ucCombo_amenitiesid.SetProperty("DataListProc", Combo_amenitiesid_Datalistproc);
         ucCombo_amenitiesid.SetProperty("DataListProcParametersPrefix", Combo_amenitiesid_Datalistprocparametersprefix);
         ucCombo_amenitiesid.SetProperty("EmptyItem", Combo_amenitiesid_Emptyitem);
         ucCombo_amenitiesid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_amenitiesid.SetProperty("DropDownOptionsData", AV28AmenitiesId_Data);
         ucCombo_amenitiesid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_amenitiesid_Internalname, "COMBO_AMENITIESIDContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerLastLine_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A93CustomerLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCustomerLastLine_Enabled!=0) ? context.localUtil.Format( (decimal)(A93CustomerLastLine), "ZZZ9") : context.localUtil.Format( (decimal)(A93CustomerLastLine), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,193);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerLastLine_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerLastLine_Visible, edtCustomerLastLine_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Customer.htm");
         /* User Defined Control */
         ucWizard_steps.Render(context, "dvelop.dvtabstransform", Wizard_steps_Internalname, "WIZARD_STEPSContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_manager( )
      {
         /*  Grid Control  */
         StartGridControl78( ) ;
         nGXsfl_78_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount2 = 2;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_2 = 1;
               ScanStart012( ) ;
               while ( RcdFound2 != 0 )
               {
                  init_level_properties2( ) ;
                  getByPrimaryKey012( ) ;
                  AddRow012( ) ;
                  ScanNext012( ) ;
               }
               ScanEnd012( ) ;
               nBlankRcdCount2 = 2;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            B93CustomerLastLine = A93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            standaloneNotModal012( ) ;
            standaloneModal012( ) ;
            sMode2 = Gx_mode;
            while ( nGXsfl_78_idx < nRC_GXsfl_78 )
            {
               bGXsfl_78_Refreshing = true;
               ReadRow012( ) ;
               edtCustomerManagerId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERID_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtCustomerManagerGivenName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERGIVENNAME_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerManagerGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerGivenName_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtCustomerManagerLastName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERLASTNAME_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerManagerLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerLastName_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtCustomerManagerInitials_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERINITIALS_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerManagerInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerInitials_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtCustomerManagerEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGEREMAIL_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerManagerEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerEmail_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtCustomerManagerPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERPHONE_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerManagerPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerPhone_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               cmbCustomerManagerGender.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERGENDER_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbCustomerManagerGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCustomerManagerGender.Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtCustomerManagerGAMGUID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERGAMGUID_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerManagerGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerGAMGUID_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               if ( ( nRcdExists_2 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal012( ) ;
               }
               SendRow012( ) ;
               bGXsfl_78_Refreshing = false;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            A93CustomerLastLine = B93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount2 = 2;
            nRcdExists_2 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart012( ) ;
               while ( RcdFound2 != 0 )
               {
                  sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_782( ) ;
                  init_level_properties2( ) ;
                  standaloneNotModal012( ) ;
                  getByPrimaryKey012( ) ;
                  standaloneModal012( ) ;
                  AddRow012( ) ;
                  ScanNext012( ) ;
               }
               ScanEnd012( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode2 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
            SubsflControlProps_782( ) ;
            InitAll012( ) ;
            init_level_properties2( ) ;
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            B93CustomerLastLine = A93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            nRcdExists_2 = 0;
            nIsMod_2 = 0;
            nRcdDeleted_2 = 0;
            nBlankRcdCount2 = (short)(nBlankRcdUsr2+nBlankRcdCount2);
            fRowAdded = 0;
            while ( nBlankRcdCount2 > 0 )
            {
               standaloneNotModal012( ) ;
               standaloneModal012( ) ;
               AddRow012( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCustomerManagerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount2 = (short)(nBlankRcdCount2-1);
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            A93CustomerLastLine = B93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_managerContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_manager", Gridlevel_managerContainer, subGridlevel_manager_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_managerContainerData", Gridlevel_managerContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_managerContainerData"+"V", Gridlevel_managerContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_managerContainerData"+"V"+"\" value='"+Gridlevel_managerContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Freestylelevel_locations( )
      {
         /*  Grid Control  */
         StartGridControl97( ) ;
         /* Save parent mode. */
         sMode3 = Gx_mode;
         nGXsfl_97_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount3 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_3 = 1;
               ScanStart013( ) ;
               while ( RcdFound3 != 0 )
               {
                  init_level_properties3( ) ;
                  getByPrimaryKey013( ) ;
                  AddRow013( ) ;
                  ScanNext013( ) ;
               }
               ScanEnd013( ) ;
               nBlankRcdCount3 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            B93CustomerLastLine = A93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            standaloneNotModal013( ) ;
            standaloneModal013( ) ;
            sMode3 = Gx_mode;
            while ( nGXsfl_97_idx < nRC_GXsfl_97 )
            {
               bGXsfl_97_Refreshing = true;
               ReadRow013( ) ;
               edtCustomerLocationId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONID_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationId_Enabled), 5, 0), !bGXsfl_97_Refreshing);
               edtCustomerLocationVisitingAddres_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONVISITINGADDRES_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationVisitingAddres_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationVisitingAddres_Enabled), 5, 0), !bGXsfl_97_Refreshing);
               edtCustomerLocationPostalAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONPOSTALADDRESS_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationPostalAddress_Enabled), 5, 0), !bGXsfl_97_Refreshing);
               edtCustomerLocationEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONEMAIL_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationEmail_Enabled), 5, 0), !bGXsfl_97_Refreshing);
               edtCustomerLocationPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONPHONE_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationPhone_Enabled), 5, 0), !bGXsfl_97_Refreshing);
               if ( ( nRcdExists_3 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal013( ) ;
               }
               SendRow013( ) ;
               bGXsfl_97_Refreshing = false;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            A93CustomerLastLine = B93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount3 = 5;
            nRcdExists_3 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart013( ) ;
               while ( RcdFound3 != 0 )
               {
                  sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_973( ) ;
                  init_level_properties3( ) ;
                  standaloneNotModal013( ) ;
                  getByPrimaryKey013( ) ;
                  standaloneModal013( ) ;
                  AddRow013( ) ;
                  ScanNext013( ) ;
               }
               ScanEnd013( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode3 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx+1), 4, 0), 4, "0");
            SubsflControlProps_973( ) ;
            InitAll013( ) ;
            init_level_properties3( ) ;
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            B93CustomerLastLine = A93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            nRcdExists_3 = 0;
            nIsMod_3 = 0;
            nRcdDeleted_3 = 0;
            nBlankRcdCount3 = (short)(nBlankRcdUsr3+nBlankRcdCount3);
            fRowAdded = 0;
            while ( nBlankRcdCount3 > 0 )
            {
               standaloneNotModal013( ) ;
               standaloneModal013( ) ;
               AddRow013( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCustomerLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount3 = (short)(nBlankRcdCount3-1);
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            A93CustomerLastLine = B93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Freestylelevel_locationsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylelevel_locations", Freestylelevel_locationsContainer, subFreestylelevel_locations_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Freestylelevel_locationsContainerData", Freestylelevel_locationsContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Freestylelevel_locationsContainerData"+"V", Freestylelevel_locationsContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylelevel_locationsContainerData"+"V"+"\" value='"+Freestylelevel_locationsContainer.GridValuesHidden()+"'/>") ;
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
         E13012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCUSTOMERTYPEID_DATA"), AV26CustomerTypeId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIER_AGBID_DATA"), AV25Supplier_AgbId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIER_GENID_DATA"), AV18Supplier_GenId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vAMENITIESID_DATA"), AV28AmenitiesId_Data);
               /* Read saved values. */
               Z1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1CustomerId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z41CustomerKvkNumber = cgiGet( "Z41CustomerKvkNumber");
               Z3CustomerName = cgiGet( "Z3CustomerName");
               Z4CustomerPostalAddress = cgiGet( "Z4CustomerPostalAddress");
               n4CustomerPostalAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A4CustomerPostalAddress)) ? true : false);
               Z5CustomerEmail = cgiGet( "Z5CustomerEmail");
               n5CustomerEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A5CustomerEmail)) ? true : false);
               Z6CustomerVisitingAddress = cgiGet( "Z6CustomerVisitingAddress");
               n6CustomerVisitingAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A6CustomerVisitingAddress)) ? true : false);
               Z7CustomerPhone = cgiGet( "Z7CustomerPhone");
               n7CustomerPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A7CustomerPhone)) ? true : false);
               Z14CustomerVatNumber = cgiGet( "Z14CustomerVatNumber");
               Z93CustomerLastLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z93CustomerLastLine"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z95CustomerLastLineLocation = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z95CustomerLastLineLocation"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z78CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z78CustomerTypeId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n78CustomerTypeId = ((0==A78CustomerTypeId) ? true : false);
               A95CustomerLastLineLocation = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z95CustomerLastLineLocation"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O95CustomerLastLineLocation = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O95CustomerLastLineLocation"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O93CustomerLastLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O93CustomerLastLine"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_78 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_78"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_97 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_97"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N78CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N78CustomerTypeId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n78CustomerTypeId = ((0==A78CustomerTypeId) ? true : false);
               AV7CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCUSTOMERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CUSTOMERTYPEID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A95CustomerLastLineLocation = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLASTLINELOCATION"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A79CustomerTypeName = cgiGet( "CUSTOMERTYPENAME");
               AV30Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A94CustomerLocationLastLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONLASTLINE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A133CustomerLocationDescription = cgiGet( "CUSTOMERLOCATIONDESCRIPTION");
               A134CustomerLocationName = cgiGet( "CUSTOMERLOCATIONNAME");
               Combo_customertypeid_Objectcall = cgiGet( "COMBO_CUSTOMERTYPEID_Objectcall");
               Combo_customertypeid_Class = cgiGet( "COMBO_CUSTOMERTYPEID_Class");
               Combo_customertypeid_Icontype = cgiGet( "COMBO_CUSTOMERTYPEID_Icontype");
               Combo_customertypeid_Icon = cgiGet( "COMBO_CUSTOMERTYPEID_Icon");
               Combo_customertypeid_Caption = cgiGet( "COMBO_CUSTOMERTYPEID_Caption");
               Combo_customertypeid_Tooltip = cgiGet( "COMBO_CUSTOMERTYPEID_Tooltip");
               Combo_customertypeid_Cls = cgiGet( "COMBO_CUSTOMERTYPEID_Cls");
               Combo_customertypeid_Selectedvalue_set = cgiGet( "COMBO_CUSTOMERTYPEID_Selectedvalue_set");
               Combo_customertypeid_Selectedvalue_get = cgiGet( "COMBO_CUSTOMERTYPEID_Selectedvalue_get");
               Combo_customertypeid_Selectedtext_set = cgiGet( "COMBO_CUSTOMERTYPEID_Selectedtext_set");
               Combo_customertypeid_Selectedtext_get = cgiGet( "COMBO_CUSTOMERTYPEID_Selectedtext_get");
               Combo_customertypeid_Gamoauthtoken = cgiGet( "COMBO_CUSTOMERTYPEID_Gamoauthtoken");
               Combo_customertypeid_Ddointernalname = cgiGet( "COMBO_CUSTOMERTYPEID_Ddointernalname");
               Combo_customertypeid_Titlecontrolalign = cgiGet( "COMBO_CUSTOMERTYPEID_Titlecontrolalign");
               Combo_customertypeid_Dropdownoptionstype = cgiGet( "COMBO_CUSTOMERTYPEID_Dropdownoptionstype");
               Combo_customertypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERTYPEID_Enabled"));
               Combo_customertypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERTYPEID_Visible"));
               Combo_customertypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_CUSTOMERTYPEID_Titlecontrolidtoreplace");
               Combo_customertypeid_Datalisttype = cgiGet( "COMBO_CUSTOMERTYPEID_Datalisttype");
               Combo_customertypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERTYPEID_Allowmultipleselection"));
               Combo_customertypeid_Datalistfixedvalues = cgiGet( "COMBO_CUSTOMERTYPEID_Datalistfixedvalues");
               Combo_customertypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERTYPEID_Isgriditem"));
               Combo_customertypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERTYPEID_Hasdescription"));
               Combo_customertypeid_Datalistproc = cgiGet( "COMBO_CUSTOMERTYPEID_Datalistproc");
               Combo_customertypeid_Datalistprocparametersprefix = cgiGet( "COMBO_CUSTOMERTYPEID_Datalistprocparametersprefix");
               Combo_customertypeid_Remoteservicesparameters = cgiGet( "COMBO_CUSTOMERTYPEID_Remoteservicesparameters");
               Combo_customertypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CUSTOMERTYPEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_customertypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERTYPEID_Includeonlyselectedoption"));
               Combo_customertypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERTYPEID_Includeselectalloption"));
               Combo_customertypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERTYPEID_Emptyitem"));
               Combo_customertypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERTYPEID_Includeaddnewoption"));
               Combo_customertypeid_Htmltemplate = cgiGet( "COMBO_CUSTOMERTYPEID_Htmltemplate");
               Combo_customertypeid_Multiplevaluestype = cgiGet( "COMBO_CUSTOMERTYPEID_Multiplevaluestype");
               Combo_customertypeid_Loadingdata = cgiGet( "COMBO_CUSTOMERTYPEID_Loadingdata");
               Combo_customertypeid_Noresultsfound = cgiGet( "COMBO_CUSTOMERTYPEID_Noresultsfound");
               Combo_customertypeid_Emptyitemtext = cgiGet( "COMBO_CUSTOMERTYPEID_Emptyitemtext");
               Combo_customertypeid_Onlyselectedvalues = cgiGet( "COMBO_CUSTOMERTYPEID_Onlyselectedvalues");
               Combo_customertypeid_Selectalltext = cgiGet( "COMBO_CUSTOMERTYPEID_Selectalltext");
               Combo_customertypeid_Multiplevaluesseparator = cgiGet( "COMBO_CUSTOMERTYPEID_Multiplevaluesseparator");
               Combo_customertypeid_Addnewoptiontext = cgiGet( "COMBO_CUSTOMERTYPEID_Addnewoptiontext");
               Combo_customertypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CUSTOMERTYPEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_steps_Objectcall = cgiGet( "GXUITABSPANEL_STEPS_Objectcall");
               Gxuitabspanel_steps_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_STEPS_Enabled"));
               Gxuitabspanel_steps_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_STEPS_Activepage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_steps_Activepagecontrolname = cgiGet( "GXUITABSPANEL_STEPS_Activepagecontrolname");
               Gxuitabspanel_steps_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_STEPS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_steps_Class = cgiGet( "GXUITABSPANEL_STEPS_Class");
               Gxuitabspanel_steps_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_STEPS_Historymanagement"));
               Gxuitabspanel_steps_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_STEPS_Visible"));
               Combo_supplier_agbid_Objectcall = cgiGet( "COMBO_SUPPLIER_AGBID_Objectcall");
               Combo_supplier_agbid_Class = cgiGet( "COMBO_SUPPLIER_AGBID_Class");
               Combo_supplier_agbid_Icontype = cgiGet( "COMBO_SUPPLIER_AGBID_Icontype");
               Combo_supplier_agbid_Icon = cgiGet( "COMBO_SUPPLIER_AGBID_Icon");
               Combo_supplier_agbid_Caption = cgiGet( "COMBO_SUPPLIER_AGBID_Caption");
               Combo_supplier_agbid_Tooltip = cgiGet( "COMBO_SUPPLIER_AGBID_Tooltip");
               Combo_supplier_agbid_Cls = cgiGet( "COMBO_SUPPLIER_AGBID_Cls");
               Combo_supplier_agbid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIER_AGBID_Selectedvalue_set");
               Combo_supplier_agbid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIER_AGBID_Selectedvalue_get");
               Combo_supplier_agbid_Selectedtext_set = cgiGet( "COMBO_SUPPLIER_AGBID_Selectedtext_set");
               Combo_supplier_agbid_Selectedtext_get = cgiGet( "COMBO_SUPPLIER_AGBID_Selectedtext_get");
               Combo_supplier_agbid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIER_AGBID_Gamoauthtoken");
               Combo_supplier_agbid_Ddointernalname = cgiGet( "COMBO_SUPPLIER_AGBID_Ddointernalname");
               Combo_supplier_agbid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIER_AGBID_Titlecontrolalign");
               Combo_supplier_agbid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIER_AGBID_Dropdownoptionstype");
               Combo_supplier_agbid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_AGBID_Enabled"));
               Combo_supplier_agbid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_AGBID_Visible"));
               Combo_supplier_agbid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIER_AGBID_Titlecontrolidtoreplace");
               Combo_supplier_agbid_Datalisttype = cgiGet( "COMBO_SUPPLIER_AGBID_Datalisttype");
               Combo_supplier_agbid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_AGBID_Allowmultipleselection"));
               Combo_supplier_agbid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIER_AGBID_Datalistfixedvalues");
               Combo_supplier_agbid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_AGBID_Isgriditem"));
               Combo_supplier_agbid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_AGBID_Hasdescription"));
               Combo_supplier_agbid_Datalistproc = cgiGet( "COMBO_SUPPLIER_AGBID_Datalistproc");
               Combo_supplier_agbid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIER_AGBID_Datalistprocparametersprefix");
               Combo_supplier_agbid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIER_AGBID_Remoteservicesparameters");
               Combo_supplier_agbid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIER_AGBID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_supplier_agbid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_AGBID_Includeonlyselectedoption"));
               Combo_supplier_agbid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_AGBID_Includeselectalloption"));
               Combo_supplier_agbid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_AGBID_Emptyitem"));
               Combo_supplier_agbid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_AGBID_Includeaddnewoption"));
               Combo_supplier_agbid_Htmltemplate = cgiGet( "COMBO_SUPPLIER_AGBID_Htmltemplate");
               Combo_supplier_agbid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIER_AGBID_Multiplevaluestype");
               Combo_supplier_agbid_Loadingdata = cgiGet( "COMBO_SUPPLIER_AGBID_Loadingdata");
               Combo_supplier_agbid_Noresultsfound = cgiGet( "COMBO_SUPPLIER_AGBID_Noresultsfound");
               Combo_supplier_agbid_Emptyitemtext = cgiGet( "COMBO_SUPPLIER_AGBID_Emptyitemtext");
               Combo_supplier_agbid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIER_AGBID_Onlyselectedvalues");
               Combo_supplier_agbid_Selectalltext = cgiGet( "COMBO_SUPPLIER_AGBID_Selectalltext");
               Combo_supplier_agbid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIER_AGBID_Multiplevaluesseparator");
               Combo_supplier_agbid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIER_AGBID_Addnewoptiontext");
               Combo_supplier_agbid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIER_AGBID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_supplier_genid_Objectcall = cgiGet( "COMBO_SUPPLIER_GENID_Objectcall");
               Combo_supplier_genid_Class = cgiGet( "COMBO_SUPPLIER_GENID_Class");
               Combo_supplier_genid_Icontype = cgiGet( "COMBO_SUPPLIER_GENID_Icontype");
               Combo_supplier_genid_Icon = cgiGet( "COMBO_SUPPLIER_GENID_Icon");
               Combo_supplier_genid_Caption = cgiGet( "COMBO_SUPPLIER_GENID_Caption");
               Combo_supplier_genid_Tooltip = cgiGet( "COMBO_SUPPLIER_GENID_Tooltip");
               Combo_supplier_genid_Cls = cgiGet( "COMBO_SUPPLIER_GENID_Cls");
               Combo_supplier_genid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIER_GENID_Selectedvalue_set");
               Combo_supplier_genid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIER_GENID_Selectedvalue_get");
               Combo_supplier_genid_Selectedtext_set = cgiGet( "COMBO_SUPPLIER_GENID_Selectedtext_set");
               Combo_supplier_genid_Selectedtext_get = cgiGet( "COMBO_SUPPLIER_GENID_Selectedtext_get");
               Combo_supplier_genid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIER_GENID_Gamoauthtoken");
               Combo_supplier_genid_Ddointernalname = cgiGet( "COMBO_SUPPLIER_GENID_Ddointernalname");
               Combo_supplier_genid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIER_GENID_Titlecontrolalign");
               Combo_supplier_genid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIER_GENID_Dropdownoptionstype");
               Combo_supplier_genid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_GENID_Enabled"));
               Combo_supplier_genid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_GENID_Visible"));
               Combo_supplier_genid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIER_GENID_Titlecontrolidtoreplace");
               Combo_supplier_genid_Datalisttype = cgiGet( "COMBO_SUPPLIER_GENID_Datalisttype");
               Combo_supplier_genid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_GENID_Allowmultipleselection"));
               Combo_supplier_genid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIER_GENID_Datalistfixedvalues");
               Combo_supplier_genid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_GENID_Isgriditem"));
               Combo_supplier_genid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_GENID_Hasdescription"));
               Combo_supplier_genid_Datalistproc = cgiGet( "COMBO_SUPPLIER_GENID_Datalistproc");
               Combo_supplier_genid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIER_GENID_Datalistprocparametersprefix");
               Combo_supplier_genid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIER_GENID_Remoteservicesparameters");
               Combo_supplier_genid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIER_GENID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_supplier_genid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_GENID_Includeonlyselectedoption"));
               Combo_supplier_genid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_GENID_Includeselectalloption"));
               Combo_supplier_genid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_GENID_Emptyitem"));
               Combo_supplier_genid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIER_GENID_Includeaddnewoption"));
               Combo_supplier_genid_Htmltemplate = cgiGet( "COMBO_SUPPLIER_GENID_Htmltemplate");
               Combo_supplier_genid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIER_GENID_Multiplevaluestype");
               Combo_supplier_genid_Loadingdata = cgiGet( "COMBO_SUPPLIER_GENID_Loadingdata");
               Combo_supplier_genid_Noresultsfound = cgiGet( "COMBO_SUPPLIER_GENID_Noresultsfound");
               Combo_supplier_genid_Emptyitemtext = cgiGet( "COMBO_SUPPLIER_GENID_Emptyitemtext");
               Combo_supplier_genid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIER_GENID_Onlyselectedvalues");
               Combo_supplier_genid_Selectalltext = cgiGet( "COMBO_SUPPLIER_GENID_Selectalltext");
               Combo_supplier_genid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIER_GENID_Multiplevaluesseparator");
               Combo_supplier_genid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIER_GENID_Addnewoptiontext");
               Combo_supplier_genid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIER_GENID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_amenitiesid_Objectcall = cgiGet( "COMBO_AMENITIESID_Objectcall");
               Combo_amenitiesid_Class = cgiGet( "COMBO_AMENITIESID_Class");
               Combo_amenitiesid_Icontype = cgiGet( "COMBO_AMENITIESID_Icontype");
               Combo_amenitiesid_Icon = cgiGet( "COMBO_AMENITIESID_Icon");
               Combo_amenitiesid_Caption = cgiGet( "COMBO_AMENITIESID_Caption");
               Combo_amenitiesid_Tooltip = cgiGet( "COMBO_AMENITIESID_Tooltip");
               Combo_amenitiesid_Cls = cgiGet( "COMBO_AMENITIESID_Cls");
               Combo_amenitiesid_Selectedvalue_set = cgiGet( "COMBO_AMENITIESID_Selectedvalue_set");
               Combo_amenitiesid_Selectedvalue_get = cgiGet( "COMBO_AMENITIESID_Selectedvalue_get");
               Combo_amenitiesid_Selectedtext_set = cgiGet( "COMBO_AMENITIESID_Selectedtext_set");
               Combo_amenitiesid_Selectedtext_get = cgiGet( "COMBO_AMENITIESID_Selectedtext_get");
               Combo_amenitiesid_Gamoauthtoken = cgiGet( "COMBO_AMENITIESID_Gamoauthtoken");
               Combo_amenitiesid_Ddointernalname = cgiGet( "COMBO_AMENITIESID_Ddointernalname");
               Combo_amenitiesid_Titlecontrolalign = cgiGet( "COMBO_AMENITIESID_Titlecontrolalign");
               Combo_amenitiesid_Dropdownoptionstype = cgiGet( "COMBO_AMENITIESID_Dropdownoptionstype");
               Combo_amenitiesid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESID_Enabled"));
               Combo_amenitiesid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESID_Visible"));
               Combo_amenitiesid_Titlecontrolidtoreplace = cgiGet( "COMBO_AMENITIESID_Titlecontrolidtoreplace");
               Combo_amenitiesid_Datalisttype = cgiGet( "COMBO_AMENITIESID_Datalisttype");
               Combo_amenitiesid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESID_Allowmultipleselection"));
               Combo_amenitiesid_Datalistfixedvalues = cgiGet( "COMBO_AMENITIESID_Datalistfixedvalues");
               Combo_amenitiesid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESID_Isgriditem"));
               Combo_amenitiesid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESID_Hasdescription"));
               Combo_amenitiesid_Datalistproc = cgiGet( "COMBO_AMENITIESID_Datalistproc");
               Combo_amenitiesid_Datalistprocparametersprefix = cgiGet( "COMBO_AMENITIESID_Datalistprocparametersprefix");
               Combo_amenitiesid_Remoteservicesparameters = cgiGet( "COMBO_AMENITIESID_Remoteservicesparameters");
               Combo_amenitiesid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_AMENITIESID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_amenitiesid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESID_Includeonlyselectedoption"));
               Combo_amenitiesid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESID_Includeselectalloption"));
               Combo_amenitiesid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESID_Emptyitem"));
               Combo_amenitiesid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESID_Includeaddnewoption"));
               Combo_amenitiesid_Htmltemplate = cgiGet( "COMBO_AMENITIESID_Htmltemplate");
               Combo_amenitiesid_Multiplevaluestype = cgiGet( "COMBO_AMENITIESID_Multiplevaluestype");
               Combo_amenitiesid_Loadingdata = cgiGet( "COMBO_AMENITIESID_Loadingdata");
               Combo_amenitiesid_Noresultsfound = cgiGet( "COMBO_AMENITIESID_Noresultsfound");
               Combo_amenitiesid_Emptyitemtext = cgiGet( "COMBO_AMENITIESID_Emptyitemtext");
               Combo_amenitiesid_Onlyselectedvalues = cgiGet( "COMBO_AMENITIESID_Onlyselectedvalues");
               Combo_amenitiesid_Selectalltext = cgiGet( "COMBO_AMENITIESID_Selectalltext");
               Combo_amenitiesid_Multiplevaluesseparator = cgiGet( "COMBO_AMENITIESID_Multiplevaluesseparator");
               Combo_amenitiesid_Addnewoptiontext = cgiGet( "COMBO_AMENITIESID_Addnewoptiontext");
               Combo_amenitiesid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_AMENITIESID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
               A41CustomerKvkNumber = cgiGet( edtCustomerKvkNumber_Internalname);
               AssignAttri("", false, "A41CustomerKvkNumber", A41CustomerKvkNumber);
               A3CustomerName = cgiGet( edtCustomerName_Internalname);
               AssignAttri("", false, "A3CustomerName", A3CustomerName);
               A4CustomerPostalAddress = cgiGet( edtCustomerPostalAddress_Internalname);
               n4CustomerPostalAddress = false;
               AssignAttri("", false, "A4CustomerPostalAddress", A4CustomerPostalAddress);
               n4CustomerPostalAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A4CustomerPostalAddress)) ? true : false);
               A5CustomerEmail = cgiGet( edtCustomerEmail_Internalname);
               n5CustomerEmail = false;
               AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
               n5CustomerEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A5CustomerEmail)) ? true : false);
               A6CustomerVisitingAddress = cgiGet( edtCustomerVisitingAddress_Internalname);
               n6CustomerVisitingAddress = false;
               AssignAttri("", false, "A6CustomerVisitingAddress", A6CustomerVisitingAddress);
               n6CustomerVisitingAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A6CustomerVisitingAddress)) ? true : false);
               A7CustomerPhone = cgiGet( edtCustomerPhone_Internalname);
               n7CustomerPhone = false;
               AssignAttri("", false, "A7CustomerPhone", A7CustomerPhone);
               n7CustomerPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A7CustomerPhone)) ? true : false);
               A14CustomerVatNumber = cgiGet( edtCustomerVatNumber_Internalname);
               AssignAttri("", false, "A14CustomerVatNumber", A14CustomerVatNumber);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUSTOMERTYPEID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A78CustomerTypeId = 0;
                  n78CustomerTypeId = false;
                  AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
               }
               else
               {
                  A78CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n78CustomerTypeId = false;
                  AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
               }
               n78CustomerTypeId = ((0==A78CustomerTypeId) ? true : false);
               AV27ComboCustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombocustomertypeid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27ComboCustomerTypeId", StringUtil.LTrimStr( (decimal)(AV27ComboCustomerTypeId), 4, 0));
               A93CustomerLastLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerLastLine_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Customer");
               A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
               forbiddenHiddens.Add("CustomerId", context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1CustomerId != Z1CustomerId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("customer:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
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
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CUSTOMERID");
                        AnyError = 1;
                        GX_FocusControl = edtCustomerId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "AFTER TRN") == 0 ) )
                        {
                           nGXsfl_78_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
                           SubsflControlProps_782( ) ;
                           if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerManagerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerManagerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
                           {
                              GXCCtl = "CUSTOMERMANAGERID_" + sGXsfl_78_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtCustomerManagerId_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A15CustomerManagerId = 0;
                           }
                           else
                           {
                              A15CustomerManagerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerManagerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           }
                           A16CustomerManagerGivenName = cgiGet( edtCustomerManagerGivenName_Internalname);
                           A9CustomerManagerLastName = cgiGet( edtCustomerManagerLastName_Internalname);
                           A17CustomerManagerInitials = cgiGet( edtCustomerManagerInitials_Internalname);
                           n17CustomerManagerInitials = false;
                           n17CustomerManagerInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A17CustomerManagerInitials)) ? true : false);
                           A10CustomerManagerEmail = cgiGet( edtCustomerManagerEmail_Internalname);
                           A11CustomerManagerPhone = cgiGet( edtCustomerManagerPhone_Internalname);
                           n11CustomerManagerPhone = false;
                           n11CustomerManagerPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A11CustomerManagerPhone)) ? true : false);
                           cmbCustomerManagerGender.Name = cmbCustomerManagerGender_Internalname;
                           cmbCustomerManagerGender.CurrentValue = cgiGet( cmbCustomerManagerGender_Internalname);
                           A12CustomerManagerGender = cgiGet( cmbCustomerManagerGender_Internalname);
                           n12CustomerManagerGender = false;
                           n12CustomerManagerGender = (String.IsNullOrEmpty(StringUtil.RTrim( A12CustomerManagerGender)) ? true : false);
                           A13CustomerManagerGAMGUID = cgiGet( edtCustomerManagerGAMGUID_Internalname);
                           GXCCtl = "Z15CustomerManagerId_" + sGXsfl_78_idx;
                           Z15CustomerManagerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "Z13CustomerManagerGAMGUID_" + sGXsfl_78_idx;
                           Z13CustomerManagerGAMGUID = cgiGet( GXCCtl);
                           GXCCtl = "Z17CustomerManagerInitials_" + sGXsfl_78_idx;
                           Z17CustomerManagerInitials = cgiGet( GXCCtl);
                           n17CustomerManagerInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A17CustomerManagerInitials)) ? true : false);
                           GXCCtl = "Z16CustomerManagerGivenName_" + sGXsfl_78_idx;
                           Z16CustomerManagerGivenName = cgiGet( GXCCtl);
                           GXCCtl = "Z9CustomerManagerLastName_" + sGXsfl_78_idx;
                           Z9CustomerManagerLastName = cgiGet( GXCCtl);
                           GXCCtl = "Z10CustomerManagerEmail_" + sGXsfl_78_idx;
                           Z10CustomerManagerEmail = cgiGet( GXCCtl);
                           GXCCtl = "Z11CustomerManagerPhone_" + sGXsfl_78_idx;
                           Z11CustomerManagerPhone = cgiGet( GXCCtl);
                           n11CustomerManagerPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A11CustomerManagerPhone)) ? true : false);
                           GXCCtl = "Z12CustomerManagerGender_" + sGXsfl_78_idx;
                           Z12CustomerManagerGender = cgiGet( GXCCtl);
                           n12CustomerManagerGender = (String.IsNullOrEmpty(StringUtil.RTrim( A12CustomerManagerGender)) ? true : false);
                           GXCCtl = "nRcdDeleted_2_" + sGXsfl_78_idx;
                           nRcdDeleted_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "nRcdExists_2_" + sGXsfl_78_idx;
                           nRcdExists_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "nIsMod_2_" + sGXsfl_78_idx;
                           nIsMod_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "vTABSACTIVEPAGE_" + sGXsfl_78_idx;
                           AV17TabsActivePage = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_78_idx;
                           AV15CheckRequiredFieldsResult = StringUtil.StrToBool( cgiGet( GXCCtl));
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E13012 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E14012 ();
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E14012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
            DisableAttributes011( ) ;
         }
         AssignProp("", false, edtavCombocustomertypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocustomertypeid_Enabled), 5, 0), true);
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode1 = Gx_mode;
            CONFIRM_012( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_013( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode1;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0121( )
      {
         nGXsfl_168_idx = 0;
         while ( nGXsfl_168_idx < nRC_GXsfl_168 )
         {
            ReadRow0121( ) ;
            if ( ( nRcdExists_21 != 0 ) || ( nIsMod_21 != 0 ) )
            {
               GetKey0121( ) ;
               if ( ( nRcdExists_21 == 0 ) && ( nRcdDeleted_21 == 0 ) )
               {
                  if ( RcdFound21 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0121( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0121( ) ;
                        CloseExtendedTableCursors0121( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCustomerLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound21 != 0 )
                  {
                     if ( nRcdDeleted_21 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0121( ) ;
                        Load0121( ) ;
                        BeforeValidate0121( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0121( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_21 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0121( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0121( ) ;
                              CloseExtendedTableCursors0121( ) ;
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
                     if ( nRcdDeleted_21 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAmenitiesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtAmenitiesTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtAmenitiesTypeName_Internalname, A100AmenitiesTypeName) ;
            ChangePostValue( "ZT_"+"Z98AmenitiesId_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_21_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_21), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_21_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_21), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_21_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_21), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_21 != 0 )
            {
               ChangePostValue( "AMENITIESID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AMENITIESID_"+sGXsfl_168_idx+"Horizontalalignment", StringUtil.RTrim( edtAmenitiesId_Horizontalalignment)) ;
               ChangePostValue( "AMENITIESTYPEID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AMENITIESTYPENAME_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesTypeName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0117( )
      {
         nGXsfl_156_idx = 0;
         while ( nGXsfl_156_idx < nRC_GXsfl_156 )
         {
            ReadRow0117( ) ;
            if ( ( nRcdExists_17 != 0 ) || ( nIsMod_17 != 0 ) )
            {
               GetKey0117( ) ;
               if ( ( nRcdExists_17 == 0 ) && ( nRcdDeleted_17 == 0 ) )
               {
                  if ( RcdFound17 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0117( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0117( ) ;
                        CloseExtendedTableCursors0117( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCustomerLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound17 != 0 )
                  {
                     if ( nRcdDeleted_17 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0117( ) ;
                        Load0117( ) ;
                        BeforeValidate0117( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0117( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_17 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0117( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0117( ) ;
                              CloseExtendedTableCursors0117( ) ;
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
                     if ( nRcdDeleted_17 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSupplier_GenId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtSupplier_GenCompanyName_Internalname, A66Supplier_GenCompanyName) ;
            ChangePostValue( edtSupplier_GenVisitingAddress_Internalname, A67Supplier_GenVisitingAddress) ;
            ChangePostValue( edtSupplier_GenPostalAddress_Internalname, A68Supplier_GenPostalAddress) ;
            ChangePostValue( edtSupplier_GenContactName_Internalname, A69Supplier_GenContactName) ;
            ChangePostValue( edtSupplier_GenContactPhone_Internalname, StringUtil.RTrim( A70Supplier_GenContactPhone)) ;
            ChangePostValue( "ZT_"+"Z64Supplier_GenId_"+sGXsfl_156_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_17_"+sGXsfl_156_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_17), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_17_"+sGXsfl_156_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_17), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_17_"+sGXsfl_156_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_17), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_17 != 0 )
            {
               ChangePostValue( "SUPPLIER_GENID_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENID_"+sGXsfl_156_idx+"Horizontalalignment", StringUtil.RTrim( edtSupplier_GenId_Horizontalalignment)) ;
               ChangePostValue( "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenCompanyName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenVisitingAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenPostalAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENCONTACTNAME_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENCONTACTPHONE_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactPhone_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0116( )
      {
         nGXsfl_143_idx = 0;
         while ( nGXsfl_143_idx < nRC_GXsfl_143 )
         {
            ReadRow0116( ) ;
            if ( ( nRcdExists_16 != 0 ) || ( nIsMod_16 != 0 ) )
            {
               GetKey0116( ) ;
               if ( ( nRcdExists_16 == 0 ) && ( nRcdDeleted_16 == 0 ) )
               {
                  if ( RcdFound16 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0116( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0116( ) ;
                        CloseExtendedTableCursors0116( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCustomerLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound16 != 0 )
                  {
                     if ( nRcdDeleted_16 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0116( ) ;
                        Load0116( ) ;
                        BeforeValidate0116( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0116( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0116( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0116( ) ;
                              CloseExtendedTableCursors0116( ) ;
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
                     if ( nRcdDeleted_16 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSupplier_AgbId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtSupplier_AgbName_Internalname, A57Supplier_AgbName) ;
            ChangePostValue( edtSupplier_AgbKvkNumber_Internalname, A58Supplier_AgbKvkNumber) ;
            ChangePostValue( edtSupplier_AgbVisitingAddress_Internalname, A59Supplier_AgbVisitingAddress) ;
            ChangePostValue( edtSupplier_AgbPostalAddress_Internalname, A60Supplier_AgbPostalAddress) ;
            ChangePostValue( edtSupplier_AgbEmail_Internalname, A61Supplier_AgbEmail) ;
            ChangePostValue( edtSupplier_AgbPhone_Internalname, StringUtil.RTrim( A62Supplier_AgbPhone)) ;
            ChangePostValue( edtSupplier_AgbContactName_Internalname, A63Supplier_AgbContactName) ;
            ChangePostValue( "ZT_"+"Z55Supplier_AgbId_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_16_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_16_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_16_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_16 != 0 )
            {
               ChangePostValue( "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Horizontalalignment", StringUtil.RTrim( edtSupplier_AgbId_Horizontalalignment)) ;
               ChangePostValue( "SUPPLIER_AGBNAME_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbKvkNumber_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbVisitingAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPostalAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBEMAIL_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBPHONE_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBCONTACTNAME_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbContactName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_014( )
      {
         s94CustomerLocationLastLine = O94CustomerLocationLastLine;
         AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
         nGXsfl_129_idx = 0;
         while ( nGXsfl_129_idx < nRC_GXsfl_129 )
         {
            ReadRow014( ) ;
            if ( ( nRcdExists_4 != 0 ) || ( nIsMod_4 != 0 ) )
            {
               GetKey014( ) ;
               if ( ( nRcdExists_4 == 0 ) && ( nRcdDeleted_4 == 0 ) )
               {
                  if ( RcdFound4 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate014( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable014( ) ;
                        CloseExtendedTableCursors014( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O94CustomerLocationLastLine = A94CustomerLocationLastLine;
                        AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCustomerLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound4 != 0 )
                  {
                     if ( nRcdDeleted_4 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey014( ) ;
                        Load014( ) ;
                        BeforeValidate014( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls014( ) ;
                           O94CustomerLocationLastLine = A94CustomerLocationLastLine;
                           AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_4 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate014( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable014( ) ;
                              CloseExtendedTableCursors014( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O94CustomerLocationLastLine = A94CustomerLocationLastLine;
                              AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_4 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCustomerLocationReceptionistId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23CustomerLocationReceptionistId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCustomerLocationReceptionistGi_Internalname, A24CustomerLocationReceptionistGi) ;
            ChangePostValue( edtCustomerLocationReceptionistLa_Internalname, A25CustomerLocationReceptionistLa) ;
            ChangePostValue( edtCustomerLocationReceptionistIn_Internalname, StringUtil.RTrim( A26CustomerLocationReceptionistIn)) ;
            ChangePostValue( edtCustomerLocationReceptionistEm_Internalname, A27CustomerLocationReceptionistEm) ;
            ChangePostValue( edtCustomerLocationReceptionistAd_Internalname, A28CustomerLocationReceptionistAd) ;
            ChangePostValue( edtCustomerLocationReceptionistPh_Internalname, StringUtil.RTrim( A29CustomerLocationReceptionistPh)) ;
            ChangePostValue( edtCustomerLocationReceptionistGA_Internalname, A30CustomerLocationReceptionistGA) ;
            ChangePostValue( "ZT_"+"Z23CustomerLocationReceptionistId_"+sGXsfl_129_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23CustomerLocationReceptionistId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z30CustomerLocationReceptionistGA_"+sGXsfl_129_idx, Z30CustomerLocationReceptionistGA) ;
            ChangePostValue( "ZT_"+"Z26CustomerLocationReceptionistIn_"+sGXsfl_129_idx, StringUtil.RTrim( Z26CustomerLocationReceptionistIn)) ;
            ChangePostValue( "ZT_"+"Z24CustomerLocationReceptionistGi_"+sGXsfl_129_idx, Z24CustomerLocationReceptionistGi) ;
            ChangePostValue( "ZT_"+"Z25CustomerLocationReceptionistLa_"+sGXsfl_129_idx, Z25CustomerLocationReceptionistLa) ;
            ChangePostValue( "ZT_"+"Z27CustomerLocationReceptionistEm_"+sGXsfl_129_idx, Z27CustomerLocationReceptionistEm) ;
            ChangePostValue( "ZT_"+"Z28CustomerLocationReceptionistAd_"+sGXsfl_129_idx, Z28CustomerLocationReceptionistAd) ;
            ChangePostValue( "ZT_"+"Z29CustomerLocationReceptionistPh_"+sGXsfl_129_idx, StringUtil.RTrim( Z29CustomerLocationReceptionistPh)) ;
            ChangePostValue( "nRcdDeleted_4_"+sGXsfl_129_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_4), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_4_"+sGXsfl_129_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_4), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_4_"+sGXsfl_129_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_4), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_4 != 0 )
            {
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTID_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTGI_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistGi_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTLA_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistLa_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTIN_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistIn_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTEM_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistEm_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTAD_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistAd_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTPH_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistPh_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTGA_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistGA_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O94CustomerLocationLastLine = s94CustomerLocationLastLine;
         AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_013( )
      {
         s95CustomerLastLineLocation = O95CustomerLastLineLocation;
         AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         nGXsfl_97_idx = 0;
         while ( nGXsfl_97_idx < nRC_GXsfl_97 )
         {
            ReadRow013( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               GetKey013( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate013( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable013( ) ;
                        CloseExtendedTableCursors013( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Save parent mode. */
                           sMode3 = Gx_mode;
                           CONFIRM_014( ) ;
                           if ( AnyError == 0 )
                           {
                              CONFIRM_0116( ) ;
                              if ( AnyError == 0 )
                              {
                                 CONFIRM_0117( ) ;
                                 if ( AnyError == 0 )
                                 {
                                    CONFIRM_0121( ) ;
                                    if ( AnyError == 0 )
                                    {
                                       /* Restore parent mode. */
                                       Gx_mode = sMode3;
                                       AssignAttri("", false, "Gx_mode", Gx_mode);
                                       IsConfirmed = 1;
                                       AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                                    }
                                 }
                              }
                           }
                           /* Restore parent mode. */
                           Gx_mode = sMode3;
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        O95CustomerLastLineLocation = A95CustomerLastLineLocation;
                        AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCustomerLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( nRcdDeleted_3 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey013( ) ;
                        Load013( ) ;
                        BeforeValidate013( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls013( ) ;
                           O95CustomerLastLineLocation = A95CustomerLastLineLocation;
                           AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate013( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable013( ) ;
                              CloseExtendedTableCursors013( ) ;
                              if ( AnyError == 0 )
                              {
                                 /* Save parent mode. */
                                 sMode3 = Gx_mode;
                                 CONFIRM_014( ) ;
                                 if ( AnyError == 0 )
                                 {
                                    CONFIRM_0116( ) ;
                                    if ( AnyError == 0 )
                                    {
                                       CONFIRM_0117( ) ;
                                       if ( AnyError == 0 )
                                       {
                                          CONFIRM_0121( ) ;
                                          if ( AnyError == 0 )
                                          {
                                             /* Restore parent mode. */
                                             Gx_mode = sMode3;
                                             AssignAttri("", false, "Gx_mode", Gx_mode);
                                             IsConfirmed = 1;
                                             AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                                          }
                                       }
                                    }
                                 }
                                 /* Restore parent mode. */
                                 Gx_mode = sMode3;
                                 AssignAttri("", false, "Gx_mode", Gx_mode);
                              }
                              O95CustomerLastLineLocation = A95CustomerLastLineLocation;
                              AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCustomerLocationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCustomerLocationVisitingAddres_Internalname, A19CustomerLocationVisitingAddres) ;
            ChangePostValue( edtCustomerLocationPostalAddress_Internalname, A20CustomerLocationPostalAddress) ;
            ChangePostValue( edtCustomerLocationEmail_Internalname, A21CustomerLocationEmail) ;
            ChangePostValue( edtCustomerLocationPhone_Internalname, StringUtil.RTrim( A22CustomerLocationPhone)) ;
            ChangePostValue( "ZT_"+"Z18CustomerLocationId_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z19CustomerLocationVisitingAddres_"+sGXsfl_97_idx, Z19CustomerLocationVisitingAddres) ;
            ChangePostValue( "ZT_"+"Z20CustomerLocationPostalAddress_"+sGXsfl_97_idx, Z20CustomerLocationPostalAddress) ;
            ChangePostValue( "ZT_"+"Z21CustomerLocationEmail_"+sGXsfl_97_idx, Z21CustomerLocationEmail) ;
            ChangePostValue( "ZT_"+"Z22CustomerLocationPhone_"+sGXsfl_97_idx, StringUtil.RTrim( Z22CustomerLocationPhone)) ;
            ChangePostValue( "ZT_"+"Z94CustomerLocationLastLine_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z94CustomerLocationLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z133CustomerLocationDescription_"+sGXsfl_97_idx, Z133CustomerLocationDescription) ;
            ChangePostValue( "ZT_"+"Z134CustomerLocationName_"+sGXsfl_97_idx, Z134CustomerLocationName) ;
            ChangePostValue( "T94CustomerLocationLastLine_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(O94CustomerLocationLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRC_GXsfl_129_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_129), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRC_GXsfl_143_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_143), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRC_GXsfl_156_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_156), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRC_GXsfl_168_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_168), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "CUSTOMERLOCATIONID_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONVISITINGADDRES_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationVisitingAddres_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONPOSTALADDRESS_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationPostalAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONEMAIL_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONPHONE_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationPhone_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O95CustomerLastLineLocation = s95CustomerLastLineLocation;
         AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_012( )
      {
         s93CustomerLastLine = O93CustomerLastLine;
         AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            ReadRow012( ) ;
            if ( ( nRcdExists_2 != 0 ) || ( nIsMod_2 != 0 ) )
            {
               GetKey012( ) ;
               if ( ( nRcdExists_2 == 0 ) && ( nRcdDeleted_2 == 0 ) )
               {
                  if ( RcdFound2 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate012( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable012( ) ;
                        CloseExtendedTableCursors012( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O93CustomerLastLine = A93CustomerLastLine;
                        AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "CUSTOMERMANAGERID_" + sGXsfl_78_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCustomerManagerId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound2 != 0 )
                  {
                     if ( nRcdDeleted_2 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey012( ) ;
                        Load012( ) ;
                        BeforeValidate012( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls012( ) ;
                           O93CustomerLastLine = A93CustomerLastLine;
                           AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_2 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate012( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable012( ) ;
                              CloseExtendedTableCursors012( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O93CustomerLastLine = A93CustomerLastLine;
                              AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_2 == 0 )
                     {
                        GXCCtl = "CUSTOMERMANAGERID_" + sGXsfl_78_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerManagerId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCustomerManagerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCustomerManagerGivenName_Internalname, A16CustomerManagerGivenName) ;
            ChangePostValue( edtCustomerManagerLastName_Internalname, A9CustomerManagerLastName) ;
            ChangePostValue( edtCustomerManagerInitials_Internalname, StringUtil.RTrim( A17CustomerManagerInitials)) ;
            ChangePostValue( edtCustomerManagerEmail_Internalname, A10CustomerManagerEmail) ;
            ChangePostValue( edtCustomerManagerPhone_Internalname, StringUtil.RTrim( A11CustomerManagerPhone)) ;
            ChangePostValue( cmbCustomerManagerGender_Internalname, StringUtil.RTrim( A12CustomerManagerGender)) ;
            ChangePostValue( edtCustomerManagerGAMGUID_Internalname, A13CustomerManagerGAMGUID) ;
            ChangePostValue( "ZT_"+"Z15CustomerManagerId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15CustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z13CustomerManagerGAMGUID_"+sGXsfl_78_idx, Z13CustomerManagerGAMGUID) ;
            ChangePostValue( "ZT_"+"Z17CustomerManagerInitials_"+sGXsfl_78_idx, StringUtil.RTrim( Z17CustomerManagerInitials)) ;
            ChangePostValue( "ZT_"+"Z16CustomerManagerGivenName_"+sGXsfl_78_idx, Z16CustomerManagerGivenName) ;
            ChangePostValue( "ZT_"+"Z9CustomerManagerLastName_"+sGXsfl_78_idx, Z9CustomerManagerLastName) ;
            ChangePostValue( "ZT_"+"Z10CustomerManagerEmail_"+sGXsfl_78_idx, Z10CustomerManagerEmail) ;
            ChangePostValue( "ZT_"+"Z11CustomerManagerPhone_"+sGXsfl_78_idx, StringUtil.RTrim( Z11CustomerManagerPhone)) ;
            ChangePostValue( "ZT_"+"Z12CustomerManagerGender_"+sGXsfl_78_idx, StringUtil.RTrim( Z12CustomerManagerGender)) ;
            ChangePostValue( "nRcdDeleted_2_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_2), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_2_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_2), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_2_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_2), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_2 != 0 )
            {
               ChangePostValue( "CUSTOMERMANAGERID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERGIVENNAME_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerGivenName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERLASTNAME_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerLastName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERINITIALS_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerInitials_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGEREMAIL_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERPHONE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERGENDER_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCustomerManagerGender.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERGAMGUID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerGAMGUID_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O93CustomerLastLine = s93CustomerLastLine;
         AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption010( )
      {
      }

      protected void E13012( )
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
         Combo_amenitiesid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_amenitiesid.SendProperty(context, "", false, Combo_amenitiesid_Internalname, "GAMOAuthToken", Combo_amenitiesid_Gamoauthtoken);
         Combo_amenitiesid_Titlecontrolidtoreplace = edtAmenitiesId_Internalname;
         ucCombo_amenitiesid.SendProperty(context, "", false, Combo_amenitiesid_Internalname, "TitleControlIdToReplace", Combo_amenitiesid_Titlecontrolidtoreplace);
         edtAmenitiesId_Horizontalalignment = "Left";
         AssignProp("", false, edtAmenitiesId_Internalname, "Horizontalalignment", edtAmenitiesId_Horizontalalignment, !bGXsfl_168_Refreshing);
         Combo_supplier_genid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_supplier_genid.SendProperty(context, "", false, Combo_supplier_genid_Internalname, "GAMOAuthToken", Combo_supplier_genid_Gamoauthtoken);
         Combo_supplier_genid_Titlecontrolidtoreplace = edtSupplier_GenId_Internalname;
         ucCombo_supplier_genid.SendProperty(context, "", false, Combo_supplier_genid_Internalname, "TitleControlIdToReplace", Combo_supplier_genid_Titlecontrolidtoreplace);
         edtSupplier_GenId_Horizontalalignment = "Left";
         AssignProp("", false, edtSupplier_GenId_Internalname, "Horizontalalignment", edtSupplier_GenId_Horizontalalignment, !bGXsfl_156_Refreshing);
         Combo_supplier_agbid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_supplier_agbid.SendProperty(context, "", false, Combo_supplier_agbid_Internalname, "GAMOAuthToken", Combo_supplier_agbid_Gamoauthtoken);
         Combo_supplier_agbid_Titlecontrolidtoreplace = edtSupplier_AgbId_Internalname;
         ucCombo_supplier_agbid.SendProperty(context, "", false, Combo_supplier_agbid_Internalname, "TitleControlIdToReplace", Combo_supplier_agbid_Titlecontrolidtoreplace);
         edtSupplier_AgbId_Horizontalalignment = "Left";
         AssignProp("", false, edtSupplier_AgbId_Internalname, "Horizontalalignment", edtSupplier_AgbId_Horizontalalignment, !bGXsfl_143_Refreshing);
         Combo_customertypeid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_customertypeid.SendProperty(context, "", false, Combo_customertypeid_Internalname, "GAMOAuthToken", Combo_customertypeid_Gamoauthtoken);
         edtCustomerTypeId_Visible = 0;
         AssignProp("", false, edtCustomerTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerTypeId_Visible), 5, 0), true);
         AV27ComboCustomerTypeId = 0;
         AssignAttri("", false, "AV27ComboCustomerTypeId", StringUtil.LTrimStr( (decimal)(AV27ComboCustomerTypeId), 4, 0));
         edtavCombocustomertypeid_Visible = 0;
         AssignProp("", false, edtavCombocustomertypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocustomertypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCUSTOMERTYPEID' */
         S112 ();
         if ( returnInSub )
         {
            pr_default.close(15);
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV30Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV31GXV1 = 1;
            AssignAttri("", false, "AV31GXV1", StringUtil.LTrimStr( (decimal)(AV31GXV1), 8, 0));
            while ( AV31GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV31GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CustomerTypeId") == 0 )
               {
                  AV13Insert_CustomerTypeId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CustomerTypeId", StringUtil.LTrimStr( (decimal)(AV13Insert_CustomerTypeId), 4, 0));
                  if ( ! (0==AV13Insert_CustomerTypeId) )
                  {
                     AV27ComboCustomerTypeId = AV13Insert_CustomerTypeId;
                     AssignAttri("", false, "AV27ComboCustomerTypeId", StringUtil.LTrimStr( (decimal)(AV27ComboCustomerTypeId), 4, 0));
                     Combo_customertypeid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV27ComboCustomerTypeId), 4, 0));
                     ucCombo_customertypeid.SendProperty(context, "", false, Combo_customertypeid_Internalname, "SelectedValue_set", Combo_customertypeid_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new customerloaddvcombo(context ).execute(  "CustomerTypeId",  "GET",  false,  AV7CustomerId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_customertypeid_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_customertypeid.SendProperty(context, "", false, Combo_customertypeid_Internalname, "SelectedText_set", Combo_customertypeid_Selectedtext_set);
                     Combo_customertypeid_Enabled = false;
                     ucCombo_customertypeid.SendProperty(context, "", false, Combo_customertypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_customertypeid_Enabled));
                  }
               }
               AV31GXV1 = (int)(AV31GXV1+1);
               AssignAttri("", false, "AV31GXV1", StringUtil.LTrimStr( (decimal)(AV31GXV1), 8, 0));
            }
         }
         edtCustomerLastLine_Visible = 0;
         AssignProp("", false, edtCustomerLastLine_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerLastLine_Visible), 5, 0), true);
      }

      protected void E14012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("customerww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(15);
         returnInSub = true;
         if (true) return;
      }

      protected void S142( )
      {
         /* 'UPDATE WIZARD STEPS BUTTONS VISIBILITY' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            bttBtnwizardprevious_Visible = (((Gxuitabspanel_steps_Activepage!=1)) ? 1 : 0);
            AssignProp("", false, bttBtnwizardprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardprevious_Visible), 5, 0), true);
            bttBtntrn_cancel_Visible = (((Gxuitabspanel_steps_Activepage==1)) ? 1 : 0);
            AssignProp("", false, bttBtntrn_cancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_cancel_Visible), 5, 0), true);
            bttBtnwizardnext_Visible = (((Gxuitabspanel_steps_Activepage!=3)) ? 1 : 0);
            AssignProp("", false, bttBtnwizardnext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardnext_Visible), 5, 0), true);
            bttBtntrn_enter_Visible = (((Gxuitabspanel_steps_Activepage==3)) ? 1 : 0);
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
         /* 'CHECKREQUIREDFIELDS_TABLEVEL_MANAGER' Routine */
         returnInSub = false;
         AV15CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV15CheckRequiredFieldsResult", AV15CheckRequiredFieldsResult);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCUSTOMERTYPEID' Routine */
         returnInSub = false;
         GXt_char2 = AV22Combo_DataJson;
         new customerloaddvcombo(context ).execute(  "CustomerTypeId",  Gx_mode,  false,  AV7CustomerId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_customertypeid_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_customertypeid.SendProperty(context, "", false, Combo_customertypeid_Internalname, "SelectedValue_set", Combo_customertypeid_Selectedvalue_set);
         Combo_customertypeid_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_customertypeid.SendProperty(context, "", false, Combo_customertypeid_Internalname, "SelectedText_set", Combo_customertypeid_Selectedtext_set);
         AV27ComboCustomerTypeId = (short)(Math.Round(NumberUtil.Val( AV20ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV27ComboCustomerTypeId", StringUtil.LTrimStr( (decimal)(AV27ComboCustomerTypeId), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_customertypeid_Enabled = false;
            ucCombo_customertypeid.SendProperty(context, "", false, Combo_customertypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_customertypeid_Enabled));
         }
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z41CustomerKvkNumber = T000119_A41CustomerKvkNumber[0];
               Z3CustomerName = T000119_A3CustomerName[0];
               Z4CustomerPostalAddress = T000119_A4CustomerPostalAddress[0];
               Z5CustomerEmail = T000119_A5CustomerEmail[0];
               Z6CustomerVisitingAddress = T000119_A6CustomerVisitingAddress[0];
               Z7CustomerPhone = T000119_A7CustomerPhone[0];
               Z14CustomerVatNumber = T000119_A14CustomerVatNumber[0];
               Z93CustomerLastLine = T000119_A93CustomerLastLine[0];
               Z95CustomerLastLineLocation = T000119_A95CustomerLastLineLocation[0];
               Z78CustomerTypeId = T000119_A78CustomerTypeId[0];
            }
            else
            {
               Z41CustomerKvkNumber = A41CustomerKvkNumber;
               Z3CustomerName = A3CustomerName;
               Z4CustomerPostalAddress = A4CustomerPostalAddress;
               Z5CustomerEmail = A5CustomerEmail;
               Z6CustomerVisitingAddress = A6CustomerVisitingAddress;
               Z7CustomerPhone = A7CustomerPhone;
               Z14CustomerVatNumber = A14CustomerVatNumber;
               Z93CustomerLastLine = A93CustomerLastLine;
               Z95CustomerLastLineLocation = A95CustomerLastLineLocation;
               Z78CustomerTypeId = A78CustomerTypeId;
            }
         }
         if ( GX_JID == -27 )
         {
            Z1CustomerId = A1CustomerId;
            Z41CustomerKvkNumber = A41CustomerKvkNumber;
            Z3CustomerName = A3CustomerName;
            Z4CustomerPostalAddress = A4CustomerPostalAddress;
            Z5CustomerEmail = A5CustomerEmail;
            Z6CustomerVisitingAddress = A6CustomerVisitingAddress;
            Z7CustomerPhone = A7CustomerPhone;
            Z14CustomerVatNumber = A14CustomerVatNumber;
            Z93CustomerLastLine = A93CustomerLastLine;
            Z95CustomerLastLineLocation = A95CustomerLastLineLocation;
            Z78CustomerTypeId = A78CustomerTypeId;
            Z79CustomerTypeName = A79CustomerTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerLastLine_Enabled = 0;
         AssignProp("", false, edtCustomerLastLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLastLine_Enabled), 5, 0), true);
         AV30Pgmname = "Customer";
         AssignAttri("", false, "AV30Pgmname", AV30Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerLastLine_Enabled = 0;
         AssignProp("", false, edtCustomerLastLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLastLine_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CustomerId) )
         {
            A1CustomerId = AV7CustomerId;
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CustomerTypeId) )
         {
            edtCustomerTypeId_Enabled = 0;
            AssignProp("", false, edtCustomerTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtCustomerTypeId_Enabled = 1;
            AssignProp("", false, edtCustomerTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerTypeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CustomerTypeId) )
         {
            A78CustomerTypeId = AV13Insert_CustomerTypeId;
            n78CustomerTypeId = false;
            AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
         }
         else
         {
            if ( (0==AV27ComboCustomerTypeId) )
            {
               A78CustomerTypeId = 0;
               n78CustomerTypeId = false;
               AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
               n78CustomerTypeId = true;
               AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
            }
            else
            {
               if ( ! (0==AV27ComboCustomerTypeId) )
               {
                  A78CustomerTypeId = AV27ComboCustomerTypeId;
                  n78CustomerTypeId = false;
                  AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
               }
            }
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
            /* Using cursor T000120 */
            pr_default.execute(18, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
            A79CustomerTypeName = T000120_A79CustomerTypeName[0];
            pr_default.close(18);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T000121 */
         pr_default.execute(19, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound1 = 1;
            A41CustomerKvkNumber = T000121_A41CustomerKvkNumber[0];
            AssignAttri("", false, "A41CustomerKvkNumber", A41CustomerKvkNumber);
            A3CustomerName = T000121_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            A4CustomerPostalAddress = T000121_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = T000121_n4CustomerPostalAddress[0];
            AssignAttri("", false, "A4CustomerPostalAddress", A4CustomerPostalAddress);
            A5CustomerEmail = T000121_A5CustomerEmail[0];
            n5CustomerEmail = T000121_n5CustomerEmail[0];
            AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
            A6CustomerVisitingAddress = T000121_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = T000121_n6CustomerVisitingAddress[0];
            AssignAttri("", false, "A6CustomerVisitingAddress", A6CustomerVisitingAddress);
            A7CustomerPhone = T000121_A7CustomerPhone[0];
            n7CustomerPhone = T000121_n7CustomerPhone[0];
            AssignAttri("", false, "A7CustomerPhone", A7CustomerPhone);
            A14CustomerVatNumber = T000121_A14CustomerVatNumber[0];
            AssignAttri("", false, "A14CustomerVatNumber", A14CustomerVatNumber);
            A79CustomerTypeName = T000121_A79CustomerTypeName[0];
            A93CustomerLastLine = T000121_A93CustomerLastLine[0];
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            A95CustomerLastLineLocation = T000121_A95CustomerLastLineLocation[0];
            A78CustomerTypeId = T000121_A78CustomerTypeId[0];
            n78CustomerTypeId = T000121_n78CustomerTypeId[0];
            AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
            ZM011( -27) ;
         }
         pr_default.close(19);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A5CustomerEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A5CustomerEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Customer Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "CUSTOMEREMAIL");
            AnyError = 1;
            GX_FocusControl = edtCustomerEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000120 */
         pr_default.execute(18, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A78CustomerTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERTYPEID");
               AnyError = 1;
               GX_FocusControl = edtCustomerTypeId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A79CustomerTypeName = T000120_A79CustomerTypeName[0];
         pr_default.close(18);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(18);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_28( short A78CustomerTypeId )
      {
         /* Using cursor T000122 */
         pr_default.execute(20, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A78CustomerTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERTYPEID");
               AnyError = 1;
               GX_FocusControl = edtCustomerTypeId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A79CustomerTypeName = T000122_A79CustomerTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A79CustomerTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey011( )
      {
         /* Using cursor T000123 */
         pr_default.execute(21, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000119 */
         pr_default.execute(17, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            ZM011( 27) ;
            RcdFound1 = 1;
            A1CustomerId = T000119_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A41CustomerKvkNumber = T000119_A41CustomerKvkNumber[0];
            AssignAttri("", false, "A41CustomerKvkNumber", A41CustomerKvkNumber);
            A3CustomerName = T000119_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            A4CustomerPostalAddress = T000119_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = T000119_n4CustomerPostalAddress[0];
            AssignAttri("", false, "A4CustomerPostalAddress", A4CustomerPostalAddress);
            A5CustomerEmail = T000119_A5CustomerEmail[0];
            n5CustomerEmail = T000119_n5CustomerEmail[0];
            AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
            A6CustomerVisitingAddress = T000119_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = T000119_n6CustomerVisitingAddress[0];
            AssignAttri("", false, "A6CustomerVisitingAddress", A6CustomerVisitingAddress);
            A7CustomerPhone = T000119_A7CustomerPhone[0];
            n7CustomerPhone = T000119_n7CustomerPhone[0];
            AssignAttri("", false, "A7CustomerPhone", A7CustomerPhone);
            A14CustomerVatNumber = T000119_A14CustomerVatNumber[0];
            AssignAttri("", false, "A14CustomerVatNumber", A14CustomerVatNumber);
            A93CustomerLastLine = T000119_A93CustomerLastLine[0];
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            A95CustomerLastLineLocation = T000119_A95CustomerLastLineLocation[0];
            A78CustomerTypeId = T000119_A78CustomerTypeId[0];
            n78CustomerTypeId = T000119_n78CustomerTypeId[0];
            AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
            O95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            O93CustomerLastLine = A93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            Z1CustomerId = A1CustomerId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(17);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T000124 */
         pr_default.execute(22, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( T000124_A1CustomerId[0] < A1CustomerId ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( T000124_A1CustomerId[0] > A1CustomerId ) ) )
            {
               A1CustomerId = T000124_A1CustomerId[0];
               AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T000125 */
         pr_default.execute(23, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( T000125_A1CustomerId[0] > A1CustomerId ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( T000125_A1CustomerId[0] < A1CustomerId ) ) )
            {
               A1CustomerId = T000125_A1CustomerId[0];
               AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A93CustomerLastLine = O93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            A95CustomerLastLineLocation = O95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            GX_FocusControl = edtCustomerKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1CustomerId != Z1CustomerId )
               {
                  A1CustomerId = Z1CustomerId;
                  AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CUSTOMERID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A93CustomerLastLine = O93CustomerLastLine;
                  AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
                  A95CustomerLastLineLocation = O95CustomerLastLineLocation;
                  AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCustomerKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A93CustomerLastLine = O93CustomerLastLine;
                  AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
                  A95CustomerLastLineLocation = O95CustomerLastLineLocation;
                  AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
                  Update011( ) ;
                  GX_FocusControl = edtCustomerKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1CustomerId != Z1CustomerId )
               {
                  /* Insert record */
                  A93CustomerLastLine = O93CustomerLastLine;
                  AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
                  A95CustomerLastLineLocation = O95CustomerLastLineLocation;
                  AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
                  GX_FocusControl = edtCustomerKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CUSTOMERID");
                     AnyError = 1;
                     GX_FocusControl = edtCustomerId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A93CustomerLastLine = O93CustomerLastLine;
                     AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
                     A95CustomerLastLineLocation = O95CustomerLastLineLocation;
                     AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
                     GX_FocusControl = edtCustomerKvkNumber_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( A1CustomerId != Z1CustomerId )
         {
            A1CustomerId = Z1CustomerId;
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A93CustomerLastLine = O93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            A95CustomerLastLineLocation = O95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCustomerKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000118 */
            pr_default.execute(16, new Object[] {A1CustomerId});
            if ( (pr_default.getStatus(16) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Customer"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(16) == 101) || ( StringUtil.StrCmp(Z41CustomerKvkNumber, T000118_A41CustomerKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z3CustomerName, T000118_A3CustomerName[0]) != 0 ) || ( StringUtil.StrCmp(Z4CustomerPostalAddress, T000118_A4CustomerPostalAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z5CustomerEmail, T000118_A5CustomerEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z6CustomerVisitingAddress, T000118_A6CustomerVisitingAddress[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z7CustomerPhone, T000118_A7CustomerPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z14CustomerVatNumber, T000118_A14CustomerVatNumber[0]) != 0 ) || ( Z93CustomerLastLine != T000118_A93CustomerLastLine[0] ) || ( Z95CustomerLastLineLocation != T000118_A95CustomerLastLineLocation[0] ) || ( Z78CustomerTypeId != T000118_A78CustomerTypeId[0] ) )
            {
               if ( StringUtil.StrCmp(Z41CustomerKvkNumber, T000118_A41CustomerKvkNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerKvkNumber");
                  GXUtil.WriteLogRaw("Old: ",Z41CustomerKvkNumber);
                  GXUtil.WriteLogRaw("Current: ",T000118_A41CustomerKvkNumber[0]);
               }
               if ( StringUtil.StrCmp(Z3CustomerName, T000118_A3CustomerName[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerName");
                  GXUtil.WriteLogRaw("Old: ",Z3CustomerName);
                  GXUtil.WriteLogRaw("Current: ",T000118_A3CustomerName[0]);
               }
               if ( StringUtil.StrCmp(Z4CustomerPostalAddress, T000118_A4CustomerPostalAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerPostalAddress");
                  GXUtil.WriteLogRaw("Old: ",Z4CustomerPostalAddress);
                  GXUtil.WriteLogRaw("Current: ",T000118_A4CustomerPostalAddress[0]);
               }
               if ( StringUtil.StrCmp(Z5CustomerEmail, T000118_A5CustomerEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerEmail");
                  GXUtil.WriteLogRaw("Old: ",Z5CustomerEmail);
                  GXUtil.WriteLogRaw("Current: ",T000118_A5CustomerEmail[0]);
               }
               if ( StringUtil.StrCmp(Z6CustomerVisitingAddress, T000118_A6CustomerVisitingAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerVisitingAddress");
                  GXUtil.WriteLogRaw("Old: ",Z6CustomerVisitingAddress);
                  GXUtil.WriteLogRaw("Current: ",T000118_A6CustomerVisitingAddress[0]);
               }
               if ( StringUtil.StrCmp(Z7CustomerPhone, T000118_A7CustomerPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerPhone");
                  GXUtil.WriteLogRaw("Old: ",Z7CustomerPhone);
                  GXUtil.WriteLogRaw("Current: ",T000118_A7CustomerPhone[0]);
               }
               if ( StringUtil.StrCmp(Z14CustomerVatNumber, T000118_A14CustomerVatNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerVatNumber");
                  GXUtil.WriteLogRaw("Old: ",Z14CustomerVatNumber);
                  GXUtil.WriteLogRaw("Current: ",T000118_A14CustomerVatNumber[0]);
               }
               if ( Z93CustomerLastLine != T000118_A93CustomerLastLine[0] )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLastLine");
                  GXUtil.WriteLogRaw("Old: ",Z93CustomerLastLine);
                  GXUtil.WriteLogRaw("Current: ",T000118_A93CustomerLastLine[0]);
               }
               if ( Z95CustomerLastLineLocation != T000118_A95CustomerLastLineLocation[0] )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLastLineLocation");
                  GXUtil.WriteLogRaw("Old: ",Z95CustomerLastLineLocation);
                  GXUtil.WriteLogRaw("Current: ",T000118_A95CustomerLastLineLocation[0]);
               }
               if ( Z78CustomerTypeId != T000118_A78CustomerTypeId[0] )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z78CustomerTypeId);
                  GXUtil.WriteLogRaw("Current: ",T000118_A78CustomerTypeId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Customer"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         if ( ! IsAuthorized("customer_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000126 */
                     pr_default.execute(24, new Object[] {A41CustomerKvkNumber, A3CustomerName, n4CustomerPostalAddress, A4CustomerPostalAddress, n5CustomerEmail, A5CustomerEmail, n6CustomerVisitingAddress, A6CustomerVisitingAddress, n7CustomerPhone, A7CustomerPhone, A14CustomerVatNumber, A93CustomerLastLine, A95CustomerLastLineLocation, n78CustomerTypeId, A78CustomerTypeId});
                     pr_default.close(24);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000127 */
                     pr_default.execute(25);
                     A1CustomerId = T000127_A1CustomerId[0];
                     AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("Customer");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         if ( ! IsAuthorized("customer_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000128 */
                     pr_default.execute(26, new Object[] {A41CustomerKvkNumber, A3CustomerName, n4CustomerPostalAddress, A4CustomerPostalAddress, n5CustomerEmail, A5CustomerEmail, n6CustomerVisitingAddress, A6CustomerVisitingAddress, n7CustomerPhone, A7CustomerPhone, A14CustomerVatNumber, A93CustomerLastLine, A95CustomerLastLineLocation, n78CustomerTypeId, A78CustomerTypeId, A1CustomerId});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("Customer");
                     if ( (pr_default.getStatus(26) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Customer"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("customer_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  A93CustomerLastLine = O93CustomerLastLine;
                  AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
                  ScanStart012( ) ;
                  while ( RcdFound2 != 0 )
                  {
                     getByPrimaryKey012( ) ;
                     Delete012( ) ;
                     ScanNext012( ) ;
                     O93CustomerLastLine = A93CustomerLastLine;
                     AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
                  }
                  ScanEnd012( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000129 */
                     pr_default.execute(27, new Object[] {A1CustomerId});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("Customer");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000130 */
            pr_default.execute(28, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
            A79CustomerTypeName = T000130_A79CustomerTypeName[0];
            pr_default.close(28);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000131 */
            pr_default.execute(29, new Object[] {A1CustomerId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "CustomerCustomization", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T000132 */
            pr_default.execute(30, new Object[] {A1CustomerId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Page", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T000133 */
            pr_default.execute(31, new Object[] {A1CustomerId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "CustomerLocation", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
         }
      }

      protected void ProcessNestedLevel012( )
      {
         s93CustomerLastLine = O93CustomerLastLine;
         AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            ReadRow012( ) ;
            if ( ( nRcdExists_2 != 0 ) || ( nIsMod_2 != 0 ) )
            {
               standaloneNotModal012( ) ;
               GetKey012( ) ;
               if ( ( nRcdExists_2 == 0 ) && ( nRcdDeleted_2 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert012( ) ;
               }
               else
               {
                  if ( RcdFound2 != 0 )
                  {
                     if ( ( nRcdDeleted_2 != 0 ) && ( nRcdExists_2 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete012( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_2 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update012( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_2 == 0 )
                     {
                        GXCCtl = "CUSTOMERMANAGERID_" + sGXsfl_78_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerManagerId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O93CustomerLastLine = A93CustomerLastLine;
               AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            }
            ChangePostValue( edtCustomerManagerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCustomerManagerGivenName_Internalname, A16CustomerManagerGivenName) ;
            ChangePostValue( edtCustomerManagerLastName_Internalname, A9CustomerManagerLastName) ;
            ChangePostValue( edtCustomerManagerInitials_Internalname, StringUtil.RTrim( A17CustomerManagerInitials)) ;
            ChangePostValue( edtCustomerManagerEmail_Internalname, A10CustomerManagerEmail) ;
            ChangePostValue( edtCustomerManagerPhone_Internalname, StringUtil.RTrim( A11CustomerManagerPhone)) ;
            ChangePostValue( cmbCustomerManagerGender_Internalname, StringUtil.RTrim( A12CustomerManagerGender)) ;
            ChangePostValue( edtCustomerManagerGAMGUID_Internalname, A13CustomerManagerGAMGUID) ;
            ChangePostValue( "ZT_"+"Z15CustomerManagerId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15CustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z13CustomerManagerGAMGUID_"+sGXsfl_78_idx, Z13CustomerManagerGAMGUID) ;
            ChangePostValue( "ZT_"+"Z17CustomerManagerInitials_"+sGXsfl_78_idx, StringUtil.RTrim( Z17CustomerManagerInitials)) ;
            ChangePostValue( "ZT_"+"Z16CustomerManagerGivenName_"+sGXsfl_78_idx, Z16CustomerManagerGivenName) ;
            ChangePostValue( "ZT_"+"Z9CustomerManagerLastName_"+sGXsfl_78_idx, Z9CustomerManagerLastName) ;
            ChangePostValue( "ZT_"+"Z10CustomerManagerEmail_"+sGXsfl_78_idx, Z10CustomerManagerEmail) ;
            ChangePostValue( "ZT_"+"Z11CustomerManagerPhone_"+sGXsfl_78_idx, StringUtil.RTrim( Z11CustomerManagerPhone)) ;
            ChangePostValue( "ZT_"+"Z12CustomerManagerGender_"+sGXsfl_78_idx, StringUtil.RTrim( Z12CustomerManagerGender)) ;
            ChangePostValue( "nRcdDeleted_2_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_2), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_2_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_2), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_2_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_2), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_2 != 0 )
            {
               ChangePostValue( "CUSTOMERMANAGERID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERGIVENNAME_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerGivenName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERLASTNAME_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerLastName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERINITIALS_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerInitials_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGEREMAIL_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERPHONE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERGENDER_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCustomerManagerGender.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERMANAGERGAMGUID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerGAMGUID_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll012( ) ;
         if ( AnyError != 0 )
         {
            O93CustomerLastLine = s93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         }
         nRcdExists_2 = 0;
         nIsMod_2 = 0;
         nRcdDeleted_2 = 0;
      }

      protected void ProcessNestedLevel013( )
      {
         s95CustomerLastLineLocation = O95CustomerLastLineLocation;
         AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         nGXsfl_97_idx = 0;
         while ( nGXsfl_97_idx < nRC_GXsfl_97 )
         {
            ReadRow013( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               standaloneNotModal013( ) ;
               GetKey013( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert013( ) ;
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( ( nRcdDeleted_3 != 0 ) && ( nRcdExists_3 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete013( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update013( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O95CustomerLastLineLocation = A95CustomerLastLineLocation;
               AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            }
            ChangePostValue( edtCustomerLocationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCustomerLocationVisitingAddres_Internalname, A19CustomerLocationVisitingAddres) ;
            ChangePostValue( edtCustomerLocationPostalAddress_Internalname, A20CustomerLocationPostalAddress) ;
            ChangePostValue( edtCustomerLocationEmail_Internalname, A21CustomerLocationEmail) ;
            ChangePostValue( edtCustomerLocationPhone_Internalname, StringUtil.RTrim( A22CustomerLocationPhone)) ;
            ChangePostValue( "ZT_"+"Z18CustomerLocationId_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z19CustomerLocationVisitingAddres_"+sGXsfl_97_idx, Z19CustomerLocationVisitingAddres) ;
            ChangePostValue( "ZT_"+"Z20CustomerLocationPostalAddress_"+sGXsfl_97_idx, Z20CustomerLocationPostalAddress) ;
            ChangePostValue( "ZT_"+"Z21CustomerLocationEmail_"+sGXsfl_97_idx, Z21CustomerLocationEmail) ;
            ChangePostValue( "ZT_"+"Z22CustomerLocationPhone_"+sGXsfl_97_idx, StringUtil.RTrim( Z22CustomerLocationPhone)) ;
            ChangePostValue( "ZT_"+"Z94CustomerLocationLastLine_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z94CustomerLocationLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z133CustomerLocationDescription_"+sGXsfl_97_idx, Z133CustomerLocationDescription) ;
            ChangePostValue( "ZT_"+"Z134CustomerLocationName_"+sGXsfl_97_idx, Z134CustomerLocationName) ;
            ChangePostValue( "T94CustomerLocationLastLine_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(O94CustomerLocationLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRC_GXsfl_129_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_129), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRC_GXsfl_143_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_143), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRC_GXsfl_156_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_156), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRC_GXsfl_168_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_168), 8, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_97_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "CUSTOMERLOCATIONID_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONVISITINGADDRES_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationVisitingAddres_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONPOSTALADDRESS_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationPostalAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONEMAIL_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONPHONE_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationPhone_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll013( ) ;
         if ( AnyError != 0 )
         {
            O95CustomerLastLineLocation = s95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         nRcdExists_3 = 0;
         nIsMod_3 = 0;
         nRcdDeleted_3 = 0;
      }

      protected void ProcessLevel011( )
      {
         /* Save parent mode. */
         sMode1 = Gx_mode;
         ProcessNestedLevel012( ) ;
         ProcessNestedLevel013( ) ;
         if ( AnyError != 0 )
         {
            O93CustomerLastLine = s93CustomerLastLine;
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
            O95CustomerLastLineLocation = s95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000134 */
         pr_default.execute(32, new Object[] {A95CustomerLastLineLocation, A93CustomerLastLine, A1CustomerId});
         pr_default.close(32);
         pr_default.SmartCacheProvider.SetUpdated("Customer");
      }

      protected void EndLevel011( )
      {
         pr_default.close(16);
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("customer",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("customer",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000135 */
         pr_default.execute(33);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound1 = 1;
            A1CustomerId = T000135_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound1 = 1;
            A1CustomerId = T000135_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerKvkNumber_Enabled = 0;
         AssignProp("", false, edtCustomerKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerKvkNumber_Enabled), 5, 0), true);
         edtCustomerName_Enabled = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), true);
         edtCustomerPostalAddress_Enabled = 0;
         AssignProp("", false, edtCustomerPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerPostalAddress_Enabled), 5, 0), true);
         edtCustomerEmail_Enabled = 0;
         AssignProp("", false, edtCustomerEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerEmail_Enabled), 5, 0), true);
         edtCustomerVisitingAddress_Enabled = 0;
         AssignProp("", false, edtCustomerVisitingAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerVisitingAddress_Enabled), 5, 0), true);
         edtCustomerPhone_Enabled = 0;
         AssignProp("", false, edtCustomerPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerPhone_Enabled), 5, 0), true);
         edtCustomerVatNumber_Enabled = 0;
         AssignProp("", false, edtCustomerVatNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerVatNumber_Enabled), 5, 0), true);
         edtCustomerTypeId_Enabled = 0;
         AssignProp("", false, edtCustomerTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerTypeId_Enabled), 5, 0), true);
         edtavCombocustomertypeid_Enabled = 0;
         AssignProp("", false, edtavCombocustomertypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocustomertypeid_Enabled), 5, 0), true);
         edtCustomerLastLine_Enabled = 0;
         AssignProp("", false, edtCustomerLastLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLastLine_Enabled), 5, 0), true);
      }

      protected void ZM012( short GX_JID )
      {
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z13CustomerManagerGAMGUID = T000117_A13CustomerManagerGAMGUID[0];
               Z17CustomerManagerInitials = T000117_A17CustomerManagerInitials[0];
               Z16CustomerManagerGivenName = T000117_A16CustomerManagerGivenName[0];
               Z9CustomerManagerLastName = T000117_A9CustomerManagerLastName[0];
               Z10CustomerManagerEmail = T000117_A10CustomerManagerEmail[0];
               Z11CustomerManagerPhone = T000117_A11CustomerManagerPhone[0];
               Z12CustomerManagerGender = T000117_A12CustomerManagerGender[0];
            }
            else
            {
               Z13CustomerManagerGAMGUID = A13CustomerManagerGAMGUID;
               Z17CustomerManagerInitials = A17CustomerManagerInitials;
               Z16CustomerManagerGivenName = A16CustomerManagerGivenName;
               Z9CustomerManagerLastName = A9CustomerManagerLastName;
               Z10CustomerManagerEmail = A10CustomerManagerEmail;
               Z11CustomerManagerPhone = A11CustomerManagerPhone;
               Z12CustomerManagerGender = A12CustomerManagerGender;
            }
         }
         if ( GX_JID == -29 )
         {
            Z1CustomerId = A1CustomerId;
            Z15CustomerManagerId = A15CustomerManagerId;
            Z13CustomerManagerGAMGUID = A13CustomerManagerGAMGUID;
            Z17CustomerManagerInitials = A17CustomerManagerInitials;
            Z16CustomerManagerGivenName = A16CustomerManagerGivenName;
            Z9CustomerManagerLastName = A9CustomerManagerLastName;
            Z10CustomerManagerEmail = A10CustomerManagerEmail;
            Z11CustomerManagerPhone = A11CustomerManagerPhone;
            Z12CustomerManagerGender = A12CustomerManagerGender;
         }
      }

      protected void standaloneNotModal012( )
      {
         edtCustomerLastLine_Enabled = 0;
         AssignProp("", false, edtCustomerLastLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLastLine_Enabled), 5, 0), true);
         edtCustomerLastLine_Enabled = 0;
         AssignProp("", false, edtCustomerLastLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLastLine_Enabled), 5, 0), true);
      }

      protected void standaloneModal012( )
      {
         if ( IsIns( )  )
         {
            A93CustomerLastLine = (short)(O93CustomerLastLine+1);
            AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A15CustomerManagerId = A93CustomerLastLine;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCustomerManagerId_Enabled = 0;
            AssignProp("", false, edtCustomerManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         }
         else
         {
            edtCustomerManagerId_Enabled = 1;
            AssignProp("", false, edtCustomerManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         }
      }

      protected void Load012( )
      {
         /* Using cursor T000136 */
         pr_default.execute(34, new Object[] {A1CustomerId, A15CustomerManagerId});
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound2 = 1;
            A13CustomerManagerGAMGUID = T000136_A13CustomerManagerGAMGUID[0];
            A17CustomerManagerInitials = T000136_A17CustomerManagerInitials[0];
            n17CustomerManagerInitials = T000136_n17CustomerManagerInitials[0];
            A16CustomerManagerGivenName = T000136_A16CustomerManagerGivenName[0];
            A9CustomerManagerLastName = T000136_A9CustomerManagerLastName[0];
            A10CustomerManagerEmail = T000136_A10CustomerManagerEmail[0];
            A11CustomerManagerPhone = T000136_A11CustomerManagerPhone[0];
            n11CustomerManagerPhone = T000136_n11CustomerManagerPhone[0];
            A12CustomerManagerGender = T000136_A12CustomerManagerGender[0];
            n12CustomerManagerGender = T000136_n12CustomerManagerGender[0];
            ZM012( -29) ;
         }
         pr_default.close(34);
         OnLoadActions012( ) ;
      }

      protected void OnLoadActions012( )
      {
      }

      protected void CheckExtendedTable012( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal012( ) ;
         new getnameinitials(context ).execute(  A16CustomerManagerGivenName,  A9CustomerManagerLastName, out  A17CustomerManagerInitials) ;
         n17CustomerManagerInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A17CustomerManagerInitials)) ? true : false);
         if ( ! ( GxRegex.IsMatch(A10CustomerManagerEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GXCCtl = "CUSTOMERMANAGEREMAIL_" + sGXsfl_78_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Customer Manager Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCustomerManagerEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A12CustomerManagerGender, "Man") == 0 ) || ( StringUtil.StrCmp(A12CustomerManagerGender, "Woman") == 0 ) || ( StringUtil.StrCmp(A12CustomerManagerGender, "Other") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A12CustomerManagerGender)) ) )
         {
            GXCCtl = "CUSTOMERMANAGERGENDER_" + sGXsfl_78_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Customer Manager Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbCustomerManagerGender_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors012( )
      {
      }

      protected void enableDisable012( )
      {
      }

      protected void GetKey012( )
      {
         /* Using cursor T000137 */
         pr_default.execute(35, new Object[] {A1CustomerId, A15CustomerManagerId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(35);
      }

      protected void getByPrimaryKey012( )
      {
         /* Using cursor T000117 */
         pr_default.execute(15, new Object[] {A1CustomerId, A15CustomerManagerId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            ZM012( 29) ;
            RcdFound2 = 1;
            InitializeNonKey012( ) ;
            A15CustomerManagerId = T000117_A15CustomerManagerId[0];
            A13CustomerManagerGAMGUID = T000117_A13CustomerManagerGAMGUID[0];
            A17CustomerManagerInitials = T000117_A17CustomerManagerInitials[0];
            n17CustomerManagerInitials = T000117_n17CustomerManagerInitials[0];
            A16CustomerManagerGivenName = T000117_A16CustomerManagerGivenName[0];
            A9CustomerManagerLastName = T000117_A9CustomerManagerLastName[0];
            A10CustomerManagerEmail = T000117_A10CustomerManagerEmail[0];
            A11CustomerManagerPhone = T000117_A11CustomerManagerPhone[0];
            n11CustomerManagerPhone = T000117_n11CustomerManagerPhone[0];
            A12CustomerManagerGender = T000117_A12CustomerManagerGender[0];
            n12CustomerManagerGender = T000117_n12CustomerManagerGender[0];
            Z1CustomerId = A1CustomerId;
            Z15CustomerManagerId = A15CustomerManagerId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load012( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey012( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal012( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes012( ) ;
         }
         pr_default.close(15);
      }

      protected void CheckOptimisticConcurrency012( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000116 */
            pr_default.execute(14, new Object[] {A1CustomerId, A15CustomerManagerId});
            if ( (pr_default.getStatus(14) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerManager"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(14) == 101) || ( StringUtil.StrCmp(Z13CustomerManagerGAMGUID, T000116_A13CustomerManagerGAMGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z17CustomerManagerInitials, T000116_A17CustomerManagerInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z16CustomerManagerGivenName, T000116_A16CustomerManagerGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z9CustomerManagerLastName, T000116_A9CustomerManagerLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z10CustomerManagerEmail, T000116_A10CustomerManagerEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z11CustomerManagerPhone, T000116_A11CustomerManagerPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z12CustomerManagerGender, T000116_A12CustomerManagerGender[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z13CustomerManagerGAMGUID, T000116_A13CustomerManagerGAMGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerManagerGAMGUID");
                  GXUtil.WriteLogRaw("Old: ",Z13CustomerManagerGAMGUID);
                  GXUtil.WriteLogRaw("Current: ",T000116_A13CustomerManagerGAMGUID[0]);
               }
               if ( StringUtil.StrCmp(Z17CustomerManagerInitials, T000116_A17CustomerManagerInitials[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerManagerInitials");
                  GXUtil.WriteLogRaw("Old: ",Z17CustomerManagerInitials);
                  GXUtil.WriteLogRaw("Current: ",T000116_A17CustomerManagerInitials[0]);
               }
               if ( StringUtil.StrCmp(Z16CustomerManagerGivenName, T000116_A16CustomerManagerGivenName[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerManagerGivenName");
                  GXUtil.WriteLogRaw("Old: ",Z16CustomerManagerGivenName);
                  GXUtil.WriteLogRaw("Current: ",T000116_A16CustomerManagerGivenName[0]);
               }
               if ( StringUtil.StrCmp(Z9CustomerManagerLastName, T000116_A9CustomerManagerLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerManagerLastName");
                  GXUtil.WriteLogRaw("Old: ",Z9CustomerManagerLastName);
                  GXUtil.WriteLogRaw("Current: ",T000116_A9CustomerManagerLastName[0]);
               }
               if ( StringUtil.StrCmp(Z10CustomerManagerEmail, T000116_A10CustomerManagerEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerManagerEmail");
                  GXUtil.WriteLogRaw("Old: ",Z10CustomerManagerEmail);
                  GXUtil.WriteLogRaw("Current: ",T000116_A10CustomerManagerEmail[0]);
               }
               if ( StringUtil.StrCmp(Z11CustomerManagerPhone, T000116_A11CustomerManagerPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerManagerPhone");
                  GXUtil.WriteLogRaw("Old: ",Z11CustomerManagerPhone);
                  GXUtil.WriteLogRaw("Current: ",T000116_A11CustomerManagerPhone[0]);
               }
               if ( StringUtil.StrCmp(Z12CustomerManagerGender, T000116_A12CustomerManagerGender[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerManagerGender");
                  GXUtil.WriteLogRaw("Old: ",Z12CustomerManagerGender);
                  GXUtil.WriteLogRaw("Current: ",T000116_A12CustomerManagerGender[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerManager"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert012( )
      {
         if ( ! IsAuthorized("customer_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate012( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable012( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM012( 0) ;
            CheckOptimisticConcurrency012( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm012( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert012( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000138 */
                     pr_default.execute(36, new Object[] {A1CustomerId, A15CustomerManagerId, A13CustomerManagerGAMGUID, n17CustomerManagerInitials, A17CustomerManagerInitials, A16CustomerManagerGivenName, A9CustomerManagerLastName, A10CustomerManagerEmail, n11CustomerManagerPhone, A11CustomerManagerPhone, n12CustomerManagerGender, A12CustomerManagerGender});
                     pr_default.close(36);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerManager");
                     if ( (pr_default.getStatus(36) == 1) )
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
               Load012( ) ;
            }
            EndLevel012( ) ;
         }
         CloseExtendedTableCursors012( ) ;
      }

      protected void Update012( )
      {
         if ( ! IsAuthorized("customer_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate012( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable012( ) ;
         }
         if ( ( nIsMod_2 != 0 ) || ( nIsDirty_2 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency012( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm012( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate012( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000139 */
                        pr_default.execute(37, new Object[] {A13CustomerManagerGAMGUID, n17CustomerManagerInitials, A17CustomerManagerInitials, A16CustomerManagerGivenName, A9CustomerManagerLastName, A10CustomerManagerEmail, n11CustomerManagerPhone, A11CustomerManagerPhone, n12CustomerManagerGender, A12CustomerManagerGender, A1CustomerId, A15CustomerManagerId});
                        pr_default.close(37);
                        pr_default.SmartCacheProvider.SetUpdated("CustomerManager");
                        if ( (pr_default.getStatus(37) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerManager"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate012( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey012( ) ;
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
               EndLevel012( ) ;
            }
         }
         CloseExtendedTableCursors012( ) ;
      }

      protected void DeferredUpdate012( )
      {
      }

      protected void Delete012( )
      {
         if ( ! IsAuthorized("customer_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate012( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency012( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls012( ) ;
            AfterConfirm012( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete012( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000140 */
                  pr_default.execute(38, new Object[] {A1CustomerId, A15CustomerManagerId});
                  pr_default.close(38);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerManager");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel012( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls012( )
      {
         standaloneModal012( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel012( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(14);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart012( )
      {
         /* Scan By routine */
         /* Using cursor T000141 */
         pr_default.execute(39, new Object[] {A1CustomerId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound2 = 1;
            A15CustomerManagerId = T000141_A15CustomerManagerId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext012( )
      {
         /* Scan next routine */
         pr_default.readNext(39);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound2 = 1;
            A15CustomerManagerId = T000141_A15CustomerManagerId[0];
         }
      }

      protected void ScanEnd012( )
      {
         pr_default.close(39);
      }

      protected void AfterConfirm012( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert012( )
      {
         /* Before Insert Rules */
         new createuseraccount(context ).execute(  A10CustomerManagerEmail,  A16CustomerManagerGivenName,  A9CustomerManagerLastName,  context.GetMessage( "Customer Manager", ""), out  A13CustomerManagerGAMGUID) ;
      }

      protected void BeforeUpdate012( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete012( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete012( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate012( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes012( )
      {
         edtCustomerManagerId_Enabled = 0;
         AssignProp("", false, edtCustomerManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtCustomerManagerGivenName_Enabled = 0;
         AssignProp("", false, edtCustomerManagerGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerGivenName_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtCustomerManagerLastName_Enabled = 0;
         AssignProp("", false, edtCustomerManagerLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerLastName_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtCustomerManagerInitials_Enabled = 0;
         AssignProp("", false, edtCustomerManagerInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerInitials_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtCustomerManagerEmail_Enabled = 0;
         AssignProp("", false, edtCustomerManagerEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerEmail_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtCustomerManagerPhone_Enabled = 0;
         AssignProp("", false, edtCustomerManagerPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerPhone_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         cmbCustomerManagerGender.Enabled = 0;
         AssignProp("", false, cmbCustomerManagerGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCustomerManagerGender.Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtCustomerManagerGAMGUID_Enabled = 0;
         AssignProp("", false, edtCustomerManagerGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerGAMGUID_Enabled), 5, 0), !bGXsfl_78_Refreshing);
      }

      protected void send_integrity_lvl_hashes012( )
      {
      }

      protected void ZM013( short GX_JID )
      {
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z19CustomerLocationVisitingAddres = T000115_A19CustomerLocationVisitingAddres[0];
               Z20CustomerLocationPostalAddress = T000115_A20CustomerLocationPostalAddress[0];
               Z21CustomerLocationEmail = T000115_A21CustomerLocationEmail[0];
               Z22CustomerLocationPhone = T000115_A22CustomerLocationPhone[0];
               Z94CustomerLocationLastLine = T000115_A94CustomerLocationLastLine[0];
               Z133CustomerLocationDescription = T000115_A133CustomerLocationDescription[0];
               Z134CustomerLocationName = T000115_A134CustomerLocationName[0];
            }
            else
            {
               Z19CustomerLocationVisitingAddres = A19CustomerLocationVisitingAddres;
               Z20CustomerLocationPostalAddress = A20CustomerLocationPostalAddress;
               Z21CustomerLocationEmail = A21CustomerLocationEmail;
               Z22CustomerLocationPhone = A22CustomerLocationPhone;
               Z94CustomerLocationLastLine = A94CustomerLocationLastLine;
               Z133CustomerLocationDescription = A133CustomerLocationDescription;
               Z134CustomerLocationName = A134CustomerLocationName;
            }
         }
         if ( GX_JID == -30 )
         {
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z19CustomerLocationVisitingAddres = A19CustomerLocationVisitingAddres;
            Z20CustomerLocationPostalAddress = A20CustomerLocationPostalAddress;
            Z21CustomerLocationEmail = A21CustomerLocationEmail;
            Z22CustomerLocationPhone = A22CustomerLocationPhone;
            Z94CustomerLocationLastLine = A94CustomerLocationLastLine;
            Z133CustomerLocationDescription = A133CustomerLocationDescription;
            Z134CustomerLocationName = A134CustomerLocationName;
         }
      }

      protected void standaloneNotModal013( )
      {
      }

      protected void standaloneModal013( )
      {
         if ( IsIns( )  )
         {
            A95CustomerLastLineLocation = (short)(O95CustomerLastLineLocation+1);
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A18CustomerLocationId = A95CustomerLastLineLocation;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCustomerLocationId_Enabled = 0;
            AssignProp("", false, edtCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationId_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         }
         else
         {
            edtCustomerLocationId_Enabled = 1;
            AssignProp("", false, edtCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationId_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         }
      }

      protected void Load013( )
      {
         /* Using cursor T000142 */
         pr_default.execute(40, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound3 = 1;
            A19CustomerLocationVisitingAddres = T000142_A19CustomerLocationVisitingAddres[0];
            A20CustomerLocationPostalAddress = T000142_A20CustomerLocationPostalAddress[0];
            A21CustomerLocationEmail = T000142_A21CustomerLocationEmail[0];
            A22CustomerLocationPhone = T000142_A22CustomerLocationPhone[0];
            A94CustomerLocationLastLine = T000142_A94CustomerLocationLastLine[0];
            A133CustomerLocationDescription = T000142_A133CustomerLocationDescription[0];
            A134CustomerLocationName = T000142_A134CustomerLocationName[0];
            ZM013( -30) ;
         }
         pr_default.close(40);
         OnLoadActions013( ) ;
      }

      protected void OnLoadActions013( )
      {
      }

      protected void CheckExtendedTable013( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal013( ) ;
         if ( ! ( GxRegex.IsMatch(A21CustomerLocationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GXCCtl = "CUSTOMERLOCATIONEMAIL_" + sGXsfl_97_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Customer Location Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCustomerLocationEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors013( )
      {
      }

      protected void enableDisable013( )
      {
      }

      protected void GetKey013( )
      {
         /* Using cursor T000143 */
         pr_default.execute(41, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(41);
      }

      protected void getByPrimaryKey013( )
      {
         /* Using cursor T000115 */
         pr_default.execute(13, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            ZM013( 30) ;
            RcdFound3 = 1;
            InitializeNonKey013( ) ;
            A18CustomerLocationId = T000115_A18CustomerLocationId[0];
            A19CustomerLocationVisitingAddres = T000115_A19CustomerLocationVisitingAddres[0];
            A20CustomerLocationPostalAddress = T000115_A20CustomerLocationPostalAddress[0];
            A21CustomerLocationEmail = T000115_A21CustomerLocationEmail[0];
            A22CustomerLocationPhone = T000115_A22CustomerLocationPhone[0];
            A94CustomerLocationLastLine = T000115_A94CustomerLocationLastLine[0];
            A133CustomerLocationDescription = T000115_A133CustomerLocationDescription[0];
            A134CustomerLocationName = T000115_A134CustomerLocationName[0];
            O94CustomerLocationLastLine = A94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load013( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey013( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal013( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes013( ) ;
         }
         pr_default.close(13);
      }

      protected void CheckOptimisticConcurrency013( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {A1CustomerId, A18CustomerLocationId});
            if ( (pr_default.getStatus(12) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocation"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(12) == 101) || ( StringUtil.StrCmp(Z19CustomerLocationVisitingAddres, T000114_A19CustomerLocationVisitingAddres[0]) != 0 ) || ( StringUtil.StrCmp(Z20CustomerLocationPostalAddress, T000114_A20CustomerLocationPostalAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z21CustomerLocationEmail, T000114_A21CustomerLocationEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z22CustomerLocationPhone, T000114_A22CustomerLocationPhone[0]) != 0 ) || ( Z94CustomerLocationLastLine != T000114_A94CustomerLocationLastLine[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z133CustomerLocationDescription, T000114_A133CustomerLocationDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z134CustomerLocationName, T000114_A134CustomerLocationName[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z19CustomerLocationVisitingAddres, T000114_A19CustomerLocationVisitingAddres[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationVisitingAddres");
                  GXUtil.WriteLogRaw("Old: ",Z19CustomerLocationVisitingAddres);
                  GXUtil.WriteLogRaw("Current: ",T000114_A19CustomerLocationVisitingAddres[0]);
               }
               if ( StringUtil.StrCmp(Z20CustomerLocationPostalAddress, T000114_A20CustomerLocationPostalAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationPostalAddress");
                  GXUtil.WriteLogRaw("Old: ",Z20CustomerLocationPostalAddress);
                  GXUtil.WriteLogRaw("Current: ",T000114_A20CustomerLocationPostalAddress[0]);
               }
               if ( StringUtil.StrCmp(Z21CustomerLocationEmail, T000114_A21CustomerLocationEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationEmail");
                  GXUtil.WriteLogRaw("Old: ",Z21CustomerLocationEmail);
                  GXUtil.WriteLogRaw("Current: ",T000114_A21CustomerLocationEmail[0]);
               }
               if ( StringUtil.StrCmp(Z22CustomerLocationPhone, T000114_A22CustomerLocationPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationPhone");
                  GXUtil.WriteLogRaw("Old: ",Z22CustomerLocationPhone);
                  GXUtil.WriteLogRaw("Current: ",T000114_A22CustomerLocationPhone[0]);
               }
               if ( Z94CustomerLocationLastLine != T000114_A94CustomerLocationLastLine[0] )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationLastLine");
                  GXUtil.WriteLogRaw("Old: ",Z94CustomerLocationLastLine);
                  GXUtil.WriteLogRaw("Current: ",T000114_A94CustomerLocationLastLine[0]);
               }
               if ( StringUtil.StrCmp(Z133CustomerLocationDescription, T000114_A133CustomerLocationDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationDescription");
                  GXUtil.WriteLogRaw("Old: ",Z133CustomerLocationDescription);
                  GXUtil.WriteLogRaw("Current: ",T000114_A133CustomerLocationDescription[0]);
               }
               if ( StringUtil.StrCmp(Z134CustomerLocationName, T000114_A134CustomerLocationName[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationName");
                  GXUtil.WriteLogRaw("Old: ",Z134CustomerLocationName);
                  GXUtil.WriteLogRaw("Current: ",T000114_A134CustomerLocationName[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocation"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert013( )
      {
         if ( ! IsAuthorized("customer_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM013( 0) ;
            CheckOptimisticConcurrency013( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm013( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert013( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000144 */
                     pr_default.execute(42, new Object[] {A1CustomerId, A18CustomerLocationId, A19CustomerLocationVisitingAddres, A20CustomerLocationPostalAddress, A21CustomerLocationEmail, A22CustomerLocationPhone, A94CustomerLocationLastLine, A133CustomerLocationDescription, A134CustomerLocationName});
                     pr_default.close(42);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocation");
                     if ( (pr_default.getStatus(42) == 1) )
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
                           ProcessLevel013( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
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
               Load013( ) ;
            }
            EndLevel013( ) ;
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void Update013( )
      {
         if ( ! IsAuthorized("customer_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( ( nIsMod_3 != 0 ) || ( nIsDirty_3 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency013( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm013( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate013( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000145 */
                        pr_default.execute(43, new Object[] {A19CustomerLocationVisitingAddres, A20CustomerLocationPostalAddress, A21CustomerLocationEmail, A22CustomerLocationPhone, A94CustomerLocationLastLine, A133CustomerLocationDescription, A134CustomerLocationName, A1CustomerId, A18CustomerLocationId});
                        pr_default.close(43);
                        pr_default.SmartCacheProvider.SetUpdated("CustomerLocation");
                        if ( (pr_default.getStatus(43) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocation"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate013( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              ProcessLevel013( ) ;
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
               EndLevel013( ) ;
            }
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void DeferredUpdate013( )
      {
      }

      protected void Delete013( )
      {
         if ( ! IsAuthorized("customer_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency013( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls013( ) ;
            AfterConfirm013( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete013( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0121( ) ;
                  while ( RcdFound21 != 0 )
                  {
                     getByPrimaryKey0121( ) ;
                     Delete0121( ) ;
                     ScanNext0121( ) ;
                  }
                  ScanEnd0121( ) ;
                  ScanStart0117( ) ;
                  while ( RcdFound17 != 0 )
                  {
                     getByPrimaryKey0117( ) ;
                     Delete0117( ) ;
                     ScanNext0117( ) ;
                  }
                  ScanEnd0117( ) ;
                  ScanStart0116( ) ;
                  while ( RcdFound16 != 0 )
                  {
                     getByPrimaryKey0116( ) ;
                     Delete0116( ) ;
                     ScanNext0116( ) ;
                  }
                  ScanEnd0116( ) ;
                  A94CustomerLocationLastLine = O94CustomerLocationLastLine;
                  AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
                  ScanStart014( ) ;
                  while ( RcdFound4 != 0 )
                  {
                     getByPrimaryKey014( ) ;
                     Delete014( ) ;
                     ScanNext014( ) ;
                     O94CustomerLocationLastLine = A94CustomerLocationLastLine;
                     AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
                  }
                  ScanEnd014( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000146 */
                     pr_default.execute(44, new Object[] {A1CustomerId, A18CustomerLocationId});
                     pr_default.close(44);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocation");
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
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel013( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls013( )
      {
         standaloneModal013( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000147 */
            pr_default.execute(45, new Object[] {A1CustomerId, A18CustomerLocationId});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "LocationEvent", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor T000148 */
            pr_default.execute(46, new Object[] {A1CustomerId, A18CustomerLocationId});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
         }
      }

      protected void ProcessNestedLevel014( )
      {
         s94CustomerLocationLastLine = O94CustomerLocationLastLine;
         AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
         nGXsfl_129_idx = 0;
         while ( nGXsfl_129_idx < nRC_GXsfl_129 )
         {
            ReadRow014( ) ;
            if ( ( nRcdExists_4 != 0 ) || ( nIsMod_4 != 0 ) )
            {
               standaloneNotModal014( ) ;
               GetKey014( ) ;
               if ( ( nRcdExists_4 == 0 ) && ( nRcdDeleted_4 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert014( ) ;
               }
               else
               {
                  if ( RcdFound4 != 0 )
                  {
                     if ( ( nRcdDeleted_4 != 0 ) && ( nRcdExists_4 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete014( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_4 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update014( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_4 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O94CustomerLocationLastLine = A94CustomerLocationLastLine;
               AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            }
            ChangePostValue( edtCustomerLocationReceptionistId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23CustomerLocationReceptionistId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCustomerLocationReceptionistGi_Internalname, A24CustomerLocationReceptionistGi) ;
            ChangePostValue( edtCustomerLocationReceptionistLa_Internalname, A25CustomerLocationReceptionistLa) ;
            ChangePostValue( edtCustomerLocationReceptionistIn_Internalname, StringUtil.RTrim( A26CustomerLocationReceptionistIn)) ;
            ChangePostValue( edtCustomerLocationReceptionistEm_Internalname, A27CustomerLocationReceptionistEm) ;
            ChangePostValue( edtCustomerLocationReceptionistAd_Internalname, A28CustomerLocationReceptionistAd) ;
            ChangePostValue( edtCustomerLocationReceptionistPh_Internalname, StringUtil.RTrim( A29CustomerLocationReceptionistPh)) ;
            ChangePostValue( edtCustomerLocationReceptionistGA_Internalname, A30CustomerLocationReceptionistGA) ;
            ChangePostValue( "ZT_"+"Z23CustomerLocationReceptionistId_"+sGXsfl_129_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23CustomerLocationReceptionistId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z30CustomerLocationReceptionistGA_"+sGXsfl_129_idx, Z30CustomerLocationReceptionistGA) ;
            ChangePostValue( "ZT_"+"Z26CustomerLocationReceptionistIn_"+sGXsfl_129_idx, StringUtil.RTrim( Z26CustomerLocationReceptionistIn)) ;
            ChangePostValue( "ZT_"+"Z24CustomerLocationReceptionistGi_"+sGXsfl_129_idx, Z24CustomerLocationReceptionistGi) ;
            ChangePostValue( "ZT_"+"Z25CustomerLocationReceptionistLa_"+sGXsfl_129_idx, Z25CustomerLocationReceptionistLa) ;
            ChangePostValue( "ZT_"+"Z27CustomerLocationReceptionistEm_"+sGXsfl_129_idx, Z27CustomerLocationReceptionistEm) ;
            ChangePostValue( "ZT_"+"Z28CustomerLocationReceptionistAd_"+sGXsfl_129_idx, Z28CustomerLocationReceptionistAd) ;
            ChangePostValue( "ZT_"+"Z29CustomerLocationReceptionistPh_"+sGXsfl_129_idx, StringUtil.RTrim( Z29CustomerLocationReceptionistPh)) ;
            ChangePostValue( "nRcdDeleted_4_"+sGXsfl_129_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_4), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_4_"+sGXsfl_129_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_4), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_4_"+sGXsfl_129_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_4), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_4 != 0 )
            {
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTID_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTGI_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistGi_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTLA_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistLa_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTIN_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistIn_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTEM_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistEm_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTAD_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistAd_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTPH_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistPh_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUSTOMERLOCATIONRECEPTIONISTGA_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistGA_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll014( ) ;
         if ( AnyError != 0 )
         {
            O94CustomerLocationLastLine = s94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
         }
         nRcdExists_4 = 0;
         nIsMod_4 = 0;
         nRcdDeleted_4 = 0;
      }

      protected void ProcessNestedLevel0116( )
      {
         nGXsfl_143_idx = 0;
         while ( nGXsfl_143_idx < nRC_GXsfl_143 )
         {
            ReadRow0116( ) ;
            if ( ( nRcdExists_16 != 0 ) || ( nIsMod_16 != 0 ) )
            {
               standaloneNotModal0116( ) ;
               GetKey0116( ) ;
               if ( ( nRcdExists_16 == 0 ) && ( nRcdDeleted_16 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0116( ) ;
               }
               else
               {
                  if ( RcdFound16 != 0 )
                  {
                     if ( ( nRcdDeleted_16 != 0 ) && ( nRcdExists_16 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0116( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0116( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_16 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSupplier_AgbId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtSupplier_AgbName_Internalname, A57Supplier_AgbName) ;
            ChangePostValue( edtSupplier_AgbKvkNumber_Internalname, A58Supplier_AgbKvkNumber) ;
            ChangePostValue( edtSupplier_AgbVisitingAddress_Internalname, A59Supplier_AgbVisitingAddress) ;
            ChangePostValue( edtSupplier_AgbPostalAddress_Internalname, A60Supplier_AgbPostalAddress) ;
            ChangePostValue( edtSupplier_AgbEmail_Internalname, A61Supplier_AgbEmail) ;
            ChangePostValue( edtSupplier_AgbPhone_Internalname, StringUtil.RTrim( A62Supplier_AgbPhone)) ;
            ChangePostValue( edtSupplier_AgbContactName_Internalname, A63Supplier_AgbContactName) ;
            ChangePostValue( "ZT_"+"Z55Supplier_AgbId_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_16_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_16_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_16_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_16 != 0 )
            {
               ChangePostValue( "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Horizontalalignment", StringUtil.RTrim( edtSupplier_AgbId_Horizontalalignment)) ;
               ChangePostValue( "SUPPLIER_AGBNAME_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbKvkNumber_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbVisitingAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPostalAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBEMAIL_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBPHONE_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_AGBCONTACTNAME_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbContactName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0116( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_16 = 0;
         nIsMod_16 = 0;
         nRcdDeleted_16 = 0;
      }

      protected void ProcessNestedLevel0117( )
      {
         nGXsfl_156_idx = 0;
         while ( nGXsfl_156_idx < nRC_GXsfl_156 )
         {
            ReadRow0117( ) ;
            if ( ( nRcdExists_17 != 0 ) || ( nIsMod_17 != 0 ) )
            {
               standaloneNotModal0117( ) ;
               GetKey0117( ) ;
               if ( ( nRcdExists_17 == 0 ) && ( nRcdDeleted_17 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0117( ) ;
               }
               else
               {
                  if ( RcdFound17 != 0 )
                  {
                     if ( ( nRcdDeleted_17 != 0 ) && ( nRcdExists_17 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0117( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_17 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0117( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_17 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSupplier_GenId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtSupplier_GenCompanyName_Internalname, A66Supplier_GenCompanyName) ;
            ChangePostValue( edtSupplier_GenVisitingAddress_Internalname, A67Supplier_GenVisitingAddress) ;
            ChangePostValue( edtSupplier_GenPostalAddress_Internalname, A68Supplier_GenPostalAddress) ;
            ChangePostValue( edtSupplier_GenContactName_Internalname, A69Supplier_GenContactName) ;
            ChangePostValue( edtSupplier_GenContactPhone_Internalname, StringUtil.RTrim( A70Supplier_GenContactPhone)) ;
            ChangePostValue( "ZT_"+"Z64Supplier_GenId_"+sGXsfl_156_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_17_"+sGXsfl_156_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_17), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_17_"+sGXsfl_156_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_17), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_17_"+sGXsfl_156_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_17), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_17 != 0 )
            {
               ChangePostValue( "SUPPLIER_GENID_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENID_"+sGXsfl_156_idx+"Horizontalalignment", StringUtil.RTrim( edtSupplier_GenId_Horizontalalignment)) ;
               ChangePostValue( "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenCompanyName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenVisitingAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenPostalAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENCONTACTNAME_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIER_GENCONTACTPHONE_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactPhone_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0117( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_17 = 0;
         nIsMod_17 = 0;
         nRcdDeleted_17 = 0;
      }

      protected void ProcessNestedLevel0121( )
      {
         nGXsfl_168_idx = 0;
         while ( nGXsfl_168_idx < nRC_GXsfl_168 )
         {
            ReadRow0121( ) ;
            if ( ( nRcdExists_21 != 0 ) || ( nIsMod_21 != 0 ) )
            {
               standaloneNotModal0121( ) ;
               GetKey0121( ) ;
               if ( ( nRcdExists_21 == 0 ) && ( nRcdDeleted_21 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0121( ) ;
               }
               else
               {
                  if ( RcdFound21 != 0 )
                  {
                     if ( ( nRcdDeleted_21 != 0 ) && ( nRcdExists_21 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0121( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_21 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0121( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_21 == 0 )
                     {
                        GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCustomerLocationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAmenitiesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtAmenitiesTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtAmenitiesTypeName_Internalname, A100AmenitiesTypeName) ;
            ChangePostValue( "ZT_"+"Z98AmenitiesId_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_21_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_21), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_21_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_21), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_21_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_21), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_21 != 0 )
            {
               ChangePostValue( "AMENITIESID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AMENITIESID_"+sGXsfl_168_idx+"Horizontalalignment", StringUtil.RTrim( edtAmenitiesId_Horizontalalignment)) ;
               ChangePostValue( "AMENITIESTYPEID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AMENITIESTYPENAME_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesTypeName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0121( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_21 = 0;
         nIsMod_21 = 0;
         nRcdDeleted_21 = 0;
      }

      protected void ProcessLevel013( )
      {
         /* Save parent mode. */
         sMode3 = Gx_mode;
         ProcessNestedLevel014( ) ;
         ProcessNestedLevel0116( ) ;
         ProcessNestedLevel0117( ) ;
         ProcessNestedLevel0121( ) ;
         if ( AnyError != 0 )
         {
            O94CustomerLocationLastLine = s94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000149 */
         pr_default.execute(47, new Object[] {A94CustomerLocationLastLine, A1CustomerId, A18CustomerLocationId});
         pr_default.close(47);
         pr_default.SmartCacheProvider.SetUpdated("CustomerLocation");
      }

      protected void EndLevel013( )
      {
         pr_default.close(12);
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart013( )
      {
         /* Scan By routine */
         /* Using cursor T000150 */
         pr_default.execute(48, new Object[] {A1CustomerId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(48) != 101) )
         {
            RcdFound3 = 1;
            A18CustomerLocationId = T000150_A18CustomerLocationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext013( )
      {
         /* Scan next routine */
         pr_default.readNext(48);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(48) != 101) )
         {
            RcdFound3 = 1;
            A18CustomerLocationId = T000150_A18CustomerLocationId[0];
         }
      }

      protected void ScanEnd013( )
      {
         pr_default.close(48);
      }

      protected void AfterConfirm013( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert013( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate013( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete013( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete013( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate013( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes013( )
      {
         edtCustomerLocationId_Enabled = 0;
         AssignProp("", false, edtCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationId_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtCustomerLocationVisitingAddres_Enabled = 0;
         AssignProp("", false, edtCustomerLocationVisitingAddres_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationVisitingAddres_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtCustomerLocationPostalAddress_Enabled = 0;
         AssignProp("", false, edtCustomerLocationPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationPostalAddress_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtCustomerLocationEmail_Enabled = 0;
         AssignProp("", false, edtCustomerLocationEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationEmail_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtCustomerLocationPhone_Enabled = 0;
         AssignProp("", false, edtCustomerLocationPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationPhone_Enabled), 5, 0), !bGXsfl_97_Refreshing);
      }

      protected void ZM014( short GX_JID )
      {
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z30CustomerLocationReceptionistGA = T000113_A30CustomerLocationReceptionistGA[0];
               Z26CustomerLocationReceptionistIn = T000113_A26CustomerLocationReceptionistIn[0];
               Z24CustomerLocationReceptionistGi = T000113_A24CustomerLocationReceptionistGi[0];
               Z25CustomerLocationReceptionistLa = T000113_A25CustomerLocationReceptionistLa[0];
               Z27CustomerLocationReceptionistEm = T000113_A27CustomerLocationReceptionistEm[0];
               Z28CustomerLocationReceptionistAd = T000113_A28CustomerLocationReceptionistAd[0];
               Z29CustomerLocationReceptionistPh = T000113_A29CustomerLocationReceptionistPh[0];
            }
            else
            {
               Z30CustomerLocationReceptionistGA = A30CustomerLocationReceptionistGA;
               Z26CustomerLocationReceptionistIn = A26CustomerLocationReceptionistIn;
               Z24CustomerLocationReceptionistGi = A24CustomerLocationReceptionistGi;
               Z25CustomerLocationReceptionistLa = A25CustomerLocationReceptionistLa;
               Z27CustomerLocationReceptionistEm = A27CustomerLocationReceptionistEm;
               Z28CustomerLocationReceptionistAd = A28CustomerLocationReceptionistAd;
               Z29CustomerLocationReceptionistPh = A29CustomerLocationReceptionistPh;
            }
         }
         if ( GX_JID == -31 )
         {
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z23CustomerLocationReceptionistId = A23CustomerLocationReceptionistId;
            Z30CustomerLocationReceptionistGA = A30CustomerLocationReceptionistGA;
            Z26CustomerLocationReceptionistIn = A26CustomerLocationReceptionistIn;
            Z24CustomerLocationReceptionistGi = A24CustomerLocationReceptionistGi;
            Z25CustomerLocationReceptionistLa = A25CustomerLocationReceptionistLa;
            Z27CustomerLocationReceptionistEm = A27CustomerLocationReceptionistEm;
            Z28CustomerLocationReceptionistAd = A28CustomerLocationReceptionistAd;
            Z29CustomerLocationReceptionistPh = A29CustomerLocationReceptionistPh;
         }
      }

      protected void standaloneNotModal014( )
      {
         edtCustomerLocationReceptionistId_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistId_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtCustomerLocationReceptionistGA_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistGA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistGA_Enabled), 5, 0), !bGXsfl_129_Refreshing);
      }

      protected void standaloneModal014( )
      {
         if ( IsIns( )  )
         {
            A94CustomerLocationLastLine = (short)(O94CustomerLocationLastLine+1);
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A23CustomerLocationReceptionistId = A94CustomerLocationLastLine;
         }
      }

      protected void Load014( )
      {
         /* Using cursor T000151 */
         pr_default.execute(49, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
         if ( (pr_default.getStatus(49) != 101) )
         {
            RcdFound4 = 1;
            A30CustomerLocationReceptionistGA = T000151_A30CustomerLocationReceptionistGA[0];
            A26CustomerLocationReceptionistIn = T000151_A26CustomerLocationReceptionistIn[0];
            n26CustomerLocationReceptionistIn = T000151_n26CustomerLocationReceptionistIn[0];
            A24CustomerLocationReceptionistGi = T000151_A24CustomerLocationReceptionistGi[0];
            A25CustomerLocationReceptionistLa = T000151_A25CustomerLocationReceptionistLa[0];
            A27CustomerLocationReceptionistEm = T000151_A27CustomerLocationReceptionistEm[0];
            A28CustomerLocationReceptionistAd = T000151_A28CustomerLocationReceptionistAd[0];
            n28CustomerLocationReceptionistAd = T000151_n28CustomerLocationReceptionistAd[0];
            A29CustomerLocationReceptionistPh = T000151_A29CustomerLocationReceptionistPh[0];
            ZM014( -31) ;
         }
         pr_default.close(49);
         OnLoadActions014( ) ;
      }

      protected void OnLoadActions014( )
      {
      }

      protected void CheckExtendedTable014( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal014( ) ;
         new getnameinitials(context ).execute(  A24CustomerLocationReceptionistGi,  A25CustomerLocationReceptionistLa, out  A26CustomerLocationReceptionistIn) ;
         n26CustomerLocationReceptionistIn = (String.IsNullOrEmpty(StringUtil.RTrim( A26CustomerLocationReceptionistIn)) ? true : false);
         if ( ! ( GxRegex.IsMatch(A27CustomerLocationReceptionistEm,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GXCCtl = "CUSTOMERLOCATIONRECEPTIONISTEM_" + sGXsfl_129_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Customer Location Receptionist Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCustomerLocationReceptionistEm_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors014( )
      {
      }

      protected void enableDisable014( )
      {
      }

      protected void GetKey014( )
      {
         /* Using cursor T000152 */
         pr_default.execute(50, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
         if ( (pr_default.getStatus(50) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(50);
      }

      protected void getByPrimaryKey014( )
      {
         /* Using cursor T000113 */
         pr_default.execute(11, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            ZM014( 31) ;
            RcdFound4 = 1;
            InitializeNonKey014( ) ;
            A23CustomerLocationReceptionistId = T000113_A23CustomerLocationReceptionistId[0];
            A30CustomerLocationReceptionistGA = T000113_A30CustomerLocationReceptionistGA[0];
            A26CustomerLocationReceptionistIn = T000113_A26CustomerLocationReceptionistIn[0];
            n26CustomerLocationReceptionistIn = T000113_n26CustomerLocationReceptionistIn[0];
            A24CustomerLocationReceptionistGi = T000113_A24CustomerLocationReceptionistGi[0];
            A25CustomerLocationReceptionistLa = T000113_A25CustomerLocationReceptionistLa[0];
            A27CustomerLocationReceptionistEm = T000113_A27CustomerLocationReceptionistEm[0];
            A28CustomerLocationReceptionistAd = T000113_A28CustomerLocationReceptionistAd[0];
            n28CustomerLocationReceptionistAd = T000113_n28CustomerLocationReceptionistAd[0];
            A29CustomerLocationReceptionistPh = T000113_A29CustomerLocationReceptionistPh[0];
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z23CustomerLocationReceptionistId = A23CustomerLocationReceptionistId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load014( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey014( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal014( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes014( ) ;
         }
         pr_default.close(11);
      }

      protected void CheckOptimisticConcurrency014( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000112 */
            pr_default.execute(10, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
            if ( (pr_default.getStatus(10) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationReceptionist"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(10) == 101) || ( StringUtil.StrCmp(Z30CustomerLocationReceptionistGA, T000112_A30CustomerLocationReceptionistGA[0]) != 0 ) || ( StringUtil.StrCmp(Z26CustomerLocationReceptionistIn, T000112_A26CustomerLocationReceptionistIn[0]) != 0 ) || ( StringUtil.StrCmp(Z24CustomerLocationReceptionistGi, T000112_A24CustomerLocationReceptionistGi[0]) != 0 ) || ( StringUtil.StrCmp(Z25CustomerLocationReceptionistLa, T000112_A25CustomerLocationReceptionistLa[0]) != 0 ) || ( StringUtil.StrCmp(Z27CustomerLocationReceptionistEm, T000112_A27CustomerLocationReceptionistEm[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z28CustomerLocationReceptionistAd, T000112_A28CustomerLocationReceptionistAd[0]) != 0 ) || ( StringUtil.StrCmp(Z29CustomerLocationReceptionistPh, T000112_A29CustomerLocationReceptionistPh[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z30CustomerLocationReceptionistGA, T000112_A30CustomerLocationReceptionistGA[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationReceptionistGA");
                  GXUtil.WriteLogRaw("Old: ",Z30CustomerLocationReceptionistGA);
                  GXUtil.WriteLogRaw("Current: ",T000112_A30CustomerLocationReceptionistGA[0]);
               }
               if ( StringUtil.StrCmp(Z26CustomerLocationReceptionistIn, T000112_A26CustomerLocationReceptionistIn[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationReceptionistIn");
                  GXUtil.WriteLogRaw("Old: ",Z26CustomerLocationReceptionistIn);
                  GXUtil.WriteLogRaw("Current: ",T000112_A26CustomerLocationReceptionistIn[0]);
               }
               if ( StringUtil.StrCmp(Z24CustomerLocationReceptionistGi, T000112_A24CustomerLocationReceptionistGi[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationReceptionistGi");
                  GXUtil.WriteLogRaw("Old: ",Z24CustomerLocationReceptionistGi);
                  GXUtil.WriteLogRaw("Current: ",T000112_A24CustomerLocationReceptionistGi[0]);
               }
               if ( StringUtil.StrCmp(Z25CustomerLocationReceptionistLa, T000112_A25CustomerLocationReceptionistLa[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationReceptionistLa");
                  GXUtil.WriteLogRaw("Old: ",Z25CustomerLocationReceptionistLa);
                  GXUtil.WriteLogRaw("Current: ",T000112_A25CustomerLocationReceptionistLa[0]);
               }
               if ( StringUtil.StrCmp(Z27CustomerLocationReceptionistEm, T000112_A27CustomerLocationReceptionistEm[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationReceptionistEm");
                  GXUtil.WriteLogRaw("Old: ",Z27CustomerLocationReceptionistEm);
                  GXUtil.WriteLogRaw("Current: ",T000112_A27CustomerLocationReceptionistEm[0]);
               }
               if ( StringUtil.StrCmp(Z28CustomerLocationReceptionistAd, T000112_A28CustomerLocationReceptionistAd[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationReceptionistAd");
                  GXUtil.WriteLogRaw("Old: ",Z28CustomerLocationReceptionistAd);
                  GXUtil.WriteLogRaw("Current: ",T000112_A28CustomerLocationReceptionistAd[0]);
               }
               if ( StringUtil.StrCmp(Z29CustomerLocationReceptionistPh, T000112_A29CustomerLocationReceptionistPh[0]) != 0 )
               {
                  GXUtil.WriteLog("customer:[seudo value changed for attri]"+"CustomerLocationReceptionistPh");
                  GXUtil.WriteLogRaw("Old: ",Z29CustomerLocationReceptionistPh);
                  GXUtil.WriteLogRaw("Current: ",T000112_A29CustomerLocationReceptionistPh[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocationReceptionist"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert014( )
      {
         if ( ! IsAuthorized("customer_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate014( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable014( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM014( 0) ;
            CheckOptimisticConcurrency014( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm014( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert014( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000153 */
                     pr_default.execute(51, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId, A30CustomerLocationReceptionistGA, n26CustomerLocationReceptionistIn, A26CustomerLocationReceptionistIn, A24CustomerLocationReceptionistGi, A25CustomerLocationReceptionistLa, A27CustomerLocationReceptionistEm, n28CustomerLocationReceptionistAd, A28CustomerLocationReceptionistAd, A29CustomerLocationReceptionistPh});
                     pr_default.close(51);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocationReceptionist");
                     if ( (pr_default.getStatus(51) == 1) )
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
               Load014( ) ;
            }
            EndLevel014( ) ;
         }
         CloseExtendedTableCursors014( ) ;
      }

      protected void Update014( )
      {
         if ( ! IsAuthorized("customer_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate014( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable014( ) ;
         }
         if ( ( nIsMod_4 != 0 ) || ( nIsDirty_4 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency014( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm014( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate014( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000154 */
                        pr_default.execute(52, new Object[] {A30CustomerLocationReceptionistGA, n26CustomerLocationReceptionistIn, A26CustomerLocationReceptionistIn, A24CustomerLocationReceptionistGi, A25CustomerLocationReceptionistLa, A27CustomerLocationReceptionistEm, n28CustomerLocationReceptionistAd, A28CustomerLocationReceptionistAd, A29CustomerLocationReceptionistPh, A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
                        pr_default.close(52);
                        pr_default.SmartCacheProvider.SetUpdated("CustomerLocationReceptionist");
                        if ( (pr_default.getStatus(52) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationReceptionist"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate014( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey014( ) ;
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
               EndLevel014( ) ;
            }
         }
         CloseExtendedTableCursors014( ) ;
      }

      protected void DeferredUpdate014( )
      {
      }

      protected void Delete014( )
      {
         if ( ! IsAuthorized("customer_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate014( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency014( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls014( ) ;
            AfterConfirm014( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete014( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000155 */
                  pr_default.execute(53, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
                  pr_default.close(53);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerLocationReceptionist");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel014( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls014( )
      {
         standaloneModal014( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel014( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(10);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart014( )
      {
         /* Scan By routine */
         /* Using cursor T000156 */
         pr_default.execute(54, new Object[] {A1CustomerId, A18CustomerLocationId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(54) != 101) )
         {
            RcdFound4 = 1;
            A23CustomerLocationReceptionistId = T000156_A23CustomerLocationReceptionistId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext014( )
      {
         /* Scan next routine */
         pr_default.readNext(54);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(54) != 101) )
         {
            RcdFound4 = 1;
            A23CustomerLocationReceptionistId = T000156_A23CustomerLocationReceptionistId[0];
         }
      }

      protected void ScanEnd014( )
      {
         pr_default.close(54);
      }

      protected void AfterConfirm014( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert014( )
      {
         /* Before Insert Rules */
         new createuseraccount(context ).execute(  A27CustomerLocationReceptionistEm,  A24CustomerLocationReceptionistGi,  A25CustomerLocationReceptionistLa,  context.GetMessage( "Receptionist", ""), out  A30CustomerLocationReceptionistGA) ;
      }

      protected void BeforeUpdate014( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete014( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete014( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate014( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes014( )
      {
         edtCustomerLocationReceptionistId_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistId_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtCustomerLocationReceptionistGi_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistGi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistGi_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtCustomerLocationReceptionistLa_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistLa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistLa_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtCustomerLocationReceptionistIn_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistIn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistIn_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtCustomerLocationReceptionistEm_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistEm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistEm_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtCustomerLocationReceptionistAd_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistAd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistAd_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtCustomerLocationReceptionistPh_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistPh_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistPh_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtCustomerLocationReceptionistGA_Enabled = 0;
         AssignProp("", false, edtCustomerLocationReceptionistGA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistGA_Enabled), 5, 0), !bGXsfl_129_Refreshing);
      }

      protected void send_integrity_lvl_hashes014( )
      {
      }

      protected void ZM0116( short GX_JID )
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
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z55Supplier_AgbId = A55Supplier_AgbId;
            Z56Supplier_AgbNumber = A56Supplier_AgbNumber;
            Z57Supplier_AgbName = A57Supplier_AgbName;
            Z58Supplier_AgbKvkNumber = A58Supplier_AgbKvkNumber;
            Z59Supplier_AgbVisitingAddress = A59Supplier_AgbVisitingAddress;
            Z60Supplier_AgbPostalAddress = A60Supplier_AgbPostalAddress;
            Z61Supplier_AgbEmail = A61Supplier_AgbEmail;
            Z62Supplier_AgbPhone = A62Supplier_AgbPhone;
            Z63Supplier_AgbContactName = A63Supplier_AgbContactName;
         }
      }

      protected void standaloneNotModal0116( )
      {
      }

      protected void standaloneModal0116( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtSupplier_AgbId_Enabled = 0;
            AssignProp("", false, edtSupplier_AgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         }
         else
         {
            edtSupplier_AgbId_Enabled = 1;
            AssignProp("", false, edtSupplier_AgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         }
      }

      protected void Load0116( )
      {
         /* Using cursor T000157 */
         pr_default.execute(55, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
         if ( (pr_default.getStatus(55) != 101) )
         {
            RcdFound16 = 1;
            A56Supplier_AgbNumber = T000157_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = T000157_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = T000157_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = T000157_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = T000157_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = T000157_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = T000157_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = T000157_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = T000157_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = T000157_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = T000157_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = T000157_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = T000157_n63Supplier_AgbContactName[0];
            ZM0116( -32) ;
         }
         pr_default.close(55);
         OnLoadActions0116( ) ;
      }

      protected void OnLoadActions0116( )
      {
      }

      protected void CheckExtendedTable0116( )
      {
         nIsDirty_16 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0116( ) ;
         /* Using cursor T000111 */
         pr_default.execute(9, new Object[] {A55Supplier_AgbId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GXCCtl = "SUPPLIER_AGBID_" + sGXsfl_143_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Supplier_AGB", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSupplier_AgbId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A56Supplier_AgbNumber = T000111_A56Supplier_AgbNumber[0];
         A57Supplier_AgbName = T000111_A57Supplier_AgbName[0];
         A58Supplier_AgbKvkNumber = T000111_A58Supplier_AgbKvkNumber[0];
         A59Supplier_AgbVisitingAddress = T000111_A59Supplier_AgbVisitingAddress[0];
         n59Supplier_AgbVisitingAddress = T000111_n59Supplier_AgbVisitingAddress[0];
         A60Supplier_AgbPostalAddress = T000111_A60Supplier_AgbPostalAddress[0];
         n60Supplier_AgbPostalAddress = T000111_n60Supplier_AgbPostalAddress[0];
         A61Supplier_AgbEmail = T000111_A61Supplier_AgbEmail[0];
         n61Supplier_AgbEmail = T000111_n61Supplier_AgbEmail[0];
         A62Supplier_AgbPhone = T000111_A62Supplier_AgbPhone[0];
         n62Supplier_AgbPhone = T000111_n62Supplier_AgbPhone[0];
         A63Supplier_AgbContactName = T000111_A63Supplier_AgbContactName[0];
         n63Supplier_AgbContactName = T000111_n63Supplier_AgbContactName[0];
         pr_default.close(9);
      }

      protected void CloseExtendedTableCursors0116( )
      {
         pr_default.close(9);
      }

      protected void enableDisable0116( )
      {
      }

      protected void gxLoad_33( short A55Supplier_AgbId )
      {
         /* Using cursor T000158 */
         pr_default.execute(56, new Object[] {A55Supplier_AgbId});
         if ( (pr_default.getStatus(56) == 101) )
         {
            GXCCtl = "SUPPLIER_AGBID_" + sGXsfl_143_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Supplier_AGB", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSupplier_AgbId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A56Supplier_AgbNumber = T000158_A56Supplier_AgbNumber[0];
         A57Supplier_AgbName = T000158_A57Supplier_AgbName[0];
         A58Supplier_AgbKvkNumber = T000158_A58Supplier_AgbKvkNumber[0];
         A59Supplier_AgbVisitingAddress = T000158_A59Supplier_AgbVisitingAddress[0];
         n59Supplier_AgbVisitingAddress = T000158_n59Supplier_AgbVisitingAddress[0];
         A60Supplier_AgbPostalAddress = T000158_A60Supplier_AgbPostalAddress[0];
         n60Supplier_AgbPostalAddress = T000158_n60Supplier_AgbPostalAddress[0];
         A61Supplier_AgbEmail = T000158_A61Supplier_AgbEmail[0];
         n61Supplier_AgbEmail = T000158_n61Supplier_AgbEmail[0];
         A62Supplier_AgbPhone = T000158_A62Supplier_AgbPhone[0];
         n62Supplier_AgbPhone = T000158_n62Supplier_AgbPhone[0];
         A63Supplier_AgbContactName = T000158_A63Supplier_AgbContactName[0];
         n63Supplier_AgbContactName = T000158_n63Supplier_AgbContactName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A56Supplier_AgbNumber)+"\""+","+"\""+GXUtil.EncodeJSConstant( A57Supplier_AgbName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A58Supplier_AgbKvkNumber)+"\""+","+"\""+GXUtil.EncodeJSConstant( A59Supplier_AgbVisitingAddress)+"\""+","+"\""+GXUtil.EncodeJSConstant( A60Supplier_AgbPostalAddress)+"\""+","+"\""+GXUtil.EncodeJSConstant( A61Supplier_AgbEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A62Supplier_AgbPhone))+"\""+","+"\""+GXUtil.EncodeJSConstant( A63Supplier_AgbContactName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(56) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(56);
      }

      protected void GetKey0116( )
      {
         /* Using cursor T000159 */
         pr_default.execute(57, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
         if ( (pr_default.getStatus(57) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(57);
      }

      protected void getByPrimaryKey0116( )
      {
         /* Using cursor T000110 */
         pr_default.execute(8, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            ZM0116( 32) ;
            RcdFound16 = 1;
            InitializeNonKey0116( ) ;
            A55Supplier_AgbId = T000110_A55Supplier_AgbId[0];
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z55Supplier_AgbId = A55Supplier_AgbId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0116( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0116( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0116( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0116( ) ;
         }
         pr_default.close(8);
      }

      protected void CheckOptimisticConcurrency0116( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00019 */
            pr_default.execute(7, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
            if ( (pr_default.getStatus(7) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationSupplier_Agb"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(7) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocationSupplier_Agb"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0116( )
      {
         if ( ! IsAuthorized("customer_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0116( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0116( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0116( 0) ;
            CheckOptimisticConcurrency0116( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0116( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0116( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000160 */
                     pr_default.execute(58, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
                     pr_default.close(58);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocationSupplier_Agb");
                     if ( (pr_default.getStatus(58) == 1) )
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
               Load0116( ) ;
            }
            EndLevel0116( ) ;
         }
         CloseExtendedTableCursors0116( ) ;
      }

      protected void Update0116( )
      {
         if ( ! IsAuthorized("customer_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0116( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0116( ) ;
         }
         if ( ( nIsMod_16 != 0 ) || ( nIsDirty_16 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0116( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0116( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0116( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table CustomerLocationSupplier_Agb */
                        DeferredUpdate0116( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0116( ) ;
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
               EndLevel0116( ) ;
            }
         }
         CloseExtendedTableCursors0116( ) ;
      }

      protected void DeferredUpdate0116( )
      {
      }

      protected void Delete0116( )
      {
         if ( ! IsAuthorized("customer_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0116( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0116( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0116( ) ;
            AfterConfirm0116( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0116( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000161 */
                  pr_default.execute(59, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
                  pr_default.close(59);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerLocationSupplier_Agb");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0116( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0116( )
      {
         standaloneModal0116( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000162 */
            pr_default.execute(60, new Object[] {A55Supplier_AgbId});
            A56Supplier_AgbNumber = T000162_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = T000162_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = T000162_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = T000162_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = T000162_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = T000162_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = T000162_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = T000162_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = T000162_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = T000162_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = T000162_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = T000162_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = T000162_n63Supplier_AgbContactName[0];
            pr_default.close(60);
         }
      }

      protected void EndLevel0116( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(7);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0116( )
      {
         /* Scan By routine */
         /* Using cursor T000163 */
         pr_default.execute(61, new Object[] {A1CustomerId, A18CustomerLocationId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(61) != 101) )
         {
            RcdFound16 = 1;
            A55Supplier_AgbId = T000163_A55Supplier_AgbId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0116( )
      {
         /* Scan next routine */
         pr_default.readNext(61);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(61) != 101) )
         {
            RcdFound16 = 1;
            A55Supplier_AgbId = T000163_A55Supplier_AgbId[0];
         }
      }

      protected void ScanEnd0116( )
      {
         pr_default.close(61);
      }

      protected void AfterConfirm0116( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0116( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0116( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0116( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0116( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0116( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0116( )
      {
         edtSupplier_AgbId_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         edtSupplier_AgbName_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbName_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         edtSupplier_AgbKvkNumber_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbKvkNumber_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         edtSupplier_AgbVisitingAddress_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbVisitingAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbVisitingAddress_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         edtSupplier_AgbPostalAddress_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPostalAddress_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         edtSupplier_AgbEmail_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbEmail_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         edtSupplier_AgbPhone_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPhone_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         edtSupplier_AgbContactName_Enabled = 0;
         AssignProp("", false, edtSupplier_AgbContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbContactName_Enabled), 5, 0), !bGXsfl_143_Refreshing);
      }

      protected void send_integrity_lvl_hashes0116( )
      {
      }

      protected void ZM0117( short GX_JID )
      {
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -34 )
         {
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z64Supplier_GenId = A64Supplier_GenId;
            Z65Supplier_GenKvKNumber = A65Supplier_GenKvKNumber;
            Z66Supplier_GenCompanyName = A66Supplier_GenCompanyName;
            Z67Supplier_GenVisitingAddress = A67Supplier_GenVisitingAddress;
            Z68Supplier_GenPostalAddress = A68Supplier_GenPostalAddress;
            Z69Supplier_GenContactName = A69Supplier_GenContactName;
            Z70Supplier_GenContactPhone = A70Supplier_GenContactPhone;
         }
      }

      protected void standaloneNotModal0117( )
      {
      }

      protected void standaloneModal0117( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtSupplier_GenId_Enabled = 0;
            AssignProp("", false, edtSupplier_GenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenId_Enabled), 5, 0), !bGXsfl_156_Refreshing);
         }
         else
         {
            edtSupplier_GenId_Enabled = 1;
            AssignProp("", false, edtSupplier_GenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenId_Enabled), 5, 0), !bGXsfl_156_Refreshing);
         }
      }

      protected void Load0117( )
      {
         /* Using cursor T000164 */
         pr_default.execute(62, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
         if ( (pr_default.getStatus(62) != 101) )
         {
            RcdFound17 = 1;
            A65Supplier_GenKvKNumber = T000164_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = T000164_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = T000164_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = T000164_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = T000164_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = T000164_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = T000164_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = T000164_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = T000164_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = T000164_n70Supplier_GenContactPhone[0];
            ZM0117( -34) ;
         }
         pr_default.close(62);
         OnLoadActions0117( ) ;
      }

      protected void OnLoadActions0117( )
      {
      }

      protected void CheckExtendedTable0117( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0117( ) ;
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GXCCtl = "SUPPLIER_GENID_" + sGXsfl_156_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Supplier_Gen", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSupplier_GenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A65Supplier_GenKvKNumber = T00018_A65Supplier_GenKvKNumber[0];
         A66Supplier_GenCompanyName = T00018_A66Supplier_GenCompanyName[0];
         A67Supplier_GenVisitingAddress = T00018_A67Supplier_GenVisitingAddress[0];
         n67Supplier_GenVisitingAddress = T00018_n67Supplier_GenVisitingAddress[0];
         A68Supplier_GenPostalAddress = T00018_A68Supplier_GenPostalAddress[0];
         n68Supplier_GenPostalAddress = T00018_n68Supplier_GenPostalAddress[0];
         A69Supplier_GenContactName = T00018_A69Supplier_GenContactName[0];
         n69Supplier_GenContactName = T00018_n69Supplier_GenContactName[0];
         A70Supplier_GenContactPhone = T00018_A70Supplier_GenContactPhone[0];
         n70Supplier_GenContactPhone = T00018_n70Supplier_GenContactPhone[0];
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors0117( )
      {
         pr_default.close(6);
      }

      protected void enableDisable0117( )
      {
      }

      protected void gxLoad_35( short A64Supplier_GenId )
      {
         /* Using cursor T000165 */
         pr_default.execute(63, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(63) == 101) )
         {
            GXCCtl = "SUPPLIER_GENID_" + sGXsfl_156_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Supplier_Gen", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSupplier_GenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A65Supplier_GenKvKNumber = T000165_A65Supplier_GenKvKNumber[0];
         A66Supplier_GenCompanyName = T000165_A66Supplier_GenCompanyName[0];
         A67Supplier_GenVisitingAddress = T000165_A67Supplier_GenVisitingAddress[0];
         n67Supplier_GenVisitingAddress = T000165_n67Supplier_GenVisitingAddress[0];
         A68Supplier_GenPostalAddress = T000165_A68Supplier_GenPostalAddress[0];
         n68Supplier_GenPostalAddress = T000165_n68Supplier_GenPostalAddress[0];
         A69Supplier_GenContactName = T000165_A69Supplier_GenContactName[0];
         n69Supplier_GenContactName = T000165_n69Supplier_GenContactName[0];
         A70Supplier_GenContactPhone = T000165_A70Supplier_GenContactPhone[0];
         n70Supplier_GenContactPhone = T000165_n70Supplier_GenContactPhone[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A65Supplier_GenKvKNumber)+"\""+","+"\""+GXUtil.EncodeJSConstant( A66Supplier_GenCompanyName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A67Supplier_GenVisitingAddress)+"\""+","+"\""+GXUtil.EncodeJSConstant( A68Supplier_GenPostalAddress)+"\""+","+"\""+GXUtil.EncodeJSConstant( A69Supplier_GenContactName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A70Supplier_GenContactPhone))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(63) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(63);
      }

      protected void GetKey0117( )
      {
         /* Using cursor T000166 */
         pr_default.execute(64, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
         if ( (pr_default.getStatus(64) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(64);
      }

      protected void getByPrimaryKey0117( )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0117( 34) ;
            RcdFound17 = 1;
            InitializeNonKey0117( ) ;
            A64Supplier_GenId = T00017_A64Supplier_GenId[0];
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z64Supplier_GenId = A64Supplier_GenId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0117( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0117( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0117( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0117( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency0117( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00016 */
            pr_default.execute(4, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationSupplier_Gen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocationSupplier_Gen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0117( )
      {
         if ( ! IsAuthorized("customer_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0117( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0117( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0117( 0) ;
            CheckOptimisticConcurrency0117( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0117( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0117( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000167 */
                     pr_default.execute(65, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
                     pr_default.close(65);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocationSupplier_Gen");
                     if ( (pr_default.getStatus(65) == 1) )
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
               Load0117( ) ;
            }
            EndLevel0117( ) ;
         }
         CloseExtendedTableCursors0117( ) ;
      }

      protected void Update0117( )
      {
         if ( ! IsAuthorized("customer_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0117( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0117( ) ;
         }
         if ( ( nIsMod_17 != 0 ) || ( nIsDirty_17 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0117( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0117( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0117( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table CustomerLocationSupplier_Gen */
                        DeferredUpdate0117( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0117( ) ;
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
               EndLevel0117( ) ;
            }
         }
         CloseExtendedTableCursors0117( ) ;
      }

      protected void DeferredUpdate0117( )
      {
      }

      protected void Delete0117( )
      {
         if ( ! IsAuthorized("customer_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0117( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0117( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0117( ) ;
            AfterConfirm0117( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0117( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000168 */
                  pr_default.execute(66, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
                  pr_default.close(66);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerLocationSupplier_Gen");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0117( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0117( )
      {
         standaloneModal0117( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000169 */
            pr_default.execute(67, new Object[] {A64Supplier_GenId});
            A65Supplier_GenKvKNumber = T000169_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = T000169_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = T000169_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = T000169_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = T000169_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = T000169_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = T000169_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = T000169_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = T000169_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = T000169_n70Supplier_GenContactPhone[0];
            pr_default.close(67);
         }
      }

      protected void EndLevel0117( )
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

      public void ScanStart0117( )
      {
         /* Scan By routine */
         /* Using cursor T000170 */
         pr_default.execute(68, new Object[] {A1CustomerId, A18CustomerLocationId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(68) != 101) )
         {
            RcdFound17 = 1;
            A64Supplier_GenId = T000170_A64Supplier_GenId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0117( )
      {
         /* Scan next routine */
         pr_default.readNext(68);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(68) != 101) )
         {
            RcdFound17 = 1;
            A64Supplier_GenId = T000170_A64Supplier_GenId[0];
         }
      }

      protected void ScanEnd0117( )
      {
         pr_default.close(68);
      }

      protected void AfterConfirm0117( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0117( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0117( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0117( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0117( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0117( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0117( )
      {
         edtSupplier_GenId_Enabled = 0;
         AssignProp("", false, edtSupplier_GenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenId_Enabled), 5, 0), !bGXsfl_156_Refreshing);
         edtSupplier_GenCompanyName_Enabled = 0;
         AssignProp("", false, edtSupplier_GenCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenCompanyName_Enabled), 5, 0), !bGXsfl_156_Refreshing);
         edtSupplier_GenVisitingAddress_Enabled = 0;
         AssignProp("", false, edtSupplier_GenVisitingAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenVisitingAddress_Enabled), 5, 0), !bGXsfl_156_Refreshing);
         edtSupplier_GenPostalAddress_Enabled = 0;
         AssignProp("", false, edtSupplier_GenPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenPostalAddress_Enabled), 5, 0), !bGXsfl_156_Refreshing);
         edtSupplier_GenContactName_Enabled = 0;
         AssignProp("", false, edtSupplier_GenContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenContactName_Enabled), 5, 0), !bGXsfl_156_Refreshing);
         edtSupplier_GenContactPhone_Enabled = 0;
         AssignProp("", false, edtSupplier_GenContactPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenContactPhone_Enabled), 5, 0), !bGXsfl_156_Refreshing);
      }

      protected void send_integrity_lvl_hashes0117( )
      {
      }

      protected void ZM0121( short GX_JID )
      {
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -36 )
         {
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z98AmenitiesId = A98AmenitiesId;
            Z101AmenitiesName = A101AmenitiesName;
            Z99AmenitiesTypeId = A99AmenitiesTypeId;
            Z100AmenitiesTypeName = A100AmenitiesTypeName;
         }
      }

      protected void standaloneNotModal0121( )
      {
      }

      protected void standaloneModal0121( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtAmenitiesId_Enabled = 0;
            AssignProp("", false, edtAmenitiesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         }
         else
         {
            edtAmenitiesId_Enabled = 1;
            AssignProp("", false, edtAmenitiesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         }
      }

      protected void Load0121( )
      {
         /* Using cursor T000171 */
         pr_default.execute(69, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
         if ( (pr_default.getStatus(69) != 101) )
         {
            RcdFound21 = 1;
            A101AmenitiesName = T000171_A101AmenitiesName[0];
            A100AmenitiesTypeName = T000171_A100AmenitiesTypeName[0];
            A99AmenitiesTypeId = T000171_A99AmenitiesTypeId[0];
            ZM0121( -36) ;
         }
         pr_default.close(69);
         OnLoadActions0121( ) ;
      }

      protected void OnLoadActions0121( )
      {
      }

      protected void CheckExtendedTable0121( )
      {
         nIsDirty_21 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0121( ) ;
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A98AmenitiesId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "AMENITIESID_" + sGXsfl_168_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Amenities", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAmenitiesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A101AmenitiesName = T00014_A101AmenitiesName[0];
         A99AmenitiesTypeId = T00014_A99AmenitiesTypeId[0];
         pr_default.close(2);
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A99AmenitiesTypeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "AMENITIESTYPEID_" + sGXsfl_168_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AmenitiesType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A100AmenitiesTypeName = T00015_A100AmenitiesTypeName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0121( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0121( )
      {
      }

      protected void gxLoad_37( short A98AmenitiesId )
      {
         /* Using cursor T000172 */
         pr_default.execute(70, new Object[] {A98AmenitiesId});
         if ( (pr_default.getStatus(70) == 101) )
         {
            GXCCtl = "AMENITIESID_" + sGXsfl_168_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Amenities", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAmenitiesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A101AmenitiesName = T000172_A101AmenitiesName[0];
         A99AmenitiesTypeId = T000172_A99AmenitiesTypeId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A101AmenitiesName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A99AmenitiesTypeId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(70) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(70);
      }

      protected void gxLoad_38( short A99AmenitiesTypeId )
      {
         /* Using cursor T000173 */
         pr_default.execute(71, new Object[] {A99AmenitiesTypeId});
         if ( (pr_default.getStatus(71) == 101) )
         {
            GXCCtl = "AMENITIESTYPEID_" + sGXsfl_168_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AmenitiesType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A100AmenitiesTypeName = T000173_A100AmenitiesTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A100AmenitiesTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(71) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(71);
      }

      protected void GetKey0121( )
      {
         /* Using cursor T000174 */
         pr_default.execute(72, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
         if ( (pr_default.getStatus(72) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(72);
      }

      protected void getByPrimaryKey0121( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0121( 36) ;
            RcdFound21 = 1;
            InitializeNonKey0121( ) ;
            A98AmenitiesId = T00013_A98AmenitiesId[0];
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z98AmenitiesId = A98AmenitiesId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0121( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0121( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0121( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0121( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0121( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationsAmenities"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocationsAmenities"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0121( )
      {
         if ( ! IsAuthorized("customer_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0121( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0121( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0121( 0) ;
            CheckOptimisticConcurrency0121( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0121( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0121( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000175 */
                     pr_default.execute(73, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
                     pr_default.close(73);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocationsAmenities");
                     if ( (pr_default.getStatus(73) == 1) )
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
               Load0121( ) ;
            }
            EndLevel0121( ) ;
         }
         CloseExtendedTableCursors0121( ) ;
      }

      protected void Update0121( )
      {
         if ( ! IsAuthorized("customer_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0121( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0121( ) ;
         }
         if ( ( nIsMod_21 != 0 ) || ( nIsDirty_21 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0121( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0121( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0121( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table CustomerLocationsAmenities */
                        DeferredUpdate0121( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0121( ) ;
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
               EndLevel0121( ) ;
            }
         }
         CloseExtendedTableCursors0121( ) ;
      }

      protected void DeferredUpdate0121( )
      {
      }

      protected void Delete0121( )
      {
         if ( ! IsAuthorized("customer_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0121( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0121( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0121( ) ;
            AfterConfirm0121( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0121( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000176 */
                  pr_default.execute(74, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
                  pr_default.close(74);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerLocationsAmenities");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0121( ) ;
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0121( )
      {
         standaloneModal0121( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000177 */
            pr_default.execute(75, new Object[] {A98AmenitiesId});
            A101AmenitiesName = T000177_A101AmenitiesName[0];
            A99AmenitiesTypeId = T000177_A99AmenitiesTypeId[0];
            pr_default.close(75);
            /* Using cursor T000178 */
            pr_default.execute(76, new Object[] {A99AmenitiesTypeId});
            A100AmenitiesTypeName = T000178_A100AmenitiesTypeName[0];
            pr_default.close(76);
         }
      }

      protected void EndLevel0121( )
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

      public void ScanStart0121( )
      {
         /* Scan By routine */
         /* Using cursor T000179 */
         pr_default.execute(77, new Object[] {A1CustomerId, A18CustomerLocationId});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(77) != 101) )
         {
            RcdFound21 = 1;
            A98AmenitiesId = T000179_A98AmenitiesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0121( )
      {
         /* Scan next routine */
         pr_default.readNext(77);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(77) != 101) )
         {
            RcdFound21 = 1;
            A98AmenitiesId = T000179_A98AmenitiesId[0];
         }
      }

      protected void ScanEnd0121( )
      {
         pr_default.close(77);
      }

      protected void AfterConfirm0121( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0121( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0121( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0121( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0121( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0121( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0121( )
      {
         edtAmenitiesId_Enabled = 0;
         AssignProp("", false, edtAmenitiesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtAmenitiesTypeId_Enabled = 0;
         AssignProp("", false, edtAmenitiesTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtAmenitiesTypeName_Enabled = 0;
         AssignProp("", false, edtAmenitiesTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeName_Enabled), 5, 0), !bGXsfl_168_Refreshing);
      }

      protected void send_integrity_lvl_hashes0121( )
      {
      }

      protected void send_integrity_lvl_hashes013( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void SubsflControlProps_782( )
      {
         edtCustomerManagerId_Internalname = "CUSTOMERMANAGERID_"+sGXsfl_78_idx;
         edtCustomerManagerGivenName_Internalname = "CUSTOMERMANAGERGIVENNAME_"+sGXsfl_78_idx;
         edtCustomerManagerLastName_Internalname = "CUSTOMERMANAGERLASTNAME_"+sGXsfl_78_idx;
         edtCustomerManagerInitials_Internalname = "CUSTOMERMANAGERINITIALS_"+sGXsfl_78_idx;
         edtCustomerManagerEmail_Internalname = "CUSTOMERMANAGEREMAIL_"+sGXsfl_78_idx;
         edtCustomerManagerPhone_Internalname = "CUSTOMERMANAGERPHONE_"+sGXsfl_78_idx;
         cmbCustomerManagerGender_Internalname = "CUSTOMERMANAGERGENDER_"+sGXsfl_78_idx;
         edtCustomerManagerGAMGUID_Internalname = "CUSTOMERMANAGERGAMGUID_"+sGXsfl_78_idx;
      }

      protected void SubsflControlProps_fel_782( )
      {
         edtCustomerManagerId_Internalname = "CUSTOMERMANAGERID_"+sGXsfl_78_fel_idx;
         edtCustomerManagerGivenName_Internalname = "CUSTOMERMANAGERGIVENNAME_"+sGXsfl_78_fel_idx;
         edtCustomerManagerLastName_Internalname = "CUSTOMERMANAGERLASTNAME_"+sGXsfl_78_fel_idx;
         edtCustomerManagerInitials_Internalname = "CUSTOMERMANAGERINITIALS_"+sGXsfl_78_fel_idx;
         edtCustomerManagerEmail_Internalname = "CUSTOMERMANAGEREMAIL_"+sGXsfl_78_fel_idx;
         edtCustomerManagerPhone_Internalname = "CUSTOMERMANAGERPHONE_"+sGXsfl_78_fel_idx;
         cmbCustomerManagerGender_Internalname = "CUSTOMERMANAGERGENDER_"+sGXsfl_78_fel_idx;
         edtCustomerManagerGAMGUID_Internalname = "CUSTOMERMANAGERGAMGUID_"+sGXsfl_78_fel_idx;
      }

      protected void AddRow012( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_782( ) ;
         SendRow012( ) ;
      }

      protected void SendRow012( )
      {
         Gridlevel_managerRow = GXWebRow.GetNew(context);
         if ( subGridlevel_manager_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_manager_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_manager_Class, "") != 0 )
            {
               subGridlevel_manager_Linesclass = subGridlevel_manager_Class+"Odd";
            }
         }
         else if ( subGridlevel_manager_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_manager_Backstyle = 0;
            subGridlevel_manager_Backcolor = subGridlevel_manager_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_manager_Class, "") != 0 )
            {
               subGridlevel_manager_Linesclass = subGridlevel_manager_Class+"Uniform";
            }
         }
         else if ( subGridlevel_manager_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_manager_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_manager_Class, "") != 0 )
            {
               subGridlevel_manager_Linesclass = subGridlevel_manager_Class+"Odd";
            }
            subGridlevel_manager_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_manager_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_manager_Backstyle = 1;
            if ( ((int)((nGXsfl_78_idx) % (2))) == 0 )
            {
               subGridlevel_manager_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_manager_Class, "") != 0 )
               {
                  subGridlevel_manager_Linesclass = subGridlevel_manager_Class+"Even";
               }
            }
            else
            {
               subGridlevel_manager_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_manager_Class, "") != 0 )
               {
                  subGridlevel_manager_Linesclass = subGridlevel_manager_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_managerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15CustomerManagerId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerManagerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerManagerId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_managerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerGivenName_Internalname,(string)A16CustomerManagerGivenName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerManagerGivenName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerManagerGivenName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_managerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerLastName_Internalname,(string)A9CustomerManagerLastName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerManagerLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerManagerLastName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_managerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerInitials_Internalname,StringUtil.RTrim( A17CustomerManagerInitials),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerManagerInitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerManagerInitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_managerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerEmail_Internalname,(string)A10CustomerManagerEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A10CustomerManagerEmail,(string)"",(string)"",(string)"",(string)edtCustomerManagerEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerManagerEmail_Enabled,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A11CustomerManagerPhone);
         }
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_managerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerPhone_Internalname,StringUtil.RTrim( A11CustomerManagerPhone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCustomerManagerPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerManagerPhone_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_78_idx + "',78)\"";
         if ( ( cmbCustomerManagerGender.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "CUSTOMERMANAGERGENDER_" + sGXsfl_78_idx;
            cmbCustomerManagerGender.Name = GXCCtl;
            cmbCustomerManagerGender.WebTags = "";
            cmbCustomerManagerGender.addItem("Man", context.GetMessage( "Man", ""), 0);
            cmbCustomerManagerGender.addItem("Woman", context.GetMessage( "Woman", ""), 0);
            cmbCustomerManagerGender.addItem("Other", context.GetMessage( "Other", ""), 0);
            if ( cmbCustomerManagerGender.ItemCount > 0 )
            {
               A12CustomerManagerGender = cmbCustomerManagerGender.getValidValue(A12CustomerManagerGender);
               n12CustomerManagerGender = false;
            }
         }
         /* ComboBox */
         Gridlevel_managerRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCustomerManagerGender,(string)cmbCustomerManagerGender_Internalname,StringUtil.RTrim( A12CustomerManagerGender),(short)1,(string)cmbCustomerManagerGender_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbCustomerManagerGender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"",(bool)true,(short)0});
         cmbCustomerManagerGender.CurrentValue = StringUtil.RTrim( A12CustomerManagerGender);
         AssignProp("", false, cmbCustomerManagerGender_Internalname, "Values", (string)(cmbCustomerManagerGender.ToJavascriptSource()), !bGXsfl_78_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridlevel_managerRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerGAMGUID_Internalname,(string)A13CustomerManagerGAMGUID,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerManagerGAMGUID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerManagerGAMGUID_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)78,(short)0,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_managerRow);
         send_integrity_lvl_hashes012( ) ;
         GXCCtl = "Z15CustomerManagerId_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15CustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z13CustomerManagerGAMGUID_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z13CustomerManagerGAMGUID);
         GXCCtl = "Z17CustomerManagerInitials_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z17CustomerManagerInitials));
         GXCCtl = "Z16CustomerManagerGivenName_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z16CustomerManagerGivenName);
         GXCCtl = "Z9CustomerManagerLastName_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z9CustomerManagerLastName);
         GXCCtl = "Z10CustomerManagerEmail_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z10CustomerManagerEmail);
         GXCCtl = "Z11CustomerManagerPhone_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z11CustomerManagerPhone));
         GXCCtl = "Z12CustomerManagerGender_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z12CustomerManagerGender));
         GXCCtl = "nRcdDeleted_2_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_2_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_2_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_78_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_78_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV15CheckRequiredFieldsResult);
         GXCCtl = "vCUSTOMERID_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vTABSACTIVEPAGE_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TabsActivePage), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERGIVENNAME_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerGivenName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERLASTNAME_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerLastName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERINITIALS_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerInitials_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGEREMAIL_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerEmail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERPHONE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerPhone_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERGENDER_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCustomerManagerGender.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERGAMGUID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerGAMGUID_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_managerContainer.AddRow(Gridlevel_managerRow);
      }

      protected void ReadRow012( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_782( ) ;
         edtCustomerManagerId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERID_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerManagerGivenName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERGIVENNAME_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerManagerLastName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERLASTNAME_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerManagerInitials_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERINITIALS_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerManagerEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGEREMAIL_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerManagerPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERPHONE_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbCustomerManagerGender.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERGENDER_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerManagerGAMGUID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERMANAGERGAMGUID_"+sGXsfl_78_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerManagerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerManagerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CUSTOMERMANAGERID_" + sGXsfl_78_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCustomerManagerId_Internalname;
            wbErr = true;
            A15CustomerManagerId = 0;
         }
         else
         {
            A15CustomerManagerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerManagerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A16CustomerManagerGivenName = cgiGet( edtCustomerManagerGivenName_Internalname);
         A9CustomerManagerLastName = cgiGet( edtCustomerManagerLastName_Internalname);
         A17CustomerManagerInitials = cgiGet( edtCustomerManagerInitials_Internalname);
         n17CustomerManagerInitials = false;
         n17CustomerManagerInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A17CustomerManagerInitials)) ? true : false);
         A10CustomerManagerEmail = cgiGet( edtCustomerManagerEmail_Internalname);
         A11CustomerManagerPhone = cgiGet( edtCustomerManagerPhone_Internalname);
         n11CustomerManagerPhone = false;
         n11CustomerManagerPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A11CustomerManagerPhone)) ? true : false);
         cmbCustomerManagerGender.Name = cmbCustomerManagerGender_Internalname;
         cmbCustomerManagerGender.CurrentValue = cgiGet( cmbCustomerManagerGender_Internalname);
         A12CustomerManagerGender = cgiGet( cmbCustomerManagerGender_Internalname);
         n12CustomerManagerGender = false;
         n12CustomerManagerGender = (String.IsNullOrEmpty(StringUtil.RTrim( A12CustomerManagerGender)) ? true : false);
         A13CustomerManagerGAMGUID = cgiGet( edtCustomerManagerGAMGUID_Internalname);
         GXCCtl = "Z15CustomerManagerId_" + sGXsfl_78_idx;
         Z15CustomerManagerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z13CustomerManagerGAMGUID_" + sGXsfl_78_idx;
         Z13CustomerManagerGAMGUID = cgiGet( GXCCtl);
         GXCCtl = "Z17CustomerManagerInitials_" + sGXsfl_78_idx;
         Z17CustomerManagerInitials = cgiGet( GXCCtl);
         n17CustomerManagerInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A17CustomerManagerInitials)) ? true : false);
         GXCCtl = "Z16CustomerManagerGivenName_" + sGXsfl_78_idx;
         Z16CustomerManagerGivenName = cgiGet( GXCCtl);
         GXCCtl = "Z9CustomerManagerLastName_" + sGXsfl_78_idx;
         Z9CustomerManagerLastName = cgiGet( GXCCtl);
         GXCCtl = "Z10CustomerManagerEmail_" + sGXsfl_78_idx;
         Z10CustomerManagerEmail = cgiGet( GXCCtl);
         GXCCtl = "Z11CustomerManagerPhone_" + sGXsfl_78_idx;
         Z11CustomerManagerPhone = cgiGet( GXCCtl);
         n11CustomerManagerPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A11CustomerManagerPhone)) ? true : false);
         GXCCtl = "Z12CustomerManagerGender_" + sGXsfl_78_idx;
         Z12CustomerManagerGender = cgiGet( GXCCtl);
         n12CustomerManagerGender = (String.IsNullOrEmpty(StringUtil.RTrim( A12CustomerManagerGender)) ? true : false);
         GXCCtl = "nRcdDeleted_2_" + sGXsfl_78_idx;
         nRcdDeleted_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_2_" + sGXsfl_78_idx;
         nRcdExists_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_2_" + sGXsfl_78_idx;
         nIsMod_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "vTABSACTIVEPAGE_" + sGXsfl_78_idx;
         AV17TabsActivePage = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_78_idx;
         AV15CheckRequiredFieldsResult = StringUtil.StrToBool( cgiGet( GXCCtl));
      }

      protected void SubsflControlProps_973( )
      {
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID_"+sGXsfl_97_idx;
         edtCustomerLocationVisitingAddres_Internalname = "CUSTOMERLOCATIONVISITINGADDRES_"+sGXsfl_97_idx;
         edtCustomerLocationPostalAddress_Internalname = "CUSTOMERLOCATIONPOSTALADDRESS_"+sGXsfl_97_idx;
         edtCustomerLocationEmail_Internalname = "CUSTOMERLOCATIONEMAIL_"+sGXsfl_97_idx;
         edtCustomerLocationPhone_Internalname = "CUSTOMERLOCATIONPHONE_"+sGXsfl_97_idx;
         subGridlevel_receptionist_Internalname = "GRIDLEVEL_RECEPTIONIST_"+sGXsfl_97_idx;
         subGridlevel_supplier_agb_Internalname = "GRIDLEVEL_SUPPLIER_AGB_"+sGXsfl_97_idx;
         subGridlevel_supplier_gen_Internalname = "GRIDLEVEL_SUPPLIER_GEN_"+sGXsfl_97_idx;
         subGridlevel_amenities_Internalname = "GRIDLEVEL_AMENITIES_"+sGXsfl_97_idx;
      }

      protected void SubsflControlProps_fel_973( )
      {
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID_"+sGXsfl_97_fel_idx;
         edtCustomerLocationVisitingAddres_Internalname = "CUSTOMERLOCATIONVISITINGADDRES_"+sGXsfl_97_fel_idx;
         edtCustomerLocationPostalAddress_Internalname = "CUSTOMERLOCATIONPOSTALADDRESS_"+sGXsfl_97_fel_idx;
         edtCustomerLocationEmail_Internalname = "CUSTOMERLOCATIONEMAIL_"+sGXsfl_97_fel_idx;
         edtCustomerLocationPhone_Internalname = "CUSTOMERLOCATIONPHONE_"+sGXsfl_97_fel_idx;
         subGridlevel_receptionist_Internalname = "GRIDLEVEL_RECEPTIONIST_"+sGXsfl_97_fel_idx;
         subGridlevel_supplier_agb_Internalname = "GRIDLEVEL_SUPPLIER_AGB_"+sGXsfl_97_fel_idx;
         subGridlevel_supplier_gen_Internalname = "GRIDLEVEL_SUPPLIER_GEN_"+sGXsfl_97_fel_idx;
         subGridlevel_amenities_Internalname = "GRIDLEVEL_AMENITIES_"+sGXsfl_97_fel_idx;
      }

      protected void AddRow013( )
      {
         nRC_GXsfl_129 = 0;
         nRC_GXsfl_143 = 0;
         nRC_GXsfl_156 = 0;
         nRC_GXsfl_168 = 0;
         nGXsfl_97_idx = (int)(nGXsfl_97_idx+1);
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
         SendRow013( ) ;
      }

      protected void SendRow013( )
      {
         Freestylelevel_locationsRow = GXWebRow.GetNew(context);
         if ( subFreestylelevel_locations_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreestylelevel_locations_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreestylelevel_locations_Class, "") != 0 )
            {
               subFreestylelevel_locations_Linesclass = subFreestylelevel_locations_Class+"Odd";
            }
         }
         else if ( subFreestylelevel_locations_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreestylelevel_locations_Backstyle = 0;
            subFreestylelevel_locations_Backcolor = subFreestylelevel_locations_Allbackcolor;
            if ( StringUtil.StrCmp(subFreestylelevel_locations_Class, "") != 0 )
            {
               subFreestylelevel_locations_Linesclass = subFreestylelevel_locations_Class+"Uniform";
            }
         }
         else if ( subFreestylelevel_locations_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreestylelevel_locations_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreestylelevel_locations_Class, "") != 0 )
            {
               subFreestylelevel_locations_Linesclass = subFreestylelevel_locations_Class+"Odd";
            }
            subFreestylelevel_locations_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreestylelevel_locations_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreestylelevel_locations_Backstyle = 1;
            if ( ((int)((nGXsfl_97_idx) % (2))) == 0 )
            {
               subFreestylelevel_locations_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreestylelevel_locations_Class, "") != 0 )
               {
                  subFreestylelevel_locations_Linesclass = subFreestylelevel_locations_Class+"Even";
               }
            }
            else
            {
               subFreestylelevel_locations_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreestylelevel_locations_Class, "") != 0 )
               {
                  subFreestylelevel_locations_Linesclass = subFreestylelevel_locations_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Freestylelevel_locationsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylelevel_locations_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_97_idx+"\">") ;
         }
         if ( FREESTYLELEVEL_LOCATIONS_IsPaging == 0 )
         {
            GXCCtl = "GRIDLEVEL_RECEPTIONIST_nFirstRecordOnPage_" + sGXsfl_97_idx;
            GRIDLEVEL_RECEPTIONIST_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GXCCtl = "GRIDLEVEL_SUPPLIER_AGB_nFirstRecordOnPage_" + sGXsfl_97_idx;
            GRIDLEVEL_SUPPLIER_AGB_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GXCCtl = "GRIDLEVEL_SUPPLIER_GEN_nFirstRecordOnPage_" + sGXsfl_97_idx;
            GRIDLEVEL_SUPPLIER_GEN_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GXCCtl = "GRIDLEVEL_AMENITIES_nFirstRecordOnPage_" + sGXsfl_97_idx;
            GRIDLEVEL_AMENITIES_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         else
         {
            GRIDLEVEL_RECEPTIONIST_nFirstRecordOnPage = 0;
            GRIDLEVEL_SUPPLIER_AGB_nFirstRecordOnPage = 0;
            GRIDLEVEL_SUPPLIER_GEN_nFirstRecordOnPage = 0;
            GRIDLEVEL_AMENITIES_nFirstRecordOnPage = 0;
         }
         /* Table start */
         Freestylelevel_locationsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablefsfreestylelevel_locations_Internalname+"_"+sGXsfl_97_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylelevel_locationsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylelevel_locationsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableintermediateinslevel_locations_Internalname+"_"+sGXsfl_97_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6 DataContentCell DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtCustomerLocationId_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_locationsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationId_Internalname,context.GetMessage( "Location Id", ""),(string)" AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_97_idx + "',97)\"";
         ROClassString = "Attribute";
         Freestylelevel_locationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A18CustomerLocationId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtCustomerLocationId_Enabled,(short)1,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6 DataContentCell DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtCustomerLocationVisitingAddres_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_locationsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationVisitingAddres_Internalname,context.GetMessage( "Visiting Address", ""),(string)" AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Multiple line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_97_idx + "',97)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         Freestylelevel_locationsRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationVisitingAddres_Internalname,(string)A19CustomerLocationVisitingAddres,"http://maps.google.com/maps?q="+GXUtil.UrlEncode( A19CustomerLocationVisitingAddres),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"",(short)0,(short)1,(int)edtCustomerLocationVisitingAddres_Enabled,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"1024",(short)-1,(short)0,(string)"_blank",(string)"",(short)0,(bool)true,(string)"GeneXus\\Address",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6 DataContentCell DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtCustomerLocationPostalAddress_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_locationsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationPostalAddress_Internalname,context.GetMessage( "Postal Address", ""),(string)" AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_97_idx + "',97)\"";
         ROClassString = "Attribute";
         Freestylelevel_locationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationPostalAddress_Internalname,(string)A20CustomerLocationPostalAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationPostalAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtCustomerLocationPostalAddress_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6 DataContentCell DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtCustomerLocationEmail_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_locationsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationEmail_Internalname,context.GetMessage( "Location Email", ""),(string)" AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_97_idx + "',97)\"";
         ROClassString = "Attribute";
         Freestylelevel_locationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationEmail_Internalname,(string)A21CustomerLocationEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A21CustomerLocationEmail,(string)"",(string)"",(string)"",(string)edtCustomerLocationEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtCustomerLocationEmail_Enabled,(short)0,(string)"email",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6 DataContentCell DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtCustomerLocationPhone_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylelevel_locationsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationPhone_Internalname,context.GetMessage( "Location Phone", ""),(string)" AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A22CustomerLocationPhone);
         }
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_97_idx + "',97)\"";
         ROClassString = "Attribute";
         Freestylelevel_locationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationPhone_Internalname,StringUtil.RTrim( A22CustomerLocationPhone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCustomerLocationPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtCustomerLocationPhone_Enabled,(short)0,(string)"tel",(string)"",(short)20,(string)"chr",(short)1,(string)"row",(short)20,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6 CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableleaflevel_receptionist_Internalname+"_"+sGXsfl_97_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /*  Child Grid Control  */
         Freestylelevel_locationsRow.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(string)"Gridlevel_receptionistContainer"});
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_receptionistContainer = new GXWebGrid( context);
         }
         else
         {
            Gridlevel_receptionistContainer.Clear();
         }
         StartGridControl129( ) ;
         nGXsfl_129_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount4 = 2;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_4 = 1;
               ScanStart014( ) ;
               while ( RcdFound4 != 0 )
               {
                  init_level_properties4( ) ;
                  getByPrimaryKey014( ) ;
                  AddRow014( ) ;
                  ScanNext014( ) ;
               }
               ScanEnd014( ) ;
               nBlankRcdCount4 = 2;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B94CustomerLocationLastLine = A94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            standaloneNotModal014( ) ;
            standaloneModal014( ) ;
            sMode4 = Gx_mode;
            while ( nGXsfl_129_idx < nRC_GXsfl_129 )
            {
               bGXsfl_129_Refreshing = true;
               ReadRow014( ) ;
               edtCustomerLocationReceptionistId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTID_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistId_Enabled), 5, 0), !bGXsfl_129_Refreshing);
               edtCustomerLocationReceptionistGi_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTGI_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationReceptionistGi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistGi_Enabled), 5, 0), !bGXsfl_129_Refreshing);
               edtCustomerLocationReceptionistLa_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTLA_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationReceptionistLa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistLa_Enabled), 5, 0), !bGXsfl_129_Refreshing);
               edtCustomerLocationReceptionistIn_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTIN_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationReceptionistIn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistIn_Enabled), 5, 0), !bGXsfl_129_Refreshing);
               edtCustomerLocationReceptionistEm_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTEM_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationReceptionistEm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistEm_Enabled), 5, 0), !bGXsfl_129_Refreshing);
               edtCustomerLocationReceptionistAd_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTAD_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationReceptionistAd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistAd_Enabled), 5, 0), !bGXsfl_129_Refreshing);
               edtCustomerLocationReceptionistPh_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTPH_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationReceptionistPh_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistPh_Enabled), 5, 0), !bGXsfl_129_Refreshing);
               edtCustomerLocationReceptionistGA_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTGA_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCustomerLocationReceptionistGA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistGA_Enabled), 5, 0), !bGXsfl_129_Refreshing);
               if ( ( nRcdExists_4 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal014( ) ;
               }
               SendRow014( ) ;
               bGXsfl_129_Refreshing = false;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A94CustomerLocationLastLine = B94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount4 = 2;
            nRcdExists_4 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart014( ) ;
               while ( RcdFound4 != 0 )
               {
                  sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx+1), 4, 0), 4, "0") + sGXsfl_97_idx;
                  SubsflControlProps_1294( ) ;
                  init_level_properties4( ) ;
                  standaloneNotModal014( ) ;
                  getByPrimaryKey014( ) ;
                  standaloneModal014( ) ;
                  AddRow014( ) ;
                  ScanNext014( ) ;
               }
               ScanEnd014( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode4 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx+1), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_1294( ) ;
            InitAll014( ) ;
            init_level_properties4( ) ;
            B94CustomerLocationLastLine = A94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            nRcdExists_4 = 0;
            nIsMod_4 = 0;
            nRcdDeleted_4 = 0;
            if ( ( NumberUtil.Val( EvtGridId, ".") + NumberUtil.Val( EvtRowId, ".") == Convert.ToDecimal( 0 )) || (Convert.ToDecimal( 97 ) == NumberUtil.Val( EvtGridId, ".") ) && ( NumberUtil.Val( EvtRowId, ".") == NumberUtil.Val( sGXsfl_97_idx, ".") ) )
            {
               nBlankRcdCount4 = (short)(nBlankRcdUsr4+nBlankRcdCount4);
            }
            fRowAdded = 0;
            while ( nBlankRcdCount4 > 0 )
            {
               standaloneNotModal014( ) ;
               standaloneModal014( ) ;
               AddRow014( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCustomerLocationReceptionistGi_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount4 = (short)(nBlankRcdCount4-1);
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A94CustomerLocationLastLine = B94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         if ( ! isAjaxCallMode( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_receptionistContainerData"+"_"+sGXsfl_97_idx, Gridlevel_receptionistContainer.ToJavascriptSource());
         }
         if ( isAjaxCallMode( ) )
         {
            Freestylelevel_locationsRow.AddGrid("Gridlevel_receptionist", Gridlevel_receptionistContainer);
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_receptionistContainerData"+"V_"+sGXsfl_97_idx, Gridlevel_receptionistContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_receptionistContainerData"+"V_"+sGXsfl_97_idx+"\" value='"+Gridlevel_receptionistContainer.GridValuesHidden()+"'/>") ;
         }
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6 CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableleaflevel_supplier_agb_Internalname+"_"+sGXsfl_97_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /*  Child Grid Control  */
         Freestylelevel_locationsRow.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(string)"Gridlevel_supplier_agbContainer"});
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_supplier_agbContainer = new GXWebGrid( context);
         }
         else
         {
            Gridlevel_supplier_agbContainer.Clear();
         }
         StartGridControl143( ) ;
         nGXsfl_143_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount16 = 2;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_16 = 1;
               ScanStart0116( ) ;
               while ( RcdFound16 != 0 )
               {
                  init_level_properties16( ) ;
                  getByPrimaryKey0116( ) ;
                  AddRow0116( ) ;
                  ScanNext0116( ) ;
               }
               ScanEnd0116( ) ;
               nBlankRcdCount16 = 2;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B94CustomerLocationLastLine = A94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            standaloneNotModal0116( ) ;
            standaloneModal0116( ) ;
            sMode16 = Gx_mode;
            while ( nGXsfl_143_idx < nRC_GXsfl_143 )
            {
               bGXsfl_143_Refreshing = true;
               ReadRow0116( ) ;
               edtSupplier_AgbId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_AgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               edtSupplier_AgbId_Horizontalalignment = cgiGet( "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Horizontalalignment");
               AssignProp("", false, edtSupplier_AgbId_Internalname, "Horizontalalignment", edtSupplier_AgbId_Horizontalalignment, !bGXsfl_143_Refreshing);
               edtSupplier_AgbName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBNAME_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_AgbName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbName_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               edtSupplier_AgbKvkNumber_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_AgbKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbKvkNumber_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               edtSupplier_AgbVisitingAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_AgbVisitingAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbVisitingAddress_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               edtSupplier_AgbPostalAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_AgbPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPostalAddress_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               edtSupplier_AgbEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBEMAIL_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_AgbEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbEmail_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               edtSupplier_AgbPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBPHONE_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_AgbPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPhone_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               edtSupplier_AgbContactName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBCONTACTNAME_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_AgbContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbContactName_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               if ( ( nRcdExists_16 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0116( ) ;
               }
               SendRow0116( ) ;
               bGXsfl_143_Refreshing = false;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A94CustomerLocationLastLine = B94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount16 = 2;
            nRcdExists_16 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0116( ) ;
               while ( RcdFound16 != 0 )
               {
                  sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx+1), 4, 0), 4, "0") + sGXsfl_97_idx;
                  SubsflControlProps_14316( ) ;
                  init_level_properties16( ) ;
                  standaloneNotModal0116( ) ;
                  getByPrimaryKey0116( ) ;
                  standaloneModal0116( ) ;
                  AddRow0116( ) ;
                  ScanNext0116( ) ;
               }
               ScanEnd0116( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode16 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx+1), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_14316( ) ;
            InitAll0116( ) ;
            init_level_properties16( ) ;
            B94CustomerLocationLastLine = A94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            nRcdExists_16 = 0;
            nIsMod_16 = 0;
            nRcdDeleted_16 = 0;
            if ( ( NumberUtil.Val( EvtGridId, ".") + NumberUtil.Val( EvtRowId, ".") == Convert.ToDecimal( 0 )) || (Convert.ToDecimal( 97 ) == NumberUtil.Val( EvtGridId, ".") ) && ( NumberUtil.Val( EvtRowId, ".") == NumberUtil.Val( sGXsfl_97_idx, ".") ) )
            {
               nBlankRcdCount16 = (short)(nBlankRcdUsr16+nBlankRcdCount16);
            }
            fRowAdded = 0;
            while ( nBlankRcdCount16 > 0 )
            {
               standaloneNotModal0116( ) ;
               standaloneModal0116( ) ;
               AddRow0116( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtSupplier_AgbId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount16 = (short)(nBlankRcdCount16-1);
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A94CustomerLocationLastLine = B94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         if ( ! isAjaxCallMode( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_supplier_agbContainerData"+"_"+sGXsfl_97_idx, Gridlevel_supplier_agbContainer.ToJavascriptSource());
         }
         if ( isAjaxCallMode( ) )
         {
            Freestylelevel_locationsRow.AddGrid("Gridlevel_supplier_agb", Gridlevel_supplier_agbContainer);
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_supplier_agbContainerData"+"V_"+sGXsfl_97_idx, Gridlevel_supplier_agbContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_supplier_agbContainerData"+"V_"+sGXsfl_97_idx+"\" value='"+Gridlevel_supplier_agbContainer.GridValuesHidden()+"'/>") ;
         }
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6 CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableleaflevel_supplier_gen_Internalname+"_"+sGXsfl_97_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /*  Child Grid Control  */
         Freestylelevel_locationsRow.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(string)"Gridlevel_supplier_genContainer"});
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_supplier_genContainer = new GXWebGrid( context);
         }
         else
         {
            Gridlevel_supplier_genContainer.Clear();
         }
         StartGridControl156( ) ;
         nGXsfl_156_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount17 = 2;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_17 = 1;
               ScanStart0117( ) ;
               while ( RcdFound17 != 0 )
               {
                  init_level_properties17( ) ;
                  getByPrimaryKey0117( ) ;
                  AddRow0117( ) ;
                  ScanNext0117( ) ;
               }
               ScanEnd0117( ) ;
               nBlankRcdCount17 = 2;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B94CustomerLocationLastLine = A94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            standaloneNotModal0117( ) ;
            standaloneModal0117( ) ;
            sMode17 = Gx_mode;
            while ( nGXsfl_156_idx < nRC_GXsfl_156 )
            {
               bGXsfl_156_Refreshing = true;
               ReadRow0117( ) ;
               edtSupplier_GenId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENID_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_GenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenId_Enabled), 5, 0), !bGXsfl_156_Refreshing);
               edtSupplier_GenId_Horizontalalignment = cgiGet( "SUPPLIER_GENID_"+sGXsfl_156_idx+"Horizontalalignment");
               AssignProp("", false, edtSupplier_GenId_Internalname, "Horizontalalignment", edtSupplier_GenId_Horizontalalignment, !bGXsfl_156_Refreshing);
               edtSupplier_GenCompanyName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_GenCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenCompanyName_Enabled), 5, 0), !bGXsfl_156_Refreshing);
               edtSupplier_GenVisitingAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_GenVisitingAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenVisitingAddress_Enabled), 5, 0), !bGXsfl_156_Refreshing);
               edtSupplier_GenPostalAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_GenPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenPostalAddress_Enabled), 5, 0), !bGXsfl_156_Refreshing);
               edtSupplier_GenContactName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENCONTACTNAME_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_GenContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenContactName_Enabled), 5, 0), !bGXsfl_156_Refreshing);
               edtSupplier_GenContactPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENCONTACTPHONE_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplier_GenContactPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenContactPhone_Enabled), 5, 0), !bGXsfl_156_Refreshing);
               if ( ( nRcdExists_17 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0117( ) ;
               }
               SendRow0117( ) ;
               bGXsfl_156_Refreshing = false;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A94CustomerLocationLastLine = B94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount17 = 2;
            nRcdExists_17 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0117( ) ;
               while ( RcdFound17 != 0 )
               {
                  sGXsfl_156_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_156_idx+1), 4, 0), 4, "0") + sGXsfl_97_idx;
                  SubsflControlProps_15617( ) ;
                  init_level_properties17( ) ;
                  standaloneNotModal0117( ) ;
                  getByPrimaryKey0117( ) ;
                  standaloneModal0117( ) ;
                  AddRow0117( ) ;
                  ScanNext0117( ) ;
               }
               ScanEnd0117( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode17 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_156_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_156_idx+1), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_15617( ) ;
            InitAll0117( ) ;
            init_level_properties17( ) ;
            B94CustomerLocationLastLine = A94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            nRcdExists_17 = 0;
            nIsMod_17 = 0;
            nRcdDeleted_17 = 0;
            if ( ( NumberUtil.Val( EvtGridId, ".") + NumberUtil.Val( EvtRowId, ".") == Convert.ToDecimal( 0 )) || (Convert.ToDecimal( 97 ) == NumberUtil.Val( EvtGridId, ".") ) && ( NumberUtil.Val( EvtRowId, ".") == NumberUtil.Val( sGXsfl_97_idx, ".") ) )
            {
               nBlankRcdCount17 = (short)(nBlankRcdUsr17+nBlankRcdCount17);
            }
            fRowAdded = 0;
            while ( nBlankRcdCount17 > 0 )
            {
               standaloneNotModal0117( ) ;
               standaloneModal0117( ) ;
               AddRow0117( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtSupplier_GenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount17 = (short)(nBlankRcdCount17-1);
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A94CustomerLocationLastLine = B94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         if ( ! isAjaxCallMode( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_supplier_genContainerData"+"_"+sGXsfl_97_idx, Gridlevel_supplier_genContainer.ToJavascriptSource());
         }
         if ( isAjaxCallMode( ) )
         {
            Freestylelevel_locationsRow.AddGrid("Gridlevel_supplier_gen", Gridlevel_supplier_genContainer);
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_supplier_genContainerData"+"V_"+sGXsfl_97_idx, Gridlevel_supplier_genContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_supplier_genContainerData"+"V_"+sGXsfl_97_idx+"\" value='"+Gridlevel_supplier_genContainer.GridValuesHidden()+"'/>") ;
         }
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableleaflevel_amenities_Internalname+"_"+sGXsfl_97_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylelevel_locationsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /*  Child Grid Control  */
         Freestylelevel_locationsRow.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(string)"Gridlevel_amenitiesContainer"});
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_amenitiesContainer = new GXWebGrid( context);
         }
         else
         {
            Gridlevel_amenitiesContainer.Clear();
         }
         StartGridControl168( ) ;
         nGXsfl_168_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount21 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_21 = 1;
               ScanStart0121( ) ;
               while ( RcdFound21 != 0 )
               {
                  init_level_properties21( ) ;
                  getByPrimaryKey0121( ) ;
                  AddRow0121( ) ;
                  ScanNext0121( ) ;
               }
               ScanEnd0121( ) ;
               nBlankRcdCount21 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B94CustomerLocationLastLine = A94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            standaloneNotModal0121( ) ;
            standaloneModal0121( ) ;
            sMode21 = Gx_mode;
            while ( nGXsfl_168_idx < nRC_GXsfl_168 )
            {
               bGXsfl_168_Refreshing = true;
               ReadRow0121( ) ;
               edtAmenitiesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AMENITIESID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAmenitiesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtAmenitiesId_Horizontalalignment = cgiGet( "AMENITIESID_"+sGXsfl_168_idx+"Horizontalalignment");
               AssignProp("", false, edtAmenitiesId_Internalname, "Horizontalalignment", edtAmenitiesId_Horizontalalignment, !bGXsfl_168_Refreshing);
               edtAmenitiesTypeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AMENITIESTYPEID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAmenitiesTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtAmenitiesTypeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AMENITIESTYPENAME_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAmenitiesTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeName_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               if ( ( nRcdExists_21 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0121( ) ;
               }
               SendRow0121( ) ;
               bGXsfl_168_Refreshing = false;
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A94CustomerLocationLastLine = B94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount21 = 5;
            nRcdExists_21 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0121( ) ;
               while ( RcdFound21 != 0 )
               {
                  sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx+1), 4, 0), 4, "0") + sGXsfl_97_idx;
                  SubsflControlProps_16821( ) ;
                  init_level_properties21( ) ;
                  standaloneNotModal0121( ) ;
                  getByPrimaryKey0121( ) ;
                  standaloneModal0121( ) ;
                  AddRow0121( ) ;
                  ScanNext0121( ) ;
               }
               ScanEnd0121( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode21 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx+1), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_16821( ) ;
            InitAll0121( ) ;
            init_level_properties21( ) ;
            B94CustomerLocationLastLine = A94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            B95CustomerLastLineLocation = A95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
            nRcdExists_21 = 0;
            nIsMod_21 = 0;
            nRcdDeleted_21 = 0;
            if ( ( NumberUtil.Val( EvtGridId, ".") + NumberUtil.Val( EvtRowId, ".") == Convert.ToDecimal( 0 )) || (Convert.ToDecimal( 97 ) == NumberUtil.Val( EvtGridId, ".") ) && ( NumberUtil.Val( EvtRowId, ".") == NumberUtil.Val( sGXsfl_97_idx, ".") ) )
            {
               nBlankRcdCount21 = (short)(nBlankRcdUsr21+nBlankRcdCount21);
            }
            fRowAdded = 0;
            while ( nBlankRcdCount21 > 0 )
            {
               standaloneNotModal0121( ) ;
               standaloneModal0121( ) ;
               AddRow0121( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtAmenitiesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount21 = (short)(nBlankRcdCount21-1);
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A94CustomerLocationLastLine = B94CustomerLocationLastLine;
            AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
            A95CustomerLastLineLocation = B95CustomerLastLineLocation;
            AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         }
         if ( ! isAjaxCallMode( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_amenitiesContainerData"+"_"+sGXsfl_97_idx, Gridlevel_amenitiesContainer.ToJavascriptSource());
         }
         if ( isAjaxCallMode( ) )
         {
            Freestylelevel_locationsRow.AddGrid("Gridlevel_amenities", Gridlevel_amenitiesContainer);
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_amenitiesContainerData"+"V_"+sGXsfl_97_idx, Gridlevel_amenitiesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_amenitiesContainerData"+"V_"+sGXsfl_97_idx+"\" value='"+Gridlevel_amenitiesContainer.GridValuesHidden()+"'/>") ;
         }
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylelevel_locationsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* End of table */
         ajax_sending_grid_row(Freestylelevel_locationsRow);
         send_integrity_lvl_hashes013( ) ;
         GXCCtl = "Z18CustomerLocationId_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z19CustomerLocationVisitingAddres_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z19CustomerLocationVisitingAddres);
         GXCCtl = "Z20CustomerLocationPostalAddress_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z20CustomerLocationPostalAddress);
         GXCCtl = "Z21CustomerLocationEmail_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z21CustomerLocationEmail);
         GXCCtl = "Z22CustomerLocationPhone_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z22CustomerLocationPhone));
         GXCCtl = "Z94CustomerLocationLastLine_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z94CustomerLocationLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z133CustomerLocationDescription_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z133CustomerLocationDescription);
         GXCCtl = "Z134CustomerLocationName_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z134CustomerLocationName);
         GXCCtl = "O94CustomerLocationLastLine_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(O94CustomerLocationLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRC_GXsfl_129_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_129_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRC_GXsfl_143_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_143_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRC_GXsfl_156_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_156_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRC_GXsfl_168_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_168_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_3_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_3_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_97_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_97_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV15CheckRequiredFieldsResult);
         GXCCtl = "vCUSTOMERID_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "CUSTOMERLOCATIONLASTLINE_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(A94CustomerLocationLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vGXBSCREEN_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "SUPPLIER_AGBNUMBER_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, A56Supplier_AgbNumber);
         GXCCtl = "SUPPLIER_GENKVKNUMBER_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, A65Supplier_GenKvKNumber);
         GXCCtl = "AMENITIESNAME_" + sGXsfl_97_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, A101AmenitiesName);
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONID_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONVISITINGADDRES_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationVisitingAddres_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONPOSTALADDRESS_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationPostalAddress_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONEMAIL_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationEmail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONPHONE_"+sGXsfl_97_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationPhone_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         GRIDLEVEL_RECEPTIONIST_nFirstRecordOnPage = 0;
         GRIDLEVEL_RECEPTIONIST_nCurrentRecord = 0;
         /* End of Columns property logic. */
         Freestylelevel_locationsContainer.AddRow(Freestylelevel_locationsRow);
      }

      protected void ReadRow013( )
      {
         nGXsfl_97_idx = (int)(nGXsfl_97_idx+1);
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
         edtCustomerLocationId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONID_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationVisitingAddres_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONVISITINGADDRES_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationPostalAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONPOSTALADDRESS_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONEMAIL_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONPHONE_"+sGXsfl_97_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerLocationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerLocationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CUSTOMERLOCATIONID_" + sGXsfl_97_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCustomerLocationId_Internalname;
            wbErr = true;
            A18CustomerLocationId = 0;
         }
         else
         {
            A18CustomerLocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerLocationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A19CustomerLocationVisitingAddres = cgiGet( edtCustomerLocationVisitingAddres_Internalname);
         A20CustomerLocationPostalAddress = cgiGet( edtCustomerLocationPostalAddress_Internalname);
         A21CustomerLocationEmail = cgiGet( edtCustomerLocationEmail_Internalname);
         A22CustomerLocationPhone = cgiGet( edtCustomerLocationPhone_Internalname);
         GXCCtl = "Z18CustomerLocationId_" + sGXsfl_97_idx;
         Z18CustomerLocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z19CustomerLocationVisitingAddres_" + sGXsfl_97_idx;
         Z19CustomerLocationVisitingAddres = cgiGet( GXCCtl);
         GXCCtl = "Z20CustomerLocationPostalAddress_" + sGXsfl_97_idx;
         Z20CustomerLocationPostalAddress = cgiGet( GXCCtl);
         GXCCtl = "Z21CustomerLocationEmail_" + sGXsfl_97_idx;
         Z21CustomerLocationEmail = cgiGet( GXCCtl);
         GXCCtl = "Z22CustomerLocationPhone_" + sGXsfl_97_idx;
         Z22CustomerLocationPhone = cgiGet( GXCCtl);
         GXCCtl = "Z94CustomerLocationLastLine_" + sGXsfl_97_idx;
         Z94CustomerLocationLastLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z133CustomerLocationDescription_" + sGXsfl_97_idx;
         Z133CustomerLocationDescription = cgiGet( GXCCtl);
         GXCCtl = "Z134CustomerLocationName_" + sGXsfl_97_idx;
         Z134CustomerLocationName = cgiGet( GXCCtl);
         GXCCtl = "Z94CustomerLocationLastLine_" + sGXsfl_97_idx;
         A94CustomerLocationLastLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z133CustomerLocationDescription_" + sGXsfl_97_idx;
         A133CustomerLocationDescription = cgiGet( GXCCtl);
         GXCCtl = "Z134CustomerLocationName_" + sGXsfl_97_idx;
         A134CustomerLocationName = cgiGet( GXCCtl);
         GXCCtl = "O94CustomerLocationLastLine_" + sGXsfl_97_idx;
         O94CustomerLocationLastLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRC_GXsfl_129_" + sGXsfl_97_idx;
         nRC_GXsfl_129 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRC_GXsfl_143_" + sGXsfl_97_idx;
         nRC_GXsfl_143 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRC_GXsfl_156_" + sGXsfl_97_idx;
         nRC_GXsfl_156 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRC_GXsfl_168_" + sGXsfl_97_idx;
         nRC_GXsfl_168 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_97_idx;
         nRcdDeleted_3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_3_" + sGXsfl_97_idx;
         nRcdExists_3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_3_" + sGXsfl_97_idx;
         nIsMod_3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "CUSTOMERLOCATIONLASTLINE_" + sGXsfl_97_idx;
         A94CustomerLocationLastLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "vGXBSCREEN_" + sGXsfl_97_idx;
         Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "SUPPLIER_AGBNUMBER_" + sGXsfl_97_idx;
         A56Supplier_AgbNumber = cgiGet( GXCCtl);
         GXCCtl = "SUPPLIER_GENKVKNUMBER_" + sGXsfl_97_idx;
         A65Supplier_GenKvKNumber = cgiGet( GXCCtl);
         GXCCtl = "AMENITIESNAME_" + sGXsfl_97_idx;
         A101AmenitiesName = cgiGet( GXCCtl);
         GXCCtl = "nRC_GXsfl_129_" + sGXsfl_97_idx;
         nRC_GXsfl_129 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRC_GXsfl_143_" + sGXsfl_97_idx;
         nRC_GXsfl_143 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRC_GXsfl_156_" + sGXsfl_97_idx;
         nRC_GXsfl_156 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRC_GXsfl_168_" + sGXsfl_97_idx;
         nRC_GXsfl_168 = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_1294( )
      {
         edtCustomerLocationReceptionistId_Internalname = "CUSTOMERLOCATIONRECEPTIONISTID_"+sGXsfl_129_idx;
         edtCustomerLocationReceptionistGi_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGI_"+sGXsfl_129_idx;
         edtCustomerLocationReceptionistLa_Internalname = "CUSTOMERLOCATIONRECEPTIONISTLA_"+sGXsfl_129_idx;
         edtCustomerLocationReceptionistIn_Internalname = "CUSTOMERLOCATIONRECEPTIONISTIN_"+sGXsfl_129_idx;
         edtCustomerLocationReceptionistEm_Internalname = "CUSTOMERLOCATIONRECEPTIONISTEM_"+sGXsfl_129_idx;
         edtCustomerLocationReceptionistAd_Internalname = "CUSTOMERLOCATIONRECEPTIONISTAD_"+sGXsfl_129_idx;
         edtCustomerLocationReceptionistPh_Internalname = "CUSTOMERLOCATIONRECEPTIONISTPH_"+sGXsfl_129_idx;
         edtCustomerLocationReceptionistGA_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGA_"+sGXsfl_129_idx;
      }

      protected void SubsflControlProps_fel_1294( )
      {
         edtCustomerLocationReceptionistId_Internalname = "CUSTOMERLOCATIONRECEPTIONISTID_"+sGXsfl_129_fel_idx;
         edtCustomerLocationReceptionistGi_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGI_"+sGXsfl_129_fel_idx;
         edtCustomerLocationReceptionistLa_Internalname = "CUSTOMERLOCATIONRECEPTIONISTLA_"+sGXsfl_129_fel_idx;
         edtCustomerLocationReceptionistIn_Internalname = "CUSTOMERLOCATIONRECEPTIONISTIN_"+sGXsfl_129_fel_idx;
         edtCustomerLocationReceptionistEm_Internalname = "CUSTOMERLOCATIONRECEPTIONISTEM_"+sGXsfl_129_fel_idx;
         edtCustomerLocationReceptionistAd_Internalname = "CUSTOMERLOCATIONRECEPTIONISTAD_"+sGXsfl_129_fel_idx;
         edtCustomerLocationReceptionistPh_Internalname = "CUSTOMERLOCATIONRECEPTIONISTPH_"+sGXsfl_129_fel_idx;
         edtCustomerLocationReceptionistGA_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGA_"+sGXsfl_129_fel_idx;
      }

      protected void AddRow014( )
      {
         nGXsfl_129_idx = (int)(nGXsfl_129_idx+1);
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_1294( ) ;
         SendRow014( ) ;
      }

      protected void SendRow014( )
      {
         Gridlevel_receptionistRow = GXWebRow.GetNew(context);
         if ( subGridlevel_receptionist_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_receptionist_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_receptionist_Class, "") != 0 )
            {
               subGridlevel_receptionist_Linesclass = subGridlevel_receptionist_Class+"Odd";
            }
         }
         else if ( subGridlevel_receptionist_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_receptionist_Backstyle = 0;
            subGridlevel_receptionist_Backcolor = subGridlevel_receptionist_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_receptionist_Class, "") != 0 )
            {
               subGridlevel_receptionist_Linesclass = subGridlevel_receptionist_Class+"Uniform";
            }
         }
         else if ( subGridlevel_receptionist_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_receptionist_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_receptionist_Class, "") != 0 )
            {
               subGridlevel_receptionist_Linesclass = subGridlevel_receptionist_Class+"Odd";
            }
            subGridlevel_receptionist_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_receptionist_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_receptionist_Backstyle = 1;
            if ( ((int)((nGXsfl_129_idx) % (2))) == 0 )
            {
               subGridlevel_receptionist_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_receptionist_Class, "") != 0 )
               {
                  subGridlevel_receptionist_Linesclass = subGridlevel_receptionist_Class+"Even";
               }
            }
            else
            {
               subGridlevel_receptionist_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_receptionist_Class, "") != 0 )
               {
                  subGridlevel_receptionist_Linesclass = subGridlevel_receptionist_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_receptionistRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23CustomerLocationReceptionistId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtCustomerLocationReceptionistId_Enabled!=0) ? context.localUtil.Format( (decimal)(A23CustomerLocationReceptionistId), "ZZZ9") : context.localUtil.Format( (decimal)(A23CustomerLocationReceptionistId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtCustomerLocationReceptionistId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_129_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 131,'',false,'" + sGXsfl_129_idx + "',129)\"";
         ROClassString = "Attribute";
         Gridlevel_receptionistRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistGi_Internalname,(string)A24CustomerLocationReceptionistGi,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistGi_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerLocationReceptionistGi_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_129_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 132,'',false,'" + sGXsfl_129_idx + "',129)\"";
         ROClassString = "Attribute";
         Gridlevel_receptionistRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistLa_Internalname,(string)A25CustomerLocationReceptionistLa,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistLa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerLocationReceptionistLa_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_129_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 133,'',false,'" + sGXsfl_129_idx + "',129)\"";
         ROClassString = "Attribute";
         Gridlevel_receptionistRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistIn_Internalname,StringUtil.RTrim( A26CustomerLocationReceptionistIn),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistIn_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerLocationReceptionistIn_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_129_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 134,'',false,'" + sGXsfl_129_idx + "',129)\"";
         ROClassString = "Attribute";
         Gridlevel_receptionistRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistEm_Internalname,(string)A27CustomerLocationReceptionistEm,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A27CustomerLocationReceptionistEm,(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistEm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerLocationReceptionistEm_Enabled,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_129_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 135,'',false,'" + sGXsfl_129_idx + "',129)\"";
         ROClassString = "Attribute";
         Gridlevel_receptionistRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistAd_Internalname,(string)A28CustomerLocationReceptionistAd,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,135);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A28CustomerLocationReceptionistAd),(string)"_blank",(string)"",(string)"",(string)edtCustomerLocationReceptionistAd_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerLocationReceptionistAd_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A29CustomerLocationReceptionistPh);
         }
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_129_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 136,'',false,'" + sGXsfl_129_idx + "',129)\"";
         ROClassString = "Attribute";
         Gridlevel_receptionistRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistPh_Internalname,StringUtil.RTrim( A29CustomerLocationReceptionistPh),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistPh_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCustomerLocationReceptionistPh_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_receptionistRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistGA_Internalname,(string)A30CustomerLocationReceptionistGA,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistGA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtCustomerLocationReceptionistGA_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)129,(short)0,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_receptionistRow);
         send_integrity_lvl_hashes014( ) ;
         GXCCtl = "Z23CustomerLocationReceptionistId_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23CustomerLocationReceptionistId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z30CustomerLocationReceptionistGA_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z30CustomerLocationReceptionistGA);
         GXCCtl = "Z26CustomerLocationReceptionistIn_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z26CustomerLocationReceptionistIn));
         GXCCtl = "Z24CustomerLocationReceptionistGi_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z24CustomerLocationReceptionistGi);
         GXCCtl = "Z25CustomerLocationReceptionistLa_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z25CustomerLocationReceptionistLa);
         GXCCtl = "Z27CustomerLocationReceptionistEm_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z27CustomerLocationReceptionistEm);
         GXCCtl = "Z28CustomerLocationReceptionistAd_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z28CustomerLocationReceptionistAd);
         GXCCtl = "Z29CustomerLocationReceptionistPh_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z29CustomerLocationReceptionistPh));
         GXCCtl = "nRcdDeleted_4_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_4), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_4_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_4), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_4_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_4), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_129_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_129_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV15CheckRequiredFieldsResult);
         GXCCtl = "vCUSTOMERID_" + sGXsfl_129_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTID_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTGI_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistGi_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTLA_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistLa_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTIN_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistIn_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTEM_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistEm_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTAD_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistAd_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTPH_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistPh_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTGA_"+sGXsfl_129_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistGA_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_receptionistContainer.AddRow(Gridlevel_receptionistRow);
      }

      protected void ReadRow014( )
      {
         nGXsfl_129_idx = (int)(nGXsfl_129_idx+1);
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_1294( ) ;
         edtCustomerLocationReceptionistId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTID_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationReceptionistGi_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTGI_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationReceptionistLa_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTLA_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationReceptionistIn_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTIN_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationReceptionistEm_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTEM_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationReceptionistAd_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTAD_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationReceptionistPh_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTPH_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCustomerLocationReceptionistGA_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CUSTOMERLOCATIONRECEPTIONISTGA_"+sGXsfl_129_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A23CustomerLocationReceptionistId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerLocationReceptionistId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A24CustomerLocationReceptionistGi = cgiGet( edtCustomerLocationReceptionistGi_Internalname);
         A25CustomerLocationReceptionistLa = cgiGet( edtCustomerLocationReceptionistLa_Internalname);
         A26CustomerLocationReceptionistIn = cgiGet( edtCustomerLocationReceptionistIn_Internalname);
         n26CustomerLocationReceptionistIn = false;
         n26CustomerLocationReceptionistIn = (String.IsNullOrEmpty(StringUtil.RTrim( A26CustomerLocationReceptionistIn)) ? true : false);
         A27CustomerLocationReceptionistEm = cgiGet( edtCustomerLocationReceptionistEm_Internalname);
         A28CustomerLocationReceptionistAd = cgiGet( edtCustomerLocationReceptionistAd_Internalname);
         n28CustomerLocationReceptionistAd = false;
         n28CustomerLocationReceptionistAd = (String.IsNullOrEmpty(StringUtil.RTrim( A28CustomerLocationReceptionistAd)) ? true : false);
         A29CustomerLocationReceptionistPh = cgiGet( edtCustomerLocationReceptionistPh_Internalname);
         A30CustomerLocationReceptionistGA = cgiGet( edtCustomerLocationReceptionistGA_Internalname);
         GXCCtl = "Z23CustomerLocationReceptionistId_" + sGXsfl_129_idx;
         Z23CustomerLocationReceptionistId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z30CustomerLocationReceptionistGA_" + sGXsfl_129_idx;
         Z30CustomerLocationReceptionistGA = cgiGet( GXCCtl);
         GXCCtl = "Z26CustomerLocationReceptionistIn_" + sGXsfl_129_idx;
         Z26CustomerLocationReceptionistIn = cgiGet( GXCCtl);
         n26CustomerLocationReceptionistIn = (String.IsNullOrEmpty(StringUtil.RTrim( A26CustomerLocationReceptionistIn)) ? true : false);
         GXCCtl = "Z24CustomerLocationReceptionistGi_" + sGXsfl_129_idx;
         Z24CustomerLocationReceptionistGi = cgiGet( GXCCtl);
         GXCCtl = "Z25CustomerLocationReceptionistLa_" + sGXsfl_129_idx;
         Z25CustomerLocationReceptionistLa = cgiGet( GXCCtl);
         GXCCtl = "Z27CustomerLocationReceptionistEm_" + sGXsfl_129_idx;
         Z27CustomerLocationReceptionistEm = cgiGet( GXCCtl);
         GXCCtl = "Z28CustomerLocationReceptionistAd_" + sGXsfl_129_idx;
         Z28CustomerLocationReceptionistAd = cgiGet( GXCCtl);
         n28CustomerLocationReceptionistAd = (String.IsNullOrEmpty(StringUtil.RTrim( A28CustomerLocationReceptionistAd)) ? true : false);
         GXCCtl = "Z29CustomerLocationReceptionistPh_" + sGXsfl_129_idx;
         Z29CustomerLocationReceptionistPh = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_4_" + sGXsfl_129_idx;
         nRcdDeleted_4 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_4_" + sGXsfl_129_idx;
         nRcdExists_4 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_4_" + sGXsfl_129_idx;
         nIsMod_4 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_14316( )
      {
         edtSupplier_AgbId_Internalname = "SUPPLIER_AGBID_"+sGXsfl_143_idx;
         edtSupplier_AgbName_Internalname = "SUPPLIER_AGBNAME_"+sGXsfl_143_idx;
         edtSupplier_AgbKvkNumber_Internalname = "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_143_idx;
         edtSupplier_AgbVisitingAddress_Internalname = "SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_143_idx;
         edtSupplier_AgbPostalAddress_Internalname = "SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_143_idx;
         edtSupplier_AgbEmail_Internalname = "SUPPLIER_AGBEMAIL_"+sGXsfl_143_idx;
         edtSupplier_AgbPhone_Internalname = "SUPPLIER_AGBPHONE_"+sGXsfl_143_idx;
         edtSupplier_AgbContactName_Internalname = "SUPPLIER_AGBCONTACTNAME_"+sGXsfl_143_idx;
      }

      protected void SubsflControlProps_fel_14316( )
      {
         edtSupplier_AgbId_Internalname = "SUPPLIER_AGBID_"+sGXsfl_143_fel_idx;
         edtSupplier_AgbName_Internalname = "SUPPLIER_AGBNAME_"+sGXsfl_143_fel_idx;
         edtSupplier_AgbKvkNumber_Internalname = "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_143_fel_idx;
         edtSupplier_AgbVisitingAddress_Internalname = "SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_143_fel_idx;
         edtSupplier_AgbPostalAddress_Internalname = "SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_143_fel_idx;
         edtSupplier_AgbEmail_Internalname = "SUPPLIER_AGBEMAIL_"+sGXsfl_143_fel_idx;
         edtSupplier_AgbPhone_Internalname = "SUPPLIER_AGBPHONE_"+sGXsfl_143_fel_idx;
         edtSupplier_AgbContactName_Internalname = "SUPPLIER_AGBCONTACTNAME_"+sGXsfl_143_fel_idx;
      }

      protected void AddRow0116( )
      {
         nGXsfl_143_idx = (int)(nGXsfl_143_idx+1);
         sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_14316( ) ;
         SendRow0116( ) ;
      }

      protected void SendRow0116( )
      {
         Gridlevel_supplier_agbRow = GXWebRow.GetNew(context);
         if ( subGridlevel_supplier_agb_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_supplier_agb_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_supplier_agb_Class, "") != 0 )
            {
               subGridlevel_supplier_agb_Linesclass = subGridlevel_supplier_agb_Class+"Odd";
            }
         }
         else if ( subGridlevel_supplier_agb_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_supplier_agb_Backstyle = 0;
            subGridlevel_supplier_agb_Backcolor = subGridlevel_supplier_agb_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_supplier_agb_Class, "") != 0 )
            {
               subGridlevel_supplier_agb_Linesclass = subGridlevel_supplier_agb_Class+"Uniform";
            }
         }
         else if ( subGridlevel_supplier_agb_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_supplier_agb_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_supplier_agb_Class, "") != 0 )
            {
               subGridlevel_supplier_agb_Linesclass = subGridlevel_supplier_agb_Class+"Odd";
            }
            subGridlevel_supplier_agb_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_supplier_agb_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_supplier_agb_Backstyle = 1;
            if ( ((int)((nGXsfl_143_idx) % (2))) == 0 )
            {
               subGridlevel_supplier_agb_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_supplier_agb_Class, "") != 0 )
               {
                  subGridlevel_supplier_agb_Linesclass = subGridlevel_supplier_agb_Class+"Even";
               }
            }
            else
            {
               subGridlevel_supplier_agb_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_supplier_agb_Class, "") != 0 )
               {
                  subGridlevel_supplier_agb_Linesclass = subGridlevel_supplier_agb_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_143_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 144,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_agbRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A55Supplier_AgbId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,144);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_AgbId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)edtSupplier_AgbId_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_143_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_agbRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbName_Internalname,(string)A57Supplier_AgbName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_AgbName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_143_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 146,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_agbRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbKvkNumber_Internalname,(string)A58Supplier_AgbKvkNumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_AgbKvkNumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_143_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_agbRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbVisitingAddress_Internalname,(string)A59Supplier_AgbVisitingAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A59Supplier_AgbVisitingAddress),(string)"_blank",(string)"",(string)"",(string)edtSupplier_AgbVisitingAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_AgbVisitingAddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_143_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 148,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_agbRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbPostalAddress_Internalname,(string)A60Supplier_AgbPostalAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A60Supplier_AgbPostalAddress),(string)"_blank",(string)"",(string)"",(string)edtSupplier_AgbPostalAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_AgbPostalAddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_143_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 149,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_agbRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbEmail_Internalname,(string)A61Supplier_AgbEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A61Supplier_AgbEmail,(string)"",(string)"",(string)"",(string)edtSupplier_AgbEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_AgbEmail_Enabled,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A62Supplier_AgbPhone);
         }
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_143_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 150,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_agbRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbPhone_Internalname,StringUtil.RTrim( A62Supplier_AgbPhone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtSupplier_AgbPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_AgbPhone_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_143_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 151,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_agbRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbContactName_Internalname,(string)A63Supplier_AgbContactName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbContactName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_AgbContactName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_supplier_agbRow);
         send_integrity_lvl_hashes0116( ) ;
         GXCCtl = "Z55Supplier_AgbId_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_16_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_16_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_16_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_143_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_143_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV15CheckRequiredFieldsResult);
         GXCCtl = "vCUSTOMERID_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Horizontalalignment", StringUtil.RTrim( edtSupplier_AgbId_Horizontalalignment));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBNAME_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbKvkNumber_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbVisitingAddress_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPostalAddress_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBEMAIL_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbEmail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBPHONE_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPhone_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBCONTACTNAME_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbContactName_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_supplier_agbContainer.AddRow(Gridlevel_supplier_agbRow);
      }

      protected void ReadRow0116( )
      {
         nGXsfl_143_idx = (int)(nGXsfl_143_idx+1);
         sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_14316( ) ;
         edtSupplier_AgbId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_AgbId_Horizontalalignment = cgiGet( "SUPPLIER_AGBID_"+sGXsfl_143_idx+"Horizontalalignment");
         edtSupplier_AgbName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBNAME_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_AgbKvkNumber_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_AgbVisitingAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_AgbPostalAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_AgbEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBEMAIL_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_AgbPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBPHONE_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_AgbContactName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_AGBCONTACTNAME_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtSupplier_AgbId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSupplier_AgbId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "SUPPLIER_AGBID_" + sGXsfl_143_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSupplier_AgbId_Internalname;
            wbErr = true;
            A55Supplier_AgbId = 0;
         }
         else
         {
            A55Supplier_AgbId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplier_AgbId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A57Supplier_AgbName = cgiGet( edtSupplier_AgbName_Internalname);
         A58Supplier_AgbKvkNumber = cgiGet( edtSupplier_AgbKvkNumber_Internalname);
         A59Supplier_AgbVisitingAddress = cgiGet( edtSupplier_AgbVisitingAddress_Internalname);
         n59Supplier_AgbVisitingAddress = false;
         A60Supplier_AgbPostalAddress = cgiGet( edtSupplier_AgbPostalAddress_Internalname);
         n60Supplier_AgbPostalAddress = false;
         A61Supplier_AgbEmail = cgiGet( edtSupplier_AgbEmail_Internalname);
         n61Supplier_AgbEmail = false;
         A62Supplier_AgbPhone = cgiGet( edtSupplier_AgbPhone_Internalname);
         n62Supplier_AgbPhone = false;
         A63Supplier_AgbContactName = cgiGet( edtSupplier_AgbContactName_Internalname);
         n63Supplier_AgbContactName = false;
         GXCCtl = "Z55Supplier_AgbId_" + sGXsfl_143_idx;
         Z55Supplier_AgbId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_16_" + sGXsfl_143_idx;
         nRcdDeleted_16 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_16_" + sGXsfl_143_idx;
         nRcdExists_16 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_16_" + sGXsfl_143_idx;
         nIsMod_16 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_15617( )
      {
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID_"+sGXsfl_156_idx;
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_156_idx;
         edtSupplier_GenVisitingAddress_Internalname = "SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_156_idx;
         edtSupplier_GenPostalAddress_Internalname = "SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_156_idx;
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME_"+sGXsfl_156_idx;
         edtSupplier_GenContactPhone_Internalname = "SUPPLIER_GENCONTACTPHONE_"+sGXsfl_156_idx;
      }

      protected void SubsflControlProps_fel_15617( )
      {
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID_"+sGXsfl_156_fel_idx;
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_156_fel_idx;
         edtSupplier_GenVisitingAddress_Internalname = "SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_156_fel_idx;
         edtSupplier_GenPostalAddress_Internalname = "SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_156_fel_idx;
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME_"+sGXsfl_156_fel_idx;
         edtSupplier_GenContactPhone_Internalname = "SUPPLIER_GENCONTACTPHONE_"+sGXsfl_156_fel_idx;
      }

      protected void AddRow0117( )
      {
         nGXsfl_156_idx = (int)(nGXsfl_156_idx+1);
         sGXsfl_156_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_156_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_15617( ) ;
         SendRow0117( ) ;
      }

      protected void SendRow0117( )
      {
         Gridlevel_supplier_genRow = GXWebRow.GetNew(context);
         if ( subGridlevel_supplier_gen_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_supplier_gen_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_supplier_gen_Class, "") != 0 )
            {
               subGridlevel_supplier_gen_Linesclass = subGridlevel_supplier_gen_Class+"Odd";
            }
         }
         else if ( subGridlevel_supplier_gen_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_supplier_gen_Backstyle = 0;
            subGridlevel_supplier_gen_Backcolor = subGridlevel_supplier_gen_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_supplier_gen_Class, "") != 0 )
            {
               subGridlevel_supplier_gen_Linesclass = subGridlevel_supplier_gen_Class+"Uniform";
            }
         }
         else if ( subGridlevel_supplier_gen_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_supplier_gen_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_supplier_gen_Class, "") != 0 )
            {
               subGridlevel_supplier_gen_Linesclass = subGridlevel_supplier_gen_Class+"Odd";
            }
            subGridlevel_supplier_gen_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_supplier_gen_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_supplier_gen_Backstyle = 1;
            if ( ((int)((nGXsfl_156_idx) % (2))) == 0 )
            {
               subGridlevel_supplier_gen_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_supplier_gen_Class, "") != 0 )
               {
                  subGridlevel_supplier_gen_Linesclass = subGridlevel_supplier_gen_Class+"Even";
               }
            }
            else
            {
               subGridlevel_supplier_gen_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_supplier_gen_Class, "") != 0 )
               {
                  subGridlevel_supplier_gen_Linesclass = subGridlevel_supplier_gen_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_17_" + sGXsfl_156_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 157,'',false,'" + sGXsfl_156_idx + "',156)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_genRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,157);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_GenId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)156,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)edtSupplier_GenId_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_17_" + sGXsfl_156_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 158,'',false,'" + sGXsfl_156_idx + "',156)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_genRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenCompanyName_Internalname,(string)A66Supplier_GenCompanyName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_GenCompanyName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)156,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_17_" + sGXsfl_156_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 159,'',false,'" + sGXsfl_156_idx + "',156)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_genRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenVisitingAddress_Internalname,(string)A67Supplier_GenVisitingAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A67Supplier_GenVisitingAddress),(string)"_blank",(string)"",(string)"",(string)edtSupplier_GenVisitingAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_GenVisitingAddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)156,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_17_" + sGXsfl_156_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 160,'',false,'" + sGXsfl_156_idx + "',156)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_genRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenPostalAddress_Internalname,(string)A68Supplier_GenPostalAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A68Supplier_GenPostalAddress),(string)"_blank",(string)"",(string)"",(string)edtSupplier_GenPostalAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_GenPostalAddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)156,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_17_" + sGXsfl_156_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 161,'',false,'" + sGXsfl_156_idx + "',156)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_genRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenContactName_Internalname,(string)A69Supplier_GenContactName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenContactName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_GenContactName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)156,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A70Supplier_GenContactPhone);
         }
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_17_" + sGXsfl_156_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 162,'',false,'" + sGXsfl_156_idx + "',156)\"";
         ROClassString = "Attribute";
         Gridlevel_supplier_genRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenContactPhone_Internalname,StringUtil.RTrim( A70Supplier_GenContactPhone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtSupplier_GenContactPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSupplier_GenContactPhone_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)156,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_supplier_genRow);
         send_integrity_lvl_hashes0117( ) ;
         GXCCtl = "Z64Supplier_GenId_" + sGXsfl_156_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_17_" + sGXsfl_156_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_17), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_17_" + sGXsfl_156_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_17), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_17_" + sGXsfl_156_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_17), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_156_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_156_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_156_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV15CheckRequiredFieldsResult);
         GXCCtl = "vCUSTOMERID_" + sGXsfl_156_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENID_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENID_"+sGXsfl_156_idx+"Horizontalalignment", StringUtil.RTrim( edtSupplier_GenId_Horizontalalignment));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenCompanyName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenVisitingAddress_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenPostalAddress_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENCONTACTNAME_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENCONTACTPHONE_"+sGXsfl_156_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactPhone_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_supplier_genContainer.AddRow(Gridlevel_supplier_genRow);
      }

      protected void ReadRow0117( )
      {
         nGXsfl_156_idx = (int)(nGXsfl_156_idx+1);
         sGXsfl_156_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_156_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_15617( ) ;
         edtSupplier_GenId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENID_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_GenId_Horizontalalignment = cgiGet( "SUPPLIER_GENID_"+sGXsfl_156_idx+"Horizontalalignment");
         edtSupplier_GenCompanyName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_GenVisitingAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_GenPostalAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_GenContactName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENCONTACTNAME_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSupplier_GenContactPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIER_GENCONTACTPHONE_"+sGXsfl_156_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtSupplier_GenId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSupplier_GenId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "SUPPLIER_GENID_" + sGXsfl_156_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSupplier_GenId_Internalname;
            wbErr = true;
            A64Supplier_GenId = 0;
         }
         else
         {
            A64Supplier_GenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplier_GenId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A66Supplier_GenCompanyName = cgiGet( edtSupplier_GenCompanyName_Internalname);
         A67Supplier_GenVisitingAddress = cgiGet( edtSupplier_GenVisitingAddress_Internalname);
         n67Supplier_GenVisitingAddress = false;
         A68Supplier_GenPostalAddress = cgiGet( edtSupplier_GenPostalAddress_Internalname);
         n68Supplier_GenPostalAddress = false;
         A69Supplier_GenContactName = cgiGet( edtSupplier_GenContactName_Internalname);
         n69Supplier_GenContactName = false;
         A70Supplier_GenContactPhone = cgiGet( edtSupplier_GenContactPhone_Internalname);
         n70Supplier_GenContactPhone = false;
         GXCCtl = "Z64Supplier_GenId_" + sGXsfl_156_idx;
         Z64Supplier_GenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_17_" + sGXsfl_156_idx;
         nRcdDeleted_17 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_17_" + sGXsfl_156_idx;
         nRcdExists_17 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_17_" + sGXsfl_156_idx;
         nIsMod_17 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_16821( )
      {
         edtAmenitiesId_Internalname = "AMENITIESID_"+sGXsfl_168_idx;
         edtAmenitiesTypeId_Internalname = "AMENITIESTYPEID_"+sGXsfl_168_idx;
         edtAmenitiesTypeName_Internalname = "AMENITIESTYPENAME_"+sGXsfl_168_idx;
      }

      protected void SubsflControlProps_fel_16821( )
      {
         edtAmenitiesId_Internalname = "AMENITIESID_"+sGXsfl_168_fel_idx;
         edtAmenitiesTypeId_Internalname = "AMENITIESTYPEID_"+sGXsfl_168_fel_idx;
         edtAmenitiesTypeName_Internalname = "AMENITIESTYPENAME_"+sGXsfl_168_fel_idx;
      }

      protected void AddRow0121( )
      {
         nGXsfl_168_idx = (int)(nGXsfl_168_idx+1);
         sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_16821( ) ;
         SendRow0121( ) ;
      }

      protected void SendRow0121( )
      {
         Gridlevel_amenitiesRow = GXWebRow.GetNew(context);
         if ( subGridlevel_amenities_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_amenities_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_amenities_Class, "") != 0 )
            {
               subGridlevel_amenities_Linesclass = subGridlevel_amenities_Class+"Odd";
            }
         }
         else if ( subGridlevel_amenities_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_amenities_Backstyle = 0;
            subGridlevel_amenities_Backcolor = subGridlevel_amenities_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_amenities_Class, "") != 0 )
            {
               subGridlevel_amenities_Linesclass = subGridlevel_amenities_Class+"Uniform";
            }
         }
         else if ( subGridlevel_amenities_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_amenities_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_amenities_Class, "") != 0 )
            {
               subGridlevel_amenities_Linesclass = subGridlevel_amenities_Class+"Odd";
            }
            subGridlevel_amenities_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_amenities_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_amenities_Backstyle = 1;
            if ( ((int)((nGXsfl_168_idx) % (2))) == 0 )
            {
               subGridlevel_amenities_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_amenities_Class, "") != 0 )
               {
                  subGridlevel_amenities_Linesclass = subGridlevel_amenities_Class+"Even";
               }
            }
            else
            {
               subGridlevel_amenities_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_amenities_Class, "") != 0 )
               {
                  subGridlevel_amenities_Linesclass = subGridlevel_amenities_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_21_" + sGXsfl_168_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 169,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_amenitiesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmenitiesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A98AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A98AmenitiesId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,169);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmenitiesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAmenitiesId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)edtAmenitiesId_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_21_" + sGXsfl_168_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 170,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_amenitiesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmenitiesTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A99AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtAmenitiesTypeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A99AmenitiesTypeId), "ZZZ9") : context.localUtil.Format( (decimal)(A99AmenitiesTypeId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,170);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmenitiesTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAmenitiesTypeId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_21_" + sGXsfl_168_idx + "',1);gx.fn.setControlValue('nIsMod_3_" + sGXsfl_97_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 171,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_amenitiesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmenitiesTypeName_Internalname,(string)A100AmenitiesTypeName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmenitiesTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAmenitiesTypeName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_amenitiesRow);
         send_integrity_lvl_hashes0121( ) ;
         GXCCtl = "Z98AmenitiesId_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_21_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_21), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_21_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_21), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_21_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_21), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_168_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_168_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV15CheckRequiredFieldsResult);
         GXCCtl = "vCUSTOMERID_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "AMENITIESID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AMENITIESID_"+sGXsfl_168_idx+"Horizontalalignment", StringUtil.RTrim( edtAmenitiesId_Horizontalalignment));
         GxWebStd.gx_hidden_field( context, "AMENITIESTYPEID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AMENITIESTYPENAME_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesTypeName_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_amenitiesContainer.AddRow(Gridlevel_amenitiesRow);
      }

      protected void ReadRow0121( )
      {
         nGXsfl_168_idx = (int)(nGXsfl_168_idx+1);
         sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_16821( ) ;
         edtAmenitiesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AMENITIESID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtAmenitiesId_Horizontalalignment = cgiGet( "AMENITIESID_"+sGXsfl_168_idx+"Horizontalalignment");
         edtAmenitiesTypeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AMENITIESTYPEID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtAmenitiesTypeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AMENITIESTYPENAME_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtAmenitiesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAmenitiesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "AMENITIESID_" + sGXsfl_168_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAmenitiesId_Internalname;
            wbErr = true;
            A98AmenitiesId = 0;
         }
         else
         {
            A98AmenitiesId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAmenitiesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A99AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAmenitiesTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A100AmenitiesTypeName = cgiGet( edtAmenitiesTypeName_Internalname);
         GXCCtl = "Z98AmenitiesId_" + sGXsfl_168_idx;
         Z98AmenitiesId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_21_" + sGXsfl_168_idx;
         nRcdDeleted_21 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_21_" + sGXsfl_168_idx;
         nRcdExists_21 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_21_" + sGXsfl_168_idx;
         nIsMod_21 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtCustomerLocationReceptionistGA_Enabled = edtCustomerLocationReceptionistGA_Enabled;
         defedtCustomerLocationReceptionistId_Enabled = edtCustomerLocationReceptionistId_Enabled;
         defedtSupplier_AgbId_Enabled = edtSupplier_AgbId_Enabled;
         defedtSupplier_GenId_Enabled = edtSupplier_GenId_Enabled;
         defedtAmenitiesId_Enabled = edtAmenitiesId_Enabled;
         defedtCustomerLocationId_Enabled = edtCustomerLocationId_Enabled;
         defedtCustomerManagerId_Enabled = edtCustomerManagerId_Enabled;
      }

      protected void ConfirmValues010( )
      {
         nGXsfl_78_idx = 0;
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_782( ) ;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_782( ) ;
            ChangePostValue( "Z15CustomerManagerId_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z15CustomerManagerId_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z15CustomerManagerId_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z13CustomerManagerGAMGUID_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z13CustomerManagerGAMGUID_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z13CustomerManagerGAMGUID_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z17CustomerManagerInitials_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z17CustomerManagerInitials_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z17CustomerManagerInitials_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z16CustomerManagerGivenName_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z16CustomerManagerGivenName_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z16CustomerManagerGivenName_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z9CustomerManagerLastName_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z9CustomerManagerLastName_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z9CustomerManagerLastName_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z10CustomerManagerEmail_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z10CustomerManagerEmail_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z10CustomerManagerEmail_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z11CustomerManagerPhone_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z11CustomerManagerPhone_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z11CustomerManagerPhone_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z12CustomerManagerGender_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z12CustomerManagerGender_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z12CustomerManagerGender_"+sGXsfl_78_idx) ;
         }
         nGXsfl_129_idx = 0;
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_1294( ) ;
         while ( nGXsfl_129_idx < nRC_GXsfl_129 )
         {
            nGXsfl_129_idx = (int)(nGXsfl_129_idx+1);
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_1294( ) ;
            ChangePostValue( "Z23CustomerLocationReceptionistId_"+sGXsfl_129_idx, cgiGet( "ZT_"+"Z23CustomerLocationReceptionistId_"+sGXsfl_129_idx)) ;
            DeletePostValue( "ZT_"+"Z23CustomerLocationReceptionistId_"+sGXsfl_129_idx) ;
            ChangePostValue( "Z30CustomerLocationReceptionistGA_"+sGXsfl_129_idx, cgiGet( "ZT_"+"Z30CustomerLocationReceptionistGA_"+sGXsfl_129_idx)) ;
            DeletePostValue( "ZT_"+"Z30CustomerLocationReceptionistGA_"+sGXsfl_129_idx) ;
            ChangePostValue( "Z26CustomerLocationReceptionistIn_"+sGXsfl_129_idx, cgiGet( "ZT_"+"Z26CustomerLocationReceptionistIn_"+sGXsfl_129_idx)) ;
            DeletePostValue( "ZT_"+"Z26CustomerLocationReceptionistIn_"+sGXsfl_129_idx) ;
            ChangePostValue( "Z24CustomerLocationReceptionistGi_"+sGXsfl_129_idx, cgiGet( "ZT_"+"Z24CustomerLocationReceptionistGi_"+sGXsfl_129_idx)) ;
            DeletePostValue( "ZT_"+"Z24CustomerLocationReceptionistGi_"+sGXsfl_129_idx) ;
            ChangePostValue( "Z25CustomerLocationReceptionistLa_"+sGXsfl_129_idx, cgiGet( "ZT_"+"Z25CustomerLocationReceptionistLa_"+sGXsfl_129_idx)) ;
            DeletePostValue( "ZT_"+"Z25CustomerLocationReceptionistLa_"+sGXsfl_129_idx) ;
            ChangePostValue( "Z27CustomerLocationReceptionistEm_"+sGXsfl_129_idx, cgiGet( "ZT_"+"Z27CustomerLocationReceptionistEm_"+sGXsfl_129_idx)) ;
            DeletePostValue( "ZT_"+"Z27CustomerLocationReceptionistEm_"+sGXsfl_129_idx) ;
            ChangePostValue( "Z28CustomerLocationReceptionistAd_"+sGXsfl_129_idx, cgiGet( "ZT_"+"Z28CustomerLocationReceptionistAd_"+sGXsfl_129_idx)) ;
            DeletePostValue( "ZT_"+"Z28CustomerLocationReceptionistAd_"+sGXsfl_129_idx) ;
            ChangePostValue( "Z29CustomerLocationReceptionistPh_"+sGXsfl_129_idx, cgiGet( "ZT_"+"Z29CustomerLocationReceptionistPh_"+sGXsfl_129_idx)) ;
            DeletePostValue( "ZT_"+"Z29CustomerLocationReceptionistPh_"+sGXsfl_129_idx) ;
         }
         nGXsfl_143_idx = 0;
         sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_14316( ) ;
         while ( nGXsfl_143_idx < nRC_GXsfl_143 )
         {
            nGXsfl_143_idx = (int)(nGXsfl_143_idx+1);
            sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_14316( ) ;
            ChangePostValue( "Z55Supplier_AgbId_"+sGXsfl_143_idx, cgiGet( "ZT_"+"Z55Supplier_AgbId_"+sGXsfl_143_idx)) ;
            DeletePostValue( "ZT_"+"Z55Supplier_AgbId_"+sGXsfl_143_idx) ;
         }
         nGXsfl_156_idx = 0;
         sGXsfl_156_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_156_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_15617( ) ;
         while ( nGXsfl_156_idx < nRC_GXsfl_156 )
         {
            nGXsfl_156_idx = (int)(nGXsfl_156_idx+1);
            sGXsfl_156_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_156_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_15617( ) ;
            ChangePostValue( "Z64Supplier_GenId_"+sGXsfl_156_idx, cgiGet( "ZT_"+"Z64Supplier_GenId_"+sGXsfl_156_idx)) ;
            DeletePostValue( "ZT_"+"Z64Supplier_GenId_"+sGXsfl_156_idx) ;
         }
         nGXsfl_168_idx = 0;
         sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
         SubsflControlProps_16821( ) ;
         while ( nGXsfl_168_idx < nRC_GXsfl_168 )
         {
            nGXsfl_168_idx = (int)(nGXsfl_168_idx+1);
            sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_16821( ) ;
            ChangePostValue( "Z98AmenitiesId_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z98AmenitiesId_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z98AmenitiesId_"+sGXsfl_168_idx) ;
         }
         nGXsfl_97_idx = 0;
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
         while ( nGXsfl_97_idx < nRC_GXsfl_97 )
         {
            nGXsfl_97_idx = (int)(nGXsfl_97_idx+1);
            sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
            SubsflControlProps_973( ) ;
            ChangePostValue( "Z18CustomerLocationId_"+sGXsfl_97_idx, cgiGet( "ZT_"+"Z18CustomerLocationId_"+sGXsfl_97_idx)) ;
            DeletePostValue( "ZT_"+"Z18CustomerLocationId_"+sGXsfl_97_idx) ;
            ChangePostValue( "Z19CustomerLocationVisitingAddres_"+sGXsfl_97_idx, cgiGet( "ZT_"+"Z19CustomerLocationVisitingAddres_"+sGXsfl_97_idx)) ;
            DeletePostValue( "ZT_"+"Z19CustomerLocationVisitingAddres_"+sGXsfl_97_idx) ;
            ChangePostValue( "Z20CustomerLocationPostalAddress_"+sGXsfl_97_idx, cgiGet( "ZT_"+"Z20CustomerLocationPostalAddress_"+sGXsfl_97_idx)) ;
            DeletePostValue( "ZT_"+"Z20CustomerLocationPostalAddress_"+sGXsfl_97_idx) ;
            ChangePostValue( "Z21CustomerLocationEmail_"+sGXsfl_97_idx, cgiGet( "ZT_"+"Z21CustomerLocationEmail_"+sGXsfl_97_idx)) ;
            DeletePostValue( "ZT_"+"Z21CustomerLocationEmail_"+sGXsfl_97_idx) ;
            ChangePostValue( "Z22CustomerLocationPhone_"+sGXsfl_97_idx, cgiGet( "ZT_"+"Z22CustomerLocationPhone_"+sGXsfl_97_idx)) ;
            DeletePostValue( "ZT_"+"Z22CustomerLocationPhone_"+sGXsfl_97_idx) ;
            ChangePostValue( "Z94CustomerLocationLastLine_"+sGXsfl_97_idx, cgiGet( "ZT_"+"Z94CustomerLocationLastLine_"+sGXsfl_97_idx)) ;
            DeletePostValue( "ZT_"+"Z94CustomerLocationLastLine_"+sGXsfl_97_idx) ;
            ChangePostValue( "Z133CustomerLocationDescription_"+sGXsfl_97_idx, cgiGet( "ZT_"+"Z133CustomerLocationDescription_"+sGXsfl_97_idx)) ;
            DeletePostValue( "ZT_"+"Z133CustomerLocationDescription_"+sGXsfl_97_idx) ;
            ChangePostValue( "Z134CustomerLocationName_"+sGXsfl_97_idx, cgiGet( "ZT_"+"Z134CustomerLocationName_"+sGXsfl_97_idx)) ;
            DeletePostValue( "ZT_"+"Z134CustomerLocationName_"+sGXsfl_97_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("customer.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CustomerId,4,0))}, new string[] {"Gx_mode","CustomerId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Customer");
         forbiddenHiddens.Add("CustomerId", context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("customer:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z41CustomerKvkNumber", Z41CustomerKvkNumber);
         GxWebStd.gx_hidden_field( context, "Z3CustomerName", Z3CustomerName);
         GxWebStd.gx_hidden_field( context, "Z4CustomerPostalAddress", Z4CustomerPostalAddress);
         GxWebStd.gx_hidden_field( context, "Z5CustomerEmail", Z5CustomerEmail);
         GxWebStd.gx_hidden_field( context, "Z6CustomerVisitingAddress", Z6CustomerVisitingAddress);
         GxWebStd.gx_hidden_field( context, "Z7CustomerPhone", StringUtil.RTrim( Z7CustomerPhone));
         GxWebStd.gx_hidden_field( context, "Z14CustomerVatNumber", Z14CustomerVatNumber);
         GxWebStd.gx_hidden_field( context, "Z93CustomerLastLine", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z93CustomerLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z95CustomerLastLineLocation", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z95CustomerLastLineLocation), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z78CustomerTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z78CustomerTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O95CustomerLastLineLocation", StringUtil.LTrim( StringUtil.NToC( (decimal)(O95CustomerLastLineLocation), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O93CustomerLastLine", StringUtil.LTrim( StringUtil.NToC( (decimal)(O93CustomerLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_78", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_78_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_97", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_97_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N78CustomerTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A78CustomerTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUSTOMERTYPEID_DATA", AV26CustomerTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUSTOMERTYPEID_DATA", AV26CustomerTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIER_AGBID_DATA", AV25Supplier_AgbId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIER_AGBID_DATA", AV25Supplier_AgbId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIER_GENID_DATA", AV18Supplier_GenId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIER_GENID_DATA", AV18Supplier_GenId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAMENITIESID_DATA", AV28AmenitiesId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAMENITIESID_DATA", AV28AmenitiesId_Data);
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
         GxWebStd.gx_hidden_field( context, "vCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CustomerId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUSTOMERTYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_CustomerTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLASTLINELOCATION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A95CustomerLastLineLocation), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERTYPENAME", A79CustomerTypeName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV30Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONLASTLINE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A94CustomerLocationLastLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONDESCRIPTION", A133CustomerLocationDescription);
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONNAME", A134CustomerLocationName);
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERTYPEID_Objectcall", StringUtil.RTrim( Combo_customertypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERTYPEID_Cls", StringUtil.RTrim( Combo_customertypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_customertypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERTYPEID_Selectedtext_set", StringUtil.RTrim( Combo_customertypeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERTYPEID_Gamoauthtoken", StringUtil.RTrim( Combo_customertypeid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERTYPEID_Enabled", StringUtil.BoolToStr( Combo_customertypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERTYPEID_Datalistproc", StringUtil.RTrim( Combo_customertypeid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERTYPEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_customertypeid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Objectcall", StringUtil.RTrim( Gxuitabspanel_steps_Objectcall));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Enabled", StringUtil.BoolToStr( Gxuitabspanel_steps_Enabled));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_steps_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Class", StringUtil.RTrim( Gxuitabspanel_steps_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_steps_Historymanagement));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Objectcall", StringUtil.RTrim( Combo_supplier_agbid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Cls", StringUtil.RTrim( Combo_supplier_agbid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Gamoauthtoken", StringUtil.RTrim( Combo_supplier_agbid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Enabled", StringUtil.BoolToStr( Combo_supplier_agbid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_supplier_agbid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Isgriditem", StringUtil.BoolToStr( Combo_supplier_agbid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Hasdescription", StringUtil.BoolToStr( Combo_supplier_agbid_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Datalistproc", StringUtil.RTrim( Combo_supplier_agbid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_supplier_agbid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_AGBID_Emptyitem", StringUtil.BoolToStr( Combo_supplier_agbid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Objectcall", StringUtil.RTrim( Combo_supplier_genid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Cls", StringUtil.RTrim( Combo_supplier_genid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Gamoauthtoken", StringUtil.RTrim( Combo_supplier_genid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Enabled", StringUtil.BoolToStr( Combo_supplier_genid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_supplier_genid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Isgriditem", StringUtil.BoolToStr( Combo_supplier_genid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Hasdescription", StringUtil.BoolToStr( Combo_supplier_genid_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Datalistproc", StringUtil.RTrim( Combo_supplier_genid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_supplier_genid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIER_GENID_Emptyitem", StringUtil.BoolToStr( Combo_supplier_genid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Objectcall", StringUtil.RTrim( Combo_amenitiesid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Cls", StringUtil.RTrim( Combo_amenitiesid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Gamoauthtoken", StringUtil.RTrim( Combo_amenitiesid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Enabled", StringUtil.BoolToStr( Combo_amenitiesid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_amenitiesid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Isgriditem", StringUtil.BoolToStr( Combo_amenitiesid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Hasdescription", StringUtil.BoolToStr( Combo_amenitiesid_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Datalistproc", StringUtil.RTrim( Combo_amenitiesid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_amenitiesid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESID_Emptyitem", StringUtil.BoolToStr( Combo_amenitiesid_Emptyitem));
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
         return formatLink("customer.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CustomerId,4,0))}, new string[] {"Gx_mode","CustomerId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Customer" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Customer", "") ;
      }

      protected void InitializeNonKey011( )
      {
         A78CustomerTypeId = 0;
         n78CustomerTypeId = false;
         AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
         n78CustomerTypeId = ((0==A78CustomerTypeId) ? true : false);
         A41CustomerKvkNumber = "";
         AssignAttri("", false, "A41CustomerKvkNumber", A41CustomerKvkNumber);
         A3CustomerName = "";
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         A4CustomerPostalAddress = "";
         n4CustomerPostalAddress = false;
         AssignAttri("", false, "A4CustomerPostalAddress", A4CustomerPostalAddress);
         n4CustomerPostalAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A4CustomerPostalAddress)) ? true : false);
         A5CustomerEmail = "";
         n5CustomerEmail = false;
         AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
         n5CustomerEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A5CustomerEmail)) ? true : false);
         A6CustomerVisitingAddress = "";
         n6CustomerVisitingAddress = false;
         AssignAttri("", false, "A6CustomerVisitingAddress", A6CustomerVisitingAddress);
         n6CustomerVisitingAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A6CustomerVisitingAddress)) ? true : false);
         A7CustomerPhone = "";
         n7CustomerPhone = false;
         AssignAttri("", false, "A7CustomerPhone", A7CustomerPhone);
         n7CustomerPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A7CustomerPhone)) ? true : false);
         A14CustomerVatNumber = "";
         AssignAttri("", false, "A14CustomerVatNumber", A14CustomerVatNumber);
         A79CustomerTypeName = "";
         AssignAttri("", false, "A79CustomerTypeName", A79CustomerTypeName);
         A93CustomerLastLine = 0;
         AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         A95CustomerLastLineLocation = 0;
         AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         O95CustomerLastLineLocation = A95CustomerLastLineLocation;
         AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
         O93CustomerLastLine = A93CustomerLastLine;
         AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
         Z41CustomerKvkNumber = "";
         Z3CustomerName = "";
         Z4CustomerPostalAddress = "";
         Z5CustomerEmail = "";
         Z6CustomerVisitingAddress = "";
         Z7CustomerPhone = "";
         Z14CustomerVatNumber = "";
         Z93CustomerLastLine = 0;
         Z95CustomerLastLineLocation = 0;
         Z78CustomerTypeId = 0;
      }

      protected void InitAll011( )
      {
         A1CustomerId = 0;
         AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey012( )
      {
         A13CustomerManagerGAMGUID = "";
         A17CustomerManagerInitials = "";
         n17CustomerManagerInitials = false;
         A16CustomerManagerGivenName = "";
         A9CustomerManagerLastName = "";
         A10CustomerManagerEmail = "";
         A11CustomerManagerPhone = "";
         n11CustomerManagerPhone = false;
         A12CustomerManagerGender = "";
         n12CustomerManagerGender = false;
         Z13CustomerManagerGAMGUID = "";
         Z17CustomerManagerInitials = "";
         Z16CustomerManagerGivenName = "";
         Z9CustomerManagerLastName = "";
         Z10CustomerManagerEmail = "";
         Z11CustomerManagerPhone = "";
         Z12CustomerManagerGender = "";
      }

      protected void InitAll012( )
      {
         A15CustomerManagerId = 0;
         InitializeNonKey012( ) ;
      }

      protected void StandaloneModalInsert012( )
      {
         A93CustomerLastLine = i93CustomerLastLine;
         AssignAttri("", false, "A93CustomerLastLine", StringUtil.LTrimStr( (decimal)(A93CustomerLastLine), 4, 0));
      }

      protected void InitializeNonKey013( )
      {
         A19CustomerLocationVisitingAddres = "";
         A20CustomerLocationPostalAddress = "";
         A21CustomerLocationEmail = "";
         A22CustomerLocationPhone = "";
         A94CustomerLocationLastLine = 0;
         AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
         A133CustomerLocationDescription = "";
         AssignAttri("", false, "A133CustomerLocationDescription", A133CustomerLocationDescription);
         A134CustomerLocationName = "";
         AssignAttri("", false, "A134CustomerLocationName", A134CustomerLocationName);
         O94CustomerLocationLastLine = A94CustomerLocationLastLine;
         AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
         Z19CustomerLocationVisitingAddres = "";
         Z20CustomerLocationPostalAddress = "";
         Z21CustomerLocationEmail = "";
         Z22CustomerLocationPhone = "";
         Z94CustomerLocationLastLine = 0;
         Z133CustomerLocationDescription = "";
         Z134CustomerLocationName = "";
      }

      protected void InitAll013( )
      {
         A18CustomerLocationId = 0;
         InitializeNonKey013( ) ;
      }

      protected void StandaloneModalInsert013( )
      {
         A95CustomerLastLineLocation = i95CustomerLastLineLocation;
         AssignAttri("", false, "A95CustomerLastLineLocation", StringUtil.LTrimStr( (decimal)(A95CustomerLastLineLocation), 4, 0));
      }

      protected void InitializeNonKey014( )
      {
         A30CustomerLocationReceptionistGA = "";
         A26CustomerLocationReceptionistIn = "";
         n26CustomerLocationReceptionistIn = false;
         A24CustomerLocationReceptionistGi = "";
         A25CustomerLocationReceptionistLa = "";
         A27CustomerLocationReceptionistEm = "";
         A28CustomerLocationReceptionistAd = "";
         n28CustomerLocationReceptionistAd = false;
         A29CustomerLocationReceptionistPh = "";
         Z30CustomerLocationReceptionistGA = "";
         Z26CustomerLocationReceptionistIn = "";
         Z24CustomerLocationReceptionistGi = "";
         Z25CustomerLocationReceptionistLa = "";
         Z27CustomerLocationReceptionistEm = "";
         Z28CustomerLocationReceptionistAd = "";
         Z29CustomerLocationReceptionistPh = "";
      }

      protected void InitAll014( )
      {
         A23CustomerLocationReceptionistId = 0;
         InitializeNonKey014( ) ;
      }

      protected void StandaloneModalInsert014( )
      {
         A94CustomerLocationLastLine = i94CustomerLocationLastLine;
         AssignAttri("", false, "A94CustomerLocationLastLine", StringUtil.LTrimStr( (decimal)(A94CustomerLocationLastLine), 4, 0));
      }

      protected void InitializeNonKey0116( )
      {
         A56Supplier_AgbNumber = "";
         AssignAttri("", false, "A56Supplier_AgbNumber", A56Supplier_AgbNumber);
         A57Supplier_AgbName = "";
         A58Supplier_AgbKvkNumber = "";
         A59Supplier_AgbVisitingAddress = "";
         n59Supplier_AgbVisitingAddress = false;
         A60Supplier_AgbPostalAddress = "";
         n60Supplier_AgbPostalAddress = false;
         A61Supplier_AgbEmail = "";
         n61Supplier_AgbEmail = false;
         A62Supplier_AgbPhone = "";
         n62Supplier_AgbPhone = false;
         A63Supplier_AgbContactName = "";
         n63Supplier_AgbContactName = false;
      }

      protected void InitAll0116( )
      {
         A55Supplier_AgbId = 0;
         InitializeNonKey0116( ) ;
      }

      protected void StandaloneModalInsert0116( )
      {
      }

      protected void InitializeNonKey0117( )
      {
         A65Supplier_GenKvKNumber = "";
         AssignAttri("", false, "A65Supplier_GenKvKNumber", A65Supplier_GenKvKNumber);
         A66Supplier_GenCompanyName = "";
         A67Supplier_GenVisitingAddress = "";
         n67Supplier_GenVisitingAddress = false;
         A68Supplier_GenPostalAddress = "";
         n68Supplier_GenPostalAddress = false;
         A69Supplier_GenContactName = "";
         n69Supplier_GenContactName = false;
         A70Supplier_GenContactPhone = "";
         n70Supplier_GenContactPhone = false;
      }

      protected void InitAll0117( )
      {
         A64Supplier_GenId = 0;
         InitializeNonKey0117( ) ;
      }

      protected void StandaloneModalInsert0117( )
      {
      }

      protected void InitializeNonKey0121( )
      {
         A101AmenitiesName = "";
         AssignAttri("", false, "A101AmenitiesName", A101AmenitiesName);
         A99AmenitiesTypeId = 0;
         A100AmenitiesTypeName = "";
      }

      protected void InitAll0121( )
      {
         A98AmenitiesId = 0;
         InitializeNonKey0121( ) ;
      }

      protected void StandaloneModalInsert0121( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315525118", true, true);
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
         context.AddJavascriptSource("customer.js", "?202491315525121", false, true);
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

      protected void init_level_properties2( )
      {
         edtCustomerManagerId_Enabled = defedtCustomerManagerId_Enabled;
         AssignProp("", false, edtCustomerManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerManagerId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
      }

      protected void init_level_properties3( )
      {
         edtCustomerLocationId_Enabled = defedtCustomerLocationId_Enabled;
         AssignProp("", false, edtCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationId_Enabled), 5, 0), !bGXsfl_97_Refreshing);
      }

      protected void init_level_properties4( )
      {
         edtCustomerLocationReceptionistGA_Enabled = defedtCustomerLocationReceptionistGA_Enabled;
         AssignProp("", false, edtCustomerLocationReceptionistGA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistGA_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtCustomerLocationReceptionistId_Enabled = defedtCustomerLocationReceptionistId_Enabled;
         AssignProp("", false, edtCustomerLocationReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationReceptionistId_Enabled), 5, 0), !bGXsfl_129_Refreshing);
      }

      protected void init_level_properties16( )
      {
         edtSupplier_AgbId_Enabled = defedtSupplier_AgbId_Enabled;
         AssignProp("", false, edtSupplier_AgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
      }

      protected void init_level_properties17( )
      {
         edtSupplier_GenId_Enabled = defedtSupplier_GenId_Enabled;
         AssignProp("", false, edtSupplier_GenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenId_Enabled), 5, 0), !bGXsfl_156_Refreshing);
      }

      protected void init_level_properties21( )
      {
         edtAmenitiesId_Enabled = defedtAmenitiesId_Enabled;
         AssignProp("", false, edtAmenitiesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
      }

      protected void StartGridControl78( )
      {
         Gridlevel_managerContainer.AddObjectProperty("GridName", "Gridlevel_manager");
         Gridlevel_managerContainer.AddObjectProperty("Header", subGridlevel_manager_Header);
         Gridlevel_managerContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_managerContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_managerContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_managerContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_manager_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_managerContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_managerContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_managerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_managerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerManagerId), 4, 0, ".", ""))));
         Gridlevel_managerColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerId_Enabled), 5, 0, ".", "")));
         Gridlevel_managerContainer.AddColumnProperties(Gridlevel_managerColumn);
         Gridlevel_managerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_managerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16CustomerManagerGivenName));
         Gridlevel_managerColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerGivenName_Enabled), 5, 0, ".", "")));
         Gridlevel_managerContainer.AddColumnProperties(Gridlevel_managerColumn);
         Gridlevel_managerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_managerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A9CustomerManagerLastName));
         Gridlevel_managerColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerLastName_Enabled), 5, 0, ".", "")));
         Gridlevel_managerContainer.AddColumnProperties(Gridlevel_managerColumn);
         Gridlevel_managerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_managerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A17CustomerManagerInitials)));
         Gridlevel_managerColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerInitials_Enabled), 5, 0, ".", "")));
         Gridlevel_managerContainer.AddColumnProperties(Gridlevel_managerColumn);
         Gridlevel_managerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_managerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A10CustomerManagerEmail));
         Gridlevel_managerColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerEmail_Enabled), 5, 0, ".", "")));
         Gridlevel_managerContainer.AddColumnProperties(Gridlevel_managerColumn);
         Gridlevel_managerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_managerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A11CustomerManagerPhone)));
         Gridlevel_managerColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerPhone_Enabled), 5, 0, ".", "")));
         Gridlevel_managerContainer.AddColumnProperties(Gridlevel_managerColumn);
         Gridlevel_managerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_managerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A12CustomerManagerGender)));
         Gridlevel_managerColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCustomerManagerGender.Enabled), 5, 0, ".", "")));
         Gridlevel_managerContainer.AddColumnProperties(Gridlevel_managerColumn);
         Gridlevel_managerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_managerColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A13CustomerManagerGAMGUID));
         Gridlevel_managerColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerManagerGAMGUID_Enabled), 5, 0, ".", "")));
         Gridlevel_managerContainer.AddColumnProperties(Gridlevel_managerColumn);
         Gridlevel_managerContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_manager_Selectedindex), 4, 0, ".", "")));
         Gridlevel_managerContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_manager_Allowselection), 1, 0, ".", "")));
         Gridlevel_managerContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_manager_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_managerContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_manager_Allowhovering), 1, 0, ".", "")));
         Gridlevel_managerContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_manager_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_managerContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_manager_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_managerContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_manager_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl97( )
      {
         Freestylelevel_locationsContainer.AddObjectProperty("GridName", "Freestylelevel_locations");
         Freestylelevel_locationsContainer.AddObjectProperty("Header", subFreestylelevel_locations_Header);
         Freestylelevel_locationsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Freestylelevel_locationsContainer.AddObjectProperty("Class", "FreeStyleGrid");
         Freestylelevel_locationsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylelevel_locationsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylelevel_locationsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_locations_Backcolorstyle), 1, 0, ".", "")));
         Freestylelevel_locationsContainer.AddObjectProperty("CmpContext", "");
         Freestylelevel_locationsContainer.AddObjectProperty("InMasterPage", "false");
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, ".", ""))));
         Freestylelevel_locationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationId_Enabled), 5, 0, ".", "")));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A19CustomerLocationVisitingAddres));
         Freestylelevel_locationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationVisitingAddres_Enabled), 5, 0, ".", "")));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A20CustomerLocationPostalAddress));
         Freestylelevel_locationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationPostalAddress_Enabled), 5, 0, ".", "")));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A21CustomerLocationEmail));
         Freestylelevel_locationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationEmail_Enabled), 5, 0, ".", "")));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A22CustomerLocationPhone)));
         Freestylelevel_locationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationPhone_Enabled), 5, 0, ".", "")));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Freestylelevel_locationsContainer.AddColumnProperties(Freestylelevel_locationsColumn);
         Freestylelevel_locationsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_locations_Selectedindex), 4, 0, ".", "")));
         Freestylelevel_locationsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_locations_Allowselection), 1, 0, ".", "")));
         Freestylelevel_locationsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_locations_Selectioncolor), 9, 0, ".", "")));
         Freestylelevel_locationsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_locations_Allowhovering), 1, 0, ".", "")));
         Freestylelevel_locationsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_locations_Hoveringcolor), 9, 0, ".", "")));
         Freestylelevel_locationsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_locations_Allowcollapsing), 1, 0, ".", "")));
         Freestylelevel_locationsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylelevel_locations_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl129( )
      {
         Gridlevel_receptionistContainer.AddObjectProperty("GridName", "Gridlevel_receptionist");
         Gridlevel_receptionistContainer.AddObjectProperty("Header", subGridlevel_receptionist_Header);
         Gridlevel_receptionistContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_receptionistContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_receptionistContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_receptionistContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_receptionist_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_receptionistContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_receptionistContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_receptionistColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_receptionistColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23CustomerLocationReceptionistId), 4, 0, ".", ""))));
         Gridlevel_receptionistColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistId_Enabled), 5, 0, ".", "")));
         Gridlevel_receptionistContainer.AddColumnProperties(Gridlevel_receptionistColumn);
         Gridlevel_receptionistColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_receptionistColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A24CustomerLocationReceptionistGi));
         Gridlevel_receptionistColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistGi_Enabled), 5, 0, ".", "")));
         Gridlevel_receptionistContainer.AddColumnProperties(Gridlevel_receptionistColumn);
         Gridlevel_receptionistColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_receptionistColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A25CustomerLocationReceptionistLa));
         Gridlevel_receptionistColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistLa_Enabled), 5, 0, ".", "")));
         Gridlevel_receptionistContainer.AddColumnProperties(Gridlevel_receptionistColumn);
         Gridlevel_receptionistColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_receptionistColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A26CustomerLocationReceptionistIn)));
         Gridlevel_receptionistColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistIn_Enabled), 5, 0, ".", "")));
         Gridlevel_receptionistContainer.AddColumnProperties(Gridlevel_receptionistColumn);
         Gridlevel_receptionistColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_receptionistColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A27CustomerLocationReceptionistEm));
         Gridlevel_receptionistColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistEm_Enabled), 5, 0, ".", "")));
         Gridlevel_receptionistContainer.AddColumnProperties(Gridlevel_receptionistColumn);
         Gridlevel_receptionistColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_receptionistColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A28CustomerLocationReceptionistAd));
         Gridlevel_receptionistColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistAd_Enabled), 5, 0, ".", "")));
         Gridlevel_receptionistContainer.AddColumnProperties(Gridlevel_receptionistColumn);
         Gridlevel_receptionistColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_receptionistColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A29CustomerLocationReceptionistPh)));
         Gridlevel_receptionistColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistPh_Enabled), 5, 0, ".", "")));
         Gridlevel_receptionistContainer.AddColumnProperties(Gridlevel_receptionistColumn);
         Gridlevel_receptionistColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_receptionistColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A30CustomerLocationReceptionistGA));
         Gridlevel_receptionistColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerLocationReceptionistGA_Enabled), 5, 0, ".", "")));
         Gridlevel_receptionistContainer.AddColumnProperties(Gridlevel_receptionistColumn);
         Gridlevel_receptionistContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_receptionist_Selectedindex), 4, 0, ".", "")));
         Gridlevel_receptionistContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_receptionist_Allowselection), 1, 0, ".", "")));
         Gridlevel_receptionistContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_receptionist_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_receptionistContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_receptionist_Allowhovering), 1, 0, ".", "")));
         Gridlevel_receptionistContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_receptionist_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_receptionistContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_receptionist_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_receptionistContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_receptionist_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl143( )
      {
         Gridlevel_supplier_agbContainer.AddObjectProperty("GridName", "Gridlevel_supplier_agb");
         Gridlevel_supplier_agbContainer.AddObjectProperty("Header", subGridlevel_supplier_agb_Header);
         Gridlevel_supplier_agbContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_supplier_agbContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_agb_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_supplier_agbContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_supplier_agbColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, ".", ""))));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbId_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtSupplier_AgbId_Horizontalalignment));
         Gridlevel_supplier_agbContainer.AddColumnProperties(Gridlevel_supplier_agbColumn);
         Gridlevel_supplier_agbColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A57Supplier_AgbName));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbName_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddColumnProperties(Gridlevel_supplier_agbColumn);
         Gridlevel_supplier_agbColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A58Supplier_AgbKvkNumber));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbKvkNumber_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddColumnProperties(Gridlevel_supplier_agbColumn);
         Gridlevel_supplier_agbColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A59Supplier_AgbVisitingAddress));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbVisitingAddress_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddColumnProperties(Gridlevel_supplier_agbColumn);
         Gridlevel_supplier_agbColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A60Supplier_AgbPostalAddress));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPostalAddress_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddColumnProperties(Gridlevel_supplier_agbColumn);
         Gridlevel_supplier_agbColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A61Supplier_AgbEmail));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbEmail_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddColumnProperties(Gridlevel_supplier_agbColumn);
         Gridlevel_supplier_agbColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A62Supplier_AgbPhone)));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbPhone_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddColumnProperties(Gridlevel_supplier_agbColumn);
         Gridlevel_supplier_agbColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A63Supplier_AgbContactName));
         Gridlevel_supplier_agbColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_AgbContactName_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddColumnProperties(Gridlevel_supplier_agbColumn);
         Gridlevel_supplier_agbContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_agb_Selectedindex), 4, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_agb_Allowselection), 1, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_agb_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_agb_Allowhovering), 1, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_agb_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_agb_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_supplier_agbContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_agb_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl156( )
      {
         Gridlevel_supplier_genContainer.AddObjectProperty("GridName", "Gridlevel_supplier_gen");
         Gridlevel_supplier_genContainer.AddObjectProperty("Header", subGridlevel_supplier_gen_Header);
         Gridlevel_supplier_genContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_supplier_genContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_gen_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_supplier_genContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_supplier_genColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_genColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, ".", ""))));
         Gridlevel_supplier_genColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenId_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_genColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtSupplier_GenId_Horizontalalignment));
         Gridlevel_supplier_genContainer.AddColumnProperties(Gridlevel_supplier_genColumn);
         Gridlevel_supplier_genColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_genColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A66Supplier_GenCompanyName));
         Gridlevel_supplier_genColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenCompanyName_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddColumnProperties(Gridlevel_supplier_genColumn);
         Gridlevel_supplier_genColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_genColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A67Supplier_GenVisitingAddress));
         Gridlevel_supplier_genColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenVisitingAddress_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddColumnProperties(Gridlevel_supplier_genColumn);
         Gridlevel_supplier_genColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_genColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A68Supplier_GenPostalAddress));
         Gridlevel_supplier_genColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenPostalAddress_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddColumnProperties(Gridlevel_supplier_genColumn);
         Gridlevel_supplier_genColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_genColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A69Supplier_GenContactName));
         Gridlevel_supplier_genColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactName_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddColumnProperties(Gridlevel_supplier_genColumn);
         Gridlevel_supplier_genColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_supplier_genColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A70Supplier_GenContactPhone)));
         Gridlevel_supplier_genColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactPhone_Enabled), 5, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddColumnProperties(Gridlevel_supplier_genColumn);
         Gridlevel_supplier_genContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_gen_Selectedindex), 4, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_gen_Allowselection), 1, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_gen_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_gen_Allowhovering), 1, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_gen_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_gen_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_supplier_genContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_supplier_gen_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl168( )
      {
         Gridlevel_amenitiesContainer.AddObjectProperty("GridName", "Gridlevel_amenities");
         Gridlevel_amenitiesContainer.AddObjectProperty("Header", subGridlevel_amenities_Header);
         Gridlevel_amenitiesContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_amenitiesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_amenities_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_amenitiesContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_amenitiesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_amenitiesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A98AmenitiesId), 4, 0, ".", ""))));
         Gridlevel_amenitiesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesId_Enabled), 5, 0, ".", "")));
         Gridlevel_amenitiesColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtAmenitiesId_Horizontalalignment));
         Gridlevel_amenitiesContainer.AddColumnProperties(Gridlevel_amenitiesColumn);
         Gridlevel_amenitiesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_amenitiesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A99AmenitiesTypeId), 4, 0, ".", ""))));
         Gridlevel_amenitiesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddColumnProperties(Gridlevel_amenitiesColumn);
         Gridlevel_amenitiesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_amenitiesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A100AmenitiesTypeName));
         Gridlevel_amenitiesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAmenitiesTypeName_Enabled), 5, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddColumnProperties(Gridlevel_amenitiesColumn);
         Gridlevel_amenitiesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_amenities_Selectedindex), 4, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_amenities_Allowselection), 1, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_amenities_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_amenities_Allowhovering), 1, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_amenities_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_amenities_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_amenitiesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_amenities_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTabgeneral_title_Internalname = "TABGENERAL_TITLE";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerKvkNumber_Internalname = "CUSTOMERKVKNUMBER";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCustomerPostalAddress_Internalname = "CUSTOMERPOSTALADDRESS";
         edtCustomerEmail_Internalname = "CUSTOMEREMAIL";
         edtCustomerVisitingAddress_Internalname = "CUSTOMERVISITINGADDRESS";
         edtCustomerPhone_Internalname = "CUSTOMERPHONE";
         edtCustomerVatNumber_Internalname = "CUSTOMERVATNUMBER";
         lblTextblockcustomertypeid_Internalname = "TEXTBLOCKCUSTOMERTYPEID";
         Combo_customertypeid_Internalname = "COMBO_CUSTOMERTYPEID";
         edtCustomerTypeId_Internalname = "CUSTOMERTYPEID";
         divTablesplittedcustomertypeid_Internalname = "TABLESPLITTEDCUSTOMERTYPEID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblTablevel_manager_title_Internalname = "TABLEVEL_MANAGER_TITLE";
         edtCustomerManagerId_Internalname = "CUSTOMERMANAGERID";
         edtCustomerManagerGivenName_Internalname = "CUSTOMERMANAGERGIVENNAME";
         edtCustomerManagerLastName_Internalname = "CUSTOMERMANAGERLASTNAME";
         edtCustomerManagerInitials_Internalname = "CUSTOMERMANAGERINITIALS";
         edtCustomerManagerEmail_Internalname = "CUSTOMERMANAGEREMAIL";
         edtCustomerManagerPhone_Internalname = "CUSTOMERMANAGERPHONE";
         cmbCustomerManagerGender_Internalname = "CUSTOMERMANAGERGENDER";
         edtCustomerManagerGAMGUID_Internalname = "CUSTOMERMANAGERGAMGUID";
         divTableleaflevel_manager_Internalname = "TABLELEAFLEVEL_MANAGER";
         divTabtablelevel_manager_Internalname = "TABTABLELEVEL_MANAGER";
         lblTablevel_locations_title_Internalname = "TABLEVEL_LOCATIONS_TITLE";
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID";
         edtCustomerLocationVisitingAddres_Internalname = "CUSTOMERLOCATIONVISITINGADDRES";
         edtCustomerLocationPostalAddress_Internalname = "CUSTOMERLOCATIONPOSTALADDRESS";
         edtCustomerLocationEmail_Internalname = "CUSTOMERLOCATIONEMAIL";
         edtCustomerLocationPhone_Internalname = "CUSTOMERLOCATIONPHONE";
         edtCustomerLocationReceptionistId_Internalname = "CUSTOMERLOCATIONRECEPTIONISTID";
         edtCustomerLocationReceptionistGi_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGI";
         edtCustomerLocationReceptionistLa_Internalname = "CUSTOMERLOCATIONRECEPTIONISTLA";
         edtCustomerLocationReceptionistIn_Internalname = "CUSTOMERLOCATIONRECEPTIONISTIN";
         edtCustomerLocationReceptionistEm_Internalname = "CUSTOMERLOCATIONRECEPTIONISTEM";
         edtCustomerLocationReceptionistAd_Internalname = "CUSTOMERLOCATIONRECEPTIONISTAD";
         edtCustomerLocationReceptionistPh_Internalname = "CUSTOMERLOCATIONRECEPTIONISTPH";
         edtCustomerLocationReceptionistGA_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGA";
         divTableleaflevel_receptionist_Internalname = "TABLELEAFLEVEL_RECEPTIONIST";
         edtSupplier_AgbId_Internalname = "SUPPLIER_AGBID";
         edtSupplier_AgbName_Internalname = "SUPPLIER_AGBNAME";
         edtSupplier_AgbKvkNumber_Internalname = "SUPPLIER_AGBKVKNUMBER";
         edtSupplier_AgbVisitingAddress_Internalname = "SUPPLIER_AGBVISITINGADDRESS";
         edtSupplier_AgbPostalAddress_Internalname = "SUPPLIER_AGBPOSTALADDRESS";
         edtSupplier_AgbEmail_Internalname = "SUPPLIER_AGBEMAIL";
         edtSupplier_AgbPhone_Internalname = "SUPPLIER_AGBPHONE";
         edtSupplier_AgbContactName_Internalname = "SUPPLIER_AGBCONTACTNAME";
         divTableleaflevel_supplier_agb_Internalname = "TABLELEAFLEVEL_SUPPLIER_AGB";
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID";
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME";
         edtSupplier_GenVisitingAddress_Internalname = "SUPPLIER_GENVISITINGADDRESS";
         edtSupplier_GenPostalAddress_Internalname = "SUPPLIER_GENPOSTALADDRESS";
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME";
         edtSupplier_GenContactPhone_Internalname = "SUPPLIER_GENCONTACTPHONE";
         divTableleaflevel_supplier_gen_Internalname = "TABLELEAFLEVEL_SUPPLIER_GEN";
         edtAmenitiesId_Internalname = "AMENITIESID";
         edtAmenitiesTypeId_Internalname = "AMENITIESTYPEID";
         edtAmenitiesTypeName_Internalname = "AMENITIESTYPENAME";
         divTableleaflevel_amenities_Internalname = "TABLELEAFLEVEL_AMENITIES";
         divTableintermediateinslevel_locations_Internalname = "TABLEINTERMEDIATEINSLEVEL_LOCATIONS";
         tblUnnamedtablefsfreestylelevel_locations_Internalname = "UNNAMEDTABLEFSFREESTYLELEVEL_LOCATIONS";
         divTableintermediatelevel_locations_Internalname = "TABLEINTERMEDIATELEVEL_LOCATIONS";
         divTabtablelevel_locations_Internalname = "TABTABLELEVEL_LOCATIONS";
         Gxuitabspanel_steps_Internalname = "GXUITABSPANEL_STEPS";
         bttBtnwizardprevious_Internalname = "BTNWIZARDPREVIOUS";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtnwizardnext_Internalname = "BTNWIZARDNEXT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocustomertypeid_Internalname = "vCOMBOCUSTOMERTYPEID";
         divSectionattribute_customertypeid_Internalname = "SECTIONATTRIBUTE_CUSTOMERTYPEID";
         Combo_supplier_agbid_Internalname = "COMBO_SUPPLIER_AGBID";
         Combo_supplier_genid_Internalname = "COMBO_SUPPLIER_GENID";
         Combo_amenitiesid_Internalname = "COMBO_AMENITIESID";
         edtCustomerLastLine_Internalname = "CUSTOMERLASTLINE";
         Wizard_steps_Internalname = "WIZARD_STEPS";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_manager_Internalname = "GRIDLEVEL_MANAGER";
         subGridlevel_receptionist_Internalname = "GRIDLEVEL_RECEPTIONIST";
         subGridlevel_supplier_agb_Internalname = "GRIDLEVEL_SUPPLIER_AGB";
         subGridlevel_supplier_gen_Internalname = "GRIDLEVEL_SUPPLIER_GEN";
         subGridlevel_amenities_Internalname = "GRIDLEVEL_AMENITIES";
         subFreestylelevel_locations_Internalname = "FREESTYLELEVEL_LOCATIONS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_amenities_Allowcollapsing = 0;
         subGridlevel_amenities_Allowselection = 0;
         subGridlevel_amenities_Header = "";
         subGridlevel_supplier_gen_Allowcollapsing = 0;
         subGridlevel_supplier_gen_Allowselection = 0;
         subGridlevel_supplier_gen_Header = "";
         subGridlevel_supplier_agb_Allowcollapsing = 0;
         subGridlevel_supplier_agb_Allowselection = 0;
         subGridlevel_supplier_agb_Header = "";
         subGridlevel_receptionist_Allowcollapsing = 0;
         subGridlevel_receptionist_Allowselection = 0;
         subGridlevel_receptionist_Header = "";
         subFreestylelevel_locations_Allowcollapsing = 0;
         subGridlevel_manager_Allowcollapsing = 0;
         subGridlevel_manager_Allowselection = 0;
         subGridlevel_manager_Header = "";
         Combo_amenitiesid_Enabled = Convert.ToBoolean( -1);
         Combo_supplier_genid_Enabled = Convert.ToBoolean( -1);
         Combo_supplier_agbid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Customer", "");
         edtAmenitiesTypeName_Jsonclick = "";
         edtAmenitiesTypeId_Jsonclick = "";
         edtAmenitiesId_Jsonclick = "";
         subGridlevel_amenities_Class = "WorkWith";
         subGridlevel_amenities_Backcolorstyle = 0;
         edtSupplier_GenContactPhone_Jsonclick = "";
         edtSupplier_GenContactName_Jsonclick = "";
         edtSupplier_GenPostalAddress_Jsonclick = "";
         edtSupplier_GenVisitingAddress_Jsonclick = "";
         edtSupplier_GenCompanyName_Jsonclick = "";
         edtSupplier_GenId_Jsonclick = "";
         subGridlevel_supplier_gen_Class = "WorkWith";
         subGridlevel_supplier_gen_Backcolorstyle = 0;
         edtSupplier_AgbContactName_Jsonclick = "";
         edtSupplier_AgbPhone_Jsonclick = "";
         edtSupplier_AgbEmail_Jsonclick = "";
         edtSupplier_AgbPostalAddress_Jsonclick = "";
         edtSupplier_AgbVisitingAddress_Jsonclick = "";
         edtSupplier_AgbKvkNumber_Jsonclick = "";
         edtSupplier_AgbName_Jsonclick = "";
         edtSupplier_AgbId_Jsonclick = "";
         subGridlevel_supplier_agb_Class = "WorkWith";
         subGridlevel_supplier_agb_Backcolorstyle = 0;
         edtCustomerLocationReceptionistGA_Jsonclick = "";
         edtCustomerLocationReceptionistPh_Jsonclick = "";
         edtCustomerLocationReceptionistAd_Jsonclick = "";
         edtCustomerLocationReceptionistEm_Jsonclick = "";
         edtCustomerLocationReceptionistIn_Jsonclick = "";
         edtCustomerLocationReceptionistLa_Jsonclick = "";
         edtCustomerLocationReceptionistGi_Jsonclick = "";
         edtCustomerLocationReceptionistId_Jsonclick = "";
         subGridlevel_receptionist_Class = "WorkWith";
         subGridlevel_receptionist_Backcolorstyle = 0;
         edtCustomerLocationPhone_Jsonclick = "";
         edtCustomerLocationEmail_Jsonclick = "";
         edtCustomerLocationPostalAddress_Jsonclick = "";
         edtCustomerLocationId_Jsonclick = "";
         subFreestylelevel_locations_Class = "FreeStyleGrid";
         subFreestylelevel_locations_Backcolorstyle = 0;
         edtCustomerManagerGAMGUID_Jsonclick = "";
         cmbCustomerManagerGender_Jsonclick = "";
         edtCustomerManagerPhone_Jsonclick = "";
         edtCustomerManagerEmail_Jsonclick = "";
         edtCustomerManagerInitials_Jsonclick = "";
         edtCustomerManagerLastName_Jsonclick = "";
         edtCustomerManagerGivenName_Jsonclick = "";
         edtCustomerManagerId_Jsonclick = "";
         subGridlevel_manager_Class = "WorkWith";
         subGridlevel_manager_Backcolorstyle = 0;
         Combo_supplier_agbid_Titlecontrolidtoreplace = "";
         Combo_supplier_genid_Titlecontrolidtoreplace = "";
         Combo_amenitiesid_Titlecontrolidtoreplace = "";
         Wizard_steps_Tabsinternalname = "";
         edtCustomerLocationReceptionistGA_Enabled = 0;
         edtCustomerLocationReceptionistPh_Enabled = 1;
         edtCustomerLocationReceptionistAd_Enabled = 1;
         edtCustomerLocationReceptionistEm_Enabled = 1;
         edtCustomerLocationReceptionistIn_Enabled = 1;
         edtCustomerLocationReceptionistLa_Enabled = 1;
         edtCustomerLocationReceptionistGi_Enabled = 1;
         edtCustomerLocationReceptionistId_Enabled = 0;
         edtSupplier_AgbContactName_Enabled = 0;
         edtSupplier_AgbPhone_Enabled = 0;
         edtSupplier_AgbEmail_Enabled = 0;
         edtSupplier_AgbPostalAddress_Enabled = 0;
         edtSupplier_AgbVisitingAddress_Enabled = 0;
         edtSupplier_AgbKvkNumber_Enabled = 0;
         edtSupplier_AgbName_Enabled = 0;
         edtSupplier_AgbId_Enabled = 1;
         edtSupplier_GenContactPhone_Enabled = 0;
         edtSupplier_GenContactName_Enabled = 0;
         edtSupplier_GenPostalAddress_Enabled = 0;
         edtSupplier_GenVisitingAddress_Enabled = 0;
         edtSupplier_GenCompanyName_Enabled = 0;
         edtSupplier_GenId_Enabled = 1;
         edtAmenitiesTypeName_Enabled = 0;
         edtAmenitiesTypeId_Enabled = 0;
         edtAmenitiesId_Enabled = 1;
         edtCustomerLocationPhone_Enabled = 1;
         edtCustomerLocationEmail_Enabled = 1;
         edtCustomerLocationPostalAddress_Enabled = 1;
         edtCustomerLocationVisitingAddres_Enabled = 1;
         edtCustomerLocationId_Enabled = 1;
         edtCustomerManagerGAMGUID_Enabled = 1;
         cmbCustomerManagerGender.Enabled = 1;
         edtCustomerManagerPhone_Enabled = 1;
         edtCustomerManagerEmail_Enabled = 1;
         edtCustomerManagerInitials_Enabled = 1;
         edtCustomerManagerLastName_Enabled = 1;
         edtCustomerManagerGivenName_Enabled = 1;
         edtCustomerManagerId_Enabled = 1;
         edtCustomerLastLine_Jsonclick = "";
         edtCustomerLastLine_Enabled = 0;
         edtCustomerLastLine_Visible = 1;
         Combo_amenitiesid_Emptyitem = Convert.ToBoolean( 0);
         Combo_amenitiesid_Datalistprocparametersprefix = " \"ComboName\": \"AmenitiesId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CustomerId\": 0";
         Combo_amenitiesid_Datalistproc = "CustomerLoadDVCombo";
         Combo_amenitiesid_Hasdescription = Convert.ToBoolean( -1);
         Combo_amenitiesid_Isgriditem = Convert.ToBoolean( -1);
         Combo_amenitiesid_Cls = "ExtendedCombo";
         Combo_amenitiesid_Caption = "";
         Combo_supplier_genid_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplier_genid_Datalistprocparametersprefix = " \"ComboName\": \"Supplier_GenId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CustomerId\": 0";
         Combo_supplier_genid_Datalistproc = "CustomerLoadDVCombo";
         Combo_supplier_genid_Hasdescription = Convert.ToBoolean( -1);
         Combo_supplier_genid_Isgriditem = Convert.ToBoolean( -1);
         Combo_supplier_genid_Cls = "ExtendedCombo";
         Combo_supplier_genid_Caption = "";
         Combo_supplier_agbid_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplier_agbid_Datalistprocparametersprefix = " \"ComboName\": \"Supplier_AgbId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CustomerId\": 0";
         Combo_supplier_agbid_Datalistproc = "CustomerLoadDVCombo";
         Combo_supplier_agbid_Hasdescription = Convert.ToBoolean( -1);
         Combo_supplier_agbid_Isgriditem = Convert.ToBoolean( -1);
         Combo_supplier_agbid_Cls = "ExtendedCombo";
         Combo_supplier_agbid_Caption = "";
         edtavCombocustomertypeid_Jsonclick = "";
         edtavCombocustomertypeid_Enabled = 0;
         edtavCombocustomertypeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         bttBtnwizardnext_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtnwizardprevious_Visible = 1;
         edtCustomerTypeId_Jsonclick = "";
         edtCustomerTypeId_Enabled = 1;
         edtCustomerTypeId_Visible = 1;
         Combo_customertypeid_Datalistprocparametersprefix = " \"ComboName\": \"CustomerTypeId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CustomerId\": 0";
         Combo_customertypeid_Datalistproc = "CustomerLoadDVCombo";
         Combo_customertypeid_Cls = "ExtendedCombo Attribute";
         Combo_customertypeid_Caption = "";
         Combo_customertypeid_Enabled = Convert.ToBoolean( -1);
         edtCustomerVatNumber_Jsonclick = "";
         edtCustomerVatNumber_Enabled = 1;
         edtCustomerPhone_Jsonclick = "";
         edtCustomerPhone_Enabled = 1;
         edtCustomerVisitingAddress_Enabled = 1;
         edtCustomerEmail_Jsonclick = "";
         edtCustomerEmail_Enabled = 1;
         edtCustomerPostalAddress_Enabled = 1;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Enabled = 1;
         edtCustomerKvkNumber_Jsonclick = "";
         edtCustomerKvkNumber_Enabled = 1;
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 0;
         Gxuitabspanel_steps_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_steps_Class = "Tab";
         Gxuitabspanel_steps_Pagecount = 3;
         divLayoutmaintable_Class = "Table";
         edtAmenitiesId_Horizontalalignment = "end";
         edtSupplier_GenId_Horizontalalignment = "end";
         edtSupplier_AgbId_Horizontalalignment = "end";
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

      protected void XC_15_012( )
      {
         new createuseraccount(context ).execute(  A10CustomerManagerEmail,  A16CustomerManagerGivenName,  A9CustomerManagerLastName,  context.GetMessage( "Customer Manager", ""), out  A13CustomerManagerGAMGUID) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_16_012( string A16CustomerManagerGivenName ,
                                string A9CustomerManagerLastName )
      {
         new getnameinitials(context ).execute(  A16CustomerManagerGivenName,  A9CustomerManagerLastName, out  A17CustomerManagerInitials) ;
         n17CustomerManagerInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A17CustomerManagerInitials)) ? true : false);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A17CustomerManagerInitials))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_25_014( )
      {
         new createuseraccount(context ).execute(  A27CustomerLocationReceptionistEm,  A24CustomerLocationReceptionistGi,  A25CustomerLocationReceptionistLa,  context.GetMessage( "Receptionist", ""), out  A30CustomerLocationReceptionistGA) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_26_014( string A24CustomerLocationReceptionistGi ,
                                string A25CustomerLocationReceptionistLa )
      {
         new getnameinitials(context ).execute(  A24CustomerLocationReceptionistGi,  A25CustomerLocationReceptionistLa, out  A26CustomerLocationReceptionistIn) ;
         n26CustomerLocationReceptionistIn = (String.IsNullOrEmpty(StringUtil.RTrim( A26CustomerLocationReceptionistIn)) ? true : false);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A26CustomerLocationReceptionistIn))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_manager_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_782( ) ;
         while ( nGXsfl_78_idx <= nRC_GXsfl_78 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal012( ) ;
            standaloneModal012( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow012( ) ;
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_782( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_managerContainer)) ;
         /* End function gxnrGridlevel_manager_newrow */
      }

      protected void gxnrFreestylelevel_locations_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_973( ) ;
         while ( nGXsfl_97_idx <= nRC_GXsfl_97 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal013( ) ;
            standaloneModal013( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow013( ) ;
            Freestylelevel_locationsRow.AddGrid("Gridlevel_receptionist", Gridlevel_receptionistContainer);
            Freestylelevel_locationsRow.AddGrid("Gridlevel_supplier_agb", Gridlevel_supplier_agbContainer);
            Freestylelevel_locationsRow.AddGrid("Gridlevel_supplier_gen", Gridlevel_supplier_genContainer);
            Freestylelevel_locationsRow.AddGrid("Gridlevel_amenities", Gridlevel_amenitiesContainer);
            nGXsfl_97_idx = (int)(nGXsfl_97_idx+1);
            sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
            SubsflControlProps_973( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylelevel_locationsContainer)) ;
         /* End function gxnrFreestylelevel_locations_newrow */
      }

      protected void gxnrGridlevel_receptionist_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_1294( ) ;
         while ( nGXsfl_129_idx <= nRC_GXsfl_129 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal013( ) ;
            standaloneModal013( ) ;
            standaloneNotModal014( ) ;
            standaloneModal014( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow014( ) ;
            nGXsfl_129_idx = (int)(nGXsfl_129_idx+1);
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_1294( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_receptionistContainer)) ;
         /* End function gxnrGridlevel_receptionist_newrow */
      }

      protected void gxnrGridlevel_supplier_agb_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_14316( ) ;
         while ( nGXsfl_143_idx <= nRC_GXsfl_143 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal013( ) ;
            standaloneModal013( ) ;
            standaloneNotModal0116( ) ;
            standaloneModal0116( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0116( ) ;
            nGXsfl_143_idx = (int)(nGXsfl_143_idx+1);
            sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_14316( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_supplier_agbContainer)) ;
         /* End function gxnrGridlevel_supplier_agb_newrow */
      }

      protected void gxnrGridlevel_supplier_gen_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_15617( ) ;
         while ( nGXsfl_156_idx <= nRC_GXsfl_156 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal013( ) ;
            standaloneModal013( ) ;
            standaloneNotModal0117( ) ;
            standaloneModal0117( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0117( ) ;
            nGXsfl_156_idx = (int)(nGXsfl_156_idx+1);
            sGXsfl_156_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_156_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_15617( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_supplier_genContainer)) ;
         /* End function gxnrGridlevel_supplier_gen_newrow */
      }

      protected void gxnrGridlevel_amenities_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_16821( ) ;
         while ( nGXsfl_168_idx <= nRC_GXsfl_168 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal013( ) ;
            standaloneModal013( ) ;
            standaloneNotModal0121( ) ;
            standaloneModal0121( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0121( ) ;
            nGXsfl_168_idx = (int)(nGXsfl_168_idx+1);
            sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0") + sGXsfl_97_idx;
            SubsflControlProps_16821( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_amenitiesContainer)) ;
         /* End function gxnrGridlevel_amenities_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "CUSTOMERMANAGERGENDER_" + sGXsfl_78_idx;
         cmbCustomerManagerGender.Name = GXCCtl;
         cmbCustomerManagerGender.WebTags = "";
         cmbCustomerManagerGender.addItem("Man", context.GetMessage( "Man", ""), 0);
         cmbCustomerManagerGender.addItem("Woman", context.GetMessage( "Woman", ""), 0);
         cmbCustomerManagerGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbCustomerManagerGender.ItemCount > 0 )
         {
            A12CustomerManagerGender = cmbCustomerManagerGender.getValidValue(A12CustomerManagerGender);
            n12CustomerManagerGender = false;
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

      public void Valid_Customertypeid( )
      {
         n78CustomerTypeId = false;
         /* Using cursor T000130 */
         pr_default.execute(28, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( (0==A78CustomerTypeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERTYPEID");
               AnyError = 1;
               GX_FocusControl = edtCustomerTypeId_Internalname;
            }
         }
         A79CustomerTypeName = T000130_A79CustomerTypeName[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A79CustomerTypeName", A79CustomerTypeName);
      }

      public void Valid_Customermanagerlastname( )
      {
         n17CustomerManagerInitials = false;
         new getnameinitials(context ).execute(  A16CustomerManagerGivenName,  A9CustomerManagerLastName, out  A17CustomerManagerInitials) ;
         n17CustomerManagerInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A17CustomerManagerInitials)) ? true : false);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A17CustomerManagerInitials", StringUtil.RTrim( A17CustomerManagerInitials));
      }

      public void Valid_Customerlocationreceptionistla( )
      {
         n26CustomerLocationReceptionistIn = false;
         new getnameinitials(context ).execute(  A24CustomerLocationReceptionistGi,  A25CustomerLocationReceptionistLa, out  A26CustomerLocationReceptionistIn) ;
         n26CustomerLocationReceptionistIn = (String.IsNullOrEmpty(StringUtil.RTrim( A26CustomerLocationReceptionistIn)) ? true : false);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A26CustomerLocationReceptionistIn", StringUtil.RTrim( A26CustomerLocationReceptionistIn));
      }

      public void Valid_Supplier_agbid( )
      {
         n59Supplier_AgbVisitingAddress = false;
         n60Supplier_AgbPostalAddress = false;
         n61Supplier_AgbEmail = false;
         n62Supplier_AgbPhone = false;
         n63Supplier_AgbContactName = false;
         /* Using cursor T000162 */
         pr_default.execute(60, new Object[] {A55Supplier_AgbId});
         if ( (pr_default.getStatus(60) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Supplier_AGB", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIER_AGBID");
            AnyError = 1;
            GX_FocusControl = edtSupplier_AgbId_Internalname;
         }
         A56Supplier_AgbNumber = T000162_A56Supplier_AgbNumber[0];
         A57Supplier_AgbName = T000162_A57Supplier_AgbName[0];
         A58Supplier_AgbKvkNumber = T000162_A58Supplier_AgbKvkNumber[0];
         A59Supplier_AgbVisitingAddress = T000162_A59Supplier_AgbVisitingAddress[0];
         n59Supplier_AgbVisitingAddress = T000162_n59Supplier_AgbVisitingAddress[0];
         A60Supplier_AgbPostalAddress = T000162_A60Supplier_AgbPostalAddress[0];
         n60Supplier_AgbPostalAddress = T000162_n60Supplier_AgbPostalAddress[0];
         A61Supplier_AgbEmail = T000162_A61Supplier_AgbEmail[0];
         n61Supplier_AgbEmail = T000162_n61Supplier_AgbEmail[0];
         A62Supplier_AgbPhone = T000162_A62Supplier_AgbPhone[0];
         n62Supplier_AgbPhone = T000162_n62Supplier_AgbPhone[0];
         A63Supplier_AgbContactName = T000162_A63Supplier_AgbContactName[0];
         n63Supplier_AgbContactName = T000162_n63Supplier_AgbContactName[0];
         pr_default.close(60);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A56Supplier_AgbNumber", A56Supplier_AgbNumber);
         AssignAttri("", false, "A57Supplier_AgbName", A57Supplier_AgbName);
         AssignAttri("", false, "A58Supplier_AgbKvkNumber", A58Supplier_AgbKvkNumber);
         AssignAttri("", false, "A59Supplier_AgbVisitingAddress", A59Supplier_AgbVisitingAddress);
         AssignAttri("", false, "A60Supplier_AgbPostalAddress", A60Supplier_AgbPostalAddress);
         AssignAttri("", false, "A61Supplier_AgbEmail", A61Supplier_AgbEmail);
         AssignAttri("", false, "A62Supplier_AgbPhone", StringUtil.RTrim( A62Supplier_AgbPhone));
         AssignAttri("", false, "A63Supplier_AgbContactName", A63Supplier_AgbContactName);
      }

      public void Valid_Supplier_genid( )
      {
         n67Supplier_GenVisitingAddress = false;
         n68Supplier_GenPostalAddress = false;
         n69Supplier_GenContactName = false;
         n70Supplier_GenContactPhone = false;
         /* Using cursor T000169 */
         pr_default.execute(67, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(67) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Supplier_Gen", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIER_GENID");
            AnyError = 1;
            GX_FocusControl = edtSupplier_GenId_Internalname;
         }
         A65Supplier_GenKvKNumber = T000169_A65Supplier_GenKvKNumber[0];
         A66Supplier_GenCompanyName = T000169_A66Supplier_GenCompanyName[0];
         A67Supplier_GenVisitingAddress = T000169_A67Supplier_GenVisitingAddress[0];
         n67Supplier_GenVisitingAddress = T000169_n67Supplier_GenVisitingAddress[0];
         A68Supplier_GenPostalAddress = T000169_A68Supplier_GenPostalAddress[0];
         n68Supplier_GenPostalAddress = T000169_n68Supplier_GenPostalAddress[0];
         A69Supplier_GenContactName = T000169_A69Supplier_GenContactName[0];
         n69Supplier_GenContactName = T000169_n69Supplier_GenContactName[0];
         A70Supplier_GenContactPhone = T000169_A70Supplier_GenContactPhone[0];
         n70Supplier_GenContactPhone = T000169_n70Supplier_GenContactPhone[0];
         pr_default.close(67);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A65Supplier_GenKvKNumber", A65Supplier_GenKvKNumber);
         AssignAttri("", false, "A66Supplier_GenCompanyName", A66Supplier_GenCompanyName);
         AssignAttri("", false, "A67Supplier_GenVisitingAddress", A67Supplier_GenVisitingAddress);
         AssignAttri("", false, "A68Supplier_GenPostalAddress", A68Supplier_GenPostalAddress);
         AssignAttri("", false, "A69Supplier_GenContactName", A69Supplier_GenContactName);
         AssignAttri("", false, "A70Supplier_GenContactPhone", StringUtil.RTrim( A70Supplier_GenContactPhone));
      }

      public void Valid_Amenitiesid( )
      {
         /* Using cursor T000177 */
         pr_default.execute(75, new Object[] {A98AmenitiesId});
         if ( (pr_default.getStatus(75) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Amenities", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AMENITIESID");
            AnyError = 1;
            GX_FocusControl = edtAmenitiesId_Internalname;
         }
         A101AmenitiesName = T000177_A101AmenitiesName[0];
         A99AmenitiesTypeId = T000177_A99AmenitiesTypeId[0];
         pr_default.close(75);
         /* Using cursor T000178 */
         pr_default.execute(76, new Object[] {A99AmenitiesTypeId});
         if ( (pr_default.getStatus(76) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AmenitiesType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AMENITIESTYPEID");
            AnyError = 1;
         }
         A100AmenitiesTypeName = T000178_A100AmenitiesTypeName[0];
         pr_default.close(76);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A101AmenitiesName", A101AmenitiesName);
         AssignAttri("", false, "A99AmenitiesTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A99AmenitiesTypeId), 4, 0, ".", "")));
         AssignAttri("", false, "A100AmenitiesTypeName", A100AmenitiesTypeName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7CustomerId","fld":"vCUSTOMERID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7CustomerId","fld":"vCUSTOMERID","pic":"ZZZ9","hsh":true},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E14012","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("'WIZARDNEXT'","""{"handler":"E12012","iparms":[{"av":"Gxuitabspanel_steps_Activepage","ctrl":"GXUITABSPANEL_STEPS","prop":"ActivePage"},{"av":"AV15CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]""");
         setEventMetadata("'WIZARDNEXT'",""","oparms":[{"av":"AV15CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E11012","iparms":[{"av":"Gxuitabspanel_steps_Activepage","ctrl":"GXUITABSPANEL_STEPS","prop":"ActivePage"}]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMEREMAIL","""{"handler":"Valid_Customeremail","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERTYPEID","""{"handler":"Valid_Customertypeid","iparms":[{"av":"A78CustomerTypeId","fld":"CUSTOMERTYPEID","pic":"ZZZ9"},{"av":"A79CustomerTypeName","fld":"CUSTOMERTYPENAME"}]""");
         setEventMetadata("VALID_CUSTOMERTYPEID",""","oparms":[{"av":"A79CustomerTypeName","fld":"CUSTOMERTYPENAME"}]}""");
         setEventMetadata("VALIDV_COMBOCUSTOMERTYPEID","""{"handler":"Validv_Combocustomertypeid","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERLASTLINE","""{"handler":"Valid_Customerlastline","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERMANAGERID","""{"handler":"Valid_Customermanagerid","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERMANAGERGIVENNAME","""{"handler":"Valid_Customermanagergivenname","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERMANAGERLASTNAME","""{"handler":"Valid_Customermanagerlastname","iparms":[{"av":"A16CustomerManagerGivenName","fld":"CUSTOMERMANAGERGIVENNAME"},{"av":"A9CustomerManagerLastName","fld":"CUSTOMERMANAGERLASTNAME"},{"av":"A17CustomerManagerInitials","fld":"CUSTOMERMANAGERINITIALS"}]""");
         setEventMetadata("VALID_CUSTOMERMANAGERLASTNAME",""","oparms":[{"av":"A17CustomerManagerInitials","fld":"CUSTOMERMANAGERINITIALS"}]}""");
         setEventMetadata("VALID_CUSTOMERMANAGEREMAIL","""{"handler":"Valid_Customermanageremail","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERMANAGERGENDER","""{"handler":"Valid_Customermanagergender","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Customermanagergamguid","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERLOCATIONID","""{"handler":"Valid_Customerlocationid","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERLOCATIONEMAIL","""{"handler":"Valid_Customerlocationemail","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Customerlocationphone","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERLOCATIONRECEPTIONISTID","""{"handler":"Valid_Customerlocationreceptionistid","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERLOCATIONRECEPTIONISTGI","""{"handler":"Valid_Customerlocationreceptionistgi","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERLOCATIONRECEPTIONISTLA","""{"handler":"Valid_Customerlocationreceptionistla","iparms":[{"av":"A24CustomerLocationReceptionistGi","fld":"CUSTOMERLOCATIONRECEPTIONISTGI"},{"av":"A25CustomerLocationReceptionistLa","fld":"CUSTOMERLOCATIONRECEPTIONISTLA"},{"av":"A26CustomerLocationReceptionistIn","fld":"CUSTOMERLOCATIONRECEPTIONISTIN"}]""");
         setEventMetadata("VALID_CUSTOMERLOCATIONRECEPTIONISTLA",""","oparms":[{"av":"A26CustomerLocationReceptionistIn","fld":"CUSTOMERLOCATIONRECEPTIONISTIN"}]}""");
         setEventMetadata("VALID_CUSTOMERLOCATIONRECEPTIONISTEM","""{"handler":"Valid_Customerlocationreceptionistem","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Customerlocationreceptionistga","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIER_AGBID","""{"handler":"Valid_Supplier_agbid","iparms":[{"av":"A55Supplier_AgbId","fld":"SUPPLIER_AGBID","pic":"ZZZ9"},{"av":"A56Supplier_AgbNumber","fld":"SUPPLIER_AGBNUMBER"},{"av":"A57Supplier_AgbName","fld":"SUPPLIER_AGBNAME"},{"av":"A58Supplier_AgbKvkNumber","fld":"SUPPLIER_AGBKVKNUMBER"},{"av":"A59Supplier_AgbVisitingAddress","fld":"SUPPLIER_AGBVISITINGADDRESS"},{"av":"A60Supplier_AgbPostalAddress","fld":"SUPPLIER_AGBPOSTALADDRESS"},{"av":"A61Supplier_AgbEmail","fld":"SUPPLIER_AGBEMAIL"},{"av":"A62Supplier_AgbPhone","fld":"SUPPLIER_AGBPHONE"},{"av":"A63Supplier_AgbContactName","fld":"SUPPLIER_AGBCONTACTNAME"}]""");
         setEventMetadata("VALID_SUPPLIER_AGBID",""","oparms":[{"av":"A56Supplier_AgbNumber","fld":"SUPPLIER_AGBNUMBER"},{"av":"A57Supplier_AgbName","fld":"SUPPLIER_AGBNAME"},{"av":"A58Supplier_AgbKvkNumber","fld":"SUPPLIER_AGBKVKNUMBER"},{"av":"A59Supplier_AgbVisitingAddress","fld":"SUPPLIER_AGBVISITINGADDRESS"},{"av":"A60Supplier_AgbPostalAddress","fld":"SUPPLIER_AGBPOSTALADDRESS"},{"av":"A61Supplier_AgbEmail","fld":"SUPPLIER_AGBEMAIL"},{"av":"A62Supplier_AgbPhone","fld":"SUPPLIER_AGBPHONE"},{"av":"A63Supplier_AgbContactName","fld":"SUPPLIER_AGBCONTACTNAME"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Supplier_agbcontactname","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIER_GENID","""{"handler":"Valid_Supplier_genid","iparms":[{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9"},{"av":"A65Supplier_GenKvKNumber","fld":"SUPPLIER_GENKVKNUMBER"},{"av":"A66Supplier_GenCompanyName","fld":"SUPPLIER_GENCOMPANYNAME"},{"av":"A67Supplier_GenVisitingAddress","fld":"SUPPLIER_GENVISITINGADDRESS"},{"av":"A68Supplier_GenPostalAddress","fld":"SUPPLIER_GENPOSTALADDRESS"},{"av":"A69Supplier_GenContactName","fld":"SUPPLIER_GENCONTACTNAME"},{"av":"A70Supplier_GenContactPhone","fld":"SUPPLIER_GENCONTACTPHONE"}]""");
         setEventMetadata("VALID_SUPPLIER_GENID",""","oparms":[{"av":"A65Supplier_GenKvKNumber","fld":"SUPPLIER_GENKVKNUMBER"},{"av":"A66Supplier_GenCompanyName","fld":"SUPPLIER_GENCOMPANYNAME"},{"av":"A67Supplier_GenVisitingAddress","fld":"SUPPLIER_GENVISITINGADDRESS"},{"av":"A68Supplier_GenPostalAddress","fld":"SUPPLIER_GENPOSTALADDRESS"},{"av":"A69Supplier_GenContactName","fld":"SUPPLIER_GENCONTACTNAME"},{"av":"A70Supplier_GenContactPhone","fld":"SUPPLIER_GENCONTACTPHONE"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Supplier_gencontactphone","iparms":[]}""");
         setEventMetadata("VALID_AMENITIESID","""{"handler":"Valid_Amenitiesid","iparms":[{"av":"A98AmenitiesId","fld":"AMENITIESID","pic":"ZZZ9"},{"av":"A99AmenitiesTypeId","fld":"AMENITIESTYPEID","pic":"ZZZ9"},{"av":"A101AmenitiesName","fld":"AMENITIESNAME"},{"av":"A100AmenitiesTypeName","fld":"AMENITIESTYPENAME"}]""");
         setEventMetadata("VALID_AMENITIESID",""","oparms":[{"av":"A101AmenitiesName","fld":"AMENITIESNAME"},{"av":"A99AmenitiesTypeId","fld":"AMENITIESTYPEID","pic":"ZZZ9"},{"av":"A100AmenitiesTypeName","fld":"AMENITIESTYPENAME"}]}""");
         setEventMetadata("VALID_AMENITIESTYPEID","""{"handler":"Valid_Amenitiestypeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Amenitiestypename","iparms":[]}""");
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
         pr_default.close(75);
         pr_default.close(76);
         pr_default.close(5);
         pr_default.close(67);
         pr_default.close(8);
         pr_default.close(60);
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(15);
         pr_default.close(17);
         pr_default.close(28);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z41CustomerKvkNumber = "";
         Z3CustomerName = "";
         Z4CustomerPostalAddress = "";
         Z5CustomerEmail = "";
         Z6CustomerVisitingAddress = "";
         Z7CustomerPhone = "";
         Z14CustomerVatNumber = "";
         Combo_customertypeid_Selectedvalue_get = "";
         Z13CustomerManagerGAMGUID = "";
         Z17CustomerManagerInitials = "";
         Z16CustomerManagerGivenName = "";
         Z9CustomerManagerLastName = "";
         Z10CustomerManagerEmail = "";
         Z11CustomerManagerPhone = "";
         Z12CustomerManagerGender = "";
         Z19CustomerLocationVisitingAddres = "";
         Z20CustomerLocationPostalAddress = "";
         Z21CustomerLocationEmail = "";
         Z22CustomerLocationPhone = "";
         Z133CustomerLocationDescription = "";
         Z134CustomerLocationName = "";
         Z30CustomerLocationReceptionistGA = "";
         Z26CustomerLocationReceptionistIn = "";
         Z24CustomerLocationReceptionistGi = "";
         Z25CustomerLocationReceptionistLa = "";
         Z27CustomerLocationReceptionistEm = "";
         Z28CustomerLocationReceptionistAd = "";
         Z29CustomerLocationReceptionistPh = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A16CustomerManagerGivenName = "";
         A9CustomerManagerLastName = "";
         A24CustomerLocationReceptionistGi = "";
         A25CustomerLocationReceptionistLa = "";
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
         A41CustomerKvkNumber = "";
         A3CustomerName = "";
         A4CustomerPostalAddress = "";
         A5CustomerEmail = "";
         A6CustomerVisitingAddress = "";
         gxphoneLink = "";
         A7CustomerPhone = "";
         A14CustomerVatNumber = "";
         lblTextblockcustomertypeid_Jsonclick = "";
         ucCombo_customertypeid = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV26CustomerTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTablevel_manager_title_Jsonclick = "";
         lblTablevel_locations_title_Jsonclick = "";
         bttBtnwizardprevious_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtnwizardnext_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_supplier_agbid = new GXUserControl();
         AV25Supplier_AgbId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         ucCombo_supplier_genid = new GXUserControl();
         AV18Supplier_GenId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         ucCombo_amenitiesid = new GXUserControl();
         AV28AmenitiesId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         ucWizard_steps = new GXUserControl();
         Gridlevel_managerContainer = new GXWebGrid( context);
         sMode2 = "";
         sStyleString = "";
         Freestylelevel_locationsContainer = new GXWebGrid( context);
         sMode3 = "";
         A79CustomerTypeName = "";
         AV30Pgmname = "";
         A133CustomerLocationDescription = "";
         A134CustomerLocationName = "";
         Combo_customertypeid_Objectcall = "";
         Combo_customertypeid_Class = "";
         Combo_customertypeid_Icontype = "";
         Combo_customertypeid_Icon = "";
         Combo_customertypeid_Tooltip = "";
         Combo_customertypeid_Selectedvalue_set = "";
         Combo_customertypeid_Selectedtext_set = "";
         Combo_customertypeid_Selectedtext_get = "";
         Combo_customertypeid_Gamoauthtoken = "";
         Combo_customertypeid_Ddointernalname = "";
         Combo_customertypeid_Titlecontrolalign = "";
         Combo_customertypeid_Dropdownoptionstype = "";
         Combo_customertypeid_Titlecontrolidtoreplace = "";
         Combo_customertypeid_Datalisttype = "";
         Combo_customertypeid_Datalistfixedvalues = "";
         Combo_customertypeid_Remoteservicesparameters = "";
         Combo_customertypeid_Htmltemplate = "";
         Combo_customertypeid_Multiplevaluestype = "";
         Combo_customertypeid_Loadingdata = "";
         Combo_customertypeid_Noresultsfound = "";
         Combo_customertypeid_Emptyitemtext = "";
         Combo_customertypeid_Onlyselectedvalues = "";
         Combo_customertypeid_Selectalltext = "";
         Combo_customertypeid_Multiplevaluesseparator = "";
         Combo_customertypeid_Addnewoptiontext = "";
         Gxuitabspanel_steps_Objectcall = "";
         Gxuitabspanel_steps_Activepagecontrolname = "";
         Combo_supplier_agbid_Objectcall = "";
         Combo_supplier_agbid_Class = "";
         Combo_supplier_agbid_Icontype = "";
         Combo_supplier_agbid_Icon = "";
         Combo_supplier_agbid_Tooltip = "";
         Combo_supplier_agbid_Selectedvalue_set = "";
         Combo_supplier_agbid_Selectedvalue_get = "";
         Combo_supplier_agbid_Selectedtext_set = "";
         Combo_supplier_agbid_Selectedtext_get = "";
         Combo_supplier_agbid_Gamoauthtoken = "";
         Combo_supplier_agbid_Ddointernalname = "";
         Combo_supplier_agbid_Titlecontrolalign = "";
         Combo_supplier_agbid_Dropdownoptionstype = "";
         Combo_supplier_agbid_Datalisttype = "";
         Combo_supplier_agbid_Datalistfixedvalues = "";
         Combo_supplier_agbid_Remoteservicesparameters = "";
         Combo_supplier_agbid_Htmltemplate = "";
         Combo_supplier_agbid_Multiplevaluestype = "";
         Combo_supplier_agbid_Loadingdata = "";
         Combo_supplier_agbid_Noresultsfound = "";
         Combo_supplier_agbid_Emptyitemtext = "";
         Combo_supplier_agbid_Onlyselectedvalues = "";
         Combo_supplier_agbid_Selectalltext = "";
         Combo_supplier_agbid_Multiplevaluesseparator = "";
         Combo_supplier_agbid_Addnewoptiontext = "";
         Combo_supplier_genid_Objectcall = "";
         Combo_supplier_genid_Class = "";
         Combo_supplier_genid_Icontype = "";
         Combo_supplier_genid_Icon = "";
         Combo_supplier_genid_Tooltip = "";
         Combo_supplier_genid_Selectedvalue_set = "";
         Combo_supplier_genid_Selectedvalue_get = "";
         Combo_supplier_genid_Selectedtext_set = "";
         Combo_supplier_genid_Selectedtext_get = "";
         Combo_supplier_genid_Gamoauthtoken = "";
         Combo_supplier_genid_Ddointernalname = "";
         Combo_supplier_genid_Titlecontrolalign = "";
         Combo_supplier_genid_Dropdownoptionstype = "";
         Combo_supplier_genid_Datalisttype = "";
         Combo_supplier_genid_Datalistfixedvalues = "";
         Combo_supplier_genid_Remoteservicesparameters = "";
         Combo_supplier_genid_Htmltemplate = "";
         Combo_supplier_genid_Multiplevaluestype = "";
         Combo_supplier_genid_Loadingdata = "";
         Combo_supplier_genid_Noresultsfound = "";
         Combo_supplier_genid_Emptyitemtext = "";
         Combo_supplier_genid_Onlyselectedvalues = "";
         Combo_supplier_genid_Selectalltext = "";
         Combo_supplier_genid_Multiplevaluesseparator = "";
         Combo_supplier_genid_Addnewoptiontext = "";
         Combo_amenitiesid_Objectcall = "";
         Combo_amenitiesid_Class = "";
         Combo_amenitiesid_Icontype = "";
         Combo_amenitiesid_Icon = "";
         Combo_amenitiesid_Tooltip = "";
         Combo_amenitiesid_Selectedvalue_set = "";
         Combo_amenitiesid_Selectedvalue_get = "";
         Combo_amenitiesid_Selectedtext_set = "";
         Combo_amenitiesid_Selectedtext_get = "";
         Combo_amenitiesid_Gamoauthtoken = "";
         Combo_amenitiesid_Ddointernalname = "";
         Combo_amenitiesid_Titlecontrolalign = "";
         Combo_amenitiesid_Dropdownoptionstype = "";
         Combo_amenitiesid_Datalisttype = "";
         Combo_amenitiesid_Datalistfixedvalues = "";
         Combo_amenitiesid_Remoteservicesparameters = "";
         Combo_amenitiesid_Htmltemplate = "";
         Combo_amenitiesid_Multiplevaluestype = "";
         Combo_amenitiesid_Loadingdata = "";
         Combo_amenitiesid_Noresultsfound = "";
         Combo_amenitiesid_Emptyitemtext = "";
         Combo_amenitiesid_Onlyselectedvalues = "";
         Combo_amenitiesid_Selectalltext = "";
         Combo_amenitiesid_Multiplevaluesseparator = "";
         Combo_amenitiesid_Addnewoptiontext = "";
         Wizard_steps_Objectcall = "";
         Wizard_steps_Class = "";
         Wizard_steps_Allowsteptitleclick = "";
         Wizard_steps_Transformtype = "";
         Wizard_steps_Wizardarrowselectedunselectedimage = "";
         Wizard_steps_Wizardarrowunselectedselectedimage = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         A17CustomerManagerInitials = "";
         A10CustomerManagerEmail = "";
         A11CustomerManagerPhone = "";
         A12CustomerManagerGender = "";
         A13CustomerManagerGAMGUID = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A100AmenitiesTypeName = "";
         A66Supplier_GenCompanyName = "";
         A67Supplier_GenVisitingAddress = "";
         A68Supplier_GenPostalAddress = "";
         A69Supplier_GenContactName = "";
         A70Supplier_GenContactPhone = "";
         A57Supplier_AgbName = "";
         A58Supplier_AgbKvkNumber = "";
         A59Supplier_AgbVisitingAddress = "";
         A60Supplier_AgbPostalAddress = "";
         A61Supplier_AgbEmail = "";
         A62Supplier_AgbPhone = "";
         A63Supplier_AgbContactName = "";
         A26CustomerLocationReceptionistIn = "";
         A27CustomerLocationReceptionistEm = "";
         A28CustomerLocationReceptionistAd = "";
         A29CustomerLocationReceptionistPh = "";
         A30CustomerLocationReceptionistGA = "";
         A19CustomerLocationVisitingAddres = "";
         A20CustomerLocationPostalAddress = "";
         A21CustomerLocationEmail = "";
         A22CustomerLocationPhone = "";
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
         Z79CustomerTypeName = "";
         T000120_A79CustomerTypeName = new string[] {""} ;
         T000121_A1CustomerId = new short[1] ;
         T000121_A41CustomerKvkNumber = new string[] {""} ;
         T000121_A3CustomerName = new string[] {""} ;
         T000121_A4CustomerPostalAddress = new string[] {""} ;
         T000121_n4CustomerPostalAddress = new bool[] {false} ;
         T000121_A5CustomerEmail = new string[] {""} ;
         T000121_n5CustomerEmail = new bool[] {false} ;
         T000121_A6CustomerVisitingAddress = new string[] {""} ;
         T000121_n6CustomerVisitingAddress = new bool[] {false} ;
         T000121_A7CustomerPhone = new string[] {""} ;
         T000121_n7CustomerPhone = new bool[] {false} ;
         T000121_A14CustomerVatNumber = new string[] {""} ;
         T000121_A79CustomerTypeName = new string[] {""} ;
         T000121_A93CustomerLastLine = new short[1] ;
         T000121_A95CustomerLastLineLocation = new short[1] ;
         T000121_A78CustomerTypeId = new short[1] ;
         T000121_n78CustomerTypeId = new bool[] {false} ;
         T000122_A79CustomerTypeName = new string[] {""} ;
         T000123_A1CustomerId = new short[1] ;
         T000119_A1CustomerId = new short[1] ;
         T000119_A41CustomerKvkNumber = new string[] {""} ;
         T000119_A3CustomerName = new string[] {""} ;
         T000119_A4CustomerPostalAddress = new string[] {""} ;
         T000119_n4CustomerPostalAddress = new bool[] {false} ;
         T000119_A5CustomerEmail = new string[] {""} ;
         T000119_n5CustomerEmail = new bool[] {false} ;
         T000119_A6CustomerVisitingAddress = new string[] {""} ;
         T000119_n6CustomerVisitingAddress = new bool[] {false} ;
         T000119_A7CustomerPhone = new string[] {""} ;
         T000119_n7CustomerPhone = new bool[] {false} ;
         T000119_A14CustomerVatNumber = new string[] {""} ;
         T000119_A93CustomerLastLine = new short[1] ;
         T000119_A95CustomerLastLineLocation = new short[1] ;
         T000119_A78CustomerTypeId = new short[1] ;
         T000119_n78CustomerTypeId = new bool[] {false} ;
         T000124_A1CustomerId = new short[1] ;
         T000125_A1CustomerId = new short[1] ;
         T000118_A1CustomerId = new short[1] ;
         T000118_A41CustomerKvkNumber = new string[] {""} ;
         T000118_A3CustomerName = new string[] {""} ;
         T000118_A4CustomerPostalAddress = new string[] {""} ;
         T000118_n4CustomerPostalAddress = new bool[] {false} ;
         T000118_A5CustomerEmail = new string[] {""} ;
         T000118_n5CustomerEmail = new bool[] {false} ;
         T000118_A6CustomerVisitingAddress = new string[] {""} ;
         T000118_n6CustomerVisitingAddress = new bool[] {false} ;
         T000118_A7CustomerPhone = new string[] {""} ;
         T000118_n7CustomerPhone = new bool[] {false} ;
         T000118_A14CustomerVatNumber = new string[] {""} ;
         T000118_A93CustomerLastLine = new short[1] ;
         T000118_A95CustomerLastLineLocation = new short[1] ;
         T000118_A78CustomerTypeId = new short[1] ;
         T000118_n78CustomerTypeId = new bool[] {false} ;
         T000127_A1CustomerId = new short[1] ;
         T000130_A79CustomerTypeName = new string[] {""} ;
         T000131_A128CustomerCustomizationId = new short[1] ;
         T000132_A103PageId = new short[1] ;
         T000133_A1CustomerId = new short[1] ;
         T000133_A18CustomerLocationId = new short[1] ;
         T000135_A1CustomerId = new short[1] ;
         T000136_A1CustomerId = new short[1] ;
         T000136_A15CustomerManagerId = new short[1] ;
         T000136_A13CustomerManagerGAMGUID = new string[] {""} ;
         T000136_A17CustomerManagerInitials = new string[] {""} ;
         T000136_n17CustomerManagerInitials = new bool[] {false} ;
         T000136_A16CustomerManagerGivenName = new string[] {""} ;
         T000136_A9CustomerManagerLastName = new string[] {""} ;
         T000136_A10CustomerManagerEmail = new string[] {""} ;
         T000136_A11CustomerManagerPhone = new string[] {""} ;
         T000136_n11CustomerManagerPhone = new bool[] {false} ;
         T000136_A12CustomerManagerGender = new string[] {""} ;
         T000136_n12CustomerManagerGender = new bool[] {false} ;
         T000137_A1CustomerId = new short[1] ;
         T000137_A15CustomerManagerId = new short[1] ;
         T000117_A1CustomerId = new short[1] ;
         T000117_A15CustomerManagerId = new short[1] ;
         T000117_A13CustomerManagerGAMGUID = new string[] {""} ;
         T000117_A17CustomerManagerInitials = new string[] {""} ;
         T000117_n17CustomerManagerInitials = new bool[] {false} ;
         T000117_A16CustomerManagerGivenName = new string[] {""} ;
         T000117_A9CustomerManagerLastName = new string[] {""} ;
         T000117_A10CustomerManagerEmail = new string[] {""} ;
         T000117_A11CustomerManagerPhone = new string[] {""} ;
         T000117_n11CustomerManagerPhone = new bool[] {false} ;
         T000117_A12CustomerManagerGender = new string[] {""} ;
         T000117_n12CustomerManagerGender = new bool[] {false} ;
         T000116_A1CustomerId = new short[1] ;
         T000116_A15CustomerManagerId = new short[1] ;
         T000116_A13CustomerManagerGAMGUID = new string[] {""} ;
         T000116_A17CustomerManagerInitials = new string[] {""} ;
         T000116_n17CustomerManagerInitials = new bool[] {false} ;
         T000116_A16CustomerManagerGivenName = new string[] {""} ;
         T000116_A9CustomerManagerLastName = new string[] {""} ;
         T000116_A10CustomerManagerEmail = new string[] {""} ;
         T000116_A11CustomerManagerPhone = new string[] {""} ;
         T000116_n11CustomerManagerPhone = new bool[] {false} ;
         T000116_A12CustomerManagerGender = new string[] {""} ;
         T000116_n12CustomerManagerGender = new bool[] {false} ;
         T000141_A1CustomerId = new short[1] ;
         T000141_A15CustomerManagerId = new short[1] ;
         T000142_A1CustomerId = new short[1] ;
         T000142_A18CustomerLocationId = new short[1] ;
         T000142_A19CustomerLocationVisitingAddres = new string[] {""} ;
         T000142_A20CustomerLocationPostalAddress = new string[] {""} ;
         T000142_A21CustomerLocationEmail = new string[] {""} ;
         T000142_A22CustomerLocationPhone = new string[] {""} ;
         T000142_A94CustomerLocationLastLine = new short[1] ;
         T000142_A133CustomerLocationDescription = new string[] {""} ;
         T000142_A134CustomerLocationName = new string[] {""} ;
         T000143_A1CustomerId = new short[1] ;
         T000143_A18CustomerLocationId = new short[1] ;
         T000115_A1CustomerId = new short[1] ;
         T000115_A18CustomerLocationId = new short[1] ;
         T000115_A19CustomerLocationVisitingAddres = new string[] {""} ;
         T000115_A20CustomerLocationPostalAddress = new string[] {""} ;
         T000115_A21CustomerLocationEmail = new string[] {""} ;
         T000115_A22CustomerLocationPhone = new string[] {""} ;
         T000115_A94CustomerLocationLastLine = new short[1] ;
         T000115_A133CustomerLocationDescription = new string[] {""} ;
         T000115_A134CustomerLocationName = new string[] {""} ;
         T000114_A1CustomerId = new short[1] ;
         T000114_A18CustomerLocationId = new short[1] ;
         T000114_A19CustomerLocationVisitingAddres = new string[] {""} ;
         T000114_A20CustomerLocationPostalAddress = new string[] {""} ;
         T000114_A21CustomerLocationEmail = new string[] {""} ;
         T000114_A22CustomerLocationPhone = new string[] {""} ;
         T000114_A94CustomerLocationLastLine = new short[1] ;
         T000114_A133CustomerLocationDescription = new string[] {""} ;
         T000114_A134CustomerLocationName = new string[] {""} ;
         T000147_A115LocationEventId = new short[1] ;
         T000148_A31ResidentId = new short[1] ;
         T000150_A1CustomerId = new short[1] ;
         T000150_A18CustomerLocationId = new short[1] ;
         T000151_A1CustomerId = new short[1] ;
         T000151_A18CustomerLocationId = new short[1] ;
         T000151_A23CustomerLocationReceptionistId = new short[1] ;
         T000151_A30CustomerLocationReceptionistGA = new string[] {""} ;
         T000151_A26CustomerLocationReceptionistIn = new string[] {""} ;
         T000151_n26CustomerLocationReceptionistIn = new bool[] {false} ;
         T000151_A24CustomerLocationReceptionistGi = new string[] {""} ;
         T000151_A25CustomerLocationReceptionistLa = new string[] {""} ;
         T000151_A27CustomerLocationReceptionistEm = new string[] {""} ;
         T000151_A28CustomerLocationReceptionistAd = new string[] {""} ;
         T000151_n28CustomerLocationReceptionistAd = new bool[] {false} ;
         T000151_A29CustomerLocationReceptionistPh = new string[] {""} ;
         T000152_A1CustomerId = new short[1] ;
         T000152_A18CustomerLocationId = new short[1] ;
         T000152_A23CustomerLocationReceptionistId = new short[1] ;
         T000113_A1CustomerId = new short[1] ;
         T000113_A18CustomerLocationId = new short[1] ;
         T000113_A23CustomerLocationReceptionistId = new short[1] ;
         T000113_A30CustomerLocationReceptionistGA = new string[] {""} ;
         T000113_A26CustomerLocationReceptionistIn = new string[] {""} ;
         T000113_n26CustomerLocationReceptionistIn = new bool[] {false} ;
         T000113_A24CustomerLocationReceptionistGi = new string[] {""} ;
         T000113_A25CustomerLocationReceptionistLa = new string[] {""} ;
         T000113_A27CustomerLocationReceptionistEm = new string[] {""} ;
         T000113_A28CustomerLocationReceptionistAd = new string[] {""} ;
         T000113_n28CustomerLocationReceptionistAd = new bool[] {false} ;
         T000113_A29CustomerLocationReceptionistPh = new string[] {""} ;
         sMode4 = "";
         T000112_A1CustomerId = new short[1] ;
         T000112_A18CustomerLocationId = new short[1] ;
         T000112_A23CustomerLocationReceptionistId = new short[1] ;
         T000112_A30CustomerLocationReceptionistGA = new string[] {""} ;
         T000112_A26CustomerLocationReceptionistIn = new string[] {""} ;
         T000112_n26CustomerLocationReceptionistIn = new bool[] {false} ;
         T000112_A24CustomerLocationReceptionistGi = new string[] {""} ;
         T000112_A25CustomerLocationReceptionistLa = new string[] {""} ;
         T000112_A27CustomerLocationReceptionistEm = new string[] {""} ;
         T000112_A28CustomerLocationReceptionistAd = new string[] {""} ;
         T000112_n28CustomerLocationReceptionistAd = new bool[] {false} ;
         T000112_A29CustomerLocationReceptionistPh = new string[] {""} ;
         T000156_A1CustomerId = new short[1] ;
         T000156_A18CustomerLocationId = new short[1] ;
         T000156_A23CustomerLocationReceptionistId = new short[1] ;
         Z56Supplier_AgbNumber = "";
         A56Supplier_AgbNumber = "";
         Z57Supplier_AgbName = "";
         Z58Supplier_AgbKvkNumber = "";
         Z59Supplier_AgbVisitingAddress = "";
         Z60Supplier_AgbPostalAddress = "";
         Z61Supplier_AgbEmail = "";
         Z62Supplier_AgbPhone = "";
         Z63Supplier_AgbContactName = "";
         T000157_A1CustomerId = new short[1] ;
         T000157_A18CustomerLocationId = new short[1] ;
         T000157_A56Supplier_AgbNumber = new string[] {""} ;
         T000157_A57Supplier_AgbName = new string[] {""} ;
         T000157_A58Supplier_AgbKvkNumber = new string[] {""} ;
         T000157_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         T000157_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         T000157_A60Supplier_AgbPostalAddress = new string[] {""} ;
         T000157_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         T000157_A61Supplier_AgbEmail = new string[] {""} ;
         T000157_n61Supplier_AgbEmail = new bool[] {false} ;
         T000157_A62Supplier_AgbPhone = new string[] {""} ;
         T000157_n62Supplier_AgbPhone = new bool[] {false} ;
         T000157_A63Supplier_AgbContactName = new string[] {""} ;
         T000157_n63Supplier_AgbContactName = new bool[] {false} ;
         T000157_A55Supplier_AgbId = new short[1] ;
         T000111_A56Supplier_AgbNumber = new string[] {""} ;
         T000111_A57Supplier_AgbName = new string[] {""} ;
         T000111_A58Supplier_AgbKvkNumber = new string[] {""} ;
         T000111_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         T000111_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         T000111_A60Supplier_AgbPostalAddress = new string[] {""} ;
         T000111_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         T000111_A61Supplier_AgbEmail = new string[] {""} ;
         T000111_n61Supplier_AgbEmail = new bool[] {false} ;
         T000111_A62Supplier_AgbPhone = new string[] {""} ;
         T000111_n62Supplier_AgbPhone = new bool[] {false} ;
         T000111_A63Supplier_AgbContactName = new string[] {""} ;
         T000111_n63Supplier_AgbContactName = new bool[] {false} ;
         T000158_A56Supplier_AgbNumber = new string[] {""} ;
         T000158_A57Supplier_AgbName = new string[] {""} ;
         T000158_A58Supplier_AgbKvkNumber = new string[] {""} ;
         T000158_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         T000158_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         T000158_A60Supplier_AgbPostalAddress = new string[] {""} ;
         T000158_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         T000158_A61Supplier_AgbEmail = new string[] {""} ;
         T000158_n61Supplier_AgbEmail = new bool[] {false} ;
         T000158_A62Supplier_AgbPhone = new string[] {""} ;
         T000158_n62Supplier_AgbPhone = new bool[] {false} ;
         T000158_A63Supplier_AgbContactName = new string[] {""} ;
         T000158_n63Supplier_AgbContactName = new bool[] {false} ;
         T000159_A1CustomerId = new short[1] ;
         T000159_A18CustomerLocationId = new short[1] ;
         T000159_A55Supplier_AgbId = new short[1] ;
         T000110_A1CustomerId = new short[1] ;
         T000110_A18CustomerLocationId = new short[1] ;
         T000110_A55Supplier_AgbId = new short[1] ;
         sMode16 = "";
         T00019_A1CustomerId = new short[1] ;
         T00019_A18CustomerLocationId = new short[1] ;
         T00019_A55Supplier_AgbId = new short[1] ;
         T000162_A56Supplier_AgbNumber = new string[] {""} ;
         T000162_A57Supplier_AgbName = new string[] {""} ;
         T000162_A58Supplier_AgbKvkNumber = new string[] {""} ;
         T000162_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         T000162_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         T000162_A60Supplier_AgbPostalAddress = new string[] {""} ;
         T000162_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         T000162_A61Supplier_AgbEmail = new string[] {""} ;
         T000162_n61Supplier_AgbEmail = new bool[] {false} ;
         T000162_A62Supplier_AgbPhone = new string[] {""} ;
         T000162_n62Supplier_AgbPhone = new bool[] {false} ;
         T000162_A63Supplier_AgbContactName = new string[] {""} ;
         T000162_n63Supplier_AgbContactName = new bool[] {false} ;
         T000163_A1CustomerId = new short[1] ;
         T000163_A18CustomerLocationId = new short[1] ;
         T000163_A55Supplier_AgbId = new short[1] ;
         Z65Supplier_GenKvKNumber = "";
         A65Supplier_GenKvKNumber = "";
         Z66Supplier_GenCompanyName = "";
         Z67Supplier_GenVisitingAddress = "";
         Z68Supplier_GenPostalAddress = "";
         Z69Supplier_GenContactName = "";
         Z70Supplier_GenContactPhone = "";
         T000164_A1CustomerId = new short[1] ;
         T000164_A18CustomerLocationId = new short[1] ;
         T000164_A65Supplier_GenKvKNumber = new string[] {""} ;
         T000164_A66Supplier_GenCompanyName = new string[] {""} ;
         T000164_A67Supplier_GenVisitingAddress = new string[] {""} ;
         T000164_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         T000164_A68Supplier_GenPostalAddress = new string[] {""} ;
         T000164_n68Supplier_GenPostalAddress = new bool[] {false} ;
         T000164_A69Supplier_GenContactName = new string[] {""} ;
         T000164_n69Supplier_GenContactName = new bool[] {false} ;
         T000164_A70Supplier_GenContactPhone = new string[] {""} ;
         T000164_n70Supplier_GenContactPhone = new bool[] {false} ;
         T000164_A64Supplier_GenId = new short[1] ;
         T00018_A65Supplier_GenKvKNumber = new string[] {""} ;
         T00018_A66Supplier_GenCompanyName = new string[] {""} ;
         T00018_A67Supplier_GenVisitingAddress = new string[] {""} ;
         T00018_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         T00018_A68Supplier_GenPostalAddress = new string[] {""} ;
         T00018_n68Supplier_GenPostalAddress = new bool[] {false} ;
         T00018_A69Supplier_GenContactName = new string[] {""} ;
         T00018_n69Supplier_GenContactName = new bool[] {false} ;
         T00018_A70Supplier_GenContactPhone = new string[] {""} ;
         T00018_n70Supplier_GenContactPhone = new bool[] {false} ;
         T000165_A65Supplier_GenKvKNumber = new string[] {""} ;
         T000165_A66Supplier_GenCompanyName = new string[] {""} ;
         T000165_A67Supplier_GenVisitingAddress = new string[] {""} ;
         T000165_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         T000165_A68Supplier_GenPostalAddress = new string[] {""} ;
         T000165_n68Supplier_GenPostalAddress = new bool[] {false} ;
         T000165_A69Supplier_GenContactName = new string[] {""} ;
         T000165_n69Supplier_GenContactName = new bool[] {false} ;
         T000165_A70Supplier_GenContactPhone = new string[] {""} ;
         T000165_n70Supplier_GenContactPhone = new bool[] {false} ;
         T000166_A1CustomerId = new short[1] ;
         T000166_A18CustomerLocationId = new short[1] ;
         T000166_A64Supplier_GenId = new short[1] ;
         T00017_A1CustomerId = new short[1] ;
         T00017_A18CustomerLocationId = new short[1] ;
         T00017_A64Supplier_GenId = new short[1] ;
         sMode17 = "";
         T00016_A1CustomerId = new short[1] ;
         T00016_A18CustomerLocationId = new short[1] ;
         T00016_A64Supplier_GenId = new short[1] ;
         T000169_A65Supplier_GenKvKNumber = new string[] {""} ;
         T000169_A66Supplier_GenCompanyName = new string[] {""} ;
         T000169_A67Supplier_GenVisitingAddress = new string[] {""} ;
         T000169_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         T000169_A68Supplier_GenPostalAddress = new string[] {""} ;
         T000169_n68Supplier_GenPostalAddress = new bool[] {false} ;
         T000169_A69Supplier_GenContactName = new string[] {""} ;
         T000169_n69Supplier_GenContactName = new bool[] {false} ;
         T000169_A70Supplier_GenContactPhone = new string[] {""} ;
         T000169_n70Supplier_GenContactPhone = new bool[] {false} ;
         T000170_A1CustomerId = new short[1] ;
         T000170_A18CustomerLocationId = new short[1] ;
         T000170_A64Supplier_GenId = new short[1] ;
         Z101AmenitiesName = "";
         A101AmenitiesName = "";
         Z100AmenitiesTypeName = "";
         T000171_A1CustomerId = new short[1] ;
         T000171_A18CustomerLocationId = new short[1] ;
         T000171_A101AmenitiesName = new string[] {""} ;
         T000171_A100AmenitiesTypeName = new string[] {""} ;
         T000171_A98AmenitiesId = new short[1] ;
         T000171_A99AmenitiesTypeId = new short[1] ;
         T00014_A101AmenitiesName = new string[] {""} ;
         T00014_A99AmenitiesTypeId = new short[1] ;
         T00015_A100AmenitiesTypeName = new string[] {""} ;
         T000172_A101AmenitiesName = new string[] {""} ;
         T000172_A99AmenitiesTypeId = new short[1] ;
         T000173_A100AmenitiesTypeName = new string[] {""} ;
         T000174_A1CustomerId = new short[1] ;
         T000174_A18CustomerLocationId = new short[1] ;
         T000174_A98AmenitiesId = new short[1] ;
         T00013_A1CustomerId = new short[1] ;
         T00013_A18CustomerLocationId = new short[1] ;
         T00013_A98AmenitiesId = new short[1] ;
         sMode21 = "";
         T00012_A1CustomerId = new short[1] ;
         T00012_A18CustomerLocationId = new short[1] ;
         T00012_A98AmenitiesId = new short[1] ;
         T000177_A101AmenitiesName = new string[] {""} ;
         T000177_A99AmenitiesTypeId = new short[1] ;
         T000178_A100AmenitiesTypeName = new string[] {""} ;
         T000179_A1CustomerId = new short[1] ;
         T000179_A18CustomerLocationId = new short[1] ;
         T000179_A98AmenitiesId = new short[1] ;
         Gridlevel_managerRow = new GXWebRow();
         subGridlevel_manager_Linesclass = "";
         ROClassString = "";
         Freestylelevel_locationsRow = new GXWebRow();
         subFreestylelevel_locations_Linesclass = "";
         Gridlevel_receptionistContainer = new GXWebGrid( context);
         Gridlevel_supplier_agbContainer = new GXWebGrid( context);
         Gridlevel_supplier_genContainer = new GXWebGrid( context);
         Gridlevel_amenitiesContainer = new GXWebGrid( context);
         Gridlevel_receptionistRow = new GXWebRow();
         subGridlevel_receptionist_Linesclass = "";
         Gridlevel_supplier_agbRow = new GXWebRow();
         subGridlevel_supplier_agb_Linesclass = "";
         Gridlevel_supplier_genRow = new GXWebRow();
         subGridlevel_supplier_gen_Linesclass = "";
         Gridlevel_amenitiesRow = new GXWebRow();
         subGridlevel_amenities_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_managerColumn = new GXWebColumn();
         subFreestylelevel_locations_Header = "";
         Freestylelevel_locationsColumn = new GXWebColumn();
         Gridlevel_receptionistColumn = new GXWebColumn();
         Gridlevel_supplier_agbColumn = new GXWebColumn();
         Gridlevel_supplier_genColumn = new GXWebColumn();
         Gridlevel_amenitiesColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.customer__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customer__default(),
            new Object[][] {
                new Object[] {
               T00012_A1CustomerId, T00012_A18CustomerLocationId, T00012_A98AmenitiesId
               }
               , new Object[] {
               T00013_A1CustomerId, T00013_A18CustomerLocationId, T00013_A98AmenitiesId
               }
               , new Object[] {
               T00014_A101AmenitiesName, T00014_A99AmenitiesTypeId
               }
               , new Object[] {
               T00015_A100AmenitiesTypeName
               }
               , new Object[] {
               T00016_A1CustomerId, T00016_A18CustomerLocationId, T00016_A64Supplier_GenId
               }
               , new Object[] {
               T00017_A1CustomerId, T00017_A18CustomerLocationId, T00017_A64Supplier_GenId
               }
               , new Object[] {
               T00018_A65Supplier_GenKvKNumber, T00018_A66Supplier_GenCompanyName, T00018_A67Supplier_GenVisitingAddress, T00018_n67Supplier_GenVisitingAddress, T00018_A68Supplier_GenPostalAddress, T00018_n68Supplier_GenPostalAddress, T00018_A69Supplier_GenContactName, T00018_n69Supplier_GenContactName, T00018_A70Supplier_GenContactPhone, T00018_n70Supplier_GenContactPhone
               }
               , new Object[] {
               T00019_A1CustomerId, T00019_A18CustomerLocationId, T00019_A55Supplier_AgbId
               }
               , new Object[] {
               T000110_A1CustomerId, T000110_A18CustomerLocationId, T000110_A55Supplier_AgbId
               }
               , new Object[] {
               T000111_A56Supplier_AgbNumber, T000111_A57Supplier_AgbName, T000111_A58Supplier_AgbKvkNumber, T000111_A59Supplier_AgbVisitingAddress, T000111_n59Supplier_AgbVisitingAddress, T000111_A60Supplier_AgbPostalAddress, T000111_n60Supplier_AgbPostalAddress, T000111_A61Supplier_AgbEmail, T000111_n61Supplier_AgbEmail, T000111_A62Supplier_AgbPhone,
               T000111_n62Supplier_AgbPhone, T000111_A63Supplier_AgbContactName, T000111_n63Supplier_AgbContactName
               }
               , new Object[] {
               T000112_A1CustomerId, T000112_A18CustomerLocationId, T000112_A23CustomerLocationReceptionistId, T000112_A30CustomerLocationReceptionistGA, T000112_A26CustomerLocationReceptionistIn, T000112_n26CustomerLocationReceptionistIn, T000112_A24CustomerLocationReceptionistGi, T000112_A25CustomerLocationReceptionistLa, T000112_A27CustomerLocationReceptionistEm, T000112_A28CustomerLocationReceptionistAd,
               T000112_n28CustomerLocationReceptionistAd, T000112_A29CustomerLocationReceptionistPh
               }
               , new Object[] {
               T000113_A1CustomerId, T000113_A18CustomerLocationId, T000113_A23CustomerLocationReceptionistId, T000113_A30CustomerLocationReceptionistGA, T000113_A26CustomerLocationReceptionistIn, T000113_n26CustomerLocationReceptionistIn, T000113_A24CustomerLocationReceptionistGi, T000113_A25CustomerLocationReceptionistLa, T000113_A27CustomerLocationReceptionistEm, T000113_A28CustomerLocationReceptionistAd,
               T000113_n28CustomerLocationReceptionistAd, T000113_A29CustomerLocationReceptionistPh
               }
               , new Object[] {
               T000114_A1CustomerId, T000114_A18CustomerLocationId, T000114_A19CustomerLocationVisitingAddres, T000114_A20CustomerLocationPostalAddress, T000114_A21CustomerLocationEmail, T000114_A22CustomerLocationPhone, T000114_A94CustomerLocationLastLine, T000114_A133CustomerLocationDescription, T000114_A134CustomerLocationName
               }
               , new Object[] {
               T000115_A1CustomerId, T000115_A18CustomerLocationId, T000115_A19CustomerLocationVisitingAddres, T000115_A20CustomerLocationPostalAddress, T000115_A21CustomerLocationEmail, T000115_A22CustomerLocationPhone, T000115_A94CustomerLocationLastLine, T000115_A133CustomerLocationDescription, T000115_A134CustomerLocationName
               }
               , new Object[] {
               T000116_A1CustomerId, T000116_A15CustomerManagerId, T000116_A13CustomerManagerGAMGUID, T000116_A17CustomerManagerInitials, T000116_n17CustomerManagerInitials, T000116_A16CustomerManagerGivenName, T000116_A9CustomerManagerLastName, T000116_A10CustomerManagerEmail, T000116_A11CustomerManagerPhone, T000116_n11CustomerManagerPhone,
               T000116_A12CustomerManagerGender, T000116_n12CustomerManagerGender
               }
               , new Object[] {
               T000117_A1CustomerId, T000117_A15CustomerManagerId, T000117_A13CustomerManagerGAMGUID, T000117_A17CustomerManagerInitials, T000117_n17CustomerManagerInitials, T000117_A16CustomerManagerGivenName, T000117_A9CustomerManagerLastName, T000117_A10CustomerManagerEmail, T000117_A11CustomerManagerPhone, T000117_n11CustomerManagerPhone,
               T000117_A12CustomerManagerGender, T000117_n12CustomerManagerGender
               }
               , new Object[] {
               T000118_A1CustomerId, T000118_A41CustomerKvkNumber, T000118_A3CustomerName, T000118_A4CustomerPostalAddress, T000118_n4CustomerPostalAddress, T000118_A5CustomerEmail, T000118_n5CustomerEmail, T000118_A6CustomerVisitingAddress, T000118_n6CustomerVisitingAddress, T000118_A7CustomerPhone,
               T000118_n7CustomerPhone, T000118_A14CustomerVatNumber, T000118_A93CustomerLastLine, T000118_A95CustomerLastLineLocation, T000118_A78CustomerTypeId, T000118_n78CustomerTypeId
               }
               , new Object[] {
               T000119_A1CustomerId, T000119_A41CustomerKvkNumber, T000119_A3CustomerName, T000119_A4CustomerPostalAddress, T000119_n4CustomerPostalAddress, T000119_A5CustomerEmail, T000119_n5CustomerEmail, T000119_A6CustomerVisitingAddress, T000119_n6CustomerVisitingAddress, T000119_A7CustomerPhone,
               T000119_n7CustomerPhone, T000119_A14CustomerVatNumber, T000119_A93CustomerLastLine, T000119_A95CustomerLastLineLocation, T000119_A78CustomerTypeId, T000119_n78CustomerTypeId
               }
               , new Object[] {
               T000120_A79CustomerTypeName
               }
               , new Object[] {
               T000121_A1CustomerId, T000121_A41CustomerKvkNumber, T000121_A3CustomerName, T000121_A4CustomerPostalAddress, T000121_n4CustomerPostalAddress, T000121_A5CustomerEmail, T000121_n5CustomerEmail, T000121_A6CustomerVisitingAddress, T000121_n6CustomerVisitingAddress, T000121_A7CustomerPhone,
               T000121_n7CustomerPhone, T000121_A14CustomerVatNumber, T000121_A79CustomerTypeName, T000121_A93CustomerLastLine, T000121_A95CustomerLastLineLocation, T000121_A78CustomerTypeId, T000121_n78CustomerTypeId
               }
               , new Object[] {
               T000122_A79CustomerTypeName
               }
               , new Object[] {
               T000123_A1CustomerId
               }
               , new Object[] {
               T000124_A1CustomerId
               }
               , new Object[] {
               T000125_A1CustomerId
               }
               , new Object[] {
               }
               , new Object[] {
               T000127_A1CustomerId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000130_A79CustomerTypeName
               }
               , new Object[] {
               T000131_A128CustomerCustomizationId
               }
               , new Object[] {
               T000132_A103PageId
               }
               , new Object[] {
               T000133_A1CustomerId, T000133_A18CustomerLocationId
               }
               , new Object[] {
               }
               , new Object[] {
               T000135_A1CustomerId
               }
               , new Object[] {
               T000136_A1CustomerId, T000136_A15CustomerManagerId, T000136_A13CustomerManagerGAMGUID, T000136_A17CustomerManagerInitials, T000136_n17CustomerManagerInitials, T000136_A16CustomerManagerGivenName, T000136_A9CustomerManagerLastName, T000136_A10CustomerManagerEmail, T000136_A11CustomerManagerPhone, T000136_n11CustomerManagerPhone,
               T000136_A12CustomerManagerGender, T000136_n12CustomerManagerGender
               }
               , new Object[] {
               T000137_A1CustomerId, T000137_A15CustomerManagerId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000141_A1CustomerId, T000141_A15CustomerManagerId
               }
               , new Object[] {
               T000142_A1CustomerId, T000142_A18CustomerLocationId, T000142_A19CustomerLocationVisitingAddres, T000142_A20CustomerLocationPostalAddress, T000142_A21CustomerLocationEmail, T000142_A22CustomerLocationPhone, T000142_A94CustomerLocationLastLine, T000142_A133CustomerLocationDescription, T000142_A134CustomerLocationName
               }
               , new Object[] {
               T000143_A1CustomerId, T000143_A18CustomerLocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000147_A115LocationEventId
               }
               , new Object[] {
               T000148_A31ResidentId
               }
               , new Object[] {
               }
               , new Object[] {
               T000150_A1CustomerId, T000150_A18CustomerLocationId
               }
               , new Object[] {
               T000151_A1CustomerId, T000151_A18CustomerLocationId, T000151_A23CustomerLocationReceptionistId, T000151_A30CustomerLocationReceptionistGA, T000151_A26CustomerLocationReceptionistIn, T000151_n26CustomerLocationReceptionistIn, T000151_A24CustomerLocationReceptionistGi, T000151_A25CustomerLocationReceptionistLa, T000151_A27CustomerLocationReceptionistEm, T000151_A28CustomerLocationReceptionistAd,
               T000151_n28CustomerLocationReceptionistAd, T000151_A29CustomerLocationReceptionistPh
               }
               , new Object[] {
               T000152_A1CustomerId, T000152_A18CustomerLocationId, T000152_A23CustomerLocationReceptionistId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000156_A1CustomerId, T000156_A18CustomerLocationId, T000156_A23CustomerLocationReceptionistId
               }
               , new Object[] {
               T000157_A1CustomerId, T000157_A18CustomerLocationId, T000157_A56Supplier_AgbNumber, T000157_A57Supplier_AgbName, T000157_A58Supplier_AgbKvkNumber, T000157_A59Supplier_AgbVisitingAddress, T000157_n59Supplier_AgbVisitingAddress, T000157_A60Supplier_AgbPostalAddress, T000157_n60Supplier_AgbPostalAddress, T000157_A61Supplier_AgbEmail,
               T000157_n61Supplier_AgbEmail, T000157_A62Supplier_AgbPhone, T000157_n62Supplier_AgbPhone, T000157_A63Supplier_AgbContactName, T000157_n63Supplier_AgbContactName, T000157_A55Supplier_AgbId
               }
               , new Object[] {
               T000158_A56Supplier_AgbNumber, T000158_A57Supplier_AgbName, T000158_A58Supplier_AgbKvkNumber, T000158_A59Supplier_AgbVisitingAddress, T000158_n59Supplier_AgbVisitingAddress, T000158_A60Supplier_AgbPostalAddress, T000158_n60Supplier_AgbPostalAddress, T000158_A61Supplier_AgbEmail, T000158_n61Supplier_AgbEmail, T000158_A62Supplier_AgbPhone,
               T000158_n62Supplier_AgbPhone, T000158_A63Supplier_AgbContactName, T000158_n63Supplier_AgbContactName
               }
               , new Object[] {
               T000159_A1CustomerId, T000159_A18CustomerLocationId, T000159_A55Supplier_AgbId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000162_A56Supplier_AgbNumber, T000162_A57Supplier_AgbName, T000162_A58Supplier_AgbKvkNumber, T000162_A59Supplier_AgbVisitingAddress, T000162_n59Supplier_AgbVisitingAddress, T000162_A60Supplier_AgbPostalAddress, T000162_n60Supplier_AgbPostalAddress, T000162_A61Supplier_AgbEmail, T000162_n61Supplier_AgbEmail, T000162_A62Supplier_AgbPhone,
               T000162_n62Supplier_AgbPhone, T000162_A63Supplier_AgbContactName, T000162_n63Supplier_AgbContactName
               }
               , new Object[] {
               T000163_A1CustomerId, T000163_A18CustomerLocationId, T000163_A55Supplier_AgbId
               }
               , new Object[] {
               T000164_A1CustomerId, T000164_A18CustomerLocationId, T000164_A65Supplier_GenKvKNumber, T000164_A66Supplier_GenCompanyName, T000164_A67Supplier_GenVisitingAddress, T000164_n67Supplier_GenVisitingAddress, T000164_A68Supplier_GenPostalAddress, T000164_n68Supplier_GenPostalAddress, T000164_A69Supplier_GenContactName, T000164_n69Supplier_GenContactName,
               T000164_A70Supplier_GenContactPhone, T000164_n70Supplier_GenContactPhone, T000164_A64Supplier_GenId
               }
               , new Object[] {
               T000165_A65Supplier_GenKvKNumber, T000165_A66Supplier_GenCompanyName, T000165_A67Supplier_GenVisitingAddress, T000165_n67Supplier_GenVisitingAddress, T000165_A68Supplier_GenPostalAddress, T000165_n68Supplier_GenPostalAddress, T000165_A69Supplier_GenContactName, T000165_n69Supplier_GenContactName, T000165_A70Supplier_GenContactPhone, T000165_n70Supplier_GenContactPhone
               }
               , new Object[] {
               T000166_A1CustomerId, T000166_A18CustomerLocationId, T000166_A64Supplier_GenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000169_A65Supplier_GenKvKNumber, T000169_A66Supplier_GenCompanyName, T000169_A67Supplier_GenVisitingAddress, T000169_n67Supplier_GenVisitingAddress, T000169_A68Supplier_GenPostalAddress, T000169_n68Supplier_GenPostalAddress, T000169_A69Supplier_GenContactName, T000169_n69Supplier_GenContactName, T000169_A70Supplier_GenContactPhone, T000169_n70Supplier_GenContactPhone
               }
               , new Object[] {
               T000170_A1CustomerId, T000170_A18CustomerLocationId, T000170_A64Supplier_GenId
               }
               , new Object[] {
               T000171_A1CustomerId, T000171_A18CustomerLocationId, T000171_A101AmenitiesName, T000171_A100AmenitiesTypeName, T000171_A98AmenitiesId, T000171_A99AmenitiesTypeId
               }
               , new Object[] {
               T000172_A101AmenitiesName, T000172_A99AmenitiesTypeId
               }
               , new Object[] {
               T000173_A100AmenitiesTypeName
               }
               , new Object[] {
               T000174_A1CustomerId, T000174_A18CustomerLocationId, T000174_A98AmenitiesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000177_A101AmenitiesName, T000177_A99AmenitiesTypeId
               }
               , new Object[] {
               T000178_A100AmenitiesTypeName
               }
               , new Object[] {
               T000179_A1CustomerId, T000179_A18CustomerLocationId, T000179_A98AmenitiesId
               }
            }
         );
         AV30Pgmname = "Customer";
      }

      private short wcpOAV7CustomerId ;
      private short Z1CustomerId ;
      private short Z93CustomerLastLine ;
      private short Z95CustomerLastLineLocation ;
      private short Z78CustomerTypeId ;
      private short O95CustomerLastLineLocation ;
      private short O93CustomerLastLine ;
      private short N78CustomerTypeId ;
      private short Z15CustomerManagerId ;
      private short nRcdDeleted_2 ;
      private short nRcdExists_2 ;
      private short nIsMod_2 ;
      private short Z18CustomerLocationId ;
      private short Z94CustomerLocationLastLine ;
      private short O94CustomerLocationLastLine ;
      private short nRcdDeleted_3 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short Z23CustomerLocationReceptionistId ;
      private short nRcdDeleted_4 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short Z55Supplier_AgbId ;
      private short nRcdDeleted_16 ;
      private short nRcdExists_16 ;
      private short nIsMod_16 ;
      private short Z64Supplier_GenId ;
      private short nRcdDeleted_17 ;
      private short nRcdExists_17 ;
      private short nIsMod_17 ;
      private short Z98AmenitiesId ;
      private short nRcdDeleted_21 ;
      private short nRcdExists_21 ;
      private short nIsMod_21 ;
      private short GxWebError ;
      private short A78CustomerTypeId ;
      private short A55Supplier_AgbId ;
      private short A64Supplier_GenId ;
      private short A98AmenitiesId ;
      private short A99AmenitiesTypeId ;
      private short AV7CustomerId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A93CustomerLastLine ;
      private short Gx_BScreen ;
      private short A94CustomerLocationLastLine ;
      private short A95CustomerLastLineLocation ;
      private short A1CustomerId ;
      private short AV27ComboCustomerTypeId ;
      private short nBlankRcdCount2 ;
      private short RcdFound2 ;
      private short B95CustomerLastLineLocation ;
      private short B93CustomerLastLine ;
      private short nBlankRcdUsr2 ;
      private short nBlankRcdCount3 ;
      private short RcdFound3 ;
      private short nBlankRcdUsr3 ;
      private short AV13Insert_CustomerTypeId ;
      private short RcdFound1 ;
      private short A15CustomerManagerId ;
      private short AV17TabsActivePage ;
      private short RcdFound21 ;
      private short RcdFound17 ;
      private short RcdFound16 ;
      private short s94CustomerLocationLastLine ;
      private short RcdFound4 ;
      private short A23CustomerLocationReceptionistId ;
      private short s95CustomerLastLineLocation ;
      private short A18CustomerLocationId ;
      private short T94CustomerLocationLastLine ;
      private short s93CustomerLastLine ;
      private short nIsDirty_2 ;
      private short nIsDirty_3 ;
      private short nIsDirty_4 ;
      private short nIsDirty_16 ;
      private short nIsDirty_17 ;
      private short Z99AmenitiesTypeId ;
      private short nIsDirty_21 ;
      private short subGridlevel_manager_Backcolorstyle ;
      private short subGridlevel_manager_Backstyle ;
      private short subFreestylelevel_locations_Backcolorstyle ;
      private short subFreestylelevel_locations_Backstyle ;
      private short nBlankRcdCount4 ;
      private short B94CustomerLocationLastLine ;
      private short nBlankRcdUsr4 ;
      private short nBlankRcdCount16 ;
      private short nBlankRcdUsr16 ;
      private short nBlankRcdCount17 ;
      private short nBlankRcdUsr17 ;
      private short nBlankRcdCount21 ;
      private short nBlankRcdUsr21 ;
      private short subGridlevel_receptionist_Backcolorstyle ;
      private short subGridlevel_receptionist_Backstyle ;
      private short subGridlevel_supplier_agb_Backcolorstyle ;
      private short subGridlevel_supplier_agb_Backstyle ;
      private short subGridlevel_supplier_gen_Backcolorstyle ;
      private short subGridlevel_supplier_gen_Backstyle ;
      private short subGridlevel_amenities_Backcolorstyle ;
      private short subGridlevel_amenities_Backstyle ;
      private short gxajaxcallmode ;
      private short i93CustomerLastLine ;
      private short i95CustomerLastLineLocation ;
      private short i94CustomerLocationLastLine ;
      private short subGridlevel_manager_Allowselection ;
      private short subGridlevel_manager_Allowhovering ;
      private short subGridlevel_manager_Allowcollapsing ;
      private short subGridlevel_manager_Collapsed ;
      private short subFreestylelevel_locations_Allowselection ;
      private short subFreestylelevel_locations_Allowhovering ;
      private short subFreestylelevel_locations_Allowcollapsing ;
      private short subFreestylelevel_locations_Collapsed ;
      private short subGridlevel_receptionist_Allowselection ;
      private short subGridlevel_receptionist_Allowhovering ;
      private short subGridlevel_receptionist_Allowcollapsing ;
      private short subGridlevel_receptionist_Collapsed ;
      private short subGridlevel_supplier_agb_Allowselection ;
      private short subGridlevel_supplier_agb_Allowhovering ;
      private short subGridlevel_supplier_agb_Allowcollapsing ;
      private short subGridlevel_supplier_agb_Collapsed ;
      private short subGridlevel_supplier_gen_Allowselection ;
      private short subGridlevel_supplier_gen_Allowhovering ;
      private short subGridlevel_supplier_gen_Allowcollapsing ;
      private short subGridlevel_supplier_gen_Collapsed ;
      private short subGridlevel_amenities_Allowselection ;
      private short subGridlevel_amenities_Allowhovering ;
      private short subGridlevel_amenities_Allowcollapsing ;
      private short subGridlevel_amenities_Collapsed ;
      private int nRC_GXsfl_78 ;
      private int nGXsfl_78_idx=1 ;
      private int nRC_GXsfl_97 ;
      private int nGXsfl_97_idx=1 ;
      private int Gxuitabspanel_steps_Activepage ;
      private int nRC_GXsfl_129 ;
      private int nGXsfl_129_idx=1 ;
      private int nRC_GXsfl_143 ;
      private int nGXsfl_143_idx=1 ;
      private int nRC_GXsfl_156 ;
      private int nGXsfl_156_idx=1 ;
      private int nRC_GXsfl_168 ;
      private int nGXsfl_168_idx=1 ;
      private int trnEnded ;
      private int Gxuitabspanel_steps_Pagecount ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerKvkNumber_Enabled ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerPostalAddress_Enabled ;
      private int edtCustomerEmail_Enabled ;
      private int edtCustomerVisitingAddress_Enabled ;
      private int edtCustomerPhone_Enabled ;
      private int edtCustomerVatNumber_Enabled ;
      private int edtCustomerTypeId_Visible ;
      private int edtCustomerTypeId_Enabled ;
      private int bttBtnwizardprevious_Visible ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtnwizardnext_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombocustomertypeid_Enabled ;
      private int edtavCombocustomertypeid_Visible ;
      private int edtCustomerLastLine_Enabled ;
      private int edtCustomerLastLine_Visible ;
      private int edtCustomerManagerId_Enabled ;
      private int edtCustomerManagerGivenName_Enabled ;
      private int edtCustomerManagerLastName_Enabled ;
      private int edtCustomerManagerInitials_Enabled ;
      private int edtCustomerManagerEmail_Enabled ;
      private int edtCustomerManagerPhone_Enabled ;
      private int edtCustomerManagerGAMGUID_Enabled ;
      private int fRowAdded ;
      private int edtCustomerLocationId_Enabled ;
      private int edtCustomerLocationVisitingAddres_Enabled ;
      private int edtCustomerLocationPostalAddress_Enabled ;
      private int edtCustomerLocationEmail_Enabled ;
      private int edtCustomerLocationPhone_Enabled ;
      private int Combo_customertypeid_Datalistupdateminimumcharacters ;
      private int Combo_customertypeid_Gxcontroltype ;
      private int Combo_supplier_agbid_Datalistupdateminimumcharacters ;
      private int Combo_supplier_agbid_Gxcontroltype ;
      private int Combo_supplier_genid_Datalistupdateminimumcharacters ;
      private int Combo_supplier_genid_Gxcontroltype ;
      private int Combo_amenitiesid_Datalistupdateminimumcharacters ;
      private int Combo_amenitiesid_Gxcontroltype ;
      private int edtAmenitiesId_Enabled ;
      private int edtAmenitiesTypeId_Enabled ;
      private int edtAmenitiesTypeName_Enabled ;
      private int edtSupplier_GenId_Enabled ;
      private int edtSupplier_GenCompanyName_Enabled ;
      private int edtSupplier_GenVisitingAddress_Enabled ;
      private int edtSupplier_GenPostalAddress_Enabled ;
      private int edtSupplier_GenContactName_Enabled ;
      private int edtSupplier_GenContactPhone_Enabled ;
      private int edtSupplier_AgbId_Enabled ;
      private int edtSupplier_AgbName_Enabled ;
      private int edtSupplier_AgbKvkNumber_Enabled ;
      private int edtSupplier_AgbVisitingAddress_Enabled ;
      private int edtSupplier_AgbPostalAddress_Enabled ;
      private int edtSupplier_AgbEmail_Enabled ;
      private int edtSupplier_AgbPhone_Enabled ;
      private int edtSupplier_AgbContactName_Enabled ;
      private int edtCustomerLocationReceptionistId_Enabled ;
      private int edtCustomerLocationReceptionistGi_Enabled ;
      private int edtCustomerLocationReceptionistLa_Enabled ;
      private int edtCustomerLocationReceptionistIn_Enabled ;
      private int edtCustomerLocationReceptionistEm_Enabled ;
      private int edtCustomerLocationReceptionistAd_Enabled ;
      private int edtCustomerLocationReceptionistPh_Enabled ;
      private int edtCustomerLocationReceptionistGA_Enabled ;
      private int AV31GXV1 ;
      private int subGridlevel_manager_Backcolor ;
      private int subGridlevel_manager_Allbackcolor ;
      private int subFreestylelevel_locations_Backcolor ;
      private int subFreestylelevel_locations_Allbackcolor ;
      private int FREESTYLELEVEL_LOCATIONS_IsPaging ;
      private int subGridlevel_receptionist_Backcolor ;
      private int subGridlevel_receptionist_Allbackcolor ;
      private int subGridlevel_supplier_agb_Backcolor ;
      private int subGridlevel_supplier_agb_Allbackcolor ;
      private int subGridlevel_supplier_gen_Backcolor ;
      private int subGridlevel_supplier_gen_Allbackcolor ;
      private int subGridlevel_amenities_Backcolor ;
      private int subGridlevel_amenities_Allbackcolor ;
      private int defedtCustomerLocationReceptionistGA_Enabled ;
      private int defedtCustomerLocationReceptionistId_Enabled ;
      private int defedtSupplier_AgbId_Enabled ;
      private int defedtSupplier_GenId_Enabled ;
      private int defedtAmenitiesId_Enabled ;
      private int defedtCustomerLocationId_Enabled ;
      private int defedtCustomerManagerId_Enabled ;
      private int idxLst ;
      private int subGridlevel_manager_Selectedindex ;
      private int subGridlevel_manager_Selectioncolor ;
      private int subGridlevel_manager_Hoveringcolor ;
      private int subFreestylelevel_locations_Selectedindex ;
      private int subFreestylelevel_locations_Selectioncolor ;
      private int subFreestylelevel_locations_Hoveringcolor ;
      private int subGridlevel_receptionist_Selectedindex ;
      private int subGridlevel_receptionist_Selectioncolor ;
      private int subGridlevel_receptionist_Hoveringcolor ;
      private int subGridlevel_supplier_agb_Selectedindex ;
      private int subGridlevel_supplier_agb_Selectioncolor ;
      private int subGridlevel_supplier_agb_Hoveringcolor ;
      private int subGridlevel_supplier_gen_Selectedindex ;
      private int subGridlevel_supplier_gen_Selectioncolor ;
      private int subGridlevel_supplier_gen_Hoveringcolor ;
      private int subGridlevel_amenities_Selectedindex ;
      private int subGridlevel_amenities_Selectioncolor ;
      private int subGridlevel_amenities_Hoveringcolor ;
      private long GRIDLEVEL_MANAGER_nFirstRecordOnPage ;
      private long FREESTYLELEVEL_LOCATIONS_nFirstRecordOnPage ;
      private long GRIDLEVEL_RECEPTIONIST_nFirstRecordOnPage ;
      private long GRIDLEVEL_SUPPLIER_AGB_nFirstRecordOnPage ;
      private long GRIDLEVEL_SUPPLIER_GEN_nFirstRecordOnPage ;
      private long GRIDLEVEL_AMENITIES_nFirstRecordOnPage ;
      private long GRIDLEVEL_RECEPTIONIST_nCurrentRecord ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z7CustomerPhone ;
      private string Combo_customertypeid_Selectedvalue_get ;
      private string Z17CustomerManagerInitials ;
      private string Z11CustomerManagerPhone ;
      private string Z12CustomerManagerGender ;
      private string Z22CustomerLocationPhone ;
      private string Z26CustomerLocationReceptionistIn ;
      private string Z29CustomerLocationReceptionistPh ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCustomerKvkNumber_Internalname ;
      private string sGXsfl_78_idx="0001" ;
      private string sGXsfl_129_idx="0001" ;
      private string sGXsfl_143_idx="0001" ;
      private string edtSupplier_AgbId_Horizontalalignment ;
      private string edtSupplier_AgbId_Internalname ;
      private string sGXsfl_156_idx="0001" ;
      private string edtSupplier_GenId_Horizontalalignment ;
      private string edtSupplier_GenId_Internalname ;
      private string sGXsfl_168_idx="0001" ;
      private string edtAmenitiesId_Horizontalalignment ;
      private string edtAmenitiesId_Internalname ;
      private string sGXsfl_97_idx="0001" ;
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
      private string edtCustomerId_Internalname ;
      private string TempTags ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerKvkNumber_Jsonclick ;
      private string edtCustomerName_Internalname ;
      private string edtCustomerName_Jsonclick ;
      private string edtCustomerPostalAddress_Internalname ;
      private string edtCustomerEmail_Internalname ;
      private string edtCustomerEmail_Jsonclick ;
      private string edtCustomerVisitingAddress_Internalname ;
      private string edtCustomerPhone_Internalname ;
      private string gxphoneLink ;
      private string A7CustomerPhone ;
      private string edtCustomerPhone_Jsonclick ;
      private string edtCustomerVatNumber_Internalname ;
      private string edtCustomerVatNumber_Jsonclick ;
      private string divTablesplittedcustomertypeid_Internalname ;
      private string lblTextblockcustomertypeid_Internalname ;
      private string lblTextblockcustomertypeid_Jsonclick ;
      private string Combo_customertypeid_Caption ;
      private string Combo_customertypeid_Cls ;
      private string Combo_customertypeid_Datalistproc ;
      private string Combo_customertypeid_Datalistprocparametersprefix ;
      private string Combo_customertypeid_Internalname ;
      private string edtCustomerTypeId_Internalname ;
      private string edtCustomerTypeId_Jsonclick ;
      private string lblTablevel_manager_title_Internalname ;
      private string lblTablevel_manager_title_Jsonclick ;
      private string divTabtablelevel_manager_Internalname ;
      private string divTableleaflevel_manager_Internalname ;
      private string lblTablevel_locations_title_Internalname ;
      private string lblTablevel_locations_title_Jsonclick ;
      private string divTabtablelevel_locations_Internalname ;
      private string divTableintermediatelevel_locations_Internalname ;
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
      private string divSectionattribute_customertypeid_Internalname ;
      private string edtavCombocustomertypeid_Internalname ;
      private string edtavCombocustomertypeid_Jsonclick ;
      private string Combo_supplier_agbid_Caption ;
      private string Combo_supplier_agbid_Cls ;
      private string Combo_supplier_agbid_Datalistproc ;
      private string Combo_supplier_agbid_Datalistprocparametersprefix ;
      private string Combo_supplier_agbid_Internalname ;
      private string Combo_supplier_genid_Caption ;
      private string Combo_supplier_genid_Cls ;
      private string Combo_supplier_genid_Datalistproc ;
      private string Combo_supplier_genid_Datalistprocparametersprefix ;
      private string Combo_supplier_genid_Internalname ;
      private string Combo_amenitiesid_Caption ;
      private string Combo_amenitiesid_Cls ;
      private string Combo_amenitiesid_Datalistproc ;
      private string Combo_amenitiesid_Datalistprocparametersprefix ;
      private string Combo_amenitiesid_Internalname ;
      private string edtCustomerLastLine_Internalname ;
      private string edtCustomerLastLine_Jsonclick ;
      private string Wizard_steps_Internalname ;
      private string sMode2 ;
      private string edtCustomerManagerId_Internalname ;
      private string edtCustomerManagerGivenName_Internalname ;
      private string edtCustomerManagerLastName_Internalname ;
      private string edtCustomerManagerInitials_Internalname ;
      private string edtCustomerManagerEmail_Internalname ;
      private string edtCustomerManagerPhone_Internalname ;
      private string cmbCustomerManagerGender_Internalname ;
      private string edtCustomerManagerGAMGUID_Internalname ;
      private string sStyleString ;
      private string subGridlevel_manager_Internalname ;
      private string sMode3 ;
      private string edtCustomerLocationId_Internalname ;
      private string edtCustomerLocationVisitingAddres_Internalname ;
      private string edtCustomerLocationPostalAddress_Internalname ;
      private string edtCustomerLocationEmail_Internalname ;
      private string edtCustomerLocationPhone_Internalname ;
      private string subFreestylelevel_locations_Internalname ;
      private string AV30Pgmname ;
      private string Combo_customertypeid_Objectcall ;
      private string Combo_customertypeid_Class ;
      private string Combo_customertypeid_Icontype ;
      private string Combo_customertypeid_Icon ;
      private string Combo_customertypeid_Tooltip ;
      private string Combo_customertypeid_Selectedvalue_set ;
      private string Combo_customertypeid_Selectedtext_set ;
      private string Combo_customertypeid_Selectedtext_get ;
      private string Combo_customertypeid_Gamoauthtoken ;
      private string Combo_customertypeid_Ddointernalname ;
      private string Combo_customertypeid_Titlecontrolalign ;
      private string Combo_customertypeid_Dropdownoptionstype ;
      private string Combo_customertypeid_Titlecontrolidtoreplace ;
      private string Combo_customertypeid_Datalisttype ;
      private string Combo_customertypeid_Datalistfixedvalues ;
      private string Combo_customertypeid_Remoteservicesparameters ;
      private string Combo_customertypeid_Htmltemplate ;
      private string Combo_customertypeid_Multiplevaluestype ;
      private string Combo_customertypeid_Loadingdata ;
      private string Combo_customertypeid_Noresultsfound ;
      private string Combo_customertypeid_Emptyitemtext ;
      private string Combo_customertypeid_Onlyselectedvalues ;
      private string Combo_customertypeid_Selectalltext ;
      private string Combo_customertypeid_Multiplevaluesseparator ;
      private string Combo_customertypeid_Addnewoptiontext ;
      private string Gxuitabspanel_steps_Objectcall ;
      private string Gxuitabspanel_steps_Activepagecontrolname ;
      private string Combo_supplier_agbid_Objectcall ;
      private string Combo_supplier_agbid_Class ;
      private string Combo_supplier_agbid_Icontype ;
      private string Combo_supplier_agbid_Icon ;
      private string Combo_supplier_agbid_Tooltip ;
      private string Combo_supplier_agbid_Selectedvalue_set ;
      private string Combo_supplier_agbid_Selectedvalue_get ;
      private string Combo_supplier_agbid_Selectedtext_set ;
      private string Combo_supplier_agbid_Selectedtext_get ;
      private string Combo_supplier_agbid_Gamoauthtoken ;
      private string Combo_supplier_agbid_Ddointernalname ;
      private string Combo_supplier_agbid_Titlecontrolalign ;
      private string Combo_supplier_agbid_Dropdownoptionstype ;
      private string Combo_supplier_agbid_Titlecontrolidtoreplace ;
      private string Combo_supplier_agbid_Datalisttype ;
      private string Combo_supplier_agbid_Datalistfixedvalues ;
      private string Combo_supplier_agbid_Remoteservicesparameters ;
      private string Combo_supplier_agbid_Htmltemplate ;
      private string Combo_supplier_agbid_Multiplevaluestype ;
      private string Combo_supplier_agbid_Loadingdata ;
      private string Combo_supplier_agbid_Noresultsfound ;
      private string Combo_supplier_agbid_Emptyitemtext ;
      private string Combo_supplier_agbid_Onlyselectedvalues ;
      private string Combo_supplier_agbid_Selectalltext ;
      private string Combo_supplier_agbid_Multiplevaluesseparator ;
      private string Combo_supplier_agbid_Addnewoptiontext ;
      private string Combo_supplier_genid_Objectcall ;
      private string Combo_supplier_genid_Class ;
      private string Combo_supplier_genid_Icontype ;
      private string Combo_supplier_genid_Icon ;
      private string Combo_supplier_genid_Tooltip ;
      private string Combo_supplier_genid_Selectedvalue_set ;
      private string Combo_supplier_genid_Selectedvalue_get ;
      private string Combo_supplier_genid_Selectedtext_set ;
      private string Combo_supplier_genid_Selectedtext_get ;
      private string Combo_supplier_genid_Gamoauthtoken ;
      private string Combo_supplier_genid_Ddointernalname ;
      private string Combo_supplier_genid_Titlecontrolalign ;
      private string Combo_supplier_genid_Dropdownoptionstype ;
      private string Combo_supplier_genid_Titlecontrolidtoreplace ;
      private string Combo_supplier_genid_Datalisttype ;
      private string Combo_supplier_genid_Datalistfixedvalues ;
      private string Combo_supplier_genid_Remoteservicesparameters ;
      private string Combo_supplier_genid_Htmltemplate ;
      private string Combo_supplier_genid_Multiplevaluestype ;
      private string Combo_supplier_genid_Loadingdata ;
      private string Combo_supplier_genid_Noresultsfound ;
      private string Combo_supplier_genid_Emptyitemtext ;
      private string Combo_supplier_genid_Onlyselectedvalues ;
      private string Combo_supplier_genid_Selectalltext ;
      private string Combo_supplier_genid_Multiplevaluesseparator ;
      private string Combo_supplier_genid_Addnewoptiontext ;
      private string Combo_amenitiesid_Objectcall ;
      private string Combo_amenitiesid_Class ;
      private string Combo_amenitiesid_Icontype ;
      private string Combo_amenitiesid_Icon ;
      private string Combo_amenitiesid_Tooltip ;
      private string Combo_amenitiesid_Selectedvalue_set ;
      private string Combo_amenitiesid_Selectedvalue_get ;
      private string Combo_amenitiesid_Selectedtext_set ;
      private string Combo_amenitiesid_Selectedtext_get ;
      private string Combo_amenitiesid_Gamoauthtoken ;
      private string Combo_amenitiesid_Ddointernalname ;
      private string Combo_amenitiesid_Titlecontrolalign ;
      private string Combo_amenitiesid_Dropdownoptionstype ;
      private string Combo_amenitiesid_Titlecontrolidtoreplace ;
      private string Combo_amenitiesid_Datalisttype ;
      private string Combo_amenitiesid_Datalistfixedvalues ;
      private string Combo_amenitiesid_Remoteservicesparameters ;
      private string Combo_amenitiesid_Htmltemplate ;
      private string Combo_amenitiesid_Multiplevaluestype ;
      private string Combo_amenitiesid_Loadingdata ;
      private string Combo_amenitiesid_Noresultsfound ;
      private string Combo_amenitiesid_Emptyitemtext ;
      private string Combo_amenitiesid_Onlyselectedvalues ;
      private string Combo_amenitiesid_Selectalltext ;
      private string Combo_amenitiesid_Multiplevaluesseparator ;
      private string Combo_amenitiesid_Addnewoptiontext ;
      private string Wizard_steps_Objectcall ;
      private string Wizard_steps_Class ;
      private string Wizard_steps_Tabsinternalname ;
      private string Wizard_steps_Allowsteptitleclick ;
      private string Wizard_steps_Transformtype ;
      private string Wizard_steps_Wizardarrowselectedunselectedimage ;
      private string Wizard_steps_Wizardarrowunselectedselectedimage ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXCCtl ;
      private string A17CustomerManagerInitials ;
      private string A11CustomerManagerPhone ;
      private string A12CustomerManagerGender ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string edtAmenitiesTypeId_Internalname ;
      private string edtAmenitiesTypeName_Internalname ;
      private string edtSupplier_GenCompanyName_Internalname ;
      private string edtSupplier_GenVisitingAddress_Internalname ;
      private string edtSupplier_GenPostalAddress_Internalname ;
      private string edtSupplier_GenContactName_Internalname ;
      private string edtSupplier_GenContactPhone_Internalname ;
      private string A70Supplier_GenContactPhone ;
      private string edtSupplier_AgbName_Internalname ;
      private string edtSupplier_AgbKvkNumber_Internalname ;
      private string edtSupplier_AgbVisitingAddress_Internalname ;
      private string edtSupplier_AgbPostalAddress_Internalname ;
      private string edtSupplier_AgbEmail_Internalname ;
      private string edtSupplier_AgbPhone_Internalname ;
      private string A62Supplier_AgbPhone ;
      private string edtSupplier_AgbContactName_Internalname ;
      private string edtCustomerLocationReceptionistId_Internalname ;
      private string edtCustomerLocationReceptionistGi_Internalname ;
      private string edtCustomerLocationReceptionistLa_Internalname ;
      private string edtCustomerLocationReceptionistIn_Internalname ;
      private string A26CustomerLocationReceptionistIn ;
      private string edtCustomerLocationReceptionistEm_Internalname ;
      private string edtCustomerLocationReceptionistAd_Internalname ;
      private string edtCustomerLocationReceptionistPh_Internalname ;
      private string A29CustomerLocationReceptionistPh ;
      private string edtCustomerLocationReceptionistGA_Internalname ;
      private string A22CustomerLocationPhone ;
      private string GXt_char2 ;
      private string sMode4 ;
      private string Z62Supplier_AgbPhone ;
      private string sMode16 ;
      private string Z70Supplier_GenContactPhone ;
      private string sMode17 ;
      private string sMode21 ;
      private string sGXsfl_78_fel_idx="0001" ;
      private string subGridlevel_manager_Class ;
      private string subGridlevel_manager_Linesclass ;
      private string ROClassString ;
      private string edtCustomerManagerId_Jsonclick ;
      private string edtCustomerManagerGivenName_Jsonclick ;
      private string edtCustomerManagerLastName_Jsonclick ;
      private string edtCustomerManagerInitials_Jsonclick ;
      private string edtCustomerManagerEmail_Jsonclick ;
      private string edtCustomerManagerPhone_Jsonclick ;
      private string cmbCustomerManagerGender_Jsonclick ;
      private string edtCustomerManagerGAMGUID_Jsonclick ;
      private string subGridlevel_receptionist_Internalname ;
      private string subGridlevel_supplier_agb_Internalname ;
      private string subGridlevel_supplier_gen_Internalname ;
      private string subGridlevel_amenities_Internalname ;
      private string sGXsfl_97_fel_idx="0001" ;
      private string subFreestylelevel_locations_Class ;
      private string subFreestylelevel_locations_Linesclass ;
      private string tblUnnamedtablefsfreestylelevel_locations_Internalname ;
      private string divTableintermediateinslevel_locations_Internalname ;
      private string edtCustomerLocationId_Jsonclick ;
      private string edtCustomerLocationPostalAddress_Jsonclick ;
      private string edtCustomerLocationEmail_Jsonclick ;
      private string edtCustomerLocationPhone_Jsonclick ;
      private string divTableleaflevel_receptionist_Internalname ;
      private string divTableleaflevel_supplier_agb_Internalname ;
      private string divTableleaflevel_supplier_gen_Internalname ;
      private string divTableleaflevel_amenities_Internalname ;
      private string sGXsfl_129_fel_idx="0001" ;
      private string subGridlevel_receptionist_Class ;
      private string subGridlevel_receptionist_Linesclass ;
      private string edtCustomerLocationReceptionistId_Jsonclick ;
      private string edtCustomerLocationReceptionistGi_Jsonclick ;
      private string edtCustomerLocationReceptionistLa_Jsonclick ;
      private string edtCustomerLocationReceptionistIn_Jsonclick ;
      private string edtCustomerLocationReceptionistEm_Jsonclick ;
      private string edtCustomerLocationReceptionistAd_Jsonclick ;
      private string edtCustomerLocationReceptionistPh_Jsonclick ;
      private string edtCustomerLocationReceptionistGA_Jsonclick ;
      private string sGXsfl_143_fel_idx="0001" ;
      private string subGridlevel_supplier_agb_Class ;
      private string subGridlevel_supplier_agb_Linesclass ;
      private string edtSupplier_AgbId_Jsonclick ;
      private string edtSupplier_AgbName_Jsonclick ;
      private string edtSupplier_AgbKvkNumber_Jsonclick ;
      private string edtSupplier_AgbVisitingAddress_Jsonclick ;
      private string edtSupplier_AgbPostalAddress_Jsonclick ;
      private string edtSupplier_AgbEmail_Jsonclick ;
      private string edtSupplier_AgbPhone_Jsonclick ;
      private string edtSupplier_AgbContactName_Jsonclick ;
      private string sGXsfl_156_fel_idx="0001" ;
      private string subGridlevel_supplier_gen_Class ;
      private string subGridlevel_supplier_gen_Linesclass ;
      private string edtSupplier_GenId_Jsonclick ;
      private string edtSupplier_GenCompanyName_Jsonclick ;
      private string edtSupplier_GenVisitingAddress_Jsonclick ;
      private string edtSupplier_GenPostalAddress_Jsonclick ;
      private string edtSupplier_GenContactName_Jsonclick ;
      private string edtSupplier_GenContactPhone_Jsonclick ;
      private string sGXsfl_168_fel_idx="0001" ;
      private string subGridlevel_amenities_Class ;
      private string subGridlevel_amenities_Linesclass ;
      private string edtAmenitiesId_Jsonclick ;
      private string edtAmenitiesTypeId_Jsonclick ;
      private string edtAmenitiesTypeName_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_manager_Header ;
      private string subFreestylelevel_locations_Header ;
      private string subGridlevel_receptionist_Header ;
      private string subGridlevel_supplier_agb_Header ;
      private string subGridlevel_supplier_gen_Header ;
      private string subGridlevel_amenities_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n78CustomerTypeId ;
      private bool wbErr ;
      private bool bGXsfl_143_Refreshing=false ;
      private bool bGXsfl_156_Refreshing=false ;
      private bool bGXsfl_168_Refreshing=false ;
      private bool Gxuitabspanel_steps_Historymanagement ;
      private bool Combo_supplier_agbid_Isgriditem ;
      private bool Combo_supplier_agbid_Hasdescription ;
      private bool Combo_supplier_agbid_Emptyitem ;
      private bool Combo_supplier_genid_Isgriditem ;
      private bool Combo_supplier_genid_Hasdescription ;
      private bool Combo_supplier_genid_Emptyitem ;
      private bool Combo_amenitiesid_Isgriditem ;
      private bool Combo_amenitiesid_Hasdescription ;
      private bool Combo_amenitiesid_Emptyitem ;
      private bool bGXsfl_78_Refreshing=false ;
      private bool bGXsfl_97_Refreshing=false ;
      private bool n4CustomerPostalAddress ;
      private bool n5CustomerEmail ;
      private bool n6CustomerVisitingAddress ;
      private bool n7CustomerPhone ;
      private bool Combo_customertypeid_Enabled ;
      private bool Combo_customertypeid_Visible ;
      private bool Combo_customertypeid_Allowmultipleselection ;
      private bool Combo_customertypeid_Isgriditem ;
      private bool Combo_customertypeid_Hasdescription ;
      private bool Combo_customertypeid_Includeonlyselectedoption ;
      private bool Combo_customertypeid_Includeselectalloption ;
      private bool Combo_customertypeid_Emptyitem ;
      private bool Combo_customertypeid_Includeaddnewoption ;
      private bool Gxuitabspanel_steps_Enabled ;
      private bool Gxuitabspanel_steps_Visible ;
      private bool Combo_supplier_agbid_Enabled ;
      private bool Combo_supplier_agbid_Visible ;
      private bool Combo_supplier_agbid_Allowmultipleselection ;
      private bool Combo_supplier_agbid_Includeonlyselectedoption ;
      private bool Combo_supplier_agbid_Includeselectalloption ;
      private bool Combo_supplier_agbid_Includeaddnewoption ;
      private bool Combo_supplier_genid_Enabled ;
      private bool Combo_supplier_genid_Visible ;
      private bool Combo_supplier_genid_Allowmultipleselection ;
      private bool Combo_supplier_genid_Includeonlyselectedoption ;
      private bool Combo_supplier_genid_Includeselectalloption ;
      private bool Combo_supplier_genid_Includeaddnewoption ;
      private bool Combo_amenitiesid_Enabled ;
      private bool Combo_amenitiesid_Visible ;
      private bool Combo_amenitiesid_Allowmultipleselection ;
      private bool Combo_amenitiesid_Includeonlyselectedoption ;
      private bool Combo_amenitiesid_Includeselectalloption ;
      private bool Combo_amenitiesid_Includeaddnewoption ;
      private bool Wizard_steps_Enabled ;
      private bool Wizard_steps_Visible ;
      private bool n17CustomerManagerInitials ;
      private bool n11CustomerManagerPhone ;
      private bool n12CustomerManagerGender ;
      private bool AV15CheckRequiredFieldsResult ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool bGXsfl_129_Refreshing=false ;
      private bool n26CustomerLocationReceptionistIn ;
      private bool n28CustomerLocationReceptionistAd ;
      private bool n59Supplier_AgbVisitingAddress ;
      private bool n60Supplier_AgbPostalAddress ;
      private bool n61Supplier_AgbEmail ;
      private bool n62Supplier_AgbPhone ;
      private bool n63Supplier_AgbContactName ;
      private bool n67Supplier_GenVisitingAddress ;
      private bool n68Supplier_GenPostalAddress ;
      private bool n69Supplier_GenContactName ;
      private bool n70Supplier_GenContactPhone ;
      private string AV22Combo_DataJson ;
      private string Z41CustomerKvkNumber ;
      private string Z3CustomerName ;
      private string Z4CustomerPostalAddress ;
      private string Z5CustomerEmail ;
      private string Z6CustomerVisitingAddress ;
      private string Z14CustomerVatNumber ;
      private string Z13CustomerManagerGAMGUID ;
      private string Z16CustomerManagerGivenName ;
      private string Z9CustomerManagerLastName ;
      private string Z10CustomerManagerEmail ;
      private string Z19CustomerLocationVisitingAddres ;
      private string Z20CustomerLocationPostalAddress ;
      private string Z21CustomerLocationEmail ;
      private string Z133CustomerLocationDescription ;
      private string Z134CustomerLocationName ;
      private string Z30CustomerLocationReceptionistGA ;
      private string Z24CustomerLocationReceptionistGi ;
      private string Z25CustomerLocationReceptionistLa ;
      private string Z27CustomerLocationReceptionistEm ;
      private string Z28CustomerLocationReceptionistAd ;
      private string A16CustomerManagerGivenName ;
      private string A9CustomerManagerLastName ;
      private string A24CustomerLocationReceptionistGi ;
      private string A25CustomerLocationReceptionistLa ;
      private string A41CustomerKvkNumber ;
      private string A3CustomerName ;
      private string A4CustomerPostalAddress ;
      private string A5CustomerEmail ;
      private string A6CustomerVisitingAddress ;
      private string A14CustomerVatNumber ;
      private string A79CustomerTypeName ;
      private string A133CustomerLocationDescription ;
      private string A134CustomerLocationName ;
      private string A10CustomerManagerEmail ;
      private string A13CustomerManagerGAMGUID ;
      private string A100AmenitiesTypeName ;
      private string A66Supplier_GenCompanyName ;
      private string A67Supplier_GenVisitingAddress ;
      private string A68Supplier_GenPostalAddress ;
      private string A69Supplier_GenContactName ;
      private string A57Supplier_AgbName ;
      private string A58Supplier_AgbKvkNumber ;
      private string A59Supplier_AgbVisitingAddress ;
      private string A60Supplier_AgbPostalAddress ;
      private string A61Supplier_AgbEmail ;
      private string A63Supplier_AgbContactName ;
      private string A27CustomerLocationReceptionistEm ;
      private string A28CustomerLocationReceptionistAd ;
      private string A30CustomerLocationReceptionistGA ;
      private string A19CustomerLocationVisitingAddres ;
      private string A20CustomerLocationPostalAddress ;
      private string A21CustomerLocationEmail ;
      private string AV20ComboSelectedValue ;
      private string AV21ComboSelectedText ;
      private string Z79CustomerTypeName ;
      private string Z56Supplier_AgbNumber ;
      private string A56Supplier_AgbNumber ;
      private string Z57Supplier_AgbName ;
      private string Z58Supplier_AgbKvkNumber ;
      private string Z59Supplier_AgbVisitingAddress ;
      private string Z60Supplier_AgbPostalAddress ;
      private string Z61Supplier_AgbEmail ;
      private string Z63Supplier_AgbContactName ;
      private string Z65Supplier_GenKvKNumber ;
      private string A65Supplier_GenKvKNumber ;
      private string Z66Supplier_GenCompanyName ;
      private string Z67Supplier_GenVisitingAddress ;
      private string Z68Supplier_GenPostalAddress ;
      private string Z69Supplier_GenContactName ;
      private string Z101AmenitiesName ;
      private string A101AmenitiesName ;
      private string Z100AmenitiesTypeName ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_managerContainer ;
      private GXWebGrid Freestylelevel_locationsContainer ;
      private GXWebGrid Gridlevel_receptionistContainer ;
      private GXWebGrid Gridlevel_supplier_agbContainer ;
      private GXWebGrid Gridlevel_supplier_genContainer ;
      private GXWebGrid Gridlevel_amenitiesContainer ;
      private GXWebRow Gridlevel_managerRow ;
      private GXWebRow Freestylelevel_locationsRow ;
      private GXWebRow Gridlevel_receptionistRow ;
      private GXWebRow Gridlevel_supplier_agbRow ;
      private GXWebRow Gridlevel_supplier_genRow ;
      private GXWebRow Gridlevel_amenitiesRow ;
      private GXWebColumn Gridlevel_managerColumn ;
      private GXWebColumn Freestylelevel_locationsColumn ;
      private GXWebColumn Gridlevel_receptionistColumn ;
      private GXWebColumn Gridlevel_supplier_agbColumn ;
      private GXWebColumn Gridlevel_supplier_genColumn ;
      private GXWebColumn Gridlevel_amenitiesColumn ;
      private GXUserControl ucGxuitabspanel_steps ;
      private GXUserControl ucCombo_customertypeid ;
      private GXUserControl ucCombo_supplier_agbid ;
      private GXUserControl ucCombo_supplier_genid ;
      private GXUserControl ucCombo_amenitiesid ;
      private GXUserControl ucWizard_steps ;
      private GxHttpRequest AV16HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCustomerManagerGender ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV26CustomerTypeId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25Supplier_AgbId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18Supplier_GenId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV28AmenitiesId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV23GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV24GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000120_A79CustomerTypeName ;
      private short[] T000121_A1CustomerId ;
      private string[] T000121_A41CustomerKvkNumber ;
      private string[] T000121_A3CustomerName ;
      private string[] T000121_A4CustomerPostalAddress ;
      private bool[] T000121_n4CustomerPostalAddress ;
      private string[] T000121_A5CustomerEmail ;
      private bool[] T000121_n5CustomerEmail ;
      private string[] T000121_A6CustomerVisitingAddress ;
      private bool[] T000121_n6CustomerVisitingAddress ;
      private string[] T000121_A7CustomerPhone ;
      private bool[] T000121_n7CustomerPhone ;
      private string[] T000121_A14CustomerVatNumber ;
      private string[] T000121_A79CustomerTypeName ;
      private short[] T000121_A93CustomerLastLine ;
      private short[] T000121_A95CustomerLastLineLocation ;
      private short[] T000121_A78CustomerTypeId ;
      private bool[] T000121_n78CustomerTypeId ;
      private string[] T000122_A79CustomerTypeName ;
      private short[] T000123_A1CustomerId ;
      private short[] T000119_A1CustomerId ;
      private string[] T000119_A41CustomerKvkNumber ;
      private string[] T000119_A3CustomerName ;
      private string[] T000119_A4CustomerPostalAddress ;
      private bool[] T000119_n4CustomerPostalAddress ;
      private string[] T000119_A5CustomerEmail ;
      private bool[] T000119_n5CustomerEmail ;
      private string[] T000119_A6CustomerVisitingAddress ;
      private bool[] T000119_n6CustomerVisitingAddress ;
      private string[] T000119_A7CustomerPhone ;
      private bool[] T000119_n7CustomerPhone ;
      private string[] T000119_A14CustomerVatNumber ;
      private short[] T000119_A93CustomerLastLine ;
      private short[] T000119_A95CustomerLastLineLocation ;
      private short[] T000119_A78CustomerTypeId ;
      private bool[] T000119_n78CustomerTypeId ;
      private short[] T000124_A1CustomerId ;
      private short[] T000125_A1CustomerId ;
      private short[] T000118_A1CustomerId ;
      private string[] T000118_A41CustomerKvkNumber ;
      private string[] T000118_A3CustomerName ;
      private string[] T000118_A4CustomerPostalAddress ;
      private bool[] T000118_n4CustomerPostalAddress ;
      private string[] T000118_A5CustomerEmail ;
      private bool[] T000118_n5CustomerEmail ;
      private string[] T000118_A6CustomerVisitingAddress ;
      private bool[] T000118_n6CustomerVisitingAddress ;
      private string[] T000118_A7CustomerPhone ;
      private bool[] T000118_n7CustomerPhone ;
      private string[] T000118_A14CustomerVatNumber ;
      private short[] T000118_A93CustomerLastLine ;
      private short[] T000118_A95CustomerLastLineLocation ;
      private short[] T000118_A78CustomerTypeId ;
      private bool[] T000118_n78CustomerTypeId ;
      private short[] T000127_A1CustomerId ;
      private string[] T000130_A79CustomerTypeName ;
      private short[] T000131_A128CustomerCustomizationId ;
      private short[] T000132_A103PageId ;
      private short[] T000133_A1CustomerId ;
      private short[] T000133_A18CustomerLocationId ;
      private short[] T000135_A1CustomerId ;
      private short[] T000136_A1CustomerId ;
      private short[] T000136_A15CustomerManagerId ;
      private string[] T000136_A13CustomerManagerGAMGUID ;
      private string[] T000136_A17CustomerManagerInitials ;
      private bool[] T000136_n17CustomerManagerInitials ;
      private string[] T000136_A16CustomerManagerGivenName ;
      private string[] T000136_A9CustomerManagerLastName ;
      private string[] T000136_A10CustomerManagerEmail ;
      private string[] T000136_A11CustomerManagerPhone ;
      private bool[] T000136_n11CustomerManagerPhone ;
      private string[] T000136_A12CustomerManagerGender ;
      private bool[] T000136_n12CustomerManagerGender ;
      private short[] T000137_A1CustomerId ;
      private short[] T000137_A15CustomerManagerId ;
      private short[] T000117_A1CustomerId ;
      private short[] T000117_A15CustomerManagerId ;
      private string[] T000117_A13CustomerManagerGAMGUID ;
      private string[] T000117_A17CustomerManagerInitials ;
      private bool[] T000117_n17CustomerManagerInitials ;
      private string[] T000117_A16CustomerManagerGivenName ;
      private string[] T000117_A9CustomerManagerLastName ;
      private string[] T000117_A10CustomerManagerEmail ;
      private string[] T000117_A11CustomerManagerPhone ;
      private bool[] T000117_n11CustomerManagerPhone ;
      private string[] T000117_A12CustomerManagerGender ;
      private bool[] T000117_n12CustomerManagerGender ;
      private short[] T000116_A1CustomerId ;
      private short[] T000116_A15CustomerManagerId ;
      private string[] T000116_A13CustomerManagerGAMGUID ;
      private string[] T000116_A17CustomerManagerInitials ;
      private bool[] T000116_n17CustomerManagerInitials ;
      private string[] T000116_A16CustomerManagerGivenName ;
      private string[] T000116_A9CustomerManagerLastName ;
      private string[] T000116_A10CustomerManagerEmail ;
      private string[] T000116_A11CustomerManagerPhone ;
      private bool[] T000116_n11CustomerManagerPhone ;
      private string[] T000116_A12CustomerManagerGender ;
      private bool[] T000116_n12CustomerManagerGender ;
      private short[] T000141_A1CustomerId ;
      private short[] T000141_A15CustomerManagerId ;
      private short[] T000142_A1CustomerId ;
      private short[] T000142_A18CustomerLocationId ;
      private string[] T000142_A19CustomerLocationVisitingAddres ;
      private string[] T000142_A20CustomerLocationPostalAddress ;
      private string[] T000142_A21CustomerLocationEmail ;
      private string[] T000142_A22CustomerLocationPhone ;
      private short[] T000142_A94CustomerLocationLastLine ;
      private string[] T000142_A133CustomerLocationDescription ;
      private string[] T000142_A134CustomerLocationName ;
      private short[] T000143_A1CustomerId ;
      private short[] T000143_A18CustomerLocationId ;
      private short[] T000115_A1CustomerId ;
      private short[] T000115_A18CustomerLocationId ;
      private string[] T000115_A19CustomerLocationVisitingAddres ;
      private string[] T000115_A20CustomerLocationPostalAddress ;
      private string[] T000115_A21CustomerLocationEmail ;
      private string[] T000115_A22CustomerLocationPhone ;
      private short[] T000115_A94CustomerLocationLastLine ;
      private string[] T000115_A133CustomerLocationDescription ;
      private string[] T000115_A134CustomerLocationName ;
      private short[] T000114_A1CustomerId ;
      private short[] T000114_A18CustomerLocationId ;
      private string[] T000114_A19CustomerLocationVisitingAddres ;
      private string[] T000114_A20CustomerLocationPostalAddress ;
      private string[] T000114_A21CustomerLocationEmail ;
      private string[] T000114_A22CustomerLocationPhone ;
      private short[] T000114_A94CustomerLocationLastLine ;
      private string[] T000114_A133CustomerLocationDescription ;
      private string[] T000114_A134CustomerLocationName ;
      private short[] T000147_A115LocationEventId ;
      private short[] T000148_A31ResidentId ;
      private short[] T000150_A1CustomerId ;
      private short[] T000150_A18CustomerLocationId ;
      private short[] T000151_A1CustomerId ;
      private short[] T000151_A18CustomerLocationId ;
      private short[] T000151_A23CustomerLocationReceptionistId ;
      private string[] T000151_A30CustomerLocationReceptionistGA ;
      private string[] T000151_A26CustomerLocationReceptionistIn ;
      private bool[] T000151_n26CustomerLocationReceptionistIn ;
      private string[] T000151_A24CustomerLocationReceptionistGi ;
      private string[] T000151_A25CustomerLocationReceptionistLa ;
      private string[] T000151_A27CustomerLocationReceptionistEm ;
      private string[] T000151_A28CustomerLocationReceptionistAd ;
      private bool[] T000151_n28CustomerLocationReceptionistAd ;
      private string[] T000151_A29CustomerLocationReceptionistPh ;
      private short[] T000152_A1CustomerId ;
      private short[] T000152_A18CustomerLocationId ;
      private short[] T000152_A23CustomerLocationReceptionistId ;
      private short[] T000113_A1CustomerId ;
      private short[] T000113_A18CustomerLocationId ;
      private short[] T000113_A23CustomerLocationReceptionistId ;
      private string[] T000113_A30CustomerLocationReceptionistGA ;
      private string[] T000113_A26CustomerLocationReceptionistIn ;
      private bool[] T000113_n26CustomerLocationReceptionistIn ;
      private string[] T000113_A24CustomerLocationReceptionistGi ;
      private string[] T000113_A25CustomerLocationReceptionistLa ;
      private string[] T000113_A27CustomerLocationReceptionistEm ;
      private string[] T000113_A28CustomerLocationReceptionistAd ;
      private bool[] T000113_n28CustomerLocationReceptionistAd ;
      private string[] T000113_A29CustomerLocationReceptionistPh ;
      private short[] T000112_A1CustomerId ;
      private short[] T000112_A18CustomerLocationId ;
      private short[] T000112_A23CustomerLocationReceptionistId ;
      private string[] T000112_A30CustomerLocationReceptionistGA ;
      private string[] T000112_A26CustomerLocationReceptionistIn ;
      private bool[] T000112_n26CustomerLocationReceptionistIn ;
      private string[] T000112_A24CustomerLocationReceptionistGi ;
      private string[] T000112_A25CustomerLocationReceptionistLa ;
      private string[] T000112_A27CustomerLocationReceptionistEm ;
      private string[] T000112_A28CustomerLocationReceptionistAd ;
      private bool[] T000112_n28CustomerLocationReceptionistAd ;
      private string[] T000112_A29CustomerLocationReceptionistPh ;
      private short[] T000156_A1CustomerId ;
      private short[] T000156_A18CustomerLocationId ;
      private short[] T000156_A23CustomerLocationReceptionistId ;
      private short[] T000157_A1CustomerId ;
      private short[] T000157_A18CustomerLocationId ;
      private string[] T000157_A56Supplier_AgbNumber ;
      private string[] T000157_A57Supplier_AgbName ;
      private string[] T000157_A58Supplier_AgbKvkNumber ;
      private string[] T000157_A59Supplier_AgbVisitingAddress ;
      private bool[] T000157_n59Supplier_AgbVisitingAddress ;
      private string[] T000157_A60Supplier_AgbPostalAddress ;
      private bool[] T000157_n60Supplier_AgbPostalAddress ;
      private string[] T000157_A61Supplier_AgbEmail ;
      private bool[] T000157_n61Supplier_AgbEmail ;
      private string[] T000157_A62Supplier_AgbPhone ;
      private bool[] T000157_n62Supplier_AgbPhone ;
      private string[] T000157_A63Supplier_AgbContactName ;
      private bool[] T000157_n63Supplier_AgbContactName ;
      private short[] T000157_A55Supplier_AgbId ;
      private string[] T000111_A56Supplier_AgbNumber ;
      private string[] T000111_A57Supplier_AgbName ;
      private string[] T000111_A58Supplier_AgbKvkNumber ;
      private string[] T000111_A59Supplier_AgbVisitingAddress ;
      private bool[] T000111_n59Supplier_AgbVisitingAddress ;
      private string[] T000111_A60Supplier_AgbPostalAddress ;
      private bool[] T000111_n60Supplier_AgbPostalAddress ;
      private string[] T000111_A61Supplier_AgbEmail ;
      private bool[] T000111_n61Supplier_AgbEmail ;
      private string[] T000111_A62Supplier_AgbPhone ;
      private bool[] T000111_n62Supplier_AgbPhone ;
      private string[] T000111_A63Supplier_AgbContactName ;
      private bool[] T000111_n63Supplier_AgbContactName ;
      private string[] T000158_A56Supplier_AgbNumber ;
      private string[] T000158_A57Supplier_AgbName ;
      private string[] T000158_A58Supplier_AgbKvkNumber ;
      private string[] T000158_A59Supplier_AgbVisitingAddress ;
      private bool[] T000158_n59Supplier_AgbVisitingAddress ;
      private string[] T000158_A60Supplier_AgbPostalAddress ;
      private bool[] T000158_n60Supplier_AgbPostalAddress ;
      private string[] T000158_A61Supplier_AgbEmail ;
      private bool[] T000158_n61Supplier_AgbEmail ;
      private string[] T000158_A62Supplier_AgbPhone ;
      private bool[] T000158_n62Supplier_AgbPhone ;
      private string[] T000158_A63Supplier_AgbContactName ;
      private bool[] T000158_n63Supplier_AgbContactName ;
      private short[] T000159_A1CustomerId ;
      private short[] T000159_A18CustomerLocationId ;
      private short[] T000159_A55Supplier_AgbId ;
      private short[] T000110_A1CustomerId ;
      private short[] T000110_A18CustomerLocationId ;
      private short[] T000110_A55Supplier_AgbId ;
      private short[] T00019_A1CustomerId ;
      private short[] T00019_A18CustomerLocationId ;
      private short[] T00019_A55Supplier_AgbId ;
      private string[] T000162_A56Supplier_AgbNumber ;
      private string[] T000162_A57Supplier_AgbName ;
      private string[] T000162_A58Supplier_AgbKvkNumber ;
      private string[] T000162_A59Supplier_AgbVisitingAddress ;
      private bool[] T000162_n59Supplier_AgbVisitingAddress ;
      private string[] T000162_A60Supplier_AgbPostalAddress ;
      private bool[] T000162_n60Supplier_AgbPostalAddress ;
      private string[] T000162_A61Supplier_AgbEmail ;
      private bool[] T000162_n61Supplier_AgbEmail ;
      private string[] T000162_A62Supplier_AgbPhone ;
      private bool[] T000162_n62Supplier_AgbPhone ;
      private string[] T000162_A63Supplier_AgbContactName ;
      private bool[] T000162_n63Supplier_AgbContactName ;
      private short[] T000163_A1CustomerId ;
      private short[] T000163_A18CustomerLocationId ;
      private short[] T000163_A55Supplier_AgbId ;
      private short[] T000164_A1CustomerId ;
      private short[] T000164_A18CustomerLocationId ;
      private string[] T000164_A65Supplier_GenKvKNumber ;
      private string[] T000164_A66Supplier_GenCompanyName ;
      private string[] T000164_A67Supplier_GenVisitingAddress ;
      private bool[] T000164_n67Supplier_GenVisitingAddress ;
      private string[] T000164_A68Supplier_GenPostalAddress ;
      private bool[] T000164_n68Supplier_GenPostalAddress ;
      private string[] T000164_A69Supplier_GenContactName ;
      private bool[] T000164_n69Supplier_GenContactName ;
      private string[] T000164_A70Supplier_GenContactPhone ;
      private bool[] T000164_n70Supplier_GenContactPhone ;
      private short[] T000164_A64Supplier_GenId ;
      private string[] T00018_A65Supplier_GenKvKNumber ;
      private string[] T00018_A66Supplier_GenCompanyName ;
      private string[] T00018_A67Supplier_GenVisitingAddress ;
      private bool[] T00018_n67Supplier_GenVisitingAddress ;
      private string[] T00018_A68Supplier_GenPostalAddress ;
      private bool[] T00018_n68Supplier_GenPostalAddress ;
      private string[] T00018_A69Supplier_GenContactName ;
      private bool[] T00018_n69Supplier_GenContactName ;
      private string[] T00018_A70Supplier_GenContactPhone ;
      private bool[] T00018_n70Supplier_GenContactPhone ;
      private string[] T000165_A65Supplier_GenKvKNumber ;
      private string[] T000165_A66Supplier_GenCompanyName ;
      private string[] T000165_A67Supplier_GenVisitingAddress ;
      private bool[] T000165_n67Supplier_GenVisitingAddress ;
      private string[] T000165_A68Supplier_GenPostalAddress ;
      private bool[] T000165_n68Supplier_GenPostalAddress ;
      private string[] T000165_A69Supplier_GenContactName ;
      private bool[] T000165_n69Supplier_GenContactName ;
      private string[] T000165_A70Supplier_GenContactPhone ;
      private bool[] T000165_n70Supplier_GenContactPhone ;
      private short[] T000166_A1CustomerId ;
      private short[] T000166_A18CustomerLocationId ;
      private short[] T000166_A64Supplier_GenId ;
      private short[] T00017_A1CustomerId ;
      private short[] T00017_A18CustomerLocationId ;
      private short[] T00017_A64Supplier_GenId ;
      private short[] T00016_A1CustomerId ;
      private short[] T00016_A18CustomerLocationId ;
      private short[] T00016_A64Supplier_GenId ;
      private string[] T000169_A65Supplier_GenKvKNumber ;
      private string[] T000169_A66Supplier_GenCompanyName ;
      private string[] T000169_A67Supplier_GenVisitingAddress ;
      private bool[] T000169_n67Supplier_GenVisitingAddress ;
      private string[] T000169_A68Supplier_GenPostalAddress ;
      private bool[] T000169_n68Supplier_GenPostalAddress ;
      private string[] T000169_A69Supplier_GenContactName ;
      private bool[] T000169_n69Supplier_GenContactName ;
      private string[] T000169_A70Supplier_GenContactPhone ;
      private bool[] T000169_n70Supplier_GenContactPhone ;
      private short[] T000170_A1CustomerId ;
      private short[] T000170_A18CustomerLocationId ;
      private short[] T000170_A64Supplier_GenId ;
      private short[] T000171_A1CustomerId ;
      private short[] T000171_A18CustomerLocationId ;
      private string[] T000171_A101AmenitiesName ;
      private string[] T000171_A100AmenitiesTypeName ;
      private short[] T000171_A98AmenitiesId ;
      private short[] T000171_A99AmenitiesTypeId ;
      private string[] T00014_A101AmenitiesName ;
      private short[] T00014_A99AmenitiesTypeId ;
      private string[] T00015_A100AmenitiesTypeName ;
      private string[] T000172_A101AmenitiesName ;
      private short[] T000172_A99AmenitiesTypeId ;
      private string[] T000173_A100AmenitiesTypeName ;
      private short[] T000174_A1CustomerId ;
      private short[] T000174_A18CustomerLocationId ;
      private short[] T000174_A98AmenitiesId ;
      private short[] T00013_A1CustomerId ;
      private short[] T00013_A18CustomerLocationId ;
      private short[] T00013_A98AmenitiesId ;
      private short[] T00012_A1CustomerId ;
      private short[] T00012_A18CustomerLocationId ;
      private short[] T00012_A98AmenitiesId ;
      private string[] T000177_A101AmenitiesName ;
      private short[] T000177_A99AmenitiesTypeId ;
      private string[] T000178_A100AmenitiesTypeName ;
      private short[] T000179_A1CustomerId ;
      private short[] T000179_A18CustomerLocationId ;
      private short[] T000179_A98AmenitiesId ;
      private IDataStoreProvider pr_gam ;
   }

   public class customer__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class customer__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new UpdateCursor(def[36])
       ,new UpdateCursor(def[37])
       ,new UpdateCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new UpdateCursor(def[42])
       ,new UpdateCursor(def[43])
       ,new UpdateCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new UpdateCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new ForEachCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new UpdateCursor(def[51])
       ,new UpdateCursor(def[52])
       ,new UpdateCursor(def[53])
       ,new ForEachCursor(def[54])
       ,new ForEachCursor(def[55])
       ,new ForEachCursor(def[56])
       ,new ForEachCursor(def[57])
       ,new UpdateCursor(def[58])
       ,new UpdateCursor(def[59])
       ,new ForEachCursor(def[60])
       ,new ForEachCursor(def[61])
       ,new ForEachCursor(def[62])
       ,new ForEachCursor(def[63])
       ,new ForEachCursor(def[64])
       ,new UpdateCursor(def[65])
       ,new UpdateCursor(def[66])
       ,new ForEachCursor(def[67])
       ,new ForEachCursor(def[68])
       ,new ForEachCursor(def[69])
       ,new ForEachCursor(def[70])
       ,new ForEachCursor(def[71])
       ,new ForEachCursor(def[72])
       ,new UpdateCursor(def[73])
       ,new UpdateCursor(def[74])
       ,new ForEachCursor(def[75])
       ,new ForEachCursor(def[76])
       ,new ForEachCursor(def[77])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00012;
        prmT00012 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT00013;
        prmT00013 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT00014;
        prmT00014 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT00015;
        prmT00015 = new Object[] {
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0)
        };
        Object[] prmT00016;
        prmT00016 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT00017;
        prmT00017 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT00018;
        prmT00018 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT00019;
        prmT00019 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmT000110;
        prmT000110 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmT000111;
        prmT000111 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmT000112;
        prmT000112 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmT000113;
        prmT000113 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmT000114;
        prmT000114 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000115;
        prmT000115 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000116;
        prmT000116 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmT000117;
        prmT000117 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmT000118;
        prmT000118 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000119;
        prmT000119 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000120;
        prmT000120 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000121;
        prmT000121 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000122;
        prmT000122 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000123;
        prmT000123 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000124;
        prmT000124 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000125;
        prmT000125 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000126;
        prmT000126 = new Object[] {
        new ParDef("CustomerKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("CustomerName",GXType.VarChar,40,0) ,
        new ParDef("CustomerPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("CustomerVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerVatNumber",GXType.VarChar,14,0) ,
        new ParDef("CustomerLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerLastLineLocation",GXType.Int16,4,0) ,
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000127;
        prmT000127 = new Object[] {
        };
        Object[] prmT000128;
        prmT000128 = new Object[] {
        new ParDef("CustomerKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("CustomerName",GXType.VarChar,40,0) ,
        new ParDef("CustomerPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("CustomerVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerVatNumber",GXType.VarChar,14,0) ,
        new ParDef("CustomerLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerLastLineLocation",GXType.Int16,4,0) ,
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000129;
        prmT000129 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000130;
        prmT000130 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000131;
        prmT000131 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000132;
        prmT000132 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000133;
        prmT000133 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000134;
        prmT000134 = new Object[] {
        new ParDef("CustomerLastLineLocation",GXType.Int16,4,0) ,
        new ParDef("CustomerLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000135;
        prmT000135 = new Object[] {
        };
        Object[] prmT000136;
        prmT000136 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmT000137;
        prmT000137 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmT000138;
        prmT000138 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("CustomerManagerInitials",GXType.Char,10,0){Nullable=true} ,
        new ParDef("CustomerManagerGivenName",GXType.VarChar,40,0) ,
        new ParDef("CustomerManagerLastName",GXType.VarChar,40,0) ,
        new ParDef("CustomerManagerEmail",GXType.VarChar,100,0) ,
        new ParDef("CustomerManagerPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerManagerGender",GXType.Char,20,0){Nullable=true}
        };
        Object[] prmT000139;
        prmT000139 = new Object[] {
        new ParDef("CustomerManagerGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("CustomerManagerInitials",GXType.Char,10,0){Nullable=true} ,
        new ParDef("CustomerManagerGivenName",GXType.VarChar,40,0) ,
        new ParDef("CustomerManagerLastName",GXType.VarChar,40,0) ,
        new ParDef("CustomerManagerEmail",GXType.VarChar,100,0) ,
        new ParDef("CustomerManagerPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerManagerGender",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmT000140;
        prmT000140 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmT000141;
        prmT000141 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000142;
        prmT000142 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000143;
        prmT000143 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000144;
        prmT000144 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationVisitingAddres",GXType.VarChar,1024,0) ,
        new ParDef("CustomerLocationPostalAddress",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationEmail",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationPhone",GXType.Char,20,0) ,
        new ParDef("CustomerLocationLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationDescription",GXType.VarChar,200,0) ,
        new ParDef("CustomerLocationName",GXType.VarChar,40,0)
        };
        Object[] prmT000145;
        prmT000145 = new Object[] {
        new ParDef("CustomerLocationVisitingAddres",GXType.VarChar,1024,0) ,
        new ParDef("CustomerLocationPostalAddress",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationEmail",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationPhone",GXType.Char,20,0) ,
        new ParDef("CustomerLocationLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationDescription",GXType.VarChar,200,0) ,
        new ParDef("CustomerLocationName",GXType.VarChar,40,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000146;
        prmT000146 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000147;
        prmT000147 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000148;
        prmT000148 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000149;
        prmT000149 = new Object[] {
        new ParDef("CustomerLocationLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000150;
        prmT000150 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000151;
        prmT000151 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmT000152;
        prmT000152 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmT000153;
        prmT000153 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistGA",GXType.VarChar,100,60) ,
        new ParDef("CustomerLocationReceptionistIn",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerLocationReceptionistGi",GXType.VarChar,40,0) ,
        new ParDef("CustomerLocationReceptionistLa",GXType.VarChar,40,0) ,
        new ParDef("CustomerLocationReceptionistEm",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationReceptionistAd",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerLocationReceptionistPh",GXType.Char,20,0)
        };
        Object[] prmT000154;
        prmT000154 = new Object[] {
        new ParDef("CustomerLocationReceptionistGA",GXType.VarChar,100,60) ,
        new ParDef("CustomerLocationReceptionistIn",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerLocationReceptionistGi",GXType.VarChar,40,0) ,
        new ParDef("CustomerLocationReceptionistLa",GXType.VarChar,40,0) ,
        new ParDef("CustomerLocationReceptionistEm",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationReceptionistAd",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerLocationReceptionistPh",GXType.Char,20,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmT000155;
        prmT000155 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmT000156;
        prmT000156 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000157;
        prmT000157 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmT000158;
        prmT000158 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmT000159;
        prmT000159 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmT000160;
        prmT000160 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmT000161;
        prmT000161 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmT000162;
        prmT000162 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmT000163;
        prmT000163 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000164;
        prmT000164 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000165;
        prmT000165 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000166;
        prmT000166 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000167;
        prmT000167 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000168;
        prmT000168 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000169;
        prmT000169 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000170;
        prmT000170 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000171;
        prmT000171 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000172;
        prmT000172 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000173;
        prmT000173 = new Object[] {
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000174;
        prmT000174 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000175;
        prmT000175 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000176;
        prmT000176 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000177;
        prmT000177 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000178;
        prmT000178 = new Object[] {
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000179;
        prmT000179 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00012", "SELECT CustomerId, CustomerLocationId, AmenitiesId FROM CustomerLocationsAmenities WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND AmenitiesId = :AmenitiesId  FOR UPDATE OF CustomerLocationsAmenities NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00013", "SELECT CustomerId, CustomerLocationId, AmenitiesId FROM CustomerLocationsAmenities WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00014", "SELECT AmenitiesName, AmenitiesTypeId FROM Amenities WHERE AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00015", "SELECT AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AmenitiesTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00016", "SELECT CustomerId, CustomerLocationId, Supplier_GenId FROM CustomerLocationSupplier_Gen WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_GenId = :Supplier_GenId  FOR UPDATE OF CustomerLocationSupplier_Gen NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00017", "SELECT CustomerId, CustomerLocationId, Supplier_GenId FROM CustomerLocationSupplier_Gen WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00018", "SELECT Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00019", "SELECT CustomerId, CustomerLocationId, Supplier_AgbId FROM CustomerLocationSupplier_Agb WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_AgbId = :Supplier_AgbId  FOR UPDATE OF CustomerLocationSupplier_Agb NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000110", "SELECT CustomerId, CustomerLocationId, Supplier_AgbId FROM CustomerLocationSupplier_Agb WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000110,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000111", "SELECT Supplier_AgbNumber, Supplier_AgbName, Supplier_AgbKvkNumber, Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress, Supplier_AgbEmail, Supplier_AgbPhone, Supplier_AgbContactName FROM Supplier_AGB WHERE Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000112", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId, CustomerLocationReceptionistGA, CustomerLocationReceptionistIn, CustomerLocationReceptionistGi, CustomerLocationReceptionistLa, CustomerLocationReceptionistEm, CustomerLocationReceptionistAd, CustomerLocationReceptionistPh FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId  FOR UPDATE OF CustomerLocationReceptionist NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000113", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId, CustomerLocationReceptionistGA, CustomerLocationReceptionistIn, CustomerLocationReceptionistGi, CustomerLocationReceptionistLa, CustomerLocationReceptionistEm, CustomerLocationReceptionistAd, CustomerLocationReceptionistPh FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000114", "SELECT CustomerId, CustomerLocationId, CustomerLocationVisitingAddres, CustomerLocationPostalAddress, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationLastLine, CustomerLocationDescription, CustomerLocationName FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId  FOR UPDATE OF CustomerLocation NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000115", "SELECT CustomerId, CustomerLocationId, CustomerLocationVisitingAddres, CustomerLocationPostalAddress, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationLastLine, CustomerLocationDescription, CustomerLocationName FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000115,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000116", "SELECT CustomerId, CustomerManagerId, CustomerManagerGAMGUID, CustomerManagerInitials, CustomerManagerGivenName, CustomerManagerLastName, CustomerManagerEmail, CustomerManagerPhone, CustomerManagerGender FROM CustomerManager WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId  FOR UPDATE OF CustomerManager NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000116,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000117", "SELECT CustomerId, CustomerManagerId, CustomerManagerGAMGUID, CustomerManagerInitials, CustomerManagerGivenName, CustomerManagerLastName, CustomerManagerEmail, CustomerManagerPhone, CustomerManagerGender FROM CustomerManager WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000117,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000118", "SELECT CustomerId, CustomerKvkNumber, CustomerName, CustomerPostalAddress, CustomerEmail, CustomerVisitingAddress, CustomerPhone, CustomerVatNumber, CustomerLastLine, CustomerLastLineLocation, CustomerTypeId FROM Customer WHERE CustomerId = :CustomerId  FOR UPDATE OF Customer NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000118,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000119", "SELECT CustomerId, CustomerKvkNumber, CustomerName, CustomerPostalAddress, CustomerEmail, CustomerVisitingAddress, CustomerPhone, CustomerVatNumber, CustomerLastLine, CustomerLastLineLocation, CustomerTypeId FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000119,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000120", "SELECT CustomerTypeName FROM CustomerType WHERE CustomerTypeId = :CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000120,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000121", "SELECT TM1.CustomerId, TM1.CustomerKvkNumber, TM1.CustomerName, TM1.CustomerPostalAddress, TM1.CustomerEmail, TM1.CustomerVisitingAddress, TM1.CustomerPhone, TM1.CustomerVatNumber, T2.CustomerTypeName, TM1.CustomerLastLine, TM1.CustomerLastLineLocation, TM1.CustomerTypeId FROM (Customer TM1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = TM1.CustomerTypeId) WHERE TM1.CustomerId = :CustomerId ORDER BY TM1.CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000121,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000122", "SELECT CustomerTypeName FROM CustomerType WHERE CustomerTypeId = :CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000122,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000123", "SELECT CustomerId FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000123,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000124", "SELECT CustomerId FROM Customer WHERE ( CustomerId > :CustomerId) ORDER BY CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000124,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000125", "SELECT CustomerId FROM Customer WHERE ( CustomerId < :CustomerId) ORDER BY CustomerId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000125,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000126", "SAVEPOINT gxupdate;INSERT INTO Customer(CustomerKvkNumber, CustomerName, CustomerPostalAddress, CustomerEmail, CustomerVisitingAddress, CustomerPhone, CustomerVatNumber, CustomerLastLine, CustomerLastLineLocation, CustomerTypeId) VALUES(:CustomerKvkNumber, :CustomerName, :CustomerPostalAddress, :CustomerEmail, :CustomerVisitingAddress, :CustomerPhone, :CustomerVatNumber, :CustomerLastLine, :CustomerLastLineLocation, :CustomerTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000126)
           ,new CursorDef("T000127", "SELECT currval('CustomerId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000127,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000128", "SAVEPOINT gxupdate;UPDATE Customer SET CustomerKvkNumber=:CustomerKvkNumber, CustomerName=:CustomerName, CustomerPostalAddress=:CustomerPostalAddress, CustomerEmail=:CustomerEmail, CustomerVisitingAddress=:CustomerVisitingAddress, CustomerPhone=:CustomerPhone, CustomerVatNumber=:CustomerVatNumber, CustomerLastLine=:CustomerLastLine, CustomerLastLineLocation=:CustomerLastLineLocation, CustomerTypeId=:CustomerTypeId  WHERE CustomerId = :CustomerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000128)
           ,new CursorDef("T000129", "SAVEPOINT gxupdate;DELETE FROM Customer  WHERE CustomerId = :CustomerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000129)
           ,new CursorDef("T000130", "SELECT CustomerTypeName FROM CustomerType WHERE CustomerTypeId = :CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000130,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000131", "SELECT CustomerCustomizationId FROM CustomerCustomization WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000131,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000132", "SELECT PageId FROM Page WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000132,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000133", "SELECT CustomerId, CustomerLocationId FROM CustomerLocation WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000133,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000134", "SAVEPOINT gxupdate;UPDATE Customer SET CustomerLastLineLocation=:CustomerLastLineLocation, CustomerLastLine=:CustomerLastLine  WHERE CustomerId = :CustomerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000134)
           ,new CursorDef("T000135", "SELECT CustomerId FROM Customer ORDER BY CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000135,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000136", "SELECT CustomerId, CustomerManagerId, CustomerManagerGAMGUID, CustomerManagerInitials, CustomerManagerGivenName, CustomerManagerLastName, CustomerManagerEmail, CustomerManagerPhone, CustomerManagerGender FROM CustomerManager WHERE CustomerId = :CustomerId and CustomerManagerId = :CustomerManagerId ORDER BY CustomerId, CustomerManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000136,3, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000137", "SELECT CustomerId, CustomerManagerId FROM CustomerManager WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000137,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000138", "SAVEPOINT gxupdate;INSERT INTO CustomerManager(CustomerId, CustomerManagerId, CustomerManagerGAMGUID, CustomerManagerInitials, CustomerManagerGivenName, CustomerManagerLastName, CustomerManagerEmail, CustomerManagerPhone, CustomerManagerGender) VALUES(:CustomerId, :CustomerManagerId, :CustomerManagerGAMGUID, :CustomerManagerInitials, :CustomerManagerGivenName, :CustomerManagerLastName, :CustomerManagerEmail, :CustomerManagerPhone, :CustomerManagerGender);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000138)
           ,new CursorDef("T000139", "SAVEPOINT gxupdate;UPDATE CustomerManager SET CustomerManagerGAMGUID=:CustomerManagerGAMGUID, CustomerManagerInitials=:CustomerManagerInitials, CustomerManagerGivenName=:CustomerManagerGivenName, CustomerManagerLastName=:CustomerManagerLastName, CustomerManagerEmail=:CustomerManagerEmail, CustomerManagerPhone=:CustomerManagerPhone, CustomerManagerGender=:CustomerManagerGender  WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000139)
           ,new CursorDef("T000140", "SAVEPOINT gxupdate;DELETE FROM CustomerManager  WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000140)
           ,new CursorDef("T000141", "SELECT CustomerId, CustomerManagerId FROM CustomerManager WHERE CustomerId = :CustomerId ORDER BY CustomerId, CustomerManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000141,3, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000142", "SELECT CustomerId, CustomerLocationId, CustomerLocationVisitingAddres, CustomerLocationPostalAddress, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationLastLine, CustomerLocationDescription, CustomerLocationName FROM CustomerLocation WHERE CustomerId = :CustomerId and CustomerLocationId = :CustomerLocationId ORDER BY CustomerId, CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000142,6, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000143", "SELECT CustomerId, CustomerLocationId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000143,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000144", "SAVEPOINT gxupdate;INSERT INTO CustomerLocation(CustomerId, CustomerLocationId, CustomerLocationVisitingAddres, CustomerLocationPostalAddress, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationLastLine, CustomerLocationDescription, CustomerLocationName) VALUES(:CustomerId, :CustomerLocationId, :CustomerLocationVisitingAddres, :CustomerLocationPostalAddress, :CustomerLocationEmail, :CustomerLocationPhone, :CustomerLocationLastLine, :CustomerLocationDescription, :CustomerLocationName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000144)
           ,new CursorDef("T000145", "SAVEPOINT gxupdate;UPDATE CustomerLocation SET CustomerLocationVisitingAddres=:CustomerLocationVisitingAddres, CustomerLocationPostalAddress=:CustomerLocationPostalAddress, CustomerLocationEmail=:CustomerLocationEmail, CustomerLocationPhone=:CustomerLocationPhone, CustomerLocationLastLine=:CustomerLocationLastLine, CustomerLocationDescription=:CustomerLocationDescription, CustomerLocationName=:CustomerLocationName  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000145)
           ,new CursorDef("T000146", "SAVEPOINT gxupdate;DELETE FROM CustomerLocation  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000146)
           ,new CursorDef("T000147", "SELECT LocationEventId FROM LocationEvent WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000147,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000148", "SELECT ResidentId FROM Resident WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000148,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000149", "SAVEPOINT gxupdate;UPDATE CustomerLocation SET CustomerLocationLastLine=:CustomerLocationLastLine  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000149)
           ,new CursorDef("T000150", "SELECT CustomerId, CustomerLocationId FROM CustomerLocation WHERE CustomerId = :CustomerId ORDER BY CustomerId, CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000150,6, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000151", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId, CustomerLocationReceptionistGA, CustomerLocationReceptionistIn, CustomerLocationReceptionistGi, CustomerLocationReceptionistLa, CustomerLocationReceptionistEm, CustomerLocationReceptionistAd, CustomerLocationReceptionistPh FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId and CustomerLocationId = :CustomerLocationId and CustomerLocationReceptionistId = :CustomerLocationReceptionistId ORDER BY CustomerId, CustomerLocationId, CustomerLocationReceptionistId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000151,3, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000152", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000152,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000153", "SAVEPOINT gxupdate;INSERT INTO CustomerLocationReceptionist(CustomerId, CustomerLocationId, CustomerLocationReceptionistId, CustomerLocationReceptionistGA, CustomerLocationReceptionistIn, CustomerLocationReceptionistGi, CustomerLocationReceptionistLa, CustomerLocationReceptionistEm, CustomerLocationReceptionistAd, CustomerLocationReceptionistPh) VALUES(:CustomerId, :CustomerLocationId, :CustomerLocationReceptionistId, :CustomerLocationReceptionistGA, :CustomerLocationReceptionistIn, :CustomerLocationReceptionistGi, :CustomerLocationReceptionistLa, :CustomerLocationReceptionistEm, :CustomerLocationReceptionistAd, :CustomerLocationReceptionistPh);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000153)
           ,new CursorDef("T000154", "SAVEPOINT gxupdate;UPDATE CustomerLocationReceptionist SET CustomerLocationReceptionistGA=:CustomerLocationReceptionistGA, CustomerLocationReceptionistIn=:CustomerLocationReceptionistIn, CustomerLocationReceptionistGi=:CustomerLocationReceptionistGi, CustomerLocationReceptionistLa=:CustomerLocationReceptionistLa, CustomerLocationReceptionistEm=:CustomerLocationReceptionistEm, CustomerLocationReceptionistAd=:CustomerLocationReceptionistAd, CustomerLocationReceptionistPh=:CustomerLocationReceptionistPh  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000154)
           ,new CursorDef("T000155", "SAVEPOINT gxupdate;DELETE FROM CustomerLocationReceptionist  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000155)
           ,new CursorDef("T000156", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId and CustomerLocationId = :CustomerLocationId ORDER BY CustomerId, CustomerLocationId, CustomerLocationReceptionistId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000156,3, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000157", "SELECT T1.CustomerId, T1.CustomerLocationId, T2.Supplier_AgbNumber, T2.Supplier_AgbName, T2.Supplier_AgbKvkNumber, T2.Supplier_AgbVisitingAddress, T2.Supplier_AgbPostalAddress, T2.Supplier_AgbEmail, T2.Supplier_AgbPhone, T2.Supplier_AgbContactName, T1.Supplier_AgbId FROM (CustomerLocationSupplier_Agb T1 INNER JOIN Supplier_AGB T2 ON T2.Supplier_AgbId = T1.Supplier_AgbId) WHERE T1.CustomerId = :CustomerId and T1.CustomerLocationId = :CustomerLocationId and T1.Supplier_AgbId = :Supplier_AgbId ORDER BY T1.CustomerId, T1.CustomerLocationId, T1.Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000157,3, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000158", "SELECT Supplier_AgbNumber, Supplier_AgbName, Supplier_AgbKvkNumber, Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress, Supplier_AgbEmail, Supplier_AgbPhone, Supplier_AgbContactName FROM Supplier_AGB WHERE Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000158,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000159", "SELECT CustomerId, CustomerLocationId, Supplier_AgbId FROM CustomerLocationSupplier_Agb WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000159,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000160", "SAVEPOINT gxupdate;INSERT INTO CustomerLocationSupplier_Agb(CustomerId, CustomerLocationId, Supplier_AgbId) VALUES(:CustomerId, :CustomerLocationId, :Supplier_AgbId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000160)
           ,new CursorDef("T000161", "SAVEPOINT gxupdate;DELETE FROM CustomerLocationSupplier_Agb  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_AgbId = :Supplier_AgbId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000161)
           ,new CursorDef("T000162", "SELECT Supplier_AgbNumber, Supplier_AgbName, Supplier_AgbKvkNumber, Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress, Supplier_AgbEmail, Supplier_AgbPhone, Supplier_AgbContactName FROM Supplier_AGB WHERE Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000162,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000163", "SELECT CustomerId, CustomerLocationId, Supplier_AgbId FROM CustomerLocationSupplier_Agb WHERE CustomerId = :CustomerId and CustomerLocationId = :CustomerLocationId ORDER BY CustomerId, CustomerLocationId, Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000163,3, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000164", "SELECT T1.CustomerId, T1.CustomerLocationId, T2.Supplier_GenKvKNumber, T2.Supplier_GenCompanyName, T2.Supplier_GenVisitingAddress, T2.Supplier_GenPostalAddress, T2.Supplier_GenContactName, T2.Supplier_GenContactPhone, T1.Supplier_GenId FROM (CustomerLocationSupplier_Gen T1 INNER JOIN Supplier_Gen T2 ON T2.Supplier_GenId = T1.Supplier_GenId) WHERE T1.CustomerId = :CustomerId and T1.CustomerLocationId = :CustomerLocationId and T1.Supplier_GenId = :Supplier_GenId ORDER BY T1.CustomerId, T1.CustomerLocationId, T1.Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000164,3, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000165", "SELECT Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000165,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000166", "SELECT CustomerId, CustomerLocationId, Supplier_GenId FROM CustomerLocationSupplier_Gen WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000166,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000167", "SAVEPOINT gxupdate;INSERT INTO CustomerLocationSupplier_Gen(CustomerId, CustomerLocationId, Supplier_GenId) VALUES(:CustomerId, :CustomerLocationId, :Supplier_GenId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000167)
           ,new CursorDef("T000168", "SAVEPOINT gxupdate;DELETE FROM CustomerLocationSupplier_Gen  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_GenId = :Supplier_GenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000168)
           ,new CursorDef("T000169", "SELECT Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000169,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000170", "SELECT CustomerId, CustomerLocationId, Supplier_GenId FROM CustomerLocationSupplier_Gen WHERE CustomerId = :CustomerId and CustomerLocationId = :CustomerLocationId ORDER BY CustomerId, CustomerLocationId, Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000170,3, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000171", "SELECT T1.CustomerId, T1.CustomerLocationId, T2.AmenitiesName, T3.AmenitiesTypeName, T1.AmenitiesId, T2.AmenitiesTypeId FROM ((CustomerLocationsAmenities T1 INNER JOIN Amenities T2 ON T2.AmenitiesId = T1.AmenitiesId) INNER JOIN AmenitiesType T3 ON T3.AmenitiesTypeId = T2.AmenitiesTypeId) WHERE T1.CustomerId = :CustomerId and T1.CustomerLocationId = :CustomerLocationId and T1.AmenitiesId = :AmenitiesId ORDER BY T1.CustomerId, T1.CustomerLocationId, T1.AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000171,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000172", "SELECT AmenitiesName, AmenitiesTypeId FROM Amenities WHERE AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000172,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000173", "SELECT AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AmenitiesTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000173,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000174", "SELECT CustomerId, CustomerLocationId, AmenitiesId FROM CustomerLocationsAmenities WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000174,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000175", "SAVEPOINT gxupdate;INSERT INTO CustomerLocationsAmenities(CustomerId, CustomerLocationId, AmenitiesId) VALUES(:CustomerId, :CustomerLocationId, :AmenitiesId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000175)
           ,new CursorDef("T000176", "SAVEPOINT gxupdate;DELETE FROM CustomerLocationsAmenities  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND AmenitiesId = :AmenitiesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000176)
           ,new CursorDef("T000177", "SELECT AmenitiesName, AmenitiesTypeId FROM Amenities WHERE AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000177,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000178", "SELECT AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AmenitiesTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000178,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000179", "SELECT CustomerId, CustomerLocationId, AmenitiesId FROM CustomerLocationsAmenities WHERE CustomerId = :CustomerId and CustomerLocationId = :CustomerLocationId ORDER BY CustomerId, CustomerLocationId, AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000179,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              return;
           case 11 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              return;
           case 16 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((short[]) buf[12])[0] = rslt.getShort(9);
              ((short[]) buf[13])[0] = rslt.getShort(10);
              ((short[]) buf[14])[0] = rslt.getShort(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((short[]) buf[12])[0] = rslt.getShort(9);
              ((short[]) buf[13])[0] = rslt.getShort(10);
              ((short[]) buf[14])[0] = rslt.getShort(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((short[]) buf[13])[0] = rslt.getShort(10);
              ((short[]) buf[14])[0] = rslt.getShort(11);
              ((short[]) buf[15])[0] = rslt.getShort(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 21 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 22 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 23 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 25 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 29 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
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
              return;
           case 31 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 33 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 34 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              return;
           case 35 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 39 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 40 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 41 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 45 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 46 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 48 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 49 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              return;
           case 50 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 54 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 55 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((short[]) buf[15])[0] = rslt.getShort(11);
              return;
           case 56 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              return;
           case 57 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
     }
     getresults60( cursor, rslt, buf) ;
  }

  public void getresults60( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 60 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              return;
           case 61 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 62 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((short[]) buf[12])[0] = rslt.getShort(9);
              return;
           case 63 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              return;
           case 64 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 67 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              return;
           case 68 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 69 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 70 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 71 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 72 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 75 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 76 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 77 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
     }
  }

}

}
