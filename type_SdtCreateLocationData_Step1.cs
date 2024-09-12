/*
				   File: type_SdtCreateLocationData_Step1
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
	[XmlRoot(ElementName="CreateLocationData.Step1")]
	[XmlType(TypeName="CreateLocationData.Step1" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateLocationData_Step1 : GxUserType
	{
		public SdtCreateLocationData_Step1( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateLocationData_Step1_Customerlocationname = "";

			gxTv_SdtCreateLocationData_Step1_Customerlocationemail = "";

			gxTv_SdtCreateLocationData_Step1_Customerlocationphone = "";

			gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress = "";

			gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress = "";

			gxTv_SdtCreateLocationData_Step1_Customerlocationdescription = "";

		}

		public SdtCreateLocationData_Step1(IGxContext context)
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
			AddObjectProperty("CustomerLocationName", gxTpr_Customerlocationname, false);


			AddObjectProperty("CustomerLocationId", gxTpr_Customerlocationid, false);


			AddObjectProperty("CustomerLocationEmail", gxTpr_Customerlocationemail, false);


			AddObjectProperty("CustomerLocationPhone", gxTpr_Customerlocationphone, false);


			AddObjectProperty("CustomerLocationPostalAddress", gxTpr_Customerlocationpostaladdress, false);


			AddObjectProperty("CustomerLocationVisitingAddress", gxTpr_Customerlocationvisitingaddress, false);


			AddObjectProperty("CustomerLocationDescription", gxTpr_Customerlocationdescription, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerLocationName")]
		[XmlElement(ElementName="CustomerLocationName")]
		public string gxTpr_Customerlocationname
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationname; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationname = value;
				SetDirty("Customerlocationname");
			}
		}




		[SoapElement(ElementName="CustomerLocationId")]
		[XmlElement(ElementName="CustomerLocationId")]
		public short gxTpr_Customerlocationid
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationid; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationid = value;
				SetDirty("Customerlocationid");
			}
		}




		[SoapElement(ElementName="CustomerLocationEmail")]
		[XmlElement(ElementName="CustomerLocationEmail")]
		public string gxTpr_Customerlocationemail
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationemail; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationemail = value;
				SetDirty("Customerlocationemail");
			}
		}




		[SoapElement(ElementName="CustomerLocationPhone")]
		[XmlElement(ElementName="CustomerLocationPhone")]
		public string gxTpr_Customerlocationphone
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationphone; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationphone = value;
				SetDirty("Customerlocationphone");
			}
		}




		[SoapElement(ElementName="CustomerLocationPostalAddress")]
		[XmlElement(ElementName="CustomerLocationPostalAddress")]
		public string gxTpr_Customerlocationpostaladdress
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress = value;
				SetDirty("Customerlocationpostaladdress");
			}
		}




		[SoapElement(ElementName="CustomerLocationVisitingAddress")]
		[XmlElement(ElementName="CustomerLocationVisitingAddress")]
		public string gxTpr_Customerlocationvisitingaddress
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress = value;
				SetDirty("Customerlocationvisitingaddress");
			}
		}




		[SoapElement(ElementName="CustomerLocationDescription")]
		[XmlElement(ElementName="CustomerLocationDescription")]
		public string gxTpr_Customerlocationdescription
		{
			get {
				return gxTv_SdtCreateLocationData_Step1_Customerlocationdescription; 
			}
			set {
				gxTv_SdtCreateLocationData_Step1_Customerlocationdescription = value;
				SetDirty("Customerlocationdescription");
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
			gxTv_SdtCreateLocationData_Step1_Customerlocationname = "";

			gxTv_SdtCreateLocationData_Step1_Customerlocationemail = "";
			gxTv_SdtCreateLocationData_Step1_Customerlocationphone = "";
			gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress = "";
			gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress = "";
			gxTv_SdtCreateLocationData_Step1_Customerlocationdescription = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationname;
		 

		protected short gxTv_SdtCreateLocationData_Step1_Customerlocationid;
		 

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationemail;
		 

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationphone;
		 

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationpostaladdress;
		 

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationvisitingaddress;
		 

		protected string gxTv_SdtCreateLocationData_Step1_Customerlocationdescription;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateLocationData.Step1", Namespace="Comforta2")]
	public class SdtCreateLocationData_Step1_RESTInterface : GxGenericCollectionItem<SdtCreateLocationData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateLocationData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtCreateLocationData_Step1_RESTInterface( SdtCreateLocationData_Step1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerLocationName", Order=0)]
		public  string gxTpr_Customerlocationname
		{
			get { 
				return sdt.gxTpr_Customerlocationname;

			}
			set { 
				 sdt.gxTpr_Customerlocationname = value;
			}
		}

		[DataMember(Name="CustomerLocationId", Order=1)]
		public short gxTpr_Customerlocationid
		{
			get { 
				return sdt.gxTpr_Customerlocationid;

			}
			set { 
				sdt.gxTpr_Customerlocationid = value;
			}
		}

		[DataMember(Name="CustomerLocationEmail", Order=2)]
		public  string gxTpr_Customerlocationemail
		{
			get { 
				return sdt.gxTpr_Customerlocationemail;

			}
			set { 
				 sdt.gxTpr_Customerlocationemail = value;
			}
		}

		[DataMember(Name="CustomerLocationPhone", Order=3)]
		public  string gxTpr_Customerlocationphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerlocationphone);

			}
			set { 
				 sdt.gxTpr_Customerlocationphone = value;
			}
		}

		[DataMember(Name="CustomerLocationPostalAddress", Order=4)]
		public  string gxTpr_Customerlocationpostaladdress
		{
			get { 
				return sdt.gxTpr_Customerlocationpostaladdress;

			}
			set { 
				 sdt.gxTpr_Customerlocationpostaladdress = value;
			}
		}

		[DataMember(Name="CustomerLocationVisitingAddress", Order=5)]
		public  string gxTpr_Customerlocationvisitingaddress
		{
			get { 
				return sdt.gxTpr_Customerlocationvisitingaddress;

			}
			set { 
				 sdt.gxTpr_Customerlocationvisitingaddress = value;
			}
		}

		[DataMember(Name="CustomerLocationDescription", Order=6)]
		public  string gxTpr_Customerlocationdescription
		{
			get { 
				return sdt.gxTpr_Customerlocationdescription;

			}
			set { 
				 sdt.gxTpr_Customerlocationdescription = value;
			}
		}


		#endregion

		public SdtCreateLocationData_Step1 sdt
		{
			get { 
				return (SdtCreateLocationData_Step1)Sdt;
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
				sdt = new SdtCreateLocationData_Step1() ;
			}
		}
	}
	#endregion
}