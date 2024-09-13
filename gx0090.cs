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
   public class gx0090 : GXDataArea
   {
      public gx0090( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0090( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pSupplier_GenId )
      {
         this.AV11pSupplier_GenId = 0 ;
         ExecuteImpl();
         aP0_pSupplier_GenId=this.AV11pSupplier_GenId;
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
            gxfirstwebparm = GetFirstPar( "pSupplier_GenId");
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
               gxfirstwebparm = GetFirstPar( "pSupplier_GenId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pSupplier_GenId");
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
               AV11pSupplier_GenId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pSupplier_GenId", StringUtil.LTrimStr( (decimal)(AV11pSupplier_GenId), 4, 0));
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
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
         AV6cSupplier_GenId = (short)(Math.Round(NumberUtil.Val( GetPar( "cSupplier_GenId"), "."), 18, MidpointRounding.ToEven));
         AV7cSupplier_GenKvKNumber = GetPar( "cSupplier_GenKvKNumber");
         AV8cSupplier_GenCompanyName = GetPar( "cSupplier_GenCompanyName");
         AV9cSupplier_GenContactName = GetPar( "cSupplier_GenContactName");
         AV10cSupplier_GenContactPhone = GetPar( "cSupplier_GenContactPhone");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_GenId, AV7cSupplier_GenKvKNumber, AV8cSupplier_GenCompanyName, AV9cSupplier_GenContactName, AV10cSupplier_GenContactPhone) ;
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
            return "gx0090_Execute" ;
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
         PA082( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START082( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pSupplier_GenId,4,0))}, new string[] {"pSupplier_GenId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_GENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSupplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_GENKVKNUMBER", AV7cSupplier_GenKvKNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_GENCOMPANYNAME", AV8cSupplier_GenCompanyName);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_GENCONTACTNAME", AV9cSupplier_GenContactName);
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIER_GENCONTACTPHONE", StringUtil.RTrim( AV10cSupplier_GenContactPhone));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPSUPPLIER_GENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pSupplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENIDFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_genidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENKVKNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_genkvknumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENCOMPANYNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_gencompanynamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENCONTACTNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_gencontactnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENCONTACTPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divSupplier_gencontactphonefiltercontainer_Class));
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
            WE082( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT082( ) ;
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
         return formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pSupplier_GenId,4,0))}, new string[] {"pSupplier_GenId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0090" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Supplier_Gen", "") ;
      }

      protected void WB080( )
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
            GxWebStd.gx_div_start( context, divSupplier_genidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_genidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_genidfilter_Internalname, context.GetMessage( "Supplier_Gen Id", ""), "", "", lblLblsupplier_genidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_genid_Internalname, context.GetMessage( "Supplier_Gen Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_genid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSupplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsupplier_genid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cSupplier_GenId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cSupplier_GenId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_genid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_genid_Visible, edtavCsupplier_genid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_genkvknumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_genkvknumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_genkvknumberfilter_Internalname, context.GetMessage( "Supplier_Gen Kv KNumber", ""), "", "", lblLblsupplier_genkvknumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_genkvknumber_Internalname, context.GetMessage( "Supplier_Gen Kv KNumber", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_genkvknumber_Internalname, AV7cSupplier_GenKvKNumber, StringUtil.RTrim( context.localUtil.Format( AV7cSupplier_GenKvKNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_genkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_genkvknumber_Visible, edtavCsupplier_genkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_gencompanynamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_gencompanynamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_gencompanynamefilter_Internalname, context.GetMessage( "Supplier_Gen Company Name", ""), "", "", lblLblsupplier_gencompanynamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_gencompanyname_Internalname, context.GetMessage( "Supplier_Gen Company Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_gencompanyname_Internalname, AV8cSupplier_GenCompanyName, StringUtil.RTrim( context.localUtil.Format( AV8cSupplier_GenCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_gencompanyname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_gencompanyname_Visible, edtavCsupplier_gencompanyname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_gencontactnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_gencontactnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_gencontactnamefilter_Internalname, context.GetMessage( "Supplier_Gen Contact Name", ""), "", "", lblLblsupplier_gencontactnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_gencontactname_Internalname, context.GetMessage( "Supplier_Gen Contact Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_gencontactname_Internalname, AV9cSupplier_GenContactName, StringUtil.RTrim( context.localUtil.Format( AV9cSupplier_GenContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_gencontactname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_gencontactname_Visible, edtavCsupplier_gencontactname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divSupplier_gencontactphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplier_gencontactphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplier_gencontactphonefilter_Internalname, context.GetMessage( "Supplier_Gen Contact Phone", ""), "", "", lblLblsupplier_gencontactphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplier_gencontactphone_Internalname, context.GetMessage( "Supplier_Gen Contact Phone", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplier_gencontactphone_Internalname, StringUtil.RTrim( AV10cSupplier_GenContactPhone), StringUtil.RTrim( context.localUtil.Format( AV10cSupplier_GenContactPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplier_gencontactphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplier_gencontactphone_Visible, edtavCsupplier_gencontactphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0090.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16081_client"+"'", TempTags, "", 2, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 64 )
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

      protected void START082( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Supplier_Gen", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP080( ) ;
      }

      protected void WS082( )
      {
         START082( ) ;
         EVT082( ) ;
      }

      protected void EVT082( )
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
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV13Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A64Supplier_GenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplier_GenId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A65Supplier_GenKvKNumber = cgiGet( edtSupplier_GenKvKNumber_Internalname);
                              A66Supplier_GenCompanyName = cgiGet( edtSupplier_GenCompanyName_Internalname);
                              A69Supplier_GenContactName = cgiGet( edtSupplier_GenContactName_Internalname);
                              n69Supplier_GenContactName = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Csupplier_genid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSUPPLIER_GENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSupplier_GenId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_genkvknumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_GENKVKNUMBER"), AV7cSupplier_GenKvKNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_gencompanyname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_GENCOMPANYNAME"), AV8cSupplier_GenCompanyName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_gencontactname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_GENCONTACTNAME"), AV9cSupplier_GenContactName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplier_gencontactphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_GENCONTACTPHONE"), AV10cSupplier_GenContactPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19082 ();
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

      protected void WE082( )
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

      protected void PA082( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cSupplier_GenId ,
                                        string AV7cSupplier_GenKvKNumber ,
                                        string AV8cSupplier_GenCompanyName ,
                                        string AV9cSupplier_GenContactName ,
                                        string AV10cSupplier_GenContactPhone )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF082( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIER_GENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, ".", "")));
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
         RF082( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF082( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cSupplier_GenKvKNumber ,
                                                 AV8cSupplier_GenCompanyName ,
                                                 AV9cSupplier_GenContactName ,
                                                 AV10cSupplier_GenContactPhone ,
                                                 A65Supplier_GenKvKNumber ,
                                                 A66Supplier_GenCompanyName ,
                                                 A69Supplier_GenContactName ,
                                                 A70Supplier_GenContactPhone ,
                                                 AV6cSupplier_GenId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV7cSupplier_GenKvKNumber = StringUtil.Concat( StringUtil.RTrim( AV7cSupplier_GenKvKNumber), "%", "");
            lV8cSupplier_GenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV8cSupplier_GenCompanyName), "%", "");
            lV9cSupplier_GenContactName = StringUtil.Concat( StringUtil.RTrim( AV9cSupplier_GenContactName), "%", "");
            lV10cSupplier_GenContactPhone = StringUtil.PadR( StringUtil.RTrim( AV10cSupplier_GenContactPhone), 20, "%");
            /* Using cursor H00082 */
            pr_default.execute(0, new Object[] {AV6cSupplier_GenId, lV7cSupplier_GenKvKNumber, lV8cSupplier_GenCompanyName, lV9cSupplier_GenContactName, lV10cSupplier_GenContactPhone, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A70Supplier_GenContactPhone = H00082_A70Supplier_GenContactPhone[0];
               n70Supplier_GenContactPhone = H00082_n70Supplier_GenContactPhone[0];
               A69Supplier_GenContactName = H00082_A69Supplier_GenContactName[0];
               n69Supplier_GenContactName = H00082_n69Supplier_GenContactName[0];
               A66Supplier_GenCompanyName = H00082_A66Supplier_GenCompanyName[0];
               A65Supplier_GenKvKNumber = H00082_A65Supplier_GenKvKNumber[0];
               A64Supplier_GenId = H00082_A64Supplier_GenId[0];
               /* Execute user event: Load */
               E18082 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB080( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes082( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIER_GENID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9"), context));
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
                                              AV7cSupplier_GenKvKNumber ,
                                              AV8cSupplier_GenCompanyName ,
                                              AV9cSupplier_GenContactName ,
                                              AV10cSupplier_GenContactPhone ,
                                              A65Supplier_GenKvKNumber ,
                                              A66Supplier_GenCompanyName ,
                                              A69Supplier_GenContactName ,
                                              A70Supplier_GenContactPhone ,
                                              AV6cSupplier_GenId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV7cSupplier_GenKvKNumber = StringUtil.Concat( StringUtil.RTrim( AV7cSupplier_GenKvKNumber), "%", "");
         lV8cSupplier_GenCompanyName = StringUtil.Concat( StringUtil.RTrim( AV8cSupplier_GenCompanyName), "%", "");
         lV9cSupplier_GenContactName = StringUtil.Concat( StringUtil.RTrim( AV9cSupplier_GenContactName), "%", "");
         lV10cSupplier_GenContactPhone = StringUtil.PadR( StringUtil.RTrim( AV10cSupplier_GenContactPhone), 20, "%");
         /* Using cursor H00083 */
         pr_default.execute(1, new Object[] {AV6cSupplier_GenId, lV7cSupplier_GenKvKNumber, lV8cSupplier_GenCompanyName, lV9cSupplier_GenContactName, lV10cSupplier_GenContactPhone});
         GRID1_nRecordCount = H00083_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_GenId, AV7cSupplier_GenKvKNumber, AV8cSupplier_GenCompanyName, AV9cSupplier_GenContactName, AV10cSupplier_GenContactPhone) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_GenId, AV7cSupplier_GenKvKNumber, AV8cSupplier_GenCompanyName, AV9cSupplier_GenContactName, AV10cSupplier_GenContactPhone) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_GenId, AV7cSupplier_GenKvKNumber, AV8cSupplier_GenCompanyName, AV9cSupplier_GenContactName, AV10cSupplier_GenContactPhone) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_GenId, AV7cSupplier_GenKvKNumber, AV8cSupplier_GenCompanyName, AV9cSupplier_GenContactName, AV10cSupplier_GenContactPhone) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSupplier_GenId, AV7cSupplier_GenKvKNumber, AV8cSupplier_GenCompanyName, AV9cSupplier_GenContactName, AV10cSupplier_GenContactPhone) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtSupplier_GenId_Enabled = 0;
         edtSupplier_GenKvKNumber_Enabled = 0;
         edtSupplier_GenCompanyName_Enabled = 0;
         edtSupplier_GenContactName_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP080( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17082 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsupplier_genid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsupplier_genid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSUPPLIER_GENID");
               GX_FocusControl = edtavCsupplier_genid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cSupplier_GenId = 0;
               AssignAttri("", false, "AV6cSupplier_GenId", StringUtil.LTrimStr( (decimal)(AV6cSupplier_GenId), 4, 0));
            }
            else
            {
               AV6cSupplier_GenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsupplier_genid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cSupplier_GenId", StringUtil.LTrimStr( (decimal)(AV6cSupplier_GenId), 4, 0));
            }
            AV7cSupplier_GenKvKNumber = cgiGet( edtavCsupplier_genkvknumber_Internalname);
            AssignAttri("", false, "AV7cSupplier_GenKvKNumber", AV7cSupplier_GenKvKNumber);
            AV8cSupplier_GenCompanyName = cgiGet( edtavCsupplier_gencompanyname_Internalname);
            AssignAttri("", false, "AV8cSupplier_GenCompanyName", AV8cSupplier_GenCompanyName);
            AV9cSupplier_GenContactName = cgiGet( edtavCsupplier_gencontactname_Internalname);
            AssignAttri("", false, "AV9cSupplier_GenContactName", AV9cSupplier_GenContactName);
            AV10cSupplier_GenContactPhone = cgiGet( edtavCsupplier_gencontactphone_Internalname);
            AssignAttri("", false, "AV10cSupplier_GenContactPhone", AV10cSupplier_GenContactPhone);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSUPPLIER_GENID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSupplier_GenId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_GENKVKNUMBER"), AV7cSupplier_GenKvKNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_GENCOMPANYNAME"), AV8cSupplier_GenCompanyName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_GENCONTACTNAME"), AV9cSupplier_GenContactName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSUPPLIER_GENCONTACTPHONE"), AV10cSupplier_GenContactPhone) != 0 )
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
         E17082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17082( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Supplier_Gen", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E18082( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV13Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E19082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19082( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pSupplier_GenId = A64Supplier_GenId;
         AssignAttri("", false, "AV11pSupplier_GenId", StringUtil.LTrimStr( (decimal)(AV11pSupplier_GenId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV11pSupplier_GenId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pSupplier_GenId"});
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
         AV11pSupplier_GenId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV11pSupplier_GenId", StringUtil.LTrimStr( (decimal)(AV11pSupplier_GenId), 4, 0));
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
         PA082( ) ;
         WS082( ) ;
         WE082( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315565474", true, true);
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
         context.AddJavascriptSource("gx0090.js", "?202491315565474", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID_"+sGXsfl_64_idx;
         edtSupplier_GenKvKNumber_Internalname = "SUPPLIER_GENKVKNUMBER_"+sGXsfl_64_idx;
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_64_idx;
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID_"+sGXsfl_64_fel_idx;
         edtSupplier_GenKvKNumber_Internalname = "SUPPLIER_GENKVKNUMBER_"+sGXsfl_64_fel_idx;
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_64_fel_idx;
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WB080( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV13Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV13Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtSupplier_GenKvKNumber_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtSupplier_GenKvKNumber_Internalname, "Link", edtSupplier_GenKvKNumber_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenKvKNumber_Internalname,(string)A65Supplier_GenKvKNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSupplier_GenKvKNumber_Link,(string)"",(string)"",(string)"",(string)edtSupplier_GenKvKNumber_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenCompanyName_Internalname,(string)A66Supplier_GenCompanyName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenContactName_Internalname,(string)A69Supplier_GenContactName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenContactName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes082( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
            context.SendWebValue( context.GetMessage( "Kv KNumber", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Company Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contact Name", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A65Supplier_GenKvKNumber));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtSupplier_GenKvKNumber_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A66Supplier_GenCompanyName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A69Supplier_GenContactName));
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
         lblLblsupplier_genidfilter_Internalname = "LBLSUPPLIER_GENIDFILTER";
         edtavCsupplier_genid_Internalname = "vCSUPPLIER_GENID";
         divSupplier_genidfiltercontainer_Internalname = "SUPPLIER_GENIDFILTERCONTAINER";
         lblLblsupplier_genkvknumberfilter_Internalname = "LBLSUPPLIER_GENKVKNUMBERFILTER";
         edtavCsupplier_genkvknumber_Internalname = "vCSUPPLIER_GENKVKNUMBER";
         divSupplier_genkvknumberfiltercontainer_Internalname = "SUPPLIER_GENKVKNUMBERFILTERCONTAINER";
         lblLblsupplier_gencompanynamefilter_Internalname = "LBLSUPPLIER_GENCOMPANYNAMEFILTER";
         edtavCsupplier_gencompanyname_Internalname = "vCSUPPLIER_GENCOMPANYNAME";
         divSupplier_gencompanynamefiltercontainer_Internalname = "SUPPLIER_GENCOMPANYNAMEFILTERCONTAINER";
         lblLblsupplier_gencontactnamefilter_Internalname = "LBLSUPPLIER_GENCONTACTNAMEFILTER";
         edtavCsupplier_gencontactname_Internalname = "vCSUPPLIER_GENCONTACTNAME";
         divSupplier_gencontactnamefiltercontainer_Internalname = "SUPPLIER_GENCONTACTNAMEFILTERCONTAINER";
         lblLblsupplier_gencontactphonefilter_Internalname = "LBLSUPPLIER_GENCONTACTPHONEFILTER";
         edtavCsupplier_gencontactphone_Internalname = "vCSUPPLIER_GENCONTACTPHONE";
         divSupplier_gencontactphonefiltercontainer_Internalname = "SUPPLIER_GENCONTACTPHONEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID";
         edtSupplier_GenKvKNumber_Internalname = "SUPPLIER_GENKVKNUMBER";
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME";
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME";
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
         edtSupplier_GenContactName_Jsonclick = "";
         edtSupplier_GenCompanyName_Jsonclick = "";
         edtSupplier_GenKvKNumber_Jsonclick = "";
         edtSupplier_GenKvKNumber_Link = "";
         edtSupplier_GenId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtSupplier_GenContactName_Enabled = 0;
         edtSupplier_GenCompanyName_Enabled = 0;
         edtSupplier_GenKvKNumber_Enabled = 0;
         edtSupplier_GenId_Enabled = 0;
         edtavCsupplier_gencontactphone_Jsonclick = "";
         edtavCsupplier_gencontactphone_Enabled = 1;
         edtavCsupplier_gencontactphone_Visible = 1;
         edtavCsupplier_gencontactname_Jsonclick = "";
         edtavCsupplier_gencontactname_Enabled = 1;
         edtavCsupplier_gencontactname_Visible = 1;
         edtavCsupplier_gencompanyname_Jsonclick = "";
         edtavCsupplier_gencompanyname_Enabled = 1;
         edtavCsupplier_gencompanyname_Visible = 1;
         edtavCsupplier_genkvknumber_Jsonclick = "";
         edtavCsupplier_genkvknumber_Enabled = 1;
         edtavCsupplier_genkvknumber_Visible = 1;
         edtavCsupplier_genid_Jsonclick = "";
         edtavCsupplier_genid_Enabled = 1;
         edtavCsupplier_genid_Visible = 1;
         divSupplier_gencontactphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_gencontactnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_gencompanynamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_genkvknumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSupplier_genidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Supplier_Gen", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_GenId","fld":"vCSUPPLIER_GENID","pic":"ZZZ9"},{"av":"AV7cSupplier_GenKvKNumber","fld":"vCSUPPLIER_GENKVKNUMBER"},{"av":"AV8cSupplier_GenCompanyName","fld":"vCSUPPLIER_GENCOMPANYNAME"},{"av":"AV9cSupplier_GenContactName","fld":"vCSUPPLIER_GENCONTACTNAME"},{"av":"AV10cSupplier_GenContactPhone","fld":"vCSUPPLIER_GENCONTACTPHONE"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E16081","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLSUPPLIER_GENIDFILTER.CLICK","""{"handler":"E11081","iparms":[{"av":"divSupplier_genidfiltercontainer_Class","ctrl":"SUPPLIER_GENIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_GENIDFILTER.CLICK",""","oparms":[{"av":"divSupplier_genidfiltercontainer_Class","ctrl":"SUPPLIER_GENIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_genid_Visible","ctrl":"vCSUPPLIER_GENID","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_GENKVKNUMBERFILTER.CLICK","""{"handler":"E12081","iparms":[{"av":"divSupplier_genkvknumberfiltercontainer_Class","ctrl":"SUPPLIER_GENKVKNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_GENKVKNUMBERFILTER.CLICK",""","oparms":[{"av":"divSupplier_genkvknumberfiltercontainer_Class","ctrl":"SUPPLIER_GENKVKNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_genkvknumber_Visible","ctrl":"vCSUPPLIER_GENKVKNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_GENCOMPANYNAMEFILTER.CLICK","""{"handler":"E13081","iparms":[{"av":"divSupplier_gencompanynamefiltercontainer_Class","ctrl":"SUPPLIER_GENCOMPANYNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_GENCOMPANYNAMEFILTER.CLICK",""","oparms":[{"av":"divSupplier_gencompanynamefiltercontainer_Class","ctrl":"SUPPLIER_GENCOMPANYNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_gencompanyname_Visible","ctrl":"vCSUPPLIER_GENCOMPANYNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_GENCONTACTNAMEFILTER.CLICK","""{"handler":"E14081","iparms":[{"av":"divSupplier_gencontactnamefiltercontainer_Class","ctrl":"SUPPLIER_GENCONTACTNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_GENCONTACTNAMEFILTER.CLICK",""","oparms":[{"av":"divSupplier_gencontactnamefiltercontainer_Class","ctrl":"SUPPLIER_GENCONTACTNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_gencontactname_Visible","ctrl":"vCSUPPLIER_GENCONTACTNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLSUPPLIER_GENCONTACTPHONEFILTER.CLICK","""{"handler":"E15081","iparms":[{"av":"divSupplier_gencontactphonefiltercontainer_Class","ctrl":"SUPPLIER_GENCONTACTPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSUPPLIER_GENCONTACTPHONEFILTER.CLICK",""","oparms":[{"av":"divSupplier_gencontactphonefiltercontainer_Class","ctrl":"SUPPLIER_GENCONTACTPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCsupplier_gencontactphone_Visible","ctrl":"vCSUPPLIER_GENCONTACTPHONE","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E19082","iparms":[{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11pSupplier_GenId","fld":"vPSUPPLIER_GENID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_GenId","fld":"vCSUPPLIER_GENID","pic":"ZZZ9"},{"av":"AV7cSupplier_GenKvKNumber","fld":"vCSUPPLIER_GENKVKNUMBER"},{"av":"AV8cSupplier_GenCompanyName","fld":"vCSUPPLIER_GENCOMPANYNAME"},{"av":"AV9cSupplier_GenContactName","fld":"vCSUPPLIER_GENCONTACTNAME"},{"av":"AV10cSupplier_GenContactPhone","fld":"vCSUPPLIER_GENCONTACTPHONE"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_GenId","fld":"vCSUPPLIER_GENID","pic":"ZZZ9"},{"av":"AV7cSupplier_GenKvKNumber","fld":"vCSUPPLIER_GENKVKNUMBER"},{"av":"AV8cSupplier_GenCompanyName","fld":"vCSUPPLIER_GENCOMPANYNAME"},{"av":"AV9cSupplier_GenContactName","fld":"vCSUPPLIER_GENCONTACTNAME"},{"av":"AV10cSupplier_GenContactPhone","fld":"vCSUPPLIER_GENCONTACTPHONE"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_GenId","fld":"vCSUPPLIER_GENID","pic":"ZZZ9"},{"av":"AV7cSupplier_GenKvKNumber","fld":"vCSUPPLIER_GENKVKNUMBER"},{"av":"AV8cSupplier_GenCompanyName","fld":"vCSUPPLIER_GENCOMPANYNAME"},{"av":"AV9cSupplier_GenContactName","fld":"vCSUPPLIER_GENCONTACTNAME"},{"av":"AV10cSupplier_GenContactPhone","fld":"vCSUPPLIER_GENCONTACTPHONE"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cSupplier_GenId","fld":"vCSUPPLIER_GENID","pic":"ZZZ9"},{"av":"AV7cSupplier_GenKvKNumber","fld":"vCSUPPLIER_GENKVKNUMBER"},{"av":"AV8cSupplier_GenCompanyName","fld":"vCSUPPLIER_GENCOMPANYNAME"},{"av":"AV9cSupplier_GenContactName","fld":"vCSUPPLIER_GENCONTACTNAME"},{"av":"AV10cSupplier_GenContactPhone","fld":"vCSUPPLIER_GENCONTACTPHONE"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Supplier_gencontactname","iparms":[]}""");
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
         AV7cSupplier_GenKvKNumber = "";
         AV8cSupplier_GenCompanyName = "";
         AV9cSupplier_GenContactName = "";
         AV10cSupplier_GenContactPhone = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblsupplier_genidfilter_Jsonclick = "";
         TempTags = "";
         lblLblsupplier_genkvknumberfilter_Jsonclick = "";
         lblLblsupplier_gencompanynamefilter_Jsonclick = "";
         lblLblsupplier_gencontactnamefilter_Jsonclick = "";
         lblLblsupplier_gencontactphonefilter_Jsonclick = "";
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
         AV13Linkselection_GXI = "";
         A65Supplier_GenKvKNumber = "";
         A66Supplier_GenCompanyName = "";
         A69Supplier_GenContactName = "";
         lV7cSupplier_GenKvKNumber = "";
         lV8cSupplier_GenCompanyName = "";
         lV9cSupplier_GenContactName = "";
         lV10cSupplier_GenContactPhone = "";
         A70Supplier_GenContactPhone = "";
         H00082_A70Supplier_GenContactPhone = new string[] {""} ;
         H00082_n70Supplier_GenContactPhone = new bool[] {false} ;
         H00082_A69Supplier_GenContactName = new string[] {""} ;
         H00082_n69Supplier_GenContactName = new bool[] {false} ;
         H00082_A66Supplier_GenCompanyName = new string[] {""} ;
         H00082_A65Supplier_GenKvKNumber = new string[] {""} ;
         H00082_A64Supplier_GenId = new short[1] ;
         H00083_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0090__default(),
            new Object[][] {
                new Object[] {
               H00082_A70Supplier_GenContactPhone, H00082_n70Supplier_GenContactPhone, H00082_A69Supplier_GenContactName, H00082_n69Supplier_GenContactName, H00082_A66Supplier_GenCompanyName, H00082_A65Supplier_GenKvKNumber, H00082_A64Supplier_GenId
               }
               , new Object[] {
               H00083_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11pSupplier_GenId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cSupplier_GenId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A64Supplier_GenId ;
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
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int edtavCsupplier_genid_Enabled ;
      private int edtavCsupplier_genid_Visible ;
      private int edtavCsupplier_genkvknumber_Visible ;
      private int edtavCsupplier_genkvknumber_Enabled ;
      private int edtavCsupplier_gencompanyname_Visible ;
      private int edtavCsupplier_gencompanyname_Enabled ;
      private int edtavCsupplier_gencontactname_Visible ;
      private int edtavCsupplier_gencontactname_Enabled ;
      private int edtavCsupplier_gencontactphone_Visible ;
      private int edtavCsupplier_gencontactphone_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSupplier_GenId_Enabled ;
      private int edtSupplier_GenKvKNumber_Enabled ;
      private int edtSupplier_GenCompanyName_Enabled ;
      private int edtSupplier_GenContactName_Enabled ;
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
      private string divSupplier_genidfiltercontainer_Class ;
      private string divSupplier_genkvknumberfiltercontainer_Class ;
      private string divSupplier_gencompanynamefiltercontainer_Class ;
      private string divSupplier_gencontactnamefiltercontainer_Class ;
      private string divSupplier_gencontactphonefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV10cSupplier_GenContactPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divSupplier_genidfiltercontainer_Internalname ;
      private string lblLblsupplier_genidfilter_Internalname ;
      private string lblLblsupplier_genidfilter_Jsonclick ;
      private string edtavCsupplier_genid_Internalname ;
      private string TempTags ;
      private string edtavCsupplier_genid_Jsonclick ;
      private string divSupplier_genkvknumberfiltercontainer_Internalname ;
      private string lblLblsupplier_genkvknumberfilter_Internalname ;
      private string lblLblsupplier_genkvknumberfilter_Jsonclick ;
      private string edtavCsupplier_genkvknumber_Internalname ;
      private string edtavCsupplier_genkvknumber_Jsonclick ;
      private string divSupplier_gencompanynamefiltercontainer_Internalname ;
      private string lblLblsupplier_gencompanynamefilter_Internalname ;
      private string lblLblsupplier_gencompanynamefilter_Jsonclick ;
      private string edtavCsupplier_gencompanyname_Internalname ;
      private string edtavCsupplier_gencompanyname_Jsonclick ;
      private string divSupplier_gencontactnamefiltercontainer_Internalname ;
      private string lblLblsupplier_gencontactnamefilter_Internalname ;
      private string lblLblsupplier_gencontactnamefilter_Jsonclick ;
      private string edtavCsupplier_gencontactname_Internalname ;
      private string edtavCsupplier_gencontactname_Jsonclick ;
      private string divSupplier_gencontactphonefiltercontainer_Internalname ;
      private string lblLblsupplier_gencontactphonefilter_Internalname ;
      private string lblLblsupplier_gencontactphonefilter_Jsonclick ;
      private string edtavCsupplier_gencontactphone_Internalname ;
      private string edtavCsupplier_gencontactphone_Jsonclick ;
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
      private string edtSupplier_GenId_Internalname ;
      private string edtSupplier_GenKvKNumber_Internalname ;
      private string edtSupplier_GenCompanyName_Internalname ;
      private string edtSupplier_GenContactName_Internalname ;
      private string lV10cSupplier_GenContactPhone ;
      private string A70Supplier_GenContactPhone ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtSupplier_GenId_Jsonclick ;
      private string edtSupplier_GenKvKNumber_Link ;
      private string edtSupplier_GenKvKNumber_Jsonclick ;
      private string edtSupplier_GenCompanyName_Jsonclick ;
      private string edtSupplier_GenContactName_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool n69Supplier_GenContactName ;
      private bool gxdyncontrolsrefreshing ;
      private bool n70Supplier_GenContactPhone ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cSupplier_GenKvKNumber ;
      private string AV8cSupplier_GenCompanyName ;
      private string AV9cSupplier_GenContactName ;
      private string AV13Linkselection_GXI ;
      private string A65Supplier_GenKvKNumber ;
      private string A66Supplier_GenCompanyName ;
      private string A69Supplier_GenContactName ;
      private string lV7cSupplier_GenKvKNumber ;
      private string lV8cSupplier_GenCompanyName ;
      private string lV9cSupplier_GenContactName ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00082_A70Supplier_GenContactPhone ;
      private bool[] H00082_n70Supplier_GenContactPhone ;
      private string[] H00082_A69Supplier_GenContactName ;
      private bool[] H00082_n69Supplier_GenContactName ;
      private string[] H00082_A66Supplier_GenCompanyName ;
      private string[] H00082_A65Supplier_GenKvKNumber ;
      private short[] H00082_A64Supplier_GenId ;
      private long[] H00083_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pSupplier_GenId ;
   }

   public class gx0090__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00082( IGxContext context ,
                                             string AV7cSupplier_GenKvKNumber ,
                                             string AV8cSupplier_GenCompanyName ,
                                             string AV9cSupplier_GenContactName ,
                                             string AV10cSupplier_GenContactPhone ,
                                             string A65Supplier_GenKvKNumber ,
                                             string A66Supplier_GenCompanyName ,
                                             string A69Supplier_GenContactName ,
                                             string A70Supplier_GenContactPhone ,
                                             short AV6cSupplier_GenId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Supplier_GenContactPhone, Supplier_GenContactName, Supplier_GenCompanyName, Supplier_GenKvKNumber, Supplier_GenId";
         sFromString = " FROM Supplier_Gen";
         sOrderString = "";
         AddWhere(sWhereString, "(Supplier_GenId >= :AV6cSupplier_GenId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cSupplier_GenKvKNumber)) )
         {
            AddWhere(sWhereString, "(Supplier_GenKvKNumber like :lV7cSupplier_GenKvKNumber)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cSupplier_GenCompanyName)) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like :lV8cSupplier_GenCompanyName)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cSupplier_GenContactName)) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName like :lV9cSupplier_GenContactName)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cSupplier_GenContactPhone)) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone like :lV10cSupplier_GenContactPhone)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY Supplier_GenId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00083( IGxContext context ,
                                             string AV7cSupplier_GenKvKNumber ,
                                             string AV8cSupplier_GenCompanyName ,
                                             string AV9cSupplier_GenContactName ,
                                             string AV10cSupplier_GenContactPhone ,
                                             string A65Supplier_GenKvKNumber ,
                                             string A66Supplier_GenCompanyName ,
                                             string A69Supplier_GenContactName ,
                                             string A70Supplier_GenContactPhone ,
                                             short AV6cSupplier_GenId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Supplier_Gen";
         AddWhere(sWhereString, "(Supplier_GenId >= :AV6cSupplier_GenId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cSupplier_GenKvKNumber)) )
         {
            AddWhere(sWhereString, "(Supplier_GenKvKNumber like :lV7cSupplier_GenKvKNumber)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cSupplier_GenCompanyName)) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like :lV8cSupplier_GenCompanyName)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cSupplier_GenContactName)) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName like :lV9cSupplier_GenContactName)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cSupplier_GenContactPhone)) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone like :lV10cSupplier_GenContactPhone)");
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H00082(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H00083(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmH00082;
          prmH00082 = new Object[] {
          new ParDef("AV6cSupplier_GenId",GXType.Int16,4,0) ,
          new ParDef("lV7cSupplier_GenKvKNumber",GXType.VarChar,8,0) ,
          new ParDef("lV8cSupplier_GenCompanyName",GXType.VarChar,40,0) ,
          new ParDef("lV9cSupplier_GenContactName",GXType.VarChar,40,0) ,
          new ParDef("lV10cSupplier_GenContactPhone",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00083;
          prmH00083 = new Object[] {
          new ParDef("AV6cSupplier_GenId",GXType.Int16,4,0) ,
          new ParDef("lV7cSupplier_GenKvKNumber",GXType.VarChar,8,0) ,
          new ParDef("lV8cSupplier_GenCompanyName",GXType.VarChar,40,0) ,
          new ParDef("lV9cSupplier_GenContactName",GXType.VarChar,40,0) ,
          new ParDef("lV10cSupplier_GenContactPhone",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00082", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00082,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00083", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00083,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
