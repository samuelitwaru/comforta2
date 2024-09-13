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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class loginuser : GXProcedure
   {
      public loginuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loginuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_username ,
                           string aP1_password ,
                           out string aP2_result )
      {
         this.AV14username = aP0_username;
         this.AV11password = aP1_password;
         this.AV12result = "" ;
         initialize();
         ExecuteImpl();
         aP2_result=this.AV12result;
      }

      public string executeUdp( string aP0_username ,
                                string aP1_password )
      {
         execute(aP0_username, aP1_password, out aP2_result);
         return AV12result ;
      }

      public void executeSubmit( string aP0_username ,
                                 string aP1_password ,
                                 out string aP2_result )
      {
         this.AV14username = aP0_username;
         this.AV11password = aP1_password;
         this.AV12result = "" ;
         SubmitImpl();
         aP2_result=this.AV12result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8baseUrl = context.GetMessage( "http://localhost:8082/ComfortaNETPostgreSQL", "");
         AV9clientId = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getclientid();
         AV13url = AV8baseUrl + context.GetMessage( "/oauth/access_token", "");
         AV10httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/x-www-form-urlencoded", ""));
         AV10httpclient.AddVariable(context.GetMessage( "client_id", ""), AV9clientId);
         AV10httpclient.AddVariable(context.GetMessage( "grant_type", ""), context.GetMessage( "password", ""));
         AV10httpclient.AddVariable(context.GetMessage( "scope", ""), context.GetMessage( "gam_user_data", ""));
         AV10httpclient.AddVariable(context.GetMessage( "username", ""), AV14username);
         AV10httpclient.AddVariable(context.GetMessage( "password", ""), AV11password);
         AV10httpclient.Execute(context.GetMessage( "POST", ""), AV13url);
         AV12result = AV10httpclient.ToString();
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
         AV12result = "";
         AV8baseUrl = "";
         AV9clientId = "";
         AV13url = "";
         AV10httpclient = new GxHttpClient( context);
         /* GeneXus formulas. */
      }

      private string AV12result ;
      private string AV14username ;
      private string AV11password ;
      private string AV8baseUrl ;
      private string AV9clientId ;
      private string AV13url ;
      private GxHttpClient AV10httpclient ;
      private string aP2_result ;
   }

}
