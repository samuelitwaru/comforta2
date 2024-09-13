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
   public class supplier_agb_bc : GxSilentTrn, IGxSilentTrn
   {
      public supplier_agb_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supplier_agb_bc( IGxContext context )
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
         ReadRow038( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey038( ) ;
         standaloneModal( ) ;
         AddRow038( ) ;
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
            E11032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z55Supplier_AgbId = A55Supplier_AgbId;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate038( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls038( ) ;
            }
            else
            {
               CheckExtendedTable038( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors038( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode8 = Gx_mode;
            CONFIRM_0315( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode8;
            }
            /* Restore parent mode. */
            Gx_mode = sMode8;
         }
      }

      protected void CONFIRM_0315( )
      {
         nGXsfl_15_idx = 0;
         while ( nGXsfl_15_idx < bcSupplier_Agb.gxTpr_Productservice.Count )
         {
            ReadRow0315( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound15 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_15 != 0 ) )
            {
               GetKey0315( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound15 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0315( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0315( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0315( 7) ;
                           ZM0315( 8) ;
                        }
                        CloseExtendedTableCursors0315( ) ;
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
                  if ( RcdFound15 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0315( ) ;
                        Load0315( ) ;
                        BeforeValidate0315( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0315( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_15 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0315( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0315( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0315( 7) ;
                                 ZM0315( 8) ;
                              }
                              CloseExtendedTableCursors0315( ) ;
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
               VarsToRow15( ((SdtSupplier_Agb_ProductService)bcSupplier_Agb.gxTpr_Productservice.Item(nGXsfl_15_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12032( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11032( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM038( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z56Supplier_AgbNumber = A56Supplier_AgbNumber;
            Z57Supplier_AgbName = A57Supplier_AgbName;
            Z58Supplier_AgbKvkNumber = A58Supplier_AgbKvkNumber;
            Z59Supplier_AgbVisitingAddress = A59Supplier_AgbVisitingAddress;
            Z60Supplier_AgbPostalAddress = A60Supplier_AgbPostalAddress;
            Z61Supplier_AgbEmail = A61Supplier_AgbEmail;
            Z62Supplier_AgbPhone = A62Supplier_AgbPhone;
            Z63Supplier_AgbContactName = A63Supplier_AgbContactName;
         }
         if ( GX_JID == -5 )
         {
            Z55Supplier_AgbId = A55Supplier_AgbId;
            Z56Supplier_AgbNumber = A56Supplier_AgbNumber;
            Z57Supplier_AgbName = A57Supplier_AgbName;
            Z58Supplier_AgbKvkNumber = A58Supplier_AgbKvkNumber;
            Z59Supplier_AgbVisitingAddress = A59Supplier_AgbVisitingAddress;
            Z60Supplier_AgbPostalAddress = A60Supplier_AgbPostalAddress;
            Z61Supplier_AgbEmail = A61Supplier_AgbEmail;
            Z62Supplier_AgbPhone = A62Supplier_AgbPhone;
            Z63Supplier_AgbContactName = A63Supplier_AgbContactName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load038( )
      {
         /* Using cursor BC00038 */
         pr_default.execute(6, new Object[] {A55Supplier_AgbId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound8 = 1;
            A56Supplier_AgbNumber = BC00038_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = BC00038_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = BC00038_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = BC00038_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = BC00038_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = BC00038_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = BC00038_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = BC00038_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = BC00038_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = BC00038_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = BC00038_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = BC00038_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = BC00038_n63Supplier_AgbContactName[0];
            ZM038( -5) ;
         }
         pr_default.close(6);
         OnLoadActions038( ) ;
      }

      protected void OnLoadActions038( )
      {
      }

      protected void CheckExtendedTable038( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A56Supplier_AgbNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier_Agb Number", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A57Supplier_AgbName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier_Agb Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A58Supplier_AgbKvkNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier_Agb Kvk Number", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A61Supplier_AgbEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A61Supplier_AgbEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Supplier_Agb Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors038( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey038( )
      {
         /* Using cursor BC00039 */
         pr_default.execute(7, new Object[] {A55Supplier_AgbId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00037 */
         pr_default.execute(5, new Object[] {A55Supplier_AgbId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM038( 5) ;
            RcdFound8 = 1;
            A55Supplier_AgbId = BC00037_A55Supplier_AgbId[0];
            A56Supplier_AgbNumber = BC00037_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = BC00037_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = BC00037_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = BC00037_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = BC00037_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = BC00037_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = BC00037_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = BC00037_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = BC00037_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = BC00037_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = BC00037_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = BC00037_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = BC00037_n63Supplier_AgbContactName[0];
            Z55Supplier_AgbId = A55Supplier_AgbId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load038( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey038( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey038( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey038( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_030( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency038( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00036 */
            pr_default.execute(4, new Object[] {A55Supplier_AgbId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier_AGB"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z56Supplier_AgbNumber, BC00036_A56Supplier_AgbNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z57Supplier_AgbName, BC00036_A57Supplier_AgbName[0]) != 0 ) || ( StringUtil.StrCmp(Z58Supplier_AgbKvkNumber, BC00036_A58Supplier_AgbKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z59Supplier_AgbVisitingAddress, BC00036_A59Supplier_AgbVisitingAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z60Supplier_AgbPostalAddress, BC00036_A60Supplier_AgbPostalAddress[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z61Supplier_AgbEmail, BC00036_A61Supplier_AgbEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z62Supplier_AgbPhone, BC00036_A62Supplier_AgbPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z63Supplier_AgbContactName, BC00036_A63Supplier_AgbContactName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Supplier_AGB"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert038( )
      {
         BeforeValidate038( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable038( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM038( 0) ;
            CheckOptimisticConcurrency038( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm038( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert038( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000310 */
                     pr_default.execute(8, new Object[] {A56Supplier_AgbNumber, A57Supplier_AgbName, A58Supplier_AgbKvkNumber, n59Supplier_AgbVisitingAddress, A59Supplier_AgbVisitingAddress, n60Supplier_AgbPostalAddress, A60Supplier_AgbPostalAddress, n61Supplier_AgbEmail, A61Supplier_AgbEmail, n62Supplier_AgbPhone, A62Supplier_AgbPhone, n63Supplier_AgbContactName, A63Supplier_AgbContactName});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000311 */
                     pr_default.execute(9);
                     A55Supplier_AgbId = BC000311_A55Supplier_AgbId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_AGB");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel038( ) ;
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
               Load038( ) ;
            }
            EndLevel038( ) ;
         }
         CloseExtendedTableCursors038( ) ;
      }

      protected void Update038( )
      {
         BeforeValidate038( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable038( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency038( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm038( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate038( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000312 */
                     pr_default.execute(10, new Object[] {A56Supplier_AgbNumber, A57Supplier_AgbName, A58Supplier_AgbKvkNumber, n59Supplier_AgbVisitingAddress, A59Supplier_AgbVisitingAddress, n60Supplier_AgbPostalAddress, A60Supplier_AgbPostalAddress, n61Supplier_AgbEmail, A61Supplier_AgbEmail, n62Supplier_AgbPhone, A62Supplier_AgbPhone, n63Supplier_AgbContactName, A63Supplier_AgbContactName, A55Supplier_AgbId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_AGB");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier_AGB"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate038( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel038( ) ;
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
            EndLevel038( ) ;
         }
         CloseExtendedTableCursors038( ) ;
      }

      protected void DeferredUpdate038( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate038( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency038( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls038( ) ;
            AfterConfirm038( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete038( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0315( ) ;
                  while ( RcdFound15 != 0 )
                  {
                     getByPrimaryKey0315( ) ;
                     Delete0315( ) ;
                     ScanKeyNext0315( ) ;
                  }
                  ScanKeyEnd0315( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000313 */
                     pr_default.execute(11, new Object[] {A55Supplier_AgbId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_AGB");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel038( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls038( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000314 */
            pr_default.execute(12, new Object[] {A55Supplier_AgbId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Supplier_Agb", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void ProcessNestedLevel0315( )
      {
         nGXsfl_15_idx = 0;
         while ( nGXsfl_15_idx < bcSupplier_Agb.gxTpr_Productservice.Count )
         {
            ReadRow0315( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound15 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_15 != 0 ) )
            {
               standaloneNotModal0315( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0315( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0315( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0315( ) ;
                  }
               }
            }
            KeyVarsToRow15( ((SdtSupplier_Agb_ProductService)bcSupplier_Agb.gxTpr_Productservice.Item(nGXsfl_15_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_15_idx = 0;
            while ( nGXsfl_15_idx < bcSupplier_Agb.gxTpr_Productservice.Count )
            {
               ReadRow0315( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound15 == 0 )
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
                  bcSupplier_Agb.gxTpr_Productservice.RemoveElement(nGXsfl_15_idx);
                  nGXsfl_15_idx = (int)(nGXsfl_15_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0315( ) ;
                  VarsToRow15( ((SdtSupplier_Agb_ProductService)bcSupplier_Agb.gxTpr_Productservice.Item(nGXsfl_15_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0315( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_15 = 0;
         nIsMod_15 = 0;
      }

      protected void ProcessLevel038( )
      {
         /* Save parent mode. */
         sMode8 = Gx_mode;
         ProcessNestedLevel0315( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode8;
         /* ' Update level parameters */
      }

      protected void EndLevel038( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete038( ) ;
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

      public void ScanKeyStart038( )
      {
         /* Scan By routine */
         /* Using cursor BC000315 */
         pr_default.execute(13, new Object[] {A55Supplier_AgbId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A55Supplier_AgbId = BC000315_A55Supplier_AgbId[0];
            A56Supplier_AgbNumber = BC000315_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = BC000315_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = BC000315_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = BC000315_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = BC000315_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = BC000315_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = BC000315_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = BC000315_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = BC000315_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = BC000315_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = BC000315_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = BC000315_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = BC000315_n63Supplier_AgbContactName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext038( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound8 = 0;
         ScanKeyLoad038( ) ;
      }

      protected void ScanKeyLoad038( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A55Supplier_AgbId = BC000315_A55Supplier_AgbId[0];
            A56Supplier_AgbNumber = BC000315_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = BC000315_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = BC000315_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = BC000315_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = BC000315_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = BC000315_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = BC000315_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = BC000315_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = BC000315_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = BC000315_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = BC000315_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = BC000315_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = BC000315_n63Supplier_AgbContactName[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd038( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm038( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert038( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate038( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete038( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete038( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate038( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes038( )
      {
      }

      protected void ZM0315( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z74ProductServiceName = A74ProductServiceName;
            Z75ProductServiceDescription = A75ProductServiceDescription;
            Z76ProductServiceQuantity = A76ProductServiceQuantity;
            Z71ProductServiceTypeId = A71ProductServiceTypeId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z72ProductServiceTypeName = A72ProductServiceTypeName;
         }
         if ( GX_JID == -6 )
         {
            Z55Supplier_AgbId = A55Supplier_AgbId;
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

      protected void standaloneNotModal0315( )
      {
      }

      protected void standaloneModal0315( )
      {
      }

      protected void Load0315( )
      {
         /* Using cursor BC000316 */
         pr_default.execute(14, new Object[] {A55Supplier_AgbId, A73ProductServiceId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound15 = 1;
            A74ProductServiceName = BC000316_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000316_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000316_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000316_A40000ProductServicePicture_GXI[0];
            A72ProductServiceTypeName = BC000316_A72ProductServiceTypeName[0];
            A71ProductServiceTypeId = BC000316_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000316_A77ProductServicePicture[0];
            ZM0315( -6) ;
         }
         pr_default.close(14);
         OnLoadActions0315( ) ;
      }

      protected void OnLoadActions0315( )
      {
      }

      protected void CheckExtendedTable0315( )
      {
         Gx_BScreen = 1;
         standaloneModal0315( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PRODUCTSERVICEID");
            AnyError = 1;
         }
         A74ProductServiceName = BC00034_A74ProductServiceName[0];
         A75ProductServiceDescription = BC00034_A75ProductServiceDescription[0];
         A76ProductServiceQuantity = BC00034_A76ProductServiceQuantity[0];
         A40000ProductServicePicture_GXI = BC00034_A40000ProductServicePicture_GXI[0];
         A71ProductServiceTypeId = BC00034_A71ProductServiceTypeId[0];
         A77ProductServicePicture = BC00034_A77ProductServicePicture[0];
         pr_default.close(2);
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
         }
         A72ProductServiceTypeName = BC00035_A72ProductServiceTypeName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0315( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0315( )
      {
      }

      protected void GetKey0315( )
      {
         /* Using cursor BC000317 */
         pr_default.execute(15, new Object[] {A55Supplier_AgbId, A73ProductServiceId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey0315( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A55Supplier_AgbId, A73ProductServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0315( 6) ;
            RcdFound15 = 1;
            InitializeNonKey0315( ) ;
            A73ProductServiceId = BC00033_A73ProductServiceId[0];
            Z55Supplier_AgbId = A55Supplier_AgbId;
            Z73ProductServiceId = A73ProductServiceId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0315( ) ;
            Load0315( ) ;
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0315( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0315( ) ;
            Gx_mode = sMode15;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0315( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0315( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A55Supplier_AgbId, A73ProductServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier_AgbProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Supplier_AgbProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0315( )
      {
         BeforeValidate0315( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0315( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0315( 0) ;
            CheckOptimisticConcurrency0315( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0315( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0315( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000318 */
                     pr_default.execute(16, new Object[] {A55Supplier_AgbId, A73ProductServiceId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier_AgbProductService");
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
               Load0315( ) ;
            }
            EndLevel0315( ) ;
         }
         CloseExtendedTableCursors0315( ) ;
      }

      protected void Update0315( )
      {
         BeforeValidate0315( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0315( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0315( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0315( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0315( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table Supplier_AgbProductService */
                     DeferredUpdate0315( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0315( ) ;
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
            EndLevel0315( ) ;
         }
         CloseExtendedTableCursors0315( ) ;
      }

      protected void DeferredUpdate0315( )
      {
      }

      protected void Delete0315( )
      {
         Gx_mode = "DLT";
         BeforeValidate0315( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0315( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0315( ) ;
            AfterConfirm0315( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0315( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000319 */
                  pr_default.execute(17, new Object[] {A55Supplier_AgbId, A73ProductServiceId});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("Supplier_AgbProductService");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0315( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0315( )
      {
         standaloneModal0315( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000320 */
            pr_default.execute(18, new Object[] {A73ProductServiceId});
            A74ProductServiceName = BC000320_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000320_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000320_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000320_A40000ProductServicePicture_GXI[0];
            A71ProductServiceTypeId = BC000320_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000320_A77ProductServicePicture[0];
            pr_default.close(18);
            /* Using cursor BC000321 */
            pr_default.execute(19, new Object[] {A71ProductServiceTypeId});
            A72ProductServiceTypeName = BC000321_A72ProductServiceTypeName[0];
            pr_default.close(19);
         }
      }

      protected void EndLevel0315( )
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

      public void ScanKeyStart0315( )
      {
         /* Scan By routine */
         /* Using cursor BC000322 */
         pr_default.execute(20, new Object[] {A55Supplier_AgbId});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound15 = 1;
            A74ProductServiceName = BC000322_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000322_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000322_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000322_A40000ProductServicePicture_GXI[0];
            A72ProductServiceTypeName = BC000322_A72ProductServiceTypeName[0];
            A73ProductServiceId = BC000322_A73ProductServiceId[0];
            A71ProductServiceTypeId = BC000322_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000322_A77ProductServicePicture[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0315( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound15 = 0;
         ScanKeyLoad0315( ) ;
      }

      protected void ScanKeyLoad0315( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound15 = 1;
            A74ProductServiceName = BC000322_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000322_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000322_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000322_A40000ProductServicePicture_GXI[0];
            A72ProductServiceTypeName = BC000322_A72ProductServiceTypeName[0];
            A73ProductServiceId = BC000322_A73ProductServiceId[0];
            A71ProductServiceTypeId = BC000322_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000322_A77ProductServicePicture[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0315( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0315( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0315( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0315( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0315( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0315( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0315( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0315( )
      {
      }

      protected void send_integrity_lvl_hashes0315( )
      {
      }

      protected void send_integrity_lvl_hashes038( )
      {
      }

      protected void AddRow038( )
      {
         VarsToRow8( bcSupplier_Agb) ;
      }

      protected void ReadRow038( )
      {
         RowToVars8( bcSupplier_Agb, 1) ;
      }

      protected void AddRow0315( )
      {
         SdtSupplier_Agb_ProductService obj15;
         obj15 = new SdtSupplier_Agb_ProductService(context);
         VarsToRow15( obj15) ;
         bcSupplier_Agb.gxTpr_Productservice.Add(obj15, 0);
         obj15.gxTpr_Mode = "UPD";
         obj15.gxTpr_Modified = 0;
      }

      protected void ReadRow0315( )
      {
         nGXsfl_15_idx = (int)(nGXsfl_15_idx+1);
         RowToVars15( ((SdtSupplier_Agb_ProductService)bcSupplier_Agb.gxTpr_Productservice.Item(nGXsfl_15_idx)), 1) ;
      }

      protected void InitializeNonKey038( )
      {
         A56Supplier_AgbNumber = "";
         A57Supplier_AgbName = "";
         A58Supplier_AgbKvkNumber = "";
         A59Supplier_AgbVisitingAddress = "";
         n59Supplier_AgbVisitingAddress = false;
         A60Supplier_AgbPostalAddress = "";
         n60Supplier_AgbPostalAddress = false;
         A61Supplier_AgbEmail = "";
         n61Supplier_AgbEmail = false;
         A62Supplier_AgbPhone = "";
         n62Supplier_AgbPhone = false;
         A63Supplier_AgbContactName = "";
         n63Supplier_AgbContactName = false;
         Z56Supplier_AgbNumber = "";
         Z57Supplier_AgbName = "";
         Z58Supplier_AgbKvkNumber = "";
         Z59Supplier_AgbVisitingAddress = "";
         Z60Supplier_AgbPostalAddress = "";
         Z61Supplier_AgbEmail = "";
         Z62Supplier_AgbPhone = "";
         Z63Supplier_AgbContactName = "";
      }

      protected void InitAll038( )
      {
         A55Supplier_AgbId = 0;
         InitializeNonKey038( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0315( )
      {
         A74ProductServiceName = "";
         A75ProductServiceDescription = "";
         A76ProductServiceQuantity = 0;
         A77ProductServicePicture = "";
         A40000ProductServicePicture_GXI = "";
         A71ProductServiceTypeId = 0;
         A72ProductServiceTypeName = "";
      }

      protected void InitAll0315( )
      {
         A73ProductServiceId = 0;
         InitializeNonKey0315( ) ;
      }

      protected void StandaloneModalInsert0315( )
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

      public void VarsToRow8( SdtSupplier_Agb obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Supplier_agbnumber = A56Supplier_AgbNumber;
         obj8.gxTpr_Supplier_agbname = A57Supplier_AgbName;
         obj8.gxTpr_Supplier_agbkvknumber = A58Supplier_AgbKvkNumber;
         obj8.gxTpr_Supplier_agbvisitingaddress = A59Supplier_AgbVisitingAddress;
         obj8.gxTpr_Supplier_agbpostaladdress = A60Supplier_AgbPostalAddress;
         obj8.gxTpr_Supplier_agbemail = A61Supplier_AgbEmail;
         obj8.gxTpr_Supplier_agbphone = A62Supplier_AgbPhone;
         obj8.gxTpr_Supplier_agbcontactname = A63Supplier_AgbContactName;
         obj8.gxTpr_Supplier_agbid = A55Supplier_AgbId;
         obj8.gxTpr_Supplier_agbid_Z = Z55Supplier_AgbId;
         obj8.gxTpr_Supplier_agbnumber_Z = Z56Supplier_AgbNumber;
         obj8.gxTpr_Supplier_agbname_Z = Z57Supplier_AgbName;
         obj8.gxTpr_Supplier_agbkvknumber_Z = Z58Supplier_AgbKvkNumber;
         obj8.gxTpr_Supplier_agbvisitingaddress_Z = Z59Supplier_AgbVisitingAddress;
         obj8.gxTpr_Supplier_agbpostaladdress_Z = Z60Supplier_AgbPostalAddress;
         obj8.gxTpr_Supplier_agbemail_Z = Z61Supplier_AgbEmail;
         obj8.gxTpr_Supplier_agbphone_Z = Z62Supplier_AgbPhone;
         obj8.gxTpr_Supplier_agbcontactname_Z = Z63Supplier_AgbContactName;
         obj8.gxTpr_Supplier_agbvisitingaddress_N = (short)(Convert.ToInt16(n59Supplier_AgbVisitingAddress));
         obj8.gxTpr_Supplier_agbpostaladdress_N = (short)(Convert.ToInt16(n60Supplier_AgbPostalAddress));
         obj8.gxTpr_Supplier_agbemail_N = (short)(Convert.ToInt16(n61Supplier_AgbEmail));
         obj8.gxTpr_Supplier_agbphone_N = (short)(Convert.ToInt16(n62Supplier_AgbPhone));
         obj8.gxTpr_Supplier_agbcontactname_N = (short)(Convert.ToInt16(n63Supplier_AgbContactName));
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( SdtSupplier_Agb obj8 )
      {
         obj8.gxTpr_Supplier_agbid = A55Supplier_AgbId;
         return  ;
      }

      public void RowToVars8( SdtSupplier_Agb obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A56Supplier_AgbNumber = obj8.gxTpr_Supplier_agbnumber;
         A57Supplier_AgbName = obj8.gxTpr_Supplier_agbname;
         A58Supplier_AgbKvkNumber = obj8.gxTpr_Supplier_agbkvknumber;
         A59Supplier_AgbVisitingAddress = obj8.gxTpr_Supplier_agbvisitingaddress;
         n59Supplier_AgbVisitingAddress = false;
         A60Supplier_AgbPostalAddress = obj8.gxTpr_Supplier_agbpostaladdress;
         n60Supplier_AgbPostalAddress = false;
         A61Supplier_AgbEmail = obj8.gxTpr_Supplier_agbemail;
         n61Supplier_AgbEmail = false;
         A62Supplier_AgbPhone = obj8.gxTpr_Supplier_agbphone;
         n62Supplier_AgbPhone = false;
         A63Supplier_AgbContactName = obj8.gxTpr_Supplier_agbcontactname;
         n63Supplier_AgbContactName = false;
         A55Supplier_AgbId = obj8.gxTpr_Supplier_agbid;
         Z55Supplier_AgbId = obj8.gxTpr_Supplier_agbid_Z;
         Z56Supplier_AgbNumber = obj8.gxTpr_Supplier_agbnumber_Z;
         Z57Supplier_AgbName = obj8.gxTpr_Supplier_agbname_Z;
         Z58Supplier_AgbKvkNumber = obj8.gxTpr_Supplier_agbkvknumber_Z;
         Z59Supplier_AgbVisitingAddress = obj8.gxTpr_Supplier_agbvisitingaddress_Z;
         Z60Supplier_AgbPostalAddress = obj8.gxTpr_Supplier_agbpostaladdress_Z;
         Z61Supplier_AgbEmail = obj8.gxTpr_Supplier_agbemail_Z;
         Z62Supplier_AgbPhone = obj8.gxTpr_Supplier_agbphone_Z;
         Z63Supplier_AgbContactName = obj8.gxTpr_Supplier_agbcontactname_Z;
         n59Supplier_AgbVisitingAddress = (bool)(Convert.ToBoolean(obj8.gxTpr_Supplier_agbvisitingaddress_N));
         n60Supplier_AgbPostalAddress = (bool)(Convert.ToBoolean(obj8.gxTpr_Supplier_agbpostaladdress_N));
         n61Supplier_AgbEmail = (bool)(Convert.ToBoolean(obj8.gxTpr_Supplier_agbemail_N));
         n62Supplier_AgbPhone = (bool)(Convert.ToBoolean(obj8.gxTpr_Supplier_agbphone_N));
         n63Supplier_AgbContactName = (bool)(Convert.ToBoolean(obj8.gxTpr_Supplier_agbcontactname_N));
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow15( SdtSupplier_Agb_ProductService obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Productservicename = A74ProductServiceName;
         obj15.gxTpr_Productservicedescription = A75ProductServiceDescription;
         obj15.gxTpr_Productservicequantity = A76ProductServiceQuantity;
         obj15.gxTpr_Productservicepicture = A77ProductServicePicture;
         obj15.gxTpr_Productservicepicture_gxi = A40000ProductServicePicture_GXI;
         obj15.gxTpr_Productservicetypeid = A71ProductServiceTypeId;
         obj15.gxTpr_Productservicetypename = A72ProductServiceTypeName;
         obj15.gxTpr_Productserviceid = A73ProductServiceId;
         obj15.gxTpr_Productserviceid_Z = Z73ProductServiceId;
         obj15.gxTpr_Productservicename_Z = Z74ProductServiceName;
         obj15.gxTpr_Productservicedescription_Z = Z75ProductServiceDescription;
         obj15.gxTpr_Productservicequantity_Z = Z76ProductServiceQuantity;
         obj15.gxTpr_Productservicetypeid_Z = Z71ProductServiceTypeId;
         obj15.gxTpr_Productservicetypename_Z = Z72ProductServiceTypeName;
         obj15.gxTpr_Productservicepicture_gxi_Z = Z40000ProductServicePicture_GXI;
         obj15.gxTpr_Modified = nIsMod_15;
         return  ;
      }

      public void KeyVarsToRow15( SdtSupplier_Agb_ProductService obj15 )
      {
         obj15.gxTpr_Productserviceid = A73ProductServiceId;
         return  ;
      }

      public void RowToVars15( SdtSupplier_Agb_ProductService obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A74ProductServiceName = obj15.gxTpr_Productservicename;
         A75ProductServiceDescription = obj15.gxTpr_Productservicedescription;
         A76ProductServiceQuantity = obj15.gxTpr_Productservicequantity;
         A77ProductServicePicture = obj15.gxTpr_Productservicepicture;
         A40000ProductServicePicture_GXI = obj15.gxTpr_Productservicepicture_gxi;
         A71ProductServiceTypeId = obj15.gxTpr_Productservicetypeid;
         A72ProductServiceTypeName = obj15.gxTpr_Productservicetypename;
         A73ProductServiceId = obj15.gxTpr_Productserviceid;
         Z73ProductServiceId = obj15.gxTpr_Productserviceid_Z;
         Z74ProductServiceName = obj15.gxTpr_Productservicename_Z;
         Z75ProductServiceDescription = obj15.gxTpr_Productservicedescription_Z;
         Z76ProductServiceQuantity = obj15.gxTpr_Productservicequantity_Z;
         Z71ProductServiceTypeId = obj15.gxTpr_Productservicetypeid_Z;
         Z72ProductServiceTypeName = obj15.gxTpr_Productservicetypename_Z;
         Z40000ProductServicePicture_GXI = obj15.gxTpr_Productservicepicture_gxi_Z;
         nIsMod_15 = obj15.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A55Supplier_AgbId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey038( ) ;
         ScanKeyStart038( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z55Supplier_AgbId = A55Supplier_AgbId;
         }
         ZM038( -5) ;
         OnLoadActions038( ) ;
         AddRow038( ) ;
         bcSupplier_Agb.gxTpr_Productservice.ClearCollection();
         if ( RcdFound8 == 1 )
         {
            ScanKeyStart0315( ) ;
            nGXsfl_15_idx = 1;
            while ( RcdFound15 != 0 )
            {
               Z55Supplier_AgbId = A55Supplier_AgbId;
               Z73ProductServiceId = A73ProductServiceId;
               ZM0315( -6) ;
               OnLoadActions0315( ) ;
               nRcdExists_15 = 1;
               nIsMod_15 = 0;
               AddRow0315( ) ;
               nGXsfl_15_idx = (int)(nGXsfl_15_idx+1);
               ScanKeyNext0315( ) ;
            }
            ScanKeyEnd0315( ) ;
         }
         ScanKeyEnd038( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcSupplier_Agb, 0) ;
         ScanKeyStart038( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z55Supplier_AgbId = A55Supplier_AgbId;
         }
         ZM038( -5) ;
         OnLoadActions038( ) ;
         AddRow038( ) ;
         bcSupplier_Agb.gxTpr_Productservice.ClearCollection();
         if ( RcdFound8 == 1 )
         {
            ScanKeyStart0315( ) ;
            nGXsfl_15_idx = 1;
            while ( RcdFound15 != 0 )
            {
               Z55Supplier_AgbId = A55Supplier_AgbId;
               Z73ProductServiceId = A73ProductServiceId;
               ZM0315( -6) ;
               OnLoadActions0315( ) ;
               nRcdExists_15 = 1;
               nIsMod_15 = 0;
               AddRow0315( ) ;
               nGXsfl_15_idx = (int)(nGXsfl_15_idx+1);
               ScanKeyNext0315( ) ;
            }
            ScanKeyEnd0315( ) ;
         }
         ScanKeyEnd038( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey038( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert038( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A55Supplier_AgbId != Z55Supplier_AgbId )
               {
                  A55Supplier_AgbId = Z55Supplier_AgbId;
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
                  Update038( ) ;
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
                  if ( A55Supplier_AgbId != Z55Supplier_AgbId )
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
                        Insert038( ) ;
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
                        Insert038( ) ;
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
         RowToVars8( bcSupplier_Agb, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcSupplier_Agb) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcSupplier_Agb, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert038( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcSupplier_Agb) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow8( bcSupplier_Agb) ;
         }
         else
         {
            SdtSupplier_Agb auxBC = new SdtSupplier_Agb(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A55Supplier_AgbId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSupplier_Agb);
               auxBC.Save();
               bcSupplier_Agb.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars8( bcSupplier_Agb, 1) ;
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
         RowToVars8( bcSupplier_Agb, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert038( ) ;
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
               VarsToRow8( bcSupplier_Agb) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow8( bcSupplier_Agb) ;
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
         RowToVars8( bcSupplier_Agb, 0) ;
         GetKey038( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A55Supplier_AgbId != Z55Supplier_AgbId )
            {
               A55Supplier_AgbId = Z55Supplier_AgbId;
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
            if ( A55Supplier_AgbId != Z55Supplier_AgbId )
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
         context.RollbackDataStores("supplier_agb_bc",pr_default);
         VarsToRow8( bcSupplier_Agb) ;
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
         Gx_mode = bcSupplier_Agb.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSupplier_Agb.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSupplier_Agb )
         {
            bcSupplier_Agb = (SdtSupplier_Agb)(sdt);
            if ( StringUtil.StrCmp(bcSupplier_Agb.gxTpr_Mode, "") == 0 )
            {
               bcSupplier_Agb.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcSupplier_Agb) ;
            }
            else
            {
               RowToVars8( bcSupplier_Agb, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSupplier_Agb.gxTpr_Mode, "") == 0 )
            {
               bcSupplier_Agb.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcSupplier_Agb, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSupplier_Agb Supplier_Agb_BC
      {
         get {
            return bcSupplier_Agb ;
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
            return "supplier_agb_Execute" ;
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
         sMode8 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z56Supplier_AgbNumber = "";
         A56Supplier_AgbNumber = "";
         Z57Supplier_AgbName = "";
         A57Supplier_AgbName = "";
         Z58Supplier_AgbKvkNumber = "";
         A58Supplier_AgbKvkNumber = "";
         Z59Supplier_AgbVisitingAddress = "";
         A59Supplier_AgbVisitingAddress = "";
         Z60Supplier_AgbPostalAddress = "";
         A60Supplier_AgbPostalAddress = "";
         Z61Supplier_AgbEmail = "";
         A61Supplier_AgbEmail = "";
         Z62Supplier_AgbPhone = "";
         A62Supplier_AgbPhone = "";
         Z63Supplier_AgbContactName = "";
         A63Supplier_AgbContactName = "";
         BC00038_A55Supplier_AgbId = new short[1] ;
         BC00038_A56Supplier_AgbNumber = new string[] {""} ;
         BC00038_A57Supplier_AgbName = new string[] {""} ;
         BC00038_A58Supplier_AgbKvkNumber = new string[] {""} ;
         BC00038_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         BC00038_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         BC00038_A60Supplier_AgbPostalAddress = new string[] {""} ;
         BC00038_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         BC00038_A61Supplier_AgbEmail = new string[] {""} ;
         BC00038_n61Supplier_AgbEmail = new bool[] {false} ;
         BC00038_A62Supplier_AgbPhone = new string[] {""} ;
         BC00038_n62Supplier_AgbPhone = new bool[] {false} ;
         BC00038_A63Supplier_AgbContactName = new string[] {""} ;
         BC00038_n63Supplier_AgbContactName = new bool[] {false} ;
         BC00039_A55Supplier_AgbId = new short[1] ;
         BC00037_A55Supplier_AgbId = new short[1] ;
         BC00037_A56Supplier_AgbNumber = new string[] {""} ;
         BC00037_A57Supplier_AgbName = new string[] {""} ;
         BC00037_A58Supplier_AgbKvkNumber = new string[] {""} ;
         BC00037_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         BC00037_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         BC00037_A60Supplier_AgbPostalAddress = new string[] {""} ;
         BC00037_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         BC00037_A61Supplier_AgbEmail = new string[] {""} ;
         BC00037_n61Supplier_AgbEmail = new bool[] {false} ;
         BC00037_A62Supplier_AgbPhone = new string[] {""} ;
         BC00037_n62Supplier_AgbPhone = new bool[] {false} ;
         BC00037_A63Supplier_AgbContactName = new string[] {""} ;
         BC00037_n63Supplier_AgbContactName = new bool[] {false} ;
         BC00036_A55Supplier_AgbId = new short[1] ;
         BC00036_A56Supplier_AgbNumber = new string[] {""} ;
         BC00036_A57Supplier_AgbName = new string[] {""} ;
         BC00036_A58Supplier_AgbKvkNumber = new string[] {""} ;
         BC00036_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         BC00036_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         BC00036_A60Supplier_AgbPostalAddress = new string[] {""} ;
         BC00036_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         BC00036_A61Supplier_AgbEmail = new string[] {""} ;
         BC00036_n61Supplier_AgbEmail = new bool[] {false} ;
         BC00036_A62Supplier_AgbPhone = new string[] {""} ;
         BC00036_n62Supplier_AgbPhone = new bool[] {false} ;
         BC00036_A63Supplier_AgbContactName = new string[] {""} ;
         BC00036_n63Supplier_AgbContactName = new bool[] {false} ;
         BC000311_A55Supplier_AgbId = new short[1] ;
         BC000314_A1CustomerId = new short[1] ;
         BC000314_A18CustomerLocationId = new short[1] ;
         BC000314_A55Supplier_AgbId = new short[1] ;
         BC000315_A55Supplier_AgbId = new short[1] ;
         BC000315_A56Supplier_AgbNumber = new string[] {""} ;
         BC000315_A57Supplier_AgbName = new string[] {""} ;
         BC000315_A58Supplier_AgbKvkNumber = new string[] {""} ;
         BC000315_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         BC000315_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         BC000315_A60Supplier_AgbPostalAddress = new string[] {""} ;
         BC000315_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         BC000315_A61Supplier_AgbEmail = new string[] {""} ;
         BC000315_n61Supplier_AgbEmail = new bool[] {false} ;
         BC000315_A62Supplier_AgbPhone = new string[] {""} ;
         BC000315_n62Supplier_AgbPhone = new bool[] {false} ;
         BC000315_A63Supplier_AgbContactName = new string[] {""} ;
         BC000315_n63Supplier_AgbContactName = new bool[] {false} ;
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
         BC000316_A55Supplier_AgbId = new short[1] ;
         BC000316_A74ProductServiceName = new string[] {""} ;
         BC000316_A75ProductServiceDescription = new string[] {""} ;
         BC000316_A76ProductServiceQuantity = new short[1] ;
         BC000316_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC000316_A72ProductServiceTypeName = new string[] {""} ;
         BC000316_A73ProductServiceId = new short[1] ;
         BC000316_A71ProductServiceTypeId = new short[1] ;
         BC000316_A77ProductServicePicture = new string[] {""} ;
         BC00034_A74ProductServiceName = new string[] {""} ;
         BC00034_A75ProductServiceDescription = new string[] {""} ;
         BC00034_A76ProductServiceQuantity = new short[1] ;
         BC00034_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC00034_A71ProductServiceTypeId = new short[1] ;
         BC00034_A77ProductServicePicture = new string[] {""} ;
         BC00035_A72ProductServiceTypeName = new string[] {""} ;
         BC000317_A55Supplier_AgbId = new short[1] ;
         BC000317_A73ProductServiceId = new short[1] ;
         BC00033_A55Supplier_AgbId = new short[1] ;
         BC00033_A73ProductServiceId = new short[1] ;
         sMode15 = "";
         BC00032_A55Supplier_AgbId = new short[1] ;
         BC00032_A73ProductServiceId = new short[1] ;
         BC000320_A74ProductServiceName = new string[] {""} ;
         BC000320_A75ProductServiceDescription = new string[] {""} ;
         BC000320_A76ProductServiceQuantity = new short[1] ;
         BC000320_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC000320_A71ProductServiceTypeId = new short[1] ;
         BC000320_A77ProductServicePicture = new string[] {""} ;
         BC000321_A72ProductServiceTypeName = new string[] {""} ;
         BC000322_A55Supplier_AgbId = new short[1] ;
         BC000322_A74ProductServiceName = new string[] {""} ;
         BC000322_A75ProductServiceDescription = new string[] {""} ;
         BC000322_A76ProductServiceQuantity = new short[1] ;
         BC000322_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC000322_A72ProductServiceTypeName = new string[] {""} ;
         BC000322_A73ProductServiceId = new short[1] ;
         BC000322_A71ProductServiceTypeId = new short[1] ;
         BC000322_A77ProductServicePicture = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.supplier_agb_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_agb_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A55Supplier_AgbId, BC00032_A73ProductServiceId
               }
               , new Object[] {
               BC00033_A55Supplier_AgbId, BC00033_A73ProductServiceId
               }
               , new Object[] {
               BC00034_A74ProductServiceName, BC00034_A75ProductServiceDescription, BC00034_A76ProductServiceQuantity, BC00034_A40000ProductServicePicture_GXI, BC00034_A71ProductServiceTypeId, BC00034_A77ProductServicePicture
               }
               , new Object[] {
               BC00035_A72ProductServiceTypeName
               }
               , new Object[] {
               BC00036_A55Supplier_AgbId, BC00036_A56Supplier_AgbNumber, BC00036_A57Supplier_AgbName, BC00036_A58Supplier_AgbKvkNumber, BC00036_A59Supplier_AgbVisitingAddress, BC00036_n59Supplier_AgbVisitingAddress, BC00036_A60Supplier_AgbPostalAddress, BC00036_n60Supplier_AgbPostalAddress, BC00036_A61Supplier_AgbEmail, BC00036_n61Supplier_AgbEmail,
               BC00036_A62Supplier_AgbPhone, BC00036_n62Supplier_AgbPhone, BC00036_A63Supplier_AgbContactName, BC00036_n63Supplier_AgbContactName
               }
               , new Object[] {
               BC00037_A55Supplier_AgbId, BC00037_A56Supplier_AgbNumber, BC00037_A57Supplier_AgbName, BC00037_A58Supplier_AgbKvkNumber, BC00037_A59Supplier_AgbVisitingAddress, BC00037_n59Supplier_AgbVisitingAddress, BC00037_A60Supplier_AgbPostalAddress, BC00037_n60Supplier_AgbPostalAddress, BC00037_A61Supplier_AgbEmail, BC00037_n61Supplier_AgbEmail,
               BC00037_A62Supplier_AgbPhone, BC00037_n62Supplier_AgbPhone, BC00037_A63Supplier_AgbContactName, BC00037_n63Supplier_AgbContactName
               }
               , new Object[] {
               BC00038_A55Supplier_AgbId, BC00038_A56Supplier_AgbNumber, BC00038_A57Supplier_AgbName, BC00038_A58Supplier_AgbKvkNumber, BC00038_A59Supplier_AgbVisitingAddress, BC00038_n59Supplier_AgbVisitingAddress, BC00038_A60Supplier_AgbPostalAddress, BC00038_n60Supplier_AgbPostalAddress, BC00038_A61Supplier_AgbEmail, BC00038_n61Supplier_AgbEmail,
               BC00038_A62Supplier_AgbPhone, BC00038_n62Supplier_AgbPhone, BC00038_A63Supplier_AgbContactName, BC00038_n63Supplier_AgbContactName
               }
               , new Object[] {
               BC00039_A55Supplier_AgbId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000311_A55Supplier_AgbId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000314_A1CustomerId, BC000314_A18CustomerLocationId, BC000314_A55Supplier_AgbId
               }
               , new Object[] {
               BC000315_A55Supplier_AgbId, BC000315_A56Supplier_AgbNumber, BC000315_A57Supplier_AgbName, BC000315_A58Supplier_AgbKvkNumber, BC000315_A59Supplier_AgbVisitingAddress, BC000315_n59Supplier_AgbVisitingAddress, BC000315_A60Supplier_AgbPostalAddress, BC000315_n60Supplier_AgbPostalAddress, BC000315_A61Supplier_AgbEmail, BC000315_n61Supplier_AgbEmail,
               BC000315_A62Supplier_AgbPhone, BC000315_n62Supplier_AgbPhone, BC000315_A63Supplier_AgbContactName, BC000315_n63Supplier_AgbContactName
               }
               , new Object[] {
               BC000316_A55Supplier_AgbId, BC000316_A74ProductServiceName, BC000316_A75ProductServiceDescription, BC000316_A76ProductServiceQuantity, BC000316_A40000ProductServicePicture_GXI, BC000316_A72ProductServiceTypeName, BC000316_A73ProductServiceId, BC000316_A71ProductServiceTypeId, BC000316_A77ProductServicePicture
               }
               , new Object[] {
               BC000317_A55Supplier_AgbId, BC000317_A73ProductServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000320_A74ProductServiceName, BC000320_A75ProductServiceDescription, BC000320_A76ProductServiceQuantity, BC000320_A40000ProductServicePicture_GXI, BC000320_A71ProductServiceTypeId, BC000320_A77ProductServicePicture
               }
               , new Object[] {
               BC000321_A72ProductServiceTypeName
               }
               , new Object[] {
               BC000322_A55Supplier_AgbId, BC000322_A74ProductServiceName, BC000322_A75ProductServiceDescription, BC000322_A76ProductServiceQuantity, BC000322_A40000ProductServicePicture_GXI, BC000322_A72ProductServiceTypeName, BC000322_A73ProductServiceId, BC000322_A71ProductServiceTypeId, BC000322_A77ProductServicePicture
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12032 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z55Supplier_AgbId ;
      private short A55Supplier_AgbId ;
      private short nIsMod_15 ;
      private short RcdFound15 ;
      private short RcdFound8 ;
      private short nRcdExists_15 ;
      private short Z76ProductServiceQuantity ;
      private short A76ProductServiceQuantity ;
      private short Z71ProductServiceTypeId ;
      private short A71ProductServiceTypeId ;
      private short Z73ProductServiceId ;
      private short A73ProductServiceId ;
      private short Gx_BScreen ;
      private short Gxremove15 ;
      private int trnEnded ;
      private int nGXsfl_15_idx=1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode8 ;
      private string Z62Supplier_AgbPhone ;
      private string A62Supplier_AgbPhone ;
      private string sMode15 ;
      private bool returnInSub ;
      private bool n59Supplier_AgbVisitingAddress ;
      private bool n60Supplier_AgbPostalAddress ;
      private bool n61Supplier_AgbEmail ;
      private bool n62Supplier_AgbPhone ;
      private bool n63Supplier_AgbContactName ;
      private bool Gx_longc ;
      private string Z56Supplier_AgbNumber ;
      private string A56Supplier_AgbNumber ;
      private string Z57Supplier_AgbName ;
      private string A57Supplier_AgbName ;
      private string Z58Supplier_AgbKvkNumber ;
      private string A58Supplier_AgbKvkNumber ;
      private string Z59Supplier_AgbVisitingAddress ;
      private string A59Supplier_AgbVisitingAddress ;
      private string Z60Supplier_AgbPostalAddress ;
      private string A60Supplier_AgbPostalAddress ;
      private string Z61Supplier_AgbEmail ;
      private string A61Supplier_AgbEmail ;
      private string Z63Supplier_AgbContactName ;
      private string A63Supplier_AgbContactName ;
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
      private SdtSupplier_Agb bcSupplier_Agb ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC00038_A55Supplier_AgbId ;
      private string[] BC00038_A56Supplier_AgbNumber ;
      private string[] BC00038_A57Supplier_AgbName ;
      private string[] BC00038_A58Supplier_AgbKvkNumber ;
      private string[] BC00038_A59Supplier_AgbVisitingAddress ;
      private bool[] BC00038_n59Supplier_AgbVisitingAddress ;
      private string[] BC00038_A60Supplier_AgbPostalAddress ;
      private bool[] BC00038_n60Supplier_AgbPostalAddress ;
      private string[] BC00038_A61Supplier_AgbEmail ;
      private bool[] BC00038_n61Supplier_AgbEmail ;
      private string[] BC00038_A62Supplier_AgbPhone ;
      private bool[] BC00038_n62Supplier_AgbPhone ;
      private string[] BC00038_A63Supplier_AgbContactName ;
      private bool[] BC00038_n63Supplier_AgbContactName ;
      private short[] BC00039_A55Supplier_AgbId ;
      private short[] BC00037_A55Supplier_AgbId ;
      private string[] BC00037_A56Supplier_AgbNumber ;
      private string[] BC00037_A57Supplier_AgbName ;
      private string[] BC00037_A58Supplier_AgbKvkNumber ;
      private string[] BC00037_A59Supplier_AgbVisitingAddress ;
      private bool[] BC00037_n59Supplier_AgbVisitingAddress ;
      private string[] BC00037_A60Supplier_AgbPostalAddress ;
      private bool[] BC00037_n60Supplier_AgbPostalAddress ;
      private string[] BC00037_A61Supplier_AgbEmail ;
      private bool[] BC00037_n61Supplier_AgbEmail ;
      private string[] BC00037_A62Supplier_AgbPhone ;
      private bool[] BC00037_n62Supplier_AgbPhone ;
      private string[] BC00037_A63Supplier_AgbContactName ;
      private bool[] BC00037_n63Supplier_AgbContactName ;
      private short[] BC00036_A55Supplier_AgbId ;
      private string[] BC00036_A56Supplier_AgbNumber ;
      private string[] BC00036_A57Supplier_AgbName ;
      private string[] BC00036_A58Supplier_AgbKvkNumber ;
      private string[] BC00036_A59Supplier_AgbVisitingAddress ;
      private bool[] BC00036_n59Supplier_AgbVisitingAddress ;
      private string[] BC00036_A60Supplier_AgbPostalAddress ;
      private bool[] BC00036_n60Supplier_AgbPostalAddress ;
      private string[] BC00036_A61Supplier_AgbEmail ;
      private bool[] BC00036_n61Supplier_AgbEmail ;
      private string[] BC00036_A62Supplier_AgbPhone ;
      private bool[] BC00036_n62Supplier_AgbPhone ;
      private string[] BC00036_A63Supplier_AgbContactName ;
      private bool[] BC00036_n63Supplier_AgbContactName ;
      private short[] BC000311_A55Supplier_AgbId ;
      private short[] BC000314_A1CustomerId ;
      private short[] BC000314_A18CustomerLocationId ;
      private short[] BC000314_A55Supplier_AgbId ;
      private short[] BC000315_A55Supplier_AgbId ;
      private string[] BC000315_A56Supplier_AgbNumber ;
      private string[] BC000315_A57Supplier_AgbName ;
      private string[] BC000315_A58Supplier_AgbKvkNumber ;
      private string[] BC000315_A59Supplier_AgbVisitingAddress ;
      private bool[] BC000315_n59Supplier_AgbVisitingAddress ;
      private string[] BC000315_A60Supplier_AgbPostalAddress ;
      private bool[] BC000315_n60Supplier_AgbPostalAddress ;
      private string[] BC000315_A61Supplier_AgbEmail ;
      private bool[] BC000315_n61Supplier_AgbEmail ;
      private string[] BC000315_A62Supplier_AgbPhone ;
      private bool[] BC000315_n62Supplier_AgbPhone ;
      private string[] BC000315_A63Supplier_AgbContactName ;
      private bool[] BC000315_n63Supplier_AgbContactName ;
      private short[] BC000316_A55Supplier_AgbId ;
      private string[] BC000316_A74ProductServiceName ;
      private string[] BC000316_A75ProductServiceDescription ;
      private short[] BC000316_A76ProductServiceQuantity ;
      private string[] BC000316_A40000ProductServicePicture_GXI ;
      private string[] BC000316_A72ProductServiceTypeName ;
      private short[] BC000316_A73ProductServiceId ;
      private short[] BC000316_A71ProductServiceTypeId ;
      private string[] BC000316_A77ProductServicePicture ;
      private string[] BC00034_A74ProductServiceName ;
      private string[] BC00034_A75ProductServiceDescription ;
      private short[] BC00034_A76ProductServiceQuantity ;
      private string[] BC00034_A40000ProductServicePicture_GXI ;
      private short[] BC00034_A71ProductServiceTypeId ;
      private string[] BC00034_A77ProductServicePicture ;
      private string[] BC00035_A72ProductServiceTypeName ;
      private short[] BC000317_A55Supplier_AgbId ;
      private short[] BC000317_A73ProductServiceId ;
      private short[] BC00033_A55Supplier_AgbId ;
      private short[] BC00033_A73ProductServiceId ;
      private short[] BC00032_A55Supplier_AgbId ;
      private short[] BC00032_A73ProductServiceId ;
      private string[] BC000320_A74ProductServiceName ;
      private string[] BC000320_A75ProductServiceDescription ;
      private short[] BC000320_A76ProductServiceQuantity ;
      private string[] BC000320_A40000ProductServicePicture_GXI ;
      private short[] BC000320_A71ProductServiceTypeId ;
      private string[] BC000320_A77ProductServicePicture ;
      private string[] BC000321_A72ProductServiceTypeName ;
      private short[] BC000322_A55Supplier_AgbId ;
      private string[] BC000322_A74ProductServiceName ;
      private string[] BC000322_A75ProductServiceDescription ;
      private short[] BC000322_A76ProductServiceQuantity ;
      private string[] BC000322_A40000ProductServicePicture_GXI ;
      private string[] BC000322_A72ProductServiceTypeName ;
      private short[] BC000322_A73ProductServiceId ;
      private short[] BC000322_A71ProductServiceTypeId ;
      private string[] BC000322_A77ProductServicePicture ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class supplier_agb_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class supplier_agb_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00032;
        prmBC00032 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC00033;
        prmBC00033 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC00034;
        prmBC00034 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC00035;
        prmBC00035 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC00036;
        prmBC00036 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC00037;
        prmBC00037 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC00038;
        prmBC00038 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC00039;
        prmBC00039 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000310;
        prmBC000310 = new Object[] {
        new ParDef("Supplier_AgbNumber",GXType.VarChar,10,0) ,
        new ParDef("Supplier_AgbName",GXType.VarChar,40,0) ,
        new ParDef("Supplier_AgbKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("Supplier_AgbVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_AgbPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_AgbEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("Supplier_AgbPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("Supplier_AgbContactName",GXType.VarChar,40,0){Nullable=true}
        };
        Object[] prmBC000311;
        prmBC000311 = new Object[] {
        };
        Object[] prmBC000312;
        prmBC000312 = new Object[] {
        new ParDef("Supplier_AgbNumber",GXType.VarChar,10,0) ,
        new ParDef("Supplier_AgbName",GXType.VarChar,40,0) ,
        new ParDef("Supplier_AgbKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("Supplier_AgbVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_AgbPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("Supplier_AgbEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("Supplier_AgbPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("Supplier_AgbContactName",GXType.VarChar,40,0){Nullable=true} ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000313;
        prmBC000313 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000314;
        prmBC000314 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000315;
        prmBC000315 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000316;
        prmBC000316 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000317;
        prmBC000317 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000318;
        prmBC000318 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000319;
        prmBC000319 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000320;
        prmBC000320 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000321;
        prmBC000321 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC000322;
        prmBC000322 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00032", "SELECT Supplier_AgbId, ProductServiceId FROM Supplier_AgbProductService WHERE Supplier_AgbId = :Supplier_AgbId AND ProductServiceId = :ProductServiceId  FOR UPDATE OF Supplier_AgbProductService",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00033", "SELECT Supplier_AgbId, ProductServiceId FROM Supplier_AgbProductService WHERE Supplier_AgbId = :Supplier_AgbId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00034", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00035", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00036", "SELECT Supplier_AgbId, Supplier_AgbNumber, Supplier_AgbName, Supplier_AgbKvkNumber, Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress, Supplier_AgbEmail, Supplier_AgbPhone, Supplier_AgbContactName FROM Supplier_AGB WHERE Supplier_AgbId = :Supplier_AgbId  FOR UPDATE OF Supplier_AGB",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00037", "SELECT Supplier_AgbId, Supplier_AgbNumber, Supplier_AgbName, Supplier_AgbKvkNumber, Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress, Supplier_AgbEmail, Supplier_AgbPhone, Supplier_AgbContactName FROM Supplier_AGB WHERE Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00037,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00038", "SELECT TM1.Supplier_AgbId, TM1.Supplier_AgbNumber, TM1.Supplier_AgbName, TM1.Supplier_AgbKvkNumber, TM1.Supplier_AgbVisitingAddress, TM1.Supplier_AgbPostalAddress, TM1.Supplier_AgbEmail, TM1.Supplier_AgbPhone, TM1.Supplier_AgbContactName FROM Supplier_AGB TM1 WHERE TM1.Supplier_AgbId = :Supplier_AgbId ORDER BY TM1.Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00038,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00039", "SELECT Supplier_AgbId FROM Supplier_AGB WHERE Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00039,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000310", "SAVEPOINT gxupdate;INSERT INTO Supplier_AGB(Supplier_AgbNumber, Supplier_AgbName, Supplier_AgbKvkNumber, Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress, Supplier_AgbEmail, Supplier_AgbPhone, Supplier_AgbContactName) VALUES(:Supplier_AgbNumber, :Supplier_AgbName, :Supplier_AgbKvkNumber, :Supplier_AgbVisitingAddress, :Supplier_AgbPostalAddress, :Supplier_AgbEmail, :Supplier_AgbPhone, :Supplier_AgbContactName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000310)
           ,new CursorDef("BC000311", "SELECT currval('Supplier_AgbId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000311,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000312", "SAVEPOINT gxupdate;UPDATE Supplier_AGB SET Supplier_AgbNumber=:Supplier_AgbNumber, Supplier_AgbName=:Supplier_AgbName, Supplier_AgbKvkNumber=:Supplier_AgbKvkNumber, Supplier_AgbVisitingAddress=:Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress=:Supplier_AgbPostalAddress, Supplier_AgbEmail=:Supplier_AgbEmail, Supplier_AgbPhone=:Supplier_AgbPhone, Supplier_AgbContactName=:Supplier_AgbContactName  WHERE Supplier_AgbId = :Supplier_AgbId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000312)
           ,new CursorDef("BC000313", "SAVEPOINT gxupdate;DELETE FROM Supplier_AGB  WHERE Supplier_AgbId = :Supplier_AgbId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000313)
           ,new CursorDef("BC000314", "SELECT CustomerId, CustomerLocationId, Supplier_AgbId FROM CustomerLocationSupplier_Agb WHERE Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000314,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000315", "SELECT TM1.Supplier_AgbId, TM1.Supplier_AgbNumber, TM1.Supplier_AgbName, TM1.Supplier_AgbKvkNumber, TM1.Supplier_AgbVisitingAddress, TM1.Supplier_AgbPostalAddress, TM1.Supplier_AgbEmail, TM1.Supplier_AgbPhone, TM1.Supplier_AgbContactName FROM Supplier_AGB TM1 WHERE TM1.Supplier_AgbId = :Supplier_AgbId ORDER BY TM1.Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000315,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000316", "SELECT T1.Supplier_AgbId, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceQuantity, T2.ProductServicePicture_GXI, T3.ProductServiceTypeName, T1.ProductServiceId, T2.ProductServiceTypeId, T2.ProductServicePicture FROM ((Supplier_AgbProductService T1 INNER JOIN ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN ProductServiceType T3 ON T3.ProductServiceTypeId = T2.ProductServiceTypeId) WHERE T1.Supplier_AgbId = :Supplier_AgbId and T1.ProductServiceId = :ProductServiceId ORDER BY T1.Supplier_AgbId, T1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000316,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000317", "SELECT Supplier_AgbId, ProductServiceId FROM Supplier_AgbProductService WHERE Supplier_AgbId = :Supplier_AgbId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000317,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000318", "SAVEPOINT gxupdate;INSERT INTO Supplier_AgbProductService(Supplier_AgbId, ProductServiceId) VALUES(:Supplier_AgbId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000318)
           ,new CursorDef("BC000319", "SAVEPOINT gxupdate;DELETE FROM Supplier_AgbProductService  WHERE Supplier_AgbId = :Supplier_AgbId AND ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000319)
           ,new CursorDef("BC000320", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000320,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000321", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000321,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000322", "SELECT T1.Supplier_AgbId, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceQuantity, T2.ProductServicePicture_GXI, T3.ProductServiceTypeName, T1.ProductServiceId, T2.ProductServiceTypeId, T2.ProductServicePicture FROM ((Supplier_AgbProductService T1 INNER JOIN ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN ProductServiceType T3 ON T3.ProductServiceTypeId = T2.ProductServiceTypeId) WHERE T1.Supplier_AgbId = :Supplier_AgbId ORDER BY T1.Supplier_AgbId, T1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000322,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
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
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
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
