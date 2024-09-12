/*
				   File: type_SdtResidentDetails_Customer_Location
			Description: Location
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
	[XmlRoot(ElementName="ResidentDetails.Customer.Location")]
	[XmlType(TypeName="ResidentDetails.Customer.Location" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtResidentDetails_Customer_Location : GxUserType
	{
		public SdtResidentDetails_Customer_Location( )
		{
			/* Constructor for serialization */
			gxTv_SdtResidentDetails_Customer_Location_Customerlocationvisitingaddress = "";

			gxTv_SdtResidentDetails_Customer_Location_Customerlocationpostaladdress = "";

			gxTv_SdtResidentDetails_Customer_Location_Customerlocationemail = "";

			gxTv_SdtResidentDetails_Customer_Location_Customerlocationphone = "";

			gxTv_SdtResidentDetails_Customer_Location_Customerlocationname = "";

			gxTv_SdtResidentDetails_Customer_Location_Customerlocationdescription = "";

		}

		public SdtResidentDetails_Customer_Location(IGxContext context)
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
			AddObjectProperty("CustomerLocationId", gxTpr_Customerlocationid, false);


			AddObjectProperty("CustomerLocationVisitingAddress", gxTpr_Customerlocationvisitingaddress, false);


			AddObjectProperty("CustomerLocationPostalAddress", gxTpr_Customerlocationpostaladdress, false);


			AddObjectProperty("CustomerLocationEmail", gxTpr_Customerlocationemail, false);


			AddObjectProperty("CustomerLocationPhone", gxTpr_Customerlocationphone, false);


			AddObjectProperty("CustomerLocationName", gxTpr_Customerlocationname, false);


			AddObjectProperty("CustomerLocationDescription", gxTpr_Customerlocationdescription, false);

			if (gxTpr_Amenities != null)
			{
				AddObjectProperty("Amenities", gxTpr_Amenities, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerLocationId")]
		[XmlElement(ElementName="CustomerLocationId")]
		public short gxTpr_Customerlocationid
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_Customerlocationid; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_Customerlocationid = value;
				SetDirty("Customerlocationid");
			}
		}




		[SoapElement(ElementName="CustomerLocationVisitingAddress")]
		[XmlElement(ElementName="CustomerLocationVisitingAddress")]
		public string gxTpr_Customerlocationvisitingaddress
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_Customerlocationvisitingaddress; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_Customerlocationvisitingaddress = value;
				SetDirty("Customerlocationvisitingaddress");
			}
		}




		[SoapElement(ElementName="CustomerLocationPostalAddress")]
		[XmlElement(ElementName="CustomerLocationPostalAddress")]
		public string gxTpr_Customerlocationpostaladdress
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_Customerlocationpostaladdress; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_Customerlocationpostaladdress = value;
				SetDirty("Customerlocationpostaladdress");
			}
		}




		[SoapElement(ElementName="CustomerLocationEmail")]
		[XmlElement(ElementName="CustomerLocationEmail")]
		public string gxTpr_Customerlocationemail
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_Customerlocationemail; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_Customerlocationemail = value;
				SetDirty("Customerlocationemail");
			}
		}




		[SoapElement(ElementName="CustomerLocationPhone")]
		[XmlElement(ElementName="CustomerLocationPhone")]
		public string gxTpr_Customerlocationphone
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_Customerlocationphone; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_Customerlocationphone = value;
				SetDirty("Customerlocationphone");
			}
		}




		[SoapElement(ElementName="CustomerLocationName")]
		[XmlElement(ElementName="CustomerLocationName")]
		public string gxTpr_Customerlocationname
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_Customerlocationname; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_Customerlocationname = value;
				SetDirty("Customerlocationname");
			}
		}




		[SoapElement(ElementName="CustomerLocationDescription")]
		[XmlElement(ElementName="CustomerLocationDescription")]
		public string gxTpr_Customerlocationdescription
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Location_Customerlocationdescription; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_Customerlocationdescription = value;
				SetDirty("Customerlocationdescription");
			}
		}




		[SoapElement(ElementName="Amenities" )]
		[XmlArray(ElementName="Amenities"  )]
		[XmlArrayItemAttribute(ElementName="AmenitiesItem" , IsNullable=false )]
		public GXBaseCollection<SdtResidentDetails_Customer_Location_AmenitiesItem> gxTpr_Amenities
		{
			get {
				if ( gxTv_SdtResidentDetails_Customer_Location_Amenities == null )
				{
					gxTv_SdtResidentDetails_Customer_Location_Amenities = new GXBaseCollection<SdtResidentDetails_Customer_Location_AmenitiesItem>( context, "ResidentDetails.Customer.Location.AmenitiesItem", "");
				}
				return gxTv_SdtResidentDetails_Customer_Location_Amenities;
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location_Amenities = value;
				SetDirty("Amenities");
			}
		}

		public void gxTv_SdtResidentDetails_Customer_Location_Amenities_SetNull()
		{
			gxTv_SdtResidentDetails_Customer_Location_Amenities = null;
		}

		public bool gxTv_SdtResidentDetails_Customer_Location_Amenities_IsNull()
		{
			return gxTv_SdtResidentDetails_Customer_Location_Amenities == null;
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
			gxTv_SdtResidentDetails_Customer_Location_Customerlocationvisitingaddress = "";
			gxTv_SdtResidentDetails_Customer_Location_Customerlocationpostaladdress = "";
			gxTv_SdtResidentDetails_Customer_Location_Customerlocationemail = "";
			gxTv_SdtResidentDetails_Customer_Location_Customerlocationphone = "";
			gxTv_SdtResidentDetails_Customer_Location_Customerlocationname = "";
			gxTv_SdtResidentDetails_Customer_Location_Customerlocationdescription = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtResidentDetails_Customer_Location_Customerlocationid;
		 

		protected string gxTv_SdtResidentDetails_Customer_Location_Customerlocationvisitingaddress;
		 

		protected string gxTv_SdtResidentDetails_Customer_Location_Customerlocationpostaladdress;
		 

		protected string gxTv_SdtResidentDetails_Customer_Location_Customerlocationemail;
		 

		protected string gxTv_SdtResidentDetails_Customer_Location_Customerlocationphone;
		 

		protected string gxTv_SdtResidentDetails_Customer_Location_Customerlocationname;
		 

		protected string gxTv_SdtResidentDetails_Customer_Location_Customerlocationdescription;
		 

		protected GXBaseCollection<SdtResidentDetails_Customer_Location_AmenitiesItem> gxTv_SdtResidentDetails_Customer_Location_Amenities = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ResidentDetails.Customer.Location", Namespace="Comforta2")]
	public class SdtResidentDetails_Customer_Location_RESTInterface : GxGenericCollectionItem<SdtResidentDetails_Customer_Location>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResidentDetails_Customer_Location_RESTInterface( ) : base()
		{	
		}

		public SdtResidentDetails_Customer_Location_RESTInterface( SdtResidentDetails_Customer_Location psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerLocationId", Order=0)]
		public short gxTpr_Customerlocationid
		{
			get { 
				return sdt.gxTpr_Customerlocationid;

			}
			set { 
				sdt.gxTpr_Customerlocationid = value;
			}
		}

		[DataMember(Name="CustomerLocationVisitingAddress", Order=1)]
		public  string gxTpr_Customerlocationvisitingaddress
		{
			get { 
				return sdt.gxTpr_Customerlocationvisitingaddress;

			}
			set { 
				 sdt.gxTpr_Customerlocationvisitingaddress = value;
			}
		}

		[DataMember(Name="CustomerLocationPostalAddress", Order=2)]
		public  string gxTpr_Customerlocationpostaladdress
		{
			get { 
				return sdt.gxTpr_Customerlocationpostaladdress;

			}
			set { 
				 sdt.gxTpr_Customerlocationpostaladdress = value;
			}
		}

		[DataMember(Name="CustomerLocationEmail", Order=3)]
		public  string gxTpr_Customerlocationemail
		{
			get { 
				return sdt.gxTpr_Customerlocationemail;

			}
			set { 
				 sdt.gxTpr_Customerlocationemail = value;
			}
		}

		[DataMember(Name="CustomerLocationPhone", Order=4)]
		public  string gxTpr_Customerlocationphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerlocationphone);

			}
			set { 
				 sdt.gxTpr_Customerlocationphone = value;
			}
		}

		[DataMember(Name="CustomerLocationName", Order=5)]
		public  string gxTpr_Customerlocationname
		{
			get { 
				return sdt.gxTpr_Customerlocationname;

			}
			set { 
				 sdt.gxTpr_Customerlocationname = value;
			}
		}

		[DataMember(Name="CustomerLocationDescription", Order=6)]
		public  string gxTpr_Customerlocationdescription
		{
			get { 
				return sdt.gxTpr_Customerlocationdescription;

			}
			set { 
				 sdt.gxTpr_Customerlocationdescription = value;
			}
		}

		[DataMember(Name="Amenities", Order=7)]
		public GxGenericCollection<SdtResidentDetails_Customer_Location_AmenitiesItem_RESTInterface> gxTpr_Amenities
		{
			get {
				return new GxGenericCollection<SdtResidentDetails_Customer_Location_AmenitiesItem_RESTInterface>(sdt.gxTpr_Amenities);

			}
			set {
				value.LoadCollection(sdt.gxTpr_Amenities);
			}
		}


		#endregion

		public SdtResidentDetails_Customer_Location sdt
		{
			get { 
				return (SdtResidentDetails_Customer_Location)Sdt;
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
				sdt = new SdtResidentDetails_Customer_Location() ;
			}
		}
	}
	#endregion
}