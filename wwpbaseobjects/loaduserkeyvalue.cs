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
namespace GeneXus.Programs.wwpbaseobjects {
   public class loaduserkeyvalue : GXProcedure
   {
      public loaduserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loaduserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           out string aP1_UserCustomizationsValue )
      {
         this.AV9UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV10UserCustomizationsValue = "" ;
         initialize();
         ExecuteImpl();
         aP1_UserCustomizationsValue=this.AV10UserCustomizationsValue;
      }

      public string executeUdp( string aP0_UserCustomizationsKey )
      {
         execute(aP0_UserCustomizationsKey, out aP1_UserCustomizationsValue);
         return AV10UserCustomizationsValue ;
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 out string aP1_UserCustomizationsValue )
      {
         this.AV9UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV10UserCustomizationsValue = "" ;
         SubmitImpl();
         aP1_UserCustomizationsValue=this.AV10UserCustomizationsValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10UserCustomizationsValue = AV8Session.Get(AV9UserCustomizationsKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10UserCustomizationsValue)) )
         {
            AV12UserCustomizations.Load(new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid(), AV9UserCustomizationsKey);
            if ( AV12UserCustomizations.Success() )
            {
               AV10UserCustomizationsValue = AV12UserCustomizations.gxTpr_Usercustomizationsvalue;
            }
            else
            {
               AV10UserCustomizationsValue = "";
            }
         }
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
         AV10UserCustomizationsValue = "";
         AV8Session = context.GetSession();
         AV12UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         /* GeneXus formulas. */
      }

      private string AV10UserCustomizationsValue ;
      private string AV9UserCustomizationsKey ;
      private IGxSession AV8Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations AV12UserCustomizations ;
      private string aP1_UserCustomizationsValue ;
   }

}
