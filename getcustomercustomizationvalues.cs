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
   public class getcustomercustomizationvalues : GXProcedure
   {
      public getcustomercustomizationvalues( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getcustomercustomizationvalues( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out SdtCustomerCustomizationSDT aP0_CustomeCustomize )
      {
         this.AV9CustomeCustomize = new SdtCustomerCustomizationSDT(context) ;
         initialize();
         ExecuteImpl();
         aP0_CustomeCustomize=this.AV9CustomeCustomize;
      }

      public SdtCustomerCustomizationSDT executeUdp( )
      {
         execute(out aP0_CustomeCustomize);
         return AV9CustomeCustomize ;
      }

      public void executeSubmit( out SdtCustomerCustomizationSDT aP0_CustomeCustomize )
      {
         this.AV9CustomeCustomize = new SdtCustomerCustomizationSDT(context) ;
         SubmitImpl();
         aP0_CustomeCustomize=this.AV9CustomeCustomize;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXLvl1 = 0;
         AV11Udparg1 = new getloggedinusercustomerid(context).executeUdp( );
         /* Using cursor P003H2 */
         pr_default.execute(0, new Object[] {AV11Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1CustomerId = P003H2_A1CustomerId[0];
            A40000CustomerCustomizationFavicon_G = P003H2_A40000CustomerCustomizationFavicon_G[0];
            A40001CustomerCustomizationLogo_GXI = P003H2_A40001CustomerCustomizationLogo_GXI[0];
            A128CustomerCustomizationId = P003H2_A128CustomerCustomizationId[0];
            A131CustomerCustomizationBaseColor = P003H2_A131CustomerCustomizationBaseColor[0];
            A132CustomerCustomizationFontSize = P003H2_A132CustomerCustomizationFontSize[0];
            A130CustomerCustomizationFavicon = P003H2_A130CustomerCustomizationFavicon[0];
            A129CustomerCustomizationLogo = P003H2_A129CustomerCustomizationLogo[0];
            AV10GXLvl1 = 1;
            AV9CustomeCustomize.gxTpr_Customercustomizationid = A128CustomerCustomizationId;
            AV9CustomeCustomize.gxTpr_Customercustomizationbasecolor = A131CustomerCustomizationBaseColor;
            AV9CustomeCustomize.gxTpr_Customercustomizationfavicon = A130CustomerCustomizationFavicon;
            AV9CustomeCustomize.gxTpr_Customercustomizationfavicon_gxi = A40000CustomerCustomizationFavicon_G;
            AV9CustomeCustomize.gxTpr_Customercustomizationfontsize = A132CustomerCustomizationFontSize;
            AV9CustomeCustomize.gxTpr_Customercustomizationlogo = A129CustomerCustomizationLogo;
            AV9CustomeCustomize.gxTpr_Customercustomizationlogo_gxi = A40001CustomerCustomizationLogo_GXI;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV10GXLvl1 == 0 )
         {
            AV9CustomeCustomize.gxTpr_Customercustomizationbasecolor = "Teal";
            AV9CustomeCustomize.gxTpr_Customercustomizationfontsize = "Medium";
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
         AV9CustomeCustomize = new SdtCustomerCustomizationSDT(context);
         P003H2_A1CustomerId = new short[1] ;
         P003H2_A40000CustomerCustomizationFavicon_G = new string[] {""} ;
         P003H2_A40001CustomerCustomizationLogo_GXI = new string[] {""} ;
         P003H2_A128CustomerCustomizationId = new short[1] ;
         P003H2_A131CustomerCustomizationBaseColor = new string[] {""} ;
         P003H2_A132CustomerCustomizationFontSize = new string[] {""} ;
         P003H2_A130CustomerCustomizationFavicon = new string[] {""} ;
         P003H2_A129CustomerCustomizationLogo = new string[] {""} ;
         A40000CustomerCustomizationFavicon_G = "";
         A40001CustomerCustomizationLogo_GXI = "";
         A131CustomerCustomizationBaseColor = "";
         A132CustomerCustomizationFontSize = "";
         A130CustomerCustomizationFavicon = "";
         A129CustomerCustomizationLogo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getcustomercustomizationvalues__default(),
            new Object[][] {
                new Object[] {
               P003H2_A1CustomerId, P003H2_A40000CustomerCustomizationFavicon_G, P003H2_A40001CustomerCustomizationLogo_GXI, P003H2_A128CustomerCustomizationId, P003H2_A131CustomerCustomizationBaseColor, P003H2_A132CustomerCustomizationFontSize, P003H2_A130CustomerCustomizationFavicon, P003H2_A129CustomerCustomizationLogo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl1 ;
      private short AV11Udparg1 ;
      private short A1CustomerId ;
      private short A128CustomerCustomizationId ;
      private string A40000CustomerCustomizationFavicon_G ;
      private string A40001CustomerCustomizationLogo_GXI ;
      private string A131CustomerCustomizationBaseColor ;
      private string A132CustomerCustomizationFontSize ;
      private string A130CustomerCustomizationFavicon ;
      private string A129CustomerCustomizationLogo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtCustomerCustomizationSDT AV9CustomeCustomize ;
      private IDataStoreProvider pr_default ;
      private short[] P003H2_A1CustomerId ;
      private string[] P003H2_A40000CustomerCustomizationFavicon_G ;
      private string[] P003H2_A40001CustomerCustomizationLogo_GXI ;
      private short[] P003H2_A128CustomerCustomizationId ;
      private string[] P003H2_A131CustomerCustomizationBaseColor ;
      private string[] P003H2_A132CustomerCustomizationFontSize ;
      private string[] P003H2_A130CustomerCustomizationFavicon ;
      private string[] P003H2_A129CustomerCustomizationLogo ;
      private SdtCustomerCustomizationSDT aP0_CustomeCustomize ;
   }

   public class getcustomercustomizationvalues__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003H2;
          prmP003H2 = new Object[] {
          new ParDef("AV11Udparg1",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003H2", "SELECT CustomerId, CustomerCustomizationFavicon_G, CustomerCustomizationLogo_GXI, CustomerCustomizationId, CustomerCustomizationBaseColor, CustomerCustomizationFontSize, CustomerCustomizationFavicon, CustomerCustomizationLogo FROM CustomerCustomization WHERE CustomerId = :AV11Udparg1 ORDER BY CustomerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003H2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
       }
    }

 }

}
