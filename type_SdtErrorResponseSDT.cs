/*
				   File: type_SdtErrorResponseSDT
			Description: ErrorResponseSDT
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
	[XmlRoot(ElementName="ErrorResponseSDT")]
	[XmlType(TypeName="ErrorResponseSDT" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtErrorResponseSDT : GxUserType
	{
		public SdtErrorResponseSDT( )
		{
			/* Constructor for serialization */
		}

		public SdtErrorResponseSDT(IGxContext context)
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
			if (gxTv_SdtErrorResponseSDT_Error != null)
			{
				AddObjectProperty("error", gxTv_SdtErrorResponseSDT_Error, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="error" )]
		[XmlElement(ElementName="error" )]
		public SdtErrorResponseSDT_error gxTpr_Error
		{
			get {
				if ( gxTv_SdtErrorResponseSDT_Error == null )
				{
					gxTv_SdtErrorResponseSDT_Error = new SdtErrorResponseSDT_error(context);
				}
				gxTv_SdtErrorResponseSDT_Error_N = false;
				return gxTv_SdtErrorResponseSDT_Error;
			}
			set {
				gxTv_SdtErrorResponseSDT_Error_N = false;
				gxTv_SdtErrorResponseSDT_Error = value;
				SetDirty("Error");
			}

		}

		public void gxTv_SdtErrorResponseSDT_Error_SetNull()
		{
			gxTv_SdtErrorResponseSDT_Error_N = true;
			gxTv_SdtErrorResponseSDT_Error = null;
		}

		public bool gxTv_SdtErrorResponseSDT_Error_IsNull()
		{
			return gxTv_SdtErrorResponseSDT_Error == null;
		}
		public bool ShouldSerializegxTpr_Error_Json()
		{
				return (gxTv_SdtErrorResponseSDT_Error != null && gxTv_SdtErrorResponseSDT_Error.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Error_Json() || 
				false);
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
			gxTv_SdtErrorResponseSDT_Error_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtErrorResponseSDT_Error_N;
		protected SdtErrorResponseSDT_error gxTv_SdtErrorResponseSDT_Error = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ErrorResponseSDT", Namespace="Comforta2")]
	public class SdtErrorResponseSDT_RESTInterface : GxGenericCollectionItem<SdtErrorResponseSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtErrorResponseSDT_RESTInterface( ) : base()
		{	
		}

		public SdtErrorResponseSDT_RESTInterface( SdtErrorResponseSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="error", Order=0, EmitDefaultValue=false)]
		public SdtErrorResponseSDT_error_RESTInterface gxTpr_Error
		{
			get {
				if (sdt.ShouldSerializegxTpr_Error_Json())
					return new SdtErrorResponseSDT_error_RESTInterface(sdt.gxTpr_Error);
				else
					return null;

			}

			set {
				sdt.gxTpr_Error = value.sdt;
			}

		}


		#endregion

		public SdtErrorResponseSDT sdt
		{
			get { 
				return (SdtErrorResponseSDT)Sdt;
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
				sdt = new SdtErrorResponseSDT() ;
			}
		}
	}
	#endregion
}