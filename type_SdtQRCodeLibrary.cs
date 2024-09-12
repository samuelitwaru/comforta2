using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtQRCodeLibrary : GxUserType, IGxExternalObject
   {
      public SdtQRCodeLibrary( )
      {
         /* Constructor for serialization */
      }

      public SdtQRCodeLibrary( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public string generateandsaveqrcode( string gxTp_url ,
                                           string gxTp_outputPath )
      {
         string returngenerateandsaveqrcode;
         if ( QRCodeLibrary_externalReference == null )
         {
            QRCodeLibrary_externalReference = new QRGeneratorLibrary.QRCodeLibrary();
         }
         returngenerateandsaveqrcode = "";
         returngenerateandsaveqrcode = (string)(QRCodeLibrary_externalReference.GenerateAndSaveQRCode(gxTp_url, gxTp_outputPath));
         return returngenerateandsaveqrcode ;
      }

      public Object ExternalInstance
      {
         get {
            if ( QRCodeLibrary_externalReference == null )
            {
               QRCodeLibrary_externalReference = new QRGeneratorLibrary.QRCodeLibrary();
            }
            return QRCodeLibrary_externalReference ;
         }

         set {
            QRCodeLibrary_externalReference = (QRGeneratorLibrary.QRCodeLibrary)(value);
         }

      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected QRGeneratorLibrary.QRCodeLibrary QRCodeLibrary_externalReference=null ;
   }

}
