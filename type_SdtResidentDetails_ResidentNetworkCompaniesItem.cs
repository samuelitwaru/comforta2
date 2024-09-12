/*
				   File: type_SdtResidentDetails_ResidentNetworkCompaniesItem
			Description: ResidentNetworkCompanies
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
	[XmlRoot(ElementName="ResidentDetails.ResidentNetworkCompaniesItem")]
	[XmlType(TypeName="ResidentDetails.ResidentNetworkCompaniesItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtResidentDetails_ResidentNetworkCompaniesItem : GxUserType
	{
		public SdtResidentDetails_ResidentNetworkCompaniesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanykvknumber = "";

			gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyname = "";

			gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyemail = "";

			gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyphone = "";

		}

		public SdtResidentDetails_ResidentNetworkCompaniesItem(IGxContext context)
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


			AddObjectProperty("ResidentINCompanyKvkNumber", gxTpr_Residentincompanykvknumber, false);


			AddObjectProperty("ResidentINCompanyName", gxTpr_Residentincompanyname, false);


			AddObjectProperty("ResidentINCompanyEmail", gxTpr_Residentincompanyemail, false);


			AddObjectProperty("ResidentINCompanyPhone", gxTpr_Residentincompanyphone, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentINCompanyId")]
		[XmlElement(ElementName="ResidentINCompanyId")]
		public short gxTpr_Residentincompanyid
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyid; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyid = value;
				SetDirty("Residentincompanyid");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyKvkNumber")]
		[XmlElement(ElementName="ResidentINCompanyKvkNumber")]
		public string gxTpr_Residentincompanykvknumber
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanykvknumber; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanykvknumber = value;
				SetDirty("Residentincompanykvknumber");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyName")]
		[XmlElement(ElementName="ResidentINCompanyName")]
		public string gxTpr_Residentincompanyname
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyname; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyname = value;
				SetDirty("Residentincompanyname");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyEmail")]
		[XmlElement(ElementName="ResidentINCompanyEmail")]
		public string gxTpr_Residentincompanyemail
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyemail; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyemail = value;
				SetDirty("Residentincompanyemail");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyPhone")]
		[XmlElement(ElementName="ResidentINCompanyPhone")]
		public string gxTpr_Residentincompanyphone
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyphone; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyphone = value;
				SetDirty("Residentincompanyphone");
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
			gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanykvknumber = "";
			gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyname = "";
			gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyemail = "";
			gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyphone = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyid;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanykvknumber;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyname;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyemail;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkCompaniesItem_Residentincompanyphone;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"ResidentDetails.ResidentNetworkCompaniesItem", Namespace="Comforta2")]
	public class SdtResidentDetails_ResidentNetworkCompaniesItem_RESTInterface : GxGenericCollectionItem<SdtResidentDetails_ResidentNetworkCompaniesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResidentDetails_ResidentNetworkCompaniesItem_RESTInterface( ) : base()
		{	
		}

		public SdtResidentDetails_ResidentNetworkCompaniesItem_RESTInterface( SdtResidentDetails_ResidentNetworkCompaniesItem psdt ) : base(psdt)
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

		[DataMember(Name="ResidentINCompanyKvkNumber", Order=1)]
		public  string gxTpr_Residentincompanykvknumber
		{
			get { 
				return sdt.gxTpr_Residentincompanykvknumber;

			}
			set { 
				 sdt.gxTpr_Residentincompanykvknumber = value;
			}
		}

		[DataMember(Name="ResidentINCompanyName", Order=2)]
		public  string gxTpr_Residentincompanyname
		{
			get { 
				return sdt.gxTpr_Residentincompanyname;

			}
			set { 
				 sdt.gxTpr_Residentincompanyname = value;
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


		#endregion

		public SdtResidentDetails_ResidentNetworkCompaniesItem sdt
		{
			get { 
				return (SdtResidentDetails_ResidentNetworkCompaniesItem)Sdt;
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
				sdt = new SdtResidentDetails_ResidentNetworkCompaniesItem() ;
			}
		}
	}
	#endregion
}