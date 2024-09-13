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
   public class gx0080 : GXDataArea
   {
      public gx0080( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0080( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pSupplier_AgbId )
      {
         this.AV13pSupplier_AgbId = 0 ;
         ExecuteImpl();
         aP0_pSupplier_AgbId=this.AV13pSupplier_AgbId;
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
            gxfirstwebparm = GetFirstPar( "pSupplier_AgbId");
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
               gxfirstwebparm = GetFirstPar( "pSupplier_AgbId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pSupplier_AgbId");
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
               AV13pSupplier_AgbId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pSupplier_AgbId", StringUtil.LTrimStr( (decimal)(AV13pSupplier_AgbId), 4, 0));
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
         AV6cSupplier_AgbId = (short)(Math.Round(NumberUtil.Val( GetPar( "cSupplier_AgbId"), "."), 18, MidpointRounding.ToEven));
         AV7cSupplier_AgbNumber = GetPar( "cSupplier_AgbNumber");
         AV8cSupplier_AgbName = GetPar( "cSupplier_AgbName");
         AV9cSupplier_AgbKvkNumber = GetPar( "cSupplier_AgbKvkNumber");
         AV10cSupplier_AgbEmail = GetPar( "cSupplier_AgbEmail");
         AV11cSupplier_AgbPhone = GetPar( "cSupplier_AgbPhone");
         AV12cSupplier_AgbContactName = GetPar( "cSupplier_AgbContactName");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_AgbId, AV7cSupplier_AgbNumber, AV8cSupplier_AgbName, AV9cSupplier_AgbKvkNumber, AV10cSupplier_AgbEmail, AV11cSupplier_AgbPhone, AV12cSupplier_AgbContactName) ;
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
            return "gx0080_Execute" ;
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
         PA072( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START072( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0080.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSupplier_AgbId,4,0))}, new string[] {"pSupplier_AgbId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_AGBID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSupplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_AGBNUMBER", AV7cSupplier_AgbNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_AGBNAME", AV8cSupplier_AgbName);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_AGBKVKNUMBER", AV9cSupplier_AgbKvkNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_AGBEMAIL", AV10cSupplier_AgbEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_AGBPHONE", StringUtil.RTrim( AV11cSupplier_AgbPhone));
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_AGBCONTACTNAME", AV12cSupplier_AgbContactName);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPSUPPLIER_AGBID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pSupplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBIDFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_agbidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_agbnumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_agbnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBKVKNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_agbkvknumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_agbemailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_agbphonefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBCONTACTNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_agbcontactnamefiltercontainer_Class));
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
            WE072( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT072( ) ;
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
         return formatLink("gx0080.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSupplier_AgbId,4,0))}, new string[] {"pSupplier_AgbId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0080" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Supplier_AGB", "") ;
      }

      protected void WB070( )
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
            GxWebStd.gx_div_start( context, divSupplier_agbidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_agbidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_agbidfilter_Internalname, context.GetMessage( "Supplier_Agb Id", ""), "", "", lblLblsupplier_agbidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_agbid_Internalname, context.GetMessage( "Supplier_Agb Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_agbid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSupplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsupplier_agbid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cSupplier_AgbId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cSupplier_AgbId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_agbid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_agbid_Visible, edtavCsupplier_agbid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_agbnumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_agbnumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_agbnumberfilter_Internalname, context.GetMessage( "Supplier_Agb Number", ""), "", "", lblLblsupplier_agbnumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_agbnumber_Internalname, context.GetMessage( "Supplier_Agb Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_agbnumber_Internalname, AV7cSupplier_AgbNumber, StringUtil.RTrim( context.localUtil.Format( AV7cSupplier_AgbNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_agbnumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_agbnumber_Visible, edtavCsupplier_agbnumber_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_agbnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_agbnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_agbnamefilter_Internalname, context.GetMessage( "Supplier_Agb Name", ""), "", "", lblLblsupplier_agbnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_agbname_Internalname, context.GetMessage( "Supplier_Agb Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_agbname_Internalname, AV8cSupplier_AgbName, StringUtil.RTrim( context.localUtil.Format( AV8cSupplier_AgbName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_agbname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_agbname_Visible, edtavCsupplier_agbname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_agbkvknumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_agbkvknumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_agbkvknumberfilter_Internalname, context.GetMessage( "Supplier_Agb Kvk Number", ""), "", "", lblLblsupplier_agbkvknumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_agbkvknumber_Internalname, context.GetMessage( "Supplier_Agb Kvk Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_agbkvknumber_Internalname, AV9cSupplier_AgbKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV9cSupplier_AgbKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_agbkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_agbkvknumber_Visible, edtavCsupplier_agbkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_agbemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_agbemailfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_agbemailfilter_Internalname, context.GetMessage( "Supplier_Agb Email", ""), "", "", lblLblsupplier_agbemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_agbemail_Internalname, context.GetMessage( "Supplier_Agb Email", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_agbemail_Internalname, AV10cSupplier_AgbEmail, StringUtil.RTrim( context.localUtil.Format( AV10cSupplier_AgbEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_agbemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_agbemail_Visible, edtavCsupplier_agbemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_agbphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_agbphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_agbphonefilter_Internalname, context.GetMessage( "Supplier_Agb Phone", ""), "", "", lblLblsupplier_agbphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_agbphone_Internalname, context.GetMessage( "Supplier_Agb Phone", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_agbphone_Internalname, StringUtil.RTrim( AV11cSupplier_AgbPhone), StringUtil.RTrim( context.localUtil.Format( AV11cSupplier_AgbPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_agbphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_agbphone_Visible, edtavCsupplier_agbphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_agbcontactnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_agbcontactnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_agbcontactnamefilter_Internalname, context.GetMessage( "Supplier_Agb Contact Name", ""), "", "", lblLblsupplier_agbcontactnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_agbcontactname_Internalname, context.GetMessage( "Supplier_Agb Contact Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_agbcontactname_Internalname, AV12cSupplier_AgbContactName, StringUtil.RTrim( context.localUtil.Format( AV12cSupplier_AgbContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_agbcontactname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_agbcontactname_Visible, edtavCsupplier_agbcontactname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18071_client"+"'", TempTags, "", 2, "HLP_Gx0080.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0080.htm");
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

      protected void START072( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Supplier_AGB", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP070( ) ;
      }

      protected void WS072( )
      {
         START072( ) ;
         EVT072( ) ;
      }

      protected void EVT072( )
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
                              A55Supplier_AgbId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplier_AgbId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A56Supplier_AgbNumber = cgiGet( edtSupplier_AgbNumber_Internalname);
                              A57Supplier_AgbName = cgiGet( edtSupplier_AgbName_Internalname);
                              A58Supplier_AgbKvkNumber = cgiGet( edtSupplier_AgbKvkNumber_Internalname);
                              A62Supplier_AgbPhone = cgiGet( edtSupplier_AgbPhone_Internalname);
                              n62Supplier_AgbPhone = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Csupplier_agbid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSUPPLIER_AGBID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSupplier_AgbId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_agbnumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBNUMBER"), AV7cSupplier_AgbNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_agbname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBNAME"), AV8cSupplier_AgbName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_agbkvknumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBKVKNUMBER"), AV9cSupplier_AgbKvkNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_agbemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBEMAIL"), AV10cSupplier_AgbEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_agbphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBPHONE"), AV11cSupplier_AgbPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_agbcontactname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBCONTACTNAME"), AV12cSupplier_AgbContactName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21072 ();
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

      protected void WE072( )
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

      protected void PA072( )
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
                                        short AV6cSupplier_AgbId ,
                                        string AV7cSupplier_AgbNumber ,
                                        string AV8cSupplier_AgbName ,
                                        string AV9cSupplier_AgbKvkNumber ,
                                        string AV10cSupplier_AgbEmail ,
                                        string AV11cSupplier_AgbPhone ,
                                        string AV12cSupplier_AgbContactName )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF072( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIER_AGBID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A55Supplier_AgbId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_AGBID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, ".", "")));
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
         RF072( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF072( )
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
                                                 AV7cSupplier_AgbNumber ,
                                                 AV8cSupplier_AgbName ,
                                                 AV9cSupplier_AgbKvkNumber ,
                                                 AV10cSupplier_AgbEmail ,
                                                 AV11cSupplier_AgbPhone ,
                                                 AV12cSupplier_AgbContactName ,
                                                 A56Supplier_AgbNumber ,
                                                 A57Supplier_AgbName ,
                                                 A58Supplier_AgbKvkNumber ,
                                                 A61Supplier_AgbEmail ,
                                                 A62Supplier_AgbPhone ,
                                                 A63Supplier_AgbContactName ,
                                                 AV6cSupplier_AgbId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV7cSupplier_AgbNumber = StringUtil.Concat( StringUtil.RTrim( AV7cSupplier_AgbNumber), "%", "");
            lV8cSupplier_AgbName = StringUtil.Concat( StringUtil.RTrim( AV8cSupplier_AgbName), "%", "");
            lV9cSupplier_AgbKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV9cSupplier_AgbKvkNumber), "%", "");
            lV10cSupplier_AgbEmail = StringUtil.Concat( StringUtil.RTrim( AV10cSupplier_AgbEmail), "%", "");
            lV11cSupplier_AgbPhone = StringUtil.PadR( StringUtil.RTrim( AV11cSupplier_AgbPhone), 20, "%");
            lV12cSupplier_AgbContactName = StringUtil.Concat( StringUtil.RTrim( AV12cSupplier_AgbContactName), "%", "");
            /* Using cursor H00072 */
            pr_default.execute(0, new Object[] {AV6cSupplier_AgbId, lV7cSupplier_AgbNumber, lV8cSupplier_AgbName, lV9cSupplier_AgbKvkNumber, lV10cSupplier_AgbEmail, lV11cSupplier_AgbPhone, lV12cSupplier_AgbContactName, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A63Supplier_AgbContactName = H00072_A63Supplier_AgbContactName[0];
               n63Supplier_AgbContactName = H00072_n63Supplier_AgbContactName[0];
               A61Supplier_AgbEmail = H00072_A61Supplier_AgbEmail[0];
               n61Supplier_AgbEmail = H00072_n61Supplier_AgbEmail[0];
               A62Supplier_AgbPhone = H00072_A62Supplier_AgbPhone[0];
               n62Supplier_AgbPhone = H00072_n62Supplier_AgbPhone[0];
               A58Supplier_AgbKvkNumber = H00072_A58Supplier_AgbKvkNumber[0];
               A57Supplier_AgbName = H00072_A57Supplier_AgbName[0];
               A56Supplier_AgbNumber = H00072_A56Supplier_AgbNumber[0];
               A55Supplier_AgbId = H00072_A55Supplier_AgbId[0];
               /* Execute user event: Load */
               E20072 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB070( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes072( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIER_AGBID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A55Supplier_AgbId), "ZZZ9"), context));
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
                                              AV7cSupplier_AgbNumber ,
                                              AV8cSupplier_AgbName ,
                                              AV9cSupplier_AgbKvkNumber ,
                                              AV10cSupplier_AgbEmail ,
                                              AV11cSupplier_AgbPhone ,
                                              AV12cSupplier_AgbContactName ,
                                              A56Supplier_AgbNumber ,
                                              A57Supplier_AgbName ,
                                              A58Supplier_AgbKvkNumber ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName ,
                                              AV6cSupplier_AgbId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV7cSupplier_AgbNumber = StringUtil.Concat( StringUtil.RTrim( AV7cSupplier_AgbNumber), "%", "");
         lV8cSupplier_AgbName = StringUtil.Concat( StringUtil.RTrim( AV8cSupplier_AgbName), "%", "");
         lV9cSupplier_AgbKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV9cSupplier_AgbKvkNumber), "%", "");
         lV10cSupplier_AgbEmail = StringUtil.Concat( StringUtil.RTrim( AV10cSupplier_AgbEmail), "%", "");
         lV11cSupplier_AgbPhone = StringUtil.PadR( StringUtil.RTrim( AV11cSupplier_AgbPhone), 20, "%");
         lV12cSupplier_AgbContactName = StringUtil.Concat( StringUtil.RTrim( AV12cSupplier_AgbContactName), "%", "");
         /* Using cursor H00073 */
         pr_default.execute(1, new Object[] {AV6cSupplier_AgbId, lV7cSupplier_AgbNumber, lV8cSupplier_AgbName, lV9cSupplier_AgbKvkNumber, lV10cSupplier_AgbEmail, lV11cSupplier_AgbPhone, lV12cSupplier_AgbContactName});
         GRID1_nRecordCount = H00073_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_AgbId, AV7cSupplier_AgbNumber, AV8cSupplier_AgbName, AV9cSupplier_AgbKvkNumber, AV10cSupplier_AgbEmail, AV11cSupplier_AgbPhone, AV12cSupplier_AgbContactName) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_AgbId, AV7cSupplier_AgbNumber, AV8cSupplier_AgbName, AV9cSupplier_AgbKvkNumber, AV10cSupplier_AgbEmail, AV11cSupplier_AgbPhone, AV12cSupplier_AgbContactName) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_AgbId, AV7cSupplier_AgbNumber, AV8cSupplier_AgbName, AV9cSupplier_AgbKvkNumber, AV10cSupplier_AgbEmail, AV11cSupplier_AgbPhone, AV12cSupplier_AgbContactName) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_AgbId, AV7cSupplier_AgbNumber, AV8cSupplier_AgbName, AV9cSupplier_AgbKvkNumber, AV10cSupplier_AgbEmail, AV11cSupplier_AgbPhone, AV12cSupplier_AgbContactName) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_AgbId, AV7cSupplier_AgbNumber, AV8cSupplier_AgbName, AV9cSupplier_AgbKvkNumber, AV10cSupplier_AgbEmail, AV11cSupplier_AgbPhone, AV12cSupplier_AgbContactName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtSupplier_AgbId_Enabled = 0;
         edtSupplier_AgbNumber_Enabled = 0;
         edtSupplier_AgbName_Enabled = 0;
         edtSupplier_AgbKvkNumber_Enabled = 0;
         edtSupplier_AgbPhone_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP070( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19072 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsupplier_agbid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsupplier_agbid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSUPPLIER_AGBID");
               GX_FocusControl = edtavCsupplier_agbid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cSupplier_AgbId = 0;
               AssignAttri("", false, "AV6cSupplier_AgbId", StringUtil.LTrimStr( (decimal)(AV6cSupplier_AgbId), 4, 0));
            }
            else
            {
               AV6cSupplier_AgbId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsupplier_agbid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cSupplier_AgbId", StringUtil.LTrimStr( (decimal)(AV6cSupplier_AgbId), 4, 0));
            }
            AV7cSupplier_AgbNumber = cgiGet( edtavCsupplier_agbnumber_Internalname);
            AssignAttri("", false, "AV7cSupplier_AgbNumber", AV7cSupplier_AgbNumber);
            AV8cSupplier_AgbName = cgiGet( edtavCsupplier_agbname_Internalname);
            AssignAttri("", false, "AV8cSupplier_AgbName", AV8cSupplier_AgbName);
            AV9cSupplier_AgbKvkNumber = cgiGet( edtavCsupplier_agbkvknumber_Internalname);
            AssignAttri("", false, "AV9cSupplier_AgbKvkNumber", AV9cSupplier_AgbKvkNumber);
            AV10cSupplier_AgbEmail = cgiGet( edtavCsupplier_agbemail_Internalname);
            AssignAttri("", false, "AV10cSupplier_AgbEmail", AV10cSupplier_AgbEmail);
            AV11cSupplier_AgbPhone = cgiGet( edtavCsupplier_agbphone_Internalname);
            AssignAttri("", false, "AV11cSupplier_AgbPhone", AV11cSupplier_AgbPhone);
            AV12cSupplier_AgbContactName = cgiGet( edtavCsupplier_agbcontactname_Internalname);
            AssignAttri("", false, "AV12cSupplier_AgbContactName", AV12cSupplier_AgbContactName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSUPPLIER_AGBID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSupplier_AgbId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBNUMBER"), AV7cSupplier_AgbNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBNAME"), AV8cSupplier_AgbName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBKVKNUMBER"), AV9cSupplier_AgbKvkNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBEMAIL"), AV10cSupplier_AgbEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBPHONE"), AV11cSupplier_AgbPhone) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_AGBCONTACTNAME"), AV12cSupplier_AgbContactName) != 0 )
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
         E19072 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19072( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Supplier_AGB", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E20072( )
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
         E21072 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21072( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pSupplier_AgbId = A55Supplier_AgbId;
         AssignAttri("", false, "AV13pSupplier_AgbId", StringUtil.LTrimStr( (decimal)(AV13pSupplier_AgbId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pSupplier_AgbId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pSupplier_AgbId"});
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
         AV13pSupplier_AgbId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pSupplier_AgbId", StringUtil.LTrimStr( (decimal)(AV13pSupplier_AgbId), 4, 0));
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
         PA072( ) ;
         WS072( ) ;
         WE072( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249131556535", true, true);
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
         context.AddJavascriptSource("gx0080.js", "?20249131556536", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtSupplier_AgbId_Internalname = "SUPPLIER_AGBID_"+sGXsfl_84_idx;
         edtSupplier_AgbNumber_Internalname = "SUPPLIER_AGBNUMBER_"+sGXsfl_84_idx;
         edtSupplier_AgbName_Internalname = "SUPPLIER_AGBNAME_"+sGXsfl_84_idx;
         edtSupplier_AgbKvkNumber_Internalname = "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_84_idx;
         edtSupplier_AgbPhone_Internalname = "SUPPLIER_AGBPHONE_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtSupplier_AgbId_Internalname = "SUPPLIER_AGBID_"+sGXsfl_84_fel_idx;
         edtSupplier_AgbNumber_Internalname = "SUPPLIER_AGBNUMBER_"+sGXsfl_84_fel_idx;
         edtSupplier_AgbName_Internalname = "SUPPLIER_AGBNAME_"+sGXsfl_84_fel_idx;
         edtSupplier_AgbKvkNumber_Internalname = "SUPPLIER_AGBKVKNUMBER_"+sGXsfl_84_fel_idx;
         edtSupplier_AgbPhone_Internalname = "SUPPLIER_AGBPHONE_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB070( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A55Supplier_AgbId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtSupplier_AgbNumber_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtSupplier_AgbNumber_Internalname, "Link", edtSupplier_AgbNumber_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbNumber_Internalname,(string)A56Supplier_AgbNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSupplier_AgbNumber_Link,(string)"",(string)"",(string)"",(string)edtSupplier_AgbNumber_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"AgbNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbName_Internalname,(string)A57Supplier_AgbName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbKvkNumber_Internalname,(string)A58Supplier_AgbKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_AgbKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A62Supplier_AgbPhone);
            }
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_AgbPhone_Internalname,StringUtil.RTrim( A62Supplier_AgbPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtSupplier_AgbPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes072( ) ;
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
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Kvk Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A56Supplier_AgbNumber));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtSupplier_AgbNumber_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A57Supplier_AgbName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A58Supplier_AgbKvkNumber));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A62Supplier_AgbPhone)));
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
         lblLblsupplier_agbidfilter_Internalname = "LBLSUPPLIER_AGBIDFILTER";
         edtavCsupplier_agbid_Internalname = "vCSUPPLIER_AGBID";
         divSupplier_agbidfiltercontainer_Internalname = "SUPPLIER_AGBIDFILTERCONTAINER";
         lblLblsupplier_agbnumberfilter_Internalname = "LBLSUPPLIER_AGBNUMBERFILTER";
         edtavCsupplier_agbnumber_Internalname = "vCSUPPLIER_AGBNUMBER";
         divSupplier_agbnumberfiltercontainer_Internalname = "SUPPLIER_AGBNUMBERFILTERCONTAINER";
         lblLblsupplier_agbnamefilter_Internalname = "LBLSUPPLIER_AGBNAMEFILTER";
         edtavCsupplier_agbname_Internalname = "vCSUPPLIER_AGBNAME";
         divSupplier_agbnamefiltercontainer_Internalname = "SUPPLIER_AGBNAMEFILTERCONTAINER";
         lblLblsupplier_agbkvknumberfilter_Internalname = "LBLSUPPLIER_AGBKVKNUMBERFILTER";
         edtavCsupplier_agbkvknumber_Internalname = "vCSUPPLIER_AGBKVKNUMBER";
         divSupplier_agbkvknumberfiltercontainer_Internalname = "SUPPLIER_AGBKVKNUMBERFILTERCONTAINER";
         lblLblsupplier_agbemailfilter_Internalname = "LBLSUPPLIER_AGBEMAILFILTER";
         edtavCsupplier_agbemail_Internalname = "vCSUPPLIER_AGBEMAIL";
         divSupplier_agbemailfiltercontainer_Internalname = "SUPPLIER_AGBEMAILFILTERCONTAINER";
         lblLblsupplier_agbphonefilter_Internalname = "LBLSUPPLIER_AGBPHONEFILTER";
         edtavCsupplier_agbphone_Internalname = "vCSUPPLIER_AGBPHONE";
         divSupplier_agbphonefiltercontainer_Internalname = "SUPPLIER_AGBPHONEFILTERCONTAINER";
         lblLblsupplier_agbcontactnamefilter_Internalname = "LBLSUPPLIER_AGBCONTACTNAMEFILTER";
         edtavCsupplier_agbcontactname_Internalname = "vCSUPPLIER_AGBCONTACTNAME";
         divSupplier_agbcontactnamefiltercontainer_Internalname = "SUPPLIER_AGBCONTACTNAMEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtSupplier_AgbId_Internalname = "SUPPLIER_AGBID";
         edtSupplier_AgbNumber_Internalname = "SUPPLIER_AGBNUMBER";
         edtSupplier_AgbName_Internalname = "SUPPLIER_AGBNAME";
         edtSupplier_AgbKvkNumber_Internalname = "SUPPLIER_AGBKVKNUMBER";
         edtSupplier_AgbPhone_Internalname = "SUPPLIER_AGBPHONE";
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
         edtSupplier_AgbPhone_Jsonclick = "";
         edtSupplier_AgbKvkNumber_Jsonclick = "";
         edtSupplier_AgbName_Jsonclick = "";
         edtSupplier_AgbNumber_Jsonclick = "";
         edtSupplier_AgbNumber_Link = "";
         edtSupplier_AgbId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtSupplier_AgbPhone_Enabled = 0;
         edtSupplier_AgbKvkNumber_Enabled = 0;
         edtSupplier_AgbName_Enabled = 0;
         edtSupplier_AgbNumber_Enabled = 0;
         edtSupplier_AgbId_Enabled = 0;
         edtavCsupplier_agbcontactname_Jsonclick = "";
         edtavCsupplier_agbcontactname_Enabled = 1;
         edtavCsupplier_agbcontactname_Visible = 1;
         edtavCsupplier_agbphone_Jsonclick = "";
         edtavCsupplier_agbphone_Enabled = 1;
         edtavCsupplier_agbphone_Visible = 1;
         edtavCsupplier_agbemail_Jsonclick = "";
         edtavCsupplier_agbemail_Enabled = 1;
         edtavCsupplier_agbemail_Visible = 1;
         edtavCsupplier_agbkvknumber_Jsonclick = "";
         edtavCsupplier_agbkvknumber_Enabled = 1;
         edtavCsupplier_agbkvknumber_Visible = 1;
         edtavCsupplier_agbname_Jsonclick = "";
         edtavCsupplier_agbname_Enabled = 1;
         edtavCsupplier_agbname_Visible = 1;
         edtavCsupplier_agbnumber_Jsonclick = "";
         edtavCsupplier_agbnumber_Enabled = 1;
         edtavCsupplier_agbnumber_Visible = 1;
         edtavCsupplier_agbid_Jsonclick = "";
         edtavCsupplier_agbid_Enabled = 1;
         edtavCsupplier_agbid_Visible = 1;
         divSupplier_agbcontactnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_agbphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_agbemailfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_agbkvknumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_agbnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_agbnumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_agbidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Supplier_AGB", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_AgbId","fld":"vCSUPPLIER_AGBID","pic":"ZZZ9"},{"av":"AV7cSupplier_AgbNumber","fld":"vCSUPPLIER_AGBNUMBER"},{"av":"AV8cSupplier_AgbName","fld":"vCSUPPLIER_AGBNAME"},{"av":"AV9cSupplier_AgbKvkNumber","fld":"vCSUPPLIER_AGBKVKNUMBER"},{"av":"AV10cSupplier_AgbEmail","fld":"vCSUPPLIER_AGBEMAIL"},{"av":"AV11cSupplier_AgbPhone","fld":"vCSUPPLIER_AGBPHONE"},{"av":"AV12cSupplier_AgbContactName","fld":"vCSUPPLIER_AGBCONTACTNAME"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E18071","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLSUPPLIER_AGBIDFILTER.CLICK","""{"handler":"E11071","iparms":[{"av":"divSupplier_agbidfiltercontainer_Class","ctrl":"SUPPLIER_AGBIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_AGBIDFILTER.CLICK",""","oparms":[{"av":"divSupplier_agbidfiltercontainer_Class","ctrl":"SUPPLIER_AGBIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_agbid_Visible","ctrl":"vCSUPPLIER_AGBID","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_AGBNUMBERFILTER.CLICK","""{"handler":"E12071","iparms":[{"av":"divSupplier_agbnumberfiltercontainer_Class","ctrl":"SUPPLIER_AGBNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_AGBNUMBERFILTER.CLICK",""","oparms":[{"av":"divSupplier_agbnumberfiltercontainer_Class","ctrl":"SUPPLIER_AGBNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_agbnumber_Visible","ctrl":"vCSUPPLIER_AGBNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_AGBNAMEFILTER.CLICK","""{"handler":"E13071","iparms":[{"av":"divSupplier_agbnamefiltercontainer_Class","ctrl":"SUPPLIER_AGBNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_AGBNAMEFILTER.CLICK",""","oparms":[{"av":"divSupplier_agbnamefiltercontainer_Class","ctrl":"SUPPLIER_AGBNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_agbname_Visible","ctrl":"vCSUPPLIER_AGBNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_AGBKVKNUMBERFILTER.CLICK","""{"handler":"E14071","iparms":[{"av":"divSupplier_agbkvknumberfiltercontainer_Class","ctrl":"SUPPLIER_AGBKVKNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_AGBKVKNUMBERFILTER.CLICK",""","oparms":[{"av":"divSupplier_agbkvknumberfiltercontainer_Class","ctrl":"SUPPLIER_AGBKVKNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_agbkvknumber_Visible","ctrl":"vCSUPPLIER_AGBKVKNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_AGBEMAILFILTER.CLICK","""{"handler":"E15071","iparms":[{"av":"divSupplier_agbemailfiltercontainer_Class","ctrl":"SUPPLIER_AGBEMAILFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_AGBEMAILFILTER.CLICK",""","oparms":[{"av":"divSupplier_agbemailfiltercontainer_Class","ctrl":"SUPPLIER_AGBEMAILFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_agbemail_Visible","ctrl":"vCSUPPLIER_AGBEMAIL","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_AGBPHONEFILTER.CLICK","""{"handler":"E16071","iparms":[{"av":"divSupplier_agbphonefiltercontainer_Class","ctrl":"SUPPLIER_AGBPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_AGBPHONEFILTER.CLICK",""","oparms":[{"av":"divSupplier_agbphonefiltercontainer_Class","ctrl":"SUPPLIER_AGBPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_agbphone_Visible","ctrl":"vCSUPPLIER_AGBPHONE","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_AGBCONTACTNAMEFILTER.CLICK","""{"handler":"E17071","iparms":[{"av":"divSupplier_agbcontactnamefiltercontainer_Class","ctrl":"SUPPLIER_AGBCONTACTNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_AGBCONTACTNAMEFILTER.CLICK",""","oparms":[{"av":"divSupplier_agbcontactnamefiltercontainer_Class","ctrl":"SUPPLIER_AGBCONTACTNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_agbcontactname_Visible","ctrl":"vCSUPPLIER_AGBCONTACTNAME","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E21072","iparms":[{"av":"A55Supplier_AgbId","fld":"SUPPLIER_AGBID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pSupplier_AgbId","fld":"vPSUPPLIER_AGBID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_AgbId","fld":"vCSUPPLIER_AGBID","pic":"ZZZ9"},{"av":"AV7cSupplier_AgbNumber","fld":"vCSUPPLIER_AGBNUMBER"},{"av":"AV8cSupplier_AgbName","fld":"vCSUPPLIER_AGBNAME"},{"av":"AV9cSupplier_AgbKvkNumber","fld":"vCSUPPLIER_AGBKVKNUMBER"},{"av":"AV10cSupplier_AgbEmail","fld":"vCSUPPLIER_AGBEMAIL"},{"av":"AV11cSupplier_AgbPhone","fld":"vCSUPPLIER_AGBPHONE"},{"av":"AV12cSupplier_AgbContactName","fld":"vCSUPPLIER_AGBCONTACTNAME"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_AgbId","fld":"vCSUPPLIER_AGBID","pic":"ZZZ9"},{"av":"AV7cSupplier_AgbNumber","fld":"vCSUPPLIER_AGBNUMBER"},{"av":"AV8cSupplier_AgbName","fld":"vCSUPPLIER_AGBNAME"},{"av":"AV9cSupplier_AgbKvkNumber","fld":"vCSUPPLIER_AGBKVKNUMBER"},{"av":"AV10cSupplier_AgbEmail","fld":"vCSUPPLIER_AGBEMAIL"},{"av":"AV11cSupplier_AgbPhone","fld":"vCSUPPLIER_AGBPHONE"},{"av":"AV12cSupplier_AgbContactName","fld":"vCSUPPLIER_AGBCONTACTNAME"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_AgbId","fld":"vCSUPPLIER_AGBID","pic":"ZZZ9"},{"av":"AV7cSupplier_AgbNumber","fld":"vCSUPPLIER_AGBNUMBER"},{"av":"AV8cSupplier_AgbName","fld":"vCSUPPLIER_AGBNAME"},{"av":"AV9cSupplier_AgbKvkNumber","fld":"vCSUPPLIER_AGBKVKNUMBER"},{"av":"AV10cSupplier_AgbEmail","fld":"vCSUPPLIER_AGBEMAIL"},{"av":"AV11cSupplier_AgbPhone","fld":"vCSUPPLIER_AGBPHONE"},{"av":"AV12cSupplier_AgbContactName","fld":"vCSUPPLIER_AGBCONTACTNAME"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_AgbId","fld":"vCSUPPLIER_AGBID","pic":"ZZZ9"},{"av":"AV7cSupplier_AgbNumber","fld":"vCSUPPLIER_AGBNUMBER"},{"av":"AV8cSupplier_AgbName","fld":"vCSUPPLIER_AGBNAME"},{"av":"AV9cSupplier_AgbKvkNumber","fld":"vCSUPPLIER_AGBKVKNUMBER"},{"av":"AV10cSupplier_AgbEmail","fld":"vCSUPPLIER_AGBEMAIL"},{"av":"AV11cSupplier_AgbPhone","fld":"vCSUPPLIER_AGBPHONE"},{"av":"AV12cSupplier_AgbContactName","fld":"vCSUPPLIER_AGBCONTACTNAME"}]}""");
         setEventMetadata("VALIDV_CSUPPLIER_AGBEMAIL","""{"handler":"Validv_Csupplier_agbemail","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Supplier_agbphone","iparms":[]}""");
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
         AV7cSupplier_AgbNumber = "";
         AV8cSupplier_AgbName = "";
         AV9cSupplier_AgbKvkNumber = "";
         AV10cSupplier_AgbEmail = "";
         AV11cSupplier_AgbPhone = "";
         AV12cSupplier_AgbContactName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblsupplier_agbidfilter_Jsonclick = "";
         TempTags = "";
         lblLblsupplier_agbnumberfilter_Jsonclick = "";
         lblLblsupplier_agbnamefilter_Jsonclick = "";
         lblLblsupplier_agbkvknumberfilter_Jsonclick = "";
         lblLblsupplier_agbemailfilter_Jsonclick = "";
         lblLblsupplier_agbphonefilter_Jsonclick = "";
         lblLblsupplier_agbcontactnamefilter_Jsonclick = "";
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
         A56Supplier_AgbNumber = "";
         A57Supplier_AgbName = "";
         A58Supplier_AgbKvkNumber = "";
         A62Supplier_AgbPhone = "";
         lV7cSupplier_AgbNumber = "";
         lV8cSupplier_AgbName = "";
         lV9cSupplier_AgbKvkNumber = "";
         lV10cSupplier_AgbEmail = "";
         lV11cSupplier_AgbPhone = "";
         lV12cSupplier_AgbContactName = "";
         A61Supplier_AgbEmail = "";
         A63Supplier_AgbContactName = "";
         H00072_A63Supplier_AgbContactName = new string[] {""} ;
         H00072_n63Supplier_AgbContactName = new bool[] {false} ;
         H00072_A61Supplier_AgbEmail = new string[] {""} ;
         H00072_n61Supplier_AgbEmail = new bool[] {false} ;
         H00072_A62Supplier_AgbPhone = new string[] {""} ;
         H00072_n62Supplier_AgbPhone = new bool[] {false} ;
         H00072_A58Supplier_AgbKvkNumber = new string[] {""} ;
         H00072_A57Supplier_AgbName = new string[] {""} ;
         H00072_A56Supplier_AgbNumber = new string[] {""} ;
         H00072_A55Supplier_AgbId = new short[1] ;
         H00073_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0080__default(),
            new Object[][] {
                new Object[] {
               H00072_A63Supplier_AgbContactName, H00072_n63Supplier_AgbContactName, H00072_A61Supplier_AgbEmail, H00072_n61Supplier_AgbEmail, H00072_A62Supplier_AgbPhone, H00072_n62Supplier_AgbPhone, H00072_A58Supplier_AgbKvkNumber, H00072_A57Supplier_AgbName, H00072_A56Supplier_AgbNumber, H00072_A55Supplier_AgbId
               }
               , new Object[] {
               H00073_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13pSupplier_AgbId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cSupplier_AgbId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A55Supplier_AgbId ;
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
      private int edtavCsupplier_agbid_Enabled ;
      private int edtavCsupplier_agbid_Visible ;
      private int edtavCsupplier_agbnumber_Visible ;
      private int edtavCsupplier_agbnumber_Enabled ;
      private int edtavCsupplier_agbname_Visible ;
      private int edtavCsupplier_agbname_Enabled ;
      private int edtavCsupplier_agbkvknumber_Visible ;
      private int edtavCsupplier_agbkvknumber_Enabled ;
      private int edtavCsupplier_agbemail_Visible ;
      private int edtavCsupplier_agbemail_Enabled ;
      private int edtavCsupplier_agbphone_Visible ;
      private int edtavCsupplier_agbphone_Enabled ;
      private int edtavCsupplier_agbcontactname_Visible ;
      private int edtavCsupplier_agbcontactname_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSupplier_AgbId_Enabled ;
      private int edtSupplier_AgbNumber_Enabled ;
      private int edtSupplier_AgbName_Enabled ;
      private int edtSupplier_AgbKvkNumber_Enabled ;
      private int edtSupplier_AgbPhone_Enabled ;
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
      private string divSupplier_agbidfiltercontainer_Class ;
      private string divSupplier_agbnumberfiltercontainer_Class ;
      private string divSupplier_agbnamefiltercontainer_Class ;
      private string divSupplier_agbkvknumberfiltercontainer_Class ;
      private string divSupplier_agbemailfiltercontainer_Class ;
      private string divSupplier_agbphonefiltercontainer_Class ;
      private string divSupplier_agbcontactnamefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV11cSupplier_AgbPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divSupplier_agbidfiltercontainer_Internalname ;
      private string lblLblsupplier_agbidfilter_Internalname ;
      private string lblLblsupplier_agbidfilter_Jsonclick ;
      private string edtavCsupplier_agbid_Internalname ;
      private string TempTags ;
      private string edtavCsupplier_agbid_Jsonclick ;
      private string divSupplier_agbnumberfiltercontainer_Internalname ;
      private string lblLblsupplier_agbnumberfilter_Internalname ;
      private string lblLblsupplier_agbnumberfilter_Jsonclick ;
      private string edtavCsupplier_agbnumber_Internalname ;
      private string edtavCsupplier_agbnumber_Jsonclick ;
      private string divSupplier_agbnamefiltercontainer_Internalname ;
      private string lblLblsupplier_agbnamefilter_Internalname ;
      private string lblLblsupplier_agbnamefilter_Jsonclick ;
      private string edtavCsupplier_agbname_Internalname ;
      private string edtavCsupplier_agbname_Jsonclick ;
      private string divSupplier_agbkvknumberfiltercontainer_Internalname ;
      private string lblLblsupplier_agbkvknumberfilter_Internalname ;
      private string lblLblsupplier_agbkvknumberfilter_Jsonclick ;
      private string edtavCsupplier_agbkvknumber_Internalname ;
      private string edtavCsupplier_agbkvknumber_Jsonclick ;
      private string divSupplier_agbemailfiltercontainer_Internalname ;
      private string lblLblsupplier_agbemailfilter_Internalname ;
      private string lblLblsupplier_agbemailfilter_Jsonclick ;
      private string edtavCsupplier_agbemail_Internalname ;
      private string edtavCsupplier_agbemail_Jsonclick ;
      private string divSupplier_agbphonefiltercontainer_Internalname ;
      private string lblLblsupplier_agbphonefilter_Internalname ;
      private string lblLblsupplier_agbphonefilter_Jsonclick ;
      private string edtavCsupplier_agbphone_Internalname ;
      private string edtavCsupplier_agbphone_Jsonclick ;
      private string divSupplier_agbcontactnamefiltercontainer_Internalname ;
      private string lblLblsupplier_agbcontactnamefilter_Internalname ;
      private string lblLblsupplier_agbcontactnamefilter_Jsonclick ;
      private string edtavCsupplier_agbcontactname_Internalname ;
      private string edtavCsupplier_agbcontactname_Jsonclick ;
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
      private string edtSupplier_AgbId_Internalname ;
      private string edtSupplier_AgbNumber_Internalname ;
      private string edtSupplier_AgbName_Internalname ;
      private string edtSupplier_AgbKvkNumber_Internalname ;
      private string A62Supplier_AgbPhone ;
      private string edtSupplier_AgbPhone_Internalname ;
      private string lV11cSupplier_AgbPhone ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtSupplier_AgbId_Jsonclick ;
      private string edtSupplier_AgbNumber_Link ;
      private string edtSupplier_AgbNumber_Jsonclick ;
      private string edtSupplier_AgbName_Jsonclick ;
      private string edtSupplier_AgbKvkNumber_Jsonclick ;
      private string gxphoneLink ;
      private string edtSupplier_AgbPhone_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n62Supplier_AgbPhone ;
      private bool gxdyncontrolsrefreshing ;
      private bool n63Supplier_AgbContactName ;
      private bool n61Supplier_AgbEmail ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cSupplier_AgbNumber ;
      private string AV8cSupplier_AgbName ;
      private string AV9cSupplier_AgbKvkNumber ;
      private string AV10cSupplier_AgbEmail ;
      private string AV12cSupplier_AgbContactName ;
      private string AV15Linkselection_GXI ;
      private string A56Supplier_AgbNumber ;
      private string A57Supplier_AgbName ;
      private string A58Supplier_AgbKvkNumber ;
      private string lV7cSupplier_AgbNumber ;
      private string lV8cSupplier_AgbName ;
      private string lV9cSupplier_AgbKvkNumber ;
      private string lV10cSupplier_AgbEmail ;
      private string lV12cSupplier_AgbContactName ;
      private string A61Supplier_AgbEmail ;
      private string A63Supplier_AgbContactName ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00072_A63Supplier_AgbContactName ;
      private bool[] H00072_n63Supplier_AgbContactName ;
      private string[] H00072_A61Supplier_AgbEmail ;
      private bool[] H00072_n61Supplier_AgbEmail ;
      private string[] H00072_A62Supplier_AgbPhone ;
      private bool[] H00072_n62Supplier_AgbPhone ;
      private string[] H00072_A58Supplier_AgbKvkNumber ;
      private string[] H00072_A57Supplier_AgbName ;
      private string[] H00072_A56Supplier_AgbNumber ;
      private short[] H00072_A55Supplier_AgbId ;
      private long[] H00073_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pSupplier_AgbId ;
   }

   public class gx0080__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00072( IGxContext context ,
                                             string AV7cSupplier_AgbNumber ,
                                             string AV8cSupplier_AgbName ,
                                             string AV9cSupplier_AgbKvkNumber ,
                                             string AV10cSupplier_AgbEmail ,
                                             string AV11cSupplier_AgbPhone ,
                                             string AV12cSupplier_AgbContactName ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             short AV6cSupplier_AgbId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Supplier_AgbContactName, Supplier_AgbEmail, Supplier_AgbPhone, Supplier_AgbKvkNumber, Supplier_AgbName, Supplier_AgbNumber, Supplier_AgbId";
         sFromString = " FROM Supplier_AGB";
         sOrderString = "";
         AddWhere(sWhereString, "(Supplier_AgbId >= :AV6cSupplier_AgbId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cSupplier_AgbNumber)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV7cSupplier_AgbNumber)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cSupplier_AgbName)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV8cSupplier_AgbName)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cSupplier_AgbKvkNumber)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV9cSupplier_AgbKvkNumber)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cSupplier_AgbEmail)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV10cSupplier_AgbEmail)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cSupplier_AgbPhone)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV11cSupplier_AgbPhone)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cSupplier_AgbContactName)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV12cSupplier_AgbContactName)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY Supplier_AgbId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00073( IGxContext context ,
                                             string AV7cSupplier_AgbNumber ,
                                             string AV8cSupplier_AgbName ,
                                             string AV9cSupplier_AgbKvkNumber ,
                                             string AV10cSupplier_AgbEmail ,
                                             string AV11cSupplier_AgbPhone ,
                                             string AV12cSupplier_AgbContactName ,
                                             string A56Supplier_AgbNumber ,
                                             string A57Supplier_AgbName ,
                                             string A58Supplier_AgbKvkNumber ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             short AV6cSupplier_AgbId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Supplier_AGB";
         AddWhere(sWhereString, "(Supplier_AgbId >= :AV6cSupplier_AgbId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cSupplier_AgbNumber)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like :lV7cSupplier_AgbNumber)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cSupplier_AgbName)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV8cSupplier_AgbName)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cSupplier_AgbKvkNumber)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbKvkNumber like :lV9cSupplier_AgbKvkNumber)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cSupplier_AgbEmail)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV10cSupplier_AgbEmail)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cSupplier_AgbPhone)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV11cSupplier_AgbPhone)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cSupplier_AgbContactName)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV12cSupplier_AgbContactName)");
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
                     return conditional_H00072(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H00073(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmH00072;
          prmH00072 = new Object[] {
          new ParDef("AV6cSupplier_AgbId",GXType.Int16,4,0) ,
          new ParDef("lV7cSupplier_AgbNumber",GXType.VarChar,10,0) ,
          new ParDef("lV8cSupplier_AgbName",GXType.VarChar,40,0) ,
          new ParDef("lV9cSupplier_AgbKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("lV10cSupplier_AgbEmail",GXType.VarChar,100,0) ,
          new ParDef("lV11cSupplier_AgbPhone",GXType.Char,20,0) ,
          new ParDef("lV12cSupplier_AgbContactName",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00073;
          prmH00073 = new Object[] {
          new ParDef("AV6cSupplier_AgbId",GXType.Int16,4,0) ,
          new ParDef("lV7cSupplier_AgbNumber",GXType.VarChar,10,0) ,
          new ParDef("lV8cSupplier_AgbName",GXType.VarChar,40,0) ,
          new ParDef("lV9cSupplier_AgbKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("lV10cSupplier_AgbEmail",GXType.VarChar,100,0) ,
          new ParDef("lV11cSupplier_AgbPhone",GXType.Char,20,0) ,
          new ParDef("lV12cSupplier_AgbContactName",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00072", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00072,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00073", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00073,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
