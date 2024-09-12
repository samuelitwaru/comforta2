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
   public class wwp_calendar_getevent : GXProcedure
   {
      public wwp_calendar_getevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_getevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EventId ,
                           out GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item aP1_Calendar_Event )
      {
         this.AV9EventId = aP0_EventId;
         this.AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context) ;
         initialize();
         ExecuteImpl();
         aP1_Calendar_Event=this.AV8Calendar_Event;
      }

      public GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item executeUdp( string aP0_EventId )
      {
         execute(aP0_EventId, out aP1_Calendar_Event);
         return AV8Calendar_Event ;
      }

      public void executeSubmit( string aP0_EventId ,
                                 out GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item aP1_Calendar_Event )
      {
         this.AV9EventId = aP0_EventId;
         this.AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context) ;
         SubmitImpl();
         aP1_Calendar_Event=this.AV8Calendar_Event;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P003D2 */
         pr_default.execute(0, new Object[] {AV9EventId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A115LocationEventId = P003D2_A115LocationEventId[0];
            A125LocationEventAllDay = P003D2_A125LocationEventAllDay[0];
            A118LocationEventTitle = P003D2_A118LocationEventTitle[0];
            A116LocationEventStartDate = P003D2_A116LocationEventStartDate[0];
            A117LocationEventEndDate = P003D2_A117LocationEventEndDate[0];
            AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
            AV8Calendar_Event.gxTpr_Allday = A125LocationEventAllDay;
            AV8Calendar_Event.gxTpr_Title = A118LocationEventTitle;
            AV8Calendar_Event.gxTpr_Start = A116LocationEventStartDate;
            AV8Calendar_Event.gxTpr_End = A117LocationEventEndDate;
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
         AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
         P003D2_A115LocationEventId = new short[1] ;
         P003D2_A125LocationEventAllDay = new bool[] {false} ;
         P003D2_A118LocationEventTitle = new string[] {""} ;
         P003D2_A116LocationEventStartDate = new DateTime[] {DateTime.MinValue} ;
         P003D2_A117LocationEventEndDate = new DateTime[] {DateTime.MinValue} ;
         A118LocationEventTitle = "";
         A116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         A117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_getevent__default(),
            new Object[][] {
                new Object[] {
               P003D2_A115LocationEventId, P003D2_A125LocationEventAllDay, P003D2_A118LocationEventTitle, P003D2_A116LocationEventStartDate, P003D2_A117LocationEventEndDate
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A115LocationEventId ;
      private DateTime A116LocationEventStartDate ;
      private DateTime A117LocationEventEndDate ;
      private bool A125LocationEventAllDay ;
      private string AV9EventId ;
      private string A118LocationEventTitle ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item AV8Calendar_Event ;
      private IDataStoreProvider pr_default ;
      private short[] P003D2_A115LocationEventId ;
      private bool[] P003D2_A125LocationEventAllDay ;
      private string[] P003D2_A118LocationEventTitle ;
      private DateTime[] P003D2_A116LocationEventStartDate ;
      private DateTime[] P003D2_A117LocationEventEndDate ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item aP1_Calendar_Event ;
   }

   public class wwp_calendar_getevent__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003D2;
          prmP003D2 = new Object[] {
          new ParDef("AV9EventId",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003D2", "SELECT LocationEventId, LocationEventAllDay, LocationEventTitle, LocationEventStartDate, LocationEventEndDate FROM LocationEvent WHERE LocationEventId = TO_NUMBER(0 || :AV9EventId,'9999999999999999999999999999.99999999999999') ORDER BY LocationEventId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003D2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                return;
       }
    }

 }

}
