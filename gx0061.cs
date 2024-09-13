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
   public class gx0061 : GXDataArea
   {
      public gx0061( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0061( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pResidentId ,
                           out short aP1_pResidentINIndividualId )
      {
         this.AV12pResidentId = aP0_pResidentId;
         this.AV13pResidentINIndividualId = 0 ;
         ExecuteImpl();
         aP1_pResidentINIndividualId=this.AV13pResidentINIndividualId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCresidentinindividualgender = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pResidentId");
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
               gxfirstwebparm = GetFirstPar( "pResidentId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pResidentId");
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
               AV12pResidentId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pResidentId", StringUtil.LTrimStr( (decimal)(AV12pResidentId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pResidentINIndividualId = (short)(Math.Round(NumberUtil.Val( GetPar( "pResidentINIndividualId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pResidentINIndividualId", StringUtil.LTrimStr( (decimal)(AV13pResidentINIndividualId), 4, 0));
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
         AV6cResidentINIndividualId = (short)(Math.Round(NumberUtil.Val( GetPar( "cResidentINIndividualId"), "."), 18, MidpointRounding.ToEven));
         AV7cResidentINIndividualBsnNumber = GetPar( "cResidentINIndividualBsnNumber");
         AV8cResidentINIndividualGivenName = GetPar( "cResidentINIndividualGivenName");
         AV9cResidentINIndividualLastName = GetPar( "cResidentINIndividualLastName");
         AV10cResidentINIndividualPhone = GetPar( "cResidentINIndividualPhone");
         cmbavCresidentinindividualgender.FromJSonString( GetNextPar( ));
         AV11cResidentINIndividualGender = GetPar( "cResidentINIndividualGender");
         AV12pResidentId = (short)(Math.Round(NumberUtil.Val( GetPar( "pResidentId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINIndividualId, AV7cResidentINIndividualBsnNumber, AV8cResidentINIndividualGivenName, AV9cResidentINIndividualLastName, AV10cResidentINIndividualPhone, AV11cResidentINIndividualGender, AV12pResidentId) ;
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
            return "gx0061_Execute" ;
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
         PA052( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START052( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0061.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pResidentId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pResidentINIndividualId,4,0))}, new string[] {"pResidentId","pResidentINIndividualId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTININDIVIDUALID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTININDIVIDUALBSNNUMBER", AV7cResidentINIndividualBsnNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTININDIVIDUALGIVENNAME", AV8cResidentINIndividualGivenName);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTININDIVIDUALLASTNAME", AV9cResidentINIndividualLastName);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTININDIVIDUALPHONE", StringUtil.RTrim( AV10cResidentINIndividualPhone));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTININDIVIDUALGENDER", StringUtil.RTrim( AV11cResidentINIndividualGender));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPRESIDENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pResidentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPRESIDENTININDIVIDUALID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALIDFILTERCONTAINER_Class", StringUtil.RTrim( divResidentinindividualidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALBSNNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divResidentinindividualbsnnumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALGIVENNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divResidentinindividualgivennamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALLASTNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divResidentinindividuallastnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divResidentinindividualphonefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALGENDERFILTERCONTAINER_Class", StringUtil.RTrim( divResidentinindividualgenderfiltercontainer_Class));
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
            WE052( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT052( ) ;
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
         return formatLink("gx0061.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pResidentId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pResidentINIndividualId,4,0))}, new string[] {"pResidentId","pResidentINIndividualId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0061" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List INIndividual", "") ;
      }

      protected void WB050( )
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
            GxWebStd.gx_div_start( context, divResidentinindividualidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentinindividualidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentinindividualidfilter_Internalname, context.GetMessage( "Resident INIndividual Id", ""), "", "", lblLblresidentinindividualidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11051_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0061.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentinindividualid_Internalname, context.GetMessage( "Resident INIndividual Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentinindividualid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCresidentinindividualid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cResidentINIndividualId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cResidentINIndividualId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentinindividualid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentinindividualid_Visible, edtavCresidentinindividualid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0061.htm");
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
            GxWebStd.gx_div_start( context, divResidentinindividualbsnnumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentinindividualbsnnumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentinindividualbsnnumberfilter_Internalname, context.GetMessage( "Resident INIndividual Bsn Number", ""), "", "", lblLblresidentinindividualbsnnumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12051_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0061.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentinindividualbsnnumber_Internalname, context.GetMessage( "Resident INIndividual Bsn Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentinindividualbsnnumber_Internalname, AV7cResidentINIndividualBsnNumber, StringUtil.RTrim( context.localUtil.Format( AV7cResidentINIndividualBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentinindividualbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentinindividualbsnnumber_Visible, edtavCresidentinindividualbsnnumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0061.htm");
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
            GxWebStd.gx_div_start( context, divResidentinindividualgivennamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentinindividualgivennamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentinindividualgivennamefilter_Internalname, context.GetMessage( "Resident INIndividual Given Name", ""), "", "", lblLblresidentinindividualgivennamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13051_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0061.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentinindividualgivenname_Internalname, context.GetMessage( "Resident INIndividual Given Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentinindividualgivenname_Internalname, AV8cResidentINIndividualGivenName, StringUtil.RTrim( context.localUtil.Format( AV8cResidentINIndividualGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentinindividualgivenname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentinindividualgivenname_Visible, edtavCresidentinindividualgivenname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0061.htm");
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
            GxWebStd.gx_div_start( context, divResidentinindividuallastnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentinindividuallastnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentinindividuallastnamefilter_Internalname, context.GetMessage( "Resident INIndividual Last Name", ""), "", "", lblLblresidentinindividuallastnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14051_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0061.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentinindividuallastname_Internalname, context.GetMessage( "Resident INIndividual Last Name", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentinindividuallastname_Internalname, AV9cResidentINIndividualLastName, StringUtil.RTrim( context.localUtil.Format( AV9cResidentINIndividualLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentinindividuallastname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentinindividuallastname_Visible, edtavCresidentinindividuallastname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0061.htm");
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
            GxWebStd.gx_div_start( context, divResidentinindividualphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentinindividualphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentinindividualphonefilter_Internalname, context.GetMessage( "Resident INIndividual Phone", ""), "", "", lblLblresidentinindividualphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15051_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0061.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentinindividualphone_Internalname, context.GetMessage( "Resident INIndividual Phone", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentinindividualphone_Internalname, StringUtil.RTrim( AV10cResidentINIndividualPhone), StringUtil.RTrim( context.localUtil.Format( AV10cResidentINIndividualPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentinindividualphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentinindividualphone_Visible, edtavCresidentinindividualphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0061.htm");
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
            GxWebStd.gx_div_start( context, divResidentinindividualgenderfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentinindividualgenderfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentinindividualgenderfilter_Internalname, context.GetMessage( "Resident INIndividual Gender", ""), "", "", lblLblresidentinindividualgenderfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16051_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0061.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCresidentinindividualgender_Internalname, context.GetMessage( "Resident INIndividual Gender", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCresidentinindividualgender, cmbavCresidentinindividualgender_Internalname, StringUtil.RTrim( AV11cResidentINIndividualGender), 1, cmbavCresidentinindividualgender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCresidentinindividualgender.Visible, cmbavCresidentinindividualgender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_Gx0061.htm");
            cmbavCresidentinindividualgender.CurrentValue = StringUtil.RTrim( AV11cResidentINIndividualGender);
            AssignProp("", false, cmbavCresidentinindividualgender_Internalname, "Values", (string)(cmbavCresidentinindividualgender.ToJavascriptSource()), true);
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17051_client"+"'", TempTags, "", 2, "HLP_Gx0061.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0061.htm");
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

      protected void START052( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List INIndividual", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP050( ) ;
      }

      protected void WS052( )
      {
         START052( ) ;
         EVT052( ) ;
      }

      protected void EVT052( )
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
                              A42ResidentINIndividualId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentINIndividualId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A43ResidentINIndividualBsnNumber = cgiGet( edtResidentINIndividualBsnNumber_Internalname);
                              A44ResidentINIndividualGivenName = cgiGet( edtResidentINIndividualGivenName_Internalname);
                              A31ResidentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18052 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19052 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cresidentinindividualid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESIDENTININDIVIDUALID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cResidentINIndividualId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentinindividualbsnnumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALBSNNUMBER"), AV7cResidentINIndividualBsnNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentinindividualgivenname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALGIVENNAME"), AV8cResidentINIndividualGivenName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentinindividuallastname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALLASTNAME"), AV9cResidentINIndividualLastName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentinindividualphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALPHONE"), AV10cResidentINIndividualPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentinindividualgender Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALGENDER"), AV11cResidentINIndividualGender) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20052 ();
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

      protected void WE052( )
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

      protected void PA052( )
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
                                        short AV6cResidentINIndividualId ,
                                        string AV7cResidentINIndividualBsnNumber ,
                                        string AV8cResidentINIndividualGivenName ,
                                        string AV9cResidentINIndividualLastName ,
                                        string AV10cResidentINIndividualPhone ,
                                        string AV11cResidentINIndividualGender ,
                                        short AV12pResidentId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF052( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTININDIVIDUALID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A42ResidentINIndividualId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ResidentINIndividualId), 4, 0, ".", "")));
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
         if ( cmbavCresidentinindividualgender.ItemCount > 0 )
         {
            AV11cResidentINIndividualGender = cmbavCresidentinindividualgender.getValidValue(AV11cResidentINIndividualGender);
            AssignAttri("", false, "AV11cResidentINIndividualGender", AV11cResidentINIndividualGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCresidentinindividualgender.CurrentValue = StringUtil.RTrim( AV11cResidentINIndividualGender);
            AssignProp("", false, cmbavCresidentinindividualgender_Internalname, "Values", cmbavCresidentinindividualgender.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF052( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF052( )
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
                                                 AV7cResidentINIndividualBsnNumber ,
                                                 AV8cResidentINIndividualGivenName ,
                                                 AV9cResidentINIndividualLastName ,
                                                 AV10cResidentINIndividualPhone ,
                                                 AV11cResidentINIndividualGender ,
                                                 A43ResidentINIndividualBsnNumber ,
                                                 A44ResidentINIndividualGivenName ,
                                                 A45ResidentINIndividualLastName ,
                                                 A47ResidentINIndividualPhone ,
                                                 A49ResidentINIndividualGender ,
                                                 AV12pResidentId ,
                                                 AV6cResidentINIndividualId ,
                                                 A31ResidentId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cResidentINIndividualBsnNumber = StringUtil.Concat( StringUtil.RTrim( AV7cResidentINIndividualBsnNumber), "%", "");
            lV8cResidentINIndividualGivenName = StringUtil.Concat( StringUtil.RTrim( AV8cResidentINIndividualGivenName), "%", "");
            lV9cResidentINIndividualLastName = StringUtil.Concat( StringUtil.RTrim( AV9cResidentINIndividualLastName), "%", "");
            lV10cResidentINIndividualPhone = StringUtil.PadR( StringUtil.RTrim( AV10cResidentINIndividualPhone), 20, "%");
            lV11cResidentINIndividualGender = StringUtil.PadR( StringUtil.RTrim( AV11cResidentINIndividualGender), 20, "%");
            /* Using cursor H00052 */
            pr_default.execute(0, new Object[] {AV12pResidentId, AV6cResidentINIndividualId, lV7cResidentINIndividualBsnNumber, lV8cResidentINIndividualGivenName, lV9cResidentINIndividualLastName, lV10cResidentINIndividualPhone, lV11cResidentINIndividualGender, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A49ResidentINIndividualGender = H00052_A49ResidentINIndividualGender[0];
               A47ResidentINIndividualPhone = H00052_A47ResidentINIndividualPhone[0];
               n47ResidentINIndividualPhone = H00052_n47ResidentINIndividualPhone[0];
               A45ResidentINIndividualLastName = H00052_A45ResidentINIndividualLastName[0];
               A31ResidentId = H00052_A31ResidentId[0];
               A44ResidentINIndividualGivenName = H00052_A44ResidentINIndividualGivenName[0];
               A43ResidentINIndividualBsnNumber = H00052_A43ResidentINIndividualBsnNumber[0];
               A42ResidentINIndividualId = H00052_A42ResidentINIndividualId[0];
               /* Execute user event: Load */
               E19052 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB050( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes052( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTININDIVIDUALID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A42ResidentINIndividualId), "ZZZ9"), context));
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
                                              AV7cResidentINIndividualBsnNumber ,
                                              AV8cResidentINIndividualGivenName ,
                                              AV9cResidentINIndividualLastName ,
                                              AV10cResidentINIndividualPhone ,
                                              AV11cResidentINIndividualGender ,
                                              A43ResidentINIndividualBsnNumber ,
                                              A44ResidentINIndividualGivenName ,
                                              A45ResidentINIndividualLastName ,
                                              A47ResidentINIndividualPhone ,
                                              A49ResidentINIndividualGender ,
                                              AV12pResidentId ,
                                              AV6cResidentINIndividualId ,
                                              A31ResidentId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cResidentINIndividualBsnNumber = StringUtil.Concat( StringUtil.RTrim( AV7cResidentINIndividualBsnNumber), "%", "");
         lV8cResidentINIndividualGivenName = StringUtil.Concat( StringUtil.RTrim( AV8cResidentINIndividualGivenName), "%", "");
         lV9cResidentINIndividualLastName = StringUtil.Concat( StringUtil.RTrim( AV9cResidentINIndividualLastName), "%", "");
         lV10cResidentINIndividualPhone = StringUtil.PadR( StringUtil.RTrim( AV10cResidentINIndividualPhone), 20, "%");
         lV11cResidentINIndividualGender = StringUtil.PadR( StringUtil.RTrim( AV11cResidentINIndividualGender), 20, "%");
         /* Using cursor H00053 */
         pr_default.execute(1, new Object[] {AV12pResidentId, AV6cResidentINIndividualId, lV7cResidentINIndividualBsnNumber, lV8cResidentINIndividualGivenName, lV9cResidentINIndividualLastName, lV10cResidentINIndividualPhone, lV11cResidentINIndividualGender});
         GRID1_nRecordCount = H00053_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINIndividualId, AV7cResidentINIndividualBsnNumber, AV8cResidentINIndividualGivenName, AV9cResidentINIndividualLastName, AV10cResidentINIndividualPhone, AV11cResidentINIndividualGender, AV12pResidentId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINIndividualId, AV7cResidentINIndividualBsnNumber, AV8cResidentINIndividualGivenName, AV9cResidentINIndividualLastName, AV10cResidentINIndividualPhone, AV11cResidentINIndividualGender, AV12pResidentId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINIndividualId, AV7cResidentINIndividualBsnNumber, AV8cResidentINIndividualGivenName, AV9cResidentINIndividualLastName, AV10cResidentINIndividualPhone, AV11cResidentINIndividualGender, AV12pResidentId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINIndividualId, AV7cResidentINIndividualBsnNumber, AV8cResidentINIndividualGivenName, AV9cResidentINIndividualLastName, AV10cResidentINIndividualPhone, AV11cResidentINIndividualGender, AV12pResidentId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINIndividualId, AV7cResidentINIndividualBsnNumber, AV8cResidentINIndividualGivenName, AV9cResidentINIndividualLastName, AV10cResidentINIndividualPhone, AV11cResidentINIndividualGender, AV12pResidentId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtResidentINIndividualId_Enabled = 0;
         edtResidentINIndividualBsnNumber_Enabled = 0;
         edtResidentINIndividualGivenName_Enabled = 0;
         edtResidentId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP050( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18052 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCresidentinindividualid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCresidentinindividualid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRESIDENTININDIVIDUALID");
               GX_FocusControl = edtavCresidentinindividualid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cResidentINIndividualId = 0;
               AssignAttri("", false, "AV6cResidentINIndividualId", StringUtil.LTrimStr( (decimal)(AV6cResidentINIndividualId), 4, 0));
            }
            else
            {
               AV6cResidentINIndividualId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCresidentinindividualid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cResidentINIndividualId", StringUtil.LTrimStr( (decimal)(AV6cResidentINIndividualId), 4, 0));
            }
            AV7cResidentINIndividualBsnNumber = cgiGet( edtavCresidentinindividualbsnnumber_Internalname);
            AssignAttri("", false, "AV7cResidentINIndividualBsnNumber", AV7cResidentINIndividualBsnNumber);
            AV8cResidentINIndividualGivenName = cgiGet( edtavCresidentinindividualgivenname_Internalname);
            AssignAttri("", false, "AV8cResidentINIndividualGivenName", AV8cResidentINIndividualGivenName);
            AV9cResidentINIndividualLastName = cgiGet( edtavCresidentinindividuallastname_Internalname);
            AssignAttri("", false, "AV9cResidentINIndividualLastName", AV9cResidentINIndividualLastName);
            AV10cResidentINIndividualPhone = cgiGet( edtavCresidentinindividualphone_Internalname);
            AssignAttri("", false, "AV10cResidentINIndividualPhone", AV10cResidentINIndividualPhone);
            cmbavCresidentinindividualgender.Name = cmbavCresidentinindividualgender_Internalname;
            cmbavCresidentinindividualgender.CurrentValue = cgiGet( cmbavCresidentinindividualgender_Internalname);
            AV11cResidentINIndividualGender = cgiGet( cmbavCresidentinindividualgender_Internalname);
            AssignAttri("", false, "AV11cResidentINIndividualGender", AV11cResidentINIndividualGender);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESIDENTININDIVIDUALID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cResidentINIndividualId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALBSNNUMBER"), AV7cResidentINIndividualBsnNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALGIVENNAME"), AV8cResidentINIndividualGivenName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALLASTNAME"), AV9cResidentINIndividualLastName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALPHONE"), AV10cResidentINIndividualPhone) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTININDIVIDUALGENDER"), AV11cResidentINIndividualGender) != 0 )
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
         E18052 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18052( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "INIndividual", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E19052( )
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
         E20052 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20052( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pResidentINIndividualId = A42ResidentINIndividualId;
         AssignAttri("", false, "AV13pResidentINIndividualId", StringUtil.LTrimStr( (decimal)(AV13pResidentINIndividualId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pResidentINIndividualId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pResidentINIndividualId"});
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
         AV12pResidentId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV12pResidentId", StringUtil.LTrimStr( (decimal)(AV12pResidentId), 4, 0));
         AV13pResidentINIndividualId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV13pResidentINIndividualId", StringUtil.LTrimStr( (decimal)(AV13pResidentINIndividualId), 4, 0));
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
         PA052( ) ;
         WS052( ) ;
         WE052( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315564982", true, true);
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
         context.AddJavascriptSource("gx0061.js", "?202491315564982", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtResidentINIndividualId_Internalname = "RESIDENTININDIVIDUALID_"+sGXsfl_74_idx;
         edtResidentINIndividualBsnNumber_Internalname = "RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_74_idx;
         edtResidentINIndividualGivenName_Internalname = "RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_74_idx;
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtResidentINIndividualId_Internalname = "RESIDENTININDIVIDUALID_"+sGXsfl_74_fel_idx;
         edtResidentINIndividualBsnNumber_Internalname = "RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_74_fel_idx;
         edtResidentINIndividualGivenName_Internalname = "RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_74_fel_idx;
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB050( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A42ResidentINIndividualId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINIndividualId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtResidentINIndividualBsnNumber_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtResidentINIndividualBsnNumber_Internalname, "Link", edtResidentINIndividualBsnNumber_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualBsnNumber_Internalname,(string)A43ResidentINIndividualBsnNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtResidentINIndividualBsnNumber_Link,(string)"",(string)"",(string)"",(string)edtResidentINIndividualBsnNumber_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"BsnNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualGivenName_Internalname,(string)A44ResidentINIndividualGivenName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINIndividualGivenName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A31ResidentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A31ResidentId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes052( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCresidentinindividualgender.Name = "vCRESIDENTININDIVIDUALGENDER";
         cmbavCresidentinindividualgender.WebTags = "";
         cmbavCresidentinindividualgender.addItem("Man", context.GetMessage( "Man", ""), 0);
         cmbavCresidentinindividualgender.addItem("Woman", context.GetMessage( "Woman", ""), 0);
         cmbavCresidentinindividualgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavCresidentinindividualgender.ItemCount > 0 )
         {
            AV11cResidentINIndividualGender = cmbavCresidentinindividualgender.getValidValue(AV11cResidentINIndividualGender);
            AssignAttri("", false, "AV11cResidentINIndividualGender", AV11cResidentINIndividualGender);
         }
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
            context.SendWebValue( context.GetMessage( "INIndividual Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Bsn Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Given Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ResidentINIndividualId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A43ResidentINIndividualBsnNumber));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtResidentINIndividualBsnNumber_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A44ResidentINIndividualGivenName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A31ResidentId), 4, 0, ".", ""))));
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
         lblLblresidentinindividualidfilter_Internalname = "LBLRESIDENTININDIVIDUALIDFILTER";
         edtavCresidentinindividualid_Internalname = "vCRESIDENTININDIVIDUALID";
         divResidentinindividualidfiltercontainer_Internalname = "RESIDENTININDIVIDUALIDFILTERCONTAINER";
         lblLblresidentinindividualbsnnumberfilter_Internalname = "LBLRESIDENTININDIVIDUALBSNNUMBERFILTER";
         edtavCresidentinindividualbsnnumber_Internalname = "vCRESIDENTININDIVIDUALBSNNUMBER";
         divResidentinindividualbsnnumberfiltercontainer_Internalname = "RESIDENTININDIVIDUALBSNNUMBERFILTERCONTAINER";
         lblLblresidentinindividualgivennamefilter_Internalname = "LBLRESIDENTININDIVIDUALGIVENNAMEFILTER";
         edtavCresidentinindividualgivenname_Internalname = "vCRESIDENTININDIVIDUALGIVENNAME";
         divResidentinindividualgivennamefiltercontainer_Internalname = "RESIDENTININDIVIDUALGIVENNAMEFILTERCONTAINER";
         lblLblresidentinindividuallastnamefilter_Internalname = "LBLRESIDENTININDIVIDUALLASTNAMEFILTER";
         edtavCresidentinindividuallastname_Internalname = "vCRESIDENTININDIVIDUALLASTNAME";
         divResidentinindividuallastnamefiltercontainer_Internalname = "RESIDENTININDIVIDUALLASTNAMEFILTERCONTAINER";
         lblLblresidentinindividualphonefilter_Internalname = "LBLRESIDENTININDIVIDUALPHONEFILTER";
         edtavCresidentinindividualphone_Internalname = "vCRESIDENTININDIVIDUALPHONE";
         divResidentinindividualphonefiltercontainer_Internalname = "RESIDENTININDIVIDUALPHONEFILTERCONTAINER";
         lblLblresidentinindividualgenderfilter_Internalname = "LBLRESIDENTININDIVIDUALGENDERFILTER";
         cmbavCresidentinindividualgender_Internalname = "vCRESIDENTININDIVIDUALGENDER";
         divResidentinindividualgenderfiltercontainer_Internalname = "RESIDENTININDIVIDUALGENDERFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtResidentINIndividualId_Internalname = "RESIDENTININDIVIDUALID";
         edtResidentINIndividualBsnNumber_Internalname = "RESIDENTININDIVIDUALBSNNUMBER";
         edtResidentINIndividualGivenName_Internalname = "RESIDENTININDIVIDUALGIVENNAME";
         edtResidentId_Internalname = "RESIDENTID";
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
         edtResidentId_Jsonclick = "";
         edtResidentINIndividualGivenName_Jsonclick = "";
         edtResidentINIndividualBsnNumber_Jsonclick = "";
         edtResidentINIndividualBsnNumber_Link = "";
         edtResidentINIndividualId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtResidentId_Enabled = 0;
         edtResidentINIndividualGivenName_Enabled = 0;
         edtResidentINIndividualBsnNumber_Enabled = 0;
         edtResidentINIndividualId_Enabled = 0;
         cmbavCresidentinindividualgender_Jsonclick = "";
         cmbavCresidentinindividualgender.Visible = 1;
         cmbavCresidentinindividualgender.Enabled = 1;
         edtavCresidentinindividualphone_Jsonclick = "";
         edtavCresidentinindividualphone_Enabled = 1;
         edtavCresidentinindividualphone_Visible = 1;
         edtavCresidentinindividuallastname_Jsonclick = "";
         edtavCresidentinindividuallastname_Enabled = 1;
         edtavCresidentinindividuallastname_Visible = 1;
         edtavCresidentinindividualgivenname_Jsonclick = "";
         edtavCresidentinindividualgivenname_Enabled = 1;
         edtavCresidentinindividualgivenname_Visible = 1;
         edtavCresidentinindividualbsnnumber_Jsonclick = "";
         edtavCresidentinindividualbsnnumber_Enabled = 1;
         edtavCresidentinindividualbsnnumber_Visible = 1;
         edtavCresidentinindividualid_Jsonclick = "";
         edtavCresidentinindividualid_Enabled = 1;
         edtavCresidentinindividualid_Visible = 1;
         divResidentinindividualgenderfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentinindividualphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentinindividuallastnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentinindividualgivennamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentinindividualbsnnumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentinindividualidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List INIndividual", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINIndividualId","fld":"vCRESIDENTININDIVIDUALID","pic":"ZZZ9"},{"av":"AV7cResidentINIndividualBsnNumber","fld":"vCRESIDENTININDIVIDUALBSNNUMBER"},{"av":"AV8cResidentINIndividualGivenName","fld":"vCRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV9cResidentINIndividualLastName","fld":"vCRESIDENTININDIVIDUALLASTNAME"},{"av":"AV10cResidentINIndividualPhone","fld":"vCRESIDENTININDIVIDUALPHONE"},{"av":"cmbavCresidentinindividualgender"},{"av":"AV11cResidentINIndividualGender","fld":"vCRESIDENTININDIVIDUALGENDER"},{"av":"AV12pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E17051","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLRESIDENTININDIVIDUALIDFILTER.CLICK","""{"handler":"E11051","iparms":[{"av":"divResidentinindividualidfiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTININDIVIDUALIDFILTER.CLICK",""","oparms":[{"av":"divResidentinindividualidfiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentinindividualid_Visible","ctrl":"vCRESIDENTININDIVIDUALID","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTININDIVIDUALBSNNUMBERFILTER.CLICK","""{"handler":"E12051","iparms":[{"av":"divResidentinindividualbsnnumberfiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALBSNNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTININDIVIDUALBSNNUMBERFILTER.CLICK",""","oparms":[{"av":"divResidentinindividualbsnnumberfiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALBSNNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentinindividualbsnnumber_Visible","ctrl":"vCRESIDENTININDIVIDUALBSNNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTININDIVIDUALGIVENNAMEFILTER.CLICK","""{"handler":"E13051","iparms":[{"av":"divResidentinindividualgivennamefiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALGIVENNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTININDIVIDUALGIVENNAMEFILTER.CLICK",""","oparms":[{"av":"divResidentinindividualgivennamefiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALGIVENNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentinindividualgivenname_Visible","ctrl":"vCRESIDENTININDIVIDUALGIVENNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTININDIVIDUALLASTNAMEFILTER.CLICK","""{"handler":"E14051","iparms":[{"av":"divResidentinindividuallastnamefiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALLASTNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTININDIVIDUALLASTNAMEFILTER.CLICK",""","oparms":[{"av":"divResidentinindividuallastnamefiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALLASTNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentinindividuallastname_Visible","ctrl":"vCRESIDENTININDIVIDUALLASTNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTININDIVIDUALPHONEFILTER.CLICK","""{"handler":"E15051","iparms":[{"av":"divResidentinindividualphonefiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTININDIVIDUALPHONEFILTER.CLICK",""","oparms":[{"av":"divResidentinindividualphonefiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentinindividualphone_Visible","ctrl":"vCRESIDENTININDIVIDUALPHONE","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTININDIVIDUALGENDERFILTER.CLICK","""{"handler":"E16051","iparms":[{"av":"divResidentinindividualgenderfiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALGENDERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTININDIVIDUALGENDERFILTER.CLICK",""","oparms":[{"av":"divResidentinindividualgenderfiltercontainer_Class","ctrl":"RESIDENTININDIVIDUALGENDERFILTERCONTAINER","prop":"Class"},{"av":"cmbavCresidentinindividualgender"}]}""");
         setEventMetadata("ENTER","""{"handler":"E20052","iparms":[{"av":"A42ResidentINIndividualId","fld":"RESIDENTININDIVIDUALID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pResidentINIndividualId","fld":"vPRESIDENTININDIVIDUALID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINIndividualId","fld":"vCRESIDENTININDIVIDUALID","pic":"ZZZ9"},{"av":"AV7cResidentINIndividualBsnNumber","fld":"vCRESIDENTININDIVIDUALBSNNUMBER"},{"av":"AV8cResidentINIndividualGivenName","fld":"vCRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV9cResidentINIndividualLastName","fld":"vCRESIDENTININDIVIDUALLASTNAME"},{"av":"AV10cResidentINIndividualPhone","fld":"vCRESIDENTININDIVIDUALPHONE"},{"av":"cmbavCresidentinindividualgender"},{"av":"AV11cResidentINIndividualGender","fld":"vCRESIDENTININDIVIDUALGENDER"},{"av":"AV12pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINIndividualId","fld":"vCRESIDENTININDIVIDUALID","pic":"ZZZ9"},{"av":"AV7cResidentINIndividualBsnNumber","fld":"vCRESIDENTININDIVIDUALBSNNUMBER"},{"av":"AV8cResidentINIndividualGivenName","fld":"vCRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV9cResidentINIndividualLastName","fld":"vCRESIDENTININDIVIDUALLASTNAME"},{"av":"AV10cResidentINIndividualPhone","fld":"vCRESIDENTININDIVIDUALPHONE"},{"av":"cmbavCresidentinindividualgender"},{"av":"AV11cResidentINIndividualGender","fld":"vCRESIDENTININDIVIDUALGENDER"},{"av":"AV12pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINIndividualId","fld":"vCRESIDENTININDIVIDUALID","pic":"ZZZ9"},{"av":"AV7cResidentINIndividualBsnNumber","fld":"vCRESIDENTININDIVIDUALBSNNUMBER"},{"av":"AV8cResidentINIndividualGivenName","fld":"vCRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV9cResidentINIndividualLastName","fld":"vCRESIDENTININDIVIDUALLASTNAME"},{"av":"AV10cResidentINIndividualPhone","fld":"vCRESIDENTININDIVIDUALPHONE"},{"av":"cmbavCresidentinindividualgender"},{"av":"AV11cResidentINIndividualGender","fld":"vCRESIDENTININDIVIDUALGENDER"},{"av":"AV12pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINIndividualId","fld":"vCRESIDENTININDIVIDUALID","pic":"ZZZ9"},{"av":"AV7cResidentINIndividualBsnNumber","fld":"vCRESIDENTININDIVIDUALBSNNUMBER"},{"av":"AV8cResidentINIndividualGivenName","fld":"vCRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV9cResidentINIndividualLastName","fld":"vCRESIDENTININDIVIDUALLASTNAME"},{"av":"AV10cResidentINIndividualPhone","fld":"vCRESIDENTININDIVIDUALPHONE"},{"av":"cmbavCresidentinindividualgender"},{"av":"AV11cResidentINIndividualGender","fld":"vCRESIDENTININDIVIDUALGENDER"},{"av":"AV12pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALIDV_CRESIDENTININDIVIDUALGENDER","""{"handler":"Validv_Cresidentinindividualgender","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Residentid","iparms":[]}""");
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
         AV7cResidentINIndividualBsnNumber = "";
         AV8cResidentINIndividualGivenName = "";
         AV9cResidentINIndividualLastName = "";
         AV10cResidentINIndividualPhone = "";
         AV11cResidentINIndividualGender = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblresidentinindividualidfilter_Jsonclick = "";
         TempTags = "";
         lblLblresidentinindividualbsnnumberfilter_Jsonclick = "";
         lblLblresidentinindividualgivennamefilter_Jsonclick = "";
         lblLblresidentinindividuallastnamefilter_Jsonclick = "";
         lblLblresidentinindividualphonefilter_Jsonclick = "";
         lblLblresidentinindividualgenderfilter_Jsonclick = "";
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
         A43ResidentINIndividualBsnNumber = "";
         A44ResidentINIndividualGivenName = "";
         lV7cResidentINIndividualBsnNumber = "";
         lV8cResidentINIndividualGivenName = "";
         lV9cResidentINIndividualLastName = "";
         lV10cResidentINIndividualPhone = "";
         lV11cResidentINIndividualGender = "";
         A45ResidentINIndividualLastName = "";
         A47ResidentINIndividualPhone = "";
         A49ResidentINIndividualGender = "";
         H00052_A49ResidentINIndividualGender = new string[] {""} ;
         H00052_A47ResidentINIndividualPhone = new string[] {""} ;
         H00052_n47ResidentINIndividualPhone = new bool[] {false} ;
         H00052_A45ResidentINIndividualLastName = new string[] {""} ;
         H00052_A31ResidentId = new short[1] ;
         H00052_A44ResidentINIndividualGivenName = new string[] {""} ;
         H00052_A43ResidentINIndividualBsnNumber = new string[] {""} ;
         H00052_A42ResidentINIndividualId = new short[1] ;
         H00053_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0061__default(),
            new Object[][] {
                new Object[] {
               H00052_A49ResidentINIndividualGender, H00052_A47ResidentINIndividualPhone, H00052_n47ResidentINIndividualPhone, H00052_A45ResidentINIndividualLastName, H00052_A31ResidentId, H00052_A44ResidentINIndividualGivenName, H00052_A43ResidentINIndividualBsnNumber, H00052_A42ResidentINIndividualId
               }
               , new Object[] {
               H00053_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12pResidentId ;
      private short AV13pResidentINIndividualId ;
      private short wcpOAV12pResidentId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cResidentINIndividualId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A42ResidentINIndividualId ;
      private short A31ResidentId ;
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
      private int edtavCresidentinindividualid_Enabled ;
      private int edtavCresidentinindividualid_Visible ;
      private int edtavCresidentinindividualbsnnumber_Visible ;
      private int edtavCresidentinindividualbsnnumber_Enabled ;
      private int edtavCresidentinindividualgivenname_Visible ;
      private int edtavCresidentinindividualgivenname_Enabled ;
      private int edtavCresidentinindividuallastname_Visible ;
      private int edtavCresidentinindividuallastname_Enabled ;
      private int edtavCresidentinindividualphone_Visible ;
      private int edtavCresidentinindividualphone_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtResidentINIndividualId_Enabled ;
      private int edtResidentINIndividualBsnNumber_Enabled ;
      private int edtResidentINIndividualGivenName_Enabled ;
      private int edtResidentId_Enabled ;
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
      private string divResidentinindividualidfiltercontainer_Class ;
      private string divResidentinindividualbsnnumberfiltercontainer_Class ;
      private string divResidentinindividualgivennamefiltercontainer_Class ;
      private string divResidentinindividuallastnamefiltercontainer_Class ;
      private string divResidentinindividualphonefiltercontainer_Class ;
      private string divResidentinindividualgenderfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV10cResidentINIndividualPhone ;
      private string AV11cResidentINIndividualGender ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divResidentinindividualidfiltercontainer_Internalname ;
      private string lblLblresidentinindividualidfilter_Internalname ;
      private string lblLblresidentinindividualidfilter_Jsonclick ;
      private string edtavCresidentinindividualid_Internalname ;
      private string TempTags ;
      private string edtavCresidentinindividualid_Jsonclick ;
      private string divResidentinindividualbsnnumberfiltercontainer_Internalname ;
      private string lblLblresidentinindividualbsnnumberfilter_Internalname ;
      private string lblLblresidentinindividualbsnnumberfilter_Jsonclick ;
      private string edtavCresidentinindividualbsnnumber_Internalname ;
      private string edtavCresidentinindividualbsnnumber_Jsonclick ;
      private string divResidentinindividualgivennamefiltercontainer_Internalname ;
      private string lblLblresidentinindividualgivennamefilter_Internalname ;
      private string lblLblresidentinindividualgivennamefilter_Jsonclick ;
      private string edtavCresidentinindividualgivenname_Internalname ;
      private string edtavCresidentinindividualgivenname_Jsonclick ;
      private string divResidentinindividuallastnamefiltercontainer_Internalname ;
      private string lblLblresidentinindividuallastnamefilter_Internalname ;
      private string lblLblresidentinindividuallastnamefilter_Jsonclick ;
      private string edtavCresidentinindividuallastname_Internalname ;
      private string edtavCresidentinindividuallastname_Jsonclick ;
      private string divResidentinindividualphonefiltercontainer_Internalname ;
      private string lblLblresidentinindividualphonefilter_Internalname ;
      private string lblLblresidentinindividualphonefilter_Jsonclick ;
      private string edtavCresidentinindividualphone_Internalname ;
      private string edtavCresidentinindividualphone_Jsonclick ;
      private string divResidentinindividualgenderfiltercontainer_Internalname ;
      private string lblLblresidentinindividualgenderfilter_Internalname ;
      private string lblLblresidentinindividualgenderfilter_Jsonclick ;
      private string cmbavCresidentinindividualgender_Internalname ;
      private string cmbavCresidentinindividualgender_Jsonclick ;
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
      private string edtResidentINIndividualId_Internalname ;
      private string edtResidentINIndividualBsnNumber_Internalname ;
      private string edtResidentINIndividualGivenName_Internalname ;
      private string edtResidentId_Internalname ;
      private string lV10cResidentINIndividualPhone ;
      private string lV11cResidentINIndividualGender ;
      private string A47ResidentINIndividualPhone ;
      private string A49ResidentINIndividualGender ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtResidentINIndividualId_Jsonclick ;
      private string edtResidentINIndividualBsnNumber_Link ;
      private string edtResidentINIndividualBsnNumber_Jsonclick ;
      private string edtResidentINIndividualGivenName_Jsonclick ;
      private string edtResidentId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n47ResidentINIndividualPhone ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cResidentINIndividualBsnNumber ;
      private string AV8cResidentINIndividualGivenName ;
      private string AV9cResidentINIndividualLastName ;
      private string AV15Linkselection_GXI ;
      private string A43ResidentINIndividualBsnNumber ;
      private string A44ResidentINIndividualGivenName ;
      private string lV7cResidentINIndividualBsnNumber ;
      private string lV8cResidentINIndividualGivenName ;
      private string lV9cResidentINIndividualLastName ;
      private string A45ResidentINIndividualLastName ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCresidentinindividualgender ;
      private IDataStoreProvider pr_default ;
      private string[] H00052_A49ResidentINIndividualGender ;
      private string[] H00052_A47ResidentINIndividualPhone ;
      private bool[] H00052_n47ResidentINIndividualPhone ;
      private string[] H00052_A45ResidentINIndividualLastName ;
      private short[] H00052_A31ResidentId ;
      private string[] H00052_A44ResidentINIndividualGivenName ;
      private string[] H00052_A43ResidentINIndividualBsnNumber ;
      private short[] H00052_A42ResidentINIndividualId ;
      private long[] H00053_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pResidentINIndividualId ;
   }

   public class gx0061__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00052( IGxContext context ,
                                             string AV7cResidentINIndividualBsnNumber ,
                                             string AV8cResidentINIndividualGivenName ,
                                             string AV9cResidentINIndividualLastName ,
                                             string AV10cResidentINIndividualPhone ,
                                             string AV11cResidentINIndividualGender ,
                                             string A43ResidentINIndividualBsnNumber ,
                                             string A44ResidentINIndividualGivenName ,
                                             string A45ResidentINIndividualLastName ,
                                             string A47ResidentINIndividualPhone ,
                                             string A49ResidentINIndividualGender ,
                                             short AV12pResidentId ,
                                             short AV6cResidentINIndividualId ,
                                             short A31ResidentId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ResidentINIndividualGender, ResidentINIndividualPhone, ResidentINIndividualLastName, ResidentId, ResidentINIndividualGivenName, ResidentINIndividualBsnNumber, ResidentINIndividualId";
         sFromString = " FROM ResidentINIndividual";
         sOrderString = "";
         AddWhere(sWhereString, "(ResidentId = :AV12pResidentId and ResidentINIndividualId >= :AV6cResidentINIndividualId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cResidentINIndividualBsnNumber)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualBsnNumber like :lV7cResidentINIndividualBsnNumber)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cResidentINIndividualGivenName)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualGivenName like :lV8cResidentINIndividualGivenName)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cResidentINIndividualLastName)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualLastName like :lV9cResidentINIndividualLastName)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cResidentINIndividualPhone)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualPhone like :lV10cResidentINIndividualPhone)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cResidentINIndividualGender)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualGender like :lV11cResidentINIndividualGender)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY ResidentId, ResidentINIndividualId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00053( IGxContext context ,
                                             string AV7cResidentINIndividualBsnNumber ,
                                             string AV8cResidentINIndividualGivenName ,
                                             string AV9cResidentINIndividualLastName ,
                                             string AV10cResidentINIndividualPhone ,
                                             string AV11cResidentINIndividualGender ,
                                             string A43ResidentINIndividualBsnNumber ,
                                             string A44ResidentINIndividualGivenName ,
                                             string A45ResidentINIndividualLastName ,
                                             string A47ResidentINIndividualPhone ,
                                             string A49ResidentINIndividualGender ,
                                             short AV12pResidentId ,
                                             short AV6cResidentINIndividualId ,
                                             short A31ResidentId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ResidentINIndividual";
         AddWhere(sWhereString, "(ResidentId = :AV12pResidentId and ResidentINIndividualId >= :AV6cResidentINIndividualId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cResidentINIndividualBsnNumber)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualBsnNumber like :lV7cResidentINIndividualBsnNumber)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cResidentINIndividualGivenName)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualGivenName like :lV8cResidentINIndividualGivenName)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cResidentINIndividualLastName)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualLastName like :lV9cResidentINIndividualLastName)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cResidentINIndividualPhone)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualPhone like :lV10cResidentINIndividualPhone)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cResidentINIndividualGender)) )
         {
            AddWhere(sWhereString, "(ResidentINIndividualGender like :lV11cResidentINIndividualGender)");
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
                     return conditional_H00052(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H00053(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmH00052;
          prmH00052 = new Object[] {
          new ParDef("AV12pResidentId",GXType.Int16,4,0) ,
          new ParDef("AV6cResidentINIndividualId",GXType.Int16,4,0) ,
          new ParDef("lV7cResidentINIndividualBsnNumber",GXType.VarChar,40,0) ,
          new ParDef("lV8cResidentINIndividualGivenName",GXType.VarChar,40,0) ,
          new ParDef("lV9cResidentINIndividualLastName",GXType.VarChar,40,0) ,
          new ParDef("lV10cResidentINIndividualPhone",GXType.Char,20,0) ,
          new ParDef("lV11cResidentINIndividualGender",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00053;
          prmH00053 = new Object[] {
          new ParDef("AV12pResidentId",GXType.Int16,4,0) ,
          new ParDef("AV6cResidentINIndividualId",GXType.Int16,4,0) ,
          new ParDef("lV7cResidentINIndividualBsnNumber",GXType.VarChar,40,0) ,
          new ParDef("lV8cResidentINIndividualGivenName",GXType.VarChar,40,0) ,
          new ParDef("lV9cResidentINIndividualLastName",GXType.VarChar,40,0) ,
          new ParDef("lV10cResidentINIndividualPhone",GXType.Char,20,0) ,
          new ParDef("lV11cResidentINIndividualGender",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00052", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00052,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00053", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00053,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
