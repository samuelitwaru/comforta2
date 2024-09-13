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
   public class pagewwgetfilterdata : GXProcedure
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
            return "pageww_Services_Execute" ;
         }

      }

      public pagewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pagewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PAGENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPAGENAMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV36Session.Get("PageWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PageWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("PageWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPAGENAME") == 0 )
            {
               AV13TFPageName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPAGENAME_SEL") == 0 )
            {
               AV14TFPageName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPAGENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFPageName = AV25SearchTxt;
         AV14TFPageName_Sel = "";
         AV51Pagewwds_1_filterfulltext = AV47FilterFullText;
         AV52Pagewwds_2_tfpagename = AV13TFPageName;
         AV53Pagewwds_3_tfpagename_sel = AV14TFPageName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51Pagewwds_1_filterfulltext ,
                                              AV53Pagewwds_3_tfpagename_sel ,
                                              AV52Pagewwds_2_tfpagename ,
                                              AV48CustomerId ,
                                              A104PageName ,
                                              A1CustomerId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV51Pagewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Pagewwds_1_filterfulltext), "%", "");
         lV52Pagewwds_2_tfpagename = StringUtil.Concat( StringUtil.RTrim( AV52Pagewwds_2_tfpagename), "%", "");
         /* Using cursor P00372 */
         pr_default.execute(0, new Object[] {lV51Pagewwds_1_filterfulltext, lV52Pagewwds_2_tfpagename, AV53Pagewwds_3_tfpagename_sel, AV48CustomerId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK372 = false;
            A104PageName = P00372_A104PageName[0];
            A1CustomerId = P00372_A1CustomerId[0];
            A103PageId = P00372_A103PageId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00372_A104PageName[0], A104PageName) == 0 ) )
            {
               BRK372 = false;
               A103PageId = P00372_A103PageId[0];
               AV35count = (long)(AV35count+1);
               BRK372 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A104PageName)) ? "<#Empty#>" : A104PageName);
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
            if ( ! BRK372 )
            {
               BRK372 = true;
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
         AV13TFPageName = "";
         AV14TFPageName_Sel = "";
         AV51Pagewwds_1_filterfulltext = "";
         AV52Pagewwds_2_tfpagename = "";
         AV53Pagewwds_3_tfpagename_sel = "";
         lV51Pagewwds_1_filterfulltext = "";
         lV52Pagewwds_2_tfpagename = "";
         A104PageName = "";
         P00372_A104PageName = new string[] {""} ;
         P00372_A1CustomerId = new short[1] ;
         P00372_A103PageId = new short[1] ;
         AV30Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pagewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00372_A104PageName, P00372_A1CustomerId, P00372_A103PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV48CustomerId ;
      private short A1CustomerId ;
      private short A103PageId ;
      private int AV49GXV1 ;
      private long AV35count ;
      private bool returnInSub ;
      private bool BRK372 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV13TFPageName ;
      private string AV14TFPageName_Sel ;
      private string AV51Pagewwds_1_filterfulltext ;
      private string AV52Pagewwds_2_tfpagename ;
      private string AV53Pagewwds_3_tfpagename_sel ;
      private string lV51Pagewwds_1_filterfulltext ;
      private string lV52Pagewwds_2_tfpagename ;
      private string A104PageName ;
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
      private string[] P00372_A104PageName ;
      private short[] P00372_A1CustomerId ;
      private short[] P00372_A103PageId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class pagewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00372( IGxContext context ,
                                             string AV51Pagewwds_1_filterfulltext ,
                                             string AV53Pagewwds_3_tfpagename_sel ,
                                             string AV52Pagewwds_2_tfpagename ,
                                             short AV48CustomerId ,
                                             string A104PageName ,
                                             short A1CustomerId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT PageName, CustomerId, PageId FROM Page";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Pagewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PageName like '%' || :lV51Pagewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Pagewwds_3_tfpagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Pagewwds_2_tfpagename)) ) )
         {
            AddWhere(sWhereString, "(PageName like :lV52Pagewwds_2_tfpagename)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Pagewwds_3_tfpagename_sel)) && ! ( StringUtil.StrCmp(AV53Pagewwds_3_tfpagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(PageName = ( :AV53Pagewwds_3_tfpagename_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV53Pagewwds_3_tfpagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PageName))=0))");
         }
         if ( ! (0==AV48CustomerId) )
         {
            AddWhere(sWhereString, "(CustomerId = :AV48CustomerId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PageName";
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
                     return conditional_P00372(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] );
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
          Object[] prmP00372;
          prmP00372 = new Object[] {
          new ParDef("lV51Pagewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Pagewwds_2_tfpagename",GXType.VarChar,40,0) ,
          new ParDef("AV53Pagewwds_3_tfpagename_sel",GXType.VarChar,40,0) ,
          new ParDef("AV48CustomerId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00372", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00372,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
