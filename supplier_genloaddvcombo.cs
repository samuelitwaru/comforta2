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
   public class supplier_genloaddvcombo : GXProcedure
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
            return "supplier_gen_Services_Execute" ;
         }

      }

      public supplier_genloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supplier_genloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           short aP3_Supplier_GenId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20Supplier_GenId = aP3_Supplier_GenId;
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
                                short aP3_Supplier_GenId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_Supplier_GenId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 short aP3_Supplier_GenId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20Supplier_GenId = aP3_Supplier_GenId;
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
         if ( StringUtil.StrCmp(AV17ComboName, "ProductServiceId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PRODUCTSERVICEID' */
            S111 ();
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
         /* 'LOADCOMBOITEMS_PRODUCTSERVICEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV29ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV28DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV32GXV1 = 1;
               while ( AV32GXV1 <= AV29ValuesCollection.Count )
               {
                  AV30ValueItem = ((string)AV29ValuesCollection.Item(AV32GXV1));
                  AV31ProductServiceId_Filter = (short)(Math.Round(NumberUtil.Val( AV30ValueItem, "."), 18, MidpointRounding.ToEven));
                  AV33GXLvl29 = 0;
                  /* Using cursor P002G2 */
                  pr_default.execute(0, new Object[] {AV31ProductServiceId_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A73ProductServiceId = P002G2_A73ProductServiceId[0];
                     A74ProductServiceName = P002G2_A74ProductServiceName[0];
                     AV33GXLvl29 = 1;
                     AV28DscsCollection.Add(A74ProductServiceName, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV33GXLvl29 == 0 )
                  {
                     AV28DscsCollection.Add("", 0);
                  }
                  AV32GXV1 = (int)(AV32GXV1+1);
               }
               AV24Combo_DataJson = AV28DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom3 = AV12SkipItems;
               GXPagingTo3 = AV11MaxItems;
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV14SearchTxt ,
                                                    A74ProductServiceName } ,
                                                    new int[]{
                                                    }
               });
               lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
               /* Using cursor P002G3 */
               pr_default.execute(1, new Object[] {lV14SearchTxt, GXPagingFrom3, GXPagingTo3, GXPagingTo3});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A74ProductServiceName = P002G3_A74ProductServiceName[0];
                  A73ProductServiceId = P002G3_A73ProductServiceId[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A73ProductServiceId), 4, 0));
                  AV16Combo_DataItem.gxTpr_Title = A74ProductServiceName;
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
         AV29ValuesCollection = new GxSimpleCollection<string>();
         AV28DscsCollection = new GxSimpleCollection<string>();
         AV30ValueItem = "";
         P002G2_A73ProductServiceId = new short[1] ;
         P002G2_A74ProductServiceName = new string[] {""} ;
         A74ProductServiceName = "";
         lV14SearchTxt = "";
         P002G3_A74ProductServiceName = new string[] {""} ;
         P002G3_A73ProductServiceId = new short[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_genloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P002G2_A73ProductServiceId, P002G2_A74ProductServiceName
               }
               , new Object[] {
               P002G3_A74ProductServiceName, P002G3_A73ProductServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20Supplier_GenId ;
      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short AV31ProductServiceId_Filter ;
      private short AV33GXLvl29 ;
      private short A73ProductServiceId ;
      private int AV11MaxItems ;
      private int AV32GXV1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string AV30ValueItem ;
      private string A74ProductServiceName ;
      private string lV14SearchTxt ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV29ValuesCollection ;
      private GxSimpleCollection<string> AV28DscsCollection ;
      private IDataStoreProvider pr_default ;
      private short[] P002G2_A73ProductServiceId ;
      private string[] P002G2_A74ProductServiceName ;
      private string[] P002G3_A74ProductServiceName ;
      private short[] P002G3_A73ProductServiceId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class supplier_genloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002G3( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A74ProductServiceName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ProductServiceName, ProductServiceId";
         sFromString = " FROM ProductService";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ProductServiceName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY ProductServiceName, ProductServiceId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom3" + " LIMIT CASE WHEN " + ":GXPagingTo3" + " > 0 THEN " + ":GXPagingTo3" + " ELSE 1e9 END";
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
               case 1 :
                     return conditional_P002G3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP002G2;
          prmP002G2 = new Object[] {
          new ParDef("AV31ProductServiceId_Filter",GXType.Int16,4,0)
          };
          Object[] prmP002G3;
          prmP002G3 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002G2", "SELECT ProductServiceId, ProductServiceName FROM ProductService WHERE ProductServiceId = :AV31ProductServiceId_Filter ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002G2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002G3,100, GxCacheFrequency.OFF ,false,false )
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
       }
    }

 }

}
