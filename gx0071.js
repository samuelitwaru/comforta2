gx.evt.autoSkip=!1;gx.define("gx0071",!1,function(){var n,t;this.ServerClass="gx0071";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0071.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV10pResidentId=gx.fn.getIntegerValue("vPRESIDENTID",gx.thousandSeparator);this.AV11pResidentINCompanyId=gx.fn.getIntegerValue("vPRESIDENTINCOMPANYID",gx.thousandSeparator)};this.e15061_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle"));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]);this.OnClientEventEnd()},arguments)};this.e11061_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("RESIDENTINCOMPANYIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("RESIDENTINCOMPANYIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCRESIDENTINCOMPANYID","Visible",!0)):(gx.fn.setCtrlProperty("RESIDENTINCOMPANYIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCRESIDENTINCOMPANYID","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYIDFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCRESIDENTINCOMPANYID','Visible')",ctrl:"vCRESIDENTINCOMPANYID",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e12061_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCRESIDENTINCOMPANYKVKNUMBER","Visible",!0)):(gx.fn.setCtrlProperty("RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCRESIDENTINCOMPANYKVKNUMBER","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCRESIDENTINCOMPANYKVKNUMBER','Visible')",ctrl:"vCRESIDENTINCOMPANYKVKNUMBER",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e13061_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("RESIDENTINCOMPANYNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("RESIDENTINCOMPANYNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCRESIDENTINCOMPANYNAME","Visible",!0)):(gx.fn.setCtrlProperty("RESIDENTINCOMPANYNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCRESIDENTINCOMPANYNAME","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYNAMEFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYNAMEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCRESIDENTINCOMPANYNAME','Visible')",ctrl:"vCRESIDENTINCOMPANYNAME",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e14061_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("RESIDENTINCOMPANYPHONEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("RESIDENTINCOMPANYPHONEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCRESIDENTINCOMPANYPHONE","Visible",!0)):(gx.fn.setCtrlProperty("RESIDENTINCOMPANYPHONEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCRESIDENTINCOMPANYPHONE","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYPHONEFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYPHONEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCRESIDENTINCOMPANYPHONE','Visible')",ctrl:"vCRESIDENTINCOMPANYPHONE",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e18062_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e19061_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,55,56,57,58,59,60,61,62,63];this.GXLastCtrlId=63;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",54,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0071",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",55,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(50,56,"RESIDENTINCOMPANYID",gx.getMessage("INCompany Id"),"","ResidentINCompanyId","int",0,"px",4,4,"end",null,[],50,"ResidentINCompanyId",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(51,57,"RESIDENTINCOMPANYKVKNUMBER",gx.getMessage("Kvk Number"),"","ResidentINCompanyKvkNumber","svchar",0,"px",8,8,"start",null,[],51,"ResidentINCompanyKvkNumber",!0,0,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(52,58,"RESIDENTINCOMPANYNAME",gx.getMessage("INCompany Name"),"","ResidentINCompanyName","svchar",0,"px",40,40,"start",null,[],52,"ResidentINCompanyName",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(54,59,"RESIDENTINCOMPANYPHONE",gx.getMessage("INCompany Phone"),"","ResidentINCompanyPhone","char",0,"px",20,20,"start",null,[],54,"ResidentINCompanyPhone",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(31,60,"RESIDENTID",gx.getMessage("Resident Id"),"","ResidentId","int",0,"px",4,4,"end",null,[],31,"ResidentId",!1,0,!1,!1,"Attribute",0,"");this.Grid1Container.emptyText=gx.getMessage("");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"RESIDENTINCOMPANYIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLRESIDENTINCOMPANYIDFILTER",format:1,grid:0,evt:"e11061_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCRESIDENTINCOMPANYID",fmt:0,gxz:"ZV6cResidentINCompanyId",gxold:"OV6cResidentINCompanyId",gxvar:"AV6cResidentINCompanyId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cResidentINCompanyId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cResidentINCompanyId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCRESIDENTINCOMPANYID",gx.O.AV6cResidentINCompanyId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cResidentINCompanyId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCRESIDENTINCOMPANYID",gx.thousandSeparator)},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLRESIDENTINCOMPANYKVKNUMBERFILTER",format:1,grid:0,evt:"e12061_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCRESIDENTINCOMPANYKVKNUMBER",fmt:0,gxz:"ZV7cResidentINCompanyKvkNumber",gxold:"OV7cResidentINCompanyKvkNumber",gxvar:"AV7cResidentINCompanyKvkNumber",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cResidentINCompanyKvkNumber=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cResidentINCompanyKvkNumber=n)},v2c:function(){gx.fn.setControlValue("vCRESIDENTINCOMPANYKVKNUMBER",gx.O.AV7cResidentINCompanyKvkNumber,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cResidentINCompanyKvkNumber=this.val())},val:function(){return gx.fn.getControlValue("vCRESIDENTINCOMPANYKVKNUMBER")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"RESIDENTINCOMPANYNAMEFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLRESIDENTINCOMPANYNAMEFILTER",format:1,grid:0,evt:"e13061_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCRESIDENTINCOMPANYNAME",fmt:0,gxz:"ZV8cResidentINCompanyName",gxold:"OV8cResidentINCompanyName",gxvar:"AV8cResidentINCompanyName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cResidentINCompanyName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8cResidentINCompanyName=n)},v2c:function(){gx.fn.setControlValue("vCRESIDENTINCOMPANYNAME",gx.O.AV8cResidentINCompanyName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cResidentINCompanyName=this.val())},val:function(){return gx.fn.getControlValue("vCRESIDENTINCOMPANYNAME")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"RESIDENTINCOMPANYPHONEFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLRESIDENTINCOMPANYPHONEFILTER",format:1,grid:0,evt:"e14061_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCRESIDENTINCOMPANYPHONE",fmt:0,gxz:"ZV9cResidentINCompanyPhone",gxold:"OV9cResidentINCompanyPhone",gxvar:"AV9cResidentINCompanyPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cResidentINCompanyPhone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9cResidentINCompanyPhone=n)},v2c:function(){gx.fn.setControlValue("vCRESIDENTINCOMPANYPHONE",gx.O.AV9cResidentINCompanyPhone,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cResidentINCompanyPhone=this.val())},val:function(){return gx.fn.getControlValue("vCRESIDENTINCOMPANYPHONE")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"GRIDTABLE",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNTOGGLE",grid:0,evt:"e15061_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[55]={id:55,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54),gx.O.AV5LinkSelection,gx.O.AV13Linkselection_GXI)},c2v:function(n){gx.O.AV13Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(54))},gxvar_GXI:"AV13Linkselection_GXI",nac:gx.falseFn};n[56]={id:56,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTINCOMPANYID",fmt:0,gxz:"Z50ResidentINCompanyId",gxold:"O50ResidentINCompanyId",gxvar:"A50ResidentINCompanyId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A50ResidentINCompanyId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z50ResidentINCompanyId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("RESIDENTINCOMPANYID",n||gx.fn.currentGridRowImpl(54),gx.O.A50ResidentINCompanyId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A50ResidentINCompanyId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("RESIDENTINCOMPANYID",n||gx.fn.currentGridRowImpl(54),gx.thousandSeparator)},nac:gx.falseFn};n[57]={id:57,lvl:2,type:"svchar",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTINCOMPANYKVKNUMBER",fmt:0,gxz:"Z51ResidentINCompanyKvkNumber",gxold:"O51ResidentINCompanyKvkNumber",gxvar:"A51ResidentINCompanyKvkNumber",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A51ResidentINCompanyKvkNumber=n)},v2z:function(n){n!==undefined&&(gx.O.Z51ResidentINCompanyKvkNumber=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTINCOMPANYKVKNUMBER",n||gx.fn.currentGridRowImpl(54),gx.O.A51ResidentINCompanyKvkNumber,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A51ResidentINCompanyKvkNumber=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTINCOMPANYKVKNUMBER",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[58]={id:58,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTINCOMPANYNAME",fmt:0,gxz:"Z52ResidentINCompanyName",gxold:"O52ResidentINCompanyName",gxvar:"A52ResidentINCompanyName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A52ResidentINCompanyName=n)},v2z:function(n){n!==undefined&&(gx.O.Z52ResidentINCompanyName=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTINCOMPANYNAME",n||gx.fn.currentGridRowImpl(54),gx.O.A52ResidentINCompanyName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A52ResidentINCompanyName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTINCOMPANYNAME",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[59]={id:59,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTINCOMPANYPHONE",fmt:0,gxz:"Z54ResidentINCompanyPhone",gxold:"O54ResidentINCompanyPhone",gxvar:"A54ResidentINCompanyPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"tel",v2v:function(n){n!==undefined&&(gx.O.A54ResidentINCompanyPhone=n)},v2z:function(n){n!==undefined&&(gx.O.Z54ResidentINCompanyPhone=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTINCOMPANYPHONE",n||gx.fn.currentGridRowImpl(54),gx.O.A54ResidentINCompanyPhone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A54ResidentINCompanyPhone=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTINCOMPANYPHONE",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[60]={id:60,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTID",fmt:0,gxz:"Z31ResidentId",gxold:"O31ResidentId",gxvar:"A31ResidentId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A31ResidentId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z31ResidentId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("RESIDENTID",n||gx.fn.currentGridRowImpl(54),gx.O.A31ResidentId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A31ResidentId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("RESIDENTID",n||gx.fn.currentGridRowImpl(54),gx.thousandSeparator)},nac:gx.falseFn};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"BTN_CANCEL",grid:0,evt:"e19061_client"};this.AV6cResidentINCompanyId=0;this.ZV6cResidentINCompanyId=0;this.OV6cResidentINCompanyId=0;this.AV7cResidentINCompanyKvkNumber="";this.ZV7cResidentINCompanyKvkNumber="";this.OV7cResidentINCompanyKvkNumber="";this.AV8cResidentINCompanyName="";this.ZV8cResidentINCompanyName="";this.OV8cResidentINCompanyName="";this.AV9cResidentINCompanyPhone="";this.ZV9cResidentINCompanyPhone="";this.OV9cResidentINCompanyPhone="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z50ResidentINCompanyId=0;this.O50ResidentINCompanyId=0;this.Z51ResidentINCompanyKvkNumber="";this.O51ResidentINCompanyKvkNumber="";this.Z52ResidentINCompanyName="";this.O52ResidentINCompanyName="";this.Z54ResidentINCompanyPhone="";this.O54ResidentINCompanyPhone="";this.Z31ResidentId=0;this.O31ResidentId=0;this.AV6cResidentINCompanyId=0;this.AV7cResidentINCompanyKvkNumber="";this.AV8cResidentINCompanyName="";this.AV9cResidentINCompanyPhone="";this.AV10pResidentId=0;this.AV11pResidentINCompanyId=0;this.AV5LinkSelection="";this.A50ResidentINCompanyId=0;this.A51ResidentINCompanyKvkNumber="";this.A52ResidentINCompanyName="";this.A54ResidentINCompanyPhone="";this.A31ResidentId=0;this.Events={e18062_client:["ENTER",!0],e19061_client:["CANCEL",!0],e15061_client:["'TOGGLE'",!1],e11061_client:["LBLRESIDENTINCOMPANYIDFILTER.CLICK",!1],e12061_client:["LBLRESIDENTINCOMPANYKVKNUMBERFILTER.CLICK",!1],e13061_client:["LBLRESIDENTINCOMPANYNAMEFILTER.CLICK",!1],e14061_client:["LBLRESIDENTINCOMPANYPHONEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cResidentINCompanyId",fld:"vCRESIDENTINCOMPANYID",pic:"ZZZ9"},{av:"AV7cResidentINCompanyKvkNumber",fld:"vCRESIDENTINCOMPANYKVKNUMBER"},{av:"AV8cResidentINCompanyName",fld:"vCRESIDENTINCOMPANYNAME"},{av:"AV9cResidentINCompanyPhone",fld:"vCRESIDENTINCOMPANYPHONE"},{av:"AV10pResidentId",fld:"vPRESIDENTID",pic:"ZZZ9"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLRESIDENTINCOMPANYIDFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYIDFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYIDFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYIDFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCRESIDENTINCOMPANYID','Visible')",ctrl:"vCRESIDENTINCOMPANYID",prop:"Visible"}]];this.EvtParms["LBLRESIDENTINCOMPANYKVKNUMBERFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYKVKNUMBERFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCRESIDENTINCOMPANYKVKNUMBER','Visible')",ctrl:"vCRESIDENTINCOMPANYKVKNUMBER",prop:"Visible"}]];this.EvtParms["LBLRESIDENTINCOMPANYNAMEFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYNAMEFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYNAMEFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYNAMEFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYNAMEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCRESIDENTINCOMPANYNAME','Visible')",ctrl:"vCRESIDENTINCOMPANYNAME",prop:"Visible"}]];this.EvtParms["LBLRESIDENTINCOMPANYPHONEFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYPHONEFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYPHONEFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('RESIDENTINCOMPANYPHONEFILTERCONTAINER','Class')",ctrl:"RESIDENTINCOMPANYPHONEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCRESIDENTINCOMPANYPHONE','Visible')",ctrl:"vCRESIDENTINCOMPANYPHONE",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A50ResidentINCompanyId",fld:"RESIDENTINCOMPANYID",pic:"ZZZ9",hsh:!0}],[{av:"AV11pResidentINCompanyId",fld:"vPRESIDENTINCOMPANYID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cResidentINCompanyId",fld:"vCRESIDENTINCOMPANYID",pic:"ZZZ9"},{av:"AV7cResidentINCompanyKvkNumber",fld:"vCRESIDENTINCOMPANYKVKNUMBER"},{av:"AV8cResidentINCompanyName",fld:"vCRESIDENTINCOMPANYNAME"},{av:"AV9cResidentINCompanyPhone",fld:"vCRESIDENTINCOMPANYPHONE"},{av:"AV10pResidentId",fld:"vPRESIDENTID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cResidentINCompanyId",fld:"vCRESIDENTINCOMPANYID",pic:"ZZZ9"},{av:"AV7cResidentINCompanyKvkNumber",fld:"vCRESIDENTINCOMPANYKVKNUMBER"},{av:"AV8cResidentINCompanyName",fld:"vCRESIDENTINCOMPANYNAME"},{av:"AV9cResidentINCompanyPhone",fld:"vCRESIDENTINCOMPANYPHONE"},{av:"AV10pResidentId",fld:"vPRESIDENTID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cResidentINCompanyId",fld:"vCRESIDENTINCOMPANYID",pic:"ZZZ9"},{av:"AV7cResidentINCompanyKvkNumber",fld:"vCRESIDENTINCOMPANYKVKNUMBER"},{av:"AV8cResidentINCompanyName",fld:"vCRESIDENTINCOMPANYNAME"},{av:"AV9cResidentINCompanyPhone",fld:"vCRESIDENTINCOMPANYPHONE"},{av:"AV10pResidentId",fld:"vPRESIDENTID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cResidentINCompanyId",fld:"vCRESIDENTINCOMPANYID",pic:"ZZZ9"},{av:"AV7cResidentINCompanyKvkNumber",fld:"vCRESIDENTINCOMPANYKVKNUMBER"},{av:"AV8cResidentINCompanyName",fld:"vCRESIDENTINCOMPANYNAME"},{av:"AV9cResidentINCompanyPhone",fld:"vCRESIDENTINCOMPANYPHONE"},{av:"AV10pResidentId",fld:"vPRESIDENTID",pic:"ZZZ9"}],[]];this.setVCMap("AV10pResidentId","vPRESIDENTID",0,"int",4,0);this.setVCMap("AV11pResidentINCompanyId","vPRESIDENTINCOMPANYID",0,"int",4,0);this.setVCMap("AV10pResidentId","vPRESIDENTID",0,"int",4,0);this.setVCMap("AV10pResidentId","vPRESIDENTID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar({rfrVar:"AV10pResidentId"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm({rfrVar:"AV10pResidentId"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0071)})