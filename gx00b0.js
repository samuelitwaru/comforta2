gx.evt.autoSkip=!1;gx.define("gx00b0",!1,function(){var n,t;this.ServerClass="gx00b0";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00b0.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV10pProductServiceId=gx.fn.getIntegerValue("vPPRODUCTSERVICEID",gx.thousandSeparator)};this.e15091_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle"));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]);this.OnClientEventEnd()},arguments)};this.e11091_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("PRODUCTSERVICEIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PRODUCTSERVICEIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPRODUCTSERVICEID","Visible",!0)):(gx.fn.setCtrlProperty("PRODUCTSERVICEIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPRODUCTSERVICEID","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('PRODUCTSERVICEIDFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICEIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCPRODUCTSERVICEID','Visible')",ctrl:"vCPRODUCTSERVICEID",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e12091_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("PRODUCTSERVICENAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PRODUCTSERVICENAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPRODUCTSERVICENAME","Visible",!0)):(gx.fn.setCtrlProperty("PRODUCTSERVICENAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPRODUCTSERVICENAME","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('PRODUCTSERVICENAMEFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICENAMEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCPRODUCTSERVICENAME','Visible')",ctrl:"vCPRODUCTSERVICENAME",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e13091_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("PRODUCTSERVICEQUANTITYFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PRODUCTSERVICEQUANTITYFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPRODUCTSERVICEQUANTITY","Visible",!0)):(gx.fn.setCtrlProperty("PRODUCTSERVICEQUANTITYFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPRODUCTSERVICEQUANTITY","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('PRODUCTSERVICEQUANTITYFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICEQUANTITYFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCPRODUCTSERVICEQUANTITY','Visible')",ctrl:"vCPRODUCTSERVICEQUANTITY",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e14091_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("PRODUCTSERVICETYPEIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PRODUCTSERVICETYPEIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPRODUCTSERVICETYPEID","Visible",!0)):(gx.fn.setCtrlProperty("PRODUCTSERVICETYPEIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPRODUCTSERVICETYPEID","Visible",!1));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('PRODUCTSERVICETYPEIDFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICETYPEIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCPRODUCTSERVICETYPEID','Visible')",ctrl:"vCPRODUCTSERVICETYPEID",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e18092_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e19091_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,55,56,57,58,59,60,61,62];this.GXLastCtrlId=62;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",54,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00b0",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",55,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(73,56,"PRODUCTSERVICEID",gx.getMessage("Service Id"),"","ProductServiceId","int",0,"px",4,4,"end",null,[],73,"ProductServiceId",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(74,57,"PRODUCTSERVICENAME",gx.getMessage("Service Name"),"","ProductServiceName","svchar",0,"px",40,40,"start",null,[],74,"ProductServiceName",!0,0,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(76,58,"PRODUCTSERVICEQUANTITY",gx.getMessage("Service Quantity"),"","ProductServiceQuantity","int",0,"px",4,4,"end",null,[],76,"ProductServiceQuantity",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addBitmap(77,"PRODUCTSERVICEPICTURE",59,0,"px",17,"px",null,"",gx.getMessage("Service Picture"),"ImageAttribute","WWColumn OptionalColumn");this.Grid1Container.emptyText=gx.getMessage("");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"PRODUCTSERVICEIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLPRODUCTSERVICEIDFILTER",format:1,grid:0,evt:"e11091_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTSERVICEID",fmt:0,gxz:"ZV6cProductServiceId",gxold:"OV6cProductServiceId",gxvar:"AV6cProductServiceId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cProductServiceId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cProductServiceId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPRODUCTSERVICEID",gx.O.AV6cProductServiceId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cProductServiceId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPRODUCTSERVICEID",gx.thousandSeparator)},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"PRODUCTSERVICENAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLPRODUCTSERVICENAMEFILTER",format:1,grid:0,evt:"e12091_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTSERVICENAME",fmt:0,gxz:"ZV7cProductServiceName",gxold:"OV7cProductServiceName",gxvar:"AV7cProductServiceName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cProductServiceName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cProductServiceName=n)},v2c:function(){gx.fn.setControlValue("vCPRODUCTSERVICENAME",gx.O.AV7cProductServiceName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cProductServiceName=this.val())},val:function(){return gx.fn.getControlValue("vCPRODUCTSERVICENAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"PRODUCTSERVICEQUANTITYFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLPRODUCTSERVICEQUANTITYFILTER",format:1,grid:0,evt:"e13091_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTSERVICEQUANTITY",fmt:0,gxz:"ZV8cProductServiceQuantity",gxold:"OV8cProductServiceQuantity",gxvar:"AV8cProductServiceQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cProductServiceQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cProductServiceQuantity=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPRODUCTSERVICEQUANTITY",gx.O.AV8cProductServiceQuantity,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cProductServiceQuantity=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPRODUCTSERVICEQUANTITY",gx.thousandSeparator)},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"PRODUCTSERVICETYPEIDFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLPRODUCTSERVICETYPEIDFILTER",format:1,grid:0,evt:"e14091_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTSERVICETYPEID",fmt:0,gxz:"ZV9cProductServiceTypeId",gxold:"OV9cProductServiceTypeId",gxvar:"AV9cProductServiceTypeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cProductServiceTypeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9cProductServiceTypeId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPRODUCTSERVICETYPEID",gx.O.AV9cProductServiceTypeId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cProductServiceTypeId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPRODUCTSERVICETYPEID",gx.thousandSeparator)},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"GRIDTABLE",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNTOGGLE",grid:0,evt:"e15091_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[55]={id:55,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54),gx.O.AV5LinkSelection,gx.O.AV12Linkselection_GXI)},c2v:function(n){gx.O.AV12Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(54))},gxvar_GXI:"AV12Linkselection_GXI",nac:gx.falseFn};n[56]={id:56,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICEID",fmt:0,gxz:"Z73ProductServiceId",gxold:"O73ProductServiceId",gxvar:"A73ProductServiceId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A73ProductServiceId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z73ProductServiceId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICEID",n||gx.fn.currentGridRowImpl(54),gx.O.A73ProductServiceId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A73ProductServiceId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTSERVICEID",n||gx.fn.currentGridRowImpl(54),gx.thousandSeparator)},nac:gx.falseFn};n[57]={id:57,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICENAME",fmt:0,gxz:"Z74ProductServiceName",gxold:"O74ProductServiceName",gxvar:"A74ProductServiceName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A74ProductServiceName=n)},v2z:function(n){n!==undefined&&(gx.O.Z74ProductServiceName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICENAME",n||gx.fn.currentGridRowImpl(54),gx.O.A74ProductServiceName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A74ProductServiceName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTSERVICENAME",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[58]={id:58,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICEQUANTITY",fmt:0,gxz:"Z76ProductServiceQuantity",gxold:"O76ProductServiceQuantity",gxvar:"A76ProductServiceQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A76ProductServiceQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z76ProductServiceQuantity=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICEQUANTITY",n||gx.fn.currentGridRowImpl(54),gx.O.A76ProductServiceQuantity,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A76ProductServiceQuantity=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTSERVICEQUANTITY",n||gx.fn.currentGridRowImpl(54),gx.thousandSeparator)},nac:gx.falseFn};n[59]={id:59,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICEPICTURE",fmt:0,gxz:"Z77ProductServicePicture",gxold:"O77ProductServicePicture",gxvar:"A77ProductServicePicture",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A77ProductServicePicture=n)},v2z:function(n){n!==undefined&&(gx.O.Z77ProductServicePicture=n)},v2c:function(n){gx.fn.setGridMultimediaValue("PRODUCTSERVICEPICTURE",n||gx.fn.currentGridRowImpl(54),gx.O.A77ProductServicePicture,gx.O.A40000ProductServicePicture_GXI)},c2v:function(n){gx.O.A40000ProductServicePicture_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A77ProductServicePicture=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTSERVICEPICTURE",n||gx.fn.currentGridRowImpl(54))},val_GXI:function(n){return gx.fn.getGridControlValue("PRODUCTSERVICEPICTURE_GXI",n||gx.fn.currentGridRowImpl(54))},gxvar_GXI:"A40000ProductServicePicture_GXI",nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"BTN_CANCEL",grid:0,evt:"e19091_client"};this.AV6cProductServiceId=0;this.ZV6cProductServiceId=0;this.OV6cProductServiceId=0;this.AV7cProductServiceName="";this.ZV7cProductServiceName="";this.OV7cProductServiceName="";this.AV8cProductServiceQuantity=0;this.ZV8cProductServiceQuantity=0;this.OV8cProductServiceQuantity=0;this.AV9cProductServiceTypeId=0;this.ZV9cProductServiceTypeId=0;this.OV9cProductServiceTypeId=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z73ProductServiceId=0;this.O73ProductServiceId=0;this.Z74ProductServiceName="";this.O74ProductServiceName="";this.Z76ProductServiceQuantity=0;this.O76ProductServiceQuantity=0;this.Z77ProductServicePicture="";this.O77ProductServicePicture="";this.AV6cProductServiceId=0;this.AV7cProductServiceName="";this.AV8cProductServiceQuantity=0;this.AV9cProductServiceTypeId=0;this.A40000ProductServicePicture_GXI="";this.AV10pProductServiceId=0;this.A71ProductServiceTypeId=0;this.AV5LinkSelection="";this.A73ProductServiceId=0;this.A74ProductServiceName="";this.A76ProductServiceQuantity=0;this.A77ProductServicePicture="";this.Events={e18092_client:["ENTER",!0],e19091_client:["CANCEL",!0],e15091_client:["'TOGGLE'",!1],e11091_client:["LBLPRODUCTSERVICEIDFILTER.CLICK",!1],e12091_client:["LBLPRODUCTSERVICENAMEFILTER.CLICK",!1],e13091_client:["LBLPRODUCTSERVICEQUANTITYFILTER.CLICK",!1],e14091_client:["LBLPRODUCTSERVICETYPEIDFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductServiceId",fld:"vCPRODUCTSERVICEID",pic:"ZZZ9"},{av:"AV7cProductServiceName",fld:"vCPRODUCTSERVICENAME"},{av:"AV8cProductServiceQuantity",fld:"vCPRODUCTSERVICEQUANTITY",pic:"ZZZ9"},{av:"AV9cProductServiceTypeId",fld:"vCPRODUCTSERVICETYPEID",pic:"ZZZ9"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('ADVANCEDCONTAINER','Class')",ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLPRODUCTSERVICEIDFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('PRODUCTSERVICEIDFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICEIDFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('PRODUCTSERVICEIDFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICEIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCPRODUCTSERVICEID','Visible')",ctrl:"vCPRODUCTSERVICEID",prop:"Visible"}]];this.EvtParms["LBLPRODUCTSERVICENAMEFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('PRODUCTSERVICENAMEFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICENAMEFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('PRODUCTSERVICENAMEFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICENAMEFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCPRODUCTSERVICENAME','Visible')",ctrl:"vCPRODUCTSERVICENAME",prop:"Visible"}]];this.EvtParms["LBLPRODUCTSERVICEQUANTITYFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('PRODUCTSERVICEQUANTITYFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICEQUANTITYFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('PRODUCTSERVICEQUANTITYFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICEQUANTITYFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCPRODUCTSERVICEQUANTITY','Visible')",ctrl:"vCPRODUCTSERVICEQUANTITY",prop:"Visible"}]];this.EvtParms["LBLPRODUCTSERVICETYPEIDFILTER.CLICK"]=[[{av:"gx.fn.getCtrlProperty('PRODUCTSERVICETYPEIDFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICETYPEIDFILTERCONTAINER",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('PRODUCTSERVICETYPEIDFILTERCONTAINER','Class')",ctrl:"PRODUCTSERVICETYPEIDFILTERCONTAINER",prop:"Class"},{av:"gx.fn.getCtrlProperty('vCPRODUCTSERVICETYPEID','Visible')",ctrl:"vCPRODUCTSERVICETYPEID",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A73ProductServiceId",fld:"PRODUCTSERVICEID",pic:"ZZZ9",hsh:!0}],[{av:"AV10pProductServiceId",fld:"vPPRODUCTSERVICEID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductServiceId",fld:"vCPRODUCTSERVICEID",pic:"ZZZ9"},{av:"AV7cProductServiceName",fld:"vCPRODUCTSERVICENAME"},{av:"AV8cProductServiceQuantity",fld:"vCPRODUCTSERVICEQUANTITY",pic:"ZZZ9"},{av:"AV9cProductServiceTypeId",fld:"vCPRODUCTSERVICETYPEID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductServiceId",fld:"vCPRODUCTSERVICEID",pic:"ZZZ9"},{av:"AV7cProductServiceName",fld:"vCPRODUCTSERVICENAME"},{av:"AV8cProductServiceQuantity",fld:"vCPRODUCTSERVICEQUANTITY",pic:"ZZZ9"},{av:"AV9cProductServiceTypeId",fld:"vCPRODUCTSERVICETYPEID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductServiceId",fld:"vCPRODUCTSERVICEID",pic:"ZZZ9"},{av:"AV7cProductServiceName",fld:"vCPRODUCTSERVICENAME"},{av:"AV8cProductServiceQuantity",fld:"vCPRODUCTSERVICEQUANTITY",pic:"ZZZ9"},{av:"AV9cProductServiceTypeId",fld:"vCPRODUCTSERVICETYPEID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"",ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductServiceId",fld:"vCPRODUCTSERVICEID",pic:"ZZZ9"},{av:"AV7cProductServiceName",fld:"vCPRODUCTSERVICENAME"},{av:"AV8cProductServiceQuantity",fld:"vCPRODUCTSERVICEQUANTITY",pic:"ZZZ9"},{av:"AV9cProductServiceTypeId",fld:"vCPRODUCTSERVICETYPEID",pic:"ZZZ9"}],[]];this.setVCMap("AV10pProductServiceId","vPPRODUCTSERVICEID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00b0)})