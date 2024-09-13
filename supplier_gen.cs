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
   public class supplier_gen : GXDataArea
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
            A73ProductServiceId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductServiceId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A73ProductServiceId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A71ProductServiceTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductServiceTypeId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A71ProductServiceTypeId) ;
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
               AV7Supplier_GenId = (short)(Math.Round(NumberUtil.Val( GetPar( "Supplier_GenId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7Supplier_GenId", StringUtil.LTrimStr( (decimal)(AV7Supplier_GenId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIER_GENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Supplier_GenId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "General Suppliers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplier_GenKvKNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_productservice_newrow_invoke( )
      {
         nRC_GXsfl_58 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_58"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_58_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_58_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_58_idx = GetPar( "sGXsfl_58_idx");
         edtProductServiceId_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtProductServiceId_Internalname, "Horizontalalignment", edtProductServiceId_Horizontalalignment, !bGXsfl_58_Refreshing);
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

      public supplier_gen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supplier_gen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_Supplier_GenId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Supplier_GenId = aP1_Supplier_GenId;
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
            return "supplier_gen_Execute" ;
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, divTablemain_Width, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "Supplier Information", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Supplier_Gen.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_GenKvKNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplier_GenKvKNumber_Internalname, context.GetMessage( "KVK Number", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplier_GenKvKNumber_Internalname, A65Supplier_GenKvKNumber, StringUtil.RTrim( context.localUtil.Format( A65Supplier_GenKvKNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplier_GenKvKNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_GenKvKNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_GenCompanyName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplier_GenCompanyName_Internalname, context.GetMessage( "Company Name", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplier_GenCompanyName_Internalname, A66Supplier_GenCompanyName, StringUtil.RTrim( context.localUtil.Format( A66Supplier_GenCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplier_GenCompanyName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_GenCompanyName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_GenContactPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplier_GenContactPhone_Internalname, context.GetMessage( "Contact Phone", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A70Supplier_GenContactPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplier_GenContactPhone_Internalname, StringUtil.RTrim( A70Supplier_GenContactPhone), StringUtil.RTrim( context.localUtil.Format( A70Supplier_GenContactPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtSupplier_GenContactPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_GenContactPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_GenContactName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplier_GenContactName_Internalname, context.GetMessage( "Contact Name", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplier_GenContactName_Internalname, A69Supplier_GenContactName, StringUtil.RTrim( context.localUtil.Format( A69Supplier_GenContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplier_GenContactName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_GenContactName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_GenVisitingAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplier_GenVisitingAddress_Internalname, context.GetMessage( "Visiting Address", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSupplier_GenVisitingAddress_Internalname, A67Supplier_GenVisitingAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A67Supplier_GenVisitingAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", 0, 1, edtSupplier_GenVisitingAddress_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_GenPostalAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplier_GenPostalAddress_Internalname, context.GetMessage( "Postal Address", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSupplier_GenPostalAddress_Internalname, A68Supplier_GenPostalAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A68Supplier_GenPostalAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtSupplier_GenPostalAddress_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_productservice_title_Internalname, context.GetMessage( "Products/Services", ""), "", "", lblTablevel_productservice_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Supplier_Gen.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_ProductService") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"panel2"+"\" style=\"display:none;\">") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "BtnDefault ButtonWizard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "", context.GetMessage( "GXM_previous", ""), bttBtnwizardprevious_Jsonclick, 7, context.GetMessage( "GXM_previous", ""), "", StyleString, ClassString, bttBtnwizardprevious_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11049_client"+"'", TempTags, "", 2, "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button ButtonWizard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnwizardnext_Internalname, "", context.GetMessage( "GXM_next", ""), bttBtnwizardnext_Jsonclick, 7, context.GetMessage( "GXM_next", ""), "", StyleString, ClassString, bttBtnwizardnext_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e12049_client"+"'", TempTags, "", 2, "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier_Gen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier_Gen.htm");
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
         ucCombo_productserviceid.SetProperty("Caption", Combo_productserviceid_Caption);
         ucCombo_productserviceid.SetProperty("Cls", Combo_productserviceid_Cls);
         ucCombo_productserviceid.SetProperty("IsGridItem", Combo_productserviceid_Isgriditem);
         ucCombo_productserviceid.SetProperty("HasDescription", Combo_productserviceid_Hasdescription);
         ucCombo_productserviceid.SetProperty("DataListProc", Combo_productserviceid_Datalistproc);
         ucCombo_productserviceid.SetProperty("DataListProcParametersPrefix", Combo_productserviceid_Datalistprocparametersprefix);
         ucCombo_productserviceid.SetProperty("EmptyItem", Combo_productserviceid_Emptyitem);
         ucCombo_productserviceid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_productserviceid.SetProperty("DropDownOptionsData", AV13ProductServiceId_Data);
         ucCombo_productserviceid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_productserviceid_Internalname, "COMBO_PRODUCTSERVICEIDContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplier_GenId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSupplier_GenId_Enabled!=0) ? context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9") : context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplier_GenId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplier_GenId_Visible, edtSupplier_GenId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Supplier_Gen.htm");
         /* User Defined Control */
         ucWizard_steps.Render(context, "dvelop.dvtabstransform", Wizard_steps_Internalname, "WIZARD_STEPSContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_productservice( )
      {
         /*  Grid Control  */
         StartGridControl58( ) ;
         nGXsfl_58_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount14 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_14 = 1;
               ScanStart0414( ) ;
               while ( RcdFound14 != 0 )
               {
                  init_level_properties14( ) ;
                  getByPrimaryKey0414( ) ;
                  AddRow0414( ) ;
                  ScanNext0414( ) ;
               }
               ScanEnd0414( ) ;
               nBlankRcdCount14 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0414( ) ;
            standaloneModal0414( ) ;
            sMode14 = Gx_mode;
            while ( nGXsfl_58_idx < nRC_GXsfl_58 )
            {
               bGXsfl_58_Refreshing = true;
               ReadRow0414( ) ;
               edtProductServiceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               edtProductServiceId_Horizontalalignment = cgiGet( "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Horizontalalignment");
               AssignProp("", false, edtProductServiceId_Internalname, "Horizontalalignment", edtProductServiceId_Horizontalalignment, !bGXsfl_58_Refreshing);
               edtProductServiceDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               edtProductServiceQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEQUANTITY_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceQuantity_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               edtProductServicePicture_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEPICTURE_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServicePicture_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServicePicture_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               edtProductServiceTypeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICETYPEID_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               edtProductServiceTypeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICETYPENAME_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeName_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               if ( ( nRcdExists_14 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0414( ) ;
               }
               SendRow0414( ) ;
               bGXsfl_58_Refreshing = false;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount14 = 5;
            nRcdExists_14 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0414( ) ;
               while ( RcdFound14 != 0 )
               {
                  sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5814( ) ;
                  init_level_properties14( ) ;
                  standaloneNotModal0414( ) ;
                  getByPrimaryKey0414( ) ;
                  standaloneModal0414( ) ;
                  AddRow0414( ) ;
                  ScanNext0414( ) ;
               }
               ScanEnd0414( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode14 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5814( ) ;
            InitAll0414( ) ;
            init_level_properties14( ) ;
            nRcdExists_14 = 0;
            nIsMod_14 = 0;
            nRcdDeleted_14 = 0;
            nBlankRcdCount14 = (short)(nBlankRcdUsr14+nBlankRcdCount14);
            fRowAdded = 0;
            while ( nBlankRcdCount14 > 0 )
            {
               standaloneNotModal0414( ) ;
               standaloneModal0414( ) ;
               AddRow0414( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProductServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount14 = (short)(nBlankRcdCount14-1);
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
         E13042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPRODUCTSERVICEID_DATA"), AV13ProductServiceId_Data);
               /* Read saved values. */
               Z64Supplier_GenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z64Supplier_GenId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z65Supplier_GenKvKNumber = cgiGet( "Z65Supplier_GenKvKNumber");
               Z66Supplier_GenCompanyName = cgiGet( "Z66Supplier_GenCompanyName");
               Z67Supplier_GenVisitingAddress = cgiGet( "Z67Supplier_GenVisitingAddress");
               n67Supplier_GenVisitingAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A67Supplier_GenVisitingAddress)) ? true : false);
               Z68Supplier_GenPostalAddress = cgiGet( "Z68Supplier_GenPostalAddress");
               n68Supplier_GenPostalAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A68Supplier_GenPostalAddress)) ? true : false);
               Z69Supplier_GenContactName = cgiGet( "Z69Supplier_GenContactName");
               n69Supplier_GenContactName = (String.IsNullOrEmpty(StringUtil.RTrim( A69Supplier_GenContactName)) ? true : false);
               Z70Supplier_GenContactPhone = cgiGet( "Z70Supplier_GenContactPhone");
               n70Supplier_GenContactPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A70Supplier_GenContactPhone)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_58 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_58"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV22TabsActivePage = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vTABSACTIVEPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "vMODE");
               AV20CheckRequiredFieldsResult = StringUtil.StrToBool( cgiGet( "vCHECKREQUIREDFIELDSRESULT"));
               AV7Supplier_GenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vSUPPLIER_GENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A74ProductServiceName = cgiGet( "PRODUCTSERVICENAME");
               A40000ProductServicePicture_GXI = cgiGet( "PRODUCTSERVICEPICTURE_GXI");
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
               A65Supplier_GenKvKNumber = cgiGet( edtSupplier_GenKvKNumber_Internalname);
               AssignAttri("", false, "A65Supplier_GenKvKNumber", A65Supplier_GenKvKNumber);
               A66Supplier_GenCompanyName = cgiGet( edtSupplier_GenCompanyName_Internalname);
               AssignAttri("", false, "A66Supplier_GenCompanyName", A66Supplier_GenCompanyName);
               A70Supplier_GenContactPhone = cgiGet( edtSupplier_GenContactPhone_Internalname);
               n70Supplier_GenContactPhone = false;
               AssignAttri("", false, "A70Supplier_GenContactPhone", A70Supplier_GenContactPhone);
               n70Supplier_GenContactPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A70Supplier_GenContactPhone)) ? true : false);
               A69Supplier_GenContactName = cgiGet( edtSupplier_GenContactName_Internalname);
               n69Supplier_GenContactName = false;
               AssignAttri("", false, "A69Supplier_GenContactName", A69Supplier_GenContactName);
               n69Supplier_GenContactName = (String.IsNullOrEmpty(StringUtil.RTrim( A69Supplier_GenContactName)) ? true : false);
               A67Supplier_GenVisitingAddress = cgiGet( edtSupplier_GenVisitingAddress_Internalname);
               n67Supplier_GenVisitingAddress = false;
               AssignAttri("", false, "A67Supplier_GenVisitingAddress", A67Supplier_GenVisitingAddress);
               n67Supplier_GenVisitingAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A67Supplier_GenVisitingAddress)) ? true : false);
               A68Supplier_GenPostalAddress = cgiGet( edtSupplier_GenPostalAddress_Internalname);
               n68Supplier_GenPostalAddress = false;
               AssignAttri("", false, "A68Supplier_GenPostalAddress", A68Supplier_GenPostalAddress);
               n68Supplier_GenPostalAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A68Supplier_GenPostalAddress)) ? true : false);
               A64Supplier_GenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplier_GenId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Supplier_Gen");
               A64Supplier_GenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplier_GenId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
               forbiddenHiddens.Add("Supplier_GenId", context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A64Supplier_GenId != Z64Supplier_GenId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("supplier_gen:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A64Supplier_GenId = (short)(Math.Round(NumberUtil.Val( GetPar( "Supplier_GenId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUPPLIER_GENID");
                        AnyError = 1;
                        GX_FocusControl = edtSupplier_GenId_Internalname;
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
                           E13042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E14042 ();
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
            E14042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll049( ) ;
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
            DisableAttributes049( ) ;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls049( ) ;
            }
            else
            {
               CheckExtendedTable049( ) ;
               CloseExtendedTableCursors049( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode9 = Gx_mode;
            CONFIRM_0414( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode9;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0414( )
      {
         nGXsfl_58_idx = 0;
         while ( nGXsfl_58_idx < nRC_GXsfl_58 )
         {
            ReadRow0414( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               GetKey0414( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  if ( RcdFound14 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0414( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0414( ) ;
                        CloseExtendedTableCursors0414( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_58_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( nRcdDeleted_14 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0414( ) ;
                        Load0414( ) ;
                        BeforeValidate0414( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0414( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0414( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0414( ) ;
                              CloseExtendedTableCursors0414( ) ;
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
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_58_idx;
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
            ChangePostValue( "ZT_"+"Z73ProductServiceId_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_14_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_14_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_14_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Horizontalalignment", StringUtil.RTrim( edtProductServiceId_Horizontalalignment)) ;
               ChangePostValue( "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEQUANTITY_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEPICTURE_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServicePicture_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICETYPEID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICETYPENAME_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption040( )
      {
      }

      protected void E13042( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         divTablemain_Width = 900;
         AssignProp("", false, divTablemain_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablemain_Width), 9, 0), true);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            Wizard_steps_Tabsinternalname = "GXUITabsPanel_Steps";
            ucWizard_steps.SendProperty(context, "", false, Wizard_steps_Internalname, "TabsInternalName", Wizard_steps_Tabsinternalname);
            if ( StringUtil.StrCmp(AV21HTTPRequest.Method, "GET") == 0 )
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV18GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV19GAMErrors);
         Combo_productserviceid_Gamoauthtoken = AV18GAMSession.gxTpr_Token;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "GAMOAuthToken", Combo_productserviceid_Gamoauthtoken);
         Combo_productserviceid_Titlecontrolidtoreplace = edtProductServiceId_Internalname;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "TitleControlIdToReplace", Combo_productserviceid_Titlecontrolidtoreplace);
         edtProductServiceId_Horizontalalignment = "Left";
         AssignProp("", false, edtProductServiceId_Internalname, "Horizontalalignment", edtProductServiceId_Horizontalalignment, !bGXsfl_58_Refreshing);
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtSupplier_GenId_Visible = 0;
         AssignProp("", false, edtSupplier_GenId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_GenId_Visible), 5, 0), true);
      }

      protected void E14042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("supplier_genww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'UPDATE WIZARD STEPS BUTTONS VISIBILITY' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            bttBtnwizardprevious_Visible = (((Gxuitabspanel_steps_Activepage!=1)) ? 1 : 0);
            AssignProp("", false, bttBtnwizardprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardprevious_Visible), 5, 0), true);
            bttBtntrn_cancel_Visible = (((Gxuitabspanel_steps_Activepage==1)) ? 1 : 0);
            AssignProp("", false, bttBtntrn_cancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_cancel_Visible), 5, 0), true);
            bttBtnwizardnext_Visible = (((Gxuitabspanel_steps_Activepage!=2)) ? 1 : 0);
            AssignProp("", false, bttBtnwizardnext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardnext_Visible), 5, 0), true);
            bttBtntrn_enter_Visible = (((Gxuitabspanel_steps_Activepage==2)) ? 1 : 0);
            AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'CHECKREQUIREDFIELDS_TABGENERAL' Routine */
         returnInSub = false;
         AV20CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV20CheckRequiredFieldsResult", AV20CheckRequiredFieldsResult);
      }

      protected void ZM049( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z65Supplier_GenKvKNumber = T00047_A65Supplier_GenKvKNumber[0];
               Z66Supplier_GenCompanyName = T00047_A66Supplier_GenCompanyName[0];
               Z67Supplier_GenVisitingAddress = T00047_A67Supplier_GenVisitingAddress[0];
               Z68Supplier_GenPostalAddress = T00047_A68Supplier_GenPostalAddress[0];
               Z69Supplier_GenContactName = T00047_A69Supplier_GenContactName[0];
               Z70Supplier_GenContactPhone = T00047_A70Supplier_GenContactPhone[0];
            }
            else
            {
               Z65Supplier_GenKvKNumber = A65Supplier_GenKvKNumber;
               Z66Supplier_GenCompanyName = A66Supplier_GenCompanyName;
               Z67Supplier_GenVisitingAddress = A67Supplier_GenVisitingAddress;
               Z68Supplier_GenPostalAddress = A68Supplier_GenPostalAddress;
               Z69Supplier_GenContactName = A69Supplier_GenContactName;
               Z70Supplier_GenContactPhone = A70Supplier_GenContactPhone;
            }
         }
         if ( GX_JID == -7 )
         {
            Z64Supplier_GenId = A64Supplier_GenId;
            Z65Supplier_GenKvKNumber = A65Supplier_GenKvKNumber;
            Z66Supplier_GenCompanyName = A66Supplier_GenCompanyName;
            Z67Supplier_GenVisitingAddress = A67Supplier_GenVisitingAddress;
            Z68Supplier_GenPostalAddress = A68Supplier_GenPostalAddress;
            Z69Supplier_GenContactName = A69Supplier_GenContactName;
            Z70Supplier_GenContactPhone = A70Supplier_GenContactPhone;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSupplier_GenId_Enabled = 0;
         AssignProp("", false, edtSupplier_GenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenId_Enabled), 5, 0), true);
         edtSupplier_GenId_Enabled = 0;
         AssignProp("", false, edtSupplier_GenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7Supplier_GenId) )
         {
            A64Supplier_GenId = AV7Supplier_GenId;
            AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
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

      protected void Load049( )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound9 = 1;
            A65Supplier_GenKvKNumber = T00048_A65Supplier_GenKvKNumber[0];
            AssignAttri("", false, "A65Supplier_GenKvKNumber", A65Supplier_GenKvKNumber);
            A66Supplier_GenCompanyName = T00048_A66Supplier_GenCompanyName[0];
            AssignAttri("", false, "A66Supplier_GenCompanyName", A66Supplier_GenCompanyName);
            A67Supplier_GenVisitingAddress = T00048_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = T00048_n67Supplier_GenVisitingAddress[0];
            AssignAttri("", false, "A67Supplier_GenVisitingAddress", A67Supplier_GenVisitingAddress);
            A68Supplier_GenPostalAddress = T00048_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = T00048_n68Supplier_GenPostalAddress[0];
            AssignAttri("", false, "A68Supplier_GenPostalAddress", A68Supplier_GenPostalAddress);
            A69Supplier_GenContactName = T00048_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = T00048_n69Supplier_GenContactName[0];
            AssignAttri("", false, "A69Supplier_GenContactName", A69Supplier_GenContactName);
            A70Supplier_GenContactPhone = T00048_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = T00048_n70Supplier_GenContactPhone[0];
            AssignAttri("", false, "A70Supplier_GenContactPhone", A70Supplier_GenContactPhone);
            ZM049( -7) ;
         }
         pr_default.close(6);
         OnLoadActions049( ) ;
      }

      protected void OnLoadActions049( )
      {
      }

      protected void CheckExtendedTable049( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65Supplier_GenKvKNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier_Gen Kv KNumber", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIER_GENKVKNUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplier_GenKvKNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A66Supplier_GenCompanyName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier_Gen Company Name", ""), "", "", "", "", "", "", "", ""), 1, "SUPPLIER_GENCOMPANYNAME");
            AnyError = 1;
            GX_FocusControl = edtSupplier_GenCompanyName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors049( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey049( )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM049( 7) ;
            RcdFound9 = 1;
            A64Supplier_GenId = T00047_A64Supplier_GenId[0];
            AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
            A65Supplier_GenKvKNumber = T00047_A65Supplier_GenKvKNumber[0];
            AssignAttri("", false, "A65Supplier_GenKvKNumber", A65Supplier_GenKvKNumber);
            A66Supplier_GenCompanyName = T00047_A66Supplier_GenCompanyName[0];
            AssignAttri("", false, "A66Supplier_GenCompanyName", A66Supplier_GenCompanyName);
            A67Supplier_GenVisitingAddress = T00047_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = T00047_n67Supplier_GenVisitingAddress[0];
            AssignAttri("", false, "A67Supplier_GenVisitingAddress", A67Supplier_GenVisitingAddress);
            A68Supplier_GenPostalAddress = T00047_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = T00047_n68Supplier_GenPostalAddress[0];
            AssignAttri("", false, "A68Supplier_GenPostalAddress", A68Supplier_GenPostalAddress);
            A69Supplier_GenContactName = T00047_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = T00047_n69Supplier_GenContactName[0];
            AssignAttri("", false, "A69Supplier_GenContactName", A69Supplier_GenContactName);
            A70Supplier_GenContactPhone = T00047_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = T00047_n70Supplier_GenContactPhone[0];
            AssignAttri("", false, "A70Supplier_GenContactPhone", A70Supplier_GenContactPhone);
            Z64Supplier_GenId = A64Supplier_GenId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load049( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey049( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey049( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey049( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000410_A64Supplier_GenId[0] < A64Supplier_GenId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000410_A64Supplier_GenId[0] > A64Supplier_GenId ) ) )
            {
               A64Supplier_GenId = T000410_A64Supplier_GenId[0];
               AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000411_A64Supplier_GenId[0] > A64Supplier_GenId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000411_A64Supplier_GenId[0] < A64Supplier_GenId ) ) )
            {
               A64Supplier_GenId = T000411_A64Supplier_GenId[0];
               AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey049( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupplier_GenKvKNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert049( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A64Supplier_GenId != Z64Supplier_GenId )
               {
                  A64Supplier_GenId = Z64Supplier_GenId;
                  AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPLIER_GENID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplier_GenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplier_GenKvKNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update049( ) ;
                  GX_FocusControl = edtSupplier_GenKvKNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A64Supplier_GenId != Z64Supplier_GenId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSupplier_GenKvKNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert049( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPLIER_GENID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplier_GenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSupplier_GenKvKNumber_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert049( ) ;
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
         if ( A64Supplier_GenId != Z64Supplier_GenId )
         {
            A64Supplier_GenId = Z64Supplier_GenId;
            AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPLIER_GENID");
            AnyError = 1;
            GX_FocusControl = edtSupplier_GenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplier_GenKvKNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency049( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00046 */
            pr_default.execute(4, new Object[] {A64Supplier_GenId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier_Gen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z65Supplier_GenKvKNumber, T00046_A65Supplier_GenKvKNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z66Supplier_GenCompanyName, T00046_A66Supplier_GenCompanyName[0]) != 0 ) || ( StringUtil.StrCmp(Z67Supplier_GenVisitingAddress, T00046_A67Supplier_GenVisitingAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z68Supplier_GenPostalAddress, T00046_A68Supplier_GenPostalAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z69Supplier_GenContactName, T00046_A69Supplier_GenContactName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z70Supplier_GenContactPhone, T00046_A70Supplier_GenContactPhone[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z65Supplier_GenKvKNumber, T00046_A65Supplier_GenKvKNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier_gen:[seudo value changed for attri]"+"Supplier_GenKvKNumber");
                  GXUtil.WriteLogRaw("Old: ",Z65Supplier_GenKvKNumber);
                  GXUtil.WriteLogRaw("Current: ",T00046_A65Supplier_GenKvKNumber[0]);
               }
               if ( StringUtil.StrCmp(Z66Supplier_GenCompanyName, T00046_A66Supplier_GenCompanyName[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier_gen:[seudo value changed for attri]"+"Supplier_GenCompanyName");
                  GXUtil.WriteLogRaw("Old: ",Z66Supplier_GenCompanyName);
                  GXUtil.WriteLogRaw("Current: ",T00046_A66Supplier_GenCompanyName[0]);
               }
               if ( StringUtil.StrCmp(Z67Supplier_GenVisitingAddress, T00046_A67Supplier_GenVisitingAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier_gen:[seudo value changed for attri]"+"Supplier_GenVisitingAddress");
                  GXUtil.WriteLogRaw("Old: ",Z67Supplier_GenVisitingAddress);
                  GXUtil.WriteLogRaw("Current: ",T00046_A67Supplier_GenVisitingAddress[0]);
               }
               if ( StringUtil.StrCmp(Z68Supplier_GenPostalAddress, T00046_A68Supplier_GenPostalAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier_gen:[seudo value changed for attri]"+"Supplier_GenPostalAddress");
                  GXUtil.WriteLogRaw("Old: ",Z68Supplier_GenPostalAddress);
                  GXUtil.WriteLogRaw("Current: ",T00046_A68Supplier_GenPostalAddress[0]);
               }
               if ( StringUtil.StrCmp(Z69Supplier_GenContactName, T00046_A69Supplier_GenContactName[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier_gen:[seudo value changed for attri]"+"Supplier_GenContactName");
                  GXUtil.WriteLogRaw("Old: ",Z69Supplier_GenContactName);
                  GXUtil.WriteLogRaw("Current: ",T00046_A69Supplier_GenContactName[0]);
               }
               if ( StringUtil.StrCmp(Z70Supplier_GenContactPhone, T00046_A70Supplier_GenContactPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier_gen:[seudo value changed for attri]"+"Supplier_GenContactPhone");
                  GXUtil.WriteLogRaw("Old: ",Z70Supplier_GenContactPhone);
                  GXUtil.WriteLogRaw("Current: ",T00046_A70Supplier_GenContactPhone[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Supplier_Gen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert049( )
      {
         if ( ! IsAuthorized("supplier_gen_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable049( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM049( 0) ;
            CheckOptimisticConcurrency049( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm049( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert049( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000412 */
                     pr_default.execute(10, new Object[] {A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, n67Supplier_GenVisitingAddress, A67Supplier_GenVisitingAddress, n68Supplier_GenPostalAddress, A68Supplier_GenPostalAddress, n69Supplier_GenContactName, A69Supplier_GenContactName, n70Supplier_GenContactPhone, A70Supplier_GenContactPhone});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000413 */
                     pr_default.execute(11);
                     A64Supplier_GenId = T000413_A64Supplier_GenId[0];
                     AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_Gen");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel049( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption040( ) ;
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
               Load049( ) ;
            }
            EndLevel049( ) ;
         }
         CloseExtendedTableCursors049( ) ;
      }

      protected void Update049( )
      {
         if ( ! IsAuthorized("supplier_gen_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable049( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency049( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm049( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate049( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000414 */
                     pr_default.execute(12, new Object[] {A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, n67Supplier_GenVisitingAddress, A67Supplier_GenVisitingAddress, n68Supplier_GenPostalAddress, A68Supplier_GenPostalAddress, n69Supplier_GenContactName, A69Supplier_GenContactName, n70Supplier_GenContactPhone, A70Supplier_GenContactPhone, A64Supplier_GenId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_Gen");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier_Gen"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate049( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel049( ) ;
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
            EndLevel049( ) ;
         }
         CloseExtendedTableCursors049( ) ;
      }

      protected void DeferredUpdate049( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("supplier_gen_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency049( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls049( ) ;
            AfterConfirm049( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete049( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0414( ) ;
                  while ( RcdFound14 != 0 )
                  {
                     getByPrimaryKey0414( ) ;
                     Delete0414( ) ;
                     ScanNext0414( ) ;
                  }
                  ScanEnd0414( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000415 */
                     pr_default.execute(13, new Object[] {A64Supplier_GenId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_Gen");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel049( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls049( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000416 */
            pr_default.execute(14, new Object[] {A64Supplier_GenId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Supplier_Gen", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel0414( )
      {
         nGXsfl_58_idx = 0;
         while ( nGXsfl_58_idx < nRC_GXsfl_58 )
         {
            ReadRow0414( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               standaloneNotModal0414( ) ;
               GetKey0414( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0414( ) ;
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( ( nRcdDeleted_14 != 0 ) && ( nRcdExists_14 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0414( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0414( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_58_idx;
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
            ChangePostValue( "ZT_"+"Z73ProductServiceId_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_14_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_14_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_14_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Horizontalalignment", StringUtil.RTrim( edtProductServiceId_Horizontalalignment)) ;
               ChangePostValue( "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEQUANTITY_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEPICTURE_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServicePicture_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICETYPEID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICETYPENAME_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0414( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_14 = 0;
         nIsMod_14 = 0;
         nRcdDeleted_14 = 0;
      }

      protected void ProcessLevel049( )
      {
         /* Save parent mode. */
         sMode9 = Gx_mode;
         ProcessNestedLevel0414( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel049( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete049( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("supplier_gen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("supplier_gen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart049( )
      {
         /* Scan By routine */
         /* Using cursor T000417 */
         pr_default.execute(15);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound9 = 1;
            A64Supplier_GenId = T000417_A64Supplier_GenId[0];
            AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext049( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound9 = 1;
            A64Supplier_GenId = T000417_A64Supplier_GenId[0];
            AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
         }
      }

      protected void ScanEnd049( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm049( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert049( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate049( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete049( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete049( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate049( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes049( )
      {
         edtSupplier_GenKvKNumber_Enabled = 0;
         AssignProp("", false, edtSupplier_GenKvKNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenKvKNumber_Enabled), 5, 0), true);
         edtSupplier_GenCompanyName_Enabled = 0;
         AssignProp("", false, edtSupplier_GenCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenCompanyName_Enabled), 5, 0), true);
         edtSupplier_GenContactPhone_Enabled = 0;
         AssignProp("", false, edtSupplier_GenContactPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenContactPhone_Enabled), 5, 0), true);
         edtSupplier_GenContactName_Enabled = 0;
         AssignProp("", false, edtSupplier_GenContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenContactName_Enabled), 5, 0), true);
         edtSupplier_GenVisitingAddress_Enabled = 0;
         AssignProp("", false, edtSupplier_GenVisitingAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenVisitingAddress_Enabled), 5, 0), true);
         edtSupplier_GenPostalAddress_Enabled = 0;
         AssignProp("", false, edtSupplier_GenPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenPostalAddress_Enabled), 5, 0), true);
         edtSupplier_GenId_Enabled = 0;
         AssignProp("", false, edtSupplier_GenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_GenId_Enabled), 5, 0), true);
      }

      protected void ZM0414( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -8 )
         {
            Z64Supplier_GenId = A64Supplier_GenId;
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

      protected void standaloneNotModal0414( )
      {
         edtProductServiceQuantity_Enabled = 0;
         AssignProp("", false, edtProductServiceQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceQuantity_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtProductServiceTypeId_Enabled = 0;
         AssignProp("", false, edtProductServiceTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
      }

      protected void standaloneModal0414( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductServiceId_Enabled = 0;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         }
         else
         {
            edtProductServiceId_Enabled = 1;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         }
      }

      protected void Load0414( )
      {
         /* Using cursor T000418 */
         pr_default.execute(16, new Object[] {A64Supplier_GenId, A73ProductServiceId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound14 = 1;
            A74ProductServiceName = T000418_A74ProductServiceName[0];
            A75ProductServiceDescription = T000418_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = T000418_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = T000418_A40000ProductServicePicture_GXI[0];
            AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
            AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            A72ProductServiceTypeName = T000418_A72ProductServiceTypeName[0];
            A71ProductServiceTypeId = T000418_A71ProductServiceTypeId[0];
            A77ProductServicePicture = T000418_A77ProductServicePicture[0];
            AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
            AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            ZM0414( -8) ;
         }
         pr_default.close(16);
         OnLoadActions0414( ) ;
      }

      protected void OnLoadActions0414( )
      {
      }

      protected void CheckExtendedTable0414( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         standaloneModal0414( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_58_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A74ProductServiceName = T00044_A74ProductServiceName[0];
         A75ProductServiceDescription = T00044_A75ProductServiceDescription[0];
         A76ProductServiceQuantity = T00044_A76ProductServiceQuantity[0];
         A40000ProductServicePicture_GXI = T00044_A40000ProductServicePicture_GXI[0];
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A71ProductServiceTypeId = T00044_A71ProductServiceTypeId[0];
         A77ProductServicePicture = T00044_A77ProductServicePicture[0];
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         pr_default.close(2);
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "PRODUCTSERVICETYPEID_" + sGXsfl_58_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A72ProductServiceTypeName = T00045_A72ProductServiceTypeName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0414( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0414( )
      {
      }

      protected void gxLoad_9( short A73ProductServiceId )
      {
         /* Using cursor T000419 */
         pr_default.execute(17, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_58_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A74ProductServiceName = T000419_A74ProductServiceName[0];
         A75ProductServiceDescription = T000419_A75ProductServiceDescription[0];
         A76ProductServiceQuantity = T000419_A76ProductServiceQuantity[0];
         A40000ProductServicePicture_GXI = T000419_A40000ProductServicePicture_GXI[0];
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A71ProductServiceTypeId = T000419_A71ProductServiceTypeId[0];
         A77ProductServicePicture = T000419_A77ProductServicePicture[0];
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A74ProductServiceName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A75ProductServiceDescription)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A77ProductServicePicture)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000ProductServicePicture_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_10( short A71ProductServiceTypeId )
      {
         /* Using cursor T000420 */
         pr_default.execute(18, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GXCCtl = "PRODUCTSERVICETYPEID_" + sGXsfl_58_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A72ProductServiceTypeName = T000420_A72ProductServiceTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A72ProductServiceTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void GetKey0414( )
      {
         /* Using cursor T000421 */
         pr_default.execute(19, new Object[] {A64Supplier_GenId, A73ProductServiceId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey0414( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A64Supplier_GenId, A73ProductServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0414( 8) ;
            RcdFound14 = 1;
            InitializeNonKey0414( ) ;
            A73ProductServiceId = T00043_A73ProductServiceId[0];
            Z64Supplier_GenId = A64Supplier_GenId;
            Z73ProductServiceId = A73ProductServiceId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0414( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0414( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0414( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0414( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0414( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A64Supplier_GenId, A73ProductServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier_GenProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Supplier_GenProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0414( )
      {
         if ( ! IsAuthorized("supplier_gen_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0414( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0414( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0414( 0) ;
            CheckOptimisticConcurrency0414( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0414( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0414( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000422 */
                     pr_default.execute(20, new Object[] {A64Supplier_GenId, A73ProductServiceId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_GenProductService");
                     if ( (pr_default.getStatus(20) == 1) )
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
               Load0414( ) ;
            }
            EndLevel0414( ) ;
         }
         CloseExtendedTableCursors0414( ) ;
      }

      protected void Update0414( )
      {
         if ( ! IsAuthorized("supplier_gen_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0414( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0414( ) ;
         }
         if ( ( nIsMod_14 != 0 ) || ( nIsDirty_14 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0414( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0414( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0414( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table Supplier_GenProductService */
                        DeferredUpdate0414( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0414( ) ;
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
               EndLevel0414( ) ;
            }
         }
         CloseExtendedTableCursors0414( ) ;
      }

      protected void DeferredUpdate0414( )
      {
      }

      protected void Delete0414( )
      {
         if ( ! IsAuthorized("supplier_gen_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0414( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0414( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0414( ) ;
            AfterConfirm0414( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0414( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000423 */
                  pr_default.execute(21, new Object[] {A64Supplier_GenId, A73ProductServiceId});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("Supplier_GenProductService");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0414( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0414( )
      {
         standaloneModal0414( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000424 */
            pr_default.execute(22, new Object[] {A73ProductServiceId});
            A74ProductServiceName = T000424_A74ProductServiceName[0];
            A75ProductServiceDescription = T000424_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = T000424_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = T000424_A40000ProductServicePicture_GXI[0];
            AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
            AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            A71ProductServiceTypeId = T000424_A71ProductServiceTypeId[0];
            A77ProductServicePicture = T000424_A77ProductServicePicture[0];
            AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
            AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            pr_default.close(22);
            /* Using cursor T000425 */
            pr_default.execute(23, new Object[] {A71ProductServiceTypeId});
            A72ProductServiceTypeName = T000425_A72ProductServiceTypeName[0];
            pr_default.close(23);
         }
      }

      protected void EndLevel0414( )
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

      public void ScanStart0414( )
      {
         /* Scan By routine */
         /* Using cursor T000426 */
         pr_default.execute(24, new Object[] {A64Supplier_GenId});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound14 = 1;
            A73ProductServiceId = T000426_A73ProductServiceId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0414( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound14 = 1;
            A73ProductServiceId = T000426_A73ProductServiceId[0];
         }
      }

      protected void ScanEnd0414( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm0414( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0414( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0414( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0414( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0414( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0414( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0414( )
      {
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtProductServiceDescription_Enabled = 0;
         AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtProductServiceQuantity_Enabled = 0;
         AssignProp("", false, edtProductServiceQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceQuantity_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtProductServicePicture_Enabled = 0;
         AssignProp("", false, edtProductServicePicture_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServicePicture_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtProductServiceTypeId_Enabled = 0;
         AssignProp("", false, edtProductServiceTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtProductServiceTypeName_Enabled = 0;
         AssignProp("", false, edtProductServiceTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeName_Enabled), 5, 0), !bGXsfl_58_Refreshing);
      }

      protected void send_integrity_lvl_hashes0414( )
      {
      }

      protected void send_integrity_lvl_hashes049( )
      {
      }

      protected void SubsflControlProps_5814( )
      {
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_58_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_58_idx;
         edtProductServiceQuantity_Internalname = "PRODUCTSERVICEQUANTITY_"+sGXsfl_58_idx;
         edtProductServicePicture_Internalname = "PRODUCTSERVICEPICTURE_"+sGXsfl_58_idx;
         edtProductServiceTypeId_Internalname = "PRODUCTSERVICETYPEID_"+sGXsfl_58_idx;
         edtProductServiceTypeName_Internalname = "PRODUCTSERVICETYPENAME_"+sGXsfl_58_idx;
      }

      protected void SubsflControlProps_fel_5814( )
      {
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_58_fel_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_58_fel_idx;
         edtProductServiceQuantity_Internalname = "PRODUCTSERVICEQUANTITY_"+sGXsfl_58_fel_idx;
         edtProductServicePicture_Internalname = "PRODUCTSERVICEPICTURE_"+sGXsfl_58_fel_idx;
         edtProductServiceTypeId_Internalname = "PRODUCTSERVICETYPEID_"+sGXsfl_58_fel_idx;
         edtProductServiceTypeName_Internalname = "PRODUCTSERVICETYPENAME_"+sGXsfl_58_fel_idx;
      }

      protected void AddRow0414( )
      {
         nGXsfl_58_idx = (int)(nGXsfl_58_idx+1);
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_5814( ) ;
         SendRow0414( ) ;
      }

      protected void SendRow0414( )
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
            if ( ((int)((nGXsfl_58_idx) % (2))) == 0 )
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
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_58_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_58_idx + "',58)\"";
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A73ProductServiceId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProductServiceId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)58,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)edtProductServiceId_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_58_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_58_idx + "',58)\"";
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceDescription_Internalname,(string)A75ProductServiceDescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProductServiceDescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)58,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProductServiceQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A76ProductServiceQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A76ProductServiceQuantity), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtProductServiceQuantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)58,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_58_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_58_idx + "',58)\"";
         ClassString = "Attribute";
         StyleString = "";
         A77ProductServicePicture_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServicePicture_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.PathToRelativeUrl( A77ProductServicePicture));
         Gridlevel_productserviceRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServicePicture_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtProductServicePicture_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"",(string)"",(string)"",(short)0,(bool)A77ProductServicePicture_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         AssignProp("", false, edtProductServicePicture_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.PathToRelativeUrl( A77ProductServicePicture)), !bGXsfl_58_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "IsBlob", StringUtil.BoolToStr( A77ProductServicePicture_IsBlob), !bGXsfl_58_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProductServiceTypeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A71ProductServiceTypeId), "ZZZ9") : context.localUtil.Format( (decimal)(A71ProductServiceTypeId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtProductServiceTypeId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)58,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_58_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_58_idx + "',58)\"";
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceTypeName_Internalname,(string)A72ProductServiceTypeName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProductServiceTypeName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)58,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_productserviceRow);
         send_integrity_lvl_hashes0414( ) ;
         GXCCtl = "Z73ProductServiceId_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_14_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_14_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_58_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_58_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV20CheckRequiredFieldsResult);
         GXCCtl = "vSUPPLIER_GENID_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "PRODUCTSERVICEPICTURE_" + sGXsfl_58_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A77ProductServicePicture);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Horizontalalignment", StringUtil.RTrim( edtProductServiceId_Horizontalalignment));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceDescription_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEQUANTITY_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceQuantity_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEPICTURE_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServicePicture_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICETYPEID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICETYPENAME_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeName_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_productserviceContainer.AddRow(Gridlevel_productserviceRow);
      }

      protected void ReadRow0414( )
      {
         nGXsfl_58_idx = (int)(nGXsfl_58_idx+1);
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_5814( ) ;
         edtProductServiceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServiceId_Horizontalalignment = cgiGet( "PRODUCTSERVICEID_"+sGXsfl_58_idx+"Horizontalalignment");
         edtProductServiceDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServiceQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEQUANTITY_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServicePicture_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEPICTURE_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServiceTypeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICETYPEID_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServiceTypeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICETYPENAME_"+sGXsfl_58_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductServiceId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductServiceId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_58_idx;
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
         GXCCtl = "Z73ProductServiceId_" + sGXsfl_58_idx;
         Z73ProductServiceId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_58_idx;
         nRcdDeleted_14 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_14_" + sGXsfl_58_idx;
         nRcdExists_14 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_14_" + sGXsfl_58_idx;
         nIsMod_14 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtProductServicePicture_Internalname, ref  A77ProductServicePicture, ref  A40000ProductServicePicture_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtProductServiceTypeId_Enabled = edtProductServiceTypeId_Enabled;
         defedtProductServiceQuantity_Enabled = edtProductServiceQuantity_Enabled;
         defedtProductServiceId_Enabled = edtProductServiceId_Enabled;
      }

      protected void ConfirmValues040( )
      {
         nGXsfl_58_idx = 0;
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_5814( ) ;
         while ( nGXsfl_58_idx < nRC_GXsfl_58 )
         {
            nGXsfl_58_idx = (int)(nGXsfl_58_idx+1);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
            SubsflControlProps_5814( ) ;
            ChangePostValue( "Z73ProductServiceId_"+sGXsfl_58_idx, cgiGet( "ZT_"+"Z73ProductServiceId_"+sGXsfl_58_idx)) ;
            DeletePostValue( "ZT_"+"Z73ProductServiceId_"+sGXsfl_58_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("supplier_gen.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7Supplier_GenId,4,0))}, new string[] {"Gx_mode","Supplier_GenId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Supplier_Gen");
         forbiddenHiddens.Add("Supplier_GenId", context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("supplier_gen:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z64Supplier_GenId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z65Supplier_GenKvKNumber", Z65Supplier_GenKvKNumber);
         GxWebStd.gx_hidden_field( context, "Z66Supplier_GenCompanyName", Z66Supplier_GenCompanyName);
         GxWebStd.gx_hidden_field( context, "Z67Supplier_GenVisitingAddress", Z67Supplier_GenVisitingAddress);
         GxWebStd.gx_hidden_field( context, "Z68Supplier_GenPostalAddress", Z68Supplier_GenPostalAddress);
         GxWebStd.gx_hidden_field( context, "Z69Supplier_GenContactName", Z69Supplier_GenContactName);
         GxWebStd.gx_hidden_field( context, "Z70Supplier_GenContactPhone", StringUtil.RTrim( Z70Supplier_GenContactPhone));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_58", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_58_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSERVICEID_DATA", AV13ProductServiceId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSERVICEID_DATA", AV13ProductServiceId_Data);
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
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV20CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vTABSACTIVEPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TabsActivePage), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vSUPPLIER_GENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIER_GENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Supplier_GenId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICENAME", A74ProductServiceName);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEPICTURE_GXI", A40000ProductServicePicture_GXI);
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
         return formatLink("supplier_gen.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7Supplier_GenId,4,0))}, new string[] {"Gx_mode","Supplier_GenId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Supplier_Gen" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "General Suppliers", "") ;
      }

      protected void InitializeNonKey049( )
      {
         A65Supplier_GenKvKNumber = "";
         AssignAttri("", false, "A65Supplier_GenKvKNumber", A65Supplier_GenKvKNumber);
         A66Supplier_GenCompanyName = "";
         AssignAttri("", false, "A66Supplier_GenCompanyName", A66Supplier_GenCompanyName);
         A67Supplier_GenVisitingAddress = "";
         n67Supplier_GenVisitingAddress = false;
         AssignAttri("", false, "A67Supplier_GenVisitingAddress", A67Supplier_GenVisitingAddress);
         n67Supplier_GenVisitingAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A67Supplier_GenVisitingAddress)) ? true : false);
         A68Supplier_GenPostalAddress = "";
         n68Supplier_GenPostalAddress = false;
         AssignAttri("", false, "A68Supplier_GenPostalAddress", A68Supplier_GenPostalAddress);
         n68Supplier_GenPostalAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A68Supplier_GenPostalAddress)) ? true : false);
         A69Supplier_GenContactName = "";
         n69Supplier_GenContactName = false;
         AssignAttri("", false, "A69Supplier_GenContactName", A69Supplier_GenContactName);
         n69Supplier_GenContactName = (String.IsNullOrEmpty(StringUtil.RTrim( A69Supplier_GenContactName)) ? true : false);
         A70Supplier_GenContactPhone = "";
         n70Supplier_GenContactPhone = false;
         AssignAttri("", false, "A70Supplier_GenContactPhone", A70Supplier_GenContactPhone);
         n70Supplier_GenContactPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A70Supplier_GenContactPhone)) ? true : false);
         Z65Supplier_GenKvKNumber = "";
         Z66Supplier_GenCompanyName = "";
         Z67Supplier_GenVisitingAddress = "";
         Z68Supplier_GenPostalAddress = "";
         Z69Supplier_GenContactName = "";
         Z70Supplier_GenContactPhone = "";
      }

      protected void InitAll049( )
      {
         A64Supplier_GenId = 0;
         AssignAttri("", false, "A64Supplier_GenId", StringUtil.LTrimStr( (decimal)(A64Supplier_GenId), 4, 0));
         InitializeNonKey049( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0414( )
      {
         A74ProductServiceName = "";
         AssignAttri("", false, "A74ProductServiceName", A74ProductServiceName);
         A75ProductServiceDescription = "";
         A76ProductServiceQuantity = 0;
         A77ProductServicePicture = "";
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A40000ProductServicePicture_GXI = "";
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_58_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A71ProductServiceTypeId = 0;
         A72ProductServiceTypeName = "";
      }

      protected void InitAll0414( )
      {
         A73ProductServiceId = 0;
         InitializeNonKey0414( ) ;
      }

      protected void StandaloneModalInsert0414( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315523470", true, true);
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
         context.AddJavascriptSource("supplier_gen.js", "?202491315523473", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVTabsTransform/DVTabsTransformRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties14( )
      {
         edtProductServiceTypeId_Enabled = defedtProductServiceTypeId_Enabled;
         AssignProp("", false, edtProductServiceTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtProductServiceQuantity_Enabled = defedtProductServiceQuantity_Enabled;
         AssignProp("", false, edtProductServiceQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceQuantity_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtProductServiceId_Enabled = defedtProductServiceId_Enabled;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
      }

      protected void StartGridControl58( )
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
         edtSupplier_GenKvKNumber_Internalname = "SUPPLIER_GENKVKNUMBER";
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME";
         edtSupplier_GenContactPhone_Internalname = "SUPPLIER_GENCONTACTPHONE";
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME";
         edtSupplier_GenVisitingAddress_Internalname = "SUPPLIER_GENVISITINGADDRESS";
         edtSupplier_GenPostalAddress_Internalname = "SUPPLIER_GENPOSTALADDRESS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
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
         Combo_productserviceid_Internalname = "COMBO_PRODUCTSERVICEID";
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID";
         Wizard_steps_Internalname = "WIZARD_STEPS";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
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
         Combo_productserviceid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "General Suppliers", "");
         edtProductServiceTypeName_Jsonclick = "";
         edtProductServiceTypeId_Jsonclick = "";
         edtProductServiceQuantity_Jsonclick = "";
         edtProductServiceDescription_Jsonclick = "";
         edtProductServiceId_Jsonclick = "";
         subGridlevel_productservice_Class = "WorkWith";
         subGridlevel_productservice_Backcolorstyle = 0;
         Combo_productserviceid_Titlecontrolidtoreplace = "";
         Wizard_steps_Tabsinternalname = "";
         edtProductServiceTypeName_Enabled = 0;
         edtProductServiceTypeId_Enabled = 0;
         edtProductServicePicture_Enabled = 0;
         edtProductServiceQuantity_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtProductServiceId_Enabled = 1;
         edtSupplier_GenId_Jsonclick = "";
         edtSupplier_GenId_Enabled = 0;
         edtSupplier_GenId_Visible = 1;
         Combo_productserviceid_Emptyitem = Convert.ToBoolean( 0);
         Combo_productserviceid_Datalistprocparametersprefix = " \"ComboName\": \"ProductServiceId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"Supplier_GenId\": 0";
         Combo_productserviceid_Datalistproc = "Supplier_GenLoadDVCombo";
         Combo_productserviceid_Hasdescription = Convert.ToBoolean( -1);
         Combo_productserviceid_Isgriditem = Convert.ToBoolean( -1);
         Combo_productserviceid_Cls = "ExtendedCombo";
         Combo_productserviceid_Caption = "";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         bttBtnwizardnext_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtnwizardprevious_Visible = 1;
         edtSupplier_GenPostalAddress_Enabled = 1;
         edtSupplier_GenVisitingAddress_Enabled = 1;
         edtSupplier_GenContactName_Jsonclick = "";
         edtSupplier_GenContactName_Enabled = 1;
         edtSupplier_GenContactPhone_Jsonclick = "";
         edtSupplier_GenContactPhone_Enabled = 1;
         edtSupplier_GenCompanyName_Jsonclick = "";
         edtSupplier_GenCompanyName_Enabled = 1;
         edtSupplier_GenKvKNumber_Jsonclick = "";
         edtSupplier_GenKvKNumber_Enabled = 1;
         Gxuitabspanel_steps_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_steps_Class = "Tab";
         Gxuitabspanel_steps_Pagecount = 2;
         divTablemain_Width = 0;
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
         /* End function dynload_actions */
      }

      protected void gxnrGridlevel_productservice_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5814( ) ;
         while ( nGXsfl_58_idx <= nRC_GXsfl_58 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0414( ) ;
            standaloneModal0414( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0414( ) ;
            nGXsfl_58_idx = (int)(nGXsfl_58_idx+1);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
            SubsflControlProps_5814( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_productserviceContainer)) ;
         /* End function gxnrGridlevel_productservice_newrow */
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

      public void Valid_Productserviceid( )
      {
         /* Using cursor T000424 */
         pr_default.execute(22, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PRODUCTSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
         }
         A74ProductServiceName = T000424_A74ProductServiceName[0];
         A75ProductServiceDescription = T000424_A75ProductServiceDescription[0];
         A76ProductServiceQuantity = T000424_A76ProductServiceQuantity[0];
         A40000ProductServicePicture_GXI = T000424_A40000ProductServicePicture_GXI[0];
         A71ProductServiceTypeId = T000424_A71ProductServiceTypeId[0];
         A77ProductServicePicture = T000424_A77ProductServicePicture[0];
         pr_default.close(22);
         /* Using cursor T000425 */
         pr_default.execute(23, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
         }
         A72ProductServiceTypeName = T000425_A72ProductServiceTypeName[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A74ProductServiceName", A74ProductServiceName);
         AssignAttri("", false, "A75ProductServiceDescription", A75ProductServiceDescription);
         AssignAttri("", false, "A76ProductServiceQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, ".", "")));
         AssignAttri("", false, "A77ProductServicePicture", context.PathToRelativeUrl( A77ProductServicePicture));
         GXCCtl = "PRODUCTSERVICEPICTURE_" + sGXsfl_58_idx;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7Supplier_GenId","fld":"vSUPPLIER_GENID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7Supplier_GenId","fld":"vSUPPLIER_GENID","pic":"ZZZ9","hsh":true},{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E14042","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("'WIZARDNEXT'","""{"handler":"E12049","iparms":[{"av":"Gxuitabspanel_steps_Activepage","ctrl":"GXUITABSPANEL_STEPS","prop":"ActivePage"},{"av":"AV20CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]""");
         setEventMetadata("'WIZARDNEXT'",""","oparms":[{"av":"AV20CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E11049","iparms":[{"av":"Gxuitabspanel_steps_Activepage","ctrl":"GXUITABSPANEL_STEPS","prop":"ActivePage"}]}""");
         setEventMetadata("VALID_SUPPLIER_GENKVKNUMBER","""{"handler":"Valid_Supplier_genkvknumber","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIER_GENCOMPANYNAME","""{"handler":"Valid_Supplier_gencompanyname","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIER_GENID","""{"handler":"Valid_Supplier_genid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[{"av":"A73ProductServiceId","fld":"PRODUCTSERVICEID","pic":"ZZZ9"},{"av":"A71ProductServiceTypeId","fld":"PRODUCTSERVICETYPEID","pic":"ZZZ9"},{"av":"A74ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"A75ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION"},{"av":"A76ProductServiceQuantity","fld":"PRODUCTSERVICEQUANTITY","pic":"ZZZ9"},{"av":"A77ProductServicePicture","fld":"PRODUCTSERVICEPICTURE"},{"av":"A40000ProductServicePicture_GXI","fld":"PRODUCTSERVICEPICTURE_GXI"},{"av":"A72ProductServiceTypeName","fld":"PRODUCTSERVICETYPENAME"}]""");
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
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(5);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z65Supplier_GenKvKNumber = "";
         Z66Supplier_GenCompanyName = "";
         Z67Supplier_GenVisitingAddress = "";
         Z68Supplier_GenPostalAddress = "";
         Z69Supplier_GenContactName = "";
         Z70Supplier_GenContactPhone = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A65Supplier_GenKvKNumber = "";
         A66Supplier_GenCompanyName = "";
         gxphoneLink = "";
         A70Supplier_GenContactPhone = "";
         A69Supplier_GenContactName = "";
         A67Supplier_GenVisitingAddress = "";
         A68Supplier_GenPostalAddress = "";
         lblTablevel_productservice_title_Jsonclick = "";
         bttBtnwizardprevious_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtnwizardnext_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_productserviceid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13ProductServiceId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         ucWizard_steps = new GXUserControl();
         Gridlevel_productserviceContainer = new GXWebGrid( context);
         sMode14 = "";
         sStyleString = "";
         A74ProductServiceName = "";
         A40000ProductServicePicture_GXI = "";
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
         sMode9 = "";
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV21HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV19GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T00048_A64Supplier_GenId = new short[1] ;
         T00048_A65Supplier_GenKvKNumber = new string[] {""} ;
         T00048_A66Supplier_GenCompanyName = new string[] {""} ;
         T00048_A67Supplier_GenVisitingAddress = new string[] {""} ;
         T00048_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         T00048_A68Supplier_GenPostalAddress = new string[] {""} ;
         T00048_n68Supplier_GenPostalAddress = new bool[] {false} ;
         T00048_A69Supplier_GenContactName = new string[] {""} ;
         T00048_n69Supplier_GenContactName = new bool[] {false} ;
         T00048_A70Supplier_GenContactPhone = new string[] {""} ;
         T00048_n70Supplier_GenContactPhone = new bool[] {false} ;
         T00049_A64Supplier_GenId = new short[1] ;
         T00047_A64Supplier_GenId = new short[1] ;
         T00047_A65Supplier_GenKvKNumber = new string[] {""} ;
         T00047_A66Supplier_GenCompanyName = new string[] {""} ;
         T00047_A67Supplier_GenVisitingAddress = new string[] {""} ;
         T00047_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         T00047_A68Supplier_GenPostalAddress = new string[] {""} ;
         T00047_n68Supplier_GenPostalAddress = new bool[] {false} ;
         T00047_A69Supplier_GenContactName = new string[] {""} ;
         T00047_n69Supplier_GenContactName = new bool[] {false} ;
         T00047_A70Supplier_GenContactPhone = new string[] {""} ;
         T00047_n70Supplier_GenContactPhone = new bool[] {false} ;
         T000410_A64Supplier_GenId = new short[1] ;
         T000411_A64Supplier_GenId = new short[1] ;
         T00046_A64Supplier_GenId = new short[1] ;
         T00046_A65Supplier_GenKvKNumber = new string[] {""} ;
         T00046_A66Supplier_GenCompanyName = new string[] {""} ;
         T00046_A67Supplier_GenVisitingAddress = new string[] {""} ;
         T00046_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         T00046_A68Supplier_GenPostalAddress = new string[] {""} ;
         T00046_n68Supplier_GenPostalAddress = new bool[] {false} ;
         T00046_A69Supplier_GenContactName = new string[] {""} ;
         T00046_n69Supplier_GenContactName = new bool[] {false} ;
         T00046_A70Supplier_GenContactPhone = new string[] {""} ;
         T00046_n70Supplier_GenContactPhone = new bool[] {false} ;
         T000413_A64Supplier_GenId = new short[1] ;
         T000416_A1CustomerId = new short[1] ;
         T000416_A18CustomerLocationId = new short[1] ;
         T000416_A64Supplier_GenId = new short[1] ;
         T000417_A64Supplier_GenId = new short[1] ;
         Z74ProductServiceName = "";
         Z75ProductServiceDescription = "";
         Z77ProductServicePicture = "";
         Z40000ProductServicePicture_GXI = "";
         Z72ProductServiceTypeName = "";
         T000418_A64Supplier_GenId = new short[1] ;
         T000418_A74ProductServiceName = new string[] {""} ;
         T000418_A75ProductServiceDescription = new string[] {""} ;
         T000418_A76ProductServiceQuantity = new short[1] ;
         T000418_A40000ProductServicePicture_GXI = new string[] {""} ;
         T000418_A72ProductServiceTypeName = new string[] {""} ;
         T000418_A73ProductServiceId = new short[1] ;
         T000418_A71ProductServiceTypeId = new short[1] ;
         T000418_A77ProductServicePicture = new string[] {""} ;
         T00044_A74ProductServiceName = new string[] {""} ;
         T00044_A75ProductServiceDescription = new string[] {""} ;
         T00044_A76ProductServiceQuantity = new short[1] ;
         T00044_A40000ProductServicePicture_GXI = new string[] {""} ;
         T00044_A71ProductServiceTypeId = new short[1] ;
         T00044_A77ProductServicePicture = new string[] {""} ;
         T00045_A72ProductServiceTypeName = new string[] {""} ;
         T000419_A74ProductServiceName = new string[] {""} ;
         T000419_A75ProductServiceDescription = new string[] {""} ;
         T000419_A76ProductServiceQuantity = new short[1] ;
         T000419_A40000ProductServicePicture_GXI = new string[] {""} ;
         T000419_A71ProductServiceTypeId = new short[1] ;
         T000419_A77ProductServicePicture = new string[] {""} ;
         T000420_A72ProductServiceTypeName = new string[] {""} ;
         T000421_A64Supplier_GenId = new short[1] ;
         T000421_A73ProductServiceId = new short[1] ;
         T00043_A64Supplier_GenId = new short[1] ;
         T00043_A73ProductServiceId = new short[1] ;
         T00042_A64Supplier_GenId = new short[1] ;
         T00042_A73ProductServiceId = new short[1] ;
         T000424_A74ProductServiceName = new string[] {""} ;
         T000424_A75ProductServiceDescription = new string[] {""} ;
         T000424_A76ProductServiceQuantity = new short[1] ;
         T000424_A40000ProductServicePicture_GXI = new string[] {""} ;
         T000424_A71ProductServiceTypeId = new short[1] ;
         T000424_A77ProductServicePicture = new string[] {""} ;
         T000425_A72ProductServiceTypeName = new string[] {""} ;
         T000426_A64Supplier_GenId = new short[1] ;
         T000426_A73ProductServiceId = new short[1] ;
         Gridlevel_productserviceRow = new GXWebRow();
         subGridlevel_productservice_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_productserviceColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.supplier_gen__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_gen__default(),
            new Object[][] {
                new Object[] {
               T00042_A64Supplier_GenId, T00042_A73ProductServiceId
               }
               , new Object[] {
               T00043_A64Supplier_GenId, T00043_A73ProductServiceId
               }
               , new Object[] {
               T00044_A74ProductServiceName, T00044_A75ProductServiceDescription, T00044_A76ProductServiceQuantity, T00044_A40000ProductServicePicture_GXI, T00044_A71ProductServiceTypeId, T00044_A77ProductServicePicture
               }
               , new Object[] {
               T00045_A72ProductServiceTypeName
               }
               , new Object[] {
               T00046_A64Supplier_GenId, T00046_A65Supplier_GenKvKNumber, T00046_A66Supplier_GenCompanyName, T00046_A67Supplier_GenVisitingAddress, T00046_n67Supplier_GenVisitingAddress, T00046_A68Supplier_GenPostalAddress, T00046_n68Supplier_GenPostalAddress, T00046_A69Supplier_GenContactName, T00046_n69Supplier_GenContactName, T00046_A70Supplier_GenContactPhone,
               T00046_n70Supplier_GenContactPhone
               }
               , new Object[] {
               T00047_A64Supplier_GenId, T00047_A65Supplier_GenKvKNumber, T00047_A66Supplier_GenCompanyName, T00047_A67Supplier_GenVisitingAddress, T00047_n67Supplier_GenVisitingAddress, T00047_A68Supplier_GenPostalAddress, T00047_n68Supplier_GenPostalAddress, T00047_A69Supplier_GenContactName, T00047_n69Supplier_GenContactName, T00047_A70Supplier_GenContactPhone,
               T00047_n70Supplier_GenContactPhone
               }
               , new Object[] {
               T00048_A64Supplier_GenId, T00048_A65Supplier_GenKvKNumber, T00048_A66Supplier_GenCompanyName, T00048_A67Supplier_GenVisitingAddress, T00048_n67Supplier_GenVisitingAddress, T00048_A68Supplier_GenPostalAddress, T00048_n68Supplier_GenPostalAddress, T00048_A69Supplier_GenContactName, T00048_n69Supplier_GenContactName, T00048_A70Supplier_GenContactPhone,
               T00048_n70Supplier_GenContactPhone
               }
               , new Object[] {
               T00049_A64Supplier_GenId
               }
               , new Object[] {
               T000410_A64Supplier_GenId
               }
               , new Object[] {
               T000411_A64Supplier_GenId
               }
               , new Object[] {
               }
               , new Object[] {
               T000413_A64Supplier_GenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000416_A1CustomerId, T000416_A18CustomerLocationId, T000416_A64Supplier_GenId
               }
               , new Object[] {
               T000417_A64Supplier_GenId
               }
               , new Object[] {
               T000418_A64Supplier_GenId, T000418_A74ProductServiceName, T000418_A75ProductServiceDescription, T000418_A76ProductServiceQuantity, T000418_A40000ProductServicePicture_GXI, T000418_A72ProductServiceTypeName, T000418_A73ProductServiceId, T000418_A71ProductServiceTypeId, T000418_A77ProductServicePicture
               }
               , new Object[] {
               T000419_A74ProductServiceName, T000419_A75ProductServiceDescription, T000419_A76ProductServiceQuantity, T000419_A40000ProductServicePicture_GXI, T000419_A71ProductServiceTypeId, T000419_A77ProductServicePicture
               }
               , new Object[] {
               T000420_A72ProductServiceTypeName
               }
               , new Object[] {
               T000421_A64Supplier_GenId, T000421_A73ProductServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000424_A74ProductServiceName, T000424_A75ProductServiceDescription, T000424_A76ProductServiceQuantity, T000424_A40000ProductServicePicture_GXI, T000424_A71ProductServiceTypeId, T000424_A77ProductServicePicture
               }
               , new Object[] {
               T000425_A72ProductServiceTypeName
               }
               , new Object[] {
               T000426_A64Supplier_GenId, T000426_A73ProductServiceId
               }
            }
         );
      }

      private short wcpOAV7Supplier_GenId ;
      private short Z64Supplier_GenId ;
      private short Z73ProductServiceId ;
      private short nRcdDeleted_14 ;
      private short nRcdExists_14 ;
      private short nIsMod_14 ;
      private short GxWebError ;
      private short A73ProductServiceId ;
      private short A71ProductServiceTypeId ;
      private short AV7Supplier_GenId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A64Supplier_GenId ;
      private short nBlankRcdCount14 ;
      private short RcdFound14 ;
      private short nBlankRcdUsr14 ;
      private short AV22TabsActivePage ;
      private short RcdFound9 ;
      private short A76ProductServiceQuantity ;
      private short Gx_BScreen ;
      private short Z76ProductServiceQuantity ;
      private short Z71ProductServiceTypeId ;
      private short nIsDirty_14 ;
      private short subGridlevel_productservice_Backcolorstyle ;
      private short subGridlevel_productservice_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_productservice_Allowselection ;
      private short subGridlevel_productservice_Allowhovering ;
      private short subGridlevel_productservice_Allowcollapsing ;
      private short subGridlevel_productservice_Collapsed ;
      private int nRC_GXsfl_58 ;
      private int nGXsfl_58_idx=1 ;
      private int Gxuitabspanel_steps_Activepage ;
      private int trnEnded ;
      private int divTablemain_Width ;
      private int Gxuitabspanel_steps_Pagecount ;
      private int edtSupplier_GenKvKNumber_Enabled ;
      private int edtSupplier_GenCompanyName_Enabled ;
      private int edtSupplier_GenContactPhone_Enabled ;
      private int edtSupplier_GenContactName_Enabled ;
      private int edtSupplier_GenVisitingAddress_Enabled ;
      private int edtSupplier_GenPostalAddress_Enabled ;
      private int bttBtnwizardprevious_Visible ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtnwizardnext_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtSupplier_GenId_Enabled ;
      private int edtSupplier_GenId_Visible ;
      private int edtProductServiceId_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int edtProductServiceQuantity_Enabled ;
      private int edtProductServicePicture_Enabled ;
      private int edtProductServiceTypeId_Enabled ;
      private int edtProductServiceTypeName_Enabled ;
      private int fRowAdded ;
      private int Combo_productserviceid_Datalistupdateminimumcharacters ;
      private int Combo_productserviceid_Gxcontroltype ;
      private int subGridlevel_productservice_Backcolor ;
      private int subGridlevel_productservice_Allbackcolor ;
      private int defedtProductServiceTypeId_Enabled ;
      private int defedtProductServiceQuantity_Enabled ;
      private int defedtProductServiceId_Enabled ;
      private int idxLst ;
      private int subGridlevel_productservice_Selectedindex ;
      private int subGridlevel_productservice_Selectioncolor ;
      private int subGridlevel_productservice_Hoveringcolor ;
      private long GRIDLEVEL_PRODUCTSERVICE_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z70Supplier_GenContactPhone ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupplier_GenKvKNumber_Internalname ;
      private string sGXsfl_58_idx="0001" ;
      private string edtProductServiceId_Horizontalalignment ;
      private string edtProductServiceId_Internalname ;
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
      private string edtSupplier_GenKvKNumber_Jsonclick ;
      private string edtSupplier_GenCompanyName_Internalname ;
      private string edtSupplier_GenCompanyName_Jsonclick ;
      private string edtSupplier_GenContactPhone_Internalname ;
      private string gxphoneLink ;
      private string A70Supplier_GenContactPhone ;
      private string edtSupplier_GenContactPhone_Jsonclick ;
      private string edtSupplier_GenContactName_Internalname ;
      private string edtSupplier_GenContactName_Jsonclick ;
      private string edtSupplier_GenVisitingAddress_Internalname ;
      private string edtSupplier_GenPostalAddress_Internalname ;
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
      private string Combo_productserviceid_Caption ;
      private string Combo_productserviceid_Cls ;
      private string Combo_productserviceid_Datalistproc ;
      private string Combo_productserviceid_Datalistprocparametersprefix ;
      private string Combo_productserviceid_Internalname ;
      private string edtSupplier_GenId_Internalname ;
      private string edtSupplier_GenId_Jsonclick ;
      private string Wizard_steps_Internalname ;
      private string sMode14 ;
      private string edtProductServiceDescription_Internalname ;
      private string edtProductServiceQuantity_Internalname ;
      private string edtProductServicePicture_Internalname ;
      private string edtProductServiceTypeId_Internalname ;
      private string edtProductServiceTypeName_Internalname ;
      private string sStyleString ;
      private string subGridlevel_productservice_Internalname ;
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
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_58_fel_idx="0001" ;
      private string subGridlevel_productservice_Class ;
      private string subGridlevel_productservice_Linesclass ;
      private string ROClassString ;
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
      private string subGridlevel_productservice_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_58_Refreshing=false ;
      private bool Gxuitabspanel_steps_Historymanagement ;
      private bool Combo_productserviceid_Isgriditem ;
      private bool Combo_productserviceid_Hasdescription ;
      private bool Combo_productserviceid_Emptyitem ;
      private bool n67Supplier_GenVisitingAddress ;
      private bool n68Supplier_GenPostalAddress ;
      private bool n69Supplier_GenContactName ;
      private bool n70Supplier_GenContactPhone ;
      private bool AV20CheckRequiredFieldsResult ;
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
      private bool A77ProductServicePicture_IsBlob ;
      private string Z65Supplier_GenKvKNumber ;
      private string Z66Supplier_GenCompanyName ;
      private string Z67Supplier_GenVisitingAddress ;
      private string Z68Supplier_GenPostalAddress ;
      private string Z69Supplier_GenContactName ;
      private string A65Supplier_GenKvKNumber ;
      private string A66Supplier_GenCompanyName ;
      private string A69Supplier_GenContactName ;
      private string A67Supplier_GenVisitingAddress ;
      private string A68Supplier_GenPostalAddress ;
      private string A74ProductServiceName ;
      private string A40000ProductServicePicture_GXI ;
      private string A75ProductServiceDescription ;
      private string A72ProductServiceTypeName ;
      private string Z74ProductServiceName ;
      private string Z75ProductServiceDescription ;
      private string Z40000ProductServicePicture_GXI ;
      private string Z72ProductServiceTypeName ;
      private string A77ProductServicePicture ;
      private string Z77ProductServicePicture ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_productserviceContainer ;
      private GXWebRow Gridlevel_productserviceRow ;
      private GXWebColumn Gridlevel_productserviceColumn ;
      private GXUserControl ucGxuitabspanel_steps ;
      private GXUserControl ucCombo_productserviceid ;
      private GXUserControl ucWizard_steps ;
      private GxHttpRequest AV21HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13ProductServiceId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV18GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T00048_A64Supplier_GenId ;
      private string[] T00048_A65Supplier_GenKvKNumber ;
      private string[] T00048_A66Supplier_GenCompanyName ;
      private string[] T00048_A67Supplier_GenVisitingAddress ;
      private bool[] T00048_n67Supplier_GenVisitingAddress ;
      private string[] T00048_A68Supplier_GenPostalAddress ;
      private bool[] T00048_n68Supplier_GenPostalAddress ;
      private string[] T00048_A69Supplier_GenContactName ;
      private bool[] T00048_n69Supplier_GenContactName ;
      private string[] T00048_A70Supplier_GenContactPhone ;
      private bool[] T00048_n70Supplier_GenContactPhone ;
      private short[] T00049_A64Supplier_GenId ;
      private short[] T00047_A64Supplier_GenId ;
      private string[] T00047_A65Supplier_GenKvKNumber ;
      private string[] T00047_A66Supplier_GenCompanyName ;
      private string[] T00047_A67Supplier_GenVisitingAddress ;
      private bool[] T00047_n67Supplier_GenVisitingAddress ;
      private string[] T00047_A68Supplier_GenPostalAddress ;
      private bool[] T00047_n68Supplier_GenPostalAddress ;
      private string[] T00047_A69Supplier_GenContactName ;
      private bool[] T00047_n69Supplier_GenContactName ;
      private string[] T00047_A70Supplier_GenContactPhone ;
      private bool[] T00047_n70Supplier_GenContactPhone ;
      private short[] T000410_A64Supplier_GenId ;
      private short[] T000411_A64Supplier_GenId ;
      private short[] T00046_A64Supplier_GenId ;
      private string[] T00046_A65Supplier_GenKvKNumber ;
      private string[] T00046_A66Supplier_GenCompanyName ;
      private string[] T00046_A67Supplier_GenVisitingAddress ;
      private bool[] T00046_n67Supplier_GenVisitingAddress ;
      private string[] T00046_A68Supplier_GenPostalAddress ;
      private bool[] T00046_n68Supplier_GenPostalAddress ;
      private string[] T00046_A69Supplier_GenContactName ;
      private bool[] T00046_n69Supplier_GenContactName ;
      private string[] T00046_A70Supplier_GenContactPhone ;
      private bool[] T00046_n70Supplier_GenContactPhone ;
      private short[] T000413_A64Supplier_GenId ;
      private short[] T000416_A1CustomerId ;
      private short[] T000416_A18CustomerLocationId ;
      private short[] T000416_A64Supplier_GenId ;
      private short[] T000417_A64Supplier_GenId ;
      private short[] T000418_A64Supplier_GenId ;
      private string[] T000418_A74ProductServiceName ;
      private string[] T000418_A75ProductServiceDescription ;
      private short[] T000418_A76ProductServiceQuantity ;
      private string[] T000418_A40000ProductServicePicture_GXI ;
      private string[] T000418_A72ProductServiceTypeName ;
      private short[] T000418_A73ProductServiceId ;
      private short[] T000418_A71ProductServiceTypeId ;
      private string[] T000418_A77ProductServicePicture ;
      private string[] T00044_A74ProductServiceName ;
      private string[] T00044_A75ProductServiceDescription ;
      private short[] T00044_A76ProductServiceQuantity ;
      private string[] T00044_A40000ProductServicePicture_GXI ;
      private short[] T00044_A71ProductServiceTypeId ;
      private string[] T00044_A77ProductServicePicture ;
      private string[] T00045_A72ProductServiceTypeName ;
      private string[] T000419_A74ProductServiceName ;
      private string[] T000419_A75ProductServiceDescription ;
      private short[] T000419_A76ProductServiceQuantity ;
      private string[] T000419_A40000ProductServicePicture_GXI ;
      private short[] T000419_A71ProductServiceTypeId ;
      private string[] T000419_A77ProductServicePicture ;
      private string[] T000420_A72ProductServiceTypeName ;
      private short[] T000421_A64Supplier_GenId ;
      private short[] T000421_A73ProductServiceId ;
      private short[] T00043_A64Supplier_GenId ;
      private short[] T00043_A73ProductServiceId ;
      private short[] T00042_A64Supplier_GenId ;
      private short[] T00042_A73ProductServiceId ;
      private string[] T000424_A74ProductServiceName ;
      private string[] T000424_A75ProductServiceDescription ;
      private short[] T000424_A76ProductServiceQuantity ;
      private string[] T000424_A40000ProductServicePicture_GXI ;
      private short[] T000424_A71ProductServiceTypeId ;
      private string[] T000424_A77ProductServicePicture ;
      private string[] T000425_A72ProductServiceTypeName ;
      private short[] T000426_A64Supplier_GenId ;
      private short[] T000426_A73ProductServiceId ;
      private IDataStoreProvider pr_gam ;
   }

   public class supplier_gen__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class supplier_gen__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00042;
        prmT00042 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00043;
        prmT00043 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00044;
        prmT00044 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00045;
        prmT00045 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT00046;
        prmT00046 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT00047;
        prmT00047 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT00048;
        prmT00048 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT00049;
        prmT00049 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000410;
        prmT000410 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000411;
        prmT000411 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000412;
        prmT000412 = new Object[] {
        new ParDef("Supplier_GenKvKNumber",GXType.VarChar,8,0) ,
        new ParDef("Supplier_GenCompanyName",GXType.VarChar,40,0) ,
        new ParDef("Supplier_GenVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_GenPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_GenContactName",GXType.VarChar,40,0){Nullable=true} ,
        new ParDef("Supplier_GenContactPhone",GXType.Char,20,0){Nullable=true}
        };
        Object[] prmT000413;
        prmT000413 = new Object[] {
        };
        Object[] prmT000414;
        prmT000414 = new Object[] {
        new ParDef("Supplier_GenKvKNumber",GXType.VarChar,8,0) ,
        new ParDef("Supplier_GenCompanyName",GXType.VarChar,40,0) ,
        new ParDef("Supplier_GenVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_GenPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_GenContactName",GXType.VarChar,40,0){Nullable=true} ,
        new ParDef("Supplier_GenContactPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000415;
        prmT000415 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000416;
        prmT000416 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmT000417;
        prmT000417 = new Object[] {
        };
        Object[] prmT000418;
        prmT000418 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000419;
        prmT000419 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000420;
        prmT000420 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000421;
        prmT000421 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000422;
        prmT000422 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000423;
        prmT000423 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000424;
        prmT000424 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000425;
        prmT000425 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000426;
        prmT000426 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00042", "SELECT Supplier_GenId, ProductServiceId FROM Supplier_GenProductService WHERE Supplier_GenId = :Supplier_GenId AND ProductServiceId = :ProductServiceId  FOR UPDATE OF Supplier_GenProductService NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00043", "SELECT Supplier_GenId, ProductServiceId FROM Supplier_GenProductService WHERE Supplier_GenId = :Supplier_GenId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00044", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00045", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00046", "SELECT Supplier_GenId, Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId  FOR UPDATE OF Supplier_Gen NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00047", "SELECT Supplier_GenId, Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00048", "SELECT TM1.Supplier_GenId, TM1.Supplier_GenKvKNumber, TM1.Supplier_GenCompanyName, TM1.Supplier_GenVisitingAddress, TM1.Supplier_GenPostalAddress, TM1.Supplier_GenContactName, TM1.Supplier_GenContactPhone FROM Supplier_Gen TM1 WHERE TM1.Supplier_GenId = :Supplier_GenId ORDER BY TM1.Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00049", "SELECT Supplier_GenId FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000410", "SELECT Supplier_GenId FROM Supplier_Gen WHERE ( Supplier_GenId > :Supplier_GenId) ORDER BY Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000411", "SELECT Supplier_GenId FROM Supplier_Gen WHERE ( Supplier_GenId < :Supplier_GenId) ORDER BY Supplier_GenId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000412", "SAVEPOINT gxupdate;INSERT INTO Supplier_Gen(Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone) VALUES(:Supplier_GenKvKNumber, :Supplier_GenCompanyName, :Supplier_GenVisitingAddress, :Supplier_GenPostalAddress, :Supplier_GenContactName, :Supplier_GenContactPhone);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000412)
           ,new CursorDef("T000413", "SELECT currval('Supplier_GenId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000414", "SAVEPOINT gxupdate;UPDATE Supplier_Gen SET Supplier_GenKvKNumber=:Supplier_GenKvKNumber, Supplier_GenCompanyName=:Supplier_GenCompanyName, Supplier_GenVisitingAddress=:Supplier_GenVisitingAddress, Supplier_GenPostalAddress=:Supplier_GenPostalAddress, Supplier_GenContactName=:Supplier_GenContactName, Supplier_GenContactPhone=:Supplier_GenContactPhone  WHERE Supplier_GenId = :Supplier_GenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000414)
           ,new CursorDef("T000415", "SAVEPOINT gxupdate;DELETE FROM Supplier_Gen  WHERE Supplier_GenId = :Supplier_GenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000415)
           ,new CursorDef("T000416", "SELECT CustomerId, CustomerLocationId, Supplier_GenId FROM CustomerLocationSupplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000417", "SELECT Supplier_GenId FROM Supplier_Gen ORDER BY Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000418", "SELECT T1.Supplier_GenId, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceQuantity, T2.ProductServicePicture_GXI, T3.ProductServiceTypeName, T1.ProductServiceId, T2.ProductServiceTypeId, T2.ProductServicePicture FROM ((Supplier_GenProductService T1 INNER JOIN ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN ProductServiceType T3 ON T3.ProductServiceTypeId = T2.ProductServiceTypeId) WHERE T1.Supplier_GenId = :Supplier_GenId and T1.ProductServiceId = :ProductServiceId ORDER BY T1.Supplier_GenId, T1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000419", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000420", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000421", "SELECT Supplier_GenId, ProductServiceId FROM Supplier_GenProductService WHERE Supplier_GenId = :Supplier_GenId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000422", "SAVEPOINT gxupdate;INSERT INTO Supplier_GenProductService(Supplier_GenId, ProductServiceId) VALUES(:Supplier_GenId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000422)
           ,new CursorDef("T000423", "SAVEPOINT gxupdate;DELETE FROM Supplier_GenProductService  WHERE Supplier_GenId = :Supplier_GenId AND ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000423)
           ,new CursorDef("T000424", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000424,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000425", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000425,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000426", "SELECT Supplier_GenId, ProductServiceId FROM Supplier_GenProductService WHERE Supplier_GenId = :Supplier_GenId ORDER BY Supplier_GenId, ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000426,11, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 5 :
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
              return;
           case 6 :
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
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 11 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 16 :
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
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 24 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}
