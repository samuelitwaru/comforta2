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
   public class customercustomizationwwgetfilterdata : GXProcedure
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
            return "customercustomizationww_Services_Execute" ;
         }

      }

      public customercustomizationwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customercustomizationwwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24MaxItems = 10;
         AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
         AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CUSTOMERCUSTOMIZATIONBASECOLOR") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERCUSTOMIZATIONBASECOLOROPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CUSTOMERCUSTOMIZATIONFONTSIZE") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERCUSTOMIZATIONFONTSIZEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CUSTOMERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("CustomerCustomizationWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CustomerCustomizationWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("CustomerCustomizationWWGridState"), null, "", "");
         }
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONID") == 0 )
            {
               AV11TFCustomerCustomizationId = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFCustomerCustomizationId_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONBASECOLOR") == 0 )
            {
               AV13TFCustomerCustomizationBaseColor = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONBASECOLOR_SEL") == 0 )
            {
               AV14TFCustomerCustomizationBaseColor_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONFONTSIZE") == 0 )
            {
               AV15TFCustomerCustomizationFontSize = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUSTOMERCUSTOMIZATIONFONTSIZE_SEL") == 0 )
            {
               AV44TFCustomerCustomizationFontSize_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUSTOMERID") == 0 )
            {
               AV17TFCustomerId = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFCustomerId_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUSTOMERNAME") == 0 )
            {
               AV19TFCustomerName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCUSTOMERNAME_SEL") == 0 )
            {
               AV20TFCustomerName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCUSTOMERCUSTOMIZATIONBASECOLOROPTIONS' Routine */
         returnInSub = false;
         AV13TFCustomerCustomizationBaseColor = AV21SearchTxt;
         AV14TFCustomerCustomizationBaseColor_Sel = "";
         AV47Customercustomizationwwds_1_filterfulltext = AV43FilterFullText;
         AV48Customercustomizationwwds_2_tfcustomercustomizationid = AV11TFCustomerCustomizationId;
         AV49Customercustomizationwwds_3_tfcustomercustomizationid_to = AV12TFCustomerCustomizationId_To;
         AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV13TFCustomerCustomizationBaseColor;
         AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV14TFCustomerCustomizationBaseColor_Sel;
         AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV15TFCustomerCustomizationFontSize;
         AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV44TFCustomerCustomizationFontSize_Sel;
         AV54Customercustomizationwwds_8_tfcustomerid = AV17TFCustomerId;
         AV55Customercustomizationwwds_9_tfcustomerid_to = AV18TFCustomerId_To;
         AV56Customercustomizationwwds_10_tfcustomername = AV19TFCustomerName;
         AV57Customercustomizationwwds_11_tfcustomername_sel = AV20TFCustomerName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47Customercustomizationwwds_1_filterfulltext ,
                                              AV48Customercustomizationwwds_2_tfcustomercustomizationid ,
                                              AV49Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                              AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                              AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                              AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                              AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                              AV54Customercustomizationwwds_8_tfcustomerid ,
                                              AV55Customercustomizationwwds_9_tfcustomerid_to ,
                                              AV57Customercustomizationwwds_11_tfcustomername_sel ,
                                              AV56Customercustomizationwwds_10_tfcustomername ,
                                              A128CustomerCustomizationId ,
                                              A131CustomerCustomizationBaseColor ,
                                              A132CustomerCustomizationFontSize ,
                                              A1CustomerId ,
                                              A3CustomerName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor), "%", "");
         lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize = StringUtil.Concat( StringUtil.RTrim( AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize), "%", "");
         lV56Customercustomizationwwds_10_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV56Customercustomizationwwds_10_tfcustomername), "%", "");
         /* Using cursor P00392 */
         pr_default.execute(0, new Object[] {lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, AV48Customercustomizationwwds_2_tfcustomercustomizationid, AV49Customercustomizationwwds_3_tfcustomercustomizationid_to, lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor, AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize, AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, AV54Customercustomizationwwds_8_tfcustomerid, AV55Customercustomizationwwds_9_tfcustomerid_to, lV56Customercustomizationwwds_10_tfcustomername, AV57Customercustomizationwwds_11_tfcustomername_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK392 = false;
            A131CustomerCustomizationBaseColor = P00392_A131CustomerCustomizationBaseColor[0];
            A1CustomerId = P00392_A1CustomerId[0];
            A128CustomerCustomizationId = P00392_A128CustomerCustomizationId[0];
            A3CustomerName = P00392_A3CustomerName[0];
            A132CustomerCustomizationFontSize = P00392_A132CustomerCustomizationFontSize[0];
            A3CustomerName = P00392_A3CustomerName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00392_A131CustomerCustomizationBaseColor[0], A131CustomerCustomizationBaseColor) == 0 ) )
            {
               BRK392 = false;
               A128CustomerCustomizationId = P00392_A128CustomerCustomizationId[0];
               AV31count = (long)(AV31count+1);
               BRK392 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A131CustomerCustomizationBaseColor)) ? "<#Empty#>" : A131CustomerCustomizationBaseColor);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK392 )
            {
               BRK392 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCUSTOMERCUSTOMIZATIONFONTSIZEOPTIONS' Routine */
         returnInSub = false;
         AV15TFCustomerCustomizationFontSize = AV21SearchTxt;
         AV44TFCustomerCustomizationFontSize_Sel = "";
         AV47Customercustomizationwwds_1_filterfulltext = AV43FilterFullText;
         AV48Customercustomizationwwds_2_tfcustomercustomizationid = AV11TFCustomerCustomizationId;
         AV49Customercustomizationwwds_3_tfcustomercustomizationid_to = AV12TFCustomerCustomizationId_To;
         AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV13TFCustomerCustomizationBaseColor;
         AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV14TFCustomerCustomizationBaseColor_Sel;
         AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV15TFCustomerCustomizationFontSize;
         AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV44TFCustomerCustomizationFontSize_Sel;
         AV54Customercustomizationwwds_8_tfcustomerid = AV17TFCustomerId;
         AV55Customercustomizationwwds_9_tfcustomerid_to = AV18TFCustomerId_To;
         AV56Customercustomizationwwds_10_tfcustomername = AV19TFCustomerName;
         AV57Customercustomizationwwds_11_tfcustomername_sel = AV20TFCustomerName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV47Customercustomizationwwds_1_filterfulltext ,
                                              AV48Customercustomizationwwds_2_tfcustomercustomizationid ,
                                              AV49Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                              AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                              AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                              AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                              AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                              AV54Customercustomizationwwds_8_tfcustomerid ,
                                              AV55Customercustomizationwwds_9_tfcustomerid_to ,
                                              AV57Customercustomizationwwds_11_tfcustomername_sel ,
                                              AV56Customercustomizationwwds_10_tfcustomername ,
                                              A128CustomerCustomizationId ,
                                              A131CustomerCustomizationBaseColor ,
                                              A132CustomerCustomizationFontSize ,
                                              A1CustomerId ,
                                              A3CustomerName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor), "%", "");
         lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize = StringUtil.Concat( StringUtil.RTrim( AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize), "%", "");
         lV56Customercustomizationwwds_10_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV56Customercustomizationwwds_10_tfcustomername), "%", "");
         /* Using cursor P00393 */
         pr_default.execute(1, new Object[] {lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, AV48Customercustomizationwwds_2_tfcustomercustomizationid, AV49Customercustomizationwwds_3_tfcustomercustomizationid_to, lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor, AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize, AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, AV54Customercustomizationwwds_8_tfcustomerid, AV55Customercustomizationwwds_9_tfcustomerid_to, lV56Customercustomizationwwds_10_tfcustomername, AV57Customercustomizationwwds_11_tfcustomername_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK394 = false;
            A132CustomerCustomizationFontSize = P00393_A132CustomerCustomizationFontSize[0];
            A1CustomerId = P00393_A1CustomerId[0];
            A128CustomerCustomizationId = P00393_A128CustomerCustomizationId[0];
            A3CustomerName = P00393_A3CustomerName[0];
            A131CustomerCustomizationBaseColor = P00393_A131CustomerCustomizationBaseColor[0];
            A3CustomerName = P00393_A3CustomerName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00393_A132CustomerCustomizationFontSize[0], A132CustomerCustomizationFontSize) == 0 ) )
            {
               BRK394 = false;
               A128CustomerCustomizationId = P00393_A128CustomerCustomizationId[0];
               AV31count = (long)(AV31count+1);
               BRK394 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A132CustomerCustomizationFontSize)) ? "<#Empty#>" : A132CustomerCustomizationFontSize);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK394 )
            {
               BRK394 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCUSTOMERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV19TFCustomerName = AV21SearchTxt;
         AV20TFCustomerName_Sel = "";
         AV47Customercustomizationwwds_1_filterfulltext = AV43FilterFullText;
         AV48Customercustomizationwwds_2_tfcustomercustomizationid = AV11TFCustomerCustomizationId;
         AV49Customercustomizationwwds_3_tfcustomercustomizationid_to = AV12TFCustomerCustomizationId_To;
         AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor = AV13TFCustomerCustomizationBaseColor;
         AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = AV14TFCustomerCustomizationBaseColor_Sel;
         AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize = AV15TFCustomerCustomizationFontSize;
         AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = AV44TFCustomerCustomizationFontSize_Sel;
         AV54Customercustomizationwwds_8_tfcustomerid = AV17TFCustomerId;
         AV55Customercustomizationwwds_9_tfcustomerid_to = AV18TFCustomerId_To;
         AV56Customercustomizationwwds_10_tfcustomername = AV19TFCustomerName;
         AV57Customercustomizationwwds_11_tfcustomername_sel = AV20TFCustomerName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV47Customercustomizationwwds_1_filterfulltext ,
                                              AV48Customercustomizationwwds_2_tfcustomercustomizationid ,
                                              AV49Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                              AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                              AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                              AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                              AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                              AV54Customercustomizationwwds_8_tfcustomerid ,
                                              AV55Customercustomizationwwds_9_tfcustomerid_to ,
                                              AV57Customercustomizationwwds_11_tfcustomername_sel ,
                                              AV56Customercustomizationwwds_10_tfcustomername ,
                                              A128CustomerCustomizationId ,
                                              A131CustomerCustomizationBaseColor ,
                                              A132CustomerCustomizationFontSize ,
                                              A1CustomerId ,
                                              A3CustomerName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV47Customercustomizationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext), "%", "");
         lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor = StringUtil.Concat( StringUtil.RTrim( AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor), "%", "");
         lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize = StringUtil.Concat( StringUtil.RTrim( AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize), "%", "");
         lV56Customercustomizationwwds_10_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV56Customercustomizationwwds_10_tfcustomername), "%", "");
         /* Using cursor P00394 */
         pr_default.execute(2, new Object[] {lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, lV47Customercustomizationwwds_1_filterfulltext, AV48Customercustomizationwwds_2_tfcustomercustomizationid, AV49Customercustomizationwwds_3_tfcustomercustomizationid_to, lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor, AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize, AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, AV54Customercustomizationwwds_8_tfcustomerid, AV55Customercustomizationwwds_9_tfcustomerid_to, lV56Customercustomizationwwds_10_tfcustomername, AV57Customercustomizationwwds_11_tfcustomername_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK396 = false;
            A3CustomerName = P00394_A3CustomerName[0];
            A1CustomerId = P00394_A1CustomerId[0];
            A128CustomerCustomizationId = P00394_A128CustomerCustomizationId[0];
            A132CustomerCustomizationFontSize = P00394_A132CustomerCustomizationFontSize[0];
            A131CustomerCustomizationBaseColor = P00394_A131CustomerCustomizationBaseColor[0];
            A3CustomerName = P00394_A3CustomerName[0];
            AV31count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00394_A3CustomerName[0], A3CustomerName) == 0 ) )
            {
               BRK396 = false;
               A1CustomerId = P00394_A1CustomerId[0];
               A128CustomerCustomizationId = P00394_A128CustomerCustomizationId[0];
               AV31count = (long)(AV31count+1);
               BRK396 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A3CustomerName)) ? "<#Empty#>" : A3CustomerName);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK396 )
            {
               BRK396 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV13TFCustomerCustomizationBaseColor = "";
         AV14TFCustomerCustomizationBaseColor_Sel = "";
         AV15TFCustomerCustomizationFontSize = "";
         AV44TFCustomerCustomizationFontSize_Sel = "";
         AV19TFCustomerName = "";
         AV20TFCustomerName_Sel = "";
         AV47Customercustomizationwwds_1_filterfulltext = "";
         AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor = "";
         AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel = "";
         AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize = "";
         AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel = "";
         AV56Customercustomizationwwds_10_tfcustomername = "";
         AV57Customercustomizationwwds_11_tfcustomername_sel = "";
         lV47Customercustomizationwwds_1_filterfulltext = "";
         lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor = "";
         lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize = "";
         lV56Customercustomizationwwds_10_tfcustomername = "";
         A131CustomerCustomizationBaseColor = "";
         A132CustomerCustomizationFontSize = "";
         A3CustomerName = "";
         P00392_A131CustomerCustomizationBaseColor = new string[] {""} ;
         P00392_A1CustomerId = new short[1] ;
         P00392_A128CustomerCustomizationId = new short[1] ;
         P00392_A3CustomerName = new string[] {""} ;
         P00392_A132CustomerCustomizationFontSize = new string[] {""} ;
         AV26Option = "";
         P00393_A132CustomerCustomizationFontSize = new string[] {""} ;
         P00393_A1CustomerId = new short[1] ;
         P00393_A128CustomerCustomizationId = new short[1] ;
         P00393_A3CustomerName = new string[] {""} ;
         P00393_A131CustomerCustomizationBaseColor = new string[] {""} ;
         P00394_A3CustomerName = new string[] {""} ;
         P00394_A1CustomerId = new short[1] ;
         P00394_A128CustomerCustomizationId = new short[1] ;
         P00394_A132CustomerCustomizationFontSize = new string[] {""} ;
         P00394_A131CustomerCustomizationBaseColor = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customercustomizationwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00392_A131CustomerCustomizationBaseColor, P00392_A1CustomerId, P00392_A128CustomerCustomizationId, P00392_A3CustomerName, P00392_A132CustomerCustomizationFontSize
               }
               , new Object[] {
               P00393_A132CustomerCustomizationFontSize, P00393_A1CustomerId, P00393_A128CustomerCustomizationId, P00393_A3CustomerName, P00393_A131CustomerCustomizationBaseColor
               }
               , new Object[] {
               P00394_A3CustomerName, P00394_A1CustomerId, P00394_A128CustomerCustomizationId, P00394_A132CustomerCustomizationFontSize, P00394_A131CustomerCustomizationBaseColor
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short AV11TFCustomerCustomizationId ;
      private short AV12TFCustomerCustomizationId_To ;
      private short AV17TFCustomerId ;
      private short AV18TFCustomerId_To ;
      private short AV48Customercustomizationwwds_2_tfcustomercustomizationid ;
      private short AV49Customercustomizationwwds_3_tfcustomercustomizationid_to ;
      private short AV54Customercustomizationwwds_8_tfcustomerid ;
      private short AV55Customercustomizationwwds_9_tfcustomerid_to ;
      private short A128CustomerCustomizationId ;
      private short A1CustomerId ;
      private int AV45GXV1 ;
      private long AV31count ;
      private bool returnInSub ;
      private bool BRK392 ;
      private bool BRK394 ;
      private bool BRK396 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV13TFCustomerCustomizationBaseColor ;
      private string AV14TFCustomerCustomizationBaseColor_Sel ;
      private string AV15TFCustomerCustomizationFontSize ;
      private string AV44TFCustomerCustomizationFontSize_Sel ;
      private string AV19TFCustomerName ;
      private string AV20TFCustomerName_Sel ;
      private string AV47Customercustomizationwwds_1_filterfulltext ;
      private string AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor ;
      private string AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ;
      private string AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize ;
      private string AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ;
      private string AV56Customercustomizationwwds_10_tfcustomername ;
      private string AV57Customercustomizationwwds_11_tfcustomername_sel ;
      private string lV47Customercustomizationwwds_1_filterfulltext ;
      private string lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor ;
      private string lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize ;
      private string lV56Customercustomizationwwds_10_tfcustomername ;
      private string A131CustomerCustomizationBaseColor ;
      private string A132CustomerCustomizationFontSize ;
      private string A3CustomerName ;
      private string AV26Option ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00392_A131CustomerCustomizationBaseColor ;
      private short[] P00392_A1CustomerId ;
      private short[] P00392_A128CustomerCustomizationId ;
      private string[] P00392_A3CustomerName ;
      private string[] P00392_A132CustomerCustomizationFontSize ;
      private string[] P00393_A132CustomerCustomizationFontSize ;
      private short[] P00393_A1CustomerId ;
      private short[] P00393_A128CustomerCustomizationId ;
      private string[] P00393_A3CustomerName ;
      private string[] P00393_A131CustomerCustomizationBaseColor ;
      private string[] P00394_A3CustomerName ;
      private short[] P00394_A1CustomerId ;
      private short[] P00394_A128CustomerCustomizationId ;
      private string[] P00394_A132CustomerCustomizationFontSize ;
      private string[] P00394_A131CustomerCustomizationBaseColor ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class customercustomizationwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00392( IGxContext context ,
                                             string AV47Customercustomizationwwds_1_filterfulltext ,
                                             short AV48Customercustomizationwwds_2_tfcustomercustomizationid ,
                                             short AV49Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                             string AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                             string AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                             string AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                             string AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                             short AV54Customercustomizationwwds_8_tfcustomerid ,
                                             short AV55Customercustomizationwwds_9_tfcustomerid_to ,
                                             string AV57Customercustomizationwwds_11_tfcustomername_sel ,
                                             string AV56Customercustomizationwwds_10_tfcustomername ,
                                             short A128CustomerCustomizationId ,
                                             string A131CustomerCustomizationBaseColor ,
                                             string A132CustomerCustomizationFontSize ,
                                             short A1CustomerId ,
                                             string A3CustomerName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.CustomerCustomizationBaseColor, T1.CustomerId, T1.CustomerCustomizationId, T2.CustomerName, T1.CustomerCustomizationFontSize FROM (CustomerCustomization T1 INNER JOIN Customer T2 ON T2.CustomerId = T1.CustomerId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.CustomerCustomizationId,'9999'), 2) like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationBaseColor like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationFontSize like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.CustomerId,'9999'), 2) like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( T2.CustomerName like '%' || :lV47Customercustomizationwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV48Customercustomizationwwds_2_tfcustomercustomizationid) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId >= :AV48Customercustomizationwwds_2_tfcustomercustomizationid)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV49Customercustomizationwwds_3_tfcustomercustomizationid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId <= :AV49Customercustomizationwwds_3_tfcustomercustomizationid_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor like :lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolo)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ! ( StringUtil.StrCmp(AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor = ( :AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolo))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationBaseColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize like :lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ! ( StringUtil.StrCmp(AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize = ( :AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationFontSize))=0))");
         }
         if ( ! (0==AV54Customercustomizationwwds_8_tfcustomerid) )
         {
            AddWhere(sWhereString, "(T1.CustomerId >= :AV54Customercustomizationwwds_8_tfcustomerid)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV55Customercustomizationwwds_9_tfcustomerid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerId <= :AV55Customercustomizationwwds_9_tfcustomerid_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Customercustomizationwwds_11_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customercustomizationwwds_10_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName like :lV56Customercustomizationwwds_10_tfcustomername)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customercustomizationwwds_11_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV57Customercustomizationwwds_11_tfcustomername_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName = ( :AV57Customercustomizationwwds_11_tfcustomername_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV57Customercustomizationwwds_11_tfcustomername_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerCustomizationBaseColor";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00393( IGxContext context ,
                                             string AV47Customercustomizationwwds_1_filterfulltext ,
                                             short AV48Customercustomizationwwds_2_tfcustomercustomizationid ,
                                             short AV49Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                             string AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                             string AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                             string AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                             string AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                             short AV54Customercustomizationwwds_8_tfcustomerid ,
                                             short AV55Customercustomizationwwds_9_tfcustomerid_to ,
                                             string AV57Customercustomizationwwds_11_tfcustomername_sel ,
                                             string AV56Customercustomizationwwds_10_tfcustomername ,
                                             short A128CustomerCustomizationId ,
                                             string A131CustomerCustomizationBaseColor ,
                                             string A132CustomerCustomizationFontSize ,
                                             short A1CustomerId ,
                                             string A3CustomerName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CustomerCustomizationFontSize, T1.CustomerId, T1.CustomerCustomizationId, T2.CustomerName, T1.CustomerCustomizationBaseColor FROM (CustomerCustomization T1 INNER JOIN Customer T2 ON T2.CustomerId = T1.CustomerId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.CustomerCustomizationId,'9999'), 2) like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationBaseColor like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationFontSize like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.CustomerId,'9999'), 2) like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( T2.CustomerName like '%' || :lV47Customercustomizationwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV48Customercustomizationwwds_2_tfcustomercustomizationid) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId >= :AV48Customercustomizationwwds_2_tfcustomercustomizationid)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV49Customercustomizationwwds_3_tfcustomercustomizationid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId <= :AV49Customercustomizationwwds_3_tfcustomercustomizationid_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor like :lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolo)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ! ( StringUtil.StrCmp(AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor = ( :AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolo))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationBaseColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize like :lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ! ( StringUtil.StrCmp(AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize = ( :AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationFontSize))=0))");
         }
         if ( ! (0==AV54Customercustomizationwwds_8_tfcustomerid) )
         {
            AddWhere(sWhereString, "(T1.CustomerId >= :AV54Customercustomizationwwds_8_tfcustomerid)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV55Customercustomizationwwds_9_tfcustomerid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerId <= :AV55Customercustomizationwwds_9_tfcustomerid_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Customercustomizationwwds_11_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customercustomizationwwds_10_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName like :lV56Customercustomizationwwds_10_tfcustomername)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customercustomizationwwds_11_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV57Customercustomizationwwds_11_tfcustomername_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName = ( :AV57Customercustomizationwwds_11_tfcustomername_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV57Customercustomizationwwds_11_tfcustomername_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerCustomizationFontSize";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00394( IGxContext context ,
                                             string AV47Customercustomizationwwds_1_filterfulltext ,
                                             short AV48Customercustomizationwwds_2_tfcustomercustomizationid ,
                                             short AV49Customercustomizationwwds_3_tfcustomercustomizationid_to ,
                                             string AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel ,
                                             string AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor ,
                                             string AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel ,
                                             string AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize ,
                                             short AV54Customercustomizationwwds_8_tfcustomerid ,
                                             short AV55Customercustomizationwwds_9_tfcustomerid_to ,
                                             string AV57Customercustomizationwwds_11_tfcustomername_sel ,
                                             string AV56Customercustomizationwwds_10_tfcustomername ,
                                             short A128CustomerCustomizationId ,
                                             string A131CustomerCustomizationBaseColor ,
                                             string A132CustomerCustomizationFontSize ,
                                             short A1CustomerId ,
                                             string A3CustomerName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.CustomerName, T1.CustomerId, T1.CustomerCustomizationId, T1.CustomerCustomizationFontSize, T1.CustomerCustomizationBaseColor FROM (CustomerCustomization T1 INNER JOIN Customer T2 ON T2.CustomerId = T1.CustomerId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Customercustomizationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.CustomerCustomizationId,'9999'), 2) like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationBaseColor like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( T1.CustomerCustomizationFontSize like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.CustomerId,'9999'), 2) like '%' || :lV47Customercustomizationwwds_1_filterfulltext) or ( T2.CustomerName like '%' || :lV47Customercustomizationwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV48Customercustomizationwwds_2_tfcustomercustomizationid) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId >= :AV48Customercustomizationwwds_2_tfcustomercustomizationid)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV49Customercustomizationwwds_3_tfcustomercustomizationid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationId <= :AV49Customercustomizationwwds_3_tfcustomercustomizationid_to)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Customercustomizationwwds_4_tfcustomercustomizationbasecolor)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor like :lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolo)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel)) && ! ( StringUtil.StrCmp(AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationBaseColor = ( :AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolo))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationBaseColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Customercustomizationwwds_6_tfcustomercustomizationfontsize)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize like :lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel)) && ! ( StringUtil.StrCmp(AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerCustomizationFontSize = ( :AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerCustomizationFontSize))=0))");
         }
         if ( ! (0==AV54Customercustomizationwwds_8_tfcustomerid) )
         {
            AddWhere(sWhereString, "(T1.CustomerId >= :AV54Customercustomizationwwds_8_tfcustomerid)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV55Customercustomizationwwds_9_tfcustomerid_to) )
         {
            AddWhere(sWhereString, "(T1.CustomerId <= :AV55Customercustomizationwwds_9_tfcustomerid_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Customercustomizationwwds_11_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customercustomizationwwds_10_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName like :lV56Customercustomizationwwds_10_tfcustomername)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customercustomizationwwds_11_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV57Customercustomizationwwds_11_tfcustomername_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerName = ( :AV57Customercustomizationwwds_11_tfcustomername_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV57Customercustomizationwwds_11_tfcustomername_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.CustomerName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00392(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] );
               case 1 :
                     return conditional_P00393(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] );
               case 2 :
                     return conditional_P00394(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00392;
          prmP00392 = new Object[] {
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV48Customercustomizationwwds_2_tfcustomercustomizationid",GXType.Int16,4,0) ,
          new ParDef("AV49Customercustomizationwwds_3_tfcustomercustomizationid_to",GXType.Int16,4,0) ,
          new ParDef("lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV54Customercustomizationwwds_8_tfcustomerid",GXType.Int16,4,0) ,
          new ParDef("AV55Customercustomizationwwds_9_tfcustomerid_to",GXType.Int16,4,0) ,
          new ParDef("lV56Customercustomizationwwds_10_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV57Customercustomizationwwds_11_tfcustomername_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00393;
          prmP00393 = new Object[] {
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV48Customercustomizationwwds_2_tfcustomercustomizationid",GXType.Int16,4,0) ,
          new ParDef("AV49Customercustomizationwwds_3_tfcustomercustomizationid_to",GXType.Int16,4,0) ,
          new ParDef("lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV54Customercustomizationwwds_8_tfcustomerid",GXType.Int16,4,0) ,
          new ParDef("AV55Customercustomizationwwds_9_tfcustomerid_to",GXType.Int16,4,0) ,
          new ParDef("lV56Customercustomizationwwds_10_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV57Customercustomizationwwds_11_tfcustomername_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00394;
          prmP00394 = new Object[] {
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Customercustomizationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV48Customercustomizationwwds_2_tfcustomercustomizationid",GXType.Int16,4,0) ,
          new ParDef("AV49Customercustomizationwwds_3_tfcustomercustomizationid_to",GXType.Int16,4,0) ,
          new ParDef("lV50Customercustomizationwwds_4_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("AV51Customercustomizationwwds_5_tfcustomercustomizationbasecolo",GXType.VarChar,40,0) ,
          new ParDef("lV52Customercustomizationwwds_6_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV53Customercustomizationwwds_7_tfcustomercustomizationfontsize",GXType.VarChar,40,0) ,
          new ParDef("AV54Customercustomizationwwds_8_tfcustomerid",GXType.Int16,4,0) ,
          new ParDef("AV55Customercustomizationwwds_9_tfcustomerid_to",GXType.Int16,4,0) ,
          new ParDef("lV56Customercustomizationwwds_10_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV57Customercustomizationwwds_11_tfcustomername_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00392", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00392,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00393", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00393,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00394", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00394,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
