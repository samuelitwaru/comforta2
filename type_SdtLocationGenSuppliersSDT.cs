/*
				   File: type_SdtLocationGenSuppliersSDT
			Description: LocationGenSuppliersSDT
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
	[XmlRoot(ElementName="LocationGenSuppliersSDT")]
	[XmlType(TypeName="LocationGenSuppliersSDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtLocationGenSuppliersSDT : GxUserType
	{
		public SdtLocationGenSuppliersSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationGenSuppliersSDT_Supplier_genkvknumber = "";

			gxTv_SdtLocationGenSuppliersSDT_Supplier_gencompanyname = "";

			gxTv_SdtLocationGenSuppliersSDT_Supplier_genvisitingaddress = "";

			gxTv_SdtLocationGenSuppliersSDT_Supplier_genpostaladdress = "";

			gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactname = "";

			gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactphone = "";

		}

		public SdtLocationGenSuppliersSDT(IGxContext context)
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
				return gxTv_SdtLocationGenSuppliersSDT_Supplier_genid; 
			}
			set {
				gxTv_SdtLocationGenSuppliersSDT_Supplier_genid = value;
				SetDirty("Supplier_genid");
			}
		}




		[SoapElement(ElementName="Supplier_GenKvKNumber")]
		[XmlElement(ElementName="Supplier_GenKvKNumber")]
		public string gxTpr_Supplier_genkvknumber
		{
			get {
				return gxTv_SdtLocationGenSuppliersSDT_Supplier_genkvknumber; 
			}
			set {
				gxTv_SdtLocationGenSuppliersSDT_Supplier_genkvknumber = value;
				SetDirty("Supplier_genkvknumber");
			}
		}




		[SoapElement(ElementName="Supplier_GenCompanyName")]
		[XmlElement(ElementName="Supplier_GenCompanyName")]
		public string gxTpr_Supplier_gencompanyname
		{
			get {
				return gxTv_SdtLocationGenSuppliersSDT_Supplier_gencompanyname; 
			}
			set {
				gxTv_SdtLocationGenSuppliersSDT_Supplier_gencompanyname = value;
				SetDirty("Supplier_gencompanyname");
			}
		}




		[SoapElement(ElementName="Supplier_GenVisitingAddress")]
		[XmlElement(ElementName="Supplier_GenVisitingAddress")]
		public string gxTpr_Supplier_genvisitingaddress
		{
			get {
				return gxTv_SdtLocationGenSuppliersSDT_Supplier_genvisitingaddress; 
			}
			set {
				gxTv_SdtLocationGenSuppliersSDT_Supplier_genvisitingaddress = value;
				SetDirty("Supplier_genvisitingaddress");
			}
		}




		[SoapElement(ElementName="Supplier_GenPostalAddress")]
		[XmlElement(ElementName="Supplier_GenPostalAddress")]
		public string gxTpr_Supplier_genpostaladdress
		{
			get {
				return gxTv_SdtLocationGenSuppliersSDT_Supplier_genpostaladdress; 
			}
			set {
				gxTv_SdtLocationGenSuppliersSDT_Supplier_genpostaladdress = value;
				SetDirty("Supplier_genpostaladdress");
			}
		}




		[SoapElement(ElementName="Supplier_GenContactName")]
		[XmlElement(ElementName="Supplier_GenContactName")]
		public string gxTpr_Supplier_gencontactname
		{
			get {
				return gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactname; 
			}
			set {
				gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactname = value;
				SetDirty("Supplier_gencontactname");
			}
		}




		[SoapElement(ElementName="Supplier_GenContactPhone")]
		[XmlElement(ElementName="Supplier_GenContactPhone")]
		public string gxTpr_Supplier_gencontactphone
		{
			get {
				return gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactphone; 
			}
			set {
				gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactphone = value;
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
			gxTv_SdtLocationGenSuppliersSDT_Supplier_genkvknumber = "";
			gxTv_SdtLocationGenSuppliersSDT_Supplier_gencompanyname = "";
			gxTv_SdtLocationGenSuppliersSDT_Supplier_genvisitingaddress = "";
			gxTv_SdtLocationGenSuppliersSDT_Supplier_genpostaladdress = "";
			gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactname = "";
			gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactphone = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtLocationGenSuppliersSDT_Supplier_genid;
		 

		protected string gxTv_SdtLocationGenSuppliersSDT_Supplier_genkvknumber;
		 

		protected string gxTv_SdtLocationGenSuppliersSDT_Supplier_gencompanyname;
		 

		protected string gxTv_SdtLocationGenSuppliersSDT_Supplier_genvisitingaddress;
		 

		protected string gxTv_SdtLocationGenSuppliersSDT_Supplier_genpostaladdress;
		 

		protected string gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactname;
		 

		protected string gxTv_SdtLocationGenSuppliersSDT_Supplier_gencontactphone;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"LocationGenSuppliersSDT", Namespace="Comforta2")]
	public class SdtLocationGenSuppliersSDT_RESTInterface : GxGenericCollectionItem<SdtLocationGenSuppliersSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationGenSuppliersSDT_RESTInterface( ) : base()
		{	
		}

		public SdtLocationGenSuppliersSDT_RESTInterface( SdtLocationGenSuppliersSDT psdt ) : base(psdt)
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

		public SdtLocationGenSuppliersSDT sdt
		{
			get { 
				return (SdtLocationGenSuppliersSDT)Sdt;
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
				sdt = new SdtLocationGenSuppliersSDT() ;
			}
		}
	}
	#endregion
}