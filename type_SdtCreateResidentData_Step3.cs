/*
				   File: type_SdtCreateResidentData_Step3
			Description: Step3
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
	[XmlRoot(ElementName="CreateResidentData.Step3")]
	[XmlType(TypeName="CreateResidentData.Step3" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateResidentData_Step3 : GxUserType
	{
		public SdtCreateResidentData_Step3( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateResidentData_Step3_Residentincompanyname = "";

			gxTv_SdtCreateResidentData_Step3_Residentincompanykvknumber = "";

			gxTv_SdtCreateResidentData_Step3_Residentincompanyemail = "";

			gxTv_SdtCreateResidentData_Step3_Residentincompanyphone = "";

		}

		public SdtCreateResidentData_Step3(IGxContext context)
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
			AddObjectProperty("ResidentINCompanyId", gxTpr_Residentincompanyid, false);


			AddObjectProperty("ResidentINCompanyName", gxTpr_Residentincompanyname, false);


			AddObjectProperty("ResidentINCompanyKvkNumber", gxTpr_Residentincompanykvknumber, false);


			AddObjectProperty("ResidentINCompanyEmail", gxTpr_Residentincompanyemail, false);


			AddObjectProperty("ResidentINCompanyPhone", gxTpr_Residentincompanyphone, false);

			if (gxTv_SdtCreateResidentData_Step3_Residentincompanysdts != null)
			{
				AddObjectProperty("ResidentINCompanySDTs", gxTv_SdtCreateResidentData_Step3_Residentincompanysdts, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentINCompanyId")]
		[XmlElement(ElementName="ResidentINCompanyId")]
		public short gxTpr_Residentincompanyid
		{
			get {
				return gxTv_SdtCreateResidentData_Step3_Residentincompanyid; 
			}
			set {
				gxTv_SdtCreateResidentData_Step3_Residentincompanyid = value;
				SetDirty("Residentincompanyid");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyName")]
		[XmlElement(ElementName="ResidentINCompanyName")]
		public string gxTpr_Residentincompanyname
		{
			get {
				return gxTv_SdtCreateResidentData_Step3_Residentincompanyname; 
			}
			set {
				gxTv_SdtCreateResidentData_Step3_Residentincompanyname = value;
				SetDirty("Residentincompanyname");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyKvkNumber")]
		[XmlElement(ElementName="ResidentINCompanyKvkNumber")]
		public string gxTpr_Residentincompanykvknumber
		{
			get {
				return gxTv_SdtCreateResidentData_Step3_Residentincompanykvknumber; 
			}
			set {
				gxTv_SdtCreateResidentData_Step3_Residentincompanykvknumber = value;
				SetDirty("Residentincompanykvknumber");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyEmail")]
		[XmlElement(ElementName="ResidentINCompanyEmail")]
		public string gxTpr_Residentincompanyemail
		{
			get {
				return gxTv_SdtCreateResidentData_Step3_Residentincompanyemail; 
			}
			set {
				gxTv_SdtCreateResidentData_Step3_Residentincompanyemail = value;
				SetDirty("Residentincompanyemail");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyPhone")]
		[XmlElement(ElementName="ResidentINCompanyPhone")]
		public string gxTpr_Residentincompanyphone
		{
			get {
				return gxTv_SdtCreateResidentData_Step3_Residentincompanyphone; 
			}
			set {
				gxTv_SdtCreateResidentData_Step3_Residentincompanyphone = value;
				SetDirty("Residentincompanyphone");
			}
		}




		[SoapElement(ElementName="ResidentINCompanySDTs" )]
		[XmlArray(ElementName="ResidentINCompanySDTs"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtResidentINCompanySDT> gxTpr_Residentincompanysdts_GXBaseCollection
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step3_Residentincompanysdts == null )
				{
					gxTv_SdtCreateResidentData_Step3_Residentincompanysdts = new GXBaseCollection<GeneXus.Programs.SdtResidentINCompanySDT>( context, "ResidentINCompanySDT", "");
				}
				return gxTv_SdtCreateResidentData_Step3_Residentincompanysdts;
			}
			set {
				gxTv_SdtCreateResidentData_Step3_Residentincompanysdts_N = false;
				gxTv_SdtCreateResidentData_Step3_Residentincompanysdts = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtResidentINCompanySDT> gxTpr_Residentincompanysdts
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step3_Residentincompanysdts == null )
				{
					gxTv_SdtCreateResidentData_Step3_Residentincompanysdts = new GXBaseCollection<GeneXus.Programs.SdtResidentINCompanySDT>( context, "ResidentINCompanySDT", "");
				}
				gxTv_SdtCreateResidentData_Step3_Residentincompanysdts_N = false;
				return gxTv_SdtCreateResidentData_Step3_Residentincompanysdts ;
			}
			set {
				gxTv_SdtCreateResidentData_Step3_Residentincompanysdts_N = false;
				gxTv_SdtCreateResidentData_Step3_Residentincompanysdts = value;
				SetDirty("Residentincompanysdts");
			}
		}

		public void gxTv_SdtCreateResidentData_Step3_Residentincompanysdts_SetNull()
		{
			gxTv_SdtCreateResidentData_Step3_Residentincompanysdts_N = true;
			gxTv_SdtCreateResidentData_Step3_Residentincompanysdts = null;
		}

		public bool gxTv_SdtCreateResidentData_Step3_Residentincompanysdts_IsNull()
		{
			return gxTv_SdtCreateResidentData_Step3_Residentincompanysdts == null;
		}
		public bool ShouldSerializegxTpr_Residentincompanysdts_GXBaseCollection_Json()
		{
			return gxTv_SdtCreateResidentData_Step3_Residentincompanysdts != null && gxTv_SdtCreateResidentData_Step3_Residentincompanysdts.Count > 0;

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
			gxTv_SdtCreateResidentData_Step3_Residentincompanyname = "";
			gxTv_SdtCreateResidentData_Step3_Residentincompanykvknumber = "";
			gxTv_SdtCreateResidentData_Step3_Residentincompanyemail = "";
			gxTv_SdtCreateResidentData_Step3_Residentincompanyphone = "";

			gxTv_SdtCreateResidentData_Step3_Residentincompanysdts_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCreateResidentData_Step3_Residentincompanyid;
		 

		protected string gxTv_SdtCreateResidentData_Step3_Residentincompanyname;
		 

		protected string gxTv_SdtCreateResidentData_Step3_Residentincompanykvknumber;
		 

		protected string gxTv_SdtCreateResidentData_Step3_Residentincompanyemail;
		 

		protected string gxTv_SdtCreateResidentData_Step3_Residentincompanyphone;
		 
		protected bool gxTv_SdtCreateResidentData_Step3_Residentincompanysdts_N;
		protected GXBaseCollection<GeneXus.Programs.SdtResidentINCompanySDT> gxTv_SdtCreateResidentData_Step3_Residentincompanysdts = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateResidentData.Step3", Namespace="Comforta2")]
	public class SdtCreateResidentData_Step3_RESTInterface : GxGenericCollectionItem<SdtCreateResidentData_Step3>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateResidentData_Step3_RESTInterface( ) : base()
		{	
		}

		public SdtCreateResidentData_Step3_RESTInterface( SdtCreateResidentData_Step3 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentINCompanyId", Order=0)]
		public short gxTpr_Residentincompanyid
		{
			get { 
				return sdt.gxTpr_Residentincompanyid;

			}
			set { 
				sdt.gxTpr_Residentincompanyid = value;
			}
		}

		[DataMember(Name="ResidentINCompanyName", Order=1)]
		public  string gxTpr_Residentincompanyname
		{
			get { 
				return sdt.gxTpr_Residentincompanyname;

			}
			set { 
				 sdt.gxTpr_Residentincompanyname = value;
			}
		}

		[DataMember(Name="ResidentINCompanyKvkNumber", Order=2)]
		public  string gxTpr_Residentincompanykvknumber
		{
			get { 
				return sdt.gxTpr_Residentincompanykvknumber;

			}
			set { 
				 sdt.gxTpr_Residentincompanykvknumber = value;
			}
		}

		[DataMember(Name="ResidentINCompanyEmail", Order=3)]
		public  string gxTpr_Residentincompanyemail
		{
			get { 
				return sdt.gxTpr_Residentincompanyemail;

			}
			set { 
				 sdt.gxTpr_Residentincompanyemail = value;
			}
		}

		[DataMember(Name="ResidentINCompanyPhone", Order=4)]
		public  string gxTpr_Residentincompanyphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentincompanyphone);

			}
			set { 
				 sdt.gxTpr_Residentincompanyphone = value;
			}
		}

		[DataMember(Name="ResidentINCompanySDTs", Order=5, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtResidentINCompanySDT_RESTInterface> gxTpr_Residentincompanysdts
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Residentincompanysdts_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtResidentINCompanySDT_RESTInterface>(sdt.gxTpr_Residentincompanysdts);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Residentincompanysdts);
			}
		}


		#endregion

		public SdtCreateResidentData_Step3 sdt
		{
			get { 
				return (SdtCreateResidentData_Step3)Sdt;
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
				sdt = new SdtCreateResidentData_Step3() ;
			}
		}
	}
	#endregion
}