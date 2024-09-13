using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class generateqrcodeimage : GXProcedure
   {
      public generateqrcodeimage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generateqrcodeimage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_email ,
                           out string aP1_linkURL )
      {
         this.AV19email = aP0_email;
         this.AV8linkURL = "" ;
         initialize();
         ExecuteImpl();
         aP1_linkURL=this.AV8linkURL;
      }

      public string executeUdp( string aP0_email )
      {
         execute(aP0_email, out aP1_linkURL);
         return AV8linkURL ;
      }

      public void executeSubmit( string aP0_email ,
                                 out string aP1_linkURL )
      {
         this.AV19email = aP0_email;
         this.AV8linkURL = "" ;
         SubmitImpl();
         aP1_linkURL=this.AV8linkURL;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11key = context.GetMessage( "76a2173be6393254e72ffa4d6df1030a3d2f94a3bb6d4a6e69a2cda0e056cb13", "");
         AV12nonce = context.GetMessage( "10dd993308d37a15b55f64a0e763f353", "");
         AV13EncryptedEmail = Encrypt64( AV19email, AV11key);
         AV14EncryptedPassword = Encrypt64( context.GetMessage( "user123", ""), AV11key);
         AV16EncryptedContent = "{\"user\": \"" + AV13EncryptedEmail + context.GetMessage( "\", \"code\": \"", "") + AV14EncryptedPassword + "\"}";
         AV15FinalEncryption = AV17SymmetricBlockCipher.doaeadencrypt("AES", "AEAD_EAX", AV11key, 128, AV12nonce, AV16EncryptedContent);
         AV8linkURL = AV18GenerateQRCode.generateandsaveqrcode(AV15FinalEncryption, "Resources/Qrcode.png");
         AV10QRCodeImage = AV8linkURL;
         AV20Qrcodeimage_GXI = GXDbFile.PathToUrl( AV8linkURL, context);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8linkURL = "";
         AV11key = "";
         AV12nonce = "";
         AV13EncryptedEmail = "";
         AV14EncryptedPassword = "";
         AV16EncryptedContent = "";
         AV15FinalEncryption = "";
         AV17SymmetricBlockCipher = new GeneXus.Programs.genexuscryptography.SdtSymmetricBlockCipher(context);
         AV18GenerateQRCode = new SdtQRCodeLibrary(context);
         AV10QRCodeImage = "";
         AV20Qrcodeimage_GXI = "";
         /* GeneXus formulas. */
      }

      private string AV16EncryptedContent ;
      private string AV15FinalEncryption ;
      private string AV19email ;
      private string AV8linkURL ;
      private string AV11key ;
      private string AV12nonce ;
      private string AV13EncryptedEmail ;
      private string AV14EncryptedPassword ;
      private string AV20Qrcodeimage_GXI ;
      private string AV10QRCodeImage ;
      private GeneXus.Programs.genexuscryptography.SdtSymmetricBlockCipher AV17SymmetricBlockCipher ;
      private SdtQRCodeLibrary AV18GenerateQRCode ;
      private string aP1_linkURL ;
   }

}
