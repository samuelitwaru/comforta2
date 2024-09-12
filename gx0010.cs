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
   public class gx0010 : GXDataArea
   {
      public gx0010( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0010( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pCustomerId )
      {
         this.AV13pCustomerId = 0 ;
         ExecuteImpl();
         aP0_pCustomerId=this.AV13pCustomerId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pCustomerId");
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
               gxfirstwebparm = GetFirstPar( "pCustomerId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCustomerId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
               AV13pCustomerId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pCustomerId", StringUtil.LTrimStr( (decimal)(AV13pCustomerId), 4, 0));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cCustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "cCustomerId"), "."), 18, MidpointRounding.ToEven));
         AV7cCustomerName = GetPar( "cCustomerName");
         AV8cCustomerEmail = GetPar( "cCustomerEmail");
         AV9cCustomerPhone = GetPar( "cCustomerPhone");
         AV10cCustomerVatNumber = GetPar( "cCustomerVatNumber");
         AV11cCustomerKvkNumber = GetPar( "cCustomerKvkNumber");
         AV12cCustomerTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "cCustomerTypeId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerId, AV7cCustomerName, AV8cCustomerEmail, AV9cCustomerPhone, AV10cCustomerVatNumber, AV11cCustomerKvkNumber, AV12cCustomerTypeId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            return "gx0010_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
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

      public override short ExecuteStartEvent( )
      {
         PA0E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0E2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0010.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pCustomerId,4,0))}, new string[] {"pCustomerId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERNAME", AV7cCustomerName);
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMEREMAIL", AV8cCustomerEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERPHONE", StringUtil.RTrim( AV9cCustomerPhone));
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERVATNUMBER", AV10cCustomerVatNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERKVKNUMBER", AV11cCustomerKvkNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERTYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cCustomerTypeId), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pCustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERIDFILTERCONTAINER_Class", StringUtil.RTrim( divCustomeridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divCustomernamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMEREMAILFILTERCONTAINER_Class", StringUtil.RTrim( divCustomeremailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divCustomerphonefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERVATNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divCustomervatnumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERKVKNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divCustomerkvknumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERTYPEIDFILTERCONTAINER_Class", StringUtil.RTrim( divCustomertypeidfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE0E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0E2( ) ;
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
         return formatLink("gx0010.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pCustomerId,4,0))}, new string[] {"pCustomerId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0010" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Customer" ;
      }

      protected void WB0E0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCustomeridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomeridfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomeridfilter_Internalname, "Customer Id", "", "", lblLblcustomeridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomerid_Internalname, "Customer Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomerid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCustomerId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCcustomerid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cCustomerId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cCustomerId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomerid_Visible, edtavCcustomerid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divCustomernamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomernamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomernamefilter_Internalname, "Customer Name", "", "", lblLblcustomernamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomername_Internalname, "Customer Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomername_Internalname, AV7cCustomerName, StringUtil.RTrim( context.localUtil.Format( AV7cCustomerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomername_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomername_Visible, edtavCcustomername_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divCustomeremailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomeremailfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomeremailfilter_Internalname, "Customer Email", "", "", lblLblcustomeremailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomeremail_Internalname, "Customer Email", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomeremail_Internalname, AV8cCustomerEmail, StringUtil.RTrim( context.localUtil.Format( AV8cCustomerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomeremail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomeremail_Visible, edtavCcustomeremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divCustomerphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomerphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomerphonefilter_Internalname, "Customer Phone", "", "", lblLblcustomerphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomerphone_Internalname, "Customer Phone", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomerphone_Internalname, StringUtil.RTrim( AV9cCustomerPhone), StringUtil.RTrim( context.localUtil.Format( AV9cCustomerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomerphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomerphone_Visible, edtavCcustomerphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divCustomervatnumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomervatnumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomervatnumberfilter_Internalname, "Customer Vat Number", "", "", lblLblcustomervatnumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomervatnumber_Internalname, "Customer Vat Number", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomervatnumber_Internalname, AV10cCustomerVatNumber, StringUtil.RTrim( context.localUtil.Format( AV10cCustomerVatNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomervatnumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomervatnumber_Visible, edtavCcustomervatnumber_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divCustomerkvknumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomerkvknumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomerkvknumberfilter_Internalname, "Customer Kvk Number", "", "", lblLblcustomerkvknumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomerkvknumber_Internalname, "Customer Kvk Number", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomerkvknumber_Internalname, AV11cCustomerKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV11cCustomerKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomerkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomerkvknumber_Visible, edtavCcustomerkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divCustomertypeidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomertypeidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomertypeidfilter_Internalname, "Customer Type Id", "", "", lblLblcustomertypeidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomertypeid_Internalname, "Customer Type Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomertypeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cCustomerTypeId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCcustomertypeid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cCustomerTypeId), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cCustomerTypeId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomertypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomertypeid_Visible, edtavCcustomertypeid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180e1_client"+"'", TempTags, "", 2, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0E2( )
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
         Form.Meta.addItem("description", "Selection List Customer", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0E0( ) ;
      }

      protected void WS0E2( )
      {
         START0E2( ) ;
         EVT0E2( ) ;
      }

      protected void EVT0E2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A3CustomerName = cgiGet( edtCustomerName_Internalname);
                              A7CustomerPhone = cgiGet( edtCustomerPhone_Internalname);
                              n7CustomerPhone = false;
                              A14CustomerVatNumber = cgiGet( edtCustomerVatNumber_Internalname);
                              A41CustomerKvkNumber = cgiGet( edtCustomerKvkNumber_Internalname);
                              A78CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n78CustomerTypeId = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccustomerid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCUSTOMERID"), ".", ",") != Convert.ToDecimal( AV6cCustomerId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomername Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERNAME"), AV7cCustomerName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomeremail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMEREMAIL"), AV8cCustomerEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomerphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERPHONE"), AV9cCustomerPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomervatnumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERVATNUMBER"), AV10cCustomerVatNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomerkvknumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERKVKNUMBER"), AV11cCustomerKvkNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomertypeid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCUSTOMERTYPEID"), ".", ",") != Convert.ToDecimal( AV12cCustomerTypeId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210E2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE0E2( )
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

      protected void PA0E2( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cCustomerId ,
                                        string AV7cCustomerName ,
                                        string AV8cCustomerEmail ,
                                        string AV9cCustomerPhone ,
                                        string AV10cCustomerVatNumber ,
                                        string AV11cCustomerKvkNumber ,
                                        short AV12cCustomerTypeId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CUSTOMERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cCustomerName ,
                                                 AV8cCustomerEmail ,
                                                 AV9cCustomerPhone ,
                                                 AV10cCustomerVatNumber ,
                                                 AV11cCustomerKvkNumber ,
                                                 AV12cCustomerTypeId ,
                                                 A3CustomerName ,
                                                 A5CustomerEmail ,
                                                 A7CustomerPhone ,
                                                 A14CustomerVatNumber ,
                                                 A41CustomerKvkNumber ,
                                                 A78CustomerTypeId ,
                                                 AV6cCustomerId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV7cCustomerName = StringUtil.Concat( StringUtil.RTrim( AV7cCustomerName), "%", "");
            lV8cCustomerEmail = StringUtil.Concat( StringUtil.RTrim( AV8cCustomerEmail), "%", "");
            lV9cCustomerPhone = StringUtil.PadR( StringUtil.RTrim( AV9cCustomerPhone), 20, "%");
            lV10cCustomerVatNumber = StringUtil.Concat( StringUtil.RTrim( AV10cCustomerVatNumber), "%", "");
            lV11cCustomerKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV11cCustomerKvkNumber), "%", "");
            /* Using cursor H000E2 */
            pr_default.execute(0, new Object[] {AV6cCustomerId, lV7cCustomerName, lV8cCustomerEmail, lV9cCustomerPhone, lV10cCustomerVatNumber, lV11cCustomerKvkNumber, AV12cCustomerTypeId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A5CustomerEmail = H000E2_A5CustomerEmail[0];
               n5CustomerEmail = H000E2_n5CustomerEmail[0];
               A78CustomerTypeId = H000E2_A78CustomerTypeId[0];
               n78CustomerTypeId = H000E2_n78CustomerTypeId[0];
               A41CustomerKvkNumber = H000E2_A41CustomerKvkNumber[0];
               A14CustomerVatNumber = H000E2_A14CustomerVatNumber[0];
               A7CustomerPhone = H000E2_A7CustomerPhone[0];
               n7CustomerPhone = H000E2_n7CustomerPhone[0];
               A3CustomerName = H000E2_A3CustomerName[0];
               A1CustomerId = H000E2_A1CustomerId[0];
               /* Execute user event: Load */
               E200E2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0E0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0E2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CUSTOMERID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cCustomerName ,
                                              AV8cCustomerEmail ,
                                              AV9cCustomerPhone ,
                                              AV10cCustomerVatNumber ,
                                              AV11cCustomerKvkNumber ,
                                              AV12cCustomerTypeId ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A41CustomerKvkNumber ,
                                              A78CustomerTypeId ,
                                              AV6cCustomerId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV7cCustomerName = StringUtil.Concat( StringUtil.RTrim( AV7cCustomerName), "%", "");
         lV8cCustomerEmail = StringUtil.Concat( StringUtil.RTrim( AV8cCustomerEmail), "%", "");
         lV9cCustomerPhone = StringUtil.PadR( StringUtil.RTrim( AV9cCustomerPhone), 20, "%");
         lV10cCustomerVatNumber = StringUtil.Concat( StringUtil.RTrim( AV10cCustomerVatNumber), "%", "");
         lV11cCustomerKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV11cCustomerKvkNumber), "%", "");
         /* Using cursor H000E3 */
         pr_default.execute(1, new Object[] {AV6cCustomerId, lV7cCustomerName, lV8cCustomerEmail, lV9cCustomerPhone, lV10cCustomerVatNumber, lV11cCustomerKvkNumber, AV12cCustomerTypeId});
         GRID1_nRecordCount = H000E3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerId, AV7cCustomerName, AV8cCustomerEmail, AV9cCustomerPhone, AV10cCustomerVatNumber, AV11cCustomerKvkNumber, AV12cCustomerTypeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerId, AV7cCustomerName, AV8cCustomerEmail, AV9cCustomerPhone, AV10cCustomerVatNumber, AV11cCustomerKvkNumber, AV12cCustomerTypeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerId, AV7cCustomerName, AV8cCustomerEmail, AV9cCustomerPhone, AV10cCustomerVatNumber, AV11cCustomerKvkNumber, AV12cCustomerTypeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerId, AV7cCustomerName, AV8cCustomerEmail, AV9cCustomerPhone, AV10cCustomerVatNumber, AV11cCustomerKvkNumber, AV12cCustomerTypeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerId, AV7cCustomerName, AV8cCustomerEmail, AV9cCustomerPhone, AV10cCustomerVatNumber, AV11cCustomerKvkNumber, AV12cCustomerTypeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtCustomerId_Enabled = 0;
         edtCustomerName_Enabled = 0;
         edtCustomerPhone_Enabled = 0;
         edtCustomerVatNumber_Enabled = 0;
         edtCustomerKvkNumber_Enabled = 0;
         edtCustomerTypeId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcustomerid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcustomerid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCUSTOMERID");
               GX_FocusControl = edtavCcustomerid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCustomerId = 0;
               AssignAttri("", false, "AV6cCustomerId", StringUtil.LTrimStr( (decimal)(AV6cCustomerId), 4, 0));
            }
            else
            {
               AV6cCustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcustomerid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cCustomerId", StringUtil.LTrimStr( (decimal)(AV6cCustomerId), 4, 0));
            }
            AV7cCustomerName = cgiGet( edtavCcustomername_Internalname);
            AssignAttri("", false, "AV7cCustomerName", AV7cCustomerName);
            AV8cCustomerEmail = cgiGet( edtavCcustomeremail_Internalname);
            AssignAttri("", false, "AV8cCustomerEmail", AV8cCustomerEmail);
            AV9cCustomerPhone = cgiGet( edtavCcustomerphone_Internalname);
            AssignAttri("", false, "AV9cCustomerPhone", AV9cCustomerPhone);
            AV10cCustomerVatNumber = cgiGet( edtavCcustomervatnumber_Internalname);
            AssignAttri("", false, "AV10cCustomerVatNumber", AV10cCustomerVatNumber);
            AV11cCustomerKvkNumber = cgiGet( edtavCcustomerkvknumber_Internalname);
            AssignAttri("", false, "AV11cCustomerKvkNumber", AV11cCustomerKvkNumber);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcustomertypeid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcustomertypeid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCUSTOMERTYPEID");
               GX_FocusControl = edtavCcustomertypeid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cCustomerTypeId = 0;
               AssignAttri("", false, "AV12cCustomerTypeId", StringUtil.LTrimStr( (decimal)(AV12cCustomerTypeId), 4, 0));
            }
            else
            {
               AV12cCustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcustomertypeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cCustomerTypeId", StringUtil.LTrimStr( (decimal)(AV12cCustomerTypeId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCUSTOMERID"), ".", ",") != Convert.ToDecimal( AV6cCustomerId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERNAME"), AV7cCustomerName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMEREMAIL"), AV8cCustomerEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERPHONE"), AV9cCustomerPhone) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERVATNUMBER"), AV10cCustomerVatNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERKVKNUMBER"), AV11cCustomerKvkNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCUSTOMERTYPEID"), ".", ",") != Convert.ToDecimal( AV12cCustomerTypeId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E190E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190E2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Customer", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200E2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E210E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210E2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCustomerId = A1CustomerId;
         AssignAttri("", false, "AV13pCustomerId", StringUtil.LTrimStr( (decimal)(AV13pCustomerId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pCustomerId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCustomerId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pCustomerId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pCustomerId", StringUtil.LTrimStr( (decimal)(AV13pCustomerId), 4, 0));
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
         PA0E2( ) ;
         WS0E2( ) ;
         WE0E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126321562", true, true);
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
         context.AddJavascriptSource("gx0010.js", "?20249126321562", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_84_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_84_idx;
         edtCustomerPhone_Internalname = "CUSTOMERPHONE_"+sGXsfl_84_idx;
         edtCustomerVatNumber_Internalname = "CUSTOMERVATNUMBER_"+sGXsfl_84_idx;
         edtCustomerKvkNumber_Internalname = "CUSTOMERKVKNUMBER_"+sGXsfl_84_idx;
         edtCustomerTypeId_Internalname = "CUSTOMERTYPEID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_84_fel_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_84_fel_idx;
         edtCustomerPhone_Internalname = "CUSTOMERPHONE_"+sGXsfl_84_fel_idx;
         edtCustomerVatNumber_Internalname = "CUSTOMERVATNUMBER_"+sGXsfl_84_fel_idx;
         edtCustomerKvkNumber_Internalname = "CUSTOMERKVKNUMBER_"+sGXsfl_84_fel_idx;
         edtCustomerTypeId_Internalname = "CUSTOMERTYPEID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB0E0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerName_Internalname,(string)A3CustomerName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A7CustomerPhone);
            }
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerPhone_Internalname,StringUtil.RTrim( A7CustomerPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCustomerPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerVatNumber_Internalname,(string)A14CustomerVatNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerVatNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCustomerKvkNumber_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtCustomerKvkNumber_Internalname, "Link", edtCustomerKvkNumber_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerKvkNumber_Internalname,(string)A41CustomerKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCustomerKvkNumber_Link,(string)"",(string)"",(string)"",(string)edtCustomerKvkNumber_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A78CustomerTypeId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A78CustomerTypeId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes0E2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vat Number") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Kvk Number") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Customer Type Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A3CustomerName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A7CustomerPhone)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A14CustomerVatNumber));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A41CustomerKvkNumber));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCustomerKvkNumber_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A78CustomerTypeId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblcustomeridfilter_Internalname = "LBLCUSTOMERIDFILTER";
         edtavCcustomerid_Internalname = "vCCUSTOMERID";
         divCustomeridfiltercontainer_Internalname = "CUSTOMERIDFILTERCONTAINER";
         lblLblcustomernamefilter_Internalname = "LBLCUSTOMERNAMEFILTER";
         edtavCcustomername_Internalname = "vCCUSTOMERNAME";
         divCustomernamefiltercontainer_Internalname = "CUSTOMERNAMEFILTERCONTAINER";
         lblLblcustomeremailfilter_Internalname = "LBLCUSTOMEREMAILFILTER";
         edtavCcustomeremail_Internalname = "vCCUSTOMEREMAIL";
         divCustomeremailfiltercontainer_Internalname = "CUSTOMEREMAILFILTERCONTAINER";
         lblLblcustomerphonefilter_Internalname = "LBLCUSTOMERPHONEFILTER";
         edtavCcustomerphone_Internalname = "vCCUSTOMERPHONE";
         divCustomerphonefiltercontainer_Internalname = "CUSTOMERPHONEFILTERCONTAINER";
         lblLblcustomervatnumberfilter_Internalname = "LBLCUSTOMERVATNUMBERFILTER";
         edtavCcustomervatnumber_Internalname = "vCCUSTOMERVATNUMBER";
         divCustomervatnumberfiltercontainer_Internalname = "CUSTOMERVATNUMBERFILTERCONTAINER";
         lblLblcustomerkvknumberfilter_Internalname = "LBLCUSTOMERKVKNUMBERFILTER";
         edtavCcustomerkvknumber_Internalname = "vCCUSTOMERKVKNUMBER";
         divCustomerkvknumberfiltercontainer_Internalname = "CUSTOMERKVKNUMBERFILTERCONTAINER";
         lblLblcustomertypeidfilter_Internalname = "LBLCUSTOMERTYPEIDFILTER";
         edtavCcustomertypeid_Internalname = "vCCUSTOMERTYPEID";
         divCustomertypeidfiltercontainer_Internalname = "CUSTOMERTYPEIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCustomerPhone_Internalname = "CUSTOMERPHONE";
         edtCustomerVatNumber_Internalname = "CUSTOMERVATNUMBER";
         edtCustomerKvkNumber_Internalname = "CUSTOMERKVKNUMBER";
         edtCustomerTypeId_Internalname = "CUSTOMERTYPEID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtCustomerTypeId_Jsonclick = "";
         edtCustomerKvkNumber_Jsonclick = "";
         edtCustomerKvkNumber_Link = "";
         edtCustomerVatNumber_Jsonclick = "";
         edtCustomerPhone_Jsonclick = "";
         edtCustomerName_Jsonclick = "";
         edtCustomerId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtCustomerTypeId_Enabled = 0;
         edtCustomerKvkNumber_Enabled = 0;
         edtCustomerVatNumber_Enabled = 0;
         edtCustomerPhone_Enabled = 0;
         edtCustomerName_Enabled = 0;
         edtCustomerId_Enabled = 0;
         edtavCcustomertypeid_Jsonclick = "";
         edtavCcustomertypeid_Enabled = 1;
         edtavCcustomertypeid_Visible = 1;
         edtavCcustomerkvknumber_Jsonclick = "";
         edtavCcustomerkvknumber_Enabled = 1;
         edtavCcustomerkvknumber_Visible = 1;
         edtavCcustomervatnumber_Jsonclick = "";
         edtavCcustomervatnumber_Enabled = 1;
         edtavCcustomervatnumber_Visible = 1;
         edtavCcustomerphone_Jsonclick = "";
         edtavCcustomerphone_Enabled = 1;
         edtavCcustomerphone_Visible = 1;
         edtavCcustomeremail_Jsonclick = "";
         edtavCcustomeremail_Enabled = 1;
         edtavCcustomeremail_Visible = 1;
         edtavCcustomername_Jsonclick = "";
         edtavCcustomername_Enabled = 1;
         edtavCcustomername_Visible = 1;
         edtavCcustomerid_Jsonclick = "";
         edtavCcustomerid_Enabled = 1;
         edtavCcustomerid_Visible = 1;
         divCustomertypeidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomerkvknumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomervatnumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomerphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomeremailfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomernamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomeridfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Customer";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerId","fld":"vCCUSTOMERID","pic":"ZZZ9"},{"av":"AV7cCustomerName","fld":"vCCUSTOMERNAME"},{"av":"AV8cCustomerEmail","fld":"vCCUSTOMEREMAIL"},{"av":"AV9cCustomerPhone","fld":"vCCUSTOMERPHONE"},{"av":"AV10cCustomerVatNumber","fld":"vCCUSTOMERVATNUMBER"},{"av":"AV11cCustomerKvkNumber","fld":"vCCUSTOMERKVKNUMBER"},{"av":"AV12cCustomerTypeId","fld":"vCCUSTOMERTYPEID","pic":"ZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E180E1","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLCUSTOMERIDFILTER.CLICK","""{"handler":"E110E1","iparms":[{"av":"divCustomeridfiltercontainer_Class","ctrl":"CUSTOMERIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERIDFILTER.CLICK",""","oparms":[{"av":"divCustomeridfiltercontainer_Class","ctrl":"CUSTOMERIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomerid_Visible","ctrl":"vCCUSTOMERID","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERNAMEFILTER.CLICK","""{"handler":"E120E1","iparms":[{"av":"divCustomernamefiltercontainer_Class","ctrl":"CUSTOMERNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERNAMEFILTER.CLICK",""","oparms":[{"av":"divCustomernamefiltercontainer_Class","ctrl":"CUSTOMERNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomername_Visible","ctrl":"vCCUSTOMERNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMEREMAILFILTER.CLICK","""{"handler":"E130E1","iparms":[{"av":"divCustomeremailfiltercontainer_Class","ctrl":"CUSTOMEREMAILFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMEREMAILFILTER.CLICK",""","oparms":[{"av":"divCustomeremailfiltercontainer_Class","ctrl":"CUSTOMEREMAILFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomeremail_Visible","ctrl":"vCCUSTOMEREMAIL","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERPHONEFILTER.CLICK","""{"handler":"E140E1","iparms":[{"av":"divCustomerphonefiltercontainer_Class","ctrl":"CUSTOMERPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERPHONEFILTER.CLICK",""","oparms":[{"av":"divCustomerphonefiltercontainer_Class","ctrl":"CUSTOMERPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomerphone_Visible","ctrl":"vCCUSTOMERPHONE","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERVATNUMBERFILTER.CLICK","""{"handler":"E150E1","iparms":[{"av":"divCustomervatnumberfiltercontainer_Class","ctrl":"CUSTOMERVATNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERVATNUMBERFILTER.CLICK",""","oparms":[{"av":"divCustomervatnumberfiltercontainer_Class","ctrl":"CUSTOMERVATNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomervatnumber_Visible","ctrl":"vCCUSTOMERVATNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERKVKNUMBERFILTER.CLICK","""{"handler":"E160E1","iparms":[{"av":"divCustomerkvknumberfiltercontainer_Class","ctrl":"CUSTOMERKVKNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERKVKNUMBERFILTER.CLICK",""","oparms":[{"av":"divCustomerkvknumberfiltercontainer_Class","ctrl":"CUSTOMERKVKNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomerkvknumber_Visible","ctrl":"vCCUSTOMERKVKNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERTYPEIDFILTER.CLICK","""{"handler":"E170E1","iparms":[{"av":"divCustomertypeidfiltercontainer_Class","ctrl":"CUSTOMERTYPEIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERTYPEIDFILTER.CLICK",""","oparms":[{"av":"divCustomertypeidfiltercontainer_Class","ctrl":"CUSTOMERTYPEIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomertypeid_Visible","ctrl":"vCCUSTOMERTYPEID","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E210E2","iparms":[{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerId","fld":"vCCUSTOMERID","pic":"ZZZ9"},{"av":"AV7cCustomerName","fld":"vCCUSTOMERNAME"},{"av":"AV8cCustomerEmail","fld":"vCCUSTOMEREMAIL"},{"av":"AV9cCustomerPhone","fld":"vCCUSTOMERPHONE"},{"av":"AV10cCustomerVatNumber","fld":"vCCUSTOMERVATNUMBER"},{"av":"AV11cCustomerKvkNumber","fld":"vCCUSTOMERKVKNUMBER"},{"av":"AV12cCustomerTypeId","fld":"vCCUSTOMERTYPEID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerId","fld":"vCCUSTOMERID","pic":"ZZZ9"},{"av":"AV7cCustomerName","fld":"vCCUSTOMERNAME"},{"av":"AV8cCustomerEmail","fld":"vCCUSTOMEREMAIL"},{"av":"AV9cCustomerPhone","fld":"vCCUSTOMERPHONE"},{"av":"AV10cCustomerVatNumber","fld":"vCCUSTOMERVATNUMBER"},{"av":"AV11cCustomerKvkNumber","fld":"vCCUSTOMERKVKNUMBER"},{"av":"AV12cCustomerTypeId","fld":"vCCUSTOMERTYPEID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerId","fld":"vCCUSTOMERID","pic":"ZZZ9"},{"av":"AV7cCustomerName","fld":"vCCUSTOMERNAME"},{"av":"AV8cCustomerEmail","fld":"vCCUSTOMEREMAIL"},{"av":"AV9cCustomerPhone","fld":"vCCUSTOMERPHONE"},{"av":"AV10cCustomerVatNumber","fld":"vCCUSTOMERVATNUMBER"},{"av":"AV11cCustomerKvkNumber","fld":"vCCUSTOMERKVKNUMBER"},{"av":"AV12cCustomerTypeId","fld":"vCCUSTOMERTYPEID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerId","fld":"vCCUSTOMERID","pic":"ZZZ9"},{"av":"AV7cCustomerName","fld":"vCCUSTOMERNAME"},{"av":"AV8cCustomerEmail","fld":"vCCUSTOMEREMAIL"},{"av":"AV9cCustomerPhone","fld":"vCCUSTOMERPHONE"},{"av":"AV10cCustomerVatNumber","fld":"vCCUSTOMERVATNUMBER"},{"av":"AV11cCustomerKvkNumber","fld":"vCCUSTOMERKVKNUMBER"},{"av":"AV12cCustomerTypeId","fld":"vCCUSTOMERTYPEID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALIDV_CCUSTOMEREMAIL","""{"handler":"Validv_Ccustomeremail","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Customertypeid","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cCustomerName = "";
         AV8cCustomerEmail = "";
         AV9cCustomerPhone = "";
         AV10cCustomerVatNumber = "";
         AV11cCustomerKvkNumber = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcustomeridfilter_Jsonclick = "";
         TempTags = "";
         lblLblcustomernamefilter_Jsonclick = "";
         lblLblcustomeremailfilter_Jsonclick = "";
         lblLblcustomerphonefilter_Jsonclick = "";
         lblLblcustomervatnumberfilter_Jsonclick = "";
         lblLblcustomerkvknumberfilter_Jsonclick = "";
         lblLblcustomertypeidfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV15Linkselection_GXI = "";
         A3CustomerName = "";
         A7CustomerPhone = "";
         A14CustomerVatNumber = "";
         A41CustomerKvkNumber = "";
         lV7cCustomerName = "";
         lV8cCustomerEmail = "";
         lV9cCustomerPhone = "";
         lV10cCustomerVatNumber = "";
         lV11cCustomerKvkNumber = "";
         A5CustomerEmail = "";
         H000E2_A5CustomerEmail = new string[] {""} ;
         H000E2_n5CustomerEmail = new bool[] {false} ;
         H000E2_A78CustomerTypeId = new short[1] ;
         H000E2_n78CustomerTypeId = new bool[] {false} ;
         H000E2_A41CustomerKvkNumber = new string[] {""} ;
         H000E2_A14CustomerVatNumber = new string[] {""} ;
         H000E2_A7CustomerPhone = new string[] {""} ;
         H000E2_n7CustomerPhone = new bool[] {false} ;
         H000E2_A3CustomerName = new string[] {""} ;
         H000E2_A1CustomerId = new short[1] ;
         H000E3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0010__default(),
            new Object[][] {
                new Object[] {
               H000E2_A5CustomerEmail, H000E2_n5CustomerEmail, H000E2_A78CustomerTypeId, H000E2_n78CustomerTypeId, H000E2_A41CustomerKvkNumber, H000E2_A14CustomerVatNumber, H000E2_A7CustomerPhone, H000E2_n7CustomerPhone, H000E2_A3CustomerName, H000E2_A1CustomerId
               }
               , new Object[] {
               H000E3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13pCustomerId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cCustomerId ;
      private short AV12cCustomerTypeId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A1CustomerId ;
      private short A78CustomerTypeId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCcustomerid_Enabled ;
      private int edtavCcustomerid_Visible ;
      private int edtavCcustomername_Visible ;
      private int edtavCcustomername_Enabled ;
      private int edtavCcustomeremail_Visible ;
      private int edtavCcustomeremail_Enabled ;
      private int edtavCcustomerphone_Visible ;
      private int edtavCcustomerphone_Enabled ;
      private int edtavCcustomervatnumber_Visible ;
      private int edtavCcustomervatnumber_Enabled ;
      private int edtavCcustomerkvknumber_Visible ;
      private int edtavCcustomerkvknumber_Enabled ;
      private int edtavCcustomertypeid_Enabled ;
      private int edtavCcustomertypeid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerPhone_Enabled ;
      private int edtCustomerVatNumber_Enabled ;
      private int edtCustomerKvkNumber_Enabled ;
      private int edtCustomerTypeId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCustomeridfiltercontainer_Class ;
      private string divCustomernamefiltercontainer_Class ;
      private string divCustomeremailfiltercontainer_Class ;
      private string divCustomerphonefiltercontainer_Class ;
      private string divCustomervatnumberfiltercontainer_Class ;
      private string divCustomerkvknumberfiltercontainer_Class ;
      private string divCustomertypeidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV9cCustomerPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCustomeridfiltercontainer_Internalname ;
      private string lblLblcustomeridfilter_Internalname ;
      private string lblLblcustomeridfilter_Jsonclick ;
      private string edtavCcustomerid_Internalname ;
      private string TempTags ;
      private string edtavCcustomerid_Jsonclick ;
      private string divCustomernamefiltercontainer_Internalname ;
      private string lblLblcustomernamefilter_Internalname ;
      private string lblLblcustomernamefilter_Jsonclick ;
      private string edtavCcustomername_Internalname ;
      private string edtavCcustomername_Jsonclick ;
      private string divCustomeremailfiltercontainer_Internalname ;
      private string lblLblcustomeremailfilter_Internalname ;
      private string lblLblcustomeremailfilter_Jsonclick ;
      private string edtavCcustomeremail_Internalname ;
      private string edtavCcustomeremail_Jsonclick ;
      private string divCustomerphonefiltercontainer_Internalname ;
      private string lblLblcustomerphonefilter_Internalname ;
      private string lblLblcustomerphonefilter_Jsonclick ;
      private string edtavCcustomerphone_Internalname ;
      private string edtavCcustomerphone_Jsonclick ;
      private string divCustomervatnumberfiltercontainer_Internalname ;
      private string lblLblcustomervatnumberfilter_Internalname ;
      private string lblLblcustomervatnumberfilter_Jsonclick ;
      private string edtavCcustomervatnumber_Internalname ;
      private string edtavCcustomervatnumber_Jsonclick ;
      private string divCustomerkvknumberfiltercontainer_Internalname ;
      private string lblLblcustomerkvknumberfilter_Internalname ;
      private string lblLblcustomerkvknumberfilter_Jsonclick ;
      private string edtavCcustomerkvknumber_Internalname ;
      private string edtavCcustomerkvknumber_Jsonclick ;
      private string divCustomertypeidfiltercontainer_Internalname ;
      private string lblLblcustomertypeidfilter_Internalname ;
      private string lblLblcustomertypeidfilter_Jsonclick ;
      private string edtavCcustomertypeid_Internalname ;
      private string edtavCcustomertypeid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerName_Internalname ;
      private string A7CustomerPhone ;
      private string edtCustomerPhone_Internalname ;
      private string edtCustomerVatNumber_Internalname ;
      private string edtCustomerKvkNumber_Internalname ;
      private string edtCustomerTypeId_Internalname ;
      private string lV9cCustomerPhone ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerName_Jsonclick ;
      private string gxphoneLink ;
      private string edtCustomerPhone_Jsonclick ;
      private string edtCustomerVatNumber_Jsonclick ;
      private string edtCustomerKvkNumber_Link ;
      private string edtCustomerKvkNumber_Jsonclick ;
      private string edtCustomerTypeId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n7CustomerPhone ;
      private bool n78CustomerTypeId ;
      private bool gxdyncontrolsrefreshing ;
      private bool n5CustomerEmail ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cCustomerName ;
      private string AV8cCustomerEmail ;
      private string AV10cCustomerVatNumber ;
      private string AV11cCustomerKvkNumber ;
      private string AV15Linkselection_GXI ;
      private string A3CustomerName ;
      private string A14CustomerVatNumber ;
      private string A41CustomerKvkNumber ;
      private string lV7cCustomerName ;
      private string lV8cCustomerEmail ;
      private string lV10cCustomerVatNumber ;
      private string lV11cCustomerKvkNumber ;
      private string A5CustomerEmail ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000E2_A5CustomerEmail ;
      private bool[] H000E2_n5CustomerEmail ;
      private short[] H000E2_A78CustomerTypeId ;
      private bool[] H000E2_n78CustomerTypeId ;
      private string[] H000E2_A41CustomerKvkNumber ;
      private string[] H000E2_A14CustomerVatNumber ;
      private string[] H000E2_A7CustomerPhone ;
      private bool[] H000E2_n7CustomerPhone ;
      private string[] H000E2_A3CustomerName ;
      private short[] H000E2_A1CustomerId ;
      private long[] H000E3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pCustomerId ;
   }

   public class gx0010__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000E2( IGxContext context ,
                                             string AV7cCustomerName ,
                                             string AV8cCustomerEmail ,
                                             string AV9cCustomerPhone ,
                                             string AV10cCustomerVatNumber ,
                                             string AV11cCustomerKvkNumber ,
                                             short AV12cCustomerTypeId ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A41CustomerKvkNumber ,
                                             short A78CustomerTypeId ,
                                             short AV6cCustomerId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CustomerEmail, CustomerTypeId, CustomerKvkNumber, CustomerVatNumber, CustomerPhone, CustomerName, CustomerId";
         sFromString = " FROM Customer";
         sOrderString = "";
         AddWhere(sWhereString, "(CustomerId >= :AV6cCustomerId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCustomerName)) )
         {
            AddWhere(sWhereString, "(CustomerName like :lV7cCustomerName)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCustomerEmail)) )
         {
            AddWhere(sWhereString, "(CustomerEmail like :lV8cCustomerEmail)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCustomerPhone)) )
         {
            AddWhere(sWhereString, "(CustomerPhone like :lV9cCustomerPhone)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cCustomerVatNumber)) )
         {
            AddWhere(sWhereString, "(CustomerVatNumber like :lV10cCustomerVatNumber)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cCustomerKvkNumber)) )
         {
            AddWhere(sWhereString, "(CustomerKvkNumber like :lV11cCustomerKvkNumber)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cCustomerTypeId) )
         {
            AddWhere(sWhereString, "(CustomerTypeId >= :AV12cCustomerTypeId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY CustomerId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000E3( IGxContext context ,
                                             string AV7cCustomerName ,
                                             string AV8cCustomerEmail ,
                                             string AV9cCustomerPhone ,
                                             string AV10cCustomerVatNumber ,
                                             string AV11cCustomerKvkNumber ,
                                             short AV12cCustomerTypeId ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A41CustomerKvkNumber ,
                                             short A78CustomerTypeId ,
                                             short AV6cCustomerId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Customer";
         AddWhere(sWhereString, "(CustomerId >= :AV6cCustomerId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCustomerName)) )
         {
            AddWhere(sWhereString, "(CustomerName like :lV7cCustomerName)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCustomerEmail)) )
         {
            AddWhere(sWhereString, "(CustomerEmail like :lV8cCustomerEmail)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCustomerPhone)) )
         {
            AddWhere(sWhereString, "(CustomerPhone like :lV9cCustomerPhone)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cCustomerVatNumber)) )
         {
            AddWhere(sWhereString, "(CustomerVatNumber like :lV10cCustomerVatNumber)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cCustomerKvkNumber)) )
         {
            AddWhere(sWhereString, "(CustomerKvkNumber like :lV11cCustomerKvkNumber)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cCustomerTypeId) )
         {
            AddWhere(sWhereString, "(CustomerTypeId >= :AV12cCustomerTypeId)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H000E3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH000E2;
          prmH000E2 = new Object[] {
          new ParDef("AV6cCustomerId",GXType.Int16,4,0) ,
          new ParDef("lV7cCustomerName",GXType.VarChar,40,0) ,
          new ParDef("lV8cCustomerEmail",GXType.VarChar,100,0) ,
          new ParDef("lV9cCustomerPhone",GXType.Char,20,0) ,
          new ParDef("lV10cCustomerVatNumber",GXType.VarChar,14,0) ,
          new ParDef("lV11cCustomerKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("AV12cCustomerTypeId",GXType.Int16,4,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000E3;
          prmH000E3 = new Object[] {
          new ParDef("AV6cCustomerId",GXType.Int16,4,0) ,
          new ParDef("lV7cCustomerName",GXType.VarChar,40,0) ,
          new ParDef("lV8cCustomerEmail",GXType.VarChar,100,0) ,
          new ParDef("lV9cCustomerPhone",GXType.Char,20,0) ,
          new ParDef("lV10cCustomerVatNumber",GXType.VarChar,14,0) ,
          new ParDef("lV11cCustomerKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("AV12cCustomerTypeId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((short[]) buf[9])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
