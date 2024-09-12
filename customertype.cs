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
   public class customertype : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7CustomerTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerTypeId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7CustomerTypeId", StringUtil.LTrimStr( (decimal)(AV7CustomerTypeId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERTYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CustomerTypeId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Customer Type", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCustomerTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public customertype( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customertype( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_CustomerTypeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CustomerTypeId = aP1_CustomerTypeId;
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
            return "customertype_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "", 1, 0, "px", 0, "px", "Group", "", "HLP_CustomerType.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerTypeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerTypeName_Internalname, "Customer Type", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerTypeName_Internalname, A79CustomerTypeName, StringUtil.RTrim( context.localUtil.Format( A79CustomerTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerTypeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerTypeName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_CustomerType.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerType.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A78CustomerTypeId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCustomerTypeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A78CustomerTypeId), "ZZZ9") : context.localUtil.Format( (decimal)(A78CustomerTypeId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerTypeId_Visible, edtCustomerTypeId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CustomerType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z78CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z78CustomerTypeId"), ".", ","), 18, MidpointRounding.ToEven));
               Z79CustomerTypeName = cgiGet( "Z79CustomerTypeName");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCUSTOMERTYPEID"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A79CustomerTypeName = cgiGet( edtCustomerTypeName_Internalname);
               AssignAttri("", false, "A79CustomerTypeName", A79CustomerTypeName);
               A78CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n78CustomerTypeId = false;
               AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CustomerType");
               A78CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n78CustomerTypeId = false;
               AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
               forbiddenHiddens.Add("CustomerTypeId", context.localUtil.Format( (decimal)(A78CustomerTypeId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A78CustomerTypeId != Z78CustomerTypeId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("customertype:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A78CustomerTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerTypeId"), "."), 18, MidpointRounding.ToEven));
                  n78CustomerTypeId = false;
                  AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode12 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode12;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound12 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CUSTOMERTYPEID");
                        AnyError = 1;
                        GX_FocusControl = edtCustomerTypeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0712( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0712( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_070( )
      {
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0712( ) ;
            }
            else
            {
               CheckExtendedTable0712( ) ;
               CloseExtendedTableCursors0712( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         divTablecontent_Width = 900;
         AssignProp("", false, divTablecontent_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablecontent_Width), 9, 0), true);
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtCustomerTypeId_Visible = 0;
         AssignProp("", false, edtCustomerTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerTypeId_Visible), 5, 0), true);
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("customertypeww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0712( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z79CustomerTypeName = T00073_A79CustomerTypeName[0];
            }
            else
            {
               Z79CustomerTypeName = A79CustomerTypeName;
            }
         }
         if ( GX_JID == -4 )
         {
            Z78CustomerTypeId = A78CustomerTypeId;
            Z79CustomerTypeName = A79CustomerTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCustomerTypeId_Enabled = 0;
         AssignProp("", false, edtCustomerTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerTypeId_Enabled), 5, 0), true);
         edtCustomerTypeId_Enabled = 0;
         AssignProp("", false, edtCustomerTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerTypeId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CustomerTypeId) )
         {
            A78CustomerTypeId = AV7CustomerTypeId;
            n78CustomerTypeId = false;
            AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0712( )
      {
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound12 = 1;
            A79CustomerTypeName = T00074_A79CustomerTypeName[0];
            AssignAttri("", false, "A79CustomerTypeName", A79CustomerTypeName);
            ZM0712( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0712( ) ;
      }

      protected void OnLoadActions0712( )
      {
      }

      protected void CheckExtendedTable0712( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A79CustomerTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Customer Type Name", "", "", "", "", "", "", "", ""), 1, "CUSTOMERTYPENAME");
            AnyError = 1;
            GX_FocusControl = edtCustomerTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0712( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0712( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0712( 4) ;
            RcdFound12 = 1;
            A78CustomerTypeId = T00073_A78CustomerTypeId[0];
            n78CustomerTypeId = T00073_n78CustomerTypeId[0];
            AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
            A79CustomerTypeName = T00073_A79CustomerTypeName[0];
            AssignAttri("", false, "A79CustomerTypeName", A79CustomerTypeName);
            Z78CustomerTypeId = A78CustomerTypeId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0712( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0712( ) ;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0712( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0712( ) ;
         if ( RcdFound12 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound12 = 0;
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00076_A78CustomerTypeId[0] < A78CustomerTypeId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00076_A78CustomerTypeId[0] > A78CustomerTypeId ) ) )
            {
               A78CustomerTypeId = T00076_A78CustomerTypeId[0];
               n78CustomerTypeId = T00076_n78CustomerTypeId[0];
               AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound12 = 0;
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00077_A78CustomerTypeId[0] > A78CustomerTypeId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00077_A78CustomerTypeId[0] < A78CustomerTypeId ) ) )
            {
               A78CustomerTypeId = T00077_A78CustomerTypeId[0];
               n78CustomerTypeId = T00077_n78CustomerTypeId[0];
               AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0712( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCustomerTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0712( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A78CustomerTypeId != Z78CustomerTypeId )
               {
                  A78CustomerTypeId = Z78CustomerTypeId;
                  n78CustomerTypeId = false;
                  AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CUSTOMERTYPEID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCustomerTypeName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0712( ) ;
                  GX_FocusControl = edtCustomerTypeName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A78CustomerTypeId != Z78CustomerTypeId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCustomerTypeName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0712( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CUSTOMERTYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtCustomerTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCustomerTypeName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0712( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A78CustomerTypeId != Z78CustomerTypeId )
         {
            A78CustomerTypeId = Z78CustomerTypeId;
            n78CustomerTypeId = false;
            AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CUSTOMERTYPEID");
            AnyError = 1;
            GX_FocusControl = edtCustomerTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCustomerTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0712( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z79CustomerTypeName, T00072_A79CustomerTypeName[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z79CustomerTypeName, T00072_A79CustomerTypeName[0]) != 0 )
               {
                  GXUtil.WriteLog("customertype:[seudo value changed for attri]"+"CustomerTypeName");
                  GXUtil.WriteLogRaw("Old: ",Z79CustomerTypeName);
                  GXUtil.WriteLogRaw("Current: ",T00072_A79CustomerTypeName[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0712( )
      {
         if ( ! IsAuthorized("customertype_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0712( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0712( 0) ;
            CheckOptimisticConcurrency0712( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0712( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0712( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00078 */
                     pr_default.execute(6, new Object[] {A79CustomerTypeName});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T00079 */
                     pr_default.execute(7);
                     A78CustomerTypeId = T00079_A78CustomerTypeId[0];
                     n78CustomerTypeId = T00079_n78CustomerTypeId[0];
                     AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerType");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption070( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0712( ) ;
            }
            EndLevel0712( ) ;
         }
         CloseExtendedTableCursors0712( ) ;
      }

      protected void Update0712( )
      {
         if ( ! IsAuthorized("customertype_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0712( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0712( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0712( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0712( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000710 */
                     pr_default.execute(8, new Object[] {A79CustomerTypeName, n78CustomerTypeId, A78CustomerTypeId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerType");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0712( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0712( ) ;
         }
         CloseExtendedTableCursors0712( ) ;
      }

      protected void DeferredUpdate0712( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("customertype_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0712( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0712( ) ;
            AfterConfirm0712( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0712( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000711 */
                  pr_default.execute(9, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerType");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0712( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0712( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000712 */
            pr_default.execute(10, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Customer"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0712( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0712( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("customertype",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("customertype",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0712( )
      {
         /* Scan By routine */
         /* Using cursor T000713 */
         pr_default.execute(11);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound12 = 1;
            A78CustomerTypeId = T000713_A78CustomerTypeId[0];
            n78CustomerTypeId = T000713_n78CustomerTypeId[0];
            AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0712( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound12 = 1;
            A78CustomerTypeId = T000713_A78CustomerTypeId[0];
            n78CustomerTypeId = T000713_n78CustomerTypeId[0];
            AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
         }
      }

      protected void ScanEnd0712( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0712( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0712( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0712( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0712( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0712( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0712( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0712( )
      {
         edtCustomerTypeName_Enabled = 0;
         AssignProp("", false, edtCustomerTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerTypeName_Enabled), 5, 0), true);
         edtCustomerTypeId_Enabled = 0;
         AssignProp("", false, edtCustomerTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerTypeId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0712( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("customertype.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CustomerTypeId,4,0))}, new string[] {"Gx_mode","CustomerTypeId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"CustomerType");
         forbiddenHiddens.Add("CustomerTypeId", context.localUtil.Format( (decimal)(A78CustomerTypeId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("customertype:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z78CustomerTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z78CustomerTypeId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z79CustomerTypeName", Z79CustomerTypeName);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCUSTOMERTYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerTypeId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERTYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CustomerTypeId), "ZZZ9"), context));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("customertype.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CustomerTypeId,4,0))}, new string[] {"Gx_mode","CustomerTypeId"})  ;
      }

      public override string GetPgmname( )
      {
         return "CustomerType" ;
      }

      public override string GetPgmdesc( )
      {
         return "Customer Type" ;
      }

      protected void InitializeNonKey0712( )
      {
         A79CustomerTypeName = "";
         AssignAttri("", false, "A79CustomerTypeName", A79CustomerTypeName);
         Z79CustomerTypeName = "";
      }

      protected void InitAll0712( )
      {
         A78CustomerTypeId = 0;
         n78CustomerTypeId = false;
         AssignAttri("", false, "A78CustomerTypeId", StringUtil.LTrimStr( (decimal)(A78CustomerTypeId), 4, 0));
         InitializeNonKey0712( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126295394", true, true);
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
         context.AddJavascriptSource("customertype.js", "?20249126295394", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCustomerTypeName_Internalname = "CUSTOMERTYPENAME";
         divTableform_Internalname = "TABLEFORM";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divActionstable_Internalname = "ACTIONSTABLE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtCustomerTypeId_Internalname = "CUSTOMERTYPEID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Customer Type";
         edtCustomerTypeId_Jsonclick = "";
         edtCustomerTypeId_Enabled = 0;
         edtCustomerTypeId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCustomerTypeName_Jsonclick = "";
         edtCustomerTypeName_Enabled = 1;
         divTablecontent_Width = 0;
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7CustomerTypeId","fld":"vCUSTOMERTYPEID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7CustomerTypeId","fld":"vCUSTOMERTYPEID","pic":"ZZZ9","hsh":true},{"av":"A78CustomerTypeId","fld":"CUSTOMERTYPEID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12072","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_CUSTOMERTYPENAME","""{"handler":"Valid_Customertypename","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERTYPEID","""{"handler":"Valid_Customertypeid","iparms":[]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z79CustomerTypeName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A79CustomerTypeName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode12 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T00074_A78CustomerTypeId = new short[1] ;
         T00074_n78CustomerTypeId = new bool[] {false} ;
         T00074_A79CustomerTypeName = new string[] {""} ;
         T00075_A78CustomerTypeId = new short[1] ;
         T00075_n78CustomerTypeId = new bool[] {false} ;
         T00073_A78CustomerTypeId = new short[1] ;
         T00073_n78CustomerTypeId = new bool[] {false} ;
         T00073_A79CustomerTypeName = new string[] {""} ;
         T00076_A78CustomerTypeId = new short[1] ;
         T00076_n78CustomerTypeId = new bool[] {false} ;
         T00077_A78CustomerTypeId = new short[1] ;
         T00077_n78CustomerTypeId = new bool[] {false} ;
         T00072_A78CustomerTypeId = new short[1] ;
         T00072_n78CustomerTypeId = new bool[] {false} ;
         T00072_A79CustomerTypeName = new string[] {""} ;
         T00079_A78CustomerTypeId = new short[1] ;
         T00079_n78CustomerTypeId = new bool[] {false} ;
         T000712_A1CustomerId = new short[1] ;
         T000713_A78CustomerTypeId = new short[1] ;
         T000713_n78CustomerTypeId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.customertype__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customertype__default(),
            new Object[][] {
                new Object[] {
               T00072_A78CustomerTypeId, T00072_A79CustomerTypeName
               }
               , new Object[] {
               T00073_A78CustomerTypeId, T00073_A79CustomerTypeName
               }
               , new Object[] {
               T00074_A78CustomerTypeId, T00074_A79CustomerTypeName
               }
               , new Object[] {
               T00075_A78CustomerTypeId
               }
               , new Object[] {
               T00076_A78CustomerTypeId
               }
               , new Object[] {
               T00077_A78CustomerTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               T00079_A78CustomerTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000712_A1CustomerId
               }
               , new Object[] {
               T000713_A78CustomerTypeId
               }
            }
         );
      }

      private short wcpOAV7CustomerTypeId ;
      private short Z78CustomerTypeId ;
      private short GxWebError ;
      private short AV7CustomerTypeId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A78CustomerTypeId ;
      private short RcdFound12 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int divTablecontent_Width ;
      private int edtCustomerTypeName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCustomerTypeId_Enabled ;
      private int edtCustomerTypeId_Visible ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCustomerTypeName_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTableform_Internalname ;
      private string TempTags ;
      private string edtCustomerTypeName_Jsonclick ;
      private string divActionstable_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCustomerTypeId_Internalname ;
      private string edtCustomerTypeId_Jsonclick ;
      private string hsh ;
      private string sMode12 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n78CustomerTypeId ;
      private bool returnInSub ;
      private string Z79CustomerTypeName ;
      private string A79CustomerTypeName ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T00074_A78CustomerTypeId ;
      private bool[] T00074_n78CustomerTypeId ;
      private string[] T00074_A79CustomerTypeName ;
      private short[] T00075_A78CustomerTypeId ;
      private bool[] T00075_n78CustomerTypeId ;
      private short[] T00073_A78CustomerTypeId ;
      private bool[] T00073_n78CustomerTypeId ;
      private string[] T00073_A79CustomerTypeName ;
      private short[] T00076_A78CustomerTypeId ;
      private bool[] T00076_n78CustomerTypeId ;
      private short[] T00077_A78CustomerTypeId ;
      private bool[] T00077_n78CustomerTypeId ;
      private short[] T00072_A78CustomerTypeId ;
      private bool[] T00072_n78CustomerTypeId ;
      private string[] T00072_A79CustomerTypeName ;
      private short[] T00079_A78CustomerTypeId ;
      private bool[] T00079_n78CustomerTypeId ;
      private short[] T000712_A1CustomerId ;
      private short[] T000713_A78CustomerTypeId ;
      private bool[] T000713_n78CustomerTypeId ;
      private IDataStoreProvider pr_gam ;
   }

   public class customertype__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class customertype__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00072;
        prmT00072 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT00073;
        prmT00073 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT00074;
        prmT00074 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT00075;
        prmT00075 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT00076;
        prmT00076 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT00077;
        prmT00077 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT00078;
        prmT00078 = new Object[] {
        new ParDef("CustomerTypeName",GXType.VarChar,40,0)
        };
        Object[] prmT00079;
        prmT00079 = new Object[] {
        };
        Object[] prmT000710;
        prmT000710 = new Object[] {
        new ParDef("CustomerTypeName",GXType.VarChar,40,0) ,
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000711;
        prmT000711 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000712;
        prmT000712 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000713;
        prmT000713 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00072", "SELECT CustomerTypeId, CustomerTypeName FROM CustomerType WHERE CustomerTypeId = :CustomerTypeId  FOR UPDATE OF CustomerType NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00073", "SELECT CustomerTypeId, CustomerTypeName FROM CustomerType WHERE CustomerTypeId = :CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00074", "SELECT TM1.CustomerTypeId, TM1.CustomerTypeName FROM CustomerType TM1 WHERE TM1.CustomerTypeId = :CustomerTypeId ORDER BY TM1.CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00075", "SELECT CustomerTypeId FROM CustomerType WHERE CustomerTypeId = :CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00076", "SELECT CustomerTypeId FROM CustomerType WHERE ( CustomerTypeId > :CustomerTypeId) ORDER BY CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00077", "SELECT CustomerTypeId FROM CustomerType WHERE ( CustomerTypeId < :CustomerTypeId) ORDER BY CustomerTypeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00078", "SAVEPOINT gxupdate;INSERT INTO CustomerType(CustomerTypeName) VALUES(:CustomerTypeName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00078)
           ,new CursorDef("T00079", "SELECT currval('CustomerTypeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000710", "SAVEPOINT gxupdate;UPDATE CustomerType SET CustomerTypeName=:CustomerTypeName  WHERE CustomerTypeId = :CustomerTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000710)
           ,new CursorDef("T000711", "SAVEPOINT gxupdate;DELETE FROM CustomerType  WHERE CustomerTypeId = :CustomerTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000711)
           ,new CursorDef("T000712", "SELECT CustomerId FROM Customer WHERE CustomerTypeId = :CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000712,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000713", "SELECT CustomerTypeId FROM CustomerType ORDER BY CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 11 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
