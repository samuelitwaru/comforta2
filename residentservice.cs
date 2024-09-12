using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class residentservice : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel ApiIntegratedSecurityLevel( string permissionMethod )
      {
         if ( StringUtil.StrCmp(permissionMethod, "gxep_login") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_loginwithqrcode") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getresidentinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_registerdevice") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_sendnotification") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         return GAMSecurityLevel.SecurityLow ;
      }

      protected override string ApiExecutePermissionPrefix( string permissionMethod )
      {
         return "" ;
      }

      public residentservice( )
      {
         context = new GxContext(  );
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public residentservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.Method);
         }
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void gxep_login( string aP0_username ,
                              string aP1_password ,
                              out string aP2_result )
      {
         this.AV10username = aP0_username;
         this.AV6password = aP1_password;
         initialize();
         /* Login Constructor */
         new loginuser(context ).execute(  AV10username,  AV6password, out  AV8result) ;
         aP2_result=this.AV8result;
      }

      public void gxep_loginwithqrcode( string aP0_secretKey ,
                                        out SdtLoginResidentResponseSDT aP1_response )
      {
         this.AV11secretKey = aP0_secretKey;
         initialize();
         /* LoginWithQrCode Constructor */
         new loginresident(context ).execute(  AV11secretKey, out  AV15response) ;
         aP1_response=this.AV15response;
      }

      public void gxep_getresidentinformation( string aP0_UserId ,
                                               out SdtResidentDetails aP1_ResidentDetails )
      {
         this.AV9UserId = aP0_UserId;
         initialize();
         /* GetResidentInformation Constructor */
         new getresidentinfo(context ).execute(  AV9UserId, out  AV7ResidentDetails) ;
         aP1_ResidentDetails=this.AV7ResidentDetails;
      }

      public void gxep_registerdevice( string aP0_DeviceToken ,
                                       string aP1_DeviceId ,
                                       short aP2_DeviceType ,
                                       string aP3_NotificationPlatform ,
                                       string aP4_NotificationPlatformId ,
                                       string aP5_UserId ,
                                       out string aP6_Message )
      {
         this.AV18DeviceToken = aP0_DeviceToken;
         this.AV16DeviceId = aP1_DeviceId;
         this.AV19DeviceType = aP2_DeviceType;
         this.AV22NotificationPlatform = aP3_NotificationPlatform;
         this.AV23NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV9UserId = aP5_UserId;
         initialize();
         /* RegisterDevice Constructor */
         new registerresidentdevice(context ).execute(  AV18DeviceToken,  AV16DeviceId,  AV19DeviceType,  AV22NotificationPlatform,  AV23NotificationPlatformId,  AV9UserId, out  AV20Message) ;
         aP6_Message=this.AV20Message;
      }

      public void gxep_sendnotification( string aP0_Title ,
                                         string aP1_Text ,
                                         out string aP2_Message )
      {
         this.AV25Title = aP0_Title;
         this.AV24Text = aP1_Text;
         initialize();
         /* SendNotification Constructor */
         new sendtestnotification(context ).execute(  AV25Title,  AV24Text, out  AV20Message) ;
         aP2_Message=this.AV20Message;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV8result = "";
         AV15response = new SdtLoginResidentResponseSDT(context);
         AV7ResidentDetails = new SdtResidentDetails(context);
         AV20Message = "";
         /* GeneXus formulas. */
      }

      protected short AV19DeviceType ;
      protected string Gx_restmethod ;
      protected string AV18DeviceToken ;
      protected string AV16DeviceId ;
      protected string AV22NotificationPlatform ;
      protected string AV23NotificationPlatformId ;
      protected string AV8result ;
      protected string AV11secretKey ;
      protected string AV20Message ;
      protected string AV10username ;
      protected string AV6password ;
      protected string AV9UserId ;
      protected string AV25Title ;
      protected string AV24Text ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected string aP2_result ;
      protected SdtLoginResidentResponseSDT AV15response ;
      protected SdtLoginResidentResponseSDT aP1_response ;
      protected SdtResidentDetails AV7ResidentDetails ;
      protected SdtResidentDetails aP1_ResidentDetails ;
      protected string aP6_Message ;
      protected string aP2_Message ;
   }

}
