/*
				   File: type_SdtCreateResidentData
			Description: CreateResidentData
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
	[XmlRoot(ElementName="CreateResidentData")]
	[XmlType(TypeName="CreateResidentData" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateResidentData : GxUserType
	{
		public SdtCreateResidentData( )
		{
			/* Constructor for serialization */
		}

		public SdtCreateResidentData(IGxContext context)
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
			if (gxTv_SdtCreateResidentData_Step1 != null)
			{
				AddObjectProperty("Step1", gxTv_SdtCreateResidentData_Step1, false);
			}
			if (gxTv_SdtCreateResidentData_Step2 != null)
			{
				AddObjectProperty("Step2", gxTv_SdtCreateResidentData_Step2, false);
			}
			if (gxTv_SdtCreateResidentData_Step3 != null)
			{
				AddObjectProperty("Step3", gxTv_SdtCreateResidentData_Step3, false);
			}
			if (gxTv_SdtCreateResidentData_Step4 != null)
			{
				AddObjectProperty("Step4", gxTv_SdtCreateResidentData_Step4, false);
			}
			if (gxTv_SdtCreateResidentData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtCreateResidentData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Step1" )]
		[XmlElement(ElementName="Step1" )]
		public SdtCreateResidentData_Step1 gxTpr_Step1
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step1 == null )
				{
					gxTv_SdtCreateResidentData_Step1 = new SdtCreateResidentData_Step1(context);
				}
				gxTv_SdtCreateResidentData_Step1_N = false;
				return gxTv_SdtCreateResidentData_Step1;
			}
			set {
				gxTv_SdtCreateResidentData_Step1_N = false;
				gxTv_SdtCreateResidentData_Step1 = value;
				SetDirty("Step1");
			}

		}

		public void gxTv_SdtCreateResidentData_Step1_SetNull()
		{
			gxTv_SdtCreateResidentData_Step1_N = true;
			gxTv_SdtCreateResidentData_Step1 = null;
		}

		public bool gxTv_SdtCreateResidentData_Step1_IsNull()
		{
			return gxTv_SdtCreateResidentData_Step1 == null;
		}
		public bool ShouldSerializegxTpr_Step1_Json()
		{
				return (gxTv_SdtCreateResidentData_Step1 != null && gxTv_SdtCreateResidentData_Step1.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Step2" )]
		[XmlElement(ElementName="Step2" )]
		public SdtCreateResidentData_Step2 gxTpr_Step2
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step2 == null )
				{
					gxTv_SdtCreateResidentData_Step2 = new SdtCreateResidentData_Step2(context);
				}
				gxTv_SdtCreateResidentData_Step2_N = false;
				return gxTv_SdtCreateResidentData_Step2;
			}
			set {
				gxTv_SdtCreateResidentData_Step2_N = false;
				gxTv_SdtCreateResidentData_Step2 = value;
				SetDirty("Step2");
			}

		}

		public void gxTv_SdtCreateResidentData_Step2_SetNull()
		{
			gxTv_SdtCreateResidentData_Step2_N = true;
			gxTv_SdtCreateResidentData_Step2 = null;
		}

		public bool gxTv_SdtCreateResidentData_Step2_IsNull()
		{
			return gxTv_SdtCreateResidentData_Step2 == null;
		}
		public bool ShouldSerializegxTpr_Step2_Json()
		{
				return (gxTv_SdtCreateResidentData_Step2 != null && gxTv_SdtCreateResidentData_Step2.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Step3" )]
		[XmlElement(ElementName="Step3" )]
		public SdtCreateResidentData_Step3 gxTpr_Step3
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step3 == null )
				{
					gxTv_SdtCreateResidentData_Step3 = new SdtCreateResidentData_Step3(context);
				}
				gxTv_SdtCreateResidentData_Step3_N = false;
				return gxTv_SdtCreateResidentData_Step3;
			}
			set {
				gxTv_SdtCreateResidentData_Step3_N = false;
				gxTv_SdtCreateResidentData_Step3 = value;
				SetDirty("Step3");
			}

		}

		public void gxTv_SdtCreateResidentData_Step3_SetNull()
		{
			gxTv_SdtCreateResidentData_Step3_N = true;
			gxTv_SdtCreateResidentData_Step3 = null;
		}

		public bool gxTv_SdtCreateResidentData_Step3_IsNull()
		{
			return gxTv_SdtCreateResidentData_Step3 == null;
		}
		public bool ShouldSerializegxTpr_Step3_Json()
		{
				return (gxTv_SdtCreateResidentData_Step3 != null && gxTv_SdtCreateResidentData_Step3.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Step4" )]
		[XmlElement(ElementName="Step4" )]
		public SdtCreateResidentData_Step4 gxTpr_Step4
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step4 == null )
				{
					gxTv_SdtCreateResidentData_Step4 = new SdtCreateResidentData_Step4(context);
				}
				gxTv_SdtCreateResidentData_Step4_N = false;
				return gxTv_SdtCreateResidentData_Step4;
			}
			set {
				gxTv_SdtCreateResidentData_Step4_N = false;
				gxTv_SdtCreateResidentData_Step4 = value;
				SetDirty("Step4");
			}

		}

		public void gxTv_SdtCreateResidentData_Step4_SetNull()
		{
			gxTv_SdtCreateResidentData_Step4_N = true;
			gxTv_SdtCreateResidentData_Step4 = null;
		}

		public bool gxTv_SdtCreateResidentData_Step4_IsNull()
		{
			return gxTv_SdtCreateResidentData_Step4 == null;
		}
		public bool ShouldSerializegxTpr_Step4_Json()
		{
				return (gxTv_SdtCreateResidentData_Step4 != null && gxTv_SdtCreateResidentData_Step4.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtCreateResidentData_Auxiliardata == null )
				{
					gxTv_SdtCreateResidentData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtCreateResidentData_Auxiliardata;
			}
			set {
				gxTv_SdtCreateResidentData_Auxiliardata_N = false;
				gxTv_SdtCreateResidentData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtCreateResidentData_Auxiliardata == null )
				{
					gxTv_SdtCreateResidentData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtCreateResidentData_Auxiliardata_N = false;
				return gxTv_SdtCreateResidentData_Auxiliardata ;
			}
			set {
				gxTv_SdtCreateResidentData_Auxiliardata_N = false;
				gxTv_SdtCreateResidentData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtCreateResidentData_Auxiliardata_SetNull()
		{
			gxTv_SdtCreateResidentData_Auxiliardata_N = true;
			gxTv_SdtCreateResidentData_Auxiliardata = null;
		}

		public bool gxTv_SdtCreateResidentData_Auxiliardata_IsNull()
		{
			return gxTv_SdtCreateResidentData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtCreateResidentData_Auxiliardata != null && gxTv_SdtCreateResidentData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Step1_Json() ||
				ShouldSerializegxTpr_Step2_Json() ||
				ShouldSerializegxTpr_Step3_Json() ||
				ShouldSerializegxTpr_Step4_Json() ||
				 ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()||  
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
			gxTv_SdtCreateResidentData_Step1_N = true;


			gxTv_SdtCreateResidentData_Step2_N = true;


			gxTv_SdtCreateResidentData_Step3_N = true;


			gxTv_SdtCreateResidentData_Step4_N = true;


			gxTv_SdtCreateResidentData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtCreateResidentData_Step1_N;
		protected SdtCreateResidentData_Step1 gxTv_SdtCreateResidentData_Step1 = null; 

		protected bool gxTv_SdtCreateResidentData_Step2_N;
		protected SdtCreateResidentData_Step2 gxTv_SdtCreateResidentData_Step2 = null; 

		protected bool gxTv_SdtCreateResidentData_Step3_N;
		protected SdtCreateResidentData_Step3 gxTv_SdtCreateResidentData_Step3 = null; 

		protected bool gxTv_SdtCreateResidentData_Step4_N;
		protected SdtCreateResidentData_Step4 gxTv_SdtCreateResidentData_Step4 = null; 

		protected bool gxTv_SdtCreateResidentData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtCreateResidentData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateResidentData", Namespace="Comforta2")]
	public class SdtCreateResidentData_RESTInterface : GxGenericCollectionItem<SdtCreateResidentData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateResidentData_RESTInterface( ) : base()
		{	
		}

		public SdtCreateResidentData_RESTInterface( SdtCreateResidentData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Step1", Order=0, EmitDefaultValue=false)]
		public SdtCreateResidentData_Step1_RESTInterface gxTpr_Step1
		{
			get {
				if (sdt.ShouldSerializegxTpr_Step1_Json())
					return new SdtCreateResidentData_Step1_RESTInterface(sdt.gxTpr_Step1);
				else
					return null;

			}

			set {
				sdt.gxTpr_Step1 = value.sdt;
			}

		}

		[DataMember(Name="Step2", Order=1, EmitDefaultValue=false)]
		public SdtCreateResidentData_Step2_RESTInterface gxTpr_Step2
		{
			get {
				if (sdt.ShouldSerializegxTpr_Step2_Json())
					return new SdtCreateResidentData_Step2_RESTInterface(sdt.gxTpr_Step2);
				else
					return null;

			}

			set {
				sdt.gxTpr_Step2 = value.sdt;
			}

		}

		[DataMember(Name="Step3", Order=2, EmitDefaultValue=false)]
		public SdtCreateResidentData_Step3_RESTInterface gxTpr_Step3
		{
			get {
				if (sdt.ShouldSerializegxTpr_Step3_Json())
					return new SdtCreateResidentData_Step3_RESTInterface(sdt.gxTpr_Step3);
				else
					return null;

			}

			set {
				sdt.gxTpr_Step3 = value.sdt;
			}

		}

		[DataMember(Name="Step4", Order=3, EmitDefaultValue=false)]
		public SdtCreateResidentData_Step4_RESTInterface gxTpr_Step4
		{
			get {
				if (sdt.ShouldSerializegxTpr_Step4_Json())
					return new SdtCreateResidentData_Step4_RESTInterface(sdt.gxTpr_Step4);
				else
					return null;

			}

			set {
				sdt.gxTpr_Step4 = value.sdt;
			}

		}

		[DataMember(Name="AuxiliarData", Order=4, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface> gxTpr_Auxiliardata
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface>(sdt.gxTpr_Auxiliardata);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Auxiliardata);
			}
		}


		#endregion

		public SdtCreateResidentData sdt
		{
			get { 
				return (SdtCreateResidentData)Sdt;
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
				sdt = new SdtCreateResidentData() ;
			}
		}
	}
	#endregion
}