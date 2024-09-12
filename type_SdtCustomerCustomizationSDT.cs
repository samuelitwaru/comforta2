/*
				   File: type_SdtCustomerCustomizationSDT
			Description: CustomerCustomizationSDT
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
	[XmlRoot(ElementName="CustomerCustomizationSDT")]
	[XmlType(TypeName="CustomerCustomizationSDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCustomerCustomizationSDT : GxUserType
	{
		public SdtCustomerCustomizationSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo = "";
			gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo_gxi = "";
			gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon = "";
			gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon_gxi = "";
			gxTv_SdtCustomerCustomizationSDT_Customercustomizationbasecolor = "";

			gxTv_SdtCustomerCustomizationSDT_Customercustomizationfontsize = "";

		}

		public SdtCustomerCustomizationSDT(IGxContext context)
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
			AddObjectProperty("CustomerCustomizationId", gxTpr_Customercustomizationid, false);


			AddObjectProperty("CustomerCustomizationLogo", gxTpr_Customercustomizationlogo, false);
			AddObjectProperty("CustomerCustomizationLogo_GXI", gxTpr_Customercustomizationlogo_gxi, false);



			AddObjectProperty("CustomerCustomizationFavicon", gxTpr_Customercustomizationfavicon, false);
			AddObjectProperty("CustomerCustomizationFavicon_GXI", gxTpr_Customercustomizationfavicon_gxi, false);



			AddObjectProperty("CustomerCustomizationBaseColor", gxTpr_Customercustomizationbasecolor, false);


			AddObjectProperty("CustomerCustomizationFontSize", gxTpr_Customercustomizationfontsize, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerCustomizationId")]
		[XmlElement(ElementName="CustomerCustomizationId")]
		public short gxTpr_Customercustomizationid
		{
			get {
				return gxTv_SdtCustomerCustomizationSDT_Customercustomizationid; 
			}
			set {
				gxTv_SdtCustomerCustomizationSDT_Customercustomizationid = value;
				SetDirty("Customercustomizationid");
			}
		}




		[SoapElement(ElementName="CustomerCustomizationLogo")]
		[XmlElement(ElementName="CustomerCustomizationLogo")]
		[GxUpload()]

		public string gxTpr_Customercustomizationlogo
		{
			get {
				return gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo; 
			}
			set {
				gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo = value;
				SetDirty("Customercustomizationlogo");
			}
		}


		[SoapElement(ElementName="CustomerCustomizationLogo_GXI" )]
		[XmlElement(ElementName="CustomerCustomizationLogo_GXI" )]
		public string gxTpr_Customercustomizationlogo_gxi
		{
			get {
				return gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo_gxi ;
			}
			set {
				gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo_gxi = value;
				SetDirty("Customercustomizationlogo_gxi");
			}
		}

		[SoapElement(ElementName="CustomerCustomizationFavicon")]
		[XmlElement(ElementName="CustomerCustomizationFavicon")]
		[GxUpload()]

		public string gxTpr_Customercustomizationfavicon
		{
			get {
				return gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon; 
			}
			set {
				gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon = value;
				SetDirty("Customercustomizationfavicon");
			}
		}


		[SoapElement(ElementName="CustomerCustomizationFavicon_GXI" )]
		[XmlElement(ElementName="CustomerCustomizationFavicon_GXI" )]
		public string gxTpr_Customercustomizationfavicon_gxi
		{
			get {
				return gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon_gxi ;
			}
			set {
				gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon_gxi = value;
				SetDirty("Customercustomizationfavicon_gxi");
			}
		}

		[SoapElement(ElementName="CustomerCustomizationBaseColor")]
		[XmlElement(ElementName="CustomerCustomizationBaseColor")]
		public string gxTpr_Customercustomizationbasecolor
		{
			get {
				return gxTv_SdtCustomerCustomizationSDT_Customercustomizationbasecolor; 
			}
			set {
				gxTv_SdtCustomerCustomizationSDT_Customercustomizationbasecolor = value;
				SetDirty("Customercustomizationbasecolor");
			}
		}




		[SoapElement(ElementName="CustomerCustomizationFontSize")]
		[XmlElement(ElementName="CustomerCustomizationFontSize")]
		public string gxTpr_Customercustomizationfontsize
		{
			get {
				return gxTv_SdtCustomerCustomizationSDT_Customercustomizationfontsize; 
			}
			set {
				gxTv_SdtCustomerCustomizationSDT_Customercustomizationfontsize = value;
				SetDirty("Customercustomizationfontsize");
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
			gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo = "";gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo_gxi = "";
			gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon = "";gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon_gxi = "";
			gxTv_SdtCustomerCustomizationSDT_Customercustomizationbasecolor = "";
			gxTv_SdtCustomerCustomizationSDT_Customercustomizationfontsize = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtCustomerCustomizationSDT_Customercustomizationid;
		 
		protected string gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo_gxi;
		protected string gxTv_SdtCustomerCustomizationSDT_Customercustomizationlogo;
		 
		protected string gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon_gxi;
		protected string gxTv_SdtCustomerCustomizationSDT_Customercustomizationfavicon;
		 

		protected string gxTv_SdtCustomerCustomizationSDT_Customercustomizationbasecolor;
		 

		protected string gxTv_SdtCustomerCustomizationSDT_Customercustomizationfontsize;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CustomerCustomizationSDT", Namespace="Comforta2")]
	public class SdtCustomerCustomizationSDT_RESTInterface : GxGenericCollectionItem<SdtCustomerCustomizationSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCustomerCustomizationSDT_RESTInterface( ) : base()
		{	
		}

		public SdtCustomerCustomizationSDT_RESTInterface( SdtCustomerCustomizationSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerCustomizationId", Order=0)]
		public short gxTpr_Customercustomizationid
		{
			get { 
				return sdt.gxTpr_Customercustomizationid;

			}
			set { 
				sdt.gxTpr_Customercustomizationid = value;
			}
		}

		[DataMember(Name="CustomerCustomizationLogo", Order=1)]
		[GxUpload()]
		public  string gxTpr_Customercustomizationlogo
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Customercustomizationlogo)) ? PathUtil.RelativePath( sdt.gxTpr_Customercustomizationlogo) : StringUtil.RTrim( sdt.gxTpr_Customercustomizationlogo_gxi));

			}
			set { 
				 sdt.gxTpr_Customercustomizationlogo = value;
			}
		}

		[DataMember(Name="CustomerCustomizationFavicon", Order=2)]
		[GxUpload()]
		public  string gxTpr_Customercustomizationfavicon
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Customercustomizationfavicon)) ? PathUtil.RelativePath( sdt.gxTpr_Customercustomizationfavicon) : StringUtil.RTrim( sdt.gxTpr_Customercustomizationfavicon_gxi));

			}
			set { 
				 sdt.gxTpr_Customercustomizationfavicon = value;
			}
		}

		[DataMember(Name="CustomerCustomizationBaseColor", Order=3)]
		public  string gxTpr_Customercustomizationbasecolor
		{
			get { 
				return sdt.gxTpr_Customercustomizationbasecolor;

			}
			set { 
				 sdt.gxTpr_Customercustomizationbasecolor = value;
			}
		}

		[DataMember(Name="CustomerCustomizationFontSize", Order=4)]
		public  string gxTpr_Customercustomizationfontsize
		{
			get { 
				return sdt.gxTpr_Customercustomizationfontsize;

			}
			set { 
				 sdt.gxTpr_Customercustomizationfontsize = value;
			}
		}


		#endregion

		public SdtCustomerCustomizationSDT sdt
		{
			get { 
				return (SdtCustomerCustomizationSDT)Sdt;
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
				sdt = new SdtCustomerCustomizationSDT() ;
			}
		}
	}
	#endregion
}