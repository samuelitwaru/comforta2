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
   public class supplier_gen_bc : GxSilentTrn, IGxSilentTrn
   {
      public supplier_gen_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supplier_gen_bc( IGxContext context )
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
         ReadRow049( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey049( ) ;
         standaloneModal( ) ;
         AddRow049( ) ;
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
            E11042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z64Supplier_GenId = A64Supplier_GenId;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls049( ) ;
            }
            else
            {
               CheckExtendedTable049( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors049( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode9 = Gx_mode;
            CONFIRM_0414( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode9;
            }
            /* Restore parent mode. */
            Gx_mode = sMode9;
         }
      }

      protected void CONFIRM_0414( )
      {
         nGXsfl_14_idx = 0;
         while ( nGXsfl_14_idx < bcSupplier_Gen.gxTpr_Productservice.Count )
         {
            ReadRow0414( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound14 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_14 != 0 ) )
            {
               GetKey0414( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound14 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0414( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0414( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0414( 5) ;
                           ZM0414( 6) ;
                        }
                        CloseExtendedTableCursors0414( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0414( ) ;
                        Load0414( ) ;
                        BeforeValidate0414( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0414( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0414( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0414( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0414( 5) ;
                                 ZM0414( 6) ;
                              }
                              CloseExtendedTableCursors0414( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow14( ((SdtSupplier_Gen_ProductService)bcSupplier_Gen.gxTpr_Productservice.Item(nGXsfl_14_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12042( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM049( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z65Supplier_GenKvKNumber = A65Supplier_GenKvKNumber;
            Z66Supplier_GenCompanyName = A66Supplier_GenCompanyName;
            Z67Supplier_GenVisitingAddress = A67Supplier_GenVisitingAddress;
            Z68Supplier_GenPostalAddress = A68Supplier_GenPostalAddress;
            Z69Supplier_GenContactName = A69Supplier_GenContactName;
            Z70Supplier_GenContactPhone = A70Supplier_GenContactPhone;
         }
         if ( GX_JID == -3 )
         {
            Z64Supplier_GenId = A64Supplier_GenId;
            Z65Supplier_GenKvKNumber = A65Supplier_GenKvKNumber;
            Z66Supplier_GenCompanyName = A66Supplier_GenCompanyName;
            Z67Supplier_GenVisitingAddress = A67Supplier_GenVisitingAddress;
            Z68Supplier_GenPostalAddress = A68Supplier_GenPostalAddress;
            Z69Supplier_GenContactName = A69Supplier_GenContactName;
            Z70Supplier_GenContactPhone = A70Supplier_GenContactPhone;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load049( )
      {
         /* Using cursor BC00048 */
         pr_default.execute(6, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound9 = 1;
            A65Supplier_GenKvKNumber = BC00048_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = BC00048_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = BC00048_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = BC00048_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = BC00048_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = BC00048_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = BC00048_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = BC00048_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = BC00048_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = BC00048_n70Supplier_GenContactPhone[0];
            ZM049( -3) ;
         }
         pr_default.close(6);
         OnLoadActions049( ) ;
      }

      protected void OnLoadActions049( )
      {
      }

      protected void CheckExtendedTable049( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65Supplier_GenKvKNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier_Gen Kv KNumber", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A66Supplier_GenCompanyName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier_Gen Company Name", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors049( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey049( )
      {
         /* Using cursor BC00049 */
         pr_default.execute(7, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM049( 3) ;
            RcdFound9 = 1;
            A64Supplier_GenId = BC00047_A64Supplier_GenId[0];
            A65Supplier_GenKvKNumber = BC00047_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = BC00047_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = BC00047_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = BC00047_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = BC00047_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = BC00047_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = BC00047_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = BC00047_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = BC00047_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = BC00047_n70Supplier_GenContactPhone[0];
            Z64Supplier_GenId = A64Supplier_GenId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load049( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey049( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey049( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey049( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_040( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency049( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00046 */
            pr_default.execute(4, new Object[] {A64Supplier_GenId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier_Gen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z65Supplier_GenKvKNumber, BC00046_A65Supplier_GenKvKNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z66Supplier_GenCompanyName, BC00046_A66Supplier_GenCompanyName[0]) != 0 ) || ( StringUtil.StrCmp(Z67Supplier_GenVisitingAddress, BC00046_A67Supplier_GenVisitingAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z68Supplier_GenPostalAddress, BC00046_A68Supplier_GenPostalAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z69Supplier_GenContactName, BC00046_A69Supplier_GenContactName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z70Supplier_GenContactPhone, BC00046_A70Supplier_GenContactPhone[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Supplier_Gen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert049( )
      {
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable049( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM049( 0) ;
            CheckOptimisticConcurrency049( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm049( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert049( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000410 */
                     pr_default.execute(8, new Object[] {A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, n67Supplier_GenVisitingAddress, A67Supplier_GenVisitingAddress, n68Supplier_GenPostalAddress, A68Supplier_GenPostalAddress, n69Supplier_GenContactName, A69Supplier_GenContactName, n70Supplier_GenContactPhone, A70Supplier_GenContactPhone});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000411 */
                     pr_default.execute(9);
                     A64Supplier_GenId = BC000411_A64Supplier_GenId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_Gen");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel049( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
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
            else
            {
               Load049( ) ;
            }
            EndLevel049( ) ;
         }
         CloseExtendedTableCursors049( ) ;
      }

      protected void Update049( )
      {
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable049( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency049( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm049( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate049( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000412 */
                     pr_default.execute(10, new Object[] {A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, n67Supplier_GenVisitingAddress, A67Supplier_GenVisitingAddress, n68Supplier_GenPostalAddress, A68Supplier_GenPostalAddress, n69Supplier_GenContactName, A69Supplier_GenContactName, n70Supplier_GenContactPhone, A70Supplier_GenContactPhone, A64Supplier_GenId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_Gen");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier_Gen"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate049( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel049( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel049( ) ;
         }
         CloseExtendedTableCursors049( ) ;
      }

      protected void DeferredUpdate049( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate049( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency049( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls049( ) ;
            AfterConfirm049( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete049( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0414( ) ;
                  while ( RcdFound14 != 0 )
                  {
                     getByPrimaryKey0414( ) ;
                     Delete0414( ) ;
                     ScanKeyNext0414( ) ;
                  }
                  ScanKeyEnd0414( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000413 */
                     pr_default.execute(11, new Object[] {A64Supplier_GenId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_Gen");
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
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel049( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls049( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000414 */
            pr_default.execute(12, new Object[] {A64Supplier_GenId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Supplier_Gen"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void ProcessNestedLevel0414( )
      {
         nGXsfl_14_idx = 0;
         while ( nGXsfl_14_idx < bcSupplier_Gen.gxTpr_Productservice.Count )
         {
            ReadRow0414( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound14 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_14 != 0 ) )
            {
               standaloneNotModal0414( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0414( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0414( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0414( ) ;
                  }
               }
            }
            KeyVarsToRow14( ((SdtSupplier_Gen_ProductService)bcSupplier_Gen.gxTpr_Productservice.Item(nGXsfl_14_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_14_idx = 0;
            while ( nGXsfl_14_idx < bcSupplier_Gen.gxTpr_Productservice.Count )
            {
               ReadRow0414( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound14 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcSupplier_Gen.gxTpr_Productservice.RemoveElement(nGXsfl_14_idx);
                  nGXsfl_14_idx = (int)(nGXsfl_14_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0414( ) ;
                  VarsToRow14( ((SdtSupplier_Gen_ProductService)bcSupplier_Gen.gxTpr_Productservice.Item(nGXsfl_14_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0414( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_14 = 0;
         nIsMod_14 = 0;
      }

      protected void ProcessLevel049( )
      {
         /* Save parent mode. */
         sMode9 = Gx_mode;
         ProcessNestedLevel0414( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode9;
         /* ' Update level parameters */
      }

      protected void EndLevel049( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete049( ) ;
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

      public void ScanKeyStart049( )
      {
         /* Scan By routine */
         /* Using cursor BC000415 */
         pr_default.execute(13, new Object[] {A64Supplier_GenId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A64Supplier_GenId = BC000415_A64Supplier_GenId[0];
            A65Supplier_GenKvKNumber = BC000415_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = BC000415_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = BC000415_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = BC000415_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = BC000415_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = BC000415_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = BC000415_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = BC000415_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = BC000415_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = BC000415_n70Supplier_GenContactPhone[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext049( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound9 = 0;
         ScanKeyLoad049( ) ;
      }

      protected void ScanKeyLoad049( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A64Supplier_GenId = BC000415_A64Supplier_GenId[0];
            A65Supplier_GenKvKNumber = BC000415_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = BC000415_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = BC000415_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = BC000415_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = BC000415_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = BC000415_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = BC000415_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = BC000415_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = BC000415_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = BC000415_n70Supplier_GenContactPhone[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd049( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm049( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert049( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate049( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete049( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete049( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate049( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes049( )
      {
      }

      protected void ZM0414( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z74ProductServiceName = A74ProductServiceName;
            Z75ProductServiceDescription = A75ProductServiceDescription;
            Z76ProductServiceQuantity = A76ProductServiceQuantity;
            Z71ProductServiceTypeId = A71ProductServiceTypeId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z72ProductServiceTypeName = A72ProductServiceTypeName;
         }
         if ( GX_JID == -4 )
         {
            Z64Supplier_GenId = A64Supplier_GenId;
            Z73ProductServiceId = A73ProductServiceId;
            Z74ProductServiceName = A74ProductServiceName;
            Z75ProductServiceDescription = A75ProductServiceDescription;
            Z76ProductServiceQuantity = A76ProductServiceQuantity;
            Z77ProductServicePicture = A77ProductServicePicture;
            Z40000ProductServicePicture_GXI = A40000ProductServicePicture_GXI;
            Z71ProductServiceTypeId = A71ProductServiceTypeId;
            Z72ProductServiceTypeName = A72ProductServiceTypeName;
         }
      }

      protected void standaloneNotModal0414( )
      {
      }

      protected void standaloneModal0414( )
      {
      }

      protected void Load0414( )
      {
         /* Using cursor BC000416 */
         pr_default.execute(14, new Object[] {A64Supplier_GenId, A73ProductServiceId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound14 = 1;
            A74ProductServiceName = BC000416_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000416_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000416_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000416_A40000ProductServicePicture_GXI[0];
            A72ProductServiceTypeName = BC000416_A72ProductServiceTypeName[0];
            A71ProductServiceTypeId = BC000416_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000416_A77ProductServicePicture[0];
            ZM0414( -4) ;
         }
         pr_default.close(14);
         OnLoadActions0414( ) ;
      }

      protected void OnLoadActions0414( )
      {
      }

      protected void CheckExtendedTable0414( )
      {
         Gx_BScreen = 1;
         standaloneModal0414( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Service'.", "ForeignKeyNotFound", 1, "PRODUCTSERVICEID");
            AnyError = 1;
         }
         A74ProductServiceName = BC00044_A74ProductServiceName[0];
         A75ProductServiceDescription = BC00044_A75ProductServiceDescription[0];
         A76ProductServiceQuantity = BC00044_A76ProductServiceQuantity[0];
         A40000ProductServicePicture_GXI = BC00044_A40000ProductServicePicture_GXI[0];
         A71ProductServiceTypeId = BC00044_A71ProductServiceTypeId[0];
         A77ProductServicePicture = BC00044_A77ProductServicePicture[0];
         pr_default.close(2);
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Service Type'.", "ForeignKeyNotFound", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
         }
         A72ProductServiceTypeName = BC00045_A72ProductServiceTypeName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0414( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0414( )
      {
      }

      protected void GetKey0414( )
      {
         /* Using cursor BC000417 */
         pr_default.execute(15, new Object[] {A64Supplier_GenId, A73ProductServiceId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey0414( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A64Supplier_GenId, A73ProductServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0414( 4) ;
            RcdFound14 = 1;
            InitializeNonKey0414( ) ;
            A73ProductServiceId = BC00043_A73ProductServiceId[0];
            Z64Supplier_GenId = A64Supplier_GenId;
            Z73ProductServiceId = A73ProductServiceId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0414( ) ;
            Load0414( ) ;
            Gx_mode = sMode14;
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0414( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0414( ) ;
            Gx_mode = sMode14;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0414( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0414( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A64Supplier_GenId, A73ProductServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier_GenProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Supplier_GenProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0414( )
      {
         BeforeValidate0414( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0414( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0414( 0) ;
            CheckOptimisticConcurrency0414( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0414( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0414( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000418 */
                     pr_default.execute(16, new Object[] {A64Supplier_GenId, A73ProductServiceId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_GenProductService");
                     if ( (pr_default.getStatus(16) == 1) )
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
               Load0414( ) ;
            }
            EndLevel0414( ) ;
         }
         CloseExtendedTableCursors0414( ) ;
      }

      protected void Update0414( )
      {
         BeforeValidate0414( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0414( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0414( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0414( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0414( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table Supplier_GenProductService */
                     DeferredUpdate0414( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0414( ) ;
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
            EndLevel0414( ) ;
         }
         CloseExtendedTableCursors0414( ) ;
      }

      protected void DeferredUpdate0414( )
      {
      }

      protected void Delete0414( )
      {
         Gx_mode = "DLT";
         BeforeValidate0414( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0414( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0414( ) ;
            AfterConfirm0414( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0414( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000419 */
                  pr_default.execute(17, new Object[] {A64Supplier_GenId, A73ProductServiceId});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("Supplier_GenProductService");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0414( ) ;
         Gx_mode = sMode14;
      }

      protected void OnDeleteControls0414( )
      {
         standaloneModal0414( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000420 */
            pr_default.execute(18, new Object[] {A73ProductServiceId});
            A74ProductServiceName = BC000420_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000420_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000420_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000420_A40000ProductServicePicture_GXI[0];
            A71ProductServiceTypeId = BC000420_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000420_A77ProductServicePicture[0];
            pr_default.close(18);
            /* Using cursor BC000421 */
            pr_default.execute(19, new Object[] {A71ProductServiceTypeId});
            A72ProductServiceTypeName = BC000421_A72ProductServiceTypeName[0];
            pr_default.close(19);
         }
      }

      protected void EndLevel0414( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0414( )
      {
         /* Scan By routine */
         /* Using cursor BC000422 */
         pr_default.execute(20, new Object[] {A64Supplier_GenId});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound14 = 1;
            A74ProductServiceName = BC000422_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000422_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000422_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000422_A40000ProductServicePicture_GXI[0];
            A72ProductServiceTypeName = BC000422_A72ProductServiceTypeName[0];
            A73ProductServiceId = BC000422_A73ProductServiceId[0];
            A71ProductServiceTypeId = BC000422_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000422_A77ProductServicePicture[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0414( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound14 = 0;
         ScanKeyLoad0414( ) ;
      }

      protected void ScanKeyLoad0414( )
      {
         sMode14 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound14 = 1;
            A74ProductServiceName = BC000422_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000422_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000422_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000422_A40000ProductServicePicture_GXI[0];
            A72ProductServiceTypeName = BC000422_A72ProductServiceTypeName[0];
            A73ProductServiceId = BC000422_A73ProductServiceId[0];
            A71ProductServiceTypeId = BC000422_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000422_A77ProductServicePicture[0];
         }
         Gx_mode = sMode14;
      }

      protected void ScanKeyEnd0414( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0414( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0414( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0414( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0414( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0414( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0414( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0414( )
      {
      }

      protected void send_integrity_lvl_hashes0414( )
      {
      }

      protected void send_integrity_lvl_hashes049( )
      {
      }

      protected void AddRow049( )
      {
         VarsToRow9( bcSupplier_Gen) ;
      }

      protected void ReadRow049( )
      {
         RowToVars9( bcSupplier_Gen, 1) ;
      }

      protected void AddRow0414( )
      {
         SdtSupplier_Gen_ProductService obj14;
         obj14 = new SdtSupplier_Gen_ProductService(context);
         VarsToRow14( obj14) ;
         bcSupplier_Gen.gxTpr_Productservice.Add(obj14, 0);
         obj14.gxTpr_Mode = "UPD";
         obj14.gxTpr_Modified = 0;
      }

      protected void ReadRow0414( )
      {
         nGXsfl_14_idx = (int)(nGXsfl_14_idx+1);
         RowToVars14( ((SdtSupplier_Gen_ProductService)bcSupplier_Gen.gxTpr_Productservice.Item(nGXsfl_14_idx)), 1) ;
      }

      protected void InitializeNonKey049( )
      {
         A65Supplier_GenKvKNumber = "";
         A66Supplier_GenCompanyName = "";
         A67Supplier_GenVisitingAddress = "";
         n67Supplier_GenVisitingAddress = false;
         A68Supplier_GenPostalAddress = "";
         n68Supplier_GenPostalAddress = false;
         A69Supplier_GenContactName = "";
         n69Supplier_GenContactName = false;
         A70Supplier_GenContactPhone = "";
         n70Supplier_GenContactPhone = false;
         Z65Supplier_GenKvKNumber = "";
         Z66Supplier_GenCompanyName = "";
         Z67Supplier_GenVisitingAddress = "";
         Z68Supplier_GenPostalAddress = "";
         Z69Supplier_GenContactName = "";
         Z70Supplier_GenContactPhone = "";
      }

      protected void InitAll049( )
      {
         A64Supplier_GenId = 0;
         InitializeNonKey049( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0414( )
      {
         A74ProductServiceName = "";
         A75ProductServiceDescription = "";
         A76ProductServiceQuantity = 0;
         A77ProductServicePicture = "";
         A40000ProductServicePicture_GXI = "";
         A71ProductServiceTypeId = 0;
         A72ProductServiceTypeName = "";
      }

      protected void InitAll0414( )
      {
         A73ProductServiceId = 0;
         InitializeNonKey0414( ) ;
      }

      protected void StandaloneModalInsert0414( )
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

      public void VarsToRow9( SdtSupplier_Gen obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Supplier_genkvknumber = A65Supplier_GenKvKNumber;
         obj9.gxTpr_Supplier_gencompanyname = A66Supplier_GenCompanyName;
         obj9.gxTpr_Supplier_genvisitingaddress = A67Supplier_GenVisitingAddress;
         obj9.gxTpr_Supplier_genpostaladdress = A68Supplier_GenPostalAddress;
         obj9.gxTpr_Supplier_gencontactname = A69Supplier_GenContactName;
         obj9.gxTpr_Supplier_gencontactphone = A70Supplier_GenContactPhone;
         obj9.gxTpr_Supplier_genid = A64Supplier_GenId;
         obj9.gxTpr_Supplier_genid_Z = Z64Supplier_GenId;
         obj9.gxTpr_Supplier_genkvknumber_Z = Z65Supplier_GenKvKNumber;
         obj9.gxTpr_Supplier_gencompanyname_Z = Z66Supplier_GenCompanyName;
         obj9.gxTpr_Supplier_genvisitingaddress_Z = Z67Supplier_GenVisitingAddress;
         obj9.gxTpr_Supplier_genpostaladdress_Z = Z68Supplier_GenPostalAddress;
         obj9.gxTpr_Supplier_gencontactname_Z = Z69Supplier_GenContactName;
         obj9.gxTpr_Supplier_gencontactphone_Z = Z70Supplier_GenContactPhone;
         obj9.gxTpr_Supplier_genvisitingaddress_N = (short)(Convert.ToInt16(n67Supplier_GenVisitingAddress));
         obj9.gxTpr_Supplier_genpostaladdress_N = (short)(Convert.ToInt16(n68Supplier_GenPostalAddress));
         obj9.gxTpr_Supplier_gencontactname_N = (short)(Convert.ToInt16(n69Supplier_GenContactName));
         obj9.gxTpr_Supplier_gencontactphone_N = (short)(Convert.ToInt16(n70Supplier_GenContactPhone));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtSupplier_Gen obj9 )
      {
         obj9.gxTpr_Supplier_genid = A64Supplier_GenId;
         return  ;
      }

      public void RowToVars9( SdtSupplier_Gen obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A65Supplier_GenKvKNumber = obj9.gxTpr_Supplier_genkvknumber;
         A66Supplier_GenCompanyName = obj9.gxTpr_Supplier_gencompanyname;
         A67Supplier_GenVisitingAddress = obj9.gxTpr_Supplier_genvisitingaddress;
         n67Supplier_GenVisitingAddress = false;
         A68Supplier_GenPostalAddress = obj9.gxTpr_Supplier_genpostaladdress;
         n68Supplier_GenPostalAddress = false;
         A69Supplier_GenContactName = obj9.gxTpr_Supplier_gencontactname;
         n69Supplier_GenContactName = false;
         A70Supplier_GenContactPhone = obj9.gxTpr_Supplier_gencontactphone;
         n70Supplier_GenContactPhone = false;
         A64Supplier_GenId = obj9.gxTpr_Supplier_genid;
         Z64Supplier_GenId = obj9.gxTpr_Supplier_genid_Z;
         Z65Supplier_GenKvKNumber = obj9.gxTpr_Supplier_genkvknumber_Z;
         Z66Supplier_GenCompanyName = obj9.gxTpr_Supplier_gencompanyname_Z;
         Z67Supplier_GenVisitingAddress = obj9.gxTpr_Supplier_genvisitingaddress_Z;
         Z68Supplier_GenPostalAddress = obj9.gxTpr_Supplier_genpostaladdress_Z;
         Z69Supplier_GenContactName = obj9.gxTpr_Supplier_gencontactname_Z;
         Z70Supplier_GenContactPhone = obj9.gxTpr_Supplier_gencontactphone_Z;
         n67Supplier_GenVisitingAddress = (bool)(Convert.ToBoolean(obj9.gxTpr_Supplier_genvisitingaddress_N));
         n68Supplier_GenPostalAddress = (bool)(Convert.ToBoolean(obj9.gxTpr_Supplier_genpostaladdress_N));
         n69Supplier_GenContactName = (bool)(Convert.ToBoolean(obj9.gxTpr_Supplier_gencontactname_N));
         n70Supplier_GenContactPhone = (bool)(Convert.ToBoolean(obj9.gxTpr_Supplier_gencontactphone_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow14( SdtSupplier_Gen_ProductService obj14 )
      {
         obj14.gxTpr_Mode = Gx_mode;
         obj14.gxTpr_Productservicename = A74ProductServiceName;
         obj14.gxTpr_Productservicedescription = A75ProductServiceDescription;
         obj14.gxTpr_Productservicequantity = A76ProductServiceQuantity;
         obj14.gxTpr_Productservicepicture = A77ProductServicePicture;
         obj14.gxTpr_Productservicepicture_gxi = A40000ProductServicePicture_GXI;
         obj14.gxTpr_Productservicetypeid = A71ProductServiceTypeId;
         obj14.gxTpr_Productservicetypename = A72ProductServiceTypeName;
         obj14.gxTpr_Productserviceid = A73ProductServiceId;
         obj14.gxTpr_Productserviceid_Z = Z73ProductServiceId;
         obj14.gxTpr_Productservicename_Z = Z74ProductServiceName;
         obj14.gxTpr_Productservicedescription_Z = Z75ProductServiceDescription;
         obj14.gxTpr_Productservicequantity_Z = Z76ProductServiceQuantity;
         obj14.gxTpr_Productservicetypeid_Z = Z71ProductServiceTypeId;
         obj14.gxTpr_Productservicetypename_Z = Z72ProductServiceTypeName;
         obj14.gxTpr_Productservicepicture_gxi_Z = Z40000ProductServicePicture_GXI;
         obj14.gxTpr_Modified = nIsMod_14;
         return  ;
      }

      public void KeyVarsToRow14( SdtSupplier_Gen_ProductService obj14 )
      {
         obj14.gxTpr_Productserviceid = A73ProductServiceId;
         return  ;
      }

      public void RowToVars14( SdtSupplier_Gen_ProductService obj14 ,
                               int forceLoad )
      {
         Gx_mode = obj14.gxTpr_Mode;
         A74ProductServiceName = obj14.gxTpr_Productservicename;
         A75ProductServiceDescription = obj14.gxTpr_Productservicedescription;
         A76ProductServiceQuantity = obj14.gxTpr_Productservicequantity;
         A77ProductServicePicture = obj14.gxTpr_Productservicepicture;
         A40000ProductServicePicture_GXI = obj14.gxTpr_Productservicepicture_gxi;
         A71ProductServiceTypeId = obj14.gxTpr_Productservicetypeid;
         A72ProductServiceTypeName = obj14.gxTpr_Productservicetypename;
         A73ProductServiceId = obj14.gxTpr_Productserviceid;
         Z73ProductServiceId = obj14.gxTpr_Productserviceid_Z;
         Z74ProductServiceName = obj14.gxTpr_Productservicename_Z;
         Z75ProductServiceDescription = obj14.gxTpr_Productservicedescription_Z;
         Z76ProductServiceQuantity = obj14.gxTpr_Productservicequantity_Z;
         Z71ProductServiceTypeId = obj14.gxTpr_Productservicetypeid_Z;
         Z72ProductServiceTypeName = obj14.gxTpr_Productservicetypename_Z;
         Z40000ProductServicePicture_GXI = obj14.gxTpr_Productservicepicture_gxi_Z;
         nIsMod_14 = obj14.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A64Supplier_GenId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey049( ) ;
         ScanKeyStart049( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z64Supplier_GenId = A64Supplier_GenId;
         }
         ZM049( -3) ;
         OnLoadActions049( ) ;
         AddRow049( ) ;
         bcSupplier_Gen.gxTpr_Productservice.ClearCollection();
         if ( RcdFound9 == 1 )
         {
            ScanKeyStart0414( ) ;
            nGXsfl_14_idx = 1;
            while ( RcdFound14 != 0 )
            {
               Z64Supplier_GenId = A64Supplier_GenId;
               Z73ProductServiceId = A73ProductServiceId;
               ZM0414( -4) ;
               OnLoadActions0414( ) ;
               nRcdExists_14 = 1;
               nIsMod_14 = 0;
               AddRow0414( ) ;
               nGXsfl_14_idx = (int)(nGXsfl_14_idx+1);
               ScanKeyNext0414( ) ;
            }
            ScanKeyEnd0414( ) ;
         }
         ScanKeyEnd049( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcSupplier_Gen, 0) ;
         ScanKeyStart049( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z64Supplier_GenId = A64Supplier_GenId;
         }
         ZM049( -3) ;
         OnLoadActions049( ) ;
         AddRow049( ) ;
         bcSupplier_Gen.gxTpr_Productservice.ClearCollection();
         if ( RcdFound9 == 1 )
         {
            ScanKeyStart0414( ) ;
            nGXsfl_14_idx = 1;
            while ( RcdFound14 != 0 )
            {
               Z64Supplier_GenId = A64Supplier_GenId;
               Z73ProductServiceId = A73ProductServiceId;
               ZM0414( -4) ;
               OnLoadActions0414( ) ;
               nRcdExists_14 = 1;
               nIsMod_14 = 0;
               AddRow0414( ) ;
               nGXsfl_14_idx = (int)(nGXsfl_14_idx+1);
               ScanKeyNext0414( ) ;
            }
            ScanKeyEnd0414( ) ;
         }
         ScanKeyEnd049( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey049( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert049( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A64Supplier_GenId != Z64Supplier_GenId )
               {
                  A64Supplier_GenId = Z64Supplier_GenId;
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
                  Update049( ) ;
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
                  if ( A64Supplier_GenId != Z64Supplier_GenId )
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
                        Insert049( ) ;
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
                        Insert049( ) ;
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
         RowToVars9( bcSupplier_Gen, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcSupplier_Gen) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcSupplier_Gen, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert049( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcSupplier_Gen) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcSupplier_Gen) ;
         }
         else
         {
            SdtSupplier_Gen auxBC = new SdtSupplier_Gen(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A64Supplier_GenId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSupplier_Gen);
               auxBC.Save();
               bcSupplier_Gen.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars9( bcSupplier_Gen, 1) ;
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
         RowToVars9( bcSupplier_Gen, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert049( ) ;
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
               VarsToRow9( bcSupplier_Gen) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcSupplier_Gen) ;
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
         RowToVars9( bcSupplier_Gen, 0) ;
         GetKey049( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A64Supplier_GenId != Z64Supplier_GenId )
            {
               A64Supplier_GenId = Z64Supplier_GenId;
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
            if ( A64Supplier_GenId != Z64Supplier_GenId )
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
         context.RollbackDataStores("supplier_gen_bc",pr_default);
         VarsToRow9( bcSupplier_Gen) ;
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
         Gx_mode = bcSupplier_Gen.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSupplier_Gen.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSupplier_Gen )
         {
            bcSupplier_Gen = (SdtSupplier_Gen)(sdt);
            if ( StringUtil.StrCmp(bcSupplier_Gen.gxTpr_Mode, "") == 0 )
            {
               bcSupplier_Gen.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcSupplier_Gen) ;
            }
            else
            {
               RowToVars9( bcSupplier_Gen, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSupplier_Gen.gxTpr_Mode, "") == 0 )
            {
               bcSupplier_Gen.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcSupplier_Gen, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSupplier_Gen Supplier_Gen_BC
      {
         get {
            return bcSupplier_Gen ;
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
            return "supplier_gen_Execute" ;
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
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(5);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode9 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z65Supplier_GenKvKNumber = "";
         A65Supplier_GenKvKNumber = "";
         Z66Supplier_GenCompanyName = "";
         A66Supplier_GenCompanyName = "";
         Z67Supplier_GenVisitingAddress = "";
         A67Supplier_GenVisitingAddress = "";
         Z68Supplier_GenPostalAddress = "";
         A68Supplier_GenPostalAddress = "";
         Z69Supplier_GenContactName = "";
         A69Supplier_GenContactName = "";
         Z70Supplier_GenContactPhone = "";
         A70Supplier_GenContactPhone = "";
         BC00048_A64Supplier_GenId = new short[1] ;
         BC00048_A65Supplier_GenKvKNumber = new string[] {""} ;
         BC00048_A66Supplier_GenCompanyName = new string[] {""} ;
         BC00048_A67Supplier_GenVisitingAddress = new string[] {""} ;
         BC00048_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         BC00048_A68Supplier_GenPostalAddress = new string[] {""} ;
         BC00048_n68Supplier_GenPostalAddress = new bool[] {false} ;
         BC00048_A69Supplier_GenContactName = new string[] {""} ;
         BC00048_n69Supplier_GenContactName = new bool[] {false} ;
         BC00048_A70Supplier_GenContactPhone = new string[] {""} ;
         BC00048_n70Supplier_GenContactPhone = new bool[] {false} ;
         BC00049_A64Supplier_GenId = new short[1] ;
         BC00047_A64Supplier_GenId = new short[1] ;
         BC00047_A65Supplier_GenKvKNumber = new string[] {""} ;
         BC00047_A66Supplier_GenCompanyName = new string[] {""} ;
         BC00047_A67Supplier_GenVisitingAddress = new string[] {""} ;
         BC00047_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         BC00047_A68Supplier_GenPostalAddress = new string[] {""} ;
         BC00047_n68Supplier_GenPostalAddress = new bool[] {false} ;
         BC00047_A69Supplier_GenContactName = new string[] {""} ;
         BC00047_n69Supplier_GenContactName = new bool[] {false} ;
         BC00047_A70Supplier_GenContactPhone = new string[] {""} ;
         BC00047_n70Supplier_GenContactPhone = new bool[] {false} ;
         BC00046_A64Supplier_GenId = new short[1] ;
         BC00046_A65Supplier_GenKvKNumber = new string[] {""} ;
         BC00046_A66Supplier_GenCompanyName = new string[] {""} ;
         BC00046_A67Supplier_GenVisitingAddress = new string[] {""} ;
         BC00046_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         BC00046_A68Supplier_GenPostalAddress = new string[] {""} ;
         BC00046_n68Supplier_GenPostalAddress = new bool[] {false} ;
         BC00046_A69Supplier_GenContactName = new string[] {""} ;
         BC00046_n69Supplier_GenContactName = new bool[] {false} ;
         BC00046_A70Supplier_GenContactPhone = new string[] {""} ;
         BC00046_n70Supplier_GenContactPhone = new bool[] {false} ;
         BC000411_A64Supplier_GenId = new short[1] ;
         BC000414_A1CustomerId = new short[1] ;
         BC000414_A18CustomerLocationId = new short[1] ;
         BC000414_A64Supplier_GenId = new short[1] ;
         BC000415_A64Supplier_GenId = new short[1] ;
         BC000415_A65Supplier_GenKvKNumber = new string[] {""} ;
         BC000415_A66Supplier_GenCompanyName = new string[] {""} ;
         BC000415_A67Supplier_GenVisitingAddress = new string[] {""} ;
         BC000415_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         BC000415_A68Supplier_GenPostalAddress = new string[] {""} ;
         BC000415_n68Supplier_GenPostalAddress = new bool[] {false} ;
         BC000415_A69Supplier_GenContactName = new string[] {""} ;
         BC000415_n69Supplier_GenContactName = new bool[] {false} ;
         BC000415_A70Supplier_GenContactPhone = new string[] {""} ;
         BC000415_n70Supplier_GenContactPhone = new bool[] {false} ;
         Z74ProductServiceName = "";
         A74ProductServiceName = "";
         Z75ProductServiceDescription = "";
         A75ProductServiceDescription = "";
         Z72ProductServiceTypeName = "";
         A72ProductServiceTypeName = "";
         Z77ProductServicePicture = "";
         A77ProductServicePicture = "";
         Z40000ProductServicePicture_GXI = "";
         A40000ProductServicePicture_GXI = "";
         BC000416_A64Supplier_GenId = new short[1] ;
         BC000416_A74ProductServiceName = new string[] {""} ;
         BC000416_A75ProductServiceDescription = new string[] {""} ;
         BC000416_A76ProductServiceQuantity = new short[1] ;
         BC000416_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC000416_A72ProductServiceTypeName = new string[] {""} ;
         BC000416_A73ProductServiceId = new short[1] ;
         BC000416_A71ProductServiceTypeId = new short[1] ;
         BC000416_A77ProductServicePicture = new string[] {""} ;
         BC00044_A74ProductServiceName = new string[] {""} ;
         BC00044_A75ProductServiceDescription = new string[] {""} ;
         BC00044_A76ProductServiceQuantity = new short[1] ;
         BC00044_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC00044_A71ProductServiceTypeId = new short[1] ;
         BC00044_A77ProductServicePicture = new string[] {""} ;
         BC00045_A72ProductServiceTypeName = new string[] {""} ;
         BC000417_A64Supplier_GenId = new short[1] ;
         BC000417_A73ProductServiceId = new short[1] ;
         BC00043_A64Supplier_GenId = new short[1] ;
         BC00043_A73ProductServiceId = new short[1] ;
         sMode14 = "";
         BC00042_A64Supplier_GenId = new short[1] ;
         BC00042_A73ProductServiceId = new short[1] ;
         BC000420_A74ProductServiceName = new string[] {""} ;
         BC000420_A75ProductServiceDescription = new string[] {""} ;
         BC000420_A76ProductServiceQuantity = new short[1] ;
         BC000420_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC000420_A71ProductServiceTypeId = new short[1] ;
         BC000420_A77ProductServicePicture = new string[] {""} ;
         BC000421_A72ProductServiceTypeName = new string[] {""} ;
         BC000422_A64Supplier_GenId = new short[1] ;
         BC000422_A74ProductServiceName = new string[] {""} ;
         BC000422_A75ProductServiceDescription = new string[] {""} ;
         BC000422_A76ProductServiceQuantity = new short[1] ;
         BC000422_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC000422_A72ProductServiceTypeName = new string[] {""} ;
         BC000422_A73ProductServiceId = new short[1] ;
         BC000422_A71ProductServiceTypeId = new short[1] ;
         BC000422_A77ProductServicePicture = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.supplier_gen_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_gen_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A64Supplier_GenId, BC00042_A73ProductServiceId
               }
               , new Object[] {
               BC00043_A64Supplier_GenId, BC00043_A73ProductServiceId
               }
               , new Object[] {
               BC00044_A74ProductServiceName, BC00044_A75ProductServiceDescription, BC00044_A76ProductServiceQuantity, BC00044_A40000ProductServicePicture_GXI, BC00044_A71ProductServiceTypeId, BC00044_A77ProductServicePicture
               }
               , new Object[] {
               BC00045_A72ProductServiceTypeName
               }
               , new Object[] {
               BC00046_A64Supplier_GenId, BC00046_A65Supplier_GenKvKNumber, BC00046_A66Supplier_GenCompanyName, BC00046_A67Supplier_GenVisitingAddress, BC00046_n67Supplier_GenVisitingAddress, BC00046_A68Supplier_GenPostalAddress, BC00046_n68Supplier_GenPostalAddress, BC00046_A69Supplier_GenContactName, BC00046_n69Supplier_GenContactName, BC00046_A70Supplier_GenContactPhone,
               BC00046_n70Supplier_GenContactPhone
               }
               , new Object[] {
               BC00047_A64Supplier_GenId, BC00047_A65Supplier_GenKvKNumber, BC00047_A66Supplier_GenCompanyName, BC00047_A67Supplier_GenVisitingAddress, BC00047_n67Supplier_GenVisitingAddress, BC00047_A68Supplier_GenPostalAddress, BC00047_n68Supplier_GenPostalAddress, BC00047_A69Supplier_GenContactName, BC00047_n69Supplier_GenContactName, BC00047_A70Supplier_GenContactPhone,
               BC00047_n70Supplier_GenContactPhone
               }
               , new Object[] {
               BC00048_A64Supplier_GenId, BC00048_A65Supplier_GenKvKNumber, BC00048_A66Supplier_GenCompanyName, BC00048_A67Supplier_GenVisitingAddress, BC00048_n67Supplier_GenVisitingAddress, BC00048_A68Supplier_GenPostalAddress, BC00048_n68Supplier_GenPostalAddress, BC00048_A69Supplier_GenContactName, BC00048_n69Supplier_GenContactName, BC00048_A70Supplier_GenContactPhone,
               BC00048_n70Supplier_GenContactPhone
               }
               , new Object[] {
               BC00049_A64Supplier_GenId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000411_A64Supplier_GenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000414_A1CustomerId, BC000414_A18CustomerLocationId, BC000414_A64Supplier_GenId
               }
               , new Object[] {
               BC000415_A64Supplier_GenId, BC000415_A65Supplier_GenKvKNumber, BC000415_A66Supplier_GenCompanyName, BC000415_A67Supplier_GenVisitingAddress, BC000415_n67Supplier_GenVisitingAddress, BC000415_A68Supplier_GenPostalAddress, BC000415_n68Supplier_GenPostalAddress, BC000415_A69Supplier_GenContactName, BC000415_n69Supplier_GenContactName, BC000415_A70Supplier_GenContactPhone,
               BC000415_n70Supplier_GenContactPhone
               }
               , new Object[] {
               BC000416_A64Supplier_GenId, BC000416_A74ProductServiceName, BC000416_A75ProductServiceDescription, BC000416_A76ProductServiceQuantity, BC000416_A40000ProductServicePicture_GXI, BC000416_A72ProductServiceTypeName, BC000416_A73ProductServiceId, BC000416_A71ProductServiceTypeId, BC000416_A77ProductServicePicture
               }
               , new Object[] {
               BC000417_A64Supplier_GenId, BC000417_A73ProductServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000420_A74ProductServiceName, BC000420_A75ProductServiceDescription, BC000420_A76ProductServiceQuantity, BC000420_A40000ProductServicePicture_GXI, BC000420_A71ProductServiceTypeId, BC000420_A77ProductServicePicture
               }
               , new Object[] {
               BC000421_A72ProductServiceTypeName
               }
               , new Object[] {
               BC000422_A64Supplier_GenId, BC000422_A74ProductServiceName, BC000422_A75ProductServiceDescription, BC000422_A76ProductServiceQuantity, BC000422_A40000ProductServicePicture_GXI, BC000422_A72ProductServiceTypeName, BC000422_A73ProductServiceId, BC000422_A71ProductServiceTypeId, BC000422_A77ProductServicePicture
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12042 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z64Supplier_GenId ;
      private short A64Supplier_GenId ;
      private short nIsMod_14 ;
      private short RcdFound14 ;
      private short RcdFound9 ;
      private short nRcdExists_14 ;
      private short Z76ProductServiceQuantity ;
      private short A76ProductServiceQuantity ;
      private short Z71ProductServiceTypeId ;
      private short A71ProductServiceTypeId ;
      private short Z73ProductServiceId ;
      private short A73ProductServiceId ;
      private short Gx_BScreen ;
      private short Gxremove14 ;
      private int trnEnded ;
      private int nGXsfl_14_idx=1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode9 ;
      private string Z70Supplier_GenContactPhone ;
      private string A70Supplier_GenContactPhone ;
      private string sMode14 ;
      private bool returnInSub ;
      private bool n67Supplier_GenVisitingAddress ;
      private bool n68Supplier_GenPostalAddress ;
      private bool n69Supplier_GenContactName ;
      private bool n70Supplier_GenContactPhone ;
      private bool Gx_longc ;
      private string Z65Supplier_GenKvKNumber ;
      private string A65Supplier_GenKvKNumber ;
      private string Z66Supplier_GenCompanyName ;
      private string A66Supplier_GenCompanyName ;
      private string Z67Supplier_GenVisitingAddress ;
      private string A67Supplier_GenVisitingAddress ;
      private string Z68Supplier_GenPostalAddress ;
      private string A68Supplier_GenPostalAddress ;
      private string Z69Supplier_GenContactName ;
      private string A69Supplier_GenContactName ;
      private string Z74ProductServiceName ;
      private string A74ProductServiceName ;
      private string Z75ProductServiceDescription ;
      private string A75ProductServiceDescription ;
      private string Z72ProductServiceTypeName ;
      private string A72ProductServiceTypeName ;
      private string Z40000ProductServicePicture_GXI ;
      private string A40000ProductServicePicture_GXI ;
      private string Z77ProductServicePicture ;
      private string A77ProductServicePicture ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSupplier_Gen bcSupplier_Gen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC00048_A64Supplier_GenId ;
      private string[] BC00048_A65Supplier_GenKvKNumber ;
      private string[] BC00048_A66Supplier_GenCompanyName ;
      private string[] BC00048_A67Supplier_GenVisitingAddress ;
      private bool[] BC00048_n67Supplier_GenVisitingAddress ;
      private string[] BC00048_A68Supplier_GenPostalAddress ;
      private bool[] BC00048_n68Supplier_GenPostalAddress ;
      private string[] BC00048_A69Supplier_GenContactName ;
      private bool[] BC00048_n69Supplier_GenContactName ;
      private string[] BC00048_A70Supplier_GenContactPhone ;
      private bool[] BC00048_n70Supplier_GenContactPhone ;
      private short[] BC00049_A64Supplier_GenId ;
      private short[] BC00047_A64Supplier_GenId ;
      private string[] BC00047_A65Supplier_GenKvKNumber ;
      private string[] BC00047_A66Supplier_GenCompanyName ;
      private string[] BC00047_A67Supplier_GenVisitingAddress ;
      private bool[] BC00047_n67Supplier_GenVisitingAddress ;
      private string[] BC00047_A68Supplier_GenPostalAddress ;
      private bool[] BC00047_n68Supplier_GenPostalAddress ;
      private string[] BC00047_A69Supplier_GenContactName ;
      private bool[] BC00047_n69Supplier_GenContactName ;
      private string[] BC00047_A70Supplier_GenContactPhone ;
      private bool[] BC00047_n70Supplier_GenContactPhone ;
      private short[] BC00046_A64Supplier_GenId ;
      private string[] BC00046_A65Supplier_GenKvKNumber ;
      private string[] BC00046_A66Supplier_GenCompanyName ;
      private string[] BC00046_A67Supplier_GenVisitingAddress ;
      private bool[] BC00046_n67Supplier_GenVisitingAddress ;
      private string[] BC00046_A68Supplier_GenPostalAddress ;
      private bool[] BC00046_n68Supplier_GenPostalAddress ;
      private string[] BC00046_A69Supplier_GenContactName ;
      private bool[] BC00046_n69Supplier_GenContactName ;
      private string[] BC00046_A70Supplier_GenContactPhone ;
      private bool[] BC00046_n70Supplier_GenContactPhone ;
      private short[] BC000411_A64Supplier_GenId ;
      private short[] BC000414_A1CustomerId ;
      private short[] BC000414_A18CustomerLocationId ;
      private short[] BC000414_A64Supplier_GenId ;
      private short[] BC000415_A64Supplier_GenId ;
      private string[] BC000415_A65Supplier_GenKvKNumber ;
      private string[] BC000415_A66Supplier_GenCompanyName ;
      private string[] BC000415_A67Supplier_GenVisitingAddress ;
      private bool[] BC000415_n67Supplier_GenVisitingAddress ;
      private string[] BC000415_A68Supplier_GenPostalAddress ;
      private bool[] BC000415_n68Supplier_GenPostalAddress ;
      private string[] BC000415_A69Supplier_GenContactName ;
      private bool[] BC000415_n69Supplier_GenContactName ;
      private string[] BC000415_A70Supplier_GenContactPhone ;
      private bool[] BC000415_n70Supplier_GenContactPhone ;
      private short[] BC000416_A64Supplier_GenId ;
      private string[] BC000416_A74ProductServiceName ;
      private string[] BC000416_A75ProductServiceDescription ;
      private short[] BC000416_A76ProductServiceQuantity ;
      private string[] BC000416_A40000ProductServicePicture_GXI ;
      private string[] BC000416_A72ProductServiceTypeName ;
      private short[] BC000416_A73ProductServiceId ;
      private short[] BC000416_A71ProductServiceTypeId ;
      private string[] BC000416_A77ProductServicePicture ;
      private string[] BC00044_A74ProductServiceName ;
      private string[] BC00044_A75ProductServiceDescription ;
      private short[] BC00044_A76ProductServiceQuantity ;
      private string[] BC00044_A40000ProductServicePicture_GXI ;
      private short[] BC00044_A71ProductServiceTypeId ;
      private string[] BC00044_A77ProductServicePicture ;
      private string[] BC00045_A72ProductServiceTypeName ;
      private short[] BC000417_A64Supplier_GenId ;
      private short[] BC000417_A73ProductServiceId ;
      private short[] BC00043_A64Supplier_GenId ;
      private short[] BC00043_A73ProductServiceId ;
      private short[] BC00042_A64Supplier_GenId ;
      private short[] BC00042_A73ProductServiceId ;
      private string[] BC000420_A74ProductServiceName ;
      private string[] BC000420_A75ProductServiceDescription ;
      private short[] BC000420_A76ProductServiceQuantity ;
      private string[] BC000420_A40000ProductServicePicture_GXI ;
      private short[] BC000420_A71ProductServiceTypeId ;
      private string[] BC000420_A77ProductServicePicture ;
      private string[] BC000421_A72ProductServiceTypeName ;
      private short[] BC000422_A64Supplier_GenId ;
      private string[] BC000422_A74ProductServiceName ;
      private string[] BC000422_A75ProductServiceDescription ;
      private short[] BC000422_A76ProductServiceQuantity ;
      private string[] BC000422_A40000ProductServicePicture_GXI ;
      private string[] BC000422_A72ProductServiceTypeName ;
      private short[] BC000422_A73ProductServiceId ;
      private short[] BC000422_A71ProductServiceTypeId ;
      private string[] BC000422_A77ProductServicePicture ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class supplier_gen_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class supplier_gen_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00042;
        prmBC00042 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC00043;
        prmBC00043 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC00044;
        prmBC00044 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC00045;
        prmBC00045 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC00046;
        prmBC00046 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC00047;
        prmBC00047 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC00048;
        prmBC00048 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC00049;
        prmBC00049 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000410;
        prmBC000410 = new Object[] {
        new ParDef("Supplier_GenKvKNumber",GXType.VarChar,8,0) ,
        new ParDef("Supplier_GenCompanyName",GXType.VarChar,40,0) ,
        new ParDef("Supplier_GenVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_GenPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_GenContactName",GXType.VarChar,40,0){Nullable=true} ,
        new ParDef("Supplier_GenContactPhone",GXType.Char,20,0){Nullable=true}
        };
        Object[] prmBC000411;
        prmBC000411 = new Object[] {
        };
        Object[] prmBC000412;
        prmBC000412 = new Object[] {
        new ParDef("Supplier_GenKvKNumber",GXType.VarChar,8,0) ,
        new ParDef("Supplier_GenCompanyName",GXType.VarChar,40,0) ,
        new ParDef("Supplier_GenVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_GenPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_GenContactName",GXType.VarChar,40,0){Nullable=true} ,
        new ParDef("Supplier_GenContactPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000413;
        prmBC000413 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000414;
        prmBC000414 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000415;
        prmBC000415 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000416;
        prmBC000416 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000417;
        prmBC000417 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000418;
        prmBC000418 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000419;
        prmBC000419 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000420;
        prmBC000420 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000421;
        prmBC000421 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC000422;
        prmBC000422 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00042", "SELECT Supplier_GenId, ProductServiceId FROM Supplier_GenProductService WHERE Supplier_GenId = :Supplier_GenId AND ProductServiceId = :ProductServiceId  FOR UPDATE OF Supplier_GenProductService",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00043", "SELECT Supplier_GenId, ProductServiceId FROM Supplier_GenProductService WHERE Supplier_GenId = :Supplier_GenId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00044", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00045", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00046", "SELECT Supplier_GenId, Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId  FOR UPDATE OF Supplier_Gen",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00047", "SELECT Supplier_GenId, Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00048", "SELECT TM1.Supplier_GenId, TM1.Supplier_GenKvKNumber, TM1.Supplier_GenCompanyName, TM1.Supplier_GenVisitingAddress, TM1.Supplier_GenPostalAddress, TM1.Supplier_GenContactName, TM1.Supplier_GenContactPhone FROM Supplier_Gen TM1 WHERE TM1.Supplier_GenId = :Supplier_GenId ORDER BY TM1.Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00048,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00049", "SELECT Supplier_GenId FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00049,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000410", "SAVEPOINT gxupdate;INSERT INTO Supplier_Gen(Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone) VALUES(:Supplier_GenKvKNumber, :Supplier_GenCompanyName, :Supplier_GenVisitingAddress, :Supplier_GenPostalAddress, :Supplier_GenContactName, :Supplier_GenContactPhone);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000410)
           ,new CursorDef("BC000411", "SELECT currval('Supplier_GenId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000411,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000412", "SAVEPOINT gxupdate;UPDATE Supplier_Gen SET Supplier_GenKvKNumber=:Supplier_GenKvKNumber, Supplier_GenCompanyName=:Supplier_GenCompanyName, Supplier_GenVisitingAddress=:Supplier_GenVisitingAddress, Supplier_GenPostalAddress=:Supplier_GenPostalAddress, Supplier_GenContactName=:Supplier_GenContactName, Supplier_GenContactPhone=:Supplier_GenContactPhone  WHERE Supplier_GenId = :Supplier_GenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000412)
           ,new CursorDef("BC000413", "SAVEPOINT gxupdate;DELETE FROM Supplier_Gen  WHERE Supplier_GenId = :Supplier_GenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000413)
           ,new CursorDef("BC000414", "SELECT CustomerId, CustomerLocationId, Supplier_GenId FROM CustomerLocationSupplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000414,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000415", "SELECT TM1.Supplier_GenId, TM1.Supplier_GenKvKNumber, TM1.Supplier_GenCompanyName, TM1.Supplier_GenVisitingAddress, TM1.Supplier_GenPostalAddress, TM1.Supplier_GenContactName, TM1.Supplier_GenContactPhone FROM Supplier_Gen TM1 WHERE TM1.Supplier_GenId = :Supplier_GenId ORDER BY TM1.Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000415,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000416", "SELECT T1.Supplier_GenId, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceQuantity, T2.ProductServicePicture_GXI, T3.ProductServiceTypeName, T1.ProductServiceId, T2.ProductServiceTypeId, T2.ProductServicePicture FROM ((Supplier_GenProductService T1 INNER JOIN ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN ProductServiceType T3 ON T3.ProductServiceTypeId = T2.ProductServiceTypeId) WHERE T1.Supplier_GenId = :Supplier_GenId and T1.ProductServiceId = :ProductServiceId ORDER BY T1.Supplier_GenId, T1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000416,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000417", "SELECT Supplier_GenId, ProductServiceId FROM Supplier_GenProductService WHERE Supplier_GenId = :Supplier_GenId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000417,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000418", "SAVEPOINT gxupdate;INSERT INTO Supplier_GenProductService(Supplier_GenId, ProductServiceId) VALUES(:Supplier_GenId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000418)
           ,new CursorDef("BC000419", "SAVEPOINT gxupdate;DELETE FROM Supplier_GenProductService  WHERE Supplier_GenId = :Supplier_GenId AND ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000419)
           ,new CursorDef("BC000420", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000420,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000421", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000421,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000422", "SELECT T1.Supplier_GenId, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceQuantity, T2.ProductServicePicture_GXI, T3.ProductServiceTypeName, T1.ProductServiceId, T2.ProductServiceTypeId, T2.ProductServicePicture FROM ((Supplier_GenProductService T1 INNER JOIN ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN ProductServiceType T3 ON T3.ProductServiceTypeId = T2.ProductServiceTypeId) WHERE T1.Supplier_GenId = :Supplier_GenId ORDER BY T1.Supplier_GenId, T1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000422,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 20 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
              return;
     }
  }

}

}
