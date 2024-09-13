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
   public class productservicetypewwgetfilterdata : GXProcedure
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
            return "productservicetypeww_Services_Execute" ;
         }

      }

      public productservicetypewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public productservicetypewwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PRODUCTSERVICETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICETYPENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("ProductServiceTypeWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProductServiceTypeWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("ProductServiceTypeWWGridState"), null, "", "");
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETYPENAME") == 0 )
            {
               AV13TFProductServiceTypeName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETYPENAME_SEL") == 0 )
            {
               AV14TFProductServiceTypeName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPRODUCTSERVICETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFProductServiceTypeName = AV15SearchTxt;
         AV14TFProductServiceTypeName_Sel = "";
         AV40Productservicetypewwds_1_filterfulltext = AV37FilterFullText;
         AV41Productservicetypewwds_2_tfproductservicetypename = AV13TFProductServiceTypeName;
         AV42Productservicetypewwds_3_tfproductservicetypename_sel = AV14TFProductServiceTypeName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Productservicetypewwds_1_filterfulltext ,
                                              AV42Productservicetypewwds_3_tfproductservicetypename_sel ,
                                              AV41Productservicetypewwds_2_tfproductservicetypename ,
                                              A72ProductServiceTypeName } ,
                                              new int[]{
                                              }
         });
         lV40Productservicetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Productservicetypewwds_1_filterfulltext), "%", "");
         lV41Productservicetypewwds_2_tfproductservicetypename = StringUtil.Concat( StringUtil.RTrim( AV41Productservicetypewwds_2_tfproductservicetypename), "%", "");
         /* Using cursor P002I2 */
         pr_default.execute(0, new Object[] {lV40Productservicetypewwds_1_filterfulltext, lV41Productservicetypewwds_2_tfproductservicetypename, AV42Productservicetypewwds_3_tfproductservicetypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2I2 = false;
            A72ProductServiceTypeName = P002I2_A72ProductServiceTypeName[0];
            A71ProductServiceTypeId = P002I2_A71ProductServiceTypeId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002I2_A72ProductServiceTypeName[0], A72ProductServiceTypeName) == 0 ) )
            {
               BRK2I2 = false;
               A71ProductServiceTypeId = P002I2_A71ProductServiceTypeId[0];
               AV25count = (long)(AV25count+1);
               BRK2I2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A72ProductServiceTypeName)) ? "<#Empty#>" : A72ProductServiceTypeName);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK2I2 )
            {
               BRK2I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV13TFProductServiceTypeName = "";
         AV14TFProductServiceTypeName_Sel = "";
         AV40Productservicetypewwds_1_filterfulltext = "";
         AV41Productservicetypewwds_2_tfproductservicetypename = "";
         AV42Productservicetypewwds_3_tfproductservicetypename_sel = "";
         lV40Productservicetypewwds_1_filterfulltext = "";
         lV41Productservicetypewwds_2_tfproductservicetypename = "";
         A72ProductServiceTypeName = "";
         P002I2_A72ProductServiceTypeName = new string[] {""} ;
         P002I2_A71ProductServiceTypeId = new short[1] ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productservicetypewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002I2_A72ProductServiceTypeName, P002I2_A71ProductServiceTypeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short A71ProductServiceTypeId ;
      private int AV38GXV1 ;
      private long AV25count ;
      private bool returnInSub ;
      private bool BRK2I2 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV13TFProductServiceTypeName ;
      private string AV14TFProductServiceTypeName_Sel ;
      private string AV40Productservicetypewwds_1_filterfulltext ;
      private string AV41Productservicetypewwds_2_tfproductservicetypename ;
      private string AV42Productservicetypewwds_3_tfproductservicetypename_sel ;
      private string lV40Productservicetypewwds_1_filterfulltext ;
      private string lV41Productservicetypewwds_2_tfproductservicetypename ;
      private string A72ProductServiceTypeName ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P002I2_A72ProductServiceTypeName ;
      private short[] P002I2_A71ProductServiceTypeId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class productservicetypewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002I2( IGxContext context ,
                                             string AV40Productservicetypewwds_1_filterfulltext ,
                                             string AV42Productservicetypewwds_3_tfproductservicetypename_sel ,
                                             string AV41Productservicetypewwds_2_tfproductservicetypename ,
                                             string A72ProductServiceTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ProductServiceTypeName, ProductServiceTypeId FROM ProductServiceType";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Productservicetypewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ProductServiceTypeName like '%' || :lV40Productservicetypewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Productservicetypewwds_3_tfproductservicetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Productservicetypewwds_2_tfproductservicetypename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceTypeName like :lV41Productservicetypewwds_2_tfproductservicetypename)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Productservicetypewwds_3_tfproductservicetypename_sel)) && ! ( StringUtil.StrCmp(AV42Productservicetypewwds_3_tfproductservicetypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceTypeName = ( :AV42Productservicetypewwds_3_tfproductservicetypename_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV42Productservicetypewwds_3_tfproductservicetypename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProductServiceTypeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002I2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002I2;
          prmP002I2 = new Object[] {
          new ParDef("lV40Productservicetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Productservicetypewwds_2_tfproductservicetypename",GXType.VarChar,40,0) ,
          new ParDef("AV42Productservicetypewwds_3_tfproductservicetypename_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002I2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
