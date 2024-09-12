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
   public class customerwwgetfilterdata : GXProcedure
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
            return "customerww_Services_Execute" ;
         }

      }

      public customerwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customerwwgetfilterdata( IGxContext context )
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
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV52OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34MaxItems = 10;
         AV33PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV48SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV31SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? "" : StringUtil.Substring( AV48SearchTxtParms, 3, -1));
         AV32SkipItems = (short)(AV33PageIndex*AV34MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CUSTOMERKVKNUMBER") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERKVKNUMBEROPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CUSTOMERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CUSTOMEREMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMEREMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CUSTOMERPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERPHONEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CUSTOMERVATNUMBER") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERVATNUMBEROPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CUSTOMERVISITINGADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERVISITINGADDRESSOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CUSTOMERPOSTALADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERPOSTALADDRESSOPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CUSTOMERTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERTYPENAMEOPTIONS' */
            S191 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV50OptionsJson = AV37Options.ToJSonString(false);
         AV51OptionsDescJson = AV39OptionsDesc.ToJSonString(false);
         AV52OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("CustomerWWGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CustomerWWGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("CustomerWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERKVKNUMBER") == 0 )
            {
               AV13TFCustomerKvkNumber = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERKVKNUMBER_SEL") == 0 )
            {
               AV14TFCustomerKvkNumber_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERNAME") == 0 )
            {
               AV15TFCustomerName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERNAME_SEL") == 0 )
            {
               AV16TFCustomerName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMEREMAIL") == 0 )
            {
               AV19TFCustomerEmail = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMEREMAIL_SEL") == 0 )
            {
               AV20TFCustomerEmail_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERPHONE") == 0 )
            {
               AV23TFCustomerPhone = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERPHONE_SEL") == 0 )
            {
               AV24TFCustomerPhone_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERVATNUMBER") == 0 )
            {
               AV25TFCustomerVatNumber = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERVATNUMBER_SEL") == 0 )
            {
               AV26TFCustomerVatNumber_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERVISITINGADDRESS") == 0 )
            {
               AV21TFCustomerVisitingAddress = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERVISITINGADDRESS_SEL") == 0 )
            {
               AV22TFCustomerVisitingAddress_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERPOSTALADDRESS") == 0 )
            {
               AV17TFCustomerPostalAddress = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERPOSTALADDRESS_SEL") == 0 )
            {
               AV18TFCustomerPostalAddress_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERTYPENAME") == 0 )
            {
               AV29TFCustomerTypeName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERTYPENAME_SEL") == 0 )
            {
               AV30TFCustomerTypeName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCUSTOMERKVKNUMBEROPTIONS' Routine */
         returnInSub = false;
         AV13TFCustomerKvkNumber = AV31SearchTxt;
         AV14TFCustomerKvkNumber_Sel = "";
         AV56Customerwwds_1_filterfulltext = AV53FilterFullText;
         AV57Customerwwds_2_tfcustomerkvknumber = AV13TFCustomerKvkNumber;
         AV58Customerwwds_3_tfcustomerkvknumber_sel = AV14TFCustomerKvkNumber_Sel;
         AV59Customerwwds_4_tfcustomername = AV15TFCustomerName;
         AV60Customerwwds_5_tfcustomername_sel = AV16TFCustomerName_Sel;
         AV61Customerwwds_6_tfcustomeremail = AV19TFCustomerEmail;
         AV62Customerwwds_7_tfcustomeremail_sel = AV20TFCustomerEmail_Sel;
         AV63Customerwwds_8_tfcustomerphone = AV23TFCustomerPhone;
         AV64Customerwwds_9_tfcustomerphone_sel = AV24TFCustomerPhone_Sel;
         AV65Customerwwds_10_tfcustomervatnumber = AV25TFCustomerVatNumber;
         AV66Customerwwds_11_tfcustomervatnumber_sel = AV26TFCustomerVatNumber_Sel;
         AV67Customerwwds_12_tfcustomervisitingaddress = AV21TFCustomerVisitingAddress;
         AV68Customerwwds_13_tfcustomervisitingaddress_sel = AV22TFCustomerVisitingAddress_Sel;
         AV69Customerwwds_14_tfcustomerpostaladdress = AV17TFCustomerPostalAddress;
         AV70Customerwwds_15_tfcustomerpostaladdress_sel = AV18TFCustomerPostalAddress_Sel;
         AV71Customerwwds_16_tfcustomertypename = AV29TFCustomerTypeName;
         AV72Customerwwds_17_tfcustomertypename_sel = AV30TFCustomerTypeName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Customerwwds_1_filterfulltext ,
                                              AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                              AV57Customerwwds_2_tfcustomerkvknumber ,
                                              AV60Customerwwds_5_tfcustomername_sel ,
                                              AV59Customerwwds_4_tfcustomername ,
                                              AV62Customerwwds_7_tfcustomeremail_sel ,
                                              AV61Customerwwds_6_tfcustomeremail ,
                                              AV64Customerwwds_9_tfcustomerphone_sel ,
                                              AV63Customerwwds_8_tfcustomerphone ,
                                              AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                              AV65Customerwwds_10_tfcustomervatnumber ,
                                              AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                              AV67Customerwwds_12_tfcustomervisitingaddress ,
                                              AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                              AV69Customerwwds_14_tfcustomerpostaladdress ,
                                              AV72Customerwwds_17_tfcustomertypename_sel ,
                                              AV71Customerwwds_16_tfcustomertypename ,
                                              A41CustomerKvkNumber ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A6CustomerVisitingAddress ,
                                              A4CustomerPostalAddress ,
                                              A79CustomerTypeName } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV57Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber), "%", "");
         lV59Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customerwwds_4_tfcustomername), "%", "");
         lV61Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail), "%", "");
         lV63Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone), 20, "%");
         lV65Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber), "%", "");
         lV67Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress), "%", "");
         lV69Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress), "%", "");
         lV71Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename), "%", "");
         /* Using cursor P002B2 */
         pr_default.execute(0, new Object[] {lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV57Customerwwds_2_tfcustomerkvknumber, AV58Customerwwds_3_tfcustomerkvknumber_sel, lV59Customerwwds_4_tfcustomername, AV60Customerwwds_5_tfcustomername_sel, lV61Customerwwds_6_tfcustomeremail, AV62Customerwwds_7_tfcustomeremail_sel, lV63Customerwwds_8_tfcustomerphone, AV64Customerwwds_9_tfcustomerphone_sel, lV65Customerwwds_10_tfcustomervatnumber, AV66Customerwwds_11_tfcustomervatnumber_sel, lV67Customerwwds_12_tfcustomervisitingaddress, AV68Customerwwds_13_tfcustomervisitingaddress_sel, lV69Customerwwds_14_tfcustomerpostaladdress, AV70Customerwwds_15_tfcustomerpostaladdress_sel, lV71Customerwwds_16_tfcustomertypename, AV72Customerwwds_17_tfcustomertypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2B2 = false;
            A78CustomerTypeId = P002B2_A78CustomerTypeId[0];
            n78CustomerTypeId = P002B2_n78CustomerTypeId[0];
            A41CustomerKvkNumber = P002B2_A41CustomerKvkNumber[0];
            A79CustomerTypeName = P002B2_A79CustomerTypeName[0];
            A4CustomerPostalAddress = P002B2_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = P002B2_n4CustomerPostalAddress[0];
            A6CustomerVisitingAddress = P002B2_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = P002B2_n6CustomerVisitingAddress[0];
            A14CustomerVatNumber = P002B2_A14CustomerVatNumber[0];
            A7CustomerPhone = P002B2_A7CustomerPhone[0];
            n7CustomerPhone = P002B2_n7CustomerPhone[0];
            A5CustomerEmail = P002B2_A5CustomerEmail[0];
            n5CustomerEmail = P002B2_n5CustomerEmail[0];
            A3CustomerName = P002B2_A3CustomerName[0];
            A1CustomerId = P002B2_A1CustomerId[0];
            A79CustomerTypeName = P002B2_A79CustomerTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002B2_A41CustomerKvkNumber[0], A41CustomerKvkNumber) == 0 ) )
            {
               BRK2B2 = false;
               A1CustomerId = P002B2_A1CustomerId[0];
               AV41count = (long)(AV41count+1);
               BRK2B2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A41CustomerKvkNumber)) ? "<#Empty#>" : A41CustomerKvkNumber);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2B2 )
            {
               BRK2B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCUSTOMERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFCustomerName = AV31SearchTxt;
         AV16TFCustomerName_Sel = "";
         AV56Customerwwds_1_filterfulltext = AV53FilterFullText;
         AV57Customerwwds_2_tfcustomerkvknumber = AV13TFCustomerKvkNumber;
         AV58Customerwwds_3_tfcustomerkvknumber_sel = AV14TFCustomerKvkNumber_Sel;
         AV59Customerwwds_4_tfcustomername = AV15TFCustomerName;
         AV60Customerwwds_5_tfcustomername_sel = AV16TFCustomerName_Sel;
         AV61Customerwwds_6_tfcustomeremail = AV19TFCustomerEmail;
         AV62Customerwwds_7_tfcustomeremail_sel = AV20TFCustomerEmail_Sel;
         AV63Customerwwds_8_tfcustomerphone = AV23TFCustomerPhone;
         AV64Customerwwds_9_tfcustomerphone_sel = AV24TFCustomerPhone_Sel;
         AV65Customerwwds_10_tfcustomervatnumber = AV25TFCustomerVatNumber;
         AV66Customerwwds_11_tfcustomervatnumber_sel = AV26TFCustomerVatNumber_Sel;
         AV67Customerwwds_12_tfcustomervisitingaddress = AV21TFCustomerVisitingAddress;
         AV68Customerwwds_13_tfcustomervisitingaddress_sel = AV22TFCustomerVisitingAddress_Sel;
         AV69Customerwwds_14_tfcustomerpostaladdress = AV17TFCustomerPostalAddress;
         AV70Customerwwds_15_tfcustomerpostaladdress_sel = AV18TFCustomerPostalAddress_Sel;
         AV71Customerwwds_16_tfcustomertypename = AV29TFCustomerTypeName;
         AV72Customerwwds_17_tfcustomertypename_sel = AV30TFCustomerTypeName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV56Customerwwds_1_filterfulltext ,
                                              AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                              AV57Customerwwds_2_tfcustomerkvknumber ,
                                              AV60Customerwwds_5_tfcustomername_sel ,
                                              AV59Customerwwds_4_tfcustomername ,
                                              AV62Customerwwds_7_tfcustomeremail_sel ,
                                              AV61Customerwwds_6_tfcustomeremail ,
                                              AV64Customerwwds_9_tfcustomerphone_sel ,
                                              AV63Customerwwds_8_tfcustomerphone ,
                                              AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                              AV65Customerwwds_10_tfcustomervatnumber ,
                                              AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                              AV67Customerwwds_12_tfcustomervisitingaddress ,
                                              AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                              AV69Customerwwds_14_tfcustomerpostaladdress ,
                                              AV72Customerwwds_17_tfcustomertypename_sel ,
                                              AV71Customerwwds_16_tfcustomertypename ,
                                              A41CustomerKvkNumber ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A6CustomerVisitingAddress ,
                                              A4CustomerPostalAddress ,
                                              A79CustomerTypeName } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV57Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber), "%", "");
         lV59Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customerwwds_4_tfcustomername), "%", "");
         lV61Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail), "%", "");
         lV63Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone), 20, "%");
         lV65Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber), "%", "");
         lV67Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress), "%", "");
         lV69Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress), "%", "");
         lV71Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename), "%", "");
         /* Using cursor P002B3 */
         pr_default.execute(1, new Object[] {lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV57Customerwwds_2_tfcustomerkvknumber, AV58Customerwwds_3_tfcustomerkvknumber_sel, lV59Customerwwds_4_tfcustomername, AV60Customerwwds_5_tfcustomername_sel, lV61Customerwwds_6_tfcustomeremail, AV62Customerwwds_7_tfcustomeremail_sel, lV63Customerwwds_8_tfcustomerphone, AV64Customerwwds_9_tfcustomerphone_sel, lV65Customerwwds_10_tfcustomervatnumber, AV66Customerwwds_11_tfcustomervatnumber_sel, lV67Customerwwds_12_tfcustomervisitingaddress, AV68Customerwwds_13_tfcustomervisitingaddress_sel, lV69Customerwwds_14_tfcustomerpostaladdress, AV70Customerwwds_15_tfcustomerpostaladdress_sel, lV71Customerwwds_16_tfcustomertypename, AV72Customerwwds_17_tfcustomertypename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2B4 = false;
            A78CustomerTypeId = P002B3_A78CustomerTypeId[0];
            n78CustomerTypeId = P002B3_n78CustomerTypeId[0];
            A3CustomerName = P002B3_A3CustomerName[0];
            A79CustomerTypeName = P002B3_A79CustomerTypeName[0];
            A4CustomerPostalAddress = P002B3_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = P002B3_n4CustomerPostalAddress[0];
            A6CustomerVisitingAddress = P002B3_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = P002B3_n6CustomerVisitingAddress[0];
            A14CustomerVatNumber = P002B3_A14CustomerVatNumber[0];
            A7CustomerPhone = P002B3_A7CustomerPhone[0];
            n7CustomerPhone = P002B3_n7CustomerPhone[0];
            A5CustomerEmail = P002B3_A5CustomerEmail[0];
            n5CustomerEmail = P002B3_n5CustomerEmail[0];
            A41CustomerKvkNumber = P002B3_A41CustomerKvkNumber[0];
            A1CustomerId = P002B3_A1CustomerId[0];
            A79CustomerTypeName = P002B3_A79CustomerTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002B3_A3CustomerName[0], A3CustomerName) == 0 ) )
            {
               BRK2B4 = false;
               A1CustomerId = P002B3_A1CustomerId[0];
               AV41count = (long)(AV41count+1);
               BRK2B4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A3CustomerName)) ? "<#Empty#>" : A3CustomerName);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2B4 )
            {
               BRK2B4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCUSTOMEREMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFCustomerEmail = AV31SearchTxt;
         AV20TFCustomerEmail_Sel = "";
         AV56Customerwwds_1_filterfulltext = AV53FilterFullText;
         AV57Customerwwds_2_tfcustomerkvknumber = AV13TFCustomerKvkNumber;
         AV58Customerwwds_3_tfcustomerkvknumber_sel = AV14TFCustomerKvkNumber_Sel;
         AV59Customerwwds_4_tfcustomername = AV15TFCustomerName;
         AV60Customerwwds_5_tfcustomername_sel = AV16TFCustomerName_Sel;
         AV61Customerwwds_6_tfcustomeremail = AV19TFCustomerEmail;
         AV62Customerwwds_7_tfcustomeremail_sel = AV20TFCustomerEmail_Sel;
         AV63Customerwwds_8_tfcustomerphone = AV23TFCustomerPhone;
         AV64Customerwwds_9_tfcustomerphone_sel = AV24TFCustomerPhone_Sel;
         AV65Customerwwds_10_tfcustomervatnumber = AV25TFCustomerVatNumber;
         AV66Customerwwds_11_tfcustomervatnumber_sel = AV26TFCustomerVatNumber_Sel;
         AV67Customerwwds_12_tfcustomervisitingaddress = AV21TFCustomerVisitingAddress;
         AV68Customerwwds_13_tfcustomervisitingaddress_sel = AV22TFCustomerVisitingAddress_Sel;
         AV69Customerwwds_14_tfcustomerpostaladdress = AV17TFCustomerPostalAddress;
         AV70Customerwwds_15_tfcustomerpostaladdress_sel = AV18TFCustomerPostalAddress_Sel;
         AV71Customerwwds_16_tfcustomertypename = AV29TFCustomerTypeName;
         AV72Customerwwds_17_tfcustomertypename_sel = AV30TFCustomerTypeName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV56Customerwwds_1_filterfulltext ,
                                              AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                              AV57Customerwwds_2_tfcustomerkvknumber ,
                                              AV60Customerwwds_5_tfcustomername_sel ,
                                              AV59Customerwwds_4_tfcustomername ,
                                              AV62Customerwwds_7_tfcustomeremail_sel ,
                                              AV61Customerwwds_6_tfcustomeremail ,
                                              AV64Customerwwds_9_tfcustomerphone_sel ,
                                              AV63Customerwwds_8_tfcustomerphone ,
                                              AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                              AV65Customerwwds_10_tfcustomervatnumber ,
                                              AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                              AV67Customerwwds_12_tfcustomervisitingaddress ,
                                              AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                              AV69Customerwwds_14_tfcustomerpostaladdress ,
                                              AV72Customerwwds_17_tfcustomertypename_sel ,
                                              AV71Customerwwds_16_tfcustomertypename ,
                                              A41CustomerKvkNumber ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A6CustomerVisitingAddress ,
                                              A4CustomerPostalAddress ,
                                              A79CustomerTypeName } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV57Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber), "%", "");
         lV59Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customerwwds_4_tfcustomername), "%", "");
         lV61Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail), "%", "");
         lV63Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone), 20, "%");
         lV65Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber), "%", "");
         lV67Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress), "%", "");
         lV69Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress), "%", "");
         lV71Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename), "%", "");
         /* Using cursor P002B4 */
         pr_default.execute(2, new Object[] {lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV57Customerwwds_2_tfcustomerkvknumber, AV58Customerwwds_3_tfcustomerkvknumber_sel, lV59Customerwwds_4_tfcustomername, AV60Customerwwds_5_tfcustomername_sel, lV61Customerwwds_6_tfcustomeremail, AV62Customerwwds_7_tfcustomeremail_sel, lV63Customerwwds_8_tfcustomerphone, AV64Customerwwds_9_tfcustomerphone_sel, lV65Customerwwds_10_tfcustomervatnumber, AV66Customerwwds_11_tfcustomervatnumber_sel, lV67Customerwwds_12_tfcustomervisitingaddress, AV68Customerwwds_13_tfcustomervisitingaddress_sel, lV69Customerwwds_14_tfcustomerpostaladdress, AV70Customerwwds_15_tfcustomerpostaladdress_sel, lV71Customerwwds_16_tfcustomertypename, AV72Customerwwds_17_tfcustomertypename_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2B6 = false;
            A78CustomerTypeId = P002B4_A78CustomerTypeId[0];
            n78CustomerTypeId = P002B4_n78CustomerTypeId[0];
            A5CustomerEmail = P002B4_A5CustomerEmail[0];
            n5CustomerEmail = P002B4_n5CustomerEmail[0];
            A79CustomerTypeName = P002B4_A79CustomerTypeName[0];
            A4CustomerPostalAddress = P002B4_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = P002B4_n4CustomerPostalAddress[0];
            A6CustomerVisitingAddress = P002B4_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = P002B4_n6CustomerVisitingAddress[0];
            A14CustomerVatNumber = P002B4_A14CustomerVatNumber[0];
            A7CustomerPhone = P002B4_A7CustomerPhone[0];
            n7CustomerPhone = P002B4_n7CustomerPhone[0];
            A3CustomerName = P002B4_A3CustomerName[0];
            A41CustomerKvkNumber = P002B4_A41CustomerKvkNumber[0];
            A1CustomerId = P002B4_A1CustomerId[0];
            A79CustomerTypeName = P002B4_A79CustomerTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002B4_A5CustomerEmail[0], A5CustomerEmail) == 0 ) )
            {
               BRK2B6 = false;
               A1CustomerId = P002B4_A1CustomerId[0];
               AV41count = (long)(AV41count+1);
               BRK2B6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A5CustomerEmail)) ? "<#Empty#>" : A5CustomerEmail);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2B6 )
            {
               BRK2B6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADCUSTOMERPHONEOPTIONS' Routine */
         returnInSub = false;
         AV23TFCustomerPhone = AV31SearchTxt;
         AV24TFCustomerPhone_Sel = "";
         AV56Customerwwds_1_filterfulltext = AV53FilterFullText;
         AV57Customerwwds_2_tfcustomerkvknumber = AV13TFCustomerKvkNumber;
         AV58Customerwwds_3_tfcustomerkvknumber_sel = AV14TFCustomerKvkNumber_Sel;
         AV59Customerwwds_4_tfcustomername = AV15TFCustomerName;
         AV60Customerwwds_5_tfcustomername_sel = AV16TFCustomerName_Sel;
         AV61Customerwwds_6_tfcustomeremail = AV19TFCustomerEmail;
         AV62Customerwwds_7_tfcustomeremail_sel = AV20TFCustomerEmail_Sel;
         AV63Customerwwds_8_tfcustomerphone = AV23TFCustomerPhone;
         AV64Customerwwds_9_tfcustomerphone_sel = AV24TFCustomerPhone_Sel;
         AV65Customerwwds_10_tfcustomervatnumber = AV25TFCustomerVatNumber;
         AV66Customerwwds_11_tfcustomervatnumber_sel = AV26TFCustomerVatNumber_Sel;
         AV67Customerwwds_12_tfcustomervisitingaddress = AV21TFCustomerVisitingAddress;
         AV68Customerwwds_13_tfcustomervisitingaddress_sel = AV22TFCustomerVisitingAddress_Sel;
         AV69Customerwwds_14_tfcustomerpostaladdress = AV17TFCustomerPostalAddress;
         AV70Customerwwds_15_tfcustomerpostaladdress_sel = AV18TFCustomerPostalAddress_Sel;
         AV71Customerwwds_16_tfcustomertypename = AV29TFCustomerTypeName;
         AV72Customerwwds_17_tfcustomertypename_sel = AV30TFCustomerTypeName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV56Customerwwds_1_filterfulltext ,
                                              AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                              AV57Customerwwds_2_tfcustomerkvknumber ,
                                              AV60Customerwwds_5_tfcustomername_sel ,
                                              AV59Customerwwds_4_tfcustomername ,
                                              AV62Customerwwds_7_tfcustomeremail_sel ,
                                              AV61Customerwwds_6_tfcustomeremail ,
                                              AV64Customerwwds_9_tfcustomerphone_sel ,
                                              AV63Customerwwds_8_tfcustomerphone ,
                                              AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                              AV65Customerwwds_10_tfcustomervatnumber ,
                                              AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                              AV67Customerwwds_12_tfcustomervisitingaddress ,
                                              AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                              AV69Customerwwds_14_tfcustomerpostaladdress ,
                                              AV72Customerwwds_17_tfcustomertypename_sel ,
                                              AV71Customerwwds_16_tfcustomertypename ,
                                              A41CustomerKvkNumber ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A6CustomerVisitingAddress ,
                                              A4CustomerPostalAddress ,
                                              A79CustomerTypeName } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV57Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber), "%", "");
         lV59Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customerwwds_4_tfcustomername), "%", "");
         lV61Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail), "%", "");
         lV63Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone), 20, "%");
         lV65Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber), "%", "");
         lV67Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress), "%", "");
         lV69Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress), "%", "");
         lV71Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename), "%", "");
         /* Using cursor P002B5 */
         pr_default.execute(3, new Object[] {lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV57Customerwwds_2_tfcustomerkvknumber, AV58Customerwwds_3_tfcustomerkvknumber_sel, lV59Customerwwds_4_tfcustomername, AV60Customerwwds_5_tfcustomername_sel, lV61Customerwwds_6_tfcustomeremail, AV62Customerwwds_7_tfcustomeremail_sel, lV63Customerwwds_8_tfcustomerphone, AV64Customerwwds_9_tfcustomerphone_sel, lV65Customerwwds_10_tfcustomervatnumber, AV66Customerwwds_11_tfcustomervatnumber_sel, lV67Customerwwds_12_tfcustomervisitingaddress, AV68Customerwwds_13_tfcustomervisitingaddress_sel, lV69Customerwwds_14_tfcustomerpostaladdress, AV70Customerwwds_15_tfcustomerpostaladdress_sel, lV71Customerwwds_16_tfcustomertypename, AV72Customerwwds_17_tfcustomertypename_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK2B8 = false;
            A78CustomerTypeId = P002B5_A78CustomerTypeId[0];
            n78CustomerTypeId = P002B5_n78CustomerTypeId[0];
            A7CustomerPhone = P002B5_A7CustomerPhone[0];
            n7CustomerPhone = P002B5_n7CustomerPhone[0];
            A79CustomerTypeName = P002B5_A79CustomerTypeName[0];
            A4CustomerPostalAddress = P002B5_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = P002B5_n4CustomerPostalAddress[0];
            A6CustomerVisitingAddress = P002B5_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = P002B5_n6CustomerVisitingAddress[0];
            A14CustomerVatNumber = P002B5_A14CustomerVatNumber[0];
            A5CustomerEmail = P002B5_A5CustomerEmail[0];
            n5CustomerEmail = P002B5_n5CustomerEmail[0];
            A3CustomerName = P002B5_A3CustomerName[0];
            A41CustomerKvkNumber = P002B5_A41CustomerKvkNumber[0];
            A1CustomerId = P002B5_A1CustomerId[0];
            A79CustomerTypeName = P002B5_A79CustomerTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P002B5_A7CustomerPhone[0], A7CustomerPhone) == 0 ) )
            {
               BRK2B8 = false;
               A1CustomerId = P002B5_A1CustomerId[0];
               AV41count = (long)(AV41count+1);
               BRK2B8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A7CustomerPhone)) ? "<#Empty#>" : A7CustomerPhone);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2B8 )
            {
               BRK2B8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADCUSTOMERVATNUMBEROPTIONS' Routine */
         returnInSub = false;
         AV25TFCustomerVatNumber = AV31SearchTxt;
         AV26TFCustomerVatNumber_Sel = "";
         AV56Customerwwds_1_filterfulltext = AV53FilterFullText;
         AV57Customerwwds_2_tfcustomerkvknumber = AV13TFCustomerKvkNumber;
         AV58Customerwwds_3_tfcustomerkvknumber_sel = AV14TFCustomerKvkNumber_Sel;
         AV59Customerwwds_4_tfcustomername = AV15TFCustomerName;
         AV60Customerwwds_5_tfcustomername_sel = AV16TFCustomerName_Sel;
         AV61Customerwwds_6_tfcustomeremail = AV19TFCustomerEmail;
         AV62Customerwwds_7_tfcustomeremail_sel = AV20TFCustomerEmail_Sel;
         AV63Customerwwds_8_tfcustomerphone = AV23TFCustomerPhone;
         AV64Customerwwds_9_tfcustomerphone_sel = AV24TFCustomerPhone_Sel;
         AV65Customerwwds_10_tfcustomervatnumber = AV25TFCustomerVatNumber;
         AV66Customerwwds_11_tfcustomervatnumber_sel = AV26TFCustomerVatNumber_Sel;
         AV67Customerwwds_12_tfcustomervisitingaddress = AV21TFCustomerVisitingAddress;
         AV68Customerwwds_13_tfcustomervisitingaddress_sel = AV22TFCustomerVisitingAddress_Sel;
         AV69Customerwwds_14_tfcustomerpostaladdress = AV17TFCustomerPostalAddress;
         AV70Customerwwds_15_tfcustomerpostaladdress_sel = AV18TFCustomerPostalAddress_Sel;
         AV71Customerwwds_16_tfcustomertypename = AV29TFCustomerTypeName;
         AV72Customerwwds_17_tfcustomertypename_sel = AV30TFCustomerTypeName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV56Customerwwds_1_filterfulltext ,
                                              AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                              AV57Customerwwds_2_tfcustomerkvknumber ,
                                              AV60Customerwwds_5_tfcustomername_sel ,
                                              AV59Customerwwds_4_tfcustomername ,
                                              AV62Customerwwds_7_tfcustomeremail_sel ,
                                              AV61Customerwwds_6_tfcustomeremail ,
                                              AV64Customerwwds_9_tfcustomerphone_sel ,
                                              AV63Customerwwds_8_tfcustomerphone ,
                                              AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                              AV65Customerwwds_10_tfcustomervatnumber ,
                                              AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                              AV67Customerwwds_12_tfcustomervisitingaddress ,
                                              AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                              AV69Customerwwds_14_tfcustomerpostaladdress ,
                                              AV72Customerwwds_17_tfcustomertypename_sel ,
                                              AV71Customerwwds_16_tfcustomertypename ,
                                              A41CustomerKvkNumber ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A6CustomerVisitingAddress ,
                                              A4CustomerPostalAddress ,
                                              A79CustomerTypeName } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV57Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber), "%", "");
         lV59Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customerwwds_4_tfcustomername), "%", "");
         lV61Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail), "%", "");
         lV63Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone), 20, "%");
         lV65Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber), "%", "");
         lV67Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress), "%", "");
         lV69Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress), "%", "");
         lV71Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename), "%", "");
         /* Using cursor P002B6 */
         pr_default.execute(4, new Object[] {lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV57Customerwwds_2_tfcustomerkvknumber, AV58Customerwwds_3_tfcustomerkvknumber_sel, lV59Customerwwds_4_tfcustomername, AV60Customerwwds_5_tfcustomername_sel, lV61Customerwwds_6_tfcustomeremail, AV62Customerwwds_7_tfcustomeremail_sel, lV63Customerwwds_8_tfcustomerphone, AV64Customerwwds_9_tfcustomerphone_sel, lV65Customerwwds_10_tfcustomervatnumber, AV66Customerwwds_11_tfcustomervatnumber_sel, lV67Customerwwds_12_tfcustomervisitingaddress, AV68Customerwwds_13_tfcustomervisitingaddress_sel, lV69Customerwwds_14_tfcustomerpostaladdress, AV70Customerwwds_15_tfcustomerpostaladdress_sel, lV71Customerwwds_16_tfcustomertypename, AV72Customerwwds_17_tfcustomertypename_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK2B10 = false;
            A78CustomerTypeId = P002B6_A78CustomerTypeId[0];
            n78CustomerTypeId = P002B6_n78CustomerTypeId[0];
            A14CustomerVatNumber = P002B6_A14CustomerVatNumber[0];
            A79CustomerTypeName = P002B6_A79CustomerTypeName[0];
            A4CustomerPostalAddress = P002B6_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = P002B6_n4CustomerPostalAddress[0];
            A6CustomerVisitingAddress = P002B6_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = P002B6_n6CustomerVisitingAddress[0];
            A7CustomerPhone = P002B6_A7CustomerPhone[0];
            n7CustomerPhone = P002B6_n7CustomerPhone[0];
            A5CustomerEmail = P002B6_A5CustomerEmail[0];
            n5CustomerEmail = P002B6_n5CustomerEmail[0];
            A3CustomerName = P002B6_A3CustomerName[0];
            A41CustomerKvkNumber = P002B6_A41CustomerKvkNumber[0];
            A1CustomerId = P002B6_A1CustomerId[0];
            A79CustomerTypeName = P002B6_A79CustomerTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P002B6_A14CustomerVatNumber[0], A14CustomerVatNumber) == 0 ) )
            {
               BRK2B10 = false;
               A1CustomerId = P002B6_A1CustomerId[0];
               AV41count = (long)(AV41count+1);
               BRK2B10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A14CustomerVatNumber)) ? "<#Empty#>" : A14CustomerVatNumber);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2B10 )
            {
               BRK2B10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADCUSTOMERVISITINGADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV21TFCustomerVisitingAddress = AV31SearchTxt;
         AV22TFCustomerVisitingAddress_Sel = "";
         AV56Customerwwds_1_filterfulltext = AV53FilterFullText;
         AV57Customerwwds_2_tfcustomerkvknumber = AV13TFCustomerKvkNumber;
         AV58Customerwwds_3_tfcustomerkvknumber_sel = AV14TFCustomerKvkNumber_Sel;
         AV59Customerwwds_4_tfcustomername = AV15TFCustomerName;
         AV60Customerwwds_5_tfcustomername_sel = AV16TFCustomerName_Sel;
         AV61Customerwwds_6_tfcustomeremail = AV19TFCustomerEmail;
         AV62Customerwwds_7_tfcustomeremail_sel = AV20TFCustomerEmail_Sel;
         AV63Customerwwds_8_tfcustomerphone = AV23TFCustomerPhone;
         AV64Customerwwds_9_tfcustomerphone_sel = AV24TFCustomerPhone_Sel;
         AV65Customerwwds_10_tfcustomervatnumber = AV25TFCustomerVatNumber;
         AV66Customerwwds_11_tfcustomervatnumber_sel = AV26TFCustomerVatNumber_Sel;
         AV67Customerwwds_12_tfcustomervisitingaddress = AV21TFCustomerVisitingAddress;
         AV68Customerwwds_13_tfcustomervisitingaddress_sel = AV22TFCustomerVisitingAddress_Sel;
         AV69Customerwwds_14_tfcustomerpostaladdress = AV17TFCustomerPostalAddress;
         AV70Customerwwds_15_tfcustomerpostaladdress_sel = AV18TFCustomerPostalAddress_Sel;
         AV71Customerwwds_16_tfcustomertypename = AV29TFCustomerTypeName;
         AV72Customerwwds_17_tfcustomertypename_sel = AV30TFCustomerTypeName_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV56Customerwwds_1_filterfulltext ,
                                              AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                              AV57Customerwwds_2_tfcustomerkvknumber ,
                                              AV60Customerwwds_5_tfcustomername_sel ,
                                              AV59Customerwwds_4_tfcustomername ,
                                              AV62Customerwwds_7_tfcustomeremail_sel ,
                                              AV61Customerwwds_6_tfcustomeremail ,
                                              AV64Customerwwds_9_tfcustomerphone_sel ,
                                              AV63Customerwwds_8_tfcustomerphone ,
                                              AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                              AV65Customerwwds_10_tfcustomervatnumber ,
                                              AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                              AV67Customerwwds_12_tfcustomervisitingaddress ,
                                              AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                              AV69Customerwwds_14_tfcustomerpostaladdress ,
                                              AV72Customerwwds_17_tfcustomertypename_sel ,
                                              AV71Customerwwds_16_tfcustomertypename ,
                                              A41CustomerKvkNumber ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A6CustomerVisitingAddress ,
                                              A4CustomerPostalAddress ,
                                              A79CustomerTypeName } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV57Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber), "%", "");
         lV59Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customerwwds_4_tfcustomername), "%", "");
         lV61Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail), "%", "");
         lV63Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone), 20, "%");
         lV65Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber), "%", "");
         lV67Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress), "%", "");
         lV69Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress), "%", "");
         lV71Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename), "%", "");
         /* Using cursor P002B7 */
         pr_default.execute(5, new Object[] {lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV57Customerwwds_2_tfcustomerkvknumber, AV58Customerwwds_3_tfcustomerkvknumber_sel, lV59Customerwwds_4_tfcustomername, AV60Customerwwds_5_tfcustomername_sel, lV61Customerwwds_6_tfcustomeremail, AV62Customerwwds_7_tfcustomeremail_sel, lV63Customerwwds_8_tfcustomerphone, AV64Customerwwds_9_tfcustomerphone_sel, lV65Customerwwds_10_tfcustomervatnumber, AV66Customerwwds_11_tfcustomervatnumber_sel, lV67Customerwwds_12_tfcustomervisitingaddress, AV68Customerwwds_13_tfcustomervisitingaddress_sel, lV69Customerwwds_14_tfcustomerpostaladdress, AV70Customerwwds_15_tfcustomerpostaladdress_sel, lV71Customerwwds_16_tfcustomertypename, AV72Customerwwds_17_tfcustomertypename_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK2B12 = false;
            A78CustomerTypeId = P002B7_A78CustomerTypeId[0];
            n78CustomerTypeId = P002B7_n78CustomerTypeId[0];
            A6CustomerVisitingAddress = P002B7_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = P002B7_n6CustomerVisitingAddress[0];
            A79CustomerTypeName = P002B7_A79CustomerTypeName[0];
            A4CustomerPostalAddress = P002B7_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = P002B7_n4CustomerPostalAddress[0];
            A14CustomerVatNumber = P002B7_A14CustomerVatNumber[0];
            A7CustomerPhone = P002B7_A7CustomerPhone[0];
            n7CustomerPhone = P002B7_n7CustomerPhone[0];
            A5CustomerEmail = P002B7_A5CustomerEmail[0];
            n5CustomerEmail = P002B7_n5CustomerEmail[0];
            A3CustomerName = P002B7_A3CustomerName[0];
            A41CustomerKvkNumber = P002B7_A41CustomerKvkNumber[0];
            A1CustomerId = P002B7_A1CustomerId[0];
            A79CustomerTypeName = P002B7_A79CustomerTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P002B7_A6CustomerVisitingAddress[0], A6CustomerVisitingAddress) == 0 ) )
            {
               BRK2B12 = false;
               A1CustomerId = P002B7_A1CustomerId[0];
               AV41count = (long)(AV41count+1);
               BRK2B12 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A6CustomerVisitingAddress)) ? "<#Empty#>" : A6CustomerVisitingAddress);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2B12 )
            {
               BRK2B12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADCUSTOMERPOSTALADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV17TFCustomerPostalAddress = AV31SearchTxt;
         AV18TFCustomerPostalAddress_Sel = "";
         AV56Customerwwds_1_filterfulltext = AV53FilterFullText;
         AV57Customerwwds_2_tfcustomerkvknumber = AV13TFCustomerKvkNumber;
         AV58Customerwwds_3_tfcustomerkvknumber_sel = AV14TFCustomerKvkNumber_Sel;
         AV59Customerwwds_4_tfcustomername = AV15TFCustomerName;
         AV60Customerwwds_5_tfcustomername_sel = AV16TFCustomerName_Sel;
         AV61Customerwwds_6_tfcustomeremail = AV19TFCustomerEmail;
         AV62Customerwwds_7_tfcustomeremail_sel = AV20TFCustomerEmail_Sel;
         AV63Customerwwds_8_tfcustomerphone = AV23TFCustomerPhone;
         AV64Customerwwds_9_tfcustomerphone_sel = AV24TFCustomerPhone_Sel;
         AV65Customerwwds_10_tfcustomervatnumber = AV25TFCustomerVatNumber;
         AV66Customerwwds_11_tfcustomervatnumber_sel = AV26TFCustomerVatNumber_Sel;
         AV67Customerwwds_12_tfcustomervisitingaddress = AV21TFCustomerVisitingAddress;
         AV68Customerwwds_13_tfcustomervisitingaddress_sel = AV22TFCustomerVisitingAddress_Sel;
         AV69Customerwwds_14_tfcustomerpostaladdress = AV17TFCustomerPostalAddress;
         AV70Customerwwds_15_tfcustomerpostaladdress_sel = AV18TFCustomerPostalAddress_Sel;
         AV71Customerwwds_16_tfcustomertypename = AV29TFCustomerTypeName;
         AV72Customerwwds_17_tfcustomertypename_sel = AV30TFCustomerTypeName_Sel;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV56Customerwwds_1_filterfulltext ,
                                              AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                              AV57Customerwwds_2_tfcustomerkvknumber ,
                                              AV60Customerwwds_5_tfcustomername_sel ,
                                              AV59Customerwwds_4_tfcustomername ,
                                              AV62Customerwwds_7_tfcustomeremail_sel ,
                                              AV61Customerwwds_6_tfcustomeremail ,
                                              AV64Customerwwds_9_tfcustomerphone_sel ,
                                              AV63Customerwwds_8_tfcustomerphone ,
                                              AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                              AV65Customerwwds_10_tfcustomervatnumber ,
                                              AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                              AV67Customerwwds_12_tfcustomervisitingaddress ,
                                              AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                              AV69Customerwwds_14_tfcustomerpostaladdress ,
                                              AV72Customerwwds_17_tfcustomertypename_sel ,
                                              AV71Customerwwds_16_tfcustomertypename ,
                                              A41CustomerKvkNumber ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A6CustomerVisitingAddress ,
                                              A4CustomerPostalAddress ,
                                              A79CustomerTypeName } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV57Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber), "%", "");
         lV59Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customerwwds_4_tfcustomername), "%", "");
         lV61Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail), "%", "");
         lV63Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone), 20, "%");
         lV65Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber), "%", "");
         lV67Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress), "%", "");
         lV69Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress), "%", "");
         lV71Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename), "%", "");
         /* Using cursor P002B8 */
         pr_default.execute(6, new Object[] {lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV57Customerwwds_2_tfcustomerkvknumber, AV58Customerwwds_3_tfcustomerkvknumber_sel, lV59Customerwwds_4_tfcustomername, AV60Customerwwds_5_tfcustomername_sel, lV61Customerwwds_6_tfcustomeremail, AV62Customerwwds_7_tfcustomeremail_sel, lV63Customerwwds_8_tfcustomerphone, AV64Customerwwds_9_tfcustomerphone_sel, lV65Customerwwds_10_tfcustomervatnumber, AV66Customerwwds_11_tfcustomervatnumber_sel, lV67Customerwwds_12_tfcustomervisitingaddress, AV68Customerwwds_13_tfcustomervisitingaddress_sel, lV69Customerwwds_14_tfcustomerpostaladdress, AV70Customerwwds_15_tfcustomerpostaladdress_sel, lV71Customerwwds_16_tfcustomertypename, AV72Customerwwds_17_tfcustomertypename_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK2B14 = false;
            A78CustomerTypeId = P002B8_A78CustomerTypeId[0];
            n78CustomerTypeId = P002B8_n78CustomerTypeId[0];
            A4CustomerPostalAddress = P002B8_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = P002B8_n4CustomerPostalAddress[0];
            A79CustomerTypeName = P002B8_A79CustomerTypeName[0];
            A6CustomerVisitingAddress = P002B8_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = P002B8_n6CustomerVisitingAddress[0];
            A14CustomerVatNumber = P002B8_A14CustomerVatNumber[0];
            A7CustomerPhone = P002B8_A7CustomerPhone[0];
            n7CustomerPhone = P002B8_n7CustomerPhone[0];
            A5CustomerEmail = P002B8_A5CustomerEmail[0];
            n5CustomerEmail = P002B8_n5CustomerEmail[0];
            A3CustomerName = P002B8_A3CustomerName[0];
            A41CustomerKvkNumber = P002B8_A41CustomerKvkNumber[0];
            A1CustomerId = P002B8_A1CustomerId[0];
            A79CustomerTypeName = P002B8_A79CustomerTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P002B8_A4CustomerPostalAddress[0], A4CustomerPostalAddress) == 0 ) )
            {
               BRK2B14 = false;
               A1CustomerId = P002B8_A1CustomerId[0];
               AV41count = (long)(AV41count+1);
               BRK2B14 = true;
               pr_default.readNext(6);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A4CustomerPostalAddress)) ? "<#Empty#>" : A4CustomerPostalAddress);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK2B14 )
            {
               BRK2B14 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void S191( )
      {
         /* 'LOADCUSTOMERTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV29TFCustomerTypeName = AV31SearchTxt;
         AV30TFCustomerTypeName_Sel = "";
         AV56Customerwwds_1_filterfulltext = AV53FilterFullText;
         AV57Customerwwds_2_tfcustomerkvknumber = AV13TFCustomerKvkNumber;
         AV58Customerwwds_3_tfcustomerkvknumber_sel = AV14TFCustomerKvkNumber_Sel;
         AV59Customerwwds_4_tfcustomername = AV15TFCustomerName;
         AV60Customerwwds_5_tfcustomername_sel = AV16TFCustomerName_Sel;
         AV61Customerwwds_6_tfcustomeremail = AV19TFCustomerEmail;
         AV62Customerwwds_7_tfcustomeremail_sel = AV20TFCustomerEmail_Sel;
         AV63Customerwwds_8_tfcustomerphone = AV23TFCustomerPhone;
         AV64Customerwwds_9_tfcustomerphone_sel = AV24TFCustomerPhone_Sel;
         AV65Customerwwds_10_tfcustomervatnumber = AV25TFCustomerVatNumber;
         AV66Customerwwds_11_tfcustomervatnumber_sel = AV26TFCustomerVatNumber_Sel;
         AV67Customerwwds_12_tfcustomervisitingaddress = AV21TFCustomerVisitingAddress;
         AV68Customerwwds_13_tfcustomervisitingaddress_sel = AV22TFCustomerVisitingAddress_Sel;
         AV69Customerwwds_14_tfcustomerpostaladdress = AV17TFCustomerPostalAddress;
         AV70Customerwwds_15_tfcustomerpostaladdress_sel = AV18TFCustomerPostalAddress_Sel;
         AV71Customerwwds_16_tfcustomertypename = AV29TFCustomerTypeName;
         AV72Customerwwds_17_tfcustomertypename_sel = AV30TFCustomerTypeName_Sel;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV56Customerwwds_1_filterfulltext ,
                                              AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                              AV57Customerwwds_2_tfcustomerkvknumber ,
                                              AV60Customerwwds_5_tfcustomername_sel ,
                                              AV59Customerwwds_4_tfcustomername ,
                                              AV62Customerwwds_7_tfcustomeremail_sel ,
                                              AV61Customerwwds_6_tfcustomeremail ,
                                              AV64Customerwwds_9_tfcustomerphone_sel ,
                                              AV63Customerwwds_8_tfcustomerphone ,
                                              AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                              AV65Customerwwds_10_tfcustomervatnumber ,
                                              AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                              AV67Customerwwds_12_tfcustomervisitingaddress ,
                                              AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                              AV69Customerwwds_14_tfcustomerpostaladdress ,
                                              AV72Customerwwds_17_tfcustomertypename_sel ,
                                              AV71Customerwwds_16_tfcustomertypename ,
                                              A41CustomerKvkNumber ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A6CustomerVisitingAddress ,
                                              A4CustomerPostalAddress ,
                                              A79CustomerTypeName } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV56Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Customerwwds_1_filterfulltext), "%", "");
         lV57Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber), "%", "");
         lV59Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV59Customerwwds_4_tfcustomername), "%", "");
         lV61Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail), "%", "");
         lV63Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone), 20, "%");
         lV65Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber), "%", "");
         lV67Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress), "%", "");
         lV69Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress), "%", "");
         lV71Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename), "%", "");
         /* Using cursor P002B9 */
         pr_default.execute(7, new Object[] {lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV56Customerwwds_1_filterfulltext, lV57Customerwwds_2_tfcustomerkvknumber, AV58Customerwwds_3_tfcustomerkvknumber_sel, lV59Customerwwds_4_tfcustomername, AV60Customerwwds_5_tfcustomername_sel, lV61Customerwwds_6_tfcustomeremail, AV62Customerwwds_7_tfcustomeremail_sel, lV63Customerwwds_8_tfcustomerphone, AV64Customerwwds_9_tfcustomerphone_sel, lV65Customerwwds_10_tfcustomervatnumber, AV66Customerwwds_11_tfcustomervatnumber_sel, lV67Customerwwds_12_tfcustomervisitingaddress, AV68Customerwwds_13_tfcustomervisitingaddress_sel, lV69Customerwwds_14_tfcustomerpostaladdress, AV70Customerwwds_15_tfcustomerpostaladdress_sel, lV71Customerwwds_16_tfcustomertypename, AV72Customerwwds_17_tfcustomertypename_sel});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRK2B16 = false;
            A78CustomerTypeId = P002B9_A78CustomerTypeId[0];
            n78CustomerTypeId = P002B9_n78CustomerTypeId[0];
            A79CustomerTypeName = P002B9_A79CustomerTypeName[0];
            A4CustomerPostalAddress = P002B9_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = P002B9_n4CustomerPostalAddress[0];
            A6CustomerVisitingAddress = P002B9_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = P002B9_n6CustomerVisitingAddress[0];
            A14CustomerVatNumber = P002B9_A14CustomerVatNumber[0];
            A7CustomerPhone = P002B9_A7CustomerPhone[0];
            n7CustomerPhone = P002B9_n7CustomerPhone[0];
            A5CustomerEmail = P002B9_A5CustomerEmail[0];
            n5CustomerEmail = P002B9_n5CustomerEmail[0];
            A3CustomerName = P002B9_A3CustomerName[0];
            A41CustomerKvkNumber = P002B9_A41CustomerKvkNumber[0];
            A1CustomerId = P002B9_A1CustomerId[0];
            A79CustomerTypeName = P002B9_A79CustomerTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(7) != 101) && ( P002B9_A78CustomerTypeId[0] == A78CustomerTypeId ) )
            {
               BRK2B16 = false;
               A1CustomerId = P002B9_A1CustomerId[0];
               AV41count = (long)(AV41count+1);
               BRK2B16 = true;
               pr_default.readNext(7);
            }
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A79CustomerTypeName)) ? "<#Empty#>" : A79CustomerTypeName);
            AV35InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV35InsertIndex = (int)(AV35InsertIndex+1);
            }
            AV37Options.Add(AV36Option, AV35InsertIndex);
            AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
            if ( AV37Options.Count == AV32SkipItems + 11 )
            {
               AV37Options.RemoveItem(AV37Options.Count);
               AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
            }
            if ( ! BRK2B16 )
            {
               BRK2B16 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
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
         AV50OptionsJson = "";
         AV51OptionsDescJson = "";
         AV52OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV39OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV31SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Session = context.GetSession();
         AV44GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV45GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53FilterFullText = "";
         AV13TFCustomerKvkNumber = "";
         AV14TFCustomerKvkNumber_Sel = "";
         AV15TFCustomerName = "";
         AV16TFCustomerName_Sel = "";
         AV19TFCustomerEmail = "";
         AV20TFCustomerEmail_Sel = "";
         AV23TFCustomerPhone = "";
         AV24TFCustomerPhone_Sel = "";
         AV25TFCustomerVatNumber = "";
         AV26TFCustomerVatNumber_Sel = "";
         AV21TFCustomerVisitingAddress = "";
         AV22TFCustomerVisitingAddress_Sel = "";
         AV17TFCustomerPostalAddress = "";
         AV18TFCustomerPostalAddress_Sel = "";
         AV29TFCustomerTypeName = "";
         AV30TFCustomerTypeName_Sel = "";
         AV56Customerwwds_1_filterfulltext = "";
         AV57Customerwwds_2_tfcustomerkvknumber = "";
         AV58Customerwwds_3_tfcustomerkvknumber_sel = "";
         AV59Customerwwds_4_tfcustomername = "";
         AV60Customerwwds_5_tfcustomername_sel = "";
         AV61Customerwwds_6_tfcustomeremail = "";
         AV62Customerwwds_7_tfcustomeremail_sel = "";
         AV63Customerwwds_8_tfcustomerphone = "";
         AV64Customerwwds_9_tfcustomerphone_sel = "";
         AV65Customerwwds_10_tfcustomervatnumber = "";
         AV66Customerwwds_11_tfcustomervatnumber_sel = "";
         AV67Customerwwds_12_tfcustomervisitingaddress = "";
         AV68Customerwwds_13_tfcustomervisitingaddress_sel = "";
         AV69Customerwwds_14_tfcustomerpostaladdress = "";
         AV70Customerwwds_15_tfcustomerpostaladdress_sel = "";
         AV71Customerwwds_16_tfcustomertypename = "";
         AV72Customerwwds_17_tfcustomertypename_sel = "";
         lV56Customerwwds_1_filterfulltext = "";
         lV57Customerwwds_2_tfcustomerkvknumber = "";
         lV59Customerwwds_4_tfcustomername = "";
         lV61Customerwwds_6_tfcustomeremail = "";
         lV63Customerwwds_8_tfcustomerphone = "";
         lV65Customerwwds_10_tfcustomervatnumber = "";
         lV67Customerwwds_12_tfcustomervisitingaddress = "";
         lV69Customerwwds_14_tfcustomerpostaladdress = "";
         lV71Customerwwds_16_tfcustomertypename = "";
         A41CustomerKvkNumber = "";
         A3CustomerName = "";
         A5CustomerEmail = "";
         A7CustomerPhone = "";
         A14CustomerVatNumber = "";
         A6CustomerVisitingAddress = "";
         A4CustomerPostalAddress = "";
         A79CustomerTypeName = "";
         P002B2_A78CustomerTypeId = new short[1] ;
         P002B2_n78CustomerTypeId = new bool[] {false} ;
         P002B2_A41CustomerKvkNumber = new string[] {""} ;
         P002B2_A79CustomerTypeName = new string[] {""} ;
         P002B2_A4CustomerPostalAddress = new string[] {""} ;
         P002B2_n4CustomerPostalAddress = new bool[] {false} ;
         P002B2_A6CustomerVisitingAddress = new string[] {""} ;
         P002B2_n6CustomerVisitingAddress = new bool[] {false} ;
         P002B2_A14CustomerVatNumber = new string[] {""} ;
         P002B2_A7CustomerPhone = new string[] {""} ;
         P002B2_n7CustomerPhone = new bool[] {false} ;
         P002B2_A5CustomerEmail = new string[] {""} ;
         P002B2_n5CustomerEmail = new bool[] {false} ;
         P002B2_A3CustomerName = new string[] {""} ;
         P002B2_A1CustomerId = new short[1] ;
         AV36Option = "";
         P002B3_A78CustomerTypeId = new short[1] ;
         P002B3_n78CustomerTypeId = new bool[] {false} ;
         P002B3_A3CustomerName = new string[] {""} ;
         P002B3_A79CustomerTypeName = new string[] {""} ;
         P002B3_A4CustomerPostalAddress = new string[] {""} ;
         P002B3_n4CustomerPostalAddress = new bool[] {false} ;
         P002B3_A6CustomerVisitingAddress = new string[] {""} ;
         P002B3_n6CustomerVisitingAddress = new bool[] {false} ;
         P002B3_A14CustomerVatNumber = new string[] {""} ;
         P002B3_A7CustomerPhone = new string[] {""} ;
         P002B3_n7CustomerPhone = new bool[] {false} ;
         P002B3_A5CustomerEmail = new string[] {""} ;
         P002B3_n5CustomerEmail = new bool[] {false} ;
         P002B3_A41CustomerKvkNumber = new string[] {""} ;
         P002B3_A1CustomerId = new short[1] ;
         P002B4_A78CustomerTypeId = new short[1] ;
         P002B4_n78CustomerTypeId = new bool[] {false} ;
         P002B4_A5CustomerEmail = new string[] {""} ;
         P002B4_n5CustomerEmail = new bool[] {false} ;
         P002B4_A79CustomerTypeName = new string[] {""} ;
         P002B4_A4CustomerPostalAddress = new string[] {""} ;
         P002B4_n4CustomerPostalAddress = new bool[] {false} ;
         P002B4_A6CustomerVisitingAddress = new string[] {""} ;
         P002B4_n6CustomerVisitingAddress = new bool[] {false} ;
         P002B4_A14CustomerVatNumber = new string[] {""} ;
         P002B4_A7CustomerPhone = new string[] {""} ;
         P002B4_n7CustomerPhone = new bool[] {false} ;
         P002B4_A3CustomerName = new string[] {""} ;
         P002B4_A41CustomerKvkNumber = new string[] {""} ;
         P002B4_A1CustomerId = new short[1] ;
         P002B5_A78CustomerTypeId = new short[1] ;
         P002B5_n78CustomerTypeId = new bool[] {false} ;
         P002B5_A7CustomerPhone = new string[] {""} ;
         P002B5_n7CustomerPhone = new bool[] {false} ;
         P002B5_A79CustomerTypeName = new string[] {""} ;
         P002B5_A4CustomerPostalAddress = new string[] {""} ;
         P002B5_n4CustomerPostalAddress = new bool[] {false} ;
         P002B5_A6CustomerVisitingAddress = new string[] {""} ;
         P002B5_n6CustomerVisitingAddress = new bool[] {false} ;
         P002B5_A14CustomerVatNumber = new string[] {""} ;
         P002B5_A5CustomerEmail = new string[] {""} ;
         P002B5_n5CustomerEmail = new bool[] {false} ;
         P002B5_A3CustomerName = new string[] {""} ;
         P002B5_A41CustomerKvkNumber = new string[] {""} ;
         P002B5_A1CustomerId = new short[1] ;
         P002B6_A78CustomerTypeId = new short[1] ;
         P002B6_n78CustomerTypeId = new bool[] {false} ;
         P002B6_A14CustomerVatNumber = new string[] {""} ;
         P002B6_A79CustomerTypeName = new string[] {""} ;
         P002B6_A4CustomerPostalAddress = new string[] {""} ;
         P002B6_n4CustomerPostalAddress = new bool[] {false} ;
         P002B6_A6CustomerVisitingAddress = new string[] {""} ;
         P002B6_n6CustomerVisitingAddress = new bool[] {false} ;
         P002B6_A7CustomerPhone = new string[] {""} ;
         P002B6_n7CustomerPhone = new bool[] {false} ;
         P002B6_A5CustomerEmail = new string[] {""} ;
         P002B6_n5CustomerEmail = new bool[] {false} ;
         P002B6_A3CustomerName = new string[] {""} ;
         P002B6_A41CustomerKvkNumber = new string[] {""} ;
         P002B6_A1CustomerId = new short[1] ;
         P002B7_A78CustomerTypeId = new short[1] ;
         P002B7_n78CustomerTypeId = new bool[] {false} ;
         P002B7_A6CustomerVisitingAddress = new string[] {""} ;
         P002B7_n6CustomerVisitingAddress = new bool[] {false} ;
         P002B7_A79CustomerTypeName = new string[] {""} ;
         P002B7_A4CustomerPostalAddress = new string[] {""} ;
         P002B7_n4CustomerPostalAddress = new bool[] {false} ;
         P002B7_A14CustomerVatNumber = new string[] {""} ;
         P002B7_A7CustomerPhone = new string[] {""} ;
         P002B7_n7CustomerPhone = new bool[] {false} ;
         P002B7_A5CustomerEmail = new string[] {""} ;
         P002B7_n5CustomerEmail = new bool[] {false} ;
         P002B7_A3CustomerName = new string[] {""} ;
         P002B7_A41CustomerKvkNumber = new string[] {""} ;
         P002B7_A1CustomerId = new short[1] ;
         P002B8_A78CustomerTypeId = new short[1] ;
         P002B8_n78CustomerTypeId = new bool[] {false} ;
         P002B8_A4CustomerPostalAddress = new string[] {""} ;
         P002B8_n4CustomerPostalAddress = new bool[] {false} ;
         P002B8_A79CustomerTypeName = new string[] {""} ;
         P002B8_A6CustomerVisitingAddress = new string[] {""} ;
         P002B8_n6CustomerVisitingAddress = new bool[] {false} ;
         P002B8_A14CustomerVatNumber = new string[] {""} ;
         P002B8_A7CustomerPhone = new string[] {""} ;
         P002B8_n7CustomerPhone = new bool[] {false} ;
         P002B8_A5CustomerEmail = new string[] {""} ;
         P002B8_n5CustomerEmail = new bool[] {false} ;
         P002B8_A3CustomerName = new string[] {""} ;
         P002B8_A41CustomerKvkNumber = new string[] {""} ;
         P002B8_A1CustomerId = new short[1] ;
         P002B9_A78CustomerTypeId = new short[1] ;
         P002B9_n78CustomerTypeId = new bool[] {false} ;
         P002B9_A79CustomerTypeName = new string[] {""} ;
         P002B9_A4CustomerPostalAddress = new string[] {""} ;
         P002B9_n4CustomerPostalAddress = new bool[] {false} ;
         P002B9_A6CustomerVisitingAddress = new string[] {""} ;
         P002B9_n6CustomerVisitingAddress = new bool[] {false} ;
         P002B9_A14CustomerVatNumber = new string[] {""} ;
         P002B9_A7CustomerPhone = new string[] {""} ;
         P002B9_n7CustomerPhone = new bool[] {false} ;
         P002B9_A5CustomerEmail = new string[] {""} ;
         P002B9_n5CustomerEmail = new bool[] {false} ;
         P002B9_A3CustomerName = new string[] {""} ;
         P002B9_A41CustomerKvkNumber = new string[] {""} ;
         P002B9_A1CustomerId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customerwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002B2_A78CustomerTypeId, P002B2_n78CustomerTypeId, P002B2_A41CustomerKvkNumber, P002B2_A79CustomerTypeName, P002B2_A4CustomerPostalAddress, P002B2_n4CustomerPostalAddress, P002B2_A6CustomerVisitingAddress, P002B2_n6CustomerVisitingAddress, P002B2_A14CustomerVatNumber, P002B2_A7CustomerPhone,
               P002B2_n7CustomerPhone, P002B2_A5CustomerEmail, P002B2_n5CustomerEmail, P002B2_A3CustomerName, P002B2_A1CustomerId
               }
               , new Object[] {
               P002B3_A78CustomerTypeId, P002B3_n78CustomerTypeId, P002B3_A3CustomerName, P002B3_A79CustomerTypeName, P002B3_A4CustomerPostalAddress, P002B3_n4CustomerPostalAddress, P002B3_A6CustomerVisitingAddress, P002B3_n6CustomerVisitingAddress, P002B3_A14CustomerVatNumber, P002B3_A7CustomerPhone,
               P002B3_n7CustomerPhone, P002B3_A5CustomerEmail, P002B3_n5CustomerEmail, P002B3_A41CustomerKvkNumber, P002B3_A1CustomerId
               }
               , new Object[] {
               P002B4_A78CustomerTypeId, P002B4_n78CustomerTypeId, P002B4_A5CustomerEmail, P002B4_n5CustomerEmail, P002B4_A79CustomerTypeName, P002B4_A4CustomerPostalAddress, P002B4_n4CustomerPostalAddress, P002B4_A6CustomerVisitingAddress, P002B4_n6CustomerVisitingAddress, P002B4_A14CustomerVatNumber,
               P002B4_A7CustomerPhone, P002B4_n7CustomerPhone, P002B4_A3CustomerName, P002B4_A41CustomerKvkNumber, P002B4_A1CustomerId
               }
               , new Object[] {
               P002B5_A78CustomerTypeId, P002B5_n78CustomerTypeId, P002B5_A7CustomerPhone, P002B5_n7CustomerPhone, P002B5_A79CustomerTypeName, P002B5_A4CustomerPostalAddress, P002B5_n4CustomerPostalAddress, P002B5_A6CustomerVisitingAddress, P002B5_n6CustomerVisitingAddress, P002B5_A14CustomerVatNumber,
               P002B5_A5CustomerEmail, P002B5_n5CustomerEmail, P002B5_A3CustomerName, P002B5_A41CustomerKvkNumber, P002B5_A1CustomerId
               }
               , new Object[] {
               P002B6_A78CustomerTypeId, P002B6_n78CustomerTypeId, P002B6_A14CustomerVatNumber, P002B6_A79CustomerTypeName, P002B6_A4CustomerPostalAddress, P002B6_n4CustomerPostalAddress, P002B6_A6CustomerVisitingAddress, P002B6_n6CustomerVisitingAddress, P002B6_A7CustomerPhone, P002B6_n7CustomerPhone,
               P002B6_A5CustomerEmail, P002B6_n5CustomerEmail, P002B6_A3CustomerName, P002B6_A41CustomerKvkNumber, P002B6_A1CustomerId
               }
               , new Object[] {
               P002B7_A78CustomerTypeId, P002B7_n78CustomerTypeId, P002B7_A6CustomerVisitingAddress, P002B7_n6CustomerVisitingAddress, P002B7_A79CustomerTypeName, P002B7_A4CustomerPostalAddress, P002B7_n4CustomerPostalAddress, P002B7_A14CustomerVatNumber, P002B7_A7CustomerPhone, P002B7_n7CustomerPhone,
               P002B7_A5CustomerEmail, P002B7_n5CustomerEmail, P002B7_A3CustomerName, P002B7_A41CustomerKvkNumber, P002B7_A1CustomerId
               }
               , new Object[] {
               P002B8_A78CustomerTypeId, P002B8_n78CustomerTypeId, P002B8_A4CustomerPostalAddress, P002B8_n4CustomerPostalAddress, P002B8_A79CustomerTypeName, P002B8_A6CustomerVisitingAddress, P002B8_n6CustomerVisitingAddress, P002B8_A14CustomerVatNumber, P002B8_A7CustomerPhone, P002B8_n7CustomerPhone,
               P002B8_A5CustomerEmail, P002B8_n5CustomerEmail, P002B8_A3CustomerName, P002B8_A41CustomerKvkNumber, P002B8_A1CustomerId
               }
               , new Object[] {
               P002B9_A78CustomerTypeId, P002B9_n78CustomerTypeId, P002B9_A79CustomerTypeName, P002B9_A4CustomerPostalAddress, P002B9_n4CustomerPostalAddress, P002B9_A6CustomerVisitingAddress, P002B9_n6CustomerVisitingAddress, P002B9_A14CustomerVatNumber, P002B9_A7CustomerPhone, P002B9_n7CustomerPhone,
               P002B9_A5CustomerEmail, P002B9_n5CustomerEmail, P002B9_A3CustomerName, P002B9_A41CustomerKvkNumber, P002B9_A1CustomerId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private short A78CustomerTypeId ;
      private short A1CustomerId ;
      private int AV54GXV1 ;
      private int AV35InsertIndex ;
      private long AV41count ;
      private string AV23TFCustomerPhone ;
      private string AV24TFCustomerPhone_Sel ;
      private string AV63Customerwwds_8_tfcustomerphone ;
      private string AV64Customerwwds_9_tfcustomerphone_sel ;
      private string lV63Customerwwds_8_tfcustomerphone ;
      private string A7CustomerPhone ;
      private bool returnInSub ;
      private bool BRK2B2 ;
      private bool n78CustomerTypeId ;
      private bool n4CustomerPostalAddress ;
      private bool n6CustomerVisitingAddress ;
      private bool n7CustomerPhone ;
      private bool n5CustomerEmail ;
      private bool BRK2B4 ;
      private bool BRK2B6 ;
      private bool BRK2B8 ;
      private bool BRK2B10 ;
      private bool BRK2B12 ;
      private bool BRK2B14 ;
      private bool BRK2B16 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV13TFCustomerKvkNumber ;
      private string AV14TFCustomerKvkNumber_Sel ;
      private string AV15TFCustomerName ;
      private string AV16TFCustomerName_Sel ;
      private string AV19TFCustomerEmail ;
      private string AV20TFCustomerEmail_Sel ;
      private string AV25TFCustomerVatNumber ;
      private string AV26TFCustomerVatNumber_Sel ;
      private string AV21TFCustomerVisitingAddress ;
      private string AV22TFCustomerVisitingAddress_Sel ;
      private string AV17TFCustomerPostalAddress ;
      private string AV18TFCustomerPostalAddress_Sel ;
      private string AV29TFCustomerTypeName ;
      private string AV30TFCustomerTypeName_Sel ;
      private string AV56Customerwwds_1_filterfulltext ;
      private string AV57Customerwwds_2_tfcustomerkvknumber ;
      private string AV58Customerwwds_3_tfcustomerkvknumber_sel ;
      private string AV59Customerwwds_4_tfcustomername ;
      private string AV60Customerwwds_5_tfcustomername_sel ;
      private string AV61Customerwwds_6_tfcustomeremail ;
      private string AV62Customerwwds_7_tfcustomeremail_sel ;
      private string AV65Customerwwds_10_tfcustomervatnumber ;
      private string AV66Customerwwds_11_tfcustomervatnumber_sel ;
      private string AV67Customerwwds_12_tfcustomervisitingaddress ;
      private string AV68Customerwwds_13_tfcustomervisitingaddress_sel ;
      private string AV69Customerwwds_14_tfcustomerpostaladdress ;
      private string AV70Customerwwds_15_tfcustomerpostaladdress_sel ;
      private string AV71Customerwwds_16_tfcustomertypename ;
      private string AV72Customerwwds_17_tfcustomertypename_sel ;
      private string lV56Customerwwds_1_filterfulltext ;
      private string lV57Customerwwds_2_tfcustomerkvknumber ;
      private string lV59Customerwwds_4_tfcustomername ;
      private string lV61Customerwwds_6_tfcustomeremail ;
      private string lV65Customerwwds_10_tfcustomervatnumber ;
      private string lV67Customerwwds_12_tfcustomervisitingaddress ;
      private string lV69Customerwwds_14_tfcustomerpostaladdress ;
      private string lV71Customerwwds_16_tfcustomertypename ;
      private string A41CustomerKvkNumber ;
      private string A3CustomerName ;
      private string A5CustomerEmail ;
      private string A14CustomerVatNumber ;
      private string A6CustomerVisitingAddress ;
      private string A4CustomerPostalAddress ;
      private string A79CustomerTypeName ;
      private string AV36Option ;
      private IGxSession AV42Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV39OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV44GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P002B2_A78CustomerTypeId ;
      private bool[] P002B2_n78CustomerTypeId ;
      private string[] P002B2_A41CustomerKvkNumber ;
      private string[] P002B2_A79CustomerTypeName ;
      private string[] P002B2_A4CustomerPostalAddress ;
      private bool[] P002B2_n4CustomerPostalAddress ;
      private string[] P002B2_A6CustomerVisitingAddress ;
      private bool[] P002B2_n6CustomerVisitingAddress ;
      private string[] P002B2_A14CustomerVatNumber ;
      private string[] P002B2_A7CustomerPhone ;
      private bool[] P002B2_n7CustomerPhone ;
      private string[] P002B2_A5CustomerEmail ;
      private bool[] P002B2_n5CustomerEmail ;
      private string[] P002B2_A3CustomerName ;
      private short[] P002B2_A1CustomerId ;
      private short[] P002B3_A78CustomerTypeId ;
      private bool[] P002B3_n78CustomerTypeId ;
      private string[] P002B3_A3CustomerName ;
      private string[] P002B3_A79CustomerTypeName ;
      private string[] P002B3_A4CustomerPostalAddress ;
      private bool[] P002B3_n4CustomerPostalAddress ;
      private string[] P002B3_A6CustomerVisitingAddress ;
      private bool[] P002B3_n6CustomerVisitingAddress ;
      private string[] P002B3_A14CustomerVatNumber ;
      private string[] P002B3_A7CustomerPhone ;
      private bool[] P002B3_n7CustomerPhone ;
      private string[] P002B3_A5CustomerEmail ;
      private bool[] P002B3_n5CustomerEmail ;
      private string[] P002B3_A41CustomerKvkNumber ;
      private short[] P002B3_A1CustomerId ;
      private short[] P002B4_A78CustomerTypeId ;
      private bool[] P002B4_n78CustomerTypeId ;
      private string[] P002B4_A5CustomerEmail ;
      private bool[] P002B4_n5CustomerEmail ;
      private string[] P002B4_A79CustomerTypeName ;
      private string[] P002B4_A4CustomerPostalAddress ;
      private bool[] P002B4_n4CustomerPostalAddress ;
      private string[] P002B4_A6CustomerVisitingAddress ;
      private bool[] P002B4_n6CustomerVisitingAddress ;
      private string[] P002B4_A14CustomerVatNumber ;
      private string[] P002B4_A7CustomerPhone ;
      private bool[] P002B4_n7CustomerPhone ;
      private string[] P002B4_A3CustomerName ;
      private string[] P002B4_A41CustomerKvkNumber ;
      private short[] P002B4_A1CustomerId ;
      private short[] P002B5_A78CustomerTypeId ;
      private bool[] P002B5_n78CustomerTypeId ;
      private string[] P002B5_A7CustomerPhone ;
      private bool[] P002B5_n7CustomerPhone ;
      private string[] P002B5_A79CustomerTypeName ;
      private string[] P002B5_A4CustomerPostalAddress ;
      private bool[] P002B5_n4CustomerPostalAddress ;
      private string[] P002B5_A6CustomerVisitingAddress ;
      private bool[] P002B5_n6CustomerVisitingAddress ;
      private string[] P002B5_A14CustomerVatNumber ;
      private string[] P002B5_A5CustomerEmail ;
      private bool[] P002B5_n5CustomerEmail ;
      private string[] P002B5_A3CustomerName ;
      private string[] P002B5_A41CustomerKvkNumber ;
      private short[] P002B5_A1CustomerId ;
      private short[] P002B6_A78CustomerTypeId ;
      private bool[] P002B6_n78CustomerTypeId ;
      private string[] P002B6_A14CustomerVatNumber ;
      private string[] P002B6_A79CustomerTypeName ;
      private string[] P002B6_A4CustomerPostalAddress ;
      private bool[] P002B6_n4CustomerPostalAddress ;
      private string[] P002B6_A6CustomerVisitingAddress ;
      private bool[] P002B6_n6CustomerVisitingAddress ;
      private string[] P002B6_A7CustomerPhone ;
      private bool[] P002B6_n7CustomerPhone ;
      private string[] P002B6_A5CustomerEmail ;
      private bool[] P002B6_n5CustomerEmail ;
      private string[] P002B6_A3CustomerName ;
      private string[] P002B6_A41CustomerKvkNumber ;
      private short[] P002B6_A1CustomerId ;
      private short[] P002B7_A78CustomerTypeId ;
      private bool[] P002B7_n78CustomerTypeId ;
      private string[] P002B7_A6CustomerVisitingAddress ;
      private bool[] P002B7_n6CustomerVisitingAddress ;
      private string[] P002B7_A79CustomerTypeName ;
      private string[] P002B7_A4CustomerPostalAddress ;
      private bool[] P002B7_n4CustomerPostalAddress ;
      private string[] P002B7_A14CustomerVatNumber ;
      private string[] P002B7_A7CustomerPhone ;
      private bool[] P002B7_n7CustomerPhone ;
      private string[] P002B7_A5CustomerEmail ;
      private bool[] P002B7_n5CustomerEmail ;
      private string[] P002B7_A3CustomerName ;
      private string[] P002B7_A41CustomerKvkNumber ;
      private short[] P002B7_A1CustomerId ;
      private short[] P002B8_A78CustomerTypeId ;
      private bool[] P002B8_n78CustomerTypeId ;
      private string[] P002B8_A4CustomerPostalAddress ;
      private bool[] P002B8_n4CustomerPostalAddress ;
      private string[] P002B8_A79CustomerTypeName ;
      private string[] P002B8_A6CustomerVisitingAddress ;
      private bool[] P002B8_n6CustomerVisitingAddress ;
      private string[] P002B8_A14CustomerVatNumber ;
      private string[] P002B8_A7CustomerPhone ;
      private bool[] P002B8_n7CustomerPhone ;
      private string[] P002B8_A5CustomerEmail ;
      private bool[] P002B8_n5CustomerEmail ;
      private string[] P002B8_A3CustomerName ;
      private string[] P002B8_A41CustomerKvkNumber ;
      private short[] P002B8_A1CustomerId ;
      private short[] P002B9_A78CustomerTypeId ;
      private bool[] P002B9_n78CustomerTypeId ;
      private string[] P002B9_A79CustomerTypeName ;
      private string[] P002B9_A4CustomerPostalAddress ;
      private bool[] P002B9_n4CustomerPostalAddress ;
      private string[] P002B9_A6CustomerVisitingAddress ;
      private bool[] P002B9_n6CustomerVisitingAddress ;
      private string[] P002B9_A14CustomerVatNumber ;
      private string[] P002B9_A7CustomerPhone ;
      private bool[] P002B9_n7CustomerPhone ;
      private string[] P002B9_A5CustomerEmail ;
      private bool[] P002B9_n5CustomerEmail ;
      private string[] P002B9_A3CustomerName ;
      private string[] P002B9_A41CustomerKvkNumber ;
      private short[] P002B9_A1CustomerId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class customerwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002B2( IGxContext context ,
                                             string AV56Customerwwds_1_filterfulltext ,
                                             string AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV57Customerwwds_2_tfcustomerkvknumber ,
                                             string AV60Customerwwds_5_tfcustomername_sel ,
                                             string AV59Customerwwds_4_tfcustomername ,
                                             string AV62Customerwwds_7_tfcustomeremail_sel ,
                                             string AV61Customerwwds_6_tfcustomeremail ,
                                             string AV64Customerwwds_9_tfcustomerphone_sel ,
                                             string AV63Customerwwds_8_tfcustomerphone ,
                                             string AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV65Customerwwds_10_tfcustomervatnumber ,
                                             string AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV67Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV69Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV72Customerwwds_17_tfcustomertypename_sel ,
                                             string AV71Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[24];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.CustomerTypeId, T1.CustomerKvkNumber, T2.CustomerTypeName, T1.CustomerPostalAddress, T1.CustomerVisitingAddress, T1.CustomerVatNumber, T1.CustomerPhone, T1.CustomerEmail, T1.CustomerName, T1.CustomerId FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV56Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV57Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV58Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV59Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV60Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV61Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV62Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV63Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV64Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV65Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV66Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV67Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV68Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV69Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV70Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV71Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV72Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerKvkNumber";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002B3( IGxContext context ,
                                             string AV56Customerwwds_1_filterfulltext ,
                                             string AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV57Customerwwds_2_tfcustomerkvknumber ,
                                             string AV60Customerwwds_5_tfcustomername_sel ,
                                             string AV59Customerwwds_4_tfcustomername ,
                                             string AV62Customerwwds_7_tfcustomeremail_sel ,
                                             string AV61Customerwwds_6_tfcustomeremail ,
                                             string AV64Customerwwds_9_tfcustomerphone_sel ,
                                             string AV63Customerwwds_8_tfcustomerphone ,
                                             string AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV65Customerwwds_10_tfcustomervatnumber ,
                                             string AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV67Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV69Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV72Customerwwds_17_tfcustomertypename_sel ,
                                             string AV71Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[24];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CustomerTypeId, T1.CustomerName, T2.CustomerTypeName, T1.CustomerPostalAddress, T1.CustomerVisitingAddress, T1.CustomerVatNumber, T1.CustomerPhone, T1.CustomerEmail, T1.CustomerKvkNumber, T1.CustomerId FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV56Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV57Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV58Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV59Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV60Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV61Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV62Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV63Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV64Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV65Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV66Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV67Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV68Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV69Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV70Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV71Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV72Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002B4( IGxContext context ,
                                             string AV56Customerwwds_1_filterfulltext ,
                                             string AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV57Customerwwds_2_tfcustomerkvknumber ,
                                             string AV60Customerwwds_5_tfcustomername_sel ,
                                             string AV59Customerwwds_4_tfcustomername ,
                                             string AV62Customerwwds_7_tfcustomeremail_sel ,
                                             string AV61Customerwwds_6_tfcustomeremail ,
                                             string AV64Customerwwds_9_tfcustomerphone_sel ,
                                             string AV63Customerwwds_8_tfcustomerphone ,
                                             string AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV65Customerwwds_10_tfcustomervatnumber ,
                                             string AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV67Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV69Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV72Customerwwds_17_tfcustomertypename_sel ,
                                             string AV71Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[24];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.CustomerTypeId, T1.CustomerEmail, T2.CustomerTypeName, T1.CustomerPostalAddress, T1.CustomerVisitingAddress, T1.CustomerVatNumber, T1.CustomerPhone, T1.CustomerName, T1.CustomerKvkNumber, T1.CustomerId FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV56Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV57Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV58Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV59Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV60Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV61Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV62Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV63Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV64Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV65Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV66Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV67Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV68Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV69Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV70Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV71Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV72Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerEmail";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002B5( IGxContext context ,
                                             string AV56Customerwwds_1_filterfulltext ,
                                             string AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV57Customerwwds_2_tfcustomerkvknumber ,
                                             string AV60Customerwwds_5_tfcustomername_sel ,
                                             string AV59Customerwwds_4_tfcustomername ,
                                             string AV62Customerwwds_7_tfcustomeremail_sel ,
                                             string AV61Customerwwds_6_tfcustomeremail ,
                                             string AV64Customerwwds_9_tfcustomerphone_sel ,
                                             string AV63Customerwwds_8_tfcustomerphone ,
                                             string AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV65Customerwwds_10_tfcustomervatnumber ,
                                             string AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV67Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV69Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV72Customerwwds_17_tfcustomertypename_sel ,
                                             string AV71Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[24];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.CustomerTypeId, T1.CustomerPhone, T2.CustomerTypeName, T1.CustomerPostalAddress, T1.CustomerVisitingAddress, T1.CustomerVatNumber, T1.CustomerEmail, T1.CustomerName, T1.CustomerKvkNumber, T1.CustomerId FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV56Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV57Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV58Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV59Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV60Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV61Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV62Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV63Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV64Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV65Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV66Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV67Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV68Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV69Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV70Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV71Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV72Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerPhone";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P002B6( IGxContext context ,
                                             string AV56Customerwwds_1_filterfulltext ,
                                             string AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV57Customerwwds_2_tfcustomerkvknumber ,
                                             string AV60Customerwwds_5_tfcustomername_sel ,
                                             string AV59Customerwwds_4_tfcustomername ,
                                             string AV62Customerwwds_7_tfcustomeremail_sel ,
                                             string AV61Customerwwds_6_tfcustomeremail ,
                                             string AV64Customerwwds_9_tfcustomerphone_sel ,
                                             string AV63Customerwwds_8_tfcustomerphone ,
                                             string AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV65Customerwwds_10_tfcustomervatnumber ,
                                             string AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV67Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV69Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV72Customerwwds_17_tfcustomertypename_sel ,
                                             string AV71Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[24];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.CustomerTypeId, T1.CustomerVatNumber, T2.CustomerTypeName, T1.CustomerPostalAddress, T1.CustomerVisitingAddress, T1.CustomerPhone, T1.CustomerEmail, T1.CustomerName, T1.CustomerKvkNumber, T1.CustomerId FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV56Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV57Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV58Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV59Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV60Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV61Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV62Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV63Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV64Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV65Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV66Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV67Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV68Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV69Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV70Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV71Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV72Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerVatNumber";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P002B7( IGxContext context ,
                                             string AV56Customerwwds_1_filterfulltext ,
                                             string AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV57Customerwwds_2_tfcustomerkvknumber ,
                                             string AV60Customerwwds_5_tfcustomername_sel ,
                                             string AV59Customerwwds_4_tfcustomername ,
                                             string AV62Customerwwds_7_tfcustomeremail_sel ,
                                             string AV61Customerwwds_6_tfcustomeremail ,
                                             string AV64Customerwwds_9_tfcustomerphone_sel ,
                                             string AV63Customerwwds_8_tfcustomerphone ,
                                             string AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV65Customerwwds_10_tfcustomervatnumber ,
                                             string AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV67Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV69Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV72Customerwwds_17_tfcustomertypename_sel ,
                                             string AV71Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[24];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.CustomerTypeId, T1.CustomerVisitingAddress, T2.CustomerTypeName, T1.CustomerPostalAddress, T1.CustomerVatNumber, T1.CustomerPhone, T1.CustomerEmail, T1.CustomerName, T1.CustomerKvkNumber, T1.CustomerId FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV56Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV57Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV58Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV59Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV60Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV61Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV62Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV63Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV64Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV65Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV66Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV67Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV68Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV69Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV70Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV71Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV72Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerVisitingAddress";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P002B8( IGxContext context ,
                                             string AV56Customerwwds_1_filterfulltext ,
                                             string AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV57Customerwwds_2_tfcustomerkvknumber ,
                                             string AV60Customerwwds_5_tfcustomername_sel ,
                                             string AV59Customerwwds_4_tfcustomername ,
                                             string AV62Customerwwds_7_tfcustomeremail_sel ,
                                             string AV61Customerwwds_6_tfcustomeremail ,
                                             string AV64Customerwwds_9_tfcustomerphone_sel ,
                                             string AV63Customerwwds_8_tfcustomerphone ,
                                             string AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV65Customerwwds_10_tfcustomervatnumber ,
                                             string AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV67Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV69Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV72Customerwwds_17_tfcustomertypename_sel ,
                                             string AV71Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[24];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.CustomerTypeId, T1.CustomerPostalAddress, T2.CustomerTypeName, T1.CustomerVisitingAddress, T1.CustomerVatNumber, T1.CustomerPhone, T1.CustomerEmail, T1.CustomerName, T1.CustomerKvkNumber, T1.CustomerId FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV56Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int13[0] = 1;
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV57Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV58Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV59Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV60Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV61Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV62Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV63Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV64Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV65Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV66Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV67Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV68Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV69Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV70Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV71Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV72Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerPostalAddress";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_P002B9( IGxContext context ,
                                             string AV56Customerwwds_1_filterfulltext ,
                                             string AV58Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV57Customerwwds_2_tfcustomerkvknumber ,
                                             string AV60Customerwwds_5_tfcustomername_sel ,
                                             string AV59Customerwwds_4_tfcustomername ,
                                             string AV62Customerwwds_7_tfcustomeremail_sel ,
                                             string AV61Customerwwds_6_tfcustomeremail ,
                                             string AV64Customerwwds_9_tfcustomerphone_sel ,
                                             string AV63Customerwwds_8_tfcustomerphone ,
                                             string AV66Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV65Customerwwds_10_tfcustomervatnumber ,
                                             string AV68Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV67Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV70Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV69Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV72Customerwwds_17_tfcustomertypename_sel ,
                                             string AV71Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[24];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT T1.CustomerTypeId, T2.CustomerTypeName, T1.CustomerPostalAddress, T1.CustomerVisitingAddress, T1.CustomerVatNumber, T1.CustomerPhone, T1.CustomerEmail, T1.CustomerName, T1.CustomerKvkNumber, T1.CustomerId FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV56Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV56Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int15[0] = 1;
            GXv_int15[1] = 1;
            GXv_int15[2] = 1;
            GXv_int15[3] = 1;
            GXv_int15[4] = 1;
            GXv_int15[5] = 1;
            GXv_int15[6] = 1;
            GXv_int15[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV57Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int15[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV58Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int15[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV59Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int15[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV60Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int15[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV61Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int15[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV62Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int15[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV63Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int15[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV64Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int15[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV65Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int15[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV66Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int15[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV67Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int15[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV68Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int15[19] = 1;
         }
         if ( StringUtil.StrCmp(AV68Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV69Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int15[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV70Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int15[21] = 1;
         }
         if ( StringUtil.StrCmp(AV70Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV71Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int15[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV72Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int15[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerTypeId";
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002B2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 1 :
                     return conditional_P002B3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 2 :
                     return conditional_P002B4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 3 :
                     return conditional_P002B5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 4 :
                     return conditional_P002B6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 5 :
                     return conditional_P002B7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 6 :
                     return conditional_P002B8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 7 :
                     return conditional_P002B9(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002B2;
          prmP002B2 = new Object[] {
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV58Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV59Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV62Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV64Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV65Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV66Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV67Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV68Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV69Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV70Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV71Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV72Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002B3;
          prmP002B3 = new Object[] {
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV58Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV59Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV62Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV64Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV65Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV66Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV67Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV68Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV69Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV70Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV71Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV72Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002B4;
          prmP002B4 = new Object[] {
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV58Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV59Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV62Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV64Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV65Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV66Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV67Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV68Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV69Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV70Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV71Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV72Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002B5;
          prmP002B5 = new Object[] {
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV58Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV59Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV62Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV64Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV65Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV66Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV67Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV68Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV69Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV70Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV71Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV72Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002B6;
          prmP002B6 = new Object[] {
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV58Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV59Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV62Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV64Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV65Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV66Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV67Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV68Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV69Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV70Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV71Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV72Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002B7;
          prmP002B7 = new Object[] {
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV58Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV59Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV62Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV64Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV65Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV66Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV67Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV68Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV69Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV70Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV71Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV72Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002B8;
          prmP002B8 = new Object[] {
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV58Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV59Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV62Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV64Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV65Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV66Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV67Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV68Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV69Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV70Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV71Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV72Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002B9;
          prmP002B9 = new Object[] {
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV58Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV59Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV60Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV61Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV62Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV64Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV65Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV66Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV67Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV68Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV69Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV70Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV71Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV72Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002B3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002B4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002B5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002B5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002B6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002B6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002B7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002B7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002B8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002B8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002B9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002B9,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 20);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                return;
       }
    }

 }

}
