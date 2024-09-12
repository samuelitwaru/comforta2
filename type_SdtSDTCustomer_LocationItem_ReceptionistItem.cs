/*
				   File: type_SdtSDTCustomer_LocationItem_ReceptionistItem
			Description: Receptionist
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
	[XmlRoot(ElementName="SDTCustomer.LocationItem.ReceptionistItem")]
	[XmlType(TypeName="SDTCustomer.LocationItem.ReceptionistItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtSDTCustomer_LocationItem_ReceptionistItem : GxUserType
	{
		public SdtSDTCustomer_LocationItem_ReceptionistItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgivenname = "";

			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistlastname = "";

			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistinitials = "";

			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistemail = "";

			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistaddress = "";

			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistphone = "";

			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgamguid = "";

		}

		public SdtSDTCustomer_LocationItem_ReceptionistItem(IGxContext context)
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
			AddObjectProperty("CustomerLocationReceptionistId", gxTpr_Customerlocationreceptionistid, false);


			AddObjectProperty("CustomerLocationReceptionistGivenName", gxTpr_Customerlocationreceptionistgivenname, false);


			AddObjectProperty("CustomerLocationReceptionistLastName", gxTpr_Customerlocationreceptionistlastname, false);


			AddObjectProperty("CustomerLocationReceptionistInitials", gxTpr_Customerlocationreceptionistinitials, false);


			AddObjectProperty("CustomerLocationReceptionistEmail", gxTpr_Customerlocationreceptionistemail, false);


			AddObjectProperty("CustomerLocationReceptionistAddress", gxTpr_Customerlocationreceptionistaddress, false);


			AddObjectProperty("CustomerLocationReceptionistPhone", gxTpr_Customerlocationreceptionistphone, false);


			AddObjectProperty("CustomerLocationReceptionistGAMGUID", gxTpr_Customerlocationreceptionistgamguid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerLocationReceptionistId")]
		[XmlElement(ElementName="CustomerLocationReceptionistId")]
		public short gxTpr_Customerlocationreceptionistid
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistid; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistid = value;
				SetDirty("Customerlocationreceptionistid");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistGivenName")]
		[XmlElement(ElementName="CustomerLocationReceptionistGivenName")]
		public string gxTpr_Customerlocationreceptionistgivenname
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgivenname; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgivenname = value;
				SetDirty("Customerlocationreceptionistgivenname");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistLastName")]
		[XmlElement(ElementName="CustomerLocationReceptionistLastName")]
		public string gxTpr_Customerlocationreceptionistlastname
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistlastname; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistlastname = value;
				SetDirty("Customerlocationreceptionistlastname");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistInitials")]
		[XmlElement(ElementName="CustomerLocationReceptionistInitials")]
		public string gxTpr_Customerlocationreceptionistinitials
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistinitials; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistinitials = value;
				SetDirty("Customerlocationreceptionistinitials");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistEmail")]
		[XmlElement(ElementName="CustomerLocationReceptionistEmail")]
		public string gxTpr_Customerlocationreceptionistemail
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistemail; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistemail = value;
				SetDirty("Customerlocationreceptionistemail");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistAddress")]
		[XmlElement(ElementName="CustomerLocationReceptionistAddress")]
		public string gxTpr_Customerlocationreceptionistaddress
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistaddress; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistaddress = value;
				SetDirty("Customerlocationreceptionistaddress");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistPhone")]
		[XmlElement(ElementName="CustomerLocationReceptionistPhone")]
		public string gxTpr_Customerlocationreceptionistphone
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistphone; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistphone = value;
				SetDirty("Customerlocationreceptionistphone");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistGAMGUID")]
		[XmlElement(ElementName="CustomerLocationReceptionistGAMGUID")]
		public string gxTpr_Customerlocationreceptionistgamguid
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgamguid; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgamguid = value;
				SetDirty("Customerlocationreceptionistgamguid");
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
			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgivenname = "";
			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistlastname = "";
			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistinitials = "";
			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistemail = "";
			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistaddress = "";
			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistphone = "";
			gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgamguid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistid;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgivenname;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistlastname;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistinitials;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistemail;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistaddress;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistphone;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_ReceptionistItem_Customerlocationreceptionistgamguid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTCustomer.LocationItem.ReceptionistItem", Namespace="Comforta2")]
	public class SdtSDTCustomer_LocationItem_ReceptionistItem_RESTInterface : GxGenericCollectionItem<SdtSDTCustomer_LocationItem_ReceptionistItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCustomer_LocationItem_ReceptionistItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCustomer_LocationItem_ReceptionistItem_RESTInterface( SdtSDTCustomer_LocationItem_ReceptionistItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerLocationReceptionistId", Order=0)]
		public short gxTpr_Customerlocationreceptionistid
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistid;

			}
			set { 
				sdt.gxTpr_Customerlocationreceptionistid = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistGivenName", Order=1)]
		public  string gxTpr_Customerlocationreceptionistgivenname
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistgivenname;

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistgivenname = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistLastName", Order=2)]
		public  string gxTpr_Customerlocationreceptionistlastname
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistlastname;

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistlastname = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistInitials", Order=3)]
		public  string gxTpr_Customerlocationreceptionistinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerlocationreceptionistinitials);

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistinitials = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistEmail", Order=4)]
		public  string gxTpr_Customerlocationreceptionistemail
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistemail;

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistemail = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistAddress", Order=5)]
		public  string gxTpr_Customerlocationreceptionistaddress
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistaddress;

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistaddress = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistPhone", Order=6)]
		public  string gxTpr_Customerlocationreceptionistphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerlocationreceptionistphone);

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistphone = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistGAMGUID", Order=7)]
		public  string gxTpr_Customerlocationreceptionistgamguid
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistgamguid;

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistgamguid = value;
			}
		}


		#endregion

		public SdtSDTCustomer_LocationItem_ReceptionistItem sdt
		{
			get { 
				return (SdtSDTCustomer_LocationItem_ReceptionistItem)Sdt;
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
				sdt = new SdtSDTCustomer_LocationItem_ReceptionistItem() ;
			}
		}
	}
	#endregion
}