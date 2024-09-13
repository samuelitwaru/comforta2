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
   public class customercustomization_bc : GxSilentTrn, IGxSilentTrn
   {
      public customercustomization_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customercustomization_bc( IGxContext context )
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
         ReadRow0H27( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0H27( ) ;
         standaloneModal( ) ;
         AddRow0H27( ) ;
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
            E110H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z128CustomerCustomizationId = A128CustomerCustomizationId;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H27( ) ;
            }
            else
            {
               CheckExtendedTable0H27( ) ;
               if ( AnyError == 0 )
               {
                  ZM0H27( 6) ;
               }
               CloseExtendedTableCursors0H27( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV7WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            while ( AV32GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CustomerId") == 0 )
               {
                  AV12Insert_CustomerId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV32GXV1 = (int)(AV32GXV1+1);
            }
         }
      }

      protected void E110H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV11WebSession.Remove(context.GetMessage( "SelectedBaseColor", ""));
         CallWebObject(formatLink("home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E130H2( )
      {
         /* 'DoSelectBaseColor' Routine */
         returnInSub = false;
      }

      protected void ZM0H27( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z131CustomerCustomizationBaseColor = A131CustomerCustomizationBaseColor;
            Z132CustomerCustomizationFontSize = A132CustomerCustomizationFontSize;
            Z1CustomerId = A1CustomerId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z3CustomerName = A3CustomerName;
         }
         if ( GX_JID == -5 )
         {
            Z128CustomerCustomizationId = A128CustomerCustomizationId;
            Z131CustomerCustomizationBaseColor = A131CustomerCustomizationBaseColor;
            Z129CustomerCustomizationLogo = A129CustomerCustomizationLogo;
            Z40000CustomerCustomizationLogo_GXI = A40000CustomerCustomizationLogo_GXI;
            Z130CustomerCustomizationFavicon = A130CustomerCustomizationFavicon;
            Z40001CustomerCustomizationFavicon_G = A40001CustomerCustomizationFavicon_G;
            Z132CustomerCustomizationFontSize = A132CustomerCustomizationFontSize;
            Z1CustomerId = A1CustomerId;
            Z3CustomerName = A3CustomerName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31Pgmname = "CustomerCustomization_BC";
      }

      protected void standaloneModal( )
      {
         GXt_int1 = A1CustomerId;
         new getloggedinusercustomerid(context ).execute( out  GXt_int1) ;
         A1CustomerId = GXt_int1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), "")))) )
         {
            A131CustomerCustomizationBaseColor = AV11WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), ""));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC000H4 */
            pr_default.execute(2, new Object[] {A1CustomerId});
            A3CustomerName = BC000H4_A3CustomerName[0];
            pr_default.close(2);
         }
      }

      protected void Load0H27( )
      {
         /* Using cursor BC000H5 */
         pr_default.execute(3, new Object[] {A128CustomerCustomizationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound27 = 1;
            A131CustomerCustomizationBaseColor = BC000H5_A131CustomerCustomizationBaseColor[0];
            A40000CustomerCustomizationLogo_GXI = BC000H5_A40000CustomerCustomizationLogo_GXI[0];
            A40001CustomerCustomizationFavicon_G = BC000H5_A40001CustomerCustomizationFavicon_G[0];
            A132CustomerCustomizationFontSize = BC000H5_A132CustomerCustomizationFontSize[0];
            A3CustomerName = BC000H5_A3CustomerName[0];
            A1CustomerId = BC000H5_A1CustomerId[0];
            A129CustomerCustomizationLogo = BC000H5_A129CustomerCustomizationLogo[0];
            A130CustomerCustomizationFavicon = BC000H5_A130CustomerCustomizationFavicon[0];
            ZM0H27( -5) ;
         }
         pr_default.close(3);
         OnLoadActions0H27( ) ;
      }

      protected void OnLoadActions0H27( )
      {
      }

      protected void CheckExtendedTable0H27( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000H4 */
         pr_default.execute(2, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
         }
         A3CustomerName = BC000H4_A3CustomerName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0H27( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H27( )
      {
         /* Using cursor BC000H6 */
         pr_default.execute(4, new Object[] {A128CustomerCustomizationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000H3 */
         pr_default.execute(1, new Object[] {A128CustomerCustomizationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H27( 5) ;
            RcdFound27 = 1;
            A128CustomerCustomizationId = BC000H3_A128CustomerCustomizationId[0];
            A131CustomerCustomizationBaseColor = BC000H3_A131CustomerCustomizationBaseColor[0];
            A40000CustomerCustomizationLogo_GXI = BC000H3_A40000CustomerCustomizationLogo_GXI[0];
            A40001CustomerCustomizationFavicon_G = BC000H3_A40001CustomerCustomizationFavicon_G[0];
            A132CustomerCustomizationFontSize = BC000H3_A132CustomerCustomizationFontSize[0];
            A1CustomerId = BC000H3_A1CustomerId[0];
            A129CustomerCustomizationLogo = BC000H3_A129CustomerCustomizationLogo[0];
            A130CustomerCustomizationFavicon = BC000H3_A130CustomerCustomizationFavicon[0];
            Z128CustomerCustomizationId = A128CustomerCustomizationId;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0H27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0H27( ) ;
            }
            Gx_mode = sMode27;
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0H27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode27;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H27( ) ;
         if ( RcdFound27 == 0 )
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
         CONFIRM_0H0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0H27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000H2 */
            pr_default.execute(0, new Object[] {A128CustomerCustomizationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerCustomization"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z131CustomerCustomizationBaseColor, BC000H2_A131CustomerCustomizationBaseColor[0]) != 0 ) || ( StringUtil.StrCmp(Z132CustomerCustomizationFontSize, BC000H2_A132CustomerCustomizationFontSize[0]) != 0 ) || ( Z1CustomerId != BC000H2_A1CustomerId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerCustomization"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H27( )
      {
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H27( 0) ;
            CheckOptimisticConcurrency0H27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H7 */
                     pr_default.execute(5, new Object[] {A131CustomerCustomizationBaseColor, A129CustomerCustomizationLogo, A40000CustomerCustomizationLogo_GXI, A130CustomerCustomizationFavicon, A40001CustomerCustomizationFavicon_G, A132CustomerCustomizationFontSize, A1CustomerId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000H8 */
                     pr_default.execute(6);
                     A128CustomerCustomizationId = BC000H8_A128CustomerCustomizationId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
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
               Load0H27( ) ;
            }
            EndLevel0H27( ) ;
         }
         CloseExtendedTableCursors0H27( ) ;
      }

      protected void Update0H27( )
      {
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H9 */
                     pr_default.execute(7, new Object[] {A131CustomerCustomizationBaseColor, A132CustomerCustomizationFontSize, A1CustomerId, A128CustomerCustomizationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerCustomization"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H27( ) ;
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
            EndLevel0H27( ) ;
         }
         CloseExtendedTableCursors0H27( ) ;
      }

      protected void DeferredUpdate0H27( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000H10 */
            pr_default.execute(8, new Object[] {A129CustomerCustomizationLogo, A40000CustomerCustomizationLogo_GXI, A128CustomerCustomizationId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000H11 */
            pr_default.execute(9, new Object[] {A130CustomerCustomizationFavicon, A40001CustomerCustomizationFavicon_G, A128CustomerCustomizationId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H27( ) ;
            AfterConfirm0H27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000H12 */
                  pr_default.execute(10, new Object[] {A128CustomerCustomizationId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0H27( ) ;
         Gx_mode = sMode27;
      }

      protected void OnDeleteControls0H27( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000H13 */
            pr_default.execute(11, new Object[] {A1CustomerId});
            A3CustomerName = BC000H13_A3CustomerName[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel0H27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H27( ) ;
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

      public void ScanKeyStart0H27( )
      {
         /* Scan By routine */
         /* Using cursor BC000H14 */
         pr_default.execute(12, new Object[] {A128CustomerCustomizationId});
         RcdFound27 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound27 = 1;
            A128CustomerCustomizationId = BC000H14_A128CustomerCustomizationId[0];
            A131CustomerCustomizationBaseColor = BC000H14_A131CustomerCustomizationBaseColor[0];
            A40000CustomerCustomizationLogo_GXI = BC000H14_A40000CustomerCustomizationLogo_GXI[0];
            A40001CustomerCustomizationFavicon_G = BC000H14_A40001CustomerCustomizationFavicon_G[0];
            A132CustomerCustomizationFontSize = BC000H14_A132CustomerCustomizationFontSize[0];
            A3CustomerName = BC000H14_A3CustomerName[0];
            A1CustomerId = BC000H14_A1CustomerId[0];
            A129CustomerCustomizationLogo = BC000H14_A129CustomerCustomizationLogo[0];
            A130CustomerCustomizationFavicon = BC000H14_A130CustomerCustomizationFavicon[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0H27( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound27 = 0;
         ScanKeyLoad0H27( ) ;
      }

      protected void ScanKeyLoad0H27( )
      {
         sMode27 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound27 = 1;
            A128CustomerCustomizationId = BC000H14_A128CustomerCustomizationId[0];
            A131CustomerCustomizationBaseColor = BC000H14_A131CustomerCustomizationBaseColor[0];
            A40000CustomerCustomizationLogo_GXI = BC000H14_A40000CustomerCustomizationLogo_GXI[0];
            A40001CustomerCustomizationFavicon_G = BC000H14_A40001CustomerCustomizationFavicon_G[0];
            A132CustomerCustomizationFontSize = BC000H14_A132CustomerCustomizationFontSize[0];
            A3CustomerName = BC000H14_A3CustomerName[0];
            A1CustomerId = BC000H14_A1CustomerId[0];
            A129CustomerCustomizationLogo = BC000H14_A129CustomerCustomizationLogo[0];
            A130CustomerCustomizationFavicon = BC000H14_A130CustomerCustomizationFavicon[0];
         }
         Gx_mode = sMode27;
      }

      protected void ScanKeyEnd0H27( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0H27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H27( )
      {
      }

      protected void send_integrity_lvl_hashes0H27( )
      {
      }

      protected void AddRow0H27( )
      {
         VarsToRow27( bcCustomerCustomization) ;
      }

      protected void ReadRow0H27( )
      {
         RowToVars27( bcCustomerCustomization, 1) ;
      }

      protected void InitializeNonKey0H27( )
      {
         A1CustomerId = 0;
         A131CustomerCustomizationBaseColor = "";
         A129CustomerCustomizationLogo = "";
         A40000CustomerCustomizationLogo_GXI = "";
         A130CustomerCustomizationFavicon = "";
         A40001CustomerCustomizationFavicon_G = "";
         A132CustomerCustomizationFontSize = "";
         A3CustomerName = "";
         Z131CustomerCustomizationBaseColor = "";
         Z132CustomerCustomizationFontSize = "";
         Z1CustomerId = 0;
      }

      protected void InitAll0H27( )
      {
         A128CustomerCustomizationId = 0;
         InitializeNonKey0H27( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1CustomerId = i1CustomerId;
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

      public void VarsToRow27( SdtCustomerCustomization obj27 )
      {
         obj27.gxTpr_Mode = Gx_mode;
         obj27.gxTpr_Customerid = A1CustomerId;
         obj27.gxTpr_Customercustomizationbasecolor = A131CustomerCustomizationBaseColor;
         obj27.gxTpr_Customercustomizationlogo = A129CustomerCustomizationLogo;
         obj27.gxTpr_Customercustomizationlogo_gxi = A40000CustomerCustomizationLogo_GXI;
         obj27.gxTpr_Customercustomizationfavicon = A130CustomerCustomizationFavicon;
         obj27.gxTpr_Customercustomizationfavicon_gxi = A40001CustomerCustomizationFavicon_G;
         obj27.gxTpr_Customercustomizationfontsize = A132CustomerCustomizationFontSize;
         obj27.gxTpr_Customername = A3CustomerName;
         obj27.gxTpr_Customercustomizationid = A128CustomerCustomizationId;
         obj27.gxTpr_Customercustomizationid_Z = Z128CustomerCustomizationId;
         obj27.gxTpr_Customercustomizationbasecolor_Z = Z131CustomerCustomizationBaseColor;
         obj27.gxTpr_Customercustomizationfontsize_Z = Z132CustomerCustomizationFontSize;
         obj27.gxTpr_Customerid_Z = Z1CustomerId;
         obj27.gxTpr_Customername_Z = Z3CustomerName;
         obj27.gxTpr_Customercustomizationlogo_gxi_Z = Z40000CustomerCustomizationLogo_GXI;
         obj27.gxTpr_Customercustomizationfavicon_gxi_Z = Z40001CustomerCustomizationFavicon_G;
         obj27.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow27( SdtCustomerCustomization obj27 )
      {
         obj27.gxTpr_Customercustomizationid = A128CustomerCustomizationId;
         return  ;
      }

      public void RowToVars27( SdtCustomerCustomization obj27 ,
                               int forceLoad )
      {
         Gx_mode = obj27.gxTpr_Mode;
         A1CustomerId = obj27.gxTpr_Customerid;
         A131CustomerCustomizationBaseColor = obj27.gxTpr_Customercustomizationbasecolor;
         A129CustomerCustomizationLogo = obj27.gxTpr_Customercustomizationlogo;
         A40000CustomerCustomizationLogo_GXI = obj27.gxTpr_Customercustomizationlogo_gxi;
         A130CustomerCustomizationFavicon = obj27.gxTpr_Customercustomizationfavicon;
         A40001CustomerCustomizationFavicon_G = obj27.gxTpr_Customercustomizationfavicon_gxi;
         A132CustomerCustomizationFontSize = obj27.gxTpr_Customercustomizationfontsize;
         A3CustomerName = obj27.gxTpr_Customername;
         A128CustomerCustomizationId = obj27.gxTpr_Customercustomizationid;
         Z128CustomerCustomizationId = obj27.gxTpr_Customercustomizationid_Z;
         Z131CustomerCustomizationBaseColor = obj27.gxTpr_Customercustomizationbasecolor_Z;
         Z132CustomerCustomizationFontSize = obj27.gxTpr_Customercustomizationfontsize_Z;
         Z1CustomerId = obj27.gxTpr_Customerid_Z;
         Z3CustomerName = obj27.gxTpr_Customername_Z;
         Z40000CustomerCustomizationLogo_GXI = obj27.gxTpr_Customercustomizationlogo_gxi_Z;
         Z40001CustomerCustomizationFavicon_G = obj27.gxTpr_Customercustomizationfavicon_gxi_Z;
         Gx_mode = obj27.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A128CustomerCustomizationId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0H27( ) ;
         ScanKeyStart0H27( ) ;
         if ( RcdFound27 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z128CustomerCustomizationId = A128CustomerCustomizationId;
         }
         ZM0H27( -5) ;
         OnLoadActions0H27( ) ;
         AddRow0H27( ) ;
         ScanKeyEnd0H27( ) ;
         if ( RcdFound27 == 0 )
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
         RowToVars27( bcCustomerCustomization, 0) ;
         ScanKeyStart0H27( ) ;
         if ( RcdFound27 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z128CustomerCustomizationId = A128CustomerCustomizationId;
         }
         ZM0H27( -5) ;
         OnLoadActions0H27( ) ;
         AddRow0H27( ) ;
         ScanKeyEnd0H27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0H27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0H27( ) ;
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( A128CustomerCustomizationId != Z128CustomerCustomizationId )
               {
                  A128CustomerCustomizationId = Z128CustomerCustomizationId;
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
                  Update0H27( ) ;
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
                  if ( A128CustomerCustomizationId != Z128CustomerCustomizationId )
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
                        Insert0H27( ) ;
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
                        Insert0H27( ) ;
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
         RowToVars27( bcCustomerCustomization, 1) ;
         SaveImpl( ) ;
         VarsToRow27( bcCustomerCustomization) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars27( bcCustomerCustomization, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H27( ) ;
         AfterTrn( ) ;
         VarsToRow27( bcCustomerCustomization) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow27( bcCustomerCustomization) ;
         }
         else
         {
            SdtCustomerCustomization auxBC = new SdtCustomerCustomization(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A128CustomerCustomizationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCustomerCustomization);
               auxBC.Save();
               bcCustomerCustomization.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars27( bcCustomerCustomization, 1) ;
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
         RowToVars27( bcCustomerCustomization, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H27( ) ;
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
               VarsToRow27( bcCustomerCustomization) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow27( bcCustomerCustomization) ;
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
         RowToVars27( bcCustomerCustomization, 0) ;
         GetKey0H27( ) ;
         if ( RcdFound27 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A128CustomerCustomizationId != Z128CustomerCustomizationId )
            {
               A128CustomerCustomizationId = Z128CustomerCustomizationId;
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
            if ( A128CustomerCustomizationId != Z128CustomerCustomizationId )
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
         context.RollbackDataStores("customercustomization_bc",pr_default);
         VarsToRow27( bcCustomerCustomization) ;
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
         Gx_mode = bcCustomerCustomization.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCustomerCustomization.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCustomerCustomization )
         {
            bcCustomerCustomization = (SdtCustomerCustomization)(sdt);
            if ( StringUtil.StrCmp(bcCustomerCustomization.gxTpr_Mode, "") == 0 )
            {
               bcCustomerCustomization.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow27( bcCustomerCustomization) ;
            }
            else
            {
               RowToVars27( bcCustomerCustomization, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCustomerCustomization.gxTpr_Mode, "") == 0 )
            {
               bcCustomerCustomization.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars27( bcCustomerCustomization, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCustomerCustomization CustomerCustomization_BC
      {
         get {
            return bcCustomerCustomization ;
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
            return "customercustomization_Execute" ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV7WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV31Pgmname = "";
         AV13TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z131CustomerCustomizationBaseColor = "";
         A131CustomerCustomizationBaseColor = "";
         Z132CustomerCustomizationFontSize = "";
         A132CustomerCustomizationFontSize = "";
         Z3CustomerName = "";
         A3CustomerName = "";
         Z129CustomerCustomizationLogo = "";
         A129CustomerCustomizationLogo = "";
         Z40000CustomerCustomizationLogo_GXI = "";
         A40000CustomerCustomizationLogo_GXI = "";
         Z130CustomerCustomizationFavicon = "";
         A130CustomerCustomizationFavicon = "";
         Z40001CustomerCustomizationFavicon_G = "";
         A40001CustomerCustomizationFavicon_G = "";
         BC000H4_A3CustomerName = new string[] {""} ;
         BC000H5_A128CustomerCustomizationId = new short[1] ;
         BC000H5_A131CustomerCustomizationBaseColor = new string[] {""} ;
         BC000H5_A40000CustomerCustomizationLogo_GXI = new string[] {""} ;
         BC000H5_A40001CustomerCustomizationFavicon_G = new string[] {""} ;
         BC000H5_A132CustomerCustomizationFontSize = new string[] {""} ;
         BC000H5_A3CustomerName = new string[] {""} ;
         BC000H5_A1CustomerId = new short[1] ;
         BC000H5_A129CustomerCustomizationLogo = new string[] {""} ;
         BC000H5_A130CustomerCustomizationFavicon = new string[] {""} ;
         BC000H6_A128CustomerCustomizationId = new short[1] ;
         BC000H3_A128CustomerCustomizationId = new short[1] ;
         BC000H3_A131CustomerCustomizationBaseColor = new string[] {""} ;
         BC000H3_A40000CustomerCustomizationLogo_GXI = new string[] {""} ;
         BC000H3_A40001CustomerCustomizationFavicon_G = new string[] {""} ;
         BC000H3_A132CustomerCustomizationFontSize = new string[] {""} ;
         BC000H3_A1CustomerId = new short[1] ;
         BC000H3_A129CustomerCustomizationLogo = new string[] {""} ;
         BC000H3_A130CustomerCustomizationFavicon = new string[] {""} ;
         sMode27 = "";
         BC000H2_A128CustomerCustomizationId = new short[1] ;
         BC000H2_A131CustomerCustomizationBaseColor = new string[] {""} ;
         BC000H2_A40000CustomerCustomizationLogo_GXI = new string[] {""} ;
         BC000H2_A40001CustomerCustomizationFavicon_G = new string[] {""} ;
         BC000H2_A132CustomerCustomizationFontSize = new string[] {""} ;
         BC000H2_A1CustomerId = new short[1] ;
         BC000H2_A129CustomerCustomizationLogo = new string[] {""} ;
         BC000H2_A130CustomerCustomizationFavicon = new string[] {""} ;
         BC000H8_A128CustomerCustomizationId = new short[1] ;
         BC000H13_A3CustomerName = new string[] {""} ;
         BC000H14_A128CustomerCustomizationId = new short[1] ;
         BC000H14_A131CustomerCustomizationBaseColor = new string[] {""} ;
         BC000H14_A40000CustomerCustomizationLogo_GXI = new string[] {""} ;
         BC000H14_A40001CustomerCustomizationFavicon_G = new string[] {""} ;
         BC000H14_A132CustomerCustomizationFontSize = new string[] {""} ;
         BC000H14_A3CustomerName = new string[] {""} ;
         BC000H14_A1CustomerId = new short[1] ;
         BC000H14_A129CustomerCustomizationLogo = new string[] {""} ;
         BC000H14_A130CustomerCustomizationFavicon = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.customercustomization_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customercustomization_bc__default(),
            new Object[][] {
                new Object[] {
               BC000H2_A128CustomerCustomizationId, BC000H2_A131CustomerCustomizationBaseColor, BC000H2_A40000CustomerCustomizationLogo_GXI, BC000H2_A40001CustomerCustomizationFavicon_G, BC000H2_A132CustomerCustomizationFontSize, BC000H2_A1CustomerId, BC000H2_A129CustomerCustomizationLogo, BC000H2_A130CustomerCustomizationFavicon
               }
               , new Object[] {
               BC000H3_A128CustomerCustomizationId, BC000H3_A131CustomerCustomizationBaseColor, BC000H3_A40000CustomerCustomizationLogo_GXI, BC000H3_A40001CustomerCustomizationFavicon_G, BC000H3_A132CustomerCustomizationFontSize, BC000H3_A1CustomerId, BC000H3_A129CustomerCustomizationLogo, BC000H3_A130CustomerCustomizationFavicon
               }
               , new Object[] {
               BC000H4_A3CustomerName
               }
               , new Object[] {
               BC000H5_A128CustomerCustomizationId, BC000H5_A131CustomerCustomizationBaseColor, BC000H5_A40000CustomerCustomizationLogo_GXI, BC000H5_A40001CustomerCustomizationFavicon_G, BC000H5_A132CustomerCustomizationFontSize, BC000H5_A3CustomerName, BC000H5_A1CustomerId, BC000H5_A129CustomerCustomizationLogo, BC000H5_A130CustomerCustomizationFavicon
               }
               , new Object[] {
               BC000H6_A128CustomerCustomizationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H8_A128CustomerCustomizationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H13_A3CustomerName
               }
               , new Object[] {
               BC000H14_A128CustomerCustomizationId, BC000H14_A131CustomerCustomizationBaseColor, BC000H14_A40000CustomerCustomizationLogo_GXI, BC000H14_A40001CustomerCustomizationFavicon_G, BC000H14_A132CustomerCustomizationFontSize, BC000H14_A3CustomerName, BC000H14_A1CustomerId, BC000H14_A129CustomerCustomizationLogo, BC000H14_A130CustomerCustomizationFavicon
               }
            }
         );
         AV31Pgmname = "CustomerCustomization_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120H2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z128CustomerCustomizationId ;
      private short A128CustomerCustomizationId ;
      private short AV12Insert_CustomerId ;
      private short Z1CustomerId ;
      private short A1CustomerId ;
      private short GXt_int1 ;
      private short Gx_BScreen ;
      private short RcdFound27 ;
      private short i1CustomerId ;
      private int trnEnded ;
      private int AV32GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV31Pgmname ;
      private string sMode27 ;
      private bool returnInSub ;
      private string Z131CustomerCustomizationBaseColor ;
      private string A131CustomerCustomizationBaseColor ;
      private string Z132CustomerCustomizationFontSize ;
      private string A132CustomerCustomizationFontSize ;
      private string Z3CustomerName ;
      private string A3CustomerName ;
      private string Z40000CustomerCustomizationLogo_GXI ;
      private string A40000CustomerCustomizationLogo_GXI ;
      private string Z40001CustomerCustomizationFavicon_G ;
      private string A40001CustomerCustomizationFavicon_G ;
      private string Z129CustomerCustomizationLogo ;
      private string A129CustomerCustomizationLogo ;
      private string Z130CustomerCustomizationFavicon ;
      private string A130CustomerCustomizationFavicon ;
      private IGxSession AV11WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV7WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] BC000H4_A3CustomerName ;
      private short[] BC000H5_A128CustomerCustomizationId ;
      private string[] BC000H5_A131CustomerCustomizationBaseColor ;
      private string[] BC000H5_A40000CustomerCustomizationLogo_GXI ;
      private string[] BC000H5_A40001CustomerCustomizationFavicon_G ;
      private string[] BC000H5_A132CustomerCustomizationFontSize ;
      private string[] BC000H5_A3CustomerName ;
      private short[] BC000H5_A1CustomerId ;
      private string[] BC000H5_A129CustomerCustomizationLogo ;
      private string[] BC000H5_A130CustomerCustomizationFavicon ;
      private short[] BC000H6_A128CustomerCustomizationId ;
      private short[] BC000H3_A128CustomerCustomizationId ;
      private string[] BC000H3_A131CustomerCustomizationBaseColor ;
      private string[] BC000H3_A40000CustomerCustomizationLogo_GXI ;
      private string[] BC000H3_A40001CustomerCustomizationFavicon_G ;
      private string[] BC000H3_A132CustomerCustomizationFontSize ;
      private short[] BC000H3_A1CustomerId ;
      private string[] BC000H3_A129CustomerCustomizationLogo ;
      private string[] BC000H3_A130CustomerCustomizationFavicon ;
      private short[] BC000H2_A128CustomerCustomizationId ;
      private string[] BC000H2_A131CustomerCustomizationBaseColor ;
      private string[] BC000H2_A40000CustomerCustomizationLogo_GXI ;
      private string[] BC000H2_A40001CustomerCustomizationFavicon_G ;
      private string[] BC000H2_A132CustomerCustomizationFontSize ;
      private short[] BC000H2_A1CustomerId ;
      private string[] BC000H2_A129CustomerCustomizationLogo ;
      private string[] BC000H2_A130CustomerCustomizationFavicon ;
      private short[] BC000H8_A128CustomerCustomizationId ;
      private string[] BC000H13_A3CustomerName ;
      private short[] BC000H14_A128CustomerCustomizationId ;
      private string[] BC000H14_A131CustomerCustomizationBaseColor ;
      private string[] BC000H14_A40000CustomerCustomizationLogo_GXI ;
      private string[] BC000H14_A40001CustomerCustomizationFavicon_G ;
      private string[] BC000H14_A132CustomerCustomizationFontSize ;
      private string[] BC000H14_A3CustomerName ;
      private short[] BC000H14_A1CustomerId ;
      private string[] BC000H14_A129CustomerCustomizationLogo ;
      private string[] BC000H14_A130CustomerCustomizationFavicon ;
      private SdtCustomerCustomization bcCustomerCustomization ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class customercustomization_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class customercustomization_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000H2;
        prmBC000H2 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmBC000H3;
        prmBC000H3 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmBC000H4;
        prmBC000H4 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000H5;
        prmBC000H5 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmBC000H6;
        prmBC000H6 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmBC000H7;
        prmBC000H7 = new Object[] {
        new ParDef("CustomerCustomizationBaseColor",GXType.VarChar,40,0) ,
        new ParDef("CustomerCustomizationLogo",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("CustomerCustomizationLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="CustomerCustomization", Fld="CustomerCustomizationLogo"} ,
        new ParDef("CustomerCustomizationFavicon",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("CustomerCustomizationFavicon_G",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="CustomerCustomization", Fld="CustomerCustomizationFavicon"} ,
        new ParDef("CustomerCustomizationFontSize",GXType.VarChar,40,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000H8;
        prmBC000H8 = new Object[] {
        };
        Object[] prmBC000H9;
        prmBC000H9 = new Object[] {
        new ParDef("CustomerCustomizationBaseColor",GXType.VarChar,40,0) ,
        new ParDef("CustomerCustomizationFontSize",GXType.VarChar,40,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmBC000H10;
        prmBC000H10 = new Object[] {
        new ParDef("CustomerCustomizationLogo",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("CustomerCustomizationLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="CustomerCustomization", Fld="CustomerCustomizationLogo"} ,
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmBC000H11;
        prmBC000H11 = new Object[] {
        new ParDef("CustomerCustomizationFavicon",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("CustomerCustomizationFavicon_G",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="CustomerCustomization", Fld="CustomerCustomizationFavicon"} ,
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmBC000H12;
        prmBC000H12 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmBC000H13;
        prmBC000H13 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000H14;
        prmBC000H14 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000H2", "SELECT CustomerCustomizationId, CustomerCustomizationBaseColor, CustomerCustomizationLogo_GXI, CustomerCustomizationFavicon_G, CustomerCustomizationFontSize, CustomerId, CustomerCustomizationLogo, CustomerCustomizationFavicon FROM CustomerCustomization WHERE CustomerCustomizationId = :CustomerCustomizationId  FOR UPDATE OF CustomerCustomization",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H3", "SELECT CustomerCustomizationId, CustomerCustomizationBaseColor, CustomerCustomizationLogo_GXI, CustomerCustomizationFavicon_G, CustomerCustomizationFontSize, CustomerId, CustomerCustomizationLogo, CustomerCustomizationFavicon FROM CustomerCustomization WHERE CustomerCustomizationId = :CustomerCustomizationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H4", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H5", "SELECT TM1.CustomerCustomizationId, TM1.CustomerCustomizationBaseColor, TM1.CustomerCustomizationLogo_GXI, TM1.CustomerCustomizationFavicon_G, TM1.CustomerCustomizationFontSize, T2.CustomerName, TM1.CustomerId, TM1.CustomerCustomizationLogo, TM1.CustomerCustomizationFavicon FROM (CustomerCustomization TM1 INNER JOIN Customer T2 ON T2.CustomerId = TM1.CustomerId) WHERE TM1.CustomerCustomizationId = :CustomerCustomizationId ORDER BY TM1.CustomerCustomizationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H6", "SELECT CustomerCustomizationId FROM CustomerCustomization WHERE CustomerCustomizationId = :CustomerCustomizationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H7", "SAVEPOINT gxupdate;INSERT INTO CustomerCustomization(CustomerCustomizationBaseColor, CustomerCustomizationLogo, CustomerCustomizationLogo_GXI, CustomerCustomizationFavicon, CustomerCustomizationFavicon_G, CustomerCustomizationFontSize, CustomerId) VALUES(:CustomerCustomizationBaseColor, :CustomerCustomizationLogo, :CustomerCustomizationLogo_GXI, :CustomerCustomizationFavicon, :CustomerCustomizationFavicon_G, :CustomerCustomizationFontSize, :CustomerId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000H7)
           ,new CursorDef("BC000H8", "SELECT currval('CustomerCustomizationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H9", "SAVEPOINT gxupdate;UPDATE CustomerCustomization SET CustomerCustomizationBaseColor=:CustomerCustomizationBaseColor, CustomerCustomizationFontSize=:CustomerCustomizationFontSize, CustomerId=:CustomerId  WHERE CustomerCustomizationId = :CustomerCustomizationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H9)
           ,new CursorDef("BC000H10", "SAVEPOINT gxupdate;UPDATE CustomerCustomization SET CustomerCustomizationLogo=:CustomerCustomizationLogo, CustomerCustomizationLogo_GXI=:CustomerCustomizationLogo_GXI  WHERE CustomerCustomizationId = :CustomerCustomizationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H10)
           ,new CursorDef("BC000H11", "SAVEPOINT gxupdate;UPDATE CustomerCustomization SET CustomerCustomizationFavicon=:CustomerCustomizationFavicon, CustomerCustomizationFavicon_G=:CustomerCustomizationFavicon_G  WHERE CustomerCustomizationId = :CustomerCustomizationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H11)
           ,new CursorDef("BC000H12", "SAVEPOINT gxupdate;DELETE FROM CustomerCustomization  WHERE CustomerCustomizationId = :CustomerCustomizationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H12)
           ,new CursorDef("BC000H13", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H14", "SELECT TM1.CustomerCustomizationId, TM1.CustomerCustomizationBaseColor, TM1.CustomerCustomizationLogo_GXI, TM1.CustomerCustomizationFavicon_G, TM1.CustomerCustomizationFontSize, T2.CustomerName, TM1.CustomerId, TM1.CustomerCustomizationLogo, TM1.CustomerCustomizationFavicon FROM (CustomerCustomization TM1 INNER JOIN Customer T2 ON T2.CustomerId = TM1.CustomerId) WHERE TM1.CustomerCustomizationId = :CustomerCustomizationId ORDER BY TM1.CustomerCustomizationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H14,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
              return;
     }
  }

}

}
