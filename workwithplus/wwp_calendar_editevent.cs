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
   public class wwp_calendar_editevent : GXProcedure
   {
      public wwp_calendar_editevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_editevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_Title ,
                           DateTime aP2_Date ,
                           DateTime aP3_FromTime ,
                           DateTime aP4_ToTime ,
                           bool aP5_AllDay ,
                           DateTime aP6_EndDate ,
                           string aP7_CalendarEventId ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP8_ErrorMessages ,
                           out bool aP9_EventCreated )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV18Title = aP1_Title;
         this.AV13Date = aP2_Date;
         this.AV17FromTime = aP3_FromTime;
         this.AV19ToTime = aP4_ToTime;
         this.AV11AllDay = aP5_AllDay;
         this.AV14EndDate = aP6_EndDate;
         this.AV12CalendarEventId = aP7_CalendarEventId;
         this.AV9ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV15EventCreated = false ;
         initialize();
         ExecuteImpl();
         aP8_ErrorMessages=this.AV9ErrorMessages;
         aP9_EventCreated=this.AV15EventCreated;
      }

      public bool executeUdp( string aP0_Gx_mode ,
                              string aP1_Title ,
                              DateTime aP2_Date ,
                              DateTime aP3_FromTime ,
                              DateTime aP4_ToTime ,
                              bool aP5_AllDay ,
                              DateTime aP6_EndDate ,
                              string aP7_CalendarEventId ,
                              out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP8_ErrorMessages )
      {
         execute(aP0_Gx_mode, aP1_Title, aP2_Date, aP3_FromTime, aP4_ToTime, aP5_AllDay, aP6_EndDate, aP7_CalendarEventId, out aP8_ErrorMessages, out aP9_EventCreated);
         return AV15EventCreated ;
      }

      public void executeSubmit( string aP0_Gx_mode ,
                                 string aP1_Title ,
                                 DateTime aP2_Date ,
                                 DateTime aP3_FromTime ,
                                 DateTime aP4_ToTime ,
                                 bool aP5_AllDay ,
                                 DateTime aP6_EndDate ,
                                 string aP7_CalendarEventId ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP8_ErrorMessages ,
                                 out bool aP9_EventCreated )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV18Title = aP1_Title;
         this.AV13Date = aP2_Date;
         this.AV17FromTime = aP3_FromTime;
         this.AV19ToTime = aP4_ToTime;
         this.AV11AllDay = aP5_AllDay;
         this.AV14EndDate = aP6_EndDate;
         this.AV12CalendarEventId = aP7_CalendarEventId;
         this.AV9ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV15EventCreated = false ;
         SubmitImpl();
         aP8_ErrorMessages=this.AV9ErrorMessages;
         aP9_EventCreated=this.AV15EventCreated;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV11AllDay )
         {
            AV10EventStartDate = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV13Date)), (short)(DateTimeUtil.Month( AV13Date)), (short)(DateTimeUtil.Day( AV13Date)), 0, 0, 0);
            AV16EventEndDate = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV14EndDate)), (short)(DateTimeUtil.Month( AV14EndDate)), (short)(DateTimeUtil.Day( AV14EndDate)), 0, 0, 0);
         }
         else
         {
            AV10EventStartDate = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV13Date)), (short)(DateTimeUtil.Month( AV13Date)), (short)(DateTimeUtil.Day( AV13Date)), (short)(DateTimeUtil.Hour( AV17FromTime)), (short)(DateTimeUtil.Minute( AV17FromTime)), 0);
            AV16EventEndDate = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV14EndDate)), (short)(DateTimeUtil.Month( AV14EndDate)), (short)(DateTimeUtil.Day( AV14EndDate)), (short)(DateTimeUtil.Hour( AV19ToTime)), (short)(DateTimeUtil.Minute( AV19ToTime)), 0);
         }
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV8Message.gxTpr_Description = context.GetMessage( "In order to add events, you need to add the code in the procedures that are in WorkWithPlus Module / UCCalendar / CalendarUser folder", "");
         AV9ErrorMessages.Add(AV8Message, 0);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV22LocationEvent.Load((short)(Math.Round(NumberUtil.Val( AV12CalendarEventId, "."), 18, MidpointRounding.ToEven)));
         }
         else
         {
         }
         AV22LocationEvent.gxTpr_Locationeventallday = AV11AllDay;
         GXt_int1 = 0;
         new getloggedinusercustomerid(context ).execute( out  GXt_int1) ;
         AV22LocationEvent.gxTpr_Customerid = GXt_int1;
         GXt_int1 = 0;
         new getreceptionistlocationid(context ).execute( out  GXt_int1) ;
         AV22LocationEvent.gxTpr_Customerlocationid = GXt_int1;
         AV22LocationEvent.gxTpr_Locationeventstartdate = AV10EventStartDate;
         AV22LocationEvent.gxTpr_Locationeventenddate = AV16EventEndDate;
         AV22LocationEvent.gxTpr_Locationeventtitle = AV18Title;
         AV22LocationEvent.Save();
         if ( AV22LocationEvent.Success() )
         {
            context.CommitDataStores("workwithplus.wwp_calendar_editevent",pr_default);
            AV15EventCreated = true;
         }
         else
         {
            AV9ErrorMessages = AV22LocationEvent.GetMessages();
            context.RollbackDataStores("workwithplus.wwp_calendar_editevent",pr_default);
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
         AV9ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10EventStartDate = (DateTime)(DateTime.MinValue);
         AV16EventEndDate = (DateTime)(DateTime.MinValue);
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV22LocationEvent = new SdtLocationEvent(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_editevent__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_editevent__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int1 ;
      private string Gx_mode ;
      private DateTime AV17FromTime ;
      private DateTime AV19ToTime ;
      private DateTime AV10EventStartDate ;
      private DateTime AV16EventEndDate ;
      private DateTime AV13Date ;
      private DateTime AV14EndDate ;
      private bool AV11AllDay ;
      private bool AV15EventCreated ;
      private string AV18Title ;
      private string AV12CalendarEventId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9ErrorMessages ;
      private GeneXus.Utils.SdtMessages_Message AV8Message ;
      private SdtLocationEvent AV22LocationEvent ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP8_ErrorMessages ;
      private bool aP9_EventCreated ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_calendar_editevent__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_calendar_editevent__default : DataStoreHelperBase, IDataStoreHelper
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
