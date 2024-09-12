/*
				   File: type_SdtAddSuppliersData_Step1
			Description: Step1
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
	[XmlRoot(ElementName="AddSuppliersData.Step1")]
	[XmlType(TypeName="AddSuppliersData.Step1" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtAddSuppliersData_Step1 : GxUserType
	{
		public SdtAddSuppliersData_Step1( )
		{
			/* Constructor for serialization */
		}

		public SdtAddSuppliersData_Step1(IGxContext context)
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
			AddObjectProperty("LocationOption", gxTpr_Locationoption, false);

			if (gxTv_SdtAddSuppliersData_Step1_Supplieragboptions != null)
			{
				AddObjectProperty("SupplierAGBOptions", gxTv_SdtAddSuppliersData_Step1_Supplieragboptions, false);
			}
			if (gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts != null)
			{
				AddObjectProperty("LocationAGBSuppliersSDTs", gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LocationOption")]
		[XmlElement(ElementName="LocationOption")]
		public short gxTpr_Locationoption
		{
			get {
				return gxTv_SdtAddSuppliersData_Step1_Locationoption; 
			}
			set {
				gxTv_SdtAddSuppliersData_Step1_Locationoption = value;
				SetDirty("Locationoption");
			}
		}




		[SoapElement(ElementName="SupplierAGBOptions" )]
		[XmlArray(ElementName="SupplierAGBOptions"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<short> gxTpr_Supplieragboptions_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtAddSuppliersData_Step1_Supplieragboptions == null )
				{
					gxTv_SdtAddSuppliersData_Step1_Supplieragboptions = new GxSimpleCollection<short>( );
				}
				return gxTv_SdtAddSuppliersData_Step1_Supplieragboptions;
			}
			set {
				gxTv_SdtAddSuppliersData_Step1_Supplieragboptions_N = false;
				gxTv_SdtAddSuppliersData_Step1_Supplieragboptions = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<short> gxTpr_Supplieragboptions
		{
			get {
				if ( gxTv_SdtAddSuppliersData_Step1_Supplieragboptions == null )
				{
					gxTv_SdtAddSuppliersData_Step1_Supplieragboptions = new GxSimpleCollection<short>();
				}
				gxTv_SdtAddSuppliersData_Step1_Supplieragboptions_N = false;
				return gxTv_SdtAddSuppliersData_Step1_Supplieragboptions ;
			}
			set {
				gxTv_SdtAddSuppliersData_Step1_Supplieragboptions_N = false;
				gxTv_SdtAddSuppliersData_Step1_Supplieragboptions = value;
				SetDirty("Supplieragboptions");
			}
		}

		public void gxTv_SdtAddSuppliersData_Step1_Supplieragboptions_SetNull()
		{
			gxTv_SdtAddSuppliersData_Step1_Supplieragboptions_N = true;
			gxTv_SdtAddSuppliersData_Step1_Supplieragboptions = null;
		}

		public bool gxTv_SdtAddSuppliersData_Step1_Supplieragboptions_IsNull()
		{
			return gxTv_SdtAddSuppliersData_Step1_Supplieragboptions == null;
		}
		public bool ShouldSerializegxTpr_Supplieragboptions_GxSimpleCollection_Json()
		{
			return gxTv_SdtAddSuppliersData_Step1_Supplieragboptions != null && gxTv_SdtAddSuppliersData_Step1_Supplieragboptions.Count > 0;

		}


		[SoapElement(ElementName="LocationAGBSuppliersSDTs" )]
		[XmlArray(ElementName="LocationAGBSuppliersSDTs"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtLocationAGBSuppliersSDT> gxTpr_Locationagbsupplierssdts_GXBaseCollection
		{
			get {
				if ( gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts == null )
				{
					gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts = new GXBaseCollection<GeneXus.Programs.SdtLocationAGBSuppliersSDT>( context, "LocationAGBSuppliersSDT", "");
				}
				return gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts;
			}
			set {
				gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts_N = false;
				gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtLocationAGBSuppliersSDT> gxTpr_Locationagbsupplierssdts
		{
			get {
				if ( gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts == null )
				{
					gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts = new GXBaseCollection<GeneXus.Programs.SdtLocationAGBSuppliersSDT>( context, "LocationAGBSuppliersSDT", "");
				}
				gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts_N = false;
				return gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts ;
			}
			set {
				gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts_N = false;
				gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts = value;
				SetDirty("Locationagbsupplierssdts");
			}
		}

		public void gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts_SetNull()
		{
			gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts_N = true;
			gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts = null;
		}

		public bool gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts_IsNull()
		{
			return gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts == null;
		}
		public bool ShouldSerializegxTpr_Locationagbsupplierssdts_GXBaseCollection_Json()
		{
			return gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts != null && gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts.Count > 0;

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
			gxTv_SdtAddSuppliersData_Step1_Supplieragboptions_N = true;


			gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtAddSuppliersData_Step1_Locationoption;
		 
		protected bool gxTv_SdtAddSuppliersData_Step1_Supplieragboptions_N;
		protected GxSimpleCollection<short> gxTv_SdtAddSuppliersData_Step1_Supplieragboptions = null;  
		protected bool gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts_N;
		protected GXBaseCollection<GeneXus.Programs.SdtLocationAGBSuppliersSDT> gxTv_SdtAddSuppliersData_Step1_Locationagbsupplierssdts = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"AddSuppliersData.Step1", Namespace="Comforta2")]
	public class SdtAddSuppliersData_Step1_RESTInterface : GxGenericCollectionItem<SdtAddSuppliersData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtAddSuppliersData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtAddSuppliersData_Step1_RESTInterface( SdtAddSuppliersData_Step1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LocationOption", Order=0)]
		public short gxTpr_Locationoption
		{
			get { 
				return sdt.gxTpr_Locationoption;

			}
			set { 
				sdt.gxTpr_Locationoption = value;
			}
		}

		[DataMember(Name="SupplierAGBOptions", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<short> gxTpr_Supplieragboptions
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Supplieragboptions_GxSimpleCollection_Json())
					return sdt.gxTpr_Supplieragboptions;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Supplieragboptions = value ;
			}
		}

		[DataMember(Name="LocationAGBSuppliersSDTs", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtLocationAGBSuppliersSDT_RESTInterface> gxTpr_Locationagbsupplierssdts
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Locationagbsupplierssdts_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtLocationAGBSuppliersSDT_RESTInterface>(sdt.gxTpr_Locationagbsupplierssdts);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Locationagbsupplierssdts);
			}
		}


		#endregion

		public SdtAddSuppliersData_Step1 sdt
		{
			get { 
				return (SdtAddSuppliersData_Step1)Sdt;
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
				sdt = new SdtAddSuppliersData_Step1() ;
			}
		}
	}
	#endregion
}