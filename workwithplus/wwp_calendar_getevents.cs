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
   public class wwp_calendar_getevents : GXProcedure
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

      public wwp_calendar_getevents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_getevents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_IsSearching ,
                           string aP1_TitleFilter ,
                           DateTime aP2_LoadFromDate ,
                           DateTime aP3_LoadToDate ,
                           out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_Gxm2rootcol )
      {
         this.AV5IsSearching = aP0_IsSearching;
         this.AV8TitleFilter = aP1_TitleFilter;
         this.AV6LoadFromDate = aP2_LoadFromDate;
         this.AV7LoadToDate = aP3_LoadToDate;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta2") ;
         initialize();
         ExecuteImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> executeUdp( bool aP0_IsSearching ,
                                                                                                     string aP1_TitleFilter ,
                                                                                                     DateTime aP2_LoadFromDate ,
                                                                                                     DateTime aP3_LoadToDate )
      {
         execute(aP0_IsSearching, aP1_TitleFilter, aP2_LoadFromDate, aP3_LoadToDate, out aP4_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( bool aP0_IsSearching ,
                                 string aP1_TitleFilter ,
                                 DateTime aP2_LoadFromDate ,
                                 DateTime aP3_LoadToDate ,
                                 out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_Gxm2rootcol )
      {
         this.AV5IsSearching = aP0_IsSearching;
         this.AV8TitleFilter = aP1_TitleFilter;
         this.AV6LoadFromDate = aP2_LoadFromDate;
         this.AV7LoadToDate = aP3_LoadToDate;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta2") ;
         SubmitImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! AV5IsSearching )
         {
            AV9RealLoadToDate = DateTimeUtil.DAdd( AV7LoadToDate, (1));
         }
         if ( AV5IsSearching )
         {
            AV9RealLoadToDate = AV7LoadToDate;
         }
         AV13Udparg3 = new getloggedinusercustomerid(context).executeUdp( );
         AV14Udparg4 = new getreceptionistlocationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV6LoadFromDate ,
                                              AV9RealLoadToDate ,
                                              AV8TitleFilter ,
                                              A116LocationEventStartDate ,
                                              A117LocationEventEndDate ,
                                              A118LocationEventTitle ,
                                              AV13Udparg3 ,
                                              AV14Udparg4 ,
                                              A1CustomerId ,
                                              A18CustomerLocationId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV8TitleFilter = StringUtil.Concat( StringUtil.RTrim( AV8TitleFilter), "%", "");
         /* Using cursor P000A2 */
         pr_default.execute(0, new Object[] {AV13Udparg3, AV14Udparg4, AV6LoadFromDate, AV9RealLoadToDate, AV6LoadFromDate, AV6LoadFromDate, lV8TitleFilter});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A18CustomerLocationId = P000A2_A18CustomerLocationId[0];
            A1CustomerId = P000A2_A1CustomerId[0];
            A118LocationEventTitle = P000A2_A118LocationEventTitle[0];
            A117LocationEventEndDate = P000A2_A117LocationEventEndDate[0];
            A116LocationEventStartDate = P000A2_A116LocationEventStartDate[0];
            A115LocationEventId = P000A2_A115LocationEventId[0];
            A125LocationEventAllDay = P000A2_A125LocationEventAllDay[0];
            Gxm1wwp_calendar_events = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
            Gxm2rootcol.Add(Gxm1wwp_calendar_events, 0);
            Gxm1wwp_calendar_events.gxTpr_Id = StringUtil.Str( (decimal)(A115LocationEventId), 4, 0);
            Gxm1wwp_calendar_events.gxTpr_Allday = A125LocationEventAllDay;
            Gxm1wwp_calendar_events.gxTpr_Start = A116LocationEventStartDate;
            Gxm1wwp_calendar_events.gxTpr_End = A117LocationEventEndDate;
            Gxm1wwp_calendar_events.gxTpr_Title = A118LocationEventTitle;
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
         AV9RealLoadToDate = DateTime.MinValue;
         lV8TitleFilter = "";
         A116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         A117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         A118LocationEventTitle = "";
         P000A2_A18CustomerLocationId = new short[1] ;
         P000A2_A1CustomerId = new short[1] ;
         P000A2_A118LocationEventTitle = new string[] {""} ;
         P000A2_A117LocationEventEndDate = new DateTime[] {DateTime.MinValue} ;
         P000A2_A116LocationEventStartDate = new DateTime[] {DateTime.MinValue} ;
         P000A2_A115LocationEventId = new short[1] ;
         P000A2_A125LocationEventAllDay = new bool[] {false} ;
         Gxm1wwp_calendar_events = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_getevents__default(),
            new Object[][] {
                new Object[] {
               P000A2_A18CustomerLocationId, P000A2_A1CustomerId, P000A2_A118LocationEventTitle, P000A2_A117LocationEventEndDate, P000A2_A116LocationEventStartDate, P000A2_A115LocationEventId, P000A2_A125LocationEventAllDay
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13Udparg3 ;
      private short AV14Udparg4 ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
      private short A115LocationEventId ;
      private DateTime AV6LoadFromDate ;
      private DateTime A116LocationEventStartDate ;
      private DateTime A117LocationEventEndDate ;
      private DateTime AV7LoadToDate ;
      private DateTime AV9RealLoadToDate ;
      private bool AV5IsSearching ;
      private bool A125LocationEventAllDay ;
      private string AV8TitleFilter ;
      private string lV8TitleFilter ;
      private string A118LocationEventTitle ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private short[] P000A2_A18CustomerLocationId ;
      private short[] P000A2_A1CustomerId ;
      private string[] P000A2_A118LocationEventTitle ;
      private DateTime[] P000A2_A117LocationEventEndDate ;
      private DateTime[] P000A2_A116LocationEventStartDate ;
      private short[] P000A2_A115LocationEventId ;
      private bool[] P000A2_A125LocationEventAllDay ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item Gxm1wwp_calendar_events ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_Gxm2rootcol ;
   }

   public class wwp_calendar_getevents__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000A2( IGxContext context ,
                                             DateTime AV6LoadFromDate ,
                                             DateTime AV9RealLoadToDate ,
                                             string AV8TitleFilter ,
                                             DateTime A116LocationEventStartDate ,
                                             DateTime A117LocationEventEndDate ,
                                             string A118LocationEventTitle ,
                                             short AV13Udparg3 ,
                                             short AV14Udparg4 ,
                                             short A1CustomerId ,
                                             short A18CustomerLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CustomerLocationId, CustomerId, LocationEventTitle, LocationEventEndDate, LocationEventStartDate, LocationEventId, LocationEventAllDay FROM LocationEvent";
         AddWhere(sWhereString, "(CustomerId = :AV13Udparg3 and CustomerLocationId = :AV14Udparg4)");
         if ( ! (DateTime.MinValue==AV6LoadFromDate) && ! (DateTime.MinValue==AV9RealLoadToDate) )
         {
            AddWhere(sWhereString, "(LocationEventStartDate >= :AV6LoadFromDate and LocationEventStartDate < :AV9RealLoadToDate or LocationEventStartDate < :AV6LoadFromDate and LocationEventEndDate >= :AV6LoadFromDate)");
         }
         else
         {
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8TitleFilter)) )
         {
            AddWhere(sWhereString, "(LocationEventTitle like '%' || :lV8TitleFilter)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CustomerId, CustomerLocationId";
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
                     return conditional_P000A2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
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
          Object[] prmP000A2;
          prmP000A2 = new Object[] {
          new ParDef("AV13Udparg3",GXType.Int16,4,0) ,
          new ParDef("AV14Udparg4",GXType.Int16,4,0) ,
          new ParDef("AV6LoadFromDate",GXType.DateTime,8,5) ,
          new ParDef("AV9RealLoadToDate",GXType.Date,8,0) ,
          new ParDef("AV6LoadFromDate",GXType.DateTime,8,5) ,
          new ParDef("AV6LoadFromDate",GXType.DateTime,8,5) ,
          new ParDef("lV8TitleFilter",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000A2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                return;
       }
    }

 }

}
