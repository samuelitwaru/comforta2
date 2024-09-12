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
namespace GeneXus.Programs.workwithplus {
   public class wwp_calendar_updateeventdate : GXProcedure
   {
      public wwp_calendar_updateeventdate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_updateeventdate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item aP0_EventToUpdate )
      {
         this.AV8EventToUpdate = aP0_EventToUpdate;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item aP0_EventToUpdate )
      {
         this.AV8EventToUpdate = aP0_EventToUpdate;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10LocationEvent.Load((short)(Math.Round(NumberUtil.Val( AV8EventToUpdate.gxTpr_Id, "."), 18, MidpointRounding.ToEven)));
         AV10LocationEvent.gxTpr_Locationeventstartdate = AV8EventToUpdate.gxTpr_Start;
         AV10LocationEvent.gxTpr_Locationeventenddate = AV8EventToUpdate.gxTpr_End;
         AV10LocationEvent.gxTpr_Locationeventallday = AV8EventToUpdate.gxTpr_Allday;
         AV10LocationEvent.Update();
         if ( AV10LocationEvent.Success() )
         {
            context.CommitDataStores("workwithplus.wwp_calendar_updateeventdate",pr_default);
         }
         else
         {
            context.RollbackDataStores("workwithplus.wwp_calendar_updateeventdate",pr_default);
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
         AV10LocationEvent = new SdtLocationEvent(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_updateeventdate__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_updateeventdate__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item AV8EventToUpdate ;
      private SdtLocationEvent AV10LocationEvent ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_calendar_updateeventdate__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class wwp_calendar_updateeventdate__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
