using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "LocationEvent" )]
   [XmlType(TypeName =  "LocationEvent" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtLocationEvent : GxSilentTrnSdt
   {
      public SdtLocationEvent( )
      {
      }

      public SdtLocationEvent( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV115LocationEventId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV115LocationEventId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LocationEventId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "LocationEvent");
         metadata.Set("BT", "LocationEvent");
         metadata.Set("PK", "[ \"LocationEventId\" ]");
         metadata.Set("PKAssigned", "[ \"LocationEventId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerId\",\"CustomerLocationId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Locationeventid_Z");
         state.Add("gxTpr_Locationeventstartdate_Z_Nullable");
         state.Add("gxTpr_Locationeventenddate_Z_Nullable");
         state.Add("gxTpr_Locationeventtitle_Z");
         state.Add("gxTpr_Locationeventdisplay_Z");
         state.Add("gxTpr_Locationeventbackgroundcolor_Z");
         state.Add("gxTpr_Locationeventbordercolor_Z");
         state.Add("gxTpr_Locationeventtextcolor_Z");
         state.Add("gxTpr_Locationeventurl_Z");
         state.Add("gxTpr_Locationeventallday_Z");
         state.Add("gxTpr_Locationeventrecurring_Z");
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customerlocationid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLocationEvent sdt;
         sdt = (SdtLocationEvent)(source);
         gxTv_SdtLocationEvent_Locationeventid = sdt.gxTv_SdtLocationEvent_Locationeventid ;
         gxTv_SdtLocationEvent_Locationeventstartdate = sdt.gxTv_SdtLocationEvent_Locationeventstartdate ;
         gxTv_SdtLocationEvent_Locationeventenddate = sdt.gxTv_SdtLocationEvent_Locationeventenddate ;
         gxTv_SdtLocationEvent_Locationeventtitle = sdt.gxTv_SdtLocationEvent_Locationeventtitle ;
         gxTv_SdtLocationEvent_Locationeventdisplay = sdt.gxTv_SdtLocationEvent_Locationeventdisplay ;
         gxTv_SdtLocationEvent_Locationeventbackgroundcolor = sdt.gxTv_SdtLocationEvent_Locationeventbackgroundcolor ;
         gxTv_SdtLocationEvent_Locationeventdescription = sdt.gxTv_SdtLocationEvent_Locationeventdescription ;
         gxTv_SdtLocationEvent_Locationeventbordercolor = sdt.gxTv_SdtLocationEvent_Locationeventbordercolor ;
         gxTv_SdtLocationEvent_Locationeventtextcolor = sdt.gxTv_SdtLocationEvent_Locationeventtextcolor ;
         gxTv_SdtLocationEvent_Locationeventurl = sdt.gxTv_SdtLocationEvent_Locationeventurl ;
         gxTv_SdtLocationEvent_Locationeventallday = sdt.gxTv_SdtLocationEvent_Locationeventallday ;
         gxTv_SdtLocationEvent_Locationeventrecurring = sdt.gxTv_SdtLocationEvent_Locationeventrecurring ;
         gxTv_SdtLocationEvent_Locationeventrecuringdays = sdt.gxTv_SdtLocationEvent_Locationeventrecuringdays ;
         gxTv_SdtLocationEvent_Customerid = sdt.gxTv_SdtLocationEvent_Customerid ;
         gxTv_SdtLocationEvent_Customerlocationid = sdt.gxTv_SdtLocationEvent_Customerlocationid ;
         gxTv_SdtLocationEvent_Mode = sdt.gxTv_SdtLocationEvent_Mode ;
         gxTv_SdtLocationEvent_Initialized = sdt.gxTv_SdtLocationEvent_Initialized ;
         gxTv_SdtLocationEvent_Locationeventid_Z = sdt.gxTv_SdtLocationEvent_Locationeventid_Z ;
         gxTv_SdtLocationEvent_Locationeventstartdate_Z = sdt.gxTv_SdtLocationEvent_Locationeventstartdate_Z ;
         gxTv_SdtLocationEvent_Locationeventenddate_Z = sdt.gxTv_SdtLocationEvent_Locationeventenddate_Z ;
         gxTv_SdtLocationEvent_Locationeventtitle_Z = sdt.gxTv_SdtLocationEvent_Locationeventtitle_Z ;
         gxTv_SdtLocationEvent_Locationeventdisplay_Z = sdt.gxTv_SdtLocationEvent_Locationeventdisplay_Z ;
         gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z = sdt.gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z ;
         gxTv_SdtLocationEvent_Locationeventbordercolor_Z = sdt.gxTv_SdtLocationEvent_Locationeventbordercolor_Z ;
         gxTv_SdtLocationEvent_Locationeventtextcolor_Z = sdt.gxTv_SdtLocationEvent_Locationeventtextcolor_Z ;
         gxTv_SdtLocationEvent_Locationeventurl_Z = sdt.gxTv_SdtLocationEvent_Locationeventurl_Z ;
         gxTv_SdtLocationEvent_Locationeventallday_Z = sdt.gxTv_SdtLocationEvent_Locationeventallday_Z ;
         gxTv_SdtLocationEvent_Locationeventrecurring_Z = sdt.gxTv_SdtLocationEvent_Locationeventrecurring_Z ;
         gxTv_SdtLocationEvent_Customerid_Z = sdt.gxTv_SdtLocationEvent_Customerid_Z ;
         gxTv_SdtLocationEvent_Customerlocationid_Z = sdt.gxTv_SdtLocationEvent_Customerlocationid_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("LocationEventId", gxTv_SdtLocationEvent_Locationeventid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtLocationEvent_Locationeventstartdate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("LocationEventStartDate", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtLocationEvent_Locationeventenddate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("LocationEventEndDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("LocationEventTitle", gxTv_SdtLocationEvent_Locationeventtitle, false, includeNonInitialized);
         AddObjectProperty("LocationEventDisplay", gxTv_SdtLocationEvent_Locationeventdisplay, false, includeNonInitialized);
         AddObjectProperty("LocationEventBackgroundColor", gxTv_SdtLocationEvent_Locationeventbackgroundcolor, false, includeNonInitialized);
         AddObjectProperty("LocationEventDescription", gxTv_SdtLocationEvent_Locationeventdescription, false, includeNonInitialized);
         AddObjectProperty("LocationEventBorderColor", gxTv_SdtLocationEvent_Locationeventbordercolor, false, includeNonInitialized);
         AddObjectProperty("LocationEventTextColor", gxTv_SdtLocationEvent_Locationeventtextcolor, false, includeNonInitialized);
         AddObjectProperty("LocationEventUrl", gxTv_SdtLocationEvent_Locationeventurl, false, includeNonInitialized);
         AddObjectProperty("LocationEventAllDay", gxTv_SdtLocationEvent_Locationeventallday, false, includeNonInitialized);
         AddObjectProperty("LocationEventRecurring", gxTv_SdtLocationEvent_Locationeventrecurring, false, includeNonInitialized);
         AddObjectProperty("LocationEventRecuringDays", gxTv_SdtLocationEvent_Locationeventrecuringdays, false, includeNonInitialized);
         AddObjectProperty("CustomerId", gxTv_SdtLocationEvent_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationId", gxTv_SdtLocationEvent_Customerlocationid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLocationEvent_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLocationEvent_Initialized, false, includeNonInitialized);
            AddObjectProperty("LocationEventId_Z", gxTv_SdtLocationEvent_Locationeventid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtLocationEvent_Locationeventstartdate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("LocationEventStartDate_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtLocationEvent_Locationeventenddate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("LocationEventEndDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("LocationEventTitle_Z", gxTv_SdtLocationEvent_Locationeventtitle_Z, false, includeNonInitialized);
            AddObjectProperty("LocationEventDisplay_Z", gxTv_SdtLocationEvent_Locationeventdisplay_Z, false, includeNonInitialized);
            AddObjectProperty("LocationEventBackgroundColor_Z", gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z, false, includeNonInitialized);
            AddObjectProperty("LocationEventBorderColor_Z", gxTv_SdtLocationEvent_Locationeventbordercolor_Z, false, includeNonInitialized);
            AddObjectProperty("LocationEventTextColor_Z", gxTv_SdtLocationEvent_Locationeventtextcolor_Z, false, includeNonInitialized);
            AddObjectProperty("LocationEventUrl_Z", gxTv_SdtLocationEvent_Locationeventurl_Z, false, includeNonInitialized);
            AddObjectProperty("LocationEventAllDay_Z", gxTv_SdtLocationEvent_Locationeventallday_Z, false, includeNonInitialized);
            AddObjectProperty("LocationEventRecurring_Z", gxTv_SdtLocationEvent_Locationeventrecurring_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerId_Z", gxTv_SdtLocationEvent_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationId_Z", gxTv_SdtLocationEvent_Customerlocationid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLocationEvent sdt )
      {
         if ( sdt.IsDirty("LocationEventId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventid = sdt.gxTv_SdtLocationEvent_Locationeventid ;
         }
         if ( sdt.IsDirty("LocationEventStartDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventstartdate = sdt.gxTv_SdtLocationEvent_Locationeventstartdate ;
         }
         if ( sdt.IsDirty("LocationEventEndDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventenddate = sdt.gxTv_SdtLocationEvent_Locationeventenddate ;
         }
         if ( sdt.IsDirty("LocationEventTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventtitle = sdt.gxTv_SdtLocationEvent_Locationeventtitle ;
         }
         if ( sdt.IsDirty("LocationEventDisplay") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventdisplay = sdt.gxTv_SdtLocationEvent_Locationeventdisplay ;
         }
         if ( sdt.IsDirty("LocationEventBackgroundColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventbackgroundcolor = sdt.gxTv_SdtLocationEvent_Locationeventbackgroundcolor ;
         }
         if ( sdt.IsDirty("LocationEventDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventdescription = sdt.gxTv_SdtLocationEvent_Locationeventdescription ;
         }
         if ( sdt.IsDirty("LocationEventBorderColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventbordercolor = sdt.gxTv_SdtLocationEvent_Locationeventbordercolor ;
         }
         if ( sdt.IsDirty("LocationEventTextColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventtextcolor = sdt.gxTv_SdtLocationEvent_Locationeventtextcolor ;
         }
         if ( sdt.IsDirty("LocationEventUrl") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventurl = sdt.gxTv_SdtLocationEvent_Locationeventurl ;
         }
         if ( sdt.IsDirty("LocationEventAllDay") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventallday = sdt.gxTv_SdtLocationEvent_Locationeventallday ;
         }
         if ( sdt.IsDirty("LocationEventRecurring") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventrecurring = sdt.gxTv_SdtLocationEvent_Locationeventrecurring ;
         }
         if ( sdt.IsDirty("LocationEventRecuringDays") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventrecuringdays = sdt.gxTv_SdtLocationEvent_Locationeventrecuringdays ;
         }
         if ( sdt.IsDirty("CustomerId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Customerid = sdt.gxTv_SdtLocationEvent_Customerid ;
         }
         if ( sdt.IsDirty("CustomerLocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Customerlocationid = sdt.gxTv_SdtLocationEvent_Customerlocationid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LocationEventId" )]
      [  XmlElement( ElementName = "LocationEventId"   )]
      public short gxTpr_Locationeventid
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtLocationEvent_Locationeventid != value )
            {
               gxTv_SdtLocationEvent_Mode = "INS";
               this.gxTv_SdtLocationEvent_Locationeventid_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventstartdate_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventenddate_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventtitle_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventdisplay_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventbordercolor_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventtextcolor_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventurl_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventallday_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Locationeventrecurring_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Customerid_Z_SetNull( );
               this.gxTv_SdtLocationEvent_Customerlocationid_Z_SetNull( );
            }
            gxTv_SdtLocationEvent_Locationeventid = value;
            SetDirty("Locationeventid");
         }

      }

      [  SoapElement( ElementName = "LocationEventStartDate" )]
      [  XmlElement( ElementName = "LocationEventStartDate"  , IsNullable=true )]
      public string gxTpr_Locationeventstartdate_Nullable
      {
         get {
            if ( gxTv_SdtLocationEvent_Locationeventstartdate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtLocationEvent_Locationeventstartdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtLocationEvent_Locationeventstartdate = DateTime.MinValue;
            else
               gxTv_SdtLocationEvent_Locationeventstartdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Locationeventstartdate
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventstartdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventstartdate = value;
            SetDirty("Locationeventstartdate");
         }

      }

      [  SoapElement( ElementName = "LocationEventEndDate" )]
      [  XmlElement( ElementName = "LocationEventEndDate"  , IsNullable=true )]
      public string gxTpr_Locationeventenddate_Nullable
      {
         get {
            if ( gxTv_SdtLocationEvent_Locationeventenddate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtLocationEvent_Locationeventenddate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtLocationEvent_Locationeventenddate = DateTime.MinValue;
            else
               gxTv_SdtLocationEvent_Locationeventenddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Locationeventenddate
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventenddate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventenddate = value;
            SetDirty("Locationeventenddate");
         }

      }

      [  SoapElement( ElementName = "LocationEventTitle" )]
      [  XmlElement( ElementName = "LocationEventTitle"   )]
      public string gxTpr_Locationeventtitle
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventtitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventtitle = value;
            SetDirty("Locationeventtitle");
         }

      }

      [  SoapElement( ElementName = "LocationEventDisplay" )]
      [  XmlElement( ElementName = "LocationEventDisplay"   )]
      public string gxTpr_Locationeventdisplay
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventdisplay ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventdisplay = value;
            SetDirty("Locationeventdisplay");
         }

      }

      [  SoapElement( ElementName = "LocationEventBackgroundColor" )]
      [  XmlElement( ElementName = "LocationEventBackgroundColor"   )]
      public string gxTpr_Locationeventbackgroundcolor
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventbackgroundcolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventbackgroundcolor = value;
            SetDirty("Locationeventbackgroundcolor");
         }

      }

      [  SoapElement( ElementName = "LocationEventDescription" )]
      [  XmlElement( ElementName = "LocationEventDescription"   )]
      public string gxTpr_Locationeventdescription
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventdescription = value;
            SetDirty("Locationeventdescription");
         }

      }

      [  SoapElement( ElementName = "LocationEventBorderColor" )]
      [  XmlElement( ElementName = "LocationEventBorderColor"   )]
      public string gxTpr_Locationeventbordercolor
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventbordercolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventbordercolor = value;
            SetDirty("Locationeventbordercolor");
         }

      }

      [  SoapElement( ElementName = "LocationEventTextColor" )]
      [  XmlElement( ElementName = "LocationEventTextColor"   )]
      public string gxTpr_Locationeventtextcolor
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventtextcolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventtextcolor = value;
            SetDirty("Locationeventtextcolor");
         }

      }

      [  SoapElement( ElementName = "LocationEventUrl" )]
      [  XmlElement( ElementName = "LocationEventUrl"   )]
      public string gxTpr_Locationeventurl
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventurl ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventurl = value;
            SetDirty("Locationeventurl");
         }

      }

      [  SoapElement( ElementName = "LocationEventAllDay" )]
      [  XmlElement( ElementName = "LocationEventAllDay"   )]
      public bool gxTpr_Locationeventallday
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventallday ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventallday = value;
            SetDirty("Locationeventallday");
         }

      }

      [  SoapElement( ElementName = "LocationEventRecurring" )]
      [  XmlElement( ElementName = "LocationEventRecurring"   )]
      public bool gxTpr_Locationeventrecurring
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventrecurring ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventrecurring = value;
            SetDirty("Locationeventrecurring");
         }

      }

      [  SoapElement( ElementName = "LocationEventRecuringDays" )]
      [  XmlElement( ElementName = "LocationEventRecuringDays"   )]
      public string gxTpr_Locationeventrecuringdays
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventrecuringdays ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventrecuringdays = value;
            SetDirty("Locationeventrecuringdays");
         }

      }

      [  SoapElement( ElementName = "CustomerId" )]
      [  XmlElement( ElementName = "CustomerId"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtLocationEvent_Customerid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationId" )]
      [  XmlElement( ElementName = "CustomerLocationId"   )]
      public short gxTpr_Customerlocationid
      {
         get {
            return gxTv_SdtLocationEvent_Customerlocationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Customerlocationid = value;
            SetDirty("Customerlocationid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLocationEvent_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLocationEvent_Mode_SetNull( )
      {
         gxTv_SdtLocationEvent_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLocationEvent_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLocationEvent_Initialized_SetNull( )
      {
         gxTv_SdtLocationEvent_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventId_Z" )]
      [  XmlElement( ElementName = "LocationEventId_Z"   )]
      public short gxTpr_Locationeventid_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventid_Z = value;
            SetDirty("Locationeventid_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventid_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventid_Z = 0;
         SetDirty("Locationeventid_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventStartDate_Z" )]
      [  XmlElement( ElementName = "LocationEventStartDate_Z"  , IsNullable=true )]
      public string gxTpr_Locationeventstartdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtLocationEvent_Locationeventstartdate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtLocationEvent_Locationeventstartdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtLocationEvent_Locationeventstartdate_Z = DateTime.MinValue;
            else
               gxTv_SdtLocationEvent_Locationeventstartdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Locationeventstartdate_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventstartdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventstartdate_Z = value;
            SetDirty("Locationeventstartdate_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventstartdate_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventstartdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Locationeventstartdate_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventstartdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventEndDate_Z" )]
      [  XmlElement( ElementName = "LocationEventEndDate_Z"  , IsNullable=true )]
      public string gxTpr_Locationeventenddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtLocationEvent_Locationeventenddate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtLocationEvent_Locationeventenddate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtLocationEvent_Locationeventenddate_Z = DateTime.MinValue;
            else
               gxTv_SdtLocationEvent_Locationeventenddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Locationeventenddate_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventenddate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventenddate_Z = value;
            SetDirty("Locationeventenddate_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventenddate_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventenddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Locationeventenddate_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventenddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventTitle_Z" )]
      [  XmlElement( ElementName = "LocationEventTitle_Z"   )]
      public string gxTpr_Locationeventtitle_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventtitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventtitle_Z = value;
            SetDirty("Locationeventtitle_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventtitle_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventtitle_Z = "";
         SetDirty("Locationeventtitle_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventtitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventDisplay_Z" )]
      [  XmlElement( ElementName = "LocationEventDisplay_Z"   )]
      public string gxTpr_Locationeventdisplay_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventdisplay_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventdisplay_Z = value;
            SetDirty("Locationeventdisplay_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventdisplay_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventdisplay_Z = "";
         SetDirty("Locationeventdisplay_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventdisplay_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventBackgroundColor_Z" )]
      [  XmlElement( ElementName = "LocationEventBackgroundColor_Z"   )]
      public string gxTpr_Locationeventbackgroundcolor_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z = value;
            SetDirty("Locationeventbackgroundcolor_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z = "";
         SetDirty("Locationeventbackgroundcolor_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventBorderColor_Z" )]
      [  XmlElement( ElementName = "LocationEventBorderColor_Z"   )]
      public string gxTpr_Locationeventbordercolor_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventbordercolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventbordercolor_Z = value;
            SetDirty("Locationeventbordercolor_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventbordercolor_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventbordercolor_Z = "";
         SetDirty("Locationeventbordercolor_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventbordercolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventTextColor_Z" )]
      [  XmlElement( ElementName = "LocationEventTextColor_Z"   )]
      public string gxTpr_Locationeventtextcolor_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventtextcolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventtextcolor_Z = value;
            SetDirty("Locationeventtextcolor_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventtextcolor_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventtextcolor_Z = "";
         SetDirty("Locationeventtextcolor_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventtextcolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventUrl_Z" )]
      [  XmlElement( ElementName = "LocationEventUrl_Z"   )]
      public string gxTpr_Locationeventurl_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventurl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventurl_Z = value;
            SetDirty("Locationeventurl_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventurl_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventurl_Z = "";
         SetDirty("Locationeventurl_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventurl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventAllDay_Z" )]
      [  XmlElement( ElementName = "LocationEventAllDay_Z"   )]
      public bool gxTpr_Locationeventallday_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventallday_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventallday_Z = value;
            SetDirty("Locationeventallday_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventallday_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventallday_Z = false;
         SetDirty("Locationeventallday_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventallday_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationEventRecurring_Z" )]
      [  XmlElement( ElementName = "LocationEventRecurring_Z"   )]
      public bool gxTpr_Locationeventrecurring_Z
      {
         get {
            return gxTv_SdtLocationEvent_Locationeventrecurring_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Locationeventrecurring_Z = value;
            SetDirty("Locationeventrecurring_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Locationeventrecurring_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Locationeventrecurring_Z = false;
         SetDirty("Locationeventrecurring_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Locationeventrecurring_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerId_Z" )]
      [  XmlElement( ElementName = "CustomerId_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtLocationEvent_Customerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Customerid_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationId_Z" )]
      [  XmlElement( ElementName = "CustomerLocationId_Z"   )]
      public short gxTpr_Customerlocationid_Z
      {
         get {
            return gxTv_SdtLocationEvent_Customerlocationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLocationEvent_Customerlocationid_Z = value;
            SetDirty("Customerlocationid_Z");
         }

      }

      public void gxTv_SdtLocationEvent_Customerlocationid_Z_SetNull( )
      {
         gxTv_SdtLocationEvent_Customerlocationid_Z = 0;
         SetDirty("Customerlocationid_Z");
         return  ;
      }

      public bool gxTv_SdtLocationEvent_Customerlocationid_Z_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtLocationEvent_Locationeventstartdate = (DateTime)(DateTime.MinValue);
         gxTv_SdtLocationEvent_Locationeventenddate = (DateTime)(DateTime.MinValue);
         gxTv_SdtLocationEvent_Locationeventtitle = "";
         gxTv_SdtLocationEvent_Locationeventdisplay = "";
         gxTv_SdtLocationEvent_Locationeventbackgroundcolor = "";
         gxTv_SdtLocationEvent_Locationeventdescription = "";
         gxTv_SdtLocationEvent_Locationeventbordercolor = "";
         gxTv_SdtLocationEvent_Locationeventtextcolor = "";
         gxTv_SdtLocationEvent_Locationeventurl = "";
         gxTv_SdtLocationEvent_Locationeventrecuringdays = "";
         gxTv_SdtLocationEvent_Mode = "";
         gxTv_SdtLocationEvent_Locationeventstartdate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtLocationEvent_Locationeventenddate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtLocationEvent_Locationeventtitle_Z = "";
         gxTv_SdtLocationEvent_Locationeventdisplay_Z = "";
         gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z = "";
         gxTv_SdtLocationEvent_Locationeventbordercolor_Z = "";
         gxTv_SdtLocationEvent_Locationeventtextcolor_Z = "";
         gxTv_SdtLocationEvent_Locationeventurl_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "locationevent", "GeneXus.Programs.locationevent_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtLocationEvent_Locationeventid ;
      private short sdtIsNull ;
      private short gxTv_SdtLocationEvent_Customerid ;
      private short gxTv_SdtLocationEvent_Customerlocationid ;
      private short gxTv_SdtLocationEvent_Initialized ;
      private short gxTv_SdtLocationEvent_Locationeventid_Z ;
      private short gxTv_SdtLocationEvent_Customerid_Z ;
      private short gxTv_SdtLocationEvent_Customerlocationid_Z ;
      private string gxTv_SdtLocationEvent_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtLocationEvent_Locationeventstartdate ;
      private DateTime gxTv_SdtLocationEvent_Locationeventenddate ;
      private DateTime gxTv_SdtLocationEvent_Locationeventstartdate_Z ;
      private DateTime gxTv_SdtLocationEvent_Locationeventenddate_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtLocationEvent_Locationeventallday ;
      private bool gxTv_SdtLocationEvent_Locationeventrecurring ;
      private bool gxTv_SdtLocationEvent_Locationeventallday_Z ;
      private bool gxTv_SdtLocationEvent_Locationeventrecurring_Z ;
      private string gxTv_SdtLocationEvent_Locationeventdescription ;
      private string gxTv_SdtLocationEvent_Locationeventrecuringdays ;
      private string gxTv_SdtLocationEvent_Locationeventtitle ;
      private string gxTv_SdtLocationEvent_Locationeventdisplay ;
      private string gxTv_SdtLocationEvent_Locationeventbackgroundcolor ;
      private string gxTv_SdtLocationEvent_Locationeventbordercolor ;
      private string gxTv_SdtLocationEvent_Locationeventtextcolor ;
      private string gxTv_SdtLocationEvent_Locationeventurl ;
      private string gxTv_SdtLocationEvent_Locationeventtitle_Z ;
      private string gxTv_SdtLocationEvent_Locationeventdisplay_Z ;
      private string gxTv_SdtLocationEvent_Locationeventbackgroundcolor_Z ;
      private string gxTv_SdtLocationEvent_Locationeventbordercolor_Z ;
      private string gxTv_SdtLocationEvent_Locationeventtextcolor_Z ;
      private string gxTv_SdtLocationEvent_Locationeventurl_Z ;
   }

   [DataContract(Name = @"LocationEvent", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtLocationEvent_RESTInterface : GxGenericCollectionItem<SdtLocationEvent>
   {
      public SdtLocationEvent_RESTInterface( ) : base()
      {
      }

      public SdtLocationEvent_RESTInterface( SdtLocationEvent psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LocationEventId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Locationeventid
      {
         get {
            return sdt.gxTpr_Locationeventid ;
         }

         set {
            sdt.gxTpr_Locationeventid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LocationEventStartDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Locationeventstartdate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Locationeventstartdate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Locationeventstartdate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "LocationEventEndDate" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Locationeventenddate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Locationeventenddate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Locationeventenddate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "LocationEventTitle" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Locationeventtitle
      {
         get {
            return sdt.gxTpr_Locationeventtitle ;
         }

         set {
            sdt.gxTpr_Locationeventtitle = value;
         }

      }

      [DataMember( Name = "LocationEventDisplay" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Locationeventdisplay
      {
         get {
            return sdt.gxTpr_Locationeventdisplay ;
         }

         set {
            sdt.gxTpr_Locationeventdisplay = value;
         }

      }

      [DataMember( Name = "LocationEventBackgroundColor" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Locationeventbackgroundcolor
      {
         get {
            return sdt.gxTpr_Locationeventbackgroundcolor ;
         }

         set {
            sdt.gxTpr_Locationeventbackgroundcolor = value;
         }

      }

      [DataMember( Name = "LocationEventDescription" , Order = 6 )]
      public string gxTpr_Locationeventdescription
      {
         get {
            return sdt.gxTpr_Locationeventdescription ;
         }

         set {
            sdt.gxTpr_Locationeventdescription = value;
         }

      }

      [DataMember( Name = "LocationEventBorderColor" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Locationeventbordercolor
      {
         get {
            return sdt.gxTpr_Locationeventbordercolor ;
         }

         set {
            sdt.gxTpr_Locationeventbordercolor = value;
         }

      }

      [DataMember( Name = "LocationEventTextColor" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Locationeventtextcolor
      {
         get {
            return sdt.gxTpr_Locationeventtextcolor ;
         }

         set {
            sdt.gxTpr_Locationeventtextcolor = value;
         }

      }

      [DataMember( Name = "LocationEventUrl" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Locationeventurl
      {
         get {
            return sdt.gxTpr_Locationeventurl ;
         }

         set {
            sdt.gxTpr_Locationeventurl = value;
         }

      }

      [DataMember( Name = "LocationEventAllDay" , Order = 10 )]
      [GxSeudo()]
      public bool gxTpr_Locationeventallday
      {
         get {
            return sdt.gxTpr_Locationeventallday ;
         }

         set {
            sdt.gxTpr_Locationeventallday = value;
         }

      }

      [DataMember( Name = "LocationEventRecurring" , Order = 11 )]
      [GxSeudo()]
      public bool gxTpr_Locationeventrecurring
      {
         get {
            return sdt.gxTpr_Locationeventrecurring ;
         }

         set {
            sdt.gxTpr_Locationeventrecurring = value;
         }

      }

      [DataMember( Name = "LocationEventRecuringDays" , Order = 12 )]
      public string gxTpr_Locationeventrecuringdays
      {
         get {
            return sdt.gxTpr_Locationeventrecuringdays ;
         }

         set {
            sdt.gxTpr_Locationeventrecuringdays = value;
         }

      }

      [DataMember( Name = "CustomerId" , Order = 13 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerid
      {
         get {
            return sdt.gxTpr_Customerid ;
         }

         set {
            sdt.gxTpr_Customerid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerLocationId" , Order = 14 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerlocationid
      {
         get {
            return sdt.gxTpr_Customerlocationid ;
         }

         set {
            sdt.gxTpr_Customerlocationid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtLocationEvent sdt
      {
         get {
            return (SdtLocationEvent)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtLocationEvent() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 15 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"LocationEvent", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtLocationEvent_RESTLInterface : GxGenericCollectionItem<SdtLocationEvent>
   {
      public SdtLocationEvent_RESTLInterface( ) : base()
      {
      }

      public SdtLocationEvent_RESTLInterface( SdtLocationEvent psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LocationEventStartDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Locationeventstartdate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Locationeventstartdate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Locationeventstartdate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtLocationEvent sdt
      {
         get {
            return (SdtLocationEvent)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtLocationEvent() ;
         }
      }

   }

}
