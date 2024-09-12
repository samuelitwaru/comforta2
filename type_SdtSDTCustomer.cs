/*
				   File: type_SdtSDTCustomer
			Description: SDTCustomer
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
	[XmlRoot(ElementName="SDTCustomer")]
	[XmlType(TypeName="SDTCustomer" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtSDTCustomer : GxUserType
	{
		public SdtSDTCustomer( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCustomer_Customerkvknumber = "";

			gxTv_SdtSDTCustomer_Customername = "";

			gxTv_SdtSDTCustomer_Customerpostaladdress = "";

			gxTv_SdtSDTCustomer_Customeremail = "";

			gxTv_SdtSDTCustomer_Customervisitingaddress = "";

			gxTv_SdtSDTCustomer_Customerphone = "";

			gxTv_SdtSDTCustomer_Customervatnumber = "";

			gxTv_SdtSDTCustomer_Customertypename = "";

		}

		public SdtSDTCustomer(IGxContext context)
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

			if (gxTv_SdtSDTCustomer_Manager != null)
			{
				AddObjectProperty("Manager", gxTv_SdtSDTCustomer_Manager, false);
			}
			if (gxTv_SdtSDTCustomer_Location != null)
			{
				AddObjectProperty("Location", gxTv_SdtSDTCustomer_Location, false);
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
				return gxTv_SdtSDTCustomer_Customerid; 
			}
			set {
				gxTv_SdtSDTCustomer_Customerid = value;
				SetDirty("Customerid");
			}
		}




		[SoapElement(ElementName="CustomerKvkNumber")]
		[XmlElement(ElementName="CustomerKvkNumber")]
		public string gxTpr_Customerkvknumber
		{
			get {
				return gxTv_SdtSDTCustomer_Customerkvknumber; 
			}
			set {
				gxTv_SdtSDTCustomer_Customerkvknumber = value;
				SetDirty("Customerkvknumber");
			}
		}




		[SoapElement(ElementName="CustomerName")]
		[XmlElement(ElementName="CustomerName")]
		public string gxTpr_Customername
		{
			get {
				return gxTv_SdtSDTCustomer_Customername; 
			}
			set {
				gxTv_SdtSDTCustomer_Customername = value;
				SetDirty("Customername");
			}
		}




		[SoapElement(ElementName="CustomerPostalAddress")]
		[XmlElement(ElementName="CustomerPostalAddress")]
		public string gxTpr_Customerpostaladdress
		{
			get {
				return gxTv_SdtSDTCustomer_Customerpostaladdress; 
			}
			set {
				gxTv_SdtSDTCustomer_Customerpostaladdress = value;
				SetDirty("Customerpostaladdress");
			}
		}




		[SoapElement(ElementName="CustomerEmail")]
		[XmlElement(ElementName="CustomerEmail")]
		public string gxTpr_Customeremail
		{
			get {
				return gxTv_SdtSDTCustomer_Customeremail; 
			}
			set {
				gxTv_SdtSDTCustomer_Customeremail = value;
				SetDirty("Customeremail");
			}
		}




		[SoapElement(ElementName="CustomerVisitingAddress")]
		[XmlElement(ElementName="CustomerVisitingAddress")]
		public string gxTpr_Customervisitingaddress
		{
			get {
				return gxTv_SdtSDTCustomer_Customervisitingaddress; 
			}
			set {
				gxTv_SdtSDTCustomer_Customervisitingaddress = value;
				SetDirty("Customervisitingaddress");
			}
		}




		[SoapElement(ElementName="CustomerPhone")]
		[XmlElement(ElementName="CustomerPhone")]
		public string gxTpr_Customerphone
		{
			get {
				return gxTv_SdtSDTCustomer_Customerphone; 
			}
			set {
				gxTv_SdtSDTCustomer_Customerphone = value;
				SetDirty("Customerphone");
			}
		}




		[SoapElement(ElementName="CustomerVatNumber")]
		[XmlElement(ElementName="CustomerVatNumber")]
		public string gxTpr_Customervatnumber
		{
			get {
				return gxTv_SdtSDTCustomer_Customervatnumber; 
			}
			set {
				gxTv_SdtSDTCustomer_Customervatnumber = value;
				SetDirty("Customervatnumber");
			}
		}




		[SoapElement(ElementName="CustomerTypeId")]
		[XmlElement(ElementName="CustomerTypeId")]
		public short gxTpr_Customertypeid
		{
			get {
				return gxTv_SdtSDTCustomer_Customertypeid; 
			}
			set {
				gxTv_SdtSDTCustomer_Customertypeid = value;
				SetDirty("Customertypeid");
			}
		}




		[SoapElement(ElementName="CustomerTypeName")]
		[XmlElement(ElementName="CustomerTypeName")]
		public string gxTpr_Customertypename
		{
			get {
				return gxTv_SdtSDTCustomer_Customertypename; 
			}
			set {
				gxTv_SdtSDTCustomer_Customertypename = value;
				SetDirty("Customertypename");
			}
		}




		[SoapElement(ElementName="Manager" )]
		[XmlArray(ElementName="Manager"  )]
		[XmlArrayItemAttribute(ElementName="ManagerItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTCustomer_ManagerItem> gxTpr_Manager
		{
			get {
				if ( gxTv_SdtSDTCustomer_Manager == null )
				{
					gxTv_SdtSDTCustomer_Manager = new GXBaseCollection<SdtSDTCustomer_ManagerItem>( context, "SDTCustomer.ManagerItem", "");
				}
				return gxTv_SdtSDTCustomer_Manager;
			}
			set {
				gxTv_SdtSDTCustomer_Manager_N = false;
				gxTv_SdtSDTCustomer_Manager = value;
				SetDirty("Manager");
			}
		}

		public void gxTv_SdtSDTCustomer_Manager_SetNull()
		{
			gxTv_SdtSDTCustomer_Manager_N = true;
			gxTv_SdtSDTCustomer_Manager = null;
		}

		public bool gxTv_SdtSDTCustomer_Manager_IsNull()
		{
			return gxTv_SdtSDTCustomer_Manager == null;
		}
		public bool ShouldSerializegxTpr_Manager_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTCustomer_Manager != null && gxTv_SdtSDTCustomer_Manager.Count > 0;

		}



		[SoapElement(ElementName="Location" )]
		[XmlArray(ElementName="Location"  )]
		[XmlArrayItemAttribute(ElementName="LocationItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTCustomer_LocationItem> gxTpr_Location
		{
			get {
				if ( gxTv_SdtSDTCustomer_Location == null )
				{
					gxTv_SdtSDTCustomer_Location = new GXBaseCollection<SdtSDTCustomer_LocationItem>( context, "SDTCustomer.LocationItem", "");
				}
				return gxTv_SdtSDTCustomer_Location;
			}
			set {
				gxTv_SdtSDTCustomer_Location_N = false;
				gxTv_SdtSDTCustomer_Location = value;
				SetDirty("Location");
			}
		}

		public void gxTv_SdtSDTCustomer_Location_SetNull()
		{
			gxTv_SdtSDTCustomer_Location_N = true;
			gxTv_SdtSDTCustomer_Location = null;
		}

		public bool gxTv_SdtSDTCustomer_Location_IsNull()
		{
			return gxTv_SdtSDTCustomer_Location == null;
		}
		public bool ShouldSerializegxTpr_Location_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTCustomer_Location != null && gxTv_SdtSDTCustomer_Location.Count > 0;

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
			gxTv_SdtSDTCustomer_Customerkvknumber = "";
			gxTv_SdtSDTCustomer_Customername = "";
			gxTv_SdtSDTCustomer_Customerpostaladdress = "";
			gxTv_SdtSDTCustomer_Customeremail = "";
			gxTv_SdtSDTCustomer_Customervisitingaddress = "";
			gxTv_SdtSDTCustomer_Customerphone = "";
			gxTv_SdtSDTCustomer_Customervatnumber = "";

			gxTv_SdtSDTCustomer_Customertypename = "";

			gxTv_SdtSDTCustomer_Manager_N = true;


			gxTv_SdtSDTCustomer_Location_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTCustomer_Customerid;
		 

		protected string gxTv_SdtSDTCustomer_Customerkvknumber;
		 

		protected string gxTv_SdtSDTCustomer_Customername;
		 

		protected string gxTv_SdtSDTCustomer_Customerpostaladdress;
		 

		protected string gxTv_SdtSDTCustomer_Customeremail;
		 

		protected string gxTv_SdtSDTCustomer_Customervisitingaddress;
		 

		protected string gxTv_SdtSDTCustomer_Customerphone;
		 

		protected string gxTv_SdtSDTCustomer_Customervatnumber;
		 

		protected short gxTv_SdtSDTCustomer_Customertypeid;
		 

		protected string gxTv_SdtSDTCustomer_Customertypename;
		 
		protected bool gxTv_SdtSDTCustomer_Manager_N;
		protected GXBaseCollection<SdtSDTCustomer_ManagerItem> gxTv_SdtSDTCustomer_Manager = null; 

		protected bool gxTv_SdtSDTCustomer_Location_N;
		protected GXBaseCollection<SdtSDTCustomer_LocationItem> gxTv_SdtSDTCustomer_Location = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTCustomer", Namespace="Comforta2")]
	public class SdtSDTCustomer_RESTInterface : GxGenericCollectionItem<SdtSDTCustomer>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCustomer_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCustomer_RESTInterface( SdtSDTCustomer psdt ) : base(psdt)
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

		[DataMember(Name="Manager", Order=10, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTCustomer_ManagerItem_RESTInterface> gxTpr_Manager
		{
			get {
				if (sdt.ShouldSerializegxTpr_Manager_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTCustomer_ManagerItem_RESTInterface>(sdt.gxTpr_Manager);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Manager);
			}
		}

		[DataMember(Name="Location", Order=11, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTCustomer_LocationItem_RESTInterface> gxTpr_Location
		{
			get {
				if (sdt.ShouldSerializegxTpr_Location_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTCustomer_LocationItem_RESTInterface>(sdt.gxTpr_Location);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Location);
			}
		}


		#endregion

		public SdtSDTCustomer sdt
		{
			get { 
				return (SdtSDTCustomer)Sdt;
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
				sdt = new SdtSDTCustomer() ;
			}
		}
	}
	#endregion
}