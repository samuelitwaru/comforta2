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
   public class wwp_calendar_deleteevent : GXProcedure
   {
      public wwp_calendar_deleteevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_deleteevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EventId )
      {
         this.AV8EventId = aP0_EventId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_EventId )
      {
         this.AV8EventId = aP0_EventId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10LocationEvent.Load((short)(Math.Round(NumberUtil.Val( AV8EventId, "."), 18, MidpointRounding.ToEven)));
         AV10LocationEvent.Delete();
         context.CommitDataStores("workwithplus.wwp_calendar_deleteevent",pr_default);
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
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_deleteevent__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_deleteevent__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV8EventId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtLocationEvent AV10LocationEvent ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_calendar_deleteevent__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_calendar_deleteevent__default : DataStoreHelperBase, IDataStoreHelper
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
