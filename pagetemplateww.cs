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
   public class pagetemplateww : GXDataArea
   {
      public pagetemplateww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pagetemplateww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SelectedPageTemplateId )
      {
         this.AV16SelectedPageTemplateId = aP0_SelectedPageTemplateId;
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SelectedPageTemplateId");
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
               gxfirstwebparm = GetFirstPar( "SelectedPageTemplateId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SelectedPageTemplateId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
               AV16SelectedPageTemplateId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV16SelectedPageTemplateId", StringUtil.LTrimStr( (decimal)(AV16SelectedPageTemplateId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSELECTEDPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16SelectedPageTemplateId), "ZZZ9"), context));
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_21 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_21"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_21_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_21_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_21_idx = GetPar( "sGXsfl_21_idx");
         edtPageTemplateId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtPageTemplateId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageTemplateId_Visible), 5, 0), !bGXsfl_21_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV13FilterFullText = GetPar( "FilterFullText");
         AV27Pgmname = GetPar( "Pgmname");
         edtPageTemplateId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtPageTemplateId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageTemplateId_Visible), 5, 0), !bGXsfl_21_Refreshing);
         AV15IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         AV16SelectedPageTemplateId = (short)(Math.Round(NumberUtil.Val( GetPar( "SelectedPageTemplateId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13FilterFullText, AV27Pgmname, AV15IsAuthorized_Insert, AV16SelectedPageTemplateId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "pagetemplateww_Execute" ;
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
         PA3A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3A2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/TabsPanel/BootstrapTabsPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("pagetemplateww.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV16SelectedPageTemplateId,4,0))}, new string[] {"SelectedPageTemplateId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV15IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV15IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vSELECTEDPAGETEMPLATEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16SelectedPageTemplateId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSELECTEDPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16SelectedPageTemplateId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV13FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_21", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_21), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vDETAILTABLENAME", AV18DetailTableName);
         GxWebStd.gx_boolean_hidden_field( context, "vREFRESHGRID", AV24RefreshGrid);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDETAILWCINFO", AV23DetailWCInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDETAILWCINFO", AV23DetailWCInfo);
         }
         GxWebStd.gx_hidden_field( context, "vLOADDETAILACTION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19LoadDetailAction), 1, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV15IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV15IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vSELECTEDPAGETEMPLATEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16SelectedPageTemplateId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSELECTEDPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16SelectedPageTemplateId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vDETAILTABCAPTION", AV22DetailTabCaption);
         GxWebStd.gx_hidden_field( context, "vDETAILWCLINK", AV20DetailWCLink);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DETAILTABSCOMPONENT_Width", StringUtil.RTrim( Detailtabscomponent_Width));
         GxWebStd.gx_hidden_field( context, "DETAILTABSCOMPONENT_Autowidth", StringUtil.BoolToStr( Detailtabscomponent_Autowidth));
         GxWebStd.gx_hidden_field( context, "DETAILTABSCOMPONENT_Autoheight", StringUtil.BoolToStr( Detailtabscomponent_Autoheight));
         GxWebStd.gx_hidden_field( context, "DETAILTABSCOMPONENT_Autoscroll", StringUtil.BoolToStr( Detailtabscomponent_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DETAILTABSCOMPONENT_Cls", StringUtil.RTrim( Detailtabscomponent_Cls));
         GxWebStd.gx_hidden_field( context, "DETAILTABSCOMPONENT_Excessivetabsbehavior", StringUtil.RTrim( Detailtabscomponent_Excessivetabsbehavior));
         GxWebStd.gx_hidden_field( context, "DETAILTABSCOMPONENT_Designtimetabs", StringUtil.RTrim( Detailtabscomponent_Designtimetabs));
         GxWebStd.gx_hidden_field( context, "PAGETEMPLATEID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageTemplateId_Visible), 5, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE3A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3A2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("pagetemplateww.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV16SelectedPageTemplateId,4,0))}, new string[] {"SelectedPageTemplateId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PageTemplateWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Page Template" ;
      }

      protected void WB3A0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-4 CellLeftSplitScreen", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableleft_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "TableHeaderSplitScreen", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "ButtonColorFilledFullWidth";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(21), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PageTemplateWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellNoPaddingHorizontal", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "col-sm-3 AttributeSearchSplitScreenLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_21_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV13FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "AttributeSearchSplitScreen", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_PageTemplateWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFSSplitScreen", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl21( ) ;
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            nRC_GXsfl_21 = (int)(nGXsfl_21_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-8 CellWCSplitScreen CellWCSplitScreenWithTabs", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_tabs_detailtabscomponent_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDetailtabscomponent.SetProperty("Width", Detailtabscomponent_Width);
            ucDetailtabscomponent.SetProperty("AutoWidth", Detailtabscomponent_Autowidth);
            ucDetailtabscomponent.SetProperty("AutoHeight", Detailtabscomponent_Autoheight);
            ucDetailtabscomponent.SetProperty("AutoScroll", Detailtabscomponent_Autoscroll);
            ucDetailtabscomponent.SetProperty("Cls", Detailtabscomponent_Cls);
            ucDetailtabscomponent.SetProperty("ExcessiveTabsBehavior", Detailtabscomponent_Excessivetabsbehavior);
            ucDetailtabscomponent.SetProperty("DesignTimeTabs", Detailtabscomponent_Designtimetabs);
            ucDetailtabscomponent.Render(context, "dvelop.gxbootstrap.tabspanel", Detailtabscomponent_Internalname, "DETAILTABSCOMPONENTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3A2( )
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
         Form.Meta.addItem("description", " Page Template", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3A0( ) ;
      }

      protected void WS3A2( )
      {
         START3A2( ) ;
         EVT3A2( ) ;
      }

      protected void EVT3A2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.SPLITSCREENWITHTABS_UPDATETAB") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E113A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E123A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              AV26Pagetemplatewwds_1_filterfulltext = AV13FilterFullText;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_21_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
                              SubsflControlProps_212( ) ;
                              A108PageTemplateName = cgiGet( edtPageTemplateName_Internalname);
                              A111PageTemplateDescription = cgiGet( edtPageTemplateDescription_Internalname);
                              A107PageTemplateId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPageTemplateId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E133A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E143A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E153A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV13FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE3A2( )
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

      protected void PA3A2( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_212( ) ;
         while ( nGXsfl_21_idx <= nRC_GXsfl_21 )
         {
            sendrow_212( ) ;
            nGXsfl_21_idx = ((subGrid_Islastpage==1)&&(nGXsfl_21_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
            sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
            SubsflControlProps_212( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV13FilterFullText ,
                                       string AV27Pgmname ,
                                       bool AV15IsAuthorized_Insert ,
                                       short AV16SelectedPageTemplateId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A107PageTemplateId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PAGETEMPLATEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A107PageTemplateId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PAGETEMPLATENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A108PageTemplateName, "")), context));
         GxWebStd.gx_hidden_field( context, "PAGETEMPLATENAME", A108PageTemplateName);
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
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_21_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF3A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV27Pgmname = "PageTemplateWW";
      }

      protected void RF3A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 21;
         /* Execute user event: Refresh */
         E143A2 ();
         nGXsfl_21_idx = (int)(1+GRID_nFirstRecordOnPage);
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         bGXsfl_21_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FSGridAutoUnselectAll"));
         GridContainer.AddObjectProperty("Class", "FSGridAutoUnselectAll");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_212( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV26Pagetemplatewwds_1_filterfulltext ,
                                                 A108PageTemplateName ,
                                                 A111PageTemplateDescription } ,
                                                 new int[]{
                                                 }
            });
            lV26Pagetemplatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV26Pagetemplatewwds_1_filterfulltext), "%", "");
            lV26Pagetemplatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV26Pagetemplatewwds_1_filterfulltext), "%", "");
            /* Using cursor H003A2 */
            pr_default.execute(0, new Object[] {lV26Pagetemplatewwds_1_filterfulltext, lV26Pagetemplatewwds_1_filterfulltext, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_21_idx = (int)(1+GRID_nFirstRecordOnPage);
            sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
            SubsflControlProps_212( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A107PageTemplateId = H003A2_A107PageTemplateId[0];
               A111PageTemplateDescription = H003A2_A111PageTemplateDescription[0];
               A108PageTemplateName = H003A2_A108PageTemplateName[0];
               /* Execute user event: Grid.Load */
               E153A2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 21;
            WB3A0( ) ;
         }
         bGXsfl_21_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3A2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PAGETEMPLATEID"+"_"+sGXsfl_21_idx, GetSecureSignedToken( sGXsfl_21_idx, context.localUtil.Format( (decimal)(A107PageTemplateId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PAGETEMPLATENAME"+"_"+sGXsfl_21_idx, GetSecureSignedToken( sGXsfl_21_idx, StringUtil.RTrim( context.localUtil.Format( A108PageTemplateName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV15IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV15IsAuthorized_Insert, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV26Pagetemplatewwds_1_filterfulltext = AV13FilterFullText;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV26Pagetemplatewwds_1_filterfulltext ,
                                              A108PageTemplateName ,
                                              A111PageTemplateDescription } ,
                                              new int[]{
                                              }
         });
         lV26Pagetemplatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV26Pagetemplatewwds_1_filterfulltext), "%", "");
         lV26Pagetemplatewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV26Pagetemplatewwds_1_filterfulltext), "%", "");
         /* Using cursor H003A3 */
         pr_default.execute(1, new Object[] {lV26Pagetemplatewwds_1_filterfulltext, lV26Pagetemplatewwds_1_filterfulltext});
         GRID_nRecordCount = H003A3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV26Pagetemplatewwds_1_filterfulltext = AV13FilterFullText;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13FilterFullText, AV27Pgmname, AV15IsAuthorized_Insert, AV16SelectedPageTemplateId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV26Pagetemplatewwds_1_filterfulltext = AV13FilterFullText;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         if ( GRID_nEOF == 1 )
         {
            GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13FilterFullText, AV27Pgmname, AV15IsAuthorized_Insert, AV16SelectedPageTemplateId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV26Pagetemplatewwds_1_filterfulltext = AV13FilterFullText;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13FilterFullText, AV27Pgmname, AV15IsAuthorized_Insert, AV16SelectedPageTemplateId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV26Pagetemplatewwds_1_filterfulltext = AV13FilterFullText;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13FilterFullText, AV27Pgmname, AV15IsAuthorized_Insert, AV16SelectedPageTemplateId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV26Pagetemplatewwds_1_filterfulltext = AV13FilterFullText;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13FilterFullText, AV27Pgmname, AV15IsAuthorized_Insert, AV16SelectedPageTemplateId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV27Pgmname = "PageTemplateWW";
         edtPageTemplateName_Enabled = 0;
         edtPageTemplateDescription_Enabled = 0;
         edtPageTemplateId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_21 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_21"), ".", ","), 18, MidpointRounding.ToEven));
            AV22DetailTabCaption = cgiGet( "vDETAILTABCAPTION");
            AV20DetailWCLink = cgiGet( "vDETAILWCLINK");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Detailtabscomponent_Width = cgiGet( "DETAILTABSCOMPONENT_Width");
            Detailtabscomponent_Autowidth = StringUtil.StrToBool( cgiGet( "DETAILTABSCOMPONENT_Autowidth"));
            Detailtabscomponent_Autoheight = StringUtil.StrToBool( cgiGet( "DETAILTABSCOMPONENT_Autoheight"));
            Detailtabscomponent_Autoscroll = StringUtil.StrToBool( cgiGet( "DETAILTABSCOMPONENT_Autoscroll"));
            Detailtabscomponent_Cls = cgiGet( "DETAILTABSCOMPONENT_Cls");
            Detailtabscomponent_Excessivetabsbehavior = cgiGet( "DETAILTABSCOMPONENT_Excessivetabsbehavior");
            Detailtabscomponent_Designtimetabs = cgiGet( "DETAILTABSCOMPONENT_Designtimetabs");
            /* Read variables values. */
            AV13FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV13FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E133A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E133A2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtPageTemplateId_Visible = 0;
         AssignProp("", false, edtPageTemplateId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageTemplateId_Visible), 5, 0), !bGXsfl_21_Refreshing);
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = " Page Template";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! (0==AV16SelectedPageTemplateId) )
         {
            /* Using cursor H003A4 */
            pr_default.execute(2, new Object[] {AV16SelectedPageTemplateId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A107PageTemplateId = H003A4_A107PageTemplateId[0];
               A108PageTemplateName = H003A4_A108PageTemplateName[0];
               AV22DetailTabCaption = A108PageTemplateName;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV20DetailWCLink = formatLink("pagetemplateview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV16SelectedPageTemplateId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PageTemplateId","TabCode"}) ;
            this.executeUsercontrolMethod("", false, "DETAILTABSCOMPONENTContainer", "AddIFrameTab", "", new Object[] {(string)AV20DetailWCLink,(string)AV22DetailTabCaption});
         }
      }

      protected void E143A2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26Pagetemplatewwds_1_filterfulltext = AV13FilterFullText;
         /*  Sending Event outputs  */
      }

      private void E153A2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 21;
         }
         sendrow_212( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_21_Refreshing )
         {
            DoAjaxLoad(21, GridRow);
         }
      }

      protected void E113A2( )
      {
         /* General\GlobalEvents_Splitscreenwithtabs_updatetab Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18DetailTableName, "pagetemplate") == 0 )
         {
            AV20DetailWCLink = AV23DetailWCInfo.gxTpr_Link;
            if ( ( AV19LoadDetailAction == 3 ) || ( AV19LoadDetailAction == 6 ) )
            {
               AV21DetailWCLink2 = formatLink("pagetemplate.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","PageTemplateId"}) ;
               if ( AV19LoadDetailAction == 3 )
               {
                  AV22DetailTabCaption = AV23DetailWCInfo.gxTpr_Title;
                  this.executeUsercontrolMethod("", false, "DETAILTABSCOMPONENTContainer", "ReplaceIFrameTab", "", new Object[] {(string)AV21DetailWCLink2,(string)AV20DetailWCLink,(string)AV22DetailTabCaption});
               }
               else
               {
                  this.executeUsercontrolMethod("", false, "DETAILTABSCOMPONENTContainer", "CloseIFrameTab", "", new Object[] {(string)AV21DetailWCLink2});
               }
            }
            else if ( AV19LoadDetailAction == 5 )
            {
               AV22DetailTabCaption = AV23DetailWCInfo.gxTpr_Title;
               this.executeUsercontrolMethod("", false, "DETAILTABSCOMPONENTContainer", "UpdateIFrameTabCaption", "", new Object[] {(string)AV20DetailWCLink,(string)AV22DetailTabCaption});
            }
            else if ( AV19LoadDetailAction == 4 )
            {
               this.executeUsercontrolMethod("", false, "DETAILTABSCOMPONENTContainer", "CloseIFrameTab", "", new Object[] {(string)AV20DetailWCLink});
            }
            if ( AV24RefreshGrid )
            {
               GRID_nFirstRecordOnPage = 0;
               GRID_nCurrentRecord = 0;
               GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_21_idx;
               GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
               gxgrGrid_refresh( subGrid_Rows, AV13FilterFullText, AV27Pgmname, AV15IsAuthorized_Insert, AV16SelectedPageTemplateId) ;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E123A2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV15IsAuthorized_Insert )
         {
            AV20DetailWCLink = formatLink("pagetemplate.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","PageTemplateId"}) ;
            this.executeUsercontrolMethod("", false, "DETAILTABSCOMPONENTContainer", "AddIFrameTab", "", new Object[] {(string)AV20DetailWCLink,(string)"<New>"});
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV15IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "pagetemplate_Insert", out  GXt_boolean1) ;
         AV15IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV15IsAuthorized_Insert", AV15IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV15IsAuthorized_Insert, context));
         if ( ! ( AV15IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV27Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV27Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV14Session.Get(AV27Pgmname+"GridState"), null, "", "");
         }
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV28GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV14Session.Get(AV27Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)),  0,  AV13FilterFullText,  AV13FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV27Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV27Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "PageTemplate";
         AV14Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16SelectedPageTemplateId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV16SelectedPageTemplateId", StringUtil.LTrimStr( (decimal)(AV16SelectedPageTemplateId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSELECTEDPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16SelectedPageTemplateId), "ZZZ9"), context));
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
         PA3A2( ) ;
         WS3A2( ) ;
         WE3A2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126315191", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("pagetemplateww.js", "?20249126315191", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/TabsPanel/BootstrapTabsPanelRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_212( )
      {
         edtPageTemplateName_Internalname = "PAGETEMPLATENAME_"+sGXsfl_21_idx;
         edtPageTemplateDescription_Internalname = "PAGETEMPLATEDESCRIPTION_"+sGXsfl_21_idx;
         edtPageTemplateId_Internalname = "PAGETEMPLATEID_"+sGXsfl_21_idx;
      }

      protected void SubsflControlProps_fel_212( )
      {
         edtPageTemplateName_Internalname = "PAGETEMPLATENAME_"+sGXsfl_21_fel_idx;
         edtPageTemplateDescription_Internalname = "PAGETEMPLATEDESCRIPTION_"+sGXsfl_21_fel_idx;
         edtPageTemplateId_Internalname = "PAGETEMPLATEID_"+sGXsfl_21_fel_idx;
      }

      protected void sendrow_212( )
      {
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         WB3A0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_21_idx - GRID_nFirstRecordOnPage <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_21_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_21_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFsgridtablerow_Internalname+"_"+sGXsfl_21_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"TableSplitMasterListRow CellSplitScreenFS",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtPageTemplateName_Internalname,(string)"Page Template Name",(string)"col-sm-3 AttributeTitleSplitScreenLabel",(short)0,(bool)true,(string)""});
            /* Single line edit */
            ROClassString = "AttributeTitleSplitScreen";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageTemplateName_Internalname,(string)A108PageTemplateName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageTemplateName_Jsonclick,(short)0,(string)"AttributeTitleSplitScreen",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtPageTemplateDescription_Internalname,(string)"Page Template Description",(string)"col-sm-3 AttributeSubtitleSplitScreenLabel",(short)0,(bool)true,(string)""});
            /* Multiple line edit */
            ClassString = "AttributeSubtitleSplitScreen";
            StyleString = "";
            ClassString = "AttributeSubtitleSplitScreen";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtPageTemplateDescription_Internalname,(string)A111PageTemplateDescription,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_21_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtPageTemplateId_Internalname,(string)"Page Template Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageTemplateId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A107PageTemplateId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A107PageTemplateId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageTemplateId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtPageTemplateId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("row");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("table");
            }
            /* End of table */
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            send_integrity_lvl_hashes3A2( ) ;
            /* End of Columns property logic. */
            GridContainer.AddRow(GridRow);
            nGXsfl_21_idx = ((subGrid_Islastpage==1)&&(nGXsfl_21_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
            sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
            SubsflControlProps_212( ) ;
         }
         /* End function sendrow_212 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl21( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"21\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FSGridAutoUnselectAll", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FSGridAutoUnselectAll"));
            GridContainer.AddObjectProperty("Class", "FSGridAutoUnselectAll");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A108PageTemplateName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A111PageTemplateDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A107PageTemplateId), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageTemplateId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTableheader_Internalname = "TABLEHEADER";
         edtPageTemplateName_Internalname = "PAGETEMPLATENAME";
         edtPageTemplateDescription_Internalname = "PAGETEMPLATEDESCRIPTION";
         edtPageTemplateId_Internalname = "PAGETEMPLATEID";
         tblUnnamedtablecontentfsgrid_Internalname = "UNNAMEDTABLECONTENTFSGRID";
         divFsgridtablerow_Internalname = "FSGRIDTABLEROW";
         divTableleft_Internalname = "TABLELEFT";
         Detailtabscomponent_Internalname = "DETAILTABSCOMPONENT";
         divHtml_tabs_detailtabscomponent_Internalname = "HTML_TABS_DETAILTABSCOMPONENT";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         edtPageTemplateId_Jsonclick = "";
         edtPageTemplateName_Jsonclick = "";
         subGrid_Class = "FSGridAutoUnselectAll";
         edtPageTemplateId_Enabled = 0;
         edtPageTemplateDescription_Enabled = 0;
         edtPageTemplateName_Enabled = 0;
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Detailtabscomponent_Designtimetabs = "[]";
         Detailtabscomponent_Excessivetabsbehavior = "Slider";
         Detailtabscomponent_Cls = "";
         Detailtabscomponent_Autoscroll = Convert.ToBoolean( -1);
         Detailtabscomponent_Autoheight = Convert.ToBoolean( -1);
         Detailtabscomponent_Autowidth = Convert.ToBoolean( 0);
         Detailtabscomponent_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Page Template";
         edtPageTemplateId_Visible = 1;
         subGrid_Rows = 50;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtPageTemplateId_Visible","ctrl":"PAGETEMPLATEID","prop":"Visible"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV16SelectedPageTemplateId","fld":"vSELECTEDPAGETEMPLATEID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E153A2","iparms":[]}""");
         setEventMetadata("GLOBALEVENTS.SPLITSCREENWITHTABS_UPDATETAB","""{"handler":"E113A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true},{"av":"edtPageTemplateId_Visible","ctrl":"PAGETEMPLATEID","prop":"Visible"},{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV16SelectedPageTemplateId","fld":"vSELECTEDPAGETEMPLATEID","pic":"ZZZ9","hsh":true},{"av":"AV18DetailTableName","fld":"vDETAILTABLENAME"},{"av":"AV24RefreshGrid","fld":"vREFRESHGRID"},{"av":"AV23DetailWCInfo","fld":"vDETAILWCINFO"},{"av":"AV19LoadDetailAction","fld":"vLOADDETAILACTION","pic":"9"}]""");
         setEventMetadata("GLOBALEVENTS.SPLITSCREENWITHTABS_UPDATETAB",""","oparms":[{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E123A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true},{"av":"edtPageTemplateId_Visible","ctrl":"PAGETEMPLATEID","prop":"Visible"},{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV16SelectedPageTemplateId","fld":"vSELECTEDPAGETEMPLATEID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtPageTemplateId_Visible","ctrl":"PAGETEMPLATEID","prop":"Visible"},{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV16SelectedPageTemplateId","fld":"vSELECTEDPAGETEMPLATEID","pic":"ZZZ9","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtPageTemplateId_Visible","ctrl":"PAGETEMPLATEID","prop":"Visible"},{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV16SelectedPageTemplateId","fld":"vSELECTEDPAGETEMPLATEID","pic":"ZZZ9","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtPageTemplateId_Visible","ctrl":"PAGETEMPLATEID","prop":"Visible"},{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV16SelectedPageTemplateId","fld":"vSELECTEDPAGETEMPLATEID","pic":"ZZZ9","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtPageTemplateId_Visible","ctrl":"PAGETEMPLATEID","prop":"Visible"},{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV16SelectedPageTemplateId","fld":"vSELECTEDPAGETEMPLATEID","pic":"ZZZ9","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"AV15IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Pagetemplateid","iparms":[]}""");
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
         AV13FilterFullText = "";
         AV27Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18DetailTableName = "";
         AV23DetailWCInfo = new GeneXus.Programs.wwpbaseobjects.SdtSplitScreenDetailInfo(context);
         AV22DetailTabCaption = "";
         AV20DetailWCLink = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDetailtabscomponent = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26Pagetemplatewwds_1_filterfulltext = "";
         A108PageTemplateName = "";
         A111PageTemplateDescription = "";
         GXCCtl = "";
         lV26Pagetemplatewwds_1_filterfulltext = "";
         H003A2_A107PageTemplateId = new short[1] ;
         H003A2_A111PageTemplateDescription = new string[] {""} ;
         H003A2_A108PageTemplateName = new string[] {""} ;
         H003A3_AGRID_nRecordCount = new long[1] ;
         H003A4_A107PageTemplateId = new short[1] ;
         H003A4_A108PageTemplateName = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV21DetailWCLink2 = "";
         AV14Session = context.GetSession();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pagetemplateww__default(),
            new Object[][] {
                new Object[] {
               H003A2_A107PageTemplateId, H003A2_A111PageTemplateDescription, H003A2_A108PageTemplateName
               }
               , new Object[] {
               H003A3_AGRID_nRecordCount
               }
               , new Object[] {
               H003A4_A107PageTemplateId, H003A4_A108PageTemplateName
               }
            }
         );
         AV27Pgmname = "PageTemplateWW";
         /* GeneXus formulas. */
         AV27Pgmname = "PageTemplateWW";
      }

      private short AV16SelectedPageTemplateId ;
      private short wcpOAV16SelectedPageTemplateId ;
      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short AV19LoadDetailAction ;
      private short wbEnd ;
      private short wbStart ;
      private short A107PageTemplateId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtPageTemplateId_Visible ;
      private int nRC_GXsfl_21 ;
      private int subGrid_Rows ;
      private int nGXsfl_21_idx=1 ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtPageTemplateName_Enabled ;
      private int edtPageTemplateDescription_Enabled ;
      private int edtPageTemplateId_Enabled ;
      private int AV28GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_21_idx="0001" ;
      private string edtPageTemplateId_Internalname ;
      private string AV27Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Detailtabscomponent_Width ;
      private string Detailtabscomponent_Cls ;
      private string Detailtabscomponent_Excessivetabsbehavior ;
      private string Detailtabscomponent_Designtimetabs ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableleft_Internalname ;
      private string divTableheader_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_tabs_detailtabscomponent_Internalname ;
      private string Detailtabscomponent_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtPageTemplateName_Internalname ;
      private string edtPageTemplateDescription_Internalname ;
      private string GXCCtl ;
      private string sGXsfl_21_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divFsgridtablerow_Internalname ;
      private string ROClassString ;
      private string edtPageTemplateName_Jsonclick ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string edtPageTemplateId_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_21_Refreshing=false ;
      private bool AV15IsAuthorized_Insert ;
      private bool AV24RefreshGrid ;
      private bool Detailtabscomponent_Autowidth ;
      private bool Detailtabscomponent_Autoheight ;
      private bool Detailtabscomponent_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV13FilterFullText ;
      private string AV18DetailTableName ;
      private string AV22DetailTabCaption ;
      private string AV20DetailWCLink ;
      private string AV26Pagetemplatewwds_1_filterfulltext ;
      private string A108PageTemplateName ;
      private string A111PageTemplateDescription ;
      private string lV26Pagetemplatewwds_1_filterfulltext ;
      private string AV21DetailWCLink2 ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDetailtabscomponent ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtSplitScreenDetailInfo AV23DetailWCInfo ;
      private IDataStoreProvider pr_default ;
      private short[] H003A2_A107PageTemplateId ;
      private string[] H003A2_A111PageTemplateDescription ;
      private string[] H003A2_A108PageTemplateName ;
      private long[] H003A3_AGRID_nRecordCount ;
      private short[] H003A4_A107PageTemplateId ;
      private string[] H003A4_A108PageTemplateName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class pagetemplateww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003A2( IGxContext context ,
                                             string AV26Pagetemplatewwds_1_filterfulltext ,
                                             string A108PageTemplateName ,
                                             string A111PageTemplateDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " PageTemplateId, PageTemplateDescription, PageTemplateName";
         sFromString = " FROM PageTemplate";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26Pagetemplatewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PageTemplateName like '%' || :lV26Pagetemplatewwds_1_filterfulltext) or ( PageTemplateDescription like '%' || :lV26Pagetemplatewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         sOrderString += " ORDER BY PageTemplateId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H003A3( IGxContext context ,
                                             string AV26Pagetemplatewwds_1_filterfulltext ,
                                             string A108PageTemplateName ,
                                             string A111PageTemplateDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[2];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM PageTemplate";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26Pagetemplatewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PageTemplateName like '%' || :lV26Pagetemplatewwds_1_filterfulltext) or ( PageTemplateDescription like '%' || :lV26Pagetemplatewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
               case 1 :
                     return conditional_H003A3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003A4;
          prmH003A4 = new Object[] {
          new ParDef("AV16SelectedPageTemplateId",GXType.Int16,4,0)
          };
          Object[] prmH003A2;
          prmH003A2 = new Object[] {
          new ParDef("lV26Pagetemplatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV26Pagetemplatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003A3;
          prmH003A3 = new Object[] {
          new ParDef("lV26Pagetemplatewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV26Pagetemplatewwds_1_filterfulltext",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A2,51, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003A4", "SELECT PageTemplateId, PageTemplateName FROM PageTemplate WHERE PageTemplateId = :AV16SelectedPageTemplateId ORDER BY PageTemplateId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
