/*
				   File: type_SdtCustomerManagerSDT
			Description: CustomerManagerSDT
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
	[XmlRoot(ElementName="CustomerManagerSDT")]
	[XmlType(TypeName="CustomerManagerSDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCustomerManagerSDT : GxUserType
	{
		public SdtCustomerManagerSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtCustomerManagerSDT_Customermanagergivenname = "";

			gxTv_SdtCustomerManagerSDT_Customermanagerlastname = "";

			gxTv_SdtCustomerManagerSDT_Customermanagerinitials = "";

			gxTv_SdtCustomerManagerSDT_Customermanageremail = "";

			gxTv_SdtCustomerManagerSDT_Customermanagerphone = "";

			gxTv_SdtCustomerManagerSDT_Customermanagergender = "";

			gxTv_SdtCustomerManagerSDT_Customermanagergamguid = "";

		}

		public SdtCustomerManagerSDT(IGxContext context)
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
			AddObjectProperty("CustomerManagerGivenName", gxTpr_Customermanagergivenname, false);


			AddObjectProperty("CustomerManagerLastName", gxTpr_Customermanagerlastname, false);


			AddObjectProperty("CustomerManagerInitials", gxTpr_Customermanagerinitials, false);


			AddObjectProperty("CustomerManagerEmail", gxTpr_Customermanageremail, false);


			AddObjectProperty("CustomerManagerPhone", gxTpr_Customermanagerphone, false);


			AddObjectProperty("CustomerManagerGender", gxTpr_Customermanagergender, false);


			AddObjectProperty("CustomerManagerGAMGUID", gxTpr_Customermanagergamguid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerManagerGivenName")]
		[XmlElement(ElementName="CustomerManagerGivenName")]
		public string gxTpr_Customermanagergivenname
		{
			get {
				return gxTv_SdtCustomerManagerSDT_Customermanagergivenname; 
			}
			set {
				gxTv_SdtCustomerManagerSDT_Customermanagergivenname = value;
				SetDirty("Customermanagergivenname");
			}
		}




		[SoapElement(ElementName="CustomerManagerLastName")]
		[XmlElement(ElementName="CustomerManagerLastName")]
		public string gxTpr_Customermanagerlastname
		{
			get {
				return gxTv_SdtCustomerManagerSDT_Customermanagerlastname; 
			}
			set {
				gxTv_SdtCustomerManagerSDT_Customermanagerlastname = value;
				SetDirty("Customermanagerlastname");
			}
		}




		[SoapElement(ElementName="CustomerManagerInitials")]
		[XmlElement(ElementName="CustomerManagerInitials")]
		public string gxTpr_Customermanagerinitials
		{
			get {
				return gxTv_SdtCustomerManagerSDT_Customermanagerinitials; 
			}
			set {
				gxTv_SdtCustomerManagerSDT_Customermanagerinitials = value;
				SetDirty("Customermanagerinitials");
			}
		}




		[SoapElement(ElementName="CustomerManagerEmail")]
		[XmlElement(ElementName="CustomerManagerEmail")]
		public string gxTpr_Customermanageremail
		{
			get {
				return gxTv_SdtCustomerManagerSDT_Customermanageremail; 
			}
			set {
				gxTv_SdtCustomerManagerSDT_Customermanageremail = value;
				SetDirty("Customermanageremail");
			}
		}




		[SoapElement(ElementName="CustomerManagerPhone")]
		[XmlElement(ElementName="CustomerManagerPhone")]
		public string gxTpr_Customermanagerphone
		{
			get {
				return gxTv_SdtCustomerManagerSDT_Customermanagerphone; 
			}
			set {
				gxTv_SdtCustomerManagerSDT_Customermanagerphone = value;
				SetDirty("Customermanagerphone");
			}
		}




		[SoapElement(ElementName="CustomerManagerGender")]
		[XmlElement(ElementName="CustomerManagerGender")]
		public string gxTpr_Customermanagergender
		{
			get {
				return gxTv_SdtCustomerManagerSDT_Customermanagergender; 
			}
			set {
				gxTv_SdtCustomerManagerSDT_Customermanagergender = value;
				SetDirty("Customermanagergender");
			}
		}




		[SoapElement(ElementName="CustomerManagerGAMGUID")]
		[XmlElement(ElementName="CustomerManagerGAMGUID")]
		public string gxTpr_Customermanagergamguid
		{
			get {
				return gxTv_SdtCustomerManagerSDT_Customermanagergamguid; 
			}
			set {
				gxTv_SdtCustomerManagerSDT_Customermanagergamguid = value;
				SetDirty("Customermanagergamguid");
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
			gxTv_SdtCustomerManagerSDT_Customermanagergivenname = "";
			gxTv_SdtCustomerManagerSDT_Customermanagerlastname = "";
			gxTv_SdtCustomerManagerSDT_Customermanagerinitials = "";
			gxTv_SdtCustomerManagerSDT_Customermanageremail = "";
			gxTv_SdtCustomerManagerSDT_Customermanagerphone = "";
			gxTv_SdtCustomerManagerSDT_Customermanagergender = "";
			gxTv_SdtCustomerManagerSDT_Customermanagergamguid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtCustomerManagerSDT_Customermanagergivenname;
		 

		protected string gxTv_SdtCustomerManagerSDT_Customermanagerlastname;
		 

		protected string gxTv_SdtCustomerManagerSDT_Customermanagerinitials;
		 

		protected string gxTv_SdtCustomerManagerSDT_Customermanageremail;
		 

		protected string gxTv_SdtCustomerManagerSDT_Customermanagerphone;
		 

		protected string gxTv_SdtCustomerManagerSDT_Customermanagergender;
		 

		protected string gxTv_SdtCustomerManagerSDT_Customermanagergamguid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CustomerManagerSDT", Namespace="Comforta2")]
	public class SdtCustomerManagerSDT_RESTInterface : GxGenericCollectionItem<SdtCustomerManagerSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCustomerManagerSDT_RESTInterface( ) : base()
		{	
		}

		public SdtCustomerManagerSDT_RESTInterface( SdtCustomerManagerSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerManagerGivenName", Order=0)]
		public  string gxTpr_Customermanagergivenname
		{
			get { 
				return sdt.gxTpr_Customermanagergivenname;

			}
			set { 
				 sdt.gxTpr_Customermanagergivenname = value;
			}
		}

		[DataMember(Name="CustomerManagerLastName", Order=1)]
		public  string gxTpr_Customermanagerlastname
		{
			get { 
				return sdt.gxTpr_Customermanagerlastname;

			}
			set { 
				 sdt.gxTpr_Customermanagerlastname = value;
			}
		}

		[DataMember(Name="CustomerManagerInitials", Order=2)]
		public  string gxTpr_Customermanagerinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customermanagerinitials);

			}
			set { 
				 sdt.gxTpr_Customermanagerinitials = value;
			}
		}

		[DataMember(Name="CustomerManagerEmail", Order=3)]
		public  string gxTpr_Customermanageremail
		{
			get { 
				return sdt.gxTpr_Customermanageremail;

			}
			set { 
				 sdt.gxTpr_Customermanageremail = value;
			}
		}

		[DataMember(Name="CustomerManagerPhone", Order=4)]
		public  string gxTpr_Customermanagerphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customermanagerphone);

			}
			set { 
				 sdt.gxTpr_Customermanagerphone = value;
			}
		}

		[DataMember(Name="CustomerManagerGender", Order=5)]
		public  string gxTpr_Customermanagergender
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customermanagergender);

			}
			set { 
				 sdt.gxTpr_Customermanagergender = value;
			}
		}

		[DataMember(Name="CustomerManagerGAMGUID", Order=6)]
		public  string gxTpr_Customermanagergamguid
		{
			get { 
				return sdt.gxTpr_Customermanagergamguid;

			}
			set { 
				 sdt.gxTpr_Customermanagergamguid = value;
			}
		}


		#endregion

		public SdtCustomerManagerSDT sdt
		{
			get { 
				return (SdtCustomerManagerSDT)Sdt;
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
				sdt = new SdtCustomerManagerSDT() ;
			}
		}
	}
	#endregion
}