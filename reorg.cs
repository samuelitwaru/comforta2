using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         SetCreateDataBase( ) ;
         CreateDataBase( ) ;
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void CreateDataBase( )
      {
         DS = (GxDataStore)(context.GetDataStore( "Default"));
         ErrCode = DS.Connection.FullConnect();
         DataBaseName = DS.Connection.Database;
         if ( ErrCode != 0 )
         {
            DS.Connection.Database = "postgres";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "\"" + DataBaseName + "\"";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  Count = 1;
               }
               catch ( Exception ex )
               {
                  ErrCode = 1;
                  GeneXus.Reorg.GXReorganization.AddMsg( ex.Message , null);
                  throw;
               }
               ErrCode = DS.Connection.Disconnect();
               DS.Connection.Database = DataBaseName;
               ErrCode = DS.Connection.FullConnect();
               while ( ( ErrCode != 0 ) && ( Count > 0 ) && ( Count < 30 ) )
               {
                  Res = GXUtil.Sleep( 1);
                  ErrCode = DS.Connection.FullConnect();
                  Count = (short)(Count+1);
               }
            }
            if ( ErrCode != 0 )
            {
               ErrMsg = DS.ErrDescription;
               GeneXus.Reorg.GXReorganization.AddMsg( ErrMsg , null);
               ErrCode = 1;
               throw new Exception( ErrMsg) ;
            }
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateDevice( )
      {
         string cmdBuffer = "";
         /* Indices for table Device */
         try
         {
            cmdBuffer=" CREATE TABLE Device (DeviceId CHAR(128) NOT NULL , DeviceType smallint NOT NULL , DeviceToken CHAR(1000) NOT NULL , DeviceName CHAR(128) NOT NULL , DeviceUserGuid VARCHAR(100) NOT NULL , PRIMARY KEY(DeviceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Device CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Device CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Device CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Device (DeviceId CHAR(128) NOT NULL , DeviceType smallint NOT NULL , DeviceToken CHAR(1000) NOT NULL , DeviceName CHAR(128) NOT NULL , DeviceUserGuid VARCHAR(100) NOT NULL , PRIMARY KEY(DeviceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCustomerCustomization( )
      {
         string cmdBuffer = "";
         /* Indices for table CustomerCustomization */
         try
         {
            cmdBuffer=" CREATE SEQUENCE CustomerCustomizationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE CustomerCustomizationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE CustomerCustomizationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE CustomerCustomization (CustomerCustomizationId smallint NOT NULL DEFAULT nextval('CustomerCustomizationId'), CustomerCustomizationLogo BYTEA NOT NULL , CustomerCustomizationLogo_GXI VARCHAR(2048) , CustomerCustomizationFavicon BYTEA NOT NULL , CustomerCustomizationFavicon_G VARCHAR(2048) , CustomerCustomizationBaseColor VARCHAR(40) NOT NULL , CustomerCustomizationFontSize VARCHAR(40) NOT NULL , CustomerId smallint NOT NULL , PRIMARY KEY(CustomerCustomizationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CustomerCustomization CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CustomerCustomization CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CustomerCustomization CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CustomerCustomization (CustomerCustomizationId smallint NOT NULL DEFAULT nextval('CustomerCustomizationId'), CustomerCustomizationLogo BYTEA NOT NULL , CustomerCustomizationLogo_GXI VARCHAR(2048) , CustomerCustomizationFavicon BYTEA NOT NULL , CustomerCustomizationFavicon_G VARCHAR(2048) , CustomerCustomizationBaseColor VARCHAR(40) NOT NULL , CustomerCustomizationFontSize VARCHAR(40) NOT NULL , CustomerId smallint NOT NULL , PRIMARY KEY(CustomerCustomizationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICUSTOMERCUSTOMIZATION1 ON CustomerCustomization (CustomerId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICUSTOMERCUSTOMIZATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICUSTOMERCUSTOMIZATION1 ON CustomerCustomization (CustomerId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateLocationEvent( )
      {
         string cmdBuffer = "";
         /* Indices for table LocationEvent */
         try
         {
            cmdBuffer=" CREATE SEQUENCE LocationEventId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE LocationEventId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE LocationEventId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE LocationEvent (LocationEventId smallint NOT NULL DEFAULT nextval('LocationEventId'), LocationEventStartDate timestamp without time zone NOT NULL , LocationEventEndDate timestamp without time zone NOT NULL , LocationEventTitle VARCHAR(100) NOT NULL , LocationEventDisplay VARCHAR(40) NOT NULL , LocationEventBackgroundColor VARCHAR(40) NOT NULL , LocationEventDescription TEXT NOT NULL , LocationEventBorderColor VARCHAR(40) NOT NULL , LocationEventTextColor VARCHAR(40) NOT NULL , LocationEventUrl VARCHAR(1000) NOT NULL , LocationEventAllDay BOOLEAN NOT NULL , LocationEventRecurring BOOLEAN NOT NULL , LocationEventRecuringDays TEXT NOT NULL , CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , PRIMARY KEY(LocationEventId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE LocationEvent CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW LocationEvent CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION LocationEvent CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE LocationEvent (LocationEventId smallint NOT NULL DEFAULT nextval('LocationEventId'), LocationEventStartDate timestamp without time zone NOT NULL , LocationEventEndDate timestamp without time zone NOT NULL , LocationEventTitle VARCHAR(100) NOT NULL , LocationEventDisplay VARCHAR(40) NOT NULL , LocationEventBackgroundColor VARCHAR(40) NOT NULL , LocationEventDescription TEXT NOT NULL , LocationEventBorderColor VARCHAR(40) NOT NULL , LocationEventTextColor VARCHAR(40) NOT NULL , LocationEventUrl VARCHAR(1000) NOT NULL , LocationEventAllDay BOOLEAN NOT NULL , LocationEventRecurring BOOLEAN NOT NULL , LocationEventRecuringDays TEXT NOT NULL , CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , PRIMARY KEY(LocationEventId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ILOCATIONEVENT1 ON LocationEvent (CustomerId ,CustomerLocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ILOCATIONEVENT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ILOCATIONEVENT1 ON LocationEvent (CustomerId ,CustomerLocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePageTemplate( )
      {
         string cmdBuffer = "";
         /* Indices for table PageTemplate */
         try
         {
            cmdBuffer=" CREATE SEQUENCE PageTemplateId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE PageTemplateId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE PageTemplateId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE PageTemplate (PageTemplateId smallint NOT NULL DEFAULT nextval('PageTemplateId'), PageTemplateName VARCHAR(40) NOT NULL , PageTemplateDescription VARCHAR(200) NOT NULL , PageTemplateImage BYTEA NOT NULL , PageTemplateImage_GXI VARCHAR(2048) , PageTemplateHtml TEXT NOT NULL , PageTemplateCSS TEXT NOT NULL , PRIMARY KEY(PageTemplateId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE PageTemplate CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW PageTemplate CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION PageTemplate CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE PageTemplate (PageTemplateId smallint NOT NULL DEFAULT nextval('PageTemplateId'), PageTemplateName VARCHAR(40) NOT NULL , PageTemplateDescription VARCHAR(200) NOT NULL , PageTemplateImage BYTEA NOT NULL , PageTemplateImage_GXI VARCHAR(2048) , PageTemplateHtml TEXT NOT NULL , PageTemplateCSS TEXT NOT NULL , PRIMARY KEY(PageTemplateId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePage( )
      {
         string cmdBuffer = "";
         /* Indices for table Page */
         try
         {
            cmdBuffer=" CREATE SEQUENCE PageId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE PageId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE PageId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Page (PageId smallint NOT NULL DEFAULT nextval('PageId'), PageName VARCHAR(40) NOT NULL , PageHtmlContent TEXT NOT NULL , PageJsonContent TEXT NOT NULL , CustomerId smallint NOT NULL , PageCssContent TEXT NOT NULL , PRIMARY KEY(PageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Page CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Page CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Page CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Page (PageId smallint NOT NULL DEFAULT nextval('PageId'), PageName VARCHAR(40) NOT NULL , PageHtmlContent TEXT NOT NULL , PageJsonContent TEXT NOT NULL , CustomerId smallint NOT NULL , PageCssContent TEXT NOT NULL , PRIMARY KEY(PageId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPAGE1 ON Page (CustomerId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPAGE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPAGE1 ON Page (CustomerId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAmenitiesType( )
      {
         string cmdBuffer = "";
         /* Indices for table AmenitiesType */
         try
         {
            cmdBuffer=" CREATE SEQUENCE AmenitiesTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE AmenitiesTypeId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE AmenitiesTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE AmenitiesType (AmenitiesTypeId smallint NOT NULL DEFAULT nextval('AmenitiesTypeId'), AmenitiesTypeName VARCHAR(40) NOT NULL , PRIMARY KEY(AmenitiesTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE AmenitiesType CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW AmenitiesType CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION AmenitiesType CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE AmenitiesType (AmenitiesTypeId smallint NOT NULL DEFAULT nextval('AmenitiesTypeId'), AmenitiesTypeName VARCHAR(40) NOT NULL , PRIMARY KEY(AmenitiesTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAmenities( )
      {
         string cmdBuffer = "";
         /* Indices for table Amenities */
         try
         {
            cmdBuffer=" CREATE SEQUENCE AmenitiesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE AmenitiesId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE AmenitiesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Amenities (AmenitiesId smallint NOT NULL DEFAULT nextval('AmenitiesId'), AmenitiesName VARCHAR(40) NOT NULL , AmenitiesTypeId smallint NOT NULL , PRIMARY KEY(AmenitiesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Amenities CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Amenities CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Amenities CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Amenities (AmenitiesId smallint NOT NULL DEFAULT nextval('AmenitiesId'), AmenitiesName VARCHAR(40) NOT NULL , AmenitiesTypeId smallint NOT NULL , PRIMARY KEY(AmenitiesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IAMENITIES1 ON Amenities (AmenitiesTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IAMENITIES1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IAMENITIES1 ON Amenities (AmenitiesTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCustomerLocationsAmenities( )
      {
         string cmdBuffer = "";
         /* Indices for table CustomerLocationsAmenities */
         try
         {
            cmdBuffer=" CREATE TABLE CustomerLocationsAmenities (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , AmenitiesId smallint NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId, AmenitiesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CustomerLocationsAmenities CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CustomerLocationsAmenities CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CustomerLocationsAmenities CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CustomerLocationsAmenities (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , AmenitiesId smallint NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId, AmenitiesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICUSTOMERLOCATIONSAMENITIES1 ON CustomerLocationsAmenities (AmenitiesId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICUSTOMERLOCATIONSAMENITIES1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICUSTOMERLOCATIONSAMENITIES1 ON CustomerLocationsAmenities (AmenitiesId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateUserCustomizations( )
      {
         string cmdBuffer = "";
         /* Indices for table UserCustomizations */
         try
         {
            cmdBuffer=" CREATE TABLE UserCustomizations (UserCustomizationsId CHAR(40) NOT NULL , UserCustomizationsKey VARCHAR(200) NOT NULL , UserCustomizationsValue TEXT NOT NULL , PRIMARY KEY(UserCustomizationsId, UserCustomizationsKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE UserCustomizations CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW UserCustomizations CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION UserCustomizations CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE UserCustomizations (UserCustomizationsId CHAR(40) NOT NULL , UserCustomizationsKey VARCHAR(200) NOT NULL , UserCustomizationsValue TEXT NOT NULL , PRIMARY KEY(UserCustomizationsId, UserCustomizationsKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Parameter( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Parameter */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Parameter (WWPParameterKey VARCHAR(300) NOT NULL , WWPParameterCategory VARCHAR(200) NOT NULL , WWPParameterDescription VARCHAR(200) NOT NULL , WWPParameterValue TEXT NOT NULL , WWPParameterDisableDelete BOOLEAN NOT NULL , PRIMARY KEY(WWPParameterKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Parameter CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Parameter CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Parameter CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Parameter (WWPParameterKey VARCHAR(300) NOT NULL , WWPParameterCategory VARCHAR(200) NOT NULL , WWPParameterDescription VARCHAR(200) NOT NULL , WWPParameterValue TEXT NOT NULL , WWPParameterDisableDelete BOOLEAN NOT NULL , PRIMARY KEY(WWPParameterKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateResidentProductService( )
      {
         string cmdBuffer = "";
         /* Indices for table ResidentProductService */
         try
         {
            cmdBuffer=" CREATE TABLE ResidentProductService (ResidentId smallint NOT NULL , ProductServiceId smallint NOT NULL , PRIMARY KEY(ResidentId, ProductServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ResidentProductService CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ResidentProductService CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ResidentProductService CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ResidentProductService (ResidentId smallint NOT NULL , ProductServiceId smallint NOT NULL , PRIMARY KEY(ResidentId, ProductServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IRESIDENTPRODUCTSERVICE1 ON ResidentProductService (ProductServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IRESIDENTPRODUCTSERVICE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IRESIDENTPRODUCTSERVICE1 ON ResidentProductService (ProductServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCustomerLocationSupplier_Gen( )
      {
         string cmdBuffer = "";
         /* Indices for table CustomerLocationSupplier_Gen */
         try
         {
            cmdBuffer=" CREATE TABLE CustomerLocationSupplier_Gen (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , Supplier_GenId smallint NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId, Supplier_GenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CustomerLocationSupplier_Gen CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CustomerLocationSupplier_Gen CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CustomerLocationSupplier_Gen CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CustomerLocationSupplier_Gen (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , Supplier_GenId smallint NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId, Supplier_GenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICUSTOMERLOCATIONSUPPLIER_GEN1 ON CustomerLocationSupplier_Gen (Supplier_GenId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICUSTOMERLOCATIONSUPPLIER_GEN1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICUSTOMERLOCATIONSUPPLIER_GEN1 ON CustomerLocationSupplier_Gen (Supplier_GenId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCustomerLocationSupplier_Agb( )
      {
         string cmdBuffer = "";
         /* Indices for table CustomerLocationSupplier_Agb */
         try
         {
            cmdBuffer=" CREATE TABLE CustomerLocationSupplier_Agb (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , Supplier_AgbId smallint NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId, Supplier_AgbId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CustomerLocationSupplier_Agb CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CustomerLocationSupplier_Agb CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CustomerLocationSupplier_Agb CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CustomerLocationSupplier_Agb (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , Supplier_AgbId smallint NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId, Supplier_AgbId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICUSTOMERLOCATIONSUPPLIER_AGB1 ON CustomerLocationSupplier_Agb (Supplier_AgbId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICUSTOMERLOCATIONSUPPLIER_AGB1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICUSTOMERLOCATIONSUPPLIER_AGB1 ON CustomerLocationSupplier_Agb (Supplier_AgbId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSupplier_AgbProductService( )
      {
         string cmdBuffer = "";
         /* Indices for table Supplier_AgbProductService */
         try
         {
            cmdBuffer=" CREATE TABLE Supplier_AgbProductService (Supplier_AgbId smallint NOT NULL , ProductServiceId smallint NOT NULL , PRIMARY KEY(Supplier_AgbId, ProductServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Supplier_AgbProductService CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Supplier_AgbProductService CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Supplier_AgbProductService CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Supplier_AgbProductService (Supplier_AgbId smallint NOT NULL , ProductServiceId smallint NOT NULL , PRIMARY KEY(Supplier_AgbId, ProductServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISUPPLIER_AGBPRODUCTSERVICE1 ON Supplier_AgbProductService (ProductServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISUPPLIER_AGBPRODUCTSERVICE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISUPPLIER_AGBPRODUCTSERVICE1 ON Supplier_AgbProductService (ProductServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSupplier_GenProductService( )
      {
         string cmdBuffer = "";
         /* Indices for table Supplier_GenProductService */
         try
         {
            cmdBuffer=" CREATE TABLE Supplier_GenProductService (Supplier_GenId smallint NOT NULL , ProductServiceId smallint NOT NULL , PRIMARY KEY(Supplier_GenId, ProductServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Supplier_GenProductService CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Supplier_GenProductService CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Supplier_GenProductService CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Supplier_GenProductService (Supplier_GenId smallint NOT NULL , ProductServiceId smallint NOT NULL , PRIMARY KEY(Supplier_GenId, ProductServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISUPPLIER_GENPRODUCTSERVICE1 ON Supplier_GenProductService (ProductServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISUPPLIER_GENPRODUCTSERVICE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISUPPLIER_GENPRODUCTSERVICE1 ON Supplier_GenProductService (ProductServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateResidentType( )
      {
         string cmdBuffer = "";
         /* Indices for table ResidentType */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ResidentTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ResidentTypeId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ResidentTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ResidentType (ResidentTypeId smallint NOT NULL DEFAULT nextval('ResidentTypeId'), ResidentTypeName VARCHAR(40) NOT NULL , PRIMARY KEY(ResidentTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ResidentType CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ResidentType CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ResidentType CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ResidentType (ResidentTypeId smallint NOT NULL DEFAULT nextval('ResidentTypeId'), ResidentTypeName VARCHAR(40) NOT NULL , PRIMARY KEY(ResidentTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCustomerType( )
      {
         string cmdBuffer = "";
         /* Indices for table CustomerType */
         try
         {
            cmdBuffer=" CREATE SEQUENCE CustomerTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE CustomerTypeId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE CustomerTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE CustomerType (CustomerTypeId smallint NOT NULL DEFAULT nextval('CustomerTypeId'), CustomerTypeName VARCHAR(40) NOT NULL , PRIMARY KEY(CustomerTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CustomerType CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CustomerType CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CustomerType CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CustomerType (CustomerTypeId smallint NOT NULL DEFAULT nextval('CustomerTypeId'), CustomerTypeName VARCHAR(40) NOT NULL , PRIMARY KEY(CustomerTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProductService( )
      {
         string cmdBuffer = "";
         /* Indices for table ProductService */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ProductServiceId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ProductServiceId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ProductServiceId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ProductService (ProductServiceId smallint NOT NULL DEFAULT nextval('ProductServiceId'), ProductServiceName VARCHAR(40) NOT NULL , ProductServiceDescription VARCHAR(200) NOT NULL , ProductServiceQuantity smallint NOT NULL , ProductServicePicture BYTEA NOT NULL , ProductServicePicture_GXI VARCHAR(2048) , ProductServiceTypeId smallint NOT NULL , PRIMARY KEY(ProductServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ProductService CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ProductService CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ProductService CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ProductService (ProductServiceId smallint NOT NULL DEFAULT nextval('ProductServiceId'), ProductServiceName VARCHAR(40) NOT NULL , ProductServiceDescription VARCHAR(200) NOT NULL , ProductServiceQuantity smallint NOT NULL , ProductServicePicture BYTEA NOT NULL , ProductServicePicture_GXI VARCHAR(2048) , ProductServiceTypeId smallint NOT NULL , PRIMARY KEY(ProductServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPRODUCTSERVICE1 ON ProductService (ProductServiceTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPRODUCTSERVICE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPRODUCTSERVICE1 ON ProductService (ProductServiceTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProductServiceType( )
      {
         string cmdBuffer = "";
         /* Indices for table ProductServiceType */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ProductServiceTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ProductServiceTypeId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ProductServiceTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ProductServiceType (ProductServiceTypeId smallint NOT NULL DEFAULT nextval('ProductServiceTypeId'), ProductServiceTypeName VARCHAR(40) NOT NULL , PRIMARY KEY(ProductServiceTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ProductServiceType CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ProductServiceType CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ProductServiceType CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ProductServiceType (ProductServiceTypeId smallint NOT NULL DEFAULT nextval('ProductServiceTypeId'), ProductServiceTypeName VARCHAR(40) NOT NULL , PRIMARY KEY(ProductServiceTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSupplier_Gen( )
      {
         string cmdBuffer = "";
         /* Indices for table Supplier_Gen */
         try
         {
            cmdBuffer=" CREATE SEQUENCE Supplier_GenId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE Supplier_GenId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE Supplier_GenId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Supplier_Gen (Supplier_GenId smallint NOT NULL DEFAULT nextval('Supplier_GenId'), Supplier_GenKvKNumber VARCHAR(8) NOT NULL , Supplier_GenCompanyName VARCHAR(40) NOT NULL , Supplier_GenVisitingAddress VARCHAR(1024) , Supplier_GenPostalAddress VARCHAR(1024) , Supplier_GenContactName VARCHAR(40) , Supplier_GenContactPhone CHAR(20) , PRIMARY KEY(Supplier_GenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Supplier_Gen CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Supplier_Gen CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Supplier_Gen CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Supplier_Gen (Supplier_GenId smallint NOT NULL DEFAULT nextval('Supplier_GenId'), Supplier_GenKvKNumber VARCHAR(8) NOT NULL , Supplier_GenCompanyName VARCHAR(40) NOT NULL , Supplier_GenVisitingAddress VARCHAR(1024) , Supplier_GenPostalAddress VARCHAR(1024) , Supplier_GenContactName VARCHAR(40) , Supplier_GenContactPhone CHAR(20) , PRIMARY KEY(Supplier_GenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSupplier_AGB( )
      {
         string cmdBuffer = "";
         /* Indices for table Supplier_AGB */
         try
         {
            cmdBuffer=" CREATE SEQUENCE Supplier_AgbId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE Supplier_AgbId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE Supplier_AgbId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Supplier_AGB (Supplier_AgbId smallint NOT NULL DEFAULT nextval('Supplier_AgbId'), Supplier_AgbNumber VARCHAR(10) NOT NULL , Supplier_AgbName VARCHAR(40) NOT NULL , Supplier_AgbKvkNumber VARCHAR(8) NOT NULL , Supplier_AgbVisitingAddress VARCHAR(1024) , Supplier_AgbPostalAddress VARCHAR(1024) , Supplier_AgbEmail VARCHAR(100) , Supplier_AgbPhone CHAR(20) , Supplier_AgbContactName VARCHAR(40) , PRIMARY KEY(Supplier_AgbId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Supplier_AGB CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Supplier_AGB CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Supplier_AGB CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Supplier_AGB (Supplier_AgbId smallint NOT NULL DEFAULT nextval('Supplier_AgbId'), Supplier_AgbNumber VARCHAR(10) NOT NULL , Supplier_AgbName VARCHAR(40) NOT NULL , Supplier_AgbKvkNumber VARCHAR(8) NOT NULL , Supplier_AgbVisitingAddress VARCHAR(1024) , Supplier_AgbPostalAddress VARCHAR(1024) , Supplier_AgbEmail VARCHAR(100) , Supplier_AgbPhone CHAR(20) , Supplier_AgbContactName VARCHAR(40) , PRIMARY KEY(Supplier_AgbId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateResidentINCompany( )
      {
         string cmdBuffer = "";
         /* Indices for table ResidentINCompany */
         try
         {
            cmdBuffer=" CREATE TABLE ResidentINCompany (ResidentId smallint NOT NULL , ResidentINCompanyId smallint NOT NULL , ResidentINCompanyKvkNumber VARCHAR(8) NOT NULL , ResidentINCompanyName VARCHAR(40) NOT NULL , ResidentINCompanyEmail VARCHAR(100) , ResidentINCompanyPhone CHAR(20) , PRIMARY KEY(ResidentId, ResidentINCompanyId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ResidentINCompany CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ResidentINCompany CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ResidentINCompany CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ResidentINCompany (ResidentId smallint NOT NULL , ResidentINCompanyId smallint NOT NULL , ResidentINCompanyKvkNumber VARCHAR(8) NOT NULL , ResidentINCompanyName VARCHAR(40) NOT NULL , ResidentINCompanyEmail VARCHAR(100) , ResidentINCompanyPhone CHAR(20) , PRIMARY KEY(ResidentId, ResidentINCompanyId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateResidentINIndividual( )
      {
         string cmdBuffer = "";
         /* Indices for table ResidentINIndividual */
         try
         {
            cmdBuffer=" CREATE TABLE ResidentINIndividual (ResidentId smallint NOT NULL , ResidentINIndividualId smallint NOT NULL , ResidentINIndividualBsnNumber VARCHAR(40) NOT NULL , ResidentINIndividualGivenName VARCHAR(40) NOT NULL , ResidentINIndividualLastName VARCHAR(40) NOT NULL , ResidentINIndividualEmail VARCHAR(100) , ResidentINIndividualPhone CHAR(20) , ResidentINIndividualAddress VARCHAR(1024) , ResidentINIndividualGender CHAR(20) NOT NULL , PRIMARY KEY(ResidentId, ResidentINIndividualId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ResidentINIndividual CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ResidentINIndividual CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ResidentINIndividual CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ResidentINIndividual (ResidentId smallint NOT NULL , ResidentINIndividualId smallint NOT NULL , ResidentINIndividualBsnNumber VARCHAR(40) NOT NULL , ResidentINIndividualGivenName VARCHAR(40) NOT NULL , ResidentINIndividualLastName VARCHAR(40) NOT NULL , ResidentINIndividualEmail VARCHAR(100) , ResidentINIndividualPhone CHAR(20) , ResidentINIndividualAddress VARCHAR(1024) , ResidentINIndividualGender CHAR(20) NOT NULL , PRIMARY KEY(ResidentId, ResidentINIndividualId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateResident( )
      {
         string cmdBuffer = "";
         /* Indices for table Resident */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ResidentId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ResidentId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ResidentId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Resident (ResidentId smallint NOT NULL DEFAULT nextval('ResidentId'), ResidentGivenName VARCHAR(40) NOT NULL , ResidentLastName VARCHAR(40) NOT NULL , ResidentInitials CHAR(20) , ResidentEmail VARCHAR(100) NOT NULL , ResidentAddress VARCHAR(1024) , ResidentPhone CHAR(20) , ResidentGAMGUID VARCHAR(100) NOT NULL , ResidentBsnNumber VARCHAR(40) NOT NULL , ResidentTypeId smallint NOT NULL , CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , ResidentLastLineIndividual smallint NOT NULL , ResidentLastLineCompany smallint NOT NULL , ResidentGender CHAR(20) NOT NULL , PRIMARY KEY(ResidentId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Resident CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Resident CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Resident CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Resident (ResidentId smallint NOT NULL DEFAULT nextval('ResidentId'), ResidentGivenName VARCHAR(40) NOT NULL , ResidentLastName VARCHAR(40) NOT NULL , ResidentInitials CHAR(20) , ResidentEmail VARCHAR(100) NOT NULL , ResidentAddress VARCHAR(1024) , ResidentPhone CHAR(20) , ResidentGAMGUID VARCHAR(100) NOT NULL , ResidentBsnNumber VARCHAR(40) NOT NULL , ResidentTypeId smallint NOT NULL , CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , ResidentLastLineIndividual smallint NOT NULL , ResidentLastLineCompany smallint NOT NULL , ResidentGender CHAR(20) NOT NULL , PRIMARY KEY(ResidentId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX URESIDENT ON Resident (ResidentBsnNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX URESIDENT "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX URESIDENT ON Resident (ResidentBsnNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IRESIDENT1 ON Resident (ResidentTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IRESIDENT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IRESIDENT1 ON Resident (ResidentTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IRESIDENT2 ON Resident (CustomerId ,CustomerLocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IRESIDENT2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IRESIDENT2 ON Resident (CustomerId ,CustomerLocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCustomerLocationReceptionist( )
      {
         string cmdBuffer = "";
         /* Indices for table CustomerLocationReceptionist */
         try
         {
            cmdBuffer=" CREATE TABLE CustomerLocationReceptionist (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , CustomerLocationReceptionistId smallint NOT NULL , CustomerLocationReceptionistGi VARCHAR(40) NOT NULL , CustomerLocationReceptionistLa VARCHAR(40) NOT NULL , CustomerLocationReceptionistIn CHAR(20) , CustomerLocationReceptionistEm VARCHAR(100) NOT NULL , CustomerLocationReceptionistAd VARCHAR(1024) , CustomerLocationReceptionistPh CHAR(20) NOT NULL , CustomerLocationReceptionistGA VARCHAR(100) NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId, CustomerLocationReceptionistId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CustomerLocationReceptionist CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CustomerLocationReceptionist CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CustomerLocationReceptionist CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CustomerLocationReceptionist (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , CustomerLocationReceptionistId smallint NOT NULL , CustomerLocationReceptionistGi VARCHAR(40) NOT NULL , CustomerLocationReceptionistLa VARCHAR(40) NOT NULL , CustomerLocationReceptionistIn CHAR(20) , CustomerLocationReceptionistEm VARCHAR(100) NOT NULL , CustomerLocationReceptionistAd VARCHAR(1024) , CustomerLocationReceptionistPh CHAR(20) NOT NULL , CustomerLocationReceptionistGA VARCHAR(100) NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId, CustomerLocationReceptionistId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCustomerLocation( )
      {
         string cmdBuffer = "";
         /* Indices for table CustomerLocation */
         try
         {
            cmdBuffer=" CREATE TABLE CustomerLocation (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , CustomerLocationVisitingAddres VARCHAR(1024) NOT NULL , CustomerLocationPostalAddress VARCHAR(100) NOT NULL , CustomerLocationEmail VARCHAR(100) NOT NULL , CustomerLocationPhone CHAR(20) NOT NULL , CustomerLocationLastLine smallint NOT NULL , CustomerLocationDescription VARCHAR(200) NOT NULL , CustomerLocationName VARCHAR(40) NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CustomerLocation CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CustomerLocation CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CustomerLocation CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CustomerLocation (CustomerId smallint NOT NULL , CustomerLocationId smallint NOT NULL , CustomerLocationVisitingAddres VARCHAR(1024) NOT NULL , CustomerLocationPostalAddress VARCHAR(100) NOT NULL , CustomerLocationEmail VARCHAR(100) NOT NULL , CustomerLocationPhone CHAR(20) NOT NULL , CustomerLocationLastLine smallint NOT NULL , CustomerLocationDescription VARCHAR(200) NOT NULL , CustomerLocationName VARCHAR(40) NOT NULL , PRIMARY KEY(CustomerId, CustomerLocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCustomerManager( )
      {
         string cmdBuffer = "";
         /* Indices for table CustomerManager */
         try
         {
            cmdBuffer=" CREATE TABLE CustomerManager (CustomerId smallint NOT NULL , CustomerManagerId smallint NOT NULL , CustomerManagerGivenName VARCHAR(40) NOT NULL , CustomerManagerLastName VARCHAR(40) NOT NULL , CustomerManagerInitials CHAR(10) , CustomerManagerEmail VARCHAR(100) NOT NULL , CustomerManagerPhone CHAR(20) , CustomerManagerGender CHAR(20) , CustomerManagerGAMGUID VARCHAR(100) NOT NULL , PRIMARY KEY(CustomerId, CustomerManagerId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CustomerManager CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CustomerManager CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CustomerManager CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CustomerManager (CustomerId smallint NOT NULL , CustomerManagerId smallint NOT NULL , CustomerManagerGivenName VARCHAR(40) NOT NULL , CustomerManagerLastName VARCHAR(40) NOT NULL , CustomerManagerInitials CHAR(10) , CustomerManagerEmail VARCHAR(100) NOT NULL , CustomerManagerPhone CHAR(20) , CustomerManagerGender CHAR(20) , CustomerManagerGAMGUID VARCHAR(100) NOT NULL , PRIMARY KEY(CustomerId, CustomerManagerId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCustomer( )
      {
         string cmdBuffer = "";
         /* Indices for table Customer */
         try
         {
            cmdBuffer=" CREATE SEQUENCE CustomerId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE CustomerId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE CustomerId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Customer (CustomerId smallint NOT NULL DEFAULT nextval('CustomerId'), CustomerName VARCHAR(40) NOT NULL , CustomerPostalAddress VARCHAR(1024) , CustomerEmail VARCHAR(100) , CustomerVisitingAddress VARCHAR(1024) , CustomerPhone CHAR(20) , CustomerVatNumber VARCHAR(14) NOT NULL , CustomerKvkNumber VARCHAR(8) NOT NULL , CustomerTypeId smallint , CustomerLastLine smallint NOT NULL , CustomerLastLineLocation smallint NOT NULL , PRIMARY KEY(CustomerId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Customer CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Customer CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Customer CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Customer (CustomerId smallint NOT NULL DEFAULT nextval('CustomerId'), CustomerName VARCHAR(40) NOT NULL , CustomerPostalAddress VARCHAR(1024) , CustomerEmail VARCHAR(100) , CustomerVisitingAddress VARCHAR(1024) , CustomerPhone CHAR(20) , CustomerVatNumber VARCHAR(14) NOT NULL , CustomerKvkNumber VARCHAR(8) NOT NULL , CustomerTypeId smallint , CustomerLastLine smallint NOT NULL , CustomerLastLineLocation smallint NOT NULL , PRIMARY KEY(CustomerId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICUSTOMER1 ON Customer (CustomerTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICUSTOMER1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICUSTOMER1 ON Customer (CustomerTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerCustomerType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Customer ADD CONSTRAINT ICUSTOMER1 FOREIGN KEY (CustomerTypeId) REFERENCES CustomerType (CustomerTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Customer DROP CONSTRAINT ICUSTOMER1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Customer ADD CONSTRAINT ICUSTOMER1 FOREIGN KEY (CustomerTypeId) REFERENCES CustomerType (CustomerTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerManagerCustomer( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerManager ADD CONSTRAINT ICUSTOMERMANAGER1 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerManager DROP CONSTRAINT ICUSTOMERMANAGER1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerManager ADD CONSTRAINT ICUSTOMERMANAGER1 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerLocationCustomer( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerLocation ADD CONSTRAINT ICUSTOMERLOCATION1 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerLocation DROP CONSTRAINT ICUSTOMERLOCATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerLocation ADD CONSTRAINT ICUSTOMERLOCATION1 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerLocationReceptionistCustomerLocation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerLocationReceptionist ADD CONSTRAINT ICUSTOMERLOCATIONRECEPTIONIST1 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerLocationReceptionist DROP CONSTRAINT ICUSTOMERLOCATIONRECEPTIONIST1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerLocationReceptionist ADD CONSTRAINT ICUSTOMERLOCATIONRECEPTIONIST1 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIResidentResidentType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Resident ADD CONSTRAINT IRESIDENT1 FOREIGN KEY (ResidentTypeId) REFERENCES ResidentType (ResidentTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Resident DROP CONSTRAINT IRESIDENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Resident ADD CONSTRAINT IRESIDENT1 FOREIGN KEY (ResidentTypeId) REFERENCES ResidentType (ResidentTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIResidentCustomerLocation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Resident ADD CONSTRAINT IRESIDENT2 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Resident DROP CONSTRAINT IRESIDENT2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Resident ADD CONSTRAINT IRESIDENT2 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIResidentINIndividualResident( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ResidentINIndividual ADD CONSTRAINT IRESIDENTININDIVIDUAL1 FOREIGN KEY (ResidentId) REFERENCES Resident (ResidentId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ResidentINIndividual DROP CONSTRAINT IRESIDENTININDIVIDUAL1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ResidentINIndividual ADD CONSTRAINT IRESIDENTININDIVIDUAL1 FOREIGN KEY (ResidentId) REFERENCES Resident (ResidentId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIResidentINCompanyResident( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ResidentINCompany ADD CONSTRAINT IRESIDENTINCOMPANY1 FOREIGN KEY (ResidentId) REFERENCES Resident (ResidentId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ResidentINCompany DROP CONSTRAINT IRESIDENTINCOMPANY1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ResidentINCompany ADD CONSTRAINT IRESIDENTINCOMPANY1 FOREIGN KEY (ResidentId) REFERENCES Resident (ResidentId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProductServiceProductServiceType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ProductService ADD CONSTRAINT IPRODUCTSERVICE1 FOREIGN KEY (ProductServiceTypeId) REFERENCES ProductServiceType (ProductServiceTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ProductService DROP CONSTRAINT IPRODUCTSERVICE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ProductService ADD CONSTRAINT IPRODUCTSERVICE1 FOREIGN KEY (ProductServiceTypeId) REFERENCES ProductServiceType (ProductServiceTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISupplier_GenProductServiceSupplier_Gen( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Supplier_GenProductService ADD CONSTRAINT ISUPPLIER_GENPRODUCTSERVICE2 FOREIGN KEY (Supplier_GenId) REFERENCES Supplier_Gen (Supplier_GenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Supplier_GenProductService DROP CONSTRAINT ISUPPLIER_GENPRODUCTSERVICE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Supplier_GenProductService ADD CONSTRAINT ISUPPLIER_GENPRODUCTSERVICE2 FOREIGN KEY (Supplier_GenId) REFERENCES Supplier_Gen (Supplier_GenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISupplier_GenProductServiceProductService( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Supplier_GenProductService ADD CONSTRAINT ISUPPLIER_GENPRODUCTSERVICE1 FOREIGN KEY (ProductServiceId) REFERENCES ProductService (ProductServiceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Supplier_GenProductService DROP CONSTRAINT ISUPPLIER_GENPRODUCTSERVICE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Supplier_GenProductService ADD CONSTRAINT ISUPPLIER_GENPRODUCTSERVICE1 FOREIGN KEY (ProductServiceId) REFERENCES ProductService (ProductServiceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISupplier_AgbProductServiceSupplier_AGB( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Supplier_AgbProductService ADD CONSTRAINT ISUPPLIER_AGBPRODUCTSERVICE2 FOREIGN KEY (Supplier_AgbId) REFERENCES Supplier_AGB (Supplier_AgbId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Supplier_AgbProductService DROP CONSTRAINT ISUPPLIER_AGBPRODUCTSERVICE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Supplier_AgbProductService ADD CONSTRAINT ISUPPLIER_AGBPRODUCTSERVICE2 FOREIGN KEY (Supplier_AgbId) REFERENCES Supplier_AGB (Supplier_AgbId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISupplier_AgbProductServiceProductService( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Supplier_AgbProductService ADD CONSTRAINT ISUPPLIER_AGBPRODUCTSERVICE1 FOREIGN KEY (ProductServiceId) REFERENCES ProductService (ProductServiceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Supplier_AgbProductService DROP CONSTRAINT ISUPPLIER_AGBPRODUCTSERVICE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Supplier_AgbProductService ADD CONSTRAINT ISUPPLIER_AGBPRODUCTSERVICE1 FOREIGN KEY (ProductServiceId) REFERENCES ProductService (ProductServiceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerLocationSupplier_AgbCustomerLocation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Agb ADD CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_AGB2 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Agb DROP CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_AGB2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Agb ADD CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_AGB2 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerLocationSupplier_AgbSupplier_AGB( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Agb ADD CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_AGB1 FOREIGN KEY (Supplier_AgbId) REFERENCES Supplier_AGB (Supplier_AgbId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Agb DROP CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_AGB1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Agb ADD CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_AGB1 FOREIGN KEY (Supplier_AgbId) REFERENCES Supplier_AGB (Supplier_AgbId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerLocationSupplier_GenCustomerLocation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Gen ADD CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_GEN2 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Gen DROP CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_GEN2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Gen ADD CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_GEN2 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerLocationSupplier_GenSupplier_Gen( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Gen ADD CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_GEN1 FOREIGN KEY (Supplier_GenId) REFERENCES Supplier_Gen (Supplier_GenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Gen DROP CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_GEN1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerLocationSupplier_Gen ADD CONSTRAINT ICUSTOMERLOCATIONSUPPLIER_GEN1 FOREIGN KEY (Supplier_GenId) REFERENCES Supplier_Gen (Supplier_GenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIResidentProductServiceResident( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ResidentProductService ADD CONSTRAINT IRESIDENTPRODUCTSERVICE2 FOREIGN KEY (ResidentId) REFERENCES Resident (ResidentId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ResidentProductService DROP CONSTRAINT IRESIDENTPRODUCTSERVICE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ResidentProductService ADD CONSTRAINT IRESIDENTPRODUCTSERVICE2 FOREIGN KEY (ResidentId) REFERENCES Resident (ResidentId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIResidentProductServiceProductService( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ResidentProductService ADD CONSTRAINT IRESIDENTPRODUCTSERVICE1 FOREIGN KEY (ProductServiceId) REFERENCES ProductService (ProductServiceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ResidentProductService DROP CONSTRAINT IRESIDENTPRODUCTSERVICE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ResidentProductService ADD CONSTRAINT IRESIDENTPRODUCTSERVICE1 FOREIGN KEY (ProductServiceId) REFERENCES ProductService (ProductServiceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerLocationsAmenitiesCustomerLocation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerLocationsAmenities ADD CONSTRAINT ICUSTOMERLOCATIONSAMENITIES2 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerLocationsAmenities DROP CONSTRAINT ICUSTOMERLOCATIONSAMENITIES2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerLocationsAmenities ADD CONSTRAINT ICUSTOMERLOCATIONSAMENITIES2 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerLocationsAmenitiesAmenities( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerLocationsAmenities ADD CONSTRAINT ICUSTOMERLOCATIONSAMENITIES1 FOREIGN KEY (AmenitiesId) REFERENCES Amenities (AmenitiesId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerLocationsAmenities DROP CONSTRAINT ICUSTOMERLOCATIONSAMENITIES1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerLocationsAmenities ADD CONSTRAINT ICUSTOMERLOCATIONSAMENITIES1 FOREIGN KEY (AmenitiesId) REFERENCES Amenities (AmenitiesId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAmenitiesAmenitiesType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Amenities ADD CONSTRAINT IAMENITIES1 FOREIGN KEY (AmenitiesTypeId) REFERENCES AmenitiesType (AmenitiesTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Amenities DROP CONSTRAINT IAMENITIES1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Amenities ADD CONSTRAINT IAMENITIES1 FOREIGN KEY (AmenitiesTypeId) REFERENCES AmenitiesType (AmenitiesTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPageCustomer( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Page ADD CONSTRAINT IPAGE1 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Page DROP CONSTRAINT IPAGE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Page ADD CONSTRAINT IPAGE1 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RILocationEventCustomerLocation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE LocationEvent ADD CONSTRAINT ILOCATIONEVENT1 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE LocationEvent DROP CONSTRAINT ILOCATIONEVENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE LocationEvent ADD CONSTRAINT ILOCATIONEVENT1 FOREIGN KEY (CustomerId, CustomerLocationId) REFERENCES CustomerLocation (CustomerId, CustomerLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICustomerCustomizationCustomer( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE CustomerCustomization ADD CONSTRAINT ICUSTOMERCUSTOMIZATION1 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE CustomerCustomization DROP CONSTRAINT ICUSTOMERCUSTOMIZATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE CustomerCustomization ADD CONSTRAINT ICUSTOMERCUSTOMIZATION1 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         if ( tableexist("Device",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Device"}) ) ;
            return false ;
         }
         if ( tableexist("CustomerCustomization",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CustomerCustomization"}) ) ;
            return false ;
         }
         if ( tableexist("LocationEvent",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"LocationEvent"}) ) ;
            return false ;
         }
         if ( tableexist("PageTemplate",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"PageTemplate"}) ) ;
            return false ;
         }
         if ( tableexist("Page",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Page"}) ) ;
            return false ;
         }
         if ( tableexist("AmenitiesType",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"AmenitiesType"}) ) ;
            return false ;
         }
         if ( tableexist("Amenities",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Amenities"}) ) ;
            return false ;
         }
         if ( tableexist("CustomerLocationsAmenities",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CustomerLocationsAmenities"}) ) ;
            return false ;
         }
         if ( tableexist("UserCustomizations",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"UserCustomizations"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Parameter",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Parameter"}) ) ;
            return false ;
         }
         if ( tableexist("ResidentProductService",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ResidentProductService"}) ) ;
            return false ;
         }
         if ( tableexist("CustomerLocationSupplier_Gen",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CustomerLocationSupplier_Gen"}) ) ;
            return false ;
         }
         if ( tableexist("CustomerLocationSupplier_Agb",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CustomerLocationSupplier_Agb"}) ) ;
            return false ;
         }
         if ( tableexist("Supplier_AgbProductService",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Supplier_AgbProductService"}) ) ;
            return false ;
         }
         if ( tableexist("Supplier_GenProductService",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Supplier_GenProductService"}) ) ;
            return false ;
         }
         if ( tableexist("ResidentType",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ResidentType"}) ) ;
            return false ;
         }
         if ( tableexist("CustomerType",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CustomerType"}) ) ;
            return false ;
         }
         if ( tableexist("ProductService",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ProductService"}) ) ;
            return false ;
         }
         if ( tableexist("ProductServiceType",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ProductServiceType"}) ) ;
            return false ;
         }
         if ( tableexist("Supplier_Gen",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Supplier_Gen"}) ) ;
            return false ;
         }
         if ( tableexist("Supplier_AGB",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Supplier_AGB"}) ) ;
            return false ;
         }
         if ( tableexist("ResidentINCompany",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ResidentINCompany"}) ) ;
            return false ;
         }
         if ( tableexist("ResidentINIndividual",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ResidentINIndividual"}) ) ;
            return false ;
         }
         if ( tableexist("Resident",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Resident"}) ) ;
            return false ;
         }
         if ( tableexist("CustomerLocationReceptionist",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CustomerLocationReceptionist"}) ) ;
            return false ;
         }
         if ( tableexist("CustomerLocation",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CustomerLocation"}) ) ;
            return false ;
         }
         if ( tableexist("CustomerManager",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CustomerManager"}) ) ;
            return false ;
         }
         if ( tableexist("Customer",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Customer"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( string sTableName ,
                               string sMySchemaName )
      {
         bool result;
         result = false;
         /* Using cursor P00012 */
         pr_default.execute(0, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            tablename = P00012_Atablename[0];
            ntablename = P00012_ntablename[0];
            schemaname = P00012_Aschemaname[0];
            nschemaname = P00012_nschemaname[0];
            result = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00023 */
         pr_default.execute(1, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(1) != 101) )
         {
            tablename = P00023_Atablename[0];
            ntablename = P00023_ntablename[0];
            schemaname = P00023_Aschemaname[0];
            nschemaname = P00023_nschemaname[0];
            result = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateDevice" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreateCustomerCustomization" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreateLocationEvent" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreatePageTemplate" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreatePage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreateAmenitiesType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateAmenities" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateCustomerLocationsAmenities" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreateUserCustomizations" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "CreateWWP_Parameter" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "CreateResidentProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "CreateCustomerLocationSupplier_Gen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "CreateCustomerLocationSupplier_Agb" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "CreateSupplier_AgbProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "CreateSupplier_GenProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "CreateResidentType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "CreateCustomerType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "CreateProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "CreateProductServiceType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "CreateSupplier_Gen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "CreateSupplier_AGB" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "CreateResidentINCompany" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 23 ,  "CreateResidentINIndividual" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 24 ,  "CreateResident" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 25 ,  "CreateCustomerLocationReceptionist" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 26 ,  "CreateCustomerLocation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 27 ,  "CreateCustomerManager" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 28 ,  "CreateCustomer" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 29 ,  "RICustomerCustomerType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 30 ,  "RICustomerManagerCustomer" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 31 ,  "RICustomerLocationCustomer" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 32 ,  "RICustomerLocationReceptionistCustomerLocation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 33 ,  "RIResidentResidentType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 34 ,  "RIResidentCustomerLocation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 35 ,  "RIResidentINIndividualResident" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 36 ,  "RIResidentINCompanyResident" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 37 ,  "RIProductServiceProductServiceType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 38 ,  "RISupplier_GenProductServiceSupplier_Gen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 39 ,  "RISupplier_GenProductServiceProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 40 ,  "RISupplier_AgbProductServiceSupplier_AGB" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 41 ,  "RISupplier_AgbProductServiceProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 42 ,  "RICustomerLocationSupplier_AgbCustomerLocation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 43 ,  "RICustomerLocationSupplier_AgbSupplier_AGB" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 44 ,  "RICustomerLocationSupplier_GenCustomerLocation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 45 ,  "RICustomerLocationSupplier_GenSupplier_Gen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 46 ,  "RIResidentProductServiceResident" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 47 ,  "RIResidentProductServiceProductService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 48 ,  "RICustomerLocationsAmenitiesCustomerLocation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 49 ,  "RICustomerLocationsAmenitiesAmenities" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 50 ,  "RIAmenitiesAmenitiesType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 51 ,  "RIPageCustomer" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 52 ,  "RILocationEventCustomerLocation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 53 ,  "RICustomerCustomizationCustomer" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Device", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CustomerCustomization", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCustomerCustomization" ,  "CreateCustomer" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"LocationEvent", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateLocationEvent" ,  "CreateCustomerLocation" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"PageTemplate", ""}) );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Page", ""}) );
         ReorgExecute.RegisterPrecedence( "CreatePage" ,  "CreateCustomer" );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"AmenitiesType", ""}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Amenities", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAmenities" ,  "CreateAmenitiesType" );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CustomerLocationsAmenities", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCustomerLocationsAmenities" ,  "CreateCustomerLocation" );
         ReorgExecute.RegisterPrecedence( "CreateCustomerLocationsAmenities" ,  "CreateAmenities" );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"UserCustomizations", ""}) );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Parameter", ""}) );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ResidentProductService", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateResidentProductService" ,  "CreateResident" );
         ReorgExecute.RegisterPrecedence( "CreateResidentProductService" ,  "CreateProductService" );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CustomerLocationSupplier_Gen", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCustomerLocationSupplier_Gen" ,  "CreateCustomerLocation" );
         ReorgExecute.RegisterPrecedence( "CreateCustomerLocationSupplier_Gen" ,  "CreateSupplier_Gen" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CustomerLocationSupplier_Agb", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCustomerLocationSupplier_Agb" ,  "CreateCustomerLocation" );
         ReorgExecute.RegisterPrecedence( "CreateCustomerLocationSupplier_Agb" ,  "CreateSupplier_AGB" );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Supplier_AgbProductService", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSupplier_AgbProductService" ,  "CreateSupplier_AGB" );
         ReorgExecute.RegisterPrecedence( "CreateSupplier_AgbProductService" ,  "CreateProductService" );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Supplier_GenProductService", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSupplier_GenProductService" ,  "CreateSupplier_Gen" );
         ReorgExecute.RegisterPrecedence( "CreateSupplier_GenProductService" ,  "CreateProductService" );
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ResidentType", ""}) );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CustomerType", ""}) );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ProductService", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateProductService" ,  "CreateProductServiceType" );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ProductServiceType", ""}) );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Supplier_Gen", ""}) );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Supplier_AGB", ""}) );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ResidentINCompany", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateResidentINCompany" ,  "CreateResident" );
         GXReorganization.SetMsg( 23 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ResidentINIndividual", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateResidentINIndividual" ,  "CreateResident" );
         GXReorganization.SetMsg( 24 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Resident", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateResident" ,  "CreateResidentType" );
         ReorgExecute.RegisterPrecedence( "CreateResident" ,  "CreateCustomerLocation" );
         GXReorganization.SetMsg( 25 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CustomerLocationReceptionist", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCustomerLocationReceptionist" ,  "CreateCustomerLocation" );
         GXReorganization.SetMsg( 26 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CustomerLocation", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCustomerLocation" ,  "CreateCustomer" );
         GXReorganization.SetMsg( 27 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CustomerManager", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCustomerManager" ,  "CreateCustomer" );
         GXReorganization.SetMsg( 28 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Customer", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCustomer" ,  "CreateCustomerType" );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 29 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMER1"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerCustomerType" ,  "CreateCustomer" );
         ReorgExecute.RegisterPrecedence( "RICustomerCustomerType" ,  "CreateCustomerType" );
         GXReorganization.SetMsg( 30 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERMANAGER1"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerManagerCustomer" ,  "CreateCustomerManager" );
         ReorgExecute.RegisterPrecedence( "RICustomerManagerCustomer" ,  "CreateCustomer" );
         GXReorganization.SetMsg( 31 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERLOCATION1"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationCustomer" ,  "CreateCustomerLocation" );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationCustomer" ,  "CreateCustomer" );
         GXReorganization.SetMsg( 32 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERLOCATIONRECEPTIONIST1"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationReceptionistCustomerLocation" ,  "CreateCustomerLocationReceptionist" );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationReceptionistCustomerLocation" ,  "CreateCustomerLocation" );
         GXReorganization.SetMsg( 33 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IRESIDENT1"}) );
         ReorgExecute.RegisterPrecedence( "RIResidentResidentType" ,  "CreateResident" );
         ReorgExecute.RegisterPrecedence( "RIResidentResidentType" ,  "CreateResidentType" );
         GXReorganization.SetMsg( 34 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IRESIDENT2"}) );
         ReorgExecute.RegisterPrecedence( "RIResidentCustomerLocation" ,  "CreateResident" );
         ReorgExecute.RegisterPrecedence( "RIResidentCustomerLocation" ,  "CreateCustomerLocation" );
         GXReorganization.SetMsg( 35 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IRESIDENTININDIVIDUAL1"}) );
         ReorgExecute.RegisterPrecedence( "RIResidentINIndividualResident" ,  "CreateResidentINIndividual" );
         ReorgExecute.RegisterPrecedence( "RIResidentINIndividualResident" ,  "CreateResident" );
         GXReorganization.SetMsg( 36 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IRESIDENTINCOMPANY1"}) );
         ReorgExecute.RegisterPrecedence( "RIResidentINCompanyResident" ,  "CreateResidentINCompany" );
         ReorgExecute.RegisterPrecedence( "RIResidentINCompanyResident" ,  "CreateResident" );
         GXReorganization.SetMsg( 37 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPRODUCTSERVICE1"}) );
         ReorgExecute.RegisterPrecedence( "RIProductServiceProductServiceType" ,  "CreateProductService" );
         ReorgExecute.RegisterPrecedence( "RIProductServiceProductServiceType" ,  "CreateProductServiceType" );
         GXReorganization.SetMsg( 38 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISUPPLIER_GENPRODUCTSERVICE2"}) );
         ReorgExecute.RegisterPrecedence( "RISupplier_GenProductServiceSupplier_Gen" ,  "CreateSupplier_GenProductService" );
         ReorgExecute.RegisterPrecedence( "RISupplier_GenProductServiceSupplier_Gen" ,  "CreateSupplier_Gen" );
         GXReorganization.SetMsg( 39 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISUPPLIER_GENPRODUCTSERVICE1"}) );
         ReorgExecute.RegisterPrecedence( "RISupplier_GenProductServiceProductService" ,  "CreateSupplier_GenProductService" );
         ReorgExecute.RegisterPrecedence( "RISupplier_GenProductServiceProductService" ,  "CreateProductService" );
         GXReorganization.SetMsg( 40 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISUPPLIER_AGBPRODUCTSERVICE2"}) );
         ReorgExecute.RegisterPrecedence( "RISupplier_AgbProductServiceSupplier_AGB" ,  "CreateSupplier_AgbProductService" );
         ReorgExecute.RegisterPrecedence( "RISupplier_AgbProductServiceSupplier_AGB" ,  "CreateSupplier_AGB" );
         GXReorganization.SetMsg( 41 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISUPPLIER_AGBPRODUCTSERVICE1"}) );
         ReorgExecute.RegisterPrecedence( "RISupplier_AgbProductServiceProductService" ,  "CreateSupplier_AgbProductService" );
         ReorgExecute.RegisterPrecedence( "RISupplier_AgbProductServiceProductService" ,  "CreateProductService" );
         GXReorganization.SetMsg( 42 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERLOCATIONSUPPLIER_AGB2"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationSupplier_AgbCustomerLocation" ,  "CreateCustomerLocationSupplier_Agb" );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationSupplier_AgbCustomerLocation" ,  "CreateCustomerLocation" );
         GXReorganization.SetMsg( 43 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERLOCATIONSUPPLIER_AGB1"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationSupplier_AgbSupplier_AGB" ,  "CreateCustomerLocationSupplier_Agb" );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationSupplier_AgbSupplier_AGB" ,  "CreateSupplier_AGB" );
         GXReorganization.SetMsg( 44 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERLOCATIONSUPPLIER_GEN2"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationSupplier_GenCustomerLocation" ,  "CreateCustomerLocationSupplier_Gen" );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationSupplier_GenCustomerLocation" ,  "CreateCustomerLocation" );
         GXReorganization.SetMsg( 45 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERLOCATIONSUPPLIER_GEN1"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationSupplier_GenSupplier_Gen" ,  "CreateCustomerLocationSupplier_Gen" );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationSupplier_GenSupplier_Gen" ,  "CreateSupplier_Gen" );
         GXReorganization.SetMsg( 46 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IRESIDENTPRODUCTSERVICE2"}) );
         ReorgExecute.RegisterPrecedence( "RIResidentProductServiceResident" ,  "CreateResidentProductService" );
         ReorgExecute.RegisterPrecedence( "RIResidentProductServiceResident" ,  "CreateResident" );
         GXReorganization.SetMsg( 47 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IRESIDENTPRODUCTSERVICE1"}) );
         ReorgExecute.RegisterPrecedence( "RIResidentProductServiceProductService" ,  "CreateResidentProductService" );
         ReorgExecute.RegisterPrecedence( "RIResidentProductServiceProductService" ,  "CreateProductService" );
         GXReorganization.SetMsg( 48 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERLOCATIONSAMENITIES2"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationsAmenitiesCustomerLocation" ,  "CreateCustomerLocationsAmenities" );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationsAmenitiesCustomerLocation" ,  "CreateCustomerLocation" );
         GXReorganization.SetMsg( 49 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERLOCATIONSAMENITIES1"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationsAmenitiesAmenities" ,  "CreateCustomerLocationsAmenities" );
         ReorgExecute.RegisterPrecedence( "RICustomerLocationsAmenitiesAmenities" ,  "CreateAmenities" );
         GXReorganization.SetMsg( 50 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IAMENITIES1"}) );
         ReorgExecute.RegisterPrecedence( "RIAmenitiesAmenitiesType" ,  "CreateAmenities" );
         ReorgExecute.RegisterPrecedence( "RIAmenitiesAmenitiesType" ,  "CreateAmenitiesType" );
         GXReorganization.SetMsg( 51 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPAGE1"}) );
         ReorgExecute.RegisterPrecedence( "RIPageCustomer" ,  "CreatePage" );
         ReorgExecute.RegisterPrecedence( "RIPageCustomer" ,  "CreateCustomer" );
         GXReorganization.SetMsg( 52 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ILOCATIONEVENT1"}) );
         ReorgExecute.RegisterPrecedence( "RILocationEventCustomerLocation" ,  "CreateLocationEvent" );
         ReorgExecute.RegisterPrecedence( "RILocationEventCustomerLocation" ,  "CreateCustomerLocation" );
         GXReorganization.SetMsg( 53 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICUSTOMERCUSTOMIZATION1"}) );
         ReorgExecute.RegisterPrecedence( "RICustomerCustomizationCustomer" ,  "CreateCustomerCustomization" );
         ReorgExecute.RegisterPrecedence( "RICustomerCustomizationCustomer" ,  "CreateCustomer" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         sSchemaVar = "";
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         P00012_Atablename = new string[] {""} ;
         P00012_ntablename = new bool[] {false} ;
         P00012_Aschemaname = new string[] {""} ;
         P00012_nschemaname = new bool[] {false} ;
         P00023_Atablename = new string[] {""} ;
         P00023_ntablename = new bool[] {false} ;
         P00023_Aschemaname = new string[] {""} ;
         P00023_nschemaname = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_Atablename, P00012_Aschemaname
               }
               , new Object[] {
               P00023_Atablename, P00023_Aschemaname
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string sSchemaVar ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected string tablename ;
      protected string schemaname ;
      protected GxDataStore DS ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_Atablename ;
      protected bool[] P00012_ntablename ;
      protected string[] P00012_Aschemaname ;
      protected bool[] P00012_nschemaname ;
      protected string[] P00023_Atablename ;
      protected bool[] P00023_ntablename ;
      protected string[] P00023_Aschemaname ;
      protected bool[] P00023_nschemaname ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT TABLENAME, TABLEOWNER FROM PG_TABLES WHERE (UPPER(TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(TABLEOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT VIEWNAME, VIEWOWNER FROM PG_VIEWS WHERE (UPPER(VIEWNAME) = ( UPPER(:sTableName))) AND (UPPER(VIEWOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
