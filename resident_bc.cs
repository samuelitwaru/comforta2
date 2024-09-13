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
   public class resident_bc : GxSilentTrn, IGxSilentTrn
   {
      public resident_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public resident_bc( IGxContext context )
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
         ReadRow025( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey025( ) ;
         standaloneModal( ) ;
         AddRow025( ) ;
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
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z31ResidentId = A31ResidentId;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls025( ) ;
            }
            else
            {
               CheckExtendedTable025( ) ;
               if ( AnyError == 0 )
               {
                  ZM025( 16) ;
                  ZM025( 17) ;
                  ZM025( 18) ;
               }
               CloseExtendedTableCursors025( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode5 = Gx_mode;
            CONFIRM_026( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_027( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_0218( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode5;
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode5;
         }
      }

      protected void CONFIRM_0218( )
      {
         nGXsfl_18_idx = 0;
         while ( nGXsfl_18_idx < bcResident.gxTpr_Productservice.Count )
         {
            ReadRow0218( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound18 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_18 != 0 ) )
            {
               GetKey0218( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound18 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0218( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0218( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0218( 22) ;
                           ZM0218( 23) ;
                        }
                        CloseExtendedTableCursors0218( ) ;
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
                  if ( RcdFound18 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0218( ) ;
                        Load0218( ) ;
                        BeforeValidate0218( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0218( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_18 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0218( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0218( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0218( 22) ;
                                 ZM0218( 23) ;
                              }
                              CloseExtendedTableCursors0218( ) ;
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
               VarsToRow18( ((SdtResident_ProductService)bcResident.gxTpr_Productservice.Item(nGXsfl_18_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_027( )
      {
         s97ResidentLastLineCompany = O97ResidentLastLineCompany;
         nGXsfl_7_idx = 0;
         while ( nGXsfl_7_idx < bcResident.gxTpr_Incompany.Count )
         {
            ReadRow027( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound7 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_7 != 0 ) )
            {
               GetKey027( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound7 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate027( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable027( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors027( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O97ResidentLastLineCompany = A97ResidentLastLineCompany;
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
                  if ( RcdFound7 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey027( ) ;
                        Load027( ) ;
                        BeforeValidate027( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls027( ) ;
                           O97ResidentLastLineCompany = A97ResidentLastLineCompany;
                        }
                     }
                     else
                     {
                        if ( nIsMod_7 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate027( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable027( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors027( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O97ResidentLastLineCompany = A97ResidentLastLineCompany;
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
               VarsToRow7( ((SdtResident_INCompany)bcResident.gxTpr_Incompany.Item(nGXsfl_7_idx))) ;
            }
         }
         O97ResidentLastLineCompany = s97ResidentLastLineCompany;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_026( )
      {
         s96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
         nGXsfl_6_idx = 0;
         while ( nGXsfl_6_idx < bcResident.gxTpr_Inindividual.Count )
         {
            ReadRow026( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound6 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_6 != 0 ) )
            {
               GetKey026( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound6 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate026( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable026( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors026( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
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
                  if ( RcdFound6 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey026( ) ;
                        Load026( ) ;
                        BeforeValidate026( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls026( ) ;
                           O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
                        }
                     }
                     else
                     {
                        if ( nIsMod_6 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate026( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable026( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors026( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
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
               VarsToRow6( ((SdtResident_INIndividual)bcResident.gxTpr_Inindividual.Item(nGXsfl_6_idx))) ;
            }
         }
         O96ResidentLastLineIndividual = s96ResidentLastLineIndividual;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV34Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV35GXV1 = 1;
            while ( AV35GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ResidentTypeId") == 0 )
               {
                  AV13Insert_ResidentTypeId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CustomerId") == 0 )
               {
                  AV27Insert_CustomerId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CustomerLocationId") == 0 )
               {
                  AV28Insert_CustomerLocationId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV35GXV1 = (int)(AV35GXV1+1);
            }
         }
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            context.PopUp(formatLink("residentqrcode.aspx", new object[] {UrlEncode(StringUtil.RTrim(A36ResidentEmail))}, new string[] {"ResidentEmail"}) , new Object[] {});
         }
      }

      protected void ZM025( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z39ResidentGAMGUID = A39ResidentGAMGUID;
            Z35ResidentInitials = A35ResidentInitials;
            Z40ResidentBsnNumber = A40ResidentBsnNumber;
            Z33ResidentGivenName = A33ResidentGivenName;
            Z34ResidentLastName = A34ResidentLastName;
            Z36ResidentEmail = A36ResidentEmail;
            Z102ResidentGender = A102ResidentGender;
            Z37ResidentAddress = A37ResidentAddress;
            Z38ResidentPhone = A38ResidentPhone;
            Z96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            Z97ResidentLastLineCompany = A97ResidentLastLineCompany;
            Z82ResidentTypeId = A82ResidentTypeId;
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z83ResidentTypeName = A83ResidentTypeName;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z3CustomerName = A3CustomerName;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -14 )
         {
            Z31ResidentId = A31ResidentId;
            Z39ResidentGAMGUID = A39ResidentGAMGUID;
            Z35ResidentInitials = A35ResidentInitials;
            Z40ResidentBsnNumber = A40ResidentBsnNumber;
            Z33ResidentGivenName = A33ResidentGivenName;
            Z34ResidentLastName = A34ResidentLastName;
            Z36ResidentEmail = A36ResidentEmail;
            Z102ResidentGender = A102ResidentGender;
            Z37ResidentAddress = A37ResidentAddress;
            Z38ResidentPhone = A38ResidentPhone;
            Z96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            Z97ResidentLastLineCompany = A97ResidentLastLineCompany;
            Z82ResidentTypeId = A82ResidentTypeId;
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z83ResidentTypeName = A83ResidentTypeName;
            Z3CustomerName = A3CustomerName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV34Pgmname = "Resident_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load025( )
      {
         /* Using cursor BC000215 */
         pr_default.execute(13, new Object[] {A31ResidentId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound5 = 1;
            A39ResidentGAMGUID = BC000215_A39ResidentGAMGUID[0];
            A35ResidentInitials = BC000215_A35ResidentInitials[0];
            n35ResidentInitials = BC000215_n35ResidentInitials[0];
            A40ResidentBsnNumber = BC000215_A40ResidentBsnNumber[0];
            A33ResidentGivenName = BC000215_A33ResidentGivenName[0];
            A34ResidentLastName = BC000215_A34ResidentLastName[0];
            A36ResidentEmail = BC000215_A36ResidentEmail[0];
            A102ResidentGender = BC000215_A102ResidentGender[0];
            A37ResidentAddress = BC000215_A37ResidentAddress[0];
            n37ResidentAddress = BC000215_n37ResidentAddress[0];
            A38ResidentPhone = BC000215_A38ResidentPhone[0];
            n38ResidentPhone = BC000215_n38ResidentPhone[0];
            A83ResidentTypeName = BC000215_A83ResidentTypeName[0];
            A3CustomerName = BC000215_A3CustomerName[0];
            A96ResidentLastLineIndividual = BC000215_A96ResidentLastLineIndividual[0];
            A97ResidentLastLineCompany = BC000215_A97ResidentLastLineCompany[0];
            A82ResidentTypeId = BC000215_A82ResidentTypeId[0];
            A1CustomerId = BC000215_A1CustomerId[0];
            A18CustomerLocationId = BC000215_A18CustomerLocationId[0];
            ZM025( -14) ;
         }
         pr_default.close(13);
         OnLoadActions025( ) ;
      }

      protected void OnLoadActions025( )
      {
      }

      protected void CheckExtendedTable025( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000216 */
         pr_default.execute(14, new Object[] {A40ResidentBsnNumber, A31ResidentId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Resident Bsn Number", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(14);
         new getnameinitials(context ).execute(  A33ResidentGivenName,  A34ResidentLastName, out  A35ResidentInitials) ;
         n35ResidentInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A35ResidentInitials)) ? true : false);
         if ( ! ( GxRegex.IsMatch(A36ResidentEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Resident Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A102ResidentGender, "Man") == 0 ) || ( StringUtil.StrCmp(A102ResidentGender, "Woman") == 0 ) || ( StringUtil.StrCmp(A102ResidentGender, "Other") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000212 */
         pr_default.execute(10, new Object[] {A82ResidentTypeId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
            AnyError = 1;
         }
         A83ResidentTypeName = BC000212_A83ResidentTypeName[0];
         pr_default.close(10);
         /* Using cursor BC000213 */
         pr_default.execute(11, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
         }
         A3CustomerName = BC000213_A3CustomerName[0];
         pr_default.close(11);
         /* Using cursor BC000214 */
         pr_default.execute(12, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "CustomerLocation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERLOCATIONID");
            AnyError = 1;
         }
         pr_default.close(12);
      }

      protected void CloseExtendedTableCursors025( )
      {
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(12);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey025( )
      {
         /* Using cursor BC000217 */
         pr_default.execute(15, new Object[] {A31ResidentId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000211 */
         pr_default.execute(9, new Object[] {A31ResidentId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            ZM025( 14) ;
            RcdFound5 = 1;
            A31ResidentId = BC000211_A31ResidentId[0];
            A39ResidentGAMGUID = BC000211_A39ResidentGAMGUID[0];
            A35ResidentInitials = BC000211_A35ResidentInitials[0];
            n35ResidentInitials = BC000211_n35ResidentInitials[0];
            A40ResidentBsnNumber = BC000211_A40ResidentBsnNumber[0];
            A33ResidentGivenName = BC000211_A33ResidentGivenName[0];
            A34ResidentLastName = BC000211_A34ResidentLastName[0];
            A36ResidentEmail = BC000211_A36ResidentEmail[0];
            A102ResidentGender = BC000211_A102ResidentGender[0];
            A37ResidentAddress = BC000211_A37ResidentAddress[0];
            n37ResidentAddress = BC000211_n37ResidentAddress[0];
            A38ResidentPhone = BC000211_A38ResidentPhone[0];
            n38ResidentPhone = BC000211_n38ResidentPhone[0];
            A96ResidentLastLineIndividual = BC000211_A96ResidentLastLineIndividual[0];
            A97ResidentLastLineCompany = BC000211_A97ResidentLastLineCompany[0];
            A82ResidentTypeId = BC000211_A82ResidentTypeId[0];
            A1CustomerId = BC000211_A1CustomerId[0];
            A18CustomerLocationId = BC000211_A18CustomerLocationId[0];
            O97ResidentLastLineCompany = A97ResidentLastLineCompany;
            O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            Z31ResidentId = A31ResidentId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load025( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey025( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey025( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(9);
      }

      protected void getEqualNoModal( )
      {
         GetKey025( ) ;
         if ( RcdFound5 == 0 )
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
         CONFIRM_020( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency025( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000210 */
            pr_default.execute(8, new Object[] {A31ResidentId});
            if ( (pr_default.getStatus(8) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Resident"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(8) == 101) || ( StringUtil.StrCmp(Z39ResidentGAMGUID, BC000210_A39ResidentGAMGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z35ResidentInitials, BC000210_A35ResidentInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z40ResidentBsnNumber, BC000210_A40ResidentBsnNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z33ResidentGivenName, BC000210_A33ResidentGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z34ResidentLastName, BC000210_A34ResidentLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z36ResidentEmail, BC000210_A36ResidentEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z102ResidentGender, BC000210_A102ResidentGender[0]) != 0 ) || ( StringUtil.StrCmp(Z37ResidentAddress, BC000210_A37ResidentAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z38ResidentPhone, BC000210_A38ResidentPhone[0]) != 0 ) || ( Z96ResidentLastLineIndividual != BC000210_A96ResidentLastLineIndividual[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z97ResidentLastLineCompany != BC000210_A97ResidentLastLineCompany[0] ) || ( Z82ResidentTypeId != BC000210_A82ResidentTypeId[0] ) || ( Z1CustomerId != BC000210_A1CustomerId[0] ) || ( Z18CustomerLocationId != BC000210_A18CustomerLocationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Resident"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert025( )
      {
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable025( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM025( 0) ;
            CheckOptimisticConcurrency025( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm025( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert025( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000218 */
                     pr_default.execute(16, new Object[] {A39ResidentGAMGUID, n35ResidentInitials, A35ResidentInitials, A40ResidentBsnNumber, A33ResidentGivenName, A34ResidentLastName, A36ResidentEmail, A102ResidentGender, n37ResidentAddress, A37ResidentAddress, n38ResidentPhone, A38ResidentPhone, A96ResidentLastLineIndividual, A97ResidentLastLineCompany, A82ResidentTypeId, A1CustomerId, A18CustomerLocationId});
                     pr_default.close(16);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000219 */
                     pr_default.execute(17);
                     A31ResidentId = BC000219_A31ResidentId[0];
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("Resident");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel025( ) ;
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
               Load025( ) ;
            }
            EndLevel025( ) ;
         }
         CloseExtendedTableCursors025( ) ;
      }

      protected void Update025( )
      {
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable025( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency025( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm025( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate025( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000220 */
                     pr_default.execute(18, new Object[] {A39ResidentGAMGUID, n35ResidentInitials, A35ResidentInitials, A40ResidentBsnNumber, A33ResidentGivenName, A34ResidentLastName, A36ResidentEmail, A102ResidentGender, n37ResidentAddress, A37ResidentAddress, n38ResidentPhone, A38ResidentPhone, A96ResidentLastLineIndividual, A97ResidentLastLineCompany, A82ResidentTypeId, A1CustomerId, A18CustomerLocationId, A31ResidentId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("Resident");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Resident"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate025( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel025( ) ;
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
            EndLevel025( ) ;
         }
         CloseExtendedTableCursors025( ) ;
      }

      protected void DeferredUpdate025( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency025( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls025( ) ;
            AfterConfirm025( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete025( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0218( ) ;
                  while ( RcdFound18 != 0 )
                  {
                     getByPrimaryKey0218( ) ;
                     Delete0218( ) ;
                     ScanKeyNext0218( ) ;
                  }
                  ScanKeyEnd0218( ) ;
                  A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                  ScanKeyStart027( ) ;
                  while ( RcdFound7 != 0 )
                  {
                     getByPrimaryKey027( ) ;
                     Delete027( ) ;
                     ScanKeyNext027( ) ;
                     O97ResidentLastLineCompany = A97ResidentLastLineCompany;
                  }
                  ScanKeyEnd027( ) ;
                  A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                  ScanKeyStart026( ) ;
                  while ( RcdFound6 != 0 )
                  {
                     getByPrimaryKey026( ) ;
                     Delete026( ) ;
                     ScanKeyNext026( ) ;
                     O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
                  }
                  ScanKeyEnd026( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000221 */
                     pr_default.execute(19, new Object[] {A31ResidentId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Resident");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel025( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls025( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000222 */
            pr_default.execute(20, new Object[] {A82ResidentTypeId});
            A83ResidentTypeName = BC000222_A83ResidentTypeName[0];
            pr_default.close(20);
            /* Using cursor BC000223 */
            pr_default.execute(21, new Object[] {A1CustomerId});
            A3CustomerName = BC000223_A3CustomerName[0];
            pr_default.close(21);
         }
      }

      protected void ProcessNestedLevel026( )
      {
         s96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
         nGXsfl_6_idx = 0;
         while ( nGXsfl_6_idx < bcResident.gxTpr_Inindividual.Count )
         {
            ReadRow026( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound6 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_6 != 0 ) )
            {
               standaloneNotModal026( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert026( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete026( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update026( ) ;
                  }
               }
               O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            }
            KeyVarsToRow6( ((SdtResident_INIndividual)bcResident.gxTpr_Inindividual.Item(nGXsfl_6_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_6_idx = 0;
            while ( nGXsfl_6_idx < bcResident.gxTpr_Inindividual.Count )
            {
               ReadRow026( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound6 == 0 )
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
                  bcResident.gxTpr_Inindividual.RemoveElement(nGXsfl_6_idx);
                  nGXsfl_6_idx = (int)(nGXsfl_6_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey026( ) ;
                  VarsToRow6( ((SdtResident_INIndividual)bcResident.gxTpr_Inindividual.Item(nGXsfl_6_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll026( ) ;
         if ( AnyError != 0 )
         {
            O96ResidentLastLineIndividual = s96ResidentLastLineIndividual;
         }
         nRcdExists_6 = 0;
         nIsMod_6 = 0;
      }

      protected void ProcessNestedLevel027( )
      {
         s97ResidentLastLineCompany = O97ResidentLastLineCompany;
         nGXsfl_7_idx = 0;
         while ( nGXsfl_7_idx < bcResident.gxTpr_Incompany.Count )
         {
            ReadRow027( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound7 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_7 != 0 ) )
            {
               standaloneNotModal027( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert027( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete027( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update027( ) ;
                  }
               }
               O97ResidentLastLineCompany = A97ResidentLastLineCompany;
            }
            KeyVarsToRow7( ((SdtResident_INCompany)bcResident.gxTpr_Incompany.Item(nGXsfl_7_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_7_idx = 0;
            while ( nGXsfl_7_idx < bcResident.gxTpr_Incompany.Count )
            {
               ReadRow027( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound7 == 0 )
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
                  bcResident.gxTpr_Incompany.RemoveElement(nGXsfl_7_idx);
                  nGXsfl_7_idx = (int)(nGXsfl_7_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey027( ) ;
                  VarsToRow7( ((SdtResident_INCompany)bcResident.gxTpr_Incompany.Item(nGXsfl_7_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll027( ) ;
         if ( AnyError != 0 )
         {
            O97ResidentLastLineCompany = s97ResidentLastLineCompany;
         }
         nRcdExists_7 = 0;
         nIsMod_7 = 0;
      }

      protected void ProcessNestedLevel0218( )
      {
         nGXsfl_18_idx = 0;
         while ( nGXsfl_18_idx < bcResident.gxTpr_Productservice.Count )
         {
            ReadRow0218( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound18 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_18 != 0 ) )
            {
               standaloneNotModal0218( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0218( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0218( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0218( ) ;
                  }
               }
            }
            KeyVarsToRow18( ((SdtResident_ProductService)bcResident.gxTpr_Productservice.Item(nGXsfl_18_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_18_idx = 0;
            while ( nGXsfl_18_idx < bcResident.gxTpr_Productservice.Count )
            {
               ReadRow0218( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound18 == 0 )
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
                  bcResident.gxTpr_Productservice.RemoveElement(nGXsfl_18_idx);
                  nGXsfl_18_idx = (int)(nGXsfl_18_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0218( ) ;
                  VarsToRow18( ((SdtResident_ProductService)bcResident.gxTpr_Productservice.Item(nGXsfl_18_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0218( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_18 = 0;
         nIsMod_18 = 0;
      }

      protected void ProcessLevel025( )
      {
         /* Save parent mode. */
         sMode5 = Gx_mode;
         ProcessNestedLevel026( ) ;
         ProcessNestedLevel027( ) ;
         ProcessNestedLevel0218( ) ;
         if ( AnyError != 0 )
         {
            O96ResidentLastLineIndividual = s96ResidentLastLineIndividual;
            O97ResidentLastLineCompany = s97ResidentLastLineCompany;
         }
         /* Restore parent mode. */
         Gx_mode = sMode5;
         /* ' Update level parameters */
         /* Using cursor BC000224 */
         pr_default.execute(22, new Object[] {A97ResidentLastLineCompany, A96ResidentLastLineIndividual, A31ResidentId});
         pr_default.close(22);
         pr_default.SmartCacheProvider.SetUpdated("Resident");
      }

      protected void EndLevel025( )
      {
         pr_default.close(8);
         if ( AnyError == 0 )
         {
            BeforeComplete025( ) ;
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

      public void ScanKeyStart025( )
      {
         /* Scan By routine */
         /* Using cursor BC000225 */
         pr_default.execute(23, new Object[] {A31ResidentId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound5 = 1;
            A31ResidentId = BC000225_A31ResidentId[0];
            A39ResidentGAMGUID = BC000225_A39ResidentGAMGUID[0];
            A35ResidentInitials = BC000225_A35ResidentInitials[0];
            n35ResidentInitials = BC000225_n35ResidentInitials[0];
            A40ResidentBsnNumber = BC000225_A40ResidentBsnNumber[0];
            A33ResidentGivenName = BC000225_A33ResidentGivenName[0];
            A34ResidentLastName = BC000225_A34ResidentLastName[0];
            A36ResidentEmail = BC000225_A36ResidentEmail[0];
            A102ResidentGender = BC000225_A102ResidentGender[0];
            A37ResidentAddress = BC000225_A37ResidentAddress[0];
            n37ResidentAddress = BC000225_n37ResidentAddress[0];
            A38ResidentPhone = BC000225_A38ResidentPhone[0];
            n38ResidentPhone = BC000225_n38ResidentPhone[0];
            A83ResidentTypeName = BC000225_A83ResidentTypeName[0];
            A3CustomerName = BC000225_A3CustomerName[0];
            A96ResidentLastLineIndividual = BC000225_A96ResidentLastLineIndividual[0];
            A97ResidentLastLineCompany = BC000225_A97ResidentLastLineCompany[0];
            A82ResidentTypeId = BC000225_A82ResidentTypeId[0];
            A1CustomerId = BC000225_A1CustomerId[0];
            A18CustomerLocationId = BC000225_A18CustomerLocationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext025( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound5 = 0;
         ScanKeyLoad025( ) ;
      }

      protected void ScanKeyLoad025( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound5 = 1;
            A31ResidentId = BC000225_A31ResidentId[0];
            A39ResidentGAMGUID = BC000225_A39ResidentGAMGUID[0];
            A35ResidentInitials = BC000225_A35ResidentInitials[0];
            n35ResidentInitials = BC000225_n35ResidentInitials[0];
            A40ResidentBsnNumber = BC000225_A40ResidentBsnNumber[0];
            A33ResidentGivenName = BC000225_A33ResidentGivenName[0];
            A34ResidentLastName = BC000225_A34ResidentLastName[0];
            A36ResidentEmail = BC000225_A36ResidentEmail[0];
            A102ResidentGender = BC000225_A102ResidentGender[0];
            A37ResidentAddress = BC000225_A37ResidentAddress[0];
            n37ResidentAddress = BC000225_n37ResidentAddress[0];
            A38ResidentPhone = BC000225_A38ResidentPhone[0];
            n38ResidentPhone = BC000225_n38ResidentPhone[0];
            A83ResidentTypeName = BC000225_A83ResidentTypeName[0];
            A3CustomerName = BC000225_A3CustomerName[0];
            A96ResidentLastLineIndividual = BC000225_A96ResidentLastLineIndividual[0];
            A97ResidentLastLineCompany = BC000225_A97ResidentLastLineCompany[0];
            A82ResidentTypeId = BC000225_A82ResidentTypeId[0];
            A1CustomerId = BC000225_A1CustomerId[0];
            A18CustomerLocationId = BC000225_A18CustomerLocationId[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd025( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm025( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert025( )
      {
         /* Before Insert Rules */
         new createuseraccount(context ).execute(  A36ResidentEmail,  A33ResidentGivenName,  A34ResidentLastName,  "Resident", out  A39ResidentGAMGUID) ;
      }

      protected void BeforeUpdate025( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete025( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete025( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate025( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes025( )
      {
      }

      protected void ZM026( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z43ResidentINIndividualBsnNumber = A43ResidentINIndividualBsnNumber;
            Z44ResidentINIndividualGivenName = A44ResidentINIndividualGivenName;
            Z45ResidentINIndividualLastName = A45ResidentINIndividualLastName;
            Z46ResidentINIndividualEmail = A46ResidentINIndividualEmail;
            Z47ResidentINIndividualPhone = A47ResidentINIndividualPhone;
            Z48ResidentINIndividualAddress = A48ResidentINIndividualAddress;
            Z49ResidentINIndividualGender = A49ResidentINIndividualGender;
         }
         if ( GX_JID == -19 )
         {
            Z31ResidentId = A31ResidentId;
            Z42ResidentINIndividualId = A42ResidentINIndividualId;
            Z43ResidentINIndividualBsnNumber = A43ResidentINIndividualBsnNumber;
            Z44ResidentINIndividualGivenName = A44ResidentINIndividualGivenName;
            Z45ResidentINIndividualLastName = A45ResidentINIndividualLastName;
            Z46ResidentINIndividualEmail = A46ResidentINIndividualEmail;
            Z47ResidentINIndividualPhone = A47ResidentINIndividualPhone;
            Z48ResidentINIndividualAddress = A48ResidentINIndividualAddress;
            Z49ResidentINIndividualGender = A49ResidentINIndividualGender;
         }
      }

      protected void standaloneNotModal026( )
      {
      }

      protected void standaloneModal026( )
      {
         if ( IsIns( )  )
         {
            A96ResidentLastLineIndividual = (short)(O96ResidentLastLineIndividual+1);
         }
         if ( IsIns( )  )
         {
            A42ResidentINIndividualId = A96ResidentLastLineIndividual;
         }
      }

      protected void Load026( )
      {
         /* Using cursor BC000226 */
         pr_default.execute(24, new Object[] {A31ResidentId, A42ResidentINIndividualId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound6 = 1;
            A43ResidentINIndividualBsnNumber = BC000226_A43ResidentINIndividualBsnNumber[0];
            A44ResidentINIndividualGivenName = BC000226_A44ResidentINIndividualGivenName[0];
            A45ResidentINIndividualLastName = BC000226_A45ResidentINIndividualLastName[0];
            A46ResidentINIndividualEmail = BC000226_A46ResidentINIndividualEmail[0];
            n46ResidentINIndividualEmail = BC000226_n46ResidentINIndividualEmail[0];
            A47ResidentINIndividualPhone = BC000226_A47ResidentINIndividualPhone[0];
            n47ResidentINIndividualPhone = BC000226_n47ResidentINIndividualPhone[0];
            A48ResidentINIndividualAddress = BC000226_A48ResidentINIndividualAddress[0];
            n48ResidentINIndividualAddress = BC000226_n48ResidentINIndividualAddress[0];
            A49ResidentINIndividualGender = BC000226_A49ResidentINIndividualGender[0];
            ZM026( -19) ;
         }
         pr_default.close(24);
         OnLoadActions026( ) ;
      }

      protected void OnLoadActions026( )
      {
      }

      protected void CheckExtendedTable026( )
      {
         Gx_BScreen = 1;
         standaloneModal026( ) ;
         Gx_BScreen = 0;
         if ( ! ( GxRegex.IsMatch(A46ResidentINIndividualEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A46ResidentINIndividualEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Resident INIndividual Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A49ResidentINIndividualGender, "Man") == 0 ) || ( StringUtil.StrCmp(A49ResidentINIndividualGender, "Woman") == 0 ) || ( StringUtil.StrCmp(A49ResidentINIndividualGender, "Other") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident INIndividual Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors026( )
      {
      }

      protected void enableDisable026( )
      {
      }

      protected void GetKey026( )
      {
         /* Using cursor BC000227 */
         pr_default.execute(25, new Object[] {A31ResidentId, A42ResidentINIndividualId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(25);
      }

      protected void getByPrimaryKey026( )
      {
         /* Using cursor BC00029 */
         pr_default.execute(7, new Object[] {A31ResidentId, A42ResidentINIndividualId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM026( 19) ;
            RcdFound6 = 1;
            InitializeNonKey026( ) ;
            A42ResidentINIndividualId = BC00029_A42ResidentINIndividualId[0];
            A43ResidentINIndividualBsnNumber = BC00029_A43ResidentINIndividualBsnNumber[0];
            A44ResidentINIndividualGivenName = BC00029_A44ResidentINIndividualGivenName[0];
            A45ResidentINIndividualLastName = BC00029_A45ResidentINIndividualLastName[0];
            A46ResidentINIndividualEmail = BC00029_A46ResidentINIndividualEmail[0];
            n46ResidentINIndividualEmail = BC00029_n46ResidentINIndividualEmail[0];
            A47ResidentINIndividualPhone = BC00029_A47ResidentINIndividualPhone[0];
            n47ResidentINIndividualPhone = BC00029_n47ResidentINIndividualPhone[0];
            A48ResidentINIndividualAddress = BC00029_A48ResidentINIndividualAddress[0];
            n48ResidentINIndividualAddress = BC00029_n48ResidentINIndividualAddress[0];
            A49ResidentINIndividualGender = BC00029_A49ResidentINIndividualGender[0];
            Z31ResidentId = A31ResidentId;
            Z42ResidentINIndividualId = A42ResidentINIndividualId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal026( ) ;
            Load026( ) ;
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey026( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal026( ) ;
            Gx_mode = sMode6;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes026( ) ;
         }
         pr_default.close(7);
      }

      protected void CheckOptimisticConcurrency026( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00028 */
            pr_default.execute(6, new Object[] {A31ResidentId, A42ResidentINIndividualId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentINIndividual"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z43ResidentINIndividualBsnNumber, BC00028_A43ResidentINIndividualBsnNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z44ResidentINIndividualGivenName, BC00028_A44ResidentINIndividualGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z45ResidentINIndividualLastName, BC00028_A45ResidentINIndividualLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z46ResidentINIndividualEmail, BC00028_A46ResidentINIndividualEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z47ResidentINIndividualPhone, BC00028_A47ResidentINIndividualPhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z48ResidentINIndividualAddress, BC00028_A48ResidentINIndividualAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z49ResidentINIndividualGender, BC00028_A49ResidentINIndividualGender[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ResidentINIndividual"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert026( )
      {
         BeforeValidate026( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable026( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM026( 0) ;
            CheckOptimisticConcurrency026( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm026( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert026( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000228 */
                     pr_default.execute(26, new Object[] {A31ResidentId, A42ResidentINIndividualId, A43ResidentINIndividualBsnNumber, A44ResidentINIndividualGivenName, A45ResidentINIndividualLastName, n46ResidentINIndividualEmail, A46ResidentINIndividualEmail, n47ResidentINIndividualPhone, A47ResidentINIndividualPhone, n48ResidentINIndividualAddress, A48ResidentINIndividualAddress, A49ResidentINIndividualGender});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("ResidentINIndividual");
                     if ( (pr_default.getStatus(26) == 1) )
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
               Load026( ) ;
            }
            EndLevel026( ) ;
         }
         CloseExtendedTableCursors026( ) ;
      }

      protected void Update026( )
      {
         BeforeValidate026( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable026( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency026( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm026( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate026( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000229 */
                     pr_default.execute(27, new Object[] {A43ResidentINIndividualBsnNumber, A44ResidentINIndividualGivenName, A45ResidentINIndividualLastName, n46ResidentINIndividualEmail, A46ResidentINIndividualEmail, n47ResidentINIndividualPhone, A47ResidentINIndividualPhone, n48ResidentINIndividualAddress, A48ResidentINIndividualAddress, A49ResidentINIndividualGender, A31ResidentId, A42ResidentINIndividualId});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("ResidentINIndividual");
                     if ( (pr_default.getStatus(27) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentINIndividual"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate026( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey026( ) ;
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
            EndLevel026( ) ;
         }
         CloseExtendedTableCursors026( ) ;
      }

      protected void DeferredUpdate026( )
      {
      }

      protected void Delete026( )
      {
         Gx_mode = "DLT";
         BeforeValidate026( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency026( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls026( ) ;
            AfterConfirm026( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete026( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000230 */
                  pr_default.execute(28, new Object[] {A31ResidentId, A42ResidentINIndividualId});
                  pr_default.close(28);
                  pr_default.SmartCacheProvider.SetUpdated("ResidentINIndividual");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel026( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls026( )
      {
         standaloneModal026( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel026( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart026( )
      {
         /* Scan By routine */
         /* Using cursor BC000231 */
         pr_default.execute(29, new Object[] {A31ResidentId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound6 = 1;
            A42ResidentINIndividualId = BC000231_A42ResidentINIndividualId[0];
            A43ResidentINIndividualBsnNumber = BC000231_A43ResidentINIndividualBsnNumber[0];
            A44ResidentINIndividualGivenName = BC000231_A44ResidentINIndividualGivenName[0];
            A45ResidentINIndividualLastName = BC000231_A45ResidentINIndividualLastName[0];
            A46ResidentINIndividualEmail = BC000231_A46ResidentINIndividualEmail[0];
            n46ResidentINIndividualEmail = BC000231_n46ResidentINIndividualEmail[0];
            A47ResidentINIndividualPhone = BC000231_A47ResidentINIndividualPhone[0];
            n47ResidentINIndividualPhone = BC000231_n47ResidentINIndividualPhone[0];
            A48ResidentINIndividualAddress = BC000231_A48ResidentINIndividualAddress[0];
            n48ResidentINIndividualAddress = BC000231_n48ResidentINIndividualAddress[0];
            A49ResidentINIndividualGender = BC000231_A49ResidentINIndividualGender[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext026( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound6 = 0;
         ScanKeyLoad026( ) ;
      }

      protected void ScanKeyLoad026( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound6 = 1;
            A42ResidentINIndividualId = BC000231_A42ResidentINIndividualId[0];
            A43ResidentINIndividualBsnNumber = BC000231_A43ResidentINIndividualBsnNumber[0];
            A44ResidentINIndividualGivenName = BC000231_A44ResidentINIndividualGivenName[0];
            A45ResidentINIndividualLastName = BC000231_A45ResidentINIndividualLastName[0];
            A46ResidentINIndividualEmail = BC000231_A46ResidentINIndividualEmail[0];
            n46ResidentINIndividualEmail = BC000231_n46ResidentINIndividualEmail[0];
            A47ResidentINIndividualPhone = BC000231_A47ResidentINIndividualPhone[0];
            n47ResidentINIndividualPhone = BC000231_n47ResidentINIndividualPhone[0];
            A48ResidentINIndividualAddress = BC000231_A48ResidentINIndividualAddress[0];
            n48ResidentINIndividualAddress = BC000231_n48ResidentINIndividualAddress[0];
            A49ResidentINIndividualGender = BC000231_A49ResidentINIndividualGender[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd026( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm026( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert026( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate026( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete026( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete026( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate026( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes026( )
      {
      }

      protected void send_integrity_lvl_hashes026( )
      {
      }

      protected void ZM027( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z51ResidentINCompanyKvkNumber = A51ResidentINCompanyKvkNumber;
            Z52ResidentINCompanyName = A52ResidentINCompanyName;
            Z53ResidentINCompanyEmail = A53ResidentINCompanyEmail;
            Z54ResidentINCompanyPhone = A54ResidentINCompanyPhone;
         }
         if ( GX_JID == -20 )
         {
            Z31ResidentId = A31ResidentId;
            Z50ResidentINCompanyId = A50ResidentINCompanyId;
            Z51ResidentINCompanyKvkNumber = A51ResidentINCompanyKvkNumber;
            Z52ResidentINCompanyName = A52ResidentINCompanyName;
            Z53ResidentINCompanyEmail = A53ResidentINCompanyEmail;
            Z54ResidentINCompanyPhone = A54ResidentINCompanyPhone;
         }
      }

      protected void standaloneNotModal027( )
      {
      }

      protected void standaloneModal027( )
      {
         if ( IsIns( )  )
         {
            A97ResidentLastLineCompany = (short)(O97ResidentLastLineCompany+1);
         }
         if ( IsIns( )  )
         {
            A50ResidentINCompanyId = A97ResidentLastLineCompany;
         }
      }

      protected void Load027( )
      {
         /* Using cursor BC000232 */
         pr_default.execute(30, new Object[] {A31ResidentId, A50ResidentINCompanyId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound7 = 1;
            A51ResidentINCompanyKvkNumber = BC000232_A51ResidentINCompanyKvkNumber[0];
            A52ResidentINCompanyName = BC000232_A52ResidentINCompanyName[0];
            A53ResidentINCompanyEmail = BC000232_A53ResidentINCompanyEmail[0];
            n53ResidentINCompanyEmail = BC000232_n53ResidentINCompanyEmail[0];
            A54ResidentINCompanyPhone = BC000232_A54ResidentINCompanyPhone[0];
            n54ResidentINCompanyPhone = BC000232_n54ResidentINCompanyPhone[0];
            ZM027( -20) ;
         }
         pr_default.close(30);
         OnLoadActions027( ) ;
      }

      protected void OnLoadActions027( )
      {
      }

      protected void CheckExtendedTable027( )
      {
         Gx_BScreen = 1;
         standaloneModal027( ) ;
         Gx_BScreen = 0;
         if ( ! ( GxRegex.IsMatch(A53ResidentINCompanyEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A53ResidentINCompanyEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Resident INCompany Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors027( )
      {
      }

      protected void enableDisable027( )
      {
      }

      protected void GetKey027( )
      {
         /* Using cursor BC000233 */
         pr_default.execute(31, new Object[] {A31ResidentId, A50ResidentINCompanyId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(31);
      }

      protected void getByPrimaryKey027( )
      {
         /* Using cursor BC00027 */
         pr_default.execute(5, new Object[] {A31ResidentId, A50ResidentINCompanyId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM027( 20) ;
            RcdFound7 = 1;
            InitializeNonKey027( ) ;
            A50ResidentINCompanyId = BC00027_A50ResidentINCompanyId[0];
            A51ResidentINCompanyKvkNumber = BC00027_A51ResidentINCompanyKvkNumber[0];
            A52ResidentINCompanyName = BC00027_A52ResidentINCompanyName[0];
            A53ResidentINCompanyEmail = BC00027_A53ResidentINCompanyEmail[0];
            n53ResidentINCompanyEmail = BC00027_n53ResidentINCompanyEmail[0];
            A54ResidentINCompanyPhone = BC00027_A54ResidentINCompanyPhone[0];
            n54ResidentINCompanyPhone = BC00027_n54ResidentINCompanyPhone[0];
            Z31ResidentId = A31ResidentId;
            Z50ResidentINCompanyId = A50ResidentINCompanyId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal027( ) ;
            Load027( ) ;
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey027( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal027( ) ;
            Gx_mode = sMode7;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes027( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency027( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00026 */
            pr_default.execute(4, new Object[] {A31ResidentId, A50ResidentINCompanyId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentINCompany"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z51ResidentINCompanyKvkNumber, BC00026_A51ResidentINCompanyKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z52ResidentINCompanyName, BC00026_A52ResidentINCompanyName[0]) != 0 ) || ( StringUtil.StrCmp(Z53ResidentINCompanyEmail, BC00026_A53ResidentINCompanyEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z54ResidentINCompanyPhone, BC00026_A54ResidentINCompanyPhone[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ResidentINCompany"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert027( )
      {
         BeforeValidate027( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable027( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM027( 0) ;
            CheckOptimisticConcurrency027( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm027( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert027( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000234 */
                     pr_default.execute(32, new Object[] {A31ResidentId, A50ResidentINCompanyId, A51ResidentINCompanyKvkNumber, A52ResidentINCompanyName, n53ResidentINCompanyEmail, A53ResidentINCompanyEmail, n54ResidentINCompanyPhone, A54ResidentINCompanyPhone});
                     pr_default.close(32);
                     pr_default.SmartCacheProvider.SetUpdated("ResidentINCompany");
                     if ( (pr_default.getStatus(32) == 1) )
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
               Load027( ) ;
            }
            EndLevel027( ) ;
         }
         CloseExtendedTableCursors027( ) ;
      }

      protected void Update027( )
      {
         BeforeValidate027( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable027( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency027( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm027( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate027( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000235 */
                     pr_default.execute(33, new Object[] {A51ResidentINCompanyKvkNumber, A52ResidentINCompanyName, n53ResidentINCompanyEmail, A53ResidentINCompanyEmail, n54ResidentINCompanyPhone, A54ResidentINCompanyPhone, A31ResidentId, A50ResidentINCompanyId});
                     pr_default.close(33);
                     pr_default.SmartCacheProvider.SetUpdated("ResidentINCompany");
                     if ( (pr_default.getStatus(33) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentINCompany"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate027( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey027( ) ;
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
            EndLevel027( ) ;
         }
         CloseExtendedTableCursors027( ) ;
      }

      protected void DeferredUpdate027( )
      {
      }

      protected void Delete027( )
      {
         Gx_mode = "DLT";
         BeforeValidate027( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency027( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls027( ) ;
            AfterConfirm027( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete027( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000236 */
                  pr_default.execute(34, new Object[] {A31ResidentId, A50ResidentINCompanyId});
                  pr_default.close(34);
                  pr_default.SmartCacheProvider.SetUpdated("ResidentINCompany");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel027( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls027( )
      {
         standaloneModal027( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel027( )
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

      public void ScanKeyStart027( )
      {
         /* Scan By routine */
         /* Using cursor BC000237 */
         pr_default.execute(35, new Object[] {A31ResidentId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound7 = 1;
            A50ResidentINCompanyId = BC000237_A50ResidentINCompanyId[0];
            A51ResidentINCompanyKvkNumber = BC000237_A51ResidentINCompanyKvkNumber[0];
            A52ResidentINCompanyName = BC000237_A52ResidentINCompanyName[0];
            A53ResidentINCompanyEmail = BC000237_A53ResidentINCompanyEmail[0];
            n53ResidentINCompanyEmail = BC000237_n53ResidentINCompanyEmail[0];
            A54ResidentINCompanyPhone = BC000237_A54ResidentINCompanyPhone[0];
            n54ResidentINCompanyPhone = BC000237_n54ResidentINCompanyPhone[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext027( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound7 = 0;
         ScanKeyLoad027( ) ;
      }

      protected void ScanKeyLoad027( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound7 = 1;
            A50ResidentINCompanyId = BC000237_A50ResidentINCompanyId[0];
            A51ResidentINCompanyKvkNumber = BC000237_A51ResidentINCompanyKvkNumber[0];
            A52ResidentINCompanyName = BC000237_A52ResidentINCompanyName[0];
            A53ResidentINCompanyEmail = BC000237_A53ResidentINCompanyEmail[0];
            n53ResidentINCompanyEmail = BC000237_n53ResidentINCompanyEmail[0];
            A54ResidentINCompanyPhone = BC000237_A54ResidentINCompanyPhone[0];
            n54ResidentINCompanyPhone = BC000237_n54ResidentINCompanyPhone[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd027( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm027( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert027( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate027( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete027( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete027( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate027( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes027( )
      {
      }

      protected void send_integrity_lvl_hashes027( )
      {
      }

      protected void ZM0218( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z74ProductServiceName = A74ProductServiceName;
            Z75ProductServiceDescription = A75ProductServiceDescription;
            Z76ProductServiceQuantity = A76ProductServiceQuantity;
            Z71ProductServiceTypeId = A71ProductServiceTypeId;
         }
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z72ProductServiceTypeName = A72ProductServiceTypeName;
         }
         if ( GX_JID == -21 )
         {
            Z31ResidentId = A31ResidentId;
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

      protected void standaloneNotModal0218( )
      {
      }

      protected void standaloneModal0218( )
      {
      }

      protected void Load0218( )
      {
         /* Using cursor BC000238 */
         pr_default.execute(36, new Object[] {A31ResidentId, A73ProductServiceId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound18 = 1;
            A74ProductServiceName = BC000238_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000238_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000238_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000238_A40000ProductServicePicture_GXI[0];
            A72ProductServiceTypeName = BC000238_A72ProductServiceTypeName[0];
            A71ProductServiceTypeId = BC000238_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000238_A77ProductServicePicture[0];
            ZM0218( -21) ;
         }
         pr_default.close(36);
         OnLoadActions0218( ) ;
      }

      protected void OnLoadActions0218( )
      {
      }

      protected void CheckExtendedTable0218( )
      {
         Gx_BScreen = 1;
         standaloneModal0218( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PRODUCTSERVICEID");
            AnyError = 1;
         }
         A74ProductServiceName = BC00024_A74ProductServiceName[0];
         A75ProductServiceDescription = BC00024_A75ProductServiceDescription[0];
         A76ProductServiceQuantity = BC00024_A76ProductServiceQuantity[0];
         A40000ProductServicePicture_GXI = BC00024_A40000ProductServicePicture_GXI[0];
         A71ProductServiceTypeId = BC00024_A71ProductServiceTypeId[0];
         A77ProductServicePicture = BC00024_A77ProductServicePicture[0];
         pr_default.close(2);
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
         }
         A72ProductServiceTypeName = BC00025_A72ProductServiceTypeName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0218( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0218( )
      {
      }

      protected void GetKey0218( )
      {
         /* Using cursor BC000239 */
         pr_default.execute(37, new Object[] {A31ResidentId, A73ProductServiceId});
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(37);
      }

      protected void getByPrimaryKey0218( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A31ResidentId, A73ProductServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0218( 21) ;
            RcdFound18 = 1;
            InitializeNonKey0218( ) ;
            A73ProductServiceId = BC00023_A73ProductServiceId[0];
            Z31ResidentId = A31ResidentId;
            Z73ProductServiceId = A73ProductServiceId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0218( ) ;
            Load0218( ) ;
            Gx_mode = sMode18;
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0218( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0218( ) ;
            Gx_mode = sMode18;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0218( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0218( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A31ResidentId, A73ProductServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ResidentProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0218( )
      {
         BeforeValidate0218( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0218( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0218( 0) ;
            CheckOptimisticConcurrency0218( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0218( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0218( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000240 */
                     pr_default.execute(38, new Object[] {A31ResidentId, A73ProductServiceId});
                     pr_default.close(38);
                     pr_default.SmartCacheProvider.SetUpdated("ResidentProductService");
                     if ( (pr_default.getStatus(38) == 1) )
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
               Load0218( ) ;
            }
            EndLevel0218( ) ;
         }
         CloseExtendedTableCursors0218( ) ;
      }

      protected void Update0218( )
      {
         BeforeValidate0218( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0218( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0218( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0218( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0218( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table ResidentProductService */
                     DeferredUpdate0218( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0218( ) ;
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
            EndLevel0218( ) ;
         }
         CloseExtendedTableCursors0218( ) ;
      }

      protected void DeferredUpdate0218( )
      {
      }

      protected void Delete0218( )
      {
         Gx_mode = "DLT";
         BeforeValidate0218( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0218( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0218( ) ;
            AfterConfirm0218( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0218( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000241 */
                  pr_default.execute(39, new Object[] {A31ResidentId, A73ProductServiceId});
                  pr_default.close(39);
                  pr_default.SmartCacheProvider.SetUpdated("ResidentProductService");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0218( ) ;
         Gx_mode = sMode18;
      }

      protected void OnDeleteControls0218( )
      {
         standaloneModal0218( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000242 */
            pr_default.execute(40, new Object[] {A73ProductServiceId});
            A74ProductServiceName = BC000242_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000242_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000242_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000242_A40000ProductServicePicture_GXI[0];
            A71ProductServiceTypeId = BC000242_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000242_A77ProductServicePicture[0];
            pr_default.close(40);
            /* Using cursor BC000243 */
            pr_default.execute(41, new Object[] {A71ProductServiceTypeId});
            A72ProductServiceTypeName = BC000243_A72ProductServiceTypeName[0];
            pr_default.close(41);
         }
      }

      protected void EndLevel0218( )
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

      public void ScanKeyStart0218( )
      {
         /* Scan By routine */
         /* Using cursor BC000244 */
         pr_default.execute(42, new Object[] {A31ResidentId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(42) != 101) )
         {
            RcdFound18 = 1;
            A74ProductServiceName = BC000244_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000244_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000244_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000244_A40000ProductServicePicture_GXI[0];
            A72ProductServiceTypeName = BC000244_A72ProductServiceTypeName[0];
            A73ProductServiceId = BC000244_A73ProductServiceId[0];
            A71ProductServiceTypeId = BC000244_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000244_A77ProductServicePicture[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0218( )
      {
         /* Scan next routine */
         pr_default.readNext(42);
         RcdFound18 = 0;
         ScanKeyLoad0218( ) ;
      }

      protected void ScanKeyLoad0218( )
      {
         sMode18 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(42) != 101) )
         {
            RcdFound18 = 1;
            A74ProductServiceName = BC000244_A74ProductServiceName[0];
            A75ProductServiceDescription = BC000244_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = BC000244_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = BC000244_A40000ProductServicePicture_GXI[0];
            A72ProductServiceTypeName = BC000244_A72ProductServiceTypeName[0];
            A73ProductServiceId = BC000244_A73ProductServiceId[0];
            A71ProductServiceTypeId = BC000244_A71ProductServiceTypeId[0];
            A77ProductServicePicture = BC000244_A77ProductServicePicture[0];
         }
         Gx_mode = sMode18;
      }

      protected void ScanKeyEnd0218( )
      {
         pr_default.close(42);
      }

      protected void AfterConfirm0218( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0218( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0218( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0218( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0218( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0218( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0218( )
      {
      }

      protected void send_integrity_lvl_hashes0218( )
      {
      }

      protected void send_integrity_lvl_hashes025( )
      {
      }

      protected void AddRow025( )
      {
         VarsToRow5( bcResident) ;
      }

      protected void ReadRow025( )
      {
         RowToVars5( bcResident, 1) ;
      }

      protected void AddRow026( )
      {
         SdtResident_INIndividual obj6;
         obj6 = new SdtResident_INIndividual(context);
         VarsToRow6( obj6) ;
         bcResident.gxTpr_Inindividual.Add(obj6, 0);
         obj6.gxTpr_Mode = "UPD";
         obj6.gxTpr_Modified = 0;
      }

      protected void ReadRow026( )
      {
         nGXsfl_6_idx = (int)(nGXsfl_6_idx+1);
         RowToVars6( ((SdtResident_INIndividual)bcResident.gxTpr_Inindividual.Item(nGXsfl_6_idx)), 1) ;
      }

      protected void AddRow027( )
      {
         SdtResident_INCompany obj7;
         obj7 = new SdtResident_INCompany(context);
         VarsToRow7( obj7) ;
         bcResident.gxTpr_Incompany.Add(obj7, 0);
         obj7.gxTpr_Mode = "UPD";
         obj7.gxTpr_Modified = 0;
      }

      protected void ReadRow027( )
      {
         nGXsfl_7_idx = (int)(nGXsfl_7_idx+1);
         RowToVars7( ((SdtResident_INCompany)bcResident.gxTpr_Incompany.Item(nGXsfl_7_idx)), 1) ;
      }

      protected void AddRow0218( )
      {
         SdtResident_ProductService obj18;
         obj18 = new SdtResident_ProductService(context);
         VarsToRow18( obj18) ;
         bcResident.gxTpr_Productservice.Add(obj18, 0);
         obj18.gxTpr_Mode = "UPD";
         obj18.gxTpr_Modified = 0;
      }

      protected void ReadRow0218( )
      {
         nGXsfl_18_idx = (int)(nGXsfl_18_idx+1);
         RowToVars18( ((SdtResident_ProductService)bcResident.gxTpr_Productservice.Item(nGXsfl_18_idx)), 1) ;
      }

      protected void InitializeNonKey025( )
      {
         A39ResidentGAMGUID = "";
         A35ResidentInitials = "";
         n35ResidentInitials = false;
         A40ResidentBsnNumber = "";
         A33ResidentGivenName = "";
         A34ResidentLastName = "";
         A36ResidentEmail = "";
         A102ResidentGender = "";
         A37ResidentAddress = "";
         n37ResidentAddress = false;
         A38ResidentPhone = "";
         n38ResidentPhone = false;
         A82ResidentTypeId = 0;
         A83ResidentTypeName = "";
         A1CustomerId = 0;
         A3CustomerName = "";
         A18CustomerLocationId = 0;
         A96ResidentLastLineIndividual = 0;
         A97ResidentLastLineCompany = 0;
         O97ResidentLastLineCompany = A97ResidentLastLineCompany;
         O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
         Z39ResidentGAMGUID = "";
         Z35ResidentInitials = "";
         Z40ResidentBsnNumber = "";
         Z33ResidentGivenName = "";
         Z34ResidentLastName = "";
         Z36ResidentEmail = "";
         Z102ResidentGender = "";
         Z37ResidentAddress = "";
         Z38ResidentPhone = "";
         Z96ResidentLastLineIndividual = 0;
         Z97ResidentLastLineCompany = 0;
         Z82ResidentTypeId = 0;
         Z1CustomerId = 0;
         Z18CustomerLocationId = 0;
      }

      protected void InitAll025( )
      {
         A31ResidentId = 0;
         InitializeNonKey025( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey026( )
      {
         A43ResidentINIndividualBsnNumber = "";
         A44ResidentINIndividualGivenName = "";
         A45ResidentINIndividualLastName = "";
         A46ResidentINIndividualEmail = "";
         n46ResidentINIndividualEmail = false;
         A47ResidentINIndividualPhone = "";
         n47ResidentINIndividualPhone = false;
         A48ResidentINIndividualAddress = "";
         n48ResidentINIndividualAddress = false;
         A49ResidentINIndividualGender = "";
         Z43ResidentINIndividualBsnNumber = "";
         Z44ResidentINIndividualGivenName = "";
         Z45ResidentINIndividualLastName = "";
         Z46ResidentINIndividualEmail = "";
         Z47ResidentINIndividualPhone = "";
         Z48ResidentINIndividualAddress = "";
         Z49ResidentINIndividualGender = "";
      }

      protected void InitAll026( )
      {
         A42ResidentINIndividualId = 0;
         InitializeNonKey026( ) ;
      }

      protected void StandaloneModalInsert026( )
      {
         A96ResidentLastLineIndividual = i96ResidentLastLineIndividual;
      }

      protected void InitializeNonKey027( )
      {
         A51ResidentINCompanyKvkNumber = "";
         A52ResidentINCompanyName = "";
         A53ResidentINCompanyEmail = "";
         n53ResidentINCompanyEmail = false;
         A54ResidentINCompanyPhone = "";
         n54ResidentINCompanyPhone = false;
         Z51ResidentINCompanyKvkNumber = "";
         Z52ResidentINCompanyName = "";
         Z53ResidentINCompanyEmail = "";
         Z54ResidentINCompanyPhone = "";
      }

      protected void InitAll027( )
      {
         A50ResidentINCompanyId = 0;
         InitializeNonKey027( ) ;
      }

      protected void StandaloneModalInsert027( )
      {
         A97ResidentLastLineCompany = i97ResidentLastLineCompany;
      }

      protected void InitializeNonKey0218( )
      {
         A74ProductServiceName = "";
         A75ProductServiceDescription = "";
         A76ProductServiceQuantity = 0;
         A77ProductServicePicture = "";
         A40000ProductServicePicture_GXI = "";
         A71ProductServiceTypeId = 0;
         A72ProductServiceTypeName = "";
      }

      protected void InitAll0218( )
      {
         A73ProductServiceId = 0;
         InitializeNonKey0218( ) ;
      }

      protected void StandaloneModalInsert0218( )
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

      public void VarsToRow5( SdtResident obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Residentgamguid = A39ResidentGAMGUID;
         obj5.gxTpr_Residentinitials = A35ResidentInitials;
         obj5.gxTpr_Residentbsnnumber = A40ResidentBsnNumber;
         obj5.gxTpr_Residentgivenname = A33ResidentGivenName;
         obj5.gxTpr_Residentlastname = A34ResidentLastName;
         obj5.gxTpr_Residentemail = A36ResidentEmail;
         obj5.gxTpr_Residentgender = A102ResidentGender;
         obj5.gxTpr_Residentaddress = A37ResidentAddress;
         obj5.gxTpr_Residentphone = A38ResidentPhone;
         obj5.gxTpr_Residenttypeid = A82ResidentTypeId;
         obj5.gxTpr_Residenttypename = A83ResidentTypeName;
         obj5.gxTpr_Customerid = A1CustomerId;
         obj5.gxTpr_Customername = A3CustomerName;
         obj5.gxTpr_Customerlocationid = A18CustomerLocationId;
         obj5.gxTpr_Residentlastlineindividual = A96ResidentLastLineIndividual;
         obj5.gxTpr_Residentlastlinecompany = A97ResidentLastLineCompany;
         obj5.gxTpr_Residentid = A31ResidentId;
         obj5.gxTpr_Residentid_Z = Z31ResidentId;
         obj5.gxTpr_Residentbsnnumber_Z = Z40ResidentBsnNumber;
         obj5.gxTpr_Residentgivenname_Z = Z33ResidentGivenName;
         obj5.gxTpr_Residentlastname_Z = Z34ResidentLastName;
         obj5.gxTpr_Residentinitials_Z = Z35ResidentInitials;
         obj5.gxTpr_Residentemail_Z = Z36ResidentEmail;
         obj5.gxTpr_Residentgender_Z = Z102ResidentGender;
         obj5.gxTpr_Residentaddress_Z = Z37ResidentAddress;
         obj5.gxTpr_Residentphone_Z = Z38ResidentPhone;
         obj5.gxTpr_Residentgamguid_Z = Z39ResidentGAMGUID;
         obj5.gxTpr_Residenttypeid_Z = Z82ResidentTypeId;
         obj5.gxTpr_Residenttypename_Z = Z83ResidentTypeName;
         obj5.gxTpr_Customerid_Z = Z1CustomerId;
         obj5.gxTpr_Customername_Z = Z3CustomerName;
         obj5.gxTpr_Customerlocationid_Z = Z18CustomerLocationId;
         obj5.gxTpr_Residentlastlineindividual_Z = Z96ResidentLastLineIndividual;
         obj5.gxTpr_Residentlastlinecompany_Z = Z97ResidentLastLineCompany;
         obj5.gxTpr_Residentinitials_N = (short)(Convert.ToInt16(n35ResidentInitials));
         obj5.gxTpr_Residentaddress_N = (short)(Convert.ToInt16(n37ResidentAddress));
         obj5.gxTpr_Residentphone_N = (short)(Convert.ToInt16(n38ResidentPhone));
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( SdtResident obj5 )
      {
         obj5.gxTpr_Residentid = A31ResidentId;
         return  ;
      }

      public void RowToVars5( SdtResident obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A39ResidentGAMGUID = obj5.gxTpr_Residentgamguid;
         A35ResidentInitials = obj5.gxTpr_Residentinitials;
         n35ResidentInitials = false;
         A40ResidentBsnNumber = obj5.gxTpr_Residentbsnnumber;
         A33ResidentGivenName = obj5.gxTpr_Residentgivenname;
         A34ResidentLastName = obj5.gxTpr_Residentlastname;
         A36ResidentEmail = obj5.gxTpr_Residentemail;
         A102ResidentGender = obj5.gxTpr_Residentgender;
         A37ResidentAddress = obj5.gxTpr_Residentaddress;
         n37ResidentAddress = false;
         A38ResidentPhone = obj5.gxTpr_Residentphone;
         n38ResidentPhone = false;
         A82ResidentTypeId = obj5.gxTpr_Residenttypeid;
         A83ResidentTypeName = obj5.gxTpr_Residenttypename;
         A1CustomerId = obj5.gxTpr_Customerid;
         A3CustomerName = obj5.gxTpr_Customername;
         A18CustomerLocationId = obj5.gxTpr_Customerlocationid;
         if ( forceLoad == 1 )
         {
            A96ResidentLastLineIndividual = obj5.gxTpr_Residentlastlineindividual;
         }
         if ( forceLoad == 1 )
         {
            A97ResidentLastLineCompany = obj5.gxTpr_Residentlastlinecompany;
         }
         A31ResidentId = obj5.gxTpr_Residentid;
         Z31ResidentId = obj5.gxTpr_Residentid_Z;
         Z40ResidentBsnNumber = obj5.gxTpr_Residentbsnnumber_Z;
         Z33ResidentGivenName = obj5.gxTpr_Residentgivenname_Z;
         Z34ResidentLastName = obj5.gxTpr_Residentlastname_Z;
         Z35ResidentInitials = obj5.gxTpr_Residentinitials_Z;
         Z36ResidentEmail = obj5.gxTpr_Residentemail_Z;
         Z102ResidentGender = obj5.gxTpr_Residentgender_Z;
         Z37ResidentAddress = obj5.gxTpr_Residentaddress_Z;
         Z38ResidentPhone = obj5.gxTpr_Residentphone_Z;
         Z39ResidentGAMGUID = obj5.gxTpr_Residentgamguid_Z;
         Z82ResidentTypeId = obj5.gxTpr_Residenttypeid_Z;
         Z83ResidentTypeName = obj5.gxTpr_Residenttypename_Z;
         Z1CustomerId = obj5.gxTpr_Customerid_Z;
         Z3CustomerName = obj5.gxTpr_Customername_Z;
         Z18CustomerLocationId = obj5.gxTpr_Customerlocationid_Z;
         Z96ResidentLastLineIndividual = obj5.gxTpr_Residentlastlineindividual_Z;
         O96ResidentLastLineIndividual = obj5.gxTpr_Residentlastlineindividual_Z;
         Z97ResidentLastLineCompany = obj5.gxTpr_Residentlastlinecompany_Z;
         O97ResidentLastLineCompany = obj5.gxTpr_Residentlastlinecompany_Z;
         n35ResidentInitials = (bool)(Convert.ToBoolean(obj5.gxTpr_Residentinitials_N));
         n37ResidentAddress = (bool)(Convert.ToBoolean(obj5.gxTpr_Residentaddress_N));
         n38ResidentPhone = (bool)(Convert.ToBoolean(obj5.gxTpr_Residentphone_N));
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow6( SdtResident_INIndividual obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Residentinindividualbsnnumber = A43ResidentINIndividualBsnNumber;
         obj6.gxTpr_Residentinindividualgivenname = A44ResidentINIndividualGivenName;
         obj6.gxTpr_Residentinindividuallastname = A45ResidentINIndividualLastName;
         obj6.gxTpr_Residentinindividualemail = A46ResidentINIndividualEmail;
         obj6.gxTpr_Residentinindividualphone = A47ResidentINIndividualPhone;
         obj6.gxTpr_Residentinindividualaddress = A48ResidentINIndividualAddress;
         obj6.gxTpr_Residentinindividualgender = A49ResidentINIndividualGender;
         obj6.gxTpr_Residentinindividualid = A42ResidentINIndividualId;
         obj6.gxTpr_Residentinindividualid_Z = Z42ResidentINIndividualId;
         obj6.gxTpr_Residentinindividualbsnnumber_Z = Z43ResidentINIndividualBsnNumber;
         obj6.gxTpr_Residentinindividualgivenname_Z = Z44ResidentINIndividualGivenName;
         obj6.gxTpr_Residentinindividuallastname_Z = Z45ResidentINIndividualLastName;
         obj6.gxTpr_Residentinindividualemail_Z = Z46ResidentINIndividualEmail;
         obj6.gxTpr_Residentinindividualphone_Z = Z47ResidentINIndividualPhone;
         obj6.gxTpr_Residentinindividualaddress_Z = Z48ResidentINIndividualAddress;
         obj6.gxTpr_Residentinindividualgender_Z = Z49ResidentINIndividualGender;
         obj6.gxTpr_Residentinindividualemail_N = (short)(Convert.ToInt16(n46ResidentINIndividualEmail));
         obj6.gxTpr_Residentinindividualphone_N = (short)(Convert.ToInt16(n47ResidentINIndividualPhone));
         obj6.gxTpr_Residentinindividualaddress_N = (short)(Convert.ToInt16(n48ResidentINIndividualAddress));
         obj6.gxTpr_Modified = nIsMod_6;
         return  ;
      }

      public void KeyVarsToRow6( SdtResident_INIndividual obj6 )
      {
         obj6.gxTpr_Residentinindividualid = A42ResidentINIndividualId;
         return  ;
      }

      public void RowToVars6( SdtResident_INIndividual obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A43ResidentINIndividualBsnNumber = obj6.gxTpr_Residentinindividualbsnnumber;
         A44ResidentINIndividualGivenName = obj6.gxTpr_Residentinindividualgivenname;
         A45ResidentINIndividualLastName = obj6.gxTpr_Residentinindividuallastname;
         A46ResidentINIndividualEmail = obj6.gxTpr_Residentinindividualemail;
         n46ResidentINIndividualEmail = false;
         A47ResidentINIndividualPhone = obj6.gxTpr_Residentinindividualphone;
         n47ResidentINIndividualPhone = false;
         A48ResidentINIndividualAddress = obj6.gxTpr_Residentinindividualaddress;
         n48ResidentINIndividualAddress = false;
         A49ResidentINIndividualGender = obj6.gxTpr_Residentinindividualgender;
         A42ResidentINIndividualId = obj6.gxTpr_Residentinindividualid;
         Z42ResidentINIndividualId = obj6.gxTpr_Residentinindividualid_Z;
         Z43ResidentINIndividualBsnNumber = obj6.gxTpr_Residentinindividualbsnnumber_Z;
         Z44ResidentINIndividualGivenName = obj6.gxTpr_Residentinindividualgivenname_Z;
         Z45ResidentINIndividualLastName = obj6.gxTpr_Residentinindividuallastname_Z;
         Z46ResidentINIndividualEmail = obj6.gxTpr_Residentinindividualemail_Z;
         Z47ResidentINIndividualPhone = obj6.gxTpr_Residentinindividualphone_Z;
         Z48ResidentINIndividualAddress = obj6.gxTpr_Residentinindividualaddress_Z;
         Z49ResidentINIndividualGender = obj6.gxTpr_Residentinindividualgender_Z;
         n46ResidentINIndividualEmail = (bool)(Convert.ToBoolean(obj6.gxTpr_Residentinindividualemail_N));
         n47ResidentINIndividualPhone = (bool)(Convert.ToBoolean(obj6.gxTpr_Residentinindividualphone_N));
         n48ResidentINIndividualAddress = (bool)(Convert.ToBoolean(obj6.gxTpr_Residentinindividualaddress_N));
         nIsMod_6 = obj6.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow7( SdtResident_INCompany obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Residentincompanykvknumber = A51ResidentINCompanyKvkNumber;
         obj7.gxTpr_Residentincompanyname = A52ResidentINCompanyName;
         obj7.gxTpr_Residentincompanyemail = A53ResidentINCompanyEmail;
         obj7.gxTpr_Residentincompanyphone = A54ResidentINCompanyPhone;
         obj7.gxTpr_Residentincompanyid = A50ResidentINCompanyId;
         obj7.gxTpr_Residentincompanyid_Z = Z50ResidentINCompanyId;
         obj7.gxTpr_Residentincompanykvknumber_Z = Z51ResidentINCompanyKvkNumber;
         obj7.gxTpr_Residentincompanyname_Z = Z52ResidentINCompanyName;
         obj7.gxTpr_Residentincompanyemail_Z = Z53ResidentINCompanyEmail;
         obj7.gxTpr_Residentincompanyphone_Z = Z54ResidentINCompanyPhone;
         obj7.gxTpr_Residentincompanyemail_N = (short)(Convert.ToInt16(n53ResidentINCompanyEmail));
         obj7.gxTpr_Residentincompanyphone_N = (short)(Convert.ToInt16(n54ResidentINCompanyPhone));
         obj7.gxTpr_Modified = nIsMod_7;
         return  ;
      }

      public void KeyVarsToRow7( SdtResident_INCompany obj7 )
      {
         obj7.gxTpr_Residentincompanyid = A50ResidentINCompanyId;
         return  ;
      }

      public void RowToVars7( SdtResident_INCompany obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A51ResidentINCompanyKvkNumber = obj7.gxTpr_Residentincompanykvknumber;
         A52ResidentINCompanyName = obj7.gxTpr_Residentincompanyname;
         A53ResidentINCompanyEmail = obj7.gxTpr_Residentincompanyemail;
         n53ResidentINCompanyEmail = false;
         A54ResidentINCompanyPhone = obj7.gxTpr_Residentincompanyphone;
         n54ResidentINCompanyPhone = false;
         A50ResidentINCompanyId = obj7.gxTpr_Residentincompanyid;
         Z50ResidentINCompanyId = obj7.gxTpr_Residentincompanyid_Z;
         Z51ResidentINCompanyKvkNumber = obj7.gxTpr_Residentincompanykvknumber_Z;
         Z52ResidentINCompanyName = obj7.gxTpr_Residentincompanyname_Z;
         Z53ResidentINCompanyEmail = obj7.gxTpr_Residentincompanyemail_Z;
         Z54ResidentINCompanyPhone = obj7.gxTpr_Residentincompanyphone_Z;
         n53ResidentINCompanyEmail = (bool)(Convert.ToBoolean(obj7.gxTpr_Residentincompanyemail_N));
         n54ResidentINCompanyPhone = (bool)(Convert.ToBoolean(obj7.gxTpr_Residentincompanyphone_N));
         nIsMod_7 = obj7.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow18( SdtResident_ProductService obj18 )
      {
         obj18.gxTpr_Mode = Gx_mode;
         obj18.gxTpr_Productservicename = A74ProductServiceName;
         obj18.gxTpr_Productservicedescription = A75ProductServiceDescription;
         obj18.gxTpr_Productservicequantity = A76ProductServiceQuantity;
         obj18.gxTpr_Productservicepicture = A77ProductServicePicture;
         obj18.gxTpr_Productservicepicture_gxi = A40000ProductServicePicture_GXI;
         obj18.gxTpr_Productservicetypeid = A71ProductServiceTypeId;
         obj18.gxTpr_Productservicetypename = A72ProductServiceTypeName;
         obj18.gxTpr_Productserviceid = A73ProductServiceId;
         obj18.gxTpr_Productserviceid_Z = Z73ProductServiceId;
         obj18.gxTpr_Productservicename_Z = Z74ProductServiceName;
         obj18.gxTpr_Productservicedescription_Z = Z75ProductServiceDescription;
         obj18.gxTpr_Productservicequantity_Z = Z76ProductServiceQuantity;
         obj18.gxTpr_Productservicetypeid_Z = Z71ProductServiceTypeId;
         obj18.gxTpr_Productservicetypename_Z = Z72ProductServiceTypeName;
         obj18.gxTpr_Productservicepicture_gxi_Z = Z40000ProductServicePicture_GXI;
         obj18.gxTpr_Modified = nIsMod_18;
         return  ;
      }

      public void KeyVarsToRow18( SdtResident_ProductService obj18 )
      {
         obj18.gxTpr_Productserviceid = A73ProductServiceId;
         return  ;
      }

      public void RowToVars18( SdtResident_ProductService obj18 ,
                               int forceLoad )
      {
         Gx_mode = obj18.gxTpr_Mode;
         A74ProductServiceName = obj18.gxTpr_Productservicename;
         A75ProductServiceDescription = obj18.gxTpr_Productservicedescription;
         A76ProductServiceQuantity = obj18.gxTpr_Productservicequantity;
         A77ProductServicePicture = obj18.gxTpr_Productservicepicture;
         A40000ProductServicePicture_GXI = obj18.gxTpr_Productservicepicture_gxi;
         A71ProductServiceTypeId = obj18.gxTpr_Productservicetypeid;
         A72ProductServiceTypeName = obj18.gxTpr_Productservicetypename;
         A73ProductServiceId = obj18.gxTpr_Productserviceid;
         Z73ProductServiceId = obj18.gxTpr_Productserviceid_Z;
         Z74ProductServiceName = obj18.gxTpr_Productservicename_Z;
         Z75ProductServiceDescription = obj18.gxTpr_Productservicedescription_Z;
         Z76ProductServiceQuantity = obj18.gxTpr_Productservicequantity_Z;
         Z71ProductServiceTypeId = obj18.gxTpr_Productservicetypeid_Z;
         Z72ProductServiceTypeName = obj18.gxTpr_Productservicetypename_Z;
         Z40000ProductServicePicture_GXI = obj18.gxTpr_Productservicepicture_gxi_Z;
         nIsMod_18 = obj18.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A31ResidentId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey025( ) ;
         ScanKeyStart025( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z31ResidentId = A31ResidentId;
            O97ResidentLastLineCompany = A97ResidentLastLineCompany;
            O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
         }
         ZM025( -14) ;
         OnLoadActions025( ) ;
         AddRow025( ) ;
         bcResident.gxTpr_Inindividual.ClearCollection();
         if ( RcdFound5 == 1 )
         {
            ScanKeyStart026( ) ;
            nGXsfl_6_idx = 1;
            while ( RcdFound6 != 0 )
            {
               Z31ResidentId = A31ResidentId;
               Z42ResidentINIndividualId = A42ResidentINIndividualId;
               ZM026( -19) ;
               OnLoadActions026( ) ;
               nRcdExists_6 = 1;
               nIsMod_6 = 0;
               AddRow026( ) ;
               nGXsfl_6_idx = (int)(nGXsfl_6_idx+1);
               ScanKeyNext026( ) ;
            }
            ScanKeyEnd026( ) ;
         }
         bcResident.gxTpr_Incompany.ClearCollection();
         if ( RcdFound5 == 1 )
         {
            ScanKeyStart027( ) ;
            nGXsfl_7_idx = 1;
            while ( RcdFound7 != 0 )
            {
               Z31ResidentId = A31ResidentId;
               Z50ResidentINCompanyId = A50ResidentINCompanyId;
               ZM027( -20) ;
               OnLoadActions027( ) ;
               nRcdExists_7 = 1;
               nIsMod_7 = 0;
               AddRow027( ) ;
               nGXsfl_7_idx = (int)(nGXsfl_7_idx+1);
               ScanKeyNext027( ) ;
            }
            ScanKeyEnd027( ) ;
         }
         bcResident.gxTpr_Productservice.ClearCollection();
         if ( RcdFound5 == 1 )
         {
            ScanKeyStart0218( ) ;
            nGXsfl_18_idx = 1;
            while ( RcdFound18 != 0 )
            {
               Z31ResidentId = A31ResidentId;
               Z73ProductServiceId = A73ProductServiceId;
               ZM0218( -21) ;
               OnLoadActions0218( ) ;
               nRcdExists_18 = 1;
               nIsMod_18 = 0;
               AddRow0218( ) ;
               nGXsfl_18_idx = (int)(nGXsfl_18_idx+1);
               ScanKeyNext0218( ) ;
            }
            ScanKeyEnd0218( ) ;
         }
         ScanKeyEnd025( ) ;
         if ( RcdFound5 == 0 )
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
         RowToVars5( bcResident, 0) ;
         ScanKeyStart025( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z31ResidentId = A31ResidentId;
            O97ResidentLastLineCompany = A97ResidentLastLineCompany;
            O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
         }
         ZM025( -14) ;
         OnLoadActions025( ) ;
         AddRow025( ) ;
         bcResident.gxTpr_Inindividual.ClearCollection();
         if ( RcdFound5 == 1 )
         {
            ScanKeyStart026( ) ;
            nGXsfl_6_idx = 1;
            while ( RcdFound6 != 0 )
            {
               Z31ResidentId = A31ResidentId;
               Z42ResidentINIndividualId = A42ResidentINIndividualId;
               ZM026( -19) ;
               OnLoadActions026( ) ;
               nRcdExists_6 = 1;
               nIsMod_6 = 0;
               AddRow026( ) ;
               nGXsfl_6_idx = (int)(nGXsfl_6_idx+1);
               ScanKeyNext026( ) ;
            }
            ScanKeyEnd026( ) ;
         }
         bcResident.gxTpr_Incompany.ClearCollection();
         if ( RcdFound5 == 1 )
         {
            ScanKeyStart027( ) ;
            nGXsfl_7_idx = 1;
            while ( RcdFound7 != 0 )
            {
               Z31ResidentId = A31ResidentId;
               Z50ResidentINCompanyId = A50ResidentINCompanyId;
               ZM027( -20) ;
               OnLoadActions027( ) ;
               nRcdExists_7 = 1;
               nIsMod_7 = 0;
               AddRow027( ) ;
               nGXsfl_7_idx = (int)(nGXsfl_7_idx+1);
               ScanKeyNext027( ) ;
            }
            ScanKeyEnd027( ) ;
         }
         bcResident.gxTpr_Productservice.ClearCollection();
         if ( RcdFound5 == 1 )
         {
            ScanKeyStart0218( ) ;
            nGXsfl_18_idx = 1;
            while ( RcdFound18 != 0 )
            {
               Z31ResidentId = A31ResidentId;
               Z73ProductServiceId = A73ProductServiceId;
               ZM0218( -21) ;
               OnLoadActions0218( ) ;
               nRcdExists_18 = 1;
               nIsMod_18 = 0;
               AddRow0218( ) ;
               nGXsfl_18_idx = (int)(nGXsfl_18_idx+1);
               ScanKeyNext0218( ) ;
            }
            ScanKeyEnd0218( ) ;
         }
         ScanKeyEnd025( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey025( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
            A97ResidentLastLineCompany = O97ResidentLastLineCompany;
            Insert025( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A31ResidentId != Z31ResidentId )
               {
                  A31ResidentId = Z31ResidentId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                  A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                  A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                  Update025( ) ;
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
                  if ( A31ResidentId != Z31ResidentId )
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
                        A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                        A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                        Insert025( ) ;
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
                        A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                        A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                        Insert025( ) ;
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
         RowToVars5( bcResident, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcResident) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcResident, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
         A97ResidentLastLineCompany = O97ResidentLastLineCompany;
         Insert025( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcResident) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow5( bcResident) ;
         }
         else
         {
            SdtResident auxBC = new SdtResident(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A31ResidentId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcResident);
               auxBC.Save();
               bcResident.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars5( bcResident, 1) ;
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
         RowToVars5( bcResident, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert025( ) ;
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
               VarsToRow5( bcResident) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow5( bcResident) ;
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
         RowToVars5( bcResident, 0) ;
         GetKey025( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A31ResidentId != Z31ResidentId )
            {
               A31ResidentId = Z31ResidentId;
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
            if ( A31ResidentId != Z31ResidentId )
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
         context.RollbackDataStores("resident_bc",pr_default);
         VarsToRow5( bcResident) ;
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
         Gx_mode = bcResident.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcResident.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcResident )
         {
            bcResident = (SdtResident)(sdt);
            if ( StringUtil.StrCmp(bcResident.gxTpr_Mode, "") == 0 )
            {
               bcResident.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcResident) ;
            }
            else
            {
               RowToVars5( bcResident, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcResident.gxTpr_Mode, "") == 0 )
            {
               bcResident.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcResident, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtResident Resident_BC
      {
         get {
            return bcResident ;
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
            return "resident_Execute" ;
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
         pr_default.close(40);
         pr_default.close(41);
         pr_default.close(5);
         pr_default.close(7);
         pr_default.close(9);
         pr_default.close(20);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode5 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV34Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         A36ResidentEmail = "";
         Z39ResidentGAMGUID = "";
         A39ResidentGAMGUID = "";
         Z35ResidentInitials = "";
         A35ResidentInitials = "";
         Z40ResidentBsnNumber = "";
         A40ResidentBsnNumber = "";
         Z33ResidentGivenName = "";
         A33ResidentGivenName = "";
         Z34ResidentLastName = "";
         A34ResidentLastName = "";
         Z36ResidentEmail = "";
         Z102ResidentGender = "";
         A102ResidentGender = "";
         Z37ResidentAddress = "";
         A37ResidentAddress = "";
         Z38ResidentPhone = "";
         A38ResidentPhone = "";
         Z83ResidentTypeName = "";
         A83ResidentTypeName = "";
         Z3CustomerName = "";
         A3CustomerName = "";
         BC000215_A31ResidentId = new short[1] ;
         BC000215_A39ResidentGAMGUID = new string[] {""} ;
         BC000215_A35ResidentInitials = new string[] {""} ;
         BC000215_n35ResidentInitials = new bool[] {false} ;
         BC000215_A40ResidentBsnNumber = new string[] {""} ;
         BC000215_A33ResidentGivenName = new string[] {""} ;
         BC000215_A34ResidentLastName = new string[] {""} ;
         BC000215_A36ResidentEmail = new string[] {""} ;
         BC000215_A102ResidentGender = new string[] {""} ;
         BC000215_A37ResidentAddress = new string[] {""} ;
         BC000215_n37ResidentAddress = new bool[] {false} ;
         BC000215_A38ResidentPhone = new string[] {""} ;
         BC000215_n38ResidentPhone = new bool[] {false} ;
         BC000215_A83ResidentTypeName = new string[] {""} ;
         BC000215_A3CustomerName = new string[] {""} ;
         BC000215_A96ResidentLastLineIndividual = new short[1] ;
         BC000215_A97ResidentLastLineCompany = new short[1] ;
         BC000215_A82ResidentTypeId = new short[1] ;
         BC000215_A1CustomerId = new short[1] ;
         BC000215_A18CustomerLocationId = new short[1] ;
         BC000216_A40ResidentBsnNumber = new string[] {""} ;
         BC000212_A83ResidentTypeName = new string[] {""} ;
         BC000213_A3CustomerName = new string[] {""} ;
         BC000214_A1CustomerId = new short[1] ;
         BC000217_A31ResidentId = new short[1] ;
         BC000211_A31ResidentId = new short[1] ;
         BC000211_A39ResidentGAMGUID = new string[] {""} ;
         BC000211_A35ResidentInitials = new string[] {""} ;
         BC000211_n35ResidentInitials = new bool[] {false} ;
         BC000211_A40ResidentBsnNumber = new string[] {""} ;
         BC000211_A33ResidentGivenName = new string[] {""} ;
         BC000211_A34ResidentLastName = new string[] {""} ;
         BC000211_A36ResidentEmail = new string[] {""} ;
         BC000211_A102ResidentGender = new string[] {""} ;
         BC000211_A37ResidentAddress = new string[] {""} ;
         BC000211_n37ResidentAddress = new bool[] {false} ;
         BC000211_A38ResidentPhone = new string[] {""} ;
         BC000211_n38ResidentPhone = new bool[] {false} ;
         BC000211_A96ResidentLastLineIndividual = new short[1] ;
         BC000211_A97ResidentLastLineCompany = new short[1] ;
         BC000211_A82ResidentTypeId = new short[1] ;
         BC000211_A1CustomerId = new short[1] ;
         BC000211_A18CustomerLocationId = new short[1] ;
         BC000210_A31ResidentId = new short[1] ;
         BC000210_A39ResidentGAMGUID = new string[] {""} ;
         BC000210_A35ResidentInitials = new string[] {""} ;
         BC000210_n35ResidentInitials = new bool[] {false} ;
         BC000210_A40ResidentBsnNumber = new string[] {""} ;
         BC000210_A33ResidentGivenName = new string[] {""} ;
         BC000210_A34ResidentLastName = new string[] {""} ;
         BC000210_A36ResidentEmail = new string[] {""} ;
         BC000210_A102ResidentGender = new string[] {""} ;
         BC000210_A37ResidentAddress = new string[] {""} ;
         BC000210_n37ResidentAddress = new bool[] {false} ;
         BC000210_A38ResidentPhone = new string[] {""} ;
         BC000210_n38ResidentPhone = new bool[] {false} ;
         BC000210_A96ResidentLastLineIndividual = new short[1] ;
         BC000210_A97ResidentLastLineCompany = new short[1] ;
         BC000210_A82ResidentTypeId = new short[1] ;
         BC000210_A1CustomerId = new short[1] ;
         BC000210_A18CustomerLocationId = new short[1] ;
         BC000219_A31ResidentId = new short[1] ;
         BC000222_A83ResidentTypeName = new string[] {""} ;
         BC000223_A3CustomerName = new string[] {""} ;
         BC000225_A31ResidentId = new short[1] ;
         BC000225_A39ResidentGAMGUID = new string[] {""} ;
         BC000225_A35ResidentInitials = new string[] {""} ;
         BC000225_n35ResidentInitials = new bool[] {false} ;
         BC000225_A40ResidentBsnNumber = new string[] {""} ;
         BC000225_A33ResidentGivenName = new string[] {""} ;
         BC000225_A34ResidentLastName = new string[] {""} ;
         BC000225_A36ResidentEmail = new string[] {""} ;
         BC000225_A102ResidentGender = new string[] {""} ;
         BC000225_A37ResidentAddress = new string[] {""} ;
         BC000225_n37ResidentAddress = new bool[] {false} ;
         BC000225_A38ResidentPhone = new string[] {""} ;
         BC000225_n38ResidentPhone = new bool[] {false} ;
         BC000225_A83ResidentTypeName = new string[] {""} ;
         BC000225_A3CustomerName = new string[] {""} ;
         BC000225_A96ResidentLastLineIndividual = new short[1] ;
         BC000225_A97ResidentLastLineCompany = new short[1] ;
         BC000225_A82ResidentTypeId = new short[1] ;
         BC000225_A1CustomerId = new short[1] ;
         BC000225_A18CustomerLocationId = new short[1] ;
         Z43ResidentINIndividualBsnNumber = "";
         A43ResidentINIndividualBsnNumber = "";
         Z44ResidentINIndividualGivenName = "";
         A44ResidentINIndividualGivenName = "";
         Z45ResidentINIndividualLastName = "";
         A45ResidentINIndividualLastName = "";
         Z46ResidentINIndividualEmail = "";
         A46ResidentINIndividualEmail = "";
         Z47ResidentINIndividualPhone = "";
         A47ResidentINIndividualPhone = "";
         Z48ResidentINIndividualAddress = "";
         A48ResidentINIndividualAddress = "";
         Z49ResidentINIndividualGender = "";
         A49ResidentINIndividualGender = "";
         BC000226_A31ResidentId = new short[1] ;
         BC000226_A42ResidentINIndividualId = new short[1] ;
         BC000226_A43ResidentINIndividualBsnNumber = new string[] {""} ;
         BC000226_A44ResidentINIndividualGivenName = new string[] {""} ;
         BC000226_A45ResidentINIndividualLastName = new string[] {""} ;
         BC000226_A46ResidentINIndividualEmail = new string[] {""} ;
         BC000226_n46ResidentINIndividualEmail = new bool[] {false} ;
         BC000226_A47ResidentINIndividualPhone = new string[] {""} ;
         BC000226_n47ResidentINIndividualPhone = new bool[] {false} ;
         BC000226_A48ResidentINIndividualAddress = new string[] {""} ;
         BC000226_n48ResidentINIndividualAddress = new bool[] {false} ;
         BC000226_A49ResidentINIndividualGender = new string[] {""} ;
         BC000227_A31ResidentId = new short[1] ;
         BC000227_A42ResidentINIndividualId = new short[1] ;
         BC00029_A31ResidentId = new short[1] ;
         BC00029_A42ResidentINIndividualId = new short[1] ;
         BC00029_A43ResidentINIndividualBsnNumber = new string[] {""} ;
         BC00029_A44ResidentINIndividualGivenName = new string[] {""} ;
         BC00029_A45ResidentINIndividualLastName = new string[] {""} ;
         BC00029_A46ResidentINIndividualEmail = new string[] {""} ;
         BC00029_n46ResidentINIndividualEmail = new bool[] {false} ;
         BC00029_A47ResidentINIndividualPhone = new string[] {""} ;
         BC00029_n47ResidentINIndividualPhone = new bool[] {false} ;
         BC00029_A48ResidentINIndividualAddress = new string[] {""} ;
         BC00029_n48ResidentINIndividualAddress = new bool[] {false} ;
         BC00029_A49ResidentINIndividualGender = new string[] {""} ;
         sMode6 = "";
         BC00028_A31ResidentId = new short[1] ;
         BC00028_A42ResidentINIndividualId = new short[1] ;
         BC00028_A43ResidentINIndividualBsnNumber = new string[] {""} ;
         BC00028_A44ResidentINIndividualGivenName = new string[] {""} ;
         BC00028_A45ResidentINIndividualLastName = new string[] {""} ;
         BC00028_A46ResidentINIndividualEmail = new string[] {""} ;
         BC00028_n46ResidentINIndividualEmail = new bool[] {false} ;
         BC00028_A47ResidentINIndividualPhone = new string[] {""} ;
         BC00028_n47ResidentINIndividualPhone = new bool[] {false} ;
         BC00028_A48ResidentINIndividualAddress = new string[] {""} ;
         BC00028_n48ResidentINIndividualAddress = new bool[] {false} ;
         BC00028_A49ResidentINIndividualGender = new string[] {""} ;
         BC000231_A31ResidentId = new short[1] ;
         BC000231_A42ResidentINIndividualId = new short[1] ;
         BC000231_A43ResidentINIndividualBsnNumber = new string[] {""} ;
         BC000231_A44ResidentINIndividualGivenName = new string[] {""} ;
         BC000231_A45ResidentINIndividualLastName = new string[] {""} ;
         BC000231_A46ResidentINIndividualEmail = new string[] {""} ;
         BC000231_n46ResidentINIndividualEmail = new bool[] {false} ;
         BC000231_A47ResidentINIndividualPhone = new string[] {""} ;
         BC000231_n47ResidentINIndividualPhone = new bool[] {false} ;
         BC000231_A48ResidentINIndividualAddress = new string[] {""} ;
         BC000231_n48ResidentINIndividualAddress = new bool[] {false} ;
         BC000231_A49ResidentINIndividualGender = new string[] {""} ;
         Z51ResidentINCompanyKvkNumber = "";
         A51ResidentINCompanyKvkNumber = "";
         Z52ResidentINCompanyName = "";
         A52ResidentINCompanyName = "";
         Z53ResidentINCompanyEmail = "";
         A53ResidentINCompanyEmail = "";
         Z54ResidentINCompanyPhone = "";
         A54ResidentINCompanyPhone = "";
         BC000232_A31ResidentId = new short[1] ;
         BC000232_A50ResidentINCompanyId = new short[1] ;
         BC000232_A51ResidentINCompanyKvkNumber = new string[] {""} ;
         BC000232_A52ResidentINCompanyName = new string[] {""} ;
         BC000232_A53ResidentINCompanyEmail = new string[] {""} ;
         BC000232_n53ResidentINCompanyEmail = new bool[] {false} ;
         BC000232_A54ResidentINCompanyPhone = new string[] {""} ;
         BC000232_n54ResidentINCompanyPhone = new bool[] {false} ;
         BC000233_A31ResidentId = new short[1] ;
         BC000233_A50ResidentINCompanyId = new short[1] ;
         BC00027_A31ResidentId = new short[1] ;
         BC00027_A50ResidentINCompanyId = new short[1] ;
         BC00027_A51ResidentINCompanyKvkNumber = new string[] {""} ;
         BC00027_A52ResidentINCompanyName = new string[] {""} ;
         BC00027_A53ResidentINCompanyEmail = new string[] {""} ;
         BC00027_n53ResidentINCompanyEmail = new bool[] {false} ;
         BC00027_A54ResidentINCompanyPhone = new string[] {""} ;
         BC00027_n54ResidentINCompanyPhone = new bool[] {false} ;
         sMode7 = "";
         BC00026_A31ResidentId = new short[1] ;
         BC00026_A50ResidentINCompanyId = new short[1] ;
         BC00026_A51ResidentINCompanyKvkNumber = new string[] {""} ;
         BC00026_A52ResidentINCompanyName = new string[] {""} ;
         BC00026_A53ResidentINCompanyEmail = new string[] {""} ;
         BC00026_n53ResidentINCompanyEmail = new bool[] {false} ;
         BC00026_A54ResidentINCompanyPhone = new string[] {""} ;
         BC00026_n54ResidentINCompanyPhone = new bool[] {false} ;
         BC000237_A31ResidentId = new short[1] ;
         BC000237_A50ResidentINCompanyId = new short[1] ;
         BC000237_A51ResidentINCompanyKvkNumber = new string[] {""} ;
         BC000237_A52ResidentINCompanyName = new string[] {""} ;
         BC000237_A53ResidentINCompanyEmail = new string[] {""} ;
         BC000237_n53ResidentINCompanyEmail = new bool[] {false} ;
         BC000237_A54ResidentINCompanyPhone = new string[] {""} ;
         BC000237_n54ResidentINCompanyPhone = new bool[] {false} ;
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
         BC000238_A31ResidentId = new short[1] ;
         BC000238_A74ProductServiceName = new string[] {""} ;
         BC000238_A75ProductServiceDescription = new string[] {""} ;
         BC000238_A76ProductServiceQuantity = new short[1] ;
         BC000238_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC000238_A72ProductServiceTypeName = new string[] {""} ;
         BC000238_A73ProductServiceId = new short[1] ;
         BC000238_A71ProductServiceTypeId = new short[1] ;
         BC000238_A77ProductServicePicture = new string[] {""} ;
         BC00024_A74ProductServiceName = new string[] {""} ;
         BC00024_A75ProductServiceDescription = new string[] {""} ;
         BC00024_A76ProductServiceQuantity = new short[1] ;
         BC00024_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC00024_A71ProductServiceTypeId = new short[1] ;
         BC00024_A77ProductServicePicture = new string[] {""} ;
         BC00025_A72ProductServiceTypeName = new string[] {""} ;
         BC000239_A31ResidentId = new short[1] ;
         BC000239_A73ProductServiceId = new short[1] ;
         BC00023_A31ResidentId = new short[1] ;
         BC00023_A73ProductServiceId = new short[1] ;
         sMode18 = "";
         BC00022_A31ResidentId = new short[1] ;
         BC00022_A73ProductServiceId = new short[1] ;
         BC000242_A74ProductServiceName = new string[] {""} ;
         BC000242_A75ProductServiceDescription = new string[] {""} ;
         BC000242_A76ProductServiceQuantity = new short[1] ;
         BC000242_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC000242_A71ProductServiceTypeId = new short[1] ;
         BC000242_A77ProductServicePicture = new string[] {""} ;
         BC000243_A72ProductServiceTypeName = new string[] {""} ;
         BC000244_A31ResidentId = new short[1] ;
         BC000244_A74ProductServiceName = new string[] {""} ;
         BC000244_A75ProductServiceDescription = new string[] {""} ;
         BC000244_A76ProductServiceQuantity = new short[1] ;
         BC000244_A40000ProductServicePicture_GXI = new string[] {""} ;
         BC000244_A72ProductServiceTypeName = new string[] {""} ;
         BC000244_A73ProductServiceId = new short[1] ;
         BC000244_A71ProductServiceTypeId = new short[1] ;
         BC000244_A77ProductServicePicture = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.resident_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.resident_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A31ResidentId, BC00022_A73ProductServiceId
               }
               , new Object[] {
               BC00023_A31ResidentId, BC00023_A73ProductServiceId
               }
               , new Object[] {
               BC00024_A74ProductServiceName, BC00024_A75ProductServiceDescription, BC00024_A76ProductServiceQuantity, BC00024_A40000ProductServicePicture_GXI, BC00024_A71ProductServiceTypeId, BC00024_A77ProductServicePicture
               }
               , new Object[] {
               BC00025_A72ProductServiceTypeName
               }
               , new Object[] {
               BC00026_A31ResidentId, BC00026_A50ResidentINCompanyId, BC00026_A51ResidentINCompanyKvkNumber, BC00026_A52ResidentINCompanyName, BC00026_A53ResidentINCompanyEmail, BC00026_n53ResidentINCompanyEmail, BC00026_A54ResidentINCompanyPhone, BC00026_n54ResidentINCompanyPhone
               }
               , new Object[] {
               BC00027_A31ResidentId, BC00027_A50ResidentINCompanyId, BC00027_A51ResidentINCompanyKvkNumber, BC00027_A52ResidentINCompanyName, BC00027_A53ResidentINCompanyEmail, BC00027_n53ResidentINCompanyEmail, BC00027_A54ResidentINCompanyPhone, BC00027_n54ResidentINCompanyPhone
               }
               , new Object[] {
               BC00028_A31ResidentId, BC00028_A42ResidentINIndividualId, BC00028_A43ResidentINIndividualBsnNumber, BC00028_A44ResidentINIndividualGivenName, BC00028_A45ResidentINIndividualLastName, BC00028_A46ResidentINIndividualEmail, BC00028_n46ResidentINIndividualEmail, BC00028_A47ResidentINIndividualPhone, BC00028_n47ResidentINIndividualPhone, BC00028_A48ResidentINIndividualAddress,
               BC00028_n48ResidentINIndividualAddress, BC00028_A49ResidentINIndividualGender
               }
               , new Object[] {
               BC00029_A31ResidentId, BC00029_A42ResidentINIndividualId, BC00029_A43ResidentINIndividualBsnNumber, BC00029_A44ResidentINIndividualGivenName, BC00029_A45ResidentINIndividualLastName, BC00029_A46ResidentINIndividualEmail, BC00029_n46ResidentINIndividualEmail, BC00029_A47ResidentINIndividualPhone, BC00029_n47ResidentINIndividualPhone, BC00029_A48ResidentINIndividualAddress,
               BC00029_n48ResidentINIndividualAddress, BC00029_A49ResidentINIndividualGender
               }
               , new Object[] {
               BC000210_A31ResidentId, BC000210_A39ResidentGAMGUID, BC000210_A35ResidentInitials, BC000210_n35ResidentInitials, BC000210_A40ResidentBsnNumber, BC000210_A33ResidentGivenName, BC000210_A34ResidentLastName, BC000210_A36ResidentEmail, BC000210_A102ResidentGender, BC000210_A37ResidentAddress,
               BC000210_n37ResidentAddress, BC000210_A38ResidentPhone, BC000210_n38ResidentPhone, BC000210_A96ResidentLastLineIndividual, BC000210_A97ResidentLastLineCompany, BC000210_A82ResidentTypeId, BC000210_A1CustomerId, BC000210_A18CustomerLocationId
               }
               , new Object[] {
               BC000211_A31ResidentId, BC000211_A39ResidentGAMGUID, BC000211_A35ResidentInitials, BC000211_n35ResidentInitials, BC000211_A40ResidentBsnNumber, BC000211_A33ResidentGivenName, BC000211_A34ResidentLastName, BC000211_A36ResidentEmail, BC000211_A102ResidentGender, BC000211_A37ResidentAddress,
               BC000211_n37ResidentAddress, BC000211_A38ResidentPhone, BC000211_n38ResidentPhone, BC000211_A96ResidentLastLineIndividual, BC000211_A97ResidentLastLineCompany, BC000211_A82ResidentTypeId, BC000211_A1CustomerId, BC000211_A18CustomerLocationId
               }
               , new Object[] {
               BC000212_A83ResidentTypeName
               }
               , new Object[] {
               BC000213_A3CustomerName
               }
               , new Object[] {
               BC000214_A1CustomerId
               }
               , new Object[] {
               BC000215_A31ResidentId, BC000215_A39ResidentGAMGUID, BC000215_A35ResidentInitials, BC000215_n35ResidentInitials, BC000215_A40ResidentBsnNumber, BC000215_A33ResidentGivenName, BC000215_A34ResidentLastName, BC000215_A36ResidentEmail, BC000215_A102ResidentGender, BC000215_A37ResidentAddress,
               BC000215_n37ResidentAddress, BC000215_A38ResidentPhone, BC000215_n38ResidentPhone, BC000215_A83ResidentTypeName, BC000215_A3CustomerName, BC000215_A96ResidentLastLineIndividual, BC000215_A97ResidentLastLineCompany, BC000215_A82ResidentTypeId, BC000215_A1CustomerId, BC000215_A18CustomerLocationId
               }
               , new Object[] {
               BC000216_A40ResidentBsnNumber
               }
               , new Object[] {
               BC000217_A31ResidentId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000219_A31ResidentId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000222_A83ResidentTypeName
               }
               , new Object[] {
               BC000223_A3CustomerName
               }
               , new Object[] {
               }
               , new Object[] {
               BC000225_A31ResidentId, BC000225_A39ResidentGAMGUID, BC000225_A35ResidentInitials, BC000225_n35ResidentInitials, BC000225_A40ResidentBsnNumber, BC000225_A33ResidentGivenName, BC000225_A34ResidentLastName, BC000225_A36ResidentEmail, BC000225_A102ResidentGender, BC000225_A37ResidentAddress,
               BC000225_n37ResidentAddress, BC000225_A38ResidentPhone, BC000225_n38ResidentPhone, BC000225_A83ResidentTypeName, BC000225_A3CustomerName, BC000225_A96ResidentLastLineIndividual, BC000225_A97ResidentLastLineCompany, BC000225_A82ResidentTypeId, BC000225_A1CustomerId, BC000225_A18CustomerLocationId
               }
               , new Object[] {
               BC000226_A31ResidentId, BC000226_A42ResidentINIndividualId, BC000226_A43ResidentINIndividualBsnNumber, BC000226_A44ResidentINIndividualGivenName, BC000226_A45ResidentINIndividualLastName, BC000226_A46ResidentINIndividualEmail, BC000226_n46ResidentINIndividualEmail, BC000226_A47ResidentINIndividualPhone, BC000226_n47ResidentINIndividualPhone, BC000226_A48ResidentINIndividualAddress,
               BC000226_n48ResidentINIndividualAddress, BC000226_A49ResidentINIndividualGender
               }
               , new Object[] {
               BC000227_A31ResidentId, BC000227_A42ResidentINIndividualId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000231_A31ResidentId, BC000231_A42ResidentINIndividualId, BC000231_A43ResidentINIndividualBsnNumber, BC000231_A44ResidentINIndividualGivenName, BC000231_A45ResidentINIndividualLastName, BC000231_A46ResidentINIndividualEmail, BC000231_n46ResidentINIndividualEmail, BC000231_A47ResidentINIndividualPhone, BC000231_n47ResidentINIndividualPhone, BC000231_A48ResidentINIndividualAddress,
               BC000231_n48ResidentINIndividualAddress, BC000231_A49ResidentINIndividualGender
               }
               , new Object[] {
               BC000232_A31ResidentId, BC000232_A50ResidentINCompanyId, BC000232_A51ResidentINCompanyKvkNumber, BC000232_A52ResidentINCompanyName, BC000232_A53ResidentINCompanyEmail, BC000232_n53ResidentINCompanyEmail, BC000232_A54ResidentINCompanyPhone, BC000232_n54ResidentINCompanyPhone
               }
               , new Object[] {
               BC000233_A31ResidentId, BC000233_A50ResidentINCompanyId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000237_A31ResidentId, BC000237_A50ResidentINCompanyId, BC000237_A51ResidentINCompanyKvkNumber, BC000237_A52ResidentINCompanyName, BC000237_A53ResidentINCompanyEmail, BC000237_n53ResidentINCompanyEmail, BC000237_A54ResidentINCompanyPhone, BC000237_n54ResidentINCompanyPhone
               }
               , new Object[] {
               BC000238_A31ResidentId, BC000238_A74ProductServiceName, BC000238_A75ProductServiceDescription, BC000238_A76ProductServiceQuantity, BC000238_A40000ProductServicePicture_GXI, BC000238_A72ProductServiceTypeName, BC000238_A73ProductServiceId, BC000238_A71ProductServiceTypeId, BC000238_A77ProductServicePicture
               }
               , new Object[] {
               BC000239_A31ResidentId, BC000239_A73ProductServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000242_A74ProductServiceName, BC000242_A75ProductServiceDescription, BC000242_A76ProductServiceQuantity, BC000242_A40000ProductServicePicture_GXI, BC000242_A71ProductServiceTypeId, BC000242_A77ProductServicePicture
               }
               , new Object[] {
               BC000243_A72ProductServiceTypeName
               }
               , new Object[] {
               BC000244_A31ResidentId, BC000244_A74ProductServiceName, BC000244_A75ProductServiceDescription, BC000244_A76ProductServiceQuantity, BC000244_A40000ProductServicePicture_GXI, BC000244_A72ProductServiceTypeName, BC000244_A73ProductServiceId, BC000244_A71ProductServiceTypeId, BC000244_A77ProductServicePicture
               }
            }
         );
         AV34Pgmname = "Resident_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z31ResidentId ;
      private short A31ResidentId ;
      private short nIsMod_18 ;
      private short RcdFound18 ;
      private short s97ResidentLastLineCompany ;
      private short O97ResidentLastLineCompany ;
      private short A97ResidentLastLineCompany ;
      private short nIsMod_7 ;
      private short RcdFound7 ;
      private short s96ResidentLastLineIndividual ;
      private short O96ResidentLastLineIndividual ;
      private short A96ResidentLastLineIndividual ;
      private short nIsMod_6 ;
      private short RcdFound6 ;
      private short AV13Insert_ResidentTypeId ;
      private short AV27Insert_CustomerId ;
      private short AV28Insert_CustomerLocationId ;
      private short Z96ResidentLastLineIndividual ;
      private short Z97ResidentLastLineCompany ;
      private short Z82ResidentTypeId ;
      private short A82ResidentTypeId ;
      private short Z1CustomerId ;
      private short A1CustomerId ;
      private short Z18CustomerLocationId ;
      private short A18CustomerLocationId ;
      private short RcdFound5 ;
      private short nRcdExists_6 ;
      private short nRcdExists_7 ;
      private short nRcdExists_18 ;
      private short Z42ResidentINIndividualId ;
      private short A42ResidentINIndividualId ;
      private short Gx_BScreen ;
      private short Gxremove6 ;
      private short Z50ResidentINCompanyId ;
      private short A50ResidentINCompanyId ;
      private short Gxremove7 ;
      private short Z76ProductServiceQuantity ;
      private short A76ProductServiceQuantity ;
      private short Z71ProductServiceTypeId ;
      private short A71ProductServiceTypeId ;
      private short Z73ProductServiceId ;
      private short A73ProductServiceId ;
      private short Gxremove18 ;
      private short i96ResidentLastLineIndividual ;
      private short i97ResidentLastLineCompany ;
      private int trnEnded ;
      private int nGXsfl_18_idx=1 ;
      private int nGXsfl_7_idx=1 ;
      private int nGXsfl_6_idx=1 ;
      private int AV35GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode5 ;
      private string AV34Pgmname ;
      private string Z35ResidentInitials ;
      private string A35ResidentInitials ;
      private string Z102ResidentGender ;
      private string A102ResidentGender ;
      private string Z38ResidentPhone ;
      private string A38ResidentPhone ;
      private string Z47ResidentINIndividualPhone ;
      private string A47ResidentINIndividualPhone ;
      private string Z49ResidentINIndividualGender ;
      private string A49ResidentINIndividualGender ;
      private string sMode6 ;
      private string Z54ResidentINCompanyPhone ;
      private string A54ResidentINCompanyPhone ;
      private string sMode7 ;
      private string sMode18 ;
      private bool returnInSub ;
      private bool n35ResidentInitials ;
      private bool n37ResidentAddress ;
      private bool n38ResidentPhone ;
      private bool Gx_longc ;
      private bool n46ResidentINIndividualEmail ;
      private bool n47ResidentINIndividualPhone ;
      private bool n48ResidentINIndividualAddress ;
      private bool n53ResidentINCompanyEmail ;
      private bool n54ResidentINCompanyPhone ;
      private string A36ResidentEmail ;
      private string Z39ResidentGAMGUID ;
      private string A39ResidentGAMGUID ;
      private string Z40ResidentBsnNumber ;
      private string A40ResidentBsnNumber ;
      private string Z33ResidentGivenName ;
      private string A33ResidentGivenName ;
      private string Z34ResidentLastName ;
      private string A34ResidentLastName ;
      private string Z36ResidentEmail ;
      private string Z37ResidentAddress ;
      private string A37ResidentAddress ;
      private string Z83ResidentTypeName ;
      private string A83ResidentTypeName ;
      private string Z3CustomerName ;
      private string A3CustomerName ;
      private string Z43ResidentINIndividualBsnNumber ;
      private string A43ResidentINIndividualBsnNumber ;
      private string Z44ResidentINIndividualGivenName ;
      private string A44ResidentINIndividualGivenName ;
      private string Z45ResidentINIndividualLastName ;
      private string A45ResidentINIndividualLastName ;
      private string Z46ResidentINIndividualEmail ;
      private string A46ResidentINIndividualEmail ;
      private string Z48ResidentINIndividualAddress ;
      private string A48ResidentINIndividualAddress ;
      private string Z51ResidentINCompanyKvkNumber ;
      private string A51ResidentINCompanyKvkNumber ;
      private string Z52ResidentINCompanyName ;
      private string A52ResidentINCompanyName ;
      private string Z53ResidentINCompanyEmail ;
      private string A53ResidentINCompanyEmail ;
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
      private SdtResident bcResident ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] BC000215_A31ResidentId ;
      private string[] BC000215_A39ResidentGAMGUID ;
      private string[] BC000215_A35ResidentInitials ;
      private bool[] BC000215_n35ResidentInitials ;
      private string[] BC000215_A40ResidentBsnNumber ;
      private string[] BC000215_A33ResidentGivenName ;
      private string[] BC000215_A34ResidentLastName ;
      private string[] BC000215_A36ResidentEmail ;
      private string[] BC000215_A102ResidentGender ;
      private string[] BC000215_A37ResidentAddress ;
      private bool[] BC000215_n37ResidentAddress ;
      private string[] BC000215_A38ResidentPhone ;
      private bool[] BC000215_n38ResidentPhone ;
      private string[] BC000215_A83ResidentTypeName ;
      private string[] BC000215_A3CustomerName ;
      private short[] BC000215_A96ResidentLastLineIndividual ;
      private short[] BC000215_A97ResidentLastLineCompany ;
      private short[] BC000215_A82ResidentTypeId ;
      private short[] BC000215_A1CustomerId ;
      private short[] BC000215_A18CustomerLocationId ;
      private string[] BC000216_A40ResidentBsnNumber ;
      private string[] BC000212_A83ResidentTypeName ;
      private string[] BC000213_A3CustomerName ;
      private short[] BC000214_A1CustomerId ;
      private short[] BC000217_A31ResidentId ;
      private short[] BC000211_A31ResidentId ;
      private string[] BC000211_A39ResidentGAMGUID ;
      private string[] BC000211_A35ResidentInitials ;
      private bool[] BC000211_n35ResidentInitials ;
      private string[] BC000211_A40ResidentBsnNumber ;
      private string[] BC000211_A33ResidentGivenName ;
      private string[] BC000211_A34ResidentLastName ;
      private string[] BC000211_A36ResidentEmail ;
      private string[] BC000211_A102ResidentGender ;
      private string[] BC000211_A37ResidentAddress ;
      private bool[] BC000211_n37ResidentAddress ;
      private string[] BC000211_A38ResidentPhone ;
      private bool[] BC000211_n38ResidentPhone ;
      private short[] BC000211_A96ResidentLastLineIndividual ;
      private short[] BC000211_A97ResidentLastLineCompany ;
      private short[] BC000211_A82ResidentTypeId ;
      private short[] BC000211_A1CustomerId ;
      private short[] BC000211_A18CustomerLocationId ;
      private short[] BC000210_A31ResidentId ;
      private string[] BC000210_A39ResidentGAMGUID ;
      private string[] BC000210_A35ResidentInitials ;
      private bool[] BC000210_n35ResidentInitials ;
      private string[] BC000210_A40ResidentBsnNumber ;
      private string[] BC000210_A33ResidentGivenName ;
      private string[] BC000210_A34ResidentLastName ;
      private string[] BC000210_A36ResidentEmail ;
      private string[] BC000210_A102ResidentGender ;
      private string[] BC000210_A37ResidentAddress ;
      private bool[] BC000210_n37ResidentAddress ;
      private string[] BC000210_A38ResidentPhone ;
      private bool[] BC000210_n38ResidentPhone ;
      private short[] BC000210_A96ResidentLastLineIndividual ;
      private short[] BC000210_A97ResidentLastLineCompany ;
      private short[] BC000210_A82ResidentTypeId ;
      private short[] BC000210_A1CustomerId ;
      private short[] BC000210_A18CustomerLocationId ;
      private short[] BC000219_A31ResidentId ;
      private string[] BC000222_A83ResidentTypeName ;
      private string[] BC000223_A3CustomerName ;
      private short[] BC000225_A31ResidentId ;
      private string[] BC000225_A39ResidentGAMGUID ;
      private string[] BC000225_A35ResidentInitials ;
      private bool[] BC000225_n35ResidentInitials ;
      private string[] BC000225_A40ResidentBsnNumber ;
      private string[] BC000225_A33ResidentGivenName ;
      private string[] BC000225_A34ResidentLastName ;
      private string[] BC000225_A36ResidentEmail ;
      private string[] BC000225_A102ResidentGender ;
      private string[] BC000225_A37ResidentAddress ;
      private bool[] BC000225_n37ResidentAddress ;
      private string[] BC000225_A38ResidentPhone ;
      private bool[] BC000225_n38ResidentPhone ;
      private string[] BC000225_A83ResidentTypeName ;
      private string[] BC000225_A3CustomerName ;
      private short[] BC000225_A96ResidentLastLineIndividual ;
      private short[] BC000225_A97ResidentLastLineCompany ;
      private short[] BC000225_A82ResidentTypeId ;
      private short[] BC000225_A1CustomerId ;
      private short[] BC000225_A18CustomerLocationId ;
      private short[] BC000226_A31ResidentId ;
      private short[] BC000226_A42ResidentINIndividualId ;
      private string[] BC000226_A43ResidentINIndividualBsnNumber ;
      private string[] BC000226_A44ResidentINIndividualGivenName ;
      private string[] BC000226_A45ResidentINIndividualLastName ;
      private string[] BC000226_A46ResidentINIndividualEmail ;
      private bool[] BC000226_n46ResidentINIndividualEmail ;
      private string[] BC000226_A47ResidentINIndividualPhone ;
      private bool[] BC000226_n47ResidentINIndividualPhone ;
      private string[] BC000226_A48ResidentINIndividualAddress ;
      private bool[] BC000226_n48ResidentINIndividualAddress ;
      private string[] BC000226_A49ResidentINIndividualGender ;
      private short[] BC000227_A31ResidentId ;
      private short[] BC000227_A42ResidentINIndividualId ;
      private short[] BC00029_A31ResidentId ;
      private short[] BC00029_A42ResidentINIndividualId ;
      private string[] BC00029_A43ResidentINIndividualBsnNumber ;
      private string[] BC00029_A44ResidentINIndividualGivenName ;
      private string[] BC00029_A45ResidentINIndividualLastName ;
      private string[] BC00029_A46ResidentINIndividualEmail ;
      private bool[] BC00029_n46ResidentINIndividualEmail ;
      private string[] BC00029_A47ResidentINIndividualPhone ;
      private bool[] BC00029_n47ResidentINIndividualPhone ;
      private string[] BC00029_A48ResidentINIndividualAddress ;
      private bool[] BC00029_n48ResidentINIndividualAddress ;
      private string[] BC00029_A49ResidentINIndividualGender ;
      private short[] BC00028_A31ResidentId ;
      private short[] BC00028_A42ResidentINIndividualId ;
      private string[] BC00028_A43ResidentINIndividualBsnNumber ;
      private string[] BC00028_A44ResidentINIndividualGivenName ;
      private string[] BC00028_A45ResidentINIndividualLastName ;
      private string[] BC00028_A46ResidentINIndividualEmail ;
      private bool[] BC00028_n46ResidentINIndividualEmail ;
      private string[] BC00028_A47ResidentINIndividualPhone ;
      private bool[] BC00028_n47ResidentINIndividualPhone ;
      private string[] BC00028_A48ResidentINIndividualAddress ;
      private bool[] BC00028_n48ResidentINIndividualAddress ;
      private string[] BC00028_A49ResidentINIndividualGender ;
      private short[] BC000231_A31ResidentId ;
      private short[] BC000231_A42ResidentINIndividualId ;
      private string[] BC000231_A43ResidentINIndividualBsnNumber ;
      private string[] BC000231_A44ResidentINIndividualGivenName ;
      private string[] BC000231_A45ResidentINIndividualLastName ;
      private string[] BC000231_A46ResidentINIndividualEmail ;
      private bool[] BC000231_n46ResidentINIndividualEmail ;
      private string[] BC000231_A47ResidentINIndividualPhone ;
      private bool[] BC000231_n47ResidentINIndividualPhone ;
      private string[] BC000231_A48ResidentINIndividualAddress ;
      private bool[] BC000231_n48ResidentINIndividualAddress ;
      private string[] BC000231_A49ResidentINIndividualGender ;
      private short[] BC000232_A31ResidentId ;
      private short[] BC000232_A50ResidentINCompanyId ;
      private string[] BC000232_A51ResidentINCompanyKvkNumber ;
      private string[] BC000232_A52ResidentINCompanyName ;
      private string[] BC000232_A53ResidentINCompanyEmail ;
      private bool[] BC000232_n53ResidentINCompanyEmail ;
      private string[] BC000232_A54ResidentINCompanyPhone ;
      private bool[] BC000232_n54ResidentINCompanyPhone ;
      private short[] BC000233_A31ResidentId ;
      private short[] BC000233_A50ResidentINCompanyId ;
      private short[] BC00027_A31ResidentId ;
      private short[] BC00027_A50ResidentINCompanyId ;
      private string[] BC00027_A51ResidentINCompanyKvkNumber ;
      private string[] BC00027_A52ResidentINCompanyName ;
      private string[] BC00027_A53ResidentINCompanyEmail ;
      private bool[] BC00027_n53ResidentINCompanyEmail ;
      private string[] BC00027_A54ResidentINCompanyPhone ;
      private bool[] BC00027_n54ResidentINCompanyPhone ;
      private short[] BC00026_A31ResidentId ;
      private short[] BC00026_A50ResidentINCompanyId ;
      private string[] BC00026_A51ResidentINCompanyKvkNumber ;
      private string[] BC00026_A52ResidentINCompanyName ;
      private string[] BC00026_A53ResidentINCompanyEmail ;
      private bool[] BC00026_n53ResidentINCompanyEmail ;
      private string[] BC00026_A54ResidentINCompanyPhone ;
      private bool[] BC00026_n54ResidentINCompanyPhone ;
      private short[] BC000237_A31ResidentId ;
      private short[] BC000237_A50ResidentINCompanyId ;
      private string[] BC000237_A51ResidentINCompanyKvkNumber ;
      private string[] BC000237_A52ResidentINCompanyName ;
      private string[] BC000237_A53ResidentINCompanyEmail ;
      private bool[] BC000237_n53ResidentINCompanyEmail ;
      private string[] BC000237_A54ResidentINCompanyPhone ;
      private bool[] BC000237_n54ResidentINCompanyPhone ;
      private short[] BC000238_A31ResidentId ;
      private string[] BC000238_A74ProductServiceName ;
      private string[] BC000238_A75ProductServiceDescription ;
      private short[] BC000238_A76ProductServiceQuantity ;
      private string[] BC000238_A40000ProductServicePicture_GXI ;
      private string[] BC000238_A72ProductServiceTypeName ;
      private short[] BC000238_A73ProductServiceId ;
      private short[] BC000238_A71ProductServiceTypeId ;
      private string[] BC000238_A77ProductServicePicture ;
      private string[] BC00024_A74ProductServiceName ;
      private string[] BC00024_A75ProductServiceDescription ;
      private short[] BC00024_A76ProductServiceQuantity ;
      private string[] BC00024_A40000ProductServicePicture_GXI ;
      private short[] BC00024_A71ProductServiceTypeId ;
      private string[] BC00024_A77ProductServicePicture ;
      private string[] BC00025_A72ProductServiceTypeName ;
      private short[] BC000239_A31ResidentId ;
      private short[] BC000239_A73ProductServiceId ;
      private short[] BC00023_A31ResidentId ;
      private short[] BC00023_A73ProductServiceId ;
      private short[] BC00022_A31ResidentId ;
      private short[] BC00022_A73ProductServiceId ;
      private string[] BC000242_A74ProductServiceName ;
      private string[] BC000242_A75ProductServiceDescription ;
      private short[] BC000242_A76ProductServiceQuantity ;
      private string[] BC000242_A40000ProductServicePicture_GXI ;
      private short[] BC000242_A71ProductServiceTypeId ;
      private string[] BC000242_A77ProductServicePicture ;
      private string[] BC000243_A72ProductServiceTypeName ;
      private short[] BC000244_A31ResidentId ;
      private string[] BC000244_A74ProductServiceName ;
      private string[] BC000244_A75ProductServiceDescription ;
      private short[] BC000244_A76ProductServiceQuantity ;
      private string[] BC000244_A40000ProductServicePicture_GXI ;
      private string[] BC000244_A72ProductServiceTypeName ;
      private short[] BC000244_A73ProductServiceId ;
      private short[] BC000244_A71ProductServiceTypeId ;
      private string[] BC000244_A77ProductServicePicture ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class resident_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class resident_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new UpdateCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new UpdateCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new UpdateCursor(def[38])
       ,new UpdateCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00022;
        prmBC00022 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC00023;
        prmBC00023 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC00024;
        prmBC00024 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC00025;
        prmBC00025 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC00026;
        prmBC00026 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmBC00027;
        prmBC00027 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmBC00028;
        prmBC00028 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmBC00029;
        prmBC00029 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmBC000210;
        prmBC000210 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000211;
        prmBC000211 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000212;
        prmBC000212 = new Object[] {
        new ParDef("ResidentTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC000213;
        prmBC000213 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000214;
        prmBC000214 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000215;
        prmBC000215 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000216;
        prmBC000216 = new Object[] {
        new ParDef("ResidentBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000217;
        prmBC000217 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000218;
        prmBC000218 = new Object[] {
        new ParDef("ResidentGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("ResidentInitials",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentGivenName",GXType.VarChar,40,0) ,
        new ParDef("ResidentLastName",GXType.VarChar,40,0) ,
        new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
        new ParDef("ResidentGender",GXType.Char,20,0) ,
        new ParDef("ResidentAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("ResidentPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentLastLineIndividual",GXType.Int16,4,0) ,
        new ParDef("ResidentLastLineCompany",GXType.Int16,4,0) ,
        new ParDef("ResidentTypeId",GXType.Int16,4,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000219;
        prmBC000219 = new Object[] {
        };
        Object[] prmBC000220;
        prmBC000220 = new Object[] {
        new ParDef("ResidentGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("ResidentInitials",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentGivenName",GXType.VarChar,40,0) ,
        new ParDef("ResidentLastName",GXType.VarChar,40,0) ,
        new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
        new ParDef("ResidentGender",GXType.Char,20,0) ,
        new ParDef("ResidentAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("ResidentPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentLastLineIndividual",GXType.Int16,4,0) ,
        new ParDef("ResidentLastLineCompany",GXType.Int16,4,0) ,
        new ParDef("ResidentTypeId",GXType.Int16,4,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000221;
        prmBC000221 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000222;
        prmBC000222 = new Object[] {
        new ParDef("ResidentTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC000223;
        prmBC000223 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmBC000224;
        prmBC000224 = new Object[] {
        new ParDef("ResidentLastLineCompany",GXType.Int16,4,0) ,
        new ParDef("ResidentLastLineIndividual",GXType.Int16,4,0) ,
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000225;
        prmBC000225 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000226;
        prmBC000226 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmBC000227;
        prmBC000227 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmBC000228;
        prmBC000228 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualGivenName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualLastName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("ResidentINIndividualPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentINIndividualAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("ResidentINIndividualGender",GXType.Char,20,0)
        };
        Object[] prmBC000229;
        prmBC000229 = new Object[] {
        new ParDef("ResidentINIndividualBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualGivenName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualLastName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("ResidentINIndividualPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentINIndividualAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("ResidentINIndividualGender",GXType.Char,20,0) ,
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmBC000230;
        prmBC000230 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmBC000231;
        prmBC000231 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000232;
        prmBC000232 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmBC000233;
        prmBC000233 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmBC000234;
        prmBC000234 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("ResidentINCompanyName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINCompanyEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("ResidentINCompanyPhone",GXType.Char,20,0){Nullable=true}
        };
        Object[] prmBC000235;
        prmBC000235 = new Object[] {
        new ParDef("ResidentINCompanyKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("ResidentINCompanyName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINCompanyEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("ResidentINCompanyPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmBC000236;
        prmBC000236 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmBC000237;
        prmBC000237 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmBC000238;
        prmBC000238 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000239;
        prmBC000239 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000240;
        prmBC000240 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000241;
        prmBC000241 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000242;
        prmBC000242 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmBC000243;
        prmBC000243 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmBC000244;
        prmBC000244 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00022", "SELECT ResidentId, ProductServiceId FROM ResidentProductService WHERE ResidentId = :ResidentId AND ProductServiceId = :ProductServiceId  FOR UPDATE OF ResidentProductService",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00023", "SELECT ResidentId, ProductServiceId FROM ResidentProductService WHERE ResidentId = :ResidentId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00024", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00025", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00026", "SELECT ResidentId, ResidentINCompanyId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone FROM ResidentINCompany WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId  FOR UPDATE OF ResidentINCompany",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00027", "SELECT ResidentId, ResidentINCompanyId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone FROM ResidentINCompany WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00028", "SELECT ResidentId, ResidentINIndividualId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualGender FROM ResidentINIndividual WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId  FOR UPDATE OF ResidentINIndividual",true, GxErrorMask.GX_NOMASK, false, this,prmBC00028,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00029", "SELECT ResidentId, ResidentINIndividualId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualGender FROM ResidentINIndividual WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00029,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000210", "SELECT ResidentId, ResidentGAMGUID, ResidentInitials, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentAddress, ResidentPhone, ResidentLastLineIndividual, ResidentLastLineCompany, ResidentTypeId, CustomerId, CustomerLocationId FROM Resident WHERE ResidentId = :ResidentId  FOR UPDATE OF Resident",true, GxErrorMask.GX_NOMASK, false, this,prmBC000210,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000211", "SELECT ResidentId, ResidentGAMGUID, ResidentInitials, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentAddress, ResidentPhone, ResidentLastLineIndividual, ResidentLastLineCompany, ResidentTypeId, CustomerId, CustomerLocationId FROM Resident WHERE ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000211,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000212", "SELECT ResidentTypeName FROM ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000212,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000213", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000213,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000214", "SELECT CustomerId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000214,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000215", "SELECT TM1.ResidentId, TM1.ResidentGAMGUID, TM1.ResidentInitials, TM1.ResidentBsnNumber, TM1.ResidentGivenName, TM1.ResidentLastName, TM1.ResidentEmail, TM1.ResidentGender, TM1.ResidentAddress, TM1.ResidentPhone, T2.ResidentTypeName, T3.CustomerName, TM1.ResidentLastLineIndividual, TM1.ResidentLastLineCompany, TM1.ResidentTypeId, TM1.CustomerId, TM1.CustomerLocationId FROM ((Resident TM1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = TM1.ResidentTypeId) INNER JOIN Customer T3 ON T3.CustomerId = TM1.CustomerId) WHERE TM1.ResidentId = :ResidentId ORDER BY TM1.ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000215,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000216", "SELECT ResidentBsnNumber FROM Resident WHERE (ResidentBsnNumber = :ResidentBsnNumber) AND (Not ( ResidentId = :ResidentId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000216,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000217", "SELECT ResidentId FROM Resident WHERE ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000217,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000218", "SAVEPOINT gxupdate;INSERT INTO Resident(ResidentGAMGUID, ResidentInitials, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentAddress, ResidentPhone, ResidentLastLineIndividual, ResidentLastLineCompany, ResidentTypeId, CustomerId, CustomerLocationId) VALUES(:ResidentGAMGUID, :ResidentInitials, :ResidentBsnNumber, :ResidentGivenName, :ResidentLastName, :ResidentEmail, :ResidentGender, :ResidentAddress, :ResidentPhone, :ResidentLastLineIndividual, :ResidentLastLineCompany, :ResidentTypeId, :CustomerId, :CustomerLocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000218)
           ,new CursorDef("BC000219", "SELECT currval('ResidentId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000219,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000220", "SAVEPOINT gxupdate;UPDATE Resident SET ResidentGAMGUID=:ResidentGAMGUID, ResidentInitials=:ResidentInitials, ResidentBsnNumber=:ResidentBsnNumber, ResidentGivenName=:ResidentGivenName, ResidentLastName=:ResidentLastName, ResidentEmail=:ResidentEmail, ResidentGender=:ResidentGender, ResidentAddress=:ResidentAddress, ResidentPhone=:ResidentPhone, ResidentLastLineIndividual=:ResidentLastLineIndividual, ResidentLastLineCompany=:ResidentLastLineCompany, ResidentTypeId=:ResidentTypeId, CustomerId=:CustomerId, CustomerLocationId=:CustomerLocationId  WHERE ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000220)
           ,new CursorDef("BC000221", "SAVEPOINT gxupdate;DELETE FROM Resident  WHERE ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000221)
           ,new CursorDef("BC000222", "SELECT ResidentTypeName FROM ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000222,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000223", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000223,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000224", "SAVEPOINT gxupdate;UPDATE Resident SET ResidentLastLineCompany=:ResidentLastLineCompany, ResidentLastLineIndividual=:ResidentLastLineIndividual  WHERE ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000224)
           ,new CursorDef("BC000225", "SELECT TM1.ResidentId, TM1.ResidentGAMGUID, TM1.ResidentInitials, TM1.ResidentBsnNumber, TM1.ResidentGivenName, TM1.ResidentLastName, TM1.ResidentEmail, TM1.ResidentGender, TM1.ResidentAddress, TM1.ResidentPhone, T2.ResidentTypeName, T3.CustomerName, TM1.ResidentLastLineIndividual, TM1.ResidentLastLineCompany, TM1.ResidentTypeId, TM1.CustomerId, TM1.CustomerLocationId FROM ((Resident TM1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = TM1.ResidentTypeId) INNER JOIN Customer T3 ON T3.CustomerId = TM1.CustomerId) WHERE TM1.ResidentId = :ResidentId ORDER BY TM1.ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000225,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000226", "SELECT ResidentId, ResidentINIndividualId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualGender FROM ResidentINIndividual WHERE ResidentId = :ResidentId and ResidentINIndividualId = :ResidentINIndividualId ORDER BY ResidentId, ResidentINIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000226,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000227", "SELECT ResidentId, ResidentINIndividualId FROM ResidentINIndividual WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000227,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000228", "SAVEPOINT gxupdate;INSERT INTO ResidentINIndividual(ResidentId, ResidentINIndividualId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualGender) VALUES(:ResidentId, :ResidentINIndividualId, :ResidentINIndividualBsnNumber, :ResidentINIndividualGivenName, :ResidentINIndividualLastName, :ResidentINIndividualEmail, :ResidentINIndividualPhone, :ResidentINIndividualAddress, :ResidentINIndividualGender);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000228)
           ,new CursorDef("BC000229", "SAVEPOINT gxupdate;UPDATE ResidentINIndividual SET ResidentINIndividualBsnNumber=:ResidentINIndividualBsnNumber, ResidentINIndividualGivenName=:ResidentINIndividualGivenName, ResidentINIndividualLastName=:ResidentINIndividualLastName, ResidentINIndividualEmail=:ResidentINIndividualEmail, ResidentINIndividualPhone=:ResidentINIndividualPhone, ResidentINIndividualAddress=:ResidentINIndividualAddress, ResidentINIndividualGender=:ResidentINIndividualGender  WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000229)
           ,new CursorDef("BC000230", "SAVEPOINT gxupdate;DELETE FROM ResidentINIndividual  WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000230)
           ,new CursorDef("BC000231", "SELECT ResidentId, ResidentINIndividualId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualGender FROM ResidentINIndividual WHERE ResidentId = :ResidentId ORDER BY ResidentId, ResidentINIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000231,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000232", "SELECT ResidentId, ResidentINCompanyId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone FROM ResidentINCompany WHERE ResidentId = :ResidentId and ResidentINCompanyId = :ResidentINCompanyId ORDER BY ResidentId, ResidentINCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000232,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000233", "SELECT ResidentId, ResidentINCompanyId FROM ResidentINCompany WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000233,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000234", "SAVEPOINT gxupdate;INSERT INTO ResidentINCompany(ResidentId, ResidentINCompanyId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone) VALUES(:ResidentId, :ResidentINCompanyId, :ResidentINCompanyKvkNumber, :ResidentINCompanyName, :ResidentINCompanyEmail, :ResidentINCompanyPhone);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000234)
           ,new CursorDef("BC000235", "SAVEPOINT gxupdate;UPDATE ResidentINCompany SET ResidentINCompanyKvkNumber=:ResidentINCompanyKvkNumber, ResidentINCompanyName=:ResidentINCompanyName, ResidentINCompanyEmail=:ResidentINCompanyEmail, ResidentINCompanyPhone=:ResidentINCompanyPhone  WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000235)
           ,new CursorDef("BC000236", "SAVEPOINT gxupdate;DELETE FROM ResidentINCompany  WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000236)
           ,new CursorDef("BC000237", "SELECT ResidentId, ResidentINCompanyId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone FROM ResidentINCompany WHERE ResidentId = :ResidentId ORDER BY ResidentId, ResidentINCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000237,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000238", "SELECT T1.ResidentId, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceQuantity, T2.ProductServicePicture_GXI, T3.ProductServiceTypeName, T1.ProductServiceId, T2.ProductServiceTypeId, T2.ProductServicePicture FROM ((ResidentProductService T1 INNER JOIN ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN ProductServiceType T3 ON T3.ProductServiceTypeId = T2.ProductServiceTypeId) WHERE T1.ResidentId = :ResidentId and T1.ProductServiceId = :ProductServiceId ORDER BY T1.ResidentId, T1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000238,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000239", "SELECT ResidentId, ProductServiceId FROM ResidentProductService WHERE ResidentId = :ResidentId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000239,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000240", "SAVEPOINT gxupdate;INSERT INTO ResidentProductService(ResidentId, ProductServiceId) VALUES(:ResidentId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000240)
           ,new CursorDef("BC000241", "SAVEPOINT gxupdate;DELETE FROM ResidentProductService  WHERE ResidentId = :ResidentId AND ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000241)
           ,new CursorDef("BC000242", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000242,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000243", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000243,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000244", "SELECT T1.ResidentId, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceQuantity, T2.ProductServicePicture_GXI, T3.ProductServiceTypeName, T1.ProductServiceId, T2.ProductServiceTypeId, T2.ProductServicePicture FROM ((ResidentProductService T1 INNER JOIN ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN ProductServiceType T3 ON T3.ProductServiceTypeId = T2.ProductServiceTypeId) WHERE T1.ResidentId = :ResidentId ORDER BY T1.ResidentId, T1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000244,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((short[]) buf[13])[0] = rslt.getShort(11);
              ((short[]) buf[14])[0] = rslt.getShort(12);
              ((short[]) buf[15])[0] = rslt.getShort(13);
              ((short[]) buf[16])[0] = rslt.getShort(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((short[]) buf[13])[0] = rslt.getShort(11);
              ((short[]) buf[14])[0] = rslt.getShort(12);
              ((short[]) buf[15])[0] = rslt.getShort(13);
              ((short[]) buf[16])[0] = rslt.getShort(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getVarchar(11);
              ((string[]) buf[14])[0] = rslt.getVarchar(12);
              ((short[]) buf[15])[0] = rslt.getShort(13);
              ((short[]) buf[16])[0] = rslt.getShort(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              ((short[]) buf[18])[0] = rslt.getShort(16);
              ((short[]) buf[19])[0] = rslt.getShort(17);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 23 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getVarchar(11);
              ((string[]) buf[14])[0] = rslt.getVarchar(12);
              ((short[]) buf[15])[0] = rslt.getShort(13);
              ((short[]) buf[16])[0] = rslt.getShort(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              ((short[]) buf[18])[0] = rslt.getShort(16);
              ((short[]) buf[19])[0] = rslt.getShort(17);
              return;
           case 24 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              return;
           case 25 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 29 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 31 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 35 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 36 :
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
           case 37 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 42 :
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
