/*
				   File: type_SdtCreateResidentData_Step2
			Description: Step2
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
	[XmlRoot(ElementName="CreateResidentData.Step2")]
	[XmlType(TypeName="CreateResidentData.Step2" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateResidentData_Step2 : GxUserType
	{
		public SdtCreateResidentData_Step2( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateResidentData_Step2_Residentinindividualgivenname = "";

			gxTv_SdtCreateResidentData_Step2_Residentinindividuallastname = "";

			gxTv_SdtCreateResidentData_Step2_Residentinindividualbsnnumber = "";

			gxTv_SdtCreateResidentData_Step2_Residentinindividualgender = "";

			gxTv_SdtCreateResidentData_Step2_Residentinindividualemail = "";

			gxTv_SdtCreateResidentData_Step2_Residentinindividualphone = "";

			gxTv_SdtCreateResidentData_Step2_Residentinindividualaddress = "";

		}

		public SdtCreateResidentData_Step2(IGxContext context)
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
			AddObjectProperty("ResidentINIndividualId", gxTpr_Residentinindividualid, false);


			AddObjectProperty("ResidentINIndividualGivenName", gxTpr_Residentinindividualgivenname, false);


			AddObjectProperty("ResidentINIndividualLastName", gxTpr_Residentinindividuallastname, false);


			AddObjectProperty("ResidentINIndividualBsnNumber", gxTpr_Residentinindividualbsnnumber, false);


			AddObjectProperty("ResidentINIndividualGender", gxTpr_Residentinindividualgender, false);


			AddObjectProperty("ResidentINIndividualEmail", gxTpr_Residentinindividualemail, false);


			AddObjectProperty("ResidentINIndividualPhone", gxTpr_Residentinindividualphone, false);


			AddObjectProperty("ResidentINIndividualAddress", gxTpr_Residentinindividualaddress, false);

			if (gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts != null)
			{
				AddObjectProperty("ResidentINIndividualSDTs", gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentINIndividualId")]
		[XmlElement(ElementName="ResidentINIndividualId")]
		public short gxTpr_Residentinindividualid
		{
			get {
				return gxTv_SdtCreateResidentData_Step2_Residentinindividualid; 
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividualid = value;
				SetDirty("Residentinindividualid");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualGivenName")]
		[XmlElement(ElementName="ResidentINIndividualGivenName")]
		public string gxTpr_Residentinindividualgivenname
		{
			get {
				return gxTv_SdtCreateResidentData_Step2_Residentinindividualgivenname; 
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividualgivenname = value;
				SetDirty("Residentinindividualgivenname");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualLastName")]
		[XmlElement(ElementName="ResidentINIndividualLastName")]
		public string gxTpr_Residentinindividuallastname
		{
			get {
				return gxTv_SdtCreateResidentData_Step2_Residentinindividuallastname; 
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividuallastname = value;
				SetDirty("Residentinindividuallastname");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualBsnNumber")]
		[XmlElement(ElementName="ResidentINIndividualBsnNumber")]
		public string gxTpr_Residentinindividualbsnnumber
		{
			get {
				return gxTv_SdtCreateResidentData_Step2_Residentinindividualbsnnumber; 
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividualbsnnumber = value;
				SetDirty("Residentinindividualbsnnumber");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualGender")]
		[XmlElement(ElementName="ResidentINIndividualGender")]
		public string gxTpr_Residentinindividualgender
		{
			get {
				return gxTv_SdtCreateResidentData_Step2_Residentinindividualgender; 
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividualgender = value;
				SetDirty("Residentinindividualgender");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualEmail")]
		[XmlElement(ElementName="ResidentINIndividualEmail")]
		public string gxTpr_Residentinindividualemail
		{
			get {
				return gxTv_SdtCreateResidentData_Step2_Residentinindividualemail; 
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividualemail = value;
				SetDirty("Residentinindividualemail");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualPhone")]
		[XmlElement(ElementName="ResidentINIndividualPhone")]
		public string gxTpr_Residentinindividualphone
		{
			get {
				return gxTv_SdtCreateResidentData_Step2_Residentinindividualphone; 
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividualphone = value;
				SetDirty("Residentinindividualphone");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualAddress")]
		[XmlElement(ElementName="ResidentINIndividualAddress")]
		public string gxTpr_Residentinindividualaddress
		{
			get {
				return gxTv_SdtCreateResidentData_Step2_Residentinindividualaddress; 
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividualaddress = value;
				SetDirty("Residentinindividualaddress");
			}
		}




		[SoapElement(ElementName="ResidentINIndividualSDTs" )]
		[XmlArray(ElementName="ResidentINIndividualSDTs"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtResidentINIndividualSDT> gxTpr_Residentinindividualsdts_GXBaseCollection
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts == null )
				{
					gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts = new GXBaseCollection<GeneXus.Programs.SdtResidentINIndividualSDT>( context, "ResidentINIndividualSDT", "");
				}
				return gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts;
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts_N = false;
				gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtResidentINIndividualSDT> gxTpr_Residentinindividualsdts
		{
			get {
				if ( gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts == null )
				{
					gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts = new GXBaseCollection<GeneXus.Programs.SdtResidentINIndividualSDT>( context, "ResidentINIndividualSDT", "");
				}
				gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts_N = false;
				return gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts ;
			}
			set {
				gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts_N = false;
				gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts = value;
				SetDirty("Residentinindividualsdts");
			}
		}

		public void gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts_SetNull()
		{
			gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts_N = true;
			gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts = null;
		}

		public bool gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts_IsNull()
		{
			return gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts == null;
		}
		public bool ShouldSerializegxTpr_Residentinindividualsdts_GXBaseCollection_Json()
		{
			return gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts != null && gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts.Count > 0;

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
			gxTv_SdtCreateResidentData_Step2_Residentinindividualgivenname = "";
			gxTv_SdtCreateResidentData_Step2_Residentinindividuallastname = "";
			gxTv_SdtCreateResidentData_Step2_Residentinindividualbsnnumber = "";
			gxTv_SdtCreateResidentData_Step2_Residentinindividualgender = "";
			gxTv_SdtCreateResidentData_Step2_Residentinindividualemail = "";
			gxTv_SdtCreateResidentData_Step2_Residentinindividualphone = "";
			gxTv_SdtCreateResidentData_Step2_Residentinindividualaddress = "";

			gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCreateResidentData_Step2_Residentinindividualid;
		 

		protected string gxTv_SdtCreateResidentData_Step2_Residentinindividualgivenname;
		 

		protected string gxTv_SdtCreateResidentData_Step2_Residentinindividuallastname;
		 

		protected string gxTv_SdtCreateResidentData_Step2_Residentinindividualbsnnumber;
		 

		protected string gxTv_SdtCreateResidentData_Step2_Residentinindividualgender;
		 

		protected string gxTv_SdtCreateResidentData_Step2_Residentinindividualemail;
		 

		protected string gxTv_SdtCreateResidentData_Step2_Residentinindividualphone;
		 

		protected string gxTv_SdtCreateResidentData_Step2_Residentinindividualaddress;
		 
		protected bool gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts_N;
		protected GXBaseCollection<GeneXus.Programs.SdtResidentINIndividualSDT> gxTv_SdtCreateResidentData_Step2_Residentinindividualsdts = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateResidentData.Step2", Namespace="Comforta2")]
	public class SdtCreateResidentData_Step2_RESTInterface : GxGenericCollectionItem<SdtCreateResidentData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateResidentData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtCreateResidentData_Step2_RESTInterface( SdtCreateResidentData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentINIndividualId", Order=0)]
		public short gxTpr_Residentinindividualid
		{
			get { 
				return sdt.gxTpr_Residentinindividualid;

			}
			set { 
				sdt.gxTpr_Residentinindividualid = value;
			}
		}

		[DataMember(Name="ResidentINIndividualGivenName", Order=1)]
		public  string gxTpr_Residentinindividualgivenname
		{
			get { 
				return sdt.gxTpr_Residentinindividualgivenname;

			}
			set { 
				 sdt.gxTpr_Residentinindividualgivenname = value;
			}
		}

		[DataMember(Name="ResidentINIndividualLastName", Order=2)]
		public  string gxTpr_Residentinindividuallastname
		{
			get { 
				return sdt.gxTpr_Residentinindividuallastname;

			}
			set { 
				 sdt.gxTpr_Residentinindividuallastname = value;
			}
		}

		[DataMember(Name="ResidentINIndividualBsnNumber", Order=3)]
		public  string gxTpr_Residentinindividualbsnnumber
		{
			get { 
				return sdt.gxTpr_Residentinindividualbsnnumber;

			}
			set { 
				 sdt.gxTpr_Residentinindividualbsnnumber = value;
			}
		}

		[DataMember(Name="ResidentINIndividualGender", Order=4)]
		public  string gxTpr_Residentinindividualgender
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentinindividualgender);

			}
			set { 
				 sdt.gxTpr_Residentinindividualgender = value;
			}
		}

		[DataMember(Name="ResidentINIndividualEmail", Order=5)]
		public  string gxTpr_Residentinindividualemail
		{
			get { 
				return sdt.gxTpr_Residentinindividualemail;

			}
			set { 
				 sdt.gxTpr_Residentinindividualemail = value;
			}
		}

		[DataMember(Name="ResidentINIndividualPhone", Order=6)]
		public  string gxTpr_Residentinindividualphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentinindividualphone);

			}
			set { 
				 sdt.gxTpr_Residentinindividualphone = value;
			}
		}

		[DataMember(Name="ResidentINIndividualAddress", Order=7)]
		public  string gxTpr_Residentinindividualaddress
		{
			get { 
				return sdt.gxTpr_Residentinindividualaddress;

			}
			set { 
				 sdt.gxTpr_Residentinindividualaddress = value;
			}
		}

		[DataMember(Name="ResidentINIndividualSDTs", Order=8, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtResidentINIndividualSDT_RESTInterface> gxTpr_Residentinindividualsdts
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Residentinindividualsdts_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtResidentINIndividualSDT_RESTInterface>(sdt.gxTpr_Residentinindividualsdts);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Residentinindividualsdts);
			}
		}


		#endregion

		public SdtCreateResidentData_Step2 sdt
		{
			get { 
				return (SdtCreateResidentData_Step2)Sdt;
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
				sdt = new SdtCreateResidentData_Step2() ;
			}
		}
	}
	#endregion
}