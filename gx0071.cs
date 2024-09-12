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
   public class gx0071 : GXDataArea
   {
      public gx0071( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0071( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pResidentId ,
                           out short aP1_pResidentINCompanyId )
      {
         this.AV10pResidentId = aP0_pResidentId;
         this.AV11pResidentINCompanyId = 0 ;
         ExecuteImpl();
         aP1_pResidentINCompanyId=this.AV11pResidentINCompanyId;
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
               AV10pResidentId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10pResidentId", StringUtil.LTrimStr( (decimal)(AV10pResidentId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11pResidentINCompanyId = (short)(Math.Round(NumberUtil.Val( GetPar( "pResidentINCompanyId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11pResidentINCompanyId", StringUtil.LTrimStr( (decimal)(AV11pResidentINCompanyId), 4, 0));
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
         nRC_GXsfl_54 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_54"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_54_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_54_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_54_idx = GetPar( "sGXsfl_54_idx");
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
         AV6cResidentINCompanyId = (short)(Math.Round(NumberUtil.Val( GetPar( "cResidentINCompanyId"), "."), 18, MidpointRounding.ToEven));
         AV7cResidentINCompanyKvkNumber = GetPar( "cResidentINCompanyKvkNumber");
         AV8cResidentINCompanyName = GetPar( "cResidentINCompanyName");
         AV9cResidentINCompanyPhone = GetPar( "cResidentINCompanyPhone");
         AV10pResidentId = (short)(Math.Round(NumberUtil.Val( GetPar( "pResidentId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINCompanyId, AV7cResidentINCompanyKvkNumber, AV8cResidentINCompanyName, AV9cResidentINCompanyPhone, AV10pResidentId) ;
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
            return "gx0071_Execute" ;
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
         PA062( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START062( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0071.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pResidentId,4,0)),UrlEncode(StringUtil.LTrimStr(AV11pResidentINCompanyId,4,0))}, new string[] {"pResidentId","pResidentINCompanyId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTINCOMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cResidentINCompanyId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTINCOMPANYKVKNUMBER", AV7cResidentINCompanyKvkNumber);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTINCOMPANYNAME", AV8cResidentINCompanyName);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESIDENTINCOMPANYPHONE", StringUtil.RTrim( AV9cResidentINCompanyPhone));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_54", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_54), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPRESIDENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pResidentId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPRESIDENTINCOMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pResidentINCompanyId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYIDFILTERCONTAINER_Class", StringUtil.RTrim( divResidentincompanyidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER_Class", StringUtil.RTrim( divResidentincompanykvknumberfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divResidentincompanynamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divResidentincompanyphonefiltercontainer_Class));
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
            WE062( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT062( ) ;
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
         return formatLink("gx0071.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pResidentId,4,0)),UrlEncode(StringUtil.LTrimStr(AV11pResidentINCompanyId,4,0))}, new string[] {"pResidentId","pResidentINCompanyId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0071" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List INCompany" ;
      }

      protected void WB060( )
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
            GxWebStd.gx_div_start( context, divResidentincompanyidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentincompanyidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentincompanyidfilter_Internalname, "Resident INCompany Id", "", "", lblLblresidentincompanyidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0071.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentincompanyid_Internalname, "Resident INCompany Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentincompanyid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cResidentINCompanyId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCresidentincompanyid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cResidentINCompanyId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cResidentINCompanyId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentincompanyid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentincompanyid_Visible, edtavCresidentincompanyid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0071.htm");
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
            GxWebStd.gx_div_start( context, divResidentincompanykvknumberfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentincompanykvknumberfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentincompanykvknumberfilter_Internalname, "Resident INCompany Kvk Number", "", "", lblLblresidentincompanykvknumberfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0071.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentincompanykvknumber_Internalname, "Resident INCompany Kvk Number", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentincompanykvknumber_Internalname, AV7cResidentINCompanyKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV7cResidentINCompanyKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentincompanykvknumber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentincompanykvknumber_Visible, edtavCresidentincompanykvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0071.htm");
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
            GxWebStd.gx_div_start( context, divResidentincompanynamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentincompanynamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentincompanynamefilter_Internalname, "Resident INCompany Name", "", "", lblLblresidentincompanynamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0071.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentincompanyname_Internalname, "Resident INCompany Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentincompanyname_Internalname, AV8cResidentINCompanyName, StringUtil.RTrim( context.localUtil.Format( AV8cResidentINCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentincompanyname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentincompanyname_Visible, edtavCresidentincompanyname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0071.htm");
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
            GxWebStd.gx_div_start( context, divResidentincompanyphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divResidentincompanyphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresidentincompanyphonefilter_Internalname, "Resident INCompany Phone", "", "", lblLblresidentincompanyphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0071.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresidentincompanyphone_Internalname, "Resident INCompany Phone", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresidentincompanyphone_Internalname, StringUtil.RTrim( AV9cResidentINCompanyPhone), StringUtil.RTrim( context.localUtil.Format( AV9cResidentINCompanyPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresidentincompanyphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresidentincompanyphone_Visible, edtavCresidentincompanyphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0071.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(54), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e15061_client"+"'", TempTags, "", 2, "HLP_Gx0071.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl54( ) ;
         }
         if ( wbEnd == 54 )
         {
            wbEnd = 0;
            nRC_GXsfl_54 = (int)(nGXsfl_54_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(54), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0071.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 54 )
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

      protected void START062( )
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
         Form.Meta.addItem("description", "Selection List INCompany", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP060( ) ;
      }

      protected void WS062( )
      {
         START062( ) ;
         EVT062( ) ;
      }

      protected void EVT062( )
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
                              nGXsfl_54_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
                              SubsflControlProps_542( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV13Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_54_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A50ResidentINCompanyId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentINCompanyId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A51ResidentINCompanyKvkNumber = cgiGet( edtResidentINCompanyKvkNumber_Internalname);
                              A52ResidentINCompanyName = cgiGet( edtResidentINCompanyName_Internalname);
                              A54ResidentINCompanyPhone = cgiGet( edtResidentINCompanyPhone_Internalname);
                              n54ResidentINCompanyPhone = false;
                              A31ResidentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E16062 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E17062 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cresidentincompanyid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESIDENTINCOMPANYID"), ".", ",") != Convert.ToDecimal( AV6cResidentINCompanyId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentincompanykvknumber Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTINCOMPANYKVKNUMBER"), AV7cResidentINCompanyKvkNumber) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentincompanyname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTINCOMPANYNAME"), AV8cResidentINCompanyName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresidentincompanyphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTINCOMPANYPHONE"), AV9cResidentINCompanyPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E18062 ();
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

      protected void WE062( )
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

      protected void PA062( )
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
         SubsflControlProps_542( ) ;
         while ( nGXsfl_54_idx <= nRC_GXsfl_54 )
         {
            sendrow_542( ) ;
            nGXsfl_54_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_54_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cResidentINCompanyId ,
                                        string AV7cResidentINCompanyKvkNumber ,
                                        string AV8cResidentINCompanyName ,
                                        string AV9cResidentINCompanyPhone ,
                                        short AV10pResidentId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF062( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTINCOMPANYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A50ResidentINCompanyId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ResidentINCompanyId), 4, 0, ".", "")));
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
         RF062( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF062( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 54;
         nGXsfl_54_idx = 1;
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_542( ) ;
         bGXsfl_54_Refreshing = true;
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
            SubsflControlProps_542( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cResidentINCompanyKvkNumber ,
                                                 AV8cResidentINCompanyName ,
                                                 AV9cResidentINCompanyPhone ,
                                                 A51ResidentINCompanyKvkNumber ,
                                                 A52ResidentINCompanyName ,
                                                 A54ResidentINCompanyPhone ,
                                                 AV10pResidentId ,
                                                 AV6cResidentINCompanyId ,
                                                 A31ResidentId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cResidentINCompanyKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV7cResidentINCompanyKvkNumber), "%", "");
            lV8cResidentINCompanyName = StringUtil.Concat( StringUtil.RTrim( AV8cResidentINCompanyName), "%", "");
            lV9cResidentINCompanyPhone = StringUtil.PadR( StringUtil.RTrim( AV9cResidentINCompanyPhone), 20, "%");
            /* Using cursor H00062 */
            pr_default.execute(0, new Object[] {AV10pResidentId, AV6cResidentINCompanyId, lV7cResidentINCompanyKvkNumber, lV8cResidentINCompanyName, lV9cResidentINCompanyPhone, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_54_idx = 1;
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A31ResidentId = H00062_A31ResidentId[0];
               A54ResidentINCompanyPhone = H00062_A54ResidentINCompanyPhone[0];
               n54ResidentINCompanyPhone = H00062_n54ResidentINCompanyPhone[0];
               A52ResidentINCompanyName = H00062_A52ResidentINCompanyName[0];
               A51ResidentINCompanyKvkNumber = H00062_A51ResidentINCompanyKvkNumber[0];
               A50ResidentINCompanyId = H00062_A50ResidentINCompanyId[0];
               /* Execute user event: Load */
               E17062 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 54;
            WB060( ) ;
         }
         bGXsfl_54_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes062( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTINCOMPANYID"+"_"+sGXsfl_54_idx, GetSecureSignedToken( sGXsfl_54_idx, context.localUtil.Format( (decimal)(A50ResidentINCompanyId), "ZZZ9"), context));
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
                                              AV7cResidentINCompanyKvkNumber ,
                                              AV8cResidentINCompanyName ,
                                              AV9cResidentINCompanyPhone ,
                                              A51ResidentINCompanyKvkNumber ,
                                              A52ResidentINCompanyName ,
                                              A54ResidentINCompanyPhone ,
                                              AV10pResidentId ,
                                              AV6cResidentINCompanyId ,
                                              A31ResidentId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cResidentINCompanyKvkNumber = StringUtil.Concat( StringUtil.RTrim( AV7cResidentINCompanyKvkNumber), "%", "");
         lV8cResidentINCompanyName = StringUtil.Concat( StringUtil.RTrim( AV8cResidentINCompanyName), "%", "");
         lV9cResidentINCompanyPhone = StringUtil.PadR( StringUtil.RTrim( AV9cResidentINCompanyPhone), 20, "%");
         /* Using cursor H00063 */
         pr_default.execute(1, new Object[] {AV10pResidentId, AV6cResidentINCompanyId, lV7cResidentINCompanyKvkNumber, lV8cResidentINCompanyName, lV9cResidentINCompanyPhone});
         GRID1_nRecordCount = H00063_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINCompanyId, AV7cResidentINCompanyKvkNumber, AV8cResidentINCompanyName, AV9cResidentINCompanyPhone, AV10pResidentId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINCompanyId, AV7cResidentINCompanyKvkNumber, AV8cResidentINCompanyName, AV9cResidentINCompanyPhone, AV10pResidentId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINCompanyId, AV7cResidentINCompanyKvkNumber, AV8cResidentINCompanyName, AV9cResidentINCompanyPhone, AV10pResidentId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINCompanyId, AV7cResidentINCompanyKvkNumber, AV8cResidentINCompanyName, AV9cResidentINCompanyPhone, AV10pResidentId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResidentINCompanyId, AV7cResidentINCompanyKvkNumber, AV8cResidentINCompanyName, AV9cResidentINCompanyPhone, AV10pResidentId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtResidentINCompanyId_Enabled = 0;
         edtResidentINCompanyKvkNumber_Enabled = 0;
         edtResidentINCompanyName_Enabled = 0;
         edtResidentINCompanyPhone_Enabled = 0;
         edtResidentId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP060( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16062 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_54 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_54"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCresidentincompanyid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCresidentincompanyid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRESIDENTINCOMPANYID");
               GX_FocusControl = edtavCresidentincompanyid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cResidentINCompanyId = 0;
               AssignAttri("", false, "AV6cResidentINCompanyId", StringUtil.LTrimStr( (decimal)(AV6cResidentINCompanyId), 4, 0));
            }
            else
            {
               AV6cResidentINCompanyId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCresidentincompanyid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cResidentINCompanyId", StringUtil.LTrimStr( (decimal)(AV6cResidentINCompanyId), 4, 0));
            }
            AV7cResidentINCompanyKvkNumber = cgiGet( edtavCresidentincompanykvknumber_Internalname);
            AssignAttri("", false, "AV7cResidentINCompanyKvkNumber", AV7cResidentINCompanyKvkNumber);
            AV8cResidentINCompanyName = cgiGet( edtavCresidentincompanyname_Internalname);
            AssignAttri("", false, "AV8cResidentINCompanyName", AV8cResidentINCompanyName);
            AV9cResidentINCompanyPhone = cgiGet( edtavCresidentincompanyphone_Internalname);
            AssignAttri("", false, "AV9cResidentINCompanyPhone", AV9cResidentINCompanyPhone);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESIDENTINCOMPANYID"), ".", ",") != Convert.ToDecimal( AV6cResidentINCompanyId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTINCOMPANYKVKNUMBER"), AV7cResidentINCompanyKvkNumber) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTINCOMPANYNAME"), AV8cResidentINCompanyName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESIDENTINCOMPANYPHONE"), AV9cResidentINCompanyPhone) != 0 )
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
         E16062 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16062( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "INCompany", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E17062( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV13Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_542( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_54_Refreshing )
         {
            DoAjaxLoad(54, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E18062 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18062( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pResidentINCompanyId = A50ResidentINCompanyId;
         AssignAttri("", false, "AV11pResidentINCompanyId", StringUtil.LTrimStr( (decimal)(AV11pResidentINCompanyId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV11pResidentINCompanyId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pResidentINCompanyId"});
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
         AV10pResidentId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV10pResidentId", StringUtil.LTrimStr( (decimal)(AV10pResidentId), 4, 0));
         AV11pResidentINCompanyId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV11pResidentINCompanyId", StringUtil.LTrimStr( (decimal)(AV11pResidentINCompanyId), 4, 0));
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
         PA062( ) ;
         WS062( ) ;
         WE062( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126321273", true, true);
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
         context.AddJavascriptSource("gx0071.js", "?20249126321273", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_542( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_54_idx;
         edtResidentINCompanyId_Internalname = "RESIDENTINCOMPANYID_"+sGXsfl_54_idx;
         edtResidentINCompanyKvkNumber_Internalname = "RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_54_idx;
         edtResidentINCompanyName_Internalname = "RESIDENTINCOMPANYNAME_"+sGXsfl_54_idx;
         edtResidentINCompanyPhone_Internalname = "RESIDENTINCOMPANYPHONE_"+sGXsfl_54_idx;
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_54_idx;
      }

      protected void SubsflControlProps_fel_542( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_54_fel_idx;
         edtResidentINCompanyId_Internalname = "RESIDENTINCOMPANYID_"+sGXsfl_54_fel_idx;
         edtResidentINCompanyKvkNumber_Internalname = "RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_54_fel_idx;
         edtResidentINCompanyName_Internalname = "RESIDENTINCOMPANYNAME_"+sGXsfl_54_fel_idx;
         edtResidentINCompanyPhone_Internalname = "RESIDENTINCOMPANYPHONE_"+sGXsfl_54_fel_idx;
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_54_fel_idx;
      }

      protected void sendrow_542( )
      {
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_542( ) ;
         WB060( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_54_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_54_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_54_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ResidentINCompanyId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_54_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINCompanyId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ResidentINCompanyId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A50ResidentINCompanyId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINCompanyId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtResidentINCompanyKvkNumber_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ResidentINCompanyId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtResidentINCompanyKvkNumber_Internalname, "Link", edtResidentINCompanyKvkNumber_Link, !bGXsfl_54_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINCompanyKvkNumber_Internalname,(string)A51ResidentINCompanyKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtResidentINCompanyKvkNumber_Link,(string)"",(string)"",(string)"",(string)edtResidentINCompanyKvkNumber_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINCompanyName_Internalname,(string)A52ResidentINCompanyName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A54ResidentINCompanyPhone);
            }
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINCompanyPhone_Internalname,StringUtil.RTrim( A54ResidentINCompanyPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtResidentINCompanyPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A31ResidentId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A31ResidentId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes062( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_54_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_54_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
         }
         /* End function sendrow_542 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl54( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"54\">") ;
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
            context.SendWebValue( "INCompany Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Kvk Number") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "INCompany Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "INCompany Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Resident Id") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ResidentINCompanyId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A51ResidentINCompanyKvkNumber));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtResidentINCompanyKvkNumber_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A52ResidentINCompanyName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A54ResidentINCompanyPhone)));
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
         lblLblresidentincompanyidfilter_Internalname = "LBLRESIDENTINCOMPANYIDFILTER";
         edtavCresidentincompanyid_Internalname = "vCRESIDENTINCOMPANYID";
         divResidentincompanyidfiltercontainer_Internalname = "RESIDENTINCOMPANYIDFILTERCONTAINER";
         lblLblresidentincompanykvknumberfilter_Internalname = "LBLRESIDENTINCOMPANYKVKNUMBERFILTER";
         edtavCresidentincompanykvknumber_Internalname = "vCRESIDENTINCOMPANYKVKNUMBER";
         divResidentincompanykvknumberfiltercontainer_Internalname = "RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER";
         lblLblresidentincompanynamefilter_Internalname = "LBLRESIDENTINCOMPANYNAMEFILTER";
         edtavCresidentincompanyname_Internalname = "vCRESIDENTINCOMPANYNAME";
         divResidentincompanynamefiltercontainer_Internalname = "RESIDENTINCOMPANYNAMEFILTERCONTAINER";
         lblLblresidentincompanyphonefilter_Internalname = "LBLRESIDENTINCOMPANYPHONEFILTER";
         edtavCresidentincompanyphone_Internalname = "vCRESIDENTINCOMPANYPHONE";
         divResidentincompanyphonefiltercontainer_Internalname = "RESIDENTINCOMPANYPHONEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtResidentINCompanyId_Internalname = "RESIDENTINCOMPANYID";
         edtResidentINCompanyKvkNumber_Internalname = "RESIDENTINCOMPANYKVKNUMBER";
         edtResidentINCompanyName_Internalname = "RESIDENTINCOMPANYNAME";
         edtResidentINCompanyPhone_Internalname = "RESIDENTINCOMPANYPHONE";
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
         edtResidentINCompanyPhone_Jsonclick = "";
         edtResidentINCompanyName_Jsonclick = "";
         edtResidentINCompanyKvkNumber_Jsonclick = "";
         edtResidentINCompanyKvkNumber_Link = "";
         edtResidentINCompanyId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtResidentId_Enabled = 0;
         edtResidentINCompanyPhone_Enabled = 0;
         edtResidentINCompanyName_Enabled = 0;
         edtResidentINCompanyKvkNumber_Enabled = 0;
         edtResidentINCompanyId_Enabled = 0;
         edtavCresidentincompanyphone_Jsonclick = "";
         edtavCresidentincompanyphone_Enabled = 1;
         edtavCresidentincompanyphone_Visible = 1;
         edtavCresidentincompanyname_Jsonclick = "";
         edtavCresidentincompanyname_Enabled = 1;
         edtavCresidentincompanyname_Visible = 1;
         edtavCresidentincompanykvknumber_Jsonclick = "";
         edtavCresidentincompanykvknumber_Enabled = 1;
         edtavCresidentincompanykvknumber_Visible = 1;
         edtavCresidentincompanyid_Jsonclick = "";
         edtavCresidentincompanyid_Enabled = 1;
         edtavCresidentincompanyid_Visible = 1;
         divResidentincompanyphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentincompanynamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentincompanykvknumberfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divResidentincompanyidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List INCompany";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINCompanyId","fld":"vCRESIDENTINCOMPANYID","pic":"ZZZ9"},{"av":"AV7cResidentINCompanyKvkNumber","fld":"vCRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV8cResidentINCompanyName","fld":"vCRESIDENTINCOMPANYNAME"},{"av":"AV9cResidentINCompanyPhone","fld":"vCRESIDENTINCOMPANYPHONE"},{"av":"AV10pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E15061","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLRESIDENTINCOMPANYIDFILTER.CLICK","""{"handler":"E11061","iparms":[{"av":"divResidentincompanyidfiltercontainer_Class","ctrl":"RESIDENTINCOMPANYIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTINCOMPANYIDFILTER.CLICK",""","oparms":[{"av":"divResidentincompanyidfiltercontainer_Class","ctrl":"RESIDENTINCOMPANYIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentincompanyid_Visible","ctrl":"vCRESIDENTINCOMPANYID","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTINCOMPANYKVKNUMBERFILTER.CLICK","""{"handler":"E12061","iparms":[{"av":"divResidentincompanykvknumberfiltercontainer_Class","ctrl":"RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTINCOMPANYKVKNUMBERFILTER.CLICK",""","oparms":[{"av":"divResidentincompanykvknumberfiltercontainer_Class","ctrl":"RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentincompanykvknumber_Visible","ctrl":"vCRESIDENTINCOMPANYKVKNUMBER","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTINCOMPANYNAMEFILTER.CLICK","""{"handler":"E13061","iparms":[{"av":"divResidentincompanynamefiltercontainer_Class","ctrl":"RESIDENTINCOMPANYNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTINCOMPANYNAMEFILTER.CLICK",""","oparms":[{"av":"divResidentincompanynamefiltercontainer_Class","ctrl":"RESIDENTINCOMPANYNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentincompanyname_Visible","ctrl":"vCRESIDENTINCOMPANYNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLRESIDENTINCOMPANYPHONEFILTER.CLICK","""{"handler":"E14061","iparms":[{"av":"divResidentincompanyphonefiltercontainer_Class","ctrl":"RESIDENTINCOMPANYPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLRESIDENTINCOMPANYPHONEFILTER.CLICK",""","oparms":[{"av":"divResidentincompanyphonefiltercontainer_Class","ctrl":"RESIDENTINCOMPANYPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCresidentincompanyphone_Visible","ctrl":"vCRESIDENTINCOMPANYPHONE","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E18062","iparms":[{"av":"A50ResidentINCompanyId","fld":"RESIDENTINCOMPANYID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11pResidentINCompanyId","fld":"vPRESIDENTINCOMPANYID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINCompanyId","fld":"vCRESIDENTINCOMPANYID","pic":"ZZZ9"},{"av":"AV7cResidentINCompanyKvkNumber","fld":"vCRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV8cResidentINCompanyName","fld":"vCRESIDENTINCOMPANYNAME"},{"av":"AV9cResidentINCompanyPhone","fld":"vCRESIDENTINCOMPANYPHONE"},{"av":"AV10pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINCompanyId","fld":"vCRESIDENTINCOMPANYID","pic":"ZZZ9"},{"av":"AV7cResidentINCompanyKvkNumber","fld":"vCRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV8cResidentINCompanyName","fld":"vCRESIDENTINCOMPANYNAME"},{"av":"AV9cResidentINCompanyPhone","fld":"vCRESIDENTINCOMPANYPHONE"},{"av":"AV10pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINCompanyId","fld":"vCRESIDENTINCOMPANYID","pic":"ZZZ9"},{"av":"AV7cResidentINCompanyKvkNumber","fld":"vCRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV8cResidentINCompanyName","fld":"vCRESIDENTINCOMPANYNAME"},{"av":"AV9cResidentINCompanyPhone","fld":"vCRESIDENTINCOMPANYPHONE"},{"av":"AV10pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cResidentINCompanyId","fld":"vCRESIDENTINCOMPANYID","pic":"ZZZ9"},{"av":"AV7cResidentINCompanyKvkNumber","fld":"vCRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV8cResidentINCompanyName","fld":"vCRESIDENTINCOMPANYNAME"},{"av":"AV9cResidentINCompanyPhone","fld":"vCRESIDENTINCOMPANYPHONE"},{"av":"AV10pResidentId","fld":"vPRESIDENTID","pic":"ZZZ9"}]}""");
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
         AV7cResidentINCompanyKvkNumber = "";
         AV8cResidentINCompanyName = "";
         AV9cResidentINCompanyPhone = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblresidentincompanyidfilter_Jsonclick = "";
         TempTags = "";
         lblLblresidentincompanykvknumberfilter_Jsonclick = "";
         lblLblresidentincompanynamefilter_Jsonclick = "";
         lblLblresidentincompanyphonefilter_Jsonclick = "";
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
         A51ResidentINCompanyKvkNumber = "";
         A52ResidentINCompanyName = "";
         A54ResidentINCompanyPhone = "";
         lV7cResidentINCompanyKvkNumber = "";
         lV8cResidentINCompanyName = "";
         lV9cResidentINCompanyPhone = "";
         H00062_A31ResidentId = new short[1] ;
         H00062_A54ResidentINCompanyPhone = new string[] {""} ;
         H00062_n54ResidentINCompanyPhone = new bool[] {false} ;
         H00062_A52ResidentINCompanyName = new string[] {""} ;
         H00062_A51ResidentINCompanyKvkNumber = new string[] {""} ;
         H00062_A50ResidentINCompanyId = new short[1] ;
         H00063_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0071__default(),
            new Object[][] {
                new Object[] {
               H00062_A31ResidentId, H00062_A54ResidentINCompanyPhone, H00062_n54ResidentINCompanyPhone, H00062_A52ResidentINCompanyName, H00062_A51ResidentINCompanyKvkNumber, H00062_A50ResidentINCompanyId
               }
               , new Object[] {
               H00063_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10pResidentId ;
      private short AV11pResidentINCompanyId ;
      private short wcpOAV10pResidentId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cResidentINCompanyId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A50ResidentINCompanyId ;
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
      private int nRC_GXsfl_54 ;
      private int subGrid1_Rows ;
      private int nGXsfl_54_idx=1 ;
      private int edtavCresidentincompanyid_Enabled ;
      private int edtavCresidentincompanyid_Visible ;
      private int edtavCresidentincompanykvknumber_Visible ;
      private int edtavCresidentincompanykvknumber_Enabled ;
      private int edtavCresidentincompanyname_Visible ;
      private int edtavCresidentincompanyname_Enabled ;
      private int edtavCresidentincompanyphone_Visible ;
      private int edtavCresidentincompanyphone_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtResidentINCompanyId_Enabled ;
      private int edtResidentINCompanyKvkNumber_Enabled ;
      private int edtResidentINCompanyName_Enabled ;
      private int edtResidentINCompanyPhone_Enabled ;
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
      private string divResidentincompanyidfiltercontainer_Class ;
      private string divResidentincompanykvknumberfiltercontainer_Class ;
      private string divResidentincompanynamefiltercontainer_Class ;
      private string divResidentincompanyphonefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_54_idx="0001" ;
      private string AV9cResidentINCompanyPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divResidentincompanyidfiltercontainer_Internalname ;
      private string lblLblresidentincompanyidfilter_Internalname ;
      private string lblLblresidentincompanyidfilter_Jsonclick ;
      private string edtavCresidentincompanyid_Internalname ;
      private string TempTags ;
      private string edtavCresidentincompanyid_Jsonclick ;
      private string divResidentincompanykvknumberfiltercontainer_Internalname ;
      private string lblLblresidentincompanykvknumberfilter_Internalname ;
      private string lblLblresidentincompanykvknumberfilter_Jsonclick ;
      private string edtavCresidentincompanykvknumber_Internalname ;
      private string edtavCresidentincompanykvknumber_Jsonclick ;
      private string divResidentincompanynamefiltercontainer_Internalname ;
      private string lblLblresidentincompanynamefilter_Internalname ;
      private string lblLblresidentincompanynamefilter_Jsonclick ;
      private string edtavCresidentincompanyname_Internalname ;
      private string edtavCresidentincompanyname_Jsonclick ;
      private string divResidentincompanyphonefiltercontainer_Internalname ;
      private string lblLblresidentincompanyphonefilter_Internalname ;
      private string lblLblresidentincompanyphonefilter_Jsonclick ;
      private string edtavCresidentincompanyphone_Internalname ;
      private string edtavCresidentincompanyphone_Jsonclick ;
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
      private string edtResidentINCompanyId_Internalname ;
      private string edtResidentINCompanyKvkNumber_Internalname ;
      private string edtResidentINCompanyName_Internalname ;
      private string A54ResidentINCompanyPhone ;
      private string edtResidentINCompanyPhone_Internalname ;
      private string edtResidentId_Internalname ;
      private string lV9cResidentINCompanyPhone ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_54_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtResidentINCompanyId_Jsonclick ;
      private string edtResidentINCompanyKvkNumber_Link ;
      private string edtResidentINCompanyKvkNumber_Jsonclick ;
      private string edtResidentINCompanyName_Jsonclick ;
      private string gxphoneLink ;
      private string edtResidentINCompanyPhone_Jsonclick ;
      private string edtResidentId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_54_Refreshing=false ;
      private bool n54ResidentINCompanyPhone ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cResidentINCompanyKvkNumber ;
      private string AV8cResidentINCompanyName ;
      private string AV13Linkselection_GXI ;
      private string A51ResidentINCompanyKvkNumber ;
      private string A52ResidentINCompanyName ;
      private string lV7cResidentINCompanyKvkNumber ;
      private string lV8cResidentINCompanyName ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00062_A31ResidentId ;
      private string[] H00062_A54ResidentINCompanyPhone ;
      private bool[] H00062_n54ResidentINCompanyPhone ;
      private string[] H00062_A52ResidentINCompanyName ;
      private string[] H00062_A51ResidentINCompanyKvkNumber ;
      private short[] H00062_A50ResidentINCompanyId ;
      private long[] H00063_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pResidentINCompanyId ;
   }

   public class gx0071__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00062( IGxContext context ,
                                             string AV7cResidentINCompanyKvkNumber ,
                                             string AV8cResidentINCompanyName ,
                                             string AV9cResidentINCompanyPhone ,
                                             string A51ResidentINCompanyKvkNumber ,
                                             string A52ResidentINCompanyName ,
                                             string A54ResidentINCompanyPhone ,
                                             short AV10pResidentId ,
                                             short AV6cResidentINCompanyId ,
                                             short A31ResidentId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ResidentId, ResidentINCompanyPhone, ResidentINCompanyName, ResidentINCompanyKvkNumber, ResidentINCompanyId";
         sFromString = " FROM ResidentINCompany";
         sOrderString = "";
         AddWhere(sWhereString, "(ResidentId = :AV10pResidentId and ResidentINCompanyId >= :AV6cResidentINCompanyId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cResidentINCompanyKvkNumber)) )
         {
            AddWhere(sWhereString, "(ResidentINCompanyKvkNumber like :lV7cResidentINCompanyKvkNumber)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cResidentINCompanyName)) )
         {
            AddWhere(sWhereString, "(ResidentINCompanyName like :lV8cResidentINCompanyName)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cResidentINCompanyPhone)) )
         {
            AddWhere(sWhereString, "(ResidentINCompanyPhone like :lV9cResidentINCompanyPhone)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY ResidentId, ResidentINCompanyId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00063( IGxContext context ,
                                             string AV7cResidentINCompanyKvkNumber ,
                                             string AV8cResidentINCompanyName ,
                                             string AV9cResidentINCompanyPhone ,
                                             string A51ResidentINCompanyKvkNumber ,
                                             string A52ResidentINCompanyName ,
                                             string A54ResidentINCompanyPhone ,
                                             short AV10pResidentId ,
                                             short AV6cResidentINCompanyId ,
                                             short A31ResidentId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ResidentINCompany";
         AddWhere(sWhereString, "(ResidentId = :AV10pResidentId and ResidentINCompanyId >= :AV6cResidentINCompanyId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cResidentINCompanyKvkNumber)) )
         {
            AddWhere(sWhereString, "(ResidentINCompanyKvkNumber like :lV7cResidentINCompanyKvkNumber)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cResidentINCompanyName)) )
         {
            AddWhere(sWhereString, "(ResidentINCompanyName like :lV8cResidentINCompanyName)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cResidentINCompanyPhone)) )
         {
            AddWhere(sWhereString, "(ResidentINCompanyPhone like :lV9cResidentINCompanyPhone)");
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
                     return conditional_H00062(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H00063(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmH00062;
          prmH00062 = new Object[] {
          new ParDef("AV10pResidentId",GXType.Int16,4,0) ,
          new ParDef("AV6cResidentINCompanyId",GXType.Int16,4,0) ,
          new ParDef("lV7cResidentINCompanyKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("lV8cResidentINCompanyName",GXType.VarChar,40,0) ,
          new ParDef("lV9cResidentINCompanyPhone",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00063;
          prmH00063 = new Object[] {
          new ParDef("AV10pResidentId",GXType.Int16,4,0) ,
          new ParDef("AV6cResidentINCompanyId",GXType.Int16,4,0) ,
          new ParDef("lV7cResidentINCompanyKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("lV8cResidentINCompanyName",GXType.VarChar,40,0) ,
          new ParDef("lV9cResidentINCompanyPhone",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00062", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00062,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00063", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00063,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
