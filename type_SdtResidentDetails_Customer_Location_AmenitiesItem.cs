/*
				   File: type_SdtResidentDetails_Customer_Location_AmenitiesItem
			Description: Amenities
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="ResidentDetails.Customer.Location.AmenitiesItem")]
	[XmlType(TypeName="ResidentDetails.Customer.Location.AmenitiesItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtResidentDetails_Customer_Location_AmenitiesItem : GxUserType
	{
		public SdtResidentDetails_Customer_Location_AmenitiesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityid = "";

			gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityname = "";

		}

		public SdtResidentDetails_Customer_Location_AmenitiesItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("AmenityId", gxTpr_Amenityid, false);


			AddObjectProperty("AmenityName", gxTpr_Amenityname, false);


			AddObjectProperty("IsAvailable", gxTpr_Isavailable, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AmenityId")]
		[XmlElement(ElementName="AmenityId")]
		public string gxTpr_Amenityid
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityid; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityid = value;
				SetDirty("Amenityid");
			}
		}




		[SoapElement(ElementName="AmenityName")]
		[XmlElement(ElementName="AmenityName")]
		public string gxTpr_Amenityname
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityname; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityname = value;
				SetDirty("Amenityname");
			}
		}




		[SoapElement(ElementName="IsAvailable")]
		[XmlElement(ElementName="IsAvailable")]
		public bool gxTpr_Isavailable
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Isavailable; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Isavailable = value;
				SetDirty("Isavailable");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityid = "";
			gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityname = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityid;
		 

		protected string gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Amenityname;
		 

		protected bool gxTv_SdtResidentDetails_Customer_Location_AmenitiesItem_Isavailable;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"ResidentDetails.Customer.Location.AmenitiesItem", Namespace="Comforta2")]
	public class SdtResidentDetails_Customer_Location_AmenitiesItem_RESTInterface : GxGenericCollectionItem<SdtResidentDetails_Customer_Location_AmenitiesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResidentDetails_Customer_Location_AmenitiesItem_RESTInterface( ) : base()
		{	
		}

		public SdtResidentDetails_Customer_Location_AmenitiesItem_RESTInterface( SdtResidentDetails_Customer_Location_AmenitiesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AmenityId", Order=0)]
		public  string gxTpr_Amenityid
		{
			get { 
				return sdt.gxTpr_Amenityid;

			}
			set { 
				 sdt.gxTpr_Amenityid = value;
			}
		}

		[DataMember(Name="AmenityName", Order=1)]
		public  string gxTpr_Amenityname
		{
			get { 
				return sdt.gxTpr_Amenityname;

			}
			set { 
				 sdt.gxTpr_Amenityname = value;
			}
		}

		[DataMember(Name="IsAvailable", Order=2)]
		public bool gxTpr_Isavailable
		{
			get { 
				return sdt.gxTpr_Isavailable;

			}
			set { 
				sdt.gxTpr_Isavailable = value;
			}
		}


		#endregion

		public SdtResidentDetails_Customer_Location_AmenitiesItem sdt
		{
			get { 
				return (SdtResidentDetails_Customer_Location_AmenitiesItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtResidentDetails_Customer_Location_AmenitiesItem() ;
			}
		}
	}
	#endregion
}