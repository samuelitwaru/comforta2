/*
				   File: type_SdtSDTCustomer_LocationItem
			Description: Location
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
	[XmlRoot(ElementName="SDTCustomer.LocationItem")]
	[XmlType(TypeName="SDTCustomer.LocationItem" , Namespace="Comforta2" )]
	[Serializable]
	public class SdtSDTCustomer_LocationItem : GxUserType
	{
		public SdtSDTCustomer_LocationItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCustomer_LocationItem_Customerlocationvisitingaddress = "";

			gxTv_SdtSDTCustomer_LocationItem_Customerlocationpostaladdress = "";

			gxTv_SdtSDTCustomer_LocationItem_Customerlocationemail = "";

			gxTv_SdtSDTCustomer_LocationItem_Customerlocationphone = "";

		}

		public SdtSDTCustomer_LocationItem(IGxContext context)
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
			AddObjectProperty("CustomerLocationId", gxTpr_Customerlocationid, false);


			AddObjectProperty("CustomerLocationVisitingAddress", gxTpr_Customerlocationvisitingaddress, false);


			AddObjectProperty("CustomerLocationPostalAddress", gxTpr_Customerlocationpostaladdress, false);


			AddObjectProperty("CustomerLocationEmail", gxTpr_Customerlocationemail, false);


			AddObjectProperty("CustomerLocationPhone", gxTpr_Customerlocationphone, false);

			if (gxTv_SdtSDTCustomer_LocationItem_Receptionist != null)
			{
				AddObjectProperty("Receptionist", gxTv_SdtSDTCustomer_LocationItem_Receptionist, false);
			}
			if (gxTv_SdtSDTCustomer_LocationItem_Supplier_agb != null)
			{
				AddObjectProperty("Supplier_Agb", gxTv_SdtSDTCustomer_LocationItem_Supplier_agb, false);
			}
			if (gxTv_SdtSDTCustomer_LocationItem_Supplier_gen != null)
			{
				AddObjectProperty("Supplier_Gen", gxTv_SdtSDTCustomer_LocationItem_Supplier_gen, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CustomerLocationId")]
		[XmlElement(ElementName="CustomerLocationId")]
		public short gxTpr_Customerlocationid
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Customerlocationid; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Customerlocationid = value;
				SetDirty("Customerlocationid");
			}
		}




		[SoapElement(ElementName="CustomerLocationVisitingAddress")]
		[XmlElement(ElementName="CustomerLocationVisitingAddress")]
		public string gxTpr_Customerlocationvisitingaddress
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Customerlocationvisitingaddress; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Customerlocationvisitingaddress = value;
				SetDirty("Customerlocationvisitingaddress");
			}
		}




		[SoapElement(ElementName="CustomerLocationPostalAddress")]
		[XmlElement(ElementName="CustomerLocationPostalAddress")]
		public string gxTpr_Customerlocationpostaladdress
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Customerlocationpostaladdress; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Customerlocationpostaladdress = value;
				SetDirty("Customerlocationpostaladdress");
			}
		}




		[SoapElement(ElementName="CustomerLocationEmail")]
		[XmlElement(ElementName="CustomerLocationEmail")]
		public string gxTpr_Customerlocationemail
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Customerlocationemail; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Customerlocationemail = value;
				SetDirty("Customerlocationemail");
			}
		}




		[SoapElement(ElementName="CustomerLocationPhone")]
		[XmlElement(ElementName="CustomerLocationPhone")]
		public string gxTpr_Customerlocationphone
		{
			get {
				return gxTv_SdtSDTCustomer_LocationItem_Customerlocationphone; 
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Customerlocationphone = value;
				SetDirty("Customerlocationphone");
			}
		}




		[SoapElement(ElementName="Receptionist" )]
		[XmlArray(ElementName="Receptionist"  )]
		[XmlArrayItemAttribute(ElementName="ReceptionistItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTCustomer_LocationItem_ReceptionistItem> gxTpr_Receptionist
		{
			get {
				if ( gxTv_SdtSDTCustomer_LocationItem_Receptionist == null )
				{
					gxTv_SdtSDTCustomer_LocationItem_Receptionist = new GXBaseCollection<SdtSDTCustomer_LocationItem_ReceptionistItem>( context, "SDTCustomer.LocationItem.ReceptionistItem", "");
				}
				return gxTv_SdtSDTCustomer_LocationItem_Receptionist;
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Receptionist_N = false;
				gxTv_SdtSDTCustomer_LocationItem_Receptionist = value;
				SetDirty("Receptionist");
			}
		}

		public void gxTv_SdtSDTCustomer_LocationItem_Receptionist_SetNull()
		{
			gxTv_SdtSDTCustomer_LocationItem_Receptionist_N = true;
			gxTv_SdtSDTCustomer_LocationItem_Receptionist = null;
		}

		public bool gxTv_SdtSDTCustomer_LocationItem_Receptionist_IsNull()
		{
			return gxTv_SdtSDTCustomer_LocationItem_Receptionist == null;
		}
		public bool ShouldSerializegxTpr_Receptionist_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTCustomer_LocationItem_Receptionist != null && gxTv_SdtSDTCustomer_LocationItem_Receptionist.Count > 0;

		}



		[SoapElement(ElementName="Supplier_Agb" )]
		[XmlArray(ElementName="Supplier_Agb"  )]
		[XmlArrayItemAttribute(ElementName="Supplier_AgbItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTCustomer_LocationItem_Supplier_AgbItem> gxTpr_Supplier_agb
		{
			get {
				if ( gxTv_SdtSDTCustomer_LocationItem_Supplier_agb == null )
				{
					gxTv_SdtSDTCustomer_LocationItem_Supplier_agb = new GXBaseCollection<SdtSDTCustomer_LocationItem_Supplier_AgbItem>( context, "SDTCustomer.LocationItem.Supplier_AgbItem", "");
				}
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_agb;
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_agb_N = false;
				gxTv_SdtSDTCustomer_LocationItem_Supplier_agb = value;
				SetDirty("Supplier_agb");
			}
		}

		public void gxTv_SdtSDTCustomer_LocationItem_Supplier_agb_SetNull()
		{
			gxTv_SdtSDTCustomer_LocationItem_Supplier_agb_N = true;
			gxTv_SdtSDTCustomer_LocationItem_Supplier_agb = null;
		}

		public bool gxTv_SdtSDTCustomer_LocationItem_Supplier_agb_IsNull()
		{
			return gxTv_SdtSDTCustomer_LocationItem_Supplier_agb == null;
		}
		public bool ShouldSerializegxTpr_Supplier_agb_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTCustomer_LocationItem_Supplier_agb != null && gxTv_SdtSDTCustomer_LocationItem_Supplier_agb.Count > 0;

		}



		[SoapElement(ElementName="Supplier_Gen" )]
		[XmlArray(ElementName="Supplier_Gen"  )]
		[XmlArrayItemAttribute(ElementName="Supplier_GenItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTCustomer_LocationItem_Supplier_GenItem> gxTpr_Supplier_gen
		{
			get {
				if ( gxTv_SdtSDTCustomer_LocationItem_Supplier_gen == null )
				{
					gxTv_SdtSDTCustomer_LocationItem_Supplier_gen = new GXBaseCollection<SdtSDTCustomer_LocationItem_Supplier_GenItem>( context, "SDTCustomer.LocationItem.Supplier_GenItem", "");
				}
				return gxTv_SdtSDTCustomer_LocationItem_Supplier_gen;
			}
			set {
				gxTv_SdtSDTCustomer_LocationItem_Supplier_gen_N = false;
				gxTv_SdtSDTCustomer_LocationItem_Supplier_gen = value;
				SetDirty("Supplier_gen");
			}
		}

		public void gxTv_SdtSDTCustomer_LocationItem_Supplier_gen_SetNull()
		{
			gxTv_SdtSDTCustomer_LocationItem_Supplier_gen_N = true;
			gxTv_SdtSDTCustomer_LocationItem_Supplier_gen = null;
		}

		public bool gxTv_SdtSDTCustomer_LocationItem_Supplier_gen_IsNull()
		{
			return gxTv_SdtSDTCustomer_LocationItem_Supplier_gen == null;
		}
		public bool ShouldSerializegxTpr_Supplier_gen_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTCustomer_LocationItem_Supplier_gen != null && gxTv_SdtSDTCustomer_LocationItem_Supplier_gen.Count > 0;

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
			gxTv_SdtSDTCustomer_LocationItem_Customerlocationvisitingaddress = "";
			gxTv_SdtSDTCustomer_LocationItem_Customerlocationpostaladdress = "";
			gxTv_SdtSDTCustomer_LocationItem_Customerlocationemail = "";
			gxTv_SdtSDTCustomer_LocationItem_Customerlocationphone = "";

			gxTv_SdtSDTCustomer_LocationItem_Receptionist_N = true;


			gxTv_SdtSDTCustomer_LocationItem_Supplier_agb_N = true;


			gxTv_SdtSDTCustomer_LocationItem_Supplier_gen_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTCustomer_LocationItem_Customerlocationid;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Customerlocationvisitingaddress;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Customerlocationpostaladdress;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Customerlocationemail;
		 

		protected string gxTv_SdtSDTCustomer_LocationItem_Customerlocationphone;
		 
		protected bool gxTv_SdtSDTCustomer_LocationItem_Receptionist_N;
		protected GXBaseCollection<SdtSDTCustomer_LocationItem_ReceptionistItem> gxTv_SdtSDTCustomer_LocationItem_Receptionist = null; 

		protected bool gxTv_SdtSDTCustomer_LocationItem_Supplier_agb_N;
		protected GXBaseCollection<SdtSDTCustomer_LocationItem_Supplier_AgbItem> gxTv_SdtSDTCustomer_LocationItem_Supplier_agb = null; 

		protected bool gxTv_SdtSDTCustomer_LocationItem_Supplier_gen_N;
		protected GXBaseCollection<SdtSDTCustomer_LocationItem_Supplier_GenItem> gxTv_SdtSDTCustomer_LocationItem_Supplier_gen = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTCustomer.LocationItem", Namespace="Comforta2")]
	public class SdtSDTCustomer_LocationItem_RESTInterface : GxGenericCollectionItem<SdtSDTCustomer_LocationItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCustomer_LocationItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCustomer_LocationItem_RESTInterface( SdtSDTCustomer_LocationItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CustomerLocationId", Order=0)]
		public short gxTpr_Customerlocationid
		{
			get { 
				return sdt.gxTpr_Customerlocationid;

			}
			set { 
				sdt.gxTpr_Customerlocationid = value;
			}
		}

		[DataMember(Name="CustomerLocationVisitingAddress", Order=1)]
		public  string gxTpr_Customerlocationvisitingaddress
		{
			get { 
				return sdt.gxTpr_Customerlocationvisitingaddress;

			}
			set { 
				 sdt.gxTpr_Customerlocationvisitingaddress = value;
			}
		}

		[DataMember(Name="CustomerLocationPostalAddress", Order=2)]
		public  string gxTpr_Customerlocationpostaladdress
		{
			get { 
				return sdt.gxTpr_Customerlocationpostaladdress;

			}
			set { 
				 sdt.gxTpr_Customerlocationpostaladdress = value;
			}
		}

		[DataMember(Name="CustomerLocationEmail", Order=3)]
		public  string gxTpr_Customerlocationemail
		{
			get { 
				return sdt.gxTpr_Customerlocationemail;

			}
			set { 
				 sdt.gxTpr_Customerlocationemail = value;
			}
		}

		[DataMember(Name="CustomerLocationPhone", Order=4)]
		public  string gxTpr_Customerlocationphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Customerlocationphone);

			}
			set { 
				 sdt.gxTpr_Customerlocationphone = value;
			}
		}

		[DataMember(Name="Receptionist", Order=5, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTCustomer_LocationItem_ReceptionistItem_RESTInterface> gxTpr_Receptionist
		{
			get {
				if (sdt.ShouldSerializegxTpr_Receptionist_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTCustomer_LocationItem_ReceptionistItem_RESTInterface>(sdt.gxTpr_Receptionist);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Receptionist);
			}
		}

		[DataMember(Name="Supplier_Agb", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTCustomer_LocationItem_Supplier_AgbItem_RESTInterface> gxTpr_Supplier_agb
		{
			get {
				if (sdt.ShouldSerializegxTpr_Supplier_agb_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTCustomer_LocationItem_Supplier_AgbItem_RESTInterface>(sdt.gxTpr_Supplier_agb);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Supplier_agb);
			}
		}

		[DataMember(Name="Supplier_Gen", Order=7, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTCustomer_LocationItem_Supplier_GenItem_RESTInterface> gxTpr_Supplier_gen
		{
			get {
				if (sdt.ShouldSerializegxTpr_Supplier_gen_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTCustomer_LocationItem_Supplier_GenItem_RESTInterface>(sdt.gxTpr_Supplier_gen);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Supplier_gen);
			}
		}


		#endregion

		public SdtSDTCustomer_LocationItem sdt
		{
			get { 
				return (SdtSDTCustomer_LocationItem)Sdt;
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
				sdt = new SdtSDTCustomer_LocationItem() ;
			}
		}
	}
	#endregion
}