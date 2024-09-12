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
   public class addgensuppliersloaddvcombo : GXProcedure
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
            return "addgensuppliers_Services_Execute" ;
         }

      }

      public addgensuppliersloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public addgensuppliersloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_SearchTxtParms ,
                           out string aP2_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18SearchTxtParms = aP1_SearchTxtParms;
         this.AV19Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP2_Combo_DataJson=this.AV19Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_SearchTxtParms, out aP2_Combo_DataJson);
         return AV19Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_SearchTxtParms ,
                                 out string aP2_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18SearchTxtParms = aP1_SearchTxtParms;
         this.AV19Combo_DataJson = "" ;
         SubmitImpl();
         aP2_Combo_DataJson=this.AV19Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV18SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? "" : StringUtil.Substring( AV18SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenOptions") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENOPTIONS' */
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
         /* 'LOADCOMBOITEMS_SUPPLIERGENOPTIONS' Routine */
         returnInSub = false;
         GXPagingFrom2 = AV12SkipItems;
         GXPagingTo2 = AV11MaxItems;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV14SearchTxt ,
                                              A66Supplier_GenCompanyName } ,
                                              new int[]{
                                              }
         });
         lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
         /* Using cursor P002W2 */
         pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A66Supplier_GenCompanyName = P002W2_A66Supplier_GenCompanyName[0];
            A64Supplier_GenId = P002W2_A64Supplier_GenId[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A64Supplier_GenId), 4, 0));
            AV16Combo_DataItem.gxTpr_Title = A66Supplier_GenCompanyName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            if ( AV15Combo_Data.Count > AV11MaxItems )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV19Combo_DataJson = AV15Combo_Data.ToJSonString(false);
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
         AV19Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         lV14SearchTxt = "";
         A66Supplier_GenCompanyName = "";
         P002W2_A66Supplier_GenCompanyName = new string[] {""} ;
         P002W2_A64Supplier_GenId = new short[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.addgensuppliersloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P002W2_A66Supplier_GenCompanyName, P002W2_A64Supplier_GenId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short A64Supplier_GenId ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string AV17ComboName ;
      private string AV18SearchTxtParms ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A66Supplier_GenCompanyName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P002W2_A66Supplier_GenCompanyName ;
      private short[] P002W2_A64Supplier_GenId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private string aP2_Combo_DataJson ;
   }

   public class addgensuppliersloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002W2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A66Supplier_GenCompanyName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Supplier_GenCompanyName, Supplier_GenId";
         sFromString = " FROM Supplier_Gen";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY Supplier_GenCompanyName, Supplier_GenId";
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
                     return conditional_P002W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP002W2;
          prmP002W2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002W2,100, GxCacheFrequency.OFF ,false,false )
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
