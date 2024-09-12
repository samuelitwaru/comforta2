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
   public class residentwwgetfilterdata : GXProcedure
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
            return "residentww_Services_Execute" ;
         }

      }

      public residentwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public residentwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTBSNNUMBER") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTBSNNUMBEROPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTGIVENNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTGIVENNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTLASTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTLASTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTEMAILOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTADDRESSOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTPHONEOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CUSTOMERLOCATIONNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCUSTOMERLOCATIONNAMEOPTIONS' */
            S181 ();
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
         if ( StringUtil.StrCmp(AV42Session.Get("ResidentWWGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ResidentWWGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("ResidentWWGridState"), null, "", "");
         }
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV64GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTID") == 0 )
            {
               AV11TFResidentId = (short)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFResidentId_To = (short)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER") == 0 )
            {
               AV13TFResidentBsnNumber = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER_SEL") == 0 )
            {
               AV14TFResidentBsnNumber_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME") == 0 )
            {
               AV15TFResidentGivenName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME_SEL") == 0 )
            {
               AV16TFResidentGivenName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME") == 0 )
            {
               AV17TFResidentLastName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME_SEL") == 0 )
            {
               AV18TFResidentLastName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL") == 0 )
            {
               AV21TFResidentEmail = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL_SEL") == 0 )
            {
               AV22TFResidentEmail_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTADDRESS") == 0 )
            {
               AV23TFResidentAddress = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTADDRESS_SEL") == 0 )
            {
               AV24TFResidentAddress_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE") == 0 )
            {
               AV25TFResidentPhone = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE_SEL") == 0 )
            {
               AV26TFResidentPhone_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERLOCATIONNAME") == 0 )
            {
               AV62TFCustomerLocationName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCUSTOMERLOCATIONNAME_SEL") == 0 )
            {
               AV63TFCustomerLocationName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            AV64GXV1 = (int)(AV64GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRESIDENTBSNNUMBEROPTIONS' Routine */
         returnInSub = false;
         AV13TFResidentBsnNumber = AV31SearchTxt;
         AV14TFResidentBsnNumber_Sel = "";
         AV66Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV67Residentwwds_2_tfresidentid = AV11TFResidentId;
         AV68Residentwwds_3_tfresidentid_to = AV12TFResidentId_To;
         AV69Residentwwds_4_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV70Residentwwds_5_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV71Residentwwds_6_tfresidentgivenname = AV15TFResidentGivenName;
         AV72Residentwwds_7_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV73Residentwwds_8_tfresidentlastname = AV17TFResidentLastName;
         AV74Residentwwds_9_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV75Residentwwds_10_tfresidentemail = AV21TFResidentEmail;
         AV76Residentwwds_11_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV77Residentwwds_12_tfresidentaddress = AV23TFResidentAddress;
         AV78Residentwwds_13_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV79Residentwwds_14_tfresidentphone = AV25TFResidentPhone;
         AV80Residentwwds_15_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV81Residentwwds_16_tfcustomerlocationname = AV62TFCustomerLocationName;
         AV82Residentwwds_17_tfcustomerlocationname_sel = AV63TFCustomerLocationName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV66Residentwwds_1_filterfulltext ,
                                              AV67Residentwwds_2_tfresidentid ,
                                              AV68Residentwwds_3_tfresidentid_to ,
                                              AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                              AV69Residentwwds_4_tfresidentbsnnumber ,
                                              AV72Residentwwds_7_tfresidentgivenname_sel ,
                                              AV71Residentwwds_6_tfresidentgivenname ,
                                              AV74Residentwwds_9_tfresidentlastname_sel ,
                                              AV73Residentwwds_8_tfresidentlastname ,
                                              AV76Residentwwds_11_tfresidentemail_sel ,
                                              AV75Residentwwds_10_tfresidentemail ,
                                              AV78Residentwwds_13_tfresidentaddress_sel ,
                                              AV77Residentwwds_12_tfresidentaddress ,
                                              AV80Residentwwds_15_tfresidentphone_sel ,
                                              AV79Residentwwds_14_tfresidentphone ,
                                              AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                              AV81Residentwwds_16_tfcustomerlocationname ,
                                              A31ResidentId ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A134CustomerLocationName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV69Residentwwds_4_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber), "%", "");
         lV71Residentwwds_6_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname), "%", "");
         lV73Residentwwds_8_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname), "%", "");
         lV75Residentwwds_10_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail), "%", "");
         lV77Residentwwds_12_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress), "%", "");
         lV79Residentwwds_14_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone), 20, "%");
         lV81Residentwwds_16_tfcustomerlocationname = StringUtil.Concat( StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname), "%", "");
         /* Using cursor P002D2 */
         pr_default.execute(0, new Object[] {lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, AV67Residentwwds_2_tfresidentid, AV68Residentwwds_3_tfresidentid_to, lV69Residentwwds_4_tfresidentbsnnumber, AV70Residentwwds_5_tfresidentbsnnumber_sel, lV71Residentwwds_6_tfresidentgivenname, AV72Residentwwds_7_tfresidentgivenname_sel, lV73Residentwwds_8_tfresidentlastname, AV74Residentwwds_9_tfresidentlastname_sel, lV75Residentwwds_10_tfresidentemail, AV76Residentwwds_11_tfresidentemail_sel, lV77Residentwwds_12_tfresidentaddress, AV78Residentwwds_13_tfresidentaddress_sel, lV79Residentwwds_14_tfresidentphone, AV80Residentwwds_15_tfresidentphone_sel, lV81Residentwwds_16_tfcustomerlocationname, AV82Residentwwds_17_tfcustomerlocationname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2D2 = false;
            A1CustomerId = P002D2_A1CustomerId[0];
            A18CustomerLocationId = P002D2_A18CustomerLocationId[0];
            A40ResidentBsnNumber = P002D2_A40ResidentBsnNumber[0];
            A31ResidentId = P002D2_A31ResidentId[0];
            A134CustomerLocationName = P002D2_A134CustomerLocationName[0];
            A38ResidentPhone = P002D2_A38ResidentPhone[0];
            n38ResidentPhone = P002D2_n38ResidentPhone[0];
            A37ResidentAddress = P002D2_A37ResidentAddress[0];
            n37ResidentAddress = P002D2_n37ResidentAddress[0];
            A36ResidentEmail = P002D2_A36ResidentEmail[0];
            A34ResidentLastName = P002D2_A34ResidentLastName[0];
            A33ResidentGivenName = P002D2_A33ResidentGivenName[0];
            A134CustomerLocationName = P002D2_A134CustomerLocationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002D2_A40ResidentBsnNumber[0], A40ResidentBsnNumber) == 0 ) )
            {
               BRK2D2 = false;
               A31ResidentId = P002D2_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A40ResidentBsnNumber)) ? "<#Empty#>" : A40ResidentBsnNumber);
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
            if ( ! BRK2D2 )
            {
               BRK2D2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRESIDENTGIVENNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFResidentGivenName = AV31SearchTxt;
         AV16TFResidentGivenName_Sel = "";
         AV66Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV67Residentwwds_2_tfresidentid = AV11TFResidentId;
         AV68Residentwwds_3_tfresidentid_to = AV12TFResidentId_To;
         AV69Residentwwds_4_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV70Residentwwds_5_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV71Residentwwds_6_tfresidentgivenname = AV15TFResidentGivenName;
         AV72Residentwwds_7_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV73Residentwwds_8_tfresidentlastname = AV17TFResidentLastName;
         AV74Residentwwds_9_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV75Residentwwds_10_tfresidentemail = AV21TFResidentEmail;
         AV76Residentwwds_11_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV77Residentwwds_12_tfresidentaddress = AV23TFResidentAddress;
         AV78Residentwwds_13_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV79Residentwwds_14_tfresidentphone = AV25TFResidentPhone;
         AV80Residentwwds_15_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV81Residentwwds_16_tfcustomerlocationname = AV62TFCustomerLocationName;
         AV82Residentwwds_17_tfcustomerlocationname_sel = AV63TFCustomerLocationName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV66Residentwwds_1_filterfulltext ,
                                              AV67Residentwwds_2_tfresidentid ,
                                              AV68Residentwwds_3_tfresidentid_to ,
                                              AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                              AV69Residentwwds_4_tfresidentbsnnumber ,
                                              AV72Residentwwds_7_tfresidentgivenname_sel ,
                                              AV71Residentwwds_6_tfresidentgivenname ,
                                              AV74Residentwwds_9_tfresidentlastname_sel ,
                                              AV73Residentwwds_8_tfresidentlastname ,
                                              AV76Residentwwds_11_tfresidentemail_sel ,
                                              AV75Residentwwds_10_tfresidentemail ,
                                              AV78Residentwwds_13_tfresidentaddress_sel ,
                                              AV77Residentwwds_12_tfresidentaddress ,
                                              AV80Residentwwds_15_tfresidentphone_sel ,
                                              AV79Residentwwds_14_tfresidentphone ,
                                              AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                              AV81Residentwwds_16_tfcustomerlocationname ,
                                              A31ResidentId ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A134CustomerLocationName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV69Residentwwds_4_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber), "%", "");
         lV71Residentwwds_6_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname), "%", "");
         lV73Residentwwds_8_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname), "%", "");
         lV75Residentwwds_10_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail), "%", "");
         lV77Residentwwds_12_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress), "%", "");
         lV79Residentwwds_14_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone), 20, "%");
         lV81Residentwwds_16_tfcustomerlocationname = StringUtil.Concat( StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname), "%", "");
         /* Using cursor P002D3 */
         pr_default.execute(1, new Object[] {lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, AV67Residentwwds_2_tfresidentid, AV68Residentwwds_3_tfresidentid_to, lV69Residentwwds_4_tfresidentbsnnumber, AV70Residentwwds_5_tfresidentbsnnumber_sel, lV71Residentwwds_6_tfresidentgivenname, AV72Residentwwds_7_tfresidentgivenname_sel, lV73Residentwwds_8_tfresidentlastname, AV74Residentwwds_9_tfresidentlastname_sel, lV75Residentwwds_10_tfresidentemail, AV76Residentwwds_11_tfresidentemail_sel, lV77Residentwwds_12_tfresidentaddress, AV78Residentwwds_13_tfresidentaddress_sel, lV79Residentwwds_14_tfresidentphone, AV80Residentwwds_15_tfresidentphone_sel, lV81Residentwwds_16_tfcustomerlocationname, AV82Residentwwds_17_tfcustomerlocationname_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2D4 = false;
            A1CustomerId = P002D3_A1CustomerId[0];
            A18CustomerLocationId = P002D3_A18CustomerLocationId[0];
            A33ResidentGivenName = P002D3_A33ResidentGivenName[0];
            A31ResidentId = P002D3_A31ResidentId[0];
            A134CustomerLocationName = P002D3_A134CustomerLocationName[0];
            A38ResidentPhone = P002D3_A38ResidentPhone[0];
            n38ResidentPhone = P002D3_n38ResidentPhone[0];
            A37ResidentAddress = P002D3_A37ResidentAddress[0];
            n37ResidentAddress = P002D3_n37ResidentAddress[0];
            A36ResidentEmail = P002D3_A36ResidentEmail[0];
            A34ResidentLastName = P002D3_A34ResidentLastName[0];
            A40ResidentBsnNumber = P002D3_A40ResidentBsnNumber[0];
            A134CustomerLocationName = P002D3_A134CustomerLocationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002D3_A33ResidentGivenName[0], A33ResidentGivenName) == 0 ) )
            {
               BRK2D4 = false;
               A31ResidentId = P002D3_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A33ResidentGivenName)) ? "<#Empty#>" : A33ResidentGivenName);
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
            if ( ! BRK2D4 )
            {
               BRK2D4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRESIDENTLASTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFResidentLastName = AV31SearchTxt;
         AV18TFResidentLastName_Sel = "";
         AV66Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV67Residentwwds_2_tfresidentid = AV11TFResidentId;
         AV68Residentwwds_3_tfresidentid_to = AV12TFResidentId_To;
         AV69Residentwwds_4_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV70Residentwwds_5_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV71Residentwwds_6_tfresidentgivenname = AV15TFResidentGivenName;
         AV72Residentwwds_7_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV73Residentwwds_8_tfresidentlastname = AV17TFResidentLastName;
         AV74Residentwwds_9_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV75Residentwwds_10_tfresidentemail = AV21TFResidentEmail;
         AV76Residentwwds_11_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV77Residentwwds_12_tfresidentaddress = AV23TFResidentAddress;
         AV78Residentwwds_13_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV79Residentwwds_14_tfresidentphone = AV25TFResidentPhone;
         AV80Residentwwds_15_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV81Residentwwds_16_tfcustomerlocationname = AV62TFCustomerLocationName;
         AV82Residentwwds_17_tfcustomerlocationname_sel = AV63TFCustomerLocationName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV66Residentwwds_1_filterfulltext ,
                                              AV67Residentwwds_2_tfresidentid ,
                                              AV68Residentwwds_3_tfresidentid_to ,
                                              AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                              AV69Residentwwds_4_tfresidentbsnnumber ,
                                              AV72Residentwwds_7_tfresidentgivenname_sel ,
                                              AV71Residentwwds_6_tfresidentgivenname ,
                                              AV74Residentwwds_9_tfresidentlastname_sel ,
                                              AV73Residentwwds_8_tfresidentlastname ,
                                              AV76Residentwwds_11_tfresidentemail_sel ,
                                              AV75Residentwwds_10_tfresidentemail ,
                                              AV78Residentwwds_13_tfresidentaddress_sel ,
                                              AV77Residentwwds_12_tfresidentaddress ,
                                              AV80Residentwwds_15_tfresidentphone_sel ,
                                              AV79Residentwwds_14_tfresidentphone ,
                                              AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                              AV81Residentwwds_16_tfcustomerlocationname ,
                                              A31ResidentId ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A134CustomerLocationName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV69Residentwwds_4_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber), "%", "");
         lV71Residentwwds_6_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname), "%", "");
         lV73Residentwwds_8_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname), "%", "");
         lV75Residentwwds_10_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail), "%", "");
         lV77Residentwwds_12_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress), "%", "");
         lV79Residentwwds_14_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone), 20, "%");
         lV81Residentwwds_16_tfcustomerlocationname = StringUtil.Concat( StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname), "%", "");
         /* Using cursor P002D4 */
         pr_default.execute(2, new Object[] {lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, AV67Residentwwds_2_tfresidentid, AV68Residentwwds_3_tfresidentid_to, lV69Residentwwds_4_tfresidentbsnnumber, AV70Residentwwds_5_tfresidentbsnnumber_sel, lV71Residentwwds_6_tfresidentgivenname, AV72Residentwwds_7_tfresidentgivenname_sel, lV73Residentwwds_8_tfresidentlastname, AV74Residentwwds_9_tfresidentlastname_sel, lV75Residentwwds_10_tfresidentemail, AV76Residentwwds_11_tfresidentemail_sel, lV77Residentwwds_12_tfresidentaddress, AV78Residentwwds_13_tfresidentaddress_sel, lV79Residentwwds_14_tfresidentphone, AV80Residentwwds_15_tfresidentphone_sel, lV81Residentwwds_16_tfcustomerlocationname, AV82Residentwwds_17_tfcustomerlocationname_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2D6 = false;
            A1CustomerId = P002D4_A1CustomerId[0];
            A18CustomerLocationId = P002D4_A18CustomerLocationId[0];
            A34ResidentLastName = P002D4_A34ResidentLastName[0];
            A31ResidentId = P002D4_A31ResidentId[0];
            A134CustomerLocationName = P002D4_A134CustomerLocationName[0];
            A38ResidentPhone = P002D4_A38ResidentPhone[0];
            n38ResidentPhone = P002D4_n38ResidentPhone[0];
            A37ResidentAddress = P002D4_A37ResidentAddress[0];
            n37ResidentAddress = P002D4_n37ResidentAddress[0];
            A36ResidentEmail = P002D4_A36ResidentEmail[0];
            A33ResidentGivenName = P002D4_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D4_A40ResidentBsnNumber[0];
            A134CustomerLocationName = P002D4_A134CustomerLocationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002D4_A34ResidentLastName[0], A34ResidentLastName) == 0 ) )
            {
               BRK2D6 = false;
               A31ResidentId = P002D4_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A34ResidentLastName)) ? "<#Empty#>" : A34ResidentLastName);
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
            if ( ! BRK2D6 )
            {
               BRK2D6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADRESIDENTEMAILOPTIONS' Routine */
         returnInSub = false;
         AV21TFResidentEmail = AV31SearchTxt;
         AV22TFResidentEmail_Sel = "";
         AV66Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV67Residentwwds_2_tfresidentid = AV11TFResidentId;
         AV68Residentwwds_3_tfresidentid_to = AV12TFResidentId_To;
         AV69Residentwwds_4_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV70Residentwwds_5_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV71Residentwwds_6_tfresidentgivenname = AV15TFResidentGivenName;
         AV72Residentwwds_7_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV73Residentwwds_8_tfresidentlastname = AV17TFResidentLastName;
         AV74Residentwwds_9_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV75Residentwwds_10_tfresidentemail = AV21TFResidentEmail;
         AV76Residentwwds_11_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV77Residentwwds_12_tfresidentaddress = AV23TFResidentAddress;
         AV78Residentwwds_13_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV79Residentwwds_14_tfresidentphone = AV25TFResidentPhone;
         AV80Residentwwds_15_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV81Residentwwds_16_tfcustomerlocationname = AV62TFCustomerLocationName;
         AV82Residentwwds_17_tfcustomerlocationname_sel = AV63TFCustomerLocationName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV66Residentwwds_1_filterfulltext ,
                                              AV67Residentwwds_2_tfresidentid ,
                                              AV68Residentwwds_3_tfresidentid_to ,
                                              AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                              AV69Residentwwds_4_tfresidentbsnnumber ,
                                              AV72Residentwwds_7_tfresidentgivenname_sel ,
                                              AV71Residentwwds_6_tfresidentgivenname ,
                                              AV74Residentwwds_9_tfresidentlastname_sel ,
                                              AV73Residentwwds_8_tfresidentlastname ,
                                              AV76Residentwwds_11_tfresidentemail_sel ,
                                              AV75Residentwwds_10_tfresidentemail ,
                                              AV78Residentwwds_13_tfresidentaddress_sel ,
                                              AV77Residentwwds_12_tfresidentaddress ,
                                              AV80Residentwwds_15_tfresidentphone_sel ,
                                              AV79Residentwwds_14_tfresidentphone ,
                                              AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                              AV81Residentwwds_16_tfcustomerlocationname ,
                                              A31ResidentId ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A134CustomerLocationName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV69Residentwwds_4_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber), "%", "");
         lV71Residentwwds_6_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname), "%", "");
         lV73Residentwwds_8_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname), "%", "");
         lV75Residentwwds_10_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail), "%", "");
         lV77Residentwwds_12_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress), "%", "");
         lV79Residentwwds_14_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone), 20, "%");
         lV81Residentwwds_16_tfcustomerlocationname = StringUtil.Concat( StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname), "%", "");
         /* Using cursor P002D5 */
         pr_default.execute(3, new Object[] {lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, AV67Residentwwds_2_tfresidentid, AV68Residentwwds_3_tfresidentid_to, lV69Residentwwds_4_tfresidentbsnnumber, AV70Residentwwds_5_tfresidentbsnnumber_sel, lV71Residentwwds_6_tfresidentgivenname, AV72Residentwwds_7_tfresidentgivenname_sel, lV73Residentwwds_8_tfresidentlastname, AV74Residentwwds_9_tfresidentlastname_sel, lV75Residentwwds_10_tfresidentemail, AV76Residentwwds_11_tfresidentemail_sel, lV77Residentwwds_12_tfresidentaddress, AV78Residentwwds_13_tfresidentaddress_sel, lV79Residentwwds_14_tfresidentphone, AV80Residentwwds_15_tfresidentphone_sel, lV81Residentwwds_16_tfcustomerlocationname, AV82Residentwwds_17_tfcustomerlocationname_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK2D8 = false;
            A1CustomerId = P002D5_A1CustomerId[0];
            A18CustomerLocationId = P002D5_A18CustomerLocationId[0];
            A36ResidentEmail = P002D5_A36ResidentEmail[0];
            A31ResidentId = P002D5_A31ResidentId[0];
            A134CustomerLocationName = P002D5_A134CustomerLocationName[0];
            A38ResidentPhone = P002D5_A38ResidentPhone[0];
            n38ResidentPhone = P002D5_n38ResidentPhone[0];
            A37ResidentAddress = P002D5_A37ResidentAddress[0];
            n37ResidentAddress = P002D5_n37ResidentAddress[0];
            A34ResidentLastName = P002D5_A34ResidentLastName[0];
            A33ResidentGivenName = P002D5_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D5_A40ResidentBsnNumber[0];
            A134CustomerLocationName = P002D5_A134CustomerLocationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P002D5_A36ResidentEmail[0], A36ResidentEmail) == 0 ) )
            {
               BRK2D8 = false;
               A31ResidentId = P002D5_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A36ResidentEmail)) ? "<#Empty#>" : A36ResidentEmail);
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
            if ( ! BRK2D8 )
            {
               BRK2D8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADRESIDENTADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV23TFResidentAddress = AV31SearchTxt;
         AV24TFResidentAddress_Sel = "";
         AV66Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV67Residentwwds_2_tfresidentid = AV11TFResidentId;
         AV68Residentwwds_3_tfresidentid_to = AV12TFResidentId_To;
         AV69Residentwwds_4_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV70Residentwwds_5_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV71Residentwwds_6_tfresidentgivenname = AV15TFResidentGivenName;
         AV72Residentwwds_7_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV73Residentwwds_8_tfresidentlastname = AV17TFResidentLastName;
         AV74Residentwwds_9_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV75Residentwwds_10_tfresidentemail = AV21TFResidentEmail;
         AV76Residentwwds_11_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV77Residentwwds_12_tfresidentaddress = AV23TFResidentAddress;
         AV78Residentwwds_13_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV79Residentwwds_14_tfresidentphone = AV25TFResidentPhone;
         AV80Residentwwds_15_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV81Residentwwds_16_tfcustomerlocationname = AV62TFCustomerLocationName;
         AV82Residentwwds_17_tfcustomerlocationname_sel = AV63TFCustomerLocationName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV66Residentwwds_1_filterfulltext ,
                                              AV67Residentwwds_2_tfresidentid ,
                                              AV68Residentwwds_3_tfresidentid_to ,
                                              AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                              AV69Residentwwds_4_tfresidentbsnnumber ,
                                              AV72Residentwwds_7_tfresidentgivenname_sel ,
                                              AV71Residentwwds_6_tfresidentgivenname ,
                                              AV74Residentwwds_9_tfresidentlastname_sel ,
                                              AV73Residentwwds_8_tfresidentlastname ,
                                              AV76Residentwwds_11_tfresidentemail_sel ,
                                              AV75Residentwwds_10_tfresidentemail ,
                                              AV78Residentwwds_13_tfresidentaddress_sel ,
                                              AV77Residentwwds_12_tfresidentaddress ,
                                              AV80Residentwwds_15_tfresidentphone_sel ,
                                              AV79Residentwwds_14_tfresidentphone ,
                                              AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                              AV81Residentwwds_16_tfcustomerlocationname ,
                                              A31ResidentId ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A134CustomerLocationName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV69Residentwwds_4_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber), "%", "");
         lV71Residentwwds_6_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname), "%", "");
         lV73Residentwwds_8_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname), "%", "");
         lV75Residentwwds_10_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail), "%", "");
         lV77Residentwwds_12_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress), "%", "");
         lV79Residentwwds_14_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone), 20, "%");
         lV81Residentwwds_16_tfcustomerlocationname = StringUtil.Concat( StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname), "%", "");
         /* Using cursor P002D6 */
         pr_default.execute(4, new Object[] {lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, AV67Residentwwds_2_tfresidentid, AV68Residentwwds_3_tfresidentid_to, lV69Residentwwds_4_tfresidentbsnnumber, AV70Residentwwds_5_tfresidentbsnnumber_sel, lV71Residentwwds_6_tfresidentgivenname, AV72Residentwwds_7_tfresidentgivenname_sel, lV73Residentwwds_8_tfresidentlastname, AV74Residentwwds_9_tfresidentlastname_sel, lV75Residentwwds_10_tfresidentemail, AV76Residentwwds_11_tfresidentemail_sel, lV77Residentwwds_12_tfresidentaddress, AV78Residentwwds_13_tfresidentaddress_sel, lV79Residentwwds_14_tfresidentphone, AV80Residentwwds_15_tfresidentphone_sel, lV81Residentwwds_16_tfcustomerlocationname, AV82Residentwwds_17_tfcustomerlocationname_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK2D10 = false;
            A1CustomerId = P002D6_A1CustomerId[0];
            A18CustomerLocationId = P002D6_A18CustomerLocationId[0];
            A37ResidentAddress = P002D6_A37ResidentAddress[0];
            n37ResidentAddress = P002D6_n37ResidentAddress[0];
            A31ResidentId = P002D6_A31ResidentId[0];
            A134CustomerLocationName = P002D6_A134CustomerLocationName[0];
            A38ResidentPhone = P002D6_A38ResidentPhone[0];
            n38ResidentPhone = P002D6_n38ResidentPhone[0];
            A36ResidentEmail = P002D6_A36ResidentEmail[0];
            A34ResidentLastName = P002D6_A34ResidentLastName[0];
            A33ResidentGivenName = P002D6_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D6_A40ResidentBsnNumber[0];
            A134CustomerLocationName = P002D6_A134CustomerLocationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P002D6_A37ResidentAddress[0], A37ResidentAddress) == 0 ) )
            {
               BRK2D10 = false;
               A31ResidentId = P002D6_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A37ResidentAddress)) ? "<#Empty#>" : A37ResidentAddress);
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
            if ( ! BRK2D10 )
            {
               BRK2D10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADRESIDENTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV25TFResidentPhone = AV31SearchTxt;
         AV26TFResidentPhone_Sel = "";
         AV66Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV67Residentwwds_2_tfresidentid = AV11TFResidentId;
         AV68Residentwwds_3_tfresidentid_to = AV12TFResidentId_To;
         AV69Residentwwds_4_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV70Residentwwds_5_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV71Residentwwds_6_tfresidentgivenname = AV15TFResidentGivenName;
         AV72Residentwwds_7_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV73Residentwwds_8_tfresidentlastname = AV17TFResidentLastName;
         AV74Residentwwds_9_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV75Residentwwds_10_tfresidentemail = AV21TFResidentEmail;
         AV76Residentwwds_11_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV77Residentwwds_12_tfresidentaddress = AV23TFResidentAddress;
         AV78Residentwwds_13_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV79Residentwwds_14_tfresidentphone = AV25TFResidentPhone;
         AV80Residentwwds_15_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV81Residentwwds_16_tfcustomerlocationname = AV62TFCustomerLocationName;
         AV82Residentwwds_17_tfcustomerlocationname_sel = AV63TFCustomerLocationName_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV66Residentwwds_1_filterfulltext ,
                                              AV67Residentwwds_2_tfresidentid ,
                                              AV68Residentwwds_3_tfresidentid_to ,
                                              AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                              AV69Residentwwds_4_tfresidentbsnnumber ,
                                              AV72Residentwwds_7_tfresidentgivenname_sel ,
                                              AV71Residentwwds_6_tfresidentgivenname ,
                                              AV74Residentwwds_9_tfresidentlastname_sel ,
                                              AV73Residentwwds_8_tfresidentlastname ,
                                              AV76Residentwwds_11_tfresidentemail_sel ,
                                              AV75Residentwwds_10_tfresidentemail ,
                                              AV78Residentwwds_13_tfresidentaddress_sel ,
                                              AV77Residentwwds_12_tfresidentaddress ,
                                              AV80Residentwwds_15_tfresidentphone_sel ,
                                              AV79Residentwwds_14_tfresidentphone ,
                                              AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                              AV81Residentwwds_16_tfcustomerlocationname ,
                                              A31ResidentId ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A134CustomerLocationName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV69Residentwwds_4_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber), "%", "");
         lV71Residentwwds_6_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname), "%", "");
         lV73Residentwwds_8_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname), "%", "");
         lV75Residentwwds_10_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail), "%", "");
         lV77Residentwwds_12_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress), "%", "");
         lV79Residentwwds_14_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone), 20, "%");
         lV81Residentwwds_16_tfcustomerlocationname = StringUtil.Concat( StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname), "%", "");
         /* Using cursor P002D7 */
         pr_default.execute(5, new Object[] {lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, AV67Residentwwds_2_tfresidentid, AV68Residentwwds_3_tfresidentid_to, lV69Residentwwds_4_tfresidentbsnnumber, AV70Residentwwds_5_tfresidentbsnnumber_sel, lV71Residentwwds_6_tfresidentgivenname, AV72Residentwwds_7_tfresidentgivenname_sel, lV73Residentwwds_8_tfresidentlastname, AV74Residentwwds_9_tfresidentlastname_sel, lV75Residentwwds_10_tfresidentemail, AV76Residentwwds_11_tfresidentemail_sel, lV77Residentwwds_12_tfresidentaddress, AV78Residentwwds_13_tfresidentaddress_sel, lV79Residentwwds_14_tfresidentphone, AV80Residentwwds_15_tfresidentphone_sel, lV81Residentwwds_16_tfcustomerlocationname, AV82Residentwwds_17_tfcustomerlocationname_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK2D12 = false;
            A1CustomerId = P002D7_A1CustomerId[0];
            A18CustomerLocationId = P002D7_A18CustomerLocationId[0];
            A38ResidentPhone = P002D7_A38ResidentPhone[0];
            n38ResidentPhone = P002D7_n38ResidentPhone[0];
            A31ResidentId = P002D7_A31ResidentId[0];
            A134CustomerLocationName = P002D7_A134CustomerLocationName[0];
            A37ResidentAddress = P002D7_A37ResidentAddress[0];
            n37ResidentAddress = P002D7_n37ResidentAddress[0];
            A36ResidentEmail = P002D7_A36ResidentEmail[0];
            A34ResidentLastName = P002D7_A34ResidentLastName[0];
            A33ResidentGivenName = P002D7_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D7_A40ResidentBsnNumber[0];
            A134CustomerLocationName = P002D7_A134CustomerLocationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P002D7_A38ResidentPhone[0], A38ResidentPhone) == 0 ) )
            {
               BRK2D12 = false;
               A31ResidentId = P002D7_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D12 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A38ResidentPhone)) ? "<#Empty#>" : A38ResidentPhone);
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
            if ( ! BRK2D12 )
            {
               BRK2D12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADCUSTOMERLOCATIONNAMEOPTIONS' Routine */
         returnInSub = false;
         AV62TFCustomerLocationName = AV31SearchTxt;
         AV63TFCustomerLocationName_Sel = "";
         AV66Residentwwds_1_filterfulltext = AV53FilterFullText;
         AV67Residentwwds_2_tfresidentid = AV11TFResidentId;
         AV68Residentwwds_3_tfresidentid_to = AV12TFResidentId_To;
         AV69Residentwwds_4_tfresidentbsnnumber = AV13TFResidentBsnNumber;
         AV70Residentwwds_5_tfresidentbsnnumber_sel = AV14TFResidentBsnNumber_Sel;
         AV71Residentwwds_6_tfresidentgivenname = AV15TFResidentGivenName;
         AV72Residentwwds_7_tfresidentgivenname_sel = AV16TFResidentGivenName_Sel;
         AV73Residentwwds_8_tfresidentlastname = AV17TFResidentLastName;
         AV74Residentwwds_9_tfresidentlastname_sel = AV18TFResidentLastName_Sel;
         AV75Residentwwds_10_tfresidentemail = AV21TFResidentEmail;
         AV76Residentwwds_11_tfresidentemail_sel = AV22TFResidentEmail_Sel;
         AV77Residentwwds_12_tfresidentaddress = AV23TFResidentAddress;
         AV78Residentwwds_13_tfresidentaddress_sel = AV24TFResidentAddress_Sel;
         AV79Residentwwds_14_tfresidentphone = AV25TFResidentPhone;
         AV80Residentwwds_15_tfresidentphone_sel = AV26TFResidentPhone_Sel;
         AV81Residentwwds_16_tfcustomerlocationname = AV62TFCustomerLocationName;
         AV82Residentwwds_17_tfcustomerlocationname_sel = AV63TFCustomerLocationName_Sel;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV66Residentwwds_1_filterfulltext ,
                                              AV67Residentwwds_2_tfresidentid ,
                                              AV68Residentwwds_3_tfresidentid_to ,
                                              AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                              AV69Residentwwds_4_tfresidentbsnnumber ,
                                              AV72Residentwwds_7_tfresidentgivenname_sel ,
                                              AV71Residentwwds_6_tfresidentgivenname ,
                                              AV74Residentwwds_9_tfresidentlastname_sel ,
                                              AV73Residentwwds_8_tfresidentlastname ,
                                              AV76Residentwwds_11_tfresidentemail_sel ,
                                              AV75Residentwwds_10_tfresidentemail ,
                                              AV78Residentwwds_13_tfresidentaddress_sel ,
                                              AV77Residentwwds_12_tfresidentaddress ,
                                              AV80Residentwwds_15_tfresidentphone_sel ,
                                              AV79Residentwwds_14_tfresidentphone ,
                                              AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                              AV81Residentwwds_16_tfcustomerlocationname ,
                                              A31ResidentId ,
                                              A40ResidentBsnNumber ,
                                              A33ResidentGivenName ,
                                              A34ResidentLastName ,
                                              A36ResidentEmail ,
                                              A37ResidentAddress ,
                                              A38ResidentPhone ,
                                              A134CustomerLocationName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV66Residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Residentwwds_1_filterfulltext), "%", "");
         lV69Residentwwds_4_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber), "%", "");
         lV71Residentwwds_6_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname), "%", "");
         lV73Residentwwds_8_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname), "%", "");
         lV75Residentwwds_10_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail), "%", "");
         lV77Residentwwds_12_tfresidentaddress = StringUtil.Concat( StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress), "%", "");
         lV79Residentwwds_14_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone), 20, "%");
         lV81Residentwwds_16_tfcustomerlocationname = StringUtil.Concat( StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname), "%", "");
         /* Using cursor P002D8 */
         pr_default.execute(6, new Object[] {lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, lV66Residentwwds_1_filterfulltext, AV67Residentwwds_2_tfresidentid, AV68Residentwwds_3_tfresidentid_to, lV69Residentwwds_4_tfresidentbsnnumber, AV70Residentwwds_5_tfresidentbsnnumber_sel, lV71Residentwwds_6_tfresidentgivenname, AV72Residentwwds_7_tfresidentgivenname_sel, lV73Residentwwds_8_tfresidentlastname, AV74Residentwwds_9_tfresidentlastname_sel, lV75Residentwwds_10_tfresidentemail, AV76Residentwwds_11_tfresidentemail_sel, lV77Residentwwds_12_tfresidentaddress, AV78Residentwwds_13_tfresidentaddress_sel, lV79Residentwwds_14_tfresidentphone, AV80Residentwwds_15_tfresidentphone_sel, lV81Residentwwds_16_tfcustomerlocationname, AV82Residentwwds_17_tfcustomerlocationname_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK2D14 = false;
            A1CustomerId = P002D8_A1CustomerId[0];
            A18CustomerLocationId = P002D8_A18CustomerLocationId[0];
            A134CustomerLocationName = P002D8_A134CustomerLocationName[0];
            A31ResidentId = P002D8_A31ResidentId[0];
            A38ResidentPhone = P002D8_A38ResidentPhone[0];
            n38ResidentPhone = P002D8_n38ResidentPhone[0];
            A37ResidentAddress = P002D8_A37ResidentAddress[0];
            n37ResidentAddress = P002D8_n37ResidentAddress[0];
            A36ResidentEmail = P002D8_A36ResidentEmail[0];
            A34ResidentLastName = P002D8_A34ResidentLastName[0];
            A33ResidentGivenName = P002D8_A33ResidentGivenName[0];
            A40ResidentBsnNumber = P002D8_A40ResidentBsnNumber[0];
            A134CustomerLocationName = P002D8_A134CustomerLocationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P002D8_A134CustomerLocationName[0], A134CustomerLocationName) == 0 ) )
            {
               BRK2D14 = false;
               A1CustomerId = P002D8_A1CustomerId[0];
               A18CustomerLocationId = P002D8_A18CustomerLocationId[0];
               A31ResidentId = P002D8_A31ResidentId[0];
               AV41count = (long)(AV41count+1);
               BRK2D14 = true;
               pr_default.readNext(6);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A134CustomerLocationName)) ? "<#Empty#>" : A134CustomerLocationName);
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
            if ( ! BRK2D14 )
            {
               BRK2D14 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
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
         AV13TFResidentBsnNumber = "";
         AV14TFResidentBsnNumber_Sel = "";
         AV15TFResidentGivenName = "";
         AV16TFResidentGivenName_Sel = "";
         AV17TFResidentLastName = "";
         AV18TFResidentLastName_Sel = "";
         AV21TFResidentEmail = "";
         AV22TFResidentEmail_Sel = "";
         AV23TFResidentAddress = "";
         AV24TFResidentAddress_Sel = "";
         AV25TFResidentPhone = "";
         AV26TFResidentPhone_Sel = "";
         AV62TFCustomerLocationName = "";
         AV63TFCustomerLocationName_Sel = "";
         AV66Residentwwds_1_filterfulltext = "";
         AV69Residentwwds_4_tfresidentbsnnumber = "";
         AV70Residentwwds_5_tfresidentbsnnumber_sel = "";
         AV71Residentwwds_6_tfresidentgivenname = "";
         AV72Residentwwds_7_tfresidentgivenname_sel = "";
         AV73Residentwwds_8_tfresidentlastname = "";
         AV74Residentwwds_9_tfresidentlastname_sel = "";
         AV75Residentwwds_10_tfresidentemail = "";
         AV76Residentwwds_11_tfresidentemail_sel = "";
         AV77Residentwwds_12_tfresidentaddress = "";
         AV78Residentwwds_13_tfresidentaddress_sel = "";
         AV79Residentwwds_14_tfresidentphone = "";
         AV80Residentwwds_15_tfresidentphone_sel = "";
         AV81Residentwwds_16_tfcustomerlocationname = "";
         AV82Residentwwds_17_tfcustomerlocationname_sel = "";
         lV66Residentwwds_1_filterfulltext = "";
         lV69Residentwwds_4_tfresidentbsnnumber = "";
         lV71Residentwwds_6_tfresidentgivenname = "";
         lV73Residentwwds_8_tfresidentlastname = "";
         lV75Residentwwds_10_tfresidentemail = "";
         lV77Residentwwds_12_tfresidentaddress = "";
         lV79Residentwwds_14_tfresidentphone = "";
         lV81Residentwwds_16_tfcustomerlocationname = "";
         A40ResidentBsnNumber = "";
         A33ResidentGivenName = "";
         A34ResidentLastName = "";
         A36ResidentEmail = "";
         A37ResidentAddress = "";
         A38ResidentPhone = "";
         A134CustomerLocationName = "";
         P002D2_A1CustomerId = new short[1] ;
         P002D2_A18CustomerLocationId = new short[1] ;
         P002D2_A40ResidentBsnNumber = new string[] {""} ;
         P002D2_A31ResidentId = new short[1] ;
         P002D2_A134CustomerLocationName = new string[] {""} ;
         P002D2_A38ResidentPhone = new string[] {""} ;
         P002D2_n38ResidentPhone = new bool[] {false} ;
         P002D2_A37ResidentAddress = new string[] {""} ;
         P002D2_n37ResidentAddress = new bool[] {false} ;
         P002D2_A36ResidentEmail = new string[] {""} ;
         P002D2_A34ResidentLastName = new string[] {""} ;
         P002D2_A33ResidentGivenName = new string[] {""} ;
         AV36Option = "";
         P002D3_A1CustomerId = new short[1] ;
         P002D3_A18CustomerLocationId = new short[1] ;
         P002D3_A33ResidentGivenName = new string[] {""} ;
         P002D3_A31ResidentId = new short[1] ;
         P002D3_A134CustomerLocationName = new string[] {""} ;
         P002D3_A38ResidentPhone = new string[] {""} ;
         P002D3_n38ResidentPhone = new bool[] {false} ;
         P002D3_A37ResidentAddress = new string[] {""} ;
         P002D3_n37ResidentAddress = new bool[] {false} ;
         P002D3_A36ResidentEmail = new string[] {""} ;
         P002D3_A34ResidentLastName = new string[] {""} ;
         P002D3_A40ResidentBsnNumber = new string[] {""} ;
         P002D4_A1CustomerId = new short[1] ;
         P002D4_A18CustomerLocationId = new short[1] ;
         P002D4_A34ResidentLastName = new string[] {""} ;
         P002D4_A31ResidentId = new short[1] ;
         P002D4_A134CustomerLocationName = new string[] {""} ;
         P002D4_A38ResidentPhone = new string[] {""} ;
         P002D4_n38ResidentPhone = new bool[] {false} ;
         P002D4_A37ResidentAddress = new string[] {""} ;
         P002D4_n37ResidentAddress = new bool[] {false} ;
         P002D4_A36ResidentEmail = new string[] {""} ;
         P002D4_A33ResidentGivenName = new string[] {""} ;
         P002D4_A40ResidentBsnNumber = new string[] {""} ;
         P002D5_A1CustomerId = new short[1] ;
         P002D5_A18CustomerLocationId = new short[1] ;
         P002D5_A36ResidentEmail = new string[] {""} ;
         P002D5_A31ResidentId = new short[1] ;
         P002D5_A134CustomerLocationName = new string[] {""} ;
         P002D5_A38ResidentPhone = new string[] {""} ;
         P002D5_n38ResidentPhone = new bool[] {false} ;
         P002D5_A37ResidentAddress = new string[] {""} ;
         P002D5_n37ResidentAddress = new bool[] {false} ;
         P002D5_A34ResidentLastName = new string[] {""} ;
         P002D5_A33ResidentGivenName = new string[] {""} ;
         P002D5_A40ResidentBsnNumber = new string[] {""} ;
         P002D6_A1CustomerId = new short[1] ;
         P002D6_A18CustomerLocationId = new short[1] ;
         P002D6_A37ResidentAddress = new string[] {""} ;
         P002D6_n37ResidentAddress = new bool[] {false} ;
         P002D6_A31ResidentId = new short[1] ;
         P002D6_A134CustomerLocationName = new string[] {""} ;
         P002D6_A38ResidentPhone = new string[] {""} ;
         P002D6_n38ResidentPhone = new bool[] {false} ;
         P002D6_A36ResidentEmail = new string[] {""} ;
         P002D6_A34ResidentLastName = new string[] {""} ;
         P002D6_A33ResidentGivenName = new string[] {""} ;
         P002D6_A40ResidentBsnNumber = new string[] {""} ;
         P002D7_A1CustomerId = new short[1] ;
         P002D7_A18CustomerLocationId = new short[1] ;
         P002D7_A38ResidentPhone = new string[] {""} ;
         P002D7_n38ResidentPhone = new bool[] {false} ;
         P002D7_A31ResidentId = new short[1] ;
         P002D7_A134CustomerLocationName = new string[] {""} ;
         P002D7_A37ResidentAddress = new string[] {""} ;
         P002D7_n37ResidentAddress = new bool[] {false} ;
         P002D7_A36ResidentEmail = new string[] {""} ;
         P002D7_A34ResidentLastName = new string[] {""} ;
         P002D7_A33ResidentGivenName = new string[] {""} ;
         P002D7_A40ResidentBsnNumber = new string[] {""} ;
         P002D8_A1CustomerId = new short[1] ;
         P002D8_A18CustomerLocationId = new short[1] ;
         P002D8_A134CustomerLocationName = new string[] {""} ;
         P002D8_A31ResidentId = new short[1] ;
         P002D8_A38ResidentPhone = new string[] {""} ;
         P002D8_n38ResidentPhone = new bool[] {false} ;
         P002D8_A37ResidentAddress = new string[] {""} ;
         P002D8_n37ResidentAddress = new bool[] {false} ;
         P002D8_A36ResidentEmail = new string[] {""} ;
         P002D8_A34ResidentLastName = new string[] {""} ;
         P002D8_A33ResidentGivenName = new string[] {""} ;
         P002D8_A40ResidentBsnNumber = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.residentwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002D2_A1CustomerId, P002D2_A18CustomerLocationId, P002D2_A40ResidentBsnNumber, P002D2_A31ResidentId, P002D2_A134CustomerLocationName, P002D2_A38ResidentPhone, P002D2_n38ResidentPhone, P002D2_A37ResidentAddress, P002D2_n37ResidentAddress, P002D2_A36ResidentEmail,
               P002D2_A34ResidentLastName, P002D2_A33ResidentGivenName
               }
               , new Object[] {
               P002D3_A1CustomerId, P002D3_A18CustomerLocationId, P002D3_A33ResidentGivenName, P002D3_A31ResidentId, P002D3_A134CustomerLocationName, P002D3_A38ResidentPhone, P002D3_n38ResidentPhone, P002D3_A37ResidentAddress, P002D3_n37ResidentAddress, P002D3_A36ResidentEmail,
               P002D3_A34ResidentLastName, P002D3_A40ResidentBsnNumber
               }
               , new Object[] {
               P002D4_A1CustomerId, P002D4_A18CustomerLocationId, P002D4_A34ResidentLastName, P002D4_A31ResidentId, P002D4_A134CustomerLocationName, P002D4_A38ResidentPhone, P002D4_n38ResidentPhone, P002D4_A37ResidentAddress, P002D4_n37ResidentAddress, P002D4_A36ResidentEmail,
               P002D4_A33ResidentGivenName, P002D4_A40ResidentBsnNumber
               }
               , new Object[] {
               P002D5_A1CustomerId, P002D5_A18CustomerLocationId, P002D5_A36ResidentEmail, P002D5_A31ResidentId, P002D5_A134CustomerLocationName, P002D5_A38ResidentPhone, P002D5_n38ResidentPhone, P002D5_A37ResidentAddress, P002D5_n37ResidentAddress, P002D5_A34ResidentLastName,
               P002D5_A33ResidentGivenName, P002D5_A40ResidentBsnNumber
               }
               , new Object[] {
               P002D6_A1CustomerId, P002D6_A18CustomerLocationId, P002D6_A37ResidentAddress, P002D6_n37ResidentAddress, P002D6_A31ResidentId, P002D6_A134CustomerLocationName, P002D6_A38ResidentPhone, P002D6_n38ResidentPhone, P002D6_A36ResidentEmail, P002D6_A34ResidentLastName,
               P002D6_A33ResidentGivenName, P002D6_A40ResidentBsnNumber
               }
               , new Object[] {
               P002D7_A1CustomerId, P002D7_A18CustomerLocationId, P002D7_A38ResidentPhone, P002D7_n38ResidentPhone, P002D7_A31ResidentId, P002D7_A134CustomerLocationName, P002D7_A37ResidentAddress, P002D7_n37ResidentAddress, P002D7_A36ResidentEmail, P002D7_A34ResidentLastName,
               P002D7_A33ResidentGivenName, P002D7_A40ResidentBsnNumber
               }
               , new Object[] {
               P002D8_A1CustomerId, P002D8_A18CustomerLocationId, P002D8_A134CustomerLocationName, P002D8_A31ResidentId, P002D8_A38ResidentPhone, P002D8_n38ResidentPhone, P002D8_A37ResidentAddress, P002D8_n37ResidentAddress, P002D8_A36ResidentEmail, P002D8_A34ResidentLastName,
               P002D8_A33ResidentGivenName, P002D8_A40ResidentBsnNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private short AV11TFResidentId ;
      private short AV12TFResidentId_To ;
      private short AV67Residentwwds_2_tfresidentid ;
      private short AV68Residentwwds_3_tfresidentid_to ;
      private short A31ResidentId ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
      private int AV64GXV1 ;
      private long AV41count ;
      private string AV25TFResidentPhone ;
      private string AV26TFResidentPhone_Sel ;
      private string AV79Residentwwds_14_tfresidentphone ;
      private string AV80Residentwwds_15_tfresidentphone_sel ;
      private string lV79Residentwwds_14_tfresidentphone ;
      private string A38ResidentPhone ;
      private bool returnInSub ;
      private bool BRK2D2 ;
      private bool n38ResidentPhone ;
      private bool n37ResidentAddress ;
      private bool BRK2D4 ;
      private bool BRK2D6 ;
      private bool BRK2D8 ;
      private bool BRK2D10 ;
      private bool BRK2D12 ;
      private bool BRK2D14 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV13TFResidentBsnNumber ;
      private string AV14TFResidentBsnNumber_Sel ;
      private string AV15TFResidentGivenName ;
      private string AV16TFResidentGivenName_Sel ;
      private string AV17TFResidentLastName ;
      private string AV18TFResidentLastName_Sel ;
      private string AV21TFResidentEmail ;
      private string AV22TFResidentEmail_Sel ;
      private string AV23TFResidentAddress ;
      private string AV24TFResidentAddress_Sel ;
      private string AV62TFCustomerLocationName ;
      private string AV63TFCustomerLocationName_Sel ;
      private string AV66Residentwwds_1_filterfulltext ;
      private string AV69Residentwwds_4_tfresidentbsnnumber ;
      private string AV70Residentwwds_5_tfresidentbsnnumber_sel ;
      private string AV71Residentwwds_6_tfresidentgivenname ;
      private string AV72Residentwwds_7_tfresidentgivenname_sel ;
      private string AV73Residentwwds_8_tfresidentlastname ;
      private string AV74Residentwwds_9_tfresidentlastname_sel ;
      private string AV75Residentwwds_10_tfresidentemail ;
      private string AV76Residentwwds_11_tfresidentemail_sel ;
      private string AV77Residentwwds_12_tfresidentaddress ;
      private string AV78Residentwwds_13_tfresidentaddress_sel ;
      private string AV81Residentwwds_16_tfcustomerlocationname ;
      private string AV82Residentwwds_17_tfcustomerlocationname_sel ;
      private string lV66Residentwwds_1_filterfulltext ;
      private string lV69Residentwwds_4_tfresidentbsnnumber ;
      private string lV71Residentwwds_6_tfresidentgivenname ;
      private string lV73Residentwwds_8_tfresidentlastname ;
      private string lV75Residentwwds_10_tfresidentemail ;
      private string lV77Residentwwds_12_tfresidentaddress ;
      private string lV81Residentwwds_16_tfcustomerlocationname ;
      private string A40ResidentBsnNumber ;
      private string A33ResidentGivenName ;
      private string A34ResidentLastName ;
      private string A36ResidentEmail ;
      private string A37ResidentAddress ;
      private string A134CustomerLocationName ;
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
      private short[] P002D2_A1CustomerId ;
      private short[] P002D2_A18CustomerLocationId ;
      private string[] P002D2_A40ResidentBsnNumber ;
      private short[] P002D2_A31ResidentId ;
      private string[] P002D2_A134CustomerLocationName ;
      private string[] P002D2_A38ResidentPhone ;
      private bool[] P002D2_n38ResidentPhone ;
      private string[] P002D2_A37ResidentAddress ;
      private bool[] P002D2_n37ResidentAddress ;
      private string[] P002D2_A36ResidentEmail ;
      private string[] P002D2_A34ResidentLastName ;
      private string[] P002D2_A33ResidentGivenName ;
      private short[] P002D3_A1CustomerId ;
      private short[] P002D3_A18CustomerLocationId ;
      private string[] P002D3_A33ResidentGivenName ;
      private short[] P002D3_A31ResidentId ;
      private string[] P002D3_A134CustomerLocationName ;
      private string[] P002D3_A38ResidentPhone ;
      private bool[] P002D3_n38ResidentPhone ;
      private string[] P002D3_A37ResidentAddress ;
      private bool[] P002D3_n37ResidentAddress ;
      private string[] P002D3_A36ResidentEmail ;
      private string[] P002D3_A34ResidentLastName ;
      private string[] P002D3_A40ResidentBsnNumber ;
      private short[] P002D4_A1CustomerId ;
      private short[] P002D4_A18CustomerLocationId ;
      private string[] P002D4_A34ResidentLastName ;
      private short[] P002D4_A31ResidentId ;
      private string[] P002D4_A134CustomerLocationName ;
      private string[] P002D4_A38ResidentPhone ;
      private bool[] P002D4_n38ResidentPhone ;
      private string[] P002D4_A37ResidentAddress ;
      private bool[] P002D4_n37ResidentAddress ;
      private string[] P002D4_A36ResidentEmail ;
      private string[] P002D4_A33ResidentGivenName ;
      private string[] P002D4_A40ResidentBsnNumber ;
      private short[] P002D5_A1CustomerId ;
      private short[] P002D5_A18CustomerLocationId ;
      private string[] P002D5_A36ResidentEmail ;
      private short[] P002D5_A31ResidentId ;
      private string[] P002D5_A134CustomerLocationName ;
      private string[] P002D5_A38ResidentPhone ;
      private bool[] P002D5_n38ResidentPhone ;
      private string[] P002D5_A37ResidentAddress ;
      private bool[] P002D5_n37ResidentAddress ;
      private string[] P002D5_A34ResidentLastName ;
      private string[] P002D5_A33ResidentGivenName ;
      private string[] P002D5_A40ResidentBsnNumber ;
      private short[] P002D6_A1CustomerId ;
      private short[] P002D6_A18CustomerLocationId ;
      private string[] P002D6_A37ResidentAddress ;
      private bool[] P002D6_n37ResidentAddress ;
      private short[] P002D6_A31ResidentId ;
      private string[] P002D6_A134CustomerLocationName ;
      private string[] P002D6_A38ResidentPhone ;
      private bool[] P002D6_n38ResidentPhone ;
      private string[] P002D6_A36ResidentEmail ;
      private string[] P002D6_A34ResidentLastName ;
      private string[] P002D6_A33ResidentGivenName ;
      private string[] P002D6_A40ResidentBsnNumber ;
      private short[] P002D7_A1CustomerId ;
      private short[] P002D7_A18CustomerLocationId ;
      private string[] P002D7_A38ResidentPhone ;
      private bool[] P002D7_n38ResidentPhone ;
      private short[] P002D7_A31ResidentId ;
      private string[] P002D7_A134CustomerLocationName ;
      private string[] P002D7_A37ResidentAddress ;
      private bool[] P002D7_n37ResidentAddress ;
      private string[] P002D7_A36ResidentEmail ;
      private string[] P002D7_A34ResidentLastName ;
      private string[] P002D7_A33ResidentGivenName ;
      private string[] P002D7_A40ResidentBsnNumber ;
      private short[] P002D8_A1CustomerId ;
      private short[] P002D8_A18CustomerLocationId ;
      private string[] P002D8_A134CustomerLocationName ;
      private short[] P002D8_A31ResidentId ;
      private string[] P002D8_A38ResidentPhone ;
      private bool[] P002D8_n38ResidentPhone ;
      private string[] P002D8_A37ResidentAddress ;
      private bool[] P002D8_n37ResidentAddress ;
      private string[] P002D8_A36ResidentEmail ;
      private string[] P002D8_A34ResidentLastName ;
      private string[] P002D8_A33ResidentGivenName ;
      private string[] P002D8_A40ResidentBsnNumber ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class residentwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002D2( IGxContext context ,
                                             string AV66Residentwwds_1_filterfulltext ,
                                             short AV67Residentwwds_2_tfresidentid ,
                                             short AV68Residentwwds_3_tfresidentid_to ,
                                             string AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                             string AV69Residentwwds_4_tfresidentbsnnumber ,
                                             string AV72Residentwwds_7_tfresidentgivenname_sel ,
                                             string AV71Residentwwds_6_tfresidentgivenname ,
                                             string AV74Residentwwds_9_tfresidentlastname_sel ,
                                             string AV73Residentwwds_8_tfresidentlastname ,
                                             string AV76Residentwwds_11_tfresidentemail_sel ,
                                             string AV75Residentwwds_10_tfresidentemail ,
                                             string AV78Residentwwds_13_tfresidentaddress_sel ,
                                             string AV77Residentwwds_12_tfresidentaddress ,
                                             string AV80Residentwwds_15_tfresidentphone_sel ,
                                             string AV79Residentwwds_14_tfresidentphone ,
                                             string AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                             string AV81Residentwwds_16_tfcustomerlocationname ,
                                             short A31ResidentId ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A134CustomerLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[24];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.CustomerId, T1.CustomerLocationId, T1.ResidentBsnNumber, T1.ResidentId, T2.CustomerLocationName, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName FROM (Resident T1 INNER JOIN CustomerLocation T2 ON T2.CustomerId = T1.CustomerId AND T2.CustomerLocationId = T1.CustomerLocationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.ResidentId,'9999'), 2) like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV66Residentwwds_1_filterfulltext) or ( T2.CustomerLocationName like '%' || :lV66Residentwwds_1_filterfulltext))");
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
         if ( ! (0==AV67Residentwwds_2_tfresidentid) )
         {
            AddWhere(sWhereString, "(T1.ResidentId >= :AV67Residentwwds_2_tfresidentid)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV68Residentwwds_3_tfresidentid_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentId <= :AV68Residentwwds_3_tfresidentid_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV69Residentwwds_4_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV70Residentwwds_5_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV71Residentwwds_6_tfresidentgivenname)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV72Residentwwds_7_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV73Residentwwds_8_tfresidentlastname)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV74Residentwwds_9_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV75Residentwwds_10_tfresidentemail)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV76Residentwwds_11_tfresidentemail_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV77Residentwwds_12_tfresidentaddress)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV78Residentwwds_13_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV79Residentwwds_14_tfresidentphone)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV80Residentwwds_15_tfresidentphone_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName like :lV81Residentwwds_16_tfcustomerlocationname)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ! ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName = ( :AV82Residentwwds_17_tfcustomerlocationname_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerLocationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentBsnNumber";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002D3( IGxContext context ,
                                             string AV66Residentwwds_1_filterfulltext ,
                                             short AV67Residentwwds_2_tfresidentid ,
                                             short AV68Residentwwds_3_tfresidentid_to ,
                                             string AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                             string AV69Residentwwds_4_tfresidentbsnnumber ,
                                             string AV72Residentwwds_7_tfresidentgivenname_sel ,
                                             string AV71Residentwwds_6_tfresidentgivenname ,
                                             string AV74Residentwwds_9_tfresidentlastname_sel ,
                                             string AV73Residentwwds_8_tfresidentlastname ,
                                             string AV76Residentwwds_11_tfresidentemail_sel ,
                                             string AV75Residentwwds_10_tfresidentemail ,
                                             string AV78Residentwwds_13_tfresidentaddress_sel ,
                                             string AV77Residentwwds_12_tfresidentaddress ,
                                             string AV80Residentwwds_15_tfresidentphone_sel ,
                                             string AV79Residentwwds_14_tfresidentphone ,
                                             string AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                             string AV81Residentwwds_16_tfcustomerlocationname ,
                                             short A31ResidentId ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A134CustomerLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[24];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CustomerId, T1.CustomerLocationId, T1.ResidentGivenName, T1.ResidentId, T2.CustomerLocationName, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentBsnNumber FROM (Resident T1 INNER JOIN CustomerLocation T2 ON T2.CustomerId = T1.CustomerId AND T2.CustomerLocationId = T1.CustomerLocationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.ResidentId,'9999'), 2) like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV66Residentwwds_1_filterfulltext) or ( T2.CustomerLocationName like '%' || :lV66Residentwwds_1_filterfulltext))");
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
         if ( ! (0==AV67Residentwwds_2_tfresidentid) )
         {
            AddWhere(sWhereString, "(T1.ResidentId >= :AV67Residentwwds_2_tfresidentid)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV68Residentwwds_3_tfresidentid_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentId <= :AV68Residentwwds_3_tfresidentid_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV69Residentwwds_4_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV70Residentwwds_5_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV71Residentwwds_6_tfresidentgivenname)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV72Residentwwds_7_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV73Residentwwds_8_tfresidentlastname)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV74Residentwwds_9_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV75Residentwwds_10_tfresidentemail)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV76Residentwwds_11_tfresidentemail_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV77Residentwwds_12_tfresidentaddress)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV78Residentwwds_13_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV79Residentwwds_14_tfresidentphone)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV80Residentwwds_15_tfresidentphone_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName like :lV81Residentwwds_16_tfcustomerlocationname)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ! ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName = ( :AV82Residentwwds_17_tfcustomerlocationname_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerLocationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentGivenName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002D4( IGxContext context ,
                                             string AV66Residentwwds_1_filterfulltext ,
                                             short AV67Residentwwds_2_tfresidentid ,
                                             short AV68Residentwwds_3_tfresidentid_to ,
                                             string AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                             string AV69Residentwwds_4_tfresidentbsnnumber ,
                                             string AV72Residentwwds_7_tfresidentgivenname_sel ,
                                             string AV71Residentwwds_6_tfresidentgivenname ,
                                             string AV74Residentwwds_9_tfresidentlastname_sel ,
                                             string AV73Residentwwds_8_tfresidentlastname ,
                                             string AV76Residentwwds_11_tfresidentemail_sel ,
                                             string AV75Residentwwds_10_tfresidentemail ,
                                             string AV78Residentwwds_13_tfresidentaddress_sel ,
                                             string AV77Residentwwds_12_tfresidentaddress ,
                                             string AV80Residentwwds_15_tfresidentphone_sel ,
                                             string AV79Residentwwds_14_tfresidentphone ,
                                             string AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                             string AV81Residentwwds_16_tfcustomerlocationname ,
                                             short A31ResidentId ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A134CustomerLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[24];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.CustomerId, T1.CustomerLocationId, T1.ResidentLastName, T1.ResidentId, T2.CustomerLocationName, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentGivenName, T1.ResidentBsnNumber FROM (Resident T1 INNER JOIN CustomerLocation T2 ON T2.CustomerId = T1.CustomerId AND T2.CustomerLocationId = T1.CustomerLocationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.ResidentId,'9999'), 2) like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV66Residentwwds_1_filterfulltext) or ( T2.CustomerLocationName like '%' || :lV66Residentwwds_1_filterfulltext))");
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
         if ( ! (0==AV67Residentwwds_2_tfresidentid) )
         {
            AddWhere(sWhereString, "(T1.ResidentId >= :AV67Residentwwds_2_tfresidentid)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV68Residentwwds_3_tfresidentid_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentId <= :AV68Residentwwds_3_tfresidentid_to)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV69Residentwwds_4_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV70Residentwwds_5_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV71Residentwwds_6_tfresidentgivenname)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV72Residentwwds_7_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV73Residentwwds_8_tfresidentlastname)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV74Residentwwds_9_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV75Residentwwds_10_tfresidentemail)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV76Residentwwds_11_tfresidentemail_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV77Residentwwds_12_tfresidentaddress)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV78Residentwwds_13_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV79Residentwwds_14_tfresidentphone)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV80Residentwwds_15_tfresidentphone_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName like :lV81Residentwwds_16_tfcustomerlocationname)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ! ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName = ( :AV82Residentwwds_17_tfcustomerlocationname_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerLocationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentLastName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002D5( IGxContext context ,
                                             string AV66Residentwwds_1_filterfulltext ,
                                             short AV67Residentwwds_2_tfresidentid ,
                                             short AV68Residentwwds_3_tfresidentid_to ,
                                             string AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                             string AV69Residentwwds_4_tfresidentbsnnumber ,
                                             string AV72Residentwwds_7_tfresidentgivenname_sel ,
                                             string AV71Residentwwds_6_tfresidentgivenname ,
                                             string AV74Residentwwds_9_tfresidentlastname_sel ,
                                             string AV73Residentwwds_8_tfresidentlastname ,
                                             string AV76Residentwwds_11_tfresidentemail_sel ,
                                             string AV75Residentwwds_10_tfresidentemail ,
                                             string AV78Residentwwds_13_tfresidentaddress_sel ,
                                             string AV77Residentwwds_12_tfresidentaddress ,
                                             string AV80Residentwwds_15_tfresidentphone_sel ,
                                             string AV79Residentwwds_14_tfresidentphone ,
                                             string AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                             string AV81Residentwwds_16_tfcustomerlocationname ,
                                             short A31ResidentId ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A134CustomerLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[24];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.CustomerId, T1.CustomerLocationId, T1.ResidentEmail, T1.ResidentId, T2.CustomerLocationName, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentBsnNumber FROM (Resident T1 INNER JOIN CustomerLocation T2 ON T2.CustomerId = T1.CustomerId AND T2.CustomerLocationId = T1.CustomerLocationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.ResidentId,'9999'), 2) like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV66Residentwwds_1_filterfulltext) or ( T2.CustomerLocationName like '%' || :lV66Residentwwds_1_filterfulltext))");
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
         if ( ! (0==AV67Residentwwds_2_tfresidentid) )
         {
            AddWhere(sWhereString, "(T1.ResidentId >= :AV67Residentwwds_2_tfresidentid)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (0==AV68Residentwwds_3_tfresidentid_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentId <= :AV68Residentwwds_3_tfresidentid_to)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV69Residentwwds_4_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV70Residentwwds_5_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV71Residentwwds_6_tfresidentgivenname)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV72Residentwwds_7_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV73Residentwwds_8_tfresidentlastname)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV74Residentwwds_9_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV75Residentwwds_10_tfresidentemail)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV76Residentwwds_11_tfresidentemail_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV77Residentwwds_12_tfresidentaddress)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV78Residentwwds_13_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV79Residentwwds_14_tfresidentphone)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV80Residentwwds_15_tfresidentphone_sel))");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName like :lV81Residentwwds_16_tfcustomerlocationname)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ! ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName = ( :AV82Residentwwds_17_tfcustomerlocationname_sel))");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerLocationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentEmail";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P002D6( IGxContext context ,
                                             string AV66Residentwwds_1_filterfulltext ,
                                             short AV67Residentwwds_2_tfresidentid ,
                                             short AV68Residentwwds_3_tfresidentid_to ,
                                             string AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                             string AV69Residentwwds_4_tfresidentbsnnumber ,
                                             string AV72Residentwwds_7_tfresidentgivenname_sel ,
                                             string AV71Residentwwds_6_tfresidentgivenname ,
                                             string AV74Residentwwds_9_tfresidentlastname_sel ,
                                             string AV73Residentwwds_8_tfresidentlastname ,
                                             string AV76Residentwwds_11_tfresidentemail_sel ,
                                             string AV75Residentwwds_10_tfresidentemail ,
                                             string AV78Residentwwds_13_tfresidentaddress_sel ,
                                             string AV77Residentwwds_12_tfresidentaddress ,
                                             string AV80Residentwwds_15_tfresidentphone_sel ,
                                             string AV79Residentwwds_14_tfresidentphone ,
                                             string AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                             string AV81Residentwwds_16_tfcustomerlocationname ,
                                             short A31ResidentId ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A134CustomerLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[24];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.CustomerId, T1.CustomerLocationId, T1.ResidentAddress, T1.ResidentId, T2.CustomerLocationName, T1.ResidentPhone, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentBsnNumber FROM (Resident T1 INNER JOIN CustomerLocation T2 ON T2.CustomerId = T1.CustomerId AND T2.CustomerLocationId = T1.CustomerLocationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.ResidentId,'9999'), 2) like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV66Residentwwds_1_filterfulltext) or ( T2.CustomerLocationName like '%' || :lV66Residentwwds_1_filterfulltext))");
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
         if ( ! (0==AV67Residentwwds_2_tfresidentid) )
         {
            AddWhere(sWhereString, "(T1.ResidentId >= :AV67Residentwwds_2_tfresidentid)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! (0==AV68Residentwwds_3_tfresidentid_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentId <= :AV68Residentwwds_3_tfresidentid_to)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV69Residentwwds_4_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV70Residentwwds_5_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV71Residentwwds_6_tfresidentgivenname)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV72Residentwwds_7_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV73Residentwwds_8_tfresidentlastname)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV74Residentwwds_9_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV75Residentwwds_10_tfresidentemail)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV76Residentwwds_11_tfresidentemail_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV77Residentwwds_12_tfresidentaddress)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV78Residentwwds_13_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV79Residentwwds_14_tfresidentphone)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV80Residentwwds_15_tfresidentphone_sel))");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName like :lV81Residentwwds_16_tfcustomerlocationname)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ! ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName = ( :AV82Residentwwds_17_tfcustomerlocationname_sel))");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerLocationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentAddress";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P002D7( IGxContext context ,
                                             string AV66Residentwwds_1_filterfulltext ,
                                             short AV67Residentwwds_2_tfresidentid ,
                                             short AV68Residentwwds_3_tfresidentid_to ,
                                             string AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                             string AV69Residentwwds_4_tfresidentbsnnumber ,
                                             string AV72Residentwwds_7_tfresidentgivenname_sel ,
                                             string AV71Residentwwds_6_tfresidentgivenname ,
                                             string AV74Residentwwds_9_tfresidentlastname_sel ,
                                             string AV73Residentwwds_8_tfresidentlastname ,
                                             string AV76Residentwwds_11_tfresidentemail_sel ,
                                             string AV75Residentwwds_10_tfresidentemail ,
                                             string AV78Residentwwds_13_tfresidentaddress_sel ,
                                             string AV77Residentwwds_12_tfresidentaddress ,
                                             string AV80Residentwwds_15_tfresidentphone_sel ,
                                             string AV79Residentwwds_14_tfresidentphone ,
                                             string AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                             string AV81Residentwwds_16_tfcustomerlocationname ,
                                             short A31ResidentId ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A134CustomerLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[24];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.CustomerId, T1.CustomerLocationId, T1.ResidentPhone, T1.ResidentId, T2.CustomerLocationName, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentBsnNumber FROM (Resident T1 INNER JOIN CustomerLocation T2 ON T2.CustomerId = T1.CustomerId AND T2.CustomerLocationId = T1.CustomerLocationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.ResidentId,'9999'), 2) like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV66Residentwwds_1_filterfulltext) or ( T2.CustomerLocationName like '%' || :lV66Residentwwds_1_filterfulltext))");
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
         if ( ! (0==AV67Residentwwds_2_tfresidentid) )
         {
            AddWhere(sWhereString, "(T1.ResidentId >= :AV67Residentwwds_2_tfresidentid)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! (0==AV68Residentwwds_3_tfresidentid_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentId <= :AV68Residentwwds_3_tfresidentid_to)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV69Residentwwds_4_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV70Residentwwds_5_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV71Residentwwds_6_tfresidentgivenname)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV72Residentwwds_7_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV73Residentwwds_8_tfresidentlastname)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV74Residentwwds_9_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV75Residentwwds_10_tfresidentemail)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV76Residentwwds_11_tfresidentemail_sel))");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV77Residentwwds_12_tfresidentaddress)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV78Residentwwds_13_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV79Residentwwds_14_tfresidentphone)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV80Residentwwds_15_tfresidentphone_sel))");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName like :lV81Residentwwds_16_tfcustomerlocationname)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ! ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName = ( :AV82Residentwwds_17_tfcustomerlocationname_sel))");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerLocationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentPhone";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P002D8( IGxContext context ,
                                             string AV66Residentwwds_1_filterfulltext ,
                                             short AV67Residentwwds_2_tfresidentid ,
                                             short AV68Residentwwds_3_tfresidentid_to ,
                                             string AV70Residentwwds_5_tfresidentbsnnumber_sel ,
                                             string AV69Residentwwds_4_tfresidentbsnnumber ,
                                             string AV72Residentwwds_7_tfresidentgivenname_sel ,
                                             string AV71Residentwwds_6_tfresidentgivenname ,
                                             string AV74Residentwwds_9_tfresidentlastname_sel ,
                                             string AV73Residentwwds_8_tfresidentlastname ,
                                             string AV76Residentwwds_11_tfresidentemail_sel ,
                                             string AV75Residentwwds_10_tfresidentemail ,
                                             string AV78Residentwwds_13_tfresidentaddress_sel ,
                                             string AV77Residentwwds_12_tfresidentaddress ,
                                             string AV80Residentwwds_15_tfresidentphone_sel ,
                                             string AV79Residentwwds_14_tfresidentphone ,
                                             string AV82Residentwwds_17_tfcustomerlocationname_sel ,
                                             string AV81Residentwwds_16_tfcustomerlocationname ,
                                             short A31ResidentId ,
                                             string A40ResidentBsnNumber ,
                                             string A33ResidentGivenName ,
                                             string A34ResidentLastName ,
                                             string A36ResidentEmail ,
                                             string A37ResidentAddress ,
                                             string A38ResidentPhone ,
                                             string A134CustomerLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[24];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.CustomerId, T1.CustomerLocationId, T2.CustomerLocationName, T1.ResidentId, T1.ResidentPhone, T1.ResidentAddress, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentBsnNumber FROM (Resident T1 INNER JOIN CustomerLocation T2 ON T2.CustomerId = T1.CustomerId AND T2.CustomerLocationId = T1.CustomerLocationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.ResidentId,'9999'), 2) like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentGivenName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentAddress like '%' || :lV66Residentwwds_1_filterfulltext) or ( T1.ResidentPhone like '%' || :lV66Residentwwds_1_filterfulltext) or ( T2.CustomerLocationName like '%' || :lV66Residentwwds_1_filterfulltext))");
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
         if ( ! (0==AV67Residentwwds_2_tfresidentid) )
         {
            AddWhere(sWhereString, "(T1.ResidentId >= :AV67Residentwwds_2_tfresidentid)");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( ! (0==AV68Residentwwds_3_tfresidentid_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentId <= :AV68Residentwwds_3_tfresidentid_to)");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Residentwwds_4_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV69Residentwwds_4_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Residentwwds_5_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV70Residentwwds_5_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Residentwwds_5_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Residentwwds_6_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV71Residentwwds_6_tfresidentgivenname)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Residentwwds_7_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV72Residentwwds_7_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Residentwwds_7_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Residentwwds_8_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV73Residentwwds_8_tfresidentlastname)");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Residentwwds_9_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV74Residentwwds_9_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( StringUtil.StrCmp(AV74Residentwwds_9_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Residentwwds_10_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV75Residentwwds_10_tfresidentemail)");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Residentwwds_11_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV76Residentwwds_11_tfresidentemail_sel))");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Residentwwds_11_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Residentwwds_12_tfresidentaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress like :lV77Residentwwds_12_tfresidentaddress)");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Residentwwds_13_tfresidentaddress_sel)) && ! ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress = ( :AV78Residentwwds_13_tfresidentaddress_sel))");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Residentwwds_13_tfresidentaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentAddress IS NULL or (char_length(trim(trailing ' ' from T1.ResidentAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Residentwwds_14_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV79Residentwwds_14_tfresidentphone)");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Residentwwds_15_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV80Residentwwds_15_tfresidentphone_sel))");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Residentwwds_15_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone IS NULL or (char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Residentwwds_16_tfcustomerlocationname)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName like :lV81Residentwwds_16_tfcustomerlocationname)");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Residentwwds_17_tfcustomerlocationname_sel)) && ! ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerLocationName = ( :AV82Residentwwds_17_tfcustomerlocationname_sel))");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( StringUtil.StrCmp(AV82Residentwwds_17_tfcustomerlocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CustomerLocationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.CustomerLocationName";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002D2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 1 :
                     return conditional_P002D3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 2 :
                     return conditional_P002D4(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 3 :
                     return conditional_P002D5(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 4 :
                     return conditional_P002D6(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 5 :
                     return conditional_P002D7(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 6 :
                     return conditional_P002D8(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002D2;
          prmP002D2 = new Object[] {
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV67Residentwwds_2_tfresidentid",GXType.Int16,4,0) ,
          new ParDef("AV68Residentwwds_3_tfresidentid_to",GXType.Int16,4,0) ,
          new ParDef("lV69Residentwwds_4_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_5_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_6_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV72Residentwwds_7_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Residentwwds_8_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV74Residentwwds_9_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV75Residentwwds_10_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Residentwwds_11_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Residentwwds_12_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV78Residentwwds_13_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV79Residentwwds_14_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV80Residentwwds_15_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV81Residentwwds_16_tfcustomerlocationname",GXType.VarChar,40,0) ,
          new ParDef("AV82Residentwwds_17_tfcustomerlocationname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D3;
          prmP002D3 = new Object[] {
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV67Residentwwds_2_tfresidentid",GXType.Int16,4,0) ,
          new ParDef("AV68Residentwwds_3_tfresidentid_to",GXType.Int16,4,0) ,
          new ParDef("lV69Residentwwds_4_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_5_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_6_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV72Residentwwds_7_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Residentwwds_8_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV74Residentwwds_9_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV75Residentwwds_10_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Residentwwds_11_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Residentwwds_12_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV78Residentwwds_13_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV79Residentwwds_14_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV80Residentwwds_15_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV81Residentwwds_16_tfcustomerlocationname",GXType.VarChar,40,0) ,
          new ParDef("AV82Residentwwds_17_tfcustomerlocationname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D4;
          prmP002D4 = new Object[] {
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV67Residentwwds_2_tfresidentid",GXType.Int16,4,0) ,
          new ParDef("AV68Residentwwds_3_tfresidentid_to",GXType.Int16,4,0) ,
          new ParDef("lV69Residentwwds_4_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_5_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_6_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV72Residentwwds_7_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Residentwwds_8_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV74Residentwwds_9_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV75Residentwwds_10_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Residentwwds_11_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Residentwwds_12_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV78Residentwwds_13_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV79Residentwwds_14_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV80Residentwwds_15_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV81Residentwwds_16_tfcustomerlocationname",GXType.VarChar,40,0) ,
          new ParDef("AV82Residentwwds_17_tfcustomerlocationname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D5;
          prmP002D5 = new Object[] {
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV67Residentwwds_2_tfresidentid",GXType.Int16,4,0) ,
          new ParDef("AV68Residentwwds_3_tfresidentid_to",GXType.Int16,4,0) ,
          new ParDef("lV69Residentwwds_4_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_5_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_6_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV72Residentwwds_7_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Residentwwds_8_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV74Residentwwds_9_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV75Residentwwds_10_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Residentwwds_11_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Residentwwds_12_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV78Residentwwds_13_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV79Residentwwds_14_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV80Residentwwds_15_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV81Residentwwds_16_tfcustomerlocationname",GXType.VarChar,40,0) ,
          new ParDef("AV82Residentwwds_17_tfcustomerlocationname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D6;
          prmP002D6 = new Object[] {
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV67Residentwwds_2_tfresidentid",GXType.Int16,4,0) ,
          new ParDef("AV68Residentwwds_3_tfresidentid_to",GXType.Int16,4,0) ,
          new ParDef("lV69Residentwwds_4_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_5_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_6_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV72Residentwwds_7_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Residentwwds_8_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV74Residentwwds_9_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV75Residentwwds_10_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Residentwwds_11_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Residentwwds_12_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV78Residentwwds_13_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV79Residentwwds_14_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV80Residentwwds_15_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV81Residentwwds_16_tfcustomerlocationname",GXType.VarChar,40,0) ,
          new ParDef("AV82Residentwwds_17_tfcustomerlocationname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D7;
          prmP002D7 = new Object[] {
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV67Residentwwds_2_tfresidentid",GXType.Int16,4,0) ,
          new ParDef("AV68Residentwwds_3_tfresidentid_to",GXType.Int16,4,0) ,
          new ParDef("lV69Residentwwds_4_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_5_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_6_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV72Residentwwds_7_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Residentwwds_8_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV74Residentwwds_9_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV75Residentwwds_10_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Residentwwds_11_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Residentwwds_12_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV78Residentwwds_13_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV79Residentwwds_14_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV80Residentwwds_15_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV81Residentwwds_16_tfcustomerlocationname",GXType.VarChar,40,0) ,
          new ParDef("AV82Residentwwds_17_tfcustomerlocationname_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002D8;
          prmP002D8 = new Object[] {
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV67Residentwwds_2_tfresidentid",GXType.Int16,4,0) ,
          new ParDef("AV68Residentwwds_3_tfresidentid_to",GXType.Int16,4,0) ,
          new ParDef("lV69Residentwwds_4_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV70Residentwwds_5_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV71Residentwwds_6_tfresidentgivenname",GXType.VarChar,40,0) ,
          new ParDef("AV72Residentwwds_7_tfresidentgivenname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV73Residentwwds_8_tfresidentlastname",GXType.VarChar,40,0) ,
          new ParDef("AV74Residentwwds_9_tfresidentlastname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV75Residentwwds_10_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV76Residentwwds_11_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV77Residentwwds_12_tfresidentaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV78Residentwwds_13_tfresidentaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV79Residentwwds_14_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV80Residentwwds_15_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("lV81Residentwwds_16_tfcustomerlocationname",GXType.VarChar,40,0) ,
          new ParDef("AV82Residentwwds_17_tfcustomerlocationname_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002D8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D8,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                return;
       }
    }

 }

}
