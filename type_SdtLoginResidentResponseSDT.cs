/*
				   File: type_SdtLoginResidentResponseSDT
			Description: LoginResidentResponseSDT
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
	[XmlRoot(ElementName="LoginResidentResponseSDT")]
	[XmlType(TypeName="LoginResidentResponseSDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtLoginResidentResponseSDT : GxUserType
	{
		public SdtLoginResidentResponseSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtLoginResidentResponseSDT_Access_token = "";

			gxTv_SdtLoginResidentResponseSDT_Token_type = "";

			gxTv_SdtLoginResidentResponseSDT_Refresh_token = "";

			gxTv_SdtLoginResidentResponseSDT_Scope = "";

			gxTv_SdtLoginResidentResponseSDT_User_guid = "";

		}

		public SdtLoginResidentResponseSDT(IGxContext context)
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
			AddObjectProperty("access_token", gxTpr_Access_token, false);


			AddObjectProperty("token_type", gxTpr_Token_type, false);


			AddObjectProperty("expires_in", gxTpr_Expires_in, false);


			AddObjectProperty("refresh_token", gxTpr_Refresh_token, false);


			AddObjectProperty("scope", gxTpr_Scope, false);


			AddObjectProperty("user_guid", gxTpr_User_guid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="access_token")]
		[XmlElement(ElementName="access_token")]
		public string gxTpr_Access_token
		{
			get {
				return gxTv_SdtLoginResidentResponseSDT_Access_token; 
			}
			set {
				gxTv_SdtLoginResidentResponseSDT_Access_token = value;
				SetDirty("Access_token");
			}
		}




		[SoapElement(ElementName="token_type")]
		[XmlElement(ElementName="token_type")]
		public string gxTpr_Token_type
		{
			get {
				return gxTv_SdtLoginResidentResponseSDT_Token_type; 
			}
			set {
				gxTv_SdtLoginResidentResponseSDT_Token_type = value;
				SetDirty("Token_type");
			}
		}



		[SoapElement(ElementName="expires_in")]
		[XmlElement(ElementName="expires_in")]
		public string gxTpr_Expires_in_double
		{
			get {
				return Convert.ToString(gxTv_SdtLoginResidentResponseSDT_Expires_in, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtLoginResidentResponseSDT_Expires_in = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Expires_in
		{
			get {
				return gxTv_SdtLoginResidentResponseSDT_Expires_in; 
			}
			set {
				gxTv_SdtLoginResidentResponseSDT_Expires_in = value;
				SetDirty("Expires_in");
			}
		}




		[SoapElement(ElementName="refresh_token")]
		[XmlElement(ElementName="refresh_token")]
		public string gxTpr_Refresh_token
		{
			get {
				return gxTv_SdtLoginResidentResponseSDT_Refresh_token; 
			}
			set {
				gxTv_SdtLoginResidentResponseSDT_Refresh_token = value;
				SetDirty("Refresh_token");
			}
		}




		[SoapElement(ElementName="scope")]
		[XmlElement(ElementName="scope")]
		public string gxTpr_Scope
		{
			get {
				return gxTv_SdtLoginResidentResponseSDT_Scope; 
			}
			set {
				gxTv_SdtLoginResidentResponseSDT_Scope = value;
				SetDirty("Scope");
			}
		}




		[SoapElement(ElementName="user_guid")]
		[XmlElement(ElementName="user_guid")]
		public string gxTpr_User_guid
		{
			get {
				return gxTv_SdtLoginResidentResponseSDT_User_guid; 
			}
			set {
				gxTv_SdtLoginResidentResponseSDT_User_guid = value;
				SetDirty("User_guid");
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
			gxTv_SdtLoginResidentResponseSDT_Access_token = "";
			gxTv_SdtLoginResidentResponseSDT_Token_type = "";

			gxTv_SdtLoginResidentResponseSDT_Refresh_token = "";
			gxTv_SdtLoginResidentResponseSDT_Scope = "";
			gxTv_SdtLoginResidentResponseSDT_User_guid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtLoginResidentResponseSDT_Access_token;
		 

		protected string gxTv_SdtLoginResidentResponseSDT_Token_type;
		 

		protected decimal gxTv_SdtLoginResidentResponseSDT_Expires_in;
		 

		protected string gxTv_SdtLoginResidentResponseSDT_Refresh_token;
		 

		protected string gxTv_SdtLoginResidentResponseSDT_Scope;
		 

		protected string gxTv_SdtLoginResidentResponseSDT_User_guid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"LoginResidentResponseSDT", Namespace="Comforta2")]
	public class SdtLoginResidentResponseSDT_RESTInterface : GxGenericCollectionItem<SdtLoginResidentResponseSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLoginResidentResponseSDT_RESTInterface( ) : base()
		{	
		}

		public SdtLoginResidentResponseSDT_RESTInterface( SdtLoginResidentResponseSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="access_token", Order=0)]
		public  string gxTpr_Access_token
		{
			get { 
				return sdt.gxTpr_Access_token;

			}
			set { 
				 sdt.gxTpr_Access_token = value;
			}
		}

		[DataMember(Name="token_type", Order=1)]
		public  string gxTpr_Token_type
		{
			get { 
				return sdt.gxTpr_Token_type;

			}
			set { 
				 sdt.gxTpr_Token_type = value;
			}
		}

		[DataMember(Name="expires_in", Order=2)]
		public decimal gxTpr_Expires_in
		{
			get { 
				return sdt.gxTpr_Expires_in;

			}
			set { 
				sdt.gxTpr_Expires_in = value;
			}
		}

		[DataMember(Name="refresh_token", Order=3)]
		public  string gxTpr_Refresh_token
		{
			get { 
				return sdt.gxTpr_Refresh_token;

			}
			set { 
				 sdt.gxTpr_Refresh_token = value;
			}
		}

		[DataMember(Name="scope", Order=4)]
		public  string gxTpr_Scope
		{
			get { 
				return sdt.gxTpr_Scope;

			}
			set { 
				 sdt.gxTpr_Scope = value;
			}
		}

		[DataMember(Name="user_guid", Order=5)]
		public  string gxTpr_User_guid
		{
			get { 
				return sdt.gxTpr_User_guid;

			}
			set { 
				 sdt.gxTpr_User_guid = value;
			}
		}


		#endregion

		public SdtLoginResidentResponseSDT sdt
		{
			get { 
				return (SdtLoginResidentResponseSDT)Sdt;
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
				sdt = new SdtLoginResidentResponseSDT() ;
			}
		}
	}
	#endregion
}