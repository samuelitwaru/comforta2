/*
				   File: type_SdtAddSuppliersData_Step2
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
	[XmlRoot(ElementName="AddSuppliersData.Step2")]
	[XmlType(TypeName="AddSuppliersData.Step2" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtAddSuppliersData_Step2 : GxUserType
	{
		public SdtAddSuppliersData_Step2( )
		{
			/* Constructor for serialization */
		}

		public SdtAddSuppliersData_Step2(IGxContext context)
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

			if (gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions != null)
			{
				AddObjectProperty("SupplierGenOptions", gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions, false);
			}
			if (gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts != null)
			{
				AddObjectProperty("LocationGenSuppliersSDTs", gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts, false);
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
				return gxTv_SdtAddSuppliersData_Step2_Locationoption; 
			}
			set {
				gxTv_SdtAddSuppliersData_Step2_Locationoption = value;
				SetDirty("Locationoption");
			}
		}




		[SoapElement(ElementName="SupplierGenOptions" )]
		[XmlArray(ElementName="SupplierGenOptions"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<short> gxTpr_Suppliergenoptions_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions == null )
				{
					gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions = new GxSimpleCollection<short>( );
				}
				return gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions;
			}
			set {
				gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions_N = false;
				gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<short> gxTpr_Suppliergenoptions
		{
			get {
				if ( gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions == null )
				{
					gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions = new GxSimpleCollection<short>();
				}
				gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions_N = false;
				return gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions ;
			}
			set {
				gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions_N = false;
				gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions = value;
				SetDirty("Suppliergenoptions");
			}
		}

		public void gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions_SetNull()
		{
			gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions_N = true;
			gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions = null;
		}

		public bool gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions_IsNull()
		{
			return gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions == null;
		}
		public bool ShouldSerializegxTpr_Suppliergenoptions_GxSimpleCollection_Json()
		{
			return gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions != null && gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions.Count > 0;

		}


		[SoapElement(ElementName="LocationGenSuppliersSDTs" )]
		[XmlArray(ElementName="LocationGenSuppliersSDTs"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtLocationGenSuppliersSDT> gxTpr_Locationgensupplierssdts_GXBaseCollection
		{
			get {
				if ( gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts == null )
				{
					gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts = new GXBaseCollection<GeneXus.Programs.SdtLocationGenSuppliersSDT>( context, "LocationGenSuppliersSDT", "");
				}
				return gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts;
			}
			set {
				gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts_N = false;
				gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtLocationGenSuppliersSDT> gxTpr_Locationgensupplierssdts
		{
			get {
				if ( gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts == null )
				{
					gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts = new GXBaseCollection<GeneXus.Programs.SdtLocationGenSuppliersSDT>( context, "LocationGenSuppliersSDT", "");
				}
				gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts_N = false;
				return gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts ;
			}
			set {
				gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts_N = false;
				gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts = value;
				SetDirty("Locationgensupplierssdts");
			}
		}

		public void gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts_SetNull()
		{
			gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts_N = true;
			gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts = null;
		}

		public bool gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts_IsNull()
		{
			return gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts == null;
		}
		public bool ShouldSerializegxTpr_Locationgensupplierssdts_GXBaseCollection_Json()
		{
			return gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts != null && gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts.Count > 0;

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
			gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions_N = true;


			gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtAddSuppliersData_Step2_Locationoption;
		 
		protected bool gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions_N;
		protected GxSimpleCollection<short> gxTv_SdtAddSuppliersData_Step2_Suppliergenoptions = null;  
		protected bool gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts_N;
		protected GXBaseCollection<GeneXus.Programs.SdtLocationGenSuppliersSDT> gxTv_SdtAddSuppliersData_Step2_Locationgensupplierssdts = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"AddSuppliersData.Step2", Namespace="Comforta2")]
	public class SdtAddSuppliersData_Step2_RESTInterface : GxGenericCollectionItem<SdtAddSuppliersData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtAddSuppliersData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtAddSuppliersData_Step2_RESTInterface( SdtAddSuppliersData_Step2 psdt ) : base(psdt)
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

		[DataMember(Name="SupplierGenOptions", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<short> gxTpr_Suppliergenoptions
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Suppliergenoptions_GxSimpleCollection_Json())
					return sdt.gxTpr_Suppliergenoptions;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Suppliergenoptions = value ;
			}
		}

		[DataMember(Name="LocationGenSuppliersSDTs", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtLocationGenSuppliersSDT_RESTInterface> gxTpr_Locationgensupplierssdts
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Locationgensupplierssdts_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtLocationGenSuppliersSDT_RESTInterface>(sdt.gxTpr_Locationgensupplierssdts);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Locationgensupplierssdts);
			}
		}


		#endregion

		public SdtAddSuppliersData_Step2 sdt
		{
			get { 
				return (SdtAddSuppliersData_Step2)Sdt;
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
				sdt = new SdtAddSuppliersData_Step2() ;
			}
		}
	}
	#endregion
}