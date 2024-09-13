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
   public class updatelocationstep2 : GXWebComponent
   {
      public updatelocationstep2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public updatelocationstep2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack ,
                           ref short aP3_LocationId )
      {
         this.AV22WebSessionKey = aP0_WebSessionKey;
         this.AV20PreviousStep = aP1_PreviousStep;
         this.AV13GoingBack = aP2_GoingBack;
         this.AV5LocationId = aP3_LocationId;
         ExecuteImpl();
         aP3_LocationId=this.AV5LocationId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkavLocationamenitiessdts__selected = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV22WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV22WebSessionKey", AV22WebSessionKey);
                  AV20PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
                  AV13GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV13GoingBack", AV13GoingBack);
                  AV5LocationId = (short)(Math.Round(NumberUtil.Val( GetPar( "LocationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV5LocationId", StringUtil.LTrimStr( (decimal)(AV5LocationId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV22WebSessionKey,(string)AV20PreviousStep,(bool)AV13GoingBack,(short)AV5LocationId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrids_newrow_invoke( )
      {
         nRC_GXsfl_18 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_18"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_18_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_18_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_18_idx = GetPar( "sGXsfl_18_idx");
         sPrefix = GetPar( "sPrefix");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19LocationAmenitiesSDTs);
         AV15HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         AV10CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6MyCustomer);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( AV19LocationAmenitiesSDTs, AV15HasValidationErrors, AV10CustomerId, AV6MyCustomer, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrids_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA3V2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavLocationamenitiessdts__amenitiesname_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationamenitiessdts__amenitiesname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationamenitiessdts__amenitiesname_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               WS3V2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Update Location Step2", "")) ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("updatelocationstep2.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV22WebSessionKey)),UrlEncode(StringUtil.RTrim(AV20PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV13GoingBack)),UrlEncode(StringUtil.LTrimStr(AV5LocationId,4,0))}, new string[] {"WebSessionKey","PreviousStep","GoingBack","LocationId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONAMENITIESSDTS", AV19LocationAmenitiesSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONAMENITIESSDTS", AV19LocationAmenitiesSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLOCATIONAMENITIESSDTS", GetSecureSignedToken( sPrefix, AV19LocationAmenitiesSDTs, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCUSTOMERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10CustomerId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMYCUSTOMER", AV6MyCustomer);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMYCUSTOMER", AV6MyCustomer);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMYCUSTOMER", GetSecureSignedToken( sPrefix, AV6MyCustomer, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Locationamenitiessdts", AV19LocationAmenitiesSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Locationamenitiessdts", AV19LocationAmenitiesSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Locationamenitiessdts", GetSecureSignedToken( sPrefix, AV19LocationAmenitiesSDTs, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_18", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_18), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV22WebSessionKey", wcpOAV22WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20PreviousStep", wcpOAV20PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV13GoingBack", wcpOAV13GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV5LocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV5LocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV22WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONAMENITIESSDTS", AV19LocationAmenitiesSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONAMENITIESSDTS", AV19LocationAmenitiesSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLOCATIONAMENITIESSDTS", GetSecureSignedToken( sPrefix, AV19LocationAmenitiesSDTs, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCUSTOMERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10CustomerId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5LocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV23WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV23WizardData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMYCUSTOMER", AV6MyCustomer);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMYCUSTOMER", AV6MyCustomer);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMYCUSTOMER", GetSecureSignedToken( sPrefix, AV6MyCustomer, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV20PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV13GoingBack);
      }

      protected void RenderHtmlCloseForm3V2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "UpdateLocationStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Update Location Step2", "") ;
      }

      protected void WB3V0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "updatelocationstep2.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", "", "", "div");
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
            StartGridControl18( ) ;
         }
         if ( wbEnd == 18 )
         {
            wbEnd = 0;
            nRC_GXsfl_18 = (int)(nGXsfl_18_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV24GXV1 = nGXsfl_18_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grids", GridsContainer, subGrids_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData", GridsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData"+"V", GridsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(18), 2, 0)+","+"null"+");", context.GetMessage( "GXM_previous", ""), bttBtnwizardprevious_Jsonclick, 5, context.GetMessage( "GXM_previous", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDPREVIOUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UpdateLocationStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardlastnext_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(18), 2, 0)+","+"null"+");", context.GetMessage( "WWP_WizardFinishCaption", ""), bttBtnwizardlastnext_Jsonclick, 5, context.GetMessage( "WWP_WizardFinishCaption", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_UpdateLocationStep2.htm");
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
         if ( wbEnd == 18 )
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
                  AV24GXV1 = nGXsfl_18_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grids", GridsContainer, subGrids_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData", GridsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData"+"V", GridsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3V2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Update Location Step2", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP3V0( ) ;
            }
         }
      }

      protected void WS3V2( )
      {
         START3V2( ) ;
         EVT3V2( ) ;
      }

      protected void EVT3V2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E113V2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E123V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRIDS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'DOFINISH'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              nGXsfl_18_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
                              SubsflControlProps_182( ) ;
                              AV24GXV1 = nGXsfl_18_idx;
                              if ( ( AV19LocationAmenitiesSDTs.Count >= AV24GXV1 ) && ( AV24GXV1 > 0 ) )
                              {
                                 AV19LocationAmenitiesSDTs.CurrentItem = ((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E133V2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Grids.Load */
                                          E143V2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOFINISH'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: 'DoFinish' */
                                          E153V2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3V0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
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

      protected void WE3V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3V2( ) ;
            }
         }
      }

      protected void PA3V2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_182( ) ;
         while ( nGXsfl_18_idx <= nRC_GXsfl_18 )
         {
            sendrow_182( ) ;
            nGXsfl_18_idx = ((subGrids_Islastpage==1)&&(nGXsfl_18_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( GXBaseCollection<SdtLocationAmenitiesSDT> AV19LocationAmenitiesSDTs ,
                                        bool AV15HasValidationErrors ,
                                        short AV10CustomerId ,
                                        SdtCustomer AV6MyCustomer ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF3V2( ) ;
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
         RF3V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavLocationamenitiessdts__amenitiesname_Enabled = 0;
      }

      protected void RF3V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 18;
         nGXsfl_18_idx = 1;
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         bGXsfl_18_Refreshing = true;
         GridsContainer.AddObjectProperty("GridName", "Grids");
         GridsContainer.AddObjectProperty("CmpContext", sPrefix);
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
            SubsflControlProps_182( ) ;
            /* Execute user event: Grids.Load */
            E143V2 ();
            wbEnd = 18;
            WB3V0( ) ;
         }
         bGXsfl_18_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3V2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONAMENITIESSDTS", AV19LocationAmenitiesSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONAMENITIESSDTS", AV19LocationAmenitiesSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLOCATIONAMENITIESSDTS", GetSecureSignedToken( sPrefix, AV19LocationAmenitiesSDTs, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCUSTOMERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10CustomerId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMYCUSTOMER", AV6MyCustomer);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMYCUSTOMER", AV6MyCustomer);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMYCUSTOMER", GetSecureSignedToken( sPrefix, AV6MyCustomer, context));
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
         edtavLocationamenitiessdts__amenitiesname_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133V2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Locationamenitiessdts"), AV19LocationAmenitiesSDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLOCATIONAMENITIESSDTS"), AV19LocationAmenitiesSDTs);
            /* Read saved values. */
            nRC_GXsfl_18 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_18"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV22WebSessionKey = cgiGet( sPrefix+"wcpOAV22WebSessionKey");
            wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
            wcpOAV13GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV13GoingBack"));
            wcpOAV5LocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5LocationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_18 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_18"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_18_fel_idx = 0;
            while ( nGXsfl_18_fel_idx < nRC_GXsfl_18 )
            {
               nGXsfl_18_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_18_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_fel_idx+1);
               sGXsfl_18_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_182( ) ;
               AV24GXV1 = nGXsfl_18_fel_idx;
               if ( ( AV19LocationAmenitiesSDTs.Count >= AV24GXV1 ) && ( AV24GXV1 > 0 ) )
               {
                  AV19LocationAmenitiesSDTs.CurrentItem = ((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1));
               }
            }
            if ( nGXsfl_18_fel_idx == 0 )
            {
               nGXsfl_18_idx = 1;
               sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
               SubsflControlProps_182( ) ;
            }
            nGXsfl_18_fel_idx = 1;
            /* Read variables values. */
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
         E133V2 ();
         if (returnInSub) return;
      }

      protected void E133V2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavLocationamenitiessdts__amenitiesid_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationamenitiessdts__amenitiesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationamenitiessdts__amenitiesid_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavLocationamenitiessdts__amenitiestypeid_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationamenitiessdts__amenitiestypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationamenitiessdts__amenitiestypeid_Visible), 5, 0), !bGXsfl_18_Refreshing);
         edtavLocationamenitiessdts__amenitiestypename_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationamenitiessdts__amenitiestypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationamenitiessdts__amenitiestypename_Visible), 5, 0), !bGXsfl_18_Refreshing);
         GXt_int1 = AV10CustomerId;
         new getloggedinusercustomerid(context ).execute( out  GXt_int1) ;
         AV10CustomerId = GXt_int1;
         AssignAttri(sPrefix, false, "AV10CustomerId", StringUtil.LTrimStr( (decimal)(AV10CustomerId), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCUSTOMERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10CustomerId), "ZZZ9"), context));
         /* Execute user subroutine: 'LOADAMENITIESGRID' */
         S122 ();
         if (returnInSub) return;
      }

      private void E143V2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV19LocationAmenitiesSDTs.Count )
         {
            AV19LocationAmenitiesSDTs.CurrentItem = ((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 18;
            }
            sendrow_182( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_18_Refreshing )
            {
               DoAjaxLoad(18, GridsRow);
            }
            AV24GXV1 = (int)(AV24GXV1+1);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E113V2 ();
         if (returnInSub) return;
      }

      protected void E113V2( )
      {
         AV24GXV1 = nGXsfl_18_idx;
         if ( ( AV24GXV1 > 0 ) && ( AV19LocationAmenitiesSDTs.Count >= AV24GXV1 ) )
         {
            AV19LocationAmenitiesSDTs.CurrentItem = ((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV15HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV21WebSession.Remove(AV22WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23WizardData", AV23WizardData);
      }

      protected void E123V2( )
      {
         AV24GXV1 = nGXsfl_18_idx;
         if ( ( AV24GXV1 > 0 ) && ( AV19LocationAmenitiesSDTs.Count >= AV24GXV1 ) )
         {
            AV19LocationAmenitiesSDTs.CurrentItem = ((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         CallWebObject(formatLink("updatelocation.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.RTrim("Step1")),UrlEncode(StringUtil.BoolToStr(true)),UrlEncode(StringUtil.LTrimStr(AV5LocationId,4,0))}, new string[] {"PreviousStep","CurrentStep","GoingBack","LocationId"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23WizardData", AV23WizardData);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV23WizardData.FromJSonString(AV21WebSession.Get(AV22WebSessionKey), null);
         AV19LocationAmenitiesSDTs = AV23WizardData.gxTpr_Step2.gxTpr_Locationamenitiessdts;
         gx_BV18 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV23WizardData.FromJSonString(AV21WebSession.Get(AV22WebSessionKey), null);
         AV23WizardData.gxTpr_Step2.gxTpr_Locationamenitiessdts = AV19LocationAmenitiesSDTs;
         AV21WebSession.Set(AV22WebSessionKey, AV23WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV9Customer.Load(AV10CustomerId);
         GX_msglist.addItem(AV9Customer.gxTpr_Customername);
         AV11CustomerLocation = AV9Customer.gxTpr_Locations.GetByKey(AV5LocationId);
         AV11CustomerLocation.gxTpr_Customerlocationemail = AV23WizardData.gxTpr_Step1.gxTpr_Customerlocationemail;
         AV11CustomerLocation.gxTpr_Customerlocationphone = AV23WizardData.gxTpr_Step1.gxTpr_Customerlocationphone;
         AV11CustomerLocation.gxTpr_Customerlocationpostaladdress = AV23WizardData.gxTpr_Step1.gxTpr_Customerlocationpostaladdress;
         AV11CustomerLocation.gxTpr_Customerlocationvisitingaddress = AV23WizardData.gxTpr_Step1.gxTpr_Customerlocationvisitingaddress;
         AV11CustomerLocation.gxTpr_Customerlocationname = AV23WizardData.gxTpr_Step1.gxTpr_Customerlocationname;
         AV11CustomerLocation.gxTpr_Customerlocationdescription = AV23WizardData.gxTpr_Step1.gxTpr_Customerlocationdescription;
         GX_msglist.addItem(AV11CustomerLocation.gxTpr_Customerlocationname);
         AV11CustomerLocation.gxTpr_Amenities.Clear();
         AV30GXV7 = 1;
         while ( AV30GXV7 <= AV19LocationAmenitiesSDTs.Count )
         {
            AV18LocationAmenitiesSDT = ((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV30GXV7));
            if ( AV18LocationAmenitiesSDT.gxTpr_Selected )
            {
               AV7AmenityBC = new SdtCustomer_Locations_Amenities(context);
               AV7AmenityBC.gxTpr_Amenitiesid = AV18LocationAmenitiesSDT.gxTpr_Amenitiesid;
               AV11CustomerLocation.gxTpr_Amenities.Add(AV7AmenityBC, 0);
            }
            AV30GXV7 = (int)(AV30GXV7+1);
         }
         new logtofile(context ).execute(  AV11CustomerLocation.gxTpr_Amenities.ToJSonString(true)) ;
         AV9Customer.Save();
         if ( AV9Customer.Success() )
         {
            context.CommitDataStores("updatelocationstep2",pr_default);
            AV21WebSession.Remove(AV22WebSessionKey);
            CallWebObject(formatLink("customerlocations.aspx") );
            context.wjLocDisableFrm = 1;
            GX_msglist.addItem(context.GetMessage( "Update Successful", ""));
         }
         else
         {
            context.RollbackDataStores("updatelocationstep2",pr_default);
            AV12ErrorMessages = AV6MyCustomer.GetMessages();
            GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV12ErrorMessages.Item(1)).gxTpr_Description);
         }
      }

      protected void E153V2( )
      {
         AV24GXV1 = nGXsfl_18_idx;
         if ( ( AV24GXV1 > 0 ) && ( AV19LocationAmenitiesSDTs.Count >= AV24GXV1 ) )
         {
            AV19LocationAmenitiesSDTs.CurrentItem = ((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1));
         }
         /* 'DoFinish' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'FINISHWIZARD' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S122( )
      {
         /* 'LOADAMENITIESGRID' Routine */
         returnInSub = false;
         AV19LocationAmenitiesSDTs.Clear();
         gx_BV18 = true;
         /* Using cursor H003V2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A98AmenitiesId = H003V2_A98AmenitiesId[0];
            A101AmenitiesName = H003V2_A101AmenitiesName[0];
            A99AmenitiesTypeId = H003V2_A99AmenitiesTypeId[0];
            AV18LocationAmenitiesSDT = new SdtLocationAmenitiesSDT(context);
            AV18LocationAmenitiesSDT.gxTpr_Amenitiesid = A98AmenitiesId;
            AV18LocationAmenitiesSDT.gxTpr_Amenitiesname = A101AmenitiesName;
            AV18LocationAmenitiesSDT.gxTpr_Selected = false;
            AV18LocationAmenitiesSDT.gxTpr_Amenitiestypeid = A99AmenitiesTypeId;
            AV19LocationAmenitiesSDTs.Add(AV18LocationAmenitiesSDT, 0);
            gx_BV18 = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor H003V3 */
         pr_default.execute(1, new Object[] {AV10CustomerId, AV5LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A18CustomerLocationId = H003V3_A18CustomerLocationId[0];
            A1CustomerId = H003V3_A1CustomerId[0];
            A98AmenitiesId = H003V3_A98AmenitiesId[0];
            AV17LocationAmenitiesCollection.Add(A98AmenitiesId, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV33GXV8 = 1;
         while ( AV33GXV8 <= AV19LocationAmenitiesSDTs.Count )
         {
            AV18LocationAmenitiesSDT = ((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV33GXV8));
            if ( (AV17LocationAmenitiesCollection.IndexOf(AV18LocationAmenitiesSDT.gxTpr_Amenitiesid)>0) )
            {
               AV18LocationAmenitiesSDT.gxTpr_Selected = true;
            }
            AV33GXV8 = (int)(AV33GXV8+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV22WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV22WebSessionKey", AV22WebSessionKey);
         AV20PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
         AV13GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV13GoingBack", AV13GoingBack);
         AV5LocationId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV5LocationId", StringUtil.LTrimStr( (decimal)(AV5LocationId), 4, 0));
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
         PA3V2( ) ;
         WS3V2( ) ;
         WE3V2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV22WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV20PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV13GoingBack = (string)((string)getParm(obj,2));
         sCtrlAV5LocationId = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3V2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "updatelocationstep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3V2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV22WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV22WebSessionKey", AV22WebSessionKey);
            AV20PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
            AV13GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV13GoingBack", AV13GoingBack);
            AV5LocationId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV5LocationId", StringUtil.LTrimStr( (decimal)(AV5LocationId), 4, 0));
         }
         wcpOAV22WebSessionKey = cgiGet( sPrefix+"wcpOAV22WebSessionKey");
         wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
         wcpOAV13GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV13GoingBack"));
         wcpOAV5LocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV5LocationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV22WebSessionKey, wcpOAV22WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV20PreviousStep, wcpOAV20PreviousStep) != 0 ) || ( AV13GoingBack != wcpOAV13GoingBack ) || ( AV5LocationId != wcpOAV5LocationId ) ) )
         {
            setjustcreated();
         }
         wcpOAV22WebSessionKey = AV22WebSessionKey;
         wcpOAV20PreviousStep = AV20PreviousStep;
         wcpOAV13GoingBack = AV13GoingBack;
         wcpOAV5LocationId = AV5LocationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV22WebSessionKey = cgiGet( sPrefix+"AV22WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV22WebSessionKey) > 0 )
         {
            AV22WebSessionKey = cgiGet( sCtrlAV22WebSessionKey);
            AssignAttri(sPrefix, false, "AV22WebSessionKey", AV22WebSessionKey);
         }
         else
         {
            AV22WebSessionKey = cgiGet( sPrefix+"AV22WebSessionKey_PARM");
         }
         sCtrlAV20PreviousStep = cgiGet( sPrefix+"AV20PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV20PreviousStep) > 0 )
         {
            AV20PreviousStep = cgiGet( sCtrlAV20PreviousStep);
            AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
         }
         else
         {
            AV20PreviousStep = cgiGet( sPrefix+"AV20PreviousStep_PARM");
         }
         sCtrlAV13GoingBack = cgiGet( sPrefix+"AV13GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV13GoingBack) > 0 )
         {
            AV13GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV13GoingBack));
            AssignAttri(sPrefix, false, "AV13GoingBack", AV13GoingBack);
         }
         else
         {
            AV13GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV13GoingBack_PARM"));
         }
         sCtrlAV5LocationId = cgiGet( sPrefix+"AV5LocationId_CTRL");
         if ( StringUtil.Len( sCtrlAV5LocationId) > 0 )
         {
            AV5LocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV5LocationId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV5LocationId", StringUtil.LTrimStr( (decimal)(AV5LocationId), 4, 0));
         }
         else
         {
            AV5LocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV5LocationId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA3V2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS3V2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV22WebSessionKey_PARM", AV22WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV22WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV22WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV22WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_PARM", AV20PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV20PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV13GoingBack_PARM", StringUtil.BoolToStr( AV13GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV13GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV13GoingBack_CTRL", StringUtil.RTrim( sCtrlAV13GoingBack));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV5LocationId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5LocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5LocationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5LocationId_CTRL", StringUtil.RTrim( sCtrlAV5LocationId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE3V2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249131552140", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("updatelocationstep2.js", "?20249131552140", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_182( )
      {
         chkavLocationamenitiessdts__selected_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__SELECTED_"+sGXsfl_18_idx;
         edtavLocationamenitiessdts__amenitiesname_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESNAME_"+sGXsfl_18_idx;
         edtavLocationamenitiessdts__amenitiesid_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESID_"+sGXsfl_18_idx;
         edtavLocationamenitiessdts__amenitiestypeid_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESTYPEID_"+sGXsfl_18_idx;
         edtavLocationamenitiessdts__amenitiestypename_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESTYPENAME_"+sGXsfl_18_idx;
      }

      protected void SubsflControlProps_fel_182( )
      {
         chkavLocationamenitiessdts__selected_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__SELECTED_"+sGXsfl_18_fel_idx;
         edtavLocationamenitiessdts__amenitiesname_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESNAME_"+sGXsfl_18_fel_idx;
         edtavLocationamenitiessdts__amenitiesid_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESID_"+sGXsfl_18_fel_idx;
         edtavLocationamenitiessdts__amenitiestypeid_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESTYPEID_"+sGXsfl_18_fel_idx;
         edtavLocationamenitiessdts__amenitiestypename_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESTYPENAME_"+sGXsfl_18_fel_idx;
      }

      protected void sendrow_182( )
      {
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         WB3V0( ) ;
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
            if ( ((int)((nGXsfl_18_idx) % (2))) == 0 )
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
            context.WriteHtmlText( "<tr"+" class=\""+subGrids_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_18_idx+"\">") ;
         }
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGridslayouttable_Internalname+"_"+sGXsfl_18_idx,(short)1,(short)100,(string)"%",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)" "+"data-gx-smarttable"+" ",(string)"grid-template-columns:30px 100fr;grid-template-rows:auto auto;",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)" "+"data-gx-smarttable-cell"+" ",(string)"",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavLocationamenitiessdts__selected_Internalname,context.GetMessage( "Selected", ""),(string)"gx-form-item AttributeCheckBoxLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GXCCtl = "LOCATIONAMENITIESSDTS__SELECTED_" + sGXsfl_18_idx;
         chkavLocationamenitiessdts__selected.Name = GXCCtl;
         chkavLocationamenitiessdts__selected.WebTags = "";
         chkavLocationamenitiessdts__selected.Caption = context.GetMessage( "Selected", "");
         AssignProp(sPrefix, false, chkavLocationamenitiessdts__selected_Internalname, "TitleCaption", chkavLocationamenitiessdts__selected.Caption, !bGXsfl_18_Refreshing);
         chkavLocationamenitiessdts__selected.CheckedValue = "false";
         GridsRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavLocationamenitiessdts__selected_Internalname,StringUtil.BoolToStr( ((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1)).gxTpr_Selected),(string)"",context.GetMessage( "Selected", ""),(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(22, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,22);\""});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)" "+"data-gx-smarttable-cell"+" ",(string)"display:flex;align-items:end;",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiesname_Internalname,context.GetMessage( "Amenities Name", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
         ROClassString = "Attribute";
         GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiesname_Internalname,((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1)).gxTpr_Amenitiesname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationamenitiessdts__amenitiesname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavLocationamenitiessdts__amenitiesname_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Invisible",(string)"start",(string)"top",(string)" "+"data-gx-smarttable-cell"+" ",(string)"",(string)"div"});
         /* Table start */
         GridsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrids_Internalname+"_"+sGXsfl_18_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiesid_Internalname,context.GetMessage( "Amenities Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
         ROClassString = "Attribute";
         GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiesid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1)).gxTpr_Amenitiesid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1)).gxTpr_Amenitiesid), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,31);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationamenitiessdts__amenitiesid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavLocationamenitiessdts__amenitiesid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( GridsContainer.GetWrapped() == 1 )
         {
            GridsContainer.CloseTag("cell");
         }
         GridsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiestypeid_Internalname,context.GetMessage( "Amenities Type Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
         ROClassString = "Attribute";
         GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiestypeid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1)).gxTpr_Amenitiestypeid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1)).gxTpr_Amenitiestypeid), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationamenitiessdts__amenitiestypeid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavLocationamenitiessdts__amenitiestypeid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         GridsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( GridsContainer.GetWrapped() == 1 )
         {
            GridsContainer.CloseTag("cell");
         }
         GridsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiestypename_Internalname,context.GetMessage( "Amenities Type Name", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
         ROClassString = "Attribute";
         GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationamenitiessdts__amenitiestypename_Internalname,((SdtLocationAmenitiesSDT)AV19LocationAmenitiesSDTs.Item(AV24GXV1)).gxTpr_Amenitiestypename,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationamenitiessdts__amenitiestypename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavLocationamenitiessdts__amenitiestypename_Visible,(short)1,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
         send_integrity_lvl_hashes3V2( ) ;
         /* End of Columns property logic. */
         GridsContainer.AddRow(GridsRow);
         nGXsfl_18_idx = ((subGrids_Islastpage==1)&&(nGXsfl_18_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         /* End function sendrow_182 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "LOCATIONAMENITIESSDTS__SELECTED_" + sGXsfl_18_idx;
         chkavLocationamenitiessdts__selected.Name = GXCCtl;
         chkavLocationamenitiessdts__selected.WebTags = "";
         chkavLocationamenitiessdts__selected.Caption = context.GetMessage( "Selected", "");
         AssignProp(sPrefix, false, chkavLocationamenitiessdts__selected_Internalname, "TitleCaption", chkavLocationamenitiessdts__selected.Caption, !bGXsfl_18_Refreshing);
         chkavLocationamenitiessdts__selected.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl18( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"18\">") ;
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
            GridsContainer.AddObjectProperty("CmpContext", sPrefix);
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
            GridsColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationamenitiessdts__amenitiestypeid_Visible), 5, 0, ".", "")));
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
            GridsColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationamenitiessdts__amenitiestypename_Visible), 5, 0, ".", "")));
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
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         chkavLocationamenitiessdts__selected_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__SELECTED";
         edtavLocationamenitiessdts__amenitiesname_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESNAME";
         edtavLocationamenitiessdts__amenitiesid_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESID";
         edtavLocationamenitiessdts__amenitiestypeid_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESTYPEID";
         edtavLocationamenitiessdts__amenitiestypename_Internalname = sPrefix+"LOCATIONAMENITIESSDTS__AMENITIESTYPENAME";
         tblUnnamedtablecontentfsgrids_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRIDS";
         divGridslayouttable_Internalname = sPrefix+"GRIDSLAYOUTTABLE";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         bttBtnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         bttBtnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrids_Internalname = sPrefix+"GRIDS";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrids_Allowcollapsing = 0;
         edtavLocationamenitiessdts__amenitiestypename_Jsonclick = "";
         edtavLocationamenitiessdts__amenitiestypename_Visible = 1;
         edtavLocationamenitiessdts__amenitiestypeid_Jsonclick = "";
         edtavLocationamenitiessdts__amenitiestypeid_Visible = 1;
         edtavLocationamenitiessdts__amenitiesid_Jsonclick = "";
         edtavLocationamenitiessdts__amenitiesid_Visible = 1;
         edtavLocationamenitiessdts__amenitiesname_Jsonclick = "";
         edtavLocationamenitiessdts__amenitiesname_Enabled = 0;
         chkavLocationamenitiessdts__selected.Caption = context.GetMessage( "Selected", "");
         subGrids_Class = "FreeStyleGrid";
         subGrids_Backcolorstyle = 0;
         edtavLocationamenitiessdts__amenitiesname_Enabled = -1;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"sPrefix"},{"av":"AV19LocationAmenitiesSDTs","fld":"vLOCATIONAMENITIESSDTS","grid":18,"hsh":true},{"av":"nGXsfl_18_idx","ctrl":"GRID","prop":"GridCurrRow","grid":18},{"av":"nRC_GXsfl_18","ctrl":"GRIDS","prop":"GridRC","grid":18},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV10CustomerId","fld":"vCUSTOMERID","pic":"ZZZ9","hsh":true},{"av":"AV6MyCustomer","fld":"vMYCUSTOMER","hsh":true}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E143V2","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E113V2","iparms":[{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV22WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV19LocationAmenitiesSDTs","fld":"vLOCATIONAMENITIESSDTS","grid":18,"hsh":true},{"av":"nGXsfl_18_idx","ctrl":"GRID","prop":"GridCurrRow","grid":18},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_18","ctrl":"GRIDS","prop":"GridRC","grid":18},{"av":"AV10CustomerId","fld":"vCUSTOMERID","pic":"ZZZ9","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","pic":"ZZZ9"},{"av":"AV23WizardData","fld":"vWIZARDDATA"},{"av":"AV6MyCustomer","fld":"vMYCUSTOMER","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV23WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E123V2","iparms":[{"av":"AV5LocationId","fld":"vLOCATIONID","pic":"ZZZ9"},{"av":"AV22WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV19LocationAmenitiesSDTs","fld":"vLOCATIONAMENITIESSDTS","grid":18,"hsh":true},{"av":"nGXsfl_18_idx","ctrl":"GRID","prop":"GridCurrRow","grid":18},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_18","ctrl":"GRIDS","prop":"GridRC","grid":18}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV5LocationId","fld":"vLOCATIONID","pic":"ZZZ9"},{"av":"AV23WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOFINISH'","""{"handler":"E153V2","iparms":[{"av":"AV10CustomerId","fld":"vCUSTOMERID","pic":"ZZZ9","hsh":true},{"av":"AV5LocationId","fld":"vLOCATIONID","pic":"ZZZ9"},{"av":"AV23WizardData","fld":"vWIZARDDATA"},{"av":"AV19LocationAmenitiesSDTs","fld":"vLOCATIONAMENITIESSDTS","grid":18,"hsh":true},{"av":"nGXsfl_18_idx","ctrl":"GRID","prop":"GridCurrRow","grid":18},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_18","ctrl":"GRIDS","prop":"GridRC","grid":18},{"av":"AV22WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV6MyCustomer","fld":"vMYCUSTOMER","hsh":true}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv6","iparms":[]}""");
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
         wcpOAV22WebSessionKey = "";
         wcpOAV20PreviousStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV19LocationAmenitiesSDTs = new GXBaseCollection<SdtLocationAmenitiesSDT>( context, "LocationAmenitiesSDT", "");
         AV6MyCustomer = new SdtCustomer(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV23WizardData = new SdtUpdateLocationData(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         TempTags = "";
         bttBtnwizardprevious_Jsonclick = "";
         bttBtnwizardlastnext_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GridsRow = new GXWebRow();
         AV21WebSession = context.GetSession();
         AV9Customer = new SdtCustomer(context);
         AV11CustomerLocation = new SdtCustomer_Locations(context);
         AV18LocationAmenitiesSDT = new SdtLocationAmenitiesSDT(context);
         AV7AmenityBC = new SdtCustomer_Locations_Amenities(context);
         AV12ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         H003V2_A98AmenitiesId = new short[1] ;
         H003V2_A101AmenitiesName = new string[] {""} ;
         H003V2_A99AmenitiesTypeId = new short[1] ;
         A101AmenitiesName = "";
         H003V3_A18CustomerLocationId = new short[1] ;
         H003V3_A1CustomerId = new short[1] ;
         H003V3_A98AmenitiesId = new short[1] ;
         AV17LocationAmenitiesCollection = new GxSimpleCollection<short>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV22WebSessionKey = "";
         sCtrlAV20PreviousStep = "";
         sCtrlAV13GoingBack = "";
         sCtrlAV5LocationId = "";
         subGrids_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         subGrids_Header = "";
         GridsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.updatelocationstep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.updatelocationstep2__default(),
            new Object[][] {
                new Object[] {
               H003V2_A98AmenitiesId, H003V2_A101AmenitiesName, H003V2_A99AmenitiesTypeId
               }
               , new Object[] {
               H003V3_A18CustomerLocationId, H003V3_A1CustomerId, H003V3_A98AmenitiesId
               }
            }
         );
         /* GeneXus formulas. */
         edtavLocationamenitiessdts__amenitiesname_Enabled = 0;
      }

      private short AV5LocationId ;
      private short wcpOAV5LocationId ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV10CustomerId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short GXt_int1 ;
      private short A98AmenitiesId ;
      private short A99AmenitiesTypeId ;
      private short A18CustomerLocationId ;
      private short A1CustomerId ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private short GRIDS_nEOF ;
      private int nRC_GXsfl_18 ;
      private int nGXsfl_18_idx=1 ;
      private int edtavLocationamenitiessdts__amenitiesname_Enabled ;
      private int AV24GXV1 ;
      private int subGrids_Islastpage ;
      private int nGXsfl_18_fel_idx=1 ;
      private int edtavLocationamenitiessdts__amenitiesid_Visible ;
      private int edtavLocationamenitiessdts__amenitiestypeid_Visible ;
      private int edtavLocationamenitiessdts__amenitiestypename_Visible ;
      private int AV30GXV7 ;
      private int AV33GXV8 ;
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
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_18_idx="0001" ;
      private string edtavLocationamenitiessdts__amenitiesname_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablefilters_Internalname ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string bttBtnwizardprevious_Internalname ;
      private string bttBtnwizardprevious_Jsonclick ;
      private string bttBtnwizardlastnext_Internalname ;
      private string bttBtnwizardlastnext_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sGXsfl_18_fel_idx="0001" ;
      private string edtavLocationamenitiessdts__amenitiesid_Internalname ;
      private string edtavLocationamenitiessdts__amenitiestypeid_Internalname ;
      private string edtavLocationamenitiessdts__amenitiestypename_Internalname ;
      private string sCtrlAV22WebSessionKey ;
      private string sCtrlAV20PreviousStep ;
      private string sCtrlAV13GoingBack ;
      private string sCtrlAV5LocationId ;
      private string chkavLocationamenitiessdts__selected_Internalname ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string divGridslayouttable_Internalname ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavLocationamenitiessdts__amenitiesname_Jsonclick ;
      private string tblUnnamedtablecontentfsgrids_Internalname ;
      private string edtavLocationamenitiessdts__amenitiesid_Jsonclick ;
      private string edtavLocationamenitiessdts__amenitiestypeid_Jsonclick ;
      private string edtavLocationamenitiessdts__amenitiestypename_Jsonclick ;
      private string subGrids_Header ;
      private bool AV13GoingBack ;
      private bool wcpOAV13GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15HasValidationErrors ;
      private bool bGXsfl_18_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV18 ;
      private string AV22WebSessionKey ;
      private string AV20PreviousStep ;
      private string wcpOAV22WebSessionKey ;
      private string wcpOAV20PreviousStep ;
      private string A101AmenitiesName ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXWebForm Form ;
      private IGxSession AV21WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP3_LocationId ;
      private GXCheckbox chkavLocationamenitiessdts__selected ;
      private GXBaseCollection<SdtLocationAmenitiesSDT> AV19LocationAmenitiesSDTs ;
      private SdtCustomer AV6MyCustomer ;
      private SdtUpdateLocationData AV23WizardData ;
      private SdtCustomer AV9Customer ;
      private SdtCustomer_Locations AV11CustomerLocation ;
      private SdtLocationAmenitiesSDT AV18LocationAmenitiesSDT ;
      private SdtCustomer_Locations_Amenities AV7AmenityBC ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12ErrorMessages ;
      private short[] H003V2_A98AmenitiesId ;
      private string[] H003V2_A101AmenitiesName ;
      private short[] H003V2_A99AmenitiesTypeId ;
      private short[] H003V3_A18CustomerLocationId ;
      private short[] H003V3_A1CustomerId ;
      private short[] H003V3_A98AmenitiesId ;
      private GxSimpleCollection<short> AV17LocationAmenitiesCollection ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class updatelocationstep2__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class updatelocationstep2__default : DataStoreHelperBase, IDataStoreHelper
 {
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
        Object[] prmH003V2;
        prmH003V2 = new Object[] {
        };
        Object[] prmH003V3;
        prmH003V3 = new Object[] {
        new ParDef("AV10CustomerId",GXType.Int16,4,0) ,
        new ParDef("AV5LocationId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("H003V2", "SELECT AmenitiesId, AmenitiesName, AmenitiesTypeId FROM Amenities ORDER BY AmenitiesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003V2,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("H003V3", "SELECT CustomerLocationId, CustomerId, AmenitiesId FROM CustomerLocationsAmenities WHERE CustomerId = :AV10CustomerId and CustomerLocationId = :AV5LocationId ORDER BY CustomerId, CustomerLocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003V3,100, GxCacheFrequency.OFF ,false,false )
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
              return;
     }
  }

}

}
