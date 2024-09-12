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
   public class getcustomercustomizationid : GXProcedure
   {
      public getcustomercustomizationid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getcustomercustomizationid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_CustomerCustomizationId )
      {
         this.AV9CustomerCustomizationId = 0 ;
         initialize();
         ExecuteImpl();
         aP0_CustomerCustomizationId=this.AV9CustomerCustomizationId;
      }

      public short executeUdp( )
      {
         execute(out aP0_CustomerCustomizationId);
         return AV9CustomerCustomizationId ;
      }

      public void executeSubmit( out short aP0_CustomerCustomizationId )
      {
         this.AV9CustomerCustomizationId = 0 ;
         SubmitImpl();
         aP0_CustomerCustomizationId=this.AV9CustomerCustomizationId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Udparg1 = new getloggedinusercustomerid(context).executeUdp( );
         /* Using cursor P003I2 */
         pr_default.execute(0, new Object[] {AV11Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1CustomerId = P003I2_A1CustomerId[0];
            A128CustomerCustomizationId = P003I2_A128CustomerCustomizationId[0];
            AV9CustomerCustomizationId = A128CustomerCustomizationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P003I2_A1CustomerId = new short[1] ;
         P003I2_A128CustomerCustomizationId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getcustomercustomizationid__default(),
            new Object[][] {
                new Object[] {
               P003I2_A1CustomerId, P003I2_A128CustomerCustomizationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9CustomerCustomizationId ;
      private short AV11Udparg1 ;
      private short A1CustomerId ;
      private short A128CustomerCustomizationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003I2_A1CustomerId ;
      private short[] P003I2_A128CustomerCustomizationId ;
      private short aP0_CustomerCustomizationId ;
   }

   public class getcustomercustomizationid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003I2;
          prmP003I2 = new Object[] {
          new ParDef("AV11Udparg1",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003I2", "SELECT CustomerId, CustomerCustomizationId FROM CustomerCustomization WHERE CustomerId = :AV11Udparg1 ORDER BY CustomerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003I2,100, GxCacheFrequency.OFF ,false,false )
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
