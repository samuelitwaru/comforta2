gx.evt.autoSkip=!1;gx.define("customertype",!1,function(){this.ServerClass="customertype";this.PackageName="GeneXus.Programs";this.ServerFullClass="customertype.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7CustomerTypeId=gx.fn.getIntegerValue("vCUSTOMERTYPEID",gx.thousandSeparator);this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Customertypeid=function(){return this.validCliEvt("Valid_Customertypeid",0,function(){try{var n=gx.util.balloon.getNew("CUSTOMERTYPEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Customertypename=function(){return this.validCliEvt("Valid_Customertypename",0,function(){try{var n=gx.util.balloon.getNew("CUSTOMERTYPENAME");if(this.AnyError=0,gx.text.compare("",this.A79CustomerTypeName)==0)try{n.setError(gx.text.format(gx.getMessage("WWP_RequiredAttribute"),gx.getMessage("Customer Type Name"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12072_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e130712_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140712_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39];this.GXLastCtrlId=39;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"UNNAMEDGROUP1",grid:0};n[16]={id:16,fld:"TABLEATTRIBUTES",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TABLEFORM",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Customertypename,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERTYPENAME",fmt:0,gxz:"Z79CustomerTypeName",gxold:"O79CustomerTypeName",gxvar:"A79CustomerTypeName",ucs:[],op:[24],ip:[24],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A79CustomerTypeName=n)},v2z:function(n){n!==undefined&&(gx.O.Z79CustomerTypeName=n)},v2c:function(){gx.fn.setControlValue("CUSTOMERTYPENAME",gx.O.A79CustomerTypeName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A79CustomerTypeName=this.val())},val:function(){return gx.fn.getControlValue("CUSTOMERTYPENAME")},nac:gx.falseFn};this.declareDomainHdlr(24,function(){});n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"ACTIONSTABLE",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"BTNTRN_ENTER",grid:0,evt:"e130712_client",std:"ENTER"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"BTNTRN_CANCEL",grid:0,evt:"e140712_client"};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"BTNTRN_DELETE",grid:0,evt:"e150712_client",std:"DELETE"};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Customertypeid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERTYPEID",fmt:0,gxz:"Z78CustomerTypeId",gxold:"O78CustomerTypeId",gxvar:"A78CustomerTypeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A78CustomerTypeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z78CustomerTypeId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUSTOMERTYPEID",gx.O.A78CustomerTypeId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A78CustomerTypeId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUSTOMERTYPEID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});this.A79CustomerTypeName="";this.Z79CustomerTypeName="";this.O79CustomerTypeName="";this.A78CustomerTypeId=0;this.Z78CustomerTypeId=0;this.O78CustomerTypeId=0;this.AV8WWPContext={UserId:0,UserName:""};this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7CustomerTypeId=0;this.AV12WebSession={};this.A78CustomerTypeId=0;this.A79CustomerTypeName="";this.Gx_mode="";this.Events={e12072_client:["AFTER TRN",!0],e130712_client:["ENTER",!0],e140712_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7CustomerTypeId",fld:"vCUSTOMERTYPEID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",hsh:!0},{av:"AV7CustomerTypeId",fld:"vCUSTOMERTYPEID",pic:"ZZZ9",hsh:!0},{av:"A78CustomerTypeId",fld:"CUSTOMERTYPEID",pic:"ZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",hsh:!0}],[]];this.EvtParms.VALID_CUSTOMERTYPENAME=[[{av:"A79CustomerTypeName",fld:"CUSTOMERTYPENAME"}],[{av:"A79CustomerTypeName",fld:"CUSTOMERTYPENAME"}]];this.EvtParms.VALID_CUSTOMERTYPEID=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7CustomerTypeId","vCUSTOMERTYPEID",0,"int",4,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.customertype)})