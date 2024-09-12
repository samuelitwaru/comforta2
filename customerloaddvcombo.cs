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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class customerloaddvcombo : GXProcedure
   {
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
            return "customer_Services_Execute" ;
         }

      }

      public customerloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customerloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           short aP3_CustomerId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20CustomerId = aP3_CustomerId;
         this.AV21SearchTxtParms = aP4_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                short aP3_CustomerId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_CustomerId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 short aP3_CustomerId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20CustomerId = aP3_CustomerId;
         this.AV21SearchTxtParms = aP4_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         SubmitImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV21SearchTxtParms : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "AmenitiesId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_AMENITIESID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "Supplier_GenId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIER_GENID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "Supplier_AgbId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIER_AGBID' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "CustomerTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CUSTOMERTYPEID' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_AMENITIESID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV30ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV29DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV35GXV1 = 1;
               while ( AV35GXV1 <= AV30ValuesCollection.Count )
               {
                  AV31ValueItem = ((string)AV30ValuesCollection.Item(AV35GXV1));
                  AV34AmenitiesId_Filter = (short)(Math.Round(NumberUtil.Val( AV31ValueItem, "."), 18, MidpointRounding.ToEven));
                  AV36GXLvl35 = 0;
                  /* Using cursor P002A2 */
                  pr_default.execute(0, new Object[] {AV34AmenitiesId_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A98AmenitiesId = P002A2_A98AmenitiesId[0];
                     A101AmenitiesName = P002A2_A101AmenitiesName[0];
                     AV36GXLvl35 = 1;
                     AV29DscsCollection.Add(A101AmenitiesName, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV36GXLvl35 == 0 )
                  {
                     AV29DscsCollection.Add("", 0);
                  }
                  AV35GXV1 = (int)(AV35GXV1+1);
               }
               AV24Combo_DataJson = AV29DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom3 = AV12SkipItems;
               GXPagingTo3 = AV11MaxItems;
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV14SearchTxt ,
                                                    A101AmenitiesName } ,
                                                    new int[]{
                                                    }
               });
               lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
               /* Using cursor P002A3 */
               pr_default.execute(1, new Object[] {lV14SearchTxt, GXPagingFrom3, GXPagingTo3, GXPagingTo3});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A101AmenitiesName = P002A3_A101AmenitiesName[0];
                  A98AmenitiesId = P002A3_A98AmenitiesId[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A98AmenitiesId), 4, 0));
                  AV16Combo_DataItem.gxTpr_Title = A101AmenitiesName;
                  AV15Combo_Data.Add(AV16Combo_DataItem, 0);
                  if ( AV15Combo_Data.Count > AV11MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIER_GENID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV30ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV29DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV38GXV2 = 1;
               while ( AV38GXV2 <= AV30ValuesCollection.Count )
               {
                  AV31ValueItem = ((string)AV30ValuesCollection.Item(AV38GXV2));
                  AV32Supplier_GenId_Filter = (short)(Math.Round(NumberUtil.Val( AV31ValueItem, "."), 18, MidpointRounding.ToEven));
                  AV39GXLvl75 = 0;
                  /* Using cursor P002A4 */
                  pr_default.execute(2, new Object[] {AV32Supplier_GenId_Filter});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A64Supplier_GenId = P002A4_A64Supplier_GenId[0];
                     A65Supplier_GenKvKNumber = P002A4_A65Supplier_GenKvKNumber[0];
                     AV39GXLvl75 = 1;
                     AV29DscsCollection.Add(A65Supplier_GenKvKNumber, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  if ( AV39GXLvl75 == 0 )
                  {
                     AV29DscsCollection.Add("", 0);
                  }
                  AV38GXV2 = (int)(AV38GXV2+1);
               }
               AV24Combo_DataJson = AV29DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom5 = AV12SkipItems;
               GXPagingTo5 = AV11MaxItems;
               pr_default.dynParam(3, new Object[]{ new Object[]{
                                                    AV14SearchTxt ,
                                                    A65Supplier_GenKvKNumber } ,
                                                    new int[]{
                                                    }
               });
               lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
               /* Using cursor P002A5 */
               pr_default.execute(3, new Object[] {lV14SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A65Supplier_GenKvKNumber = P002A5_A65Supplier_GenKvKNumber[0];
                  A64Supplier_GenId = P002A5_A64Supplier_GenId[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A64Supplier_GenId), 4, 0));
                  AV16Combo_DataItem.gxTpr_Title = A65Supplier_GenKvKNumber;
                  AV15Combo_Data.Add(AV16Combo_DataItem, 0);
                  if ( AV15Combo_Data.Count > AV11MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIER_AGBID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV30ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV29DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV41GXV3 = 1;
               while ( AV41GXV3 <= AV30ValuesCollection.Count )
               {
                  AV31ValueItem = ((string)AV30ValuesCollection.Item(AV41GXV3));
                  AV33Supplier_AgbId_Filter = (short)(Math.Round(NumberUtil.Val( AV31ValueItem, "."), 18, MidpointRounding.ToEven));
                  AV42GXLvl115 = 0;
                  /* Using cursor P002A6 */
                  pr_default.execute(4, new Object[] {AV33Supplier_AgbId_Filter});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A55Supplier_AgbId = P002A6_A55Supplier_AgbId[0];
                     A56Supplier_AgbNumber = P002A6_A56Supplier_AgbNumber[0];
                     AV42GXLvl115 = 1;
                     AV29DscsCollection.Add(A56Supplier_AgbNumber, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
                  if ( AV42GXLvl115 == 0 )
                  {
                     AV29DscsCollection.Add("", 0);
                  }
                  AV41GXV3 = (int)(AV41GXV3+1);
               }
               AV24Combo_DataJson = AV29DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom7 = AV12SkipItems;
               GXPagingTo7 = AV11MaxItems;
               pr_default.dynParam(5, new Object[]{ new Object[]{
                                                    AV14SearchTxt ,
                                                    A56Supplier_AgbNumber } ,
                                                    new int[]{
                                                    }
               });
               lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
               /* Using cursor P002A7 */
               pr_default.execute(5, new Object[] {lV14SearchTxt, GXPagingFrom7, GXPagingTo7, GXPagingTo7});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A56Supplier_AgbNumber = P002A7_A56Supplier_AgbNumber[0];
                  A55Supplier_AgbId = P002A7_A55Supplier_AgbId[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A55Supplier_AgbId), 4, 0));
                  AV16Combo_DataItem.gxTpr_Title = A56Supplier_AgbNumber;
                  AV15Combo_Data.Add(AV16Combo_DataItem, 0);
                  if ( AV15Combo_Data.Count > AV11MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(5);
               }
               pr_default.close(5);
               AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_CUSTOMERTYPEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom8 = AV12SkipItems;
            GXPagingTo8 = AV11MaxItems;
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A79CustomerTypeName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P002A8 */
            pr_default.execute(6, new Object[] {lV14SearchTxt, GXPagingFrom8, GXPagingTo8, GXPagingTo8});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A79CustomerTypeName = P002A8_A79CustomerTypeName[0];
               A78CustomerTypeId = P002A8_A78CustomerTypeId[0];
               n78CustomerTypeId = P002A8_n78CustomerTypeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A78CustomerTypeId), 4, 0));
               AV16Combo_DataItem.gxTpr_Title = A79CustomerTypeName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P002A9 */
                  pr_default.execute(7, new Object[] {AV20CustomerId});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A1CustomerId = P002A9_A1CustomerId[0];
                     A78CustomerTypeId = P002A9_A78CustomerTypeId[0];
                     n78CustomerTypeId = P002A9_n78CustomerTypeId[0];
                     A79CustomerTypeName = P002A9_A79CustomerTypeName[0];
                     A79CustomerTypeName = P002A9_A79CustomerTypeName[0];
                     AV22SelectedValue = ((0==A78CustomerTypeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A78CustomerTypeId), 4, 0)));
                     AV23SelectedText = A79CustomerTypeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV28CustomerTypeId = (short)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P002A10 */
                  pr_default.execute(8, new Object[] {AV28CustomerTypeId});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A78CustomerTypeId = P002A10_A78CustomerTypeId[0];
                     n78CustomerTypeId = P002A10_n78CustomerTypeId[0];
                     A79CustomerTypeName = P002A10_A79CustomerTypeName[0];
                     AV23SelectedText = A79CustomerTypeName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(8);
               }
            }
         }
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV22SelectedValue = "";
         AV23SelectedText = "";
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         AV30ValuesCollection = new GxSimpleCollection<string>();
         AV29DscsCollection = new GxSimpleCollection<string>();
         AV31ValueItem = "";
         P002A2_A98AmenitiesId = new short[1] ;
         P002A2_A101AmenitiesName = new string[] {""} ;
         A101AmenitiesName = "";
         lV14SearchTxt = "";
         P002A3_A101AmenitiesName = new string[] {""} ;
         P002A3_A98AmenitiesId = new short[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P002A4_A64Supplier_GenId = new short[1] ;
         P002A4_A65Supplier_GenKvKNumber = new string[] {""} ;
         A65Supplier_GenKvKNumber = "";
         P002A5_A65Supplier_GenKvKNumber = new string[] {""} ;
         P002A5_A64Supplier_GenId = new short[1] ;
         P002A6_A55Supplier_AgbId = new short[1] ;
         P002A6_A56Supplier_AgbNumber = new string[] {""} ;
         A56Supplier_AgbNumber = "";
         P002A7_A56Supplier_AgbNumber = new string[] {""} ;
         P002A7_A55Supplier_AgbId = new short[1] ;
         A79CustomerTypeName = "";
         P002A8_A79CustomerTypeName = new string[] {""} ;
         P002A8_A78CustomerTypeId = new short[1] ;
         P002A8_n78CustomerTypeId = new bool[] {false} ;
         P002A9_A1CustomerId = new short[1] ;
         P002A9_A78CustomerTypeId = new short[1] ;
         P002A9_n78CustomerTypeId = new bool[] {false} ;
         P002A9_A79CustomerTypeName = new string[] {""} ;
         P002A10_A78CustomerTypeId = new short[1] ;
         P002A10_n78CustomerTypeId = new bool[] {false} ;
         P002A10_A79CustomerTypeName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customerloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P002A2_A98AmenitiesId, P002A2_A101AmenitiesName
               }
               , new Object[] {
               P002A3_A101AmenitiesName, P002A3_A98AmenitiesId
               }
               , new Object[] {
               P002A4_A64Supplier_GenId, P002A4_A65Supplier_GenKvKNumber
               }
               , new Object[] {
               P002A5_A65Supplier_GenKvKNumber, P002A5_A64Supplier_GenId
               }
               , new Object[] {
               P002A6_A55Supplier_AgbId, P002A6_A56Supplier_AgbNumber
               }
               , new Object[] {
               P002A7_A56Supplier_AgbNumber, P002A7_A55Supplier_AgbId
               }
               , new Object[] {
               P002A8_A79CustomerTypeName, P002A8_A78CustomerTypeId
               }
               , new Object[] {
               P002A9_A1CustomerId, P002A9_A78CustomerTypeId, P002A9_n78CustomerTypeId, P002A9_A79CustomerTypeName
               }
               , new Object[] {
               P002A10_A78CustomerTypeId, P002A10_A79CustomerTypeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20CustomerId ;
      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short AV34AmenitiesId_Filter ;
      private short AV36GXLvl35 ;
      private short A98AmenitiesId ;
      private short AV32Supplier_GenId_Filter ;
      private short AV39GXLvl75 ;
      private short A64Supplier_GenId ;
      private short AV33Supplier_AgbId_Filter ;
      private short AV42GXLvl115 ;
      private short A55Supplier_AgbId ;
      private short A78CustomerTypeId ;
      private short A1CustomerId ;
      private short AV28CustomerTypeId ;
      private int AV11MaxItems ;
      private int AV35GXV1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private int AV38GXV2 ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int AV41GXV3 ;
      private int GXPagingFrom7 ;
      private int GXPagingTo7 ;
      private int GXPagingFrom8 ;
      private int GXPagingTo8 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private bool n78CustomerTypeId ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string AV31ValueItem ;
      private string A101AmenitiesName ;
      private string lV14SearchTxt ;
      private string A65Supplier_GenKvKNumber ;
      private string A56Supplier_AgbNumber ;
      private string A79CustomerTypeName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV30ValuesCollection ;
      private GxSimpleCollection<string> AV29DscsCollection ;
      private IDataStoreProvider pr_default ;
      private short[] P002A2_A98AmenitiesId ;
      private string[] P002A2_A101AmenitiesName ;
      private string[] P002A3_A101AmenitiesName ;
      private short[] P002A3_A98AmenitiesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private short[] P002A4_A64Supplier_GenId ;
      private string[] P002A4_A65Supplier_GenKvKNumber ;
      private string[] P002A5_A65Supplier_GenKvKNumber ;
      private short[] P002A5_A64Supplier_GenId ;
      private short[] P002A6_A55Supplier_AgbId ;
      private string[] P002A6_A56Supplier_AgbNumber ;
      private string[] P002A7_A56Supplier_AgbNumber ;
      private short[] P002A7_A55Supplier_AgbId ;
      private string[] P002A8_A79CustomerTypeName ;
      private short[] P002A8_A78CustomerTypeId ;
      private bool[] P002A8_n78CustomerTypeId ;
      private short[] P002A9_A1CustomerId ;
      private short[] P002A9_A78CustomerTypeId ;
      private bool[] P002A9_n78CustomerTypeId ;
      private string[] P002A9_A79CustomerTypeName ;
      private short[] P002A10_A78CustomerTypeId ;
      private bool[] P002A10_n78CustomerTypeId ;
      private string[] P002A10_A79CustomerTypeName ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class customerloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002A3( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A101AmenitiesName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " AmenitiesName, AmenitiesId";
         sFromString = " FROM Amenities";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(AmenitiesName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY AmenitiesName, AmenitiesId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom3" + " LIMIT CASE WHEN " + ":GXPagingTo3" + " > 0 THEN " + ":GXPagingTo3" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002A5( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A65Supplier_GenKvKNumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Supplier_GenKvKNumber, Supplier_GenId";
         sFromString = " FROM Supplier_Gen";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(Supplier_GenKvKNumber like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY Supplier_GenKvKNumber, Supplier_GenId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002A7( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A56Supplier_AgbNumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Supplier_AgbNumber, Supplier_AgbId";
         sFromString = " FROM Supplier_AGB";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(Supplier_AgbNumber like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         sOrderString += " ORDER BY Supplier_AgbNumber, Supplier_AgbId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom7" + " LIMIT CASE WHEN " + ":GXPagingTo7" + " > 0 THEN " + ":GXPagingTo7" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002A8( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A79CustomerTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[4];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CustomerTypeName, CustomerTypeId";
         sFromString = " FROM CustomerType";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(CustomerTypeName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         sOrderString += " ORDER BY CustomerTypeName, CustomerTypeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom8" + " LIMIT CASE WHEN " + ":GXPagingTo8" + " > 0 THEN " + ":GXPagingTo8" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P002A3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P002A5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 5 :
                     return conditional_P002A7(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 6 :
                     return conditional_P002A8(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002A2;
          prmP002A2 = new Object[] {
          new ParDef("AV34AmenitiesId_Filter",GXType.Int16,4,0)
          };
          Object[] prmP002A4;
          prmP002A4 = new Object[] {
          new ParDef("AV32Supplier_GenId_Filter",GXType.Int16,4,0)
          };
          Object[] prmP002A6;
          prmP002A6 = new Object[] {
          new ParDef("AV33Supplier_AgbId_Filter",GXType.Int16,4,0)
          };
          Object[] prmP002A9;
          prmP002A9 = new Object[] {
          new ParDef("AV20CustomerId",GXType.Int16,4,0)
          };
          Object[] prmP002A10;
          prmP002A10 = new Object[] {
          new ParDef("AV28CustomerTypeId",GXType.Int16,4,0)
          };
          Object[] prmP002A3;
          prmP002A3 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          Object[] prmP002A5;
          prmP002A5 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP002A7;
          prmP002A7 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom7",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo7",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo7",GXType.Int32,9,0)
          };
          Object[] prmP002A8;
          prmP002A8 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002A2", "SELECT AmenitiesId, AmenitiesName FROM Amenities WHERE AmenitiesId = :AV34AmenitiesId_Filter ORDER BY AmenitiesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002A4", "SELECT Supplier_GenId, Supplier_GenKvKNumber FROM Supplier_Gen WHERE Supplier_GenId = :AV32Supplier_GenId_Filter ORDER BY Supplier_GenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002A5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002A6", "SELECT Supplier_AgbId, Supplier_AgbNumber FROM Supplier_AGB WHERE Supplier_AgbId = :AV33Supplier_AgbId_Filter ORDER BY Supplier_AgbId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002A7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002A8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002A9", "SELECT T1.CustomerId, T1.CustomerTypeId, T2.CustomerTypeName FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId) WHERE T1.CustomerId = :AV20CustomerId ORDER BY T1.CustomerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002A10", "SELECT CustomerTypeId, CustomerTypeName FROM CustomerType WHERE CustomerTypeId = :AV28CustomerTypeId ORDER BY CustomerTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A10,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
