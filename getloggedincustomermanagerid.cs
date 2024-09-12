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
   public class getloggedincustomermanagerid : GXProcedure
   {
      public getloggedincustomermanagerid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getloggedincustomermanagerid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_CustomerManagerId ,
                           out SdtCustomer aP1_Customer )
      {
         this.AV10CustomerManagerId = 0 ;
         this.AV8Customer = new SdtCustomer(context) ;
         initialize();
         ExecuteImpl();
         aP0_CustomerManagerId=this.AV10CustomerManagerId;
         aP1_Customer=this.AV8Customer;
      }

      public SdtCustomer executeUdp( out short aP0_CustomerManagerId )
      {
         execute(out aP0_CustomerManagerId, out aP1_Customer);
         return AV8Customer ;
      }

      public void executeSubmit( out short aP0_CustomerManagerId ,
                                 out SdtCustomer aP1_Customer )
      {
         this.AV10CustomerManagerId = 0 ;
         this.AV8Customer = new SdtCustomer(context) ;
         SubmitImpl();
         aP0_CustomerManagerId=this.AV10CustomerManagerId;
         aP1_Customer=this.AV8Customer;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV11GAMErrors);
         AV13GAMUser = AV12GAMSession.gxTpr_User;
         /* Using cursor P002Y2 */
         pr_default.execute(0, new Object[] {AV13GAMUser.gxTpr_Email, AV13GAMUser.gxTpr_Guid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A10CustomerManagerEmail = P002Y2_A10CustomerManagerEmail[0];
            A13CustomerManagerGAMGUID = P002Y2_A13CustomerManagerGAMGUID[0];
            A1CustomerId = P002Y2_A1CustomerId[0];
            A15CustomerManagerId = P002Y2_A15CustomerManagerId[0];
            AV8Customer.Load(A1CustomerId);
            AV10CustomerManagerId = A15CustomerManagerId;
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
         AV8Customer = new SdtCustomer(context);
         AV12GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV11GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P002Y2_A10CustomerManagerEmail = new string[] {""} ;
         P002Y2_A13CustomerManagerGAMGUID = new string[] {""} ;
         P002Y2_A1CustomerId = new short[1] ;
         P002Y2_A15CustomerManagerId = new short[1] ;
         A10CustomerManagerEmail = "";
         A13CustomerManagerGAMGUID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getloggedincustomermanagerid__default(),
            new Object[][] {
                new Object[] {
               P002Y2_A10CustomerManagerEmail, P002Y2_A13CustomerManagerGAMGUID, P002Y2_A1CustomerId, P002Y2_A15CustomerManagerId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10CustomerManagerId ;
      private short A1CustomerId ;
      private short A15CustomerManagerId ;
      private string A10CustomerManagerEmail ;
      private string A13CustomerManagerGAMGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtCustomer AV8Customer ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV12GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV13GAMUser ;
      private IDataStoreProvider pr_default ;
      private string[] P002Y2_A10CustomerManagerEmail ;
      private string[] P002Y2_A13CustomerManagerGAMGUID ;
      private short[] P002Y2_A1CustomerId ;
      private short[] P002Y2_A15CustomerManagerId ;
      private short aP0_CustomerManagerId ;
      private SdtCustomer aP1_Customer ;
   }

   public class getloggedincustomermanagerid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002Y2;
          prmP002Y2 = new Object[] {
          new ParDef("AV13GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV13GAMUser__Guid",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002Y2", "SELECT CustomerManagerEmail, CustomerManagerGAMGUID, CustomerId, CustomerManagerId FROM CustomerManager WHERE (LOWER(CustomerManagerEmail) = ( :AV13GAMUser__Email)) AND (CustomerManagerGAMGUID = ( :AV13GAMUser__Guid)) ORDER BY CustomerId, CustomerManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y2,100, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
