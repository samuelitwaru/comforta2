/*
				   File: type_SdtResidentDetails_Customer
			Description: Customer
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
	[XmlRoot(ElementName="ResidentDetails.Customer")]
	[XmlType(TypeName="ResidentDetails.Customer" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtResidentDetails_Customer : GxUserType
	{
		public SdtResidentDetails_Customer( )
		{
			/* Constructor for serialization */
			gxTv_SdtResidentDetails_Customer_Customerkvknumber = "";

			gxTv_SdtResidentDetails_Customer_Customername = "";

			gxTv_SdtResidentDetails_Customer_Customerpostaladdress = "";

			gxTv_SdtResidentDetails_Customer_Customeremail = "";

			gxTv_SdtResidentDetails_Customer_Customervisitingaddress = "";

			gxTv_SdtResidentDetails_Customer_Customerphone = "";

			gxTv_SdtResidentDetails_Customer_Customervatnumber = "";

			gxTv_SdtResidentDetails_Customer_Customertypename = "";

		}

		public SdtResidentDetails_Customer(IGxContext context)
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
			AddObjectProperty("CustomerId", gxTpr_Customerid, false);


			AddObjectProperty("CustomerKvkNumber", gxTpr_Customerkvknumber, false);


			AddObjectProperty("CustomerName", gxTpr_Customername, false);


			AddObjectProperty("CustomerPostalAddress", gxTpr_Customerpostaladdress, false);


			AddObjectProperty("CustomerEmail", gxTpr_Customeremail, false);


			AddObjectProperty("CustomerVisitingAddress", gxTpr_Customervisitingaddress, false);


			AddObjectProperty("CustomerPhone", gxTpr_Customerphone, false);


			AddObjectProperty("CustomerVatNumber", gxTpr_Customervatnumber, false);


			AddObjectProperty("CustomerTypeId", gxTpr_Customertypeid, false);


			AddObjectProperty("CustomerTypeName", gxTpr_Customertypename, false);

			if (gxTpr_Location != null)
			{
				AddObjectProperty("Location", gxTpr_Location, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerId")]
		[XmlElement(ElementName="CustomerId")]
		public short gxTpr_Customerid
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customerid; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customerid = value;
				SetDirty("Customerid");
			}
		}




		[SoapElement(ElementName="CustomerKvkNumber")]
		[XmlElement(ElementName="CustomerKvkNumber")]
		public string gxTpr_Customerkvknumber
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customerkvknumber; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customerkvknumber = value;
				SetDirty("Customerkvknumber");
			}
		}




		[SoapElement(ElementName="CustomerName")]
		[XmlElement(ElementName="CustomerName")]
		public string gxTpr_Customername
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customername; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customername = value;
				SetDirty("Customername");
			}
		}




		[SoapElement(ElementName="CustomerPostalAddress")]
		[XmlElement(ElementName="CustomerPostalAddress")]
		public string gxTpr_Customerpostaladdress
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customerpostaladdress; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customerpostaladdress = value;
				SetDirty("Customerpostaladdress");
			}
		}




		[SoapElement(ElementName="CustomerEmail")]
		[XmlElement(ElementName="CustomerEmail")]
		public string gxTpr_Customeremail
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customeremail; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customeremail = value;
				SetDirty("Customeremail");
			}
		}




		[SoapElement(ElementName="CustomerVisitingAddress")]
		[XmlElement(ElementName="CustomerVisitingAddress")]
		public string gxTpr_Customervisitingaddress
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customervisitingaddress; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customervisitingaddress = value;
				SetDirty("Customervisitingaddress");
			}
		}




		[SoapElement(ElementName="CustomerPhone")]
		[XmlElement(ElementName="CustomerPhone")]
		public string gxTpr_Customerphone
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customerphone; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customerphone = value;
				SetDirty("Customerphone");
			}
		}




		[SoapElement(ElementName="CustomerVatNumber")]
		[XmlElement(ElementName="CustomerVatNumber")]
		public string gxTpr_Customervatnumber
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customervatnumber; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customervatnumber = value;
				SetDirty("Customervatnumber");
			}
		}




		[SoapElement(ElementName="CustomerTypeId")]
		[XmlElement(ElementName="CustomerTypeId")]
		public short gxTpr_Customertypeid
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customertypeid; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customertypeid = value;
				SetDirty("Customertypeid");
			}
		}




		[SoapElement(ElementName="CustomerTypeName")]
		[XmlElement(ElementName="CustomerTypeName")]
		public string gxTpr_Customertypename
		{
			get {
				return gxTv_SdtResidentDetails_Customer_Customertypename; 
			}
			set {
				gxTv_SdtResidentDetails_Customer_Customertypename = value;
				SetDirty("Customertypename");
			}
		}



		[SoapElement(ElementName="Location" )]
		[XmlElement(ElementName="Location" )]
		public SdtResidentDetails_Customer_Location gxTpr_Location
		{
			get {
				if ( gxTv_SdtResidentDetails_Customer_Location == null )
				{
					gxTv_SdtResidentDetails_Customer_Location = new SdtResidentDetails_Customer_Location(context);
				}
				return gxTv_SdtResidentDetails_Customer_Location;
			}
			set {
				gxTv_SdtResidentDetails_Customer_Location = value;
				SetDirty("Location");
			}

		}

		public void gxTv_SdtResidentDetails_Customer_Location_SetNull()
		{
			gxTv_SdtResidentDetails_Customer_Location = null;
		}

		public bool gxTv_SdtResidentDetails_Customer_Location_IsNull()
		{
			return gxTv_SdtResidentDetails_Customer_Location == null;
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
			gxTv_SdtResidentDetails_Customer_Customerkvknumber = "";
			gxTv_SdtResidentDetails_Customer_Customername = "";
			gxTv_SdtResidentDetails_Customer_Customerpostaladdress = "";
			gxTv_SdtResidentDetails_Customer_Customeremail = "";
			gxTv_SdtResidentDetails_Customer_Customervisitingaddress = "";
			gxTv_SdtResidentDetails_Customer_Customerphone = "";
			gxTv_SdtResidentDetails_Customer_Customervatnumber = "";

			gxTv_SdtResidentDetails_Customer_Customertypename = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtResidentDetails_Customer_Customerid;
		 

		protected string gxTv_SdtResidentDetails_Customer_Customerkvknumber;
		 

		protected string gxTv_SdtResidentDetails_Customer_Customername;
		 

		protected string gxTv_SdtResidentDetails_Customer_Customerpostaladdress;
		 

		protected string gxTv_SdtResidentDetails_Customer_Customeremail;
		 

		protected string gxTv_SdtResidentDetails_Customer_Customervisitingaddress;
		 

		protected string gxTv_SdtResidentDetails_Customer_Customerphone;
		 

		protected string gxTv_SdtResidentDetails_Customer_Customervatnumber;
		 

		protected short gxTv_SdtResidentDetails_Customer_Customertypeid;
		 

		protected string gxTv_SdtResidentDetails_Customer_Customertypename;
		 

		protected SdtResidentDetails_Customer_Location gxTv_SdtResidentDetails_Customer_Location = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ResidentDetails.Customer", Namespace="Comforta2")]
	public class SdtResidentDetails_Customer_RESTInterface : GxGenericCollectionItem<SdtResidentDetails_Customer>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResidentDetails_Customer_RESTInterface( ) : base()
		{	
		}

		public SdtResidentDetails_Customer_RESTInterface( SdtResidentDetails_Customer psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerId", Order=0)]
		public short gxTpr_Customerid
		{
			get { 
				return sdt.gxTpr_Customerid;

			}
			set { 
				sdt.gxTpr_Customerid = value;
			}
		}

		[DataMember(Name="CustomerKvkNumber", Order=1)]
		public  string gxTpr_Customerkvknumber
		{
			get { 
				return sdt.gxTpr_Customerkvknumber;

			}
			set { 
				 sdt.gxTpr_Customerkvknumber = value;
			}
		}

		[DataMember(Name="CustomerName", Order=2)]
		public  string gxTpr_Customername
		{
			get { 
				return sdt.gxTpr_Customername;

			}
			set { 
				 sdt.gxTpr_Customername = value;
			}
		}

		[DataMember(Name="CustomerPostalAddress", Order=3)]
		public  string gxTpr_Customerpostaladdress
		{
			get { 
				return sdt.gxTpr_Customerpostaladdress;

			}
			set { 
				 sdt.gxTpr_Customerpostaladdress = value;
			}
		}

		[DataMember(Name="CustomerEmail", Order=4)]
		public  string gxTpr_Customeremail
		{
			get { 
				return sdt.gxTpr_Customeremail;

			}
			set { 
				 sdt.gxTpr_Customeremail = value;
			}
		}

		[DataMember(Name="CustomerVisitingAddress", Order=5)]
		public  string gxTpr_Customervisitingaddress
		{
			get { 
				return sdt.gxTpr_Customervisitingaddress;

			}
			set { 
				 sdt.gxTpr_Customervisitingaddress = value;
			}
		}

		[DataMember(Name="CustomerPhone", Order=6)]
		public  string gxTpr_Customerphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerphone);

			}
			set { 
				 sdt.gxTpr_Customerphone = value;
			}
		}

		[DataMember(Name="CustomerVatNumber", Order=7)]
		public  string gxTpr_Customervatnumber
		{
			get { 
				return sdt.gxTpr_Customervatnumber;

			}
			set { 
				 sdt.gxTpr_Customervatnumber = value;
			}
		}

		[DataMember(Name="CustomerTypeId", Order=8)]
		public short gxTpr_Customertypeid
		{
			get { 
				return sdt.gxTpr_Customertypeid;

			}
			set { 
				sdt.gxTpr_Customertypeid = value;
			}
		}

		[DataMember(Name="CustomerTypeName", Order=9)]
		public  string gxTpr_Customertypename
		{
			get { 
				return sdt.gxTpr_Customertypename;

			}
			set { 
				 sdt.gxTpr_Customertypename = value;
			}
		}

		[DataMember(Name="Location", Order=10)]
		public SdtResidentDetails_Customer_Location_RESTInterface gxTpr_Location
		{
			get {
				return new SdtResidentDetails_Customer_Location_RESTInterface(sdt.gxTpr_Location);

			}

			set {
				sdt.gxTpr_Location = value.sdt;
			}

		}


		#endregion

		public SdtResidentDetails_Customer sdt
		{
			get { 
				return (SdtResidentDetails_Customer)Sdt;
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
				sdt = new SdtResidentDetails_Customer() ;
			}
		}
	}
	#endregion
}