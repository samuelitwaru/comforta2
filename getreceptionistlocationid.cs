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
   public class getreceptionistlocationid : GXProcedure
   {
      public getreceptionistlocationid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getreceptionistlocationid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_LocationId )
      {
         this.AV9LocationId = 0 ;
         initialize();
         ExecuteImpl();
         aP0_LocationId=this.AV9LocationId;
      }

      public short executeUdp( )
      {
         execute(out aP0_LocationId);
         return AV9LocationId ;
      }

      public void executeSubmit( out short aP0_LocationId )
      {
         this.AV9LocationId = 0 ;
         SubmitImpl();
         aP0_LocationId=this.AV9LocationId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new getloggedinuser(context ).execute( out  AV8GAMUser) ;
         if ( AV8GAMUser.checkrole("Receptionist") )
         {
            /* Using cursor P00312 */
            pr_default.execute(0, new Object[] {AV8GAMUser.gxTpr_Email, AV8GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A27CustomerLocationReceptionistEm = P00312_A27CustomerLocationReceptionistEm[0];
               A30CustomerLocationReceptionistGA = P00312_A30CustomerLocationReceptionistGA[0];
               A18CustomerLocationId = P00312_A18CustomerLocationId[0];
               A1CustomerId = P00312_A1CustomerId[0];
               A23CustomerLocationReceptionistId = P00312_A23CustomerLocationReceptionistId[0];
               AV9LocationId = A18CustomerLocationId;
               pr_default.readNext(0);
            }
            pr_default.close(0);
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
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P00312_A27CustomerLocationReceptionistEm = new string[] {""} ;
         P00312_A30CustomerLocationReceptionistGA = new string[] {""} ;
         P00312_A18CustomerLocationId = new short[1] ;
         P00312_A1CustomerId = new short[1] ;
         P00312_A23CustomerLocationReceptionistId = new short[1] ;
         A27CustomerLocationReceptionistEm = "";
         A30CustomerLocationReceptionistGA = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getreceptionistlocationid__default(),
            new Object[][] {
                new Object[] {
               P00312_A27CustomerLocationReceptionistEm, P00312_A30CustomerLocationReceptionistGA, P00312_A18CustomerLocationId, P00312_A1CustomerId, P00312_A23CustomerLocationReceptionistId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9LocationId ;
      private short A18CustomerLocationId ;
      private short A1CustomerId ;
      private short A23CustomerLocationReceptionistId ;
      private string A27CustomerLocationReceptionistEm ;
      private string A30CustomerLocationReceptionistGA ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private IDataStoreProvider pr_default ;
      private string[] P00312_A27CustomerLocationReceptionistEm ;
      private string[] P00312_A30CustomerLocationReceptionistGA ;
      private short[] P00312_A18CustomerLocationId ;
      private short[] P00312_A1CustomerId ;
      private short[] P00312_A23CustomerLocationReceptionistId ;
      private short aP0_LocationId ;
   }

   public class getreceptionistlocationid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00312;
          prmP00312 = new Object[] {
          new ParDef("AV8GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV8GAMUser__Guid",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00312", "SELECT CustomerLocationReceptionistEm, CustomerLocationReceptionistGA, CustomerLocationId, CustomerId, CustomerLocationReceptionistId FROM CustomerLocationReceptionist WHERE (LOWER(CustomerLocationReceptionistEm) = ( :AV8GAMUser__Email)) AND (CustomerLocationReceptionistGA = ( :AV8GAMUser__Guid)) ORDER BY CustomerId, CustomerLocationId, CustomerLocationReceptionistId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00312,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
