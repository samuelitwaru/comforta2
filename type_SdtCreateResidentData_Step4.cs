/*
				   File: type_SdtCreateResidentData_Step4
			Description: Step4
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
	[XmlRoot(ElementName="CreateResidentData.Step4")]
	[XmlType(TypeName="CreateResidentData.Step4" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateResidentData_Step4 : GxUserType
	{
		public SdtCreateResidentData_Step4( )
		{
			/* Constructor for serialization */
		}

		public SdtCreateResidentData_Step4(IGxContext context)
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
			AddObjectProperty("ProductServiceId", gxTpr_Productserviceid, false);

			if (gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts != null)
			{
				AddObjectProperty("ResidentProductServiceSDTs", gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProductServiceId")]
		[XmlElement(ElementName="ProductServiceId")]
		public short gxTpr_Productserviceid
		{
			get {
				return gxTv_SdtCreateResidentData_Step4_Productserviceid; 
			}
			set {
				gxTv_SdtCreateResidentData_Step4_Productserviceid = value;
				SetDirty("Productserviceid");
			}
		}




		[SoapElement(ElementName="ResidentProductServiceSDTs" )]
		[XmlArray(ElementName="ResidentProductServiceSDTs"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtResidentProductServiceSDT> gxTpr_Residentproductservicesdts_GXBaseCollection
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts == null )
				{
					gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts = new GXBaseCollection<GeneXus.Programs.SdtResidentProductServiceSDT>( context, "ResidentProductServiceSDT", "");
				}
				return gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts;
			}
			set {
				gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts_N = false;
				gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtResidentProductServiceSDT> gxTpr_Residentproductservicesdts
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts == null )
				{
					gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts = new GXBaseCollection<GeneXus.Programs.SdtResidentProductServiceSDT>( context, "ResidentProductServiceSDT", "");
				}
				gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts_N = false;
				return gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts ;
			}
			set {
				gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts_N = false;
				gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts = value;
				SetDirty("Residentproductservicesdts");
			}
		}

		public void gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts_SetNull()
		{
			gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts_N = true;
			gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts = null;
		}

		public bool gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts_IsNull()
		{
			return gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts == null;
		}
		public bool ShouldSerializegxTpr_Residentproductservicesdts_GXBaseCollection_Json()
		{
			return gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts != null && gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts.Count > 0;

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
			gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCreateResidentData_Step4_Productserviceid;
		 
		protected bool gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts_N;
		protected GXBaseCollection<GeneXus.Programs.SdtResidentProductServiceSDT> gxTv_SdtCreateResidentData_Step4_Residentproductservicesdts = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateResidentData.Step4", Namespace="Comforta2")]
	public class SdtCreateResidentData_Step4_RESTInterface : GxGenericCollectionItem<SdtCreateResidentData_Step4>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateResidentData_Step4_RESTInterface( ) : base()
		{	
		}

		public SdtCreateResidentData_Step4_RESTInterface( SdtCreateResidentData_Step4 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProductServiceId", Order=0)]
		public short gxTpr_Productserviceid
		{
			get { 
				return sdt.gxTpr_Productserviceid;

			}
			set { 
				sdt.gxTpr_Productserviceid = value;
			}
		}

		[DataMember(Name="ResidentProductServiceSDTs", Order=1, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtResidentProductServiceSDT_RESTInterface> gxTpr_Residentproductservicesdts
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Residentproductservicesdts_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtResidentProductServiceSDT_RESTInterface>(sdt.gxTpr_Residentproductservicesdts);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Residentproductservicesdts);
			}
		}


		#endregion

		public SdtCreateResidentData_Step4 sdt
		{
			get { 
				return (SdtCreateResidentData_Step4)Sdt;
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
				sdt = new SdtCreateResidentData_Step4() ;
			}
		}
	}
	#endregion
}