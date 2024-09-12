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
   public class gx0042 : GXDataArea
   {
      public gx0042( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0042( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pCustomerId ,
                           short aP1_pCustomerLocationId ,
                           out short aP2_pCustomerLocationReceptionistId )
      {
         this.AV11pCustomerId = aP0_pCustomerId;
         this.AV12pCustomerLocationId = aP1_pCustomerLocationId;
         this.AV13pCustomerLocationReceptionistId = 0 ;
         ExecuteImpl();
         aP2_pCustomerLocationReceptionistId=this.AV13pCustomerLocationReceptionistId;
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
               AV11pCustomerId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pCustomerId", StringUtil.LTrimStr( (decimal)(AV11pCustomerId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pCustomerLocationId = (short)(Math.Round(NumberUtil.Val( GetPar( "pCustomerLocationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12pCustomerLocationId", StringUtil.LTrimStr( (decimal)(AV12pCustomerLocationId), 4, 0));
                  AV13pCustomerLocationReceptionistId = (short)(Math.Round(NumberUtil.Val( GetPar( "pCustomerLocationReceptionistId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pCustomerLocationReceptionistId", StringUtil.LTrimStr( (decimal)(AV13pCustomerLocationReceptionistId), 4, 0));
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
         AV6cCustomerLocationReceptionistId = (short)(Math.Round(NumberUtil.Val( GetPar( "cCustomerLocationReceptionistId"), "."), 18, MidpointRounding.ToEven));
         AV7cCustomerLocationReceptionistGivenName = GetPar( "cCustomerLocationReceptionistGivenName");
         AV8cCustomerLocationReceptionistLastName = GetPar( "cCustomerLocationReceptionistLastName");
         AV9cCustomerLocationReceptionistInitials = GetPar( "cCustomerLocationReceptionistInitials");
         AV10cCustomerLocationReceptionistPhone = GetPar( "cCustomerLocationReceptionistPhone");
         AV11pCustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "pCustomerId"), "."), 18, MidpointRounding.ToEven));
         AV12pCustomerLocationId = (short)(Math.Round(NumberUtil.Val( GetPar( "pCustomerLocationId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerLocationReceptionistId, AV7cCustomerLocationReceptionistGivenName, AV8cCustomerLocationReceptionistLastName, AV9cCustomerLocationReceptionistInitials, AV10cCustomerLocationReceptionistPhone, AV11pCustomerId, AV12pCustomerLocationId) ;
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
            return "gx0042_Execute" ;
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
         PA0H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0H2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0042.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pCustomerId,4,0)),UrlEncode(StringUtil.LTrimStr(AV12pCustomerLocationId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pCustomerLocationReceptionistId,4,0))}, new string[] {"pCustomerId","pCustomerLocationId","pCustomerLocationReceptionistId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERLOCATIONRECEPTIONISTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCustomerLocationReceptionistId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME", AV7cCustomerLocationReceptionistGivenName);
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME", AV8cCustomerLocationReceptionistLastName);
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERLOCATIONRECEPTIONISTINITIALS", StringUtil.RTrim( AV9cCustomerLocationReceptionistInitials));
         GxWebStd.gx_hidden_field( context, "GXH_vCCUSTOMERLOCATIONRECEPTIONISTPHONE", StringUtil.RTrim( AV10cCustomerLocationReceptionistPhone));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pCustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPCUSTOMERLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pCustomerLocationId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPCUSTOMERLOCATIONRECEPTIONISTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pCustomerLocationReceptionistId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTIDFILTERCONTAINER_Class", StringUtil.RTrim( divCustomerlocationreceptionistidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTGIVENNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divCustomerlocationreceptionistgivennamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTLASTNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divCustomerlocationreceptionistlastnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTINITIALSFILTERCONTAINER_Class", StringUtil.RTrim( divCustomerlocationreceptionistinitialsfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTPHONEFILTERCONTAINER_Class", StringUtil.RTrim( divCustomerlocationreceptionistphonefiltercontainer_Class));
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
            WE0H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0H2( ) ;
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
         return formatLink("gx0042.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pCustomerId,4,0)),UrlEncode(StringUtil.LTrimStr(AV12pCustomerLocationId,4,0)),UrlEncode(StringUtil.LTrimStr(AV13pCustomerLocationReceptionistId,4,0))}, new string[] {"pCustomerId","pCustomerLocationId","pCustomerLocationReceptionistId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0042" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Receptionist" ;
      }

      protected void WB0H0( )
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
            GxWebStd.gx_div_start( context, divCustomerlocationreceptionistidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomerlocationreceptionistidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomerlocationreceptionistidfilter_Internalname, "Customer Location Receptionist Id", "", "", lblLblcustomerlocationreceptionistidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0042.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomerlocationreceptionistid_Internalname, "Customer Location Receptionist Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomerlocationreceptionistid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cCustomerLocationReceptionistId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCcustomerlocationreceptionistid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cCustomerLocationReceptionistId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cCustomerLocationReceptionistId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomerlocationreceptionistid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomerlocationreceptionistid_Visible, edtavCcustomerlocationreceptionistid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0042.htm");
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
            GxWebStd.gx_div_start( context, divCustomerlocationreceptionistgivennamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomerlocationreceptionistgivennamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomerlocationreceptionistgivennamefilter_Internalname, "Customer Location Receptionist Given Name", "", "", lblLblcustomerlocationreceptionistgivennamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0042.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomerlocationreceptionistgivenname_Internalname, "Customer Location Receptionist Given Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomerlocationreceptionistgivenname_Internalname, AV7cCustomerLocationReceptionistGivenName, StringUtil.RTrim( context.localUtil.Format( AV7cCustomerLocationReceptionistGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomerlocationreceptionistgivenname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomerlocationreceptionistgivenname_Visible, edtavCcustomerlocationreceptionistgivenname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0042.htm");
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
            GxWebStd.gx_div_start( context, divCustomerlocationreceptionistlastnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomerlocationreceptionistlastnamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomerlocationreceptionistlastnamefilter_Internalname, "Customer Location Receptionist Last Name", "", "", lblLblcustomerlocationreceptionistlastnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0042.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomerlocationreceptionistlastname_Internalname, "Customer Location Receptionist Last Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomerlocationreceptionistlastname_Internalname, AV8cCustomerLocationReceptionistLastName, StringUtil.RTrim( context.localUtil.Format( AV8cCustomerLocationReceptionistLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomerlocationreceptionistlastname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomerlocationreceptionistlastname_Visible, edtavCcustomerlocationreceptionistlastname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0042.htm");
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
            GxWebStd.gx_div_start( context, divCustomerlocationreceptionistinitialsfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomerlocationreceptionistinitialsfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomerlocationreceptionistinitialsfilter_Internalname, "Customer Location Receptionist Initials", "", "", lblLblcustomerlocationreceptionistinitialsfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0042.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomerlocationreceptionistinitials_Internalname, "Customer Location Receptionist Initials", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomerlocationreceptionistinitials_Internalname, StringUtil.RTrim( AV9cCustomerLocationReceptionistInitials), StringUtil.RTrim( context.localUtil.Format( AV9cCustomerLocationReceptionistInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomerlocationreceptionistinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomerlocationreceptionistinitials_Visible, edtavCcustomerlocationreceptionistinitials_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0042.htm");
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
            GxWebStd.gx_div_start( context, divCustomerlocationreceptionistphonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCustomerlocationreceptionistphonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcustomerlocationreceptionistphonefilter_Internalname, "Customer Location Receptionist Phone", "", "", lblLblcustomerlocationreceptionistphonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0042.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcustomerlocationreceptionistphone_Internalname, "Customer Location Receptionist Phone", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcustomerlocationreceptionistphone_Internalname, StringUtil.RTrim( AV10cCustomerLocationReceptionistPhone), StringUtil.RTrim( context.localUtil.Format( AV10cCustomerLocationReceptionistPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcustomerlocationreceptionistphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcustomerlocationreceptionistphone_Visible, edtavCcustomerlocationreceptionistphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0042.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e160h1_client"+"'", TempTags, "", 2, "HLP_Gx0042.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0042.htm");
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

      protected void START0H2( )
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
         Form.Meta.addItem("description", "Selection List Receptionist", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0H0( ) ;
      }

      protected void WS0H2( )
      {
         START0H2( ) ;
         EVT0H2( ) ;
      }

      protected void EVT0H2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A23CustomerLocationReceptionistId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerLocationReceptionistId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A24CustomerLocationReceptionistGi = cgiGet( edtCustomerLocationReceptionistGi_Internalname);
                              A25CustomerLocationReceptionistLa = cgiGet( edtCustomerLocationReceptionistLa_Internalname);
                              A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A18CustomerLocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerLocationId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E170H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E180H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccustomerlocationreceptionistid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTID"), ".", ",") != Convert.ToDecimal( AV6cCustomerLocationReceptionistId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomerlocationreceptionistgivenname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"), AV7cCustomerLocationReceptionistGivenName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomerlocationreceptionistlastname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME"), AV8cCustomerLocationReceptionistLastName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomerlocationreceptionistinitials Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTINITIALS"), AV9cCustomerLocationReceptionistInitials) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccustomerlocationreceptionistphone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTPHONE"), AV10cCustomerLocationReceptionistPhone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E190H2 ();
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

      protected void WE0H2( )
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

      protected void PA0H2( )
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
                                        short AV6cCustomerLocationReceptionistId ,
                                        string AV7cCustomerLocationReceptionistGivenName ,
                                        string AV8cCustomerLocationReceptionistLastName ,
                                        string AV9cCustomerLocationReceptionistInitials ,
                                        string AV10cCustomerLocationReceptionistPhone ,
                                        short AV11pCustomerId ,
                                        short AV12pCustomerLocationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CUSTOMERLOCATIONRECEPTIONISTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A23CustomerLocationReceptionistId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONRECEPTIONISTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23CustomerLocationReceptionistId), 4, 0, ".", "")));
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
         RF0H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0H2( )
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
                                                 AV7cCustomerLocationReceptionistGivenName ,
                                                 AV8cCustomerLocationReceptionistLastName ,
                                                 AV9cCustomerLocationReceptionistInitials ,
                                                 AV10cCustomerLocationReceptionistPhone ,
                                                 A24CustomerLocationReceptionistGi ,
                                                 A25CustomerLocationReceptionistLa ,
                                                 A26CustomerLocationReceptionistIn ,
                                                 A29CustomerLocationReceptionistPh ,
                                                 AV11pCustomerId ,
                                                 AV12pCustomerLocationId ,
                                                 AV6cCustomerLocationReceptionistId ,
                                                 A1CustomerId ,
                                                 A18CustomerLocationId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cCustomerLocationReceptionistGivenName = StringUtil.Concat( StringUtil.RTrim( AV7cCustomerLocationReceptionistGivenName), "%", "");
            lV8cCustomerLocationReceptionistLastName = StringUtil.Concat( StringUtil.RTrim( AV8cCustomerLocationReceptionistLastName), "%", "");
            lV9cCustomerLocationReceptionistInitials = StringUtil.PadR( StringUtil.RTrim( AV9cCustomerLocationReceptionistInitials), 20, "%");
            lV10cCustomerLocationReceptionistPhone = StringUtil.PadR( StringUtil.RTrim( AV10cCustomerLocationReceptionistPhone), 20, "%");
            /* Using cursor H000H2 */
            pr_default.execute(0, new Object[] {AV11pCustomerId, AV12pCustomerLocationId, AV6cCustomerLocationReceptionistId, lV7cCustomerLocationReceptionistGivenName, lV8cCustomerLocationReceptionistLastName, lV9cCustomerLocationReceptionistInitials, lV10cCustomerLocationReceptionistPhone, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A29CustomerLocationReceptionistPh = H000H2_A29CustomerLocationReceptionistPh[0];
               A26CustomerLocationReceptionistIn = H000H2_A26CustomerLocationReceptionistIn[0];
               n26CustomerLocationReceptionistIn = H000H2_n26CustomerLocationReceptionistIn[0];
               A18CustomerLocationId = H000H2_A18CustomerLocationId[0];
               A1CustomerId = H000H2_A1CustomerId[0];
               A25CustomerLocationReceptionistLa = H000H2_A25CustomerLocationReceptionistLa[0];
               A24CustomerLocationReceptionistGi = H000H2_A24CustomerLocationReceptionistGi[0];
               A23CustomerLocationReceptionistId = H000H2_A23CustomerLocationReceptionistId[0];
               /* Execute user event: Load */
               E180H2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB0H0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0H2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CUSTOMERLOCATIONRECEPTIONISTID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A23CustomerLocationReceptionistId), "ZZZ9"), context));
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
                                              AV7cCustomerLocationReceptionistGivenName ,
                                              AV8cCustomerLocationReceptionistLastName ,
                                              AV9cCustomerLocationReceptionistInitials ,
                                              AV10cCustomerLocationReceptionistPhone ,
                                              A24CustomerLocationReceptionistGi ,
                                              A25CustomerLocationReceptionistLa ,
                                              A26CustomerLocationReceptionistIn ,
                                              A29CustomerLocationReceptionistPh ,
                                              AV11pCustomerId ,
                                              AV12pCustomerLocationId ,
                                              AV6cCustomerLocationReceptionistId ,
                                              A1CustomerId ,
                                              A18CustomerLocationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cCustomerLocationReceptionistGivenName = StringUtil.Concat( StringUtil.RTrim( AV7cCustomerLocationReceptionistGivenName), "%", "");
         lV8cCustomerLocationReceptionistLastName = StringUtil.Concat( StringUtil.RTrim( AV8cCustomerLocationReceptionistLastName), "%", "");
         lV9cCustomerLocationReceptionistInitials = StringUtil.PadR( StringUtil.RTrim( AV9cCustomerLocationReceptionistInitials), 20, "%");
         lV10cCustomerLocationReceptionistPhone = StringUtil.PadR( StringUtil.RTrim( AV10cCustomerLocationReceptionistPhone), 20, "%");
         /* Using cursor H000H3 */
         pr_default.execute(1, new Object[] {AV11pCustomerId, AV12pCustomerLocationId, AV6cCustomerLocationReceptionistId, lV7cCustomerLocationReceptionistGivenName, lV8cCustomerLocationReceptionistLastName, lV9cCustomerLocationReceptionistInitials, lV10cCustomerLocationReceptionistPhone});
         GRID1_nRecordCount = H000H3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerLocationReceptionistId, AV7cCustomerLocationReceptionistGivenName, AV8cCustomerLocationReceptionistLastName, AV9cCustomerLocationReceptionistInitials, AV10cCustomerLocationReceptionistPhone, AV11pCustomerId, AV12pCustomerLocationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerLocationReceptionistId, AV7cCustomerLocationReceptionistGivenName, AV8cCustomerLocationReceptionistLastName, AV9cCustomerLocationReceptionistInitials, AV10cCustomerLocationReceptionistPhone, AV11pCustomerId, AV12pCustomerLocationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerLocationReceptionistId, AV7cCustomerLocationReceptionistGivenName, AV8cCustomerLocationReceptionistLastName, AV9cCustomerLocationReceptionistInitials, AV10cCustomerLocationReceptionistPhone, AV11pCustomerId, AV12pCustomerLocationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerLocationReceptionistId, AV7cCustomerLocationReceptionistGivenName, AV8cCustomerLocationReceptionistLastName, AV9cCustomerLocationReceptionistInitials, AV10cCustomerLocationReceptionistPhone, AV11pCustomerId, AV12pCustomerLocationId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCustomerLocationReceptionistId, AV7cCustomerLocationReceptionistGivenName, AV8cCustomerLocationReceptionistLastName, AV9cCustomerLocationReceptionistInitials, AV10cCustomerLocationReceptionistPhone, AV11pCustomerId, AV12pCustomerLocationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtCustomerLocationReceptionistId_Enabled = 0;
         edtCustomerLocationReceptionistGi_Enabled = 0;
         edtCustomerLocationReceptionistLa_Enabled = 0;
         edtCustomerId_Enabled = 0;
         edtCustomerLocationId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E170H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcustomerlocationreceptionistid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcustomerlocationreceptionistid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCUSTOMERLOCATIONRECEPTIONISTID");
               GX_FocusControl = edtavCcustomerlocationreceptionistid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCustomerLocationReceptionistId = 0;
               AssignAttri("", false, "AV6cCustomerLocationReceptionistId", StringUtil.LTrimStr( (decimal)(AV6cCustomerLocationReceptionistId), 4, 0));
            }
            else
            {
               AV6cCustomerLocationReceptionistId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcustomerlocationreceptionistid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cCustomerLocationReceptionistId", StringUtil.LTrimStr( (decimal)(AV6cCustomerLocationReceptionistId), 4, 0));
            }
            AV7cCustomerLocationReceptionistGivenName = cgiGet( edtavCcustomerlocationreceptionistgivenname_Internalname);
            AssignAttri("", false, "AV7cCustomerLocationReceptionistGivenName", AV7cCustomerLocationReceptionistGivenName);
            AV8cCustomerLocationReceptionistLastName = cgiGet( edtavCcustomerlocationreceptionistlastname_Internalname);
            AssignAttri("", false, "AV8cCustomerLocationReceptionistLastName", AV8cCustomerLocationReceptionistLastName);
            AV9cCustomerLocationReceptionistInitials = cgiGet( edtavCcustomerlocationreceptionistinitials_Internalname);
            AssignAttri("", false, "AV9cCustomerLocationReceptionistInitials", AV9cCustomerLocationReceptionistInitials);
            AV10cCustomerLocationReceptionistPhone = cgiGet( edtavCcustomerlocationreceptionistphone_Internalname);
            AssignAttri("", false, "AV10cCustomerLocationReceptionistPhone", AV10cCustomerLocationReceptionistPhone);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTID"), ".", ",") != Convert.ToDecimal( AV6cCustomerLocationReceptionistId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"), AV7cCustomerLocationReceptionistGivenName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME"), AV8cCustomerLocationReceptionistLastName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTINITIALS"), AV9cCustomerLocationReceptionistInitials) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCUSTOMERLOCATIONRECEPTIONISTPHONE"), AV10cCustomerLocationReceptionistPhone) != 0 )
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
         E170H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E170H2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Receptionist", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E180H2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E190H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190H2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCustomerLocationReceptionistId = A23CustomerLocationReceptionistId;
         AssignAttri("", false, "AV13pCustomerLocationReceptionistId", StringUtil.LTrimStr( (decimal)(AV13pCustomerLocationReceptionistId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pCustomerLocationReceptionistId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCustomerLocationReceptionistId"});
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
         AV11pCustomerId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV11pCustomerId", StringUtil.LTrimStr( (decimal)(AV11pCustomerId), 4, 0));
         AV12pCustomerLocationId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV12pCustomerLocationId", StringUtil.LTrimStr( (decimal)(AV12pCustomerLocationId), 4, 0));
         AV13pCustomerLocationReceptionistId = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV13pCustomerLocationReceptionistId", StringUtil.LTrimStr( (decimal)(AV13pCustomerLocationReceptionistId), 4, 0));
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
         PA0H2( ) ;
         WS0H2( ) ;
         WE0H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126321661", true, true);
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
         context.AddJavascriptSource("gx0042.js", "?20249126321661", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtCustomerLocationReceptionistId_Internalname = "CUSTOMERLOCATIONRECEPTIONISTID_"+sGXsfl_64_idx;
         edtCustomerLocationReceptionistGi_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGI_"+sGXsfl_64_idx;
         edtCustomerLocationReceptionistLa_Internalname = "CUSTOMERLOCATIONRECEPTIONISTLA_"+sGXsfl_64_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_64_idx;
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtCustomerLocationReceptionistId_Internalname = "CUSTOMERLOCATIONRECEPTIONISTID_"+sGXsfl_64_fel_idx;
         edtCustomerLocationReceptionistGi_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGI_"+sGXsfl_64_fel_idx;
         edtCustomerLocationReceptionistLa_Internalname = "CUSTOMERLOCATIONRECEPTIONISTLA_"+sGXsfl_64_fel_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_64_fel_idx;
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WB0H0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23CustomerLocationReceptionistId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23CustomerLocationReceptionistId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A23CustomerLocationReceptionistId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCustomerLocationReceptionistGi_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23CustomerLocationReceptionistId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtCustomerLocationReceptionistGi_Internalname, "Link", edtCustomerLocationReceptionistGi_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistGi_Internalname,(string)A24CustomerLocationReceptionistGi,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCustomerLocationReceptionistGi_Link,(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistGi_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationReceptionistLa_Internalname,(string)A25CustomerLocationReceptionistLa,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationReceptionistLa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLocationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A18CustomerLocationId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLocationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes0H2( ) ;
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
            context.SendWebValue( "Receptionist Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Given Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Last Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Customer Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Customer Location Id") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23CustomerLocationReceptionistId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A24CustomerLocationReceptionistGi));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCustomerLocationReceptionistGi_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A25CustomerLocationReceptionistLa));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, ".", ""))));
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
         lblLblcustomerlocationreceptionistidfilter_Internalname = "LBLCUSTOMERLOCATIONRECEPTIONISTIDFILTER";
         edtavCcustomerlocationreceptionistid_Internalname = "vCCUSTOMERLOCATIONRECEPTIONISTID";
         divCustomerlocationreceptionistidfiltercontainer_Internalname = "CUSTOMERLOCATIONRECEPTIONISTIDFILTERCONTAINER";
         lblLblcustomerlocationreceptionistgivennamefilter_Internalname = "LBLCUSTOMERLOCATIONRECEPTIONISTGIVENNAMEFILTER";
         edtavCcustomerlocationreceptionistgivenname_Internalname = "vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME";
         divCustomerlocationreceptionistgivennamefiltercontainer_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGIVENNAMEFILTERCONTAINER";
         lblLblcustomerlocationreceptionistlastnamefilter_Internalname = "LBLCUSTOMERLOCATIONRECEPTIONISTLASTNAMEFILTER";
         edtavCcustomerlocationreceptionistlastname_Internalname = "vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME";
         divCustomerlocationreceptionistlastnamefiltercontainer_Internalname = "CUSTOMERLOCATIONRECEPTIONISTLASTNAMEFILTERCONTAINER";
         lblLblcustomerlocationreceptionistinitialsfilter_Internalname = "LBLCUSTOMERLOCATIONRECEPTIONISTINITIALSFILTER";
         edtavCcustomerlocationreceptionistinitials_Internalname = "vCCUSTOMERLOCATIONRECEPTIONISTINITIALS";
         divCustomerlocationreceptionistinitialsfiltercontainer_Internalname = "CUSTOMERLOCATIONRECEPTIONISTINITIALSFILTERCONTAINER";
         lblLblcustomerlocationreceptionistphonefilter_Internalname = "LBLCUSTOMERLOCATIONRECEPTIONISTPHONEFILTER";
         edtavCcustomerlocationreceptionistphone_Internalname = "vCCUSTOMERLOCATIONRECEPTIONISTPHONE";
         divCustomerlocationreceptionistphonefiltercontainer_Internalname = "CUSTOMERLOCATIONRECEPTIONISTPHONEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCustomerLocationReceptionistId_Internalname = "CUSTOMERLOCATIONRECEPTIONISTID";
         edtCustomerLocationReceptionistGi_Internalname = "CUSTOMERLOCATIONRECEPTIONISTGI";
         edtCustomerLocationReceptionistLa_Internalname = "CUSTOMERLOCATIONRECEPTIONISTLA";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID";
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
         edtCustomerLocationId_Jsonclick = "";
         edtCustomerId_Jsonclick = "";
         edtCustomerLocationReceptionistLa_Jsonclick = "";
         edtCustomerLocationReceptionistGi_Jsonclick = "";
         edtCustomerLocationReceptionistGi_Link = "";
         edtCustomerLocationReceptionistId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtCustomerLocationId_Enabled = 0;
         edtCustomerId_Enabled = 0;
         edtCustomerLocationReceptionistLa_Enabled = 0;
         edtCustomerLocationReceptionistGi_Enabled = 0;
         edtCustomerLocationReceptionistId_Enabled = 0;
         edtavCcustomerlocationreceptionistphone_Jsonclick = "";
         edtavCcustomerlocationreceptionistphone_Enabled = 1;
         edtavCcustomerlocationreceptionistphone_Visible = 1;
         edtavCcustomerlocationreceptionistinitials_Jsonclick = "";
         edtavCcustomerlocationreceptionistinitials_Enabled = 1;
         edtavCcustomerlocationreceptionistinitials_Visible = 1;
         edtavCcustomerlocationreceptionistlastname_Jsonclick = "";
         edtavCcustomerlocationreceptionistlastname_Enabled = 1;
         edtavCcustomerlocationreceptionistlastname_Visible = 1;
         edtavCcustomerlocationreceptionistgivenname_Jsonclick = "";
         edtavCcustomerlocationreceptionistgivenname_Enabled = 1;
         edtavCcustomerlocationreceptionistgivenname_Visible = 1;
         edtavCcustomerlocationreceptionistid_Jsonclick = "";
         edtavCcustomerlocationreceptionistid_Enabled = 1;
         edtavCcustomerlocationreceptionistid_Visible = 1;
         divCustomerlocationreceptionistphonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomerlocationreceptionistinitialsfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomerlocationreceptionistlastnamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomerlocationreceptionistgivennamefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCustomerlocationreceptionistidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Receptionist";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerLocationReceptionistId","fld":"vCCUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9"},{"av":"AV7cCustomerLocationReceptionistGivenName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV8cCustomerLocationReceptionistLastName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV9cCustomerLocationReceptionistInitials","fld":"vCCUSTOMERLOCATIONRECEPTIONISTINITIALS"},{"av":"AV10cCustomerLocationReceptionistPhone","fld":"vCCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV11pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"},{"av":"AV12pCustomerLocationId","fld":"vPCUSTOMERLOCATIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E160H1","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTIDFILTER.CLICK","""{"handler":"E110H1","iparms":[{"av":"divCustomerlocationreceptionistidfiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTIDFILTER.CLICK",""","oparms":[{"av":"divCustomerlocationreceptionistidfiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomerlocationreceptionistid_Visible","ctrl":"vCCUSTOMERLOCATIONRECEPTIONISTID","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTGIVENNAMEFILTER.CLICK","""{"handler":"E120H1","iparms":[{"av":"divCustomerlocationreceptionistgivennamefiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTGIVENNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTGIVENNAMEFILTER.CLICK",""","oparms":[{"av":"divCustomerlocationreceptionistgivennamefiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTGIVENNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomerlocationreceptionistgivenname_Visible","ctrl":"vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTLASTNAMEFILTER.CLICK","""{"handler":"E130H1","iparms":[{"av":"divCustomerlocationreceptionistlastnamefiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTLASTNAMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTLASTNAMEFILTER.CLICK",""","oparms":[{"av":"divCustomerlocationreceptionistlastnamefiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTLASTNAMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomerlocationreceptionistlastname_Visible","ctrl":"vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTINITIALSFILTER.CLICK","""{"handler":"E140H1","iparms":[{"av":"divCustomerlocationreceptionistinitialsfiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTINITIALSFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTINITIALSFILTER.CLICK",""","oparms":[{"av":"divCustomerlocationreceptionistinitialsfiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTINITIALSFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomerlocationreceptionistinitials_Visible","ctrl":"vCCUSTOMERLOCATIONRECEPTIONISTINITIALS","prop":"Visible"}]}""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTPHONEFILTER.CLICK","""{"handler":"E150H1","iparms":[{"av":"divCustomerlocationreceptionistphonefiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTPHONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCUSTOMERLOCATIONRECEPTIONISTPHONEFILTER.CLICK",""","oparms":[{"av":"divCustomerlocationreceptionistphonefiltercontainer_Class","ctrl":"CUSTOMERLOCATIONRECEPTIONISTPHONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCcustomerlocationreceptionistphone_Visible","ctrl":"vCCUSTOMERLOCATIONRECEPTIONISTPHONE","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E190H2","iparms":[{"av":"A23CustomerLocationReceptionistId","fld":"CUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pCustomerLocationReceptionistId","fld":"vPCUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerLocationReceptionistId","fld":"vCCUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9"},{"av":"AV7cCustomerLocationReceptionistGivenName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV8cCustomerLocationReceptionistLastName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV9cCustomerLocationReceptionistInitials","fld":"vCCUSTOMERLOCATIONRECEPTIONISTINITIALS"},{"av":"AV10cCustomerLocationReceptionistPhone","fld":"vCCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV11pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"},{"av":"AV12pCustomerLocationId","fld":"vPCUSTOMERLOCATIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerLocationReceptionistId","fld":"vCCUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9"},{"av":"AV7cCustomerLocationReceptionistGivenName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV8cCustomerLocationReceptionistLastName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV9cCustomerLocationReceptionistInitials","fld":"vCCUSTOMERLOCATIONRECEPTIONISTINITIALS"},{"av":"AV10cCustomerLocationReceptionistPhone","fld":"vCCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV11pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"},{"av":"AV12pCustomerLocationId","fld":"vPCUSTOMERLOCATIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerLocationReceptionistId","fld":"vCCUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9"},{"av":"AV7cCustomerLocationReceptionistGivenName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV8cCustomerLocationReceptionistLastName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV9cCustomerLocationReceptionistInitials","fld":"vCCUSTOMERLOCATIONRECEPTIONISTINITIALS"},{"av":"AV10cCustomerLocationReceptionistPhone","fld":"vCCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV11pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"},{"av":"AV12pCustomerLocationId","fld":"vPCUSTOMERLOCATIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cCustomerLocationReceptionistId","fld":"vCCUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9"},{"av":"AV7cCustomerLocationReceptionistGivenName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV8cCustomerLocationReceptionistLastName","fld":"vCCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV9cCustomerLocationReceptionistInitials","fld":"vCCUSTOMERLOCATIONRECEPTIONISTINITIALS"},{"av":"AV10cCustomerLocationReceptionistPhone","fld":"vCCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV11pCustomerId","fld":"vPCUSTOMERID","pic":"ZZZ9"},{"av":"AV12pCustomerLocationId","fld":"vPCUSTOMERLOCATIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Customerlocationid","iparms":[]}""");
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
         AV7cCustomerLocationReceptionistGivenName = "";
         AV8cCustomerLocationReceptionistLastName = "";
         AV9cCustomerLocationReceptionistInitials = "";
         AV10cCustomerLocationReceptionistPhone = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcustomerlocationreceptionistidfilter_Jsonclick = "";
         TempTags = "";
         lblLblcustomerlocationreceptionistgivennamefilter_Jsonclick = "";
         lblLblcustomerlocationreceptionistlastnamefilter_Jsonclick = "";
         lblLblcustomerlocationreceptionistinitialsfilter_Jsonclick = "";
         lblLblcustomerlocationreceptionistphonefilter_Jsonclick = "";
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
         A24CustomerLocationReceptionistGi = "";
         A25CustomerLocationReceptionistLa = "";
         lV7cCustomerLocationReceptionistGivenName = "";
         lV8cCustomerLocationReceptionistLastName = "";
         lV9cCustomerLocationReceptionistInitials = "";
         lV10cCustomerLocationReceptionistPhone = "";
         A26CustomerLocationReceptionistIn = "";
         A29CustomerLocationReceptionistPh = "";
         H000H2_A29CustomerLocationReceptionistPh = new string[] {""} ;
         H000H2_A26CustomerLocationReceptionistIn = new string[] {""} ;
         H000H2_n26CustomerLocationReceptionistIn = new bool[] {false} ;
         H000H2_A18CustomerLocationId = new short[1] ;
         H000H2_A1CustomerId = new short[1] ;
         H000H2_A25CustomerLocationReceptionistLa = new string[] {""} ;
         H000H2_A24CustomerLocationReceptionistGi = new string[] {""} ;
         H000H2_A23CustomerLocationReceptionistId = new short[1] ;
         H000H3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0042__default(),
            new Object[][] {
                new Object[] {
               H000H2_A29CustomerLocationReceptionistPh, H000H2_A26CustomerLocationReceptionistIn, H000H2_n26CustomerLocationReceptionistIn, H000H2_A18CustomerLocationId, H000H2_A1CustomerId, H000H2_A25CustomerLocationReceptionistLa, H000H2_A24CustomerLocationReceptionistGi, H000H2_A23CustomerLocationReceptionistId
               }
               , new Object[] {
               H000H3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11pCustomerId ;
      private short AV12pCustomerLocationId ;
      private short AV13pCustomerLocationReceptionistId ;
      private short wcpOAV11pCustomerId ;
      private short wcpOAV12pCustomerLocationId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cCustomerLocationReceptionistId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A23CustomerLocationReceptionistId ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
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
      private int edtavCcustomerlocationreceptionistid_Enabled ;
      private int edtavCcustomerlocationreceptionistid_Visible ;
      private int edtavCcustomerlocationreceptionistgivenname_Visible ;
      private int edtavCcustomerlocationreceptionistgivenname_Enabled ;
      private int edtavCcustomerlocationreceptionistlastname_Visible ;
      private int edtavCcustomerlocationreceptionistlastname_Enabled ;
      private int edtavCcustomerlocationreceptionistinitials_Visible ;
      private int edtavCcustomerlocationreceptionistinitials_Enabled ;
      private int edtavCcustomerlocationreceptionistphone_Visible ;
      private int edtavCcustomerlocationreceptionistphone_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCustomerLocationReceptionistId_Enabled ;
      private int edtCustomerLocationReceptionistGi_Enabled ;
      private int edtCustomerLocationReceptionistLa_Enabled ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerLocationId_Enabled ;
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
      private string divCustomerlocationreceptionistidfiltercontainer_Class ;
      private string divCustomerlocationreceptionistgivennamefiltercontainer_Class ;
      private string divCustomerlocationreceptionistlastnamefiltercontainer_Class ;
      private string divCustomerlocationreceptionistinitialsfiltercontainer_Class ;
      private string divCustomerlocationreceptionistphonefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV9cCustomerLocationReceptionistInitials ;
      private string AV10cCustomerLocationReceptionistPhone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCustomerlocationreceptionistidfiltercontainer_Internalname ;
      private string lblLblcustomerlocationreceptionistidfilter_Internalname ;
      private string lblLblcustomerlocationreceptionistidfilter_Jsonclick ;
      private string edtavCcustomerlocationreceptionistid_Internalname ;
      private string TempTags ;
      private string edtavCcustomerlocationreceptionistid_Jsonclick ;
      private string divCustomerlocationreceptionistgivennamefiltercontainer_Internalname ;
      private string lblLblcustomerlocationreceptionistgivennamefilter_Internalname ;
      private string lblLblcustomerlocationreceptionistgivennamefilter_Jsonclick ;
      private string edtavCcustomerlocationreceptionistgivenname_Internalname ;
      private string edtavCcustomerlocationreceptionistgivenname_Jsonclick ;
      private string divCustomerlocationreceptionistlastnamefiltercontainer_Internalname ;
      private string lblLblcustomerlocationreceptionistlastnamefilter_Internalname ;
      private string lblLblcustomerlocationreceptionistlastnamefilter_Jsonclick ;
      private string edtavCcustomerlocationreceptionistlastname_Internalname ;
      private string edtavCcustomerlocationreceptionistlastname_Jsonclick ;
      private string divCustomerlocationreceptionistinitialsfiltercontainer_Internalname ;
      private string lblLblcustomerlocationreceptionistinitialsfilter_Internalname ;
      private string lblLblcustomerlocationreceptionistinitialsfilter_Jsonclick ;
      private string edtavCcustomerlocationreceptionistinitials_Internalname ;
      private string edtavCcustomerlocationreceptionistinitials_Jsonclick ;
      private string divCustomerlocationreceptionistphonefiltercontainer_Internalname ;
      private string lblLblcustomerlocationreceptionistphonefilter_Internalname ;
      private string lblLblcustomerlocationreceptionistphonefilter_Jsonclick ;
      private string edtavCcustomerlocationreceptionistphone_Internalname ;
      private string edtavCcustomerlocationreceptionistphone_Jsonclick ;
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
      private string edtCustomerLocationReceptionistId_Internalname ;
      private string edtCustomerLocationReceptionistGi_Internalname ;
      private string edtCustomerLocationReceptionistLa_Internalname ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerLocationId_Internalname ;
      private string lV9cCustomerLocationReceptionistInitials ;
      private string lV10cCustomerLocationReceptionistPhone ;
      private string A26CustomerLocationReceptionistIn ;
      private string A29CustomerLocationReceptionistPh ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCustomerLocationReceptionistId_Jsonclick ;
      private string edtCustomerLocationReceptionistGi_Link ;
      private string edtCustomerLocationReceptionistGi_Jsonclick ;
      private string edtCustomerLocationReceptionistLa_Jsonclick ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerLocationId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n26CustomerLocationReceptionistIn ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cCustomerLocationReceptionistGivenName ;
      private string AV8cCustomerLocationReceptionistLastName ;
      private string AV15Linkselection_GXI ;
      private string A24CustomerLocationReceptionistGi ;
      private string A25CustomerLocationReceptionistLa ;
      private string lV7cCustomerLocationReceptionistGivenName ;
      private string lV8cCustomerLocationReceptionistLastName ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000H2_A29CustomerLocationReceptionistPh ;
      private string[] H000H2_A26CustomerLocationReceptionistIn ;
      private bool[] H000H2_n26CustomerLocationReceptionistIn ;
      private short[] H000H2_A18CustomerLocationId ;
      private short[] H000H2_A1CustomerId ;
      private string[] H000H2_A25CustomerLocationReceptionistLa ;
      private string[] H000H2_A24CustomerLocationReceptionistGi ;
      private short[] H000H2_A23CustomerLocationReceptionistId ;
      private long[] H000H3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP2_pCustomerLocationReceptionistId ;
   }

   public class gx0042__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000H2( IGxContext context ,
                                             string AV7cCustomerLocationReceptionistGivenName ,
                                             string AV8cCustomerLocationReceptionistLastName ,
                                             string AV9cCustomerLocationReceptionistInitials ,
                                             string AV10cCustomerLocationReceptionistPhone ,
                                             string A24CustomerLocationReceptionistGi ,
                                             string A25CustomerLocationReceptionistLa ,
                                             string A26CustomerLocationReceptionistIn ,
                                             string A29CustomerLocationReceptionistPh ,
                                             short AV11pCustomerId ,
                                             short AV12pCustomerLocationId ,
                                             short AV6cCustomerLocationReceptionistId ,
                                             short A1CustomerId ,
                                             short A18CustomerLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CustomerLocationReceptionistPh, CustomerLocationReceptionistIn, CustomerLocationId, CustomerId, CustomerLocationReceptionistLa, CustomerLocationReceptionistGi, CustomerLocationReceptionistId";
         sFromString = " FROM CustomerLocationReceptionist";
         sOrderString = "";
         AddWhere(sWhereString, "(CustomerId = :AV11pCustomerId and CustomerLocationId = :AV12pCustomerLocationId and CustomerLocationReceptionistId >= :AV6cCustomerLocationReceptionistId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCustomerLocationReceptionistGivenName)) )
         {
            AddWhere(sWhereString, "(CustomerLocationReceptionistGi like :lV7cCustomerLocationReceptionistGivenName)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCustomerLocationReceptionistLastName)) )
         {
            AddWhere(sWhereString, "(CustomerLocationReceptionistLa like :lV8cCustomerLocationReceptionistLastName)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCustomerLocationReceptionistInitials)) )
         {
            AddWhere(sWhereString, "(CustomerLocationReceptionistIn like :lV9cCustomerLocationReceptionistInitials)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cCustomerLocationReceptionistPhone)) )
         {
            AddWhere(sWhereString, "(CustomerLocationReceptionistPh like :lV10cCustomerLocationReceptionistPhone)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY CustomerId, CustomerLocationId, CustomerLocationReceptionistId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000H3( IGxContext context ,
                                             string AV7cCustomerLocationReceptionistGivenName ,
                                             string AV8cCustomerLocationReceptionistLastName ,
                                             string AV9cCustomerLocationReceptionistInitials ,
                                             string AV10cCustomerLocationReceptionistPhone ,
                                             string A24CustomerLocationReceptionistGi ,
                                             string A25CustomerLocationReceptionistLa ,
                                             string A26CustomerLocationReceptionistIn ,
                                             string A29CustomerLocationReceptionistPh ,
                                             short AV11pCustomerId ,
                                             short AV12pCustomerLocationId ,
                                             short AV6cCustomerLocationReceptionistId ,
                                             short A1CustomerId ,
                                             short A18CustomerLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM CustomerLocationReceptionist";
         AddWhere(sWhereString, "(CustomerId = :AV11pCustomerId and CustomerLocationId = :AV12pCustomerLocationId and CustomerLocationReceptionistId >= :AV6cCustomerLocationReceptionistId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cCustomerLocationReceptionistGivenName)) )
         {
            AddWhere(sWhereString, "(CustomerLocationReceptionistGi like :lV7cCustomerLocationReceptionistGivenName)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cCustomerLocationReceptionistLastName)) )
         {
            AddWhere(sWhereString, "(CustomerLocationReceptionistLa like :lV8cCustomerLocationReceptionistLastName)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cCustomerLocationReceptionistInitials)) )
         {
            AddWhere(sWhereString, "(CustomerLocationReceptionistIn like :lV9cCustomerLocationReceptionistInitials)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cCustomerLocationReceptionistPhone)) )
         {
            AddWhere(sWhereString, "(CustomerLocationReceptionistPh like :lV10cCustomerLocationReceptionistPhone)");
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
                     return conditional_H000H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H000H3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmH000H2;
          prmH000H2 = new Object[] {
          new ParDef("AV11pCustomerId",GXType.Int16,4,0) ,
          new ParDef("AV12pCustomerLocationId",GXType.Int16,4,0) ,
          new ParDef("AV6cCustomerLocationReceptionistId",GXType.Int16,4,0) ,
          new ParDef("lV7cCustomerLocationReceptionistGivenName",GXType.VarChar,40,0) ,
          new ParDef("lV8cCustomerLocationReceptionistLastName",GXType.VarChar,40,0) ,
          new ParDef("lV9cCustomerLocationReceptionistInitials",GXType.Char,20,0) ,
          new ParDef("lV10cCustomerLocationReceptionistPhone",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000H3;
          prmH000H3 = new Object[] {
          new ParDef("AV11pCustomerId",GXType.Int16,4,0) ,
          new ParDef("AV12pCustomerLocationId",GXType.Int16,4,0) ,
          new ParDef("AV6cCustomerLocationReceptionistId",GXType.Int16,4,0) ,
          new ParDef("lV7cCustomerLocationReceptionistGivenName",GXType.VarChar,40,0) ,
          new ParDef("lV8cCustomerLocationReceptionistLastName",GXType.VarChar,40,0) ,
          new ParDef("lV9cCustomerLocationReceptionistInitials",GXType.Char,20,0) ,
          new ParDef("lV10cCustomerLocationReceptionistPhone",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H3,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(3);
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
