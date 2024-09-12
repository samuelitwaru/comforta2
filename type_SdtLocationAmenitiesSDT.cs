/*
				   File: type_SdtLocationAmenitiesSDT
			Description: LocationAmenitiesSDT
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
	[XmlRoot(ElementName="LocationAmenitiesSDT")]
	[XmlType(TypeName="LocationAmenitiesSDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtLocationAmenitiesSDT : GxUserType
	{
		public SdtLocationAmenitiesSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationAmenitiesSDT_Amenitiesname = "";

			gxTv_SdtLocationAmenitiesSDT_Amenitiestypename = "";

		}

		public SdtLocationAmenitiesSDT(IGxContext context)
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
			AddObjectProperty("AmenitiesId", gxTpr_Amenitiesid, false);


			AddObjectProperty("AmenitiesName", gxTpr_Amenitiesname, false);


			AddObjectProperty("AmenitiesTypeId", gxTpr_Amenitiestypeid, false);


			AddObjectProperty("AmenitiesTypeName", gxTpr_Amenitiestypename, false);


			AddObjectProperty("Selected", gxTpr_Selected, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AmenitiesId")]
		[XmlElement(ElementName="AmenitiesId")]
		public short gxTpr_Amenitiesid
		{
			get {
				return gxTv_SdtLocationAmenitiesSDT_Amenitiesid; 
			}
			set {
				gxTv_SdtLocationAmenitiesSDT_Amenitiesid = value;
				SetDirty("Amenitiesid");
			}
		}




		[SoapElement(ElementName="AmenitiesName")]
		[XmlElement(ElementName="AmenitiesName")]
		public string gxTpr_Amenitiesname
		{
			get {
				return gxTv_SdtLocationAmenitiesSDT_Amenitiesname; 
			}
			set {
				gxTv_SdtLocationAmenitiesSDT_Amenitiesname = value;
				SetDirty("Amenitiesname");
			}
		}




		[SoapElement(ElementName="AmenitiesTypeId")]
		[XmlElement(ElementName="AmenitiesTypeId")]
		public short gxTpr_Amenitiestypeid
		{
			get {
				return gxTv_SdtLocationAmenitiesSDT_Amenitiestypeid; 
			}
			set {
				gxTv_SdtLocationAmenitiesSDT_Amenitiestypeid = value;
				SetDirty("Amenitiestypeid");
			}
		}




		[SoapElement(ElementName="AmenitiesTypeName")]
		[XmlElement(ElementName="AmenitiesTypeName")]
		public string gxTpr_Amenitiestypename
		{
			get {
				return gxTv_SdtLocationAmenitiesSDT_Amenitiestypename; 
			}
			set {
				gxTv_SdtLocationAmenitiesSDT_Amenitiestypename = value;
				SetDirty("Amenitiestypename");
			}
		}




		[SoapElement(ElementName="Selected")]
		[XmlElement(ElementName="Selected")]
		public bool gxTpr_Selected
		{
			get {
				return gxTv_SdtLocationAmenitiesSDT_Selected; 
			}
			set {
				gxTv_SdtLocationAmenitiesSDT_Selected = value;
				SetDirty("Selected");
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
			gxTv_SdtLocationAmenitiesSDT_Amenitiesname = "";

			gxTv_SdtLocationAmenitiesSDT_Amenitiestypename = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtLocationAmenitiesSDT_Amenitiesid;
		 

		protected string gxTv_SdtLocationAmenitiesSDT_Amenitiesname;
		 

		protected short gxTv_SdtLocationAmenitiesSDT_Amenitiestypeid;
		 

		protected string gxTv_SdtLocationAmenitiesSDT_Amenitiestypename;
		 

		protected bool gxTv_SdtLocationAmenitiesSDT_Selected;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"LocationAmenitiesSDT", Namespace="Comforta2")]
	public class SdtLocationAmenitiesSDT_RESTInterface : GxGenericCollectionItem<SdtLocationAmenitiesSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationAmenitiesSDT_RESTInterface( ) : base()
		{	
		}

		public SdtLocationAmenitiesSDT_RESTInterface( SdtLocationAmenitiesSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AmenitiesId", Order=0)]
		public short gxTpr_Amenitiesid
		{
			get { 
				return sdt.gxTpr_Amenitiesid;

			}
			set { 
				sdt.gxTpr_Amenitiesid = value;
			}
		}

		[DataMember(Name="AmenitiesName", Order=1)]
		public  string gxTpr_Amenitiesname
		{
			get { 
				return sdt.gxTpr_Amenitiesname;

			}
			set { 
				 sdt.gxTpr_Amenitiesname = value;
			}
		}

		[DataMember(Name="AmenitiesTypeId", Order=2)]
		public short gxTpr_Amenitiestypeid
		{
			get { 
				return sdt.gxTpr_Amenitiestypeid;

			}
			set { 
				sdt.gxTpr_Amenitiestypeid = value;
			}
		}

		[DataMember(Name="AmenitiesTypeName", Order=3)]
		public  string gxTpr_Amenitiestypename
		{
			get { 
				return sdt.gxTpr_Amenitiestypename;

			}
			set { 
				 sdt.gxTpr_Amenitiestypename = value;
			}
		}

		[DataMember(Name="Selected", Order=4)]
		public bool gxTpr_Selected
		{
			get { 
				return sdt.gxTpr_Selected;

			}
			set { 
				sdt.gxTpr_Selected = value;
			}
		}


		#endregion

		public SdtLocationAmenitiesSDT sdt
		{
			get { 
				return (SdtLocationAmenitiesSDT)Sdt;
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
				sdt = new SdtLocationAmenitiesSDT() ;
			}
		}
	}
	#endregion
}