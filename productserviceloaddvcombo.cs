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
   public class productserviceloaddvcombo : GXProcedure
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
            return "productservice_Services_Execute" ;
         }

      }

      public productserviceloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public productserviceloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           short aP3_ProductServiceId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ProductServiceId = aP3_ProductServiceId;
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
                                short aP3_ProductServiceId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ProductServiceId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 short aP3_ProductServiceId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ProductServiceId = aP3_ProductServiceId;
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
         if ( StringUtil.StrCmp(AV17ComboName, "ProductServiceTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PRODUCTSERVICETYPEID' */
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
         /* 'LOADCOMBOITEMS_PRODUCTSERVICETYPEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A72ProductServiceTypeName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P002J2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A72ProductServiceTypeName = P002J2_A72ProductServiceTypeName[0];
               A71ProductServiceTypeId = P002J2_A71ProductServiceTypeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A71ProductServiceTypeId), 4, 0));
               AV16Combo_DataItem.gxTpr_Title = A72ProductServiceTypeName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P002J3 */
                  pr_default.execute(1, new Object[] {AV20ProductServiceId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A73ProductServiceId = P002J3_A73ProductServiceId[0];
                     A71ProductServiceTypeId = P002J3_A71ProductServiceTypeId[0];
                     A72ProductServiceTypeName = P002J3_A72ProductServiceTypeName[0];
                     A72ProductServiceTypeName = P002J3_A72ProductServiceTypeName[0];
                     AV22SelectedValue = ((0==A71ProductServiceTypeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A71ProductServiceTypeId), 4, 0)));
                     AV23SelectedText = A72ProductServiceTypeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28ProductServiceTypeId = (short)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P002J4 */
                  pr_default.execute(2, new Object[] {AV28ProductServiceTypeId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A71ProductServiceTypeId = P002J4_A71ProductServiceTypeId[0];
                     A72ProductServiceTypeName = P002J4_A72ProductServiceTypeName[0];
                     AV23SelectedText = A72ProductServiceTypeName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
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
         lV14SearchTxt = "";
         A72ProductServiceTypeName = "";
         P002J2_A72ProductServiceTypeName = new string[] {""} ;
         P002J2_A71ProductServiceTypeId = new short[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P002J3_A73ProductServiceId = new short[1] ;
         P002J3_A71ProductServiceTypeId = new short[1] ;
         P002J3_A72ProductServiceTypeName = new string[] {""} ;
         P002J4_A71ProductServiceTypeId = new short[1] ;
         P002J4_A72ProductServiceTypeName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productserviceloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P002J2_A72ProductServiceTypeName, P002J2_A71ProductServiceTypeId
               }
               , new Object[] {
               P002J3_A73ProductServiceId, P002J3_A71ProductServiceTypeId, P002J3_A72ProductServiceTypeName
               }
               , new Object[] {
               P002J4_A71ProductServiceTypeId, P002J4_A72ProductServiceTypeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20ProductServiceId ;
      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short A71ProductServiceTypeId ;
      private short A73ProductServiceId ;
      private short AV28ProductServiceTypeId ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A72ProductServiceTypeName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P002J2_A72ProductServiceTypeName ;
      private short[] P002J2_A71ProductServiceTypeId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private short[] P002J3_A73ProductServiceId ;
      private short[] P002J3_A71ProductServiceTypeId ;
      private string[] P002J3_A72ProductServiceTypeName ;
      private short[] P002J4_A71ProductServiceTypeId ;
      private string[] P002J4_A72ProductServiceTypeName ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class productserviceloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002J2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A72ProductServiceTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ProductServiceTypeName, ProductServiceTypeId";
         sFromString = " FROM ProductServiceType";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ProductServiceTypeName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY ProductServiceTypeName, ProductServiceTypeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
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
                     return conditional_P002J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP002J3;
          prmP002J3 = new Object[] {
          new ParDef("AV20ProductServiceId",GXType.Int16,4,0)
          };
          Object[] prmP002J4;
          prmP002J4 = new Object[] {
          new ParDef("AV28ProductServiceTypeId",GXType.Int16,4,0)
          };
          Object[] prmP002J2;
          prmP002J2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002J2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002J3", "SELECT T1.ProductServiceId, T1.ProductServiceTypeId, T2.ProductServiceTypeName FROM (ProductService T1 INNER JOIN ProductServiceType T2 ON T2.ProductServiceTypeId = T1.ProductServiceTypeId) WHERE T1.ProductServiceId = :AV20ProductServiceId ORDER BY T1.ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002J3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002J4", "SELECT ProductServiceTypeId, ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :AV28ProductServiceTypeId ORDER BY ProductServiceTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002J4,1, GxCacheFrequency.OFF ,false,true )
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
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
