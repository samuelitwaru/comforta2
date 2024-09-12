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
namespace GeneXus.Programs.wwpbaseobjects {
   public class usercustomizations_bc : GxSilentTrn, IGxSilentTrn
   {
      public usercustomizations_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usercustomizations_bc( IGxContext context )
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
         ReadRow0B20( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B20( ) ;
         standaloneModal( ) ;
         AddRow0B20( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z90UserCustomizationsId = A90UserCustomizationsId;
               Z91UserCustomizationsKey = A91UserCustomizationsKey;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B20( ) ;
            }
            else
            {
               CheckExtendedTable0B20( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0B20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0B20( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z90UserCustomizationsId = A90UserCustomizationsId;
            Z91UserCustomizationsKey = A91UserCustomizationsKey;
            Z92UserCustomizationsValue = A92UserCustomizationsValue;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0B20( )
      {
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {A90UserCustomizationsId, A91UserCustomizationsKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound20 = 1;
            A92UserCustomizationsValue = BC000B4_A92UserCustomizationsValue[0];
            ZM0B20( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0B20( ) ;
      }

      protected void OnLoadActions0B20( )
      {
      }

      protected void CheckExtendedTable0B20( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0B20( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B20( )
      {
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A90UserCustomizationsId, A91UserCustomizationsKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A90UserCustomizationsId, A91UserCustomizationsKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B20( 1) ;
            RcdFound20 = 1;
            A90UserCustomizationsId = BC000B3_A90UserCustomizationsId[0];
            A91UserCustomizationsKey = BC000B3_A91UserCustomizationsKey[0];
            A92UserCustomizationsValue = BC000B3_A92UserCustomizationsValue[0];
            Z90UserCustomizationsId = A90UserCustomizationsId;
            Z91UserCustomizationsKey = A91UserCustomizationsKey;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0B20( ) ;
            }
            Gx_mode = sMode20;
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0B20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode20;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B20( ) ;
         if ( RcdFound20 == 0 )
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
         CONFIRM_0B0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0B20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A90UserCustomizationsId, A91UserCustomizationsKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UserCustomizations"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B20( )
      {
         BeforeValidate0B20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B20( 0) ;
            CheckOptimisticConcurrency0B20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B6 */
                     pr_default.execute(4, new Object[] {A90UserCustomizationsId, A91UserCustomizationsKey, A92UserCustomizationsValue});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load0B20( ) ;
            }
            EndLevel0B20( ) ;
         }
         CloseExtendedTableCursors0B20( ) ;
      }

      protected void Update0B20( )
      {
         BeforeValidate0B20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B7 */
                     pr_default.execute(5, new Object[] {A92UserCustomizationsValue, A90UserCustomizationsId, A91UserCustomizationsKey});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B20( ) ;
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
            EndLevel0B20( ) ;
         }
         CloseExtendedTableCursors0B20( ) ;
      }

      protected void DeferredUpdate0B20( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B20( ) ;
            AfterConfirm0B20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B8 */
                  pr_default.execute(6, new Object[] {A90UserCustomizationsId, A91UserCustomizationsKey});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B20( ) ;
         Gx_mode = sMode20;
      }

      protected void OnDeleteControls0B20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0B20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B20( ) ;
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

      public void ScanKeyStart0B20( )
      {
         /* Using cursor BC000B9 */
         pr_default.execute(7, new Object[] {A90UserCustomizationsId, A91UserCustomizationsKey});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound20 = 1;
            A90UserCustomizationsId = BC000B9_A90UserCustomizationsId[0];
            A91UserCustomizationsKey = BC000B9_A91UserCustomizationsKey[0];
            A92UserCustomizationsValue = BC000B9_A92UserCustomizationsValue[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B20( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound20 = 0;
         ScanKeyLoad0B20( ) ;
      }

      protected void ScanKeyLoad0B20( )
      {
         sMode20 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound20 = 1;
            A90UserCustomizationsId = BC000B9_A90UserCustomizationsId[0];
            A91UserCustomizationsKey = BC000B9_A91UserCustomizationsKey[0];
            A92UserCustomizationsValue = BC000B9_A92UserCustomizationsValue[0];
         }
         Gx_mode = sMode20;
      }

      protected void ScanKeyEnd0B20( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0B20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B20( )
      {
      }

      protected void send_integrity_lvl_hashes0B20( )
      {
      }

      protected void AddRow0B20( )
      {
         VarsToRow20( bcwwpbaseobjects_UserCustomizations) ;
      }

      protected void ReadRow0B20( )
      {
         RowToVars20( bcwwpbaseobjects_UserCustomizations, 1) ;
      }

      protected void InitializeNonKey0B20( )
      {
         A92UserCustomizationsValue = "";
      }

      protected void InitAll0B20( )
      {
         A90UserCustomizationsId = "";
         A91UserCustomizationsKey = "";
         InitializeNonKey0B20( ) ;
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

      public void VarsToRow20( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj20 )
      {
         obj20.gxTpr_Mode = Gx_mode;
         obj20.gxTpr_Usercustomizationsvalue = A92UserCustomizationsValue;
         obj20.gxTpr_Usercustomizationsid = A90UserCustomizationsId;
         obj20.gxTpr_Usercustomizationskey = A91UserCustomizationsKey;
         obj20.gxTpr_Usercustomizationsid_Z = Z90UserCustomizationsId;
         obj20.gxTpr_Usercustomizationskey_Z = Z91UserCustomizationsKey;
         obj20.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow20( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj20 )
      {
         obj20.gxTpr_Usercustomizationsid = A90UserCustomizationsId;
         obj20.gxTpr_Usercustomizationskey = A91UserCustomizationsKey;
         return  ;
      }

      public void RowToVars20( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj20 ,
                               int forceLoad )
      {
         Gx_mode = obj20.gxTpr_Mode;
         A92UserCustomizationsValue = obj20.gxTpr_Usercustomizationsvalue;
         A90UserCustomizationsId = obj20.gxTpr_Usercustomizationsid;
         A91UserCustomizationsKey = obj20.gxTpr_Usercustomizationskey;
         Z90UserCustomizationsId = obj20.gxTpr_Usercustomizationsid_Z;
         Z91UserCustomizationsKey = obj20.gxTpr_Usercustomizationskey_Z;
         Gx_mode = obj20.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A90UserCustomizationsId = (string)getParm(obj,0);
         A91UserCustomizationsKey = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B20( ) ;
         ScanKeyStart0B20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z90UserCustomizationsId = A90UserCustomizationsId;
            Z91UserCustomizationsKey = A91UserCustomizationsKey;
         }
         ZM0B20( -1) ;
         OnLoadActions0B20( ) ;
         AddRow0B20( ) ;
         ScanKeyEnd0B20( ) ;
         if ( RcdFound20 == 0 )
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
         RowToVars20( bcwwpbaseobjects_UserCustomizations, 0) ;
         ScanKeyStart0B20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z90UserCustomizationsId = A90UserCustomizationsId;
            Z91UserCustomizationsKey = A91UserCustomizationsKey;
         }
         ZM0B20( -1) ;
         OnLoadActions0B20( ) ;
         AddRow0B20( ) ;
         ScanKeyEnd0B20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0B20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B20( ) ;
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( ( StringUtil.StrCmp(A90UserCustomizationsId, Z90UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A91UserCustomizationsKey, Z91UserCustomizationsKey) != 0 ) )
               {
                  A90UserCustomizationsId = Z90UserCustomizationsId;
                  A91UserCustomizationsKey = Z91UserCustomizationsKey;
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
                  Update0B20( ) ;
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
                  if ( ( StringUtil.StrCmp(A90UserCustomizationsId, Z90UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A91UserCustomizationsKey, Z91UserCustomizationsKey) != 0 ) )
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
                        Insert0B20( ) ;
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
                        Insert0B20( ) ;
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
         RowToVars20( bcwwpbaseobjects_UserCustomizations, 1) ;
         SaveImpl( ) ;
         VarsToRow20( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars20( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B20( ) ;
         AfterTrn( ) ;
         VarsToRow20( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow20( bcwwpbaseobjects_UserCustomizations) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations auxBC = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A90UserCustomizationsId, A91UserCustomizationsKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_UserCustomizations);
               auxBC.Save();
               bcwwpbaseobjects_UserCustomizations.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars20( bcwwpbaseobjects_UserCustomizations, 1) ;
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
         RowToVars20( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B20( ) ;
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
               VarsToRow20( bcwwpbaseobjects_UserCustomizations) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow20( bcwwpbaseobjects_UserCustomizations) ;
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
         RowToVars20( bcwwpbaseobjects_UserCustomizations, 0) ;
         GetKey0B20( ) ;
         if ( RcdFound20 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( StringUtil.StrCmp(A90UserCustomizationsId, Z90UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A91UserCustomizationsKey, Z91UserCustomizationsKey) != 0 ) )
            {
               A90UserCustomizationsId = Z90UserCustomizationsId;
               A91UserCustomizationsKey = Z91UserCustomizationsKey;
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
            if ( ( StringUtil.StrCmp(A90UserCustomizationsId, Z90UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A91UserCustomizationsKey, Z91UserCustomizationsKey) != 0 ) )
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
         context.RollbackDataStores("wwpbaseobjects.usercustomizations_bc",pr_default);
         VarsToRow20( bcwwpbaseobjects_UserCustomizations) ;
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
         Gx_mode = bcwwpbaseobjects_UserCustomizations.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_UserCustomizations )
         {
            bcwwpbaseobjects_UserCustomizations = (GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow20( bcwwpbaseobjects_UserCustomizations) ;
            }
            else
            {
               RowToVars20( bcwwpbaseobjects_UserCustomizations, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars20( bcwwpbaseobjects_UserCustomizations, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtUserCustomizations UserCustomizations_BC
      {
         get {
            return bcwwpbaseobjects_UserCustomizations ;
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
            return "usercustomizations_Execute" ;
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
         Z90UserCustomizationsId = "";
         A90UserCustomizationsId = "";
         Z91UserCustomizationsKey = "";
         A91UserCustomizationsKey = "";
         Z92UserCustomizationsValue = "";
         A92UserCustomizationsValue = "";
         BC000B4_A90UserCustomizationsId = new string[] {""} ;
         BC000B4_A91UserCustomizationsKey = new string[] {""} ;
         BC000B4_A92UserCustomizationsValue = new string[] {""} ;
         BC000B5_A90UserCustomizationsId = new string[] {""} ;
         BC000B5_A91UserCustomizationsKey = new string[] {""} ;
         BC000B3_A90UserCustomizationsId = new string[] {""} ;
         BC000B3_A91UserCustomizationsKey = new string[] {""} ;
         BC000B3_A92UserCustomizationsValue = new string[] {""} ;
         sMode20 = "";
         BC000B2_A90UserCustomizationsId = new string[] {""} ;
         BC000B2_A91UserCustomizationsKey = new string[] {""} ;
         BC000B2_A92UserCustomizationsValue = new string[] {""} ;
         BC000B9_A90UserCustomizationsId = new string[] {""} ;
         BC000B9_A91UserCustomizationsKey = new string[] {""} ;
         BC000B9_A92UserCustomizationsValue = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A90UserCustomizationsId, BC000B2_A91UserCustomizationsKey, BC000B2_A92UserCustomizationsValue
               }
               , new Object[] {
               BC000B3_A90UserCustomizationsId, BC000B3_A91UserCustomizationsKey, BC000B3_A92UserCustomizationsValue
               }
               , new Object[] {
               BC000B4_A90UserCustomizationsId, BC000B4_A91UserCustomizationsKey, BC000B4_A92UserCustomizationsValue
               }
               , new Object[] {
               BC000B5_A90UserCustomizationsId, BC000B5_A91UserCustomizationsKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B9_A90UserCustomizationsId, BC000B9_A91UserCustomizationsKey, BC000B9_A92UserCustomizationsValue
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound20 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z90UserCustomizationsId ;
      private string A90UserCustomizationsId ;
      private string sMode20 ;
      private string Z92UserCustomizationsValue ;
      private string A92UserCustomizationsValue ;
      private string Z91UserCustomizationsKey ;
      private string A91UserCustomizationsKey ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000B4_A90UserCustomizationsId ;
      private string[] BC000B4_A91UserCustomizationsKey ;
      private string[] BC000B4_A92UserCustomizationsValue ;
      private string[] BC000B5_A90UserCustomizationsId ;
      private string[] BC000B5_A91UserCustomizationsKey ;
      private string[] BC000B3_A90UserCustomizationsId ;
      private string[] BC000B3_A91UserCustomizationsKey ;
      private string[] BC000B3_A92UserCustomizationsValue ;
      private string[] BC000B2_A90UserCustomizationsId ;
      private string[] BC000B2_A91UserCustomizationsKey ;
      private string[] BC000B2_A92UserCustomizationsValue ;
      private string[] BC000B9_A90UserCustomizationsId ;
      private string[] BC000B9_A91UserCustomizationsKey ;
      private string[] BC000B9_A92UserCustomizationsValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations bcwwpbaseobjects_UserCustomizations ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class usercustomizations_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class usercustomizations_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000B2;
        prmBC000B2 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000B3;
        prmBC000B3 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000B4;
        prmBC000B4 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000B5;
        prmBC000B5 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000B6;
        prmBC000B6 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0) ,
        new ParDef("UserCustomizationsValue",GXType.LongVarChar,2097152,0)
        };
        Object[] prmBC000B7;
        prmBC000B7 = new Object[] {
        new ParDef("UserCustomizationsValue",GXType.LongVarChar,2097152,0) ,
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000B8;
        prmBC000B8 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000B9;
        prmBC000B9 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000B2", "SELECT UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey  FOR UPDATE OF UserCustomizations",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B3", "SELECT UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B4", "SELECT TM1.UserCustomizationsId, TM1.UserCustomizationsKey, TM1.UserCustomizationsValue FROM UserCustomizations TM1 WHERE TM1.UserCustomizationsId = ( :UserCustomizationsId) and TM1.UserCustomizationsKey = ( :UserCustomizationsKey) ORDER BY TM1.UserCustomizationsId, TM1.UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B5", "SELECT UserCustomizationsId, UserCustomizationsKey FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B6", "SAVEPOINT gxupdate;INSERT INTO UserCustomizations(UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue) VALUES(:UserCustomizationsId, :UserCustomizationsKey, :UserCustomizationsValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000B6)
           ,new CursorDef("BC000B7", "SAVEPOINT gxupdate;UPDATE UserCustomizations SET UserCustomizationsValue=:UserCustomizationsValue  WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B7)
           ,new CursorDef("BC000B8", "SAVEPOINT gxupdate;DELETE FROM UserCustomizations  WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B8)
           ,new CursorDef("BC000B9", "SELECT TM1.UserCustomizationsId, TM1.UserCustomizationsKey, TM1.UserCustomizationsValue FROM UserCustomizations TM1 WHERE TM1.UserCustomizationsId = ( :UserCustomizationsId) and TM1.UserCustomizationsKey = ( :UserCustomizationsKey) ORDER BY TM1.UserCustomizationsId, TM1.UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B9,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
