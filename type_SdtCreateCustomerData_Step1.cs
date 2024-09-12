/*
				   File: type_SdtCreateCustomerData_Step1
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
	[XmlRoot(ElementName="CreateCustomerData.Step1")]
	[XmlType(TypeName="CreateCustomerData.Step1" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateCustomerData_Step1 : GxUserType
	{
		public SdtCreateCustomerData_Step1( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateCustomerData_Step1_Customerkvknumber = "";

			gxTv_SdtCreateCustomerData_Step1_Customername = "";

			gxTv_SdtCreateCustomerData_Step1_Customervatnumber = "";

			gxTv_SdtCreateCustomerData_Step1_Customeremail = "";

			gxTv_SdtCreateCustomerData_Step1_Customerphone = "";

			gxTv_SdtCreateCustomerData_Step1_Customerpostaladdress = "";

			gxTv_SdtCreateCustomerData_Step1_Customervisitingaddress = "";

		}

		public SdtCreateCustomerData_Step1(IGxContext context)
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


			AddObjectProperty("CustomerVatNumber", gxTpr_Customervatnumber, false);


			AddObjectProperty("CustomerTypeId", gxTpr_Customertypeid, false);


			AddObjectProperty("CustomerEmail", gxTpr_Customeremail, false);


			AddObjectProperty("CustomerPhone", gxTpr_Customerphone, false);


			AddObjectProperty("CustomerPostalAddress", gxTpr_Customerpostaladdress, false);


			AddObjectProperty("CustomerVisitingAddress", gxTpr_Customervisitingaddress, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerId")]
		[XmlElement(ElementName="CustomerId")]
		public short gxTpr_Customerid
		{
			get {
				return gxTv_SdtCreateCustomerData_Step1_Customerid; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step1_Customerid = value;
				SetDirty("Customerid");
			}
		}




		[SoapElement(ElementName="CustomerKvkNumber")]
		[XmlElement(ElementName="CustomerKvkNumber")]
		public string gxTpr_Customerkvknumber
		{
			get {
				return gxTv_SdtCreateCustomerData_Step1_Customerkvknumber; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step1_Customerkvknumber = value;
				SetDirty("Customerkvknumber");
			}
		}




		[SoapElement(ElementName="CustomerName")]
		[XmlElement(ElementName="CustomerName")]
		public string gxTpr_Customername
		{
			get {
				return gxTv_SdtCreateCustomerData_Step1_Customername; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step1_Customername = value;
				SetDirty("Customername");
			}
		}




		[SoapElement(ElementName="CustomerVatNumber")]
		[XmlElement(ElementName="CustomerVatNumber")]
		public string gxTpr_Customervatnumber
		{
			get {
				return gxTv_SdtCreateCustomerData_Step1_Customervatnumber; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step1_Customervatnumber = value;
				SetDirty("Customervatnumber");
			}
		}




		[SoapElement(ElementName="CustomerTypeId")]
		[XmlElement(ElementName="CustomerTypeId")]
		public short gxTpr_Customertypeid
		{
			get {
				return gxTv_SdtCreateCustomerData_Step1_Customertypeid; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step1_Customertypeid = value;
				SetDirty("Customertypeid");
			}
		}




		[SoapElement(ElementName="CustomerEmail")]
		[XmlElement(ElementName="CustomerEmail")]
		public string gxTpr_Customeremail
		{
			get {
				return gxTv_SdtCreateCustomerData_Step1_Customeremail; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step1_Customeremail = value;
				SetDirty("Customeremail");
			}
		}




		[SoapElement(ElementName="CustomerPhone")]
		[XmlElement(ElementName="CustomerPhone")]
		public string gxTpr_Customerphone
		{
			get {
				return gxTv_SdtCreateCustomerData_Step1_Customerphone; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step1_Customerphone = value;
				SetDirty("Customerphone");
			}
		}




		[SoapElement(ElementName="CustomerPostalAddress")]
		[XmlElement(ElementName="CustomerPostalAddress")]
		public string gxTpr_Customerpostaladdress
		{
			get {
				return gxTv_SdtCreateCustomerData_Step1_Customerpostaladdress; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step1_Customerpostaladdress = value;
				SetDirty("Customerpostaladdress");
			}
		}




		[SoapElement(ElementName="CustomerVisitingAddress")]
		[XmlElement(ElementName="CustomerVisitingAddress")]
		public string gxTpr_Customervisitingaddress
		{
			get {
				return gxTv_SdtCreateCustomerData_Step1_Customervisitingaddress; 
			}
			set {
				gxTv_SdtCreateCustomerData_Step1_Customervisitingaddress = value;
				SetDirty("Customervisitingaddress");
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
			gxTv_SdtCreateCustomerData_Step1_Customerkvknumber = "";
			gxTv_SdtCreateCustomerData_Step1_Customername = "";
			gxTv_SdtCreateCustomerData_Step1_Customervatnumber = "";

			gxTv_SdtCreateCustomerData_Step1_Customeremail = "";
			gxTv_SdtCreateCustomerData_Step1_Customerphone = "";
			gxTv_SdtCreateCustomerData_Step1_Customerpostaladdress = "";
			gxTv_SdtCreateCustomerData_Step1_Customervisitingaddress = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCreateCustomerData_Step1_Customerid;
		 

		protected string gxTv_SdtCreateCustomerData_Step1_Customerkvknumber;
		 

		protected string gxTv_SdtCreateCustomerData_Step1_Customername;
		 

		protected string gxTv_SdtCreateCustomerData_Step1_Customervatnumber;
		 

		protected short gxTv_SdtCreateCustomerData_Step1_Customertypeid;
		 

		protected string gxTv_SdtCreateCustomerData_Step1_Customeremail;
		 

		protected string gxTv_SdtCreateCustomerData_Step1_Customerphone;
		 

		protected string gxTv_SdtCreateCustomerData_Step1_Customerpostaladdress;
		 

		protected string gxTv_SdtCreateCustomerData_Step1_Customervisitingaddress;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateCustomerData.Step1", Namespace="Comforta2")]
	public class SdtCreateCustomerData_Step1_RESTInterface : GxGenericCollectionItem<SdtCreateCustomerData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateCustomerData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtCreateCustomerData_Step1_RESTInterface( SdtCreateCustomerData_Step1 psdt ) : base(psdt)
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

		[DataMember(Name="CustomerVatNumber", Order=3)]
		public  string gxTpr_Customervatnumber
		{
			get { 
				return sdt.gxTpr_Customervatnumber;

			}
			set { 
				 sdt.gxTpr_Customervatnumber = value;
			}
		}

		[DataMember(Name="CustomerTypeId", Order=4)]
		public short gxTpr_Customertypeid
		{
			get { 
				return sdt.gxTpr_Customertypeid;

			}
			set { 
				sdt.gxTpr_Customertypeid = value;
			}
		}

		[DataMember(Name="CustomerEmail", Order=5)]
		public  string gxTpr_Customeremail
		{
			get { 
				return sdt.gxTpr_Customeremail;

			}
			set { 
				 sdt.gxTpr_Customeremail = value;
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

		[DataMember(Name="CustomerPostalAddress", Order=7)]
		public  string gxTpr_Customerpostaladdress
		{
			get { 
				return sdt.gxTpr_Customerpostaladdress;

			}
			set { 
				 sdt.gxTpr_Customerpostaladdress = value;
			}
		}

		[DataMember(Name="CustomerVisitingAddress", Order=8)]
		public  string gxTpr_Customervisitingaddress
		{
			get { 
				return sdt.gxTpr_Customervisitingaddress;

			}
			set { 
				 sdt.gxTpr_Customervisitingaddress = value;
			}
		}


		#endregion

		public SdtCreateCustomerData_Step1 sdt
		{
			get { 
				return (SdtCreateCustomerData_Step1)Sdt;
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
				sdt = new SdtCreateCustomerData_Step1() ;
			}
		}
	}
	#endregion
}