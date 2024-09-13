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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameter_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_parameter_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameter_bc( IGxContext context )
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
         ReadRow0A19( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A19( ) ;
         standaloneModal( ) ;
         AddRow0A19( ) ;
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
            E110A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z84WWPParameterKey = A84WWPParameterKey;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A19( ) ;
            }
            else
            {
               CheckExtendedTable0A19( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0A19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120A2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0A19( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z86WWPParameterCategory = A86WWPParameterCategory;
            Z87WWPParameterDescription = A87WWPParameterDescription;
            Z88WWPParameterDisableDelete = A88WWPParameterDisableDelete;
            Z89WWPParameterValueTrimmed = A89WWPParameterValueTrimmed;
         }
         if ( GX_JID == -3 )
         {
            Z84WWPParameterKey = A84WWPParameterKey;
            Z86WWPParameterCategory = A86WWPParameterCategory;
            Z87WWPParameterDescription = A87WWPParameterDescription;
            Z85WWPParameterValue = A85WWPParameterValue;
            Z88WWPParameterDisableDelete = A88WWPParameterDisableDelete;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0A19( )
      {
         /* Using cursor BC000A4 */
         pr_default.execute(2, new Object[] {A84WWPParameterKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A86WWPParameterCategory = BC000A4_A86WWPParameterCategory[0];
            A87WWPParameterDescription = BC000A4_A87WWPParameterDescription[0];
            A85WWPParameterValue = BC000A4_A85WWPParameterValue[0];
            A88WWPParameterDisableDelete = BC000A4_A88WWPParameterDisableDelete[0];
            ZM0A19( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0A19( ) ;
      }

      protected void OnLoadActions0A19( )
      {
         if ( StringUtil.Len( A85WWPParameterValue) <= 30 )
         {
            A89WWPParameterValueTrimmed = A85WWPParameterValue;
         }
         else
         {
            A89WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A85WWPParameterValue, 1, 27)) + "...";
         }
      }

      protected void CheckExtendedTable0A19( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A84WWPParameterKey)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_ParameterKey_Attribute_Description", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A85WWPParameterValue) <= 30 )
         {
            A89WWPParameterValueTrimmed = A85WWPParameterValue;
         }
         else
         {
            A89WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A85WWPParameterValue, 1, 27)) + "...";
         }
      }

      protected void CloseExtendedTableCursors0A19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A19( )
      {
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {A84WWPParameterKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {A84WWPParameterKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A19( 3) ;
            RcdFound19 = 1;
            A84WWPParameterKey = BC000A3_A84WWPParameterKey[0];
            A86WWPParameterCategory = BC000A3_A86WWPParameterCategory[0];
            A87WWPParameterDescription = BC000A3_A87WWPParameterDescription[0];
            A85WWPParameterValue = BC000A3_A85WWPParameterValue[0];
            A88WWPParameterDisableDelete = BC000A3_A88WWPParameterDisableDelete[0];
            Z84WWPParameterKey = A84WWPParameterKey;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0A19( ) ;
            }
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0A19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode19;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A19( ) ;
         if ( RcdFound19 == 0 )
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
         CONFIRM_0A0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0A19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {A84WWPParameterKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z86WWPParameterCategory, BC000A2_A86WWPParameterCategory[0]) != 0 ) || ( StringUtil.StrCmp(Z87WWPParameterDescription, BC000A2_A87WWPParameterDescription[0]) != 0 ) || ( Z88WWPParameterDisableDelete != BC000A2_A88WWPParameterDisableDelete[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Parameter"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A19( )
      {
         BeforeValidate0A19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A19( 0) ;
            CheckOptimisticConcurrency0A19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A6 */
                     pr_default.execute(4, new Object[] {A84WWPParameterKey, A86WWPParameterCategory, A87WWPParameterDescription, A85WWPParameterValue, A88WWPParameterDisableDelete});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
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
               Load0A19( ) ;
            }
            EndLevel0A19( ) ;
         }
         CloseExtendedTableCursors0A19( ) ;
      }

      protected void Update0A19( )
      {
         BeforeValidate0A19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A7 */
                     pr_default.execute(5, new Object[] {A86WWPParameterCategory, A87WWPParameterDescription, A85WWPParameterValue, A88WWPParameterDisableDelete, A84WWPParameterKey});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A19( ) ;
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
            EndLevel0A19( ) ;
         }
         CloseExtendedTableCursors0A19( ) ;
      }

      protected void DeferredUpdate0A19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A19( ) ;
            AfterConfirm0A19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A8 */
                  pr_default.execute(6, new Object[] {A84WWPParameterKey});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0A19( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( StringUtil.Len( A85WWPParameterValue) <= 30 )
            {
               A89WWPParameterValueTrimmed = A85WWPParameterValue;
            }
            else
            {
               A89WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A85WWPParameterValue, 1, 27)) + "...";
            }
         }
      }

      protected void EndLevel0A19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A19( ) ;
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

      public void ScanKeyStart0A19( )
      {
         /* Scan By routine */
         /* Using cursor BC000A9 */
         pr_default.execute(7, new Object[] {A84WWPParameterKey});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
            A84WWPParameterKey = BC000A9_A84WWPParameterKey[0];
            A86WWPParameterCategory = BC000A9_A86WWPParameterCategory[0];
            A87WWPParameterDescription = BC000A9_A87WWPParameterDescription[0];
            A85WWPParameterValue = BC000A9_A85WWPParameterValue[0];
            A88WWPParameterDisableDelete = BC000A9_A88WWPParameterDisableDelete[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A19( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound19 = 0;
         ScanKeyLoad0A19( ) ;
      }

      protected void ScanKeyLoad0A19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
            A84WWPParameterKey = BC000A9_A84WWPParameterKey[0];
            A86WWPParameterCategory = BC000A9_A86WWPParameterCategory[0];
            A87WWPParameterDescription = BC000A9_A87WWPParameterDescription[0];
            A85WWPParameterValue = BC000A9_A85WWPParameterValue[0];
            A88WWPParameterDisableDelete = BC000A9_A88WWPParameterDisableDelete[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0A19( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0A19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A19( )
      {
      }

      protected void send_integrity_lvl_hashes0A19( )
      {
      }

      protected void AddRow0A19( )
      {
         VarsToRow19( bcworkwithplus_WWP_Parameter) ;
      }

      protected void ReadRow0A19( )
      {
         RowToVars19( bcworkwithplus_WWP_Parameter, 1) ;
      }

      protected void InitializeNonKey0A19( )
      {
         A89WWPParameterValueTrimmed = "";
         A86WWPParameterCategory = "";
         A87WWPParameterDescription = "";
         A85WWPParameterValue = "";
         A88WWPParameterDisableDelete = false;
         Z86WWPParameterCategory = "";
         Z87WWPParameterDescription = "";
         Z88WWPParameterDisableDelete = false;
      }

      protected void InitAll0A19( )
      {
         A84WWPParameterKey = "";
         InitializeNonKey0A19( ) ;
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

      public void VarsToRow19( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Wwpparametervaluetrimmed = A89WWPParameterValueTrimmed;
         obj19.gxTpr_Wwpparametercategory = A86WWPParameterCategory;
         obj19.gxTpr_Wwpparameterdescription = A87WWPParameterDescription;
         obj19.gxTpr_Wwpparametervalue = A85WWPParameterValue;
         obj19.gxTpr_Wwpparameterdisabledelete = A88WWPParameterDisableDelete;
         obj19.gxTpr_Wwpparameterkey = A84WWPParameterKey;
         obj19.gxTpr_Wwpparameterkey_Z = Z84WWPParameterKey;
         obj19.gxTpr_Wwpparametercategory_Z = Z86WWPParameterCategory;
         obj19.gxTpr_Wwpparameterdescription_Z = Z87WWPParameterDescription;
         obj19.gxTpr_Wwpparametervaluetrimmed_Z = Z89WWPParameterValueTrimmed;
         obj19.gxTpr_Wwpparameterdisabledelete_Z = Z88WWPParameterDisableDelete;
         obj19.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow19( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj19 )
      {
         obj19.gxTpr_Wwpparameterkey = A84WWPParameterKey;
         return  ;
      }

      public void RowToVars19( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A89WWPParameterValueTrimmed = obj19.gxTpr_Wwpparametervaluetrimmed;
         A86WWPParameterCategory = obj19.gxTpr_Wwpparametercategory;
         A87WWPParameterDescription = obj19.gxTpr_Wwpparameterdescription;
         A85WWPParameterValue = obj19.gxTpr_Wwpparametervalue;
         A88WWPParameterDisableDelete = obj19.gxTpr_Wwpparameterdisabledelete;
         A84WWPParameterKey = obj19.gxTpr_Wwpparameterkey;
         Z84WWPParameterKey = obj19.gxTpr_Wwpparameterkey_Z;
         Z86WWPParameterCategory = obj19.gxTpr_Wwpparametercategory_Z;
         Z87WWPParameterDescription = obj19.gxTpr_Wwpparameterdescription_Z;
         Z89WWPParameterValueTrimmed = obj19.gxTpr_Wwpparametervaluetrimmed_Z;
         Z88WWPParameterDisableDelete = obj19.gxTpr_Wwpparameterdisabledelete_Z;
         Gx_mode = obj19.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A84WWPParameterKey = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A19( ) ;
         ScanKeyStart0A19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z84WWPParameterKey = A84WWPParameterKey;
         }
         ZM0A19( -3) ;
         OnLoadActions0A19( ) ;
         AddRow0A19( ) ;
         ScanKeyEnd0A19( ) ;
         if ( RcdFound19 == 0 )
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
         RowToVars19( bcworkwithplus_WWP_Parameter, 0) ;
         ScanKeyStart0A19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z84WWPParameterKey = A84WWPParameterKey;
         }
         ZM0A19( -3) ;
         OnLoadActions0A19( ) ;
         AddRow0A19( ) ;
         ScanKeyEnd0A19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0A19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A19( ) ;
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( StringUtil.StrCmp(A84WWPParameterKey, Z84WWPParameterKey) != 0 )
               {
                  A84WWPParameterKey = Z84WWPParameterKey;
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
                  Update0A19( ) ;
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
                  if ( StringUtil.StrCmp(A84WWPParameterKey, Z84WWPParameterKey) != 0 )
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
                        Insert0A19( ) ;
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
                        Insert0A19( ) ;
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
         RowToVars19( bcworkwithplus_WWP_Parameter, 1) ;
         SaveImpl( ) ;
         VarsToRow19( bcworkwithplus_WWP_Parameter) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars19( bcworkwithplus_WWP_Parameter, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A19( ) ;
         AfterTrn( ) ;
         VarsToRow19( bcworkwithplus_WWP_Parameter) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow19( bcworkwithplus_WWP_Parameter) ;
         }
         else
         {
            GeneXus.Programs.workwithplus.SdtWWP_Parameter auxBC = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A84WWPParameterKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcworkwithplus_WWP_Parameter);
               auxBC.Save();
               bcworkwithplus_WWP_Parameter.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars19( bcworkwithplus_WWP_Parameter, 1) ;
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
         RowToVars19( bcworkwithplus_WWP_Parameter, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A19( ) ;
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
               VarsToRow19( bcworkwithplus_WWP_Parameter) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow19( bcworkwithplus_WWP_Parameter) ;
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
         RowToVars19( bcworkwithplus_WWP_Parameter, 0) ;
         GetKey0A19( ) ;
         if ( RcdFound19 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A84WWPParameterKey, Z84WWPParameterKey) != 0 )
            {
               A84WWPParameterKey = Z84WWPParameterKey;
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
            if ( StringUtil.StrCmp(A84WWPParameterKey, Z84WWPParameterKey) != 0 )
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
         context.RollbackDataStores("workwithplus.wwp_parameter_bc",pr_default);
         VarsToRow19( bcworkwithplus_WWP_Parameter) ;
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
         Gx_mode = bcworkwithplus_WWP_Parameter.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcworkwithplus_WWP_Parameter.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcworkwithplus_WWP_Parameter )
         {
            bcworkwithplus_WWP_Parameter = (GeneXus.Programs.workwithplus.SdtWWP_Parameter)(sdt);
            if ( StringUtil.StrCmp(bcworkwithplus_WWP_Parameter.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_WWP_Parameter.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow19( bcworkwithplus_WWP_Parameter) ;
            }
            else
            {
               RowToVars19( bcworkwithplus_WWP_Parameter, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcworkwithplus_WWP_Parameter.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_WWP_Parameter.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars19( bcworkwithplus_WWP_Parameter, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Parameter WWP_Parameter_BC
      {
         get {
            return bcworkwithplus_WWP_Parameter ;
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
            return "wwp_parameter_Execute" ;
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
         Z84WWPParameterKey = "";
         A84WWPParameterKey = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z86WWPParameterCategory = "";
         A86WWPParameterCategory = "";
         Z87WWPParameterDescription = "";
         A87WWPParameterDescription = "";
         Z89WWPParameterValueTrimmed = "";
         A89WWPParameterValueTrimmed = "";
         Z85WWPParameterValue = "";
         A85WWPParameterValue = "";
         BC000A4_A84WWPParameterKey = new string[] {""} ;
         BC000A4_A86WWPParameterCategory = new string[] {""} ;
         BC000A4_A87WWPParameterDescription = new string[] {""} ;
         BC000A4_A85WWPParameterValue = new string[] {""} ;
         BC000A4_A88WWPParameterDisableDelete = new bool[] {false} ;
         BC000A5_A84WWPParameterKey = new string[] {""} ;
         BC000A3_A84WWPParameterKey = new string[] {""} ;
         BC000A3_A86WWPParameterCategory = new string[] {""} ;
         BC000A3_A87WWPParameterDescription = new string[] {""} ;
         BC000A3_A85WWPParameterValue = new string[] {""} ;
         BC000A3_A88WWPParameterDisableDelete = new bool[] {false} ;
         sMode19 = "";
         BC000A2_A84WWPParameterKey = new string[] {""} ;
         BC000A2_A86WWPParameterCategory = new string[] {""} ;
         BC000A2_A87WWPParameterDescription = new string[] {""} ;
         BC000A2_A85WWPParameterValue = new string[] {""} ;
         BC000A2_A88WWPParameterDisableDelete = new bool[] {false} ;
         BC000A9_A84WWPParameterKey = new string[] {""} ;
         BC000A9_A86WWPParameterCategory = new string[] {""} ;
         BC000A9_A87WWPParameterDescription = new string[] {""} ;
         BC000A9_A85WWPParameterValue = new string[] {""} ;
         BC000A9_A88WWPParameterDisableDelete = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A84WWPParameterKey, BC000A2_A86WWPParameterCategory, BC000A2_A87WWPParameterDescription, BC000A2_A85WWPParameterValue, BC000A2_A88WWPParameterDisableDelete
               }
               , new Object[] {
               BC000A3_A84WWPParameterKey, BC000A3_A86WWPParameterCategory, BC000A3_A87WWPParameterDescription, BC000A3_A85WWPParameterValue, BC000A3_A88WWPParameterDisableDelete
               }
               , new Object[] {
               BC000A4_A84WWPParameterKey, BC000A4_A86WWPParameterCategory, BC000A4_A87WWPParameterDescription, BC000A4_A85WWPParameterValue, BC000A4_A88WWPParameterDisableDelete
               }
               , new Object[] {
               BC000A5_A84WWPParameterKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A9_A84WWPParameterKey, BC000A9_A86WWPParameterCategory, BC000A9_A87WWPParameterDescription, BC000A9_A85WWPParameterValue, BC000A9_A88WWPParameterDisableDelete
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120A2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound19 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode19 ;
      private bool returnInSub ;
      private bool Z88WWPParameterDisableDelete ;
      private bool A88WWPParameterDisableDelete ;
      private string Z85WWPParameterValue ;
      private string A85WWPParameterValue ;
      private string Z84WWPParameterKey ;
      private string A84WWPParameterKey ;
      private string Z86WWPParameterCategory ;
      private string A86WWPParameterCategory ;
      private string Z87WWPParameterDescription ;
      private string A87WWPParameterDescription ;
      private string Z89WWPParameterValueTrimmed ;
      private string A89WWPParameterValueTrimmed ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] BC000A4_A84WWPParameterKey ;
      private string[] BC000A4_A86WWPParameterCategory ;
      private string[] BC000A4_A87WWPParameterDescription ;
      private string[] BC000A4_A85WWPParameterValue ;
      private bool[] BC000A4_A88WWPParameterDisableDelete ;
      private string[] BC000A5_A84WWPParameterKey ;
      private string[] BC000A3_A84WWPParameterKey ;
      private string[] BC000A3_A86WWPParameterCategory ;
      private string[] BC000A3_A87WWPParameterDescription ;
      private string[] BC000A3_A85WWPParameterValue ;
      private bool[] BC000A3_A88WWPParameterDisableDelete ;
      private string[] BC000A2_A84WWPParameterKey ;
      private string[] BC000A2_A86WWPParameterCategory ;
      private string[] BC000A2_A87WWPParameterDescription ;
      private string[] BC000A2_A85WWPParameterValue ;
      private bool[] BC000A2_A88WWPParameterDisableDelete ;
      private string[] BC000A9_A84WWPParameterKey ;
      private string[] BC000A9_A86WWPParameterCategory ;
      private string[] BC000A9_A87WWPParameterDescription ;
      private string[] BC000A9_A85WWPParameterValue ;
      private bool[] BC000A9_A88WWPParameterDisableDelete ;
      private GeneXus.Programs.workwithplus.SdtWWP_Parameter bcworkwithplus_WWP_Parameter ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_parameter_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_parameter_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000A2;
        prmBC000A2 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC000A3;
        prmBC000A3 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC000A4;
        prmBC000A4 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC000A5;
        prmBC000A5 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC000A6;
        prmBC000A6 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0) ,
        new ParDef("WWPParameterCategory",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterDescription",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterValue",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPParameterDisableDelete",GXType.Boolean,4,0)
        };
        Object[] prmBC000A7;
        prmBC000A7 = new Object[] {
        new ParDef("WWPParameterCategory",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterDescription",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterValue",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPParameterDisableDelete",GXType.Boolean,4,0) ,
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC000A8;
        prmBC000A8 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC000A9;
        prmBC000A9 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000A2", "SELECT WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey  FOR UPDATE OF WWP_Parameter",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A3", "SELECT WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A4", "SELECT TM1.WWPParameterKey, TM1.WWPParameterCategory, TM1.WWPParameterDescription, TM1.WWPParameterValue, TM1.WWPParameterDisableDelete FROM WWP_Parameter TM1 WHERE TM1.WWPParameterKey = ( :WWPParameterKey) ORDER BY TM1.WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A5", "SELECT WWPParameterKey FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A6", "SAVEPOINT gxupdate;INSERT INTO WWP_Parameter(WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete) VALUES(:WWPParameterKey, :WWPParameterCategory, :WWPParameterDescription, :WWPParameterValue, :WWPParameterDisableDelete);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000A6)
           ,new CursorDef("BC000A7", "SAVEPOINT gxupdate;UPDATE WWP_Parameter SET WWPParameterCategory=:WWPParameterCategory, WWPParameterDescription=:WWPParameterDescription, WWPParameterValue=:WWPParameterValue, WWPParameterDisableDelete=:WWPParameterDisableDelete  WHERE WWPParameterKey = :WWPParameterKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000A7)
           ,new CursorDef("BC000A8", "SAVEPOINT gxupdate;DELETE FROM WWP_Parameter  WHERE WWPParameterKey = :WWPParameterKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000A8)
           ,new CursorDef("BC000A9", "SELECT TM1.WWPParameterKey, TM1.WWPParameterCategory, TM1.WWPParameterDescription, TM1.WWPParameterValue, TM1.WWPParameterDisableDelete FROM WWP_Parameter TM1 WHERE TM1.WWPParameterKey = ( :WWPParameterKey) ORDER BY TM1.WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A9,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
     }
  }

}

}
