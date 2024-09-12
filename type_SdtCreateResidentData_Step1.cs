/*
				   File: type_SdtCreateResidentData_Step1
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
	[XmlRoot(ElementName="CreateResidentData.Step1")]
	[XmlType(TypeName="CreateResidentData.Step1" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateResidentData_Step1 : GxUserType
	{
		public SdtCreateResidentData_Step1( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateResidentData_Step1_Residentbsnnumber = "";

			gxTv_SdtCreateResidentData_Step1_Residentgivenname = "";

			gxTv_SdtCreateResidentData_Step1_Residentlastname = "";

			gxTv_SdtCreateResidentData_Step1_Residentgender = "";

			gxTv_SdtCreateResidentData_Step1_Residentinitials = "";

			gxTv_SdtCreateResidentData_Step1_Residentemail = "";

			gxTv_SdtCreateResidentData_Step1_Residentphone = "";

			gxTv_SdtCreateResidentData_Step1_Residentaddress = "";

		}

		public SdtCreateResidentData_Step1(IGxContext context)
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
			AddObjectProperty("ResidentId", gxTpr_Residentid, false);


			AddObjectProperty("ResidentBsnNumber", gxTpr_Residentbsnnumber, false);


			AddObjectProperty("ResidentGivenName", gxTpr_Residentgivenname, false);


			AddObjectProperty("ResidentLastName", gxTpr_Residentlastname, false);


			AddObjectProperty("ResidentGender", gxTpr_Residentgender, false);


			AddObjectProperty("ResidentInitials", gxTpr_Residentinitials, false);


			AddObjectProperty("ResidentEmail", gxTpr_Residentemail, false);


			AddObjectProperty("ResidentPhone", gxTpr_Residentphone, false);


			AddObjectProperty("ResidentTypeId", gxTpr_Residenttypeid, false);


			AddObjectProperty("ResidentAddress", gxTpr_Residentaddress, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentId")]
		[XmlElement(ElementName="ResidentId")]
		public short gxTpr_Residentid
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residentid; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residentid = value;
				SetDirty("Residentid");
			}
		}




		[SoapElement(ElementName="ResidentBsnNumber")]
		[XmlElement(ElementName="ResidentBsnNumber")]
		public string gxTpr_Residentbsnnumber
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residentbsnnumber; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residentbsnnumber = value;
				SetDirty("Residentbsnnumber");
			}
		}




		[SoapElement(ElementName="ResidentGivenName")]
		[XmlElement(ElementName="ResidentGivenName")]
		public string gxTpr_Residentgivenname
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residentgivenname; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residentgivenname = value;
				SetDirty("Residentgivenname");
			}
		}




		[SoapElement(ElementName="ResidentLastName")]
		[XmlElement(ElementName="ResidentLastName")]
		public string gxTpr_Residentlastname
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residentlastname; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residentlastname = value;
				SetDirty("Residentlastname");
			}
		}




		[SoapElement(ElementName="ResidentGender")]
		[XmlElement(ElementName="ResidentGender")]
		public string gxTpr_Residentgender
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residentgender; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residentgender = value;
				SetDirty("Residentgender");
			}
		}




		[SoapElement(ElementName="ResidentInitials")]
		[XmlElement(ElementName="ResidentInitials")]
		public string gxTpr_Residentinitials
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residentinitials; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residentinitials = value;
				SetDirty("Residentinitials");
			}
		}




		[SoapElement(ElementName="ResidentEmail")]
		[XmlElement(ElementName="ResidentEmail")]
		public string gxTpr_Residentemail
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residentemail; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residentemail = value;
				SetDirty("Residentemail");
			}
		}




		[SoapElement(ElementName="ResidentPhone")]
		[XmlElement(ElementName="ResidentPhone")]
		public string gxTpr_Residentphone
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residentphone; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residentphone = value;
				SetDirty("Residentphone");
			}
		}




		[SoapElement(ElementName="ResidentTypeId")]
		[XmlElement(ElementName="ResidentTypeId")]
		public short gxTpr_Residenttypeid
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residenttypeid; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residenttypeid = value;
				SetDirty("Residenttypeid");
			}
		}




		[SoapElement(ElementName="ResidentAddress")]
		[XmlElement(ElementName="ResidentAddress")]
		public string gxTpr_Residentaddress
		{
			get {
				return gxTv_SdtCreateResidentData_Step1_Residentaddress; 
			}
			set {
				gxTv_SdtCreateResidentData_Step1_Residentaddress = value;
				SetDirty("Residentaddress");
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
			gxTv_SdtCreateResidentData_Step1_Residentbsnnumber = "";
			gxTv_SdtCreateResidentData_Step1_Residentgivenname = "";
			gxTv_SdtCreateResidentData_Step1_Residentlastname = "";
			gxTv_SdtCreateResidentData_Step1_Residentgender = "";
			gxTv_SdtCreateResidentData_Step1_Residentinitials = "";
			gxTv_SdtCreateResidentData_Step1_Residentemail = "";
			gxTv_SdtCreateResidentData_Step1_Residentphone = "";

			gxTv_SdtCreateResidentData_Step1_Residentaddress = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCreateResidentData_Step1_Residentid;
		 

		protected string gxTv_SdtCreateResidentData_Step1_Residentbsnnumber;
		 

		protected string gxTv_SdtCreateResidentData_Step1_Residentgivenname;
		 

		protected string gxTv_SdtCreateResidentData_Step1_Residentlastname;
		 

		protected string gxTv_SdtCreateResidentData_Step1_Residentgender;
		 

		protected string gxTv_SdtCreateResidentData_Step1_Residentinitials;
		 

		protected string gxTv_SdtCreateResidentData_Step1_Residentemail;
		 

		protected string gxTv_SdtCreateResidentData_Step1_Residentphone;
		 

		protected short gxTv_SdtCreateResidentData_Step1_Residenttypeid;
		 

		protected string gxTv_SdtCreateResidentData_Step1_Residentaddress;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateResidentData.Step1", Namespace="Comforta2")]
	public class SdtCreateResidentData_Step1_RESTInterface : GxGenericCollectionItem<SdtCreateResidentData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateResidentData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtCreateResidentData_Step1_RESTInterface( SdtCreateResidentData_Step1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentId", Order=0)]
		public short gxTpr_Residentid
		{
			get { 
				return sdt.gxTpr_Residentid;

			}
			set { 
				sdt.gxTpr_Residentid = value;
			}
		}

		[DataMember(Name="ResidentBsnNumber", Order=1)]
		public  string gxTpr_Residentbsnnumber
		{
			get { 
				return sdt.gxTpr_Residentbsnnumber;

			}
			set { 
				 sdt.gxTpr_Residentbsnnumber = value;
			}
		}

		[DataMember(Name="ResidentGivenName", Order=2)]
		public  string gxTpr_Residentgivenname
		{
			get { 
				return sdt.gxTpr_Residentgivenname;

			}
			set { 
				 sdt.gxTpr_Residentgivenname = value;
			}
		}

		[DataMember(Name="ResidentLastName", Order=3)]
		public  string gxTpr_Residentlastname
		{
			get { 
				return sdt.gxTpr_Residentlastname;

			}
			set { 
				 sdt.gxTpr_Residentlastname = value;
			}
		}

		[DataMember(Name="ResidentGender", Order=4)]
		public  string gxTpr_Residentgender
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentgender);

			}
			set { 
				 sdt.gxTpr_Residentgender = value;
			}
		}

		[DataMember(Name="ResidentInitials", Order=5)]
		public  string gxTpr_Residentinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentinitials);

			}
			set { 
				 sdt.gxTpr_Residentinitials = value;
			}
		}

		[DataMember(Name="ResidentEmail", Order=6)]
		public  string gxTpr_Residentemail
		{
			get { 
				return sdt.gxTpr_Residentemail;

			}
			set { 
				 sdt.gxTpr_Residentemail = value;
			}
		}

		[DataMember(Name="ResidentPhone", Order=7)]
		public  string gxTpr_Residentphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentphone);

			}
			set { 
				 sdt.gxTpr_Residentphone = value;
			}
		}

		[DataMember(Name="ResidentTypeId", Order=8)]
		public short gxTpr_Residenttypeid
		{
			get { 
				return sdt.gxTpr_Residenttypeid;

			}
			set { 
				sdt.gxTpr_Residenttypeid = value;
			}
		}

		[DataMember(Name="ResidentAddress", Order=9)]
		public  string gxTpr_Residentaddress
		{
			get { 
				return sdt.gxTpr_Residentaddress;

			}
			set { 
				 sdt.gxTpr_Residentaddress = value;
			}
		}


		#endregion

		public SdtCreateResidentData_Step1 sdt
		{
			get { 
				return (SdtCreateResidentData_Step1)Sdt;
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
				sdt = new SdtCreateResidentData_Step1() ;
			}
		}
	}
	#endregion
}