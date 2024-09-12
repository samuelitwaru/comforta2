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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class locationevent_bc : GxSilentTrn, IGxSilentTrn
   {
      public locationevent_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public locationevent_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0G26( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0G26( ) ;
         standaloneModal( ) ;
         AddRow0G26( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z115LocationEventId = A115LocationEventId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G26( ) ;
            }
            else
            {
               CheckExtendedTable0G26( ) ;
               if ( AnyError == 0 )
               {
                  ZM0G26( 3) ;
               }
               CloseExtendedTableCursors0G26( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0G26( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z116LocationEventStartDate = A116LocationEventStartDate;
            Z117LocationEventEndDate = A117LocationEventEndDate;
            Z118LocationEventTitle = A118LocationEventTitle;
            Z119LocationEventDisplay = A119LocationEventDisplay;
            Z120LocationEventBackgroundColor = A120LocationEventBackgroundColor;
            Z122LocationEventBorderColor = A122LocationEventBorderColor;
            Z123LocationEventTextColor = A123LocationEventTextColor;
            Z124LocationEventUrl = A124LocationEventUrl;
            Z125LocationEventAllDay = A125LocationEventAllDay;
            Z126LocationEventRecurring = A126LocationEventRecurring;
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z115LocationEventId = A115LocationEventId;
            Z116LocationEventStartDate = A116LocationEventStartDate;
            Z117LocationEventEndDate = A117LocationEventEndDate;
            Z118LocationEventTitle = A118LocationEventTitle;
            Z119LocationEventDisplay = A119LocationEventDisplay;
            Z120LocationEventBackgroundColor = A120LocationEventBackgroundColor;
            Z121LocationEventDescription = A121LocationEventDescription;
            Z122LocationEventBorderColor = A122LocationEventBorderColor;
            Z123LocationEventTextColor = A123LocationEventTextColor;
            Z124LocationEventUrl = A124LocationEventUrl;
            Z125LocationEventAllDay = A125LocationEventAllDay;
            Z126LocationEventRecurring = A126LocationEventRecurring;
            Z127LocationEventRecuringDays = A127LocationEventRecuringDays;
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0G26( )
      {
         /* Using cursor BC000G5 */
         pr_default.execute(3, new Object[] {A115LocationEventId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound26 = 1;
            A116LocationEventStartDate = BC000G5_A116LocationEventStartDate[0];
            A117LocationEventEndDate = BC000G5_A117LocationEventEndDate[0];
            A118LocationEventTitle = BC000G5_A118LocationEventTitle[0];
            A119LocationEventDisplay = BC000G5_A119LocationEventDisplay[0];
            A120LocationEventBackgroundColor = BC000G5_A120LocationEventBackgroundColor[0];
            A121LocationEventDescription = BC000G5_A121LocationEventDescription[0];
            A122LocationEventBorderColor = BC000G5_A122LocationEventBorderColor[0];
            A123LocationEventTextColor = BC000G5_A123LocationEventTextColor[0];
            A124LocationEventUrl = BC000G5_A124LocationEventUrl[0];
            A125LocationEventAllDay = BC000G5_A125LocationEventAllDay[0];
            A126LocationEventRecurring = BC000G5_A126LocationEventRecurring[0];
            A127LocationEventRecuringDays = BC000G5_A127LocationEventRecuringDays[0];
            A1CustomerId = BC000G5_A1CustomerId[0];
            A18CustomerLocationId = BC000G5_A18CustomerLocationId[0];
            ZM0G26( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0G26( ) ;
      }

      protected void OnLoadActions0G26( )
      {
      }

      protected void CheckExtendedTable0G26( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A124LocationEventUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("Field Location Event Url does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000G4 */
         pr_default.execute(2, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'CustomerLocation'.", "ForeignKeyNotFound", 1, "CUSTOMERLOCATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0G26( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G26( )
      {
         /* Using cursor BC000G6 */
         pr_default.execute(4, new Object[] {A115LocationEventId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000G3 */
         pr_default.execute(1, new Object[] {A115LocationEventId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G26( 2) ;
            RcdFound26 = 1;
            A115LocationEventId = BC000G3_A115LocationEventId[0];
            A116LocationEventStartDate = BC000G3_A116LocationEventStartDate[0];
            A117LocationEventEndDate = BC000G3_A117LocationEventEndDate[0];
            A118LocationEventTitle = BC000G3_A118LocationEventTitle[0];
            A119LocationEventDisplay = BC000G3_A119LocationEventDisplay[0];
            A120LocationEventBackgroundColor = BC000G3_A120LocationEventBackgroundColor[0];
            A121LocationEventDescription = BC000G3_A121LocationEventDescription[0];
            A122LocationEventBorderColor = BC000G3_A122LocationEventBorderColor[0];
            A123LocationEventTextColor = BC000G3_A123LocationEventTextColor[0];
            A124LocationEventUrl = BC000G3_A124LocationEventUrl[0];
            A125LocationEventAllDay = BC000G3_A125LocationEventAllDay[0];
            A126LocationEventRecurring = BC000G3_A126LocationEventRecurring[0];
            A127LocationEventRecuringDays = BC000G3_A127LocationEventRecuringDays[0];
            A1CustomerId = BC000G3_A1CustomerId[0];
            A18CustomerLocationId = BC000G3_A18CustomerLocationId[0];
            Z115LocationEventId = A115LocationEventId;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0G26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0G26( ) ;
            }
            Gx_mode = sMode26;
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0G26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode26;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0G26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G2 */
            pr_default.execute(0, new Object[] {A115LocationEventId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LocationEvent"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z116LocationEventStartDate != BC000G2_A116LocationEventStartDate[0] ) || ( Z117LocationEventEndDate != BC000G2_A117LocationEventEndDate[0] ) || ( StringUtil.StrCmp(Z118LocationEventTitle, BC000G2_A118LocationEventTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z119LocationEventDisplay, BC000G2_A119LocationEventDisplay[0]) != 0 ) || ( StringUtil.StrCmp(Z120LocationEventBackgroundColor, BC000G2_A120LocationEventBackgroundColor[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z122LocationEventBorderColor, BC000G2_A122LocationEventBorderColor[0]) != 0 ) || ( StringUtil.StrCmp(Z123LocationEventTextColor, BC000G2_A123LocationEventTextColor[0]) != 0 ) || ( StringUtil.StrCmp(Z124LocationEventUrl, BC000G2_A124LocationEventUrl[0]) != 0 ) || ( Z125LocationEventAllDay != BC000G2_A125LocationEventAllDay[0] ) || ( Z126LocationEventRecurring != BC000G2_A126LocationEventRecurring[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1CustomerId != BC000G2_A1CustomerId[0] ) || ( Z18CustomerLocationId != BC000G2_A18CustomerLocationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LocationEvent"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G26( )
      {
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G26( 0) ;
            CheckOptimisticConcurrency0G26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G7 */
                     pr_default.execute(5, new Object[] {A116LocationEventStartDate, A117LocationEventEndDate, A118LocationEventTitle, A119LocationEventDisplay, A120LocationEventBackgroundColor, A121LocationEventDescription, A122LocationEventBorderColor, A123LocationEventTextColor, A124LocationEventUrl, A125LocationEventAllDay, A126LocationEventRecurring, A127LocationEventRecuringDays, A1CustomerId, A18CustomerLocationId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000G8 */
                     pr_default.execute(6);
                     A115LocationEventId = BC000G8_A115LocationEventId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("LocationEvent");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0G26( ) ;
            }
            EndLevel0G26( ) ;
         }
         CloseExtendedTableCursors0G26( ) ;
      }

      protected void Update0G26( )
      {
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G9 */
                     pr_default.execute(7, new Object[] {A116LocationEventStartDate, A117LocationEventEndDate, A118LocationEventTitle, A119LocationEventDisplay, A120LocationEventBackgroundColor, A121LocationEventDescription, A122LocationEventBorderColor, A123LocationEventTextColor, A124LocationEventUrl, A125LocationEventAllDay, A126LocationEventRecurring, A127LocationEventRecuringDays, A1CustomerId, A18CustomerLocationId, A115LocationEventId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("LocationEvent");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LocationEvent"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G26( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0G26( ) ;
         }
         CloseExtendedTableCursors0G26( ) ;
      }

      protected void DeferredUpdate0G26( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G26( ) ;
            AfterConfirm0G26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000G10 */
                  pr_default.execute(8, new Object[] {A115LocationEventId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("LocationEvent");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G26( ) ;
         Gx_mode = sMode26;
      }

      protected void OnDeleteControls0G26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0G26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0G26( )
      {
         /* Using cursor BC000G11 */
         pr_default.execute(9, new Object[] {A115LocationEventId});
         RcdFound26 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound26 = 1;
            A115LocationEventId = BC000G11_A115LocationEventId[0];
            A116LocationEventStartDate = BC000G11_A116LocationEventStartDate[0];
            A117LocationEventEndDate = BC000G11_A117LocationEventEndDate[0];
            A118LocationEventTitle = BC000G11_A118LocationEventTitle[0];
            A119LocationEventDisplay = BC000G11_A119LocationEventDisplay[0];
            A120LocationEventBackgroundColor = BC000G11_A120LocationEventBackgroundColor[0];
            A121LocationEventDescription = BC000G11_A121LocationEventDescription[0];
            A122LocationEventBorderColor = BC000G11_A122LocationEventBorderColor[0];
            A123LocationEventTextColor = BC000G11_A123LocationEventTextColor[0];
            A124LocationEventUrl = BC000G11_A124LocationEventUrl[0];
            A125LocationEventAllDay = BC000G11_A125LocationEventAllDay[0];
            A126LocationEventRecurring = BC000G11_A126LocationEventRecurring[0];
            A127LocationEventRecuringDays = BC000G11_A127LocationEventRecuringDays[0];
            A1CustomerId = BC000G11_A1CustomerId[0];
            A18CustomerLocationId = BC000G11_A18CustomerLocationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G26( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound26 = 0;
         ScanKeyLoad0G26( ) ;
      }

      protected void ScanKeyLoad0G26( )
      {
         sMode26 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound26 = 1;
            A115LocationEventId = BC000G11_A115LocationEventId[0];
            A116LocationEventStartDate = BC000G11_A116LocationEventStartDate[0];
            A117LocationEventEndDate = BC000G11_A117LocationEventEndDate[0];
            A118LocationEventTitle = BC000G11_A118LocationEventTitle[0];
            A119LocationEventDisplay = BC000G11_A119LocationEventDisplay[0];
            A120LocationEventBackgroundColor = BC000G11_A120LocationEventBackgroundColor[0];
            A121LocationEventDescription = BC000G11_A121LocationEventDescription[0];
            A122LocationEventBorderColor = BC000G11_A122LocationEventBorderColor[0];
            A123LocationEventTextColor = BC000G11_A123LocationEventTextColor[0];
            A124LocationEventUrl = BC000G11_A124LocationEventUrl[0];
            A125LocationEventAllDay = BC000G11_A125LocationEventAllDay[0];
            A126LocationEventRecurring = BC000G11_A126LocationEventRecurring[0];
            A127LocationEventRecuringDays = BC000G11_A127LocationEventRecuringDays[0];
            A1CustomerId = BC000G11_A1CustomerId[0];
            A18CustomerLocationId = BC000G11_A18CustomerLocationId[0];
         }
         Gx_mode = sMode26;
      }

      protected void ScanKeyEnd0G26( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0G26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G26( )
      {
      }

      protected void send_integrity_lvl_hashes0G26( )
      {
      }

      protected void AddRow0G26( )
      {
         VarsToRow26( bcLocationEvent) ;
      }

      protected void ReadRow0G26( )
      {
         RowToVars26( bcLocationEvent, 1) ;
      }

      protected void InitializeNonKey0G26( )
      {
         A116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         A117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         A118LocationEventTitle = "";
         A119LocationEventDisplay = "";
         A120LocationEventBackgroundColor = "";
         A121LocationEventDescription = "";
         A122LocationEventBorderColor = "";
         A123LocationEventTextColor = "";
         A124LocationEventUrl = "";
         A125LocationEventAllDay = false;
         A126LocationEventRecurring = false;
         A127LocationEventRecuringDays = "";
         A1CustomerId = 0;
         A18CustomerLocationId = 0;
         Z116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         Z117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         Z118LocationEventTitle = "";
         Z119LocationEventDisplay = "";
         Z120LocationEventBackgroundColor = "";
         Z122LocationEventBorderColor = "";
         Z123LocationEventTextColor = "";
         Z124LocationEventUrl = "";
         Z125LocationEventAllDay = false;
         Z126LocationEventRecurring = false;
         Z1CustomerId = 0;
         Z18CustomerLocationId = 0;
      }

      protected void InitAll0G26( )
      {
         A115LocationEventId = 0;
         InitializeNonKey0G26( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow26( SdtLocationEvent obj26 )
      {
         obj26.gxTpr_Mode = Gx_mode;
         obj26.gxTpr_Locationeventstartdate = A116LocationEventStartDate;
         obj26.gxTpr_Locationeventenddate = A117LocationEventEndDate;
         obj26.gxTpr_Locationeventtitle = A118LocationEventTitle;
         obj26.gxTpr_Locationeventdisplay = A119LocationEventDisplay;
         obj26.gxTpr_Locationeventbackgroundcolor = A120LocationEventBackgroundColor;
         obj26.gxTpr_Locationeventdescription = A121LocationEventDescription;
         obj26.gxTpr_Locationeventbordercolor = A122LocationEventBorderColor;
         obj26.gxTpr_Locationeventtextcolor = A123LocationEventTextColor;
         obj26.gxTpr_Locationeventurl = A124LocationEventUrl;
         obj26.gxTpr_Locationeventallday = A125LocationEventAllDay;
         obj26.gxTpr_Locationeventrecurring = A126LocationEventRecurring;
         obj26.gxTpr_Locationeventrecuringdays = A127LocationEventRecuringDays;
         obj26.gxTpr_Customerid = A1CustomerId;
         obj26.gxTpr_Customerlocationid = A18CustomerLocationId;
         obj26.gxTpr_Locationeventid = A115LocationEventId;
         obj26.gxTpr_Locationeventid_Z = Z115LocationEventId;
         obj26.gxTpr_Locationeventstartdate_Z = Z116LocationEventStartDate;
         obj26.gxTpr_Locationeventenddate_Z = Z117LocationEventEndDate;
         obj26.gxTpr_Locationeventtitle_Z = Z118LocationEventTitle;
         obj26.gxTpr_Locationeventdisplay_Z = Z119LocationEventDisplay;
         obj26.gxTpr_Locationeventbackgroundcolor_Z = Z120LocationEventBackgroundColor;
         obj26.gxTpr_Locationeventbordercolor_Z = Z122LocationEventBorderColor;
         obj26.gxTpr_Locationeventtextcolor_Z = Z123LocationEventTextColor;
         obj26.gxTpr_Locationeventurl_Z = Z124LocationEventUrl;
         obj26.gxTpr_Locationeventallday_Z = Z125LocationEventAllDay;
         obj26.gxTpr_Locationeventrecurring_Z = Z126LocationEventRecurring;
         obj26.gxTpr_Customerid_Z = Z1CustomerId;
         obj26.gxTpr_Customerlocationid_Z = Z18CustomerLocationId;
         obj26.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow26( SdtLocationEvent obj26 )
      {
         obj26.gxTpr_Locationeventid = A115LocationEventId;
         return  ;
      }

      public void RowToVars26( SdtLocationEvent obj26 ,
                               int forceLoad )
      {
         Gx_mode = obj26.gxTpr_Mode;
         A116LocationEventStartDate = obj26.gxTpr_Locationeventstartdate;
         A117LocationEventEndDate = obj26.gxTpr_Locationeventenddate;
         A118LocationEventTitle = obj26.gxTpr_Locationeventtitle;
         A119LocationEventDisplay = obj26.gxTpr_Locationeventdisplay;
         A120LocationEventBackgroundColor = obj26.gxTpr_Locationeventbackgroundcolor;
         A121LocationEventDescription = obj26.gxTpr_Locationeventdescription;
         A122LocationEventBorderColor = obj26.gxTpr_Locationeventbordercolor;
         A123LocationEventTextColor = obj26.gxTpr_Locationeventtextcolor;
         A124LocationEventUrl = obj26.gxTpr_Locationeventurl;
         A125LocationEventAllDay = obj26.gxTpr_Locationeventallday;
         A126LocationEventRecurring = obj26.gxTpr_Locationeventrecurring;
         A127LocationEventRecuringDays = obj26.gxTpr_Locationeventrecuringdays;
         A1CustomerId = obj26.gxTpr_Customerid;
         A18CustomerLocationId = obj26.gxTpr_Customerlocationid;
         A115LocationEventId = obj26.gxTpr_Locationeventid;
         Z115LocationEventId = obj26.gxTpr_Locationeventid_Z;
         Z116LocationEventStartDate = obj26.gxTpr_Locationeventstartdate_Z;
         Z117LocationEventEndDate = obj26.gxTpr_Locationeventenddate_Z;
         Z118LocationEventTitle = obj26.gxTpr_Locationeventtitle_Z;
         Z119LocationEventDisplay = obj26.gxTpr_Locationeventdisplay_Z;
         Z120LocationEventBackgroundColor = obj26.gxTpr_Locationeventbackgroundcolor_Z;
         Z122LocationEventBorderColor = obj26.gxTpr_Locationeventbordercolor_Z;
         Z123LocationEventTextColor = obj26.gxTpr_Locationeventtextcolor_Z;
         Z124LocationEventUrl = obj26.gxTpr_Locationeventurl_Z;
         Z125LocationEventAllDay = obj26.gxTpr_Locationeventallday_Z;
         Z126LocationEventRecurring = obj26.gxTpr_Locationeventrecurring_Z;
         Z1CustomerId = obj26.gxTpr_Customerid_Z;
         Z18CustomerLocationId = obj26.gxTpr_Customerlocationid_Z;
         Gx_mode = obj26.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A115LocationEventId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0G26( ) ;
         ScanKeyStart0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z115LocationEventId = A115LocationEventId;
         }
         ZM0G26( -2) ;
         OnLoadActions0G26( ) ;
         AddRow0G26( ) ;
         ScanKeyEnd0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars26( bcLocationEvent, 0) ;
         ScanKeyStart0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z115LocationEventId = A115LocationEventId;
         }
         ZM0G26( -2) ;
         OnLoadActions0G26( ) ;
         AddRow0G26( ) ;
         ScanKeyEnd0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0G26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0G26( ) ;
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( A115LocationEventId != Z115LocationEventId )
               {
                  A115LocationEventId = Z115LocationEventId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0G26( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A115LocationEventId != Z115LocationEventId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0G26( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0G26( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars26( bcLocationEvent, 1) ;
         SaveImpl( ) ;
         VarsToRow26( bcLocationEvent) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars26( bcLocationEvent, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G26( ) ;
         AfterTrn( ) ;
         VarsToRow26( bcLocationEvent) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow26( bcLocationEvent) ;
         }
         else
         {
            SdtLocationEvent auxBC = new SdtLocationEvent(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A115LocationEventId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcLocationEvent);
               auxBC.Save();
               bcLocationEvent.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars26( bcLocationEvent, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars26( bcLocationEvent, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G26( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow26( bcLocationEvent) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow26( bcLocationEvent) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars26( bcLocationEvent, 0) ;
         GetKey0G26( ) ;
         if ( RcdFound26 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A115LocationEventId != Z115LocationEventId )
            {
               A115LocationEventId = Z115LocationEventId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A115LocationEventId != Z115LocationEventId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("locationevent_bc",pr_default);
         VarsToRow26( bcLocationEvent) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcLocationEvent.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcLocationEvent.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcLocationEvent )
         {
            bcLocationEvent = (SdtLocationEvent)(sdt);
            if ( StringUtil.StrCmp(bcLocationEvent.gxTpr_Mode, "") == 0 )
            {
               bcLocationEvent.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow26( bcLocationEvent) ;
            }
            else
            {
               RowToVars26( bcLocationEvent, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcLocationEvent.gxTpr_Mode, "") == 0 )
            {
               bcLocationEvent.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars26( bcLocationEvent, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtLocationEvent LocationEvent_BC
      {
         get {
            return bcLocationEvent ;
         }

      }

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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "locationagenda_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         A116LocationEventStartDate = (DateTime)(DateTime.MinValue);
         Z117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         A117LocationEventEndDate = (DateTime)(DateTime.MinValue);
         Z118LocationEventTitle = "";
         A118LocationEventTitle = "";
         Z119LocationEventDisplay = "";
         A119LocationEventDisplay = "";
         Z120LocationEventBackgroundColor = "";
         A120LocationEventBackgroundColor = "";
         Z122LocationEventBorderColor = "";
         A122LocationEventBorderColor = "";
         Z123LocationEventTextColor = "";
         A123LocationEventTextColor = "";
         Z124LocationEventUrl = "";
         A124LocationEventUrl = "";
         Z121LocationEventDescription = "";
         A121LocationEventDescription = "";
         Z127LocationEventRecuringDays = "";
         A127LocationEventRecuringDays = "";
         BC000G5_A115LocationEventId = new short[1] ;
         BC000G5_A116LocationEventStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000G5_A117LocationEventEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000G5_A118LocationEventTitle = new string[] {""} ;
         BC000G5_A119LocationEventDisplay = new string[] {""} ;
         BC000G5_A120LocationEventBackgroundColor = new string[] {""} ;
         BC000G5_A121LocationEventDescription = new string[] {""} ;
         BC000G5_A122LocationEventBorderColor = new string[] {""} ;
         BC000G5_A123LocationEventTextColor = new string[] {""} ;
         BC000G5_A124LocationEventUrl = new string[] {""} ;
         BC000G5_A125LocationEventAllDay = new bool[] {false} ;
         BC000G5_A126LocationEventRecurring = new bool[] {false} ;
         BC000G5_A127LocationEventRecuringDays = new string[] {""} ;
         BC000G5_A1CustomerId = new short[1] ;
         BC000G5_A18CustomerLocationId = new short[1] ;
         BC000G4_A1CustomerId = new short[1] ;
         BC000G6_A115LocationEventId = new short[1] ;
         BC000G3_A115LocationEventId = new short[1] ;
         BC000G3_A116LocationEventStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000G3_A117LocationEventEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000G3_A118LocationEventTitle = new string[] {""} ;
         BC000G3_A119LocationEventDisplay = new string[] {""} ;
         BC000G3_A120LocationEventBackgroundColor = new string[] {""} ;
         BC000G3_A121LocationEventDescription = new string[] {""} ;
         BC000G3_A122LocationEventBorderColor = new string[] {""} ;
         BC000G3_A123LocationEventTextColor = new string[] {""} ;
         BC000G3_A124LocationEventUrl = new string[] {""} ;
         BC000G3_A125LocationEventAllDay = new bool[] {false} ;
         BC000G3_A126LocationEventRecurring = new bool[] {false} ;
         BC000G3_A127LocationEventRecuringDays = new string[] {""} ;
         BC000G3_A1CustomerId = new short[1] ;
         BC000G3_A18CustomerLocationId = new short[1] ;
         sMode26 = "";
         BC000G2_A115LocationEventId = new short[1] ;
         BC000G2_A116LocationEventStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000G2_A117LocationEventEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000G2_A118LocationEventTitle = new string[] {""} ;
         BC000G2_A119LocationEventDisplay = new string[] {""} ;
         BC000G2_A120LocationEventBackgroundColor = new string[] {""} ;
         BC000G2_A121LocationEventDescription = new string[] {""} ;
         BC000G2_A122LocationEventBorderColor = new string[] {""} ;
         BC000G2_A123LocationEventTextColor = new string[] {""} ;
         BC000G2_A124LocationEventUrl = new string[] {""} ;
         BC000G2_A125LocationEventAllDay = new bool[] {false} ;
         BC000G2_A126LocationEventRecurring = new bool[] {false} ;
         BC000G2_A127LocationEventRecuringDays = new string[] {""} ;
         BC000G2_A1CustomerId = new short[1] ;
         BC000G2_A18CustomerLocationId = new short[1] ;
         BC000G8_A115LocationEventId = new short[1] ;
         BC000G11_A115LocationEventId = new short[1] ;
         BC000G11_A116LocationEventStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000G11_A117LocationEventEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000G11_A118LocationEventTitle = new string[] {""} ;
         BC000G11_A119LocationEventDisplay = new string[] {""} ;
         BC000G11_A120LocationEventBackgroundColor = new string[] {""} ;
         BC000G11_A121LocationEventDescription = new string[] {""} ;
         BC000G11_A122LocationEventBorderColor = new string[] {""} ;
         BC000G11_A123LocationEventTextColor = new string[] {""} ;
         BC000G11_A124LocationEventUrl = new string[] {""} ;
         BC000G11_A125LocationEventAllDay = new bool[] {false} ;
         BC000G11_A126LocationEventRecurring = new bool[] {false} ;
         BC000G11_A127LocationEventRecuringDays = new string[] {""} ;
         BC000G11_A1CustomerId = new short[1] ;
         BC000G11_A18CustomerLocationId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.locationevent_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.locationevent_bc__default(),
            new Object[][] {
                new Object[] {
               BC000G2_A115LocationEventId, BC000G2_A116LocationEventStartDate, BC000G2_A117LocationEventEndDate, BC000G2_A118LocationEventTitle, BC000G2_A119LocationEventDisplay, BC000G2_A120LocationEventBackgroundColor, BC000G2_A121LocationEventDescription, BC000G2_A122LocationEventBorderColor, BC000G2_A123LocationEventTextColor, BC000G2_A124LocationEventUrl,
               BC000G2_A125LocationEventAllDay, BC000G2_A126LocationEventRecurring, BC000G2_A127LocationEventRecuringDays, BC000G2_A1CustomerId, BC000G2_A18CustomerLocationId
               }
               , new Object[] {
               BC000G3_A115LocationEventId, BC000G3_A116LocationEventStartDate, BC000G3_A117LocationEventEndDate, BC000G3_A118LocationEventTitle, BC000G3_A119LocationEventDisplay, BC000G3_A120LocationEventBackgroundColor, BC000G3_A121LocationEventDescription, BC000G3_A122LocationEventBorderColor, BC000G3_A123LocationEventTextColor, BC000G3_A124LocationEventUrl,
               BC000G3_A125LocationEventAllDay, BC000G3_A126LocationEventRecurring, BC000G3_A127LocationEventRecuringDays, BC000G3_A1CustomerId, BC000G3_A18CustomerLocationId
               }
               , new Object[] {
               BC000G4_A1CustomerId
               }
               , new Object[] {
               BC000G5_A115LocationEventId, BC000G5_A116LocationEventStartDate, BC000G5_A117LocationEventEndDate, BC000G5_A118LocationEventTitle, BC000G5_A119LocationEventDisplay, BC000G5_A120LocationEventBackgroundColor, BC000G5_A121LocationEventDescription, BC000G5_A122LocationEventBorderColor, BC000G5_A123LocationEventTextColor, BC000G5_A124LocationEventUrl,
               BC000G5_A125LocationEventAllDay, BC000G5_A126LocationEventRecurring, BC000G5_A127LocationEventRecuringDays, BC000G5_A1CustomerId, BC000G5_A18CustomerLocationId
               }
               , new Object[] {
               BC000G6_A115LocationEventId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G8_A115LocationEventId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G11_A115LocationEventId, BC000G11_A116LocationEventStartDate, BC000G11_A117LocationEventEndDate, BC000G11_A118LocationEventTitle, BC000G11_A119LocationEventDisplay, BC000G11_A120LocationEventBackgroundColor, BC000G11_A121LocationEventDescription, BC000G11_A122LocationEventBorderColor, BC000G11_A123LocationEventTextColor, BC000G11_A124LocationEventUrl,
               BC000G11_A125LocationEventAllDay, BC000G11_A126LocationEventRecurring, BC000G11_A127LocationEventRecuringDays, BC000G11_A1CustomerId, BC000G11_A18CustomerLocationId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z115LocationEventId ;
      private short A115LocationEventId ;
      private short Z1CustomerId ;
      private short A1CustomerId ;
      private short Z18CustomerLocationId ;
      private short A18CustomerLocationId ;
      private short RcdFound26 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode26 ;
      private DateTime Z116LocationEventStartDate ;
      private DateTime A116LocationEventStartDate ;
      private DateTime Z117LocationEventEndDate ;
      private DateTime A117LocationEventEndDate ;
      private bool Z125LocationEventAllDay ;
      private bool A125LocationEventAllDay ;
      private bool Z126LocationEventRecurring ;
      private bool A126LocationEventRecurring ;
      private bool Gx_longc ;
      private string Z121LocationEventDescription ;
      private string A121LocationEventDescription ;
      private string Z127LocationEventRecuringDays ;
      private string A127LocationEventRecuringDays ;
      private string Z118LocationEventTitle ;
      private string A118LocationEventTitle ;
      private string Z119LocationEventDisplay ;
      private string A119LocationEventDisplay ;
      private string Z120LocationEventBackgroundColor ;
      private string A120LocationEventBackgroundColor ;
      private string Z122LocationEventBorderColor ;
      private string A122LocationEventBorderColor ;
      private string Z123LocationEventTextColor ;
      private string A123LocationEventTextColor ;
      private string Z124LocationEventUrl ;
      private string A124LocationEventUrl ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000G5_A115LocationEventId ;
      private DateTime[] BC000G5_A116LocationEventStartDate ;
      private DateTime[] BC000G5_A117LocationEventEndDate ;
      private string[] BC000G5_A118LocationEventTitle ;
      private string[] BC000G5_A119LocationEventDisplay ;
      private string[] BC000G5_A120LocationEventBackgroundColor ;
      private string[] BC000G5_A121LocationEventDescription ;
      private string[] BC000G5_A122LocationEventBorderColor ;
      private string[] BC000G5_A123LocationEventTextColor ;
      private string[] BC000G5_A124LocationEventUrl ;
      private bool[] BC000G5_A125LocationEventAllDay ;
      private bool[] BC000G5_A126LocationEventRecurring ;
      private string[] BC000G5_A127LocationEventRecuringDays ;
      private short[] BC000G5_A1CustomerId ;
      private short[] BC000G5_A18CustomerLocationId ;
      private short[] BC000G4_A1CustomerId ;
      private short[] BC000G6_A115LocationEventId ;
      private short[] BC000G3_A115LocationEventId ;
      private DateTime[] BC000G3_A116LocationEventStartDate ;
      private DateTime[] BC000G3_A117LocationEventEndDate ;
      private string[] BC000G3_A118LocationEventTitle ;
      private string[] BC000G3_A119LocationEventDisplay ;
      private string[] BC000G3_A120LocationEventBackgroundColor ;
      private string[] BC000G3_A121LocationEventDescription ;
      private string[] BC000G3_A122LocationEventBorderColor ;
      private string[] BC000G3_A123LocationEventTextColor ;
      private string[] BC000G3_A124LocationEventUrl ;
      private bool[] BC000G3_A125LocationEventAllDay ;
      private bool[] BC000G3_A126LocationEventRecurring ;
      private string[] BC000G3_A127LocationEventRecuringDays ;
      private short[] BC000G3_A1CustomerId ;
      private short[] BC000G3_A18CustomerLocationId ;
      private short[] BC000G2_A115LocationEventId ;
      private DateTime[] BC000G2_A116LocationEventStartDate ;
      private DateTime[] BC000G2_A117LocationEventEndDate ;
      private string[] BC000G2_A118LocationEventTitle ;
      private string[] BC000G2_A119LocationEventDisplay ;
      private string[] BC000G2_A120LocationEventBackgroundColor ;
      private string[] BC000G2_A121LocationEventDescription ;
      private string[] BC000G2_A122LocationEventBorderColor ;
      private string[] BC000G2_A123LocationEventTextColor ;
      private string[] BC000G2_A124LocationEventUrl ;
      private bool[] BC000G2_A125LocationEventAllDay ;
      private bool[] BC000G2_A126LocationEventRecurring ;
      private string[] BC000G2_A127LocationEventRecuringDays ;
      private short[] BC000G2_A1CustomerId ;
      private short[] BC000G2_A18CustomerLocationId ;
      private short[] BC000G8_A115LocationEventId ;
      private short[] BC000G11_A115LocationEventId ;
      private DateTime[] BC000G11_A116LocationEventStartDate ;
      private DateTime[] BC000G11_A117LocationEventEndDate ;
      private string[] BC000G11_A118LocationEventTitle ;
      private string[] BC000G11_A119LocationEventDisplay ;
      private string[] BC000G11_A120LocationEventBackgroundColor ;
      private string[] BC000G11_A121LocationEventDescription ;
      private string[] BC000G11_A122LocationEventBorderColor ;
      private string[] BC000G11_A123LocationEventTextColor ;
      private string[] BC000G11_A124LocationEventUrl ;
      private bool[] BC000G11_A125LocationEventAllDay ;
      private bool[] BC000G11_A126LocationEventRecurring ;
      private string[] BC000G11_A127LocationEventRecuringDays ;
      private short[] BC000G11_A1CustomerId ;
      private short[] BC000G11_A18CustomerLocationId ;
      private SdtLocationEvent bcLocationEvent ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class locationevent_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class locationevent_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000G2;
        prmBC000G2 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmBC000G3;
        prmBC000G3 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmBC000G4;
        prmBC000G4 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000G5;
        prmBC000G5 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmBC000G6;
        prmBC000G6 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmBC000G7;
        prmBC000G7 = new Object[] {
        new ParDef("LocationEventStartDate",GXType.DateTime,8,5) ,
        new ParDef("LocationEventEndDate",GXType.DateTime,8,5) ,
        new ParDef("LocationEventTitle",GXType.VarChar,100,0) ,
        new ParDef("LocationEventDisplay",GXType.VarChar,40,0) ,
        new ParDef("LocationEventBackgroundColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("LocationEventBorderColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventTextColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventUrl",GXType.VarChar,1000,0) ,
        new ParDef("LocationEventAllDay",GXType.Boolean,4,0) ,
        new ParDef("LocationEventRecurring",GXType.Boolean,4,0) ,
        new ParDef("LocationEventRecuringDays",GXType.LongVarChar,2097152,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmBC000G8;
        prmBC000G8 = new Object[] {
        };
        Object[] prmBC000G9;
        prmBC000G9 = new Object[] {
        new ParDef("LocationEventStartDate",GXType.DateTime,8,5) ,
        new ParDef("LocationEventEndDate",GXType.DateTime,8,5) ,
        new ParDef("LocationEventTitle",GXType.VarChar,100,0) ,
        new ParDef("LocationEventDisplay",GXType.VarChar,40,0) ,
        new ParDef("LocationEventBackgroundColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("LocationEventBorderColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventTextColor",GXType.VarChar,40,0) ,
        new ParDef("LocationEventUrl",GXType.VarChar,1000,0) ,
        new ParDef("LocationEventAllDay",GXType.Boolean,4,0) ,
        new ParDef("LocationEventRecurring",GXType.Boolean,4,0) ,
        new ParDef("LocationEventRecuringDays",GXType.LongVarChar,2097152,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmBC000G10;
        prmBC000G10 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        Object[] prmBC000G11;
        prmBC000G11 = new Object[] {
        new ParDef("LocationEventId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000G2", "SELECT LocationEventId, LocationEventStartDate, LocationEventEndDate, LocationEventTitle, LocationEventDisplay, LocationEventBackgroundColor, LocationEventDescription, LocationEventBorderColor, LocationEventTextColor, LocationEventUrl, LocationEventAllDay, LocationEventRecurring, LocationEventRecuringDays, CustomerId, CustomerLocationId FROM LocationEvent WHERE LocationEventId = :LocationEventId  FOR UPDATE OF LocationEvent",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G3", "SELECT LocationEventId, LocationEventStartDate, LocationEventEndDate, LocationEventTitle, LocationEventDisplay, LocationEventBackgroundColor, LocationEventDescription, LocationEventBorderColor, LocationEventTextColor, LocationEventUrl, LocationEventAllDay, LocationEventRecurring, LocationEventRecuringDays, CustomerId, CustomerLocationId FROM LocationEvent WHERE LocationEventId = :LocationEventId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G4", "SELECT CustomerId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G5", "SELECT TM1.LocationEventId, TM1.LocationEventStartDate, TM1.LocationEventEndDate, TM1.LocationEventTitle, TM1.LocationEventDisplay, TM1.LocationEventBackgroundColor, TM1.LocationEventDescription, TM1.LocationEventBorderColor, TM1.LocationEventTextColor, TM1.LocationEventUrl, TM1.LocationEventAllDay, TM1.LocationEventRecurring, TM1.LocationEventRecuringDays, TM1.CustomerId, TM1.CustomerLocationId FROM LocationEvent TM1 WHERE TM1.LocationEventId = :LocationEventId ORDER BY TM1.LocationEventId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G6", "SELECT LocationEventId FROM LocationEvent WHERE LocationEventId = :LocationEventId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G7", "SAVEPOINT gxupdate;INSERT INTO LocationEvent(LocationEventStartDate, LocationEventEndDate, LocationEventTitle, LocationEventDisplay, LocationEventBackgroundColor, LocationEventDescription, LocationEventBorderColor, LocationEventTextColor, LocationEventUrl, LocationEventAllDay, LocationEventRecurring, LocationEventRecuringDays, CustomerId, CustomerLocationId) VALUES(:LocationEventStartDate, :LocationEventEndDate, :LocationEventTitle, :LocationEventDisplay, :LocationEventBackgroundColor, :LocationEventDescription, :LocationEventBorderColor, :LocationEventTextColor, :LocationEventUrl, :LocationEventAllDay, :LocationEventRecurring, :LocationEventRecuringDays, :CustomerId, :CustomerLocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G7)
           ,new CursorDef("BC000G8", "SELECT currval('LocationEventId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G9", "SAVEPOINT gxupdate;UPDATE LocationEvent SET LocationEventStartDate=:LocationEventStartDate, LocationEventEndDate=:LocationEventEndDate, LocationEventTitle=:LocationEventTitle, LocationEventDisplay=:LocationEventDisplay, LocationEventBackgroundColor=:LocationEventBackgroundColor, LocationEventDescription=:LocationEventDescription, LocationEventBorderColor=:LocationEventBorderColor, LocationEventTextColor=:LocationEventTextColor, LocationEventUrl=:LocationEventUrl, LocationEventAllDay=:LocationEventAllDay, LocationEventRecurring=:LocationEventRecurring, LocationEventRecuringDays=:LocationEventRecuringDays, CustomerId=:CustomerId, CustomerLocationId=:CustomerLocationId  WHERE LocationEventId = :LocationEventId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G9)
           ,new CursorDef("BC000G10", "SAVEPOINT gxupdate;DELETE FROM LocationEvent  WHERE LocationEventId = :LocationEventId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G10)
           ,new CursorDef("BC000G11", "SELECT TM1.LocationEventId, TM1.LocationEventStartDate, TM1.LocationEventEndDate, TM1.LocationEventTitle, TM1.LocationEventDisplay, TM1.LocationEventBackgroundColor, TM1.LocationEventDescription, TM1.LocationEventBorderColor, TM1.LocationEventTextColor, TM1.LocationEventUrl, TM1.LocationEventAllDay, TM1.LocationEventRecurring, TM1.LocationEventRecuringDays, TM1.CustomerId, TM1.CustomerLocationId FROM LocationEvent TM1 WHERE TM1.LocationEventId = :LocationEventId ORDER BY TM1.LocationEventId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G11,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              return;
     }
  }

}

}
