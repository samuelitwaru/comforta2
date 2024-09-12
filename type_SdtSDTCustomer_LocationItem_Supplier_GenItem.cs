/*
				   File: type_SdtSDTCustomer_LocationItem_Supplier_GenItem
			Description: Supplier_Gen
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
	[XmlRoot(ElementName="SDTCustomer.LocationItem.Supplier_GenItem")]
	[XmlType(TypeName="SDTCustomer.LocationItem.Supplier_GenItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtSDTCustomer_LocationItem_Supplier_GenItem : GxUserType
	{
		public SdtSDTCustomer_LocationItem_Supplier_GenItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genkvknumber = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencompanyname = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genvisitingaddress = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genpostaladdress = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactname = "";

			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactphone = "";

		}

		public SdtSDTCustomer_LocationItem_Supplier_GenItem(IGxContext context)
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
			AddObjectProperty("Supplier_GenId", gxTpr_Supplier_genid, false);


			AddObjectProperty("Supplier_GenKvKNumber", gxTpr_Supplier_genkvknumber, false);


			AddObjectProperty("Supplier_GenCompanyName", gxTpr_Supplier_gencompanyname, false);


			AddObjectProperty("Supplier_GenVisitingAddress", gxTpr_Supplier_genvisitingaddress, false);


			AddObjectProperty("Supplier_GenPostalAddress", gxTpr_Supplier_genpostaladdress, false);


			AddObjectProperty("Supplier_GenContactName", gxTpr_Supplier_gencontactname, false);


			AddObjectProperty("Supplier_GenContactPhone", gxTpr_Supplier_gencontactphone, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Supplier_GenId")]
		[XmlElement(ElementName="Supplier_GenId")]
		public short gxTpr_Supplier_genid
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genid; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genid = value;
				SetDirty("Supplier_genid");
			}
		}




		[SoapElement(ElementName="Supplier_GenKvKNumber")]
		[XmlElement(ElementName="Supplier_GenKvKNumber")]
		public string gxTpr_Supplier_genkvknumber
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genkvknumber; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genkvknumber = value;
				SetDirty("Supplier_genkvknumber");
			}
		}




		[SoapElement(ElementName="Supplier_GenCompanyName")]
		[XmlElement(ElementName="Supplier_GenCompanyName")]
		public string gxTpr_Supplier_gencompanyname
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencompanyname; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencompanyname = value;
				SetDirty("Supplier_gencompanyname");
			}
		}




		[SoapElement(ElementName="Supplier_GenVisitingAddress")]
		[XmlElement(ElementName="Supplier_GenVisitingAddress")]
		public string gxTpr_Supplier_genvisitingaddress
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genvisitingaddress; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genvisitingaddress = value;
				SetDirty("Supplier_genvisitingaddress");
			}
		}




		[SoapElement(ElementName="Supplier_GenPostalAddress")]
		[XmlElement(ElementName="Supplier_GenPostalAddress")]
		public string gxTpr_Supplier_genpostaladdress
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genpostaladdress; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genpostaladdress = value;
				SetDirty("Supplier_genpostaladdress");
			}
		}




		[SoapElement(ElementName="Supplier_GenContactName")]
		[XmlElement(ElementName="Supplier_GenContactName")]
		public string gxTpr_Supplier_gencontactname
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactname; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactname = value;
				SetDirty("Supplier_gencontactname");
			}
		}




		[SoapElement(ElementName="Supplier_GenContactPhone")]
		[XmlElement(ElementName="Supplier_GenContactPhone")]
		public string gxTpr_Supplier_gencontactphone
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactphone; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactphone = value;
				SetDirty("Supplier_gencontactphone");
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
			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genkvknumber = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencompanyname = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genvisitingaddress = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genpostaladdress = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactname = "";
			gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactphone = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genid;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genkvknumber;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencompanyname;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genvisitingaddress;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_genpostaladdress;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactname;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Supplier_GenItem_Supplier_gencontactphone;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTCustomer.LocationItem.Supplier_GenItem", Namespace="Comforta2")]
	public class SdtSDTCustomer_LocationItem_Supplier_GenItem_RESTInterface : GxGenericCollectionItem<SdtSDTCustomer_LocationItem_Supplier_GenItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCustomer_LocationItem_Supplier_GenItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCustomer_LocationItem_Supplier_GenItem_RESTInterface( SdtSDTCustomer_LocationItem_Supplier_GenItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Supplier_GenId", Order=0)]
		public short gxTpr_Supplier_genid
		{
			get { 
				return sdt.gxTpr_Supplier_genid;

			}
			set { 
				sdt.gxTpr_Supplier_genid = value;
			}
		}

		[DataMember(Name="Supplier_GenKvKNumber", Order=1)]
		public  string gxTpr_Supplier_genkvknumber
		{
			get { 
				return sdt.gxTpr_Supplier_genkvknumber;

			}
			set { 
				 sdt.gxTpr_Supplier_genkvknumber = value;
			}
		}

		[DataMember(Name="Supplier_GenCompanyName", Order=2)]
		public  string gxTpr_Supplier_gencompanyname
		{
			get { 
				return sdt.gxTpr_Supplier_gencompanyname;

			}
			set { 
				 sdt.gxTpr_Supplier_gencompanyname = value;
			}
		}

		[DataMember(Name="Supplier_GenVisitingAddress", Order=3)]
		public  string gxTpr_Supplier_genvisitingaddress
		{
			get { 
				return sdt.gxTpr_Supplier_genvisitingaddress;

			}
			set { 
				 sdt.gxTpr_Supplier_genvisitingaddress = value;
			}
		}

		[DataMember(Name="Supplier_GenPostalAddress", Order=4)]
		public  string gxTpr_Supplier_genpostaladdress
		{
			get { 
				return sdt.gxTpr_Supplier_genpostaladdress;

			}
			set { 
				 sdt.gxTpr_Supplier_genpostaladdress = value;
			}
		}

		[DataMember(Name="Supplier_GenContactName", Order=5)]
		public  string gxTpr_Supplier_gencontactname
		{
			get { 
				return sdt.gxTpr_Supplier_gencontactname;

			}
			set { 
				 sdt.gxTpr_Supplier_gencontactname = value;
			}
		}

		[DataMember(Name="Supplier_GenContactPhone", Order=6)]
		public  string gxTpr_Supplier_gencontactphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Supplier_gencontactphone);

			}
			set { 
				 sdt.gxTpr_Supplier_gencontactphone = value;
			}
		}


		#endregion

		public SdtSDTCustomer_LocationItem_Supplier_GenItem sdt
		{
			get { 
				return (SdtSDTCustomer_LocationItem_Supplier_GenItem)Sdt;
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
				sdt = new SdtSDTCustomer_LocationItem_Supplier_GenItem() ;
			}
		}
	}
	#endregion
}