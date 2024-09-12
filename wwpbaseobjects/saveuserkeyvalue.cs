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
namespace GeneXus.Programs.wwpbaseobjects {
   public class saveuserkeyvalue : GXProcedure
   {
      public saveuserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public saveuserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           string aP1_UserCustomizationsValue )
      {
         this.AV9UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV10UserCustomizationsValue = aP1_UserCustomizationsValue;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 string aP1_UserCustomizationsValue )
      {
         this.AV9UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV10UserCustomizationsValue = aP1_UserCustomizationsValue;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10UserCustomizationsValue)) )
         {
            AV8Session.Remove(AV9UserCustomizationsKey);
         }
         else
         {
            AV8Session.Set(AV9UserCustomizationsKey, AV10UserCustomizationsValue);
         }
         AV11UserCustomizations.Load(new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid(), AV9UserCustomizationsKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10UserCustomizationsValue)) )
         {
            if ( AV11UserCustomizations.Success() )
            {
               AV11UserCustomizations.Delete();
               context.CommitDataStores("wwpbaseobjects.saveuserkeyvalue",pr_default);
            }
         }
         else
         {
            if ( ! AV11UserCustomizations.Success() )
            {
               AV11UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
               AV11UserCustomizations.gxTpr_Usercustomizationsid = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
               AV11UserCustomizations.gxTpr_Usercustomizationskey = AV9UserCustomizationsKey;
            }
            AV11UserCustomizations.gxTpr_Usercustomizationsvalue = AV10UserCustomizationsValue;
            AV11UserCustomizations.Save();
            context.CommitDataStores("wwpbaseobjects.saveuserkeyvalue",pr_default);
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
         AV8Session = context.GetSession();
         AV11UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV10UserCustomizationsValue ;
      private string AV9UserCustomizationsKey ;
      private IGxSession AV8Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations AV11UserCustomizations ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class saveuserkeyvalue__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class saveuserkeyvalue__default : DataStoreHelperBase, IDataStoreHelper
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
