/*
				   File: type_SdtResidentDetails
			Description: ResidentDetails
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
	[XmlRoot(ElementName="ResidentDetails")]
	[XmlType(TypeName="ResidentDetails" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtResidentDetails : GxUserType
	{
		public SdtResidentDetails( )
		{
			/* Constructor for serialization */
			gxTv_SdtResidentDetails_Residentid = "";

			gxTv_SdtResidentDetails_Residentbsnnumber = "";

			gxTv_SdtResidentDetails_Residentgivenname = "";

			gxTv_SdtResidentDetails_Residentlastname = "";

			gxTv_SdtResidentDetails_Residentinitials = "";

			gxTv_SdtResidentDetails_Residentemail = "";

			gxTv_SdtResidentDetails_Residentaddress = "";

			gxTv_SdtResidentDetails_Residentphone = "";

			gxTv_SdtResidentDetails_Residentgamguid = "";

			gxTv_SdtResidentDetails_Residenttypename = "";

		}

		public SdtResidentDetails(IGxContext context)
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


			AddObjectProperty("ResidentInitials", gxTpr_Residentinitials, false);


			AddObjectProperty("ResidentEmail", gxTpr_Residentemail, false);


			AddObjectProperty("ResidentAddress", gxTpr_Residentaddress, false);


			AddObjectProperty("ResidentPhone", gxTpr_Residentphone, false);


			AddObjectProperty("ResidentGAMGUID", gxTpr_Residentgamguid, false);


			AddObjectProperty("ResidentTypeId", gxTpr_Residenttypeid, false);


			AddObjectProperty("ResidentTypeName", gxTpr_Residenttypename, false);

			if (gxTpr_Customer != null)
			{
				AddObjectProperty("Customer", gxTpr_Customer, false);
			}
			if (gxTpr_Residentnetworkindividuals != null)
			{
				AddObjectProperty("ResidentNetworkIndividuals", gxTpr_Residentnetworkindividuals, false);
			}
			if (gxTpr_Residentnetworkcompanies != null)
			{
				AddObjectProperty("ResidentNetworkCompanies", gxTpr_Residentnetworkcompanies, false);
			}
			if (gxTpr_Residentservicesandproducts != null)
			{
				AddObjectProperty("ResidentServicesAndProducts", gxTpr_Residentservicesandproducts, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentId")]
		[XmlElement(ElementName="ResidentId")]
		public string gxTpr_Residentid
		{
			get {
				return gxTv_SdtResidentDetails_Residentid; 
			}
			set {
				gxTv_SdtResidentDetails_Residentid = value;
				SetDirty("Residentid");
			}
		}




		[SoapElement(ElementName="ResidentBsnNumber")]
		[XmlElement(ElementName="ResidentBsnNumber")]
		public string gxTpr_Residentbsnnumber
		{
			get {
				return gxTv_SdtResidentDetails_Residentbsnnumber; 
			}
			set {
				gxTv_SdtResidentDetails_Residentbsnnumber = value;
				SetDirty("Residentbsnnumber");
			}
		}




		[SoapElement(ElementName="ResidentGivenName")]
		[XmlElement(ElementName="ResidentGivenName")]
		public string gxTpr_Residentgivenname
		{
			get {
				return gxTv_SdtResidentDetails_Residentgivenname; 
			}
			set {
				gxTv_SdtResidentDetails_Residentgivenname = value;
				SetDirty("Residentgivenname");
			}
		}




		[SoapElement(ElementName="ResidentLastName")]
		[XmlElement(ElementName="ResidentLastName")]
		public string gxTpr_Residentlastname
		{
			get {
				return gxTv_SdtResidentDetails_Residentlastname; 
			}
			set {
				gxTv_SdtResidentDetails_Residentlastname = value;
				SetDirty("Residentlastname");
			}
		}




		[SoapElement(ElementName="ResidentInitials")]
		[XmlElement(ElementName="ResidentInitials")]
		public string gxTpr_Residentinitials
		{
			get {
				return gxTv_SdtResidentDetails_Residentinitials; 
			}
			set {
				gxTv_SdtResidentDetails_Residentinitials = value;
				SetDirty("Residentinitials");
			}
		}




		[SoapElement(ElementName="ResidentEmail")]
		[XmlElement(ElementName="ResidentEmail")]
		public string gxTpr_Residentemail
		{
			get {
				return gxTv_SdtResidentDetails_Residentemail; 
			}
			set {
				gxTv_SdtResidentDetails_Residentemail = value;
				SetDirty("Residentemail");
			}
		}




		[SoapElement(ElementName="ResidentAddress")]
		[XmlElement(ElementName="ResidentAddress")]
		public string gxTpr_Residentaddress
		{
			get {
				return gxTv_SdtResidentDetails_Residentaddress; 
			}
			set {
				gxTv_SdtResidentDetails_Residentaddress = value;
				SetDirty("Residentaddress");
			}
		}




		[SoapElement(ElementName="ResidentPhone")]
		[XmlElement(ElementName="ResidentPhone")]
		public string gxTpr_Residentphone
		{
			get {
				return gxTv_SdtResidentDetails_Residentphone; 
			}
			set {
				gxTv_SdtResidentDetails_Residentphone = value;
				SetDirty("Residentphone");
			}
		}




		[SoapElement(ElementName="ResidentGAMGUID")]
		[XmlElement(ElementName="ResidentGAMGUID")]
		public string gxTpr_Residentgamguid
		{
			get {
				return gxTv_SdtResidentDetails_Residentgamguid; 
			}
			set {
				gxTv_SdtResidentDetails_Residentgamguid = value;
				SetDirty("Residentgamguid");
			}
		}




		[SoapElement(ElementName="ResidentTypeId")]
		[XmlElement(ElementName="ResidentTypeId")]
		public short gxTpr_Residenttypeid
		{
			get {
				return gxTv_SdtResidentDetails_Residenttypeid; 
			}
			set {
				gxTv_SdtResidentDetails_Residenttypeid = value;
				SetDirty("Residenttypeid");
			}
		}




		[SoapElement(ElementName="ResidentTypeName")]
		[XmlElement(ElementName="ResidentTypeName")]
		public string gxTpr_Residenttypename
		{
			get {
				return gxTv_SdtResidentDetails_Residenttypename; 
			}
			set {
				gxTv_SdtResidentDetails_Residenttypename = value;
				SetDirty("Residenttypename");
			}
		}



		[SoapElement(ElementName="Customer" )]
		[XmlElement(ElementName="Customer" )]
		public SdtResidentDetails_Customer gxTpr_Customer
		{
			get {
				if ( gxTv_SdtResidentDetails_Customer == null )
				{
					gxTv_SdtResidentDetails_Customer = new SdtResidentDetails_Customer(context);
				}
				return gxTv_SdtResidentDetails_Customer;
			}
			set {
				gxTv_SdtResidentDetails_Customer = value;
				SetDirty("Customer");
			}

		}

		public void gxTv_SdtResidentDetails_Customer_SetNull()
		{
			gxTv_SdtResidentDetails_Customer = null;
		}

		public bool gxTv_SdtResidentDetails_Customer_IsNull()
		{
			return gxTv_SdtResidentDetails_Customer == null;
		}



		[SoapElement(ElementName="ResidentNetworkIndividuals" )]
		[XmlArray(ElementName="ResidentNetworkIndividuals"  )]
		[XmlArrayItemAttribute(ElementName="ResidentNetworkIndividualsItem" , IsNullable=false )]
		public GXBaseCollection<SdtResidentDetails_ResidentNetworkIndividualsItem> gxTpr_Residentnetworkindividuals
		{
			get {
				if ( gxTv_SdtResidentDetails_Residentnetworkindividuals == null )
				{
					gxTv_SdtResidentDetails_Residentnetworkindividuals = new GXBaseCollection<SdtResidentDetails_ResidentNetworkIndividualsItem>( context, "ResidentDetails.ResidentNetworkIndividualsItem", "");
				}
				return gxTv_SdtResidentDetails_Residentnetworkindividuals;
			}
			set {
				gxTv_SdtResidentDetails_Residentnetworkindividuals = value;
				SetDirty("Residentnetworkindividuals");
			}
		}

		public void gxTv_SdtResidentDetails_Residentnetworkindividuals_SetNull()
		{
			gxTv_SdtResidentDetails_Residentnetworkindividuals = null;
		}

		public bool gxTv_SdtResidentDetails_Residentnetworkindividuals_IsNull()
		{
			return gxTv_SdtResidentDetails_Residentnetworkindividuals == null;
		}



		[SoapElement(ElementName="ResidentNetworkCompanies" )]
		[XmlArray(ElementName="ResidentNetworkCompanies"  )]
		[XmlArrayItemAttribute(ElementName="ResidentNetworkCompaniesItem" , IsNullable=false )]
		public GXBaseCollection<SdtResidentDetails_ResidentNetworkCompaniesItem> gxTpr_Residentnetworkcompanies
		{
			get {
				if ( gxTv_SdtResidentDetails_Residentnetworkcompanies == null )
				{
					gxTv_SdtResidentDetails_Residentnetworkcompanies = new GXBaseCollection<SdtResidentDetails_ResidentNetworkCompaniesItem>( context, "ResidentDetails.ResidentNetworkCompaniesItem", "");
				}
				return gxTv_SdtResidentDetails_Residentnetworkcompanies;
			}
			set {
				gxTv_SdtResidentDetails_Residentnetworkcompanies = value;
				SetDirty("Residentnetworkcompanies");
			}
		}

		public void gxTv_SdtResidentDetails_Residentnetworkcompanies_SetNull()
		{
			gxTv_SdtResidentDetails_Residentnetworkcompanies = null;
		}

		public bool gxTv_SdtResidentDetails_Residentnetworkcompanies_IsNull()
		{
			return gxTv_SdtResidentDetails_Residentnetworkcompanies == null;
		}



		[SoapElement(ElementName="ResidentServicesAndProducts" )]
		[XmlArray(ElementName="ResidentServicesAndProducts"  )]
		[XmlArrayItemAttribute(ElementName="ResidentServicesAndProductsItem" , IsNullable=false )]
		public GXBaseCollection<SdtResidentDetails_ResidentServicesAndProductsItem> gxTpr_Residentservicesandproducts
		{
			get {
				if ( gxTv_SdtResidentDetails_Residentservicesandproducts == null )
				{
					gxTv_SdtResidentDetails_Residentservicesandproducts = new GXBaseCollection<SdtResidentDetails_ResidentServicesAndProductsItem>( context, "ResidentDetails.ResidentServicesAndProductsItem", "");
				}
				return gxTv_SdtResidentDetails_Residentservicesandproducts;
			}
			set {
				gxTv_SdtResidentDetails_Residentservicesandproducts = value;
				SetDirty("Residentservicesandproducts");
			}
		}

		public void gxTv_SdtResidentDetails_Residentservicesandproducts_SetNull()
		{
			gxTv_SdtResidentDetails_Residentservicesandproducts = null;
		}

		public bool gxTv_SdtResidentDetails_Residentservicesandproducts_IsNull()
		{
			return gxTv_SdtResidentDetails_Residentservicesandproducts == null;
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
			gxTv_SdtResidentDetails_Residentid = "";
			gxTv_SdtResidentDetails_Residentbsnnumber = "";
			gxTv_SdtResidentDetails_Residentgivenname = "";
			gxTv_SdtResidentDetails_Residentlastname = "";
			gxTv_SdtResidentDetails_Residentinitials = "";
			gxTv_SdtResidentDetails_Residentemail = "";
			gxTv_SdtResidentDetails_Residentaddress = "";
			gxTv_SdtResidentDetails_Residentphone = "";
			gxTv_SdtResidentDetails_Residentgamguid = "";

			gxTv_SdtResidentDetails_Residenttypename = "";




			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtResidentDetails_Residentid;
		 

		protected string gxTv_SdtResidentDetails_Residentbsnnumber;
		 

		protected string gxTv_SdtResidentDetails_Residentgivenname;
		 

		protected string gxTv_SdtResidentDetails_Residentlastname;
		 

		protected string gxTv_SdtResidentDetails_Residentinitials;
		 

		protected string gxTv_SdtResidentDetails_Residentemail;
		 

		protected string gxTv_SdtResidentDetails_Residentaddress;
		 

		protected string gxTv_SdtResidentDetails_Residentphone;
		 

		protected string gxTv_SdtResidentDetails_Residentgamguid;
		 

		protected short gxTv_SdtResidentDetails_Residenttypeid;
		 

		protected string gxTv_SdtResidentDetails_Residenttypename;
		 

		protected SdtResidentDetails_Customer gxTv_SdtResidentDetails_Customer = null; 


		protected GXBaseCollection<SdtResidentDetails_ResidentNetworkIndividualsItem> gxTv_SdtResidentDetails_Residentnetworkindividuals = null; 


		protected GXBaseCollection<SdtResidentDetails_ResidentNetworkCompaniesItem> gxTv_SdtResidentDetails_Residentnetworkcompanies = null; 


		protected GXBaseCollection<SdtResidentDetails_ResidentServicesAndProductsItem> gxTv_SdtResidentDetails_Residentservicesandproducts = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ResidentDetails", Namespace="Comforta2")]
	public class SdtResidentDetails_RESTInterface : GxGenericCollectionItem<SdtResidentDetails>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResidentDetails_RESTInterface( ) : base()
		{	
		}

		public SdtResidentDetails_RESTInterface( SdtResidentDetails psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentId", Order=0)]
		public  string gxTpr_Residentid
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

		[DataMember(Name="ResidentInitials", Order=4)]
		public  string gxTpr_Residentinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentinitials);

			}
			set { 
				 sdt.gxTpr_Residentinitials = value;
			}
		}

		[DataMember(Name="ResidentEmail", Order=5)]
		public  string gxTpr_Residentemail
		{
			get { 
				return sdt.gxTpr_Residentemail;

			}
			set { 
				 sdt.gxTpr_Residentemail = value;
			}
		}

		[DataMember(Name="ResidentAddress", Order=6)]
		public  string gxTpr_Residentaddress
		{
			get { 
				return sdt.gxTpr_Residentaddress;

			}
			set { 
				 sdt.gxTpr_Residentaddress = value;
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

		[DataMember(Name="ResidentGAMGUID", Order=8)]
		public  string gxTpr_Residentgamguid
		{
			get { 
				return sdt.gxTpr_Residentgamguid;

			}
			set { 
				 sdt.gxTpr_Residentgamguid = value;
			}
		}

		[DataMember(Name="ResidentTypeId", Order=9)]
		public short gxTpr_Residenttypeid
		{
			get { 
				return sdt.gxTpr_Residenttypeid;

			}
			set { 
				sdt.gxTpr_Residenttypeid = value;
			}
		}

		[DataMember(Name="ResidentTypeName", Order=10)]
		public  string gxTpr_Residenttypename
		{
			get { 
				return sdt.gxTpr_Residenttypename;

			}
			set { 
				 sdt.gxTpr_Residenttypename = value;
			}
		}

		[DataMember(Name="Customer", Order=11)]
		public SdtResidentDetails_Customer_RESTInterface gxTpr_Customer
		{
			get {
				return new SdtResidentDetails_Customer_RESTInterface(sdt.gxTpr_Customer);

			}

			set {
				sdt.gxTpr_Customer = value.sdt;
			}

		}

		[DataMember(Name="ResidentNetworkIndividuals", Order=12)]
		public GxGenericCollection<SdtResidentDetails_ResidentNetworkIndividualsItem_RESTInterface> gxTpr_Residentnetworkindividuals
		{
			get {
				return new GxGenericCollection<SdtResidentDetails_ResidentNetworkIndividualsItem_RESTInterface>(sdt.gxTpr_Residentnetworkindividuals);

			}
			set {
				value.LoadCollection(sdt.gxTpr_Residentnetworkindividuals);
			}
		}

		[DataMember(Name="ResidentNetworkCompanies", Order=13)]
		public GxGenericCollection<SdtResidentDetails_ResidentNetworkCompaniesItem_RESTInterface> gxTpr_Residentnetworkcompanies
		{
			get {
				return new GxGenericCollection<SdtResidentDetails_ResidentNetworkCompaniesItem_RESTInterface>(sdt.gxTpr_Residentnetworkcompanies);

			}
			set {
				value.LoadCollection(sdt.gxTpr_Residentnetworkcompanies);
			}
		}

		[DataMember(Name="ResidentServicesAndProducts", Order=14)]
		public GxGenericCollection<SdtResidentDetails_ResidentServicesAndProductsItem_RESTInterface> gxTpr_Residentservicesandproducts
		{
			get {
				return new GxGenericCollection<SdtResidentDetails_ResidentServicesAndProductsItem_RESTInterface>(sdt.gxTpr_Residentservicesandproducts);

			}
			set {
				value.LoadCollection(sdt.gxTpr_Residentservicesandproducts);
			}
		}


		#endregion

		public SdtResidentDetails sdt
		{
			get { 
				return (SdtResidentDetails)Sdt;
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
				sdt = new SdtResidentDetails() ;
			}
		}
	}
	#endregion
}