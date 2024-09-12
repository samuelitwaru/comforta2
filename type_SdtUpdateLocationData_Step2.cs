/*
				   File: type_SdtUpdateLocationData_Step2
			Description: Step2
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
	[XmlRoot(ElementName="UpdateLocationData.Step2")]
	[XmlType(TypeName="UpdateLocationData.Step2" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtUpdateLocationData_Step2 : GxUserType
	{
		public SdtUpdateLocationData_Step2( )
		{
			/* Constructor for serialization */
		}

		public SdtUpdateLocationData_Step2(IGxContext context)
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
			if (gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts != null)
			{
				AddObjectProperty("LocationAmenitiesSDTs", gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LocationAmenitiesSDTs" )]
		[XmlArray(ElementName="LocationAmenitiesSDTs"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtLocationAmenitiesSDT> gxTpr_Locationamenitiessdts_GXBaseCollection
		{
			get {
				if ( gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts == null )
				{
					gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts = new GXBaseCollection<GeneXus.Programs.SdtLocationAmenitiesSDT>( context, "LocationAmenitiesSDT", "");
				}
				return gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts;
			}
			set {
				gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts_N = false;
				gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtLocationAmenitiesSDT> gxTpr_Locationamenitiessdts
		{
			get {
				if ( gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts == null )
				{
					gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts = new GXBaseCollection<GeneXus.Programs.SdtLocationAmenitiesSDT>( context, "LocationAmenitiesSDT", "");
				}
				gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts_N = false;
				return gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts ;
			}
			set {
				gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts_N = false;
				gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts = value;
				SetDirty("Locationamenitiessdts");
			}
		}

		public void gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts_SetNull()
		{
			gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts_N = true;
			gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts = null;
		}

		public bool gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts_IsNull()
		{
			return gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts == null;
		}
		public bool ShouldSerializegxTpr_Locationamenitiessdts_GXBaseCollection_Json()
		{
			return gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts != null && gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Locationamenitiessdts_GXBaseCollection_Json()||  
				false);
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
			gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts_N;
		protected GXBaseCollection<GeneXus.Programs.SdtLocationAmenitiesSDT> gxTv_SdtUpdateLocationData_Step2_Locationamenitiessdts = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"UpdateLocationData.Step2", Namespace="Comforta2")]
	public class SdtUpdateLocationData_Step2_RESTInterface : GxGenericCollectionItem<SdtUpdateLocationData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtUpdateLocationData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtUpdateLocationData_Step2_RESTInterface( SdtUpdateLocationData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LocationAmenitiesSDTs", Order=0, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtLocationAmenitiesSDT_RESTInterface> gxTpr_Locationamenitiessdts
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Locationamenitiessdts_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtLocationAmenitiesSDT_RESTInterface>(sdt.gxTpr_Locationamenitiessdts);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Locationamenitiessdts);
			}
		}


		#endregion

		public SdtUpdateLocationData_Step2 sdt
		{
			get { 
				return (SdtUpdateLocationData_Step2)Sdt;
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
				sdt = new SdtUpdateLocationData_Step2() ;
			}
		}
	}
	#endregion
}