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
   public class productservicewwgetfilterdata : GXProcedure
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
            return "productserviceww_Services_Execute" ;
         }

      }

      public productservicewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public productservicewwgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26MaxItems = 10;
         AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
         AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_PRODUCTSERVICENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_PRODUCTSERVICETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICETYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("ProductServiceWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProductServiceWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("ProductServiceWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME") == 0 )
            {
               AV13TFProductServiceName = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME_SEL") == 0 )
            {
               AV14TFProductServiceName_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETYPENAME") == 0 )
            {
               AV21TFProductServiceTypeName = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETYPENAME_SEL") == 0 )
            {
               AV22TFProductServiceTypeName_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPRODUCTSERVICENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFProductServiceName = AV23SearchTxt;
         AV14TFProductServiceName_Sel = "";
         AV48Productservicewwds_1_filterfulltext = AV45FilterFullText;
         AV49Productservicewwds_2_tfproductservicename = AV13TFProductServiceName;
         AV50Productservicewwds_3_tfproductservicename_sel = AV14TFProductServiceName_Sel;
         AV51Productservicewwds_4_tfproductservicetypename = AV21TFProductServiceTypeName;
         AV52Productservicewwds_5_tfproductservicetypename_sel = AV22TFProductServiceTypeName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV48Productservicewwds_1_filterfulltext ,
                                              AV50Productservicewwds_3_tfproductservicename_sel ,
                                              AV49Productservicewwds_2_tfproductservicename ,
                                              AV52Productservicewwds_5_tfproductservicetypename_sel ,
                                              AV51Productservicewwds_4_tfproductservicetypename ,
                                              A74ProductServiceName ,
                                              A72ProductServiceTypeName } ,
                                              new int[]{
                                              }
         });
         lV48Productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Productservicewwds_1_filterfulltext), "%", "");
         lV48Productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Productservicewwds_1_filterfulltext), "%", "");
         lV49Productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV49Productservicewwds_2_tfproductservicename), "%", "");
         lV51Productservicewwds_4_tfproductservicetypename = StringUtil.Concat( StringUtil.RTrim( AV51Productservicewwds_4_tfproductservicetypename), "%", "");
         /* Using cursor P002K2 */
         pr_default.execute(0, new Object[] {lV48Productservicewwds_1_filterfulltext, lV48Productservicewwds_1_filterfulltext, lV49Productservicewwds_2_tfproductservicename, AV50Productservicewwds_3_tfproductservicename_sel, lV51Productservicewwds_4_tfproductservicetypename, AV52Productservicewwds_5_tfproductservicetypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2K2 = false;
            A71ProductServiceTypeId = P002K2_A71ProductServiceTypeId[0];
            A74ProductServiceName = P002K2_A74ProductServiceName[0];
            A72ProductServiceTypeName = P002K2_A72ProductServiceTypeName[0];
            A73ProductServiceId = P002K2_A73ProductServiceId[0];
            A72ProductServiceTypeName = P002K2_A72ProductServiceTypeName[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002K2_A74ProductServiceName[0], A74ProductServiceName) == 0 ) )
            {
               BRK2K2 = false;
               A73ProductServiceId = P002K2_A73ProductServiceId[0];
               AV33count = (long)(AV33count+1);
               BRK2K2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A74ProductServiceName)) ? "<#Empty#>" : A74ProductServiceName);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK2K2 )
            {
               BRK2K2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPRODUCTSERVICETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV21TFProductServiceTypeName = AV23SearchTxt;
         AV22TFProductServiceTypeName_Sel = "";
         AV48Productservicewwds_1_filterfulltext = AV45FilterFullText;
         AV49Productservicewwds_2_tfproductservicename = AV13TFProductServiceName;
         AV50Productservicewwds_3_tfproductservicename_sel = AV14TFProductServiceName_Sel;
         AV51Productservicewwds_4_tfproductservicetypename = AV21TFProductServiceTypeName;
         AV52Productservicewwds_5_tfproductservicetypename_sel = AV22TFProductServiceTypeName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV48Productservicewwds_1_filterfulltext ,
                                              AV50Productservicewwds_3_tfproductservicename_sel ,
                                              AV49Productservicewwds_2_tfproductservicename ,
                                              AV52Productservicewwds_5_tfproductservicetypename_sel ,
                                              AV51Productservicewwds_4_tfproductservicetypename ,
                                              A74ProductServiceName ,
                                              A72ProductServiceTypeName } ,
                                              new int[]{
                                              }
         });
         lV48Productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Productservicewwds_1_filterfulltext), "%", "");
         lV48Productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Productservicewwds_1_filterfulltext), "%", "");
         lV49Productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV49Productservicewwds_2_tfproductservicename), "%", "");
         lV51Productservicewwds_4_tfproductservicetypename = StringUtil.Concat( StringUtil.RTrim( AV51Productservicewwds_4_tfproductservicetypename), "%", "");
         /* Using cursor P002K3 */
         pr_default.execute(1, new Object[] {lV48Productservicewwds_1_filterfulltext, lV48Productservicewwds_1_filterfulltext, lV49Productservicewwds_2_tfproductservicename, AV50Productservicewwds_3_tfproductservicename_sel, lV51Productservicewwds_4_tfproductservicetypename, AV52Productservicewwds_5_tfproductservicetypename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2K4 = false;
            A71ProductServiceTypeId = P002K3_A71ProductServiceTypeId[0];
            A72ProductServiceTypeName = P002K3_A72ProductServiceTypeName[0];
            A74ProductServiceName = P002K3_A74ProductServiceName[0];
            A73ProductServiceId = P002K3_A73ProductServiceId[0];
            A72ProductServiceTypeName = P002K3_A72ProductServiceTypeName[0];
            AV33count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P002K3_A71ProductServiceTypeId[0] == A71ProductServiceTypeId ) )
            {
               BRK2K4 = false;
               A73ProductServiceId = P002K3_A73ProductServiceId[0];
               AV33count = (long)(AV33count+1);
               BRK2K4 = true;
               pr_default.readNext(1);
            }
            AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A72ProductServiceTypeName)) ? "<#Empty#>" : A72ProductServiceTypeName);
            AV27InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV28Option, "<#Empty#>") != 0 ) && ( AV27InsertIndex <= AV29Options.Count ) && ( ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), AV28Option) < 0 ) || ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV29Options.Add(AV28Option, AV27InsertIndex);
            AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), AV27InsertIndex);
            if ( AV29Options.Count == AV24SkipItems + 11 )
            {
               AV29Options.RemoveItem(AV29Options.Count);
               AV32OptionIndexes.RemoveItem(AV32OptionIndexes.Count);
            }
            if ( ! BRK2K4 )
            {
               BRK2K4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV24SkipItems > 0 )
         {
            AV29Options.RemoveItem(1);
            AV32OptionIndexes.RemoveItem(1);
            AV24SkipItems = (short)(AV24SkipItems-1);
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV13TFProductServiceName = "";
         AV14TFProductServiceName_Sel = "";
         AV21TFProductServiceTypeName = "";
         AV22TFProductServiceTypeName_Sel = "";
         AV48Productservicewwds_1_filterfulltext = "";
         AV49Productservicewwds_2_tfproductservicename = "";
         AV50Productservicewwds_3_tfproductservicename_sel = "";
         AV51Productservicewwds_4_tfproductservicetypename = "";
         AV52Productservicewwds_5_tfproductservicetypename_sel = "";
         lV48Productservicewwds_1_filterfulltext = "";
         lV49Productservicewwds_2_tfproductservicename = "";
         lV51Productservicewwds_4_tfproductservicetypename = "";
         A74ProductServiceName = "";
         A72ProductServiceTypeName = "";
         P002K2_A71ProductServiceTypeId = new short[1] ;
         P002K2_A74ProductServiceName = new string[] {""} ;
         P002K2_A72ProductServiceTypeName = new string[] {""} ;
         P002K2_A73ProductServiceId = new short[1] ;
         AV28Option = "";
         P002K3_A71ProductServiceTypeId = new short[1] ;
         P002K3_A72ProductServiceTypeName = new string[] {""} ;
         P002K3_A74ProductServiceName = new string[] {""} ;
         P002K3_A73ProductServiceId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productservicewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002K2_A71ProductServiceTypeId, P002K2_A74ProductServiceName, P002K2_A72ProductServiceTypeName, P002K2_A73ProductServiceId
               }
               , new Object[] {
               P002K3_A71ProductServiceTypeId, P002K3_A72ProductServiceTypeName, P002K3_A74ProductServiceName, P002K3_A73ProductServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private short A71ProductServiceTypeId ;
      private short A73ProductServiceId ;
      private int AV46GXV1 ;
      private int AV27InsertIndex ;
      private long AV33count ;
      private bool returnInSub ;
      private bool BRK2K2 ;
      private bool BRK2K4 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV13TFProductServiceName ;
      private string AV14TFProductServiceName_Sel ;
      private string AV21TFProductServiceTypeName ;
      private string AV22TFProductServiceTypeName_Sel ;
      private string AV48Productservicewwds_1_filterfulltext ;
      private string AV49Productservicewwds_2_tfproductservicename ;
      private string AV50Productservicewwds_3_tfproductservicename_sel ;
      private string AV51Productservicewwds_4_tfproductservicetypename ;
      private string AV52Productservicewwds_5_tfproductservicetypename_sel ;
      private string lV48Productservicewwds_1_filterfulltext ;
      private string lV49Productservicewwds_2_tfproductservicename ;
      private string lV51Productservicewwds_4_tfproductservicetypename ;
      private string A74ProductServiceName ;
      private string A72ProductServiceTypeName ;
      private string AV28Option ;
      private IGxSession AV34Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P002K2_A71ProductServiceTypeId ;
      private string[] P002K2_A74ProductServiceName ;
      private string[] P002K2_A72ProductServiceTypeName ;
      private short[] P002K2_A73ProductServiceId ;
      private short[] P002K3_A71ProductServiceTypeId ;
      private string[] P002K3_A72ProductServiceTypeName ;
      private string[] P002K3_A74ProductServiceName ;
      private short[] P002K3_A73ProductServiceId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class productservicewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002K2( IGxContext context ,
                                             string AV48Productservicewwds_1_filterfulltext ,
                                             string AV50Productservicewwds_3_tfproductservicename_sel ,
                                             string AV49Productservicewwds_2_tfproductservicename ,
                                             string AV52Productservicewwds_5_tfproductservicetypename_sel ,
                                             string AV51Productservicewwds_4_tfproductservicetypename ,
                                             string A74ProductServiceName ,
                                             string A72ProductServiceTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceTypeId, T1.ProductServiceName, T2.ProductServiceTypeName, T1.ProductServiceId FROM (ProductService T1 INNER JOIN ProductServiceType T2 ON T2.ProductServiceTypeId = T1.ProductServiceTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Productservicewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ProductServiceName like '%' || :lV48Productservicewwds_1_filterfulltext) or ( T2.ProductServiceTypeName like '%' || :lV48Productservicewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV49Productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV50Productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV50Productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV50Productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Productservicewwds_5_tfproductservicetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Productservicewwds_4_tfproductservicetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceTypeName like :lV51Productservicewwds_4_tfproductservicetypename)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Productservicewwds_5_tfproductservicetypename_sel)) && ! ( StringUtil.StrCmp(AV52Productservicewwds_5_tfproductservicetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceTypeName = ( :AV52Productservicewwds_5_tfproductservicetypename_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV52Productservicewwds_5_tfproductservicetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProductServiceTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProductServiceName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002K3( IGxContext context ,
                                             string AV48Productservicewwds_1_filterfulltext ,
                                             string AV50Productservicewwds_3_tfproductservicename_sel ,
                                             string AV49Productservicewwds_2_tfproductservicename ,
                                             string AV52Productservicewwds_5_tfproductservicetypename_sel ,
                                             string AV51Productservicewwds_4_tfproductservicetypename ,
                                             string A74ProductServiceName ,
                                             string A72ProductServiceTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceTypeId, T2.ProductServiceTypeName, T1.ProductServiceName, T1.ProductServiceId FROM (ProductService T1 INNER JOIN ProductServiceType T2 ON T2.ProductServiceTypeId = T1.ProductServiceTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Productservicewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ProductServiceName like '%' || :lV48Productservicewwds_1_filterfulltext) or ( T2.ProductServiceTypeName like '%' || :lV48Productservicewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV49Productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV50Productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV50Productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV50Productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Productservicewwds_5_tfproductservicetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Productservicewwds_4_tfproductservicetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceTypeName like :lV51Productservicewwds_4_tfproductservicetypename)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Productservicewwds_5_tfproductservicetypename_sel)) && ! ( StringUtil.StrCmp(AV52Productservicewwds_5_tfproductservicetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceTypeName = ( :AV52Productservicewwds_5_tfproductservicetypename_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV52Productservicewwds_5_tfproductservicetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProductServiceTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProductServiceTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P002K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002K2;
          prmP002K2 = new Object[] {
          new ParDef("lV48Productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Productservicewwds_2_tfproductservicename",GXType.VarChar,40,0) ,
          new ParDef("AV50Productservicewwds_3_tfproductservicename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV51Productservicewwds_4_tfproductservicetypename",GXType.VarChar,40,0) ,
          new ParDef("AV52Productservicewwds_5_tfproductservicetypename_sel",GXType.VarChar,40,0)
          };
          Object[] prmP002K3;
          prmP002K3 = new Object[] {
          new ParDef("lV48Productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Productservicewwds_2_tfproductservicename",GXType.VarChar,40,0) ,
          new ParDef("AV50Productservicewwds_3_tfproductservicename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV51Productservicewwds_4_tfproductservicetypename",GXType.VarChar,40,0) ,
          new ParDef("AV52Productservicewwds_5_tfproductservicetypename_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002K3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
