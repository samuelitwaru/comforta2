/*
				   File: type_SdtSDTCustomer_ManagerItem
			Description: Manager
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
	[XmlRoot(ElementName="SDTCustomer.ManagerItem")]
	[XmlType(TypeName="SDTCustomer.ManagerItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtSDTCustomer_ManagerItem : GxUserType
	{
		public SdtSDTCustomer_ManagerItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCustomer_ManagerItem_Customermanagergivenname = "";

			gxTv_SdtSDTCustomer_ManagerItem_Customermanagerlastname = "";

			gxTv_SdtSDTCustomer_ManagerItem_Customermanagerinitials = "";

			gxTv_SdtSDTCustomer_ManagerItem_Customermanageremail = "";

			gxTv_SdtSDTCustomer_ManagerItem_Customermanagerphone = "";

			gxTv_SdtSDTCustomer_ManagerItem_Customermanagergender = "";

			gxTv_SdtSDTCustomer_ManagerItem_Customermanagergamguid = "";

		}

		public SdtSDTCustomer_ManagerItem(IGxContext context)
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

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerManagerId")]
		[XmlElement(ElementName="CustomerManagerId")]
		public short gxTpr_Customermanagerid
		{
			get {
				return gxTv_SdtSDTCustomer_ManagerItem_Customermanagerid; 
			}
			set {
				gxTv_SdtSDTCustomer_ManagerItem_Customermanagerid = value;
				SetDirty("Customermanagerid");
			}
		}




		[SoapElement(ElementName="CustomerManagerGivenName")]
		[XmlElement(ElementName="CustomerManagerGivenName")]
		public string gxTpr_Customermanagergivenname
		{
			get {
				return gxTv_SdtSDTCustomer_ManagerItem_Customermanagergivenname; 
			}
			set {
				gxTv_SdtSDTCustomer_ManagerItem_Customermanagergivenname = value;
				SetDirty("Customermanagergivenname");
			}
		}




		[SoapElement(ElementName="CustomerManagerLastName")]
		[XmlElement(ElementName="CustomerManagerLastName")]
		public string gxTpr_Customermanagerlastname
		{
			get {
				return gxTv_SdtSDTCustomer_ManagerItem_Customermanagerlastname; 
			}
			set {
				gxTv_SdtSDTCustomer_ManagerItem_Customermanagerlastname = value;
				SetDirty("Customermanagerlastname");
			}
		}




		[SoapElement(ElementName="CustomerManagerInitials")]
		[XmlElement(ElementName="CustomerManagerInitials")]
		public string gxTpr_Customermanagerinitials
		{
			get {
				return gxTv_SdtSDTCustomer_ManagerItem_Customermanagerinitials; 
			}
			set {
				gxTv_SdtSDTCustomer_ManagerItem_Customermanagerinitials = value;
				SetDirty("Customermanagerinitials");
			}
		}




		[SoapElement(ElementName="CustomerManagerEmail")]
		[XmlElement(ElementName="CustomerManagerEmail")]
		public string gxTpr_Customermanageremail
		{
			get {
				return gxTv_SdtSDTCustomer_ManagerItem_Customermanageremail; 
			}
			set {
				gxTv_SdtSDTCustomer_ManagerItem_Customermanageremail = value;
				SetDirty("Customermanageremail");
			}
		}




		[SoapElement(ElementName="CustomerManagerPhone")]
		[XmlElement(ElementName="CustomerManagerPhone")]
		public string gxTpr_Customermanagerphone
		{
			get {
				return gxTv_SdtSDTCustomer_ManagerItem_Customermanagerphone; 
			}
			set {
				gxTv_SdtSDTCustomer_ManagerItem_Customermanagerphone = value;
				SetDirty("Customermanagerphone");
			}
		}




		[SoapElement(ElementName="CustomerManagerGender")]
		[XmlElement(ElementName="CustomerManagerGender")]
		public string gxTpr_Customermanagergender
		{
			get {
				return gxTv_SdtSDTCustomer_ManagerItem_Customermanagergender; 
			}
			set {
				gxTv_SdtSDTCustomer_ManagerItem_Customermanagergender = value;
				SetDirty("Customermanagergender");
			}
		}




		[SoapElement(ElementName="CustomerManagerGAMGUID")]
		[XmlElement(ElementName="CustomerManagerGAMGUID")]
		public string gxTpr_Customermanagergamguid
		{
			get {
				return gxTv_SdtSDTCustomer_ManagerItem_Customermanagergamguid; 
			}
			set {
				gxTv_SdtSDTCustomer_ManagerItem_Customermanagergamguid = value;
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
			gxTv_SdtSDTCustomer_ManagerItem_Customermanagergivenname = "";
			gxTv_SdtSDTCustomer_ManagerItem_Customermanagerlastname = "";
			gxTv_SdtSDTCustomer_ManagerItem_Customermanagerinitials = "";
			gxTv_SdtSDTCustomer_ManagerItem_Customermanageremail = "";
			gxTv_SdtSDTCustomer_ManagerItem_Customermanagerphone = "";
			gxTv_SdtSDTCustomer_ManagerItem_Customermanagergender = "";
			gxTv_SdtSDTCustomer_ManagerItem_Customermanagergamguid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTCustomer_ManagerItem_Customermanagerid;
		 

		protected string gxTv_SdtSDTCustomer_ManagerItem_Customermanagergivenname;
		 

		protected string gxTv_SdtSDTCustomer_ManagerItem_Customermanagerlastname;
		 

		protected string gxTv_SdtSDTCustomer_ManagerItem_Customermanagerinitials;
		 

		protected string gxTv_SdtSDTCustomer_ManagerItem_Customermanageremail;
		 

		protected string gxTv_SdtSDTCustomer_ManagerItem_Customermanagerphone;
		 

		protected string gxTv_SdtSDTCustomer_ManagerItem_Customermanagergender;
		 

		protected string gxTv_SdtSDTCustomer_ManagerItem_Customermanagergamguid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTCustomer.ManagerItem", Namespace="Comforta2")]
	public class SdtSDTCustomer_ManagerItem_RESTInterface : GxGenericCollectionItem<SdtSDTCustomer_ManagerItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCustomer_ManagerItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCustomer_ManagerItem_RESTInterface( SdtSDTCustomer_ManagerItem psdt ) : base(psdt)
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


		#endregion

		public SdtSDTCustomer_ManagerItem sdt
		{
			get { 
				return (SdtSDTCustomer_ManagerItem)Sdt;
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
				sdt = new SdtSDTCustomer_ManagerItem() ;
			}
		}
	}
	#endregion
}