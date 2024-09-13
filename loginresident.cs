using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class loginresident : GXProcedure
   {
      public loginresident( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loginresident( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_secretKey ,
                           out SdtLoginResidentResponseSDT aP1_response )
      {
         this.AV15secretKey = aP0_secretKey;
         this.AV17response = new SdtLoginResidentResponseSDT(context) ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV17response;
      }

      public SdtLoginResidentResponseSDT executeUdp( string aP0_secretKey )
      {
         execute(aP0_secretKey, out aP1_response);
         return AV17response ;
      }

      public void executeSubmit( string aP0_secretKey ,
                                 out SdtLoginResidentResponseSDT aP1_response )
      {
         this.AV15secretKey = aP0_secretKey;
         this.AV17response = new SdtLoginResidentResponseSDT(context) ;
         SubmitImpl();
         aP1_response=this.AV17response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9clientId = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getclientid();
         if ( StringUtil.StrCmp(AV16HttpRequest.ServerHost, context.GetMessage( "localhost", "")) == 0 )
         {
            AV8baseUrl = context.GetMessage( "http://localhost:8082/ComfortaNETPostgreSQL", "");
         }
         else
         {
            AV8baseUrl = context.GetMessage( "https://comforta.yukon.software", "");
         }
         AV13url = AV8baseUrl + context.GetMessage( "/oauth/access_token", "");
         new decodeqrcode(context ).execute(  AV15secretKey, out  AV14username, out  AV11password) ;
         AV10httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/x-www-form-urlencoded", ""));
         AV10httpclient.AddVariable(context.GetMessage( "client_id", ""), AV9clientId);
         AV10httpclient.AddVariable(context.GetMessage( "grant_type", ""), context.GetMessage( "password", ""));
         AV10httpclient.AddVariable(context.GetMessage( "scope", ""), context.GetMessage( "gam_user_data", ""));
         AV10httpclient.AddVariable(context.GetMessage( "username", ""), AV14username);
         AV10httpclient.AddVariable(context.GetMessage( "password", ""), AV11password);
         AV10httpclient.Execute(context.GetMessage( "POST", ""), AV13url);
         AV12result = AV10httpclient.ToString();
         if ( StringUtil.Contains( AV12result, "error") )
         {
            AV17response.gxTpr_Expires_in = (decimal)(0);
            AV17response.gxTpr_Scope = "Invalid Key";
         }
         else
         {
            AV17response.FromJSonString(AV12result, null);
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
         AV17response = new SdtLoginResidentResponseSDT(context);
         AV9clientId = "";
         AV16HttpRequest = new GxHttpRequest( context);
         AV8baseUrl = "";
         AV13url = "";
         AV14username = "";
         AV11password = "";
         AV10httpclient = new GxHttpClient( context);
         AV12result = "";
         /* GeneXus formulas. */
      }

      private string AV15secretKey ;
      private string AV12result ;
      private string AV9clientId ;
      private string AV8baseUrl ;
      private string AV13url ;
      private string AV14username ;
      private string AV11password ;
      private GxHttpClient AV10httpclient ;
      private GxHttpRequest AV16HttpRequest ;
      private SdtLoginResidentResponseSDT AV17response ;
      private SdtLoginResidentResponseSDT aP1_response ;
   }

}
