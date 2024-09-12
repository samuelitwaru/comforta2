/*
				   File: type_SdtCreateLocationData_Step2
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
	[XmlRoot(ElementName="CreateLocationData.Step2")]
	[XmlType(TypeName="CreateLocationData.Step2" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtCreateLocationData_Step2 : GxUserType
	{
		public SdtCreateLocationData_Step2( )
		{
			/* Constructor for serialization */
		}

		public SdtCreateLocationData_Step2(IGxContext context)
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
			if (gxTv_SdtCreateLocationData_Step2_Grid != null)
			{
				AddObjectProperty("Grid", gxTv_SdtCreateLocationData_Step2_Grid, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Grid" )]
		[XmlArray(ElementName="Grid"  )]
		[XmlArrayItemAttribute(ElementName="GridItem" , IsNullable=false )]
		public GXBaseCollection<SdtCreateLocationData_Step2_GridItem> gxTpr_Grid
		{
			get {
				if ( gxTv_SdtCreateLocationData_Step2_Grid == null )
				{
					gxTv_SdtCreateLocationData_Step2_Grid = new GXBaseCollection<SdtCreateLocationData_Step2_GridItem>( context, "CreateLocationData.Step2.GridItem", "");
				}
				return gxTv_SdtCreateLocationData_Step2_Grid;
			}
			set {
				gxTv_SdtCreateLocationData_Step2_Grid_N = false;
				gxTv_SdtCreateLocationData_Step2_Grid = value;
				SetDirty("Grid");
			}
		}

		public void gxTv_SdtCreateLocationData_Step2_Grid_SetNull()
		{
			gxTv_SdtCreateLocationData_Step2_Grid_N = true;
			gxTv_SdtCreateLocationData_Step2_Grid = null;
		}

		public bool gxTv_SdtCreateLocationData_Step2_Grid_IsNull()
		{
			return gxTv_SdtCreateLocationData_Step2_Grid == null;
		}
		public bool ShouldSerializegxTpr_Grid_GxSimpleCollection_Json()
		{
			return gxTv_SdtCreateLocationData_Step2_Grid != null && gxTv_SdtCreateLocationData_Step2_Grid.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Grid_GxSimpleCollection_Json() || 
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
			gxTv_SdtCreateLocationData_Step2_Grid_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtCreateLocationData_Step2_Grid_N;
		protected GXBaseCollection<SdtCreateLocationData_Step2_GridItem> gxTv_SdtCreateLocationData_Step2_Grid = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"CreateLocationData.Step2", Namespace="Comforta2")]
	public class SdtCreateLocationData_Step2_RESTInterface : GxGenericCollectionItem<SdtCreateLocationData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCreateLocationData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtCreateLocationData_Step2_RESTInterface( SdtCreateLocationData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Grid", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtCreateLocationData_Step2_GridItem_RESTInterface> gxTpr_Grid
		{
			get {
				if (sdt.ShouldSerializegxTpr_Grid_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtCreateLocationData_Step2_GridItem_RESTInterface>(sdt.gxTpr_Grid);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Grid);
			}
		}


		#endregion

		public SdtCreateLocationData_Step2 sdt
		{
			get { 
				return (SdtCreateLocationData_Step2)Sdt;
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
				sdt = new SdtCreateLocationData_Step2() ;
			}
		}
	}
	#endregion
}