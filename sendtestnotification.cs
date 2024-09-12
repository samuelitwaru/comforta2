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
   public class sendtestnotification : GXProcedure
   {
      public sendtestnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sendtestnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Title ,
                           string aP1_Message ,
                           out string aP2_response )
      {
         this.AV15Title = aP0_Title;
         this.AV10Message = aP1_Message;
         this.AV17response = "" ;
         initialize();
         ExecuteImpl();
         aP2_response=this.AV17response;
      }

      public string executeUdp( string aP0_Title ,
                                string aP1_Message )
      {
         execute(aP0_Title, aP1_Message, out aP2_response);
         return AV17response ;
      }

      public void executeSubmit( string aP0_Title ,
                                 string aP1_Message ,
                                 out string aP2_response )
      {
         this.AV15Title = aP0_Title;
         this.AV10Message = aP1_Message;
         this.AV17response = "" ;
         SubmitImpl();
         aP2_response=this.AV17response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12TheNotification.gxTpr_Title.gxTpr_Defaulttext = AV15Title;
         AV12TheNotification.gxTpr_Text.gxTpr_Defaulttext = AV10Message;
         AV14TheNotificationDelivery.gxTpr_Priority = "High";
         AV13TheNotificationConfiguration.gxTpr_Applicationid = "Comforta";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15Title)) || String.IsNullOrEmpty(StringUtil.RTrim( AV10Message)) )
         {
            AV9IsSuccessful = false;
         }
         else
         {
            /* Using cursor P003L2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A137DeviceToken = P003L2_A137DeviceToken[0];
               A135DeviceId = P003L2_A135DeviceId[0];
               new GeneXus.Core.genexus.common.notifications.sendnotification(context ).execute(  AV13TheNotificationConfiguration,  A137DeviceToken,  AV12TheNotification,  AV14TheNotificationDelivery, out  AV11OutMessages, out  AV9IsSuccessful) ;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( AV9IsSuccessful )
         {
            AV17response = "Notification sent";
         }
         else
         {
            AV17response = "Notification could not be sent";
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
         AV17response = "";
         AV12TheNotification = new GeneXus.Core.genexus.common.notifications.SdtNotification(context);
         AV14TheNotificationDelivery = new GeneXus.Core.genexus.common.notifications.SdtDelivery(context);
         AV13TheNotificationConfiguration = new GeneXus.Core.genexus.common.notifications.SdtConfiguration(context);
         P003L2_A137DeviceToken = new string[] {""} ;
         P003L2_A135DeviceId = new string[] {""} ;
         A137DeviceToken = "";
         A135DeviceId = "";
         AV11OutMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sendtestnotification__default(),
            new Object[][] {
                new Object[] {
               P003L2_A137DeviceToken, P003L2_A135DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A137DeviceToken ;
      private string A135DeviceId ;
      private bool AV9IsSuccessful ;
      private string AV17response ;
      private string AV15Title ;
      private string AV10Message ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Core.genexus.common.notifications.SdtNotification AV12TheNotification ;
      private GeneXus.Core.genexus.common.notifications.SdtDelivery AV14TheNotificationDelivery ;
      private GeneXus.Core.genexus.common.notifications.SdtConfiguration AV13TheNotificationConfiguration ;
      private IDataStoreProvider pr_default ;
      private string[] P003L2_A137DeviceToken ;
      private string[] P003L2_A135DeviceId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11OutMessages ;
      private string aP2_response ;
   }

   public class sendtestnotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003L2;
          prmP003L2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P003L2", "SELECT DeviceToken, DeviceId FROM Device ORDER BY DeviceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003L2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1000);
                ((string[]) buf[1])[0] = rslt.getString(2, 128);
                return;
       }
    }

 }

}
