gx.evt.autoSkip=!1;gx.define("gamexampleupdateregisteruser",!1,function(){this.ServerClass="gamexampleupdateregisteruser";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamexampleupdateregisteruser.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV13IDP_State=gx.fn.getControlValue("vIDP_STATE")};this.Validv_Gender=function(){return this.validCliEvt("Validv_Gender",0,function(){try{var n=gx.util.balloon.getNew("vGENDER");if(this.AnyError=0,!(gx.text.compare(this.AV12Gender,"N")==0||gx.text.compare(this.AV12Gender,"F")==0||gx.text.compare(this.AV12Gender,"M")==0))try{n.setError("Field Gender is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e120p2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e130p2_client=function(){return this.executeServerEvent("'RETURNTOLOGIN'",!1,null,!1,!1)};this.e150p2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,80,81,82,83,84,85,86];this.GXLastCtrlId=86;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TBTITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV16Name",gxold:"OV16Name",gxvar:"AV16Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV16Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV16Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(11,function(){});n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEMAIL",fmt:0,gxz:"ZV6EMail",gxold:"OV6EMail",gxvar:"AV6EMail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6EMail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6EMail=n)},v2c:function(){gx.fn.setControlValue("vEMAIL",gx.O.AV6EMail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV6EMail=this.val())},val:function(){return gx.fn.getControlValue("vEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(16,function(){});n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"CELL_FIRSTNAME",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFIRSTNAME",fmt:0,gxz:"ZV7FirstName",gxold:"OV7FirstName",gxvar:"AV7FirstName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7FirstName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7FirstName=n)},v2c:function(){gx.fn.setControlValue("vFIRSTNAME",gx.O.AV7FirstName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV7FirstName=this.val())},val:function(){return gx.fn.getControlValue("vFIRSTNAME")},nac:gx.falseFn};this.declareDomainHdlr(21,function(){});n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"CELL_LASTNAME",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLASTNAME",fmt:0,gxz:"ZV15LastName",gxold:"OV15LastName",gxvar:"AV15LastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15LastName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15LastName=n)},v2c:function(){gx.fn.setControlValue("vLASTNAME",gx.O.AV15LastName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV15LastName=this.val())},val:function(){return gx.fn.getControlValue("vLASTNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"CELL_PHONE",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPHONE",fmt:0,gxz:"ZV38Phone",gxold:"OV38Phone",gxvar:"AV38Phone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV38Phone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV38Phone=n)},v2c:function(){gx.fn.setControlValue("vPHONE",gx.O.AV38Phone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV38Phone=this.val())},val:function(){return gx.fn.getControlValue("vPHONE")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"CELL_BIRTHDAY",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBIRTHDAY",fmt:0,gxz:"ZV5Birthday",gxold:"OV5Birthday",gxvar:"AV5Birthday",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5Birthday=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5Birthday=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vBIRTHDAY",gx.O.AV5Birthday,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV5Birthday=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vBIRTHDAY")},nac:gx.falseFn};this.declareDomainHdlr(36,function(){});n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"CELL_GENDER",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Gender,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGENDER",fmt:0,gxz:"ZV12Gender",gxold:"OV12Gender",gxvar:"AV12Gender",ucs:[],op:[41],ip:[41],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV12Gender=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Gender=n)},v2c:function(){gx.fn.setComboBoxValue("vGENDER",gx.O.AV12Gender);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12Gender=this.val())},val:function(){return gx.fn.getControlValue("vGENDER")},nac:gx.falseFn};this.declareDomainHdlr(41,function(){});n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"CELL_ADDRESS",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vADDRESS",fmt:0,gxz:"ZV28Address",gxold:"OV28Address",gxvar:"AV28Address",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV28Address=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28Address=n)},v2c:function(){gx.fn.setControlValue("vADDRESS",gx.O.AV28Address,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV28Address=this.val())},val:function(){return gx.fn.getControlValue("vADDRESS")},nac:gx.falseFn};this.declareDomainHdlr(46,function(){});n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"CELL_CITY",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCITY",fmt:0,gxz:"ZV29City",gxold:"OV29City",gxvar:"AV29City",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV29City=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29City=n)},v2c:function(){gx.fn.setControlValue("vCITY",gx.O.AV29City,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV29City=this.val())},val:function(){return gx.fn.getControlValue("vCITY")},nac:gx.falseFn};this.declareDomainHdlr(51,function(){});n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"CELL_STATE",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSTATE",fmt:0,gxz:"ZV40State",gxold:"OV40State",gxvar:"AV40State",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV40State=n)},v2z:function(n){n!==undefined&&(gx.O.ZV40State=n)},v2c:function(){gx.fn.setControlValue("vSTATE",gx.O.AV40State,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV40State=this.val())},val:function(){return gx.fn.getControlValue("vSTATE")},nac:gx.falseFn};this.declareDomainHdlr(56,function(){});n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"CELL_POSTCODE",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPOSTCODE",fmt:0,gxz:"ZV39PostCode",gxold:"OV39PostCode",gxvar:"AV39PostCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV39PostCode=n)},v2z:function(n){n!==undefined&&(gx.O.ZV39PostCode=n)},v2c:function(){gx.fn.setControlValue("vPOSTCODE",gx.O.AV39PostCode,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV39PostCode=this.val())},val:function(){return gx.fn.getControlValue("vPOSTCODE")},nac:gx.falseFn};this.declareDomainHdlr(61,function(){});n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"CELL_LANGUAGE",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"svchar",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLANGUAGE",fmt:0,gxz:"ZV37Language",gxold:"OV37Language",gxvar:"AV37Language",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV37Language=n)},v2z:function(n){n!==undefined&&(gx.O.ZV37Language=n)},v2c:function(){gx.fn.setComboBoxValue("vLANGUAGE",gx.O.AV37Language);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV37Language=this.val())},val:function(){return gx.fn.getControlValue("vLANGUAGE")},nac:gx.falseFn};this.declareDomainHdlr(66,function(){});n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"CELL_TIMEZONE",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIMEZONE",fmt:0,gxz:"ZV41Timezone",gxold:"OV41Timezone",gxvar:"AV41Timezone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV41Timezone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV41Timezone=n)},v2c:function(){gx.fn.setControlValue("vTIMEZONE",gx.O.AV41Timezone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV41Timezone=this.val())},val:function(){return gx.fn.getControlValue("vTIMEZONE")},nac:gx.falseFn};this.declareDomainHdlr(71,function(){});n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"CELL_PHOTO",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"svchar",len:2048,dec:250,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vURLIMAGE",fmt:0,gxz:"ZV42URLImage",gxold:"OV42URLImage",gxvar:"AV42URLImage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV42URLImage=n)},v2z:function(n){n!==undefined&&(gx.O.ZV42URLImage=n)},v2c:function(){gx.fn.setControlValue("vURLIMAGE",gx.O.AV42URLImage,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV42URLImage=this.val())},val:function(){return gx.fn.getControlValue("vURLIMAGE")},nac:gx.falseFn};this.declareDomainHdlr(76,function(){});n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"BUTTONLOGIN",grid:0,evt:"e130p2_client"};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"BUTTON2",grid:0,evt:"e120p2_client",std:"ENTER"};this.AV16Name="";this.ZV16Name="";this.OV16Name="";this.AV6EMail="";this.ZV6EMail="";this.OV6EMail="";this.AV7FirstName="";this.ZV7FirstName="";this.OV7FirstName="";this.AV15LastName="";this.ZV15LastName="";this.OV15LastName="";this.AV38Phone="";this.ZV38Phone="";this.OV38Phone="";this.AV5Birthday=gx.date.nullDate();this.ZV5Birthday=gx.date.nullDate();this.OV5Birthday=gx.date.nullDate();this.AV12Gender="";this.ZV12Gender="";this.OV12Gender="";this.AV28Address="";this.ZV28Address="";this.OV28Address="";this.AV29City="";this.ZV29City="";this.OV29City="";this.AV40State="";this.ZV40State="";this.OV40State="";this.AV39PostCode="";this.ZV39PostCode="";this.OV39PostCode="";this.AV37Language="";this.ZV37Language="";this.OV37Language="";this.AV41Timezone="";this.ZV41Timezone="";this.OV41Timezone="";this.AV42URLImage="";this.ZV42URLImage="";this.OV42URLImage="";this.AV16Name="";this.AV6EMail="";this.AV7FirstName="";this.AV15LastName="";this.AV38Phone="";this.AV5Birthday=gx.date.nullDate();this.AV12Gender="";this.AV28Address="";this.AV29City="";this.AV40State="";this.AV39PostCode="";this.AV37Language="";this.AV41Timezone="";this.AV42URLImage="";this.AV13IDP_State="";this.Events={e120p2_client:["ENTER",!0],e130p2_client:["'RETURNTOLOGIN'",!0],e150p2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV13IDP_State",fld:"vIDP_STATE",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV16Name",fld:"vNAME"},{av:"AV6EMail",fld:"vEMAIL"},{av:"AV7FirstName",fld:"vFIRSTNAME"},{av:"AV15LastName",fld:"vLASTNAME"},{av:"AV38Phone",fld:"vPHONE"},{av:"AV5Birthday",fld:"vBIRTHDAY"},{ctrl:"vGENDER"},{av:"AV12Gender",fld:"vGENDER"},{av:"AV28Address",fld:"vADDRESS"},{av:"AV29City",fld:"vCITY"},{av:"AV40State",fld:"vSTATE"},{av:"AV39PostCode",fld:"vPOSTCODE"},{ctrl:"vLANGUAGE"},{av:"AV37Language",fld:"vLANGUAGE"},{av:"AV41Timezone",fld:"vTIMEZONE"},{av:"AV42URLImage",fld:"vURLIMAGE"},{av:"AV13IDP_State",fld:"vIDP_STATE",hsh:!0}],[]];this.EvtParms["'RETURNTOLOGIN'"]=[[],[]];this.EvtParms.VALIDV_GENDER=[[],[]];this.EnterCtrl=["BUTTON2"];this.setVCMap("AV13IDP_State","vIDP_STATE",0,"char",60,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamexampleupdateregisteruser)})