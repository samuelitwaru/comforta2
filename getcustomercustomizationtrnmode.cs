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
   public class getcustomercustomizationtrnmode : GXProcedure
   {
      public getcustomercustomizationtrnmode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getcustomercustomizationtrnmode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_TrnMode )
      {
         this.AV8TrnMode = aP0_TrnMode;
         initialize();
         ExecuteImpl();
         aP0_TrnMode=this.AV8TrnMode;
      }

      public string executeUdp( )
      {
         execute(ref aP0_TrnMode);
         return AV8TrnMode ;
      }

      public void executeSubmit( ref string aP0_TrnMode )
      {
         this.AV8TrnMode = aP0_TrnMode;
         SubmitImpl();
         aP0_TrnMode=this.AV8TrnMode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GXLvl1 = 0;
         AV10Udparg1 = new getloggedinusercustomerid(context).executeUdp( );
         /* Using cursor P003G2 */
         pr_default.execute(0, new Object[] {AV10Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1CustomerId = P003G2_A1CustomerId[0];
            A128CustomerCustomizationId = P003G2_A128CustomerCustomizationId[0];
            AV9GXLvl1 = 1;
            AV8TrnMode = "UPD";
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9GXLvl1 == 0 )
         {
            AV8TrnMode = "INS";
         }
         cleanup();
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
         P003G2_A1CustomerId = new short[1] ;
         P003G2_A128CustomerCustomizationId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getcustomercustomizationtrnmode__default(),
            new Object[][] {
                new Object[] {
               P003G2_A1CustomerId, P003G2_A128CustomerCustomizationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9GXLvl1 ;
      private short AV10Udparg1 ;
      private short A1CustomerId ;
      private short A128CustomerCustomizationId ;
      private string AV8TrnMode ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_TrnMode ;
      private IDataStoreProvider pr_default ;
      private short[] P003G2_A1CustomerId ;
      private short[] P003G2_A128CustomerCustomizationId ;
   }

   public class getcustomercustomizationtrnmode__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP003G2;
          prmP003G2 = new Object[] {
          new ParDef("AV10Udparg1",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003G2", "SELECT CustomerId, CustomerCustomizationId FROM CustomerCustomization WHERE CustomerId = :AV10Udparg1 ORDER BY CustomerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003G2,100, GxCacheFrequency.OFF ,false,false )
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
                return;
       }
    }

 }

}
