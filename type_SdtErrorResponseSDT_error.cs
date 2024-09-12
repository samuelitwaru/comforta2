/*
				   File: type_SdtErrorResponseSDT_error
			Description: error
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
	[XmlRoot(ElementName="ErrorResponseSDT.error")]
	[XmlType(TypeName="ErrorResponseSDT.error" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtErrorResponseSDT_error : GxUserType
	{
		public SdtErrorResponseSDT_error( )
		{
			/* Constructor for serialization */
			gxTv_SdtErrorResponseSDT_error_Code = "";

		}

		public SdtErrorResponseSDT_error(IGxContext context)
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
			AddObjectProperty("code", gxTpr_Code, false);


			AddObjectProperty("message", gxTpr_Message, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="code")]
		[XmlElement(ElementName="code")]
		public string gxTpr_Code
		{
			get {
				return gxTv_SdtErrorResponseSDT_error_Code; 
			}
			set {
				gxTv_SdtErrorResponseSDT_error_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="message")]
		[XmlElement(ElementName="message")]
		public short gxTpr_Message
		{
			get {
				return gxTv_SdtErrorResponseSDT_error_Message; 
			}
			set {
				gxTv_SdtErrorResponseSDT_error_Message = value;
				SetDirty("Message");
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
			gxTv_SdtErrorResponseSDT_error_Code = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtErrorResponseSDT_error_Code;
		 

		protected short gxTv_SdtErrorResponseSDT_error_Message;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ErrorResponseSDT.error", Namespace="Comforta2")]
	public class SdtErrorResponseSDT_error_RESTInterface : GxGenericCollectionItem<SdtErrorResponseSDT_error>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtErrorResponseSDT_error_RESTInterface( ) : base()
		{	
		}

		public SdtErrorResponseSDT_error_RESTInterface( SdtErrorResponseSDT_error psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="code", Order=0)]
		public  string gxTpr_Code
		{
			get { 
				return sdt.gxTpr_Code;

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="message", Order=1)]
		public short gxTpr_Message
		{
			get { 
				return sdt.gxTpr_Message;

			}
			set { 
				sdt.gxTpr_Message = value;
			}
		}


		#endregion

		public SdtErrorResponseSDT_error sdt
		{
			get { 
				return (SdtErrorResponseSDT_error)Sdt;
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
				sdt = new SdtErrorResponseSDT_error() ;
			}
		}
	}
	#endregion
}