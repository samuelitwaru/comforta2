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
   public class supplier_genwwgetfilterdata : GXProcedure
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
            return "supplier_genww_Services_Execute" ;
         }

      }

      public supplier_genwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supplier_genwwgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28MaxItems = 10;
         AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
         AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIER_GENCOMPANYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_GENCOMPANYNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIER_GENCONTACTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_GENCONTACTNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIER_GENCONTACTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_GENCONTACTPHONEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIER_GENVISITINGADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_GENVISITINGADDRESSOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_SUPPLIER_GENPOSTALADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_GENPOSTALADDRESSOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("Supplier_GenWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Supplier_GenWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("Supplier_GenWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCOMPANYNAME") == 0 )
            {
               AV15TFSupplier_GenCompanyName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCOMPANYNAME_SEL") == 0 )
            {
               AV16TFSupplier_GenCompanyName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCONTACTNAME") == 0 )
            {
               AV21TFSupplier_GenContactName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCONTACTNAME_SEL") == 0 )
            {
               AV22TFSupplier_GenContactName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCONTACTPHONE") == 0 )
            {
               AV23TFSupplier_GenContactPhone = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCONTACTPHONE_SEL") == 0 )
            {
               AV24TFSupplier_GenContactPhone_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENVISITINGADDRESS") == 0 )
            {
               AV17TFSupplier_GenVisitingAddress = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENVISITINGADDRESS_SEL") == 0 )
            {
               AV18TFSupplier_GenVisitingAddress_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENPOSTALADDRESS") == 0 )
            {
               AV19TFSupplier_GenPostalAddress = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENPOSTALADDRESS_SEL") == 0 )
            {
               AV20TFSupplier_GenPostalAddress_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIER_GENCOMPANYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFSupplier_GenCompanyName = AV25SearchTxt;
         AV16TFSupplier_GenCompanyName_Sel = "";
         AV50Supplier_genwwds_1_filterfulltext = AV47FilterFullText;
         AV51Supplier_genwwds_2_tfsupplier_gencompanyname = AV15TFSupplier_GenCompanyName;
         AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV16TFSupplier_GenCompanyName_Sel;
         AV53Supplier_genwwds_4_tfsupplier_gencontactname = AV21TFSupplier_GenContactName;
         AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV22TFSupplier_GenContactName_Sel;
         AV55Supplier_genwwds_6_tfsupplier_gencontactphone = AV23TFSupplier_GenContactPhone;
         AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV24TFSupplier_GenContactPhone_Sel;
         AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV17TFSupplier_GenVisitingAddress;
         AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV18TFSupplier_GenVisitingAddress_Sel;
         AV59Supplier_genwwds_10_tfsupplier_genpostaladdress = AV19TFSupplier_GenPostalAddress;
         AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV20TFSupplier_GenPostalAddress_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Supplier_genwwds_1_filterfulltext ,
                                              AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                              AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                              AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                              AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                              AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                              AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                              AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                              AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                              AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                              AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                              A66Supplier_GenCompanyName ,
                                              A69Supplier_GenContactName ,
                                              A70Supplier_GenContactPhone ,
                                              A67Supplier_GenVisitingAddress ,
                                              A68Supplier_GenPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV51Supplier_genwwds_2_tfsupplier_gencompanyname = StringUtil.Concat( StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname), "%", "");
         lV53Supplier_genwwds_4_tfsupplier_gencontactname = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname), "%", "");
         lV55Supplier_genwwds_6_tfsupplier_gencontactphone = StringUtil.PadR( StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone), 20, "%");
         lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress), "%", "");
         lV59Supplier_genwwds_10_tfsupplier_genpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress), "%", "");
         /* Using cursor P002H2 */
         pr_default.execute(0, new Object[] {lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV51Supplier_genwwds_2_tfsupplier_gencompanyname, AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, lV53Supplier_genwwds_4_tfsupplier_gencontactname, AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, lV55Supplier_genwwds_6_tfsupplier_gencontactphone, AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress, AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, lV59Supplier_genwwds_10_tfsupplier_genpostaladdress, AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2H2 = false;
            A66Supplier_GenCompanyName = P002H2_A66Supplier_GenCompanyName[0];
            A68Supplier_GenPostalAddress = P002H2_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = P002H2_n68Supplier_GenPostalAddress[0];
            A67Supplier_GenVisitingAddress = P002H2_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = P002H2_n67Supplier_GenVisitingAddress[0];
            A70Supplier_GenContactPhone = P002H2_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = P002H2_n70Supplier_GenContactPhone[0];
            A69Supplier_GenContactName = P002H2_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = P002H2_n69Supplier_GenContactName[0];
            A64Supplier_GenId = P002H2_A64Supplier_GenId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002H2_A66Supplier_GenCompanyName[0], A66Supplier_GenCompanyName) == 0 ) )
            {
               BRK2H2 = false;
               A64Supplier_GenId = P002H2_A64Supplier_GenId[0];
               AV35count = (long)(AV35count+1);
               BRK2H2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A66Supplier_GenCompanyName)) ? "<#Empty#>" : A66Supplier_GenCompanyName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK2H2 )
            {
               BRK2H2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSUPPLIER_GENCONTACTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV21TFSupplier_GenContactName = AV25SearchTxt;
         AV22TFSupplier_GenContactName_Sel = "";
         AV50Supplier_genwwds_1_filterfulltext = AV47FilterFullText;
         AV51Supplier_genwwds_2_tfsupplier_gencompanyname = AV15TFSupplier_GenCompanyName;
         AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV16TFSupplier_GenCompanyName_Sel;
         AV53Supplier_genwwds_4_tfsupplier_gencontactname = AV21TFSupplier_GenContactName;
         AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV22TFSupplier_GenContactName_Sel;
         AV55Supplier_genwwds_6_tfsupplier_gencontactphone = AV23TFSupplier_GenContactPhone;
         AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV24TFSupplier_GenContactPhone_Sel;
         AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV17TFSupplier_GenVisitingAddress;
         AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV18TFSupplier_GenVisitingAddress_Sel;
         AV59Supplier_genwwds_10_tfsupplier_genpostaladdress = AV19TFSupplier_GenPostalAddress;
         AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV20TFSupplier_GenPostalAddress_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50Supplier_genwwds_1_filterfulltext ,
                                              AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                              AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                              AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                              AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                              AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                              AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                              AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                              AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                              AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                              AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                              A66Supplier_GenCompanyName ,
                                              A69Supplier_GenContactName ,
                                              A70Supplier_GenContactPhone ,
                                              A67Supplier_GenVisitingAddress ,
                                              A68Supplier_GenPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV51Supplier_genwwds_2_tfsupplier_gencompanyname = StringUtil.Concat( StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname), "%", "");
         lV53Supplier_genwwds_4_tfsupplier_gencontactname = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname), "%", "");
         lV55Supplier_genwwds_6_tfsupplier_gencontactphone = StringUtil.PadR( StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone), 20, "%");
         lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress), "%", "");
         lV59Supplier_genwwds_10_tfsupplier_genpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress), "%", "");
         /* Using cursor P002H3 */
         pr_default.execute(1, new Object[] {lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV51Supplier_genwwds_2_tfsupplier_gencompanyname, AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, lV53Supplier_genwwds_4_tfsupplier_gencontactname, AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, lV55Supplier_genwwds_6_tfsupplier_gencontactphone, AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress, AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, lV59Supplier_genwwds_10_tfsupplier_genpostaladdress, AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2H4 = false;
            A69Supplier_GenContactName = P002H3_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = P002H3_n69Supplier_GenContactName[0];
            A68Supplier_GenPostalAddress = P002H3_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = P002H3_n68Supplier_GenPostalAddress[0];
            A67Supplier_GenVisitingAddress = P002H3_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = P002H3_n67Supplier_GenVisitingAddress[0];
            A70Supplier_GenContactPhone = P002H3_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = P002H3_n70Supplier_GenContactPhone[0];
            A66Supplier_GenCompanyName = P002H3_A66Supplier_GenCompanyName[0];
            A64Supplier_GenId = P002H3_A64Supplier_GenId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002H3_A69Supplier_GenContactName[0], A69Supplier_GenContactName) == 0 ) )
            {
               BRK2H4 = false;
               A64Supplier_GenId = P002H3_A64Supplier_GenId[0];
               AV35count = (long)(AV35count+1);
               BRK2H4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A69Supplier_GenContactName)) ? "<#Empty#>" : A69Supplier_GenContactName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK2H4 )
            {
               BRK2H4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSUPPLIER_GENCONTACTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV23TFSupplier_GenContactPhone = AV25SearchTxt;
         AV24TFSupplier_GenContactPhone_Sel = "";
         AV50Supplier_genwwds_1_filterfulltext = AV47FilterFullText;
         AV51Supplier_genwwds_2_tfsupplier_gencompanyname = AV15TFSupplier_GenCompanyName;
         AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV16TFSupplier_GenCompanyName_Sel;
         AV53Supplier_genwwds_4_tfsupplier_gencontactname = AV21TFSupplier_GenContactName;
         AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV22TFSupplier_GenContactName_Sel;
         AV55Supplier_genwwds_6_tfsupplier_gencontactphone = AV23TFSupplier_GenContactPhone;
         AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV24TFSupplier_GenContactPhone_Sel;
         AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV17TFSupplier_GenVisitingAddress;
         AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV18TFSupplier_GenVisitingAddress_Sel;
         AV59Supplier_genwwds_10_tfsupplier_genpostaladdress = AV19TFSupplier_GenPostalAddress;
         AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV20TFSupplier_GenPostalAddress_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV50Supplier_genwwds_1_filterfulltext ,
                                              AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                              AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                              AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                              AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                              AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                              AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                              AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                              AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                              AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                              AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                              A66Supplier_GenCompanyName ,
                                              A69Supplier_GenContactName ,
                                              A70Supplier_GenContactPhone ,
                                              A67Supplier_GenVisitingAddress ,
                                              A68Supplier_GenPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV51Supplier_genwwds_2_tfsupplier_gencompanyname = StringUtil.Concat( StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname), "%", "");
         lV53Supplier_genwwds_4_tfsupplier_gencontactname = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname), "%", "");
         lV55Supplier_genwwds_6_tfsupplier_gencontactphone = StringUtil.PadR( StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone), 20, "%");
         lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress), "%", "");
         lV59Supplier_genwwds_10_tfsupplier_genpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress), "%", "");
         /* Using cursor P002H4 */
         pr_default.execute(2, new Object[] {lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV51Supplier_genwwds_2_tfsupplier_gencompanyname, AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, lV53Supplier_genwwds_4_tfsupplier_gencontactname, AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, lV55Supplier_genwwds_6_tfsupplier_gencontactphone, AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress, AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, lV59Supplier_genwwds_10_tfsupplier_genpostaladdress, AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2H6 = false;
            A70Supplier_GenContactPhone = P002H4_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = P002H4_n70Supplier_GenContactPhone[0];
            A68Supplier_GenPostalAddress = P002H4_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = P002H4_n68Supplier_GenPostalAddress[0];
            A67Supplier_GenVisitingAddress = P002H4_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = P002H4_n67Supplier_GenVisitingAddress[0];
            A69Supplier_GenContactName = P002H4_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = P002H4_n69Supplier_GenContactName[0];
            A66Supplier_GenCompanyName = P002H4_A66Supplier_GenCompanyName[0];
            A64Supplier_GenId = P002H4_A64Supplier_GenId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002H4_A70Supplier_GenContactPhone[0], A70Supplier_GenContactPhone) == 0 ) )
            {
               BRK2H6 = false;
               A64Supplier_GenId = P002H4_A64Supplier_GenId[0];
               AV35count = (long)(AV35count+1);
               BRK2H6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A70Supplier_GenContactPhone)) ? "<#Empty#>" : A70Supplier_GenContactPhone);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK2H6 )
            {
               BRK2H6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSUPPLIER_GENVISITINGADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV17TFSupplier_GenVisitingAddress = AV25SearchTxt;
         AV18TFSupplier_GenVisitingAddress_Sel = "";
         AV50Supplier_genwwds_1_filterfulltext = AV47FilterFullText;
         AV51Supplier_genwwds_2_tfsupplier_gencompanyname = AV15TFSupplier_GenCompanyName;
         AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV16TFSupplier_GenCompanyName_Sel;
         AV53Supplier_genwwds_4_tfsupplier_gencontactname = AV21TFSupplier_GenContactName;
         AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV22TFSupplier_GenContactName_Sel;
         AV55Supplier_genwwds_6_tfsupplier_gencontactphone = AV23TFSupplier_GenContactPhone;
         AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV24TFSupplier_GenContactPhone_Sel;
         AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV17TFSupplier_GenVisitingAddress;
         AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV18TFSupplier_GenVisitingAddress_Sel;
         AV59Supplier_genwwds_10_tfsupplier_genpostaladdress = AV19TFSupplier_GenPostalAddress;
         AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV20TFSupplier_GenPostalAddress_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV50Supplier_genwwds_1_filterfulltext ,
                                              AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                              AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                              AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                              AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                              AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                              AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                              AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                              AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                              AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                              AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                              A66Supplier_GenCompanyName ,
                                              A69Supplier_GenContactName ,
                                              A70Supplier_GenContactPhone ,
                                              A67Supplier_GenVisitingAddress ,
                                              A68Supplier_GenPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV51Supplier_genwwds_2_tfsupplier_gencompanyname = StringUtil.Concat( StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname), "%", "");
         lV53Supplier_genwwds_4_tfsupplier_gencontactname = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname), "%", "");
         lV55Supplier_genwwds_6_tfsupplier_gencontactphone = StringUtil.PadR( StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone), 20, "%");
         lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress), "%", "");
         lV59Supplier_genwwds_10_tfsupplier_genpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress), "%", "");
         /* Using cursor P002H5 */
         pr_default.execute(3, new Object[] {lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV51Supplier_genwwds_2_tfsupplier_gencompanyname, AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, lV53Supplier_genwwds_4_tfsupplier_gencontactname, AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, lV55Supplier_genwwds_6_tfsupplier_gencontactphone, AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress, AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, lV59Supplier_genwwds_10_tfsupplier_genpostaladdress, AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK2H8 = false;
            A67Supplier_GenVisitingAddress = P002H5_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = P002H5_n67Supplier_GenVisitingAddress[0];
            A68Supplier_GenPostalAddress = P002H5_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = P002H5_n68Supplier_GenPostalAddress[0];
            A70Supplier_GenContactPhone = P002H5_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = P002H5_n70Supplier_GenContactPhone[0];
            A69Supplier_GenContactName = P002H5_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = P002H5_n69Supplier_GenContactName[0];
            A66Supplier_GenCompanyName = P002H5_A66Supplier_GenCompanyName[0];
            A64Supplier_GenId = P002H5_A64Supplier_GenId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P002H5_A67Supplier_GenVisitingAddress[0], A67Supplier_GenVisitingAddress) == 0 ) )
            {
               BRK2H8 = false;
               A64Supplier_GenId = P002H5_A64Supplier_GenId[0];
               AV35count = (long)(AV35count+1);
               BRK2H8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A67Supplier_GenVisitingAddress)) ? "<#Empty#>" : A67Supplier_GenVisitingAddress);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK2H8 )
            {
               BRK2H8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSUPPLIER_GENPOSTALADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV19TFSupplier_GenPostalAddress = AV25SearchTxt;
         AV20TFSupplier_GenPostalAddress_Sel = "";
         AV50Supplier_genwwds_1_filterfulltext = AV47FilterFullText;
         AV51Supplier_genwwds_2_tfsupplier_gencompanyname = AV15TFSupplier_GenCompanyName;
         AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV16TFSupplier_GenCompanyName_Sel;
         AV53Supplier_genwwds_4_tfsupplier_gencontactname = AV21TFSupplier_GenContactName;
         AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV22TFSupplier_GenContactName_Sel;
         AV55Supplier_genwwds_6_tfsupplier_gencontactphone = AV23TFSupplier_GenContactPhone;
         AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV24TFSupplier_GenContactPhone_Sel;
         AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV17TFSupplier_GenVisitingAddress;
         AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV18TFSupplier_GenVisitingAddress_Sel;
         AV59Supplier_genwwds_10_tfsupplier_genpostaladdress = AV19TFSupplier_GenPostalAddress;
         AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV20TFSupplier_GenPostalAddress_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV50Supplier_genwwds_1_filterfulltext ,
                                              AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                              AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                              AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                              AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                              AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                              AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                              AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                              AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                              AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                              AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                              A66Supplier_GenCompanyName ,
                                              A69Supplier_GenContactName ,
                                              A70Supplier_GenContactPhone ,
                                              A67Supplier_GenVisitingAddress ,
                                              A68Supplier_GenPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV50Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext), "%", "");
         lV51Supplier_genwwds_2_tfsupplier_gencompanyname = StringUtil.Concat( StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname), "%", "");
         lV53Supplier_genwwds_4_tfsupplier_gencontactname = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname), "%", "");
         lV55Supplier_genwwds_6_tfsupplier_gencontactphone = StringUtil.PadR( StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone), 20, "%");
         lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress), "%", "");
         lV59Supplier_genwwds_10_tfsupplier_genpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress), "%", "");
         /* Using cursor P002H6 */
         pr_default.execute(4, new Object[] {lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV50Supplier_genwwds_1_filterfulltext, lV51Supplier_genwwds_2_tfsupplier_gencompanyname, AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, lV53Supplier_genwwds_4_tfsupplier_gencontactname, AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, lV55Supplier_genwwds_6_tfsupplier_gencontactphone, AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress, AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, lV59Supplier_genwwds_10_tfsupplier_genpostaladdress, AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK2H10 = false;
            A68Supplier_GenPostalAddress = P002H6_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = P002H6_n68Supplier_GenPostalAddress[0];
            A67Supplier_GenVisitingAddress = P002H6_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = P002H6_n67Supplier_GenVisitingAddress[0];
            A70Supplier_GenContactPhone = P002H6_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = P002H6_n70Supplier_GenContactPhone[0];
            A69Supplier_GenContactName = P002H6_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = P002H6_n69Supplier_GenContactName[0];
            A66Supplier_GenCompanyName = P002H6_A66Supplier_GenCompanyName[0];
            A64Supplier_GenId = P002H6_A64Supplier_GenId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P002H6_A68Supplier_GenPostalAddress[0], A68Supplier_GenPostalAddress) == 0 ) )
            {
               BRK2H10 = false;
               A64Supplier_GenId = P002H6_A64Supplier_GenId[0];
               AV35count = (long)(AV35count+1);
               BRK2H10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A68Supplier_GenPostalAddress)) ? "<#Empty#>" : A68Supplier_GenPostalAddress);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK2H10 )
            {
               BRK2H10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV15TFSupplier_GenCompanyName = "";
         AV16TFSupplier_GenCompanyName_Sel = "";
         AV21TFSupplier_GenContactName = "";
         AV22TFSupplier_GenContactName_Sel = "";
         AV23TFSupplier_GenContactPhone = "";
         AV24TFSupplier_GenContactPhone_Sel = "";
         AV17TFSupplier_GenVisitingAddress = "";
         AV18TFSupplier_GenVisitingAddress_Sel = "";
         AV19TFSupplier_GenPostalAddress = "";
         AV20TFSupplier_GenPostalAddress_Sel = "";
         AV50Supplier_genwwds_1_filterfulltext = "";
         AV51Supplier_genwwds_2_tfsupplier_gencompanyname = "";
         AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel = "";
         AV53Supplier_genwwds_4_tfsupplier_gencontactname = "";
         AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel = "";
         AV55Supplier_genwwds_6_tfsupplier_gencontactphone = "";
         AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel = "";
         AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = "";
         AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = "";
         AV59Supplier_genwwds_10_tfsupplier_genpostaladdress = "";
         AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = "";
         lV50Supplier_genwwds_1_filterfulltext = "";
         lV51Supplier_genwwds_2_tfsupplier_gencompanyname = "";
         lV53Supplier_genwwds_4_tfsupplier_gencontactname = "";
         lV55Supplier_genwwds_6_tfsupplier_gencontactphone = "";
         lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress = "";
         lV59Supplier_genwwds_10_tfsupplier_genpostaladdress = "";
         A66Supplier_GenCompanyName = "";
         A69Supplier_GenContactName = "";
         A70Supplier_GenContactPhone = "";
         A67Supplier_GenVisitingAddress = "";
         A68Supplier_GenPostalAddress = "";
         P002H2_A66Supplier_GenCompanyName = new string[] {""} ;
         P002H2_A68Supplier_GenPostalAddress = new string[] {""} ;
         P002H2_n68Supplier_GenPostalAddress = new bool[] {false} ;
         P002H2_A67Supplier_GenVisitingAddress = new string[] {""} ;
         P002H2_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         P002H2_A70Supplier_GenContactPhone = new string[] {""} ;
         P002H2_n70Supplier_GenContactPhone = new bool[] {false} ;
         P002H2_A69Supplier_GenContactName = new string[] {""} ;
         P002H2_n69Supplier_GenContactName = new bool[] {false} ;
         P002H2_A64Supplier_GenId = new short[1] ;
         AV30Option = "";
         P002H3_A69Supplier_GenContactName = new string[] {""} ;
         P002H3_n69Supplier_GenContactName = new bool[] {false} ;
         P002H3_A68Supplier_GenPostalAddress = new string[] {""} ;
         P002H3_n68Supplier_GenPostalAddress = new bool[] {false} ;
         P002H3_A67Supplier_GenVisitingAddress = new string[] {""} ;
         P002H3_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         P002H3_A70Supplier_GenContactPhone = new string[] {""} ;
         P002H3_n70Supplier_GenContactPhone = new bool[] {false} ;
         P002H3_A66Supplier_GenCompanyName = new string[] {""} ;
         P002H3_A64Supplier_GenId = new short[1] ;
         P002H4_A70Supplier_GenContactPhone = new string[] {""} ;
         P002H4_n70Supplier_GenContactPhone = new bool[] {false} ;
         P002H4_A68Supplier_GenPostalAddress = new string[] {""} ;
         P002H4_n68Supplier_GenPostalAddress = new bool[] {false} ;
         P002H4_A67Supplier_GenVisitingAddress = new string[] {""} ;
         P002H4_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         P002H4_A69Supplier_GenContactName = new string[] {""} ;
         P002H4_n69Supplier_GenContactName = new bool[] {false} ;
         P002H4_A66Supplier_GenCompanyName = new string[] {""} ;
         P002H4_A64Supplier_GenId = new short[1] ;
         P002H5_A67Supplier_GenVisitingAddress = new string[] {""} ;
         P002H5_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         P002H5_A68Supplier_GenPostalAddress = new string[] {""} ;
         P002H5_n68Supplier_GenPostalAddress = new bool[] {false} ;
         P002H5_A70Supplier_GenContactPhone = new string[] {""} ;
         P002H5_n70Supplier_GenContactPhone = new bool[] {false} ;
         P002H5_A69Supplier_GenContactName = new string[] {""} ;
         P002H5_n69Supplier_GenContactName = new bool[] {false} ;
         P002H5_A66Supplier_GenCompanyName = new string[] {""} ;
         P002H5_A64Supplier_GenId = new short[1] ;
         P002H6_A68Supplier_GenPostalAddress = new string[] {""} ;
         P002H6_n68Supplier_GenPostalAddress = new bool[] {false} ;
         P002H6_A67Supplier_GenVisitingAddress = new string[] {""} ;
         P002H6_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         P002H6_A70Supplier_GenContactPhone = new string[] {""} ;
         P002H6_n70Supplier_GenContactPhone = new bool[] {false} ;
         P002H6_A69Supplier_GenContactName = new string[] {""} ;
         P002H6_n69Supplier_GenContactName = new bool[] {false} ;
         P002H6_A66Supplier_GenCompanyName = new string[] {""} ;
         P002H6_A64Supplier_GenId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_genwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002H2_A66Supplier_GenCompanyName, P002H2_A68Supplier_GenPostalAddress, P002H2_n68Supplier_GenPostalAddress, P002H2_A67Supplier_GenVisitingAddress, P002H2_n67Supplier_GenVisitingAddress, P002H2_A70Supplier_GenContactPhone, P002H2_n70Supplier_GenContactPhone, P002H2_A69Supplier_GenContactName, P002H2_n69Supplier_GenContactName, P002H2_A64Supplier_GenId
               }
               , new Object[] {
               P002H3_A69Supplier_GenContactName, P002H3_n69Supplier_GenContactName, P002H3_A68Supplier_GenPostalAddress, P002H3_n68Supplier_GenPostalAddress, P002H3_A67Supplier_GenVisitingAddress, P002H3_n67Supplier_GenVisitingAddress, P002H3_A70Supplier_GenContactPhone, P002H3_n70Supplier_GenContactPhone, P002H3_A66Supplier_GenCompanyName, P002H3_A64Supplier_GenId
               }
               , new Object[] {
               P002H4_A70Supplier_GenContactPhone, P002H4_n70Supplier_GenContactPhone, P002H4_A68Supplier_GenPostalAddress, P002H4_n68Supplier_GenPostalAddress, P002H4_A67Supplier_GenVisitingAddress, P002H4_n67Supplier_GenVisitingAddress, P002H4_A69Supplier_GenContactName, P002H4_n69Supplier_GenContactName, P002H4_A66Supplier_GenCompanyName, P002H4_A64Supplier_GenId
               }
               , new Object[] {
               P002H5_A67Supplier_GenVisitingAddress, P002H5_n67Supplier_GenVisitingAddress, P002H5_A68Supplier_GenPostalAddress, P002H5_n68Supplier_GenPostalAddress, P002H5_A70Supplier_GenContactPhone, P002H5_n70Supplier_GenContactPhone, P002H5_A69Supplier_GenContactName, P002H5_n69Supplier_GenContactName, P002H5_A66Supplier_GenCompanyName, P002H5_A64Supplier_GenId
               }
               , new Object[] {
               P002H6_A68Supplier_GenPostalAddress, P002H6_n68Supplier_GenPostalAddress, P002H6_A67Supplier_GenVisitingAddress, P002H6_n67Supplier_GenVisitingAddress, P002H6_A70Supplier_GenContactPhone, P002H6_n70Supplier_GenContactPhone, P002H6_A69Supplier_GenContactName, P002H6_n69Supplier_GenContactName, P002H6_A66Supplier_GenCompanyName, P002H6_A64Supplier_GenId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short A64Supplier_GenId ;
      private int AV48GXV1 ;
      private long AV35count ;
      private string AV23TFSupplier_GenContactPhone ;
      private string AV24TFSupplier_GenContactPhone_Sel ;
      private string AV55Supplier_genwwds_6_tfsupplier_gencontactphone ;
      private string AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ;
      private string lV55Supplier_genwwds_6_tfsupplier_gencontactphone ;
      private string A70Supplier_GenContactPhone ;
      private bool returnInSub ;
      private bool BRK2H2 ;
      private bool n68Supplier_GenPostalAddress ;
      private bool n67Supplier_GenVisitingAddress ;
      private bool n70Supplier_GenContactPhone ;
      private bool n69Supplier_GenContactName ;
      private bool BRK2H4 ;
      private bool BRK2H6 ;
      private bool BRK2H8 ;
      private bool BRK2H10 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV15TFSupplier_GenCompanyName ;
      private string AV16TFSupplier_GenCompanyName_Sel ;
      private string AV21TFSupplier_GenContactName ;
      private string AV22TFSupplier_GenContactName_Sel ;
      private string AV17TFSupplier_GenVisitingAddress ;
      private string AV18TFSupplier_GenVisitingAddress_Sel ;
      private string AV19TFSupplier_GenPostalAddress ;
      private string AV20TFSupplier_GenPostalAddress_Sel ;
      private string AV50Supplier_genwwds_1_filterfulltext ;
      private string AV51Supplier_genwwds_2_tfsupplier_gencompanyname ;
      private string AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ;
      private string AV53Supplier_genwwds_4_tfsupplier_gencontactname ;
      private string AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ;
      private string AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ;
      private string AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ;
      private string AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ;
      private string AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ;
      private string lV50Supplier_genwwds_1_filterfulltext ;
      private string lV51Supplier_genwwds_2_tfsupplier_gencompanyname ;
      private string lV53Supplier_genwwds_4_tfsupplier_gencontactname ;
      private string lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ;
      private string lV59Supplier_genwwds_10_tfsupplier_genpostaladdress ;
      private string A66Supplier_GenCompanyName ;
      private string A69Supplier_GenContactName ;
      private string A67Supplier_GenVisitingAddress ;
      private string A68Supplier_GenPostalAddress ;
      private string AV30Option ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P002H2_A66Supplier_GenCompanyName ;
      private string[] P002H2_A68Supplier_GenPostalAddress ;
      private bool[] P002H2_n68Supplier_GenPostalAddress ;
      private string[] P002H2_A67Supplier_GenVisitingAddress ;
      private bool[] P002H2_n67Supplier_GenVisitingAddress ;
      private string[] P002H2_A70Supplier_GenContactPhone ;
      private bool[] P002H2_n70Supplier_GenContactPhone ;
      private string[] P002H2_A69Supplier_GenContactName ;
      private bool[] P002H2_n69Supplier_GenContactName ;
      private short[] P002H2_A64Supplier_GenId ;
      private string[] P002H3_A69Supplier_GenContactName ;
      private bool[] P002H3_n69Supplier_GenContactName ;
      private string[] P002H3_A68Supplier_GenPostalAddress ;
      private bool[] P002H3_n68Supplier_GenPostalAddress ;
      private string[] P002H3_A67Supplier_GenVisitingAddress ;
      private bool[] P002H3_n67Supplier_GenVisitingAddress ;
      private string[] P002H3_A70Supplier_GenContactPhone ;
      private bool[] P002H3_n70Supplier_GenContactPhone ;
      private string[] P002H3_A66Supplier_GenCompanyName ;
      private short[] P002H3_A64Supplier_GenId ;
      private string[] P002H4_A70Supplier_GenContactPhone ;
      private bool[] P002H4_n70Supplier_GenContactPhone ;
      private string[] P002H4_A68Supplier_GenPostalAddress ;
      private bool[] P002H4_n68Supplier_GenPostalAddress ;
      private string[] P002H4_A67Supplier_GenVisitingAddress ;
      private bool[] P002H4_n67Supplier_GenVisitingAddress ;
      private string[] P002H4_A69Supplier_GenContactName ;
      private bool[] P002H4_n69Supplier_GenContactName ;
      private string[] P002H4_A66Supplier_GenCompanyName ;
      private short[] P002H4_A64Supplier_GenId ;
      private string[] P002H5_A67Supplier_GenVisitingAddress ;
      private bool[] P002H5_n67Supplier_GenVisitingAddress ;
      private string[] P002H5_A68Supplier_GenPostalAddress ;
      private bool[] P002H5_n68Supplier_GenPostalAddress ;
      private string[] P002H5_A70Supplier_GenContactPhone ;
      private bool[] P002H5_n70Supplier_GenContactPhone ;
      private string[] P002H5_A69Supplier_GenContactName ;
      private bool[] P002H5_n69Supplier_GenContactName ;
      private string[] P002H5_A66Supplier_GenCompanyName ;
      private short[] P002H5_A64Supplier_GenId ;
      private string[] P002H6_A68Supplier_GenPostalAddress ;
      private bool[] P002H6_n68Supplier_GenPostalAddress ;
      private string[] P002H6_A67Supplier_GenVisitingAddress ;
      private bool[] P002H6_n67Supplier_GenVisitingAddress ;
      private string[] P002H6_A70Supplier_GenContactPhone ;
      private bool[] P002H6_n70Supplier_GenContactPhone ;
      private string[] P002H6_A69Supplier_GenContactName ;
      private bool[] P002H6_n69Supplier_GenContactName ;
      private string[] P002H6_A66Supplier_GenCompanyName ;
      private short[] P002H6_A64Supplier_GenId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class supplier_genwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002H2( IGxContext context ,
                                             string AV50Supplier_genwwds_1_filterfulltext ,
                                             string AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                             string AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                             string AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                             string AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                             string AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                             string AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                             string AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                             string AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                             string AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                             string AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                             string A66Supplier_GenCompanyName ,
                                             string A69Supplier_GenContactName ,
                                             string A70Supplier_GenContactPhone ,
                                             string A67Supplier_GenVisitingAddress ,
                                             string A68Supplier_GenPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Supplier_GenCompanyName, Supplier_GenPostalAddress, Supplier_GenVisitingAddress, Supplier_GenContactPhone, Supplier_GenContactName, Supplier_GenId FROM Supplier_Gen";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_GenCompanyName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactPhone like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenVisitingAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenPostalAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like :lV51Supplier_genwwds_2_tfsupplier_gencompanyname)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ! ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName = ( :AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_GenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName like :lV53Supplier_genwwds_4_tfsupplier_gencontactname)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ! ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName = ( :AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone like :lV55Supplier_genwwds_6_tfsupplier_gencontactphone)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone = ( :AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress like :lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress = ( :AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress like :lV59Supplier_genwwds_10_tfsupplier_genpostaladdress)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress = ( :AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_GenCompanyName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002H3( IGxContext context ,
                                             string AV50Supplier_genwwds_1_filterfulltext ,
                                             string AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                             string AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                             string AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                             string AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                             string AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                             string AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                             string AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                             string AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                             string AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                             string AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                             string A66Supplier_GenCompanyName ,
                                             string A69Supplier_GenContactName ,
                                             string A70Supplier_GenContactPhone ,
                                             string A67Supplier_GenVisitingAddress ,
                                             string A68Supplier_GenPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT Supplier_GenContactName, Supplier_GenPostalAddress, Supplier_GenVisitingAddress, Supplier_GenContactPhone, Supplier_GenCompanyName, Supplier_GenId FROM Supplier_Gen";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_GenCompanyName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactPhone like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenVisitingAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenPostalAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like :lV51Supplier_genwwds_2_tfsupplier_gencompanyname)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ! ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName = ( :AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_GenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName like :lV53Supplier_genwwds_4_tfsupplier_gencontactname)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ! ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName = ( :AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone like :lV55Supplier_genwwds_6_tfsupplier_gencontactphone)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone = ( :AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress like :lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress = ( :AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress like :lV59Supplier_genwwds_10_tfsupplier_genpostaladdress)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress = ( :AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_GenContactName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002H4( IGxContext context ,
                                             string AV50Supplier_genwwds_1_filterfulltext ,
                                             string AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                             string AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                             string AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                             string AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                             string AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                             string AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                             string AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                             string AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                             string AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                             string AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                             string A66Supplier_GenCompanyName ,
                                             string A69Supplier_GenContactName ,
                                             string A70Supplier_GenContactPhone ,
                                             string A67Supplier_GenVisitingAddress ,
                                             string A68Supplier_GenPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT Supplier_GenContactPhone, Supplier_GenPostalAddress, Supplier_GenVisitingAddress, Supplier_GenContactName, Supplier_GenCompanyName, Supplier_GenId FROM Supplier_Gen";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_GenCompanyName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactPhone like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenVisitingAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenPostalAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like :lV51Supplier_genwwds_2_tfsupplier_gencompanyname)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ! ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName = ( :AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_GenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName like :lV53Supplier_genwwds_4_tfsupplier_gencontactname)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ! ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName = ( :AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone like :lV55Supplier_genwwds_6_tfsupplier_gencontactphone)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone = ( :AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress like :lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress = ( :AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress like :lV59Supplier_genwwds_10_tfsupplier_genpostaladdress)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress = ( :AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_GenContactPhone";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002H5( IGxContext context ,
                                             string AV50Supplier_genwwds_1_filterfulltext ,
                                             string AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                             string AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                             string AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                             string AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                             string AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                             string AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                             string AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                             string AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                             string AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                             string AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                             string A66Supplier_GenCompanyName ,
                                             string A69Supplier_GenContactName ,
                                             string A70Supplier_GenContactPhone ,
                                             string A67Supplier_GenVisitingAddress ,
                                             string A68Supplier_GenPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT Supplier_GenVisitingAddress, Supplier_GenPostalAddress, Supplier_GenContactPhone, Supplier_GenContactName, Supplier_GenCompanyName, Supplier_GenId FROM Supplier_Gen";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_GenCompanyName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactPhone like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenVisitingAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenPostalAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like :lV51Supplier_genwwds_2_tfsupplier_gencompanyname)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ! ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName = ( :AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_GenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName like :lV53Supplier_genwwds_4_tfsupplier_gencontactname)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ! ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName = ( :AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone like :lV55Supplier_genwwds_6_tfsupplier_gencontactphone)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone = ( :AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress like :lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress = ( :AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress like :lV59Supplier_genwwds_10_tfsupplier_genpostaladdress)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress = ( :AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_GenVisitingAddress";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P002H6( IGxContext context ,
                                             string AV50Supplier_genwwds_1_filterfulltext ,
                                             string AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                             string AV51Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                             string AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                             string AV53Supplier_genwwds_4_tfsupplier_gencontactname ,
                                             string AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                             string AV55Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                             string AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                             string AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                             string AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                             string AV59Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                             string A66Supplier_GenCompanyName ,
                                             string A69Supplier_GenContactName ,
                                             string A70Supplier_GenContactPhone ,
                                             string A67Supplier_GenVisitingAddress ,
                                             string A68Supplier_GenPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[15];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT Supplier_GenPostalAddress, Supplier_GenVisitingAddress, Supplier_GenContactPhone, Supplier_GenContactName, Supplier_GenCompanyName, Supplier_GenId FROM Supplier_Gen";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Supplier_genwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_GenCompanyName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactName like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactPhone like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenVisitingAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext) or ( Supplier_GenPostalAddress like '%' || :lV50Supplier_genwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Supplier_genwwds_2_tfsupplier_gencompanyname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like :lV51Supplier_genwwds_2_tfsupplier_gencompanyname)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ! ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName = ( :AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_GenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Supplier_genwwds_4_tfsupplier_gencontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName like :lV53Supplier_genwwds_4_tfsupplier_gencontactname)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ! ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName = ( :AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_genwwds_6_tfsupplier_gencontactphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone like :lV55Supplier_genwwds_6_tfsupplier_gencontactphone)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone = ( :AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress like :lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress = ( :AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_genwwds_10_tfsupplier_genpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress like :lV59Supplier_genwwds_10_tfsupplier_genpostaladdress)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress = ( :AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_GenPostalAddress";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 1 :
                     return conditional_P002H3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 2 :
                     return conditional_P002H4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 3 :
                     return conditional_P002H5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 4 :
                     return conditional_P002H6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002H2;
          prmP002H2 = new Object[] {
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Supplier_genwwds_2_tfsupplier_gencompanyname",GXType.VarChar,40,0) ,
          new ParDef("AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV53Supplier_genwwds_4_tfsupplier_gencontactname",GXType.VarChar,40,0) ,
          new ParDef("AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV55Supplier_genwwds_6_tfsupplier_gencontactphone",GXType.Char,20,0) ,
          new ParDef("AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV59Supplier_genwwds_10_tfsupplier_genpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel",GXType.VarChar,1024,0)
          };
          Object[] prmP002H3;
          prmP002H3 = new Object[] {
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Supplier_genwwds_2_tfsupplier_gencompanyname",GXType.VarChar,40,0) ,
          new ParDef("AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV53Supplier_genwwds_4_tfsupplier_gencontactname",GXType.VarChar,40,0) ,
          new ParDef("AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV55Supplier_genwwds_6_tfsupplier_gencontactphone",GXType.Char,20,0) ,
          new ParDef("AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV59Supplier_genwwds_10_tfsupplier_genpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel",GXType.VarChar,1024,0)
          };
          Object[] prmP002H4;
          prmP002H4 = new Object[] {
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Supplier_genwwds_2_tfsupplier_gencompanyname",GXType.VarChar,40,0) ,
          new ParDef("AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV53Supplier_genwwds_4_tfsupplier_gencontactname",GXType.VarChar,40,0) ,
          new ParDef("AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV55Supplier_genwwds_6_tfsupplier_gencontactphone",GXType.Char,20,0) ,
          new ParDef("AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV59Supplier_genwwds_10_tfsupplier_genpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel",GXType.VarChar,1024,0)
          };
          Object[] prmP002H5;
          prmP002H5 = new Object[] {
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Supplier_genwwds_2_tfsupplier_gencompanyname",GXType.VarChar,40,0) ,
          new ParDef("AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV53Supplier_genwwds_4_tfsupplier_gencontactname",GXType.VarChar,40,0) ,
          new ParDef("AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV55Supplier_genwwds_6_tfsupplier_gencontactphone",GXType.Char,20,0) ,
          new ParDef("AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV59Supplier_genwwds_10_tfsupplier_genpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel",GXType.VarChar,1024,0)
          };
          Object[] prmP002H6;
          prmP002H6 = new Object[] {
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Supplier_genwwds_2_tfsupplier_gencompanyname",GXType.VarChar,40,0) ,
          new ParDef("AV52Supplier_genwwds_3_tfsupplier_gencompanyname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV53Supplier_genwwds_4_tfsupplier_gencontactname",GXType.VarChar,40,0) ,
          new ParDef("AV54Supplier_genwwds_5_tfsupplier_gencontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV55Supplier_genwwds_6_tfsupplier_gencontactphone",GXType.Char,20,0) ,
          new ParDef("AV56Supplier_genwwds_7_tfsupplier_gencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV57Supplier_genwwds_8_tfsupplier_genvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV58Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV59Supplier_genwwds_10_tfsupplier_genpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV60Supplier_genwwds_11_tfsupplier_genpostaladdress_sel",GXType.VarChar,1024,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002H4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002H5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002H6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H6,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
