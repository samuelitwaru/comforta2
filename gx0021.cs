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
   public class gx0021 : GXDataArea
   {
      public gx0021( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0021( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pCustomerId ,
                           out short aP1_pCustomerManagerId )
      {
         this.AV12pCustomerId = aP0_pCustomerId;
         this.AV13pCustomerManagerId = 0 ;
         ExecuteImpl();
         aP1_pCustomerManagerId=this.AV13pCustomerManagerId;
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
               AV12pCustomerId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pCustomerId", StringUtil.LTrimStr( (decimal)(AV12pCustomerId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pCustomerManagerId = (short)(Math.Round(NumberUtil.Val( GetPar( "pCustomerManagerId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pCustomerManagerId", StringUtil.LTrimStr( (decimal)(AV13pCustomerManagerId), 4, 0));
               }
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
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
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
         AV6cCustomerManagerId = (short)(Math.Round(NumberUtil.Val( GetPar( "cCustomerManagerId"), "."), 18, MidpointRounding.ToEven));
         AV7cCustomerManagerGivenName = GetPar( "cCustomerManagerGivenName");
         AV8cCustomerManagerLastName = GetPar( "cCustomerManagerLastName");
         AV9cCustomerManagerInitials = GetPar( "cCustomerManagerInitials");
         AV10cCustomerManagerEmail = GetPar( "cCustomerManagerEmail");
         AV11cCustomerManagerPhone = GetPar( "cCustomerManagerPhone");
         AV12pCustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "pCustomerId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerManagerId, AV7cCustomerManagerGivenName, AV8cCustomerManagerLastName, AV9cCustomerManagerInitials, AV10cCustomerManagerEmail, AV11cCustomerManagerPhone, AV12pCustomerId) ;
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
            return "gx0021_Execute" ;
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
         PA0F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0F2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0021.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pCustomerId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pCustomerManagerId,4,0))}, new string[] {"pCustomerId","pCustomerManagerId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERMANAGERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERMANAGERGIVENNAME", AV7cCustomerManagerGivenName);
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERMANAGERLASTNAME", AV8cCustomerManagerLastName);
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERMANAGERINITIALS", StringUtil.RTrim( AV9cCustomerManagerInitials));
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERMANAGEREMAIL", AV10cCustomerManagerEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERMANAGERPHONE", StringUtil.RTrim( AV11cCustomerManagerPhone));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pCustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCUSTOMERMANAGERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pCustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERIDFILTERCONTAINER_Class", StringUtil.RTrim( divCustomermanageridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERGIVENNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divCustomermanagergivennamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERLASTNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divCustomermanagerlastnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERINITIALSFILTERCONTAINER_Class", StringUtil.RTrim( divCustomermanagerinitialsfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGEREMAILFILTERCONTAINER_Class", StringUtil.RTrim( divCustomermanageremailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divCustomermanagerphonefiltercontainer_Class));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0F2( ) ;
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
         return formatLink("gx0021.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pCustomerId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pCustomerManagerId,4,0))}, new string[] {"pCustomerId","pCustomerManagerId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0021" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Manager", "") ;
      }

      protected void WB0F0( )
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
            GxWebStd.gx_div_start( context, divCustomermanageridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomermanageridfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomermanageridfilter_Internalname, context.GetMessage( "Customer Manager Id", ""), "", "", lblLblcustomermanageridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomermanagerid_Internalname, context.GetMessage( "Customer Manager Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomermanagerid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcustomermanagerid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cCustomerManagerId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cCustomerManagerId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomermanagerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomermanagerid_Visible, edtavCcustomermanagerid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0021.htm");
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
            GxWebStd.gx_div_start( context, divCustomermanagergivennamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomermanagergivennamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomermanagergivennamefilter_Internalname, context.GetMessage( "Customer Manager Given Name", ""), "", "", lblLblcustomermanagergivennamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomermanagergivenname_Internalname, context.GetMessage( "Customer Manager Given Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomermanagergivenname_Internalname, AV7cCustomerManagerGivenName, StringUtil.RTrim( context.localUtil.Format( AV7cCustomerManagerGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomermanagergivenname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomermanagergivenname_Visible, edtavCcustomermanagergivenname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0021.htm");
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
            GxWebStd.gx_div_start( context, divCustomermanagerlastnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomermanagerlastnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomermanagerlastnamefilter_Internalname, context.GetMessage( "Customer Manager Last Name", ""), "", "", lblLblcustomermanagerlastnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomermanagerlastname_Internalname, context.GetMessage( "Customer Manager Last Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomermanagerlastname_Internalname, AV8cCustomerManagerLastName, StringUtil.RTrim( context.localUtil.Format( AV8cCustomerManagerLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomermanagerlastname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomermanagerlastname_Visible, edtavCcustomermanagerlastname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0021.htm");
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
            GxWebStd.gx_div_start( context, divCustomermanagerinitialsfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomermanagerinitialsfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomermanagerinitialsfilter_Internalname, context.GetMessage( "Customer Manager Initials", ""), "", "", lblLblcustomermanagerinitialsfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomermanagerinitials_Internalname, context.GetMessage( "Customer Manager Initials", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomermanagerinitials_Internalname, StringUtil.RTrim( AV9cCustomerManagerInitials), StringUtil.RTrim( context.localUtil.Format( AV9cCustomerManagerInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomermanagerinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomermanagerinitials_Visible, edtavCcustomermanagerinitials_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0021.htm");
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
            GxWebStd.gx_div_start( context, divCustomermanageremailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomermanageremailfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomermanageremailfilter_Internalname, context.GetMessage( "Customer Manager Email", ""), "", "", lblLblcustomermanageremailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomermanageremail_Internalname, context.GetMessage( "Customer Manager Email", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomermanageremail_Internalname, AV10cCustomerManagerEmail, StringUtil.RTrim( context.localUtil.Format( AV10cCustomerManagerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomermanageremail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomermanageremail_Visible, edtavCcustomermanageremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0021.htm");
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
            GxWebStd.gx_div_start( context, divCustomermanagerphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomermanagerphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomermanagerphonefilter_Internalname, context.GetMessage( "Customer Manager Phone", ""), "", "", lblLblcustomermanagerphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomermanagerphone_Internalname, context.GetMessage( "Customer Manager Phone", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomermanagerphone_Internalname, StringUtil.RTrim( AV11cCustomerManagerPhone), StringUtil.RTrim( context.localUtil.Format( AV11cCustomerManagerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomermanagerphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomermanagerphone_Visible, edtavCcustomermanagerphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0021.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e170f1_client"+"'", TempTags, "", 2, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 74 )
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

      protected void START0F2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Manager", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0F0( ) ;
      }

      protected void WS0F2( )
      {
         START0F2( ) ;
         EVT0F2( ) ;
      }

      protected void EVT0F2( )
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
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A15CustomerManagerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerManagerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A16CustomerManagerGivenName = cgiGet( edtCustomerManagerGivenName_Internalname);
                              A9CustomerManagerLastName = cgiGet( edtCustomerManagerLastName_Internalname);
                              A17CustomerManagerInitials = cgiGet( edtCustomerManagerInitials_Internalname);
                              n17CustomerManagerInitials = false;
                              A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E180F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E190F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccustomermanagerid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCUSTOMERMANAGERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCustomerManagerId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomermanagergivenname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGERGIVENNAME"), AV7cCustomerManagerGivenName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomermanagerlastname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGERLASTNAME"), AV8cCustomerManagerLastName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomermanagerinitials Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGERINITIALS"), AV9cCustomerManagerInitials) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomermanageremail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGEREMAIL"), AV10cCustomerManagerEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomermanagerphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGERPHONE"), AV11cCustomerManagerPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E200F2 ();
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

      protected void WE0F2( )
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

      protected void PA0F2( )
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
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cCustomerManagerId ,
                                        string AV7cCustomerManagerGivenName ,
                                        string AV8cCustomerManagerLastName ,
                                        string AV9cCustomerManagerInitials ,
                                        string AV10cCustomerManagerEmail ,
                                        string AV11cCustomerManagerPhone ,
                                        short AV12pCustomerId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0F2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CUSTOMERMANAGERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A15CustomerManagerId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CUSTOMERMANAGERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerManagerId), 4, 0, ".", "")));
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
         RF0F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
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
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cCustomerManagerGivenName ,
                                                 AV8cCustomerManagerLastName ,
                                                 AV9cCustomerManagerInitials ,
                                                 AV10cCustomerManagerEmail ,
                                                 AV11cCustomerManagerPhone ,
                                                 A16CustomerManagerGivenName ,
                                                 A9CustomerManagerLastName ,
                                                 A17CustomerManagerInitials ,
                                                 A10CustomerManagerEmail ,
                                                 A11CustomerManagerPhone ,
                                                 AV12pCustomerId ,
                                                 AV6cCustomerManagerId ,
                                                 A1CustomerId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cCustomerManagerGivenName = StringUtil.Concat( StringUtil.RTrim( AV7cCustomerManagerGivenName), "%", "");
            lV8cCustomerManagerLastName = StringUtil.Concat( StringUtil.RTrim( AV8cCustomerManagerLastName), "%", "");
            lV9cCustomerManagerInitials = StringUtil.PadR( StringUtil.RTrim( AV9cCustomerManagerInitials), 10, "%");
            lV10cCustomerManagerEmail = StringUtil.Concat( StringUtil.RTrim( AV10cCustomerManagerEmail), "%", "");
            lV11cCustomerManagerPhone = StringUtil.PadR( StringUtil.RTrim( AV11cCustomerManagerPhone), 20, "%");
            /* Using cursor H000F2 */
            pr_default.execute(0, new Object[] {AV12pCustomerId, AV6cCustomerManagerId, lV7cCustomerManagerGivenName, lV8cCustomerManagerLastName, lV9cCustomerManagerInitials, lV10cCustomerManagerEmail, lV11cCustomerManagerPhone, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A11CustomerManagerPhone = H000F2_A11CustomerManagerPhone[0];
               n11CustomerManagerPhone = H000F2_n11CustomerManagerPhone[0];
               A10CustomerManagerEmail = H000F2_A10CustomerManagerEmail[0];
               A1CustomerId = H000F2_A1CustomerId[0];
               A17CustomerManagerInitials = H000F2_A17CustomerManagerInitials[0];
               n17CustomerManagerInitials = H000F2_n17CustomerManagerInitials[0];
               A9CustomerManagerLastName = H000F2_A9CustomerManagerLastName[0];
               A16CustomerManagerGivenName = H000F2_A16CustomerManagerGivenName[0];
               A15CustomerManagerId = H000F2_A15CustomerManagerId[0];
               /* Execute user event: Load */
               E190F2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB0F0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0F2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CUSTOMERMANAGERID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A15CustomerManagerId), "ZZZ9"), context));
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
                                              AV7cCustomerManagerGivenName ,
                                              AV8cCustomerManagerLastName ,
                                              AV9cCustomerManagerInitials ,
                                              AV10cCustomerManagerEmail ,
                                              AV11cCustomerManagerPhone ,
                                              A16CustomerManagerGivenName ,
                                              A9CustomerManagerLastName ,
                                              A17CustomerManagerInitials ,
                                              A10CustomerManagerEmail ,
                                              A11CustomerManagerPhone ,
                                              AV12pCustomerId ,
                                              AV6cCustomerManagerId ,
                                              A1CustomerId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cCustomerManagerGivenName = StringUtil.Concat( StringUtil.RTrim( AV7cCustomerManagerGivenName), "%", "");
         lV8cCustomerManagerLastName = StringUtil.Concat( StringUtil.RTrim( AV8cCustomerManagerLastName), "%", "");
         lV9cCustomerManagerInitials = StringUtil.PadR( StringUtil.RTrim( AV9cCustomerManagerInitials), 10, "%");
         lV10cCustomerManagerEmail = StringUtil.Concat( StringUtil.RTrim( AV10cCustomerManagerEmail), "%", "");
         lV11cCustomerManagerPhone = StringUtil.PadR( StringUtil.RTrim( AV11cCustomerManagerPhone), 20, "%");
         /* Using cursor H000F3 */
         pr_default.execute(1, new Object[] {AV12pCustomerId, AV6cCustomerManagerId, lV7cCustomerManagerGivenName, lV8cCustomerManagerLastName, lV9cCustomerManagerInitials, lV10cCustomerManagerEmail, lV11cCustomerManagerPhone});
         GRID1_nRecordCount = H000F3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerManagerId, AV7cCustomerManagerGivenName, AV8cCustomerManagerLastName, AV9cCustomerManagerInitials, AV10cCustomerManagerEmail, AV11cCustomerManagerPhone, AV12pCustomerId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerManagerId, AV7cCustomerManagerGivenName, AV8cCustomerManagerLastName, AV9cCustomerManagerInitials, AV10cCustomerManagerEmail, AV11cCustomerManagerPhone, AV12pCustomerId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerManagerId, AV7cCustomerManagerGivenName, AV8cCustomerManagerLastName, AV9cCustomerManagerInitials, AV10cCustomerManagerEmail, AV11cCustomerManagerPhone, AV12pCustomerId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerManagerId, AV7cCustomerManagerGivenName, AV8cCustomerManagerLastName, AV9cCustomerManagerInitials, AV10cCustomerManagerEmail, AV11cCustomerManagerPhone, AV12pCustomerId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerManagerId, AV7cCustomerManagerGivenName, AV8cCustomerManagerLastName, AV9cCustomerManagerInitials, AV10cCustomerManagerEmail, AV11cCustomerManagerPhone, AV12pCustomerId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtCustomerManagerId_Enabled = 0;
         edtCustomerManagerGivenName_Enabled = 0;
         edtCustomerManagerLastName_Enabled = 0;
         edtCustomerManagerInitials_Enabled = 0;
         edtCustomerId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E180F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcustomermanagerid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcustomermanagerid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCUSTOMERMANAGERID");
               GX_FocusControl = edtavCcustomermanagerid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCustomerManagerId = 0;
               AssignAttri("", false, "AV6cCustomerManagerId", StringUtil.LTrimStr( (decimal)(AV6cCustomerManagerId), 4, 0));
            }
            else
            {
               AV6cCustomerManagerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcustomermanagerid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cCustomerManagerId", StringUtil.LTrimStr( (decimal)(AV6cCustomerManagerId), 4, 0));
            }
            AV7cCustomerManagerGivenName = cgiGet( edtavCcustomermanagergivenname_Internalname);
            AssignAttri("", false, "AV7cCustomerManagerGivenName", AV7cCustomerManagerGivenName);
            AV8cCustomerManagerLastName = cgiGet( edtavCcustomermanagerlastname_Internalname);
            AssignAttri("", false, "AV8cCustomerManagerLastName", AV8cCustomerManagerLastName);
            AV9cCustomerManagerInitials = cgiGet( edtavCcustomermanagerinitials_Internalname);
            AssignAttri("", false, "AV9cCustomerManagerInitials", AV9cCustomerManagerInitials);
            AV10cCustomerManagerEmail = cgiGet( edtavCcustomermanageremail_Internalname);
            AssignAttri("", false, "AV10cCustomerManagerEmail", AV10cCustomerManagerEmail);
            AV11cCustomerManagerPhone = cgiGet( edtavCcustomermanagerphone_Internalname);
            AssignAttri("", false, "AV11cCustomerManagerPhone", AV11cCustomerManagerPhone);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCUSTOMERMANAGERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cCustomerManagerId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGERGIVENNAME"), AV7cCustomerManagerGivenName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGERLASTNAME"), AV8cCustomerManagerLastName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGERINITIALS"), AV9cCustomerManagerInitials) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGEREMAIL"), AV10cCustomerManagerEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERMANAGERPHONE"), AV11cCustomerManagerPhone) != 0 )
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
         E180F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E180F2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Manager", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E190F2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E200F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E200F2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCustomerManagerId = A15CustomerManagerId;
         AssignAttri("", false, "AV13pCustomerManagerId", StringUtil.LTrimStr( (decimal)(AV13pCustomerManagerId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pCustomerManagerId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCustomerManagerId"});
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
         AV12pCustomerId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV12pCustomerId", StringUtil.LTrimStr( (decimal)(AV12pCustomerId), 4, 0));
         AV13pCustomerManagerId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV13pCustomerManagerId", StringUtil.LTrimStr( (decimal)(AV13pCustomerManagerId), 4, 0));
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
         PA0F2( ) ;
         WS0F2( ) ;
         WE0F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315565915", true, true);
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
         context.AddJavascriptSource("gx0021.js", "?202491315565915", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtCustomerManagerId_Internalname = "CUSTOMERMANAGERID_"+sGXsfl_74_idx;
         edtCustomerManagerGivenName_Internalname = "CUSTOMERMANAGERGIVENNAME_"+sGXsfl_74_idx;
         edtCustomerManagerLastName_Internalname = "CUSTOMERMANAGERLASTNAME_"+sGXsfl_74_idx;
         edtCustomerManagerInitials_Internalname = "CUSTOMERMANAGERINITIALS_"+sGXsfl_74_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtCustomerManagerId_Internalname = "CUSTOMERMANAGERID_"+sGXsfl_74_fel_idx;
         edtCustomerManagerGivenName_Internalname = "CUSTOMERMANAGERGIVENNAME_"+sGXsfl_74_fel_idx;
         edtCustomerManagerLastName_Internalname = "CUSTOMERMANAGERLASTNAME_"+sGXsfl_74_fel_idx;
         edtCustomerManagerInitials_Internalname = "CUSTOMERMANAGERINITIALS_"+sGXsfl_74_fel_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB0F0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15CustomerManagerId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerManagerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCustomerManagerGivenName_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerManagerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtCustomerManagerGivenName_Internalname, "Link", edtCustomerManagerGivenName_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerGivenName_Internalname,(string)A16CustomerManagerGivenName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCustomerManagerGivenName_Link,(string)"",(string)"",(string)"",(string)edtCustomerManagerGivenName_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerLastName_Internalname,(string)A9CustomerManagerLastName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerManagerLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerManagerInitials_Internalname,StringUtil.RTrim( A17CustomerManagerInitials),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerManagerInitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes0F2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
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
            context.SendWebValue( context.GetMessage( "Manager Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Given Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Manager Initials", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Customer Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CustomerManagerId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A16CustomerManagerGivenName));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCustomerManagerGivenName_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A9CustomerManagerLastName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A17CustomerManagerInitials)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", ""))));
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
         lblLblcustomermanageridfilter_Internalname = "LBLCUSTOMERMANAGERIDFILTER";
         edtavCcustomermanagerid_Internalname = "vCCUSTOMERMANAGERID";
         divCustomermanageridfiltercontainer_Internalname = "CUSTOMERMANAGERIDFILTERCONTAINER";
         lblLblcustomermanagergivennamefilter_Internalname = "LBLCUSTOMERMANAGERGIVENNAMEFILTER";
         edtavCcustomermanagergivenname_Internalname = "vCCUSTOMERMANAGERGIVENNAME";
         divCustomermanagergivennamefiltercontainer_Internalname = "CUSTOMERMANAGERGIVENNAMEFILTERCONTAINER";
         lblLblcustomermanagerlastnamefilter_Internalname = "LBLCUSTOMERMANAGERLASTNAMEFILTER";
         edtavCcustomermanagerlastname_Internalname = "vCCUSTOMERMANAGERLASTNAME";
         divCustomermanagerlastnamefiltercontainer_Internalname = "CUSTOMERMANAGERLASTNAMEFILTERCONTAINER";
         lblLblcustomermanagerinitialsfilter_Internalname = "LBLCUSTOMERMANAGERINITIALSFILTER";
         edtavCcustomermanagerinitials_Internalname = "vCCUSTOMERMANAGERINITIALS";
         divCustomermanagerinitialsfiltercontainer_Internalname = "CUSTOMERMANAGERINITIALSFILTERCONTAINER";
         lblLblcustomermanageremailfilter_Internalname = "LBLCUSTOMERMANAGEREMAILFILTER";
         edtavCcustomermanageremail_Internalname = "vCCUSTOMERMANAGEREMAIL";
         divCustomermanageremailfiltercontainer_Internalname = "CUSTOMERMANAGEREMAILFILTERCONTAINER";
         lblLblcustomermanagerphonefilter_Internalname = "LBLCUSTOMERMANAGERPHONEFILTER";
         edtavCcustomermanagerphone_Internalname = "vCCUSTOMERMANAGERPHONE";
         divCustomermanagerphonefiltercontainer_Internalname = "CUSTOMERMANAGERPHONEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCustomerManagerId_Internalname = "CUSTOMERMANAGERID";
         edtCustomerManagerGivenName_Internalname = "CUSTOMERMANAGERGIVENNAME";
         edtCustomerManagerLastName_Internalname = "CUSTOMERMANAGERLASTNAME";
         edtCustomerManagerInitials_Internalname = "CUSTOMERMANAGERINITIALS";
         edtCustomerId_Internalname = "CUSTOMERID";
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
         edtCustomerId_Jsonclick = "";
         edtCustomerManagerInitials_Jsonclick = "";
         edtCustomerManagerLastName_Jsonclick = "";
         edtCustomerManagerGivenName_Jsonclick = "";
         edtCustomerManagerGivenName_Link = "";
         edtCustomerManagerId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtCustomerId_Enabled = 0;
         edtCustomerManagerInitials_Enabled = 0;
         edtCustomerManagerLastName_Enabled = 0;
         edtCustomerManagerGivenName_Enabled = 0;
         edtCustomerManagerId_Enabled = 0;
         edtavCcustomermanagerphone_Jsonclick = "";
         edtavCcustomermanagerphone_Enabled = 1;
         edtavCcustomermanagerphone_Visible = 1;
         edtavCcustomermanageremail_Jsonclick = "";
         edtavCcustomermanageremail_Enabled = 1;
         edtavCcustomermanageremail_Visible = 1;
         edtavCcustomermanagerinitials_Jsonclick = "";
         edtavCcustomermanagerinitials_Enabled = 1;
         edtavCcustomermanagerinitials_Visible = 1;
         edtavCcustomermanagerlastname_Jsonclick = "";
         edtavCcustomermanagerlastname_Enabled = 1;
         edtavCcustomermanagerlastname_Visible = 1;
         edtavCcustomermanagergivenname_Jsonclick = "";
         edtavCcustomermanagergivenname_Enabled = 1;
         edtavCcustomermanagergivenname_Visible = 1;
         edtavCcustomermanagerid_Jsonclick = "";
         edtavCcustomermanagerid_Enabled = 1;
         edtavCcustomermanagerid_Visible = 1;
         divCustomermanagerphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomermanageremailfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomermanagerinitialsfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomermanagerlastnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomermanagergivennamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomermanageridfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Manager", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerManagerId","fld":"vCCUSTOMERMANAGERID","pic":"ZZZ9"},{"av":"AV7cCustomerManagerGivenName","fld":"vCCUSTOMERMANAGERGIVENNAME"},{"av":"AV8cCustomerManagerLastName","fld":"vCCUSTOMERMANAGERLASTNAME"},{"av":"AV9cCustomerManagerInitials","fld":"vCCUSTOMERMANAGERINITIALS"},{"av":"AV10cCustomerManagerEmail","fld":"vCCUSTOMERMANAGEREMAIL"},{"av":"AV11cCustomerManagerPhone","fld":"vCCUSTOMERMANAGERPHONE"},{"av":"AV12pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E170F1","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLCUSTOMERMANAGERIDFILTER.CLICK","""{"handler":"E110F1","iparms":[{"av":"divCustomermanageridfiltercontainer_Class","ctrl":"CUSTOMERMANAGERIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERMANAGERIDFILTER.CLICK",""","oparms":[{"av":"divCustomermanageridfiltercontainer_Class","ctrl":"CUSTOMERMANAGERIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomermanagerid_Visible","ctrl":"vCCUSTOMERMANAGERID","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERMANAGERGIVENNAMEFILTER.CLICK","""{"handler":"E120F1","iparms":[{"av":"divCustomermanagergivennamefiltercontainer_Class","ctrl":"CUSTOMERMANAGERGIVENNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERMANAGERGIVENNAMEFILTER.CLICK",""","oparms":[{"av":"divCustomermanagergivennamefiltercontainer_Class","ctrl":"CUSTOMERMANAGERGIVENNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomermanagergivenname_Visible","ctrl":"vCCUSTOMERMANAGERGIVENNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERMANAGERLASTNAMEFILTER.CLICK","""{"handler":"E130F1","iparms":[{"av":"divCustomermanagerlastnamefiltercontainer_Class","ctrl":"CUSTOMERMANAGERLASTNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERMANAGERLASTNAMEFILTER.CLICK",""","oparms":[{"av":"divCustomermanagerlastnamefiltercontainer_Class","ctrl":"CUSTOMERMANAGERLASTNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomermanagerlastname_Visible","ctrl":"vCCUSTOMERMANAGERLASTNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERMANAGERINITIALSFILTER.CLICK","""{"handler":"E140F1","iparms":[{"av":"divCustomermanagerinitialsfiltercontainer_Class","ctrl":"CUSTOMERMANAGERINITIALSFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERMANAGERINITIALSFILTER.CLICK",""","oparms":[{"av":"divCustomermanagerinitialsfiltercontainer_Class","ctrl":"CUSTOMERMANAGERINITIALSFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomermanagerinitials_Visible","ctrl":"vCCUSTOMERMANAGERINITIALS","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERMANAGEREMAILFILTER.CLICK","""{"handler":"E150F1","iparms":[{"av":"divCustomermanageremailfiltercontainer_Class","ctrl":"CUSTOMERMANAGEREMAILFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERMANAGEREMAILFILTER.CLICK",""","oparms":[{"av":"divCustomermanageremailfiltercontainer_Class","ctrl":"CUSTOMERMANAGEREMAILFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomermanageremail_Visible","ctrl":"vCCUSTOMERMANAGEREMAIL","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERMANAGERPHONEFILTER.CLICK","""{"handler":"E160F1","iparms":[{"av":"divCustomermanagerphonefiltercontainer_Class","ctrl":"CUSTOMERMANAGERPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERMANAGERPHONEFILTER.CLICK",""","oparms":[{"av":"divCustomermanagerphonefiltercontainer_Class","ctrl":"CUSTOMERMANAGERPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomermanagerphone_Visible","ctrl":"vCCUSTOMERMANAGERPHONE","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E200F2","iparms":[{"av":"A15CustomerManagerId","fld":"CUSTOMERMANAGERID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pCustomerManagerId","fld":"vPCUSTOMERMANAGERID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerManagerId","fld":"vCCUSTOMERMANAGERID","pic":"ZZZ9"},{"av":"AV7cCustomerManagerGivenName","fld":"vCCUSTOMERMANAGERGIVENNAME"},{"av":"AV8cCustomerManagerLastName","fld":"vCCUSTOMERMANAGERLASTNAME"},{"av":"AV9cCustomerManagerInitials","fld":"vCCUSTOMERMANAGERINITIALS"},{"av":"AV10cCustomerManagerEmail","fld":"vCCUSTOMERMANAGEREMAIL"},{"av":"AV11cCustomerManagerPhone","fld":"vCCUSTOMERMANAGERPHONE"},{"av":"AV12pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerManagerId","fld":"vCCUSTOMERMANAGERID","pic":"ZZZ9"},{"av":"AV7cCustomerManagerGivenName","fld":"vCCUSTOMERMANAGERGIVENNAME"},{"av":"AV8cCustomerManagerLastName","fld":"vCCUSTOMERMANAGERLASTNAME"},{"av":"AV9cCustomerManagerInitials","fld":"vCCUSTOMERMANAGERINITIALS"},{"av":"AV10cCustomerManagerEmail","fld":"vCCUSTOMERMANAGEREMAIL"},{"av":"AV11cCustomerManagerPhone","fld":"vCCUSTOMERMANAGERPHONE"},{"av":"AV12pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerManagerId","fld":"vCCUSTOMERMANAGERID","pic":"ZZZ9"},{"av":"AV7cCustomerManagerGivenName","fld":"vCCUSTOMERMANAGERGIVENNAME"},{"av":"AV8cCustomerManagerLastName","fld":"vCCUSTOMERMANAGERLASTNAME"},{"av":"AV9cCustomerManagerInitials","fld":"vCCUSTOMERMANAGERINITIALS"},{"av":"AV10cCustomerManagerEmail","fld":"vCCUSTOMERMANAGEREMAIL"},{"av":"AV11cCustomerManagerPhone","fld":"vCCUSTOMERMANAGERPHONE"},{"av":"AV12pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerManagerId","fld":"vCCUSTOMERMANAGERID","pic":"ZZZ9"},{"av":"AV7cCustomerManagerGivenName","fld":"vCCUSTOMERMANAGERGIVENNAME"},{"av":"AV8cCustomerManagerLastName","fld":"vCCUSTOMERMANAGERLASTNAME"},{"av":"AV9cCustomerManagerInitials","fld":"vCCUSTOMERMANAGERINITIALS"},{"av":"AV10cCustomerManagerEmail","fld":"vCCUSTOMERMANAGEREMAIL"},{"av":"AV11cCustomerManagerPhone","fld":"vCCUSTOMERMANAGERPHONE"},{"av":"AV12pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALIDV_CCUSTOMERMANAGEREMAIL","""{"handler":"Validv_Ccustomermanageremail","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Customerid","iparms":[]}""");
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
         AV7cCustomerManagerGivenName = "";
         AV8cCustomerManagerLastName = "";
         AV9cCustomerManagerInitials = "";
         AV10cCustomerManagerEmail = "";
         AV11cCustomerManagerPhone = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcustomermanageridfilter_Jsonclick = "";
         TempTags = "";
         lblLblcustomermanagergivennamefilter_Jsonclick = "";
         lblLblcustomermanagerlastnamefilter_Jsonclick = "";
         lblLblcustomermanagerinitialsfilter_Jsonclick = "";
         lblLblcustomermanageremailfilter_Jsonclick = "";
         lblLblcustomermanagerphonefilter_Jsonclick = "";
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
         A16CustomerManagerGivenName = "";
         A9CustomerManagerLastName = "";
         A17CustomerManagerInitials = "";
         lV7cCustomerManagerGivenName = "";
         lV8cCustomerManagerLastName = "";
         lV9cCustomerManagerInitials = "";
         lV10cCustomerManagerEmail = "";
         lV11cCustomerManagerPhone = "";
         A10CustomerManagerEmail = "";
         A11CustomerManagerPhone = "";
         H000F2_A11CustomerManagerPhone = new string[] {""} ;
         H000F2_n11CustomerManagerPhone = new bool[] {false} ;
         H000F2_A10CustomerManagerEmail = new string[] {""} ;
         H000F2_A1CustomerId = new short[1] ;
         H000F2_A17CustomerManagerInitials = new string[] {""} ;
         H000F2_n17CustomerManagerInitials = new bool[] {false} ;
         H000F2_A9CustomerManagerLastName = new string[] {""} ;
         H000F2_A16CustomerManagerGivenName = new string[] {""} ;
         H000F2_A15CustomerManagerId = new short[1] ;
         H000F3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0021__default(),
            new Object[][] {
                new Object[] {
               H000F2_A11CustomerManagerPhone, H000F2_n11CustomerManagerPhone, H000F2_A10CustomerManagerEmail, H000F2_A1CustomerId, H000F2_A17CustomerManagerInitials, H000F2_n17CustomerManagerInitials, H000F2_A9CustomerManagerLastName, H000F2_A16CustomerManagerGivenName, H000F2_A15CustomerManagerId
               }
               , new Object[] {
               H000F3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12pCustomerId ;
      private short AV13pCustomerManagerId ;
      private short wcpOAV12pCustomerId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cCustomerManagerId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A15CustomerManagerId ;
      private short A1CustomerId ;
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCcustomermanagerid_Enabled ;
      private int edtavCcustomermanagerid_Visible ;
      private int edtavCcustomermanagergivenname_Visible ;
      private int edtavCcustomermanagergivenname_Enabled ;
      private int edtavCcustomermanagerlastname_Visible ;
      private int edtavCcustomermanagerlastname_Enabled ;
      private int edtavCcustomermanagerinitials_Visible ;
      private int edtavCcustomermanagerinitials_Enabled ;
      private int edtavCcustomermanageremail_Visible ;
      private int edtavCcustomermanageremail_Enabled ;
      private int edtavCcustomermanagerphone_Visible ;
      private int edtavCcustomermanagerphone_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCustomerManagerId_Enabled ;
      private int edtCustomerManagerGivenName_Enabled ;
      private int edtCustomerManagerLastName_Enabled ;
      private int edtCustomerManagerInitials_Enabled ;
      private int edtCustomerId_Enabled ;
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
      private string divCustomermanageridfiltercontainer_Class ;
      private string divCustomermanagergivennamefiltercontainer_Class ;
      private string divCustomermanagerlastnamefiltercontainer_Class ;
      private string divCustomermanagerinitialsfiltercontainer_Class ;
      private string divCustomermanageremailfiltercontainer_Class ;
      private string divCustomermanagerphonefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV9cCustomerManagerInitials ;
      private string AV11cCustomerManagerPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCustomermanageridfiltercontainer_Internalname ;
      private string lblLblcustomermanageridfilter_Internalname ;
      private string lblLblcustomermanageridfilter_Jsonclick ;
      private string edtavCcustomermanagerid_Internalname ;
      private string TempTags ;
      private string edtavCcustomermanagerid_Jsonclick ;
      private string divCustomermanagergivennamefiltercontainer_Internalname ;
      private string lblLblcustomermanagergivennamefilter_Internalname ;
      private string lblLblcustomermanagergivennamefilter_Jsonclick ;
      private string edtavCcustomermanagergivenname_Internalname ;
      private string edtavCcustomermanagergivenname_Jsonclick ;
      private string divCustomermanagerlastnamefiltercontainer_Internalname ;
      private string lblLblcustomermanagerlastnamefilter_Internalname ;
      private string lblLblcustomermanagerlastnamefilter_Jsonclick ;
      private string edtavCcustomermanagerlastname_Internalname ;
      private string edtavCcustomermanagerlastname_Jsonclick ;
      private string divCustomermanagerinitialsfiltercontainer_Internalname ;
      private string lblLblcustomermanagerinitialsfilter_Internalname ;
      private string lblLblcustomermanagerinitialsfilter_Jsonclick ;
      private string edtavCcustomermanagerinitials_Internalname ;
      private string edtavCcustomermanagerinitials_Jsonclick ;
      private string divCustomermanageremailfiltercontainer_Internalname ;
      private string lblLblcustomermanageremailfilter_Internalname ;
      private string lblLblcustomermanageremailfilter_Jsonclick ;
      private string edtavCcustomermanageremail_Internalname ;
      private string edtavCcustomermanageremail_Jsonclick ;
      private string divCustomermanagerphonefiltercontainer_Internalname ;
      private string lblLblcustomermanagerphonefilter_Internalname ;
      private string lblLblcustomermanagerphonefilter_Jsonclick ;
      private string edtavCcustomermanagerphone_Internalname ;
      private string edtavCcustomermanagerphone_Jsonclick ;
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
      private string edtCustomerManagerId_Internalname ;
      private string edtCustomerManagerGivenName_Internalname ;
      private string edtCustomerManagerLastName_Internalname ;
      private string A17CustomerManagerInitials ;
      private string edtCustomerManagerInitials_Internalname ;
      private string edtCustomerId_Internalname ;
      private string lV9cCustomerManagerInitials ;
      private string lV11cCustomerManagerPhone ;
      private string A11CustomerManagerPhone ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCustomerManagerId_Jsonclick ;
      private string edtCustomerManagerGivenName_Link ;
      private string edtCustomerManagerGivenName_Jsonclick ;
      private string edtCustomerManagerLastName_Jsonclick ;
      private string edtCustomerManagerInitials_Jsonclick ;
      private string edtCustomerId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n17CustomerManagerInitials ;
      private bool gxdyncontrolsrefreshing ;
      private bool n11CustomerManagerPhone ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cCustomerManagerGivenName ;
      private string AV8cCustomerManagerLastName ;
      private string AV10cCustomerManagerEmail ;
      private string AV15Linkselection_GXI ;
      private string A16CustomerManagerGivenName ;
      private string A9CustomerManagerLastName ;
      private string lV7cCustomerManagerGivenName ;
      private string lV8cCustomerManagerLastName ;
      private string lV10cCustomerManagerEmail ;
      private string A10CustomerManagerEmail ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000F2_A11CustomerManagerPhone ;
      private bool[] H000F2_n11CustomerManagerPhone ;
      private string[] H000F2_A10CustomerManagerEmail ;
      private short[] H000F2_A1CustomerId ;
      private string[] H000F2_A17CustomerManagerInitials ;
      private bool[] H000F2_n17CustomerManagerInitials ;
      private string[] H000F2_A9CustomerManagerLastName ;
      private string[] H000F2_A16CustomerManagerGivenName ;
      private short[] H000F2_A15CustomerManagerId ;
      private long[] H000F3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pCustomerManagerId ;
   }

   public class gx0021__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000F2( IGxContext context ,
                                             string AV7cCustomerManagerGivenName ,
                                             string AV8cCustomerManagerLastName ,
                                             string AV9cCustomerManagerInitials ,
                                             string AV10cCustomerManagerEmail ,
                                             string AV11cCustomerManagerPhone ,
                                             string A16CustomerManagerGivenName ,
                                             string A9CustomerManagerLastName ,
                                             string A17CustomerManagerInitials ,
                                             string A10CustomerManagerEmail ,
                                             string A11CustomerManagerPhone ,
                                             short AV12pCustomerId ,
                                             short AV6cCustomerManagerId ,
                                             short A1CustomerId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CustomerManagerPhone, CustomerManagerEmail, CustomerId, CustomerManagerInitials, CustomerManagerLastName, CustomerManagerGivenName, CustomerManagerId";
         sFromString = " FROM CustomerManager";
         sOrderString = "";
         AddWhere(sWhereString, "(CustomerId = :AV12pCustomerId and CustomerManagerId >= :AV6cCustomerManagerId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCustomerManagerGivenName)) )
         {
            AddWhere(sWhereString, "(CustomerManagerGivenName like :lV7cCustomerManagerGivenName)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCustomerManagerLastName)) )
         {
            AddWhere(sWhereString, "(CustomerManagerLastName like :lV8cCustomerManagerLastName)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCustomerManagerInitials)) )
         {
            AddWhere(sWhereString, "(CustomerManagerInitials like :lV9cCustomerManagerInitials)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cCustomerManagerEmail)) )
         {
            AddWhere(sWhereString, "(CustomerManagerEmail like :lV10cCustomerManagerEmail)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cCustomerManagerPhone)) )
         {
            AddWhere(sWhereString, "(CustomerManagerPhone like :lV11cCustomerManagerPhone)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY CustomerId, CustomerManagerId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000F3( IGxContext context ,
                                             string AV7cCustomerManagerGivenName ,
                                             string AV8cCustomerManagerLastName ,
                                             string AV9cCustomerManagerInitials ,
                                             string AV10cCustomerManagerEmail ,
                                             string AV11cCustomerManagerPhone ,
                                             string A16CustomerManagerGivenName ,
                                             string A9CustomerManagerLastName ,
                                             string A17CustomerManagerInitials ,
                                             string A10CustomerManagerEmail ,
                                             string A11CustomerManagerPhone ,
                                             short AV12pCustomerId ,
                                             short AV6cCustomerManagerId ,
                                             short A1CustomerId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM CustomerManager";
         AddWhere(sWhereString, "(CustomerId = :AV12pCustomerId and CustomerManagerId >= :AV6cCustomerManagerId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCustomerManagerGivenName)) )
         {
            AddWhere(sWhereString, "(CustomerManagerGivenName like :lV7cCustomerManagerGivenName)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCustomerManagerLastName)) )
         {
            AddWhere(sWhereString, "(CustomerManagerLastName like :lV8cCustomerManagerLastName)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCustomerManagerInitials)) )
         {
            AddWhere(sWhereString, "(CustomerManagerInitials like :lV9cCustomerManagerInitials)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cCustomerManagerEmail)) )
         {
            AddWhere(sWhereString, "(CustomerManagerEmail like :lV10cCustomerManagerEmail)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cCustomerManagerPhone)) )
         {
            AddWhere(sWhereString, "(CustomerManagerPhone like :lV11cCustomerManagerPhone)");
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
                     return conditional_H000F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H000F3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmH000F2;
          prmH000F2 = new Object[] {
          new ParDef("AV12pCustomerId",GXType.Int16,4,0) ,
          new ParDef("AV6cCustomerManagerId",GXType.Int16,4,0) ,
          new ParDef("lV7cCustomerManagerGivenName",GXType.VarChar,40,0) ,
          new ParDef("lV8cCustomerManagerLastName",GXType.VarChar,40,0) ,
          new ParDef("lV9cCustomerManagerInitials",GXType.Char,10,0) ,
          new ParDef("lV10cCustomerManagerEmail",GXType.VarChar,100,0) ,
          new ParDef("lV11cCustomerManagerPhone",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000F3;
          prmH000F3 = new Object[] {
          new ParDef("AV12pCustomerId",GXType.Int16,4,0) ,
          new ParDef("AV6cCustomerManagerId",GXType.Int16,4,0) ,
          new ParDef("lV7cCustomerManagerGivenName",GXType.VarChar,40,0) ,
          new ParDef("lV8cCustomerManagerLastName",GXType.VarChar,40,0) ,
          new ParDef("lV9cCustomerManagerInitials",GXType.Char,10,0) ,
          new ParDef("lV10cCustomerManagerEmail",GXType.VarChar,100,0) ,
          new ParDef("lV11cCustomerManagerPhone",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
