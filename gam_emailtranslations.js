gx.evt.autoSkip=!1;gx.define("gam_emailtranslations",!1,function(){var n,t;this.ServerClass="gam_emailtranslations";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_emailtranslations.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV17Type=gx.fn.getControlValue("vTYPE");this.AV16Title=gx.fn.getControlValue("vTITLE");this.Gx_mode=gx.fn.getControlValue("vMODE");this.subGridtranslations_Recordcount=gx.fn.getIntegerValue("subGridtranslations_Recordcount",gx.thousandSeparator)};this.s112_client=function(){return this.executeClientEvent(function(){this.AV6Delete=gx.getMessage("GAM_Delete");gx.text.compare(this.Gx_mode,"DSP")==0||gx.text.compare(this.Gx_mode,"DLT")==0?(gx.fn.setCtrlProperty("vLANGUAGE","Enabled",!1),gx.fn.setCtrlProperty("vSUBJECT","Enabled",!1),gx.fn.setCtrlProperty("vBODY","Enabled",!1),gx.fn.setCtrlProperty("vDELETE","Visible",!1)):(gx.fn.setCtrlProperty("vSUBJECT","Enabled",!0),gx.fn.setCtrlProperty("vBODY","Enabled",!0))},arguments)};this.e153h2_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV15Subject="";this.AV5Body="";this.refreshOutputs([{av:"AV15Subject",fld:"vSUBJECT"},{av:"AV5Body",fld:"vBODY"}]);this.OnClientEventEnd()},arguments)};this.e113h2_client=function(){return this.executeServerEvent("'CANCEL'",!1,null,!1,!1)};this.e123h2_client=function(){return this.executeServerEvent("'CONFIRM'",!1,null,!1,!1)};this.e163h2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e173h2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,28,29,30,31,32,33,34,36,37,38,39,40,41,42,43,44,45];this.GXLastCtrlId=45;this.GridtranslationsContainer=new gx.grid.grid(this,2,"WbpLvl2",27,"Gridtranslations","Gridtranslations","GridtranslationsContainer",this.CmpContext,this.IsMasterPage,"gam_emailtranslations",[],!1,1,!1,!0,0,!1,!1,!1,"",100,"%",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!0,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridtranslationsContainer;t.addSingleLineEdit("Lngid",28,"vLNGID","","","LngID","char",115,"px",15,15,"start",null,[],"Lngid","LngID",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit("Language",29,"vLANGUAGE",gx.getMessage("GAM_Language"),"","Language","svchar",30,"%",40,40,"start",null,[],"Language","Language",!0,0,!1,!1,"Attribute",0,"column column-optional");t.addSingleLineEdit("Subject",30,"vSUBJECT",gx.getMessage("GAM_Subject"),"","Subject","char",80,"%",254,80,"start",null,[],"Subject","Subject",!0,0,!1,!1,"Attribute",0,"column column-optional");t.addSingleLineEdit("Body",31,"vBODY",gx.getMessage("GAM_Body"),"","Body","svchar",95,"%",2048,80,"start",null,[],"Body","Body",!0,100,!1,!1,"Attribute",0,"column column-optional");t.addSingleLineEdit("Delete",32,"vDELETE","","","Delete","char",0,"px",20,20,"start","e153h2_client",[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",0,"WWTextActionColumn");this.GridtranslationsContainer.emptyText=gx.getMessage("GAM_Noresultsfound");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"GAM_HEADERWWNOFILTERS",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"GAM_HEADERWWNOFILTERS_TABLEACTIONS",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"GAM_HEADERWWNOFILTERS_TITLE",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"GAM_HEADERWWNOFILTERS_ADDNEW",grid:0,evt:"e183h1_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSEARCH",fmt:0,gxz:"ZV14Search",gxold:"OV14Search",gxvar:"AV14Search",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14Search=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Search=n)},v2c:function(){gx.fn.setControlValue("vSEARCH",gx.O.AV14Search,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14Search=this.val())},val:function(){return gx.fn.getControlValue("vSEARCH")},nac:gx.falseFn};this.declareDomainHdlr(16,function(){});n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"SECTION1",grid:0};n[20]={id:20,fld:"GRIDTABLE",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"GROUPPROPERTIES",grid:0};n[24]={id:24,fld:"GROUPPROPERTIESTABLE1",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[28]={id:28,lvl:2,type:"char",len:15,dec:0,sign:!1,ro:0,isacc:0,grid:27,gxgrid:this.GridtranslationsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLNGID",fmt:0,gxz:"ZV13LngID",gxold:"OV13LngID",gxvar:"AV13LngID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV13LngID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13LngID=n)},v2c:function(n){gx.fn.setGridControlValue("vLNGID",n||gx.fn.currentGridRowImpl(27),gx.O.AV13LngID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13LngID=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLNGID",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:27,gxgrid:this.GridtranslationsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLANGUAGE",fmt:0,gxz:"ZV12Language",gxold:"OV12Language",gxvar:"AV12Language",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Language=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Language=n)},v2c:function(n){gx.fn.setGridControlValue("vLANGUAGE",n||gx.fn.currentGridRowImpl(27),gx.O.AV12Language,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Language=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLANGUAGE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:27,gxgrid:this.GridtranslationsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBJECT",fmt:0,gxz:"ZV15Subject",gxold:"OV15Subject",gxvar:"AV15Subject",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV15Subject=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15Subject=n)},v2c:function(n){gx.fn.setGridControlValue("vSUBJECT",n||gx.fn.currentGridRowImpl(27),gx.O.AV15Subject,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV15Subject=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSUBJECT",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"svchar",len:2048,dec:100,sign:!1,ro:0,isacc:0,grid:27,gxgrid:this.GridtranslationsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBODY",fmt:0,gxz:"ZV5Body",gxold:"OV5Body",gxvar:"AV5Body",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5Body=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5Body=n)},v2c:function(n){gx.fn.setGridControlValue("vBODY",n||gx.fn.currentGridRowImpl(27),gx.O.AV5Body,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5Body=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBODY",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:27,gxgrid:this.GridtranslationsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV6Delete",gxold:"OV6Delete",gxvar:"AV6Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV6Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27),gx.O.AV6Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn,evt:"e153h2_client"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"GAM_FOOTERPOPUP",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"GAM_FOOTERPOPUP_TABLEBUTTONS",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"GAM_FOOTERPOPUP_BTNCANCEL",grid:0,evt:"e113h2_client"};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"GAM_FOOTERPOPUP_BTNCONFIRM",grid:0,evt:"e123h2_client"};this.AV14Search="";this.ZV14Search="";this.OV14Search="";this.ZV13LngID="";this.OV13LngID="";this.ZV12Language="";this.OV12Language="";this.ZV15Subject="";this.OV15Subject="";this.ZV5Body="";this.OV5Body="";this.ZV6Delete="";this.OV6Delete="";this.AV14Search="";this.AV17Type="";this.AV16Title="";this.AV13LngID="";this.AV12Language="";this.AV15Subject="";this.AV5Body="";this.AV6Delete="";this.Gx_mode="";this.Events={e113h2_client:["'CANCEL'",!0],e123h2_client:["'CONFIRM'",!0],e163h2_client:["ENTER",!0],e173h2_client:["CANCEL",!0],e153h2_client:["'DELETEROW'",!1]};this.EvtParms.REFRESH=[[{av:"GRIDTRANSLATIONS_nFirstRecordOnPage"},{av:"GRIDTRANSLATIONS_nEOF"},{av:"AV15Subject",fld:"vSUBJECT"},{av:"AV5Body",fld:"vBODY"},{av:"AV17Type",fld:"vTYPE",hsh:!0},{av:"AV16Title",fld:"vTITLE",hsh:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[]];this.EvtParms["GRIDTRANSLATIONS.LOAD"]=[[{av:"AV17Type",fld:"vTYPE",hsh:!0},{av:"AV15Subject",fld:"vSUBJECT"},{av:"AV5Body",fld:"vBODY"},{av:"AV16Title",fld:"vTITLE",hsh:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[{av:"AV13LngID",fld:"vLNGID",hsh:!0},{av:"AV12Language",fld:"vLANGUAGE"},{av:"AV6Delete",fld:"vDELETE"},{av:"gx.fn.getCtrlProperty('vLANGUAGE','Enabled')",ctrl:"vLANGUAGE",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vSUBJECT','Enabled')",ctrl:"vSUBJECT",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vBODY','Enabled')",ctrl:"vBODY",prop:"Enabled"}]];this.EvtParms["'DELETEROW'"]=[[],[{av:"AV15Subject",fld:"vSUBJECT"},{av:"AV5Body",fld:"vBODY"}]];this.EvtParms["'CANCEL'"]=[[],[]];this.EvtParms["'CONFIRM'"]=[[{av:"AV15Subject",fld:"vSUBJECT",grid:27},{av:"GRIDTRANSLATIONS_nFirstRecordOnPage"},{av:"nRC_GXsfl_27",ctrl:"GRIDTRANSLATIONS",grid:27,prop:"GridRC",grid:27},{av:"AV5Body",fld:"vBODY",grid:27},{av:"AV17Type",fld:"vTYPE",hsh:!0},{av:"AV13LngID",fld:"vLNGID",grid:27,hsh:!0},{av:"AV16Title",fld:"vTITLE",hsh:!0}],[{ctrl:"WCMESSAGES"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV17Type","vTYPE",0,"char",20,0);this.setVCMap("AV16Title","vTITLE",0,"svchar",40,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV17Type","vTYPE",0,"char",20,0);this.setVCMap("AV16Title","vTITLE",0,"svchar",40,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV17Type","vTYPE",0,"char",20,0);this.setVCMap("AV16Title","vTITLE",0,"svchar",40,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);t.addRefreshingVar({rfrVar:"AV17Type"});t.addRefreshingVar({rfrVar:"AV15Subject",rfrProp:"Value",gxAttId:"Subject"});t.addRefreshingVar({rfrVar:"AV5Body",rfrProp:"Value",gxAttId:"Body"});t.addRefreshingVar({rfrVar:"AV16Title"});t.addRefreshingVar({rfrVar:"Gx_mode"});t.addRefreshingParm({rfrVar:"AV17Type"});t.addRefreshingParm({rfrVar:"AV15Subject",rfrProp:"Value",gxAttId:"Subject"});t.addRefreshingParm({rfrVar:"AV5Body",rfrProp:"Value",gxAttId:"Body"});t.addRefreshingParm({rfrVar:"AV16Title"});t.addRefreshingParm({rfrVar:"Gx_mode"});this.Initialize();this.setComponent({id:"WCMESSAGES",GXClass:null,Prefix:"W0035",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_emailtranslations)})