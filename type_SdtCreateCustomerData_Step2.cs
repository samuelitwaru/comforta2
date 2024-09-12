/*
				   File: type_SdtCreateCustomerData_Step2
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
	[XmlRoot(ElementName="CreateCustomerData.Step2")]
	[XmlType(TypeName="CreateCustomerData.Step2" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateCustomerData_Step2 : GxUserType
	{
		public SdtCreateCustomerData_Step2( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateCustomerData_Step2_Customermanagergivenname = "";

			gxTv_SdtCreateCustomerData_Step2_Customermanagerlastname = "";

			gxTv_SdtCreateCustomerData_Step2_Customermanagerinitials = "";

			gxTv_SdtCreateCustomerData_Step2_Customermanageremail = "";

			gxTv_SdtCreateCustomerData_Step2_Customermanagerphone = "";

			gxTv_SdtCreateCustomerData_Step2_Customermanagergender = "";

			gxTv_SdtCreateCustomerData_Step2_Customermanagergamguid = "";

		}

		public SdtCreateCustomerData_Step2(IGxContext context)
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
			AddObjectProperty("CustomerManagerId", gxTpr_Customermanagerid, false);


			AddObjectProperty("CustomerManagerGivenName", gxTpr_Customermanagergivenname, false);


			AddObjectProperty("CustomerManagerLastName", gxTpr_Customermanagerlastname, false);


			AddObjectProperty("CustomerManagerInitials", gxTpr_Customermanagerinitials, false);


			AddObjectProperty("CustomerManagerEmail", gxTpr_Customermanageremail, false);


			AddObjectProperty("CustomerManagerPhone", gxTpr_Customermanagerphone, false);


			AddObjectProperty("CustomerManagerGender", gxTpr_Customermanagergender, false);


			AddObjectProperty("CustomerManagerGAMGUID", gxTpr_Customermanagergamguid, false);

			if (gxTv_SdtCreateCustomerData_Step2_Customermanagersdts != null)
			{
				AddObjectProperty("CustomerManagerSDTs", gxTv_SdtCreateCustomerData_Step2_Customermanagersdts, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerManagerId")]
		[XmlElement(ElementName="CustomerManagerId")]
		public short gxTpr_Customermanagerid
		{
			get {
				return gxTv_SdtCreateCustomerData_Step2_Customermanagerid; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanagerid = value;
				SetDirty("Customermanagerid");
			}
		}




		[SoapElement(ElementName="CustomerManagerGivenName")]
		[XmlElement(ElementName="CustomerManagerGivenName")]
		public string gxTpr_Customermanagergivenname
		{
			get {
				return gxTv_SdtCreateCustomerData_Step2_Customermanagergivenname; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanagergivenname = value;
				SetDirty("Customermanagergivenname");
			}
		}




		[SoapElement(ElementName="CustomerManagerLastName")]
		[XmlElement(ElementName="CustomerManagerLastName")]
		public string gxTpr_Customermanagerlastname
		{
			get {
				return gxTv_SdtCreateCustomerData_Step2_Customermanagerlastname; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanagerlastname = value;
				SetDirty("Customermanagerlastname");
			}
		}




		[SoapElement(ElementName="CustomerManagerInitials")]
		[XmlElement(ElementName="CustomerManagerInitials")]
		public string gxTpr_Customermanagerinitials
		{
			get {
				return gxTv_SdtCreateCustomerData_Step2_Customermanagerinitials; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanagerinitials = value;
				SetDirty("Customermanagerinitials");
			}
		}




		[SoapElement(ElementName="CustomerManagerEmail")]
		[XmlElement(ElementName="CustomerManagerEmail")]
		public string gxTpr_Customermanageremail
		{
			get {
				return gxTv_SdtCreateCustomerData_Step2_Customermanageremail; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanageremail = value;
				SetDirty("Customermanageremail");
			}
		}




		[SoapElement(ElementName="CustomerManagerPhone")]
		[XmlElement(ElementName="CustomerManagerPhone")]
		public string gxTpr_Customermanagerphone
		{
			get {
				return gxTv_SdtCreateCustomerData_Step2_Customermanagerphone; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanagerphone = value;
				SetDirty("Customermanagerphone");
			}
		}




		[SoapElement(ElementName="CustomerManagerGender")]
		[XmlElement(ElementName="CustomerManagerGender")]
		public string gxTpr_Customermanagergender
		{
			get {
				return gxTv_SdtCreateCustomerData_Step2_Customermanagergender; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanagergender = value;
				SetDirty("Customermanagergender");
			}
		}




		[SoapElement(ElementName="CustomerManagerGAMGUID")]
		[XmlElement(ElementName="CustomerManagerGAMGUID")]
		public string gxTpr_Customermanagergamguid
		{
			get {
				return gxTv_SdtCreateCustomerData_Step2_Customermanagergamguid; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanagergamguid = value;
				SetDirty("Customermanagergamguid");
			}
		}




		[SoapElement(ElementName="CustomerManagerSDTs" )]
		[XmlArray(ElementName="CustomerManagerSDTs"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtCustomerManagerSDT> gxTpr_Customermanagersdts_GXBaseCollection
		{
			get {
				if ( gxTv_SdtCreateCustomerData_Step2_Customermanagersdts == null )
				{
					gxTv_SdtCreateCustomerData_Step2_Customermanagersdts = new GXBaseCollection<GeneXus.Programs.SdtCustomerManagerSDT>( context, "CustomerManagerSDT", "");
				}
				return gxTv_SdtCreateCustomerData_Step2_Customermanagersdts;
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanagersdts_N = false;
				gxTv_SdtCreateCustomerData_Step2_Customermanagersdts = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtCustomerManagerSDT> gxTpr_Customermanagersdts
		{
			get {
				if ( gxTv_SdtCreateCustomerData_Step2_Customermanagersdts == null )
				{
					gxTv_SdtCreateCustomerData_Step2_Customermanagersdts = new GXBaseCollection<GeneXus.Programs.SdtCustomerManagerSDT>( context, "CustomerManagerSDT", "");
				}
				gxTv_SdtCreateCustomerData_Step2_Customermanagersdts_N = false;
				return gxTv_SdtCreateCustomerData_Step2_Customermanagersdts ;
			}
			set {
				gxTv_SdtCreateCustomerData_Step2_Customermanagersdts_N = false;
				gxTv_SdtCreateCustomerData_Step2_Customermanagersdts = value;
				SetDirty("Customermanagersdts");
			}
		}

		public void gxTv_SdtCreateCustomerData_Step2_Customermanagersdts_SetNull()
		{
			gxTv_SdtCreateCustomerData_Step2_Customermanagersdts_N = true;
			gxTv_SdtCreateCustomerData_Step2_Customermanagersdts = null;
		}

		public bool gxTv_SdtCreateCustomerData_Step2_Customermanagersdts_IsNull()
		{
			return gxTv_SdtCreateCustomerData_Step2_Customermanagersdts == null;
		}
		public bool ShouldSerializegxTpr_Customermanagersdts_GXBaseCollection_Json()
		{
			return gxTv_SdtCreateCustomerData_Step2_Customermanagersdts != null && gxTv_SdtCreateCustomerData_Step2_Customermanagersdts.Count > 0;

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
			gxTv_SdtCreateCustomerData_Step2_Customermanagergivenname = "";
			gxTv_SdtCreateCustomerData_Step2_Customermanagerlastname = "";
			gxTv_SdtCreateCustomerData_Step2_Customermanagerinitials = "";
			gxTv_SdtCreateCustomerData_Step2_Customermanageremail = "";
			gxTv_SdtCreateCustomerData_Step2_Customermanagerphone = "";
			gxTv_SdtCreateCustomerData_Step2_Customermanagergender = "";
			gxTv_SdtCreateCustomerData_Step2_Customermanagergamguid = "";

			gxTv_SdtCreateCustomerData_Step2_Customermanagersdts_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCreateCustomerData_Step2_Customermanagerid;
		 

		protected string gxTv_SdtCreateCustomerData_Step2_Customermanagergivenname;
		 

		protected string gxTv_SdtCreateCustomerData_Step2_Customermanagerlastname;
		 

		protected string gxTv_SdtCreateCustomerData_Step2_Customermanagerinitials;
		 

		protected string gxTv_SdtCreateCustomerData_Step2_Customermanageremail;
		 

		protected string gxTv_SdtCreateCustomerData_Step2_Customermanagerphone;
		 

		protected string gxTv_SdtCreateCustomerData_Step2_Customermanagergender;
		 

		protected string gxTv_SdtCreateCustomerData_Step2_Customermanagergamguid;
		 
		protected bool gxTv_SdtCreateCustomerData_Step2_Customermanagersdts_N;
		protected GXBaseCollection<GeneXus.Programs.SdtCustomerManagerSDT> gxTv_SdtCreateCustomerData_Step2_Customermanagersdts = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateCustomerData.Step2", Namespace="Comforta2")]
	public class SdtCreateCustomerData_Step2_RESTInterface : GxGenericCollectionItem<SdtCreateCustomerData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateCustomerData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtCreateCustomerData_Step2_RESTInterface( SdtCreateCustomerData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerManagerId", Order=0)]
		public short gxTpr_Customermanagerid
		{
			get { 
				return sdt.gxTpr_Customermanagerid;

			}
			set { 
				sdt.gxTpr_Customermanagerid = value;
			}
		}

		[DataMember(Name="CustomerManagerGivenName", Order=1)]
		public  string gxTpr_Customermanagergivenname
		{
			get { 
				return sdt.gxTpr_Customermanagergivenname;

			}
			set { 
				 sdt.gxTpr_Customermanagergivenname = value;
			}
		}

		[DataMember(Name="CustomerManagerLastName", Order=2)]
		public  string gxTpr_Customermanagerlastname
		{
			get { 
				return sdt.gxTpr_Customermanagerlastname;

			}
			set { 
				 sdt.gxTpr_Customermanagerlastname = value;
			}
		}

		[DataMember(Name="CustomerManagerInitials", Order=3)]
		public  string gxTpr_Customermanagerinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customermanagerinitials);

			}
			set { 
				 sdt.gxTpr_Customermanagerinitials = value;
			}
		}

		[DataMember(Name="CustomerManagerEmail", Order=4)]
		public  string gxTpr_Customermanageremail
		{
			get { 
				return sdt.gxTpr_Customermanageremail;

			}
			set { 
				 sdt.gxTpr_Customermanageremail = value;
			}
		}

		[DataMember(Name="CustomerManagerPhone", Order=5)]
		public  string gxTpr_Customermanagerphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customermanagerphone);

			}
			set { 
				 sdt.gxTpr_Customermanagerphone = value;
			}
		}

		[DataMember(Name="CustomerManagerGender", Order=6)]
		public  string gxTpr_Customermanagergender
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customermanagergender);

			}
			set { 
				 sdt.gxTpr_Customermanagergender = value;
			}
		}

		[DataMember(Name="CustomerManagerGAMGUID", Order=7)]
		public  string gxTpr_Customermanagergamguid
		{
			get { 
				return sdt.gxTpr_Customermanagergamguid;

			}
			set { 
				 sdt.gxTpr_Customermanagergamguid = value;
			}
		}

		[DataMember(Name="CustomerManagerSDTs", Order=8, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtCustomerManagerSDT_RESTInterface> gxTpr_Customermanagersdts
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Customermanagersdts_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtCustomerManagerSDT_RESTInterface>(sdt.gxTpr_Customermanagersdts);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Customermanagersdts);
			}
		}


		#endregion

		public SdtCreateCustomerData_Step2 sdt
		{
			get { 
				return (SdtCreateCustomerData_Step2)Sdt;
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
				sdt = new SdtCreateCustomerData_Step2() ;
			}
		}
	}
	#endregion
}