/*
				   File: type_SdtLocationReceptionistSDT
			Description: LocationReceptionistSDT
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
	[XmlRoot(ElementName="LocationReceptionistSDT")]
	[XmlType(TypeName="LocationReceptionistSDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtLocationReceptionistSDT : GxUserType
	{
		public SdtLocationReceptionistSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationReceptionistSDT_Locationreceptionistgivenname = "";

			gxTv_SdtLocationReceptionistSDT_Locationreceptionistlastname = "";

			gxTv_SdtLocationReceptionistSDT_Locationreceptionistinitials = "";

			gxTv_SdtLocationReceptionistSDT_Locationreceptionistemail = "";

			gxTv_SdtLocationReceptionistSDT_Locationreceptionistaddress = "";

			gxTv_SdtLocationReceptionistSDT_Locationreceptionistphone = "";

		}

		public SdtLocationReceptionistSDT(IGxContext context)
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
			AddObjectProperty("LocationReceptionistId", gxTpr_Locationreceptionistid, false);


			AddObjectProperty("LocationReceptionistGivenName", gxTpr_Locationreceptionistgivenname, false);


			AddObjectProperty("LocationReceptionistLastName", gxTpr_Locationreceptionistlastname, false);


			AddObjectProperty("LocationReceptionistInitials", gxTpr_Locationreceptionistinitials, false);


			AddObjectProperty("LocationReceptionistEmail", gxTpr_Locationreceptionistemail, false);


			AddObjectProperty("LocationReceptionistAddress", gxTpr_Locationreceptionistaddress, false);


			AddObjectProperty("LocationReceptionistPhone", gxTpr_Locationreceptionistphone, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LocationReceptionistId")]
		[XmlElement(ElementName="LocationReceptionistId")]
		public short gxTpr_Locationreceptionistid
		{
			get {
				return gxTv_SdtLocationReceptionistSDT_Locationreceptionistid; 
			}
			set {
				gxTv_SdtLocationReceptionistSDT_Locationreceptionistid = value;
				SetDirty("Locationreceptionistid");
			}
		}




		[SoapElement(ElementName="LocationReceptionistGivenName")]
		[XmlElement(ElementName="LocationReceptionistGivenName")]
		public string gxTpr_Locationreceptionistgivenname
		{
			get {
				return gxTv_SdtLocationReceptionistSDT_Locationreceptionistgivenname; 
			}
			set {
				gxTv_SdtLocationReceptionistSDT_Locationreceptionistgivenname = value;
				SetDirty("Locationreceptionistgivenname");
			}
		}




		[SoapElement(ElementName="LocationReceptionistLastName")]
		[XmlElement(ElementName="LocationReceptionistLastName")]
		public string gxTpr_Locationreceptionistlastname
		{
			get {
				return gxTv_SdtLocationReceptionistSDT_Locationreceptionistlastname; 
			}
			set {
				gxTv_SdtLocationReceptionistSDT_Locationreceptionistlastname = value;
				SetDirty("Locationreceptionistlastname");
			}
		}




		[SoapElement(ElementName="LocationReceptionistInitials")]
		[XmlElement(ElementName="LocationReceptionistInitials")]
		public string gxTpr_Locationreceptionistinitials
		{
			get {
				return gxTv_SdtLocationReceptionistSDT_Locationreceptionistinitials; 
			}
			set {
				gxTv_SdtLocationReceptionistSDT_Locationreceptionistinitials = value;
				SetDirty("Locationreceptionistinitials");
			}
		}




		[SoapElement(ElementName="LocationReceptionistEmail")]
		[XmlElement(ElementName="LocationReceptionistEmail")]
		public string gxTpr_Locationreceptionistemail
		{
			get {
				return gxTv_SdtLocationReceptionistSDT_Locationreceptionistemail; 
			}
			set {
				gxTv_SdtLocationReceptionistSDT_Locationreceptionistemail = value;
				SetDirty("Locationreceptionistemail");
			}
		}




		[SoapElement(ElementName="LocationReceptionistAddress")]
		[XmlElement(ElementName="LocationReceptionistAddress")]
		public string gxTpr_Locationreceptionistaddress
		{
			get {
				return gxTv_SdtLocationReceptionistSDT_Locationreceptionistaddress; 
			}
			set {
				gxTv_SdtLocationReceptionistSDT_Locationreceptionistaddress = value;
				SetDirty("Locationreceptionistaddress");
			}
		}




		[SoapElement(ElementName="LocationReceptionistPhone")]
		[XmlElement(ElementName="LocationReceptionistPhone")]
		public string gxTpr_Locationreceptionistphone
		{
			get {
				return gxTv_SdtLocationReceptionistSDT_Locationreceptionistphone; 
			}
			set {
				gxTv_SdtLocationReceptionistSDT_Locationreceptionistphone = value;
				SetDirty("Locationreceptionistphone");
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
			gxTv_SdtLocationReceptionistSDT_Locationreceptionistgivenname = "";
			gxTv_SdtLocationReceptionistSDT_Locationreceptionistlastname = "";
			gxTv_SdtLocationReceptionistSDT_Locationreceptionistinitials = "";
			gxTv_SdtLocationReceptionistSDT_Locationreceptionistemail = "";
			gxTv_SdtLocationReceptionistSDT_Locationreceptionistaddress = "";
			gxTv_SdtLocationReceptionistSDT_Locationreceptionistphone = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtLocationReceptionistSDT_Locationreceptionistid;
		 

		protected string gxTv_SdtLocationReceptionistSDT_Locationreceptionistgivenname;
		 

		protected string gxTv_SdtLocationReceptionistSDT_Locationreceptionistlastname;
		 

		protected string gxTv_SdtLocationReceptionistSDT_Locationreceptionistinitials;
		 

		protected string gxTv_SdtLocationReceptionistSDT_Locationreceptionistemail;
		 

		protected string gxTv_SdtLocationReceptionistSDT_Locationreceptionistaddress;
		 

		protected string gxTv_SdtLocationReceptionistSDT_Locationreceptionistphone;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"LocationReceptionistSDT", Namespace="Comforta2")]
	public class SdtLocationReceptionistSDT_RESTInterface : GxGenericCollectionItem<SdtLocationReceptionistSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationReceptionistSDT_RESTInterface( ) : base()
		{	
		}

		public SdtLocationReceptionistSDT_RESTInterface( SdtLocationReceptionistSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LocationReceptionistId", Order=0)]
		public short gxTpr_Locationreceptionistid
		{
			get { 
				return sdt.gxTpr_Locationreceptionistid;

			}
			set { 
				sdt.gxTpr_Locationreceptionistid = value;
			}
		}

		[DataMember(Name="LocationReceptionistGivenName", Order=1)]
		public  string gxTpr_Locationreceptionistgivenname
		{
			get { 
				return sdt.gxTpr_Locationreceptionistgivenname;

			}
			set { 
				 sdt.gxTpr_Locationreceptionistgivenname = value;
			}
		}

		[DataMember(Name="LocationReceptionistLastName", Order=2)]
		public  string gxTpr_Locationreceptionistlastname
		{
			get { 
				return sdt.gxTpr_Locationreceptionistlastname;

			}
			set { 
				 sdt.gxTpr_Locationreceptionistlastname = value;
			}
		}

		[DataMember(Name="LocationReceptionistInitials", Order=3)]
		public  string gxTpr_Locationreceptionistinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Locationreceptionistinitials);

			}
			set { 
				 sdt.gxTpr_Locationreceptionistinitials = value;
			}
		}

		[DataMember(Name="LocationReceptionistEmail", Order=4)]
		public  string gxTpr_Locationreceptionistemail
		{
			get { 
				return sdt.gxTpr_Locationreceptionistemail;

			}
			set { 
				 sdt.gxTpr_Locationreceptionistemail = value;
			}
		}

		[DataMember(Name="LocationReceptionistAddress", Order=5)]
		public  string gxTpr_Locationreceptionistaddress
		{
			get { 
				return sdt.gxTpr_Locationreceptionistaddress;

			}
			set { 
				 sdt.gxTpr_Locationreceptionistaddress = value;
			}
		}

		[DataMember(Name="LocationReceptionistPhone", Order=6)]
		public  string gxTpr_Locationreceptionistphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Locationreceptionistphone);

			}
			set { 
				 sdt.gxTpr_Locationreceptionistphone = value;
			}
		}


		#endregion

		public SdtLocationReceptionistSDT sdt
		{
			get { 
				return (SdtLocationReceptionistSDT)Sdt;
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
				sdt = new SdtLocationReceptionistSDT() ;
			}
		}
	}
	#endregion
}