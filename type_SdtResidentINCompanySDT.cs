/*
				   File: type_SdtResidentINCompanySDT
			Description: ResidentINCompanySDT
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
	[XmlRoot(ElementName="ResidentINCompanySDT")]
	[XmlType(TypeName="ResidentINCompanySDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtResidentINCompanySDT : GxUserType
	{
		public SdtResidentINCompanySDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtResidentINCompanySDT_Residentincompanykvknumber = "";

			gxTv_SdtResidentINCompanySDT_Residentincompanyname = "";

			gxTv_SdtResidentINCompanySDT_Residentincompanyemail = "";

			gxTv_SdtResidentINCompanySDT_Residentincompanyphone = "";

		}

		public SdtResidentINCompanySDT(IGxContext context)
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
			AddObjectProperty("ResidentINCompanyKvkNumber", gxTpr_Residentincompanykvknumber, false);


			AddObjectProperty("ResidentINCompanyName", gxTpr_Residentincompanyname, false);


			AddObjectProperty("ResidentINCompanyEmail", gxTpr_Residentincompanyemail, false);


			AddObjectProperty("ResidentINCompanyPhone", gxTpr_Residentincompanyphone, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentINCompanyKvkNumber")]
		[XmlElement(ElementName="ResidentINCompanyKvkNumber")]
		public string gxTpr_Residentincompanykvknumber
		{
			get {
				return gxTv_SdtResidentINCompanySDT_Residentincompanykvknumber; 
			}
			set {
				gxTv_SdtResidentINCompanySDT_Residentincompanykvknumber = value;
				SetDirty("Residentincompanykvknumber");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyName")]
		[XmlElement(ElementName="ResidentINCompanyName")]
		public string gxTpr_Residentincompanyname
		{
			get {
				return gxTv_SdtResidentINCompanySDT_Residentincompanyname; 
			}
			set {
				gxTv_SdtResidentINCompanySDT_Residentincompanyname = value;
				SetDirty("Residentincompanyname");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyEmail")]
		[XmlElement(ElementName="ResidentINCompanyEmail")]
		public string gxTpr_Residentincompanyemail
		{
			get {
				return gxTv_SdtResidentINCompanySDT_Residentincompanyemail; 
			}
			set {
				gxTv_SdtResidentINCompanySDT_Residentincompanyemail = value;
				SetDirty("Residentincompanyemail");
			}
		}




		[SoapElement(ElementName="ResidentINCompanyPhone")]
		[XmlElement(ElementName="ResidentINCompanyPhone")]
		public string gxTpr_Residentincompanyphone
		{
			get {
				return gxTv_SdtResidentINCompanySDT_Residentincompanyphone; 
			}
			set {
				gxTv_SdtResidentINCompanySDT_Residentincompanyphone = value;
				SetDirty("Residentincompanyphone");
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
			gxTv_SdtResidentINCompanySDT_Residentincompanykvknumber = "";
			gxTv_SdtResidentINCompanySDT_Residentincompanyname = "";
			gxTv_SdtResidentINCompanySDT_Residentincompanyemail = "";
			gxTv_SdtResidentINCompanySDT_Residentincompanyphone = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtResidentINCompanySDT_Residentincompanykvknumber;
		 

		protected string gxTv_SdtResidentINCompanySDT_Residentincompanyname;
		 

		protected string gxTv_SdtResidentINCompanySDT_Residentincompanyemail;
		 

		protected string gxTv_SdtResidentINCompanySDT_Residentincompanyphone;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ResidentINCompanySDT", Namespace="Comforta2")]
	public class SdtResidentINCompanySDT_RESTInterface : GxGenericCollectionItem<SdtResidentINCompanySDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResidentINCompanySDT_RESTInterface( ) : base()
		{	
		}

		public SdtResidentINCompanySDT_RESTInterface( SdtResidentINCompanySDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentINCompanyKvkNumber", Order=0)]
		public  string gxTpr_Residentincompanykvknumber
		{
			get { 
				return sdt.gxTpr_Residentincompanykvknumber;

			}
			set { 
				 sdt.gxTpr_Residentincompanykvknumber = value;
			}
		}

		[DataMember(Name="ResidentINCompanyName", Order=1)]
		public  string gxTpr_Residentincompanyname
		{
			get { 
				return sdt.gxTpr_Residentincompanyname;

			}
			set { 
				 sdt.gxTpr_Residentincompanyname = value;
			}
		}

		[DataMember(Name="ResidentINCompanyEmail", Order=2)]
		public  string gxTpr_Residentincompanyemail
		{
			get { 
				return sdt.gxTpr_Residentincompanyemail;

			}
			set { 
				 sdt.gxTpr_Residentincompanyemail = value;
			}
		}

		[DataMember(Name="ResidentINCompanyPhone", Order=3)]
		public  string gxTpr_Residentincompanyphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Residentincompanyphone);

			}
			set { 
				 sdt.gxTpr_Residentincompanyphone = value;
			}
		}


		#endregion

		public SdtResidentINCompanySDT sdt
		{
			get { 
				return (SdtResidentINCompanySDT)Sdt;
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
				sdt = new SdtResidentINCompanySDT() ;
			}
		}
	}
	#endregion
}