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
   public class locationamenities : GXDataArea
   {
      public locationamenities( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public locationamenities( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavLocationoption = new GXCombobox();
         chkavLocationamenitiessdts__selected = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONOPTION") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvLOCATIONOPTION3R2( ) ;
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grids") == 0 )
            {
               gxnrGrids_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grids") == 0 )
            {
               gxgrGrids_refresh_invoke( ) ;
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

      protected void gxnrGrids_newrow_invoke( )
      {
         nRC_GXsfl_26 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_26"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_26_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_26_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_26_idx = GetPar( "sGXsfl_26_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrids_newrow( ) ;
         /* End function gxnrGrids_newrow_invoke */
      }

      protected void gxgrGrids_refresh_invoke( )
      {
         dynavLocationoption.FromJSonString( GetNextPar( ));
         AV18LocationOption = (short)(Math.Round(NumberUtil.Val( GetPar( "LocationOption"), "."), 18, MidpointRounding.ToEven));
         AV27Udparg1 = (short)(Math.Round(NumberUtil.Val( GetPar( "Udparg1"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( AV18LocationOption, AV27Udparg1) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrids_refresh_invoke */
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
            return "locationamenities_Execute" ;
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
         PA3R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3R2( ) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("locationamenities.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vUDPARG1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Udparg1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27Udparg1), "9999"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Locationamenitiessdts", AV17LocationAmenitiesSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Locationamenitiessdts", AV17LocationAmenitiesSDTs);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_26", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_26), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Udparg1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27Udparg1), "9999"), context));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AMENITIESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A98AmenitiesId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AMENITIESNAME", A101AmenitiesName);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONAMENITIESSDTS", AV17LocationAmenitiesSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONAMENITIESSDTS", AV17LocationAmenitiesSDTs);
         }
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
            WE3R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3R2( ) ;
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
         return formatLink("locationamenities.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "LocationAmenities" ;
      }

      public override string GetPgmdesc( )
      {
         return "Location Amenities" ;
      }

      protected void WB3R0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", divTablefilters_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", dynavLocationoption.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavLocationoption_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationoption_Internalname, "Location: ", "col-sm-1 AddressAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-11 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_26_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationoption, dynavLocationoption_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18LocationOption), 4, 0)), 1, dynavLocationoption_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavLocationoption.Visible, dynavLocationoption.Enabled, 0, 0, 30, "em", 0, "", "", "AddressAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_LocationAmenities.htm");
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18LocationOption), 4, 0));
            AssignProp("", false, dynavLocationoption_Internalname, "Values", (string)(dynavLocationoption.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridsContainer.SetIsFreestyle(true);
            GridsContainer.SetWrapped(nGXWrapped);
            StartGridControl26( ) ;
         }
         if ( wbEnd == 26 )
         {
            wbEnd = 0;
            nRC_GXsfl_26 = (int)(nGXsfl_26_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV22GXV1 = nGXsfl_26_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grids", GridsContainer, subGrids_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsContainerData", GridsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsContainerData"+"V", GridsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 26 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV22GXV1 = nGXsfl_26_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grids", GridsContainer, subGrids_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsContainerData", GridsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsContainerData"+"V", GridsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3R2( )
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
         Form.Meta.addItem("description", "Location Amenities", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3R0( ) ;
      }

      protected void WS3R2( )
      {
         START3R2( ) ;
         EVT3R2( ) ;
      }

      protected void EVT3R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VLOCATIONOPTION.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E113R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRIDS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_26_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
                              SubsflControlProps_262( ) ;
                              AV22GXV1 = nGXsfl_26_idx;
                              if ( ( AV17LocationAmenitiesSDTs.Count >= AV22GXV1 ) && ( AV22GXV1 > 0 ) )
                              {
                                 AV17LocationAmenitiesSDTs.CurrentItem = ((SdtLocationAmenitiesSDT)AV17LocationAmenitiesSDTs.Item(AV22GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E123R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grids.Load */
                                    E133R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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

      protected void WE3R2( )
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

      protected void PA3R2( )
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
               GX_FocusControl = dynavLocationoption_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvLOCATIONOPTION3R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONOPTION_data3R2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLOCATIONOPTION_html3R2( )
      {
         short gxdynajaxvalue;
         GXDLVvLOCATIONOPTION_data3R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationoption.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavLocationoption.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV18LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18LocationOption", StringUtil.LTrimStr( (decimal)(AV18LocationOption), 4, 0));
         }
      }

      protected void GXDLVvLOCATIONOPTION_data3R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H003R2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H003R2_A1CustomerId[0] == new getloggedinusercustomerid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H003R2_A18CustomerLocationId[0]), 4, 0, ".", "")));
               gxdynajaxctrldescr.Add(H003R2_A134CustomerLocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_262( ) ;
         while ( nGXsfl_26_idx <= nRC_GXsfl_26 )
         {
            sendrow_262( ) ;
            nGXsfl_26_idx = ((subGrids_Islastpage==1)&&(nGXsfl_26_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( short AV18LocationOption ,
                                        short AV27Udparg1 )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF3R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrids_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvLOCATIONOPTION_html3R2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV18LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18LocationOption", StringUtil.LTrimStr( (decimal)(AV18LocationOption), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18LocationOption), 4, 0));
            AssignProp("", false, dynavLocationoption_Internalname, "Values", dynavLocationoption.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         chkavLocationamenitiessdts__selected.Enabled = 0;
         edtavLocationamenitiessdts__amenitiesname_Enabled = 0;
      }

      protected void RF3R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 26;
         nGXsfl_26_idx = 1;
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         bGXsfl_26_Refreshing = true;
         GridsContainer.AddObjectProperty("GridName", "Grids");
         GridsContainer.AddObjectProperty("CmpContext", "");
         GridsContainer.AddObjectProperty("InMasterPage", "false");
         GridsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridsContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
         GridsContainer.PageSize = subGrids_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_262( ) ;
            /* Execute user event: Grids.Load */
            E133R2 ();
            wbEnd = 26;
            WB3R0( ) ;
         }
         bGXsfl_26_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3R2( )
      {
         GxWebStd.gx_hidden_field( context, "vUDPARG1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Udparg1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27Udparg1), "9999"), context));
      }

      protected int subGrids_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrids_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrids_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrids_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         chkavLocationamenitiessdts__selected.Enabled = 0;
         edtavLocationamenitiessdts__amenitiesname_Enabled = 0;
         GXVvLOCATIONOPTION_html3R2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E123R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Locationamenitiessdts"), AV17LocationAmenitiesSDTs);
            ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONAMENITIESSDTS"), AV17LocationAmenitiesSDTs);
            /* Read saved values. */
            nRC_GXsfl_26 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_26"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_26 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_26"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_26_fel_idx = 0;
            while ( nGXsfl_26_fel_idx < nRC_GXsfl_26 )
            {
               nGXsfl_26_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_26_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_fel_idx+1);
               sGXsfl_26_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_262( ) ;
               AV22GXV1 = nGXsfl_26_fel_idx;
               if ( ( AV17LocationAmenitiesSDTs.Count >= AV22GXV1 ) && ( AV22GXV1 > 0 ) )
               {
                  AV17LocationAmenitiesSDTs.CurrentItem = ((SdtLocationAmenitiesSDT)AV17LocationAmenitiesSDTs.Item(AV22GXV1));
               }
            }
            if ( nGXsfl_26_fel_idx == 0 )
            {
               nGXsfl_26_idx = 1;
               sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
               SubsflControlProps_262( ) ;
            }
            nGXsfl_26_fel_idx = 1;
            /* Read variables values. */
            dynavLocationoption.Name = dynavLocationoption_Internalname;
            dynavLocationoption.CurrentValue = cgiGet( dynavLocationoption_Internalname);
            AV18LocationOption = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavLocationoption_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18LocationOption", StringUtil.LTrimStr( (decimal)(AV18LocationOption), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E123R2 ();
         if (returnInSub) return;
      }

      protected void E123R2( )
      {
         /* Start Routine */
         returnInSub = false;
         divTablefilters_Height = 50;
         AssignProp("", false, divTablefilters_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablefilters_Height), 9, 0), true);
         edtavLocationamenitiessdts__amenitiesid_Visible = 0;
         AssignProp("", false, edtavLocationamenitiessdts__amenitiesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationamenitiessdts__amenitiesid_Visible), 5, 0), !bGXsfl_26_Refreshing);
         GXt_SdtGAMUser1 = AV6GAMUser;
         new getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV6GAMUser = GXt_SdtGAMUser1;
         if ( AV6GAMUser.checkrole("Customer Manager") )
         {
            dynavLocationoption.Visible = 1;
            AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
         }
         else
         {
            if ( AV6GAMUser.checkrole("Receptionist") )
            {
               GXt_int2 = AV18LocationOption;
               new getreceptionistlocationid(context ).execute( out  GXt_int2) ;
               AV18LocationOption = GXt_int2;
               AssignAttri("", false, "AV18LocationOption", StringUtil.LTrimStr( (decimal)(AV18LocationOption), 4, 0));
               dynavLocationoption.Visible = 0;
               AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
               divTablefilters_Height = 5;
               AssignProp("", false, divTablefilters_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablefilters_Height), 9, 0), true);
            }
         }
         /* Execute user subroutine: 'LOADGRIDDATA' */
         S112 ();
         if (returnInSub) return;
      }

      private void E133R2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV17LocationAmenitiesSDTs.Count )
         {
            AV17LocationAmenitiesSDTs.CurrentItem = ((SdtLocationAmenitiesSDT)AV17LocationAmenitiesSDTs.Item(AV22GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 26;
            }
            sendrow_262( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_26_Refreshing )
            {
               DoAjaxLoad(26, GridsRow);
            }
            AV22GXV1 = (int)(AV22GXV1+1);
         }
      }

      protected void E113R2( )
      {
         /* Locationoption_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV26 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17LocationAmenitiesSDTs", AV17LocationAmenitiesSDTs);
            nGXsfl_26_bak_idx = nGXsfl_26_idx;
            gxgrGrids_refresh( AV18LocationOption, AV27Udparg1) ;
            nGXsfl_26_idx = nGXsfl_26_bak_idx;
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADGRIDDATA' Routine */
         returnInSub = false;
         AV17LocationAmenitiesSDTs.Clear();
         gx_BV26 = true;
         AV27Udparg1 = new getloggedinusercustomerid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV18LocationOption ,
                                              A18CustomerLocationId ,
                                              AV27Udparg1 ,
                                              A1CustomerId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H003R3 */
         pr_default.execute(1, new Object[] {AV27Udparg1, AV18LocationOption});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A18CustomerLocationId = H003R3_A18CustomerLocationId[0];
            A1CustomerId = H003R3_A1CustomerId[0];
            A98AmenitiesId = H003R3_A98AmenitiesId[0];
            A101AmenitiesName = H003R3_A101AmenitiesName[0];
            A101AmenitiesName = H003R3_A101AmenitiesName[0];
            AV21LocationAmenitiesSDT = new SdtLocationAmenitiesSDT(context);
            AV21LocationAmenitiesSDT.gxTpr_Amenitiesid = A98AmenitiesId;
            AV21LocationAmenitiesSDT.gxTpr_Amenitiesname = A101AmenitiesName;
            AV21LocationAmenitiesSDT.gxTpr_Selected = true;
            AV17LocationAmenitiesSDTs.Add(AV21LocationAmenitiesSDT, 0);
            gx_BV26 = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA3R2( ) ;
         WS3R2( ) ;
         WE3R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024912632073", true, true);
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
            context.AddJavascriptSource("locationamenities.js", "?2024912632074", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_262( )
      {
         chkavLocationamenitiessdts__selected_Internalname = "LOCATIONAMENITIESSDTS__SELECTED_"+sGXsfl_26_idx;
         edtavLocationamenitiessdts__amenitiesname_Internalname = "LOCATIONAMENITIESSDTS__AMENITIESNAME_"+sGXsfl_26_idx;
         edtavLocationamenitiessdts__amenitiesid_Internalname = "LOCATIONAMENITIESSDTS__AMENITIESID_"+sGXsfl_26_idx;
      }

      protected void SubsflControlProps_fel_262( )
      {
         chkavLocationamenitiessdts__selected_Internalname = "LOCATIONAMENITIESSDTS__SELECTED_"+sGXsfl_26_fel_idx;
         edtavLocationamenitiessdts__amenitiesname_Internalname = "LOCATIONAMENITIESSDTS__AMENITIESNAME_"+sGXsfl_26_fel_idx;
         edtavLocationamenitiessdts__amenitiesid_Internalname = "LOCATIONAMENITIESSDTS__AMENITIESID_"+sGXsfl_26_fel_idx;
      }

      protected void sendrow_262( )
      {
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         WB3R0( ) ;
         GridsRow = GXWebRow.GetNew(context,GridsContainer);
         if ( subGrids_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrids_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
            {
               subGrids_Linesclass = subGrids_Class+"Odd";
            }
         }
         else if ( subGrids_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrids_Backstyle = 0;
            subGrids_Backcolor = subGrids_Allbackcolor;
            if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
            {
               subGrids_Linesclass = subGrids_Class+"Uniform";
            }
         }
         else if ( subGrids_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrids_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
            {
               subGrids_Linesclass = subGrids_Class+"Odd";
            }
            subGrids_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrids_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrids_Backstyle = 1;
            if ( ((int)((nGXsfl_26_idx) % (2))) == 0 )
            {
               subGrids_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Even";
               }
            }
            else
            {
               subGrids_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrids_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_26_idx+"\">") ;
         }
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGridslayouttable_Internalname+"_"+sGXsfl_26_idx,(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)" "+"data-gx-smarttable"+" ",(string)"grid-template-columns:30px 100fr;grid-template-rows:auto auto;",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)" "+"data-gx-smarttable-cell"+" ",(string)"",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavLocationamenitiessdts__selected_Internalname,(string)"Selected",(string)"gx-form-item AttributeCheckBoxLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_26_idx + "',26)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GXCCtl = "LOCATIONAMENITIESSDTS__SELECTED_" + sGXsfl_26_idx;
         chkavLocationamenitiessdts__selected.Name = GXCCtl;
         chkavLocationamenitiessdts__selected.WebTags = "";
         chkavLocationamenitiessdts__selected.Caption = "Selected";
         AssignProp("", false, chkavLocationamenitiessdts__selected_Internalname, "TitleCaption", chkavLocationamenitiessdts__selected.Caption, !bGXsfl_26_Refreshing);
         chkavLocationamenitiessdts__selected.CheckedValue = "false";
         GridsRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavLocationamenitiessdts__selected_Internalname,StringUtil.BoolToStr( ((SdtLocationAmenitiesSDT)AV17LocationAmenitiesSDTs.Item(AV22GXV1)).gxTpr_Selected),(string)"",(string)"Selected",(short)1,chkavLocationamenitiessdts__selected.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(30, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,30);\""});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)" "+"data-gx-smarttable-cell"+" ",(string)"display:flex;align-items:end;",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiesname_Internalname,(string)"Amenities Name",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_26_idx + "',26)\"";
         ROClassString = "Attribute";
         GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiesname_Internalname,((SdtLocationAmenitiesSDT)AV17LocationAmenitiesSDTs.Item(AV22GXV1)).gxTpr_Amenitiesname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationamenitiessdts__amenitiesname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavLocationamenitiessdts__amenitiesname_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Invisible",(string)"start",(string)"top",(string)" "+"data-gx-smarttable-cell"+" ",(string)"",(string)"div"});
         /* Table start */
         GridsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrids_Internalname+"_"+sGXsfl_26_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiesid_Internalname,(string)"Amenities Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_26_idx + "',26)\"";
         ROClassString = "Attribute";
         GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiesid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtLocationAmenitiesSDT)AV17LocationAmenitiesSDTs.Item(AV22GXV1)).gxTpr_Amenitiesid), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtLocationAmenitiesSDT)AV17LocationAmenitiesSDTs.Item(AV22GXV1)).gxTpr_Amenitiesid), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationamenitiessdts__amenitiesid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavLocationamenitiessdts__amenitiesid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)26,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( GridsContainer.GetWrapped() == 1 )
         {
            GridsContainer.CloseTag("cell");
         }
         if ( GridsContainer.GetWrapped() == 1 )
         {
            GridsContainer.CloseTag("row");
         }
         if ( GridsContainer.GetWrapped() == 1 )
         {
            GridsContainer.CloseTag("table");
         }
         /* End of table */
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes3R2( ) ;
         /* End of Columns property logic. */
         GridsContainer.AddRow(GridsRow);
         nGXsfl_26_idx = ((subGrids_Islastpage==1)&&(nGXsfl_26_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         /* End function sendrow_262 */
      }

      protected void init_web_controls( )
      {
         dynavLocationoption.Name = "vLOCATIONOPTION";
         dynavLocationoption.WebTags = "";
         GXCCtl = "LOCATIONAMENITIESSDTS__SELECTED_" + sGXsfl_26_idx;
         chkavLocationamenitiessdts__selected.Name = GXCCtl;
         chkavLocationamenitiessdts__selected.WebTags = "";
         chkavLocationamenitiessdts__selected.Caption = "Selected";
         AssignProp("", false, chkavLocationamenitiessdts__selected_Internalname, "TitleCaption", chkavLocationamenitiessdts__selected.Caption, !bGXsfl_26_Refreshing);
         chkavLocationamenitiessdts__selected.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl26( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridsContainer"+"DivS\" data-gxgridid=\"26\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrids_Internalname, subGrids_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridsContainer.AddObjectProperty("GridName", "Grids");
         }
         else
         {
            GridsContainer.AddObjectProperty("GridName", "Grids");
            GridsContainer.AddObjectProperty("Header", subGrids_Header);
            GridsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridsContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("CmpContext", "");
            GridsContainer.AddObjectProperty("InMasterPage", "false");
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavLocationamenitiessdts__selected.Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationamenitiessdts__amenitiesname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationamenitiessdts__amenitiesid_Visible), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectedindex), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowselection), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectioncolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowhovering), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Hoveringcolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowcollapsing), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         dynavLocationoption_Internalname = "vLOCATIONOPTION";
         divTablefilters_Internalname = "TABLEFILTERS";
         chkavLocationamenitiessdts__selected_Internalname = "LOCATIONAMENITIESSDTS__SELECTED";
         edtavLocationamenitiessdts__amenitiesname_Internalname = "LOCATIONAMENITIESSDTS__AMENITIESNAME";
         edtavLocationamenitiessdts__amenitiesid_Internalname = "LOCATIONAMENITIESSDTS__AMENITIESID";
         tblUnnamedtablecontentfsgrids_Internalname = "UNNAMEDTABLECONTENTFSGRIDS";
         divGridslayouttable_Internalname = "GRIDSLAYOUTTABLE";
         divTablegrid_Internalname = "TABLEGRID";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrids_Internalname = "GRIDS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrids_Allowcollapsing = 0;
         edtavLocationamenitiessdts__amenitiesid_Jsonclick = "";
         edtavLocationamenitiessdts__amenitiesid_Visible = 1;
         edtavLocationamenitiessdts__amenitiesname_Jsonclick = "";
         edtavLocationamenitiessdts__amenitiesname_Enabled = 0;
         chkavLocationamenitiessdts__selected.Caption = "Selected";
         chkavLocationamenitiessdts__selected.Enabled = 0;
         subGrids_Class = "FreeStyleGrid";
         subGrids_Backcolorstyle = 0;
         edtavLocationamenitiessdts__amenitiesname_Enabled = -1;
         chkavLocationamenitiessdts__selected.Enabled = -1;
         dynavLocationoption_Jsonclick = "";
         dynavLocationoption.Enabled = 1;
         dynavLocationoption.Visible = 1;
         divTablefilters_Height = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Location Amenities";
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV17LocationAmenitiesSDTs","fld":"vLOCATIONAMENITIESSDTS","grid":26},{"av":"nGXsfl_26_idx","ctrl":"GRID","prop":"GridCurrRow","grid":26},{"av":"nRC_GXsfl_26","ctrl":"GRIDS","prop":"GridRC","grid":26},{"av":"dynavLocationoption"},{"av":"AV18LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV27Udparg1","fld":"vUDPARG1","pic":"9999","hsh":true}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E133R2","iparms":[]}""");
         setEventMetadata("VLOCATIONOPTION.CONTROLVALUECHANGED","""{"handler":"E113R2","iparms":[{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"AV27Udparg1","fld":"vUDPARG1","pic":"9999","hsh":true},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"dynavLocationoption"},{"av":"AV18LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"A98AmenitiesId","fld":"AMENITIESID","pic":"ZZZ9"},{"av":"A101AmenitiesName","fld":"AMENITIESNAME"},{"av":"AV17LocationAmenitiesSDTs","fld":"vLOCATIONAMENITIESSDTS","grid":26},{"av":"nGXsfl_26_idx","ctrl":"GRID","prop":"GridCurrRow","grid":26},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_26","ctrl":"GRIDS","prop":"GridRC","grid":26},{"av":"GRIDS_nEOF"}]""");
         setEventMetadata("VLOCATIONOPTION.CONTROLVALUECHANGED",""","oparms":[{"av":"AV17LocationAmenitiesSDTs","fld":"vLOCATIONAMENITIESSDTS","grid":26},{"av":"nGXsfl_26_idx","ctrl":"GRID","prop":"GridCurrRow","grid":26},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_26","ctrl":"GRIDS","prop":"GridRC","grid":26}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv4","iparms":[]}""");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17LocationAmenitiesSDTs = new GXBaseCollection<SdtLocationAmenitiesSDT>( context, "LocationAmenitiesSDT", "Comforta2");
         A101AmenitiesName = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H003R2_A18CustomerLocationId = new short[1] ;
         H003R2_A134CustomerLocationName = new string[] {""} ;
         H003R2_A1CustomerId = new short[1] ;
         AV6GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GridsRow = new GXWebRow();
         H003R3_A18CustomerLocationId = new short[1] ;
         H003R3_A1CustomerId = new short[1] ;
         H003R3_A98AmenitiesId = new short[1] ;
         H003R3_A101AmenitiesName = new string[] {""} ;
         AV21LocationAmenitiesSDT = new SdtLocationAmenitiesSDT(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrids_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         subGrids_Header = "";
         GridsColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.locationamenities__default(),
            new Object[][] {
                new Object[] {
               H003R2_A18CustomerLocationId, H003R2_A134CustomerLocationName, H003R2_A1CustomerId
               }
               , new Object[] {
               H003R3_A18CustomerLocationId, H003R3_A1CustomerId, H003R3_A98AmenitiesId, H003R3_A101AmenitiesName
               }
            }
         );
         /* GeneXus formulas. */
         chkavLocationamenitiessdts__selected.Enabled = 0;
         edtavLocationamenitiessdts__amenitiesname_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV18LocationOption ;
      private short AV27Udparg1 ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
      private short A98AmenitiesId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short GXt_int2 ;
      private short GRIDS_nEOF ;
      private short subGrids_Backstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int nRC_GXsfl_26 ;
      private int nGXsfl_26_idx=1 ;
      private int divTablefilters_Height ;
      private int AV22GXV1 ;
      private int gxdynajaxindex ;
      private int subGrids_Islastpage ;
      private int edtavLocationamenitiessdts__amenitiesname_Enabled ;
      private int nGXsfl_26_fel_idx=1 ;
      private int edtavLocationamenitiessdts__amenitiesid_Visible ;
      private int nGXsfl_26_bak_idx=1 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_26_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTablefilters_Internalname ;
      private string dynavLocationoption_Internalname ;
      private string TempTags ;
      private string dynavLocationoption_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string sGXsfl_26_fel_idx="0001" ;
      private string edtavLocationamenitiessdts__amenitiesid_Internalname ;
      private string chkavLocationamenitiessdts__selected_Internalname ;
      private string edtavLocationamenitiessdts__amenitiesname_Internalname ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string divGridslayouttable_Internalname ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavLocationamenitiessdts__amenitiesname_Jsonclick ;
      private string tblUnnamedtablecontentfsgrids_Internalname ;
      private string edtavLocationamenitiessdts__amenitiesid_Jsonclick ;
      private string subGrids_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_26_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV26 ;
      private string A101AmenitiesName ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationoption ;
      private GXCheckbox chkavLocationamenitiessdts__selected ;
      private GXBaseCollection<SdtLocationAmenitiesSDT> AV17LocationAmenitiesSDTs ;
      private IDataStoreProvider pr_default ;
      private short[] H003R2_A18CustomerLocationId ;
      private string[] H003R2_A134CustomerLocationName ;
      private short[] H003R2_A1CustomerId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV6GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private short[] H003R3_A18CustomerLocationId ;
      private short[] H003R3_A1CustomerId ;
      private short[] H003R3_A98AmenitiesId ;
      private string[] H003R3_A101AmenitiesName ;
      private SdtLocationAmenitiesSDT AV21LocationAmenitiesSDT ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class locationamenities__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003R3( IGxContext context ,
                                             short AV18LocationOption ,
                                             short A18CustomerLocationId ,
                                             short AV27Udparg1 ,
                                             short A1CustomerId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CustomerLocationId, T1.CustomerId, T1.AmenitiesId, T2.AmenitiesName FROM (CustomerLocationsAmenities T1 INNER JOIN Amenities T2 ON T2.AmenitiesId = T1.AmenitiesId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV27Udparg1)");
         if ( ! (0==AV18LocationOption) )
         {
            AddWhere(sWhereString, "(T1.CustomerLocationId = :AV18LocationOption)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerId";
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
               case 1 :
                     return conditional_H003R3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] );
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
          Object[] prmH003R2;
          prmH003R2 = new Object[] {
          };
          Object[] prmH003R3;
          prmH003R3 = new Object[] {
          new ParDef("AV27Udparg1",GXType.Int16,4,0) ,
          new ParDef("AV18LocationOption",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003R2", "SELECT CustomerLocationId, CustomerLocationName, CustomerId FROM CustomerLocation ORDER BY CustomerLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003R2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003R3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
