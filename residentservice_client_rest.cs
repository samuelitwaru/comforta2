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
      public residentservice( )
      {
         context = new GxContext(  );
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
         initialize();
      }

      public residentservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         initialize();
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

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 8082;
         restLocation.BaseUrl = "Comforta2NETPostgreSQL/ResidentService";
         gxProperties = new GxObjectProperties();
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_login( string aP0_username ,
                              string aP1_password ,
                              out string aP2_result )
      {
         restCliLogin = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/api/auth/login";
         restCliLogin.Location = restLocation;
         restCliLogin.HttpMethod = "POST";
         restCliLogin.AddBodyVar("username", (string)(aP0_username));
         restCliLogin.AddBodyVar("password", (string)(aP1_password));
         restCliLogin.RestExecute();
         if ( restCliLogin.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliLogin.ErrorCode;
            gxProperties.ErrorMessage = restCliLogin.ErrorMessage;
            gxProperties.StatusCode = restCliLogin.StatusCode;
            aP2_result = "";
         }
         else
         {
            aP2_result = restCliLogin.GetBodyString("result");
         }
         /* Login Constructor */
      }

      public void gxep_loginwithqrcode( string aP0_secretKey ,
                                        out SdtLoginResidentResponseSDT aP1_response )
      {
         restCliLoginWithQrCode = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/api/auth/resident-login";
         restCliLoginWithQrCode.Location = restLocation;
         restCliLoginWithQrCode.HttpMethod = "POST";
         restCliLoginWithQrCode.AddBodyVar("secretKey", (string)(aP0_secretKey));
         restCliLoginWithQrCode.RestExecute();
         if ( restCliLoginWithQrCode.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliLoginWithQrCode.ErrorCode;
            gxProperties.ErrorMessage = restCliLoginWithQrCode.ErrorMessage;
            gxProperties.StatusCode = restCliLoginWithQrCode.StatusCode;
            aP1_response = new SdtLoginResidentResponseSDT();
         }
         else
         {
            aP1_response = restCliLoginWithQrCode.GetBodySdt<SdtLoginResidentResponseSDT>("response");
         }
         /* LoginWithQrCode Constructor */
      }

      public void gxep_getresidentinformation( string aP0_UserId ,
                                               out SdtResidentDetails aP1_ResidentDetails )
      {
         restCliGetResidentInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/api/auth/resident";
         restCliGetResidentInformation.Location = restLocation;
         restCliGetResidentInformation.HttpMethod = "GET";
         restCliGetResidentInformation.AddQueryVar("Userid", (string)(aP0_UserId));
         restCliGetResidentInformation.RestExecute();
         if ( restCliGetResidentInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetResidentInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetResidentInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetResidentInformation.StatusCode;
            aP1_ResidentDetails = new SdtResidentDetails();
         }
         else
         {
            aP1_ResidentDetails = restCliGetResidentInformation.GetBodySdt<SdtResidentDetails>("ResidentDetails");
         }
         /* GetResidentInformation Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxProperties = new GxObjectProperties();
         restCliLogin = new GXRestAPIClient();
         aP2_result = "";
         restCliLoginWithQrCode = new GXRestAPIClient();
         aP1_response = new SdtLoginResidentResponseSDT();
         restCliGetResidentInformation = new GXRestAPIClient();
         aP1_ResidentDetails = new SdtResidentDetails();
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliLogin ;
      protected GXRestAPIClient restCliLoginWithQrCode ;
      protected GXRestAPIClient restCliGetResidentInformation ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected string aP2_result ;
      protected SdtLoginResidentResponseSDT aP1_response ;
      protected SdtResidentDetails aP1_ResidentDetails ;
   }

}
