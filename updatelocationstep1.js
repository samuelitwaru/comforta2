gx.evt.autoSkip=!1;gx.define("updatelocationstep1",!0,function(n){this.ServerClass="updatelocationstep1";this.PackageName="GeneXus.Programs";this.ServerFullClass="updatelocationstep1.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7GoingBack=gx.fn.getControlValue("vGOINGBACK");this.AV19CheckRequiredFieldsResult=gx.fn.getControlValue("vCHECKREQUIREDFIELDSRESULT");this.AV10HasValidationErrors=gx.fn.getControlValue("vHASVALIDATIONERRORS");this.AV20LocationId=gx.fn.getIntegerValue("vLOCATIONID",",");this.AV6WebSessionKey=gx.fn.getControlValue("vWEBSESSIONKEY");this.AV8PreviousStep=gx.fn.getControlValue("vPREVIOUSSTEP")};this.Validv_Customerlocationemail=function(){return this.validCliEvt("Validv_Customerlocationemail",0,function(){try{var n=gx.util.balloon.getNew("vCUSTOMERLOCATIONEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.AV15CustomerLocationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError("Field Customer Location Email does not match the specified pattern");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s122_client=function(){return this.executeClientEvent(function(){!this.AV7GoingBack||gx.fn.setCtrlProperty("BTNWIZARDFIRSTPREVIOUS","Visible",!1)},arguments)};this.e133u2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e143u2_client=function(){return this.executeServerEvent("'WIZARDPREVIOUS'",!1,null,!1,!1)};this.e163u2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55];this.GXLastCtrlId=55;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLECONTENT",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"TABLEATTRIBUTES",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONNAME",fmt:0,gxz:"ZV12CustomerLocationName",gxold:"OV12CustomerLocationName",gxvar:"AV12CustomerLocationName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12CustomerLocationName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12CustomerLocationName=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONNAME",gx.O.AV12CustomerLocationName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12CustomerLocationName=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONNAME")},nac:gx.falseFn};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Customerlocationemail,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONEMAIL",fmt:0,gxz:"ZV15CustomerLocationEmail",gxold:"OV15CustomerLocationEmail",gxvar:"AV15CustomerLocationEmail",ucs:[],op:[],ip:[24],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15CustomerLocationEmail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15CustomerLocationEmail=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONEMAIL",gx.O.AV15CustomerLocationEmail,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15CustomerLocationEmail=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONEMAIL")},nac:gx.falseFn,hasRVFmt:!0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONPHONE",fmt:0,gxz:"ZV16CustomerLocationPhone",gxold:"OV16CustomerLocationPhone",gxvar:"AV16CustomerLocationPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16CustomerLocationPhone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16CustomerLocationPhone=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONPHONE",gx.O.AV16CustomerLocationPhone,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16CustomerLocationPhone=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONPHONE")},nac:gx.falseFn};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONPOSTALADDRESS",fmt:0,gxz:"ZV17CustomerLocationPostalAddress",gxold:"OV17CustomerLocationPostalAddress",gxvar:"AV17CustomerLocationPostalAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17CustomerLocationPostalAddress=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17CustomerLocationPostalAddress=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONPOSTALADDRESS",gx.O.AV17CustomerLocationPostalAddress,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17CustomerLocationPostalAddress=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONPOSTALADDRESS")},nac:gx.falseFn};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"svchar",len:1024,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONVISITINGADDRESS",fmt:0,gxz:"ZV18CustomerLocationVisitingAddress",gxold:"OV18CustomerLocationVisitingAddress",gxvar:"AV18CustomerLocationVisitingAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18CustomerLocationVisitingAddress=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18CustomerLocationVisitingAddress=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONVISITINGADDRESS",gx.O.AV18CustomerLocationVisitingAddress,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV18CustomerLocationVisitingAddress=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONVISITINGADDRESS")},nac:gx.falseFn};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONDESCRIPTION",fmt:0,gxz:"ZV13CustomerLocationDescription",gxold:"OV13CustomerLocationDescription",gxvar:"AV13CustomerLocationDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13CustomerLocationDescription=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13CustomerLocationDescription=n)},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONDESCRIPTION",gx.O.AV13CustomerLocationDescription,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13CustomerLocationDescription=this.val())},val:function(){return gx.fn.getControlValue("vCUSTOMERLOCATIONDESCRIPTION")},nac:gx.falseFn};t[43]={id:43,fld:"",grid:0};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"TABLEACTIONS",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"",grid:0};t[49]={id:49,fld:"BTNWIZARDFIRSTPREVIOUS",grid:0,evt:"e143u2_client"};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"BTNWIZARDNEXT",grid:0,evt:"e133u2_client",std:"ENTER"};t[52]={id:52,fld:"",grid:0};t[53]={id:53,fld:"",grid:0};t[54]={id:54,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[55]={id:55,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUSTOMERLOCATIONID",fmt:0,gxz:"ZV14CustomerLocationId",gxold:"OV14CustomerLocationId",gxvar:"AV14CustomerLocationId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14CustomerLocationId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14CustomerLocationId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCUSTOMERLOCATIONID",gx.O.AV14CustomerLocationId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14CustomerLocationId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCUSTOMERLOCATIONID",",")},nac:gx.falseFn};this.AV12CustomerLocationName="";this.ZV12CustomerLocationName="";this.OV12CustomerLocationName="";this.AV15CustomerLocationEmail="";this.ZV15CustomerLocationEmail="";this.OV15CustomerLocationEmail="";this.AV16CustomerLocationPhone="";this.ZV16CustomerLocationPhone="";this.OV16CustomerLocationPhone="";this.AV17CustomerLocationPostalAddress="";this.ZV17CustomerLocationPostalAddress="";this.OV17CustomerLocationPostalAddress="";this.AV18CustomerLocationVisitingAddress="";this.ZV18CustomerLocationVisitingAddress="";this.OV18CustomerLocationVisitingAddress="";this.AV13CustomerLocationDescription="";this.ZV13CustomerLocationDescription="";this.OV13CustomerLocationDescription="";this.AV14CustomerLocationId=0;this.ZV14CustomerLocationId=0;this.OV14CustomerLocationId=0;this.AV12CustomerLocationName="";this.AV15CustomerLocationEmail="";this.AV16CustomerLocationPhone="";this.AV17CustomerLocationPostalAddress="";this.AV18CustomerLocationVisitingAddress="";this.AV13CustomerLocationDescription="";this.AV14CustomerLocationId=0;this.AV6WebSessionKey="";this.AV8PreviousStep="";this.AV7GoingBack=!1;this.AV20LocationId=0;this.AV19CheckRequiredFieldsResult=!1;this.AV10HasValidationErrors=!1;this.Events={e133u2_client:["ENTER",!0],e143u2_client:["'WIZARDPREVIOUS'",!0],e163u2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV7GoingBack",fld:"vGOINGBACK"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0}],[{ctrl:"BTNWIZARDFIRSTPREVIOUS",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"AV19CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"AV20LocationId",fld:"vLOCATIONID",pic:"ZZZ9"},{av:"AV12CustomerLocationName",fld:"vCUSTOMERLOCATIONNAME"},{av:"AV18CustomerLocationVisitingAddress",fld:"vCUSTOMERLOCATIONVISITINGADDRESS"},{av:"AV13CustomerLocationDescription",fld:"vCUSTOMERLOCATIONDESCRIPTION"},{av:"AV6WebSessionKey",fld:"vWEBSESSIONKEY"},{av:"AV14CustomerLocationId",fld:"vCUSTOMERLOCATIONID",pic:"ZZZ9"},{av:"AV15CustomerLocationEmail",fld:"vCUSTOMERLOCATIONEMAIL"},{av:"AV16CustomerLocationPhone",fld:"vCUSTOMERLOCATIONPHONE"},{av:"AV17CustomerLocationPostalAddress",fld:"vCUSTOMERLOCATIONPOSTALADDRESS"}],[{av:"AV20LocationId",fld:"vLOCATIONID",pic:"ZZZ9"},{av:"AV19CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"}]];this.EvtParms["'WIZARDPREVIOUS'"]=[[{av:"AV20LocationId",fld:"vLOCATIONID",pic:"ZZZ9"}],[]];this.EvtParms.VALIDV_CUSTOMERLOCATIONEMAIL=[[],[]];this.EnterCtrl=["BTNWIZARDNEXT"];this.setVCMap("AV7GoingBack","vGOINGBACK",0,"boolean",4,0);this.setVCMap("AV19CheckRequiredFieldsResult","vCHECKREQUIREDFIELDSRESULT",0,"boolean",4,0);this.setVCMap("AV10HasValidationErrors","vHASVALIDATIONERRORS",0,"boolean",4,0);this.setVCMap("AV20LocationId","vLOCATIONID",0,"int",4,0);this.setVCMap("AV6WebSessionKey","vWEBSESSIONKEY",0,"svchar",40,0);this.setVCMap("AV8PreviousStep","vPREVIOUSSTEP",0,"svchar",40,0);this.Initialize()})