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
   public class getloggedinusercustomerid : GXProcedure
   {
      public getloggedinusercustomerid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getloggedinusercustomerid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_CustomerId )
      {
         this.AV9CustomerId = 0 ;
         initialize();
         ExecuteImpl();
         aP0_CustomerId=this.AV9CustomerId;
      }

      public short executeUdp( )
      {
         execute(out aP0_CustomerId);
         return AV9CustomerId ;
      }

      public void executeSubmit( out short aP0_CustomerId )
      {
         this.AV9CustomerId = 0 ;
         SubmitImpl();
         aP0_CustomerId=this.AV9CustomerId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV12GAMErrors);
         AV14GAMUser = AV13GAMSession.gxTpr_User;
         if ( AV14GAMUser.checkrole("Customer Manager") )
         {
            /* Using cursor P002V2 */
            pr_default.execute(0, new Object[] {AV14GAMUser.gxTpr_Email, AV14GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A10CustomerManagerEmail = P002V2_A10CustomerManagerEmail[0];
               A13CustomerManagerGAMGUID = P002V2_A13CustomerManagerGAMGUID[0];
               A1CustomerId = P002V2_A1CustomerId[0];
               A15CustomerManagerId = P002V2_A15CustomerManagerId[0];
               AV9CustomerId = A1CustomerId;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( AV14GAMUser.checkrole("Receptionist") )
         {
            /* Using cursor P002V3 */
            pr_default.execute(1, new Object[] {AV14GAMUser.gxTpr_Email, AV14GAMUser.gxTpr_Guid});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A27CustomerLocationReceptionistEm = P002V3_A27CustomerLocationReceptionistEm[0];
               A30CustomerLocationReceptionistGA = P002V3_A30CustomerLocationReceptionistGA[0];
               A1CustomerId = P002V3_A1CustomerId[0];
               A18CustomerLocationId = P002V3_A18CustomerLocationId[0];
               A23CustomerLocationReceptionistId = P002V3_A23CustomerLocationReceptionistId[0];
               AV9CustomerId = A1CustomerId;
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         AV13GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV12GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P002V2_A10CustomerManagerEmail = new string[] {""} ;
         P002V2_A13CustomerManagerGAMGUID = new string[] {""} ;
         P002V2_A1CustomerId = new short[1] ;
         P002V2_A15CustomerManagerId = new short[1] ;
         A10CustomerManagerEmail = "";
         A13CustomerManagerGAMGUID = "";
         P002V3_A27CustomerLocationReceptionistEm = new string[] {""} ;
         P002V3_A30CustomerLocationReceptionistGA = new string[] {""} ;
         P002V3_A1CustomerId = new short[1] ;
         P002V3_A18CustomerLocationId = new short[1] ;
         P002V3_A23CustomerLocationReceptionistId = new short[1] ;
         A27CustomerLocationReceptionistEm = "";
         A30CustomerLocationReceptionistGA = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getloggedinusercustomerid__default(),
            new Object[][] {
                new Object[] {
               P002V2_A10CustomerManagerEmail, P002V2_A13CustomerManagerGAMGUID, P002V2_A1CustomerId, P002V2_A15CustomerManagerId
               }
               , new Object[] {
               P002V3_A27CustomerLocationReceptionistEm, P002V3_A30CustomerLocationReceptionistGA, P002V3_A1CustomerId, P002V3_A18CustomerLocationId, P002V3_A23CustomerLocationReceptionistId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9CustomerId ;
      private short A1CustomerId ;
      private short A15CustomerManagerId ;
      private short A18CustomerLocationId ;
      private short A23CustomerLocationReceptionistId ;
      private string A10CustomerManagerEmail ;
      private string A13CustomerManagerGAMGUID ;
      private string A27CustomerLocationReceptionistEm ;
      private string A30CustomerLocationReceptionistGA ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV13GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV14GAMUser ;
      private IDataStoreProvider pr_default ;
      private string[] P002V2_A10CustomerManagerEmail ;
      private string[] P002V2_A13CustomerManagerGAMGUID ;
      private short[] P002V2_A1CustomerId ;
      private short[] P002V2_A15CustomerManagerId ;
      private string[] P002V3_A27CustomerLocationReceptionistEm ;
      private string[] P002V3_A30CustomerLocationReceptionistGA ;
      private short[] P002V3_A1CustomerId ;
      private short[] P002V3_A18CustomerLocationId ;
      private short[] P002V3_A23CustomerLocationReceptionistId ;
      private short aP0_CustomerId ;
   }

   public class getloggedinusercustomerid__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP002V2;
          prmP002V2 = new Object[] {
          new ParDef("AV14GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV14GAMUser__Guid",GXType.Char,40,0)
          };
          Object[] prmP002V3;
          prmP002V3 = new Object[] {
          new ParDef("AV14GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV14GAMUser__Guid",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002V2", "SELECT CustomerManagerEmail, CustomerManagerGAMGUID, CustomerId, CustomerManagerId FROM CustomerManager WHERE (LOWER(CustomerManagerEmail) = ( :AV14GAMUser__Email)) AND (CustomerManagerGAMGUID = ( :AV14GAMUser__Guid)) ORDER BY CustomerId, CustomerManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002V2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002V3", "SELECT CustomerLocationReceptionistEm, CustomerLocationReceptionistGA, CustomerId, CustomerLocationId, CustomerLocationReceptionistId FROM CustomerLocationReceptionist WHERE (LOWER(CustomerLocationReceptionistEm) = ( :AV14GAMUser__Email)) AND (CustomerLocationReceptionistGA = ( :AV14GAMUser__Guid)) ORDER BY CustomerId, CustomerLocationId, CustomerLocationReceptionistId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002V3,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
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
