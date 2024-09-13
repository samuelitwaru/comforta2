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
   public class supplier_agbwwgetfilterdata : GXProcedure
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
            return "supplier_agbww_Services_Execute" ;
         }

      }

      public supplier_agbwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supplier_agbwwgetfilterdata( IGxContext context )
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
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV50OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32MaxItems = 10;
         AV31PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV46SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV29SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? "" : StringUtil.Substring( AV46SearchTxtParms, 3, -1));
         AV30SkipItems = (short)(AV31PageIndex*AV32MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBEMAILOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBPHONEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBCONTACTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBCONTACTNAMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBVISITINGADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBVISITINGADDRESSOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_SUPPLIER_AGBPOSTALADDRESS") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIER_AGBPOSTALADDRESSOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV48OptionsJson = AV35Options.ToJSonString(false);
         AV49OptionsDescJson = AV37OptionsDesc.ToJSonString(false);
         AV50OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get("Supplier_AgbWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Supplier_AgbWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("Supplier_AgbWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNAME") == 0 )
            {
               AV15TFSupplier_AgbName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBNAME_SEL") == 0 )
            {
               AV16TFSupplier_AgbName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBEMAIL") == 0 )
            {
               AV23TFSupplier_AgbEmail = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBEMAIL_SEL") == 0 )
            {
               AV24TFSupplier_AgbEmail_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPHONE") == 0 )
            {
               AV25TFSupplier_AgbPhone = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPHONE_SEL") == 0 )
            {
               AV26TFSupplier_AgbPhone_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBCONTACTNAME") == 0 )
            {
               AV27TFSupplier_AgbContactName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBCONTACTNAME_SEL") == 0 )
            {
               AV28TFSupplier_AgbContactName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBVISITINGADDRESS") == 0 )
            {
               AV19TFSupplier_AgbVisitingAddress = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBVISITINGADDRESS_SEL") == 0 )
            {
               AV20TFSupplier_AgbVisitingAddress_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPOSTALADDRESS") == 0 )
            {
               AV21TFSupplier_AgbPostalAddress = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_AGBPOSTALADDRESS_SEL") == 0 )
            {
               AV22TFSupplier_AgbPostalAddress_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIER_AGBNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFSupplier_AgbName = AV29SearchTxt;
         AV16TFSupplier_AgbName_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV56Supplier_agbwwds_3_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV57Supplier_agbwwds_4_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              A57Supplier_AgbName ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV55Supplier_agbwwds_2_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone), 20, "%");
         lV61Supplier_agbwwds_8_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         /* Using cursor P002F2 */
         pr_default.execute(0, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV55Supplier_agbwwds_2_tfsupplier_agbname, AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, lV57Supplier_agbwwds_4_tfsupplier_agbemail, AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, lV59Supplier_agbwwds_6_tfsupplier_agbphone, AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, lV61Supplier_agbwwds_8_tfsupplier_agbcontactname, AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2F2 = false;
            A57Supplier_AgbName = P002F2_A57Supplier_AgbName[0];
            A60Supplier_AgbPostalAddress = P002F2_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F2_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F2_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F2_n59Supplier_AgbVisitingAddress[0];
            A63Supplier_AgbContactName = P002F2_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F2_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F2_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F2_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F2_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F2_n61Supplier_AgbEmail[0];
            A55Supplier_AgbId = P002F2_A55Supplier_AgbId[0];
            AV39count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002F2_A57Supplier_AgbName[0], A57Supplier_AgbName) == 0 ) )
            {
               BRK2F2 = false;
               A55Supplier_AgbId = P002F2_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A57Supplier_AgbName)) ? "<#Empty#>" : A57Supplier_AgbName);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F2 )
            {
               BRK2F2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSUPPLIER_AGBEMAILOPTIONS' Routine */
         returnInSub = false;
         AV23TFSupplier_AgbEmail = AV29SearchTxt;
         AV24TFSupplier_AgbEmail_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV56Supplier_agbwwds_3_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV57Supplier_agbwwds_4_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              A57Supplier_AgbName ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV55Supplier_agbwwds_2_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone), 20, "%");
         lV61Supplier_agbwwds_8_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         /* Using cursor P002F3 */
         pr_default.execute(1, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV55Supplier_agbwwds_2_tfsupplier_agbname, AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, lV57Supplier_agbwwds_4_tfsupplier_agbemail, AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, lV59Supplier_agbwwds_6_tfsupplier_agbphone, AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, lV61Supplier_agbwwds_8_tfsupplier_agbcontactname, AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2F4 = false;
            A61Supplier_AgbEmail = P002F3_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F3_n61Supplier_AgbEmail[0];
            A60Supplier_AgbPostalAddress = P002F3_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F3_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F3_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F3_n59Supplier_AgbVisitingAddress[0];
            A63Supplier_AgbContactName = P002F3_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F3_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F3_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F3_n62Supplier_AgbPhone[0];
            A57Supplier_AgbName = P002F3_A57Supplier_AgbName[0];
            A55Supplier_AgbId = P002F3_A55Supplier_AgbId[0];
            AV39count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002F3_A61Supplier_AgbEmail[0], A61Supplier_AgbEmail) == 0 ) )
            {
               BRK2F4 = false;
               A55Supplier_AgbId = P002F3_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A61Supplier_AgbEmail)) ? "<#Empty#>" : A61Supplier_AgbEmail);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F4 )
            {
               BRK2F4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSUPPLIER_AGBPHONEOPTIONS' Routine */
         returnInSub = false;
         AV25TFSupplier_AgbPhone = AV29SearchTxt;
         AV26TFSupplier_AgbPhone_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV56Supplier_agbwwds_3_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV57Supplier_agbwwds_4_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              A57Supplier_AgbName ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV55Supplier_agbwwds_2_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone), 20, "%");
         lV61Supplier_agbwwds_8_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         /* Using cursor P002F4 */
         pr_default.execute(2, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV55Supplier_agbwwds_2_tfsupplier_agbname, AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, lV57Supplier_agbwwds_4_tfsupplier_agbemail, AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, lV59Supplier_agbwwds_6_tfsupplier_agbphone, AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, lV61Supplier_agbwwds_8_tfsupplier_agbcontactname, AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2F6 = false;
            A62Supplier_AgbPhone = P002F4_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F4_n62Supplier_AgbPhone[0];
            A60Supplier_AgbPostalAddress = P002F4_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F4_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F4_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F4_n59Supplier_AgbVisitingAddress[0];
            A63Supplier_AgbContactName = P002F4_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F4_n63Supplier_AgbContactName[0];
            A61Supplier_AgbEmail = P002F4_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F4_n61Supplier_AgbEmail[0];
            A57Supplier_AgbName = P002F4_A57Supplier_AgbName[0];
            A55Supplier_AgbId = P002F4_A55Supplier_AgbId[0];
            AV39count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002F4_A62Supplier_AgbPhone[0], A62Supplier_AgbPhone) == 0 ) )
            {
               BRK2F6 = false;
               A55Supplier_AgbId = P002F4_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A62Supplier_AgbPhone)) ? "<#Empty#>" : A62Supplier_AgbPhone);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F6 )
            {
               BRK2F6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSUPPLIER_AGBCONTACTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV27TFSupplier_AgbContactName = AV29SearchTxt;
         AV28TFSupplier_AgbContactName_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV56Supplier_agbwwds_3_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV57Supplier_agbwwds_4_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              A57Supplier_AgbName ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV55Supplier_agbwwds_2_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone), 20, "%");
         lV61Supplier_agbwwds_8_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         /* Using cursor P002F5 */
         pr_default.execute(3, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV55Supplier_agbwwds_2_tfsupplier_agbname, AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, lV57Supplier_agbwwds_4_tfsupplier_agbemail, AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, lV59Supplier_agbwwds_6_tfsupplier_agbphone, AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, lV61Supplier_agbwwds_8_tfsupplier_agbcontactname, AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK2F8 = false;
            A63Supplier_AgbContactName = P002F5_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F5_n63Supplier_AgbContactName[0];
            A60Supplier_AgbPostalAddress = P002F5_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F5_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F5_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F5_n59Supplier_AgbVisitingAddress[0];
            A62Supplier_AgbPhone = P002F5_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F5_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F5_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F5_n61Supplier_AgbEmail[0];
            A57Supplier_AgbName = P002F5_A57Supplier_AgbName[0];
            A55Supplier_AgbId = P002F5_A55Supplier_AgbId[0];
            AV39count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P002F5_A63Supplier_AgbContactName[0], A63Supplier_AgbContactName) == 0 ) )
            {
               BRK2F8 = false;
               A55Supplier_AgbId = P002F5_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A63Supplier_AgbContactName)) ? "<#Empty#>" : A63Supplier_AgbContactName);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F8 )
            {
               BRK2F8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSUPPLIER_AGBVISITINGADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV19TFSupplier_AgbVisitingAddress = AV29SearchTxt;
         AV20TFSupplier_AgbVisitingAddress_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV56Supplier_agbwwds_3_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV57Supplier_agbwwds_4_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              A57Supplier_AgbName ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV55Supplier_agbwwds_2_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone), 20, "%");
         lV61Supplier_agbwwds_8_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         /* Using cursor P002F6 */
         pr_default.execute(4, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV55Supplier_agbwwds_2_tfsupplier_agbname, AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, lV57Supplier_agbwwds_4_tfsupplier_agbemail, AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, lV59Supplier_agbwwds_6_tfsupplier_agbphone, AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, lV61Supplier_agbwwds_8_tfsupplier_agbcontactname, AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK2F10 = false;
            A59Supplier_AgbVisitingAddress = P002F6_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F6_n59Supplier_AgbVisitingAddress[0];
            A60Supplier_AgbPostalAddress = P002F6_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F6_n60Supplier_AgbPostalAddress[0];
            A63Supplier_AgbContactName = P002F6_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F6_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F6_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F6_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F6_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F6_n61Supplier_AgbEmail[0];
            A57Supplier_AgbName = P002F6_A57Supplier_AgbName[0];
            A55Supplier_AgbId = P002F6_A55Supplier_AgbId[0];
            AV39count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P002F6_A59Supplier_AgbVisitingAddress[0], A59Supplier_AgbVisitingAddress) == 0 ) )
            {
               BRK2F10 = false;
               A55Supplier_AgbId = P002F6_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A59Supplier_AgbVisitingAddress)) ? "<#Empty#>" : A59Supplier_AgbVisitingAddress);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F10 )
            {
               BRK2F10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADSUPPLIER_AGBPOSTALADDRESSOPTIONS' Routine */
         returnInSub = false;
         AV21TFSupplier_AgbPostalAddress = AV29SearchTxt;
         AV22TFSupplier_AgbPostalAddress_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = AV51FilterFullText;
         AV55Supplier_agbwwds_2_tfsupplier_agbname = AV15TFSupplier_AgbName;
         AV56Supplier_agbwwds_3_tfsupplier_agbname_sel = AV16TFSupplier_AgbName_Sel;
         AV57Supplier_agbwwds_4_tfsupplier_agbemail = AV23TFSupplier_AgbEmail;
         AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel = AV24TFSupplier_AgbEmail_Sel;
         AV59Supplier_agbwwds_6_tfsupplier_agbphone = AV25TFSupplier_AgbPhone;
         AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel = AV26TFSupplier_AgbPhone_Sel;
         AV61Supplier_agbwwds_8_tfsupplier_agbcontactname = AV27TFSupplier_AgbContactName;
         AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel = AV28TFSupplier_AgbContactName_Sel;
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = AV19TFSupplier_AgbVisitingAddress;
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = AV20TFSupplier_AgbVisitingAddress_Sel;
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = AV21TFSupplier_AgbPostalAddress;
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = AV22TFSupplier_AgbPostalAddress_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV54Supplier_agbwwds_1_filterfulltext ,
                                              AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                              AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                              AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                              AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                              AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                              AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                              AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                              AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                              AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                              AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                              AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                              AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                              A57Supplier_AgbName ,
                                              A61Supplier_AgbEmail ,
                                              A62Supplier_AgbPhone ,
                                              A63Supplier_AgbContactName ,
                                              A59Supplier_AgbVisitingAddress ,
                                              A60Supplier_AgbPostalAddress } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV54Supplier_agbwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext), "%", "");
         lV55Supplier_agbwwds_2_tfsupplier_agbname = StringUtil.Concat( StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname), "%", "");
         lV57Supplier_agbwwds_4_tfsupplier_agbemail = StringUtil.Concat( StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail), "%", "");
         lV59Supplier_agbwwds_6_tfsupplier_agbphone = StringUtil.PadR( StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone), 20, "%");
         lV61Supplier_agbwwds_8_tfsupplier_agbcontactname = StringUtil.Concat( StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname), "%", "");
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress), "%", "");
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress), "%", "");
         /* Using cursor P002F7 */
         pr_default.execute(5, new Object[] {lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV54Supplier_agbwwds_1_filterfulltext, lV55Supplier_agbwwds_2_tfsupplier_agbname, AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, lV57Supplier_agbwwds_4_tfsupplier_agbemail, AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, lV59Supplier_agbwwds_6_tfsupplier_agbphone, AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, lV61Supplier_agbwwds_8_tfsupplier_agbcontactname, AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress, AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress, AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK2F12 = false;
            A60Supplier_AgbPostalAddress = P002F7_A60Supplier_AgbPostalAddress[0];
            n60Supplier_AgbPostalAddress = P002F7_n60Supplier_AgbPostalAddress[0];
            A59Supplier_AgbVisitingAddress = P002F7_A59Supplier_AgbVisitingAddress[0];
            n59Supplier_AgbVisitingAddress = P002F7_n59Supplier_AgbVisitingAddress[0];
            A63Supplier_AgbContactName = P002F7_A63Supplier_AgbContactName[0];
            n63Supplier_AgbContactName = P002F7_n63Supplier_AgbContactName[0];
            A62Supplier_AgbPhone = P002F7_A62Supplier_AgbPhone[0];
            n62Supplier_AgbPhone = P002F7_n62Supplier_AgbPhone[0];
            A61Supplier_AgbEmail = P002F7_A61Supplier_AgbEmail[0];
            n61Supplier_AgbEmail = P002F7_n61Supplier_AgbEmail[0];
            A57Supplier_AgbName = P002F7_A57Supplier_AgbName[0];
            A55Supplier_AgbId = P002F7_A55Supplier_AgbId[0];
            AV39count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P002F7_A60Supplier_AgbPostalAddress[0], A60Supplier_AgbPostalAddress) == 0 ) )
            {
               BRK2F12 = false;
               A55Supplier_AgbId = P002F7_A55Supplier_AgbId[0];
               AV39count = (long)(AV39count+1);
               BRK2F12 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A60Supplier_AgbPostalAddress)) ? "<#Empty#>" : A60Supplier_AgbPostalAddress);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK2F12 )
            {
               BRK2F12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
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
         AV48OptionsJson = "";
         AV49OptionsDescJson = "";
         AV50OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV37OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV29SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV15TFSupplier_AgbName = "";
         AV16TFSupplier_AgbName_Sel = "";
         AV23TFSupplier_AgbEmail = "";
         AV24TFSupplier_AgbEmail_Sel = "";
         AV25TFSupplier_AgbPhone = "";
         AV26TFSupplier_AgbPhone_Sel = "";
         AV27TFSupplier_AgbContactName = "";
         AV28TFSupplier_AgbContactName_Sel = "";
         AV19TFSupplier_AgbVisitingAddress = "";
         AV20TFSupplier_AgbVisitingAddress_Sel = "";
         AV21TFSupplier_AgbPostalAddress = "";
         AV22TFSupplier_AgbPostalAddress_Sel = "";
         AV54Supplier_agbwwds_1_filterfulltext = "";
         AV55Supplier_agbwwds_2_tfsupplier_agbname = "";
         AV56Supplier_agbwwds_3_tfsupplier_agbname_sel = "";
         AV57Supplier_agbwwds_4_tfsupplier_agbemail = "";
         AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel = "";
         AV59Supplier_agbwwds_6_tfsupplier_agbphone = "";
         AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel = "";
         AV61Supplier_agbwwds_8_tfsupplier_agbcontactname = "";
         AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel = "";
         AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = "";
         AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel = "";
         AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = "";
         AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel = "";
         lV54Supplier_agbwwds_1_filterfulltext = "";
         lV55Supplier_agbwwds_2_tfsupplier_agbname = "";
         lV57Supplier_agbwwds_4_tfsupplier_agbemail = "";
         lV59Supplier_agbwwds_6_tfsupplier_agbphone = "";
         lV61Supplier_agbwwds_8_tfsupplier_agbcontactname = "";
         lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress = "";
         lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress = "";
         A57Supplier_AgbName = "";
         A61Supplier_AgbEmail = "";
         A62Supplier_AgbPhone = "";
         A63Supplier_AgbContactName = "";
         A59Supplier_AgbVisitingAddress = "";
         A60Supplier_AgbPostalAddress = "";
         P002F2_A57Supplier_AgbName = new string[] {""} ;
         P002F2_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F2_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F2_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F2_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F2_A63Supplier_AgbContactName = new string[] {""} ;
         P002F2_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F2_A62Supplier_AgbPhone = new string[] {""} ;
         P002F2_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F2_A61Supplier_AgbEmail = new string[] {""} ;
         P002F2_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F2_A55Supplier_AgbId = new short[1] ;
         AV34Option = "";
         P002F3_A61Supplier_AgbEmail = new string[] {""} ;
         P002F3_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F3_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F3_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F3_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F3_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F3_A63Supplier_AgbContactName = new string[] {""} ;
         P002F3_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F3_A62Supplier_AgbPhone = new string[] {""} ;
         P002F3_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F3_A57Supplier_AgbName = new string[] {""} ;
         P002F3_A55Supplier_AgbId = new short[1] ;
         P002F4_A62Supplier_AgbPhone = new string[] {""} ;
         P002F4_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F4_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F4_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F4_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F4_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F4_A63Supplier_AgbContactName = new string[] {""} ;
         P002F4_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F4_A61Supplier_AgbEmail = new string[] {""} ;
         P002F4_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F4_A57Supplier_AgbName = new string[] {""} ;
         P002F4_A55Supplier_AgbId = new short[1] ;
         P002F5_A63Supplier_AgbContactName = new string[] {""} ;
         P002F5_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F5_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F5_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F5_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F5_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F5_A62Supplier_AgbPhone = new string[] {""} ;
         P002F5_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F5_A61Supplier_AgbEmail = new string[] {""} ;
         P002F5_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F5_A57Supplier_AgbName = new string[] {""} ;
         P002F5_A55Supplier_AgbId = new short[1] ;
         P002F6_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F6_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F6_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F6_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F6_A63Supplier_AgbContactName = new string[] {""} ;
         P002F6_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F6_A62Supplier_AgbPhone = new string[] {""} ;
         P002F6_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F6_A61Supplier_AgbEmail = new string[] {""} ;
         P002F6_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F6_A57Supplier_AgbName = new string[] {""} ;
         P002F6_A55Supplier_AgbId = new short[1] ;
         P002F7_A60Supplier_AgbPostalAddress = new string[] {""} ;
         P002F7_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         P002F7_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         P002F7_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         P002F7_A63Supplier_AgbContactName = new string[] {""} ;
         P002F7_n63Supplier_AgbContactName = new bool[] {false} ;
         P002F7_A62Supplier_AgbPhone = new string[] {""} ;
         P002F7_n62Supplier_AgbPhone = new bool[] {false} ;
         P002F7_A61Supplier_AgbEmail = new string[] {""} ;
         P002F7_n61Supplier_AgbEmail = new bool[] {false} ;
         P002F7_A57Supplier_AgbName = new string[] {""} ;
         P002F7_A55Supplier_AgbId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_agbwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002F2_A57Supplier_AgbName, P002F2_A60Supplier_AgbPostalAddress, P002F2_n60Supplier_AgbPostalAddress, P002F2_A59Supplier_AgbVisitingAddress, P002F2_n59Supplier_AgbVisitingAddress, P002F2_A63Supplier_AgbContactName, P002F2_n63Supplier_AgbContactName, P002F2_A62Supplier_AgbPhone, P002F2_n62Supplier_AgbPhone, P002F2_A61Supplier_AgbEmail,
               P002F2_n61Supplier_AgbEmail, P002F2_A55Supplier_AgbId
               }
               , new Object[] {
               P002F3_A61Supplier_AgbEmail, P002F3_n61Supplier_AgbEmail, P002F3_A60Supplier_AgbPostalAddress, P002F3_n60Supplier_AgbPostalAddress, P002F3_A59Supplier_AgbVisitingAddress, P002F3_n59Supplier_AgbVisitingAddress, P002F3_A63Supplier_AgbContactName, P002F3_n63Supplier_AgbContactName, P002F3_A62Supplier_AgbPhone, P002F3_n62Supplier_AgbPhone,
               P002F3_A57Supplier_AgbName, P002F3_A55Supplier_AgbId
               }
               , new Object[] {
               P002F4_A62Supplier_AgbPhone, P002F4_n62Supplier_AgbPhone, P002F4_A60Supplier_AgbPostalAddress, P002F4_n60Supplier_AgbPostalAddress, P002F4_A59Supplier_AgbVisitingAddress, P002F4_n59Supplier_AgbVisitingAddress, P002F4_A63Supplier_AgbContactName, P002F4_n63Supplier_AgbContactName, P002F4_A61Supplier_AgbEmail, P002F4_n61Supplier_AgbEmail,
               P002F4_A57Supplier_AgbName, P002F4_A55Supplier_AgbId
               }
               , new Object[] {
               P002F5_A63Supplier_AgbContactName, P002F5_n63Supplier_AgbContactName, P002F5_A60Supplier_AgbPostalAddress, P002F5_n60Supplier_AgbPostalAddress, P002F5_A59Supplier_AgbVisitingAddress, P002F5_n59Supplier_AgbVisitingAddress, P002F5_A62Supplier_AgbPhone, P002F5_n62Supplier_AgbPhone, P002F5_A61Supplier_AgbEmail, P002F5_n61Supplier_AgbEmail,
               P002F5_A57Supplier_AgbName, P002F5_A55Supplier_AgbId
               }
               , new Object[] {
               P002F6_A59Supplier_AgbVisitingAddress, P002F6_n59Supplier_AgbVisitingAddress, P002F6_A60Supplier_AgbPostalAddress, P002F6_n60Supplier_AgbPostalAddress, P002F6_A63Supplier_AgbContactName, P002F6_n63Supplier_AgbContactName, P002F6_A62Supplier_AgbPhone, P002F6_n62Supplier_AgbPhone, P002F6_A61Supplier_AgbEmail, P002F6_n61Supplier_AgbEmail,
               P002F6_A57Supplier_AgbName, P002F6_A55Supplier_AgbId
               }
               , new Object[] {
               P002F7_A60Supplier_AgbPostalAddress, P002F7_n60Supplier_AgbPostalAddress, P002F7_A59Supplier_AgbVisitingAddress, P002F7_n59Supplier_AgbVisitingAddress, P002F7_A63Supplier_AgbContactName, P002F7_n63Supplier_AgbContactName, P002F7_A62Supplier_AgbPhone, P002F7_n62Supplier_AgbPhone, P002F7_A61Supplier_AgbEmail, P002F7_n61Supplier_AgbEmail,
               P002F7_A57Supplier_AgbName, P002F7_A55Supplier_AgbId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32MaxItems ;
      private short AV31PageIndex ;
      private short AV30SkipItems ;
      private short A55Supplier_AgbId ;
      private int AV52GXV1 ;
      private long AV39count ;
      private string AV25TFSupplier_AgbPhone ;
      private string AV26TFSupplier_AgbPhone_Sel ;
      private string AV59Supplier_agbwwds_6_tfsupplier_agbphone ;
      private string AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ;
      private string lV59Supplier_agbwwds_6_tfsupplier_agbphone ;
      private string A62Supplier_AgbPhone ;
      private bool returnInSub ;
      private bool BRK2F2 ;
      private bool n60Supplier_AgbPostalAddress ;
      private bool n59Supplier_AgbVisitingAddress ;
      private bool n63Supplier_AgbContactName ;
      private bool n62Supplier_AgbPhone ;
      private bool n61Supplier_AgbEmail ;
      private bool BRK2F4 ;
      private bool BRK2F6 ;
      private bool BRK2F8 ;
      private bool BRK2F10 ;
      private bool BRK2F12 ;
      private string AV48OptionsJson ;
      private string AV49OptionsDescJson ;
      private string AV50OptionIndexesJson ;
      private string AV45DDOName ;
      private string AV46SearchTxtParms ;
      private string AV47SearchTxtTo ;
      private string AV29SearchTxt ;
      private string AV51FilterFullText ;
      private string AV15TFSupplier_AgbName ;
      private string AV16TFSupplier_AgbName_Sel ;
      private string AV23TFSupplier_AgbEmail ;
      private string AV24TFSupplier_AgbEmail_Sel ;
      private string AV27TFSupplier_AgbContactName ;
      private string AV28TFSupplier_AgbContactName_Sel ;
      private string AV19TFSupplier_AgbVisitingAddress ;
      private string AV20TFSupplier_AgbVisitingAddress_Sel ;
      private string AV21TFSupplier_AgbPostalAddress ;
      private string AV22TFSupplier_AgbPostalAddress_Sel ;
      private string AV54Supplier_agbwwds_1_filterfulltext ;
      private string AV55Supplier_agbwwds_2_tfsupplier_agbname ;
      private string AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ;
      private string AV57Supplier_agbwwds_4_tfsupplier_agbemail ;
      private string AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ;
      private string AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ;
      private string AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ;
      private string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ;
      private string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ;
      private string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ;
      private string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ;
      private string lV54Supplier_agbwwds_1_filterfulltext ;
      private string lV55Supplier_agbwwds_2_tfsupplier_agbname ;
      private string lV57Supplier_agbwwds_4_tfsupplier_agbemail ;
      private string lV61Supplier_agbwwds_8_tfsupplier_agbcontactname ;
      private string lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ;
      private string lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ;
      private string A57Supplier_AgbName ;
      private string A61Supplier_AgbEmail ;
      private string A63Supplier_AgbContactName ;
      private string A59Supplier_AgbVisitingAddress ;
      private string A60Supplier_AgbPostalAddress ;
      private string AV34Option ;
      private IGxSession AV40Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV37OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P002F2_A57Supplier_AgbName ;
      private string[] P002F2_A60Supplier_AgbPostalAddress ;
      private bool[] P002F2_n60Supplier_AgbPostalAddress ;
      private string[] P002F2_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F2_n59Supplier_AgbVisitingAddress ;
      private string[] P002F2_A63Supplier_AgbContactName ;
      private bool[] P002F2_n63Supplier_AgbContactName ;
      private string[] P002F2_A62Supplier_AgbPhone ;
      private bool[] P002F2_n62Supplier_AgbPhone ;
      private string[] P002F2_A61Supplier_AgbEmail ;
      private bool[] P002F2_n61Supplier_AgbEmail ;
      private short[] P002F2_A55Supplier_AgbId ;
      private string[] P002F3_A61Supplier_AgbEmail ;
      private bool[] P002F3_n61Supplier_AgbEmail ;
      private string[] P002F3_A60Supplier_AgbPostalAddress ;
      private bool[] P002F3_n60Supplier_AgbPostalAddress ;
      private string[] P002F3_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F3_n59Supplier_AgbVisitingAddress ;
      private string[] P002F3_A63Supplier_AgbContactName ;
      private bool[] P002F3_n63Supplier_AgbContactName ;
      private string[] P002F3_A62Supplier_AgbPhone ;
      private bool[] P002F3_n62Supplier_AgbPhone ;
      private string[] P002F3_A57Supplier_AgbName ;
      private short[] P002F3_A55Supplier_AgbId ;
      private string[] P002F4_A62Supplier_AgbPhone ;
      private bool[] P002F4_n62Supplier_AgbPhone ;
      private string[] P002F4_A60Supplier_AgbPostalAddress ;
      private bool[] P002F4_n60Supplier_AgbPostalAddress ;
      private string[] P002F4_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F4_n59Supplier_AgbVisitingAddress ;
      private string[] P002F4_A63Supplier_AgbContactName ;
      private bool[] P002F4_n63Supplier_AgbContactName ;
      private string[] P002F4_A61Supplier_AgbEmail ;
      private bool[] P002F4_n61Supplier_AgbEmail ;
      private string[] P002F4_A57Supplier_AgbName ;
      private short[] P002F4_A55Supplier_AgbId ;
      private string[] P002F5_A63Supplier_AgbContactName ;
      private bool[] P002F5_n63Supplier_AgbContactName ;
      private string[] P002F5_A60Supplier_AgbPostalAddress ;
      private bool[] P002F5_n60Supplier_AgbPostalAddress ;
      private string[] P002F5_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F5_n59Supplier_AgbVisitingAddress ;
      private string[] P002F5_A62Supplier_AgbPhone ;
      private bool[] P002F5_n62Supplier_AgbPhone ;
      private string[] P002F5_A61Supplier_AgbEmail ;
      private bool[] P002F5_n61Supplier_AgbEmail ;
      private string[] P002F5_A57Supplier_AgbName ;
      private short[] P002F5_A55Supplier_AgbId ;
      private string[] P002F6_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F6_n59Supplier_AgbVisitingAddress ;
      private string[] P002F6_A60Supplier_AgbPostalAddress ;
      private bool[] P002F6_n60Supplier_AgbPostalAddress ;
      private string[] P002F6_A63Supplier_AgbContactName ;
      private bool[] P002F6_n63Supplier_AgbContactName ;
      private string[] P002F6_A62Supplier_AgbPhone ;
      private bool[] P002F6_n62Supplier_AgbPhone ;
      private string[] P002F6_A61Supplier_AgbEmail ;
      private bool[] P002F6_n61Supplier_AgbEmail ;
      private string[] P002F6_A57Supplier_AgbName ;
      private short[] P002F6_A55Supplier_AgbId ;
      private string[] P002F7_A60Supplier_AgbPostalAddress ;
      private bool[] P002F7_n60Supplier_AgbPostalAddress ;
      private string[] P002F7_A59Supplier_AgbVisitingAddress ;
      private bool[] P002F7_n59Supplier_AgbVisitingAddress ;
      private string[] P002F7_A63Supplier_AgbContactName ;
      private bool[] P002F7_n63Supplier_AgbContactName ;
      private string[] P002F7_A62Supplier_AgbPhone ;
      private bool[] P002F7_n62Supplier_AgbPhone ;
      private string[] P002F7_A61Supplier_AgbEmail ;
      private bool[] P002F7_n61Supplier_AgbEmail ;
      private string[] P002F7_A57Supplier_AgbName ;
      private short[] P002F7_A55Supplier_AgbId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class supplier_agbwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002F2( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             string AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                             string AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string A57Supplier_AgbName ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbName, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbId FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV55Supplier_agbwwds_2_tfsupplier_agbname)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV56Supplier_agbwwds_3_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV57Supplier_agbwwds_4_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV59Supplier_agbwwds_6_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV61Supplier_agbwwds_8_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002F3( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             string AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                             string AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string A57Supplier_AgbName ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbEmail, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbName, Supplier_AgbId FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV55Supplier_agbwwds_2_tfsupplier_agbname)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV56Supplier_agbwwds_3_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV57Supplier_agbwwds_4_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV59Supplier_agbwwds_6_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV61Supplier_agbwwds_8_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbEmail";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002F4( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             string AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                             string AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string A57Supplier_AgbName ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[18];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbPhone, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbContactName, Supplier_AgbEmail, Supplier_AgbName, Supplier_AgbId FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV55Supplier_agbwwds_2_tfsupplier_agbname)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV56Supplier_agbwwds_3_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV57Supplier_agbwwds_4_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV59Supplier_agbwwds_6_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV61Supplier_agbwwds_8_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbPhone";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002F5( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             string AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                             string AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string A57Supplier_AgbName ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[18];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbContactName, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbName, Supplier_AgbId FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV55Supplier_agbwwds_2_tfsupplier_agbname)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV56Supplier_agbwwds_3_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV57Supplier_agbwwds_4_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV59Supplier_agbwwds_6_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV61Supplier_agbwwds_8_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbContactName";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P002F6( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             string AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                             string AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string A57Supplier_AgbName ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[18];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbVisitingAddress, Supplier_AgbPostalAddress, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbName, Supplier_AgbId FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV55Supplier_agbwwds_2_tfsupplier_agbname)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV56Supplier_agbwwds_3_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV57Supplier_agbwwds_4_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV59Supplier_agbwwds_6_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV61Supplier_agbwwds_8_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbVisitingAddress";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P002F7( IGxContext context ,
                                             string AV54Supplier_agbwwds_1_filterfulltext ,
                                             string AV56Supplier_agbwwds_3_tfsupplier_agbname_sel ,
                                             string AV55Supplier_agbwwds_2_tfsupplier_agbname ,
                                             string AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel ,
                                             string AV57Supplier_agbwwds_4_tfsupplier_agbemail ,
                                             string AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel ,
                                             string AV59Supplier_agbwwds_6_tfsupplier_agbphone ,
                                             string AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel ,
                                             string AV61Supplier_agbwwds_8_tfsupplier_agbcontactname ,
                                             string AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel ,
                                             string AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress ,
                                             string AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel ,
                                             string AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress ,
                                             string A57Supplier_AgbName ,
                                             string A61Supplier_AgbEmail ,
                                             string A62Supplier_AgbPhone ,
                                             string A63Supplier_AgbContactName ,
                                             string A59Supplier_AgbVisitingAddress ,
                                             string A60Supplier_AgbPostalAddress )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[18];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbName, Supplier_AgbId FROM Supplier_AGB";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_agbwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_AgbName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbEmail like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPhone like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbContactName like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbVisitingAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext) or ( Supplier_AgbPostalAddress like '%' || :lV54Supplier_agbwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_agbwwds_2_tfsupplier_agbname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName like :lV55Supplier_agbwwds_2_tfsupplier_agbname)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_agbwwds_3_tfsupplier_agbname_sel)) && ! ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbName = ( :AV56Supplier_agbwwds_3_tfsupplier_agbname_sel))");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Supplier_agbwwds_3_tfsupplier_agbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_AgbName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_agbwwds_4_tfsupplier_agbemail)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail like :lV57Supplier_agbwwds_4_tfsupplier_agbemail)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel)) && ! ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail = ( :AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel))");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( StringUtil.StrCmp(AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbEmail IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_agbwwds_6_tfsupplier_agbphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone like :lV59Supplier_agbwwds_6_tfsupplier_agbphone)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel)) && ! ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone = ( :AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel))");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( StringUtil.StrCmp(AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_agbwwds_8_tfsupplier_agbcontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName like :lV61Supplier_agbwwds_8_tfsupplier_agbcontactname)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel)) && ! ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName = ( :AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel))");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( StringUtil.StrCmp(AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress like :lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress = ( :AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel))");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( StringUtil.StrCmp(AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress like :lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress = ( :AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel))");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(Supplier_AgbPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_AgbPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Supplier_AgbPostalAddress";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 1 :
                     return conditional_P002F3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 2 :
                     return conditional_P002F4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 3 :
                     return conditional_P002F5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 4 :
                     return conditional_P002F6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 5 :
                     return conditional_P002F7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002F2;
          prmP002F2 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Supplier_agbwwds_2_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0)
          };
          Object[] prmP002F3;
          prmP002F3 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Supplier_agbwwds_2_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0)
          };
          Object[] prmP002F4;
          prmP002F4 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Supplier_agbwwds_2_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0)
          };
          Object[] prmP002F5;
          prmP002F5 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Supplier_agbwwds_2_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0)
          };
          Object[] prmP002F6;
          prmP002F6 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Supplier_agbwwds_2_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0)
          };
          Object[] prmP002F7;
          prmP002F7 = new Object[] {
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_agbwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Supplier_agbwwds_2_tfsupplier_agbname",GXType.VarChar,40,0) ,
          new ParDef("AV56Supplier_agbwwds_3_tfsupplier_agbname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Supplier_agbwwds_4_tfsupplier_agbemail",GXType.VarChar,100,0) ,
          new ParDef("AV58Supplier_agbwwds_5_tfsupplier_agbemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Supplier_agbwwds_6_tfsupplier_agbphone",GXType.Char,20,0) ,
          new ParDef("AV60Supplier_agbwwds_7_tfsupplier_agbphone_sel",GXType.Char,20,0) ,
          new ParDef("lV61Supplier_agbwwds_8_tfsupplier_agbcontactname",GXType.VarChar,40,0) ,
          new ParDef("AV62Supplier_agbwwds_9_tfsupplier_agbcontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV63Supplier_agbwwds_10_tfsupplier_agbvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV64Supplier_agbwwds_11_tfsupplier_agbvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV65Supplier_agbwwds_12_tfsupplier_agbpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV66Supplier_agbwwds_13_tfsupplier_agbpostaladdress_sel",GXType.VarChar,1024,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
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
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
