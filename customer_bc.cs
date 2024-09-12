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
   public class customer_bc : GxSilentTrn, IGxSilentTrn
   {
      public customer_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customer_bc( IGxContext context )
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
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
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
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1CustomerId = A1CustomerId;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
                  ZM011( 19) ;
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode1 = Gx_mode;
            CONFIRM_012( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_013( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode1;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode1;
         }
      }

      protected void CONFIRM_0121( )
      {
         nGXsfl_21_idx = 0;
         while ( nGXsfl_21_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.Count )
         {
            ReadRow0121( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound21 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_21 != 0 ) )
            {
               GetKey0121( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound21 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0121( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0121( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0121( 28) ;
                           ZM0121( 29) ;
                        }
                        CloseExtendedTableCursors0121( ) ;
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
                  if ( RcdFound21 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0121( ) ;
                        Load0121( ) ;
                        BeforeValidate0121( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0121( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_21 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0121( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0121( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0121( 28) ;
                                 ZM0121( 29) ;
                              }
                              CloseExtendedTableCursors0121( ) ;
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
               VarsToRow21( ((SdtCustomer_Locations_Amenities)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.Item(nGXsfl_21_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0117( )
      {
         nGXsfl_17_idx = 0;
         while ( nGXsfl_17_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.Count )
         {
            ReadRow0117( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound17 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_17 != 0 ) )
            {
               GetKey0117( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound17 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0117( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0117( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0117( 26) ;
                        }
                        CloseExtendedTableCursors0117( ) ;
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
                  if ( RcdFound17 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0117( ) ;
                        Load0117( ) ;
                        BeforeValidate0117( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0117( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_17 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0117( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0117( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0117( 26) ;
                              }
                              CloseExtendedTableCursors0117( ) ;
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
               VarsToRow17( ((SdtCustomer_Locations_Supplier_Gen)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.Item(nGXsfl_17_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0116( )
      {
         nGXsfl_16_idx = 0;
         while ( nGXsfl_16_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.Count )
         {
            ReadRow0116( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound16 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_16 != 0 ) )
            {
               GetKey0116( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound16 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0116( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0116( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0116( 24) ;
                        }
                        CloseExtendedTableCursors0116( ) ;
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
                  if ( RcdFound16 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0116( ) ;
                        Load0116( ) ;
                        BeforeValidate0116( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0116( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0116( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0116( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0116( 24) ;
                              }
                              CloseExtendedTableCursors0116( ) ;
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
               VarsToRow16( ((SdtCustomer_Locations_Supplier_Agb)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.Item(nGXsfl_16_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_014( )
      {
         s94CustomerLocationLastLine = O94CustomerLocationLastLine;
         nGXsfl_4_idx = 0;
         while ( nGXsfl_4_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.Count )
         {
            ReadRow014( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound4 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_4 != 0 ) )
            {
               GetKey014( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound4 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate014( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable014( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors014( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O94CustomerLocationLastLine = A94CustomerLocationLastLine;
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
                  if ( RcdFound4 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey014( ) ;
                        Load014( ) ;
                        BeforeValidate014( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls014( ) ;
                           O94CustomerLocationLastLine = A94CustomerLocationLastLine;
                        }
                     }
                     else
                     {
                        if ( nIsMod_4 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate014( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable014( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors014( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O94CustomerLocationLastLine = A94CustomerLocationLastLine;
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
               VarsToRow4( ((SdtCustomer_Locations_Receptionist)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.Item(nGXsfl_4_idx))) ;
            }
         }
         O94CustomerLocationLastLine = s94CustomerLocationLastLine;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_013( )
      {
         s95CustomerLastLineLocation = O95CustomerLastLineLocation;
         nGXsfl_3_idx = 0;
         while ( nGXsfl_3_idx < bcCustomer.gxTpr_Locations.Count )
         {
            ReadRow013( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound3 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_3 != 0 ) )
            {
               GetKey013( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate013( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable013( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors013( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Save parent mode. */
                           sMode3 = Gx_mode;
                           CONFIRM_014( ) ;
                           if ( AnyError == 0 )
                           {
                              CONFIRM_0116( ) ;
                              if ( AnyError == 0 )
                              {
                                 CONFIRM_0117( ) ;
                                 if ( AnyError == 0 )
                                 {
                                    CONFIRM_0121( ) ;
                                    if ( AnyError == 0 )
                                    {
                                       /* Restore parent mode. */
                                       Gx_mode = sMode3;
                                    }
                                 }
                              }
                           }
                           /* Restore parent mode. */
                           Gx_mode = sMode3;
                        }
                        O95CustomerLastLineLocation = A95CustomerLastLineLocation;
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
                  if ( RcdFound3 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey013( ) ;
                        Load013( ) ;
                        BeforeValidate013( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls013( ) ;
                           O95CustomerLastLineLocation = A95CustomerLastLineLocation;
                        }
                     }
                     else
                     {
                        if ( nIsMod_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate013( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable013( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors013( ) ;
                              if ( AnyError == 0 )
                              {
                                 /* Save parent mode. */
                                 sMode3 = Gx_mode;
                                 CONFIRM_014( ) ;
                                 if ( AnyError == 0 )
                                 {
                                    CONFIRM_0116( ) ;
                                    if ( AnyError == 0 )
                                    {
                                       CONFIRM_0117( ) ;
                                       if ( AnyError == 0 )
                                       {
                                          CONFIRM_0121( ) ;
                                          if ( AnyError == 0 )
                                          {
                                             /* Restore parent mode. */
                                             Gx_mode = sMode3;
                                          }
                                       }
                                    }
                                 }
                                 /* Restore parent mode. */
                                 Gx_mode = sMode3;
                              }
                              O95CustomerLastLineLocation = A95CustomerLastLineLocation;
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
               VarsToRow3( ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx))) ;
            }
         }
         O95CustomerLastLineLocation = s95CustomerLastLineLocation;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_012( )
      {
         s93CustomerLastLine = O93CustomerLastLine;
         nGXsfl_2_idx = 0;
         while ( nGXsfl_2_idx < bcCustomer.gxTpr_Manager.Count )
         {
            ReadRow012( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound2 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_2 != 0 ) )
            {
               GetKey012( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound2 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate012( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable012( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors012( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O93CustomerLastLine = A93CustomerLastLine;
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
                  if ( RcdFound2 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey012( ) ;
                        Load012( ) ;
                        BeforeValidate012( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls012( ) ;
                           O93CustomerLastLine = A93CustomerLastLine;
                        }
                     }
                     else
                     {
                        if ( nIsMod_2 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate012( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable012( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors012( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O93CustomerLastLine = A93CustomerLastLine;
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
               VarsToRow2( ((SdtCustomer_Manager)bcCustomer.gxTpr_Manager.Item(nGXsfl_2_idx))) ;
            }
         }
         O93CustomerLastLine = s93CustomerLastLine;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV29Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV30GXV1 = 1;
            while ( AV30GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV30GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CustomerTypeId") == 0 )
               {
                  AV13Insert_CustomerTypeId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV30GXV1 = (int)(AV30GXV1+1);
            }
         }
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z41CustomerKvkNumber = A41CustomerKvkNumber;
            Z3CustomerName = A3CustomerName;
            Z4CustomerPostalAddress = A4CustomerPostalAddress;
            Z5CustomerEmail = A5CustomerEmail;
            Z6CustomerVisitingAddress = A6CustomerVisitingAddress;
            Z7CustomerPhone = A7CustomerPhone;
            Z14CustomerVatNumber = A14CustomerVatNumber;
            Z93CustomerLastLine = A93CustomerLastLine;
            Z95CustomerLastLineLocation = A95CustomerLastLineLocation;
            Z78CustomerTypeId = A78CustomerTypeId;
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z79CustomerTypeName = A79CustomerTypeName;
         }
         if ( GX_JID == -18 )
         {
            Z1CustomerId = A1CustomerId;
            Z41CustomerKvkNumber = A41CustomerKvkNumber;
            Z3CustomerName = A3CustomerName;
            Z4CustomerPostalAddress = A4CustomerPostalAddress;
            Z5CustomerEmail = A5CustomerEmail;
            Z6CustomerVisitingAddress = A6CustomerVisitingAddress;
            Z7CustomerPhone = A7CustomerPhone;
            Z14CustomerVatNumber = A14CustomerVatNumber;
            Z93CustomerLastLine = A93CustomerLastLine;
            Z95CustomerLastLineLocation = A95CustomerLastLineLocation;
            Z78CustomerTypeId = A78CustomerTypeId;
            Z79CustomerTypeName = A79CustomerTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV29Pgmname = "Customer_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC000121 */
         pr_default.execute(19, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound1 = 1;
            A41CustomerKvkNumber = BC000121_A41CustomerKvkNumber[0];
            A3CustomerName = BC000121_A3CustomerName[0];
            A4CustomerPostalAddress = BC000121_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = BC000121_n4CustomerPostalAddress[0];
            A5CustomerEmail = BC000121_A5CustomerEmail[0];
            n5CustomerEmail = BC000121_n5CustomerEmail[0];
            A6CustomerVisitingAddress = BC000121_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = BC000121_n6CustomerVisitingAddress[0];
            A7CustomerPhone = BC000121_A7CustomerPhone[0];
            n7CustomerPhone = BC000121_n7CustomerPhone[0];
            A14CustomerVatNumber = BC000121_A14CustomerVatNumber[0];
            A79CustomerTypeName = BC000121_A79CustomerTypeName[0];
            A93CustomerLastLine = BC000121_A93CustomerLastLine[0];
            A95CustomerLastLineLocation = BC000121_A95CustomerLastLineLocation[0];
            A78CustomerTypeId = BC000121_A78CustomerTypeId[0];
            n78CustomerTypeId = BC000121_n78CustomerTypeId[0];
            ZM011( -18) ;
         }
         pr_default.close(19);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A5CustomerEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A5CustomerEmail)) ) )
         {
            GX_msglist.addItem("Field Customer Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000120 */
         pr_default.execute(18, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A78CustomerTypeId) ) )
            {
               GX_msglist.addItem("No matching 'Customer Type'.", "ForeignKeyNotFound", 1, "CUSTOMERTYPEID");
               AnyError = 1;
            }
         }
         A79CustomerTypeName = BC000120_A79CustomerTypeName[0];
         pr_default.close(18);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(18);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC000122 */
         pr_default.execute(20, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000119 */
         pr_default.execute(17, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            ZM011( 18) ;
            RcdFound1 = 1;
            A1CustomerId = BC000119_A1CustomerId[0];
            A41CustomerKvkNumber = BC000119_A41CustomerKvkNumber[0];
            A3CustomerName = BC000119_A3CustomerName[0];
            A4CustomerPostalAddress = BC000119_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = BC000119_n4CustomerPostalAddress[0];
            A5CustomerEmail = BC000119_A5CustomerEmail[0];
            n5CustomerEmail = BC000119_n5CustomerEmail[0];
            A6CustomerVisitingAddress = BC000119_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = BC000119_n6CustomerVisitingAddress[0];
            A7CustomerPhone = BC000119_A7CustomerPhone[0];
            n7CustomerPhone = BC000119_n7CustomerPhone[0];
            A14CustomerVatNumber = BC000119_A14CustomerVatNumber[0];
            A93CustomerLastLine = BC000119_A93CustomerLastLine[0];
            A95CustomerLastLineLocation = BC000119_A95CustomerLastLineLocation[0];
            A78CustomerTypeId = BC000119_A78CustomerTypeId[0];
            n78CustomerTypeId = BC000119_n78CustomerTypeId[0];
            O95CustomerLastLineLocation = A95CustomerLastLineLocation;
            O93CustomerLastLine = A93CustomerLastLine;
            Z1CustomerId = A1CustomerId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(17);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         CONFIRM_010( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000118 */
            pr_default.execute(16, new Object[] {A1CustomerId});
            if ( (pr_default.getStatus(16) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Customer"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(16) == 101) || ( StringUtil.StrCmp(Z41CustomerKvkNumber, BC000118_A41CustomerKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z3CustomerName, BC000118_A3CustomerName[0]) != 0 ) || ( StringUtil.StrCmp(Z4CustomerPostalAddress, BC000118_A4CustomerPostalAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z5CustomerEmail, BC000118_A5CustomerEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z6CustomerVisitingAddress, BC000118_A6CustomerVisitingAddress[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z7CustomerPhone, BC000118_A7CustomerPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z14CustomerVatNumber, BC000118_A14CustomerVatNumber[0]) != 0 ) || ( Z93CustomerLastLine != BC000118_A93CustomerLastLine[0] ) || ( Z95CustomerLastLineLocation != BC000118_A95CustomerLastLineLocation[0] ) || ( Z78CustomerTypeId != BC000118_A78CustomerTypeId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Customer"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000123 */
                     pr_default.execute(21, new Object[] {A41CustomerKvkNumber, A3CustomerName, n4CustomerPostalAddress, A4CustomerPostalAddress, n5CustomerEmail, A5CustomerEmail, n6CustomerVisitingAddress, A6CustomerVisitingAddress, n7CustomerPhone, A7CustomerPhone, A14CustomerVatNumber, A93CustomerLastLine, A95CustomerLastLineLocation, n78CustomerTypeId, A78CustomerTypeId});
                     pr_default.close(21);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000124 */
                     pr_default.execute(22);
                     A1CustomerId = BC000124_A1CustomerId[0];
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("Customer");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000125 */
                     pr_default.execute(23, new Object[] {A41CustomerKvkNumber, A3CustomerName, n4CustomerPostalAddress, A4CustomerPostalAddress, n5CustomerEmail, A5CustomerEmail, n6CustomerVisitingAddress, A6CustomerVisitingAddress, n7CustomerPhone, A7CustomerPhone, A14CustomerVatNumber, A93CustomerLastLine, A95CustomerLastLineLocation, n78CustomerTypeId, A78CustomerTypeId, A1CustomerId});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("Customer");
                     if ( (pr_default.getStatus(23) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Customer"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  A93CustomerLastLine = O93CustomerLastLine;
                  ScanKeyStart012( ) ;
                  while ( RcdFound2 != 0 )
                  {
                     getByPrimaryKey012( ) ;
                     Delete012( ) ;
                     ScanKeyNext012( ) ;
                     O93CustomerLastLine = A93CustomerLastLine;
                  }
                  ScanKeyEnd012( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000126 */
                     pr_default.execute(24, new Object[] {A1CustomerId});
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("Customer");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000127 */
            pr_default.execute(25, new Object[] {n78CustomerTypeId, A78CustomerTypeId});
            A79CustomerTypeName = BC000127_A79CustomerTypeName[0];
            pr_default.close(25);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000128 */
            pr_default.execute(26, new Object[] {A1CustomerId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CustomerCustomization"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor BC000129 */
            pr_default.execute(27, new Object[] {A1CustomerId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Page"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor BC000130 */
            pr_default.execute(28, new Object[] {A1CustomerId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CustomerLocation"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
         }
      }

      protected void ProcessNestedLevel012( )
      {
         s93CustomerLastLine = O93CustomerLastLine;
         nGXsfl_2_idx = 0;
         while ( nGXsfl_2_idx < bcCustomer.gxTpr_Manager.Count )
         {
            ReadRow012( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound2 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_2 != 0 ) )
            {
               standaloneNotModal012( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert012( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete012( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update012( ) ;
                  }
               }
               O93CustomerLastLine = A93CustomerLastLine;
            }
            KeyVarsToRow2( ((SdtCustomer_Manager)bcCustomer.gxTpr_Manager.Item(nGXsfl_2_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_2_idx = 0;
            while ( nGXsfl_2_idx < bcCustomer.gxTpr_Manager.Count )
            {
               ReadRow012( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound2 == 0 )
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
                  bcCustomer.gxTpr_Manager.RemoveElement(nGXsfl_2_idx);
                  nGXsfl_2_idx = (int)(nGXsfl_2_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey012( ) ;
                  VarsToRow2( ((SdtCustomer_Manager)bcCustomer.gxTpr_Manager.Item(nGXsfl_2_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll012( ) ;
         if ( AnyError != 0 )
         {
            O93CustomerLastLine = s93CustomerLastLine;
         }
         nRcdExists_2 = 0;
         nIsMod_2 = 0;
      }

      protected void ProcessNestedLevel013( )
      {
         s95CustomerLastLineLocation = O95CustomerLastLineLocation;
         nGXsfl_3_idx = 0;
         while ( nGXsfl_3_idx < bcCustomer.gxTpr_Locations.Count )
         {
            ReadRow013( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound3 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_3 != 0 ) )
            {
               standaloneNotModal013( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert013( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete013( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update013( ) ;
                  }
               }
               O95CustomerLastLineLocation = A95CustomerLastLineLocation;
            }
            KeyVarsToRow3( ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_3_idx = 0;
            while ( nGXsfl_3_idx < bcCustomer.gxTpr_Locations.Count )
            {
               ReadRow013( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound3 == 0 )
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
                  bcCustomer.gxTpr_Locations.RemoveElement(nGXsfl_3_idx);
                  nGXsfl_3_idx = (int)(nGXsfl_3_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey013( ) ;
                  VarsToRow3( ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll013( ) ;
         if ( AnyError != 0 )
         {
            O95CustomerLastLineLocation = s95CustomerLastLineLocation;
         }
         nRcdExists_3 = 0;
         nIsMod_3 = 0;
      }

      protected void ProcessLevel011( )
      {
         /* Save parent mode. */
         sMode1 = Gx_mode;
         ProcessNestedLevel012( ) ;
         ProcessNestedLevel013( ) ;
         if ( AnyError != 0 )
         {
            O93CustomerLastLine = s93CustomerLastLine;
            O95CustomerLastLineLocation = s95CustomerLastLineLocation;
         }
         /* Restore parent mode. */
         Gx_mode = sMode1;
         /* ' Update level parameters */
         /* Using cursor BC000131 */
         pr_default.execute(29, new Object[] {A95CustomerLastLineLocation, A93CustomerLastLine, A1CustomerId});
         pr_default.close(29);
         pr_default.SmartCacheProvider.SetUpdated("Customer");
      }

      protected void EndLevel011( )
      {
         pr_default.close(16);
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
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

      public void ScanKeyStart011( )
      {
         /* Scan By routine */
         /* Using cursor BC000132 */
         pr_default.execute(30, new Object[] {A1CustomerId});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound1 = 1;
            A1CustomerId = BC000132_A1CustomerId[0];
            A41CustomerKvkNumber = BC000132_A41CustomerKvkNumber[0];
            A3CustomerName = BC000132_A3CustomerName[0];
            A4CustomerPostalAddress = BC000132_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = BC000132_n4CustomerPostalAddress[0];
            A5CustomerEmail = BC000132_A5CustomerEmail[0];
            n5CustomerEmail = BC000132_n5CustomerEmail[0];
            A6CustomerVisitingAddress = BC000132_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = BC000132_n6CustomerVisitingAddress[0];
            A7CustomerPhone = BC000132_A7CustomerPhone[0];
            n7CustomerPhone = BC000132_n7CustomerPhone[0];
            A14CustomerVatNumber = BC000132_A14CustomerVatNumber[0];
            A79CustomerTypeName = BC000132_A79CustomerTypeName[0];
            A93CustomerLastLine = BC000132_A93CustomerLastLine[0];
            A95CustomerLastLineLocation = BC000132_A95CustomerLastLineLocation[0];
            A78CustomerTypeId = BC000132_A78CustomerTypeId[0];
            n78CustomerTypeId = BC000132_n78CustomerTypeId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound1 = 1;
            A1CustomerId = BC000132_A1CustomerId[0];
            A41CustomerKvkNumber = BC000132_A41CustomerKvkNumber[0];
            A3CustomerName = BC000132_A3CustomerName[0];
            A4CustomerPostalAddress = BC000132_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = BC000132_n4CustomerPostalAddress[0];
            A5CustomerEmail = BC000132_A5CustomerEmail[0];
            n5CustomerEmail = BC000132_n5CustomerEmail[0];
            A6CustomerVisitingAddress = BC000132_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = BC000132_n6CustomerVisitingAddress[0];
            A7CustomerPhone = BC000132_A7CustomerPhone[0];
            n7CustomerPhone = BC000132_n7CustomerPhone[0];
            A14CustomerVatNumber = BC000132_A14CustomerVatNumber[0];
            A79CustomerTypeName = BC000132_A79CustomerTypeName[0];
            A93CustomerLastLine = BC000132_A93CustomerLastLine[0];
            A95CustomerLastLineLocation = BC000132_A95CustomerLastLineLocation[0];
            A78CustomerTypeId = BC000132_A78CustomerTypeId[0];
            n78CustomerTypeId = BC000132_n78CustomerTypeId[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void ZM012( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z13CustomerManagerGAMGUID = A13CustomerManagerGAMGUID;
            Z17CustomerManagerInitials = A17CustomerManagerInitials;
            Z16CustomerManagerGivenName = A16CustomerManagerGivenName;
            Z9CustomerManagerLastName = A9CustomerManagerLastName;
            Z10CustomerManagerEmail = A10CustomerManagerEmail;
            Z11CustomerManagerPhone = A11CustomerManagerPhone;
            Z12CustomerManagerGender = A12CustomerManagerGender;
         }
         if ( GX_JID == -20 )
         {
            Z1CustomerId = A1CustomerId;
            Z15CustomerManagerId = A15CustomerManagerId;
            Z13CustomerManagerGAMGUID = A13CustomerManagerGAMGUID;
            Z17CustomerManagerInitials = A17CustomerManagerInitials;
            Z16CustomerManagerGivenName = A16CustomerManagerGivenName;
            Z9CustomerManagerLastName = A9CustomerManagerLastName;
            Z10CustomerManagerEmail = A10CustomerManagerEmail;
            Z11CustomerManagerPhone = A11CustomerManagerPhone;
            Z12CustomerManagerGender = A12CustomerManagerGender;
         }
      }

      protected void standaloneNotModal012( )
      {
      }

      protected void standaloneModal012( )
      {
         if ( IsIns( )  )
         {
            A93CustomerLastLine = (short)(O93CustomerLastLine+1);
         }
         if ( IsIns( )  )
         {
            A15CustomerManagerId = A93CustomerLastLine;
         }
      }

      protected void Load012( )
      {
         /* Using cursor BC000133 */
         pr_default.execute(31, new Object[] {A1CustomerId, A15CustomerManagerId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound2 = 1;
            A13CustomerManagerGAMGUID = BC000133_A13CustomerManagerGAMGUID[0];
            A17CustomerManagerInitials = BC000133_A17CustomerManagerInitials[0];
            n17CustomerManagerInitials = BC000133_n17CustomerManagerInitials[0];
            A16CustomerManagerGivenName = BC000133_A16CustomerManagerGivenName[0];
            A9CustomerManagerLastName = BC000133_A9CustomerManagerLastName[0];
            A10CustomerManagerEmail = BC000133_A10CustomerManagerEmail[0];
            A11CustomerManagerPhone = BC000133_A11CustomerManagerPhone[0];
            n11CustomerManagerPhone = BC000133_n11CustomerManagerPhone[0];
            A12CustomerManagerGender = BC000133_A12CustomerManagerGender[0];
            n12CustomerManagerGender = BC000133_n12CustomerManagerGender[0];
            ZM012( -20) ;
         }
         pr_default.close(31);
         OnLoadActions012( ) ;
      }

      protected void OnLoadActions012( )
      {
      }

      protected void CheckExtendedTable012( )
      {
         Gx_BScreen = 1;
         standaloneModal012( ) ;
         Gx_BScreen = 0;
         new getnameinitials(context ).execute(  A16CustomerManagerGivenName,  A9CustomerManagerLastName, out  A17CustomerManagerInitials) ;
         n17CustomerManagerInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A17CustomerManagerInitials)) ? true : false);
         if ( ! ( GxRegex.IsMatch(A10CustomerManagerEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Customer Manager Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A12CustomerManagerGender, "Man") == 0 ) || ( StringUtil.StrCmp(A12CustomerManagerGender, "Woman") == 0 ) || ( StringUtil.StrCmp(A12CustomerManagerGender, "Other") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A12CustomerManagerGender)) ) )
         {
            GX_msglist.addItem("Field Customer Manager Gender is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors012( )
      {
      }

      protected void enableDisable012( )
      {
      }

      protected void GetKey012( )
      {
         /* Using cursor BC000134 */
         pr_default.execute(32, new Object[] {A1CustomerId, A15CustomerManagerId});
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(32);
      }

      protected void getByPrimaryKey012( )
      {
         /* Using cursor BC000117 */
         pr_default.execute(15, new Object[] {A1CustomerId, A15CustomerManagerId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            ZM012( 20) ;
            RcdFound2 = 1;
            InitializeNonKey012( ) ;
            A15CustomerManagerId = BC000117_A15CustomerManagerId[0];
            A13CustomerManagerGAMGUID = BC000117_A13CustomerManagerGAMGUID[0];
            A17CustomerManagerInitials = BC000117_A17CustomerManagerInitials[0];
            n17CustomerManagerInitials = BC000117_n17CustomerManagerInitials[0];
            A16CustomerManagerGivenName = BC000117_A16CustomerManagerGivenName[0];
            A9CustomerManagerLastName = BC000117_A9CustomerManagerLastName[0];
            A10CustomerManagerEmail = BC000117_A10CustomerManagerEmail[0];
            A11CustomerManagerPhone = BC000117_A11CustomerManagerPhone[0];
            n11CustomerManagerPhone = BC000117_n11CustomerManagerPhone[0];
            A12CustomerManagerGender = BC000117_A12CustomerManagerGender[0];
            n12CustomerManagerGender = BC000117_n12CustomerManagerGender[0];
            Z1CustomerId = A1CustomerId;
            Z15CustomerManagerId = A15CustomerManagerId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal012( ) ;
            Load012( ) ;
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey012( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal012( ) ;
            Gx_mode = sMode2;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes012( ) ;
         }
         pr_default.close(15);
      }

      protected void CheckOptimisticConcurrency012( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000116 */
            pr_default.execute(14, new Object[] {A1CustomerId, A15CustomerManagerId});
            if ( (pr_default.getStatus(14) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerManager"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(14) == 101) || ( StringUtil.StrCmp(Z13CustomerManagerGAMGUID, BC000116_A13CustomerManagerGAMGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z17CustomerManagerInitials, BC000116_A17CustomerManagerInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z16CustomerManagerGivenName, BC000116_A16CustomerManagerGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z9CustomerManagerLastName, BC000116_A9CustomerManagerLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z10CustomerManagerEmail, BC000116_A10CustomerManagerEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z11CustomerManagerPhone, BC000116_A11CustomerManagerPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z12CustomerManagerGender, BC000116_A12CustomerManagerGender[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerManager"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert012( )
      {
         BeforeValidate012( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable012( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM012( 0) ;
            CheckOptimisticConcurrency012( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm012( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert012( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000135 */
                     pr_default.execute(33, new Object[] {A1CustomerId, A15CustomerManagerId, A13CustomerManagerGAMGUID, n17CustomerManagerInitials, A17CustomerManagerInitials, A16CustomerManagerGivenName, A9CustomerManagerLastName, A10CustomerManagerEmail, n11CustomerManagerPhone, A11CustomerManagerPhone, n12CustomerManagerGender, A12CustomerManagerGender});
                     pr_default.close(33);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerManager");
                     if ( (pr_default.getStatus(33) == 1) )
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
               Load012( ) ;
            }
            EndLevel012( ) ;
         }
         CloseExtendedTableCursors012( ) ;
      }

      protected void Update012( )
      {
         BeforeValidate012( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable012( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency012( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm012( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate012( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000136 */
                     pr_default.execute(34, new Object[] {A13CustomerManagerGAMGUID, n17CustomerManagerInitials, A17CustomerManagerInitials, A16CustomerManagerGivenName, A9CustomerManagerLastName, A10CustomerManagerEmail, n11CustomerManagerPhone, A11CustomerManagerPhone, n12CustomerManagerGender, A12CustomerManagerGender, A1CustomerId, A15CustomerManagerId});
                     pr_default.close(34);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerManager");
                     if ( (pr_default.getStatus(34) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerManager"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate012( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey012( ) ;
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
            EndLevel012( ) ;
         }
         CloseExtendedTableCursors012( ) ;
      }

      protected void DeferredUpdate012( )
      {
      }

      protected void Delete012( )
      {
         Gx_mode = "DLT";
         BeforeValidate012( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency012( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls012( ) ;
            AfterConfirm012( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete012( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000137 */
                  pr_default.execute(35, new Object[] {A1CustomerId, A15CustomerManagerId});
                  pr_default.close(35);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerManager");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel012( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls012( )
      {
         standaloneModal012( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel012( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(14);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart012( )
      {
         /* Scan By routine */
         /* Using cursor BC000138 */
         pr_default.execute(36, new Object[] {A1CustomerId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound2 = 1;
            A15CustomerManagerId = BC000138_A15CustomerManagerId[0];
            A13CustomerManagerGAMGUID = BC000138_A13CustomerManagerGAMGUID[0];
            A17CustomerManagerInitials = BC000138_A17CustomerManagerInitials[0];
            n17CustomerManagerInitials = BC000138_n17CustomerManagerInitials[0];
            A16CustomerManagerGivenName = BC000138_A16CustomerManagerGivenName[0];
            A9CustomerManagerLastName = BC000138_A9CustomerManagerLastName[0];
            A10CustomerManagerEmail = BC000138_A10CustomerManagerEmail[0];
            A11CustomerManagerPhone = BC000138_A11CustomerManagerPhone[0];
            n11CustomerManagerPhone = BC000138_n11CustomerManagerPhone[0];
            A12CustomerManagerGender = BC000138_A12CustomerManagerGender[0];
            n12CustomerManagerGender = BC000138_n12CustomerManagerGender[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext012( )
      {
         /* Scan next routine */
         pr_default.readNext(36);
         RcdFound2 = 0;
         ScanKeyLoad012( ) ;
      }

      protected void ScanKeyLoad012( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound2 = 1;
            A15CustomerManagerId = BC000138_A15CustomerManagerId[0];
            A13CustomerManagerGAMGUID = BC000138_A13CustomerManagerGAMGUID[0];
            A17CustomerManagerInitials = BC000138_A17CustomerManagerInitials[0];
            n17CustomerManagerInitials = BC000138_n17CustomerManagerInitials[0];
            A16CustomerManagerGivenName = BC000138_A16CustomerManagerGivenName[0];
            A9CustomerManagerLastName = BC000138_A9CustomerManagerLastName[0];
            A10CustomerManagerEmail = BC000138_A10CustomerManagerEmail[0];
            A11CustomerManagerPhone = BC000138_A11CustomerManagerPhone[0];
            n11CustomerManagerPhone = BC000138_n11CustomerManagerPhone[0];
            A12CustomerManagerGender = BC000138_A12CustomerManagerGender[0];
            n12CustomerManagerGender = BC000138_n12CustomerManagerGender[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd012( )
      {
         pr_default.close(36);
      }

      protected void AfterConfirm012( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert012( )
      {
         /* Before Insert Rules */
         new createuseraccount(context ).execute(  A10CustomerManagerEmail,  A16CustomerManagerGivenName,  A9CustomerManagerLastName,  "Customer Manager", out  A13CustomerManagerGAMGUID) ;
      }

      protected void BeforeUpdate012( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete012( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete012( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate012( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes012( )
      {
      }

      protected void send_integrity_lvl_hashes012( )
      {
      }

      protected void ZM013( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            Z19CustomerLocationVisitingAddres = A19CustomerLocationVisitingAddres;
            Z20CustomerLocationPostalAddress = A20CustomerLocationPostalAddress;
            Z21CustomerLocationEmail = A21CustomerLocationEmail;
            Z22CustomerLocationPhone = A22CustomerLocationPhone;
            Z94CustomerLocationLastLine = A94CustomerLocationLastLine;
            Z133CustomerLocationDescription = A133CustomerLocationDescription;
            Z134CustomerLocationName = A134CustomerLocationName;
         }
         if ( GX_JID == -21 )
         {
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z19CustomerLocationVisitingAddres = A19CustomerLocationVisitingAddres;
            Z20CustomerLocationPostalAddress = A20CustomerLocationPostalAddress;
            Z21CustomerLocationEmail = A21CustomerLocationEmail;
            Z22CustomerLocationPhone = A22CustomerLocationPhone;
            Z94CustomerLocationLastLine = A94CustomerLocationLastLine;
            Z133CustomerLocationDescription = A133CustomerLocationDescription;
            Z134CustomerLocationName = A134CustomerLocationName;
         }
      }

      protected void standaloneNotModal013( )
      {
      }

      protected void standaloneModal013( )
      {
         if ( IsIns( )  )
         {
            A95CustomerLastLineLocation = (short)(O95CustomerLastLineLocation+1);
         }
         if ( IsIns( )  )
         {
            A18CustomerLocationId = A95CustomerLastLineLocation;
         }
      }

      protected void Load013( )
      {
         /* Using cursor BC000139 */
         pr_default.execute(37, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound3 = 1;
            A19CustomerLocationVisitingAddres = BC000139_A19CustomerLocationVisitingAddres[0];
            A20CustomerLocationPostalAddress = BC000139_A20CustomerLocationPostalAddress[0];
            A21CustomerLocationEmail = BC000139_A21CustomerLocationEmail[0];
            A22CustomerLocationPhone = BC000139_A22CustomerLocationPhone[0];
            A94CustomerLocationLastLine = BC000139_A94CustomerLocationLastLine[0];
            A133CustomerLocationDescription = BC000139_A133CustomerLocationDescription[0];
            A134CustomerLocationName = BC000139_A134CustomerLocationName[0];
            ZM013( -21) ;
         }
         pr_default.close(37);
         OnLoadActions013( ) ;
      }

      protected void OnLoadActions013( )
      {
      }

      protected void CheckExtendedTable013( )
      {
         Gx_BScreen = 1;
         standaloneModal013( ) ;
         Gx_BScreen = 0;
         if ( ! ( GxRegex.IsMatch(A21CustomerLocationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Customer Location Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors013( )
      {
      }

      protected void enableDisable013( )
      {
      }

      protected void GetKey013( )
      {
         /* Using cursor BC000140 */
         pr_default.execute(38, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(38);
      }

      protected void getByPrimaryKey013( )
      {
         /* Using cursor BC000115 */
         pr_default.execute(13, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            ZM013( 21) ;
            RcdFound3 = 1;
            InitializeNonKey013( ) ;
            A18CustomerLocationId = BC000115_A18CustomerLocationId[0];
            A19CustomerLocationVisitingAddres = BC000115_A19CustomerLocationVisitingAddres[0];
            A20CustomerLocationPostalAddress = BC000115_A20CustomerLocationPostalAddress[0];
            A21CustomerLocationEmail = BC000115_A21CustomerLocationEmail[0];
            A22CustomerLocationPhone = BC000115_A22CustomerLocationPhone[0];
            A94CustomerLocationLastLine = BC000115_A94CustomerLocationLastLine[0];
            A133CustomerLocationDescription = BC000115_A133CustomerLocationDescription[0];
            A134CustomerLocationName = BC000115_A134CustomerLocationName[0];
            O94CustomerLocationLastLine = A94CustomerLocationLastLine;
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal013( ) ;
            Load013( ) ;
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey013( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal013( ) ;
            Gx_mode = sMode3;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes013( ) ;
         }
         pr_default.close(13);
      }

      protected void CheckOptimisticConcurrency013( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000114 */
            pr_default.execute(12, new Object[] {A1CustomerId, A18CustomerLocationId});
            if ( (pr_default.getStatus(12) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocation"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(12) == 101) || ( StringUtil.StrCmp(Z19CustomerLocationVisitingAddres, BC000114_A19CustomerLocationVisitingAddres[0]) != 0 ) || ( StringUtil.StrCmp(Z20CustomerLocationPostalAddress, BC000114_A20CustomerLocationPostalAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z21CustomerLocationEmail, BC000114_A21CustomerLocationEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z22CustomerLocationPhone, BC000114_A22CustomerLocationPhone[0]) != 0 ) || ( Z94CustomerLocationLastLine != BC000114_A94CustomerLocationLastLine[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z133CustomerLocationDescription, BC000114_A133CustomerLocationDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z134CustomerLocationName, BC000114_A134CustomerLocationName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocation"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert013( )
      {
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM013( 0) ;
            CheckOptimisticConcurrency013( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm013( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert013( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000141 */
                     pr_default.execute(39, new Object[] {A1CustomerId, A18CustomerLocationId, A19CustomerLocationVisitingAddres, A20CustomerLocationPostalAddress, A21CustomerLocationEmail, A22CustomerLocationPhone, A94CustomerLocationLastLine, A133CustomerLocationDescription, A134CustomerLocationName});
                     pr_default.close(39);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocation");
                     if ( (pr_default.getStatus(39) == 1) )
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
                           ProcessLevel013( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
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
               Load013( ) ;
            }
            EndLevel013( ) ;
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void Update013( )
      {
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency013( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm013( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate013( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000142 */
                     pr_default.execute(40, new Object[] {A19CustomerLocationVisitingAddres, A20CustomerLocationPostalAddress, A21CustomerLocationEmail, A22CustomerLocationPhone, A94CustomerLocationLastLine, A133CustomerLocationDescription, A134CustomerLocationName, A1CustomerId, A18CustomerLocationId});
                     pr_default.close(40);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocation");
                     if ( (pr_default.getStatus(40) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocation"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate013( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel013( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey013( ) ;
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
            EndLevel013( ) ;
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void DeferredUpdate013( )
      {
      }

      protected void Delete013( )
      {
         Gx_mode = "DLT";
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency013( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls013( ) ;
            AfterConfirm013( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete013( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0121( ) ;
                  while ( RcdFound21 != 0 )
                  {
                     getByPrimaryKey0121( ) ;
                     Delete0121( ) ;
                     ScanKeyNext0121( ) ;
                  }
                  ScanKeyEnd0121( ) ;
                  ScanKeyStart0117( ) ;
                  while ( RcdFound17 != 0 )
                  {
                     getByPrimaryKey0117( ) ;
                     Delete0117( ) ;
                     ScanKeyNext0117( ) ;
                  }
                  ScanKeyEnd0117( ) ;
                  ScanKeyStart0116( ) ;
                  while ( RcdFound16 != 0 )
                  {
                     getByPrimaryKey0116( ) ;
                     Delete0116( ) ;
                     ScanKeyNext0116( ) ;
                  }
                  ScanKeyEnd0116( ) ;
                  A94CustomerLocationLastLine = O94CustomerLocationLastLine;
                  ScanKeyStart014( ) ;
                  while ( RcdFound4 != 0 )
                  {
                     getByPrimaryKey014( ) ;
                     Delete014( ) ;
                     ScanKeyNext014( ) ;
                     O94CustomerLocationLastLine = A94CustomerLocationLastLine;
                  }
                  ScanKeyEnd014( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000143 */
                     pr_default.execute(41, new Object[] {A1CustomerId, A18CustomerLocationId});
                     pr_default.close(41);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocation");
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
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel013( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls013( )
      {
         standaloneModal013( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000144 */
            pr_default.execute(42, new Object[] {A1CustomerId, A18CustomerLocationId});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"LocationEvent"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor BC000145 */
            pr_default.execute(43, new Object[] {A1CustomerId, A18CustomerLocationId});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Resident"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
         }
      }

      protected void ProcessNestedLevel014( )
      {
         s94CustomerLocationLastLine = O94CustomerLocationLastLine;
         nGXsfl_4_idx = 0;
         while ( nGXsfl_4_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.Count )
         {
            ReadRow014( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound4 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_4 != 0 ) )
            {
               standaloneNotModal014( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert014( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete014( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update014( ) ;
                  }
               }
               O94CustomerLocationLastLine = A94CustomerLocationLastLine;
            }
            KeyVarsToRow4( ((SdtCustomer_Locations_Receptionist)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.Item(nGXsfl_4_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_4_idx = 0;
            while ( nGXsfl_4_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.Count )
            {
               ReadRow014( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound4 == 0 )
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
                  ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.RemoveElement(nGXsfl_4_idx);
                  nGXsfl_4_idx = (int)(nGXsfl_4_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey014( ) ;
                  VarsToRow4( ((SdtCustomer_Locations_Receptionist)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.Item(nGXsfl_4_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll014( ) ;
         if ( AnyError != 0 )
         {
            O94CustomerLocationLastLine = s94CustomerLocationLastLine;
         }
         nRcdExists_4 = 0;
         nIsMod_4 = 0;
      }

      protected void ProcessNestedLevel0116( )
      {
         nGXsfl_16_idx = 0;
         while ( nGXsfl_16_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.Count )
         {
            ReadRow0116( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound16 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_16 != 0 ) )
            {
               standaloneNotModal0116( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0116( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0116( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0116( ) ;
                  }
               }
            }
            KeyVarsToRow16( ((SdtCustomer_Locations_Supplier_Agb)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.Item(nGXsfl_16_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_16_idx = 0;
            while ( nGXsfl_16_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.Count )
            {
               ReadRow0116( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound16 == 0 )
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
                  ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.RemoveElement(nGXsfl_16_idx);
                  nGXsfl_16_idx = (int)(nGXsfl_16_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0116( ) ;
                  VarsToRow16( ((SdtCustomer_Locations_Supplier_Agb)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.Item(nGXsfl_16_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0116( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_16 = 0;
         nIsMod_16 = 0;
      }

      protected void ProcessNestedLevel0117( )
      {
         nGXsfl_17_idx = 0;
         while ( nGXsfl_17_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.Count )
         {
            ReadRow0117( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound17 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_17 != 0 ) )
            {
               standaloneNotModal0117( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0117( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0117( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0117( ) ;
                  }
               }
            }
            KeyVarsToRow17( ((SdtCustomer_Locations_Supplier_Gen)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.Item(nGXsfl_17_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_17_idx = 0;
            while ( nGXsfl_17_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.Count )
            {
               ReadRow0117( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound17 == 0 )
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
                  ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.RemoveElement(nGXsfl_17_idx);
                  nGXsfl_17_idx = (int)(nGXsfl_17_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0117( ) ;
                  VarsToRow17( ((SdtCustomer_Locations_Supplier_Gen)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.Item(nGXsfl_17_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0117( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_17 = 0;
         nIsMod_17 = 0;
      }

      protected void ProcessNestedLevel0121( )
      {
         nGXsfl_21_idx = 0;
         while ( nGXsfl_21_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.Count )
         {
            ReadRow0121( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound21 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_21 != 0 ) )
            {
               standaloneNotModal0121( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0121( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0121( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0121( ) ;
                  }
               }
            }
            KeyVarsToRow21( ((SdtCustomer_Locations_Amenities)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.Item(nGXsfl_21_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_21_idx = 0;
            while ( nGXsfl_21_idx < ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.Count )
            {
               ReadRow0121( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound21 == 0 )
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
                  ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.RemoveElement(nGXsfl_21_idx);
                  nGXsfl_21_idx = (int)(nGXsfl_21_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0121( ) ;
                  VarsToRow21( ((SdtCustomer_Locations_Amenities)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.Item(nGXsfl_21_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0121( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_21 = 0;
         nIsMod_21 = 0;
      }

      protected void ProcessLevel013( )
      {
         /* Save parent mode. */
         sMode3 = Gx_mode;
         ProcessNestedLevel014( ) ;
         ProcessNestedLevel0116( ) ;
         ProcessNestedLevel0117( ) ;
         ProcessNestedLevel0121( ) ;
         if ( AnyError != 0 )
         {
            O94CustomerLocationLastLine = s94CustomerLocationLastLine;
         }
         /* Restore parent mode. */
         Gx_mode = sMode3;
         /* ' Update level parameters */
         /* Using cursor BC000146 */
         pr_default.execute(44, new Object[] {A94CustomerLocationLastLine, A1CustomerId, A18CustomerLocationId});
         pr_default.close(44);
         pr_default.SmartCacheProvider.SetUpdated("CustomerLocation");
      }

      protected void EndLevel013( )
      {
         pr_default.close(12);
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart013( )
      {
         /* Scan By routine */
         /* Using cursor BC000147 */
         pr_default.execute(45, new Object[] {A1CustomerId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound3 = 1;
            A18CustomerLocationId = BC000147_A18CustomerLocationId[0];
            A19CustomerLocationVisitingAddres = BC000147_A19CustomerLocationVisitingAddres[0];
            A20CustomerLocationPostalAddress = BC000147_A20CustomerLocationPostalAddress[0];
            A21CustomerLocationEmail = BC000147_A21CustomerLocationEmail[0];
            A22CustomerLocationPhone = BC000147_A22CustomerLocationPhone[0];
            A94CustomerLocationLastLine = BC000147_A94CustomerLocationLastLine[0];
            A133CustomerLocationDescription = BC000147_A133CustomerLocationDescription[0];
            A134CustomerLocationName = BC000147_A134CustomerLocationName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext013( )
      {
         /* Scan next routine */
         pr_default.readNext(45);
         RcdFound3 = 0;
         ScanKeyLoad013( ) ;
      }

      protected void ScanKeyLoad013( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound3 = 1;
            A18CustomerLocationId = BC000147_A18CustomerLocationId[0];
            A19CustomerLocationVisitingAddres = BC000147_A19CustomerLocationVisitingAddres[0];
            A20CustomerLocationPostalAddress = BC000147_A20CustomerLocationPostalAddress[0];
            A21CustomerLocationEmail = BC000147_A21CustomerLocationEmail[0];
            A22CustomerLocationPhone = BC000147_A22CustomerLocationPhone[0];
            A94CustomerLocationLastLine = BC000147_A94CustomerLocationLastLine[0];
            A133CustomerLocationDescription = BC000147_A133CustomerLocationDescription[0];
            A134CustomerLocationName = BC000147_A134CustomerLocationName[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd013( )
      {
         pr_default.close(45);
      }

      protected void AfterConfirm013( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert013( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate013( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete013( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete013( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate013( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes013( )
      {
      }

      protected void ZM014( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z30CustomerLocationReceptionistGA = A30CustomerLocationReceptionistGA;
            Z26CustomerLocationReceptionistIn = A26CustomerLocationReceptionistIn;
            Z24CustomerLocationReceptionistGi = A24CustomerLocationReceptionistGi;
            Z25CustomerLocationReceptionistLa = A25CustomerLocationReceptionistLa;
            Z27CustomerLocationReceptionistEm = A27CustomerLocationReceptionistEm;
            Z28CustomerLocationReceptionistAd = A28CustomerLocationReceptionistAd;
            Z29CustomerLocationReceptionistPh = A29CustomerLocationReceptionistPh;
         }
         if ( GX_JID == -22 )
         {
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z23CustomerLocationReceptionistId = A23CustomerLocationReceptionistId;
            Z30CustomerLocationReceptionistGA = A30CustomerLocationReceptionistGA;
            Z26CustomerLocationReceptionistIn = A26CustomerLocationReceptionistIn;
            Z24CustomerLocationReceptionistGi = A24CustomerLocationReceptionistGi;
            Z25CustomerLocationReceptionistLa = A25CustomerLocationReceptionistLa;
            Z27CustomerLocationReceptionistEm = A27CustomerLocationReceptionistEm;
            Z28CustomerLocationReceptionistAd = A28CustomerLocationReceptionistAd;
            Z29CustomerLocationReceptionistPh = A29CustomerLocationReceptionistPh;
         }
      }

      protected void standaloneNotModal014( )
      {
      }

      protected void standaloneModal014( )
      {
         if ( IsIns( )  )
         {
            A94CustomerLocationLastLine = (short)(O94CustomerLocationLastLine+1);
         }
         if ( IsIns( )  )
         {
            A23CustomerLocationReceptionistId = A94CustomerLocationLastLine;
         }
      }

      protected void Load014( )
      {
         /* Using cursor BC000148 */
         pr_default.execute(46, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound4 = 1;
            A30CustomerLocationReceptionistGA = BC000148_A30CustomerLocationReceptionistGA[0];
            A26CustomerLocationReceptionistIn = BC000148_A26CustomerLocationReceptionistIn[0];
            n26CustomerLocationReceptionistIn = BC000148_n26CustomerLocationReceptionistIn[0];
            A24CustomerLocationReceptionistGi = BC000148_A24CustomerLocationReceptionistGi[0];
            A25CustomerLocationReceptionistLa = BC000148_A25CustomerLocationReceptionistLa[0];
            A27CustomerLocationReceptionistEm = BC000148_A27CustomerLocationReceptionistEm[0];
            A28CustomerLocationReceptionistAd = BC000148_A28CustomerLocationReceptionistAd[0];
            n28CustomerLocationReceptionistAd = BC000148_n28CustomerLocationReceptionistAd[0];
            A29CustomerLocationReceptionistPh = BC000148_A29CustomerLocationReceptionistPh[0];
            ZM014( -22) ;
         }
         pr_default.close(46);
         OnLoadActions014( ) ;
      }

      protected void OnLoadActions014( )
      {
      }

      protected void CheckExtendedTable014( )
      {
         Gx_BScreen = 1;
         standaloneModal014( ) ;
         Gx_BScreen = 0;
         new getnameinitials(context ).execute(  A24CustomerLocationReceptionistGi,  A25CustomerLocationReceptionistLa, out  A26CustomerLocationReceptionistIn) ;
         n26CustomerLocationReceptionistIn = (String.IsNullOrEmpty(StringUtil.RTrim( A26CustomerLocationReceptionistIn)) ? true : false);
         if ( ! ( GxRegex.IsMatch(A27CustomerLocationReceptionistEm,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Customer Location Receptionist Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors014( )
      {
      }

      protected void enableDisable014( )
      {
      }

      protected void GetKey014( )
      {
         /* Using cursor BC000149 */
         pr_default.execute(47, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
         if ( (pr_default.getStatus(47) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(47);
      }

      protected void getByPrimaryKey014( )
      {
         /* Using cursor BC000113 */
         pr_default.execute(11, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            ZM014( 22) ;
            RcdFound4 = 1;
            InitializeNonKey014( ) ;
            A23CustomerLocationReceptionistId = BC000113_A23CustomerLocationReceptionistId[0];
            A30CustomerLocationReceptionistGA = BC000113_A30CustomerLocationReceptionistGA[0];
            A26CustomerLocationReceptionistIn = BC000113_A26CustomerLocationReceptionistIn[0];
            n26CustomerLocationReceptionistIn = BC000113_n26CustomerLocationReceptionistIn[0];
            A24CustomerLocationReceptionistGi = BC000113_A24CustomerLocationReceptionistGi[0];
            A25CustomerLocationReceptionistLa = BC000113_A25CustomerLocationReceptionistLa[0];
            A27CustomerLocationReceptionistEm = BC000113_A27CustomerLocationReceptionistEm[0];
            A28CustomerLocationReceptionistAd = BC000113_A28CustomerLocationReceptionistAd[0];
            n28CustomerLocationReceptionistAd = BC000113_n28CustomerLocationReceptionistAd[0];
            A29CustomerLocationReceptionistPh = BC000113_A29CustomerLocationReceptionistPh[0];
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z23CustomerLocationReceptionistId = A23CustomerLocationReceptionistId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal014( ) ;
            Load014( ) ;
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey014( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal014( ) ;
            Gx_mode = sMode4;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes014( ) ;
         }
         pr_default.close(11);
      }

      protected void CheckOptimisticConcurrency014( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
            if ( (pr_default.getStatus(10) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationReceptionist"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(10) == 101) || ( StringUtil.StrCmp(Z30CustomerLocationReceptionistGA, BC000112_A30CustomerLocationReceptionistGA[0]) != 0 ) || ( StringUtil.StrCmp(Z26CustomerLocationReceptionistIn, BC000112_A26CustomerLocationReceptionistIn[0]) != 0 ) || ( StringUtil.StrCmp(Z24CustomerLocationReceptionistGi, BC000112_A24CustomerLocationReceptionistGi[0]) != 0 ) || ( StringUtil.StrCmp(Z25CustomerLocationReceptionistLa, BC000112_A25CustomerLocationReceptionistLa[0]) != 0 ) || ( StringUtil.StrCmp(Z27CustomerLocationReceptionistEm, BC000112_A27CustomerLocationReceptionistEm[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z28CustomerLocationReceptionistAd, BC000112_A28CustomerLocationReceptionistAd[0]) != 0 ) || ( StringUtil.StrCmp(Z29CustomerLocationReceptionistPh, BC000112_A29CustomerLocationReceptionistPh[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocationReceptionist"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert014( )
      {
         BeforeValidate014( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable014( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM014( 0) ;
            CheckOptimisticConcurrency014( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm014( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert014( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000150 */
                     pr_default.execute(48, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId, A30CustomerLocationReceptionistGA, n26CustomerLocationReceptionistIn, A26CustomerLocationReceptionistIn, A24CustomerLocationReceptionistGi, A25CustomerLocationReceptionistLa, A27CustomerLocationReceptionistEm, n28CustomerLocationReceptionistAd, A28CustomerLocationReceptionistAd, A29CustomerLocationReceptionistPh});
                     pr_default.close(48);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocationReceptionist");
                     if ( (pr_default.getStatus(48) == 1) )
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
               Load014( ) ;
            }
            EndLevel014( ) ;
         }
         CloseExtendedTableCursors014( ) ;
      }

      protected void Update014( )
      {
         BeforeValidate014( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable014( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency014( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm014( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate014( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000151 */
                     pr_default.execute(49, new Object[] {A30CustomerLocationReceptionistGA, n26CustomerLocationReceptionistIn, A26CustomerLocationReceptionistIn, A24CustomerLocationReceptionistGi, A25CustomerLocationReceptionistLa, A27CustomerLocationReceptionistEm, n28CustomerLocationReceptionistAd, A28CustomerLocationReceptionistAd, A29CustomerLocationReceptionistPh, A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
                     pr_default.close(49);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocationReceptionist");
                     if ( (pr_default.getStatus(49) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationReceptionist"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate014( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey014( ) ;
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
            EndLevel014( ) ;
         }
         CloseExtendedTableCursors014( ) ;
      }

      protected void DeferredUpdate014( )
      {
      }

      protected void Delete014( )
      {
         Gx_mode = "DLT";
         BeforeValidate014( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency014( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls014( ) ;
            AfterConfirm014( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete014( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000152 */
                  pr_default.execute(50, new Object[] {A1CustomerId, A18CustomerLocationId, A23CustomerLocationReceptionistId});
                  pr_default.close(50);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerLocationReceptionist");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel014( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls014( )
      {
         standaloneModal014( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel014( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(10);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart014( )
      {
         /* Scan By routine */
         /* Using cursor BC000153 */
         pr_default.execute(51, new Object[] {A1CustomerId, A18CustomerLocationId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(51) != 101) )
         {
            RcdFound4 = 1;
            A23CustomerLocationReceptionistId = BC000153_A23CustomerLocationReceptionistId[0];
            A30CustomerLocationReceptionistGA = BC000153_A30CustomerLocationReceptionistGA[0];
            A26CustomerLocationReceptionistIn = BC000153_A26CustomerLocationReceptionistIn[0];
            n26CustomerLocationReceptionistIn = BC000153_n26CustomerLocationReceptionistIn[0];
            A24CustomerLocationReceptionistGi = BC000153_A24CustomerLocationReceptionistGi[0];
            A25CustomerLocationReceptionistLa = BC000153_A25CustomerLocationReceptionistLa[0];
            A27CustomerLocationReceptionistEm = BC000153_A27CustomerLocationReceptionistEm[0];
            A28CustomerLocationReceptionistAd = BC000153_A28CustomerLocationReceptionistAd[0];
            n28CustomerLocationReceptionistAd = BC000153_n28CustomerLocationReceptionistAd[0];
            A29CustomerLocationReceptionistPh = BC000153_A29CustomerLocationReceptionistPh[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext014( )
      {
         /* Scan next routine */
         pr_default.readNext(51);
         RcdFound4 = 0;
         ScanKeyLoad014( ) ;
      }

      protected void ScanKeyLoad014( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(51) != 101) )
         {
            RcdFound4 = 1;
            A23CustomerLocationReceptionistId = BC000153_A23CustomerLocationReceptionistId[0];
            A30CustomerLocationReceptionistGA = BC000153_A30CustomerLocationReceptionistGA[0];
            A26CustomerLocationReceptionistIn = BC000153_A26CustomerLocationReceptionistIn[0];
            n26CustomerLocationReceptionistIn = BC000153_n26CustomerLocationReceptionistIn[0];
            A24CustomerLocationReceptionistGi = BC000153_A24CustomerLocationReceptionistGi[0];
            A25CustomerLocationReceptionistLa = BC000153_A25CustomerLocationReceptionistLa[0];
            A27CustomerLocationReceptionistEm = BC000153_A27CustomerLocationReceptionistEm[0];
            A28CustomerLocationReceptionistAd = BC000153_A28CustomerLocationReceptionistAd[0];
            n28CustomerLocationReceptionistAd = BC000153_n28CustomerLocationReceptionistAd[0];
            A29CustomerLocationReceptionistPh = BC000153_A29CustomerLocationReceptionistPh[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd014( )
      {
         pr_default.close(51);
      }

      protected void AfterConfirm014( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert014( )
      {
         /* Before Insert Rules */
         new createuseraccount(context ).execute(  A27CustomerLocationReceptionistEm,  A24CustomerLocationReceptionistGi,  A25CustomerLocationReceptionistLa,  "Receptionist", out  A30CustomerLocationReceptionistGA) ;
      }

      protected void BeforeUpdate014( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete014( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete014( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate014( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes014( )
      {
      }

      protected void send_integrity_lvl_hashes014( )
      {
      }

      protected void ZM0116( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
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
         if ( GX_JID == -23 )
         {
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
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

      protected void standaloneNotModal0116( )
      {
      }

      protected void standaloneModal0116( )
      {
      }

      protected void Load0116( )
      {
         /* Using cursor BC000154 */
         pr_default.execute(52, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
         if ( (pr_default.getStatus(52) != 101) )
         {
            RcdFound16 = 1;
            A56Supplier_AgbNumber = BC000154_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = BC000154_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = BC000154_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = BC000154_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = BC000154_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = BC000154_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = BC000154_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = BC000154_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = BC000154_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = BC000154_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = BC000154_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = BC000154_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = BC000154_n63Supplier_AgbContactName[0];
            ZM0116( -23) ;
         }
         pr_default.close(52);
         OnLoadActions0116( ) ;
      }

      protected void OnLoadActions0116( )
      {
      }

      protected void CheckExtendedTable0116( )
      {
         Gx_BScreen = 1;
         standaloneModal0116( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000111 */
         pr_default.execute(9, new Object[] {A55Supplier_AgbId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier_AGB'.", "ForeignKeyNotFound", 1, "SUPPLIER_AGBID");
            AnyError = 1;
         }
         A56Supplier_AgbNumber = BC000111_A56Supplier_AgbNumber[0];
         A57Supplier_AgbName = BC000111_A57Supplier_AgbName[0];
         A58Supplier_AgbKvkNumber = BC000111_A58Supplier_AgbKvkNumber[0];
         A59Supplier_AgbVisitingAddress = BC000111_A59Supplier_AgbVisitingAddress[0];
         n59Supplier_AgbVisitingAddress = BC000111_n59Supplier_AgbVisitingAddress[0];
         A60Supplier_AgbPostalAddress = BC000111_A60Supplier_AgbPostalAddress[0];
         n60Supplier_AgbPostalAddress = BC000111_n60Supplier_AgbPostalAddress[0];
         A61Supplier_AgbEmail = BC000111_A61Supplier_AgbEmail[0];
         n61Supplier_AgbEmail = BC000111_n61Supplier_AgbEmail[0];
         A62Supplier_AgbPhone = BC000111_A62Supplier_AgbPhone[0];
         n62Supplier_AgbPhone = BC000111_n62Supplier_AgbPhone[0];
         A63Supplier_AgbContactName = BC000111_A63Supplier_AgbContactName[0];
         n63Supplier_AgbContactName = BC000111_n63Supplier_AgbContactName[0];
         pr_default.close(9);
      }

      protected void CloseExtendedTableCursors0116( )
      {
         pr_default.close(9);
      }

      protected void enableDisable0116( )
      {
      }

      protected void GetKey0116( )
      {
         /* Using cursor BC000155 */
         pr_default.execute(53, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
         if ( (pr_default.getStatus(53) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(53);
      }

      protected void getByPrimaryKey0116( )
      {
         /* Using cursor BC000110 */
         pr_default.execute(8, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            ZM0116( 23) ;
            RcdFound16 = 1;
            InitializeNonKey0116( ) ;
            A55Supplier_AgbId = BC000110_A55Supplier_AgbId[0];
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z55Supplier_AgbId = A55Supplier_AgbId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0116( ) ;
            Load0116( ) ;
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0116( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0116( ) ;
            Gx_mode = sMode16;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0116( ) ;
         }
         pr_default.close(8);
      }

      protected void CheckOptimisticConcurrency0116( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00019 */
            pr_default.execute(7, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
            if ( (pr_default.getStatus(7) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationSupplier_Agb"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(7) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocationSupplier_Agb"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0116( )
      {
         BeforeValidate0116( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0116( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0116( 0) ;
            CheckOptimisticConcurrency0116( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0116( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0116( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000156 */
                     pr_default.execute(54, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
                     pr_default.close(54);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocationSupplier_Agb");
                     if ( (pr_default.getStatus(54) == 1) )
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
               Load0116( ) ;
            }
            EndLevel0116( ) ;
         }
         CloseExtendedTableCursors0116( ) ;
      }

      protected void Update0116( )
      {
         BeforeValidate0116( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0116( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0116( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0116( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0116( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table CustomerLocationSupplier_Agb */
                     DeferredUpdate0116( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0116( ) ;
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
            EndLevel0116( ) ;
         }
         CloseExtendedTableCursors0116( ) ;
      }

      protected void DeferredUpdate0116( )
      {
      }

      protected void Delete0116( )
      {
         Gx_mode = "DLT";
         BeforeValidate0116( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0116( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0116( ) ;
            AfterConfirm0116( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0116( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000157 */
                  pr_default.execute(55, new Object[] {A1CustomerId, A18CustomerLocationId, A55Supplier_AgbId});
                  pr_default.close(55);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerLocationSupplier_Agb");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0116( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0116( )
      {
         standaloneModal0116( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000158 */
            pr_default.execute(56, new Object[] {A55Supplier_AgbId});
            A56Supplier_AgbNumber = BC000158_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = BC000158_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = BC000158_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = BC000158_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = BC000158_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = BC000158_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = BC000158_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = BC000158_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = BC000158_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = BC000158_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = BC000158_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = BC000158_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = BC000158_n63Supplier_AgbContactName[0];
            pr_default.close(56);
         }
      }

      protected void EndLevel0116( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(7);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0116( )
      {
         /* Scan By routine */
         /* Using cursor BC000159 */
         pr_default.execute(57, new Object[] {A1CustomerId, A18CustomerLocationId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(57) != 101) )
         {
            RcdFound16 = 1;
            A56Supplier_AgbNumber = BC000159_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = BC000159_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = BC000159_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = BC000159_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = BC000159_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = BC000159_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = BC000159_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = BC000159_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = BC000159_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = BC000159_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = BC000159_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = BC000159_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = BC000159_n63Supplier_AgbContactName[0];
            A55Supplier_AgbId = BC000159_A55Supplier_AgbId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0116( )
      {
         /* Scan next routine */
         pr_default.readNext(57);
         RcdFound16 = 0;
         ScanKeyLoad0116( ) ;
      }

      protected void ScanKeyLoad0116( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(57) != 101) )
         {
            RcdFound16 = 1;
            A56Supplier_AgbNumber = BC000159_A56Supplier_AgbNumber[0];
            A57Supplier_AgbName = BC000159_A57Supplier_AgbName[0];
            A58Supplier_AgbKvkNumber = BC000159_A58Supplier_AgbKvkNumber[0];
            A59Supplier_AgbVisitingAddress = BC000159_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = BC000159_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = BC000159_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = BC000159_n60Supplier_AgbPostalAddress[0];
            A61Supplier_AgbEmail = BC000159_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = BC000159_n61Supplier_AgbEmail[0];
            A62Supplier_AgbPhone = BC000159_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = BC000159_n62Supplier_AgbPhone[0];
            A63Supplier_AgbContactName = BC000159_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = BC000159_n63Supplier_AgbContactName[0];
            A55Supplier_AgbId = BC000159_A55Supplier_AgbId[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0116( )
      {
         pr_default.close(57);
      }

      protected void AfterConfirm0116( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0116( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0116( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0116( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0116( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0116( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0116( )
      {
      }

      protected void send_integrity_lvl_hashes0116( )
      {
      }

      protected void ZM0117( short GX_JID )
      {
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
            Z65Supplier_GenKvKNumber = A65Supplier_GenKvKNumber;
            Z66Supplier_GenCompanyName = A66Supplier_GenCompanyName;
            Z67Supplier_GenVisitingAddress = A67Supplier_GenVisitingAddress;
            Z68Supplier_GenPostalAddress = A68Supplier_GenPostalAddress;
            Z69Supplier_GenContactName = A69Supplier_GenContactName;
            Z70Supplier_GenContactPhone = A70Supplier_GenContactPhone;
         }
         if ( GX_JID == -25 )
         {
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z64Supplier_GenId = A64Supplier_GenId;
            Z65Supplier_GenKvKNumber = A65Supplier_GenKvKNumber;
            Z66Supplier_GenCompanyName = A66Supplier_GenCompanyName;
            Z67Supplier_GenVisitingAddress = A67Supplier_GenVisitingAddress;
            Z68Supplier_GenPostalAddress = A68Supplier_GenPostalAddress;
            Z69Supplier_GenContactName = A69Supplier_GenContactName;
            Z70Supplier_GenContactPhone = A70Supplier_GenContactPhone;
         }
      }

      protected void standaloneNotModal0117( )
      {
      }

      protected void standaloneModal0117( )
      {
      }

      protected void Load0117( )
      {
         /* Using cursor BC000160 */
         pr_default.execute(58, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
         if ( (pr_default.getStatus(58) != 101) )
         {
            RcdFound17 = 1;
            A65Supplier_GenKvKNumber = BC000160_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = BC000160_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = BC000160_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = BC000160_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = BC000160_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = BC000160_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = BC000160_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = BC000160_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = BC000160_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = BC000160_n70Supplier_GenContactPhone[0];
            ZM0117( -25) ;
         }
         pr_default.close(58);
         OnLoadActions0117( ) ;
      }

      protected void OnLoadActions0117( )
      {
      }

      protected void CheckExtendedTable0117( )
      {
         Gx_BScreen = 1;
         standaloneModal0117( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00018 */
         pr_default.execute(6, new Object[] {A64Supplier_GenId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier_Gen'.", "ForeignKeyNotFound", 1, "SUPPLIER_GENID");
            AnyError = 1;
         }
         A65Supplier_GenKvKNumber = BC00018_A65Supplier_GenKvKNumber[0];
         A66Supplier_GenCompanyName = BC00018_A66Supplier_GenCompanyName[0];
         A67Supplier_GenVisitingAddress = BC00018_A67Supplier_GenVisitingAddress[0];
         n67Supplier_GenVisitingAddress = BC00018_n67Supplier_GenVisitingAddress[0];
         A68Supplier_GenPostalAddress = BC00018_A68Supplier_GenPostalAddress[0];
         n68Supplier_GenPostalAddress = BC00018_n68Supplier_GenPostalAddress[0];
         A69Supplier_GenContactName = BC00018_A69Supplier_GenContactName[0];
         n69Supplier_GenContactName = BC00018_n69Supplier_GenContactName[0];
         A70Supplier_GenContactPhone = BC00018_A70Supplier_GenContactPhone[0];
         n70Supplier_GenContactPhone = BC00018_n70Supplier_GenContactPhone[0];
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors0117( )
      {
         pr_default.close(6);
      }

      protected void enableDisable0117( )
      {
      }

      protected void GetKey0117( )
      {
         /* Using cursor BC000161 */
         pr_default.execute(59, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
         if ( (pr_default.getStatus(59) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(59);
      }

      protected void getByPrimaryKey0117( )
      {
         /* Using cursor BC00017 */
         pr_default.execute(5, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0117( 25) ;
            RcdFound17 = 1;
            InitializeNonKey0117( ) ;
            A64Supplier_GenId = BC00017_A64Supplier_GenId[0];
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z64Supplier_GenId = A64Supplier_GenId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0117( ) ;
            Load0117( ) ;
            Gx_mode = sMode17;
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0117( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0117( ) ;
            Gx_mode = sMode17;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0117( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency0117( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00016 */
            pr_default.execute(4, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationSupplier_Gen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocationSupplier_Gen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0117( )
      {
         BeforeValidate0117( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0117( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0117( 0) ;
            CheckOptimisticConcurrency0117( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0117( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0117( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000162 */
                     pr_default.execute(60, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
                     pr_default.close(60);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocationSupplier_Gen");
                     if ( (pr_default.getStatus(60) == 1) )
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
               Load0117( ) ;
            }
            EndLevel0117( ) ;
         }
         CloseExtendedTableCursors0117( ) ;
      }

      protected void Update0117( )
      {
         BeforeValidate0117( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0117( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0117( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0117( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0117( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table CustomerLocationSupplier_Gen */
                     DeferredUpdate0117( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0117( ) ;
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
            EndLevel0117( ) ;
         }
         CloseExtendedTableCursors0117( ) ;
      }

      protected void DeferredUpdate0117( )
      {
      }

      protected void Delete0117( )
      {
         Gx_mode = "DLT";
         BeforeValidate0117( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0117( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0117( ) ;
            AfterConfirm0117( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0117( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000163 */
                  pr_default.execute(61, new Object[] {A1CustomerId, A18CustomerLocationId, A64Supplier_GenId});
                  pr_default.close(61);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerLocationSupplier_Gen");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0117( ) ;
         Gx_mode = sMode17;
      }

      protected void OnDeleteControls0117( )
      {
         standaloneModal0117( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000164 */
            pr_default.execute(62, new Object[] {A64Supplier_GenId});
            A65Supplier_GenKvKNumber = BC000164_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = BC000164_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = BC000164_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = BC000164_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = BC000164_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = BC000164_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = BC000164_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = BC000164_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = BC000164_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = BC000164_n70Supplier_GenContactPhone[0];
            pr_default.close(62);
         }
      }

      protected void EndLevel0117( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0117( )
      {
         /* Scan By routine */
         /* Using cursor BC000165 */
         pr_default.execute(63, new Object[] {A1CustomerId, A18CustomerLocationId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(63) != 101) )
         {
            RcdFound17 = 1;
            A65Supplier_GenKvKNumber = BC000165_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = BC000165_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = BC000165_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = BC000165_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = BC000165_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = BC000165_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = BC000165_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = BC000165_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = BC000165_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = BC000165_n70Supplier_GenContactPhone[0];
            A64Supplier_GenId = BC000165_A64Supplier_GenId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0117( )
      {
         /* Scan next routine */
         pr_default.readNext(63);
         RcdFound17 = 0;
         ScanKeyLoad0117( ) ;
      }

      protected void ScanKeyLoad0117( )
      {
         sMode17 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(63) != 101) )
         {
            RcdFound17 = 1;
            A65Supplier_GenKvKNumber = BC000165_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = BC000165_A66Supplier_GenCompanyName[0];
            A67Supplier_GenVisitingAddress = BC000165_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = BC000165_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = BC000165_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = BC000165_n68Supplier_GenPostalAddress[0];
            A69Supplier_GenContactName = BC000165_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = BC000165_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = BC000165_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = BC000165_n70Supplier_GenContactPhone[0];
            A64Supplier_GenId = BC000165_A64Supplier_GenId[0];
         }
         Gx_mode = sMode17;
      }

      protected void ScanKeyEnd0117( )
      {
         pr_default.close(63);
      }

      protected void AfterConfirm0117( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0117( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0117( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0117( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0117( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0117( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0117( )
      {
      }

      protected void send_integrity_lvl_hashes0117( )
      {
      }

      protected void ZM0121( short GX_JID )
      {
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            Z101AmenitiesName = A101AmenitiesName;
            Z99AmenitiesTypeId = A99AmenitiesTypeId;
         }
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            Z100AmenitiesTypeName = A100AmenitiesTypeName;
         }
         if ( GX_JID == -27 )
         {
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z98AmenitiesId = A98AmenitiesId;
            Z101AmenitiesName = A101AmenitiesName;
            Z99AmenitiesTypeId = A99AmenitiesTypeId;
            Z100AmenitiesTypeName = A100AmenitiesTypeName;
         }
      }

      protected void standaloneNotModal0121( )
      {
      }

      protected void standaloneModal0121( )
      {
      }

      protected void Load0121( )
      {
         /* Using cursor BC000166 */
         pr_default.execute(64, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
         if ( (pr_default.getStatus(64) != 101) )
         {
            RcdFound21 = 1;
            A101AmenitiesName = BC000166_A101AmenitiesName[0];
            A100AmenitiesTypeName = BC000166_A100AmenitiesTypeName[0];
            A99AmenitiesTypeId = BC000166_A99AmenitiesTypeId[0];
            ZM0121( -27) ;
         }
         pr_default.close(64);
         OnLoadActions0121( ) ;
      }

      protected void OnLoadActions0121( )
      {
      }

      protected void CheckExtendedTable0121( )
      {
         Gx_BScreen = 1;
         standaloneModal0121( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A98AmenitiesId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Amenities'.", "ForeignKeyNotFound", 1, "AMENITIESID");
            AnyError = 1;
         }
         A101AmenitiesName = BC00014_A101AmenitiesName[0];
         A99AmenitiesTypeId = BC00014_A99AmenitiesTypeId[0];
         pr_default.close(2);
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A99AmenitiesTypeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'AmenitiesType'.", "ForeignKeyNotFound", 1, "AMENITIESTYPEID");
            AnyError = 1;
         }
         A100AmenitiesTypeName = BC00015_A100AmenitiesTypeName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0121( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0121( )
      {
      }

      protected void GetKey0121( )
      {
         /* Using cursor BC000167 */
         pr_default.execute(65, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
         if ( (pr_default.getStatus(65) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(65);
      }

      protected void getByPrimaryKey0121( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0121( 27) ;
            RcdFound21 = 1;
            InitializeNonKey0121( ) ;
            A98AmenitiesId = BC00013_A98AmenitiesId[0];
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z98AmenitiesId = A98AmenitiesId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0121( ) ;
            Load0121( ) ;
            Gx_mode = sMode21;
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0121( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0121( ) ;
            Gx_mode = sMode21;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0121( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0121( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerLocationsAmenities"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerLocationsAmenities"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0121( )
      {
         BeforeValidate0121( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0121( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0121( 0) ;
            CheckOptimisticConcurrency0121( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0121( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0121( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000168 */
                     pr_default.execute(66, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
                     pr_default.close(66);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerLocationsAmenities");
                     if ( (pr_default.getStatus(66) == 1) )
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
               Load0121( ) ;
            }
            EndLevel0121( ) ;
         }
         CloseExtendedTableCursors0121( ) ;
      }

      protected void Update0121( )
      {
         BeforeValidate0121( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0121( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0121( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0121( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0121( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table CustomerLocationsAmenities */
                     DeferredUpdate0121( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0121( ) ;
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
            EndLevel0121( ) ;
         }
         CloseExtendedTableCursors0121( ) ;
      }

      protected void DeferredUpdate0121( )
      {
      }

      protected void Delete0121( )
      {
         Gx_mode = "DLT";
         BeforeValidate0121( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0121( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0121( ) ;
            AfterConfirm0121( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0121( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000169 */
                  pr_default.execute(67, new Object[] {A1CustomerId, A18CustomerLocationId, A98AmenitiesId});
                  pr_default.close(67);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerLocationsAmenities");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0121( ) ;
         Gx_mode = sMode21;
      }

      protected void OnDeleteControls0121( )
      {
         standaloneModal0121( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000170 */
            pr_default.execute(68, new Object[] {A98AmenitiesId});
            A101AmenitiesName = BC000170_A101AmenitiesName[0];
            A99AmenitiesTypeId = BC000170_A99AmenitiesTypeId[0];
            pr_default.close(68);
            /* Using cursor BC000171 */
            pr_default.execute(69, new Object[] {A99AmenitiesTypeId});
            A100AmenitiesTypeName = BC000171_A100AmenitiesTypeName[0];
            pr_default.close(69);
         }
      }

      protected void EndLevel0121( )
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

      public void ScanKeyStart0121( )
      {
         /* Scan By routine */
         /* Using cursor BC000172 */
         pr_default.execute(70, new Object[] {A1CustomerId, A18CustomerLocationId});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(70) != 101) )
         {
            RcdFound21 = 1;
            A101AmenitiesName = BC000172_A101AmenitiesName[0];
            A100AmenitiesTypeName = BC000172_A100AmenitiesTypeName[0];
            A98AmenitiesId = BC000172_A98AmenitiesId[0];
            A99AmenitiesTypeId = BC000172_A99AmenitiesTypeId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0121( )
      {
         /* Scan next routine */
         pr_default.readNext(70);
         RcdFound21 = 0;
         ScanKeyLoad0121( ) ;
      }

      protected void ScanKeyLoad0121( )
      {
         sMode21 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(70) != 101) )
         {
            RcdFound21 = 1;
            A101AmenitiesName = BC000172_A101AmenitiesName[0];
            A100AmenitiesTypeName = BC000172_A100AmenitiesTypeName[0];
            A98AmenitiesId = BC000172_A98AmenitiesId[0];
            A99AmenitiesTypeId = BC000172_A99AmenitiesTypeId[0];
         }
         Gx_mode = sMode21;
      }

      protected void ScanKeyEnd0121( )
      {
         pr_default.close(70);
      }

      protected void AfterConfirm0121( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0121( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0121( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0121( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0121( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0121( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0121( )
      {
      }

      protected void send_integrity_lvl_hashes0121( )
      {
      }

      protected void send_integrity_lvl_hashes013( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcCustomer) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcCustomer, 1) ;
      }

      protected void AddRow012( )
      {
         SdtCustomer_Manager obj2;
         obj2 = new SdtCustomer_Manager(context);
         VarsToRow2( obj2) ;
         bcCustomer.gxTpr_Manager.Add(obj2, 0);
         obj2.gxTpr_Mode = "UPD";
         obj2.gxTpr_Modified = 0;
      }

      protected void ReadRow012( )
      {
         nGXsfl_2_idx = (int)(nGXsfl_2_idx+1);
         RowToVars2( ((SdtCustomer_Manager)bcCustomer.gxTpr_Manager.Item(nGXsfl_2_idx)), 1) ;
      }

      protected void AddRow013( )
      {
         SdtCustomer_Locations obj3;
         obj3 = new SdtCustomer_Locations(context);
         VarsToRow3( obj3) ;
         bcCustomer.gxTpr_Locations.Add(obj3, 0);
         obj3.gxTpr_Mode = "UPD";
         obj3.gxTpr_Modified = 0;
      }

      protected void ReadRow013( )
      {
         nGXsfl_3_idx = (int)(nGXsfl_3_idx+1);
         RowToVars3( ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)), 1) ;
      }

      protected void AddRow014( )
      {
         SdtCustomer_Locations_Receptionist obj4;
         obj4 = new SdtCustomer_Locations_Receptionist(context);
         VarsToRow4( obj4) ;
         ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.Add(obj4, 0);
         obj4.gxTpr_Mode = "UPD";
         obj4.gxTpr_Modified = 0;
      }

      protected void ReadRow014( )
      {
         nGXsfl_4_idx = (int)(nGXsfl_4_idx+1);
         RowToVars4( ((SdtCustomer_Locations_Receptionist)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.Item(nGXsfl_4_idx)), 1) ;
      }

      protected void AddRow0116( )
      {
         SdtCustomer_Locations_Supplier_Agb obj16;
         obj16 = new SdtCustomer_Locations_Supplier_Agb(context);
         VarsToRow16( obj16) ;
         ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.Add(obj16, 0);
         obj16.gxTpr_Mode = "UPD";
         obj16.gxTpr_Modified = 0;
      }

      protected void ReadRow0116( )
      {
         nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
         RowToVars16( ((SdtCustomer_Locations_Supplier_Agb)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.Item(nGXsfl_16_idx)), 1) ;
      }

      protected void AddRow0117( )
      {
         SdtCustomer_Locations_Supplier_Gen obj17;
         obj17 = new SdtCustomer_Locations_Supplier_Gen(context);
         VarsToRow17( obj17) ;
         ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.Add(obj17, 0);
         obj17.gxTpr_Mode = "UPD";
         obj17.gxTpr_Modified = 0;
      }

      protected void ReadRow0117( )
      {
         nGXsfl_17_idx = (int)(nGXsfl_17_idx+1);
         RowToVars17( ((SdtCustomer_Locations_Supplier_Gen)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.Item(nGXsfl_17_idx)), 1) ;
      }

      protected void AddRow0121( )
      {
         SdtCustomer_Locations_Amenities obj21;
         obj21 = new SdtCustomer_Locations_Amenities(context);
         VarsToRow21( obj21) ;
         ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.Add(obj21, 0);
         obj21.gxTpr_Mode = "UPD";
         obj21.gxTpr_Modified = 0;
      }

      protected void ReadRow0121( )
      {
         nGXsfl_21_idx = (int)(nGXsfl_21_idx+1);
         RowToVars21( ((SdtCustomer_Locations_Amenities)((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.Item(nGXsfl_21_idx)), 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A41CustomerKvkNumber = "";
         A3CustomerName = "";
         A4CustomerPostalAddress = "";
         n4CustomerPostalAddress = false;
         A5CustomerEmail = "";
         n5CustomerEmail = false;
         A6CustomerVisitingAddress = "";
         n6CustomerVisitingAddress = false;
         A7CustomerPhone = "";
         n7CustomerPhone = false;
         A14CustomerVatNumber = "";
         A78CustomerTypeId = 0;
         n78CustomerTypeId = false;
         A79CustomerTypeName = "";
         A93CustomerLastLine = 0;
         A95CustomerLastLineLocation = 0;
         O95CustomerLastLineLocation = A95CustomerLastLineLocation;
         O93CustomerLastLine = A93CustomerLastLine;
         Z41CustomerKvkNumber = "";
         Z3CustomerName = "";
         Z4CustomerPostalAddress = "";
         Z5CustomerEmail = "";
         Z6CustomerVisitingAddress = "";
         Z7CustomerPhone = "";
         Z14CustomerVatNumber = "";
         Z93CustomerLastLine = 0;
         Z95CustomerLastLineLocation = 0;
         Z78CustomerTypeId = 0;
      }

      protected void InitAll011( )
      {
         A1CustomerId = 0;
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey012( )
      {
         A13CustomerManagerGAMGUID = "";
         A17CustomerManagerInitials = "";
         n17CustomerManagerInitials = false;
         A16CustomerManagerGivenName = "";
         A9CustomerManagerLastName = "";
         A10CustomerManagerEmail = "";
         A11CustomerManagerPhone = "";
         n11CustomerManagerPhone = false;
         A12CustomerManagerGender = "";
         n12CustomerManagerGender = false;
         Z13CustomerManagerGAMGUID = "";
         Z17CustomerManagerInitials = "";
         Z16CustomerManagerGivenName = "";
         Z9CustomerManagerLastName = "";
         Z10CustomerManagerEmail = "";
         Z11CustomerManagerPhone = "";
         Z12CustomerManagerGender = "";
      }

      protected void InitAll012( )
      {
         A15CustomerManagerId = 0;
         InitializeNonKey012( ) ;
      }

      protected void StandaloneModalInsert012( )
      {
         A93CustomerLastLine = i93CustomerLastLine;
      }

      protected void InitializeNonKey013( )
      {
         A19CustomerLocationVisitingAddres = "";
         A20CustomerLocationPostalAddress = "";
         A21CustomerLocationEmail = "";
         A22CustomerLocationPhone = "";
         A94CustomerLocationLastLine = 0;
         A133CustomerLocationDescription = "";
         A134CustomerLocationName = "";
         O94CustomerLocationLastLine = A94CustomerLocationLastLine;
         Z19CustomerLocationVisitingAddres = "";
         Z20CustomerLocationPostalAddress = "";
         Z21CustomerLocationEmail = "";
         Z22CustomerLocationPhone = "";
         Z94CustomerLocationLastLine = 0;
         Z133CustomerLocationDescription = "";
         Z134CustomerLocationName = "";
      }

      protected void InitAll013( )
      {
         A18CustomerLocationId = 0;
         InitializeNonKey013( ) ;
      }

      protected void StandaloneModalInsert013( )
      {
         A95CustomerLastLineLocation = i95CustomerLastLineLocation;
      }

      protected void InitializeNonKey014( )
      {
         A30CustomerLocationReceptionistGA = "";
         A26CustomerLocationReceptionistIn = "";
         n26CustomerLocationReceptionistIn = false;
         A24CustomerLocationReceptionistGi = "";
         A25CustomerLocationReceptionistLa = "";
         A27CustomerLocationReceptionistEm = "";
         A28CustomerLocationReceptionistAd = "";
         n28CustomerLocationReceptionistAd = false;
         A29CustomerLocationReceptionistPh = "";
         Z30CustomerLocationReceptionistGA = "";
         Z26CustomerLocationReceptionistIn = "";
         Z24CustomerLocationReceptionistGi = "";
         Z25CustomerLocationReceptionistLa = "";
         Z27CustomerLocationReceptionistEm = "";
         Z28CustomerLocationReceptionistAd = "";
         Z29CustomerLocationReceptionistPh = "";
      }

      protected void InitAll014( )
      {
         A23CustomerLocationReceptionistId = 0;
         InitializeNonKey014( ) ;
      }

      protected void StandaloneModalInsert014( )
      {
         A94CustomerLocationLastLine = i94CustomerLocationLastLine;
      }

      protected void InitializeNonKey0116( )
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
      }

      protected void InitAll0116( )
      {
         A55Supplier_AgbId = 0;
         InitializeNonKey0116( ) ;
      }

      protected void StandaloneModalInsert0116( )
      {
      }

      protected void InitializeNonKey0117( )
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
      }

      protected void InitAll0117( )
      {
         A64Supplier_GenId = 0;
         InitializeNonKey0117( ) ;
      }

      protected void StandaloneModalInsert0117( )
      {
      }

      protected void InitializeNonKey0121( )
      {
         A101AmenitiesName = "";
         A99AmenitiesTypeId = 0;
         A100AmenitiesTypeName = "";
      }

      protected void InitAll0121( )
      {
         A98AmenitiesId = 0;
         InitializeNonKey0121( ) ;
      }

      protected void StandaloneModalInsert0121( )
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

      public void VarsToRow1( SdtCustomer obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Customerkvknumber = A41CustomerKvkNumber;
         obj1.gxTpr_Customername = A3CustomerName;
         obj1.gxTpr_Customerpostaladdress = A4CustomerPostalAddress;
         obj1.gxTpr_Customeremail = A5CustomerEmail;
         obj1.gxTpr_Customervisitingaddress = A6CustomerVisitingAddress;
         obj1.gxTpr_Customerphone = A7CustomerPhone;
         obj1.gxTpr_Customervatnumber = A14CustomerVatNumber;
         obj1.gxTpr_Customertypeid = A78CustomerTypeId;
         obj1.gxTpr_Customertypename = A79CustomerTypeName;
         obj1.gxTpr_Customerlastline = A93CustomerLastLine;
         obj1.gxTpr_Customerlastlinelocation = A95CustomerLastLineLocation;
         obj1.gxTpr_Customerid = A1CustomerId;
         obj1.gxTpr_Customerid_Z = Z1CustomerId;
         obj1.gxTpr_Customerkvknumber_Z = Z41CustomerKvkNumber;
         obj1.gxTpr_Customername_Z = Z3CustomerName;
         obj1.gxTpr_Customerpostaladdress_Z = Z4CustomerPostalAddress;
         obj1.gxTpr_Customeremail_Z = Z5CustomerEmail;
         obj1.gxTpr_Customervisitingaddress_Z = Z6CustomerVisitingAddress;
         obj1.gxTpr_Customerphone_Z = Z7CustomerPhone;
         obj1.gxTpr_Customervatnumber_Z = Z14CustomerVatNumber;
         obj1.gxTpr_Customertypeid_Z = Z78CustomerTypeId;
         obj1.gxTpr_Customertypename_Z = Z79CustomerTypeName;
         obj1.gxTpr_Customerlastline_Z = Z93CustomerLastLine;
         obj1.gxTpr_Customerlastlinelocation_Z = Z95CustomerLastLineLocation;
         obj1.gxTpr_Customerpostaladdress_N = (short)(Convert.ToInt16(n4CustomerPostalAddress));
         obj1.gxTpr_Customeremail_N = (short)(Convert.ToInt16(n5CustomerEmail));
         obj1.gxTpr_Customervisitingaddress_N = (short)(Convert.ToInt16(n6CustomerVisitingAddress));
         obj1.gxTpr_Customerphone_N = (short)(Convert.ToInt16(n7CustomerPhone));
         obj1.gxTpr_Customertypeid_N = (short)(Convert.ToInt16(n78CustomerTypeId));
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtCustomer obj1 )
      {
         obj1.gxTpr_Customerid = A1CustomerId;
         return  ;
      }

      public void RowToVars1( SdtCustomer obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A41CustomerKvkNumber = obj1.gxTpr_Customerkvknumber;
         A3CustomerName = obj1.gxTpr_Customername;
         A4CustomerPostalAddress = obj1.gxTpr_Customerpostaladdress;
         n4CustomerPostalAddress = false;
         A5CustomerEmail = obj1.gxTpr_Customeremail;
         n5CustomerEmail = false;
         A6CustomerVisitingAddress = obj1.gxTpr_Customervisitingaddress;
         n6CustomerVisitingAddress = false;
         A7CustomerPhone = obj1.gxTpr_Customerphone;
         n7CustomerPhone = false;
         A14CustomerVatNumber = obj1.gxTpr_Customervatnumber;
         A78CustomerTypeId = obj1.gxTpr_Customertypeid;
         n78CustomerTypeId = false;
         A79CustomerTypeName = obj1.gxTpr_Customertypename;
         if ( forceLoad == 1 )
         {
            A93CustomerLastLine = obj1.gxTpr_Customerlastline;
         }
         if ( forceLoad == 1 )
         {
            A95CustomerLastLineLocation = obj1.gxTpr_Customerlastlinelocation;
         }
         A1CustomerId = obj1.gxTpr_Customerid;
         Z1CustomerId = obj1.gxTpr_Customerid_Z;
         Z41CustomerKvkNumber = obj1.gxTpr_Customerkvknumber_Z;
         Z3CustomerName = obj1.gxTpr_Customername_Z;
         Z4CustomerPostalAddress = obj1.gxTpr_Customerpostaladdress_Z;
         Z5CustomerEmail = obj1.gxTpr_Customeremail_Z;
         Z6CustomerVisitingAddress = obj1.gxTpr_Customervisitingaddress_Z;
         Z7CustomerPhone = obj1.gxTpr_Customerphone_Z;
         Z14CustomerVatNumber = obj1.gxTpr_Customervatnumber_Z;
         Z78CustomerTypeId = obj1.gxTpr_Customertypeid_Z;
         Z79CustomerTypeName = obj1.gxTpr_Customertypename_Z;
         Z93CustomerLastLine = obj1.gxTpr_Customerlastline_Z;
         O93CustomerLastLine = obj1.gxTpr_Customerlastline_Z;
         Z95CustomerLastLineLocation = obj1.gxTpr_Customerlastlinelocation_Z;
         O95CustomerLastLineLocation = obj1.gxTpr_Customerlastlinelocation_Z;
         n4CustomerPostalAddress = (bool)(Convert.ToBoolean(obj1.gxTpr_Customerpostaladdress_N));
         n5CustomerEmail = (bool)(Convert.ToBoolean(obj1.gxTpr_Customeremail_N));
         n6CustomerVisitingAddress = (bool)(Convert.ToBoolean(obj1.gxTpr_Customervisitingaddress_N));
         n7CustomerPhone = (bool)(Convert.ToBoolean(obj1.gxTpr_Customerphone_N));
         n78CustomerTypeId = (bool)(Convert.ToBoolean(obj1.gxTpr_Customertypeid_N));
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow2( SdtCustomer_Manager obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Customermanagergamguid = A13CustomerManagerGAMGUID;
         obj2.gxTpr_Customermanagerinitials = A17CustomerManagerInitials;
         obj2.gxTpr_Customermanagergivenname = A16CustomerManagerGivenName;
         obj2.gxTpr_Customermanagerlastname = A9CustomerManagerLastName;
         obj2.gxTpr_Customermanageremail = A10CustomerManagerEmail;
         obj2.gxTpr_Customermanagerphone = A11CustomerManagerPhone;
         obj2.gxTpr_Customermanagergender = A12CustomerManagerGender;
         obj2.gxTpr_Customermanagerid = A15CustomerManagerId;
         obj2.gxTpr_Customermanagerid_Z = Z15CustomerManagerId;
         obj2.gxTpr_Customermanagergivenname_Z = Z16CustomerManagerGivenName;
         obj2.gxTpr_Customermanagerlastname_Z = Z9CustomerManagerLastName;
         obj2.gxTpr_Customermanagerinitials_Z = Z17CustomerManagerInitials;
         obj2.gxTpr_Customermanageremail_Z = Z10CustomerManagerEmail;
         obj2.gxTpr_Customermanagerphone_Z = Z11CustomerManagerPhone;
         obj2.gxTpr_Customermanagergender_Z = Z12CustomerManagerGender;
         obj2.gxTpr_Customermanagergamguid_Z = Z13CustomerManagerGAMGUID;
         obj2.gxTpr_Customermanagerinitials_N = (short)(Convert.ToInt16(n17CustomerManagerInitials));
         obj2.gxTpr_Customermanagerphone_N = (short)(Convert.ToInt16(n11CustomerManagerPhone));
         obj2.gxTpr_Customermanagergender_N = (short)(Convert.ToInt16(n12CustomerManagerGender));
         obj2.gxTpr_Modified = nIsMod_2;
         return  ;
      }

      public void KeyVarsToRow2( SdtCustomer_Manager obj2 )
      {
         obj2.gxTpr_Customermanagerid = A15CustomerManagerId;
         return  ;
      }

      public void RowToVars2( SdtCustomer_Manager obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A13CustomerManagerGAMGUID = obj2.gxTpr_Customermanagergamguid;
         A17CustomerManagerInitials = obj2.gxTpr_Customermanagerinitials;
         n17CustomerManagerInitials = false;
         A16CustomerManagerGivenName = obj2.gxTpr_Customermanagergivenname;
         A9CustomerManagerLastName = obj2.gxTpr_Customermanagerlastname;
         A10CustomerManagerEmail = obj2.gxTpr_Customermanageremail;
         A11CustomerManagerPhone = obj2.gxTpr_Customermanagerphone;
         n11CustomerManagerPhone = false;
         A12CustomerManagerGender = obj2.gxTpr_Customermanagergender;
         n12CustomerManagerGender = false;
         A15CustomerManagerId = obj2.gxTpr_Customermanagerid;
         Z15CustomerManagerId = obj2.gxTpr_Customermanagerid_Z;
         Z16CustomerManagerGivenName = obj2.gxTpr_Customermanagergivenname_Z;
         Z9CustomerManagerLastName = obj2.gxTpr_Customermanagerlastname_Z;
         Z17CustomerManagerInitials = obj2.gxTpr_Customermanagerinitials_Z;
         Z10CustomerManagerEmail = obj2.gxTpr_Customermanageremail_Z;
         Z11CustomerManagerPhone = obj2.gxTpr_Customermanagerphone_Z;
         Z12CustomerManagerGender = obj2.gxTpr_Customermanagergender_Z;
         Z13CustomerManagerGAMGUID = obj2.gxTpr_Customermanagergamguid_Z;
         n17CustomerManagerInitials = (bool)(Convert.ToBoolean(obj2.gxTpr_Customermanagerinitials_N));
         n11CustomerManagerPhone = (bool)(Convert.ToBoolean(obj2.gxTpr_Customermanagerphone_N));
         n12CustomerManagerGender = (bool)(Convert.ToBoolean(obj2.gxTpr_Customermanagergender_N));
         nIsMod_2 = obj2.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow3( SdtCustomer_Locations obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Customerlocationvisitingaddress = A19CustomerLocationVisitingAddres;
         obj3.gxTpr_Customerlocationpostaladdress = A20CustomerLocationPostalAddress;
         obj3.gxTpr_Customerlocationemail = A21CustomerLocationEmail;
         obj3.gxTpr_Customerlocationphone = A22CustomerLocationPhone;
         obj3.gxTpr_Customerlocationlastline = A94CustomerLocationLastLine;
         obj3.gxTpr_Customerlocationdescription = A133CustomerLocationDescription;
         obj3.gxTpr_Customerlocationname = A134CustomerLocationName;
         obj3.gxTpr_Customerlocationid = A18CustomerLocationId;
         obj3.gxTpr_Customerlocationid_Z = Z18CustomerLocationId;
         obj3.gxTpr_Customerlocationvisitingaddress_Z = Z19CustomerLocationVisitingAddres;
         obj3.gxTpr_Customerlocationpostaladdress_Z = Z20CustomerLocationPostalAddress;
         obj3.gxTpr_Customerlocationemail_Z = Z21CustomerLocationEmail;
         obj3.gxTpr_Customerlocationphone_Z = Z22CustomerLocationPhone;
         obj3.gxTpr_Customerlocationlastline_Z = Z94CustomerLocationLastLine;
         obj3.gxTpr_Customerlocationdescription_Z = Z133CustomerLocationDescription;
         obj3.gxTpr_Customerlocationname_Z = Z134CustomerLocationName;
         obj3.gxTpr_Modified = nIsMod_3;
         return  ;
      }

      public void KeyVarsToRow3( SdtCustomer_Locations obj3 )
      {
         obj3.gxTpr_Customerlocationid = A18CustomerLocationId;
         return  ;
      }

      public void RowToVars3( SdtCustomer_Locations obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A19CustomerLocationVisitingAddres = obj3.gxTpr_Customerlocationvisitingaddress;
         A20CustomerLocationPostalAddress = obj3.gxTpr_Customerlocationpostaladdress;
         A21CustomerLocationEmail = obj3.gxTpr_Customerlocationemail;
         A22CustomerLocationPhone = obj3.gxTpr_Customerlocationphone;
         if ( forceLoad == 1 )
         {
            A94CustomerLocationLastLine = obj3.gxTpr_Customerlocationlastline;
         }
         A133CustomerLocationDescription = obj3.gxTpr_Customerlocationdescription;
         A134CustomerLocationName = obj3.gxTpr_Customerlocationname;
         A18CustomerLocationId = obj3.gxTpr_Customerlocationid;
         Z18CustomerLocationId = obj3.gxTpr_Customerlocationid_Z;
         Z19CustomerLocationVisitingAddres = obj3.gxTpr_Customerlocationvisitingaddress_Z;
         Z20CustomerLocationPostalAddress = obj3.gxTpr_Customerlocationpostaladdress_Z;
         Z21CustomerLocationEmail = obj3.gxTpr_Customerlocationemail_Z;
         Z22CustomerLocationPhone = obj3.gxTpr_Customerlocationphone_Z;
         Z94CustomerLocationLastLine = obj3.gxTpr_Customerlocationlastline_Z;
         O94CustomerLocationLastLine = obj3.gxTpr_Customerlocationlastline_Z;
         Z133CustomerLocationDescription = obj3.gxTpr_Customerlocationdescription_Z;
         Z134CustomerLocationName = obj3.gxTpr_Customerlocationname_Z;
         nIsMod_3 = obj3.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow4( SdtCustomer_Locations_Receptionist obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Customerlocationreceptionistgamguid = A30CustomerLocationReceptionistGA;
         obj4.gxTpr_Customerlocationreceptionistinitials = A26CustomerLocationReceptionistIn;
         obj4.gxTpr_Customerlocationreceptionistgivenname = A24CustomerLocationReceptionistGi;
         obj4.gxTpr_Customerlocationreceptionistlastname = A25CustomerLocationReceptionistLa;
         obj4.gxTpr_Customerlocationreceptionistemail = A27CustomerLocationReceptionistEm;
         obj4.gxTpr_Customerlocationreceptionistaddress = A28CustomerLocationReceptionistAd;
         obj4.gxTpr_Customerlocationreceptionistphone = A29CustomerLocationReceptionistPh;
         obj4.gxTpr_Customerlocationreceptionistid = A23CustomerLocationReceptionistId;
         obj4.gxTpr_Customerlocationreceptionistid_Z = Z23CustomerLocationReceptionistId;
         obj4.gxTpr_Customerlocationreceptionistgivenname_Z = Z24CustomerLocationReceptionistGi;
         obj4.gxTpr_Customerlocationreceptionistlastname_Z = Z25CustomerLocationReceptionistLa;
         obj4.gxTpr_Customerlocationreceptionistinitials_Z = Z26CustomerLocationReceptionistIn;
         obj4.gxTpr_Customerlocationreceptionistemail_Z = Z27CustomerLocationReceptionistEm;
         obj4.gxTpr_Customerlocationreceptionistaddress_Z = Z28CustomerLocationReceptionistAd;
         obj4.gxTpr_Customerlocationreceptionistphone_Z = Z29CustomerLocationReceptionistPh;
         obj4.gxTpr_Customerlocationreceptionistgamguid_Z = Z30CustomerLocationReceptionistGA;
         obj4.gxTpr_Customerlocationreceptionistinitials_N = (short)(Convert.ToInt16(n26CustomerLocationReceptionistIn));
         obj4.gxTpr_Customerlocationreceptionistaddress_N = (short)(Convert.ToInt16(n28CustomerLocationReceptionistAd));
         obj4.gxTpr_Modified = nIsMod_4;
         return  ;
      }

      public void KeyVarsToRow4( SdtCustomer_Locations_Receptionist obj4 )
      {
         obj4.gxTpr_Customerlocationreceptionistid = A23CustomerLocationReceptionistId;
         return  ;
      }

      public void RowToVars4( SdtCustomer_Locations_Receptionist obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A30CustomerLocationReceptionistGA = obj4.gxTpr_Customerlocationreceptionistgamguid;
         A26CustomerLocationReceptionistIn = obj4.gxTpr_Customerlocationreceptionistinitials;
         n26CustomerLocationReceptionistIn = false;
         A24CustomerLocationReceptionistGi = obj4.gxTpr_Customerlocationreceptionistgivenname;
         A25CustomerLocationReceptionistLa = obj4.gxTpr_Customerlocationreceptionistlastname;
         A27CustomerLocationReceptionistEm = obj4.gxTpr_Customerlocationreceptionistemail;
         A28CustomerLocationReceptionistAd = obj4.gxTpr_Customerlocationreceptionistaddress;
         n28CustomerLocationReceptionistAd = false;
         A29CustomerLocationReceptionistPh = obj4.gxTpr_Customerlocationreceptionistphone;
         A23CustomerLocationReceptionistId = obj4.gxTpr_Customerlocationreceptionistid;
         Z23CustomerLocationReceptionistId = obj4.gxTpr_Customerlocationreceptionistid_Z;
         Z24CustomerLocationReceptionistGi = obj4.gxTpr_Customerlocationreceptionistgivenname_Z;
         Z25CustomerLocationReceptionistLa = obj4.gxTpr_Customerlocationreceptionistlastname_Z;
         Z26CustomerLocationReceptionistIn = obj4.gxTpr_Customerlocationreceptionistinitials_Z;
         Z27CustomerLocationReceptionistEm = obj4.gxTpr_Customerlocationreceptionistemail_Z;
         Z28CustomerLocationReceptionistAd = obj4.gxTpr_Customerlocationreceptionistaddress_Z;
         Z29CustomerLocationReceptionistPh = obj4.gxTpr_Customerlocationreceptionistphone_Z;
         Z30CustomerLocationReceptionistGA = obj4.gxTpr_Customerlocationreceptionistgamguid_Z;
         n26CustomerLocationReceptionistIn = (bool)(Convert.ToBoolean(obj4.gxTpr_Customerlocationreceptionistinitials_N));
         n28CustomerLocationReceptionistAd = (bool)(Convert.ToBoolean(obj4.gxTpr_Customerlocationreceptionistaddress_N));
         nIsMod_4 = obj4.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow16( SdtCustomer_Locations_Supplier_Agb obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Supplier_agbnumber = A56Supplier_AgbNumber;
         obj16.gxTpr_Supplier_agbname = A57Supplier_AgbName;
         obj16.gxTpr_Supplier_agbkvknumber = A58Supplier_AgbKvkNumber;
         obj16.gxTpr_Supplier_agbvisitingaddress = A59Supplier_AgbVisitingAddress;
         obj16.gxTpr_Supplier_agbpostaladdress = A60Supplier_AgbPostalAddress;
         obj16.gxTpr_Supplier_agbemail = A61Supplier_AgbEmail;
         obj16.gxTpr_Supplier_agbphone = A62Supplier_AgbPhone;
         obj16.gxTpr_Supplier_agbcontactname = A63Supplier_AgbContactName;
         obj16.gxTpr_Supplier_agbid = A55Supplier_AgbId;
         obj16.gxTpr_Supplier_agbid_Z = Z55Supplier_AgbId;
         obj16.gxTpr_Supplier_agbnumber_Z = Z56Supplier_AgbNumber;
         obj16.gxTpr_Supplier_agbname_Z = Z57Supplier_AgbName;
         obj16.gxTpr_Supplier_agbkvknumber_Z = Z58Supplier_AgbKvkNumber;
         obj16.gxTpr_Supplier_agbvisitingaddress_Z = Z59Supplier_AgbVisitingAddress;
         obj16.gxTpr_Supplier_agbpostaladdress_Z = Z60Supplier_AgbPostalAddress;
         obj16.gxTpr_Supplier_agbemail_Z = Z61Supplier_AgbEmail;
         obj16.gxTpr_Supplier_agbphone_Z = Z62Supplier_AgbPhone;
         obj16.gxTpr_Supplier_agbcontactname_Z = Z63Supplier_AgbContactName;
         obj16.gxTpr_Supplier_agbvisitingaddress_N = (short)(Convert.ToInt16(n59Supplier_AgbVisitingAddress));
         obj16.gxTpr_Supplier_agbpostaladdress_N = (short)(Convert.ToInt16(n60Supplier_AgbPostalAddress));
         obj16.gxTpr_Supplier_agbemail_N = (short)(Convert.ToInt16(n61Supplier_AgbEmail));
         obj16.gxTpr_Supplier_agbphone_N = (short)(Convert.ToInt16(n62Supplier_AgbPhone));
         obj16.gxTpr_Supplier_agbcontactname_N = (short)(Convert.ToInt16(n63Supplier_AgbContactName));
         obj16.gxTpr_Modified = nIsMod_16;
         return  ;
      }

      public void KeyVarsToRow16( SdtCustomer_Locations_Supplier_Agb obj16 )
      {
         obj16.gxTpr_Supplier_agbid = A55Supplier_AgbId;
         return  ;
      }

      public void RowToVars16( SdtCustomer_Locations_Supplier_Agb obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A56Supplier_AgbNumber = obj16.gxTpr_Supplier_agbnumber;
         A57Supplier_AgbName = obj16.gxTpr_Supplier_agbname;
         A58Supplier_AgbKvkNumber = obj16.gxTpr_Supplier_agbkvknumber;
         A59Supplier_AgbVisitingAddress = obj16.gxTpr_Supplier_agbvisitingaddress;
         n59Supplier_AgbVisitingAddress = false;
         A60Supplier_AgbPostalAddress = obj16.gxTpr_Supplier_agbpostaladdress;
         n60Supplier_AgbPostalAddress = false;
         A61Supplier_AgbEmail = obj16.gxTpr_Supplier_agbemail;
         n61Supplier_AgbEmail = false;
         A62Supplier_AgbPhone = obj16.gxTpr_Supplier_agbphone;
         n62Supplier_AgbPhone = false;
         A63Supplier_AgbContactName = obj16.gxTpr_Supplier_agbcontactname;
         n63Supplier_AgbContactName = false;
         A55Supplier_AgbId = obj16.gxTpr_Supplier_agbid;
         Z55Supplier_AgbId = obj16.gxTpr_Supplier_agbid_Z;
         Z56Supplier_AgbNumber = obj16.gxTpr_Supplier_agbnumber_Z;
         Z57Supplier_AgbName = obj16.gxTpr_Supplier_agbname_Z;
         Z58Supplier_AgbKvkNumber = obj16.gxTpr_Supplier_agbkvknumber_Z;
         Z59Supplier_AgbVisitingAddress = obj16.gxTpr_Supplier_agbvisitingaddress_Z;
         Z60Supplier_AgbPostalAddress = obj16.gxTpr_Supplier_agbpostaladdress_Z;
         Z61Supplier_AgbEmail = obj16.gxTpr_Supplier_agbemail_Z;
         Z62Supplier_AgbPhone = obj16.gxTpr_Supplier_agbphone_Z;
         Z63Supplier_AgbContactName = obj16.gxTpr_Supplier_agbcontactname_Z;
         n59Supplier_AgbVisitingAddress = (bool)(Convert.ToBoolean(obj16.gxTpr_Supplier_agbvisitingaddress_N));
         n60Supplier_AgbPostalAddress = (bool)(Convert.ToBoolean(obj16.gxTpr_Supplier_agbpostaladdress_N));
         n61Supplier_AgbEmail = (bool)(Convert.ToBoolean(obj16.gxTpr_Supplier_agbemail_N));
         n62Supplier_AgbPhone = (bool)(Convert.ToBoolean(obj16.gxTpr_Supplier_agbphone_N));
         n63Supplier_AgbContactName = (bool)(Convert.ToBoolean(obj16.gxTpr_Supplier_agbcontactname_N));
         nIsMod_16 = obj16.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow17( SdtCustomer_Locations_Supplier_Gen obj17 )
      {
         obj17.gxTpr_Mode = Gx_mode;
         obj17.gxTpr_Supplier_genkvknumber = A65Supplier_GenKvKNumber;
         obj17.gxTpr_Supplier_gencompanyname = A66Supplier_GenCompanyName;
         obj17.gxTpr_Supplier_genvisitingaddress = A67Supplier_GenVisitingAddress;
         obj17.gxTpr_Supplier_genpostaladdress = A68Supplier_GenPostalAddress;
         obj17.gxTpr_Supplier_gencontactname = A69Supplier_GenContactName;
         obj17.gxTpr_Supplier_gencontactphone = A70Supplier_GenContactPhone;
         obj17.gxTpr_Supplier_genid = A64Supplier_GenId;
         obj17.gxTpr_Supplier_genid_Z = Z64Supplier_GenId;
         obj17.gxTpr_Supplier_genkvknumber_Z = Z65Supplier_GenKvKNumber;
         obj17.gxTpr_Supplier_gencompanyname_Z = Z66Supplier_GenCompanyName;
         obj17.gxTpr_Supplier_genvisitingaddress_Z = Z67Supplier_GenVisitingAddress;
         obj17.gxTpr_Supplier_genpostaladdress_Z = Z68Supplier_GenPostalAddress;
         obj17.gxTpr_Supplier_gencontactname_Z = Z69Supplier_GenContactName;
         obj17.gxTpr_Supplier_gencontactphone_Z = Z70Supplier_GenContactPhone;
         obj17.gxTpr_Supplier_genvisitingaddress_N = (short)(Convert.ToInt16(n67Supplier_GenVisitingAddress));
         obj17.gxTpr_Supplier_genpostaladdress_N = (short)(Convert.ToInt16(n68Supplier_GenPostalAddress));
         obj17.gxTpr_Supplier_gencontactname_N = (short)(Convert.ToInt16(n69Supplier_GenContactName));
         obj17.gxTpr_Supplier_gencontactphone_N = (short)(Convert.ToInt16(n70Supplier_GenContactPhone));
         obj17.gxTpr_Modified = nIsMod_17;
         return  ;
      }

      public void KeyVarsToRow17( SdtCustomer_Locations_Supplier_Gen obj17 )
      {
         obj17.gxTpr_Supplier_genid = A64Supplier_GenId;
         return  ;
      }

      public void RowToVars17( SdtCustomer_Locations_Supplier_Gen obj17 ,
                               int forceLoad )
      {
         Gx_mode = obj17.gxTpr_Mode;
         A65Supplier_GenKvKNumber = obj17.gxTpr_Supplier_genkvknumber;
         A66Supplier_GenCompanyName = obj17.gxTpr_Supplier_gencompanyname;
         A67Supplier_GenVisitingAddress = obj17.gxTpr_Supplier_genvisitingaddress;
         n67Supplier_GenVisitingAddress = false;
         A68Supplier_GenPostalAddress = obj17.gxTpr_Supplier_genpostaladdress;
         n68Supplier_GenPostalAddress = false;
         A69Supplier_GenContactName = obj17.gxTpr_Supplier_gencontactname;
         n69Supplier_GenContactName = false;
         A70Supplier_GenContactPhone = obj17.gxTpr_Supplier_gencontactphone;
         n70Supplier_GenContactPhone = false;
         A64Supplier_GenId = obj17.gxTpr_Supplier_genid;
         Z64Supplier_GenId = obj17.gxTpr_Supplier_genid_Z;
         Z65Supplier_GenKvKNumber = obj17.gxTpr_Supplier_genkvknumber_Z;
         Z66Supplier_GenCompanyName = obj17.gxTpr_Supplier_gencompanyname_Z;
         Z67Supplier_GenVisitingAddress = obj17.gxTpr_Supplier_genvisitingaddress_Z;
         Z68Supplier_GenPostalAddress = obj17.gxTpr_Supplier_genpostaladdress_Z;
         Z69Supplier_GenContactName = obj17.gxTpr_Supplier_gencontactname_Z;
         Z70Supplier_GenContactPhone = obj17.gxTpr_Supplier_gencontactphone_Z;
         n67Supplier_GenVisitingAddress = (bool)(Convert.ToBoolean(obj17.gxTpr_Supplier_genvisitingaddress_N));
         n68Supplier_GenPostalAddress = (bool)(Convert.ToBoolean(obj17.gxTpr_Supplier_genpostaladdress_N));
         n69Supplier_GenContactName = (bool)(Convert.ToBoolean(obj17.gxTpr_Supplier_gencontactname_N));
         n70Supplier_GenContactPhone = (bool)(Convert.ToBoolean(obj17.gxTpr_Supplier_gencontactphone_N));
         nIsMod_17 = obj17.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow21( SdtCustomer_Locations_Amenities obj21 )
      {
         obj21.gxTpr_Mode = Gx_mode;
         obj21.gxTpr_Amenitiesname = A101AmenitiesName;
         obj21.gxTpr_Amenitiestypeid = A99AmenitiesTypeId;
         obj21.gxTpr_Amenitiestypename = A100AmenitiesTypeName;
         obj21.gxTpr_Amenitiesid = A98AmenitiesId;
         obj21.gxTpr_Amenitiesid_Z = Z98AmenitiesId;
         obj21.gxTpr_Amenitiesname_Z = Z101AmenitiesName;
         obj21.gxTpr_Amenitiestypeid_Z = Z99AmenitiesTypeId;
         obj21.gxTpr_Amenitiestypename_Z = Z100AmenitiesTypeName;
         obj21.gxTpr_Modified = nIsMod_21;
         return  ;
      }

      public void KeyVarsToRow21( SdtCustomer_Locations_Amenities obj21 )
      {
         obj21.gxTpr_Amenitiesid = A98AmenitiesId;
         return  ;
      }

      public void RowToVars21( SdtCustomer_Locations_Amenities obj21 ,
                               int forceLoad )
      {
         Gx_mode = obj21.gxTpr_Mode;
         A101AmenitiesName = obj21.gxTpr_Amenitiesname;
         A99AmenitiesTypeId = obj21.gxTpr_Amenitiestypeid;
         A100AmenitiesTypeName = obj21.gxTpr_Amenitiestypename;
         A98AmenitiesId = obj21.gxTpr_Amenitiesid;
         Z98AmenitiesId = obj21.gxTpr_Amenitiesid_Z;
         Z101AmenitiesName = obj21.gxTpr_Amenitiesname_Z;
         Z99AmenitiesTypeId = obj21.gxTpr_Amenitiestypeid_Z;
         Z100AmenitiesTypeName = obj21.gxTpr_Amenitiestypename_Z;
         nIsMod_21 = obj21.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1CustomerId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1CustomerId = A1CustomerId;
            O95CustomerLastLineLocation = A95CustomerLastLineLocation;
            O93CustomerLastLine = A93CustomerLastLine;
         }
         ZM011( -18) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         bcCustomer.gxTpr_Manager.ClearCollection();
         if ( RcdFound1 == 1 )
         {
            ScanKeyStart012( ) ;
            nGXsfl_2_idx = 1;
            while ( RcdFound2 != 0 )
            {
               Z1CustomerId = A1CustomerId;
               Z15CustomerManagerId = A15CustomerManagerId;
               ZM012( -20) ;
               OnLoadActions012( ) ;
               nRcdExists_2 = 1;
               nIsMod_2 = 0;
               AddRow012( ) ;
               nGXsfl_2_idx = (int)(nGXsfl_2_idx+1);
               ScanKeyNext012( ) ;
            }
            ScanKeyEnd012( ) ;
         }
         bcCustomer.gxTpr_Locations.ClearCollection();
         if ( RcdFound1 == 1 )
         {
            ScanKeyStart013( ) ;
            nGXsfl_3_idx = 1;
            while ( RcdFound3 != 0 )
            {
               O94CustomerLocationLastLine = A94CustomerLocationLastLine;
               Z1CustomerId = A1CustomerId;
               Z18CustomerLocationId = A18CustomerLocationId;
               ZM013( -21) ;
               OnLoadActions013( ) ;
               nRcdExists_3 = 1;
               nIsMod_3 = 0;
               Z94CustomerLocationLastLine = A94CustomerLocationLastLine;
               AddRow013( ) ;
               ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.ClearCollection();
               if ( RcdFound3 == 1 )
               {
                  ScanKeyStart014( ) ;
                  nGXsfl_4_idx = 1;
                  while ( RcdFound4 != 0 )
                  {
                     Z1CustomerId = A1CustomerId;
                     Z18CustomerLocationId = A18CustomerLocationId;
                     Z23CustomerLocationReceptionistId = A23CustomerLocationReceptionistId;
                     ZM014( -22) ;
                     OnLoadActions014( ) ;
                     nRcdExists_4 = 1;
                     nIsMod_4 = 0;
                     AddRow014( ) ;
                     nGXsfl_4_idx = (int)(nGXsfl_4_idx+1);
                     ScanKeyNext014( ) ;
                  }
                  ScanKeyEnd014( ) ;
               }
               ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.ClearCollection();
               if ( RcdFound3 == 1 )
               {
                  ScanKeyStart0116( ) ;
                  nGXsfl_16_idx = 1;
                  while ( RcdFound16 != 0 )
                  {
                     Z1CustomerId = A1CustomerId;
                     Z18CustomerLocationId = A18CustomerLocationId;
                     Z55Supplier_AgbId = A55Supplier_AgbId;
                     ZM0116( -23) ;
                     OnLoadActions0116( ) ;
                     nRcdExists_16 = 1;
                     nIsMod_16 = 0;
                     AddRow0116( ) ;
                     nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
                     ScanKeyNext0116( ) ;
                  }
                  ScanKeyEnd0116( ) ;
               }
               ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.ClearCollection();
               if ( RcdFound3 == 1 )
               {
                  ScanKeyStart0117( ) ;
                  nGXsfl_17_idx = 1;
                  while ( RcdFound17 != 0 )
                  {
                     Z1CustomerId = A1CustomerId;
                     Z18CustomerLocationId = A18CustomerLocationId;
                     Z64Supplier_GenId = A64Supplier_GenId;
                     ZM0117( -25) ;
                     OnLoadActions0117( ) ;
                     nRcdExists_17 = 1;
                     nIsMod_17 = 0;
                     AddRow0117( ) ;
                     nGXsfl_17_idx = (int)(nGXsfl_17_idx+1);
                     ScanKeyNext0117( ) ;
                  }
                  ScanKeyEnd0117( ) ;
               }
               ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.ClearCollection();
               if ( RcdFound3 == 1 )
               {
                  ScanKeyStart0121( ) ;
                  nGXsfl_21_idx = 1;
                  while ( RcdFound21 != 0 )
                  {
                     Z1CustomerId = A1CustomerId;
                     Z18CustomerLocationId = A18CustomerLocationId;
                     Z98AmenitiesId = A98AmenitiesId;
                     ZM0121( -27) ;
                     OnLoadActions0121( ) ;
                     nRcdExists_21 = 1;
                     nIsMod_21 = 0;
                     AddRow0121( ) ;
                     nGXsfl_21_idx = (int)(nGXsfl_21_idx+1);
                     ScanKeyNext0121( ) ;
                  }
                  ScanKeyEnd0121( ) ;
               }
               nGXsfl_3_idx = (int)(nGXsfl_3_idx+1);
               ScanKeyNext013( ) ;
            }
            ScanKeyEnd013( ) ;
         }
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
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
         RowToVars1( bcCustomer, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1CustomerId = A1CustomerId;
            O95CustomerLastLineLocation = A95CustomerLastLineLocation;
            O93CustomerLastLine = A93CustomerLastLine;
         }
         ZM011( -18) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         bcCustomer.gxTpr_Manager.ClearCollection();
         if ( RcdFound1 == 1 )
         {
            ScanKeyStart012( ) ;
            nGXsfl_2_idx = 1;
            while ( RcdFound2 != 0 )
            {
               Z1CustomerId = A1CustomerId;
               Z15CustomerManagerId = A15CustomerManagerId;
               ZM012( -20) ;
               OnLoadActions012( ) ;
               nRcdExists_2 = 1;
               nIsMod_2 = 0;
               AddRow012( ) ;
               nGXsfl_2_idx = (int)(nGXsfl_2_idx+1);
               ScanKeyNext012( ) ;
            }
            ScanKeyEnd012( ) ;
         }
         bcCustomer.gxTpr_Locations.ClearCollection();
         if ( RcdFound1 == 1 )
         {
            ScanKeyStart013( ) ;
            nGXsfl_3_idx = 1;
            while ( RcdFound3 != 0 )
            {
               O94CustomerLocationLastLine = A94CustomerLocationLastLine;
               Z1CustomerId = A1CustomerId;
               Z18CustomerLocationId = A18CustomerLocationId;
               ZM013( -21) ;
               OnLoadActions013( ) ;
               nRcdExists_3 = 1;
               nIsMod_3 = 0;
               Z94CustomerLocationLastLine = A94CustomerLocationLastLine;
               AddRow013( ) ;
               ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Receptionist.ClearCollection();
               if ( RcdFound3 == 1 )
               {
                  ScanKeyStart014( ) ;
                  nGXsfl_4_idx = 1;
                  while ( RcdFound4 != 0 )
                  {
                     Z1CustomerId = A1CustomerId;
                     Z18CustomerLocationId = A18CustomerLocationId;
                     Z23CustomerLocationReceptionistId = A23CustomerLocationReceptionistId;
                     ZM014( -22) ;
                     OnLoadActions014( ) ;
                     nRcdExists_4 = 1;
                     nIsMod_4 = 0;
                     AddRow014( ) ;
                     nGXsfl_4_idx = (int)(nGXsfl_4_idx+1);
                     ScanKeyNext014( ) ;
                  }
                  ScanKeyEnd014( ) ;
               }
               ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_agb.ClearCollection();
               if ( RcdFound3 == 1 )
               {
                  ScanKeyStart0116( ) ;
                  nGXsfl_16_idx = 1;
                  while ( RcdFound16 != 0 )
                  {
                     Z1CustomerId = A1CustomerId;
                     Z18CustomerLocationId = A18CustomerLocationId;
                     Z55Supplier_AgbId = A55Supplier_AgbId;
                     ZM0116( -23) ;
                     OnLoadActions0116( ) ;
                     nRcdExists_16 = 1;
                     nIsMod_16 = 0;
                     AddRow0116( ) ;
                     nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
                     ScanKeyNext0116( ) ;
                  }
                  ScanKeyEnd0116( ) ;
               }
               ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Supplier_gen.ClearCollection();
               if ( RcdFound3 == 1 )
               {
                  ScanKeyStart0117( ) ;
                  nGXsfl_17_idx = 1;
                  while ( RcdFound17 != 0 )
                  {
                     Z1CustomerId = A1CustomerId;
                     Z18CustomerLocationId = A18CustomerLocationId;
                     Z64Supplier_GenId = A64Supplier_GenId;
                     ZM0117( -25) ;
                     OnLoadActions0117( ) ;
                     nRcdExists_17 = 1;
                     nIsMod_17 = 0;
                     AddRow0117( ) ;
                     nGXsfl_17_idx = (int)(nGXsfl_17_idx+1);
                     ScanKeyNext0117( ) ;
                  }
                  ScanKeyEnd0117( ) ;
               }
               ((SdtCustomer_Locations)bcCustomer.gxTpr_Locations.Item(nGXsfl_3_idx)).gxTpr_Amenities.ClearCollection();
               if ( RcdFound3 == 1 )
               {
                  ScanKeyStart0121( ) ;
                  nGXsfl_21_idx = 1;
                  while ( RcdFound21 != 0 )
                  {
                     Z1CustomerId = A1CustomerId;
                     Z18CustomerLocationId = A18CustomerLocationId;
                     Z98AmenitiesId = A98AmenitiesId;
                     ZM0121( -27) ;
                     OnLoadActions0121( ) ;
                     nRcdExists_21 = 1;
                     nIsMod_21 = 0;
                     AddRow0121( ) ;
                     nGXsfl_21_idx = (int)(nGXsfl_21_idx+1);
                     ScanKeyNext0121( ) ;
                  }
                  ScanKeyEnd0121( ) ;
               }
               nGXsfl_3_idx = (int)(nGXsfl_3_idx+1);
               ScanKeyNext013( ) ;
            }
            ScanKeyEnd013( ) ;
         }
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A93CustomerLastLine = O93CustomerLastLine;
            A95CustomerLastLineLocation = O95CustomerLastLineLocation;
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1CustomerId != Z1CustomerId )
               {
                  A1CustomerId = Z1CustomerId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A93CustomerLastLine = O93CustomerLastLine;
                  A95CustomerLastLineLocation = O95CustomerLastLineLocation;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A93CustomerLastLine = O93CustomerLastLine;
                  A95CustomerLastLineLocation = O95CustomerLastLineLocation;
                  Update011( ) ;
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
                  if ( A1CustomerId != Z1CustomerId )
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
                        A93CustomerLastLine = O93CustomerLastLine;
                        A95CustomerLastLineLocation = O95CustomerLastLineLocation;
                        Insert011( ) ;
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
                        A93CustomerLastLine = O93CustomerLastLine;
                        A95CustomerLastLineLocation = O95CustomerLastLineLocation;
                        Insert011( ) ;
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
         RowToVars1( bcCustomer, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcCustomer) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcCustomer, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A93CustomerLastLine = O93CustomerLastLine;
         A95CustomerLastLineLocation = O95CustomerLastLineLocation;
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcCustomer) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bcCustomer) ;
         }
         else
         {
            SdtCustomer auxBC = new SdtCustomer(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1CustomerId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCustomer);
               auxBC.Save();
               bcCustomer.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars1( bcCustomer, 1) ;
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
         RowToVars1( bcCustomer, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
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
               VarsToRow1( bcCustomer) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bcCustomer) ;
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
         RowToVars1( bcCustomer, 0) ;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1CustomerId != Z1CustomerId )
            {
               A1CustomerId = Z1CustomerId;
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
            if ( A1CustomerId != Z1CustomerId )
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
         context.RollbackDataStores("customer_bc",pr_default);
         VarsToRow1( bcCustomer) ;
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
         Gx_mode = bcCustomer.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCustomer.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCustomer )
         {
            bcCustomer = (SdtCustomer)(sdt);
            if ( StringUtil.StrCmp(bcCustomer.gxTpr_Mode, "") == 0 )
            {
               bcCustomer.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcCustomer) ;
            }
            else
            {
               RowToVars1( bcCustomer, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCustomer.gxTpr_Mode, "") == 0 )
            {
               bcCustomer.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcCustomer, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCustomer Customer_BC
      {
         get {
            return bcCustomer ;
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
            return "customer_Execute" ;
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
         pr_default.close(68);
         pr_default.close(69);
         pr_default.close(5);
         pr_default.close(62);
         pr_default.close(8);
         pr_default.close(56);
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(15);
         pr_default.close(17);
         pr_default.close(25);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode1 = "";
         sMode3 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV29Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z41CustomerKvkNumber = "";
         A41CustomerKvkNumber = "";
         Z3CustomerName = "";
         A3CustomerName = "";
         Z4CustomerPostalAddress = "";
         A4CustomerPostalAddress = "";
         Z5CustomerEmail = "";
         A5CustomerEmail = "";
         Z6CustomerVisitingAddress = "";
         A6CustomerVisitingAddress = "";
         Z7CustomerPhone = "";
         A7CustomerPhone = "";
         Z14CustomerVatNumber = "";
         A14CustomerVatNumber = "";
         Z79CustomerTypeName = "";
         A79CustomerTypeName = "";
         BC000121_A1CustomerId = new short[1] ;
         BC000121_A41CustomerKvkNumber = new string[] {""} ;
         BC000121_A3CustomerName = new string[] {""} ;
         BC000121_A4CustomerPostalAddress = new string[] {""} ;
         BC000121_n4CustomerPostalAddress = new bool[] {false} ;
         BC000121_A5CustomerEmail = new string[] {""} ;
         BC000121_n5CustomerEmail = new bool[] {false} ;
         BC000121_A6CustomerVisitingAddress = new string[] {""} ;
         BC000121_n6CustomerVisitingAddress = new bool[] {false} ;
         BC000121_A7CustomerPhone = new string[] {""} ;
         BC000121_n7CustomerPhone = new bool[] {false} ;
         BC000121_A14CustomerVatNumber = new string[] {""} ;
         BC000121_A79CustomerTypeName = new string[] {""} ;
         BC000121_A93CustomerLastLine = new short[1] ;
         BC000121_A95CustomerLastLineLocation = new short[1] ;
         BC000121_A78CustomerTypeId = new short[1] ;
         BC000121_n78CustomerTypeId = new bool[] {false} ;
         BC000120_A79CustomerTypeName = new string[] {""} ;
         BC000122_A1CustomerId = new short[1] ;
         BC000119_A1CustomerId = new short[1] ;
         BC000119_A41CustomerKvkNumber = new string[] {""} ;
         BC000119_A3CustomerName = new string[] {""} ;
         BC000119_A4CustomerPostalAddress = new string[] {""} ;
         BC000119_n4CustomerPostalAddress = new bool[] {false} ;
         BC000119_A5CustomerEmail = new string[] {""} ;
         BC000119_n5CustomerEmail = new bool[] {false} ;
         BC000119_A6CustomerVisitingAddress = new string[] {""} ;
         BC000119_n6CustomerVisitingAddress = new bool[] {false} ;
         BC000119_A7CustomerPhone = new string[] {""} ;
         BC000119_n7CustomerPhone = new bool[] {false} ;
         BC000119_A14CustomerVatNumber = new string[] {""} ;
         BC000119_A93CustomerLastLine = new short[1] ;
         BC000119_A95CustomerLastLineLocation = new short[1] ;
         BC000119_A78CustomerTypeId = new short[1] ;
         BC000119_n78CustomerTypeId = new bool[] {false} ;
         BC000118_A1CustomerId = new short[1] ;
         BC000118_A41CustomerKvkNumber = new string[] {""} ;
         BC000118_A3CustomerName = new string[] {""} ;
         BC000118_A4CustomerPostalAddress = new string[] {""} ;
         BC000118_n4CustomerPostalAddress = new bool[] {false} ;
         BC000118_A5CustomerEmail = new string[] {""} ;
         BC000118_n5CustomerEmail = new bool[] {false} ;
         BC000118_A6CustomerVisitingAddress = new string[] {""} ;
         BC000118_n6CustomerVisitingAddress = new bool[] {false} ;
         BC000118_A7CustomerPhone = new string[] {""} ;
         BC000118_n7CustomerPhone = new bool[] {false} ;
         BC000118_A14CustomerVatNumber = new string[] {""} ;
         BC000118_A93CustomerLastLine = new short[1] ;
         BC000118_A95CustomerLastLineLocation = new short[1] ;
         BC000118_A78CustomerTypeId = new short[1] ;
         BC000118_n78CustomerTypeId = new bool[] {false} ;
         BC000124_A1CustomerId = new short[1] ;
         BC000127_A79CustomerTypeName = new string[] {""} ;
         BC000128_A128CustomerCustomizationId = new short[1] ;
         BC000129_A103PageId = new short[1] ;
         BC000130_A1CustomerId = new short[1] ;
         BC000130_A18CustomerLocationId = new short[1] ;
         BC000132_A1CustomerId = new short[1] ;
         BC000132_A41CustomerKvkNumber = new string[] {""} ;
         BC000132_A3CustomerName = new string[] {""} ;
         BC000132_A4CustomerPostalAddress = new string[] {""} ;
         BC000132_n4CustomerPostalAddress = new bool[] {false} ;
         BC000132_A5CustomerEmail = new string[] {""} ;
         BC000132_n5CustomerEmail = new bool[] {false} ;
         BC000132_A6CustomerVisitingAddress = new string[] {""} ;
         BC000132_n6CustomerVisitingAddress = new bool[] {false} ;
         BC000132_A7CustomerPhone = new string[] {""} ;
         BC000132_n7CustomerPhone = new bool[] {false} ;
         BC000132_A14CustomerVatNumber = new string[] {""} ;
         BC000132_A79CustomerTypeName = new string[] {""} ;
         BC000132_A93CustomerLastLine = new short[1] ;
         BC000132_A95CustomerLastLineLocation = new short[1] ;
         BC000132_A78CustomerTypeId = new short[1] ;
         BC000132_n78CustomerTypeId = new bool[] {false} ;
         Z13CustomerManagerGAMGUID = "";
         A13CustomerManagerGAMGUID = "";
         Z17CustomerManagerInitials = "";
         A17CustomerManagerInitials = "";
         Z16CustomerManagerGivenName = "";
         A16CustomerManagerGivenName = "";
         Z9CustomerManagerLastName = "";
         A9CustomerManagerLastName = "";
         Z10CustomerManagerEmail = "";
         A10CustomerManagerEmail = "";
         Z11CustomerManagerPhone = "";
         A11CustomerManagerPhone = "";
         Z12CustomerManagerGender = "";
         A12CustomerManagerGender = "";
         BC000133_A1CustomerId = new short[1] ;
         BC000133_A15CustomerManagerId = new short[1] ;
         BC000133_A13CustomerManagerGAMGUID = new string[] {""} ;
         BC000133_A17CustomerManagerInitials = new string[] {""} ;
         BC000133_n17CustomerManagerInitials = new bool[] {false} ;
         BC000133_A16CustomerManagerGivenName = new string[] {""} ;
         BC000133_A9CustomerManagerLastName = new string[] {""} ;
         BC000133_A10CustomerManagerEmail = new string[] {""} ;
         BC000133_A11CustomerManagerPhone = new string[] {""} ;
         BC000133_n11CustomerManagerPhone = new bool[] {false} ;
         BC000133_A12CustomerManagerGender = new string[] {""} ;
         BC000133_n12CustomerManagerGender = new bool[] {false} ;
         BC000134_A1CustomerId = new short[1] ;
         BC000134_A15CustomerManagerId = new short[1] ;
         BC000117_A1CustomerId = new short[1] ;
         BC000117_A15CustomerManagerId = new short[1] ;
         BC000117_A13CustomerManagerGAMGUID = new string[] {""} ;
         BC000117_A17CustomerManagerInitials = new string[] {""} ;
         BC000117_n17CustomerManagerInitials = new bool[] {false} ;
         BC000117_A16CustomerManagerGivenName = new string[] {""} ;
         BC000117_A9CustomerManagerLastName = new string[] {""} ;
         BC000117_A10CustomerManagerEmail = new string[] {""} ;
         BC000117_A11CustomerManagerPhone = new string[] {""} ;
         BC000117_n11CustomerManagerPhone = new bool[] {false} ;
         BC000117_A12CustomerManagerGender = new string[] {""} ;
         BC000117_n12CustomerManagerGender = new bool[] {false} ;
         sMode2 = "";
         BC000116_A1CustomerId = new short[1] ;
         BC000116_A15CustomerManagerId = new short[1] ;
         BC000116_A13CustomerManagerGAMGUID = new string[] {""} ;
         BC000116_A17CustomerManagerInitials = new string[] {""} ;
         BC000116_n17CustomerManagerInitials = new bool[] {false} ;
         BC000116_A16CustomerManagerGivenName = new string[] {""} ;
         BC000116_A9CustomerManagerLastName = new string[] {""} ;
         BC000116_A10CustomerManagerEmail = new string[] {""} ;
         BC000116_A11CustomerManagerPhone = new string[] {""} ;
         BC000116_n11CustomerManagerPhone = new bool[] {false} ;
         BC000116_A12CustomerManagerGender = new string[] {""} ;
         BC000116_n12CustomerManagerGender = new bool[] {false} ;
         BC000138_A1CustomerId = new short[1] ;
         BC000138_A15CustomerManagerId = new short[1] ;
         BC000138_A13CustomerManagerGAMGUID = new string[] {""} ;
         BC000138_A17CustomerManagerInitials = new string[] {""} ;
         BC000138_n17CustomerManagerInitials = new bool[] {false} ;
         BC000138_A16CustomerManagerGivenName = new string[] {""} ;
         BC000138_A9CustomerManagerLastName = new string[] {""} ;
         BC000138_A10CustomerManagerEmail = new string[] {""} ;
         BC000138_A11CustomerManagerPhone = new string[] {""} ;
         BC000138_n11CustomerManagerPhone = new bool[] {false} ;
         BC000138_A12CustomerManagerGender = new string[] {""} ;
         BC000138_n12CustomerManagerGender = new bool[] {false} ;
         Z19CustomerLocationVisitingAddres = "";
         A19CustomerLocationVisitingAddres = "";
         Z20CustomerLocationPostalAddress = "";
         A20CustomerLocationPostalAddress = "";
         Z21CustomerLocationEmail = "";
         A21CustomerLocationEmail = "";
         Z22CustomerLocationPhone = "";
         A22CustomerLocationPhone = "";
         Z133CustomerLocationDescription = "";
         A133CustomerLocationDescription = "";
         Z134CustomerLocationName = "";
         A134CustomerLocationName = "";
         BC000139_A1CustomerId = new short[1] ;
         BC000139_A18CustomerLocationId = new short[1] ;
         BC000139_A19CustomerLocationVisitingAddres = new string[] {""} ;
         BC000139_A20CustomerLocationPostalAddress = new string[] {""} ;
         BC000139_A21CustomerLocationEmail = new string[] {""} ;
         BC000139_A22CustomerLocationPhone = new string[] {""} ;
         BC000139_A94CustomerLocationLastLine = new short[1] ;
         BC000139_A133CustomerLocationDescription = new string[] {""} ;
         BC000139_A134CustomerLocationName = new string[] {""} ;
         BC000140_A1CustomerId = new short[1] ;
         BC000140_A18CustomerLocationId = new short[1] ;
         BC000115_A1CustomerId = new short[1] ;
         BC000115_A18CustomerLocationId = new short[1] ;
         BC000115_A19CustomerLocationVisitingAddres = new string[] {""} ;
         BC000115_A20CustomerLocationPostalAddress = new string[] {""} ;
         BC000115_A21CustomerLocationEmail = new string[] {""} ;
         BC000115_A22CustomerLocationPhone = new string[] {""} ;
         BC000115_A94CustomerLocationLastLine = new short[1] ;
         BC000115_A133CustomerLocationDescription = new string[] {""} ;
         BC000115_A134CustomerLocationName = new string[] {""} ;
         BC000114_A1CustomerId = new short[1] ;
         BC000114_A18CustomerLocationId = new short[1] ;
         BC000114_A19CustomerLocationVisitingAddres = new string[] {""} ;
         BC000114_A20CustomerLocationPostalAddress = new string[] {""} ;
         BC000114_A21CustomerLocationEmail = new string[] {""} ;
         BC000114_A22CustomerLocationPhone = new string[] {""} ;
         BC000114_A94CustomerLocationLastLine = new short[1] ;
         BC000114_A133CustomerLocationDescription = new string[] {""} ;
         BC000114_A134CustomerLocationName = new string[] {""} ;
         BC000144_A115LocationEventId = new short[1] ;
         BC000145_A31ResidentId = new short[1] ;
         BC000147_A1CustomerId = new short[1] ;
         BC000147_A18CustomerLocationId = new short[1] ;
         BC000147_A19CustomerLocationVisitingAddres = new string[] {""} ;
         BC000147_A20CustomerLocationPostalAddress = new string[] {""} ;
         BC000147_A21CustomerLocationEmail = new string[] {""} ;
         BC000147_A22CustomerLocationPhone = new string[] {""} ;
         BC000147_A94CustomerLocationLastLine = new short[1] ;
         BC000147_A133CustomerLocationDescription = new string[] {""} ;
         BC000147_A134CustomerLocationName = new string[] {""} ;
         Z30CustomerLocationReceptionistGA = "";
         A30CustomerLocationReceptionistGA = "";
         Z26CustomerLocationReceptionistIn = "";
         A26CustomerLocationReceptionistIn = "";
         Z24CustomerLocationReceptionistGi = "";
         A24CustomerLocationReceptionistGi = "";
         Z25CustomerLocationReceptionistLa = "";
         A25CustomerLocationReceptionistLa = "";
         Z27CustomerLocationReceptionistEm = "";
         A27CustomerLocationReceptionistEm = "";
         Z28CustomerLocationReceptionistAd = "";
         A28CustomerLocationReceptionistAd = "";
         Z29CustomerLocationReceptionistPh = "";
         A29CustomerLocationReceptionistPh = "";
         BC000148_A1CustomerId = new short[1] ;
         BC000148_A18CustomerLocationId = new short[1] ;
         BC000148_A23CustomerLocationReceptionistId = new short[1] ;
         BC000148_A30CustomerLocationReceptionistGA = new string[] {""} ;
         BC000148_A26CustomerLocationReceptionistIn = new string[] {""} ;
         BC000148_n26CustomerLocationReceptionistIn = new bool[] {false} ;
         BC000148_A24CustomerLocationReceptionistGi = new string[] {""} ;
         BC000148_A25CustomerLocationReceptionistLa = new string[] {""} ;
         BC000148_A27CustomerLocationReceptionistEm = new string[] {""} ;
         BC000148_A28CustomerLocationReceptionistAd = new string[] {""} ;
         BC000148_n28CustomerLocationReceptionistAd = new bool[] {false} ;
         BC000148_A29CustomerLocationReceptionistPh = new string[] {""} ;
         BC000149_A1CustomerId = new short[1] ;
         BC000149_A18CustomerLocationId = new short[1] ;
         BC000149_A23CustomerLocationReceptionistId = new short[1] ;
         BC000113_A1CustomerId = new short[1] ;
         BC000113_A18CustomerLocationId = new short[1] ;
         BC000113_A23CustomerLocationReceptionistId = new short[1] ;
         BC000113_A30CustomerLocationReceptionistGA = new string[] {""} ;
         BC000113_A26CustomerLocationReceptionistIn = new string[] {""} ;
         BC000113_n26CustomerLocationReceptionistIn = new bool[] {false} ;
         BC000113_A24CustomerLocationReceptionistGi = new string[] {""} ;
         BC000113_A25CustomerLocationReceptionistLa = new string[] {""} ;
         BC000113_A27CustomerLocationReceptionistEm = new string[] {""} ;
         BC000113_A28CustomerLocationReceptionistAd = new string[] {""} ;
         BC000113_n28CustomerLocationReceptionistAd = new bool[] {false} ;
         BC000113_A29CustomerLocationReceptionistPh = new string[] {""} ;
         sMode4 = "";
         BC000112_A1CustomerId = new short[1] ;
         BC000112_A18CustomerLocationId = new short[1] ;
         BC000112_A23CustomerLocationReceptionistId = new short[1] ;
         BC000112_A30CustomerLocationReceptionistGA = new string[] {""} ;
         BC000112_A26CustomerLocationReceptionistIn = new string[] {""} ;
         BC000112_n26CustomerLocationReceptionistIn = new bool[] {false} ;
         BC000112_A24CustomerLocationReceptionistGi = new string[] {""} ;
         BC000112_A25CustomerLocationReceptionistLa = new string[] {""} ;
         BC000112_A27CustomerLocationReceptionistEm = new string[] {""} ;
         BC000112_A28CustomerLocationReceptionistAd = new string[] {""} ;
         BC000112_n28CustomerLocationReceptionistAd = new bool[] {false} ;
         BC000112_A29CustomerLocationReceptionistPh = new string[] {""} ;
         BC000153_A1CustomerId = new short[1] ;
         BC000153_A18CustomerLocationId = new short[1] ;
         BC000153_A23CustomerLocationReceptionistId = new short[1] ;
         BC000153_A30CustomerLocationReceptionistGA = new string[] {""} ;
         BC000153_A26CustomerLocationReceptionistIn = new string[] {""} ;
         BC000153_n26CustomerLocationReceptionistIn = new bool[] {false} ;
         BC000153_A24CustomerLocationReceptionistGi = new string[] {""} ;
         BC000153_A25CustomerLocationReceptionistLa = new string[] {""} ;
         BC000153_A27CustomerLocationReceptionistEm = new string[] {""} ;
         BC000153_A28CustomerLocationReceptionistAd = new string[] {""} ;
         BC000153_n28CustomerLocationReceptionistAd = new bool[] {false} ;
         BC000153_A29CustomerLocationReceptionistPh = new string[] {""} ;
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
         BC000154_A1CustomerId = new short[1] ;
         BC000154_A18CustomerLocationId = new short[1] ;
         BC000154_A56Supplier_AgbNumber = new string[] {""} ;
         BC000154_A57Supplier_AgbName = new string[] {""} ;
         BC000154_A58Supplier_AgbKvkNumber = new string[] {""} ;
         BC000154_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         BC000154_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         BC000154_A60Supplier_AgbPostalAddress = new string[] {""} ;
         BC000154_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         BC000154_A61Supplier_AgbEmail = new string[] {""} ;
         BC000154_n61Supplier_AgbEmail = new bool[] {false} ;
         BC000154_A62Supplier_AgbPhone = new string[] {""} ;
         BC000154_n62Supplier_AgbPhone = new bool[] {false} ;
         BC000154_A63Supplier_AgbContactName = new string[] {""} ;
         BC000154_n63Supplier_AgbContactName = new bool[] {false} ;
         BC000154_A55Supplier_AgbId = new short[1] ;
         BC000111_A56Supplier_AgbNumber = new string[] {""} ;
         BC000111_A57Supplier_AgbName = new string[] {""} ;
         BC000111_A58Supplier_AgbKvkNumber = new string[] {""} ;
         BC000111_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         BC000111_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         BC000111_A60Supplier_AgbPostalAddress = new string[] {""} ;
         BC000111_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         BC000111_A61Supplier_AgbEmail = new string[] {""} ;
         BC000111_n61Supplier_AgbEmail = new bool[] {false} ;
         BC000111_A62Supplier_AgbPhone = new string[] {""} ;
         BC000111_n62Supplier_AgbPhone = new bool[] {false} ;
         BC000111_A63Supplier_AgbContactName = new string[] {""} ;
         BC000111_n63Supplier_AgbContactName = new bool[] {false} ;
         BC000155_A1CustomerId = new short[1] ;
         BC000155_A18CustomerLocationId = new short[1] ;
         BC000155_A55Supplier_AgbId = new short[1] ;
         BC000110_A1CustomerId = new short[1] ;
         BC000110_A18CustomerLocationId = new short[1] ;
         BC000110_A55Supplier_AgbId = new short[1] ;
         sMode16 = "";
         BC00019_A1CustomerId = new short[1] ;
         BC00019_A18CustomerLocationId = new short[1] ;
         BC00019_A55Supplier_AgbId = new short[1] ;
         BC000158_A56Supplier_AgbNumber = new string[] {""} ;
         BC000158_A57Supplier_AgbName = new string[] {""} ;
         BC000158_A58Supplier_AgbKvkNumber = new string[] {""} ;
         BC000158_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         BC000158_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         BC000158_A60Supplier_AgbPostalAddress = new string[] {""} ;
         BC000158_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         BC000158_A61Supplier_AgbEmail = new string[] {""} ;
         BC000158_n61Supplier_AgbEmail = new bool[] {false} ;
         BC000158_A62Supplier_AgbPhone = new string[] {""} ;
         BC000158_n62Supplier_AgbPhone = new bool[] {false} ;
         BC000158_A63Supplier_AgbContactName = new string[] {""} ;
         BC000158_n63Supplier_AgbContactName = new bool[] {false} ;
         BC000159_A1CustomerId = new short[1] ;
         BC000159_A18CustomerLocationId = new short[1] ;
         BC000159_A56Supplier_AgbNumber = new string[] {""} ;
         BC000159_A57Supplier_AgbName = new string[] {""} ;
         BC000159_A58Supplier_AgbKvkNumber = new string[] {""} ;
         BC000159_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         BC000159_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         BC000159_A60Supplier_AgbPostalAddress = new string[] {""} ;
         BC000159_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         BC000159_A61Supplier_AgbEmail = new string[] {""} ;
         BC000159_n61Supplier_AgbEmail = new bool[] {false} ;
         BC000159_A62Supplier_AgbPhone = new string[] {""} ;
         BC000159_n62Supplier_AgbPhone = new bool[] {false} ;
         BC000159_A63Supplier_AgbContactName = new string[] {""} ;
         BC000159_n63Supplier_AgbContactName = new bool[] {false} ;
         BC000159_A55Supplier_AgbId = new short[1] ;
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
         BC000160_A1CustomerId = new short[1] ;
         BC000160_A18CustomerLocationId = new short[1] ;
         BC000160_A65Supplier_GenKvKNumber = new string[] {""} ;
         BC000160_A66Supplier_GenCompanyName = new string[] {""} ;
         BC000160_A67Supplier_GenVisitingAddress = new string[] {""} ;
         BC000160_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         BC000160_A68Supplier_GenPostalAddress = new string[] {""} ;
         BC000160_n68Supplier_GenPostalAddress = new bool[] {false} ;
         BC000160_A69Supplier_GenContactName = new string[] {""} ;
         BC000160_n69Supplier_GenContactName = new bool[] {false} ;
         BC000160_A70Supplier_GenContactPhone = new string[] {""} ;
         BC000160_n70Supplier_GenContactPhone = new bool[] {false} ;
         BC000160_A64Supplier_GenId = new short[1] ;
         BC00018_A65Supplier_GenKvKNumber = new string[] {""} ;
         BC00018_A66Supplier_GenCompanyName = new string[] {""} ;
         BC00018_A67Supplier_GenVisitingAddress = new string[] {""} ;
         BC00018_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         BC00018_A68Supplier_GenPostalAddress = new string[] {""} ;
         BC00018_n68Supplier_GenPostalAddress = new bool[] {false} ;
         BC00018_A69Supplier_GenContactName = new string[] {""} ;
         BC00018_n69Supplier_GenContactName = new bool[] {false} ;
         BC00018_A70Supplier_GenContactPhone = new string[] {""} ;
         BC00018_n70Supplier_GenContactPhone = new bool[] {false} ;
         BC000161_A1CustomerId = new short[1] ;
         BC000161_A18CustomerLocationId = new short[1] ;
         BC000161_A64Supplier_GenId = new short[1] ;
         BC00017_A1CustomerId = new short[1] ;
         BC00017_A18CustomerLocationId = new short[1] ;
         BC00017_A64Supplier_GenId = new short[1] ;
         sMode17 = "";
         BC00016_A1CustomerId = new short[1] ;
         BC00016_A18CustomerLocationId = new short[1] ;
         BC00016_A64Supplier_GenId = new short[1] ;
         BC000164_A65Supplier_GenKvKNumber = new string[] {""} ;
         BC000164_A66Supplier_GenCompanyName = new string[] {""} ;
         BC000164_A67Supplier_GenVisitingAddress = new string[] {""} ;
         BC000164_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         BC000164_A68Supplier_GenPostalAddress = new string[] {""} ;
         BC000164_n68Supplier_GenPostalAddress = new bool[] {false} ;
         BC000164_A69Supplier_GenContactName = new string[] {""} ;
         BC000164_n69Supplier_GenContactName = new bool[] {false} ;
         BC000164_A70Supplier_GenContactPhone = new string[] {""} ;
         BC000164_n70Supplier_GenContactPhone = new bool[] {false} ;
         BC000165_A1CustomerId = new short[1] ;
         BC000165_A18CustomerLocationId = new short[1] ;
         BC000165_A65Supplier_GenKvKNumber = new string[] {""} ;
         BC000165_A66Supplier_GenCompanyName = new string[] {""} ;
         BC000165_A67Supplier_GenVisitingAddress = new string[] {""} ;
         BC000165_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         BC000165_A68Supplier_GenPostalAddress = new string[] {""} ;
         BC000165_n68Supplier_GenPostalAddress = new bool[] {false} ;
         BC000165_A69Supplier_GenContactName = new string[] {""} ;
         BC000165_n69Supplier_GenContactName = new bool[] {false} ;
         BC000165_A70Supplier_GenContactPhone = new string[] {""} ;
         BC000165_n70Supplier_GenContactPhone = new bool[] {false} ;
         BC000165_A64Supplier_GenId = new short[1] ;
         Z101AmenitiesName = "";
         A101AmenitiesName = "";
         Z100AmenitiesTypeName = "";
         A100AmenitiesTypeName = "";
         BC000166_A1CustomerId = new short[1] ;
         BC000166_A18CustomerLocationId = new short[1] ;
         BC000166_A101AmenitiesName = new string[] {""} ;
         BC000166_A100AmenitiesTypeName = new string[] {""} ;
         BC000166_A98AmenitiesId = new short[1] ;
         BC000166_A99AmenitiesTypeId = new short[1] ;
         BC00014_A101AmenitiesName = new string[] {""} ;
         BC00014_A99AmenitiesTypeId = new short[1] ;
         BC00015_A100AmenitiesTypeName = new string[] {""} ;
         BC000167_A1CustomerId = new short[1] ;
         BC000167_A18CustomerLocationId = new short[1] ;
         BC000167_A98AmenitiesId = new short[1] ;
         BC00013_A1CustomerId = new short[1] ;
         BC00013_A18CustomerLocationId = new short[1] ;
         BC00013_A98AmenitiesId = new short[1] ;
         sMode21 = "";
         BC00012_A1CustomerId = new short[1] ;
         BC00012_A18CustomerLocationId = new short[1] ;
         BC00012_A98AmenitiesId = new short[1] ;
         BC000170_A101AmenitiesName = new string[] {""} ;
         BC000170_A99AmenitiesTypeId = new short[1] ;
         BC000171_A100AmenitiesTypeName = new string[] {""} ;
         BC000172_A1CustomerId = new short[1] ;
         BC000172_A18CustomerLocationId = new short[1] ;
         BC000172_A101AmenitiesName = new string[] {""} ;
         BC000172_A100AmenitiesTypeName = new string[] {""} ;
         BC000172_A98AmenitiesId = new short[1] ;
         BC000172_A99AmenitiesTypeId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.customer_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customer_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1CustomerId, BC00012_A18CustomerLocationId, BC00012_A98AmenitiesId
               }
               , new Object[] {
               BC00013_A1CustomerId, BC00013_A18CustomerLocationId, BC00013_A98AmenitiesId
               }
               , new Object[] {
               BC00014_A101AmenitiesName, BC00014_A99AmenitiesTypeId
               }
               , new Object[] {
               BC00015_A100AmenitiesTypeName
               }
               , new Object[] {
               BC00016_A1CustomerId, BC00016_A18CustomerLocationId, BC00016_A64Supplier_GenId
               }
               , new Object[] {
               BC00017_A1CustomerId, BC00017_A18CustomerLocationId, BC00017_A64Supplier_GenId
               }
               , new Object[] {
               BC00018_A65Supplier_GenKvKNumber, BC00018_A66Supplier_GenCompanyName, BC00018_A67Supplier_GenVisitingAddress, BC00018_n67Supplier_GenVisitingAddress, BC00018_A68Supplier_GenPostalAddress, BC00018_n68Supplier_GenPostalAddress, BC00018_A69Supplier_GenContactName, BC00018_n69Supplier_GenContactName, BC00018_A70Supplier_GenContactPhone, BC00018_n70Supplier_GenContactPhone
               }
               , new Object[] {
               BC00019_A1CustomerId, BC00019_A18CustomerLocationId, BC00019_A55Supplier_AgbId
               }
               , new Object[] {
               BC000110_A1CustomerId, BC000110_A18CustomerLocationId, BC000110_A55Supplier_AgbId
               }
               , new Object[] {
               BC000111_A56Supplier_AgbNumber, BC000111_A57Supplier_AgbName, BC000111_A58Supplier_AgbKvkNumber, BC000111_A59Supplier_AgbVisitingAddress, BC000111_n59Supplier_AgbVisitingAddress, BC000111_A60Supplier_AgbPostalAddress, BC000111_n60Supplier_AgbPostalAddress, BC000111_A61Supplier_AgbEmail, BC000111_n61Supplier_AgbEmail, BC000111_A62Supplier_AgbPhone,
               BC000111_n62Supplier_AgbPhone, BC000111_A63Supplier_AgbContactName, BC000111_n63Supplier_AgbContactName
               }
               , new Object[] {
               BC000112_A1CustomerId, BC000112_A18CustomerLocationId, BC000112_A23CustomerLocationReceptionistId, BC000112_A30CustomerLocationReceptionistGA, BC000112_A26CustomerLocationReceptionistIn, BC000112_n26CustomerLocationReceptionistIn, BC000112_A24CustomerLocationReceptionistGi, BC000112_A25CustomerLocationReceptionistLa, BC000112_A27CustomerLocationReceptionistEm, BC000112_A28CustomerLocationReceptionistAd,
               BC000112_n28CustomerLocationReceptionistAd, BC000112_A29CustomerLocationReceptionistPh
               }
               , new Object[] {
               BC000113_A1CustomerId, BC000113_A18CustomerLocationId, BC000113_A23CustomerLocationReceptionistId, BC000113_A30CustomerLocationReceptionistGA, BC000113_A26CustomerLocationReceptionistIn, BC000113_n26CustomerLocationReceptionistIn, BC000113_A24CustomerLocationReceptionistGi, BC000113_A25CustomerLocationReceptionistLa, BC000113_A27CustomerLocationReceptionistEm, BC000113_A28CustomerLocationReceptionistAd,
               BC000113_n28CustomerLocationReceptionistAd, BC000113_A29CustomerLocationReceptionistPh
               }
               , new Object[] {
               BC000114_A1CustomerId, BC000114_A18CustomerLocationId, BC000114_A19CustomerLocationVisitingAddres, BC000114_A20CustomerLocationPostalAddress, BC000114_A21CustomerLocationEmail, BC000114_A22CustomerLocationPhone, BC000114_A94CustomerLocationLastLine, BC000114_A133CustomerLocationDescription, BC000114_A134CustomerLocationName
               }
               , new Object[] {
               BC000115_A1CustomerId, BC000115_A18CustomerLocationId, BC000115_A19CustomerLocationVisitingAddres, BC000115_A20CustomerLocationPostalAddress, BC000115_A21CustomerLocationEmail, BC000115_A22CustomerLocationPhone, BC000115_A94CustomerLocationLastLine, BC000115_A133CustomerLocationDescription, BC000115_A134CustomerLocationName
               }
               , new Object[] {
               BC000116_A1CustomerId, BC000116_A15CustomerManagerId, BC000116_A13CustomerManagerGAMGUID, BC000116_A17CustomerManagerInitials, BC000116_n17CustomerManagerInitials, BC000116_A16CustomerManagerGivenName, BC000116_A9CustomerManagerLastName, BC000116_A10CustomerManagerEmail, BC000116_A11CustomerManagerPhone, BC000116_n11CustomerManagerPhone,
               BC000116_A12CustomerManagerGender, BC000116_n12CustomerManagerGender
               }
               , new Object[] {
               BC000117_A1CustomerId, BC000117_A15CustomerManagerId, BC000117_A13CustomerManagerGAMGUID, BC000117_A17CustomerManagerInitials, BC000117_n17CustomerManagerInitials, BC000117_A16CustomerManagerGivenName, BC000117_A9CustomerManagerLastName, BC000117_A10CustomerManagerEmail, BC000117_A11CustomerManagerPhone, BC000117_n11CustomerManagerPhone,
               BC000117_A12CustomerManagerGender, BC000117_n12CustomerManagerGender
               }
               , new Object[] {
               BC000118_A1CustomerId, BC000118_A41CustomerKvkNumber, BC000118_A3CustomerName, BC000118_A4CustomerPostalAddress, BC000118_n4CustomerPostalAddress, BC000118_A5CustomerEmail, BC000118_n5CustomerEmail, BC000118_A6CustomerVisitingAddress, BC000118_n6CustomerVisitingAddress, BC000118_A7CustomerPhone,
               BC000118_n7CustomerPhone, BC000118_A14CustomerVatNumber, BC000118_A93CustomerLastLine, BC000118_A95CustomerLastLineLocation, BC000118_A78CustomerTypeId, BC000118_n78CustomerTypeId
               }
               , new Object[] {
               BC000119_A1CustomerId, BC000119_A41CustomerKvkNumber, BC000119_A3CustomerName, BC000119_A4CustomerPostalAddress, BC000119_n4CustomerPostalAddress, BC000119_A5CustomerEmail, BC000119_n5CustomerEmail, BC000119_A6CustomerVisitingAddress, BC000119_n6CustomerVisitingAddress, BC000119_A7CustomerPhone,
               BC000119_n7CustomerPhone, BC000119_A14CustomerVatNumber, BC000119_A93CustomerLastLine, BC000119_A95CustomerLastLineLocation, BC000119_A78CustomerTypeId, BC000119_n78CustomerTypeId
               }
               , new Object[] {
               BC000120_A79CustomerTypeName
               }
               , new Object[] {
               BC000121_A1CustomerId, BC000121_A41CustomerKvkNumber, BC000121_A3CustomerName, BC000121_A4CustomerPostalAddress, BC000121_n4CustomerPostalAddress, BC000121_A5CustomerEmail, BC000121_n5CustomerEmail, BC000121_A6CustomerVisitingAddress, BC000121_n6CustomerVisitingAddress, BC000121_A7CustomerPhone,
               BC000121_n7CustomerPhone, BC000121_A14CustomerVatNumber, BC000121_A79CustomerTypeName, BC000121_A93CustomerLastLine, BC000121_A95CustomerLastLineLocation, BC000121_A78CustomerTypeId, BC000121_n78CustomerTypeId
               }
               , new Object[] {
               BC000122_A1CustomerId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000124_A1CustomerId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000127_A79CustomerTypeName
               }
               , new Object[] {
               BC000128_A128CustomerCustomizationId
               }
               , new Object[] {
               BC000129_A103PageId
               }
               , new Object[] {
               BC000130_A1CustomerId, BC000130_A18CustomerLocationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000132_A1CustomerId, BC000132_A41CustomerKvkNumber, BC000132_A3CustomerName, BC000132_A4CustomerPostalAddress, BC000132_n4CustomerPostalAddress, BC000132_A5CustomerEmail, BC000132_n5CustomerEmail, BC000132_A6CustomerVisitingAddress, BC000132_n6CustomerVisitingAddress, BC000132_A7CustomerPhone,
               BC000132_n7CustomerPhone, BC000132_A14CustomerVatNumber, BC000132_A79CustomerTypeName, BC000132_A93CustomerLastLine, BC000132_A95CustomerLastLineLocation, BC000132_A78CustomerTypeId, BC000132_n78CustomerTypeId
               }
               , new Object[] {
               BC000133_A1CustomerId, BC000133_A15CustomerManagerId, BC000133_A13CustomerManagerGAMGUID, BC000133_A17CustomerManagerInitials, BC000133_n17CustomerManagerInitials, BC000133_A16CustomerManagerGivenName, BC000133_A9CustomerManagerLastName, BC000133_A10CustomerManagerEmail, BC000133_A11CustomerManagerPhone, BC000133_n11CustomerManagerPhone,
               BC000133_A12CustomerManagerGender, BC000133_n12CustomerManagerGender
               }
               , new Object[] {
               BC000134_A1CustomerId, BC000134_A15CustomerManagerId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000138_A1CustomerId, BC000138_A15CustomerManagerId, BC000138_A13CustomerManagerGAMGUID, BC000138_A17CustomerManagerInitials, BC000138_n17CustomerManagerInitials, BC000138_A16CustomerManagerGivenName, BC000138_A9CustomerManagerLastName, BC000138_A10CustomerManagerEmail, BC000138_A11CustomerManagerPhone, BC000138_n11CustomerManagerPhone,
               BC000138_A12CustomerManagerGender, BC000138_n12CustomerManagerGender
               }
               , new Object[] {
               BC000139_A1CustomerId, BC000139_A18CustomerLocationId, BC000139_A19CustomerLocationVisitingAddres, BC000139_A20CustomerLocationPostalAddress, BC000139_A21CustomerLocationEmail, BC000139_A22CustomerLocationPhone, BC000139_A94CustomerLocationLastLine, BC000139_A133CustomerLocationDescription, BC000139_A134CustomerLocationName
               }
               , new Object[] {
               BC000140_A1CustomerId, BC000140_A18CustomerLocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000144_A115LocationEventId
               }
               , new Object[] {
               BC000145_A31ResidentId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000147_A1CustomerId, BC000147_A18CustomerLocationId, BC000147_A19CustomerLocationVisitingAddres, BC000147_A20CustomerLocationPostalAddress, BC000147_A21CustomerLocationEmail, BC000147_A22CustomerLocationPhone, BC000147_A94CustomerLocationLastLine, BC000147_A133CustomerLocationDescription, BC000147_A134CustomerLocationName
               }
               , new Object[] {
               BC000148_A1CustomerId, BC000148_A18CustomerLocationId, BC000148_A23CustomerLocationReceptionistId, BC000148_A30CustomerLocationReceptionistGA, BC000148_A26CustomerLocationReceptionistIn, BC000148_n26CustomerLocationReceptionistIn, BC000148_A24CustomerLocationReceptionistGi, BC000148_A25CustomerLocationReceptionistLa, BC000148_A27CustomerLocationReceptionistEm, BC000148_A28CustomerLocationReceptionistAd,
               BC000148_n28CustomerLocationReceptionistAd, BC000148_A29CustomerLocationReceptionistPh
               }
               , new Object[] {
               BC000149_A1CustomerId, BC000149_A18CustomerLocationId, BC000149_A23CustomerLocationReceptionistId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000153_A1CustomerId, BC000153_A18CustomerLocationId, BC000153_A23CustomerLocationReceptionistId, BC000153_A30CustomerLocationReceptionistGA, BC000153_A26CustomerLocationReceptionistIn, BC000153_n26CustomerLocationReceptionistIn, BC000153_A24CustomerLocationReceptionistGi, BC000153_A25CustomerLocationReceptionistLa, BC000153_A27CustomerLocationReceptionistEm, BC000153_A28CustomerLocationReceptionistAd,
               BC000153_n28CustomerLocationReceptionistAd, BC000153_A29CustomerLocationReceptionistPh
               }
               , new Object[] {
               BC000154_A1CustomerId, BC000154_A18CustomerLocationId, BC000154_A56Supplier_AgbNumber, BC000154_A57Supplier_AgbName, BC000154_A58Supplier_AgbKvkNumber, BC000154_A59Supplier_AgbVisitingAddress, BC000154_n59Supplier_AgbVisitingAddress, BC000154_A60Supplier_AgbPostalAddress, BC000154_n60Supplier_AgbPostalAddress, BC000154_A61Supplier_AgbEmail,
               BC000154_n61Supplier_AgbEmail, BC000154_A62Supplier_AgbPhone, BC000154_n62Supplier_AgbPhone, BC000154_A63Supplier_AgbContactName, BC000154_n63Supplier_AgbContactName, BC000154_A55Supplier_AgbId
               }
               , new Object[] {
               BC000155_A1CustomerId, BC000155_A18CustomerLocationId, BC000155_A55Supplier_AgbId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000158_A56Supplier_AgbNumber, BC000158_A57Supplier_AgbName, BC000158_A58Supplier_AgbKvkNumber, BC000158_A59Supplier_AgbVisitingAddress, BC000158_n59Supplier_AgbVisitingAddress, BC000158_A60Supplier_AgbPostalAddress, BC000158_n60Supplier_AgbPostalAddress, BC000158_A61Supplier_AgbEmail, BC000158_n61Supplier_AgbEmail, BC000158_A62Supplier_AgbPhone,
               BC000158_n62Supplier_AgbPhone, BC000158_A63Supplier_AgbContactName, BC000158_n63Supplier_AgbContactName
               }
               , new Object[] {
               BC000159_A1CustomerId, BC000159_A18CustomerLocationId, BC000159_A56Supplier_AgbNumber, BC000159_A57Supplier_AgbName, BC000159_A58Supplier_AgbKvkNumber, BC000159_A59Supplier_AgbVisitingAddress, BC000159_n59Supplier_AgbVisitingAddress, BC000159_A60Supplier_AgbPostalAddress, BC000159_n60Supplier_AgbPostalAddress, BC000159_A61Supplier_AgbEmail,
               BC000159_n61Supplier_AgbEmail, BC000159_A62Supplier_AgbPhone, BC000159_n62Supplier_AgbPhone, BC000159_A63Supplier_AgbContactName, BC000159_n63Supplier_AgbContactName, BC000159_A55Supplier_AgbId
               }
               , new Object[] {
               BC000160_A1CustomerId, BC000160_A18CustomerLocationId, BC000160_A65Supplier_GenKvKNumber, BC000160_A66Supplier_GenCompanyName, BC000160_A67Supplier_GenVisitingAddress, BC000160_n67Supplier_GenVisitingAddress, BC000160_A68Supplier_GenPostalAddress, BC000160_n68Supplier_GenPostalAddress, BC000160_A69Supplier_GenContactName, BC000160_n69Supplier_GenContactName,
               BC000160_A70Supplier_GenContactPhone, BC000160_n70Supplier_GenContactPhone, BC000160_A64Supplier_GenId
               }
               , new Object[] {
               BC000161_A1CustomerId, BC000161_A18CustomerLocationId, BC000161_A64Supplier_GenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000164_A65Supplier_GenKvKNumber, BC000164_A66Supplier_GenCompanyName, BC000164_A67Supplier_GenVisitingAddress, BC000164_n67Supplier_GenVisitingAddress, BC000164_A68Supplier_GenPostalAddress, BC000164_n68Supplier_GenPostalAddress, BC000164_A69Supplier_GenContactName, BC000164_n69Supplier_GenContactName, BC000164_A70Supplier_GenContactPhone, BC000164_n70Supplier_GenContactPhone
               }
               , new Object[] {
               BC000165_A1CustomerId, BC000165_A18CustomerLocationId, BC000165_A65Supplier_GenKvKNumber, BC000165_A66Supplier_GenCompanyName, BC000165_A67Supplier_GenVisitingAddress, BC000165_n67Supplier_GenVisitingAddress, BC000165_A68Supplier_GenPostalAddress, BC000165_n68Supplier_GenPostalAddress, BC000165_A69Supplier_GenContactName, BC000165_n69Supplier_GenContactName,
               BC000165_A70Supplier_GenContactPhone, BC000165_n70Supplier_GenContactPhone, BC000165_A64Supplier_GenId
               }
               , new Object[] {
               BC000166_A1CustomerId, BC000166_A18CustomerLocationId, BC000166_A101AmenitiesName, BC000166_A100AmenitiesTypeName, BC000166_A98AmenitiesId, BC000166_A99AmenitiesTypeId
               }
               , new Object[] {
               BC000167_A1CustomerId, BC000167_A18CustomerLocationId, BC000167_A98AmenitiesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000170_A101AmenitiesName, BC000170_A99AmenitiesTypeId
               }
               , new Object[] {
               BC000171_A100AmenitiesTypeName
               }
               , new Object[] {
               BC000172_A1CustomerId, BC000172_A18CustomerLocationId, BC000172_A101AmenitiesName, BC000172_A100AmenitiesTypeName, BC000172_A98AmenitiesId, BC000172_A99AmenitiesTypeId
               }
            }
         );
         AV29Pgmname = "Customer_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z1CustomerId ;
      private short A1CustomerId ;
      private short nIsMod_21 ;
      private short RcdFound21 ;
      private short nIsMod_17 ;
      private short RcdFound17 ;
      private short nIsMod_16 ;
      private short RcdFound16 ;
      private short s94CustomerLocationLastLine ;
      private short O94CustomerLocationLastLine ;
      private short A94CustomerLocationLastLine ;
      private short nIsMod_4 ;
      private short RcdFound4 ;
      private short s95CustomerLastLineLocation ;
      private short O95CustomerLastLineLocation ;
      private short A95CustomerLastLineLocation ;
      private short nIsMod_3 ;
      private short RcdFound3 ;
      private short s93CustomerLastLine ;
      private short O93CustomerLastLine ;
      private short A93CustomerLastLine ;
      private short nIsMod_2 ;
      private short RcdFound2 ;
      private short AV13Insert_CustomerTypeId ;
      private short Z93CustomerLastLine ;
      private short Z95CustomerLastLineLocation ;
      private short Z78CustomerTypeId ;
      private short A78CustomerTypeId ;
      private short RcdFound1 ;
      private short nRcdExists_2 ;
      private short nRcdExists_3 ;
      private short Z15CustomerManagerId ;
      private short A15CustomerManagerId ;
      private short Gx_BScreen ;
      private short Gxremove2 ;
      private short Z94CustomerLocationLastLine ;
      private short Z18CustomerLocationId ;
      private short A18CustomerLocationId ;
      private short nRcdExists_4 ;
      private short nRcdExists_16 ;
      private short nRcdExists_17 ;
      private short nRcdExists_21 ;
      private short Z23CustomerLocationReceptionistId ;
      private short A23CustomerLocationReceptionistId ;
      private short Gxremove4 ;
      private short Z55Supplier_AgbId ;
      private short A55Supplier_AgbId ;
      private short Gxremove16 ;
      private short Z64Supplier_GenId ;
      private short A64Supplier_GenId ;
      private short Gxremove17 ;
      private short Z99AmenitiesTypeId ;
      private short A99AmenitiesTypeId ;
      private short Z98AmenitiesId ;
      private short A98AmenitiesId ;
      private short Gxremove21 ;
      private short Gxremove3 ;
      private short i93CustomerLastLine ;
      private short i95CustomerLastLineLocation ;
      private short i94CustomerLocationLastLine ;
      private int trnEnded ;
      private int nGXsfl_21_idx=1 ;
      private int nGXsfl_3_idx=1 ;
      private int nGXsfl_17_idx=1 ;
      private int nGXsfl_16_idx=1 ;
      private int nGXsfl_4_idx=1 ;
      private int nGXsfl_2_idx=1 ;
      private int AV30GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode1 ;
      private string sMode3 ;
      private string AV29Pgmname ;
      private string Z7CustomerPhone ;
      private string A7CustomerPhone ;
      private string Z17CustomerManagerInitials ;
      private string A17CustomerManagerInitials ;
      private string Z11CustomerManagerPhone ;
      private string A11CustomerManagerPhone ;
      private string Z12CustomerManagerGender ;
      private string A12CustomerManagerGender ;
      private string sMode2 ;
      private string Z22CustomerLocationPhone ;
      private string A22CustomerLocationPhone ;
      private string Z26CustomerLocationReceptionistIn ;
      private string A26CustomerLocationReceptionistIn ;
      private string Z29CustomerLocationReceptionistPh ;
      private string A29CustomerLocationReceptionistPh ;
      private string sMode4 ;
      private string Z62Supplier_AgbPhone ;
      private string A62Supplier_AgbPhone ;
      private string sMode16 ;
      private string Z70Supplier_GenContactPhone ;
      private string A70Supplier_GenContactPhone ;
      private string sMode17 ;
      private string sMode21 ;
      private bool returnInSub ;
      private bool n4CustomerPostalAddress ;
      private bool n5CustomerEmail ;
      private bool n6CustomerVisitingAddress ;
      private bool n7CustomerPhone ;
      private bool n78CustomerTypeId ;
      private bool Gx_longc ;
      private bool n17CustomerManagerInitials ;
      private bool n11CustomerManagerPhone ;
      private bool n12CustomerManagerGender ;
      private bool n26CustomerLocationReceptionistIn ;
      private bool n28CustomerLocationReceptionistAd ;
      private bool n59Supplier_AgbVisitingAddress ;
      private bool n60Supplier_AgbPostalAddress ;
      private bool n61Supplier_AgbEmail ;
      private bool n62Supplier_AgbPhone ;
      private bool n63Supplier_AgbContactName ;
      private bool n67Supplier_GenVisitingAddress ;
      private bool n68Supplier_GenPostalAddress ;
      private bool n69Supplier_GenContactName ;
      private bool n70Supplier_GenContactPhone ;
      private string Z41CustomerKvkNumber ;
      private string A41CustomerKvkNumber ;
      private string Z3CustomerName ;
      private string A3CustomerName ;
      private string Z4CustomerPostalAddress ;
      private string A4CustomerPostalAddress ;
      private string Z5CustomerEmail ;
      private string A5CustomerEmail ;
      private string Z6CustomerVisitingAddress ;
      private string A6CustomerVisitingAddress ;
      private string Z14CustomerVatNumber ;
      private string A14CustomerVatNumber ;
      private string Z79CustomerTypeName ;
      private string A79CustomerTypeName ;
      private string Z13CustomerManagerGAMGUID ;
      private string A13CustomerManagerGAMGUID ;
      private string Z16CustomerManagerGivenName ;
      private string A16CustomerManagerGivenName ;
      private string Z9CustomerManagerLastName ;
      private string A9CustomerManagerLastName ;
      private string Z10CustomerManagerEmail ;
      private string A10CustomerManagerEmail ;
      private string Z19CustomerLocationVisitingAddres ;
      private string A19CustomerLocationVisitingAddres ;
      private string Z20CustomerLocationPostalAddress ;
      private string A20CustomerLocationPostalAddress ;
      private string Z21CustomerLocationEmail ;
      private string A21CustomerLocationEmail ;
      private string Z133CustomerLocationDescription ;
      private string A133CustomerLocationDescription ;
      private string Z134CustomerLocationName ;
      private string A134CustomerLocationName ;
      private string Z30CustomerLocationReceptionistGA ;
      private string A30CustomerLocationReceptionistGA ;
      private string Z24CustomerLocationReceptionistGi ;
      private string A24CustomerLocationReceptionistGi ;
      private string Z25CustomerLocationReceptionistLa ;
      private string A25CustomerLocationReceptionistLa ;
      private string Z27CustomerLocationReceptionistEm ;
      private string A27CustomerLocationReceptionistEm ;
      private string Z28CustomerLocationReceptionistAd ;
      private string A28CustomerLocationReceptionistAd ;
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
      private string Z101AmenitiesName ;
      private string A101AmenitiesName ;
      private string Z100AmenitiesTypeName ;
      private string A100AmenitiesTypeName ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtCustomer bcCustomer ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] BC000121_A1CustomerId ;
      private string[] BC000121_A41CustomerKvkNumber ;
      private string[] BC000121_A3CustomerName ;
      private string[] BC000121_A4CustomerPostalAddress ;
      private bool[] BC000121_n4CustomerPostalAddress ;
      private string[] BC000121_A5CustomerEmail ;
      private bool[] BC000121_n5CustomerEmail ;
      private string[] BC000121_A6CustomerVisitingAddress ;
      private bool[] BC000121_n6CustomerVisitingAddress ;
      private string[] BC000121_A7CustomerPhone ;
      private bool[] BC000121_n7CustomerPhone ;
      private string[] BC000121_A14CustomerVatNumber ;
      private string[] BC000121_A79CustomerTypeName ;
      private short[] BC000121_A93CustomerLastLine ;
      private short[] BC000121_A95CustomerLastLineLocation ;
      private short[] BC000121_A78CustomerTypeId ;
      private bool[] BC000121_n78CustomerTypeId ;
      private string[] BC000120_A79CustomerTypeName ;
      private short[] BC000122_A1CustomerId ;
      private short[] BC000119_A1CustomerId ;
      private string[] BC000119_A41CustomerKvkNumber ;
      private string[] BC000119_A3CustomerName ;
      private string[] BC000119_A4CustomerPostalAddress ;
      private bool[] BC000119_n4CustomerPostalAddress ;
      private string[] BC000119_A5CustomerEmail ;
      private bool[] BC000119_n5CustomerEmail ;
      private string[] BC000119_A6CustomerVisitingAddress ;
      private bool[] BC000119_n6CustomerVisitingAddress ;
      private string[] BC000119_A7CustomerPhone ;
      private bool[] BC000119_n7CustomerPhone ;
      private string[] BC000119_A14CustomerVatNumber ;
      private short[] BC000119_A93CustomerLastLine ;
      private short[] BC000119_A95CustomerLastLineLocation ;
      private short[] BC000119_A78CustomerTypeId ;
      private bool[] BC000119_n78CustomerTypeId ;
      private short[] BC000118_A1CustomerId ;
      private string[] BC000118_A41CustomerKvkNumber ;
      private string[] BC000118_A3CustomerName ;
      private string[] BC000118_A4CustomerPostalAddress ;
      private bool[] BC000118_n4CustomerPostalAddress ;
      private string[] BC000118_A5CustomerEmail ;
      private bool[] BC000118_n5CustomerEmail ;
      private string[] BC000118_A6CustomerVisitingAddress ;
      private bool[] BC000118_n6CustomerVisitingAddress ;
      private string[] BC000118_A7CustomerPhone ;
      private bool[] BC000118_n7CustomerPhone ;
      private string[] BC000118_A14CustomerVatNumber ;
      private short[] BC000118_A93CustomerLastLine ;
      private short[] BC000118_A95CustomerLastLineLocation ;
      private short[] BC000118_A78CustomerTypeId ;
      private bool[] BC000118_n78CustomerTypeId ;
      private short[] BC000124_A1CustomerId ;
      private string[] BC000127_A79CustomerTypeName ;
      private short[] BC000128_A128CustomerCustomizationId ;
      private short[] BC000129_A103PageId ;
      private short[] BC000130_A1CustomerId ;
      private short[] BC000130_A18CustomerLocationId ;
      private short[] BC000132_A1CustomerId ;
      private string[] BC000132_A41CustomerKvkNumber ;
      private string[] BC000132_A3CustomerName ;
      private string[] BC000132_A4CustomerPostalAddress ;
      private bool[] BC000132_n4CustomerPostalAddress ;
      private string[] BC000132_A5CustomerEmail ;
      private bool[] BC000132_n5CustomerEmail ;
      private string[] BC000132_A6CustomerVisitingAddress ;
      private bool[] BC000132_n6CustomerVisitingAddress ;
      private string[] BC000132_A7CustomerPhone ;
      private bool[] BC000132_n7CustomerPhone ;
      private string[] BC000132_A14CustomerVatNumber ;
      private string[] BC000132_A79CustomerTypeName ;
      private short[] BC000132_A93CustomerLastLine ;
      private short[] BC000132_A95CustomerLastLineLocation ;
      private short[] BC000132_A78CustomerTypeId ;
      private bool[] BC000132_n78CustomerTypeId ;
      private short[] BC000133_A1CustomerId ;
      private short[] BC000133_A15CustomerManagerId ;
      private string[] BC000133_A13CustomerManagerGAMGUID ;
      private string[] BC000133_A17CustomerManagerInitials ;
      private bool[] BC000133_n17CustomerManagerInitials ;
      private string[] BC000133_A16CustomerManagerGivenName ;
      private string[] BC000133_A9CustomerManagerLastName ;
      private string[] BC000133_A10CustomerManagerEmail ;
      private string[] BC000133_A11CustomerManagerPhone ;
      private bool[] BC000133_n11CustomerManagerPhone ;
      private string[] BC000133_A12CustomerManagerGender ;
      private bool[] BC000133_n12CustomerManagerGender ;
      private short[] BC000134_A1CustomerId ;
      private short[] BC000134_A15CustomerManagerId ;
      private short[] BC000117_A1CustomerId ;
      private short[] BC000117_A15CustomerManagerId ;
      private string[] BC000117_A13CustomerManagerGAMGUID ;
      private string[] BC000117_A17CustomerManagerInitials ;
      private bool[] BC000117_n17CustomerManagerInitials ;
      private string[] BC000117_A16CustomerManagerGivenName ;
      private string[] BC000117_A9CustomerManagerLastName ;
      private string[] BC000117_A10CustomerManagerEmail ;
      private string[] BC000117_A11CustomerManagerPhone ;
      private bool[] BC000117_n11CustomerManagerPhone ;
      private string[] BC000117_A12CustomerManagerGender ;
      private bool[] BC000117_n12CustomerManagerGender ;
      private short[] BC000116_A1CustomerId ;
      private short[] BC000116_A15CustomerManagerId ;
      private string[] BC000116_A13CustomerManagerGAMGUID ;
      private string[] BC000116_A17CustomerManagerInitials ;
      private bool[] BC000116_n17CustomerManagerInitials ;
      private string[] BC000116_A16CustomerManagerGivenName ;
      private string[] BC000116_A9CustomerManagerLastName ;
      private string[] BC000116_A10CustomerManagerEmail ;
      private string[] BC000116_A11CustomerManagerPhone ;
      private bool[] BC000116_n11CustomerManagerPhone ;
      private string[] BC000116_A12CustomerManagerGender ;
      private bool[] BC000116_n12CustomerManagerGender ;
      private short[] BC000138_A1CustomerId ;
      private short[] BC000138_A15CustomerManagerId ;
      private string[] BC000138_A13CustomerManagerGAMGUID ;
      private string[] BC000138_A17CustomerManagerInitials ;
      private bool[] BC000138_n17CustomerManagerInitials ;
      private string[] BC000138_A16CustomerManagerGivenName ;
      private string[] BC000138_A9CustomerManagerLastName ;
      private string[] BC000138_A10CustomerManagerEmail ;
      private string[] BC000138_A11CustomerManagerPhone ;
      private bool[] BC000138_n11CustomerManagerPhone ;
      private string[] BC000138_A12CustomerManagerGender ;
      private bool[] BC000138_n12CustomerManagerGender ;
      private short[] BC000139_A1CustomerId ;
      private short[] BC000139_A18CustomerLocationId ;
      private string[] BC000139_A19CustomerLocationVisitingAddres ;
      private string[] BC000139_A20CustomerLocationPostalAddress ;
      private string[] BC000139_A21CustomerLocationEmail ;
      private string[] BC000139_A22CustomerLocationPhone ;
      private short[] BC000139_A94CustomerLocationLastLine ;
      private string[] BC000139_A133CustomerLocationDescription ;
      private string[] BC000139_A134CustomerLocationName ;
      private short[] BC000140_A1CustomerId ;
      private short[] BC000140_A18CustomerLocationId ;
      private short[] BC000115_A1CustomerId ;
      private short[] BC000115_A18CustomerLocationId ;
      private string[] BC000115_A19CustomerLocationVisitingAddres ;
      private string[] BC000115_A20CustomerLocationPostalAddress ;
      private string[] BC000115_A21CustomerLocationEmail ;
      private string[] BC000115_A22CustomerLocationPhone ;
      private short[] BC000115_A94CustomerLocationLastLine ;
      private string[] BC000115_A133CustomerLocationDescription ;
      private string[] BC000115_A134CustomerLocationName ;
      private short[] BC000114_A1CustomerId ;
      private short[] BC000114_A18CustomerLocationId ;
      private string[] BC000114_A19CustomerLocationVisitingAddres ;
      private string[] BC000114_A20CustomerLocationPostalAddress ;
      private string[] BC000114_A21CustomerLocationEmail ;
      private string[] BC000114_A22CustomerLocationPhone ;
      private short[] BC000114_A94CustomerLocationLastLine ;
      private string[] BC000114_A133CustomerLocationDescription ;
      private string[] BC000114_A134CustomerLocationName ;
      private short[] BC000144_A115LocationEventId ;
      private short[] BC000145_A31ResidentId ;
      private short[] BC000147_A1CustomerId ;
      private short[] BC000147_A18CustomerLocationId ;
      private string[] BC000147_A19CustomerLocationVisitingAddres ;
      private string[] BC000147_A20CustomerLocationPostalAddress ;
      private string[] BC000147_A21CustomerLocationEmail ;
      private string[] BC000147_A22CustomerLocationPhone ;
      private short[] BC000147_A94CustomerLocationLastLine ;
      private string[] BC000147_A133CustomerLocationDescription ;
      private string[] BC000147_A134CustomerLocationName ;
      private short[] BC000148_A1CustomerId ;
      private short[] BC000148_A18CustomerLocationId ;
      private short[] BC000148_A23CustomerLocationReceptionistId ;
      private string[] BC000148_A30CustomerLocationReceptionistGA ;
      private string[] BC000148_A26CustomerLocationReceptionistIn ;
      private bool[] BC000148_n26CustomerLocationReceptionistIn ;
      private string[] BC000148_A24CustomerLocationReceptionistGi ;
      private string[] BC000148_A25CustomerLocationReceptionistLa ;
      private string[] BC000148_A27CustomerLocationReceptionistEm ;
      private string[] BC000148_A28CustomerLocationReceptionistAd ;
      private bool[] BC000148_n28CustomerLocationReceptionistAd ;
      private string[] BC000148_A29CustomerLocationReceptionistPh ;
      private short[] BC000149_A1CustomerId ;
      private short[] BC000149_A18CustomerLocationId ;
      private short[] BC000149_A23CustomerLocationReceptionistId ;
      private short[] BC000113_A1CustomerId ;
      private short[] BC000113_A18CustomerLocationId ;
      private short[] BC000113_A23CustomerLocationReceptionistId ;
      private string[] BC000113_A30CustomerLocationReceptionistGA ;
      private string[] BC000113_A26CustomerLocationReceptionistIn ;
      private bool[] BC000113_n26CustomerLocationReceptionistIn ;
      private string[] BC000113_A24CustomerLocationReceptionistGi ;
      private string[] BC000113_A25CustomerLocationReceptionistLa ;
      private string[] BC000113_A27CustomerLocationReceptionistEm ;
      private string[] BC000113_A28CustomerLocationReceptionistAd ;
      private bool[] BC000113_n28CustomerLocationReceptionistAd ;
      private string[] BC000113_A29CustomerLocationReceptionistPh ;
      private short[] BC000112_A1CustomerId ;
      private short[] BC000112_A18CustomerLocationId ;
      private short[] BC000112_A23CustomerLocationReceptionistId ;
      private string[] BC000112_A30CustomerLocationReceptionistGA ;
      private string[] BC000112_A26CustomerLocationReceptionistIn ;
      private bool[] BC000112_n26CustomerLocationReceptionistIn ;
      private string[] BC000112_A24CustomerLocationReceptionistGi ;
      private string[] BC000112_A25CustomerLocationReceptionistLa ;
      private string[] BC000112_A27CustomerLocationReceptionistEm ;
      private string[] BC000112_A28CustomerLocationReceptionistAd ;
      private bool[] BC000112_n28CustomerLocationReceptionistAd ;
      private string[] BC000112_A29CustomerLocationReceptionistPh ;
      private short[] BC000153_A1CustomerId ;
      private short[] BC000153_A18CustomerLocationId ;
      private short[] BC000153_A23CustomerLocationReceptionistId ;
      private string[] BC000153_A30CustomerLocationReceptionistGA ;
      private string[] BC000153_A26CustomerLocationReceptionistIn ;
      private bool[] BC000153_n26CustomerLocationReceptionistIn ;
      private string[] BC000153_A24CustomerLocationReceptionistGi ;
      private string[] BC000153_A25CustomerLocationReceptionistLa ;
      private string[] BC000153_A27CustomerLocationReceptionistEm ;
      private string[] BC000153_A28CustomerLocationReceptionistAd ;
      private bool[] BC000153_n28CustomerLocationReceptionistAd ;
      private string[] BC000153_A29CustomerLocationReceptionistPh ;
      private short[] BC000154_A1CustomerId ;
      private short[] BC000154_A18CustomerLocationId ;
      private string[] BC000154_A56Supplier_AgbNumber ;
      private string[] BC000154_A57Supplier_AgbName ;
      private string[] BC000154_A58Supplier_AgbKvkNumber ;
      private string[] BC000154_A59Supplier_AgbVisitingAddress ;
      private bool[] BC000154_n59Supplier_AgbVisitingAddress ;
      private string[] BC000154_A60Supplier_AgbPostalAddress ;
      private bool[] BC000154_n60Supplier_AgbPostalAddress ;
      private string[] BC000154_A61Supplier_AgbEmail ;
      private bool[] BC000154_n61Supplier_AgbEmail ;
      private string[] BC000154_A62Supplier_AgbPhone ;
      private bool[] BC000154_n62Supplier_AgbPhone ;
      private string[] BC000154_A63Supplier_AgbContactName ;
      private bool[] BC000154_n63Supplier_AgbContactName ;
      private short[] BC000154_A55Supplier_AgbId ;
      private string[] BC000111_A56Supplier_AgbNumber ;
      private string[] BC000111_A57Supplier_AgbName ;
      private string[] BC000111_A58Supplier_AgbKvkNumber ;
      private string[] BC000111_A59Supplier_AgbVisitingAddress ;
      private bool[] BC000111_n59Supplier_AgbVisitingAddress ;
      private string[] BC000111_A60Supplier_AgbPostalAddress ;
      private bool[] BC000111_n60Supplier_AgbPostalAddress ;
      private string[] BC000111_A61Supplier_AgbEmail ;
      private bool[] BC000111_n61Supplier_AgbEmail ;
      private string[] BC000111_A62Supplier_AgbPhone ;
      private bool[] BC000111_n62Supplier_AgbPhone ;
      private string[] BC000111_A63Supplier_AgbContactName ;
      private bool[] BC000111_n63Supplier_AgbContactName ;
      private short[] BC000155_A1CustomerId ;
      private short[] BC000155_A18CustomerLocationId ;
      private short[] BC000155_A55Supplier_AgbId ;
      private short[] BC000110_A1CustomerId ;
      private short[] BC000110_A18CustomerLocationId ;
      private short[] BC000110_A55Supplier_AgbId ;
      private short[] BC00019_A1CustomerId ;
      private short[] BC00019_A18CustomerLocationId ;
      private short[] BC00019_A55Supplier_AgbId ;
      private string[] BC000158_A56Supplier_AgbNumber ;
      private string[] BC000158_A57Supplier_AgbName ;
      private string[] BC000158_A58Supplier_AgbKvkNumber ;
      private string[] BC000158_A59Supplier_AgbVisitingAddress ;
      private bool[] BC000158_n59Supplier_AgbVisitingAddress ;
      private string[] BC000158_A60Supplier_AgbPostalAddress ;
      private bool[] BC000158_n60Supplier_AgbPostalAddress ;
      private string[] BC000158_A61Supplier_AgbEmail ;
      private bool[] BC000158_n61Supplier_AgbEmail ;
      private string[] BC000158_A62Supplier_AgbPhone ;
      private bool[] BC000158_n62Supplier_AgbPhone ;
      private string[] BC000158_A63Supplier_AgbContactName ;
      private bool[] BC000158_n63Supplier_AgbContactName ;
      private short[] BC000159_A1CustomerId ;
      private short[] BC000159_A18CustomerLocationId ;
      private string[] BC000159_A56Supplier_AgbNumber ;
      private string[] BC000159_A57Supplier_AgbName ;
      private string[] BC000159_A58Supplier_AgbKvkNumber ;
      private string[] BC000159_A59Supplier_AgbVisitingAddress ;
      private bool[] BC000159_n59Supplier_AgbVisitingAddress ;
      private string[] BC000159_A60Supplier_AgbPostalAddress ;
      private bool[] BC000159_n60Supplier_AgbPostalAddress ;
      private string[] BC000159_A61Supplier_AgbEmail ;
      private bool[] BC000159_n61Supplier_AgbEmail ;
      private string[] BC000159_A62Supplier_AgbPhone ;
      private bool[] BC000159_n62Supplier_AgbPhone ;
      private string[] BC000159_A63Supplier_AgbContactName ;
      private bool[] BC000159_n63Supplier_AgbContactName ;
      private short[] BC000159_A55Supplier_AgbId ;
      private short[] BC000160_A1CustomerId ;
      private short[] BC000160_A18CustomerLocationId ;
      private string[] BC000160_A65Supplier_GenKvKNumber ;
      private string[] BC000160_A66Supplier_GenCompanyName ;
      private string[] BC000160_A67Supplier_GenVisitingAddress ;
      private bool[] BC000160_n67Supplier_GenVisitingAddress ;
      private string[] BC000160_A68Supplier_GenPostalAddress ;
      private bool[] BC000160_n68Supplier_GenPostalAddress ;
      private string[] BC000160_A69Supplier_GenContactName ;
      private bool[] BC000160_n69Supplier_GenContactName ;
      private string[] BC000160_A70Supplier_GenContactPhone ;
      private bool[] BC000160_n70Supplier_GenContactPhone ;
      private short[] BC000160_A64Supplier_GenId ;
      private string[] BC00018_A65Supplier_GenKvKNumber ;
      private string[] BC00018_A66Supplier_GenCompanyName ;
      private string[] BC00018_A67Supplier_GenVisitingAddress ;
      private bool[] BC00018_n67Supplier_GenVisitingAddress ;
      private string[] BC00018_A68Supplier_GenPostalAddress ;
      private bool[] BC00018_n68Supplier_GenPostalAddress ;
      private string[] BC00018_A69Supplier_GenContactName ;
      private bool[] BC00018_n69Supplier_GenContactName ;
      private string[] BC00018_A70Supplier_GenContactPhone ;
      private bool[] BC00018_n70Supplier_GenContactPhone ;
      private short[] BC000161_A1CustomerId ;
      private short[] BC000161_A18CustomerLocationId ;
      private short[] BC000161_A64Supplier_GenId ;
      private short[] BC00017_A1CustomerId ;
      private short[] BC00017_A18CustomerLocationId ;
      private short[] BC00017_A64Supplier_GenId ;
      private short[] BC00016_A1CustomerId ;
      private short[] BC00016_A18CustomerLocationId ;
      private short[] BC00016_A64Supplier_GenId ;
      private string[] BC000164_A65Supplier_GenKvKNumber ;
      private string[] BC000164_A66Supplier_GenCompanyName ;
      private string[] BC000164_A67Supplier_GenVisitingAddress ;
      private bool[] BC000164_n67Supplier_GenVisitingAddress ;
      private string[] BC000164_A68Supplier_GenPostalAddress ;
      private bool[] BC000164_n68Supplier_GenPostalAddress ;
      private string[] BC000164_A69Supplier_GenContactName ;
      private bool[] BC000164_n69Supplier_GenContactName ;
      private string[] BC000164_A70Supplier_GenContactPhone ;
      private bool[] BC000164_n70Supplier_GenContactPhone ;
      private short[] BC000165_A1CustomerId ;
      private short[] BC000165_A18CustomerLocationId ;
      private string[] BC000165_A65Supplier_GenKvKNumber ;
      private string[] BC000165_A66Supplier_GenCompanyName ;
      private string[] BC000165_A67Supplier_GenVisitingAddress ;
      private bool[] BC000165_n67Supplier_GenVisitingAddress ;
      private string[] BC000165_A68Supplier_GenPostalAddress ;
      private bool[] BC000165_n68Supplier_GenPostalAddress ;
      private string[] BC000165_A69Supplier_GenContactName ;
      private bool[] BC000165_n69Supplier_GenContactName ;
      private string[] BC000165_A70Supplier_GenContactPhone ;
      private bool[] BC000165_n70Supplier_GenContactPhone ;
      private short[] BC000165_A64Supplier_GenId ;
      private short[] BC000166_A1CustomerId ;
      private short[] BC000166_A18CustomerLocationId ;
      private string[] BC000166_A101AmenitiesName ;
      private string[] BC000166_A100AmenitiesTypeName ;
      private short[] BC000166_A98AmenitiesId ;
      private short[] BC000166_A99AmenitiesTypeId ;
      private string[] BC00014_A101AmenitiesName ;
      private short[] BC00014_A99AmenitiesTypeId ;
      private string[] BC00015_A100AmenitiesTypeName ;
      private short[] BC000167_A1CustomerId ;
      private short[] BC000167_A18CustomerLocationId ;
      private short[] BC000167_A98AmenitiesId ;
      private short[] BC00013_A1CustomerId ;
      private short[] BC00013_A18CustomerLocationId ;
      private short[] BC00013_A98AmenitiesId ;
      private short[] BC00012_A1CustomerId ;
      private short[] BC00012_A18CustomerLocationId ;
      private short[] BC00012_A98AmenitiesId ;
      private string[] BC000170_A101AmenitiesName ;
      private short[] BC000170_A99AmenitiesTypeId ;
      private string[] BC000171_A100AmenitiesTypeName ;
      private short[] BC000172_A1CustomerId ;
      private short[] BC000172_A18CustomerLocationId ;
      private string[] BC000172_A101AmenitiesName ;
      private string[] BC000172_A100AmenitiesTypeName ;
      private short[] BC000172_A98AmenitiesId ;
      private short[] BC000172_A99AmenitiesTypeId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class customer_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class customer_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new UpdateCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new UpdateCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new UpdateCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new UpdateCursor(def[39])
       ,new UpdateCursor(def[40])
       ,new UpdateCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new UpdateCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new UpdateCursor(def[48])
       ,new UpdateCursor(def[49])
       ,new UpdateCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
       ,new UpdateCursor(def[54])
       ,new UpdateCursor(def[55])
       ,new ForEachCursor(def[56])
       ,new ForEachCursor(def[57])
       ,new ForEachCursor(def[58])
       ,new ForEachCursor(def[59])
       ,new UpdateCursor(def[60])
       ,new UpdateCursor(def[61])
       ,new ForEachCursor(def[62])
       ,new ForEachCursor(def[63])
       ,new ForEachCursor(def[64])
       ,new ForEachCursor(def[65])
       ,new UpdateCursor(def[66])
       ,new UpdateCursor(def[67])
       ,new ForEachCursor(def[68])
       ,new ForEachCursor(def[69])
       ,new ForEachCursor(def[70])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00012;
        prmBC00012 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmBC00013;
        prmBC00013 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmBC00014;
        prmBC00014 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmBC00015;
        prmBC00015 = new Object[] {
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC00016;
        prmBC00016 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC00017;
        prmBC00017 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC00018;
        prmBC00018 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC00019;
        prmBC00019 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000110;
        prmBC000110 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000111;
        prmBC000111 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000112;
        prmBC000112 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmBC000113;
        prmBC000113 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmBC000114;
        prmBC000114 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000115;
        prmBC000115 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000116;
        prmBC000116 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmBC000117;
        prmBC000117 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmBC000118;
        prmBC000118 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000119;
        prmBC000119 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000120;
        prmBC000120 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC000121;
        prmBC000121 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000122;
        prmBC000122 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000123;
        prmBC000123 = new Object[] {
        new ParDef("CustomerKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("CustomerName",GXType.VarChar,40,0) ,
        new ParDef("CustomerPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("CustomerVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerVatNumber",GXType.VarChar,14,0) ,
        new ParDef("CustomerLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerLastLineLocation",GXType.Int16,4,0) ,
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC000124;
        prmBC000124 = new Object[] {
        };
        Object[] prmBC000125;
        prmBC000125 = new Object[] {
        new ParDef("CustomerKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("CustomerName",GXType.VarChar,40,0) ,
        new ParDef("CustomerPostalAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("CustomerVisitingAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerVatNumber",GXType.VarChar,14,0) ,
        new ParDef("CustomerLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerLastLineLocation",GXType.Int16,4,0) ,
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000126;
        prmBC000126 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000127;
        prmBC000127 = new Object[] {
        new ParDef("CustomerTypeId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC000128;
        prmBC000128 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000129;
        prmBC000129 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000130;
        prmBC000130 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000131;
        prmBC000131 = new Object[] {
        new ParDef("CustomerLastLineLocation",GXType.Int16,4,0) ,
        new ParDef("CustomerLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000132;
        prmBC000132 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000133;
        prmBC000133 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmBC000134;
        prmBC000134 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmBC000135;
        prmBC000135 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("CustomerManagerInitials",GXType.Char,10,0){Nullable=true} ,
        new ParDef("CustomerManagerGivenName",GXType.VarChar,40,0) ,
        new ParDef("CustomerManagerLastName",GXType.VarChar,40,0) ,
        new ParDef("CustomerManagerEmail",GXType.VarChar,100,0) ,
        new ParDef("CustomerManagerPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerManagerGender",GXType.Char,20,0){Nullable=true}
        };
        Object[] prmBC000136;
        prmBC000136 = new Object[] {
        new ParDef("CustomerManagerGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("CustomerManagerInitials",GXType.Char,10,0){Nullable=true} ,
        new ParDef("CustomerManagerGivenName",GXType.VarChar,40,0) ,
        new ParDef("CustomerManagerLastName",GXType.VarChar,40,0) ,
        new ParDef("CustomerManagerEmail",GXType.VarChar,100,0) ,
        new ParDef("CustomerManagerPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerManagerGender",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmBC000137;
        prmBC000137 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerManagerId",GXType.Int16,4,0)
        };
        Object[] prmBC000138;
        prmBC000138 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000139;
        prmBC000139 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000140;
        prmBC000140 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000141;
        prmBC000141 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationVisitingAddres",GXType.VarChar,1024,0) ,
        new ParDef("CustomerLocationPostalAddress",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationEmail",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationPhone",GXType.Char,20,0) ,
        new ParDef("CustomerLocationLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationDescription",GXType.VarChar,200,0) ,
        new ParDef("CustomerLocationName",GXType.VarChar,40,0)
        };
        Object[] prmBC000142;
        prmBC000142 = new Object[] {
        new ParDef("CustomerLocationVisitingAddres",GXType.VarChar,1024,0) ,
        new ParDef("CustomerLocationPostalAddress",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationEmail",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationPhone",GXType.Char,20,0) ,
        new ParDef("CustomerLocationLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationDescription",GXType.VarChar,200,0) ,
        new ParDef("CustomerLocationName",GXType.VarChar,40,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000143;
        prmBC000143 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000144;
        prmBC000144 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000145;
        prmBC000145 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000146;
        prmBC000146 = new Object[] {
        new ParDef("CustomerLocationLastLine",GXType.Int16,4,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000147;
        prmBC000147 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000148;
        prmBC000148 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmBC000149;
        prmBC000149 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmBC000150;
        prmBC000150 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistGA",GXType.VarChar,100,60) ,
        new ParDef("CustomerLocationReceptionistIn",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerLocationReceptionistGi",GXType.VarChar,40,0) ,
        new ParDef("CustomerLocationReceptionistLa",GXType.VarChar,40,0) ,
        new ParDef("CustomerLocationReceptionistEm",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationReceptionistAd",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerLocationReceptionistPh",GXType.Char,20,0)
        };
        Object[] prmBC000151;
        prmBC000151 = new Object[] {
        new ParDef("CustomerLocationReceptionistGA",GXType.VarChar,100,60) ,
        new ParDef("CustomerLocationReceptionistIn",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CustomerLocationReceptionistGi",GXType.VarChar,40,0) ,
        new ParDef("CustomerLocationReceptionistLa",GXType.VarChar,40,0) ,
        new ParDef("CustomerLocationReceptionistEm",GXType.VarChar,100,0) ,
        new ParDef("CustomerLocationReceptionistAd",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("CustomerLocationReceptionistPh",GXType.Char,20,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmBC000152;
        prmBC000152 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationReceptionistId",GXType.Int16,4,0)
        };
        Object[] prmBC000153;
        prmBC000153 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000154;
        prmBC000154 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000155;
        prmBC000155 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000156;
        prmBC000156 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000157;
        prmBC000157 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000158;
        prmBC000158 = new Object[] {
        new ParDef("Supplier_AgbId",GXType.Int16,4,0)
        };
        Object[] prmBC000159;
        prmBC000159 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000160;
        prmBC000160 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000161;
        prmBC000161 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000162;
        prmBC000162 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000163;
        prmBC000163 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000164;
        prmBC000164 = new Object[] {
        new ParDef("Supplier_GenId",GXType.Int16,4,0)
        };
        Object[] prmBC000165;
        prmBC000165 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000166;
        prmBC000166 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmBC000167;
        prmBC000167 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmBC000168;
        prmBC000168 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmBC000169;
        prmBC000169 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmBC000170;
        prmBC000170 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmBC000171;
        prmBC000171 = new Object[] {
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC000172;
        prmBC000172 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00012", "SELECT CustomerId, CustomerLocationId, AmenitiesId FROM CustomerLocationsAmenities WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND AmenitiesId = :AmenitiesId  FOR UPDATE OF CustomerLocationsAmenities",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00013", "SELECT CustomerId, CustomerLocationId, AmenitiesId FROM CustomerLocationsAmenities WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00014", "SELECT AmenitiesName, AmenitiesTypeId FROM Amenities WHERE AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00015", "SELECT AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AmenitiesTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00016", "SELECT CustomerId, CustomerLocationId, Supplier_GenId FROM CustomerLocationSupplier_Gen WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_GenId = :Supplier_GenId  FOR UPDATE OF CustomerLocationSupplier_Gen",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00017", "SELECT CustomerId, CustomerLocationId, Supplier_GenId FROM CustomerLocationSupplier_Gen WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00017,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00018", "SELECT Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00018,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00019", "SELECT CustomerId, CustomerLocationId, Supplier_AgbId FROM CustomerLocationSupplier_Agb WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_AgbId = :Supplier_AgbId  FOR UPDATE OF CustomerLocationSupplier_Agb",true, GxErrorMask.GX_NOMASK, false, this,prmBC00019,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000110", "SELECT CustomerId, CustomerLocationId, Supplier_AgbId FROM CustomerLocationSupplier_Agb WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000110,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000111", "SELECT Supplier_AgbNumber, Supplier_AgbName, Supplier_AgbKvkNumber, Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress, Supplier_AgbEmail, Supplier_AgbPhone, Supplier_AgbContactName FROM Supplier_AGB WHERE Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000112", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId, CustomerLocationReceptionistGA, CustomerLocationReceptionistIn, CustomerLocationReceptionistGi, CustomerLocationReceptionistLa, CustomerLocationReceptionistEm, CustomerLocationReceptionistAd, CustomerLocationReceptionistPh FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId  FOR UPDATE OF CustomerLocationReceptionist",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000113", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId, CustomerLocationReceptionistGA, CustomerLocationReceptionistIn, CustomerLocationReceptionistGi, CustomerLocationReceptionistLa, CustomerLocationReceptionistEm, CustomerLocationReceptionistAd, CustomerLocationReceptionistPh FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000114", "SELECT CustomerId, CustomerLocationId, CustomerLocationVisitingAddres, CustomerLocationPostalAddress, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationLastLine, CustomerLocationDescription, CustomerLocationName FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId  FOR UPDATE OF CustomerLocation",true, GxErrorMask.GX_NOMASK, false, this,prmBC000114,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000115", "SELECT CustomerId, CustomerLocationId, CustomerLocationVisitingAddres, CustomerLocationPostalAddress, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationLastLine, CustomerLocationDescription, CustomerLocationName FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000115,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000116", "SELECT CustomerId, CustomerManagerId, CustomerManagerGAMGUID, CustomerManagerInitials, CustomerManagerGivenName, CustomerManagerLastName, CustomerManagerEmail, CustomerManagerPhone, CustomerManagerGender FROM CustomerManager WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId  FOR UPDATE OF CustomerManager",true, GxErrorMask.GX_NOMASK, false, this,prmBC000116,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000117", "SELECT CustomerId, CustomerManagerId, CustomerManagerGAMGUID, CustomerManagerInitials, CustomerManagerGivenName, CustomerManagerLastName, CustomerManagerEmail, CustomerManagerPhone, CustomerManagerGender FROM CustomerManager WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000117,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000118", "SELECT CustomerId, CustomerKvkNumber, CustomerName, CustomerPostalAddress, CustomerEmail, CustomerVisitingAddress, CustomerPhone, CustomerVatNumber, CustomerLastLine, CustomerLastLineLocation, CustomerTypeId FROM Customer WHERE CustomerId = :CustomerId  FOR UPDATE OF Customer",true, GxErrorMask.GX_NOMASK, false, this,prmBC000118,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000119", "SELECT CustomerId, CustomerKvkNumber, CustomerName, CustomerPostalAddress, CustomerEmail, CustomerVisitingAddress, CustomerPhone, CustomerVatNumber, CustomerLastLine, CustomerLastLineLocation, CustomerTypeId FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000119,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000120", "SELECT CustomerTypeName FROM CustomerType WHERE CustomerTypeId = :CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000120,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000121", "SELECT TM1.CustomerId, TM1.CustomerKvkNumber, TM1.CustomerName, TM1.CustomerPostalAddress, TM1.CustomerEmail, TM1.CustomerVisitingAddress, TM1.CustomerPhone, TM1.CustomerVatNumber, T2.CustomerTypeName, TM1.CustomerLastLine, TM1.CustomerLastLineLocation, TM1.CustomerTypeId FROM (Customer TM1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = TM1.CustomerTypeId) WHERE TM1.CustomerId = :CustomerId ORDER BY TM1.CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000121,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000122", "SELECT CustomerId FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000122,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000123", "SAVEPOINT gxupdate;INSERT INTO Customer(CustomerKvkNumber, CustomerName, CustomerPostalAddress, CustomerEmail, CustomerVisitingAddress, CustomerPhone, CustomerVatNumber, CustomerLastLine, CustomerLastLineLocation, CustomerTypeId) VALUES(:CustomerKvkNumber, :CustomerName, :CustomerPostalAddress, :CustomerEmail, :CustomerVisitingAddress, :CustomerPhone, :CustomerVatNumber, :CustomerLastLine, :CustomerLastLineLocation, :CustomerTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000123)
           ,new CursorDef("BC000124", "SELECT currval('CustomerId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000124,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000125", "SAVEPOINT gxupdate;UPDATE Customer SET CustomerKvkNumber=:CustomerKvkNumber, CustomerName=:CustomerName, CustomerPostalAddress=:CustomerPostalAddress, CustomerEmail=:CustomerEmail, CustomerVisitingAddress=:CustomerVisitingAddress, CustomerPhone=:CustomerPhone, CustomerVatNumber=:CustomerVatNumber, CustomerLastLine=:CustomerLastLine, CustomerLastLineLocation=:CustomerLastLineLocation, CustomerTypeId=:CustomerTypeId  WHERE CustomerId = :CustomerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000125)
           ,new CursorDef("BC000126", "SAVEPOINT gxupdate;DELETE FROM Customer  WHERE CustomerId = :CustomerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000126)
           ,new CursorDef("BC000127", "SELECT CustomerTypeName FROM CustomerType WHERE CustomerTypeId = :CustomerTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000127,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000128", "SELECT CustomerCustomizationId FROM CustomerCustomization WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000128,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000129", "SELECT PageId FROM Page WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000129,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000130", "SELECT CustomerId, CustomerLocationId FROM CustomerLocation WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000130,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000131", "SAVEPOINT gxupdate;UPDATE Customer SET CustomerLastLineLocation=:CustomerLastLineLocation, CustomerLastLine=:CustomerLastLine  WHERE CustomerId = :CustomerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000131)
           ,new CursorDef("BC000132", "SELECT TM1.CustomerId, TM1.CustomerKvkNumber, TM1.CustomerName, TM1.CustomerPostalAddress, TM1.CustomerEmail, TM1.CustomerVisitingAddress, TM1.CustomerPhone, TM1.CustomerVatNumber, T2.CustomerTypeName, TM1.CustomerLastLine, TM1.CustomerLastLineLocation, TM1.CustomerTypeId FROM (Customer TM1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = TM1.CustomerTypeId) WHERE TM1.CustomerId = :CustomerId ORDER BY TM1.CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000132,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000133", "SELECT CustomerId, CustomerManagerId, CustomerManagerGAMGUID, CustomerManagerInitials, CustomerManagerGivenName, CustomerManagerLastName, CustomerManagerEmail, CustomerManagerPhone, CustomerManagerGender FROM CustomerManager WHERE CustomerId = :CustomerId and CustomerManagerId = :CustomerManagerId ORDER BY CustomerId, CustomerManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000133,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000134", "SELECT CustomerId, CustomerManagerId FROM CustomerManager WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000134,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000135", "SAVEPOINT gxupdate;INSERT INTO CustomerManager(CustomerId, CustomerManagerId, CustomerManagerGAMGUID, CustomerManagerInitials, CustomerManagerGivenName, CustomerManagerLastName, CustomerManagerEmail, CustomerManagerPhone, CustomerManagerGender) VALUES(:CustomerId, :CustomerManagerId, :CustomerManagerGAMGUID, :CustomerManagerInitials, :CustomerManagerGivenName, :CustomerManagerLastName, :CustomerManagerEmail, :CustomerManagerPhone, :CustomerManagerGender);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000135)
           ,new CursorDef("BC000136", "SAVEPOINT gxupdate;UPDATE CustomerManager SET CustomerManagerGAMGUID=:CustomerManagerGAMGUID, CustomerManagerInitials=:CustomerManagerInitials, CustomerManagerGivenName=:CustomerManagerGivenName, CustomerManagerLastName=:CustomerManagerLastName, CustomerManagerEmail=:CustomerManagerEmail, CustomerManagerPhone=:CustomerManagerPhone, CustomerManagerGender=:CustomerManagerGender  WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000136)
           ,new CursorDef("BC000137", "SAVEPOINT gxupdate;DELETE FROM CustomerManager  WHERE CustomerId = :CustomerId AND CustomerManagerId = :CustomerManagerId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000137)
           ,new CursorDef("BC000138", "SELECT CustomerId, CustomerManagerId, CustomerManagerGAMGUID, CustomerManagerInitials, CustomerManagerGivenName, CustomerManagerLastName, CustomerManagerEmail, CustomerManagerPhone, CustomerManagerGender FROM CustomerManager WHERE CustomerId = :CustomerId ORDER BY CustomerId, CustomerManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000138,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000139", "SELECT CustomerId, CustomerLocationId, CustomerLocationVisitingAddres, CustomerLocationPostalAddress, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationLastLine, CustomerLocationDescription, CustomerLocationName FROM CustomerLocation WHERE CustomerId = :CustomerId and CustomerLocationId = :CustomerLocationId ORDER BY CustomerId, CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000139,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000140", "SELECT CustomerId, CustomerLocationId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000140,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000141", "SAVEPOINT gxupdate;INSERT INTO CustomerLocation(CustomerId, CustomerLocationId, CustomerLocationVisitingAddres, CustomerLocationPostalAddress, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationLastLine, CustomerLocationDescription, CustomerLocationName) VALUES(:CustomerId, :CustomerLocationId, :CustomerLocationVisitingAddres, :CustomerLocationPostalAddress, :CustomerLocationEmail, :CustomerLocationPhone, :CustomerLocationLastLine, :CustomerLocationDescription, :CustomerLocationName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000141)
           ,new CursorDef("BC000142", "SAVEPOINT gxupdate;UPDATE CustomerLocation SET CustomerLocationVisitingAddres=:CustomerLocationVisitingAddres, CustomerLocationPostalAddress=:CustomerLocationPostalAddress, CustomerLocationEmail=:CustomerLocationEmail, CustomerLocationPhone=:CustomerLocationPhone, CustomerLocationLastLine=:CustomerLocationLastLine, CustomerLocationDescription=:CustomerLocationDescription, CustomerLocationName=:CustomerLocationName  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000142)
           ,new CursorDef("BC000143", "SAVEPOINT gxupdate;DELETE FROM CustomerLocation  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000143)
           ,new CursorDef("BC000144", "SELECT LocationEventId FROM LocationEvent WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000144,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000145", "SELECT ResidentId FROM Resident WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000145,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000146", "SAVEPOINT gxupdate;UPDATE CustomerLocation SET CustomerLocationLastLine=:CustomerLocationLastLine  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000146)
           ,new CursorDef("BC000147", "SELECT CustomerId, CustomerLocationId, CustomerLocationVisitingAddres, CustomerLocationPostalAddress, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationLastLine, CustomerLocationDescription, CustomerLocationName FROM CustomerLocation WHERE CustomerId = :CustomerId ORDER BY CustomerId, CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000147,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000148", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId, CustomerLocationReceptionistGA, CustomerLocationReceptionistIn, CustomerLocationReceptionistGi, CustomerLocationReceptionistLa, CustomerLocationReceptionistEm, CustomerLocationReceptionistAd, CustomerLocationReceptionistPh FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId and CustomerLocationId = :CustomerLocationId and CustomerLocationReceptionistId = :CustomerLocationReceptionistId ORDER BY CustomerId, CustomerLocationId, CustomerLocationReceptionistId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000148,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000149", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000149,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000150", "SAVEPOINT gxupdate;INSERT INTO CustomerLocationReceptionist(CustomerId, CustomerLocationId, CustomerLocationReceptionistId, CustomerLocationReceptionistGA, CustomerLocationReceptionistIn, CustomerLocationReceptionistGi, CustomerLocationReceptionistLa, CustomerLocationReceptionistEm, CustomerLocationReceptionistAd, CustomerLocationReceptionistPh) VALUES(:CustomerId, :CustomerLocationId, :CustomerLocationReceptionistId, :CustomerLocationReceptionistGA, :CustomerLocationReceptionistIn, :CustomerLocationReceptionistGi, :CustomerLocationReceptionistLa, :CustomerLocationReceptionistEm, :CustomerLocationReceptionistAd, :CustomerLocationReceptionistPh);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000150)
           ,new CursorDef("BC000151", "SAVEPOINT gxupdate;UPDATE CustomerLocationReceptionist SET CustomerLocationReceptionistGA=:CustomerLocationReceptionistGA, CustomerLocationReceptionistIn=:CustomerLocationReceptionistIn, CustomerLocationReceptionistGi=:CustomerLocationReceptionistGi, CustomerLocationReceptionistLa=:CustomerLocationReceptionistLa, CustomerLocationReceptionistEm=:CustomerLocationReceptionistEm, CustomerLocationReceptionistAd=:CustomerLocationReceptionistAd, CustomerLocationReceptionistPh=:CustomerLocationReceptionistPh  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000151)
           ,new CursorDef("BC000152", "SAVEPOINT gxupdate;DELETE FROM CustomerLocationReceptionist  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND CustomerLocationReceptionistId = :CustomerLocationReceptionistId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000152)
           ,new CursorDef("BC000153", "SELECT CustomerId, CustomerLocationId, CustomerLocationReceptionistId, CustomerLocationReceptionistGA, CustomerLocationReceptionistIn, CustomerLocationReceptionistGi, CustomerLocationReceptionistLa, CustomerLocationReceptionistEm, CustomerLocationReceptionistAd, CustomerLocationReceptionistPh FROM CustomerLocationReceptionist WHERE CustomerId = :CustomerId and CustomerLocationId = :CustomerLocationId ORDER BY CustomerId, CustomerLocationId, CustomerLocationReceptionistId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000153,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000154", "SELECT T1.CustomerId, T1.CustomerLocationId, T2.Supplier_AgbNumber, T2.Supplier_AgbName, T2.Supplier_AgbKvkNumber, T2.Supplier_AgbVisitingAddress, T2.Supplier_AgbPostalAddress, T2.Supplier_AgbEmail, T2.Supplier_AgbPhone, T2.Supplier_AgbContactName, T1.Supplier_AgbId FROM (CustomerLocationSupplier_Agb T1 INNER JOIN Supplier_AGB T2 ON T2.Supplier_AgbId = T1.Supplier_AgbId) WHERE T1.CustomerId = :CustomerId and T1.CustomerLocationId = :CustomerLocationId and T1.Supplier_AgbId = :Supplier_AgbId ORDER BY T1.CustomerId, T1.CustomerLocationId, T1.Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000154,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000155", "SELECT CustomerId, CustomerLocationId, Supplier_AgbId FROM CustomerLocationSupplier_Agb WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000155,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000156", "SAVEPOINT gxupdate;INSERT INTO CustomerLocationSupplier_Agb(CustomerId, CustomerLocationId, Supplier_AgbId) VALUES(:CustomerId, :CustomerLocationId, :Supplier_AgbId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000156)
           ,new CursorDef("BC000157", "SAVEPOINT gxupdate;DELETE FROM CustomerLocationSupplier_Agb  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_AgbId = :Supplier_AgbId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000157)
           ,new CursorDef("BC000158", "SELECT Supplier_AgbNumber, Supplier_AgbName, Supplier_AgbKvkNumber, Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress, Supplier_AgbEmail, Supplier_AgbPhone, Supplier_AgbContactName FROM Supplier_AGB WHERE Supplier_AgbId = :Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000158,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000159", "SELECT T1.CustomerId, T1.CustomerLocationId, T2.Supplier_AgbNumber, T2.Supplier_AgbName, T2.Supplier_AgbKvkNumber, T2.Supplier_AgbVisitingAddress, T2.Supplier_AgbPostalAddress, T2.Supplier_AgbEmail, T2.Supplier_AgbPhone, T2.Supplier_AgbContactName, T1.Supplier_AgbId FROM (CustomerLocationSupplier_Agb T1 INNER JOIN Supplier_AGB T2 ON T2.Supplier_AgbId = T1.Supplier_AgbId) WHERE T1.CustomerId = :CustomerId and T1.CustomerLocationId = :CustomerLocationId ORDER BY T1.CustomerId, T1.CustomerLocationId, T1.Supplier_AgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000159,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000160", "SELECT T1.CustomerId, T1.CustomerLocationId, T2.Supplier_GenKvKNumber, T2.Supplier_GenCompanyName, T2.Supplier_GenVisitingAddress, T2.Supplier_GenPostalAddress, T2.Supplier_GenContactName, T2.Supplier_GenContactPhone, T1.Supplier_GenId FROM (CustomerLocationSupplier_Gen T1 INNER JOIN Supplier_Gen T2 ON T2.Supplier_GenId = T1.Supplier_GenId) WHERE T1.CustomerId = :CustomerId and T1.CustomerLocationId = :CustomerLocationId and T1.Supplier_GenId = :Supplier_GenId ORDER BY T1.CustomerId, T1.CustomerLocationId, T1.Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000160,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000161", "SELECT CustomerId, CustomerLocationId, Supplier_GenId FROM CustomerLocationSupplier_Gen WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000161,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000162", "SAVEPOINT gxupdate;INSERT INTO CustomerLocationSupplier_Gen(CustomerId, CustomerLocationId, Supplier_GenId) VALUES(:CustomerId, :CustomerLocationId, :Supplier_GenId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000162)
           ,new CursorDef("BC000163", "SAVEPOINT gxupdate;DELETE FROM CustomerLocationSupplier_Gen  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND Supplier_GenId = :Supplier_GenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000163)
           ,new CursorDef("BC000164", "SELECT Supplier_GenKvKNumber, Supplier_GenCompanyName, Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactName, Supplier_GenContactPhone FROM Supplier_Gen WHERE Supplier_GenId = :Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000164,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000165", "SELECT T1.CustomerId, T1.CustomerLocationId, T2.Supplier_GenKvKNumber, T2.Supplier_GenCompanyName, T2.Supplier_GenVisitingAddress, T2.Supplier_GenPostalAddress, T2.Supplier_GenContactName, T2.Supplier_GenContactPhone, T1.Supplier_GenId FROM (CustomerLocationSupplier_Gen T1 INNER JOIN Supplier_Gen T2 ON T2.Supplier_GenId = T1.Supplier_GenId) WHERE T1.CustomerId = :CustomerId and T1.CustomerLocationId = :CustomerLocationId ORDER BY T1.CustomerId, T1.CustomerLocationId, T1.Supplier_GenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000165,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000166", "SELECT T1.CustomerId, T1.CustomerLocationId, T2.AmenitiesName, T3.AmenitiesTypeName, T1.AmenitiesId, T2.AmenitiesTypeId FROM ((CustomerLocationsAmenities T1 INNER JOIN Amenities T2 ON T2.AmenitiesId = T1.AmenitiesId) INNER JOIN AmenitiesType T3 ON T3.AmenitiesTypeId = T2.AmenitiesTypeId) WHERE T1.CustomerId = :CustomerId and T1.CustomerLocationId = :CustomerLocationId and T1.AmenitiesId = :AmenitiesId ORDER BY T1.CustomerId, T1.CustomerLocationId, T1.AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000166,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000167", "SELECT CustomerId, CustomerLocationId, AmenitiesId FROM CustomerLocationsAmenities WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000167,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000168", "SAVEPOINT gxupdate;INSERT INTO CustomerLocationsAmenities(CustomerId, CustomerLocationId, AmenitiesId) VALUES(:CustomerId, :CustomerLocationId, :AmenitiesId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000168)
           ,new CursorDef("BC000169", "SAVEPOINT gxupdate;DELETE FROM CustomerLocationsAmenities  WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId AND AmenitiesId = :AmenitiesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000169)
           ,new CursorDef("BC000170", "SELECT AmenitiesName, AmenitiesTypeId FROM Amenities WHERE AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000170,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000171", "SELECT AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AmenitiesTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000171,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000172", "SELECT T1.CustomerId, T1.CustomerLocationId, T2.AmenitiesName, T3.AmenitiesTypeName, T1.AmenitiesId, T2.AmenitiesTypeId FROM ((CustomerLocationsAmenities T1 INNER JOIN Amenities T2 ON T2.AmenitiesId = T1.AmenitiesId) INNER JOIN AmenitiesType T3 ON T3.AmenitiesTypeId = T2.AmenitiesTypeId) WHERE T1.CustomerId = :CustomerId and T1.CustomerLocationId = :CustomerLocationId ORDER BY T1.CustomerId, T1.CustomerLocationId, T1.AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000172,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              return;
           case 11 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              return;
           case 16 :
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
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((short[]) buf[12])[0] = rslt.getShort(9);
              ((short[]) buf[13])[0] = rslt.getShort(10);
              ((short[]) buf[14])[0] = rslt.getShort(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              return;
           case 17 :
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
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((short[]) buf[12])[0] = rslt.getShort(9);
              ((short[]) buf[13])[0] = rslt.getShort(10);
              ((short[]) buf[14])[0] = rslt.getShort(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
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
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((short[]) buf[13])[0] = rslt.getShort(10);
              ((short[]) buf[14])[0] = rslt.getShort(11);
              ((short[]) buf[15])[0] = rslt.getShort(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              return;
           case 20 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 22 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 26 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 27 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 28 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
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
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((short[]) buf[13])[0] = rslt.getShort(10);
              ((short[]) buf[14])[0] = rslt.getShort(11);
              ((short[]) buf[15])[0] = rslt.getShort(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              return;
           case 31 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              return;
           case 32 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 36 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              return;
           case 37 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 38 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 42 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 43 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 45 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 46 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              return;
           case 47 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 51 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              return;
           case 52 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((short[]) buf[15])[0] = rslt.getShort(11);
              return;
           case 53 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 56 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              return;
           case 57 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((short[]) buf[15])[0] = rslt.getShort(11);
              return;
           case 58 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
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
              ((short[]) buf[12])[0] = rslt.getShort(9);
              return;
           case 59 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 62 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              return;
           case 63 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
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
              ((short[]) buf[12])[0] = rslt.getShort(9);
              return;
           case 64 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 65 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 68 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 69 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 70 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
     }
  }

}

}
