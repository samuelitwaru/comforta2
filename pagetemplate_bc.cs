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
   public class pagetemplate_bc : GxSilentTrn, IGxSilentTrn
   {
      public pagetemplate_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pagetemplate_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0F25( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F25( ) ;
         standaloneModal( ) ;
         AddRow0F25( ) ;
         Gx_mode = "INS";
         return  ;
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
            E110F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z107PageTemplateId = A107PageTemplateId;
               SetMode( "UPD") ;
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

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F25( ) ;
            }
            else
            {
               CheckExtendedTable0F25( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0F25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120F2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void E130F2( )
      {
         /* 'Cancel' Routine */
         returnInSub = false;
      }

      protected void ZM0F25( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z108PageTemplateName = A108PageTemplateName;
            Z111PageTemplateDescription = A111PageTemplateDescription;
         }
         if ( GX_JID == -4 )
         {
            Z107PageTemplateId = A107PageTemplateId;
            Z108PageTemplateName = A108PageTemplateName;
            Z111PageTemplateDescription = A111PageTemplateDescription;
            Z114PageTemplateHtml = A114PageTemplateHtml;
            Z113PageTemplateCSS = A113PageTemplateCSS;
            Z110PageTemplateImage = A110PageTemplateImage;
            Z40000PageTemplateImage_GXI = A40000PageTemplateImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0F25( )
      {
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A107PageTemplateId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound25 = 1;
            A108PageTemplateName = BC000F4_A108PageTemplateName[0];
            A111PageTemplateDescription = BC000F4_A111PageTemplateDescription[0];
            A114PageTemplateHtml = BC000F4_A114PageTemplateHtml[0];
            A113PageTemplateCSS = BC000F4_A113PageTemplateCSS[0];
            A40000PageTemplateImage_GXI = BC000F4_A40000PageTemplateImage_GXI[0];
            A110PageTemplateImage = BC000F4_A110PageTemplateImage[0];
            ZM0F25( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0F25( ) ;
      }

      protected void OnLoadActions0F25( )
      {
      }

      protected void CheckExtendedTable0F25( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A108PageTemplateName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Page Template Name", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A111PageTemplateDescription)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Page Template Description", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) && String.IsNullOrEmpty(StringUtil.RTrim( A40000PageTemplateImage_GXI)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Page Template Image", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0F25( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F25( )
      {
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {A107PageTemplateId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A107PageTemplateId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F25( 4) ;
            RcdFound25 = 1;
            A107PageTemplateId = BC000F3_A107PageTemplateId[0];
            A108PageTemplateName = BC000F3_A108PageTemplateName[0];
            A111PageTemplateDescription = BC000F3_A111PageTemplateDescription[0];
            A114PageTemplateHtml = BC000F3_A114PageTemplateHtml[0];
            A113PageTemplateCSS = BC000F3_A113PageTemplateCSS[0];
            A40000PageTemplateImage_GXI = BC000F3_A40000PageTemplateImage_GXI[0];
            A110PageTemplateImage = BC000F3_A110PageTemplateImage[0];
            Z107PageTemplateId = A107PageTemplateId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0F25( ) ;
            }
            Gx_mode = sMode25;
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0F25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode25;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0F25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A107PageTemplateId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PageTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z108PageTemplateName, BC000F2_A108PageTemplateName[0]) != 0 ) || ( StringUtil.StrCmp(Z111PageTemplateDescription, BC000F2_A111PageTemplateDescription[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PageTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F25( )
      {
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F25( 0) ;
            CheckOptimisticConcurrency0F25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F6 */
                     pr_default.execute(4, new Object[] {A108PageTemplateName, A111PageTemplateDescription, A114PageTemplateHtml, A113PageTemplateCSS, A110PageTemplateImage, A40000PageTemplateImage_GXI});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000F7 */
                     pr_default.execute(5);
                     A107PageTemplateId = BC000F7_A107PageTemplateId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
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
               Load0F25( ) ;
            }
            EndLevel0F25( ) ;
         }
         CloseExtendedTableCursors0F25( ) ;
      }

      protected void Update0F25( )
      {
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F8 */
                     pr_default.execute(6, new Object[] {A108PageTemplateName, A111PageTemplateDescription, A114PageTemplateHtml, A113PageTemplateCSS, A107PageTemplateId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PageTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F25( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel0F25( ) ;
         }
         CloseExtendedTableCursors0F25( ) ;
      }

      protected void DeferredUpdate0F25( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F9 */
            pr_default.execute(7, new Object[] {A110PageTemplateImage, A40000PageTemplateImage_GXI, A107PageTemplateId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F25( ) ;
            AfterConfirm0F25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F10 */
                  pr_default.execute(8, new Object[] {A107PageTemplateId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F25( ) ;
         Gx_mode = sMode25;
      }

      protected void OnDeleteControls0F25( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0F25( )
      {
         /* Scan By routine */
         /* Using cursor BC000F11 */
         pr_default.execute(9, new Object[] {A107PageTemplateId});
         RcdFound25 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound25 = 1;
            A107PageTemplateId = BC000F11_A107PageTemplateId[0];
            A108PageTemplateName = BC000F11_A108PageTemplateName[0];
            A111PageTemplateDescription = BC000F11_A111PageTemplateDescription[0];
            A114PageTemplateHtml = BC000F11_A114PageTemplateHtml[0];
            A113PageTemplateCSS = BC000F11_A113PageTemplateCSS[0];
            A40000PageTemplateImage_GXI = BC000F11_A40000PageTemplateImage_GXI[0];
            A110PageTemplateImage = BC000F11_A110PageTemplateImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F25( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound25 = 0;
         ScanKeyLoad0F25( ) ;
      }

      protected void ScanKeyLoad0F25( )
      {
         sMode25 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound25 = 1;
            A107PageTemplateId = BC000F11_A107PageTemplateId[0];
            A108PageTemplateName = BC000F11_A108PageTemplateName[0];
            A111PageTemplateDescription = BC000F11_A111PageTemplateDescription[0];
            A114PageTemplateHtml = BC000F11_A114PageTemplateHtml[0];
            A113PageTemplateCSS = BC000F11_A113PageTemplateCSS[0];
            A40000PageTemplateImage_GXI = BC000F11_A40000PageTemplateImage_GXI[0];
            A110PageTemplateImage = BC000F11_A110PageTemplateImage[0];
         }
         Gx_mode = sMode25;
      }

      protected void ScanKeyEnd0F25( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0F25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F25( )
      {
      }

      protected void send_integrity_lvl_hashes0F25( )
      {
      }

      protected void AddRow0F25( )
      {
         VarsToRow25( bcPageTemplate) ;
      }

      protected void ReadRow0F25( )
      {
         RowToVars25( bcPageTemplate, 1) ;
      }

      protected void InitializeNonKey0F25( )
      {
         A108PageTemplateName = "";
         A111PageTemplateDescription = "";
         A114PageTemplateHtml = "";
         A113PageTemplateCSS = "";
         A110PageTemplateImage = "";
         A40000PageTemplateImage_GXI = "";
         Z108PageTemplateName = "";
         Z111PageTemplateDescription = "";
      }

      protected void InitAll0F25( )
      {
         A107PageTemplateId = 0;
         InitializeNonKey0F25( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow25( SdtPageTemplate obj25 )
      {
         obj25.gxTpr_Mode = Gx_mode;
         obj25.gxTpr_Pagetemplatename = A108PageTemplateName;
         obj25.gxTpr_Pagetemplatedescription = A111PageTemplateDescription;
         obj25.gxTpr_Pagetemplatehtml = A114PageTemplateHtml;
         obj25.gxTpr_Pagetemplatecss = A113PageTemplateCSS;
         obj25.gxTpr_Pagetemplateimage = A110PageTemplateImage;
         obj25.gxTpr_Pagetemplateimage_gxi = A40000PageTemplateImage_GXI;
         obj25.gxTpr_Pagetemplateid = A107PageTemplateId;
         obj25.gxTpr_Pagetemplateid_Z = Z107PageTemplateId;
         obj25.gxTpr_Pagetemplatename_Z = Z108PageTemplateName;
         obj25.gxTpr_Pagetemplatedescription_Z = Z111PageTemplateDescription;
         obj25.gxTpr_Pagetemplateimage_gxi_Z = Z40000PageTemplateImage_GXI;
         obj25.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow25( SdtPageTemplate obj25 )
      {
         obj25.gxTpr_Pagetemplateid = A107PageTemplateId;
         return  ;
      }

      public void RowToVars25( SdtPageTemplate obj25 ,
                               int forceLoad )
      {
         Gx_mode = obj25.gxTpr_Mode;
         A108PageTemplateName = obj25.gxTpr_Pagetemplatename;
         A111PageTemplateDescription = obj25.gxTpr_Pagetemplatedescription;
         A114PageTemplateHtml = obj25.gxTpr_Pagetemplatehtml;
         A113PageTemplateCSS = obj25.gxTpr_Pagetemplatecss;
         A110PageTemplateImage = obj25.gxTpr_Pagetemplateimage;
         A40000PageTemplateImage_GXI = obj25.gxTpr_Pagetemplateimage_gxi;
         A107PageTemplateId = obj25.gxTpr_Pagetemplateid;
         Z107PageTemplateId = obj25.gxTpr_Pagetemplateid_Z;
         Z108PageTemplateName = obj25.gxTpr_Pagetemplatename_Z;
         Z111PageTemplateDescription = obj25.gxTpr_Pagetemplatedescription_Z;
         Z40000PageTemplateImage_GXI = obj25.gxTpr_Pagetemplateimage_gxi_Z;
         Gx_mode = obj25.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A107PageTemplateId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F25( ) ;
         ScanKeyStart0F25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z107PageTemplateId = A107PageTemplateId;
         }
         ZM0F25( -4) ;
         OnLoadActions0F25( ) ;
         AddRow0F25( ) ;
         ScanKeyEnd0F25( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars25( bcPageTemplate, 0) ;
         ScanKeyStart0F25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z107PageTemplateId = A107PageTemplateId;
         }
         ZM0F25( -4) ;
         OnLoadActions0F25( ) ;
         AddRow0F25( ) ;
         ScanKeyEnd0F25( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0F25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F25( ) ;
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A107PageTemplateId != Z107PageTemplateId )
               {
                  A107PageTemplateId = Z107PageTemplateId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0F25( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A107PageTemplateId != Z107PageTemplateId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0F25( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0F25( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars25( bcPageTemplate, 1) ;
         SaveImpl( ) ;
         VarsToRow25( bcPageTemplate) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars25( bcPageTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F25( ) ;
         AfterTrn( ) ;
         VarsToRow25( bcPageTemplate) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow25( bcPageTemplate) ;
         }
         else
         {
            SdtPageTemplate auxBC = new SdtPageTemplate(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A107PageTemplateId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPageTemplate);
               auxBC.Save();
               bcPageTemplate.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars25( bcPageTemplate, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars25( bcPageTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F25( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow25( bcPageTemplate) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow25( bcPageTemplate) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars25( bcPageTemplate, 0) ;
         GetKey0F25( ) ;
         if ( RcdFound25 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A107PageTemplateId != Z107PageTemplateId )
            {
               A107PageTemplateId = Z107PageTemplateId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A107PageTemplateId != Z107PageTemplateId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("pagetemplate_bc",pr_default);
         VarsToRow25( bcPageTemplate) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcPageTemplate.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPageTemplate.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPageTemplate )
         {
            bcPageTemplate = (SdtPageTemplate)(sdt);
            if ( StringUtil.StrCmp(bcPageTemplate.gxTpr_Mode, "") == 0 )
            {
               bcPageTemplate.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow25( bcPageTemplate) ;
            }
            else
            {
               RowToVars25( bcPageTemplate, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPageTemplate.gxTpr_Mode, "") == 0 )
            {
               bcPageTemplate.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars25( bcPageTemplate, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPageTemplate PageTemplate_BC
      {
         get {
            return bcPageTemplate ;
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
            return "pagetemplate_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
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
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z108PageTemplateName = "";
         A108PageTemplateName = "";
         Z111PageTemplateDescription = "";
         A111PageTemplateDescription = "";
         Z114PageTemplateHtml = "";
         A114PageTemplateHtml = "";
         Z113PageTemplateCSS = "";
         A113PageTemplateCSS = "";
         Z110PageTemplateImage = "";
         A110PageTemplateImage = "";
         Z40000PageTemplateImage_GXI = "";
         A40000PageTemplateImage_GXI = "";
         BC000F4_A107PageTemplateId = new short[1] ;
         BC000F4_A108PageTemplateName = new string[] {""} ;
         BC000F4_A111PageTemplateDescription = new string[] {""} ;
         BC000F4_A114PageTemplateHtml = new string[] {""} ;
         BC000F4_A113PageTemplateCSS = new string[] {""} ;
         BC000F4_A40000PageTemplateImage_GXI = new string[] {""} ;
         BC000F4_A110PageTemplateImage = new string[] {""} ;
         BC000F5_A107PageTemplateId = new short[1] ;
         BC000F3_A107PageTemplateId = new short[1] ;
         BC000F3_A108PageTemplateName = new string[] {""} ;
         BC000F3_A111PageTemplateDescription = new string[] {""} ;
         BC000F3_A114PageTemplateHtml = new string[] {""} ;
         BC000F3_A113PageTemplateCSS = new string[] {""} ;
         BC000F3_A40000PageTemplateImage_GXI = new string[] {""} ;
         BC000F3_A110PageTemplateImage = new string[] {""} ;
         sMode25 = "";
         BC000F2_A107PageTemplateId = new short[1] ;
         BC000F2_A108PageTemplateName = new string[] {""} ;
         BC000F2_A111PageTemplateDescription = new string[] {""} ;
         BC000F2_A114PageTemplateHtml = new string[] {""} ;
         BC000F2_A113PageTemplateCSS = new string[] {""} ;
         BC000F2_A40000PageTemplateImage_GXI = new string[] {""} ;
         BC000F2_A110PageTemplateImage = new string[] {""} ;
         BC000F7_A107PageTemplateId = new short[1] ;
         BC000F11_A107PageTemplateId = new short[1] ;
         BC000F11_A108PageTemplateName = new string[] {""} ;
         BC000F11_A111PageTemplateDescription = new string[] {""} ;
         BC000F11_A114PageTemplateHtml = new string[] {""} ;
         BC000F11_A113PageTemplateCSS = new string[] {""} ;
         BC000F11_A40000PageTemplateImage_GXI = new string[] {""} ;
         BC000F11_A110PageTemplateImage = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.pagetemplate_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pagetemplate_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A107PageTemplateId, BC000F2_A108PageTemplateName, BC000F2_A111PageTemplateDescription, BC000F2_A114PageTemplateHtml, BC000F2_A113PageTemplateCSS, BC000F2_A40000PageTemplateImage_GXI, BC000F2_A110PageTemplateImage
               }
               , new Object[] {
               BC000F3_A107PageTemplateId, BC000F3_A108PageTemplateName, BC000F3_A111PageTemplateDescription, BC000F3_A114PageTemplateHtml, BC000F3_A113PageTemplateCSS, BC000F3_A40000PageTemplateImage_GXI, BC000F3_A110PageTemplateImage
               }
               , new Object[] {
               BC000F4_A107PageTemplateId, BC000F4_A108PageTemplateName, BC000F4_A111PageTemplateDescription, BC000F4_A114PageTemplateHtml, BC000F4_A113PageTemplateCSS, BC000F4_A40000PageTemplateImage_GXI, BC000F4_A110PageTemplateImage
               }
               , new Object[] {
               BC000F5_A107PageTemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F7_A107PageTemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F11_A107PageTemplateId, BC000F11_A108PageTemplateName, BC000F11_A111PageTemplateDescription, BC000F11_A114PageTemplateHtml, BC000F11_A113PageTemplateCSS, BC000F11_A40000PageTemplateImage_GXI, BC000F11_A110PageTemplateImage
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120F2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z107PageTemplateId ;
      private short A107PageTemplateId ;
      private short RcdFound25 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode25 ;
      private bool returnInSub ;
      private string Z114PageTemplateHtml ;
      private string A114PageTemplateHtml ;
      private string Z113PageTemplateCSS ;
      private string A113PageTemplateCSS ;
      private string Z108PageTemplateName ;
      private string A108PageTemplateName ;
      private string Z111PageTemplateDescription ;
      private string A111PageTemplateDescription ;
      private string Z40000PageTemplateImage_GXI ;
      private string A40000PageTemplateImage_GXI ;
      private string Z110PageTemplateImage ;
      private string A110PageTemplateImage ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC000F4_A107PageTemplateId ;
      private string[] BC000F4_A108PageTemplateName ;
      private string[] BC000F4_A111PageTemplateDescription ;
      private string[] BC000F4_A114PageTemplateHtml ;
      private string[] BC000F4_A113PageTemplateCSS ;
      private string[] BC000F4_A40000PageTemplateImage_GXI ;
      private string[] BC000F4_A110PageTemplateImage ;
      private short[] BC000F5_A107PageTemplateId ;
      private short[] BC000F3_A107PageTemplateId ;
      private string[] BC000F3_A108PageTemplateName ;
      private string[] BC000F3_A111PageTemplateDescription ;
      private string[] BC000F3_A114PageTemplateHtml ;
      private string[] BC000F3_A113PageTemplateCSS ;
      private string[] BC000F3_A40000PageTemplateImage_GXI ;
      private string[] BC000F3_A110PageTemplateImage ;
      private short[] BC000F2_A107PageTemplateId ;
      private string[] BC000F2_A108PageTemplateName ;
      private string[] BC000F2_A111PageTemplateDescription ;
      private string[] BC000F2_A114PageTemplateHtml ;
      private string[] BC000F2_A113PageTemplateCSS ;
      private string[] BC000F2_A40000PageTemplateImage_GXI ;
      private string[] BC000F2_A110PageTemplateImage ;
      private short[] BC000F7_A107PageTemplateId ;
      private short[] BC000F11_A107PageTemplateId ;
      private string[] BC000F11_A108PageTemplateName ;
      private string[] BC000F11_A111PageTemplateDescription ;
      private string[] BC000F11_A114PageTemplateHtml ;
      private string[] BC000F11_A113PageTemplateCSS ;
      private string[] BC000F11_A40000PageTemplateImage_GXI ;
      private string[] BC000F11_A110PageTemplateImage ;
      private SdtPageTemplate bcPageTemplate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class pagetemplate_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class pagetemplate_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000F2;
        prmBC000F2 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000F3;
        prmBC000F3 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000F4;
        prmBC000F4 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000F5;
        prmBC000F5 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000F6;
        prmBC000F6 = new Object[] {
        new ParDef("PageTemplateName",GXType.VarChar,40,0) ,
        new ParDef("PageTemplateDescription",GXType.VarChar,200,0) ,
        new ParDef("PageTemplateHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateCSS",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("PageTemplateImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="PageTemplate", Fld="PageTemplateImage"}
        };
        Object[] prmBC000F7;
        prmBC000F7 = new Object[] {
        };
        Object[] prmBC000F8;
        prmBC000F8 = new Object[] {
        new ParDef("PageTemplateName",GXType.VarChar,40,0) ,
        new ParDef("PageTemplateDescription",GXType.VarChar,200,0) ,
        new ParDef("PageTemplateHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateCSS",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000F9;
        prmBC000F9 = new Object[] {
        new ParDef("PageTemplateImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("PageTemplateImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="PageTemplate", Fld="PageTemplateImage"} ,
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000F10;
        prmBC000F10 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmBC000F11;
        prmBC000F11 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000F2", "SELECT PageTemplateId, PageTemplateName, PageTemplateDescription, PageTemplateHtml, PageTemplateCSS, PageTemplateImage_GXI, PageTemplateImage FROM PageTemplate WHERE PageTemplateId = :PageTemplateId  FOR UPDATE OF PageTemplate",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F3", "SELECT PageTemplateId, PageTemplateName, PageTemplateDescription, PageTemplateHtml, PageTemplateCSS, PageTemplateImage_GXI, PageTemplateImage FROM PageTemplate WHERE PageTemplateId = :PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F4", "SELECT TM1.PageTemplateId, TM1.PageTemplateName, TM1.PageTemplateDescription, TM1.PageTemplateHtml, TM1.PageTemplateCSS, TM1.PageTemplateImage_GXI, TM1.PageTemplateImage FROM PageTemplate TM1 WHERE TM1.PageTemplateId = :PageTemplateId ORDER BY TM1.PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F5", "SELECT PageTemplateId FROM PageTemplate WHERE PageTemplateId = :PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F6", "SAVEPOINT gxupdate;INSERT INTO PageTemplate(PageTemplateName, PageTemplateDescription, PageTemplateHtml, PageTemplateCSS, PageTemplateImage, PageTemplateImage_GXI) VALUES(:PageTemplateName, :PageTemplateDescription, :PageTemplateHtml, :PageTemplateCSS, :PageTemplateImage, :PageTemplateImage_GXI);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000F6)
           ,new CursorDef("BC000F7", "SELECT currval('PageTemplateId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F8", "SAVEPOINT gxupdate;UPDATE PageTemplate SET PageTemplateName=:PageTemplateName, PageTemplateDescription=:PageTemplateDescription, PageTemplateHtml=:PageTemplateHtml, PageTemplateCSS=:PageTemplateCSS  WHERE PageTemplateId = :PageTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F8)
           ,new CursorDef("BC000F9", "SAVEPOINT gxupdate;UPDATE PageTemplate SET PageTemplateImage=:PageTemplateImage, PageTemplateImage_GXI=:PageTemplateImage_GXI  WHERE PageTemplateId = :PageTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F9)
           ,new CursorDef("BC000F10", "SAVEPOINT gxupdate;DELETE FROM PageTemplate  WHERE PageTemplateId = :PageTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F10)
           ,new CursorDef("BC000F11", "SELECT TM1.PageTemplateId, TM1.PageTemplateName, TM1.PageTemplateDescription, TM1.PageTemplateHtml, TM1.PageTemplateCSS, TM1.PageTemplateImage_GXI, TM1.PageTemplateImage FROM PageTemplate TM1 WHERE TM1.PageTemplateId = :PageTemplateId ORDER BY TM1.PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
     }
  }

}

}
