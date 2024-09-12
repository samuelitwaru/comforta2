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
   public class locationevent : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A1CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerLocationId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A1CustomerId, A18CustomerLocationId) ;
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
         Form.Meta.addItem("description", "Location Event", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLocationEventId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public locationevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public locationevent( IGxContext context )
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
         chkLocationEventAllDay = new GXCheckbox();
         chkLocationEventRecurring = new GXCheckbox();
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
            return "locationagenda_Execute" ;
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
         A125LocationEventAllDay = StringUtil.StrToBool( StringUtil.BoolToStr( A125LocationEventAllDay));
         AssignAttri("", false, "A125LocationEventAllDay", A125LocationEventAllDay);
         A126LocationEventRecurring = StringUtil.StrToBool( StringUtil.BoolToStr( A126LocationEventRecurring));
         AssignAttri("", false, "A126LocationEventRecurring", A126LocationEventRecurring);
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Location Event", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventId_Internalname, "Event Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationEventId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115LocationEventId), 4, 0, ".", "")), StringUtil.LTrim( ((edtLocationEventId_Enabled!=0) ? context.localUtil.Format( (decimal)(A115LocationEventId), "ZZZ9") : context.localUtil.Format( (decimal)(A115LocationEventId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationEventId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEventId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventStartDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventStartDate_Internalname, "Start Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLocationEventStartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLocationEventStartDate_Internalname, context.localUtil.TToC( A116LocationEventStartDate, 10, 8, 1, 2, "/", ":", " "), context.localUtil.Format( A116LocationEventStartDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',5,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationEventStartDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEventStartDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_bitmap( context, edtLocationEventStartDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLocationEventStartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LocationEvent.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventEndDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventEndDate_Internalname, "End Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLocationEventEndDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLocationEventEndDate_Internalname, context.localUtil.TToC( A117LocationEventEndDate, 10, 8, 1, 2, "/", ":", " "), context.localUtil.Format( A117LocationEventEndDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',5,12,'eng',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationEventEndDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEventEndDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_bitmap( context, edtLocationEventEndDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLocationEventEndDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LocationEvent.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventTitle_Internalname, "Event Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationEventTitle_Internalname, A118LocationEventTitle, StringUtil.RTrim( context.localUtil.Format( A118LocationEventTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationEventTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEventTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Title", "start", true, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventDisplay_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventDisplay_Internalname, "Event Display", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationEventDisplay_Internalname, A119LocationEventDisplay, StringUtil.RTrim( context.localUtil.Format( A119LocationEventDisplay, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationEventDisplay_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEventDisplay_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventBackgroundColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventBackgroundColor_Internalname, "Background Color", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationEventBackgroundColor_Internalname, A120LocationEventBackgroundColor, StringUtil.RTrim( context.localUtil.Format( A120LocationEventBackgroundColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationEventBackgroundColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEventBackgroundColor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventDescription_Internalname, "Event Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtLocationEventDescription_Internalname, A121LocationEventDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtLocationEventDescription_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventBorderColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventBorderColor_Internalname, "Border Color", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationEventBorderColor_Internalname, A122LocationEventBorderColor, StringUtil.RTrim( context.localUtil.Format( A122LocationEventBorderColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationEventBorderColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEventBorderColor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventTextColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventTextColor_Internalname, "Text Color", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationEventTextColor_Internalname, A123LocationEventTextColor, StringUtil.RTrim( context.localUtil.Format( A123LocationEventTextColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationEventTextColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEventTextColor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventUrl_Internalname, "Event Url", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationEventUrl_Internalname, A124LocationEventUrl, StringUtil.RTrim( context.localUtil.Format( A124LocationEventUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", A124LocationEventUrl, "_blank", "", "", edtLocationEventUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEventUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkLocationEventAllDay_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkLocationEventAllDay_Internalname, "All Day", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkLocationEventAllDay_Internalname, StringUtil.BoolToStr( A125LocationEventAllDay), "", "All Day", 1, chkLocationEventAllDay.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkLocationEventRecurring_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkLocationEventRecurring_Internalname, "Event Recurring", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkLocationEventRecurring_Internalname, StringUtil.BoolToStr( A126LocationEventRecurring), "", "Event Recurring", 1, chkLocationEventRecurring.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEventRecuringDays_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationEventRecuringDays_Internalname, "Recuring Days", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtLocationEventRecuringDays_Internalname, A127LocationEventRecuringDays, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", 0, 1, edtLocationEventRecuringDays_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerId_Internalname, "Customer Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCustomerId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9") : context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerLocationId_Internalname, "Customer Location Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerLocationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCustomerLocationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A18CustomerLocationId), "ZZZ9") : context.localUtil.Format( (decimal)(A18CustomerLocationId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerLocationId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LocationEvent.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_LocationEvent.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z115LocationEventId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z115LocationEventId"), ".", ","), 18, MidpointRounding.ToEven));
            Z116LocationEventStartDate = context.localUtil.CToT( cgiGet( "Z116LocationEventStartDate"), 0);
            Z117LocationEventEndDate = context.localUtil.CToT( cgiGet( "Z117LocationEventEndDate"), 0);
            Z118LocationEventTitle = cgiGet( "Z118LocationEventTitle");
            Z119LocationEventDisplay = cgiGet( "Z119LocationEventDisplay");
            Z120LocationEventBackgroundColor = cgiGet( "Z120LocationEventBackgroundColor");
            Z122LocationEventBorderColor = cgiGet( "Z122LocationEventBorderColor");
            Z123LocationEventTextColor = cgiGet( "Z123LocationEventTextColor");
            Z124LocationEventUrl = cgiGet( "Z124LocationEventUrl");
            Z125LocationEventAllDay = StringUtil.StrToBool( cgiGet( "Z125LocationEventAllDay"));
            Z126LocationEventRecurring = StringUtil.StrToBool( cgiGet( "Z126LocationEventRecurring"));
            Z1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1CustomerId"), ".", ","), 18, MidpointRounding.ToEven));
            Z18CustomerLocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z18CustomerLocationId"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtLocationEventId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLocationEventId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LOCATIONEVENTID");
               AnyError = 1;
               GX_FocusControl = edtLocationEventId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A115LocationEventId = 0;
               AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
            }
            else
            {
               A115LocationEventId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtLocationEventId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtLocationEventStartDate_Internalname), 1, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Location Event Start Date"}), 1, "LOCATIONEVENTSTARTDATE");
               AnyError = 1;
               GX_FocusControl = edtLocationEventStartDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A116LocationEventStartDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A116LocationEventStartDate", context.localUtil.TToC( A116LocationEventStartDate, 8, 5, 1, 2, "/", ":", " "));
            }
            else
            {
               A116LocationEventStartDate = context.localUtil.CToT( cgiGet( edtLocationEventStartDate_Internalname));
               AssignAttri("", false, "A116LocationEventStartDate", context.localUtil.TToC( A116LocationEventStartDate, 8, 5, 1, 2, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtLocationEventEndDate_Internalname), 1, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Location Event End Date"}), 1, "LOCATIONEVENTENDDATE");
               AnyError = 1;
               GX_FocusControl = edtLocationEventEndDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A117LocationEventEndDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A117LocationEventEndDate", context.localUtil.TToC( A117LocationEventEndDate, 8, 5, 1, 2, "/", ":", " "));
            }
            else
            {
               A117LocationEventEndDate = context.localUtil.CToT( cgiGet( edtLocationEventEndDate_Internalname));
               AssignAttri("", false, "A117LocationEventEndDate", context.localUtil.TToC( A117LocationEventEndDate, 8, 5, 1, 2, "/", ":", " "));
            }
            A118LocationEventTitle = cgiGet( edtLocationEventTitle_Internalname);
            AssignAttri("", false, "A118LocationEventTitle", A118LocationEventTitle);
            A119LocationEventDisplay = cgiGet( edtLocationEventDisplay_Internalname);
            AssignAttri("", false, "A119LocationEventDisplay", A119LocationEventDisplay);
            A120LocationEventBackgroundColor = cgiGet( edtLocationEventBackgroundColor_Internalname);
            AssignAttri("", false, "A120LocationEventBackgroundColor", A120LocationEventBackgroundColor);
            A121LocationEventDescription = cgiGet( edtLocationEventDescription_Internalname);
            AssignAttri("", false, "A121LocationEventDescription", A121LocationEventDescription);
            A122LocationEventBorderColor = cgiGet( edtLocationEventBorderColor_Internalname);
            AssignAttri("", false, "A122LocationEventBorderColor", A122LocationEventBorderColor);
            A123LocationEventTextColor = cgiGet( edtLocationEventTextColor_Internalname);
            AssignAttri("", false, "A123LocationEventTextColor", A123LocationEventTextColor);
            A124LocationEventUrl = cgiGet( edtLocationEventUrl_Internalname);
            AssignAttri("", false, "A124LocationEventUrl", A124LocationEventUrl);
            A125LocationEventAllDay = StringUtil.StrToBool( cgiGet( chkLocationEventAllDay_Internalname));
            AssignAttri("", false, "A125LocationEventAllDay", A125LocationEventAllDay);
            A126LocationEventRecurring = StringUtil.StrToBool( cgiGet( chkLocationEventRecurring_Internalname));
            AssignAttri("", false, "A126LocationEventRecurring", A126LocationEventRecurring);
            A127LocationEventRecuringDays = cgiGet( edtLocationEventRecuringDays_Internalname);
            AssignAttri("", false, "A127LocationEventRecuringDays", A127LocationEventRecuringDays);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUSTOMERID");
               AnyError = 1;
               GX_FocusControl = edtCustomerId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1CustomerId = 0;
               AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            }
            else
            {
               A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerLocationId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerLocationId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUSTOMERLOCATIONID");
               AnyError = 1;
               GX_FocusControl = edtCustomerLocationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A18CustomerLocationId = 0;
               AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
            }
            else
            {
               A18CustomerLocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerLocationId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A115LocationEventId = (short)(Math.Round(NumberUtil.Val( GetPar( "LocationEventId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0G26( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0G26( ) ;
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

      protected void ResetCaption0G0( )
      {
      }

      protected void ZM0G26( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z116LocationEventStartDate = T000G3_A116LocationEventStartDate[0];
               Z117LocationEventEndDate = T000G3_A117LocationEventEndDate[0];
               Z118LocationEventTitle = T000G3_A118LocationEventTitle[0];
               Z119LocationEventDisplay = T000G3_A119LocationEventDisplay[0];
               Z120LocationEventBackgroundColor = T000G3_A120LocationEventBackgroundColor[0];
               Z122LocationEventBorderColor = T000G3_A122LocationEventBorderColor[0];
               Z123LocationEventTextColor = T000G3_A123LocationEventTextColor[0];
               Z124LocationEventUrl = T000G3_A124LocationEventUrl[0];
               Z125LocationEventAllDay = T000G3_A125LocationEventAllDay[0];
               Z126LocationEventRecurring = T000G3_A126LocationEventRecurring[0];
               Z1CustomerId = T000G3_A1CustomerId[0];
               Z18CustomerLocationId = T000G3_A18CustomerLocationId[0];
            }
            else
            {
               Z116LocationEventStartDate = A116LocationEventStartDate;
               Z117LocationEventEndDate = A117LocationEventEndDate;
               Z118LocationEventTitle = A118LocationEventTitle;
               Z119LocationEventDisplay = A119LocationEventDisplay;
               Z120LocationEventBackgroundColor = A120LocationEventBackgroundColor;
               Z122LocationEventBorderColor = A122LocationEventBorderColor;
               Z123LocationEventTextColor = A123LocationEventTextColor;
               Z124LocationEventUrl = A124LocationEventUrl;
               Z125LocationEventAllDay = A125LocationEventAllDay;
               Z126LocationEventRecurring = A126LocationEventRecurring;
               Z1CustomerId = A1CustomerId;
               Z18CustomerLocationId = A18CustomerLocationId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z115LocationEventId = A115LocationEventId;
            Z116LocationEventStartDate = A116LocationEventStartDate;
            Z117LocationEventEndDate = A117LocationEventEndDate;
            Z118LocationEventTitle = A118LocationEventTitle;
            Z119LocationEventDisplay = A119LocationEventDisplay;
            Z120LocationEventBackgroundColor = A120LocationEventBackgroundColor;
            Z121LocationEventDescription = A121LocationEventDescription;
            Z122LocationEventBorderColor = A122LocationEventBorderColor;
            Z123LocationEventTextColor = A123LocationEventTextColor;
            Z124LocationEventUrl = A124LocationEventUrl;
            Z125LocationEventAllDay = A125LocationEventAllDay;
            Z126LocationEventRecurring = A126LocationEventRecurring;
            Z127LocationEventRecuringDays = A127LocationEventRecuringDays;
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0G26( )
      {
         /* Using cursor T000G5 */
         pr_default.execute(3, new Object[] {A115LocationEventId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound26 = 1;
            A116LocationEventStartDate = T000G5_A116LocationEventStartDate[0];
            AssignAttri("", false, "A116LocationEventStartDate", context.localUtil.TToC( A116LocationEventStartDate, 8, 5, 1, 2, "/", ":", " "));
            A117LocationEventEndDate = T000G5_A117LocationEventEndDate[0];
            AssignAttri("", false, "A117LocationEventEndDate", context.localUtil.TToC( A117LocationEventEndDate, 8, 5, 1, 2, "/", ":", " "));
            A118LocationEventTitle = T000G5_A118LocationEventTitle[0];
            AssignAttri("", false, "A118LocationEventTitle", A118LocationEventTitle);
            A119LocationEventDisplay = T000G5_A119LocationEventDisplay[0];
            AssignAttri("", false, "A119LocationEventDisplay", A119LocationEventDisplay);
            A120LocationEventBackgroundColor = T000G5_A120LocationEventBackgroundColor[0];
            AssignAttri("", false, "A120LocationEventBackgroundColor", A120LocationEventBackgroundColor);
            A121LocationEventDescription = T000G5_A121LocationEventDescription[0];
            AssignAttri("", false, "A121LocationEventDescription", A121LocationEventDescription);
            A122LocationEventBorderColor = T000G5_A122LocationEventBorderColor[0];
            AssignAttri("", false, "A122LocationEventBorderColor", A122LocationEventBorderColor);
            A123LocationEventTextColor = T000G5_A123LocationEventTextColor[0];
            AssignAttri("", false, "A123LocationEventTextColor", A123LocationEventTextColor);
            A124LocationEventUrl = T000G5_A124LocationEventUrl[0];
            AssignAttri("", false, "A124LocationEventUrl", A124LocationEventUrl);
            A125LocationEventAllDay = T000G5_A125LocationEventAllDay[0];
            AssignAttri("", false, "A125LocationEventAllDay", A125LocationEventAllDay);
            A126LocationEventRecurring = T000G5_A126LocationEventRecurring[0];
            AssignAttri("", false, "A126LocationEventRecurring", A126LocationEventRecurring);
            A127LocationEventRecuringDays = T000G5_A127LocationEventRecuringDays[0];
            AssignAttri("", false, "A127LocationEventRecuringDays", A127LocationEventRecuringDays);
            A1CustomerId = T000G5_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A18CustomerLocationId = T000G5_A18CustomerLocationId[0];
            AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
            ZM0G26( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0G26( ) ;
      }

      protected void OnLoadActions0G26( )
      {
      }

      protected void CheckExtendedTable0G26( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A124LocationEventUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("Field Location Event Url does not match the specified pattern", "OutOfRange", 1, "LOCATIONEVENTURL");
            AnyError = 1;
            GX_FocusControl = edtLocationEventUrl_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000G4 */
         pr_default.execute(2, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'CustomerLocation'.", "ForeignKeyNotFound", 1, "CUSTOMERLOCATIONID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0G26( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( short A1CustomerId ,
                               short A18CustomerLocationId )
      {
         /* Using cursor T000G6 */
         pr_default.execute(4, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'CustomerLocation'.", "ForeignKeyNotFound", 1, "CUSTOMERLOCATIONID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0G26( )
      {
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {A115LocationEventId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {A115LocationEventId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G26( 2) ;
            RcdFound26 = 1;
            A115LocationEventId = T000G3_A115LocationEventId[0];
            AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
            A116LocationEventStartDate = T000G3_A116LocationEventStartDate[0];
            AssignAttri("", false, "A116LocationEventStartDate", context.localUtil.TToC( A116LocationEventStartDate, 8, 5, 1, 2, "/", ":", " "));
            A117LocationEventEndDate = T000G3_A117LocationEventEndDate[0];
            AssignAttri("", false, "A117LocationEventEndDate", context.localUtil.TToC( A117LocationEventEndDate, 8, 5, 1, 2, "/", ":", " "));
            A118LocationEventTitle = T000G3_A118LocationEventTitle[0];
            AssignAttri("", false, "A118LocationEventTitle", A118LocationEventTitle);
            A119LocationEventDisplay = T000G3_A119LocationEventDisplay[0];
            AssignAttri("", false, "A119LocationEventDisplay", A119LocationEventDisplay);
            A120LocationEventBackgroundColor = T000G3_A120LocationEventBackgroundColor[0];
            AssignAttri("", false, "A120LocationEventBackgroundColor", A120LocationEventBackgroundColor);
            A121LocationEventDescription = T000G3_A121LocationEventDescription[0];
            AssignAttri("", false, "A121LocationEventDescription", A121LocationEventDescription);
            A122LocationEventBorderColor = T000G3_A122LocationEventBorderColor[0];
            AssignAttri("", false, "A122LocationEventBorderColor", A122LocationEventBorderColor);
            A123LocationEventTextColor = T000G3_A123LocationEventTextColor[0];
            AssignAttri("", false, "A123LocationEventTextColor", A123LocationEventTextColor);
            A124LocationEventUrl = T000G3_A124LocationEventUrl[0];
            AssignAttri("", false, "A124LocationEventUrl", A124LocationEventUrl);
            A125LocationEventAllDay = T000G3_A125LocationEventAllDay[0];
            AssignAttri("", false, "A125LocationEventAllDay", A125LocationEventAllDay);
            A126LocationEventRecurring = T000G3_A126LocationEventRecurring[0];
            AssignAttri("", false, "A126LocationEventRecurring", A126LocationEventRecurring);
            A127LocationEventRecuringDays = T000G3_A127LocationEventRecuringDays[0];
            AssignAttri("", false, "A127LocationEventRecuringDays", A127LocationEventRecuringDays);
            A1CustomerId = T000G3_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A18CustomerLocationId = T000G3_A18CustomerLocationId[0];
            AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
            Z115LocationEventId = A115LocationEventId;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0G26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0G26( ) ;
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0G26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound26 = 0;
         /* Using cursor T000G8 */
         pr_default.execute(6, new Object[] {A115LocationEventId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000G8_A115LocationEventId[0] < A115LocationEventId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000G8_A115LocationEventId[0] > A115LocationEventId ) ) )
            {
               A115LocationEventId = T000G8_A115LocationEventId[0];
               AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound26 = 0;
         /* Using cursor T000G9 */
         pr_default.execute(7, new Object[] {A115LocationEventId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000G9_A115LocationEventId[0] > A115LocationEventId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000G9_A115LocationEventId[0] < A115LocationEventId ) ) )
            {
               A115LocationEventId = T000G9_A115LocationEventId[0];
               AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLocationEventId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G26( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( A115LocationEventId != Z115LocationEventId )
               {
                  A115LocationEventId = Z115LocationEventId;
                  AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LOCATIONEVENTID");
                  AnyError = 1;
                  GX_FocusControl = edtLocationEventId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLocationEventId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0G26( ) ;
                  GX_FocusControl = edtLocationEventId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A115LocationEventId != Z115LocationEventId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLocationEventId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G26( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LOCATIONEVENTID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationEventId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLocationEventId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G26( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A115LocationEventId != Z115LocationEventId )
         {
            A115LocationEventId = Z115LocationEventId;
            AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LOCATIONEVENTID");
            AnyError = 1;
            GX_FocusControl = edtLocationEventId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLocationEventId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LOCATIONEVENTID");
            AnyError = 1;
            GX_FocusControl = edtLocationEventId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLocationEventStartDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLocationEventStartDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G26( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLocationEventStartDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLocationEventStartDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound26 != 0 )
            {
               ScanNext0G26( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLocationEventStartDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G26( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0G26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {A115LocationEventId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LocationEvent"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z116LocationEventStartDate != T000G2_A116LocationEventStartDate[0] ) || ( Z117LocationEventEndDate != T000G2_A117LocationEventEndDate[0] ) || ( StringUtil.StrCmp(Z118LocationEventTitle, T000G2_A118LocationEventTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z119LocationEventDisplay, T000G2_A119LocationEventDisplay[0]) != 0 ) || ( StringUtil.StrCmp(Z120LocationEventBackgroundColor, T000G2_A120LocationEventBackgroundColor[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z122LocationEventBorderColor, T000G2_A122LocationEventBorderColor[0]) != 0 ) || ( StringUtil.StrCmp(Z123LocationEventTextColor, T000G2_A123LocationEventTextColor[0]) != 0 ) || ( StringUtil.StrCmp(Z124LocationEventUrl, T000G2_A124LocationEventUrl[0]) != 0 ) || ( Z125LocationEventAllDay != T000G2_A125LocationEventAllDay[0] ) || ( Z126LocationEventRecurring != T000G2_A126LocationEventRecurring[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1CustomerId != T000G2_A1CustomerId[0] ) || ( Z18CustomerLocationId != T000G2_A18CustomerLocationId[0] ) )
            {
               if ( Z116LocationEventStartDate != T000G2_A116LocationEventStartDate[0] )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventStartDate");
                  GXUtil.WriteLogRaw("Old: ",Z116LocationEventStartDate);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A116LocationEventStartDate[0]);
               }
               if ( Z117LocationEventEndDate != T000G2_A117LocationEventEndDate[0] )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventEndDate");
                  GXUtil.WriteLogRaw("Old: ",Z117LocationEventEndDate);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A117LocationEventEndDate[0]);
               }
               if ( StringUtil.StrCmp(Z118LocationEventTitle, T000G2_A118LocationEventTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventTitle");
                  GXUtil.WriteLogRaw("Old: ",Z118LocationEventTitle);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A118LocationEventTitle[0]);
               }
               if ( StringUtil.StrCmp(Z119LocationEventDisplay, T000G2_A119LocationEventDisplay[0]) != 0 )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventDisplay");
                  GXUtil.WriteLogRaw("Old: ",Z119LocationEventDisplay);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A119LocationEventDisplay[0]);
               }
               if ( StringUtil.StrCmp(Z120LocationEventBackgroundColor, T000G2_A120LocationEventBackgroundColor[0]) != 0 )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventBackgroundColor");
                  GXUtil.WriteLogRaw("Old: ",Z120LocationEventBackgroundColor);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A120LocationEventBackgroundColor[0]);
               }
               if ( StringUtil.StrCmp(Z122LocationEventBorderColor, T000G2_A122LocationEventBorderColor[0]) != 0 )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventBorderColor");
                  GXUtil.WriteLogRaw("Old: ",Z122LocationEventBorderColor);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A122LocationEventBorderColor[0]);
               }
               if ( StringUtil.StrCmp(Z123LocationEventTextColor, T000G2_A123LocationEventTextColor[0]) != 0 )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventTextColor");
                  GXUtil.WriteLogRaw("Old: ",Z123LocationEventTextColor);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A123LocationEventTextColor[0]);
               }
               if ( StringUtil.StrCmp(Z124LocationEventUrl, T000G2_A124LocationEventUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventUrl");
                  GXUtil.WriteLogRaw("Old: ",Z124LocationEventUrl);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A124LocationEventUrl[0]);
               }
               if ( Z125LocationEventAllDay != T000G2_A125LocationEventAllDay[0] )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventAllDay");
                  GXUtil.WriteLogRaw("Old: ",Z125LocationEventAllDay);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A125LocationEventAllDay[0]);
               }
               if ( Z126LocationEventRecurring != T000G2_A126LocationEventRecurring[0] )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"LocationEventRecurring");
                  GXUtil.WriteLogRaw("Old: ",Z126LocationEventRecurring);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A126LocationEventRecurring[0]);
               }
               if ( Z1CustomerId != T000G2_A1CustomerId[0] )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"CustomerId");
                  GXUtil.WriteLogRaw("Old: ",Z1CustomerId);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1CustomerId[0]);
               }
               if ( Z18CustomerLocationId != T000G2_A18CustomerLocationId[0] )
               {
                  GXUtil.WriteLog("locationevent:[seudo value changed for attri]"+"CustomerLocationId");
                  GXUtil.WriteLogRaw("Old: ",Z18CustomerLocationId);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A18CustomerLocationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LocationEvent"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G26( )
      {
         if ( ! IsAuthorized("locationagenda_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G26( 0) ;
            CheckOptimisticConcurrency0G26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G10 */
                     pr_default.execute(8, new Object[] {A116LocationEventStartDate, A117LocationEventEndDate, A118LocationEventTitle, A119LocationEventDisplay, A120LocationEventBackgroundColor, A121LocationEventDescription, A122LocationEventBorderColor, A123LocationEventTextColor, A124LocationEventUrl, A125LocationEventAllDay, A126LocationEventRecurring, A127LocationEventRecuringDays, A1CustomerId, A18CustomerLocationId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000G11 */
                     pr_default.execute(9);
                     A115LocationEventId = T000G11_A115LocationEventId[0];
                     AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("LocationEvent");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0G0( ) ;
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
               Load0G26( ) ;
            }
            EndLevel0G26( ) ;
         }
         CloseExtendedTableCursors0G26( ) ;
      }

      protected void Update0G26( )
      {
         if ( ! IsAuthorized("locationagenda_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G12 */
                     pr_default.execute(10, new Object[] {A116LocationEventStartDate, A117LocationEventEndDate, A118LocationEventTitle, A119LocationEventDisplay, A120LocationEventBackgroundColor, A121LocationEventDescription, A122LocationEventBorderColor, A123LocationEventTextColor, A124LocationEventUrl, A125LocationEventAllDay, A126LocationEventRecurring, A127LocationEventRecuringDays, A1CustomerId, A18CustomerLocationId, A115LocationEventId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("LocationEvent");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LocationEvent"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G26( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0G0( ) ;
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
            EndLevel0G26( ) ;
         }
         CloseExtendedTableCursors0G26( ) ;
      }

      protected void DeferredUpdate0G26( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("locationagenda_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G26( ) ;
            AfterConfirm0G26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G13 */
                  pr_default.execute(11, new Object[] {A115LocationEventId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("LocationEvent");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound26 == 0 )
                        {
                           InitAll0G26( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0G0( ) ;
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G26( ) ;
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0G26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("locationevent",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("locationevent",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G26( )
      {
         /* Using cursor T000G14 */
         pr_default.execute(12);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound26 = 1;
            A115LocationEventId = T000G14_A115LocationEventId[0];
            AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G26( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound26 = 1;
            A115LocationEventId = T000G14_A115LocationEventId[0];
            AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
         }
      }

      protected void ScanEnd0G26( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0G26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G26( )
      {
         edtLocationEventId_Enabled = 0;
         AssignProp("", false, edtLocationEventId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventId_Enabled), 5, 0), true);
         edtLocationEventStartDate_Enabled = 0;
         AssignProp("", false, edtLocationEventStartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventStartDate_Enabled), 5, 0), true);
         edtLocationEventEndDate_Enabled = 0;
         AssignProp("", false, edtLocationEventEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventEndDate_Enabled), 5, 0), true);
         edtLocationEventTitle_Enabled = 0;
         AssignProp("", false, edtLocationEventTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventTitle_Enabled), 5, 0), true);
         edtLocationEventDisplay_Enabled = 0;
         AssignProp("", false, edtLocationEventDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventDisplay_Enabled), 5, 0), true);
         edtLocationEventBackgroundColor_Enabled = 0;
         AssignProp("", false, edtLocationEventBackgroundColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventBackgroundColor_Enabled), 5, 0), true);
         edtLocationEventDescription_Enabled = 0;
         AssignProp("", false, edtLocationEventDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventDescription_Enabled), 5, 0), true);
         edtLocationEventBorderColor_Enabled = 0;
         AssignProp("", false, edtLocationEventBorderColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventBorderColor_Enabled), 5, 0), true);
         edtLocationEventTextColor_Enabled = 0;
         AssignProp("", false, edtLocationEventTextColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventTextColor_Enabled), 5, 0), true);
         edtLocationEventUrl_Enabled = 0;
         AssignProp("", false, edtLocationEventUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventUrl_Enabled), 5, 0), true);
         chkLocationEventAllDay.Enabled = 0;
         AssignProp("", false, chkLocationEventAllDay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkLocationEventAllDay.Enabled), 5, 0), true);
         chkLocationEventRecurring.Enabled = 0;
         AssignProp("", false, chkLocationEventRecurring_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkLocationEventRecurring.Enabled), 5, 0), true);
         edtLocationEventRecuringDays_Enabled = 0;
         AssignProp("", false, edtLocationEventRecuringDays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEventRecuringDays_Enabled), 5, 0), true);
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerLocationId_Enabled = 0;
         AssignProp("", false, edtCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerLocationId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0G26( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0G0( )
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1918140), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("locationevent.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z115LocationEventId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115LocationEventId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z116LocationEventStartDate", context.localUtil.TToC( Z116LocationEventStartDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z117LocationEventEndDate", context.localUtil.TToC( Z117LocationEventEndDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z118LocationEventTitle", Z118LocationEventTitle);
         GxWebStd.gx_hidden_field( context, "Z119LocationEventDisplay", Z119LocationEventDisplay);
         GxWebStd.gx_hidden_field( context, "Z120LocationEventBackgroundColor", Z120LocationEventBackgroundColor);
         GxWebStd.gx_hidden_field( context, "Z122LocationEventBorderColor", Z122LocationEventBorderColor);
         GxWebStd.gx_hidden_field( context, "Z123LocationEventTextColor", Z123LocationEventTextColor);
         GxWebStd.gx_hidden_field( context, "Z124LocationEventUrl", Z124LocationEventUrl);
         GxWebStd.gx_boolean_hidden_field( context, "Z125LocationEventAllDay", Z125LocationEventAllDay);
         GxWebStd.gx_boolean_hidden_field( context, "Z126LocationEventRecurring", Z126LocationEventRecurring);
         GxWebStd.gx_hidden_field( context, "Z1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1CustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z18CustomerLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18CustomerLocationId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("locationevent.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "LocationEvent" ;
      }

      public override string GetPgmdesc( )
      {
         return "Location Event" ;
      }

      protected void InitializeNonKey0G26( )
      {
         A116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A116LocationEventStartDate", context.localUtil.TToC( A116LocationEventStartDate, 8, 5, 1, 2, "/", ":", " "));
         A117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A117LocationEventEndDate", context.localUtil.TToC( A117LocationEventEndDate, 8, 5, 1, 2, "/", ":", " "));
         A118LocationEventTitle = "";
         AssignAttri("", false, "A118LocationEventTitle", A118LocationEventTitle);
         A119LocationEventDisplay = "";
         AssignAttri("", false, "A119LocationEventDisplay", A119LocationEventDisplay);
         A120LocationEventBackgroundColor = "";
         AssignAttri("", false, "A120LocationEventBackgroundColor", A120LocationEventBackgroundColor);
         A121LocationEventDescription = "";
         AssignAttri("", false, "A121LocationEventDescription", A121LocationEventDescription);
         A122LocationEventBorderColor = "";
         AssignAttri("", false, "A122LocationEventBorderColor", A122LocationEventBorderColor);
         A123LocationEventTextColor = "";
         AssignAttri("", false, "A123LocationEventTextColor", A123LocationEventTextColor);
         A124LocationEventUrl = "";
         AssignAttri("", false, "A124LocationEventUrl", A124LocationEventUrl);
         A125LocationEventAllDay = false;
         AssignAttri("", false, "A125LocationEventAllDay", A125LocationEventAllDay);
         A126LocationEventRecurring = false;
         AssignAttri("", false, "A126LocationEventRecurring", A126LocationEventRecurring);
         A127LocationEventRecuringDays = "";
         AssignAttri("", false, "A127LocationEventRecuringDays", A127LocationEventRecuringDays);
         A1CustomerId = 0;
         AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         A18CustomerLocationId = 0;
         AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
         Z116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         Z117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         Z118LocationEventTitle = "";
         Z119LocationEventDisplay = "";
         Z120LocationEventBackgroundColor = "";
         Z122LocationEventBorderColor = "";
         Z123LocationEventTextColor = "";
         Z124LocationEventUrl = "";
         Z125LocationEventAllDay = false;
         Z126LocationEventRecurring = false;
         Z1CustomerId = 0;
         Z18CustomerLocationId = 0;
      }

      protected void InitAll0G26( )
      {
         A115LocationEventId = 0;
         AssignAttri("", false, "A115LocationEventId", StringUtil.LTrimStr( (decimal)(A115LocationEventId), 4, 0));
         InitializeNonKey0G26( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126301057", true, true);
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
         context.AddJavascriptSource("locationevent.js", "?20249126301058", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtLocationEventId_Internalname = "LOCATIONEVENTID";
         edtLocationEventStartDate_Internalname = "LOCATIONEVENTSTARTDATE";
         edtLocationEventEndDate_Internalname = "LOCATIONEVENTENDDATE";
         edtLocationEventTitle_Internalname = "LOCATIONEVENTTITLE";
         edtLocationEventDisplay_Internalname = "LOCATIONEVENTDISPLAY";
         edtLocationEventBackgroundColor_Internalname = "LOCATIONEVENTBACKGROUNDCOLOR";
         edtLocationEventDescription_Internalname = "LOCATIONEVENTDESCRIPTION";
         edtLocationEventBorderColor_Internalname = "LOCATIONEVENTBORDERCOLOR";
         edtLocationEventTextColor_Internalname = "LOCATIONEVENTTEXTCOLOR";
         edtLocationEventUrl_Internalname = "LOCATIONEVENTURL";
         chkLocationEventAllDay_Internalname = "LOCATIONEVENTALLDAY";
         chkLocationEventRecurring_Internalname = "LOCATIONEVENTRECURRING";
         edtLocationEventRecuringDays_Internalname = "LOCATIONEVENTRECURINGDAYS";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerLocationId_Internalname = "CUSTOMERLOCATIONID";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Caption = "Location Event";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCustomerLocationId_Jsonclick = "";
         edtCustomerLocationId_Enabled = 1;
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 1;
         edtLocationEventRecuringDays_Enabled = 1;
         chkLocationEventRecurring.Enabled = 1;
         chkLocationEventAllDay.Enabled = 1;
         edtLocationEventUrl_Jsonclick = "";
         edtLocationEventUrl_Enabled = 1;
         edtLocationEventTextColor_Jsonclick = "";
         edtLocationEventTextColor_Enabled = 1;
         edtLocationEventBorderColor_Jsonclick = "";
         edtLocationEventBorderColor_Enabled = 1;
         edtLocationEventDescription_Enabled = 1;
         edtLocationEventBackgroundColor_Jsonclick = "";
         edtLocationEventBackgroundColor_Enabled = 1;
         edtLocationEventDisplay_Jsonclick = "";
         edtLocationEventDisplay_Enabled = 1;
         edtLocationEventTitle_Jsonclick = "";
         edtLocationEventTitle_Enabled = 1;
         edtLocationEventEndDate_Jsonclick = "";
         edtLocationEventEndDate_Enabled = 1;
         edtLocationEventStartDate_Jsonclick = "";
         edtLocationEventStartDate_Enabled = 1;
         edtLocationEventId_Jsonclick = "";
         edtLocationEventId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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
         chkLocationEventAllDay.Name = "LOCATIONEVENTALLDAY";
         chkLocationEventAllDay.WebTags = "";
         chkLocationEventAllDay.Caption = "All Day";
         AssignProp("", false, chkLocationEventAllDay_Internalname, "TitleCaption", chkLocationEventAllDay.Caption, true);
         chkLocationEventAllDay.CheckedValue = "false";
         A125LocationEventAllDay = StringUtil.StrToBool( StringUtil.BoolToStr( A125LocationEventAllDay));
         AssignAttri("", false, "A125LocationEventAllDay", A125LocationEventAllDay);
         chkLocationEventRecurring.Name = "LOCATIONEVENTRECURRING";
         chkLocationEventRecurring.WebTags = "";
         chkLocationEventRecurring.Caption = "Event Recurring";
         AssignProp("", false, chkLocationEventRecurring_Internalname, "TitleCaption", chkLocationEventRecurring.Caption, true);
         chkLocationEventRecurring.CheckedValue = "false";
         A126LocationEventRecurring = StringUtil.StrToBool( StringUtil.BoolToStr( A126LocationEventRecurring));
         AssignAttri("", false, "A126LocationEventRecurring", A126LocationEventRecurring);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtLocationEventStartDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Locationeventid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A125LocationEventAllDay = StringUtil.StrToBool( StringUtil.BoolToStr( A125LocationEventAllDay));
         A126LocationEventRecurring = StringUtil.StrToBool( StringUtil.BoolToStr( A126LocationEventRecurring));
         /*  Sending validation outputs */
         AssignAttri("", false, "A116LocationEventStartDate", context.localUtil.TToC( A116LocationEventStartDate, 10, 8, 1, 2, "/", ":", " "));
         AssignAttri("", false, "A117LocationEventEndDate", context.localUtil.TToC( A117LocationEventEndDate, 10, 8, 1, 2, "/", ":", " "));
         AssignAttri("", false, "A118LocationEventTitle", A118LocationEventTitle);
         AssignAttri("", false, "A119LocationEventDisplay", A119LocationEventDisplay);
         AssignAttri("", false, "A120LocationEventBackgroundColor", A120LocationEventBackgroundColor);
         AssignAttri("", false, "A121LocationEventDescription", A121LocationEventDescription);
         AssignAttri("", false, "A122LocationEventBorderColor", A122LocationEventBorderColor);
         AssignAttri("", false, "A123LocationEventTextColor", A123LocationEventTextColor);
         AssignAttri("", false, "A124LocationEventUrl", A124LocationEventUrl);
         AssignAttri("", false, "A125LocationEventAllDay", A125LocationEventAllDay);
         AssignAttri("", false, "A126LocationEventRecurring", A126LocationEventRecurring);
         AssignAttri("", false, "A127LocationEventRecuringDays", A127LocationEventRecuringDays);
         AssignAttri("", false, "A1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")));
         AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z115LocationEventId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115LocationEventId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z116LocationEventStartDate", context.localUtil.TToC( Z116LocationEventStartDate, 10, 8, 1, 2, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z117LocationEventEndDate", context.localUtil.TToC( Z117LocationEventEndDate, 10, 8, 1, 2, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z118LocationEventTitle", Z118LocationEventTitle);
         GxWebStd.gx_hidden_field( context, "Z119LocationEventDisplay", Z119LocationEventDisplay);
         GxWebStd.gx_hidden_field( context, "Z120LocationEventBackgroundColor", Z120LocationEventBackgroundColor);
         GxWebStd.gx_hidden_field( context, "Z121LocationEventDescription", Z121LocationEventDescription);
         GxWebStd.gx_hidden_field( context, "Z122LocationEventBorderColor", Z122LocationEventBorderColor);
         GxWebStd.gx_hidden_field( context, "Z123LocationEventTextColor", Z123LocationEventTextColor);
         GxWebStd.gx_hidden_field( context, "Z124LocationEventUrl", Z124LocationEventUrl);
         GxWebStd.gx_hidden_field( context, "Z125LocationEventAllDay", StringUtil.BoolToStr( Z125LocationEventAllDay));
         GxWebStd.gx_hidden_field( context, "Z126LocationEventRecurring", StringUtil.BoolToStr( Z126LocationEventRecurring));
         GxWebStd.gx_hidden_field( context, "Z127LocationEventRecuringDays", Z127LocationEventRecuringDays);
         GxWebStd.gx_hidden_field( context, "Z1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1CustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z18CustomerLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18CustomerLocationId), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Customerlocationid( )
      {
         /* Using cursor T000G15 */
         pr_default.execute(13, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching 'CustomerLocation'.", "ForeignKeyNotFound", 1, "CUSTOMERLOCATIONID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]}""");
         setEventMetadata("VALID_LOCATIONEVENTID","""{"handler":"Valid_Locationeventid","iparms":[{"av":"A115LocationEventId","fld":"LOCATIONEVENTID","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]""");
         setEventMetadata("VALID_LOCATIONEVENTID",""","oparms":[{"av":"A116LocationEventStartDate","fld":"LOCATIONEVENTSTARTDATE","pic":"99/99/99 99:99"},{"av":"A117LocationEventEndDate","fld":"LOCATIONEVENTENDDATE","pic":"99/99/99 99:99"},{"av":"A118LocationEventTitle","fld":"LOCATIONEVENTTITLE"},{"av":"A119LocationEventDisplay","fld":"LOCATIONEVENTDISPLAY"},{"av":"A120LocationEventBackgroundColor","fld":"LOCATIONEVENTBACKGROUNDCOLOR"},{"av":"A121LocationEventDescription","fld":"LOCATIONEVENTDESCRIPTION"},{"av":"A122LocationEventBorderColor","fld":"LOCATIONEVENTBORDERCOLOR"},{"av":"A123LocationEventTextColor","fld":"LOCATIONEVENTTEXTCOLOR"},{"av":"A124LocationEventUrl","fld":"LOCATIONEVENTURL"},{"av":"A127LocationEventRecuringDays","fld":"LOCATIONEVENTRECURINGDAYS"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z115LocationEventId"},{"av":"Z116LocationEventStartDate"},{"av":"Z117LocationEventEndDate"},{"av":"Z118LocationEventTitle"},{"av":"Z119LocationEventDisplay"},{"av":"Z120LocationEventBackgroundColor"},{"av":"Z121LocationEventDescription"},{"av":"Z122LocationEventBorderColor"},{"av":"Z123LocationEventTextColor"},{"av":"Z124LocationEventUrl"},{"av":"Z125LocationEventAllDay"},{"av":"Z126LocationEventRecurring"},{"av":"Z127LocationEventRecuringDays"},{"av":"Z1CustomerId"},{"av":"Z18CustomerLocationId"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]}""");
         setEventMetadata("VALID_LOCATIONEVENTURL","""{"handler":"Valid_Locationeventurl","iparms":[{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]""");
         setEventMetadata("VALID_LOCATIONEVENTURL",""","oparms":[{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]""");
         setEventMetadata("VALID_CUSTOMERID",""","oparms":[{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]}""");
         setEventMetadata("VALID_CUSTOMERLOCATIONID","""{"handler":"Valid_Customerlocationid","iparms":[{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]""");
         setEventMetadata("VALID_CUSTOMERLOCATIONID",""","oparms":[{"av":"A125LocationEventAllDay","fld":"LOCATIONEVENTALLDAY"},{"av":"A126LocationEventRecurring","fld":"LOCATIONEVENTRECURRING"}]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         Z117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         Z118LocationEventTitle = "";
         Z119LocationEventDisplay = "";
         Z120LocationEventBackgroundColor = "";
         Z122LocationEventBorderColor = "";
         Z123LocationEventTextColor = "";
         Z124LocationEventUrl = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         A117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         A118LocationEventTitle = "";
         A119LocationEventDisplay = "";
         A120LocationEventBackgroundColor = "";
         A121LocationEventDescription = "";
         A122LocationEventBorderColor = "";
         A123LocationEventTextColor = "";
         A124LocationEventUrl = "";
         A127LocationEventRecuringDays = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z121LocationEventDescription = "";
         Z127LocationEventRecuringDays = "";
         T000G5_A115LocationEventId = new short[1] ;
         T000G5_A116LocationEventStartDate = new DateTime[] {DateTime.MinValue} ;
         T000G5_A117LocationEventEndDate = new DateTime[] {DateTime.MinValue} ;
         T000G5_A118LocationEventTitle = new string[] {""} ;
         T000G5_A119LocationEventDisplay = new string[] {""} ;
         T000G5_A120LocationEventBackgroundColor = new string[] {""} ;
         T000G5_A121LocationEventDescription = new string[] {""} ;
         T000G5_A122LocationEventBorderColor = new string[] {""} ;
         T000G5_A123LocationEventTextColor = new string[] {""} ;
         T000G5_A124LocationEventUrl = new string[] {""} ;
         T000G5_A125LocationEventAllDay = new bool[] {false} ;
         T000G5_A126LocationEventRecurring = new bool[] {false} ;
         T000G5_A127LocationEventRecuringDays = new string[] {""} ;
         T000G5_A1CustomerId = new short[1] ;
         T000G5_A18CustomerLocationId = new short[1] ;
         T000G4_A1CustomerId = new short[1] ;
         T000G6_A1CustomerId = new short[1] ;
         T000G7_A115LocationEventId = new short[1] ;
         T000G3_A115LocationEventId = new short[1] ;
         T000G3_A116LocationEventStartDate = new DateTime[] {DateTime.MinValue} ;
         T000G3_A117LocationEventEndDate = new DateTime[] {DateTime.MinValue} ;
         T000G3_A118LocationEventTitle = new string[] {""} ;
         T000G3_A119LocationEventDisplay = new string[] {""} ;
         T000G3_A120LocationEventBackgroundColor = new string[] {""} ;
         T000G3_A121LocationEventDescription = new string[] {""} ;
         T000G3_A122LocationEventBorderColor = new string[] {""} ;
         T000G3_A123LocationEventTextColor = new string[] {""} ;
         T000G3_A124LocationEventUrl = new string[] {""} ;
         T000G3_A125LocationEventAllDay = new bool[] {false} ;
         T000G3_A126LocationEventRecurring = new bool[] {false} ;
         T000G3_A127LocationEventRecuringDays = new string[] {""} ;
         T000G3_A1CustomerId = new short[1] ;
         T000G3_A18CustomerLocationId = new short[1] ;
         sMode26 = "";
         T000G8_A115LocationEventId = new short[1] ;
         T000G9_A115LocationEventId = new short[1] ;
         T000G2_A115LocationEventId = new short[1] ;
         T000G2_A116LocationEventStartDate = new DateTime[] {DateTime.MinValue} ;
         T000G2_A117LocationEventEndDate = new DateTime[] {DateTime.MinValue} ;
         T000G2_A118LocationEventTitle = new string[] {""} ;
         T000G2_A119LocationEventDisplay = new string[] {""} ;
         T000G2_A120LocationEventBackgroundColor = new string[] {""} ;
         T000G2_A121LocationEventDescription = new string[] {""} ;
         T000G2_A122LocationEventBorderColor = new string[] {""} ;
         T000G2_A123LocationEventTextColor = new string[] {""} ;
         T000G2_A124LocationEventUrl = new string[] {""} ;
         T000G2_A125LocationEventAllDay = new bool[] {false} ;
         T000G2_A126LocationEventRecurring = new bool[] {false} ;
         T000G2_A127LocationEventRecuringDays = new string[] {""} ;
         T000G2_A1CustomerId = new short[1] ;
         T000G2_A18CustomerLocationId = new short[1] ;
         T000G11_A115LocationEventId = new short[1] ;
         T000G14_A115LocationEventId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         ZZ117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         ZZ118LocationEventTitle = "";
         ZZ119LocationEventDisplay = "";
         ZZ120LocationEventBackgroundColor = "";
         ZZ121LocationEventDescription = "";
         ZZ122LocationEventBorderColor = "";
         ZZ123LocationEventTextColor = "";
         ZZ124LocationEventUrl = "";
         ZZ127LocationEventRecuringDays = "";
         T000G15_A1CustomerId = new short[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.locationevent__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.locationevent__default(),
            new Object[][] {
                new Object[] {
               T000G2_A115LocationEventId, T000G2_A116LocationEventStartDate, T000G2_A117LocationEventEndDate, T000G2_A118LocationEventTitle, T000G2_A119LocationEventDisplay, T000G2_A120LocationEventBackgroundColor, T000G2_A121LocationEventDescription, T000G2_A122LocationEventBorderColor, T000G2_A123LocationEventTextColor, T000G2_A124LocationEventUrl,
               T000G2_A125LocationEventAllDay, T000G2_A126LocationEventRecurring, T000G2_A127LocationEventRecuringDays, T000G2_A1CustomerId, T000G2_A18CustomerLocationId
               }
               , new Object[] {
               T000G3_A115LocationEventId, T000G3_A116LocationEventStartDate, T000G3_A117LocationEventEndDate, T000G3_A118LocationEventTitle, T000G3_A119LocationEventDisplay, T000G3_A120LocationEventBackgroundColor, T000G3_A121LocationEventDescription, T000G3_A122LocationEventBorderColor, T000G3_A123LocationEventTextColor, T000G3_A124LocationEventUrl,
               T000G3_A125LocationEventAllDay, T000G3_A126LocationEventRecurring, T000G3_A127LocationEventRecuringDays, T000G3_A1CustomerId, T000G3_A18CustomerLocationId
               }
               , new Object[] {
               T000G4_A1CustomerId
               }
               , new Object[] {
               T000G5_A115LocationEventId, T000G5_A116LocationEventStartDate, T000G5_A117LocationEventEndDate, T000G5_A118LocationEventTitle, T000G5_A119LocationEventDisplay, T000G5_A120LocationEventBackgroundColor, T000G5_A121LocationEventDescription, T000G5_A122LocationEventBorderColor, T000G5_A123LocationEventTextColor, T000G5_A124LocationEventUrl,
               T000G5_A125LocationEventAllDay, T000G5_A126LocationEventRecurring, T000G5_A127LocationEventRecuringDays, T000G5_A1CustomerId, T000G5_A18CustomerLocationId
               }
               , new Object[] {
               T000G6_A1CustomerId
               }
               , new Object[] {
               T000G7_A115LocationEventId
               }
               , new Object[] {
               T000G8_A115LocationEventId
               }
               , new Object[] {
               T000G9_A115LocationEventId
               }
               , new Object[] {
               }
               , new Object[] {
               T000G11_A115LocationEventId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G14_A115LocationEventId
               }
               , new Object[] {
               T000G15_A1CustomerId
               }
            }
         );
      }

      private short Z115LocationEventId ;
      private short Z1CustomerId ;
      private short Z18CustomerLocationId ;
      private short GxWebError ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A115LocationEventId ;
      private short RcdFound26 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ115LocationEventId ;
      private short ZZ1CustomerId ;
      private short ZZ18CustomerLocationId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLocationEventId_Enabled ;
      private int edtLocationEventStartDate_Enabled ;
      private int edtLocationEventEndDate_Enabled ;
      private int edtLocationEventTitle_Enabled ;
      private int edtLocationEventDisplay_Enabled ;
      private int edtLocationEventBackgroundColor_Enabled ;
      private int edtLocationEventDescription_Enabled ;
      private int edtLocationEventBorderColor_Enabled ;
      private int edtLocationEventTextColor_Enabled ;
      private int edtLocationEventUrl_Enabled ;
      private int edtLocationEventRecuringDays_Enabled ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerLocationId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLocationEventId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtLocationEventId_Jsonclick ;
      private string edtLocationEventStartDate_Internalname ;
      private string edtLocationEventStartDate_Jsonclick ;
      private string edtLocationEventEndDate_Internalname ;
      private string edtLocationEventEndDate_Jsonclick ;
      private string edtLocationEventTitle_Internalname ;
      private string edtLocationEventTitle_Jsonclick ;
      private string edtLocationEventDisplay_Internalname ;
      private string edtLocationEventDisplay_Jsonclick ;
      private string edtLocationEventBackgroundColor_Internalname ;
      private string edtLocationEventBackgroundColor_Jsonclick ;
      private string edtLocationEventDescription_Internalname ;
      private string edtLocationEventBorderColor_Internalname ;
      private string edtLocationEventBorderColor_Jsonclick ;
      private string edtLocationEventTextColor_Internalname ;
      private string edtLocationEventTextColor_Jsonclick ;
      private string edtLocationEventUrl_Internalname ;
      private string edtLocationEventUrl_Jsonclick ;
      private string chkLocationEventAllDay_Internalname ;
      private string chkLocationEventRecurring_Internalname ;
      private string edtLocationEventRecuringDays_Internalname ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerLocationId_Internalname ;
      private string edtCustomerLocationId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode26 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z116LocationEventStartDate ;
      private DateTime Z117LocationEventEndDate ;
      private DateTime A116LocationEventStartDate ;
      private DateTime A117LocationEventEndDate ;
      private DateTime ZZ116LocationEventStartDate ;
      private DateTime ZZ117LocationEventEndDate ;
      private bool Z125LocationEventAllDay ;
      private bool Z126LocationEventRecurring ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A125LocationEventAllDay ;
      private bool A126LocationEventRecurring ;
      private bool Gx_longc ;
      private bool ZZ125LocationEventAllDay ;
      private bool ZZ126LocationEventRecurring ;
      private string A121LocationEventDescription ;
      private string A127LocationEventRecuringDays ;
      private string Z121LocationEventDescription ;
      private string Z127LocationEventRecuringDays ;
      private string ZZ121LocationEventDescription ;
      private string ZZ127LocationEventRecuringDays ;
      private string Z118LocationEventTitle ;
      private string Z119LocationEventDisplay ;
      private string Z120LocationEventBackgroundColor ;
      private string Z122LocationEventBorderColor ;
      private string Z123LocationEventTextColor ;
      private string Z124LocationEventUrl ;
      private string A118LocationEventTitle ;
      private string A119LocationEventDisplay ;
      private string A120LocationEventBackgroundColor ;
      private string A122LocationEventBorderColor ;
      private string A123LocationEventTextColor ;
      private string A124LocationEventUrl ;
      private string ZZ118LocationEventTitle ;
      private string ZZ119LocationEventDisplay ;
      private string ZZ120LocationEventBackgroundColor ;
      private string ZZ122LocationEventBorderColor ;
      private string ZZ123LocationEventTextColor ;
      private string ZZ124LocationEventUrl ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkLocationEventAllDay ;
      private GXCheckbox chkLocationEventRecurring ;
      private IDataStoreProvider pr_default ;
      private short[] T000G5_A115LocationEventId ;
      private DateTime[] T000G5_A116LocationEventStartDate ;
      private DateTime[] T000G5_A117LocationEventEndDate ;
      private string[] T000G5_A118LocationEventTitle ;
      private string[] T000G5_A119LocationEventDisplay ;
      private string[] T000G5_A120LocationEventBackgroundColor ;
      private string[] T000G5_A121LocationEventDescription ;
      private string[] T000G5_A122LocationEventBorderColor ;
      private string[] T000G5_A123LocationEventTextColor ;
      private string[] T000G5_A124LocationEventUrl ;
      private bool[] T000G5_A125LocationEventAllDay ;
      private bool[] T000G5_A126LocationEventRecurring ;
      private string[] T000G5_A127LocationEventRecuringDays ;
      private short[] T000G5_A1CustomerId ;
      private short[] T000G5_A18CustomerLocationId ;
      private short[] T000G4_A1CustomerId ;
      private short[] T000G6_A1CustomerId ;
      private short[] T000G7_A115LocationEventId ;
      private short[] T000G3_A115LocationEventId ;
      private DateTime[] T000G3_A116LocationEventStartDate ;
      private DateTime[] T000G3_A117LocationEventEndDate ;
      private string[] T000G3_A118LocationEventTitle ;
      private string[] T000G3_A119LocationEventDisplay ;
      private string[] T000G3_A120LocationEventBackgroundColor ;
      private string[] T000G3_A121LocationEventDescription ;
      private string[] T000G3_A122LocationEventBorderColor ;
      private string[] T000G3_A123LocationEventTextColor ;
      private string[] T000G3_A124LocationEventUrl ;
      private bool[] T000G3_A125LocationEventAllDay ;
      private bool[] T000G3_A126LocationEventRecurring ;
      private string[] T000G3_A127LocationEventRecuringDays ;
      private short[] T000G3_A1CustomerId ;
      private short[] T000G3_A18CustomerLocationId ;
      private short[] T000G8_A115LocationEventId ;
      private short[] T000G9_A115LocationEventId ;
      private short[] T000G2_A115LocationEventId ;
      private DateTime[] T000G2_A116LocationEventStartDate ;
      private DateTime[] T000G2_A117LocationEventEndDate ;
      private string[] T000G2_A118LocationEventTitle ;
      private string[] T000G2_A119LocationEventDisplay ;
      private string[] T000G2_A120LocationEventBackgroundColor ;
      private string[] T000G2_A121LocationEventDescription ;
      private string[] T000G2_A122LocationEventBorderColor ;
      private string[] T000G2_A123LocationEventTextColor ;
      private string[] T000G2_A124LocationEventUrl ;
      private bool[] T000G2_A125LocationEventAllDay ;
      private bool[] T000G2_A126LocationEventRecurring ;
      private string[] T000G2_A127LocationEventRecuringDays ;
      private short[] T000G2_A1CustomerId ;
      private short[] T000G2_A18CustomerLocationId ;
      private short[] T000G11_A115LocationEventId ;
      private short[] T000G14_A115LocationEventId ;
      private short[] T000G15_A1CustomerId ;
      private IDataStoreProvider pr_gam ;
   }

   public class locationevent__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class locationevent__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000G2;
        prmT000G2 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmT000G3;
        prmT000G3 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmT000G4;
        prmT000G4 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000G5;
        prmT000G5 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmT000G6;
        prmT000G6 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000G7;
        prmT000G7 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmT000G8;
        prmT000G8 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmT000G9;
        prmT000G9 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmT000G10;
        prmT000G10 = new Object[] {
        new ParDef("LocationEventStartDate",GXType.DateTime,8,5) ,
        new ParDef("LocationEventEndDate",GXType.DateTime,8,5) ,
        new ParDef("LocationEventTitle",GXType.VarChar,100,0) ,
        new ParDef("LocationEventDisplay",GXType.VarChar,40,0) ,
        new ParDef("LocationEventBackgroundColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("LocationEventBorderColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventTextColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventUrl",GXType.VarChar,1000,0) ,
        new ParDef("LocationEventAllDay",GXType.Boolean,4,0) ,
        new ParDef("LocationEventRecurring",GXType.Boolean,4,0) ,
        new ParDef("LocationEventRecuringDays",GXType.LongVarChar,2097152,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000G11;
        prmT000G11 = new Object[] {
        };
        Object[] prmT000G12;
        prmT000G12 = new Object[] {
        new ParDef("LocationEventStartDate",GXType.DateTime,8,5) ,
        new ParDef("LocationEventEndDate",GXType.DateTime,8,5) ,
        new ParDef("LocationEventTitle",GXType.VarChar,100,0) ,
        new ParDef("LocationEventDisplay",GXType.VarChar,40,0) ,
        new ParDef("LocationEventBackgroundColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("LocationEventBorderColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventTextColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventUrl",GXType.VarChar,1000,0) ,
        new ParDef("LocationEventAllDay",GXType.Boolean,4,0) ,
        new ParDef("LocationEventRecurring",GXType.Boolean,4,0) ,
        new ParDef("LocationEventRecuringDays",GXType.LongVarChar,2097152,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmT000G13;
        prmT000G13 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmT000G14;
        prmT000G14 = new Object[] {
        };
        Object[] prmT000G15;
        prmT000G15 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000G2", "SELECT LocationEventId, LocationEventStartDate, LocationEventEndDate, LocationEventTitle, LocationEventDisplay, LocationEventBackgroundColor, LocationEventDescription, LocationEventBorderColor, LocationEventTextColor, LocationEventUrl, LocationEventAllDay, LocationEventRecurring, LocationEventRecuringDays, CustomerId, CustomerLocationId FROM LocationEvent WHERE LocationEventId = :LocationEventId  FOR UPDATE OF LocationEvent NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G3", "SELECT LocationEventId, LocationEventStartDate, LocationEventEndDate, LocationEventTitle, LocationEventDisplay, LocationEventBackgroundColor, LocationEventDescription, LocationEventBorderColor, LocationEventTextColor, LocationEventUrl, LocationEventAllDay, LocationEventRecurring, LocationEventRecuringDays, CustomerId, CustomerLocationId FROM LocationEvent WHERE LocationEventId = :LocationEventId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G4", "SELECT CustomerId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G5", "SELECT TM1.LocationEventId, TM1.LocationEventStartDate, TM1.LocationEventEndDate, TM1.LocationEventTitle, TM1.LocationEventDisplay, TM1.LocationEventBackgroundColor, TM1.LocationEventDescription, TM1.LocationEventBorderColor, TM1.LocationEventTextColor, TM1.LocationEventUrl, TM1.LocationEventAllDay, TM1.LocationEventRecurring, TM1.LocationEventRecuringDays, TM1.CustomerId, TM1.CustomerLocationId FROM LocationEvent TM1 WHERE TM1.LocationEventId = :LocationEventId ORDER BY TM1.LocationEventId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G6", "SELECT CustomerId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G7", "SELECT LocationEventId FROM LocationEvent WHERE LocationEventId = :LocationEventId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G8", "SELECT LocationEventId FROM LocationEvent WHERE ( LocationEventId > :LocationEventId) ORDER BY LocationEventId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G9", "SELECT LocationEventId FROM LocationEvent WHERE ( LocationEventId < :LocationEventId) ORDER BY LocationEventId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G10", "SAVEPOINT gxupdate;INSERT INTO LocationEvent(LocationEventStartDate, LocationEventEndDate, LocationEventTitle, LocationEventDisplay, LocationEventBackgroundColor, LocationEventDescription, LocationEventBorderColor, LocationEventTextColor, LocationEventUrl, LocationEventAllDay, LocationEventRecurring, LocationEventRecuringDays, CustomerId, CustomerLocationId) VALUES(:LocationEventStartDate, :LocationEventEndDate, :LocationEventTitle, :LocationEventDisplay, :LocationEventBackgroundColor, :LocationEventDescription, :LocationEventBorderColor, :LocationEventTextColor, :LocationEventUrl, :LocationEventAllDay, :LocationEventRecurring, :LocationEventRecuringDays, :CustomerId, :CustomerLocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G10)
           ,new CursorDef("T000G11", "SELECT currval('LocationEventId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G12", "SAVEPOINT gxupdate;UPDATE LocationEvent SET LocationEventStartDate=:LocationEventStartDate, LocationEventEndDate=:LocationEventEndDate, LocationEventTitle=:LocationEventTitle, LocationEventDisplay=:LocationEventDisplay, LocationEventBackgroundColor=:LocationEventBackgroundColor, LocationEventDescription=:LocationEventDescription, LocationEventBorderColor=:LocationEventBorderColor, LocationEventTextColor=:LocationEventTextColor, LocationEventUrl=:LocationEventUrl, LocationEventAllDay=:LocationEventAllDay, LocationEventRecurring=:LocationEventRecurring, LocationEventRecuringDays=:LocationEventRecuringDays, CustomerId=:CustomerId, CustomerLocationId=:CustomerLocationId  WHERE LocationEventId = :LocationEventId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G12)
           ,new CursorDef("T000G13", "SAVEPOINT gxupdate;DELETE FROM LocationEvent  WHERE LocationEventId = :LocationEventId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G13)
           ,new CursorDef("T000G14", "SELECT LocationEventId FROM LocationEvent ORDER BY LocationEventId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G15", "SELECT CustomerId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G15,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
