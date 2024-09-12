/*
				   File: type_SdtResidentDetails_ResidentNetworkIndividualsItem
			Description: ResidentNetworkIndividuals
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
	[XmlRoot(ElementName="ResidentDetails.ResidentNetworkIndividualsItem")]
	[XmlType(TypeName="ResidentDetails.ResidentNetworkIndividualsItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtResidentDetails_ResidentNetworkIndividualsItem : GxUserType
	{
		public SdtResidentDetails_ResidentNetworkIndividualsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualbsnnumber = "";

			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgivenname = "";

			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividuallastname = "";

			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualemail = "";

			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualphone = "";

			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualaddress = "";

			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgender = "";

		}

		public SdtResidentDetails_ResidentNetworkIndividualsItem(IGxContext context)
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
			AddObjectProperty("ResidentINIndividualId", gxTpr_Residentinindividualid, false);


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

		[SoapElement(ElementName="ResidentINIndividualId")]
		[XmlElement(ElementName="ResidentINIndividualId")]
		public short gxTpr_Residentinindividualid
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualid; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualid = value;
				SetDirty("Residentinindividualid");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualBsnNumber")]
		[XmlElement(ElementName="ResidentINIndividualBsnNumber")]
		public string gxTpr_Residentinindividualbsnnumber
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualbsnnumber; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualbsnnumber = value;
				SetDirty("Residentinindividualbsnnumber");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualGivenName")]
		[XmlElement(ElementName="ResidentINIndividualGivenName")]
		public string gxTpr_Residentinindividualgivenname
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgivenname; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgivenname = value;
				SetDirty("Residentinindividualgivenname");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualLastName")]
		[XmlElement(ElementName="ResidentINIndividualLastName")]
		public string gxTpr_Residentinindividuallastname
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividuallastname; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividuallastname = value;
				SetDirty("Residentinindividuallastname");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualEmail")]
		[XmlElement(ElementName="ResidentINIndividualEmail")]
		public string gxTpr_Residentinindividualemail
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualemail; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualemail = value;
				SetDirty("Residentinindividualemail");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualPhone")]
		[XmlElement(ElementName="ResidentINIndividualPhone")]
		public string gxTpr_Residentinindividualphone
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualphone; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualphone = value;
				SetDirty("Residentinindividualphone");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualAddress")]
		[XmlElement(ElementName="ResidentINIndividualAddress")]
		public string gxTpr_Residentinindividualaddress
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualaddress; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualaddress = value;
				SetDirty("Residentinindividualaddress");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualGender")]
		[XmlElement(ElementName="ResidentINIndividualGender")]
		public string gxTpr_Residentinindividualgender
		{
			get {
				return gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgender; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgender = value;
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
			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualbsnnumber = "";
			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgivenname = "";
			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividuallastname = "";
			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualemail = "";
			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualphone = "";
			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualaddress = "";
			gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgender = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualid;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualbsnnumber;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgivenname;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividuallastname;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualemail;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualphone;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualaddress;
		 

		protected string gxTv_SdtResidentDetails_ResidentNetworkIndividualsItem_Residentinindividualgender;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"ResidentDetails.ResidentNetworkIndividualsItem", Namespace="Comforta2")]
	public class SdtResidentDetails_ResidentNetworkIndividualsItem_RESTInterface : GxGenericCollectionItem<SdtResidentDetails_ResidentNetworkIndividualsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResidentDetails_ResidentNetworkIndividualsItem_RESTInterface( ) : base()
		{	
		}

		public SdtResidentDetails_ResidentNetworkIndividualsItem_RESTInterface( SdtResidentDetails_ResidentNetworkIndividualsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentINIndividualId", Order=0)]
		public short gxTpr_Residentinindividualid
		{
			get { 
				return sdt.gxTpr_Residentinindividualid;

			}
			set { 
				sdt.gxTpr_Residentinindividualid = value;
			}
		}

		[DataMember(Name="ResidentINIndividualBsnNumber", Order=1)]
		public  string gxTpr_Residentinindividualbsnnumber
		{
			get { 
				return sdt.gxTpr_Residentinindividualbsnnumber;

			}
			set { 
				 sdt.gxTpr_Residentinindividualbsnnumber = value;
			}
		}

		[DataMember(Name="ResidentINIndividualGivenName", Order=2)]
		public  string gxTpr_Residentinindividualgivenname
		{
			get { 
				return sdt.gxTpr_Residentinindividualgivenname;

			}
			set { 
				 sdt.gxTpr_Residentinindividualgivenname = value;
			}
		}

		[DataMember(Name="ResidentINIndividualLastName", Order=3)]
		public  string gxTpr_Residentinindividuallastname
		{
			get { 
				return sdt.gxTpr_Residentinindividuallastname;

			}
			set { 
				 sdt.gxTpr_Residentinindividuallastname = value;
			}
		}

		[DataMember(Name="ResidentINIndividualEmail", Order=4)]
		public  string gxTpr_Residentinindividualemail
		{
			get { 
				return sdt.gxTpr_Residentinindividualemail;

			}
			set { 
				 sdt.gxTpr_Residentinindividualemail = value;
			}
		}

		[DataMember(Name="ResidentINIndividualPhone", Order=5)]
		public  string gxTpr_Residentinindividualphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentinindividualphone);

			}
			set { 
				 sdt.gxTpr_Residentinindividualphone = value;
			}
		}

		[DataMember(Name="ResidentINIndividualAddress", Order=6)]
		public  string gxTpr_Residentinindividualaddress
		{
			get { 
				return sdt.gxTpr_Residentinindividualaddress;

			}
			set { 
				 sdt.gxTpr_Residentinindividualaddress = value;
			}
		}

		[DataMember(Name="ResidentINIndividualGender", Order=7)]
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

		public SdtResidentDetails_ResidentNetworkIndividualsItem sdt
		{
			get { 
				return (SdtResidentDetails_ResidentNetworkIndividualsItem)Sdt;
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
				sdt = new SdtResidentDetails_ResidentNetworkIndividualsItem() ;
			}
		}
	}
	#endregion
}