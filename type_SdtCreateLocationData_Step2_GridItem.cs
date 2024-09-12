/*
				   File: type_SdtCreateLocationData_Step2_GridItem
			Description: Grid
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
	[XmlRoot(ElementName="CreateLocationData.Step2.GridItem")]
	[XmlType(TypeName="CreateLocationData.Step2.GridItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateLocationData_Step2_GridItem : GxUserType
	{
		public SdtCreateLocationData_Step2_GridItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateLocationData_Step2_GridItem_Amenitiesname = "";

		}

		public SdtCreateLocationData_Step2_GridItem(IGxContext context)
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

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AmenitiesId")]
		[XmlElement(ElementName="AmenitiesId")]
		public short gxTpr_Amenitiesid
		{
			get {
				return gxTv_SdtCreateLocationData_Step2_GridItem_Amenitiesid; 
			}
			set {
				gxTv_SdtCreateLocationData_Step2_GridItem_Amenitiesid = value;
				SetDirty("Amenitiesid");
			}
		}




		[SoapElement(ElementName="AmenitiesName")]
		[XmlElement(ElementName="AmenitiesName")]
		public string gxTpr_Amenitiesname
		{
			get {
				return gxTv_SdtCreateLocationData_Step2_GridItem_Amenitiesname; 
			}
			set {
				gxTv_SdtCreateLocationData_Step2_GridItem_Amenitiesname = value;
				SetDirty("Amenitiesname");
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
			gxTv_SdtCreateLocationData_Step2_GridItem_Amenitiesname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCreateLocationData_Step2_GridItem_Amenitiesid;
		 

		protected string gxTv_SdtCreateLocationData_Step2_GridItem_Amenitiesname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"CreateLocationData.Step2.GridItem", Namespace="Comforta2")]
	public class SdtCreateLocationData_Step2_GridItem_RESTInterface : GxGenericCollectionItem<SdtCreateLocationData_Step2_GridItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateLocationData_Step2_GridItem_RESTInterface( ) : base()
		{	
		}

		public SdtCreateLocationData_Step2_GridItem_RESTInterface( SdtCreateLocationData_Step2_GridItem psdt ) : base(psdt)
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


		#endregion

		public SdtCreateLocationData_Step2_GridItem sdt
		{
			get { 
				return (SdtCreateLocationData_Step2_GridItem)Sdt;
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
				sdt = new SdtCreateLocationData_Step2_GridItem() ;
			}
		}
	}
	#endregion
}