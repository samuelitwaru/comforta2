/*
				   File: type_SdtResidentINIndividualSDT
			Description: ResidentINIndividualSDT
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
	[XmlRoot(ElementName="ResidentINIndividualSDT")]
	[XmlType(TypeName="ResidentINIndividualSDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtResidentINIndividualSDT : GxUserType
	{
		public SdtResidentINIndividualSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtResidentINIndividualSDT_Residentinindividualbsnnumber = "";

			gxTv_SdtResidentINIndividualSDT_Residentinindividualgivenname = "";

			gxTv_SdtResidentINIndividualSDT_Residentinindividuallastname = "";

			gxTv_SdtResidentINIndividualSDT_Residentinindividualemail = "";

			gxTv_SdtResidentINIndividualSDT_Residentinindividualphone = "";

			gxTv_SdtResidentINIndividualSDT_Residentinindividualaddress = "";

			gxTv_SdtResidentINIndividualSDT_Residentinindividualgender = "";

		}

		public SdtResidentINIndividualSDT(IGxContext context)
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
			AddObjectProperty("ResidentINIndividualBsnNumber", gxTpr_Residentinindividualbsnnumber, false);


			AddObjectProperty("ResidentINIndividualGivenName", gxTpr_Residentinindividualgivenname, false);


			AddObjectProperty("ResidentINIndividualLastName", gxTpr_Residentinindividuallastname, false);


			AddObjectProperty("ResidentINIndividualEmail", gxTpr_Residentinindividualemail, false);


			AddObjectProperty("ResidentINIndividualPhone", gxTpr_Residentinindividualphone, false);


			AddObjectProperty("ResidentINIndividualAddress", gxTpr_Residentinindividualaddress, false);


			AddObjectProperty("ResidentINIndividualGender", gxTpr_Residentinindividualgender, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentINIndividualBsnNumber")]
		[XmlElement(ElementName="ResidentINIndividualBsnNumber")]
		public string gxTpr_Residentinindividualbsnnumber
		{
			get {
				return gxTv_SdtResidentINIndividualSDT_Residentinindividualbsnnumber; 
			}
			set {
				gxTv_SdtResidentINIndividualSDT_Residentinindividualbsnnumber = value;
				SetDirty("Residentinindividualbsnnumber");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualGivenName")]
		[XmlElement(ElementName="ResidentINIndividualGivenName")]
		public string gxTpr_Residentinindividualgivenname
		{
			get {
				return gxTv_SdtResidentINIndividualSDT_Residentinindividualgivenname; 
			}
			set {
				gxTv_SdtResidentINIndividualSDT_Residentinindividualgivenname = value;
				SetDirty("Residentinindividualgivenname");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualLastName")]
		[XmlElement(ElementName="ResidentINIndividualLastName")]
		public string gxTpr_Residentinindividuallastname
		{
			get {
				return gxTv_SdtResidentINIndividualSDT_Residentinindividuallastname; 
			}
			set {
				gxTv_SdtResidentINIndividualSDT_Residentinindividuallastname = value;
				SetDirty("Residentinindividuallastname");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualEmail")]
		[XmlElement(ElementName="ResidentINIndividualEmail")]
		public string gxTpr_Residentinindividualemail
		{
			get {
				return gxTv_SdtResidentINIndividualSDT_Residentinindividualemail; 
			}
			set {
				gxTv_SdtResidentINIndividualSDT_Residentinindividualemail = value;
				SetDirty("Residentinindividualemail");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualPhone")]
		[XmlElement(ElementName="ResidentINIndividualPhone")]
		public string gxTpr_Residentinindividualphone
		{
			get {
				return gxTv_SdtResidentINIndividualSDT_Residentinindividualphone; 
			}
			set {
				gxTv_SdtResidentINIndividualSDT_Residentinindividualphone = value;
				SetDirty("Residentinindividualphone");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualAddress")]
		[XmlElement(ElementName="ResidentINIndividualAddress")]
		public string gxTpr_Residentinindividualaddress
		{
			get {
				return gxTv_SdtResidentINIndividualSDT_Residentinindividualaddress; 
			}
			set {
				gxTv_SdtResidentINIndividualSDT_Residentinindividualaddress = value;
				SetDirty("Residentinindividualaddress");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualGender")]
		[XmlElement(ElementName="ResidentINIndividualGender")]
		public string gxTpr_Residentinindividualgender
		{
			get {
				return gxTv_SdtResidentINIndividualSDT_Residentinindividualgender; 
			}
			set {
				gxTv_SdtResidentINIndividualSDT_Residentinindividualgender = value;
				SetDirty("Residentinindividualgender");
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
			gxTv_SdtResidentINIndividualSDT_Residentinindividualbsnnumber = "";
			gxTv_SdtResidentINIndividualSDT_Residentinindividualgivenname = "";
			gxTv_SdtResidentINIndividualSDT_Residentinindividuallastname = "";
			gxTv_SdtResidentINIndividualSDT_Residentinindividualemail = "";
			gxTv_SdtResidentINIndividualSDT_Residentinindividualphone = "";
			gxTv_SdtResidentINIndividualSDT_Residentinindividualaddress = "";
			gxTv_SdtResidentINIndividualSDT_Residentinindividualgender = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtResidentINIndividualSDT_Residentinindividualbsnnumber;
		 

		protected string gxTv_SdtResidentINIndividualSDT_Residentinindividualgivenname;
		 

		protected string gxTv_SdtResidentINIndividualSDT_Residentinindividuallastname;
		 

		protected string gxTv_SdtResidentINIndividualSDT_Residentinindividualemail;
		 

		protected string gxTv_SdtResidentINIndividualSDT_Residentinindividualphone;
		 

		protected string gxTv_SdtResidentINIndividualSDT_Residentinindividualaddress;
		 

		protected string gxTv_SdtResidentINIndividualSDT_Residentinindividualgender;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ResidentINIndividualSDT", Namespace="Comforta2")]
	public class SdtResidentINIndividualSDT_RESTInterface : GxGenericCollectionItem<SdtResidentINIndividualSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResidentINIndividualSDT_RESTInterface( ) : base()
		{	
		}

		public SdtResidentINIndividualSDT_RESTInterface( SdtResidentINIndividualSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentINIndividualBsnNumber", Order=0)]
		public  string gxTpr_Residentinindividualbsnnumber
		{
			get { 
				return sdt.gxTpr_Residentinindividualbsnnumber;

			}
			set { 
				 sdt.gxTpr_Residentinindividualbsnnumber = value;
			}
		}

		[DataMember(Name="ResidentINIndividualGivenName", Order=1)]
		public  string gxTpr_Residentinindividualgivenname
		{
			get { 
				return sdt.gxTpr_Residentinindividualgivenname;

			}
			set { 
				 sdt.gxTpr_Residentinindividualgivenname = value;
			}
		}

		[DataMember(Name="ResidentINIndividualLastName", Order=2)]
		public  string gxTpr_Residentinindividuallastname
		{
			get { 
				return sdt.gxTpr_Residentinindividuallastname;

			}
			set { 
				 sdt.gxTpr_Residentinindividuallastname = value;
			}
		}

		[DataMember(Name="ResidentINIndividualEmail", Order=3)]
		public  string gxTpr_Residentinindividualemail
		{
			get { 
				return sdt.gxTpr_Residentinindividualemail;

			}
			set { 
				 sdt.gxTpr_Residentinindividualemail = value;
			}
		}

		[DataMember(Name="ResidentINIndividualPhone", Order=4)]
		public  string gxTpr_Residentinindividualphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentinindividualphone);

			}
			set { 
				 sdt.gxTpr_Residentinindividualphone = value;
			}
		}

		[DataMember(Name="ResidentINIndividualAddress", Order=5)]
		public  string gxTpr_Residentinindividualaddress
		{
			get { 
				return sdt.gxTpr_Residentinindividualaddress;

			}
			set { 
				 sdt.gxTpr_Residentinindividualaddress = value;
			}
		}

		[DataMember(Name="ResidentINIndividualGender", Order=6)]
		public  string gxTpr_Residentinindividualgender
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentinindividualgender);

			}
			set { 
				 sdt.gxTpr_Residentinindividualgender = value;
			}
		}


		#endregion

		public SdtResidentINIndividualSDT sdt
		{
			get { 
				return (SdtResidentINIndividualSDT)Sdt;
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
				sdt = new SdtResidentINIndividualSDT() ;
			}
		}
	}
	#endregion
}