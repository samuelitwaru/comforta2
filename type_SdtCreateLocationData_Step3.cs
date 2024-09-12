/*
				   File: type_SdtCreateLocationData_Step3
			Description: Step3
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
	[XmlRoot(ElementName="CreateLocationData.Step3")]
	[XmlType(TypeName="CreateLocationData.Step3" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateLocationData_Step3 : GxUserType
	{
		public SdtCreateLocationData_Step3( )
		{
			/* Constructor for serialization */
			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistgivenname = "";

			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistlastname = "";

			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistinitials = "";

			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistemail = "";

			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistphone = "";

			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistaddress = "";

		}

		public SdtCreateLocationData_Step3(IGxContext context)
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
			AddObjectProperty("CustomerLocationReceptionistId", gxTpr_Customerlocationreceptionistid, false);


			AddObjectProperty("CustomerLocationReceptionistGivenName", gxTpr_Customerlocationreceptionistgivenname, false);


			AddObjectProperty("CustomerLocationReceptionistLastName", gxTpr_Customerlocationreceptionistlastname, false);


			AddObjectProperty("CustomerLocationReceptionistInitials", gxTpr_Customerlocationreceptionistinitials, false);


			AddObjectProperty("CustomerLocationReceptionistEmail", gxTpr_Customerlocationreceptionistemail, false);


			AddObjectProperty("CustomerLocationReceptionistPhone", gxTpr_Customerlocationreceptionistphone, false);


			AddObjectProperty("CustomerLocationReceptionistAddress", gxTpr_Customerlocationreceptionistaddress, false);

			if (gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts != null)
			{
				AddObjectProperty("LocationReceptionistSDTs", gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerLocationReceptionistId")]
		[XmlElement(ElementName="CustomerLocationReceptionistId")]
		public short gxTpr_Customerlocationreceptionistid
		{
			get {
				return gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistid; 
			}
			set {
				gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistid = value;
				SetDirty("Customerlocationreceptionistid");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistGivenName")]
		[XmlElement(ElementName="CustomerLocationReceptionistGivenName")]
		public string gxTpr_Customerlocationreceptionistgivenname
		{
			get {
				return gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistgivenname; 
			}
			set {
				gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistgivenname = value;
				SetDirty("Customerlocationreceptionistgivenname");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistLastName")]
		[XmlElement(ElementName="CustomerLocationReceptionistLastName")]
		public string gxTpr_Customerlocationreceptionistlastname
		{
			get {
				return gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistlastname; 
			}
			set {
				gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistlastname = value;
				SetDirty("Customerlocationreceptionistlastname");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistInitials")]
		[XmlElement(ElementName="CustomerLocationReceptionistInitials")]
		public string gxTpr_Customerlocationreceptionistinitials
		{
			get {
				return gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistinitials; 
			}
			set {
				gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistinitials = value;
				SetDirty("Customerlocationreceptionistinitials");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistEmail")]
		[XmlElement(ElementName="CustomerLocationReceptionistEmail")]
		public string gxTpr_Customerlocationreceptionistemail
		{
			get {
				return gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistemail; 
			}
			set {
				gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistemail = value;
				SetDirty("Customerlocationreceptionistemail");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistPhone")]
		[XmlElement(ElementName="CustomerLocationReceptionistPhone")]
		public string gxTpr_Customerlocationreceptionistphone
		{
			get {
				return gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistphone; 
			}
			set {
				gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistphone = value;
				SetDirty("Customerlocationreceptionistphone");
			}
		}




		[SoapElement(ElementName="CustomerLocationReceptionistAddress")]
		[XmlElement(ElementName="CustomerLocationReceptionistAddress")]
		public string gxTpr_Customerlocationreceptionistaddress
		{
			get {
				return gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistaddress; 
			}
			set {
				gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistaddress = value;
				SetDirty("Customerlocationreceptionistaddress");
			}
		}




		[SoapElement(ElementName="LocationReceptionistSDTs" )]
		[XmlArray(ElementName="LocationReceptionistSDTs"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtLocationReceptionistSDT> gxTpr_Locationreceptionistsdts_GXBaseCollection
		{
			get {
				if ( gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts == null )
				{
					gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts = new GXBaseCollection<GeneXus.Programs.SdtLocationReceptionistSDT>( context, "LocationReceptionistSDT", "");
				}
				return gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts;
			}
			set {
				gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts_N = false;
				gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtLocationReceptionistSDT> gxTpr_Locationreceptionistsdts
		{
			get {
				if ( gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts == null )
				{
					gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts = new GXBaseCollection<GeneXus.Programs.SdtLocationReceptionistSDT>( context, "LocationReceptionistSDT", "");
				}
				gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts_N = false;
				return gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts ;
			}
			set {
				gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts_N = false;
				gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts = value;
				SetDirty("Locationreceptionistsdts");
			}
		}

		public void gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts_SetNull()
		{
			gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts_N = true;
			gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts = null;
		}

		public bool gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts_IsNull()
		{
			return gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts == null;
		}
		public bool ShouldSerializegxTpr_Locationreceptionistsdts_GXBaseCollection_Json()
		{
			return gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts != null && gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts.Count > 0;

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
			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistgivenname = "";
			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistlastname = "";
			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistinitials = "";
			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistemail = "";
			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistphone = "";
			gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistaddress = "";

			gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistid;
		 

		protected string gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistgivenname;
		 

		protected string gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistlastname;
		 

		protected string gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistinitials;
		 

		protected string gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistemail;
		 

		protected string gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistphone;
		 

		protected string gxTv_SdtCreateLocationData_Step3_Customerlocationreceptionistaddress;
		 
		protected bool gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts_N;
		protected GXBaseCollection<GeneXus.Programs.SdtLocationReceptionistSDT> gxTv_SdtCreateLocationData_Step3_Locationreceptionistsdts = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateLocationData.Step3", Namespace="Comforta2")]
	public class SdtCreateLocationData_Step3_RESTInterface : GxGenericCollectionItem<SdtCreateLocationData_Step3>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateLocationData_Step3_RESTInterface( ) : base()
		{	
		}

		public SdtCreateLocationData_Step3_RESTInterface( SdtCreateLocationData_Step3 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerLocationReceptionistId", Order=0)]
		public short gxTpr_Customerlocationreceptionistid
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistid;

			}
			set { 
				sdt.gxTpr_Customerlocationreceptionistid = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistGivenName", Order=1)]
		public  string gxTpr_Customerlocationreceptionistgivenname
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistgivenname;

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistgivenname = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistLastName", Order=2)]
		public  string gxTpr_Customerlocationreceptionistlastname
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistlastname;

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistlastname = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistInitials", Order=3)]
		public  string gxTpr_Customerlocationreceptionistinitials
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerlocationreceptionistinitials);

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistinitials = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistEmail", Order=4)]
		public  string gxTpr_Customerlocationreceptionistemail
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistemail;

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistemail = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistPhone", Order=5)]
		public  string gxTpr_Customerlocationreceptionistphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerlocationreceptionistphone);

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistphone = value;
			}
		}

		[DataMember(Name="CustomerLocationReceptionistAddress", Order=6)]
		public  string gxTpr_Customerlocationreceptionistaddress
		{
			get { 
				return sdt.gxTpr_Customerlocationreceptionistaddress;

			}
			set { 
				 sdt.gxTpr_Customerlocationreceptionistaddress = value;
			}
		}

		[DataMember(Name="LocationReceptionistSDTs", Order=7, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtLocationReceptionistSDT_RESTInterface> gxTpr_Locationreceptionistsdts
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Locationreceptionistsdts_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtLocationReceptionistSDT_RESTInterface>(sdt.gxTpr_Locationreceptionistsdts);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Locationreceptionistsdts);
			}
		}


		#endregion

		public SdtCreateLocationData_Step3 sdt
		{
			get { 
				return (SdtCreateLocationData_Step3)Sdt;
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
				sdt = new SdtCreateLocationData_Step3() ;
			}
		}
	}
	#endregion
}