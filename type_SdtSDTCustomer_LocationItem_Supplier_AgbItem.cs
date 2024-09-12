/*
				   File: type_SdtSDTCustomer_LocationItem_Supplier_AgbItem
			Description: Supplier_Agb
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
	[XmlRoot(ElementName="SDTCustomer.LocationItem.Supplier_AgbItem")]
	[XmlType(TypeName="SDTCustomer.LocationItem.Supplier_AgbItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtSDTCustomer_LocationItem_Supplier_AgbItem : GxUserType
	{
		public SdtSDTCustomer_LocationItem_Supplier_AgbItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbnumber = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbname = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbkvknumber = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbvisitingaddress = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbpostaladdress = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbemail = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbphone = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbcontactname = "";

		}

		public SdtSDTCustomer_LocationItem_Supplier_AgbItem(IGxContext context)
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
			AddObjectProperty("Supplier_AgbId", gxTpr_Supplier_agbid, false);


			AddObjectProperty("Supplier_AgbNumber", gxTpr_Supplier_agbnumber, false);


			AddObjectProperty("Supplier_AgbName", gxTpr_Supplier_agbname, false);


			AddObjectProperty("Supplier_AgbKvkNumber", gxTpr_Supplier_agbkvknumber, false);


			AddObjectProperty("Supplier_AgbVisitingAddress", gxTpr_Supplier_agbvisitingaddress, false);


			AddObjectProperty("Supplier_AgbPostalAddress", gxTpr_Supplier_agbpostaladdress, false);


			AddObjectProperty("Supplier_AgbEmail", gxTpr_Supplier_agbemail, false);


			AddObjectProperty("Supplier_AgbPhone", gxTpr_Supplier_agbphone, false);


			AddObjectProperty("Supplier_AgbContactName", gxTpr_Supplier_agbcontactname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Supplier_AgbId")]
		[XmlElement(ElementName="Supplier_AgbId")]
		public short gxTpr_Supplier_agbid
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbid; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbid = value;
				SetDirty("Supplier_agbid");
			}
		}




		[SoapElement(ElementName="Supplier_AgbNumber")]
		[XmlElement(ElementName="Supplier_AgbNumber")]
		public string gxTpr_Supplier_agbnumber
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbnumber; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbnumber = value;
				SetDirty("Supplier_agbnumber");
			}
		}




		[SoapElement(ElementName="Supplier_AgbName")]
		[XmlElement(ElementName="Supplier_AgbName")]
		public string gxTpr_Supplier_agbname
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbname; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbname = value;
				SetDirty("Supplier_agbname");
			}
		}




		[SoapElement(ElementName="Supplier_AgbKvkNumber")]
		[XmlElement(ElementName="Supplier_AgbKvkNumber")]
		public string gxTpr_Supplier_agbkvknumber
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbkvknumber; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbkvknumber = value;
				SetDirty("Supplier_agbkvknumber");
			}
		}




		[SoapElement(ElementName="Supplier_AgbVisitingAddress")]
		[XmlElement(ElementName="Supplier_AgbVisitingAddress")]
		public string gxTpr_Supplier_agbvisitingaddress
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbvisitingaddress; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbvisitingaddress = value;
				SetDirty("Supplier_agbvisitingaddress");
			}
		}




		[SoapElement(ElementName="Supplier_AgbPostalAddress")]
		[XmlElement(ElementName="Supplier_AgbPostalAddress")]
		public string gxTpr_Supplier_agbpostaladdress
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbpostaladdress; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbpostaladdress = value;
				SetDirty("Supplier_agbpostaladdress");
			}
		}




		[SoapElement(ElementName="Supplier_AgbEmail")]
		[XmlElement(ElementName="Supplier_AgbEmail")]
		public string gxTpr_Supplier_agbemail
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbemail; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbemail = value;
				SetDirty("Supplier_agbemail");
			}
		}




		[SoapElement(ElementName="Supplier_AgbPhone")]
		[XmlElement(ElementName="Supplier_AgbPhone")]
		public string gxTpr_Supplier_agbphone
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbphone; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbphone = value;
				SetDirty("Supplier_agbphone");
			}
		}




		[SoapElement(ElementName="Supplier_AgbContactName")]
		[XmlElement(ElementName="Supplier_AgbContactName")]
		public string gxTpr_Supplier_agbcontactname
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbcontactname; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbcontactname = value;
				SetDirty("Supplier_agbcontactname");
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
			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbnumber = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbname = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbkvknumber = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbvisitingaddress = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbpostaladdress = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbemail = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbphone = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbcontactname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbid;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbnumber;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbname;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbkvknumber;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbvisitingaddress;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbpostaladdress;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbemail;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbphone;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_AgbItem_Supplier_agbcontactname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTCustomer.LocationItem.Supplier_AgbItem", Namespace="Comforta2")]
	public class SdtSDTCustomer_LocationItem_Supplier_AgbItem_RESTInterface : GxGenericCollectionItem<SdtSDTCustomer_LocationItem_Supplier_AgbItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCustomer_LocationItem_Supplier_AgbItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCustomer_LocationItem_Supplier_AgbItem_RESTInterface( SdtSDTCustomer_LocationItem_Supplier_AgbItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Supplier_AgbId", Order=0)]
		public short gxTpr_Supplier_agbid
		{
			get { 
				return sdt.gxTpr_Supplier_agbid;

			}
			set { 
				sdt.gxTpr_Supplier_agbid = value;
			}
		}

		[DataMember(Name="Supplier_AgbNumber", Order=1)]
		public  string gxTpr_Supplier_agbnumber
		{
			get { 
				return sdt.gxTpr_Supplier_agbnumber;

			}
			set { 
				 sdt.gxTpr_Supplier_agbnumber = value;
			}
		}

		[DataMember(Name="Supplier_AgbName", Order=2)]
		public  string gxTpr_Supplier_agbname
		{
			get { 
				return sdt.gxTpr_Supplier_agbname;

			}
			set { 
				 sdt.gxTpr_Supplier_agbname = value;
			}
		}

		[DataMember(Name="Supplier_AgbKvkNumber", Order=3)]
		public  string gxTpr_Supplier_agbkvknumber
		{
			get { 
				return sdt.gxTpr_Supplier_agbkvknumber;

			}
			set { 
				 sdt.gxTpr_Supplier_agbkvknumber = value;
			}
		}

		[DataMember(Name="Supplier_AgbVisitingAddress", Order=4)]
		public  string gxTpr_Supplier_agbvisitingaddress
		{
			get { 
				return sdt.gxTpr_Supplier_agbvisitingaddress;

			}
			set { 
				 sdt.gxTpr_Supplier_agbvisitingaddress = value;
			}
		}

		[DataMember(Name="Supplier_AgbPostalAddress", Order=5)]
		public  string gxTpr_Supplier_agbpostaladdress
		{
			get { 
				return sdt.gxTpr_Supplier_agbpostaladdress;

			}
			set { 
				 sdt.gxTpr_Supplier_agbpostaladdress = value;
			}
		}

		[DataMember(Name="Supplier_AgbEmail", Order=6)]
		public  string gxTpr_Supplier_agbemail
		{
			get { 
				return sdt.gxTpr_Supplier_agbemail;

			}
			set { 
				 sdt.gxTpr_Supplier_agbemail = value;
			}
		}

		[DataMember(Name="Supplier_AgbPhone", Order=7)]
		public  string gxTpr_Supplier_agbphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Supplier_agbphone);

			}
			set { 
				 sdt.gxTpr_Supplier_agbphone = value;
			}
		}

		[DataMember(Name="Supplier_AgbContactName", Order=8)]
		public  string gxTpr_Supplier_agbcontactname
		{
			get { 
				return sdt.gxTpr_Supplier_agbcontactname;

			}
			set { 
				 sdt.gxTpr_Supplier_agbcontactname = value;
			}
		}


		#endregion

		public SdtSDTCustomer_LocationItem_Supplier_AgbItem sdt
		{
			get { 
				return (SdtSDTCustomer_LocationItem_Supplier_AgbItem)Sdt;
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
				sdt = new SdtSDTCustomer_LocationItem_Supplier_AgbItem() ;
			}
		}
	}
	#endregion
}