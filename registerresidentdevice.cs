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
   public class registerresidentdevice : GXProcedure
   {
      public registerresidentdevice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public registerresidentdevice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DeviceToken ,
                           string aP1_DeviceId ,
                           short aP2_DeviceType ,
                           string aP3_NotificationPlatform ,
                           string aP4_NotificationPlatformId ,
                           string aP5_UserId ,
                           out string aP6_Message )
      {
         this.AV11DeviceToken = aP0_DeviceToken;
         this.AV9DeviceId = aP1_DeviceId;
         this.AV12DeviceType = aP2_DeviceType;
         this.AV14NotificationPlatform = aP3_NotificationPlatform;
         this.AV15NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV18UserId = aP5_UserId;
         this.AV13Message = "" ;
         initialize();
         ExecuteImpl();
         aP6_Message=this.AV13Message;
      }

      public string executeUdp( string aP0_DeviceToken ,
                                string aP1_DeviceId ,
                                short aP2_DeviceType ,
                                string aP3_NotificationPlatform ,
                                string aP4_NotificationPlatformId ,
                                string aP5_UserId )
      {
         execute(aP0_DeviceToken, aP1_DeviceId, aP2_DeviceType, aP3_NotificationPlatform, aP4_NotificationPlatformId, aP5_UserId, out aP6_Message);
         return AV13Message ;
      }

      public void executeSubmit( string aP0_DeviceToken ,
                                 string aP1_DeviceId ,
                                 short aP2_DeviceType ,
                                 string aP3_NotificationPlatform ,
                                 string aP4_NotificationPlatformId ,
                                 string aP5_UserId ,
                                 out string aP6_Message )
      {
         this.AV11DeviceToken = aP0_DeviceToken;
         this.AV9DeviceId = aP1_DeviceId;
         this.AV12DeviceType = aP2_DeviceType;
         this.AV14NotificationPlatform = aP3_NotificationPlatform;
         this.AV15NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV18UserId = aP5_UserId;
         this.AV13Message = "" ;
         SubmitImpl();
         aP6_Message=this.AV13Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16OneSignalToken = new SdtOneSignalToken(context);
         AV16OneSignalToken.gxTpr_Deviceid = AV9DeviceId;
         AV16OneSignalToken.gxTpr_Devicetoken = AV11DeviceToken;
         AV16OneSignalToken.gxTpr_Devicetype = (decimal)(AV12DeviceType);
         AV16OneSignalToken.gxTpr_Notificationplatform = AV14NotificationPlatform;
         AV16OneSignalToken.gxTpr_Notificationplatformid = AV15NotificationPlatformId;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11DeviceToken)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9DeviceId)) )
         {
            AV13Message = "Device could not be registered";
         }
         else
         {
            AV19GXLvl14 = 0;
            /* Using cursor P003K2 */
            pr_default.execute(0, new Object[] {AV9DeviceId, AV12DeviceType});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A135DeviceId = P003K2_A135DeviceId[0];
               A136DeviceType = P003K2_A136DeviceType[0];
               A137DeviceToken = P003K2_A137DeviceToken[0];
               A138DeviceName = P003K2_A138DeviceName[0];
               AV19GXLvl14 = 1;
               A137DeviceToken = AV16OneSignalToken.ToJSonString(false, true);
               A138DeviceName = AV9DeviceId;
               /* Using cursor P003K3 */
               pr_default.execute(1, new Object[] {A137DeviceToken, A138DeviceName, A135DeviceId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Device");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV19GXLvl14 == 0 )
            {
               /*
                  INSERT RECORD ON TABLE Device

               */
               A136DeviceType = AV12DeviceType;
               A135DeviceId = AV9DeviceId;
               A137DeviceToken = AV16OneSignalToken.ToJSonString(false, true);
               A138DeviceName = AV9DeviceId;
               A139DeviceUserGuid = AV18UserId;
               /* Using cursor P003K4 */
               pr_default.execute(2, new Object[] {A135DeviceId, A136DeviceType, A137DeviceToken, A138DeviceName, A139DeviceUserGuid});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Device");
               if ( (pr_default.getStatus(2) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               /* End Insert */
            }
            AV13Message = "Device registered successfully";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("registerresidentdevice",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV13Message = "";
         AV16OneSignalToken = new SdtOneSignalToken(context);
         P003K2_A135DeviceId = new string[] {""} ;
         P003K2_A136DeviceType = new short[1] ;
         P003K2_A137DeviceToken = new string[] {""} ;
         P003K2_A138DeviceName = new string[] {""} ;
         A135DeviceId = "";
         A137DeviceToken = "";
         A138DeviceName = "";
         A139DeviceUserGuid = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.registerresidentdevice__default(),
            new Object[][] {
                new Object[] {
               P003K2_A135DeviceId, P003K2_A136DeviceType, P003K2_A137DeviceToken, P003K2_A138DeviceName
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12DeviceType ;
      private short AV19GXLvl14 ;
      private short A136DeviceType ;
      private int GX_INS28 ;
      private string AV11DeviceToken ;
      private string AV9DeviceId ;
      private string AV15NotificationPlatformId ;
      private string A135DeviceId ;
      private string A137DeviceToken ;
      private string A138DeviceName ;
      private string Gx_emsg ;
      private string AV13Message ;
      private string AV14NotificationPlatform ;
      private string AV18UserId ;
      private string A139DeviceUserGuid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtOneSignalToken AV16OneSignalToken ;
      private IDataStoreProvider pr_default ;
      private string[] P003K2_A135DeviceId ;
      private short[] P003K2_A136DeviceType ;
      private string[] P003K2_A137DeviceToken ;
      private string[] P003K2_A138DeviceName ;
      private string aP6_Message ;
   }

   public class registerresidentdevice__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003K2;
          prmP003K2 = new Object[] {
          new ParDef("AV9DeviceId",GXType.Char,128,0) ,
          new ParDef("AV12DeviceType",GXType.Int16,1,0)
          };
          Object[] prmP003K3;
          prmP003K3 = new Object[] {
          new ParDef("DeviceToken",GXType.Char,1000,0) ,
          new ParDef("DeviceName",GXType.Char,128,0) ,
          new ParDef("DeviceId",GXType.Char,128,0)
          };
          Object[] prmP003K4;
          prmP003K4 = new Object[] {
          new ParDef("DeviceId",GXType.Char,128,0) ,
          new ParDef("DeviceType",GXType.Int16,1,0) ,
          new ParDef("DeviceToken",GXType.Char,1000,0) ,
          new ParDef("DeviceName",GXType.Char,128,0) ,
          new ParDef("DeviceUserGuid",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P003K2", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName FROM Device WHERE (DeviceId = ( :AV9DeviceId)) AND (DeviceType = :AV12DeviceType) ORDER BY DeviceId  FOR UPDATE OF Device",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P003K3", "SAVEPOINT gxupdate;UPDATE Device SET DeviceToken=:DeviceToken, DeviceName=:DeviceName  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003K3)
             ,new CursorDef("P003K4", "SAVEPOINT gxupdate;INSERT INTO Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserGuid) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUserGuid);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP003K4)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 128);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1000);
                ((string[]) buf[3])[0] = rslt.getString(4, 128);
                return;
       }
    }

 }

}
