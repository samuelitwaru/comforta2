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
   public class device_bc : GxSilentTrn, IGxSilentTrn
   {
      public device_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public device_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<SdtDevice> GetAll( int Start ,
                                               int Count )
      {
         GXPagingFrom28 = Start;
         GXPagingTo28 = Count;
         /* Using cursor BC000I4 */
         pr_default.execute(2, new Object[] {GXPagingFrom28, GXPagingTo28});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound28 = 1;
            A135DeviceId = BC000I4_A135DeviceId[0];
            A136DeviceType = BC000I4_A136DeviceType[0];
            A137DeviceToken = BC000I4_A137DeviceToken[0];
            A138DeviceName = BC000I4_A138DeviceName[0];
            A139DeviceUserGuid = BC000I4_A139DeviceUserGuid[0];
         }
         bcDevice = new SdtDevice(context);
         gx_restcollection.Clear();
         while ( RcdFound28 != 0 )
         {
            OnLoadActions0I28( ) ;
            AddRow0I28( ) ;
            gx_sdt_item = (SdtDevice)(bcDevice.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(2);
            RcdFound28 = 0;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(2) != 101) )
            {
               RcdFound28 = 1;
               A135DeviceId = BC000I4_A135DeviceId[0];
               A136DeviceType = BC000I4_A136DeviceType[0];
               A137DeviceToken = BC000I4_A137DeviceToken[0];
               A138DeviceName = BC000I4_A138DeviceName[0];
               A139DeviceUserGuid = BC000I4_A139DeviceUserGuid[0];
            }
            Gx_mode = sMode28;
         }
         pr_default.close(2);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM0I28( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow0I28( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0I28( ) ;
         standaloneModal( ) ;
         AddRow0I28( ) ;
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
               Z135DeviceId = A135DeviceId;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I28( ) ;
            }
            else
            {
               CheckExtendedTable0I28( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0I28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0I28( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z136DeviceType = A136DeviceType;
            Z137DeviceToken = A137DeviceToken;
            Z138DeviceName = A138DeviceName;
            Z139DeviceUserGuid = A139DeviceUserGuid;
         }
         if ( GX_JID == -2 )
         {
            Z135DeviceId = A135DeviceId;
            Z136DeviceType = A136DeviceType;
            Z137DeviceToken = A137DeviceToken;
            Z138DeviceName = A138DeviceName;
            Z139DeviceUserGuid = A139DeviceUserGuid;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0I28( )
      {
         /* Using cursor BC000I5 */
         pr_default.execute(3, new Object[] {A135DeviceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound28 = 1;
            A136DeviceType = BC000I5_A136DeviceType[0];
            A137DeviceToken = BC000I5_A137DeviceToken[0];
            A138DeviceName = BC000I5_A138DeviceName[0];
            A139DeviceUserGuid = BC000I5_A139DeviceUserGuid[0];
            ZM0I28( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0I28( ) ;
      }

      protected void OnLoadActions0I28( )
      {
      }

      protected void CheckExtendedTable0I28( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A136DeviceType == 0 ) || ( A136DeviceType == 1 ) || ( A136DeviceType == 2 ) || ( A136DeviceType == 3 ) ) )
         {
            GX_msglist.addItem("Field Device Type is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0I28( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I28( )
      {
         /* Using cursor BC000I6 */
         pr_default.execute(4, new Object[] {A135DeviceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000I3 */
         pr_default.execute(1, new Object[] {A135DeviceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I28( 2) ;
            RcdFound28 = 1;
            A135DeviceId = BC000I3_A135DeviceId[0];
            A136DeviceType = BC000I3_A136DeviceType[0];
            A137DeviceToken = BC000I3_A137DeviceToken[0];
            A138DeviceName = BC000I3_A138DeviceName[0];
            A139DeviceUserGuid = BC000I3_A139DeviceUserGuid[0];
            Z135DeviceId = A135DeviceId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0I28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0I28( ) ;
            }
            Gx_mode = sMode28;
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0I28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode28;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I28( ) ;
         if ( RcdFound28 == 0 )
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
         CONFIRM_0I0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0I28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000I2 */
            pr_default.execute(0, new Object[] {A135DeviceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Device"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z136DeviceType != BC000I2_A136DeviceType[0] ) || ( StringUtil.StrCmp(Z137DeviceToken, BC000I2_A137DeviceToken[0]) != 0 ) || ( StringUtil.StrCmp(Z138DeviceName, BC000I2_A138DeviceName[0]) != 0 ) || ( StringUtil.StrCmp(Z139DeviceUserGuid, BC000I2_A139DeviceUserGuid[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Device"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I28( )
      {
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I28( 0) ;
            CheckOptimisticConcurrency0I28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I7 */
                     pr_default.execute(5, new Object[] {A135DeviceId, A136DeviceType, A137DeviceToken, A138DeviceName, A139DeviceUserGuid});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Device");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load0I28( ) ;
            }
            EndLevel0I28( ) ;
         }
         CloseExtendedTableCursors0I28( ) ;
      }

      protected void Update0I28( )
      {
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I8 */
                     pr_default.execute(6, new Object[] {A136DeviceType, A137DeviceToken, A138DeviceName, A139DeviceUserGuid, A135DeviceId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Device");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Device"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I28( ) ;
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
            EndLevel0I28( ) ;
         }
         CloseExtendedTableCursors0I28( ) ;
      }

      protected void DeferredUpdate0I28( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I28( ) ;
            AfterConfirm0I28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000I9 */
                  pr_default.execute(7, new Object[] {A135DeviceId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Device");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0I28( ) ;
         Gx_mode = sMode28;
      }

      protected void OnDeleteControls0I28( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0I28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I28( ) ;
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

      public void ScanKeyStart0I28( )
      {
         /* Using cursor BC000I10 */
         pr_default.execute(8, new Object[] {A135DeviceId});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound28 = 1;
            A135DeviceId = BC000I10_A135DeviceId[0];
            A136DeviceType = BC000I10_A136DeviceType[0];
            A137DeviceToken = BC000I10_A137DeviceToken[0];
            A138DeviceName = BC000I10_A138DeviceName[0];
            A139DeviceUserGuid = BC000I10_A139DeviceUserGuid[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0I28( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound28 = 0;
         ScanKeyLoad0I28( ) ;
      }

      protected void ScanKeyLoad0I28( )
      {
         sMode28 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound28 = 1;
            A135DeviceId = BC000I10_A135DeviceId[0];
            A136DeviceType = BC000I10_A136DeviceType[0];
            A137DeviceToken = BC000I10_A137DeviceToken[0];
            A138DeviceName = BC000I10_A138DeviceName[0];
            A139DeviceUserGuid = BC000I10_A139DeviceUserGuid[0];
         }
         Gx_mode = sMode28;
      }

      protected void ScanKeyEnd0I28( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0I28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I28( )
      {
      }

      protected void send_integrity_lvl_hashes0I28( )
      {
      }

      protected void AddRow0I28( )
      {
         VarsToRow28( bcDevice) ;
      }

      protected void ReadRow0I28( )
      {
         RowToVars28( bcDevice, 1) ;
      }

      protected void InitializeNonKey0I28( )
      {
         A136DeviceType = 0;
         A137DeviceToken = "";
         A138DeviceName = "";
         A139DeviceUserGuid = "";
         Z136DeviceType = 0;
         Z137DeviceToken = "";
         Z138DeviceName = "";
         Z139DeviceUserGuid = "";
      }

      protected void InitAll0I28( )
      {
         A135DeviceId = "";
         InitializeNonKey0I28( ) ;
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

      public void VarsToRow28( SdtDevice obj28 )
      {
         obj28.gxTpr_Mode = Gx_mode;
         obj28.gxTpr_Devicetype = A136DeviceType;
         obj28.gxTpr_Devicetoken = A137DeviceToken;
         obj28.gxTpr_Devicename = A138DeviceName;
         obj28.gxTpr_Deviceuserguid = A139DeviceUserGuid;
         obj28.gxTpr_Deviceid = A135DeviceId;
         obj28.gxTpr_Deviceid_Z = Z135DeviceId;
         obj28.gxTpr_Devicetype_Z = Z136DeviceType;
         obj28.gxTpr_Devicetoken_Z = Z137DeviceToken;
         obj28.gxTpr_Devicename_Z = Z138DeviceName;
         obj28.gxTpr_Deviceuserguid_Z = Z139DeviceUserGuid;
         obj28.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow28( SdtDevice obj28 )
      {
         obj28.gxTpr_Deviceid = A135DeviceId;
         return  ;
      }

      public void RowToVars28( SdtDevice obj28 ,
                               int forceLoad )
      {
         Gx_mode = obj28.gxTpr_Mode;
         A136DeviceType = obj28.gxTpr_Devicetype;
         A137DeviceToken = obj28.gxTpr_Devicetoken;
         A138DeviceName = obj28.gxTpr_Devicename;
         A139DeviceUserGuid = obj28.gxTpr_Deviceuserguid;
         A135DeviceId = obj28.gxTpr_Deviceid;
         Z135DeviceId = obj28.gxTpr_Deviceid_Z;
         Z136DeviceType = obj28.gxTpr_Devicetype_Z;
         Z137DeviceToken = obj28.gxTpr_Devicetoken_Z;
         Z138DeviceName = obj28.gxTpr_Devicename_Z;
         Z139DeviceUserGuid = obj28.gxTpr_Deviceuserguid_Z;
         Gx_mode = obj28.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A135DeviceId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0I28( ) ;
         ScanKeyStart0I28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z135DeviceId = A135DeviceId;
         }
         ZM0I28( -2) ;
         OnLoadActions0I28( ) ;
         AddRow0I28( ) ;
         ScanKeyEnd0I28( ) ;
         if ( RcdFound28 == 0 )
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
         RowToVars28( bcDevice, 0) ;
         ScanKeyStart0I28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z135DeviceId = A135DeviceId;
         }
         ZM0I28( -2) ;
         OnLoadActions0I28( ) ;
         AddRow0I28( ) ;
         ScanKeyEnd0I28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0I28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0I28( ) ;
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( StringUtil.StrCmp(A135DeviceId, Z135DeviceId) != 0 )
               {
                  A135DeviceId = Z135DeviceId;
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
                  Update0I28( ) ;
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
                  if ( StringUtil.StrCmp(A135DeviceId, Z135DeviceId) != 0 )
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
                        Insert0I28( ) ;
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
                        Insert0I28( ) ;
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
         RowToVars28( bcDevice, 1) ;
         SaveImpl( ) ;
         VarsToRow28( bcDevice) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars28( bcDevice, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I28( ) ;
         AfterTrn( ) ;
         VarsToRow28( bcDevice) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow28( bcDevice) ;
         }
         else
         {
            SdtDevice auxBC = new SdtDevice(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A135DeviceId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDevice);
               auxBC.Save();
               bcDevice.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars28( bcDevice, 1) ;
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
         RowToVars28( bcDevice, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I28( ) ;
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
               VarsToRow28( bcDevice) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow28( bcDevice) ;
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
         RowToVars28( bcDevice, 0) ;
         GetKey0I28( ) ;
         if ( RcdFound28 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A135DeviceId, Z135DeviceId) != 0 )
            {
               A135DeviceId = Z135DeviceId;
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
            if ( StringUtil.StrCmp(A135DeviceId, Z135DeviceId) != 0 )
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
         context.RollbackDataStores("device_bc",pr_default);
         VarsToRow28( bcDevice) ;
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
         Gx_mode = bcDevice.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDevice.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDevice )
         {
            bcDevice = (SdtDevice)(sdt);
            if ( StringUtil.StrCmp(bcDevice.gxTpr_Mode, "") == 0 )
            {
               bcDevice.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow28( bcDevice) ;
            }
            else
            {
               RowToVars28( bcDevice, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDevice.gxTpr_Mode, "") == 0 )
            {
               bcDevice.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars28( bcDevice, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtDevice Device_BC
      {
         get {
            return bcDevice ;
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
            return "device_Execute" ;
         }

      }

      public override string ServiceExecutePermissionPrefix
      {
         get {
            return "device_Services_Execute" ;
         }

      }

      public override string ServiceDeletePermissionPrefix
      {
         get {
            return "device_Services_Delete" ;
         }

      }

      public override string ServiceInsertPermissionPrefix
      {
         get {
            return "device_Services_Insert" ;
         }

      }

      public override string ServiceUpdatePermissionPrefix
      {
         get {
            return "device_Services_Update" ;
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
         BC000I4_A135DeviceId = new string[] {""} ;
         BC000I4_A136DeviceType = new short[1] ;
         BC000I4_A137DeviceToken = new string[] {""} ;
         BC000I4_A138DeviceName = new string[] {""} ;
         BC000I4_A139DeviceUserGuid = new string[] {""} ;
         A135DeviceId = "";
         A137DeviceToken = "";
         A138DeviceName = "";
         A139DeviceUserGuid = "";
         gx_restcollection = new GXBCCollection<SdtDevice>( context, "Device", "Comforta2");
         sMode28 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z135DeviceId = "";
         Z137DeviceToken = "";
         Z138DeviceName = "";
         Z139DeviceUserGuid = "";
         BC000I5_A135DeviceId = new string[] {""} ;
         BC000I5_A136DeviceType = new short[1] ;
         BC000I5_A137DeviceToken = new string[] {""} ;
         BC000I5_A138DeviceName = new string[] {""} ;
         BC000I5_A139DeviceUserGuid = new string[] {""} ;
         BC000I6_A135DeviceId = new string[] {""} ;
         BC000I3_A135DeviceId = new string[] {""} ;
         BC000I3_A136DeviceType = new short[1] ;
         BC000I3_A137DeviceToken = new string[] {""} ;
         BC000I3_A138DeviceName = new string[] {""} ;
         BC000I3_A139DeviceUserGuid = new string[] {""} ;
         BC000I2_A135DeviceId = new string[] {""} ;
         BC000I2_A136DeviceType = new short[1] ;
         BC000I2_A137DeviceToken = new string[] {""} ;
         BC000I2_A138DeviceName = new string[] {""} ;
         BC000I2_A139DeviceUserGuid = new string[] {""} ;
         BC000I10_A135DeviceId = new string[] {""} ;
         BC000I10_A136DeviceType = new short[1] ;
         BC000I10_A137DeviceToken = new string[] {""} ;
         BC000I10_A138DeviceName = new string[] {""} ;
         BC000I10_A139DeviceUserGuid = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.device_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.device_bc__default(),
            new Object[][] {
                new Object[] {
               BC000I2_A135DeviceId, BC000I2_A136DeviceType, BC000I2_A137DeviceToken, BC000I2_A138DeviceName, BC000I2_A139DeviceUserGuid
               }
               , new Object[] {
               BC000I3_A135DeviceId, BC000I3_A136DeviceType, BC000I3_A137DeviceToken, BC000I3_A138DeviceName, BC000I3_A139DeviceUserGuid
               }
               , new Object[] {
               BC000I4_A135DeviceId, BC000I4_A136DeviceType, BC000I4_A137DeviceToken, BC000I4_A138DeviceName, BC000I4_A139DeviceUserGuid
               }
               , new Object[] {
               BC000I5_A135DeviceId, BC000I5_A136DeviceType, BC000I5_A137DeviceToken, BC000I5_A138DeviceName, BC000I5_A139DeviceUserGuid
               }
               , new Object[] {
               BC000I6_A135DeviceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I10_A135DeviceId, BC000I10_A136DeviceType, BC000I10_A137DeviceToken, BC000I10_A138DeviceName, BC000I10_A139DeviceUserGuid
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound28 ;
      private short A136DeviceType ;
      private short Z136DeviceType ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom28 ;
      private int GXPagingTo28 ;
      private string A135DeviceId ;
      private string A137DeviceToken ;
      private string A138DeviceName ;
      private string sMode28 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z135DeviceId ;
      private string Z137DeviceToken ;
      private string Z138DeviceName ;
      private string A139DeviceUserGuid ;
      private string Z139DeviceUserGuid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtDevice bcDevice ;
      private IDataStoreProvider pr_default ;
      private string[] BC000I4_A135DeviceId ;
      private short[] BC000I4_A136DeviceType ;
      private string[] BC000I4_A137DeviceToken ;
      private string[] BC000I4_A138DeviceName ;
      private string[] BC000I4_A139DeviceUserGuid ;
      private SdtDevice gx_sdt_item ;
      private GXBCCollection<SdtDevice> gx_restcollection ;
      private string[] BC000I5_A135DeviceId ;
      private short[] BC000I5_A136DeviceType ;
      private string[] BC000I5_A137DeviceToken ;
      private string[] BC000I5_A138DeviceName ;
      private string[] BC000I5_A139DeviceUserGuid ;
      private string[] BC000I6_A135DeviceId ;
      private string[] BC000I3_A135DeviceId ;
      private short[] BC000I3_A136DeviceType ;
      private string[] BC000I3_A137DeviceToken ;
      private string[] BC000I3_A138DeviceName ;
      private string[] BC000I3_A139DeviceUserGuid ;
      private string[] BC000I2_A135DeviceId ;
      private short[] BC000I2_A136DeviceType ;
      private string[] BC000I2_A137DeviceToken ;
      private string[] BC000I2_A138DeviceName ;
      private string[] BC000I2_A139DeviceUserGuid ;
      private string[] BC000I10_A135DeviceId ;
      private short[] BC000I10_A136DeviceType ;
      private string[] BC000I10_A137DeviceToken ;
      private string[] BC000I10_A138DeviceName ;
      private string[] BC000I10_A139DeviceUserGuid ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class device_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class device_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000I2;
        prmBC000I2 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000I3;
        prmBC000I3 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000I4;
        prmBC000I4 = new Object[] {
        new ParDef("GXPagingFrom28",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo28",GXType.Int32,9,0)
        };
        Object[] prmBC000I5;
        prmBC000I5 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000I6;
        prmBC000I6 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000I7;
        prmBC000I7 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0) ,
        new ParDef("DeviceType",GXType.Int16,1,0) ,
        new ParDef("DeviceToken",GXType.Char,1000,0) ,
        new ParDef("DeviceName",GXType.Char,128,0) ,
        new ParDef("DeviceUserGuid",GXType.VarChar,100,60)
        };
        Object[] prmBC000I8;
        prmBC000I8 = new Object[] {
        new ParDef("DeviceType",GXType.Int16,1,0) ,
        new ParDef("DeviceToken",GXType.Char,1000,0) ,
        new ParDef("DeviceName",GXType.Char,128,0) ,
        new ParDef("DeviceUserGuid",GXType.VarChar,100,60) ,
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000I9;
        prmBC000I9 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000I10;
        prmBC000I10 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000I2", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserGuid FROM Device WHERE DeviceId = :DeviceId  FOR UPDATE OF Device",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I3", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserGuid FROM Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I4", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUserGuid FROM Device TM1 ORDER BY TM1.DeviceId  OFFSET :GXPagingFrom28 LIMIT CASE WHEN :GXPagingTo28 > 0 THEN :GXPagingTo28 ELSE 1e9 END",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I5", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUserGuid FROM Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I6", "SELECT DeviceId FROM Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I7", "SAVEPOINT gxupdate;INSERT INTO Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserGuid) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUserGuid);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000I7)
           ,new CursorDef("BC000I8", "SAVEPOINT gxupdate;UPDATE Device SET DeviceType=:DeviceType, DeviceToken=:DeviceToken, DeviceName=:DeviceName, DeviceUserGuid=:DeviceUserGuid  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I8)
           ,new CursorDef("BC000I9", "SAVEPOINT gxupdate;DELETE FROM Device  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I9)
           ,new CursorDef("BC000I10", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUserGuid FROM Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
     }
  }

}

}
