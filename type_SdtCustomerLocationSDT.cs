/*
				   File: type_SdtCustomerLocationSDT
			Description: CustomerLocationSDT
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
	[XmlRoot(ElementName="CustomerLocationSDT")]
	[XmlType(TypeName="CustomerLocationSDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCustomerLocationSDT : GxUserType
	{
		public SdtCustomerLocationSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtCustomerLocationSDT_Customerlocationname = "";

			gxTv_SdtCustomerLocationSDT_Customerlocationdescription = "";

			gxTv_SdtCustomerLocationSDT_Customerlocationvisitingaddress = "";

			gxTv_SdtCustomerLocationSDT_Customerlocationemail = "";

			gxTv_SdtCustomerLocationSDT_Customerlocationphone = "";

			gxTv_SdtCustomerLocationSDT_Customerlocationpostaladdress = "";

		}

		public SdtCustomerLocationSDT(IGxContext context)
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


			AddObjectProperty("CustomerLocationId", gxTpr_Customerlocationid, false);


			AddObjectProperty("CustomerLocationName", gxTpr_Customerlocationname, false);


			AddObjectProperty("CustomerLocationDescription", gxTpr_Customerlocationdescription, false);


			AddObjectProperty("CustomerLocationVisitingAddress", gxTpr_Customerlocationvisitingaddress, false);


			AddObjectProperty("CustomerLocationEmail", gxTpr_Customerlocationemail, false);


			AddObjectProperty("CustomerLocationPhone", gxTpr_Customerlocationphone, false);


			AddObjectProperty("CustomerLocationPostalAddress", gxTpr_Customerlocationpostaladdress, false);


			AddObjectProperty("CustomerLocationLastLine", gxTpr_Customerlocationlastline, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerId")]
		[XmlElement(ElementName="CustomerId")]
		public short gxTpr_Customerid
		{
			get {
				return gxTv_SdtCustomerLocationSDT_Customerid; 
			}
			set {
				gxTv_SdtCustomerLocationSDT_Customerid = value;
				SetDirty("Customerid");
			}
		}




		[SoapElement(ElementName="CustomerLocationId")]
		[XmlElement(ElementName="CustomerLocationId")]
		public short gxTpr_Customerlocationid
		{
			get {
				return gxTv_SdtCustomerLocationSDT_Customerlocationid; 
			}
			set {
				gxTv_SdtCustomerLocationSDT_Customerlocationid = value;
				SetDirty("Customerlocationid");
			}
		}




		[SoapElement(ElementName="CustomerLocationName")]
		[XmlElement(ElementName="CustomerLocationName")]
		public string gxTpr_Customerlocationname
		{
			get {
				return gxTv_SdtCustomerLocationSDT_Customerlocationname; 
			}
			set {
				gxTv_SdtCustomerLocationSDT_Customerlocationname = value;
				SetDirty("Customerlocationname");
			}
		}




		[SoapElement(ElementName="CustomerLocationDescription")]
		[XmlElement(ElementName="CustomerLocationDescription")]
		public string gxTpr_Customerlocationdescription
		{
			get {
				return gxTv_SdtCustomerLocationSDT_Customerlocationdescription; 
			}
			set {
				gxTv_SdtCustomerLocationSDT_Customerlocationdescription = value;
				SetDirty("Customerlocationdescription");
			}
		}




		[SoapElement(ElementName="CustomerLocationVisitingAddress")]
		[XmlElement(ElementName="CustomerLocationVisitingAddress")]
		public string gxTpr_Customerlocationvisitingaddress
		{
			get {
				return gxTv_SdtCustomerLocationSDT_Customerlocationvisitingaddress; 
			}
			set {
				gxTv_SdtCustomerLocationSDT_Customerlocationvisitingaddress = value;
				SetDirty("Customerlocationvisitingaddress");
			}
		}




		[SoapElement(ElementName="CustomerLocationEmail")]
		[XmlElement(ElementName="CustomerLocationEmail")]
		public string gxTpr_Customerlocationemail
		{
			get {
				return gxTv_SdtCustomerLocationSDT_Customerlocationemail; 
			}
			set {
				gxTv_SdtCustomerLocationSDT_Customerlocationemail = value;
				SetDirty("Customerlocationemail");
			}
		}




		[SoapElement(ElementName="CustomerLocationPhone")]
		[XmlElement(ElementName="CustomerLocationPhone")]
		public string gxTpr_Customerlocationphone
		{
			get {
				return gxTv_SdtCustomerLocationSDT_Customerlocationphone; 
			}
			set {
				gxTv_SdtCustomerLocationSDT_Customerlocationphone = value;
				SetDirty("Customerlocationphone");
			}
		}




		[SoapElement(ElementName="CustomerLocationPostalAddress")]
		[XmlElement(ElementName="CustomerLocationPostalAddress")]
		public string gxTpr_Customerlocationpostaladdress
		{
			get {
				return gxTv_SdtCustomerLocationSDT_Customerlocationpostaladdress; 
			}
			set {
				gxTv_SdtCustomerLocationSDT_Customerlocationpostaladdress = value;
				SetDirty("Customerlocationpostaladdress");
			}
		}




		[SoapElement(ElementName="CustomerLocationLastLine")]
		[XmlElement(ElementName="CustomerLocationLastLine")]
		public short gxTpr_Customerlocationlastline
		{
			get {
				return gxTv_SdtCustomerLocationSDT_Customerlocationlastline; 
			}
			set {
				gxTv_SdtCustomerLocationSDT_Customerlocationlastline = value;
				SetDirty("Customerlocationlastline");
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
			gxTv_SdtCustomerLocationSDT_Customerlocationname = "";
			gxTv_SdtCustomerLocationSDT_Customerlocationdescription = "";
			gxTv_SdtCustomerLocationSDT_Customerlocationvisitingaddress = "";
			gxTv_SdtCustomerLocationSDT_Customerlocationemail = "";
			gxTv_SdtCustomerLocationSDT_Customerlocationphone = "";
			gxTv_SdtCustomerLocationSDT_Customerlocationpostaladdress = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCustomerLocationSDT_Customerid;
		 

		protected short gxTv_SdtCustomerLocationSDT_Customerlocationid;
		 

		protected string gxTv_SdtCustomerLocationSDT_Customerlocationname;
		 

		protected string gxTv_SdtCustomerLocationSDT_Customerlocationdescription;
		 

		protected string gxTv_SdtCustomerLocationSDT_Customerlocationvisitingaddress;
		 

		protected string gxTv_SdtCustomerLocationSDT_Customerlocationemail;
		 

		protected string gxTv_SdtCustomerLocationSDT_Customerlocationphone;
		 

		protected string gxTv_SdtCustomerLocationSDT_Customerlocationpostaladdress;
		 

		protected short gxTv_SdtCustomerLocationSDT_Customerlocationlastline;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CustomerLocationSDT", Namespace="Comforta2")]
	public class SdtCustomerLocationSDT_RESTInterface : GxGenericCollectionItem<SdtCustomerLocationSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCustomerLocationSDT_RESTInterface( ) : base()
		{	
		}

		public SdtCustomerLocationSDT_RESTInterface( SdtCustomerLocationSDT psdt ) : base(psdt)
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

		[DataMember(Name="CustomerLocationId", Order=1)]
		public short gxTpr_Customerlocationid
		{
			get { 
				return sdt.gxTpr_Customerlocationid;

			}
			set { 
				sdt.gxTpr_Customerlocationid = value;
			}
		}

		[DataMember(Name="CustomerLocationName", Order=2)]
		public  string gxTpr_Customerlocationname
		{
			get { 
				return sdt.gxTpr_Customerlocationname;

			}
			set { 
				 sdt.gxTpr_Customerlocationname = value;
			}
		}

		[DataMember(Name="CustomerLocationDescription", Order=3)]
		public  string gxTpr_Customerlocationdescription
		{
			get { 
				return sdt.gxTpr_Customerlocationdescription;

			}
			set { 
				 sdt.gxTpr_Customerlocationdescription = value;
			}
		}

		[DataMember(Name="CustomerLocationVisitingAddress", Order=4)]
		public  string gxTpr_Customerlocationvisitingaddress
		{
			get { 
				return sdt.gxTpr_Customerlocationvisitingaddress;

			}
			set { 
				 sdt.gxTpr_Customerlocationvisitingaddress = value;
			}
		}

		[DataMember(Name="CustomerLocationEmail", Order=5)]
		public  string gxTpr_Customerlocationemail
		{
			get { 
				return sdt.gxTpr_Customerlocationemail;

			}
			set { 
				 sdt.gxTpr_Customerlocationemail = value;
			}
		}

		[DataMember(Name="CustomerLocationPhone", Order=6)]
		public  string gxTpr_Customerlocationphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerlocationphone);

			}
			set { 
				 sdt.gxTpr_Customerlocationphone = value;
			}
		}

		[DataMember(Name="CustomerLocationPostalAddress", Order=7)]
		public  string gxTpr_Customerlocationpostaladdress
		{
			get { 
				return sdt.gxTpr_Customerlocationpostaladdress;

			}
			set { 
				 sdt.gxTpr_Customerlocationpostaladdress = value;
			}
		}

		[DataMember(Name="CustomerLocationLastLine", Order=8)]
		public short gxTpr_Customerlocationlastline
		{
			get { 
				return sdt.gxTpr_Customerlocationlastline;

			}
			set { 
				sdt.gxTpr_Customerlocationlastline = value;
			}
		}


		#endregion

		public SdtCustomerLocationSDT sdt
		{
			get { 
				return (SdtCustomerLocationSDT)Sdt;
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
				sdt = new SdtCustomerLocationSDT() ;
			}
		}
	}
	#endregion
}