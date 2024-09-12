/*
				   File: type_SdtResidentDetails_ResidentServicesAndProductsItem
			Description: ResidentServicesAndProducts
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
	[XmlRoot(ElementName="ResidentDetails.ResidentServicesAndProductsItem")]
	[XmlType(TypeName="ResidentDetails.ResidentServicesAndProductsItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtResidentDetails_ResidentServicesAndProductsItem : GxUserType
	{
		public SdtResidentDetails_ResidentServicesAndProductsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicename = "";

			gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicedescription = "";

			gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture = "";
			gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture_gxi = "";
			gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicetypename = "";

		}

		public SdtResidentDetails_ResidentServicesAndProductsItem(IGxContext context)
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
			AddObjectProperty("ProductServiceId", gxTpr_Productserviceid, false);


			AddObjectProperty("ProductServiceName", gxTpr_Productservicename, false);


			AddObjectProperty("ProductServiceDescription", gxTpr_Productservicedescription, false);


			AddObjectProperty("ProductServiceQuantity", gxTpr_Productservicequantity, false);


			AddObjectProperty("ProductServicePicture", gxTpr_Productservicepicture, false);
			AddObjectProperty("ProductServicePicture_GXI", gxTpr_Productservicepicture_gxi, false);



			AddObjectProperty("ProductServiceTypeId", gxTpr_Productservicetypeid, false);


			AddObjectProperty("ProductServiceTypeName", gxTpr_Productservicetypename, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProductServiceId")]
		[XmlElement(ElementName="ProductServiceId")]
		public short gxTpr_Productserviceid
		{
			get {
				return gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productserviceid; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productserviceid = value;
				SetDirty("Productserviceid");
			}
		}




		[SoapElement(ElementName="ProductServiceName")]
		[XmlElement(ElementName="ProductServiceName")]
		public string gxTpr_Productservicename
		{
			get {
				return gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicename; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicename = value;
				SetDirty("Productservicename");
			}
		}




		[SoapElement(ElementName="ProductServiceDescription")]
		[XmlElement(ElementName="ProductServiceDescription")]
		public string gxTpr_Productservicedescription
		{
			get {
				return gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicedescription; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicedescription = value;
				SetDirty("Productservicedescription");
			}
		}




		[SoapElement(ElementName="ProductServiceQuantity")]
		[XmlElement(ElementName="ProductServiceQuantity")]
		public short gxTpr_Productservicequantity
		{
			get {
				return gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicequantity; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicequantity = value;
				SetDirty("Productservicequantity");
			}
		}




		[SoapElement(ElementName="ProductServicePicture")]
		[XmlElement(ElementName="ProductServicePicture")]
		[GxUpload()]

		public string gxTpr_Productservicepicture
		{
			get {
				return gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture = value;
				SetDirty("Productservicepicture");
			}
		}


		[SoapElement(ElementName="ProductServicePicture_GXI" )]
		[XmlElement(ElementName="ProductServicePicture_GXI" )]
		public string gxTpr_Productservicepicture_gxi
		{
			get {
				return gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture_gxi ;
			}
			set {
				gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture_gxi = value;
				SetDirty("Productservicepicture_gxi");
			}
		}

		[SoapElement(ElementName="ProductServiceTypeId")]
		[XmlElement(ElementName="ProductServiceTypeId")]
		public short gxTpr_Productservicetypeid
		{
			get {
				return gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicetypeid; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicetypeid = value;
				SetDirty("Productservicetypeid");
			}
		}




		[SoapElement(ElementName="ProductServiceTypeName")]
		[XmlElement(ElementName="ProductServiceTypeName")]
		public string gxTpr_Productservicetypename
		{
			get {
				return gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicetypename; 
			}
			set {
				gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicetypename = value;
				SetDirty("Productservicetypename");
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
			gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicename = "";
			gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicedescription = "";

			gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture = "";gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture_gxi = "";

			gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicetypename = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productserviceid;
		 

		protected string gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicename;
		 

		protected string gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicedescription;
		 

		protected short gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicequantity;
		 
		protected string gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture_gxi;
		protected string gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicepicture;
		 

		protected short gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicetypeid;
		 

		protected string gxTv_SdtResidentDetails_ResidentServicesAndProductsItem_Productservicetypename;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"ResidentDetails.ResidentServicesAndProductsItem", Namespace="Comforta2")]
	public class SdtResidentDetails_ResidentServicesAndProductsItem_RESTInterface : GxGenericCollectionItem<SdtResidentDetails_ResidentServicesAndProductsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResidentDetails_ResidentServicesAndProductsItem_RESTInterface( ) : base()
		{	
		}

		public SdtResidentDetails_ResidentServicesAndProductsItem_RESTInterface( SdtResidentDetails_ResidentServicesAndProductsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProductServiceId", Order=0)]
		public short gxTpr_Productserviceid
		{
			get { 
				return sdt.gxTpr_Productserviceid;

			}
			set { 
				sdt.gxTpr_Productserviceid = value;
			}
		}

		[DataMember(Name="ProductServiceName", Order=1)]
		public  string gxTpr_Productservicename
		{
			get { 
				return sdt.gxTpr_Productservicename;

			}
			set { 
				 sdt.gxTpr_Productservicename = value;
			}
		}

		[DataMember(Name="ProductServiceDescription", Order=2)]
		public  string gxTpr_Productservicedescription
		{
			get { 
				return sdt.gxTpr_Productservicedescription;

			}
			set { 
				 sdt.gxTpr_Productservicedescription = value;
			}
		}

		[DataMember(Name="ProductServiceQuantity", Order=3)]
		public short gxTpr_Productservicequantity
		{
			get { 
				return sdt.gxTpr_Productservicequantity;

			}
			set { 
				sdt.gxTpr_Productservicequantity = value;
			}
		}

		[DataMember(Name="ProductServicePicture", Order=4)]
		[GxUpload()]
		public  string gxTpr_Productservicepicture
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productservicepicture)) ? PathUtil.RelativePath( sdt.gxTpr_Productservicepicture) : StringUtil.RTrim( sdt.gxTpr_Productservicepicture_gxi));

			}
			set { 
				 sdt.gxTpr_Productservicepicture = value;
			}
		}

		[DataMember(Name="ProductServiceTypeId", Order=5)]
		public short gxTpr_Productservicetypeid
		{
			get { 
				return sdt.gxTpr_Productservicetypeid;

			}
			set { 
				sdt.gxTpr_Productservicetypeid = value;
			}
		}

		[DataMember(Name="ProductServiceTypeName", Order=6)]
		public  string gxTpr_Productservicetypename
		{
			get { 
				return sdt.gxTpr_Productservicetypename;

			}
			set { 
				 sdt.gxTpr_Productservicetypename = value;
			}
		}


		#endregion

		public SdtResidentDetails_ResidentServicesAndProductsItem sdt
		{
			get { 
				return (SdtResidentDetails_ResidentServicesAndProductsItem)Sdt;
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
				sdt = new SdtResidentDetails_ResidentServicesAndProductsItem() ;
			}
		}
	}
	#endregion
}