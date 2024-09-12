using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class createuseraccount : GXProcedure
   {
      public createuseraccount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public createuseraccount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Email ,
                           string aP1_GivenName ,
                           string aP2_LastName ,
                           string aP3_RoleName ,
                           out string aP4_GAMUserGUID )
      {
         this.AV9Email = aP0_Email;
         this.AV13GivenName = aP1_GivenName;
         this.AV14LastName = aP2_LastName;
         this.AV16RoleName = aP3_RoleName;
         this.AV12GAMUserGUID = "" ;
         initialize();
         ExecuteImpl();
         aP4_GAMUserGUID=this.AV12GAMUserGUID;
      }

      public string executeUdp( string aP0_Email ,
                                string aP1_GivenName ,
                                string aP2_LastName ,
                                string aP3_RoleName )
      {
         execute(aP0_Email, aP1_GivenName, aP2_LastName, aP3_RoleName, out aP4_GAMUserGUID);
         return AV12GAMUserGUID ;
      }

      public void executeSubmit( string aP0_Email ,
                                 string aP1_GivenName ,
                                 string aP2_LastName ,
                                 string aP3_RoleName ,
                                 out string aP4_GAMUserGUID )
      {
         this.AV9Email = aP0_Email;
         this.AV13GivenName = aP1_GivenName;
         this.AV14LastName = aP2_LastName;
         this.AV16RoleName = aP3_RoleName;
         this.AV12GAMUserGUID = "" ;
         SubmitImpl();
         aP4_GAMUserGUID=this.AV12GAMUserGUID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV11GAMUser.gxTpr_Name = AV9Email;
         AV11GAMUser.gxTpr_Firstname = AV13GivenName;
         AV11GAMUser.gxTpr_Lastname = AV14LastName;
         AV11GAMUser.gxTpr_Email = AV9Email;
         AV11GAMUser.gxTpr_Mustchangepassword = false;
         AV17Password = "user123";
         AV11GAMUser.gxTpr_Password = AV17Password;
         AV11GAMUser.gxTpr_Authenticationtypename = "local";
         AV11GAMUser.gxTpr_Namespace = "Comforta";
         AV11GAMUser.save();
         if ( AV11GAMUser.success() )
         {
            AV12GAMUserGUID = AV11GAMUser.gxTpr_Guid;
            AV15Role = AV10GAMRole.getbyname(AV16RoleName, out  AV8GAMErrorCollection);
            if ( AV11GAMUser.addrole(AV15Role, out  AV8GAMErrorCollection) )
            {
               context.CommitDataStores("createuseraccount",pr_default);
            }
            context.CommitDataStores("createuseraccount",pr_default);
         }
         else
         {
            AV8GAMErrorCollection = AV11GAMUser.geterrors();
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
         AV12GAMUserGUID = "";
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV17Password = "";
         AV15Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV8GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.createuseraccount__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createuseraccount__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV17Password ;
      private string AV9Email ;
      private string AV13GivenName ;
      private string AV14LastName ;
      private string AV16RoleName ;
      private string AV12GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV15Role ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV10GAMRole ;
      private IDataStoreProvider pr_default ;
      private string aP4_GAMUserGUID ;
      private IDataStoreProvider pr_gam ;
   }

   public class createuseraccount__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class createuseraccount__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
