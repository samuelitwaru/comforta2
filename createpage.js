gx.evt.autoSkip=!1;gx.define("createpage",!0,function(n){this.ServerClass="createpage";this.PackageName="GeneXus.Programs";this.ServerFullClass="createpage.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV9BCPage=gx.fn.getControlValue("vBCPAGE");this.AV8PageHtmlContent=gx.fn.getControlValue("vPAGEHTMLCONTENT");this.AV12PageCssContent=gx.fn.getControlValue("vPAGECSSCONTENT")};this.e123h2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e143h1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24];this.GXLastCtrlId=24;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLECONTENT",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPAGENAME",fmt:0,gxz:"ZV7PageName",gxold:"OV7PageName",gxvar:"AV7PageName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7PageName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7PageName=n)},v2c:function(){gx.fn.setControlValue("vPAGENAME",gx.O.AV7PageName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7PageName=this.val())},val:function(){return gx.fn.getControlValue("vPAGENAME")},nac:gx.falseFn};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"BTNENTER",grid:0,evt:"e123h2_client",std:"ENTER"};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"BTNCANCEL",grid:0,evt:"e143h1_client"};this.AV7PageName="";this.ZV7PageName="";this.OV7PageName="";this.AV7PageName="";this.AV8PageHtmlContent="";this.AV12PageCssContent="";this.AV9BCPage={PageId:0,PageName:"",PageHtmlContent:"",PageCssContent:"",PageJsonContent:"",CustomerId:0,CustomerName:"",CustomerEmail:"",Mode:"",Initialized:0,PageId_Z:0,PageName_Z:"",PageHtmlContent_Z:"",PageCssContent_Z:"",PageJsonContent_Z:"",CustomerId_Z:0,CustomerName_Z:"",CustomerEmail_Z:""};this.Events={e123h2_client:["ENTER",!0],e143h1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.ENTER=[[{av:"AV7PageName",fld:"vPAGENAME"},{av:"AV9BCPage",fld:"vBCPAGE"},{av:"AV8PageHtmlContent",fld:"vPAGEHTMLCONTENT"},{av:"AV12PageCssContent",fld:"vPAGECSSCONTENT"}],[{av:"AV9BCPage",fld:"vBCPAGE"}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV9BCPage","vBCPAGE",0,"Page",0,0);this.setVCMap("AV8PageHtmlContent","vPAGEHTMLCONTENT",0,"vchar",5242880,0);this.setVCMap("AV12PageCssContent","vPAGECSSCONTENT",0,"vchar",2097152,0);this.Initialize()})