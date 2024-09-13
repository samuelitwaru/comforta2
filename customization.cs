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
   public class customization : GXDataArea
   {
      public customization( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customization( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           short aP1_CustomerCustomizationId )
      {
         this.AV10TrnMode = aP0_TrnMode;
         this.AV14CustomerCustomizationId = aP1_CustomerCustomizationId;
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
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
               AV10TrnMode = gxfirstwebparm;
               AssignAttri("", false, "AV10TrnMode", AV10TrnMode);
               GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14CustomerCustomizationId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerCustomizationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(AV14CustomerCustomizationId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERCUSTOMIZATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14CustomerCustomizationId), "ZZZ9"), context));
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
            return "customization_Execute" ;
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
         PA3N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3N2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("customization.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10TrnMode)),UrlEncode(StringUtil.LTrimStr(AV14CustomerCustomizationId,4,0))}, new string[] {"TrnMode","CustomerCustomizationId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vCUSTOMERCUSTOMIZATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14CustomerCustomizationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERCUSTOMIZATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14CustomerCustomizationId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Customercustomization", AV7CustomerCustomization);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Customercustomization", AV7CustomerCustomization);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV12CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV9Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV9Messages);
         }
         GxWebStd.gx_hidden_field( context, "vCUSTOMERCUSTOMIZATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14CustomerCustomizationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERCUSTOMIZATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14CustomerCustomizationId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUSTOMERCUSTOMIZATION", AV7CustomerCustomization);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUSTOMERCUSTOMIZATION", AV7CustomerCustomization);
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
            WE3N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3N2( ) ;
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
         return formatLink("customization.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10TrnMode)),UrlEncode(StringUtil.LTrimStr(AV14CustomerCustomizationId,4,0))}, new string[] {"TrnMode","CustomerCustomizationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Customization" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Customization", "") ;
      }

      protected void WB3N0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, divTablecontent_Width, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "", 1, 0, "px", 0, "px", "Group", "", "HLP_Customization.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableform_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomercustomization_customercustomizationid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomercustomization_customercustomizationid_Internalname, context.GetMessage( "Customization Id", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomercustomization_customercustomizationid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerCustomization.gxTpr_Customercustomizationid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCustomercustomization_customercustomizationid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7CustomerCustomization.gxTpr_Customercustomizationid), "ZZZ9") : context.localUtil.Format( (decimal)(AV7CustomerCustomization.gxTpr_Customercustomizationid), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomercustomization_customercustomizationid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomercustomization_customercustomizationid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Customization.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgavCustomercustomization_customercustomizationlogo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Customization Logo", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute" + " " + ((StringUtil.StrCmp(imgavCustomercustomization_customercustomizationlogo_gximage, "")==0) ? "" : "GX_Image_"+imgavCustomercustomization_customercustomizationlogo_gximage+"_Class");
            StyleString = "";
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV7CustomerCustomization.gxTpr_Customercustomizationlogo)) ? AV7CustomerCustomization.gxTpr_Customercustomizationlogo_gxi : context.PathToRelativeUrl( AV7CustomerCustomization.gxTpr_Customercustomizationlogo));
            GxWebStd.gx_bitmap( context, imgavCustomercustomization_customercustomizationlogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgavCustomercustomization_customercustomizationlogo_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Customization.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgavCustomercustomization_customercustomizationfavicon_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Customization Favicon", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute" + " " + ((StringUtil.StrCmp(imgavCustomercustomization_customercustomizationfavicon_gximage, "")==0) ? "" : "GX_Image_"+imgavCustomercustomization_customercustomizationfavicon_gximage+"_Class");
            StyleString = "";
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV7CustomerCustomization.gxTpr_Customercustomizationfavicon)) ? AV7CustomerCustomization.gxTpr_Customercustomizationfavicon_gxi : context.PathToRelativeUrl( AV7CustomerCustomization.gxTpr_Customercustomizationfavicon));
            GxWebStd.gx_bitmap( context, imgavCustomercustomization_customercustomizationfavicon_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgavCustomercustomization_customercustomizationfavicon_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Customization.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomercustomization_customercustomizationbasecolor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomercustomization_customercustomizationbasecolor_Internalname, context.GetMessage( "Base Color", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomercustomization_customercustomizationbasecolor_Internalname, AV7CustomerCustomization.gxTpr_Customercustomizationbasecolor, StringUtil.RTrim( context.localUtil.Format( AV7CustomerCustomization.gxTpr_Customercustomizationbasecolor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomercustomization_customercustomizationbasecolor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomercustomization_customercustomizationbasecolor_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Customization.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomercustomization_customercustomizationfontsize_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomercustomization_customercustomizationfontsize_Internalname, context.GetMessage( "Font Size", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomercustomization_customercustomizationfontsize_Internalname, AV7CustomerCustomization.gxTpr_Customercustomizationfontsize, StringUtil.RTrim( context.localUtil.Format( AV7CustomerCustomization.gxTpr_Customercustomizationfontsize, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomercustomization_customercustomizationfontsize_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomercustomization_customercustomizationfontsize_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Customization.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomercustomization_customerid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomercustomization_customerid_Internalname, context.GetMessage( "Customer Id", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomercustomization_customerid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerCustomization.gxTpr_Customerid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7CustomerCustomization.gxTpr_Customerid), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomercustomization_customerid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomercustomization_customerid_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Customization.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomercustomization_customername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomercustomization_customername_Internalname, context.GetMessage( "Customer Name", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomercustomization_customername_Internalname, AV7CustomerCustomization.gxTpr_Customername, StringUtil.RTrim( context.localUtil.Format( AV7CustomerCustomization.gxTpr_Customername, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomercustomization_customername_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomercustomization_customername_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Customization.htm");
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
            GxWebStd.gx_div_start( context, divActionstable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Customization.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Customization.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
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
         wbLoad = true;
      }

      protected void START3N2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Customization", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3N0( ) ;
      }

      protected void WS3N2( )
      {
         START3N2( ) ;
         EVT3N2( ) ;
      }

      protected void EVT3N2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E113N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E123N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E133N2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E143N2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3N2( )
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

      protected void PA3N2( )
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
               GX_FocusControl = edtavCustomercustomization_customercustomizationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         RF3N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavCustomercustomization_customercustomizationid_Enabled = 0;
         AssignProp("", false, edtavCustomercustomization_customercustomizationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomercustomization_customercustomizationid_Enabled), 5, 0), true);
         edtavCustomercustomization_customername_Enabled = 0;
         AssignProp("", false, edtavCustomercustomization_customername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomercustomization_customername_Enabled), 5, 0), true);
      }

      protected void RF3N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E123N2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E143N2 ();
            WB3N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3N2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavCustomercustomization_customercustomizationid_Enabled = 0;
         AssignProp("", false, edtavCustomercustomization_customercustomizationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomercustomization_customercustomizationid_Enabled), 5, 0), true);
         edtavCustomercustomization_customername_Enabled = 0;
         AssignProp("", false, edtavCustomercustomization_customername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomercustomization_customername_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vCUSTOMERCUSTOMIZATION"), AV7CustomerCustomization);
            ajax_req_read_hidden_sdt(cgiGet( "Customercustomization"), AV7CustomerCustomization);
            /* Read saved values. */
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCustomercustomization_customercustomizationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCustomercustomization_customercustomizationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUSTOMERCUSTOMIZATION_CUSTOMERCUSTOMIZATIONID");
               GX_FocusControl = edtavCustomercustomization_customercustomizationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7CustomerCustomization.gxTpr_Customercustomizationid = 0;
            }
            else
            {
               AV7CustomerCustomization.gxTpr_Customercustomizationid = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCustomercustomization_customercustomizationid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV7CustomerCustomization.gxTpr_Customercustomizationlogo = cgiGet( imgavCustomercustomization_customercustomizationlogo_Internalname);
            AV7CustomerCustomization.gxTpr_Customercustomizationfavicon = cgiGet( imgavCustomercustomization_customercustomizationfavicon_Internalname);
            AV7CustomerCustomization.gxTpr_Customercustomizationbasecolor = cgiGet( edtavCustomercustomization_customercustomizationbasecolor_Internalname);
            AV7CustomerCustomization.gxTpr_Customercustomizationfontsize = cgiGet( edtavCustomercustomization_customercustomizationfontsize_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCustomercustomization_customerid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCustomercustomization_customerid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUSTOMERCUSTOMIZATION_CUSTOMERID");
               GX_FocusControl = edtavCustomercustomization_customerid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7CustomerCustomization.gxTpr_Customerid = 0;
            }
            else
            {
               AV7CustomerCustomization.gxTpr_Customerid = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCustomercustomization_customerid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV7CustomerCustomization.gxTpr_Customername = cgiGet( edtavCustomercustomization_customername_Internalname);
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
         E113N2 ();
         if (returnInSub) return;
      }

      protected void E113N2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV11LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "INS") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "customercustomization_Insert") ) || ( ( StringUtil.StrCmp(AV10TrnMode, "UPD") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "customercustomization_Update") ) || ( ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context).executeUdp(  "customercustomization_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "INS") != 0 )
            {
               AV7CustomerCustomization.Load(AV14CustomerCustomizationId);
               AV11LoadSuccess = AV7CustomerCustomization.Success();
               if ( ! AV11LoadSuccess )
               {
                  AV9Messages = AV7CustomerCustomization.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) )
               {
                  imgavCustomercustomization_customercustomizationlogo_Enabled = 0;
                  AssignProp("", false, imgavCustomercustomization_customercustomizationlogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgavCustomercustomization_customercustomizationlogo_Enabled), 5, 0), true);
                  imgavCustomercustomization_customercustomizationfavicon_Enabled = 0;
                  AssignProp("", false, imgavCustomercustomization_customercustomizationfavicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgavCustomercustomization_customercustomizationfavicon_Enabled), 5, 0), true);
                  edtavCustomercustomization_customercustomizationbasecolor_Enabled = 0;
                  AssignProp("", false, edtavCustomercustomization_customercustomizationbasecolor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomercustomization_customercustomizationbasecolor_Enabled), 5, 0), true);
                  edtavCustomercustomization_customercustomizationfontsize_Enabled = 0;
                  AssignProp("", false, edtavCustomercustomization_customercustomizationfontsize_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomercustomization_customercustomizationfontsize_Enabled), 5, 0), true);
                  edtavCustomercustomization_customerid_Enabled = 0;
                  AssignProp("", false, edtavCustomercustomization_customerid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomercustomization_customerid_Enabled), 5, 0), true);
               }
            }
         }
         else
         {
            AV11LoadSuccess = false;
            CallWebObject(formatLink("notauthorized.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( AV11LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""));
            }
         }
         divTablecontent_Width = 900;
         AssignProp("", false, divTablecontent_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablecontent_Width), 9, 0), true);
      }

      protected void E123N2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E133N2 ();
         if (returnInSub) return;
      }

      protected void E133N2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV10TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S132 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) || AV12CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 )
               {
                  AV7CustomerCustomization.Delete();
               }
               else
               {
                  AV7CustomerCustomization.Save();
               }
               if ( AV7CustomerCustomization.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S142 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV9Messages = AV7CustomerCustomization.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7CustomerCustomization", AV7CustomerCustomization);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9Messages", AV9Messages);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV22GXV8 = 1;
         while ( AV22GXV8 <= AV9Messages.Count )
         {
            AV8Message = ((GeneXus.Utils.SdtMessages_Message)AV9Messages.Item(AV22GXV8));
            GX_msglist.addItem(AV8Message.gxTpr_Description);
            AV22GXV8 = (int)(AV22GXV8+1);
         }
      }

      protected void S142( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("customization",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV12CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
      }

      protected void nextLoad( )
      {
      }

      protected void E143N2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV10TrnMode", AV10TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         AV14CustomerCustomizationId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(AV14CustomerCustomizationId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERCUSTOMIZATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14CustomerCustomizationId), "ZZZ9"), context));
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
         PA3N2( ) ;
         WS3N2( ) ;
         WE3N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315563742", true, true);
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
         context.AddJavascriptSource("customization.js", "?202491315563742", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavCustomercustomization_customercustomizationid_Internalname = "CUSTOMERCUSTOMIZATION_CUSTOMERCUSTOMIZATIONID";
         imgavCustomercustomization_customercustomizationlogo_Internalname = "CUSTOMERCUSTOMIZATION_CUSTOMERCUSTOMIZATIONLOGO";
         imgavCustomercustomization_customercustomizationfavicon_Internalname = "CUSTOMERCUSTOMIZATION_CUSTOMERCUSTOMIZATIONFAVICON";
         edtavCustomercustomization_customercustomizationbasecolor_Internalname = "CUSTOMERCUSTOMIZATION_CUSTOMERCUSTOMIZATIONBASECOLOR";
         edtavCustomercustomization_customercustomizationfontsize_Internalname = "CUSTOMERCUSTOMIZATION_CUSTOMERCUSTOMIZATIONFONTSIZE";
         edtavCustomercustomization_customerid_Internalname = "CUSTOMERCUSTOMIZATION_CUSTOMERID";
         edtavCustomercustomization_customername_Internalname = "CUSTOMERCUSTOMIZATION_CUSTOMERNAME";
         divTableform_Internalname = "TABLEFORM";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divActionstable_Internalname = "ACTIONSTABLE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavCustomercustomization_customerid_Enabled = 1;
         edtavCustomercustomization_customercustomizationfontsize_Enabled = 1;
         edtavCustomercustomization_customercustomizationbasecolor_Enabled = 1;
         edtavCustomercustomization_customername_Enabled = -1;
         edtavCustomercustomization_customercustomizationid_Enabled = -1;
         bttBtnenter_Visible = 1;
         edtavCustomercustomization_customername_Jsonclick = "";
         edtavCustomercustomization_customername_Enabled = 0;
         edtavCustomercustomization_customerid_Jsonclick = "";
         edtavCustomercustomization_customerid_Enabled = 1;
         edtavCustomercustomization_customercustomizationfontsize_Jsonclick = "";
         edtavCustomercustomization_customercustomizationfontsize_Enabled = 1;
         edtavCustomercustomization_customercustomizationbasecolor_Jsonclick = "";
         edtavCustomercustomization_customercustomizationbasecolor_Enabled = 1;
         imgavCustomercustomization_customercustomizationfavicon_gximage = "";
         imgavCustomercustomization_customercustomizationfavicon_Enabled = 0;
         imgavCustomercustomization_customercustomizationlogo_gximage = "";
         imgavCustomercustomization_customercustomizationlogo_Enabled = 0;
         edtavCustomercustomization_customercustomizationid_Jsonclick = "";
         edtavCustomercustomization_customercustomizationid_Enabled = 0;
         divTablecontent_Width = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Customization", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV14CustomerCustomizationId","fld":"vCUSTOMERCUSTOMIZATIONID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E133N2","iparms":[{"av":"AV10TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV7CustomerCustomization","fld":"vCUSTOMERCUSTOMIZATION"},{"av":"AV9Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV7CustomerCustomization","fld":"vCUSTOMERCUSTOMIZATION"},{"av":"AV9Messages","fld":"vMESSAGES"},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
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
         wcpOAV10TrnMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV7CustomerCustomization = new SdtCustomerCustomization(context);
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.customization__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customization__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavCustomercustomization_customercustomizationid_Enabled = 0;
         edtavCustomercustomization_customername_Enabled = 0;
      }

      private short AV14CustomerCustomizationId ;
      private short wcpOAV14CustomerCustomizationId ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int divTablecontent_Width ;
      private int edtavCustomercustomization_customercustomizationid_Enabled ;
      private int imgavCustomercustomization_customercustomizationlogo_Enabled ;
      private int imgavCustomercustomization_customercustomizationfavicon_Enabled ;
      private int edtavCustomercustomization_customercustomizationbasecolor_Enabled ;
      private int edtavCustomercustomization_customercustomizationfontsize_Enabled ;
      private int edtavCustomercustomization_customerid_Enabled ;
      private int edtavCustomercustomization_customername_Enabled ;
      private int bttBtnenter_Visible ;
      private int AV22GXV8 ;
      private int idxLst ;
      private string AV10TrnMode ;
      private string wcpOAV10TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTableform_Internalname ;
      private string edtavCustomercustomization_customercustomizationid_Internalname ;
      private string TempTags ;
      private string edtavCustomercustomization_customercustomizationid_Jsonclick ;
      private string imgavCustomercustomization_customercustomizationlogo_Internalname ;
      private string imgavCustomercustomization_customercustomizationlogo_gximage ;
      private string sImgUrl ;
      private string imgavCustomercustomization_customercustomizationfavicon_Internalname ;
      private string imgavCustomercustomization_customercustomizationfavicon_gximage ;
      private string edtavCustomercustomization_customercustomizationbasecolor_Internalname ;
      private string edtavCustomercustomization_customercustomizationbasecolor_Jsonclick ;
      private string edtavCustomercustomization_customercustomizationfontsize_Internalname ;
      private string edtavCustomercustomization_customercustomizationfontsize_Jsonclick ;
      private string edtavCustomercustomization_customerid_Internalname ;
      private string edtavCustomercustomization_customerid_Jsonclick ;
      private string edtavCustomercustomization_customername_Internalname ;
      private string edtavCustomercustomization_customername_Jsonclick ;
      private string divActionstable_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11LoadSuccess ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtCustomerCustomization AV7CustomerCustomization ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private GeneXus.Utils.SdtMessages_Message AV8Message ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class customization__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class customization__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
