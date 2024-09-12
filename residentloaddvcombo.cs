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
   public class residentloaddvcombo : GXProcedure
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
            return "resident_Services_Execute" ;
         }

      }

      public residentloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public residentloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           short aP3_ResidentId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ResidentId = aP3_ResidentId;
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
                                short aP3_ResidentId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ResidentId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 short aP3_ResidentId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ResidentId = aP3_ResidentId;
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
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTTYPEID' */
            S121 ();
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
               AV30ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV29DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV36GXV1 = 1;
               while ( AV36GXV1 <= AV30ValuesCollection.Count )
               {
                  AV31ValueItem = ((string)AV30ValuesCollection.Item(AV36GXV1));
                  AV32ProductServiceId_Filter = (short)(Math.Round(NumberUtil.Val( AV31ValueItem, "."), 18, MidpointRounding.ToEven));
                  AV37GXLvl31 = 0;
                  /* Using cursor P002C2 */
                  pr_default.execute(0, new Object[] {AV32ProductServiceId_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A73ProductServiceId = P002C2_A73ProductServiceId[0];
                     A74ProductServiceName = P002C2_A74ProductServiceName[0];
                     AV37GXLvl31 = 1;
                     AV29DscsCollection.Add(A74ProductServiceName, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV37GXLvl31 == 0 )
                  {
                     AV29DscsCollection.Add("", 0);
                  }
                  AV36GXV1 = (int)(AV36GXV1+1);
               }
               AV24Combo_DataJson = AV29DscsCollection.ToJSonString(false);
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
               /* Using cursor P002C3 */
               pr_default.execute(1, new Object[] {lV14SearchTxt, GXPagingFrom3, GXPagingTo3, GXPagingTo3});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A74ProductServiceName = P002C3_A74ProductServiceName[0];
                  A73ProductServiceId = P002C3_A73ProductServiceId[0];
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

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTTYPEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom4 = AV12SkipItems;
            GXPagingTo4 = AV11MaxItems;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A83ResidentTypeName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P002C4 */
            pr_default.execute(2, new Object[] {lV14SearchTxt, GXPagingFrom4, GXPagingTo4, GXPagingTo4});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A83ResidentTypeName = P002C4_A83ResidentTypeName[0];
               A82ResidentTypeId = P002C4_A82ResidentTypeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A82ResidentTypeId), 4, 0));
               AV16Combo_DataItem.gxTpr_Title = A83ResidentTypeName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P002C5 */
                  pr_default.execute(3, new Object[] {AV20ResidentId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A31ResidentId = P002C5_A31ResidentId[0];
                     A82ResidentTypeId = P002C5_A82ResidentTypeId[0];
                     A83ResidentTypeName = P002C5_A83ResidentTypeName[0];
                     A83ResidentTypeName = P002C5_A83ResidentTypeName[0];
                     AV22SelectedValue = ((0==A82ResidentTypeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A82ResidentTypeId), 4, 0)));
                     AV23SelectedText = A83ResidentTypeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
               else
               {
                  AV28ResidentTypeId = (short)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P002C6 */
                  pr_default.execute(4, new Object[] {AV28ResidentTypeId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A82ResidentTypeId = P002C6_A82ResidentTypeId[0];
                     A83ResidentTypeName = P002C6_A83ResidentTypeName[0];
                     AV23SelectedText = A83ResidentTypeName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
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
         AV30ValuesCollection = new GxSimpleCollection<string>();
         AV29DscsCollection = new GxSimpleCollection<string>();
         AV31ValueItem = "";
         P002C2_A73ProductServiceId = new short[1] ;
         P002C2_A74ProductServiceName = new string[] {""} ;
         A74ProductServiceName = "";
         lV14SearchTxt = "";
         P002C3_A74ProductServiceName = new string[] {""} ;
         P002C3_A73ProductServiceId = new short[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A83ResidentTypeName = "";
         P002C4_A83ResidentTypeName = new string[] {""} ;
         P002C4_A82ResidentTypeId = new short[1] ;
         P002C5_A31ResidentId = new short[1] ;
         P002C5_A82ResidentTypeId = new short[1] ;
         P002C5_A83ResidentTypeName = new string[] {""} ;
         P002C6_A82ResidentTypeId = new short[1] ;
         P002C6_A83ResidentTypeName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.residentloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P002C2_A73ProductServiceId, P002C2_A74ProductServiceName
               }
               , new Object[] {
               P002C3_A74ProductServiceName, P002C3_A73ProductServiceId
               }
               , new Object[] {
               P002C4_A83ResidentTypeName, P002C4_A82ResidentTypeId
               }
               , new Object[] {
               P002C5_A31ResidentId, P002C5_A82ResidentTypeId, P002C5_A83ResidentTypeName
               }
               , new Object[] {
               P002C6_A82ResidentTypeId, P002C6_A83ResidentTypeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20ResidentId ;
      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short AV32ProductServiceId_Filter ;
      private short AV37GXLvl31 ;
      private short A73ProductServiceId ;
      private short A82ResidentTypeId ;
      private short A31ResidentId ;
      private short AV28ResidentTypeId ;
      private int AV11MaxItems ;
      private int AV36GXV1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private int GXPagingFrom4 ;
      private int GXPagingTo4 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string AV31ValueItem ;
      private string A74ProductServiceName ;
      private string lV14SearchTxt ;
      private string A83ResidentTypeName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV30ValuesCollection ;
      private GxSimpleCollection<string> AV29DscsCollection ;
      private IDataStoreProvider pr_default ;
      private short[] P002C2_A73ProductServiceId ;
      private string[] P002C2_A74ProductServiceName ;
      private string[] P002C3_A74ProductServiceName ;
      private short[] P002C3_A73ProductServiceId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private string[] P002C4_A83ResidentTypeName ;
      private short[] P002C4_A82ResidentTypeId ;
      private short[] P002C5_A31ResidentId ;
      private short[] P002C5_A82ResidentTypeId ;
      private string[] P002C5_A83ResidentTypeName ;
      private short[] P002C6_A82ResidentTypeId ;
      private string[] P002C6_A83ResidentTypeName ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class residentloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002C3( IGxContext context ,
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

      protected Object[] conditional_P002C4( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A83ResidentTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ResidentTypeName, ResidentTypeId";
         sFromString = " FROM ResidentType";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ResidentTypeName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY ResidentTypeName, ResidentTypeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom4" + " LIMIT CASE WHEN " + ":GXPagingTo4" + " > 0 THEN " + ":GXPagingTo4" + " ELSE 1e9 END";
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
               case 1 :
                     return conditional_P002C3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 2 :
                     return conditional_P002C4(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP002C2;
          prmP002C2 = new Object[] {
          new ParDef("AV32ProductServiceId_Filter",GXType.Int16,4,0)
          };
          Object[] prmP002C5;
          prmP002C5 = new Object[] {
          new ParDef("AV20ResidentId",GXType.Int16,4,0)
          };
          Object[] prmP002C6;
          prmP002C6 = new Object[] {
          new ParDef("AV28ResidentTypeId",GXType.Int16,4,0)
          };
          Object[] prmP002C3;
          prmP002C3 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          Object[] prmP002C4;
          prmP002C4 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002C2", "SELECT ProductServiceId, ProductServiceName FROM ProductService WHERE ProductServiceId = :AV32ProductServiceId_Filter ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002C5", "SELECT T1.ResidentId, T1.ResidentTypeId, T2.ResidentTypeName FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) WHERE T1.ResidentId = :AV20ResidentId ORDER BY T1.ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002C6", "SELECT ResidentTypeId, ResidentTypeName FROM ResidentType WHERE ResidentTypeId = :AV28ResidentTypeId ORDER BY ResidentTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C6,1, GxCacheFrequency.OFF ,false,true )
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
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
