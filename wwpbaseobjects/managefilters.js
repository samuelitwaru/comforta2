gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.managefilters",!1,function(){var n,r,i,t;this.ServerClass="wwpbaseobjects.managefilters";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.managefilters.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV14UserKey=gx.fn.getControlValue("vUSERKEY");this.AV6GridStateCollection=gx.fn.getControlValue("vGRIDSTATECOLLECTION")};this.e111a2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e151a2_client=function(){return this.executeServerEvent("VMOVEUP.CLICK",!0,arguments[0],!1,!1)};this.e161a2_client=function(){return this.executeServerEvent("VMOVEDOWN.CLICK",!0,arguments[0],!1,!1)};this.e171a2_client=function(){return this.executeServerEvent("VUDELETE.CLICK",!0,arguments[0],!1,!1)};this.e181a1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,36,37,38,39];this.GXLastCtrlId=39;this.GridgridstatecollectionsContainer=new gx.grid.grid(this,2,"WbpLvl2",15,"Gridgridstatecollections","Gridgridstatecollections","GridgridstatecollectionsContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.managefilters",[],!1,1,!1,!0,0,!0,!1,!1,"CollWWPBaseObjectsGridStateCollection.Item",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"AV6GridStateCollection",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridgridstatecollectionsContainer;r.addSingleLineEdit("Moveup",16,"vMOVEUP","","","MoveUp","char",30,"px",20,20,"start","e151a2_client",[],"Moveup","MoveUp",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit("Movedown",17,"vMOVEDOWN","","","MoveDown","char",30,"px",20,20,"start","e161a2_client",[],"Movedown","MoveDown",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit("GXV2",18,"GRIDSTATECOLLECTION__TITLE","","","Title","svchar",0,"px",100,80,"start",null,[],"GXV2","GXV2",!0,0,!1,!1,"",0,"WWColumn");r.addSingleLineEdit("GXV3",19,"GRIDSTATECOLLECTION__GRIDSTATEXML",gx.getMessage("URL"),"","GridStateXML","vchar",0,"px",2097152,80,"start",null,[],"GXV3","GXV3",!0,0,!1,!1,"AttributeRealWidth",0,"WWColumn");r.addSingleLineEdit("Udelete",20,"vUDELETE","","","UDelete","char",30,"px",20,20,"start","e171a2_client",[],"Udelete","UDelete",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");this.GridgridstatecollectionsContainer.emptyText=gx.getMessage("");this.setGrid(r);this.GRIDGRIDSTATECOLLECTIONS_EMPOWERERContainer=gx.uc.getNew(this,40,39,"WWP_GridEmpowerer","GRIDGRIDSTATECOLLECTIONS_EMPOWERERContainer","Gridgridstatecollections_empowerer","GRIDGRIDSTATECOLLECTIONS_EMPOWERER");i=this.GRIDGRIDSTATECOLLECTIONS_EMPOWERERContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setDynProp("GridInternalName","Gridinternalname","","char");i.setProp("HasCategories","Hascategories",!1,"bool");i.setProp("InfiniteScrolling","Infinitescrolling","False","str");i.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");i.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");i.setProp("HasRowGroups","Hasrowgroups",!1,"bool");i.setProp("FixedColumns","Fixedcolumns","","str");i.setProp("PopoversInGrid","Popoversingrid","","str");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.DVELOP_BOOTSTRAP_PANEL1Container=gx.uc.getNew(this,34,16,"BootstrapPanel","DVELOP_BOOTSTRAP_PANEL1Container","Dvelop_bootstrap_panel1","DVELOP_BOOTSTRAP_PANEL1");t=this.DVELOP_BOOTSTRAP_PANEL1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!1,"bool");t.setProp("Cls","Cls","","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","","str");t.setProp("Collapsible","Collapsible",!0,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!0,"bool");t.setProp("IconPosition","Iconposition","left","str");t.setProp("AutoScroll","Autoscroll",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[16]={id:16,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:15,gxgrid:this.GridgridstatecollectionsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMOVEUP",fmt:1,gxz:"ZV12MoveUp",gxold:"OV12MoveUp",gxvar:"AV12MoveUp",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12MoveUp=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12MoveUp=n)},v2c:function(n){gx.fn.setGridControlValue("vMOVEUP",n||gx.fn.currentGridRowImpl(15),gx.O.AV12MoveUp,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12MoveUp=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vMOVEUP",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn,evt:"e151a2_client"};n[17]={id:17,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:15,gxgrid:this.GridgridstatecollectionsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMOVEDOWN",fmt:1,gxz:"ZV11MoveDown",gxold:"OV11MoveDown",gxvar:"AV11MoveDown",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11MoveDown=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11MoveDown=n)},v2c:function(n){gx.fn.setGridControlValue("vMOVEDOWN",n||gx.fn.currentGridRowImpl(15),gx.O.AV11MoveDown,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11MoveDown=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vMOVEDOWN",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn,evt:"e161a2_client"};n[18]={id:18,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:0,isacc:0,grid:15,gxgrid:this.GridgridstatecollectionsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"GRIDSTATECOLLECTION__TITLE",fmt:0,gxz:"ZV18GXV2",gxold:"OV18GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18GXV2=n)},v2c:function(n){gx.fn.setGridControlValue("GRIDSTATECOLLECTION__TITLE",n||gx.fn.currentGridRowImpl(15),gx.O.GXV2,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=this.val(n))},val:function(n){return gx.fn.getGridControlValue("GRIDSTATECOLLECTION__TITLE",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};n[19]={id:19,lvl:2,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,isacc:0,grid:15,gxgrid:this.GridgridstatecollectionsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"GRIDSTATECOLLECTION__GRIDSTATEXML",fmt:0,gxz:"ZV19GXV3",gxold:"OV19GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19GXV3=n)},v2c:function(n){gx.fn.setGridControlValue("GRIDSTATECOLLECTION__GRIDSTATEXML",n||gx.fn.currentGridRowImpl(15),gx.O.GXV3,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV3=this.val(n))},val:function(n){return gx.fn.getGridControlValue("GRIDSTATECOLLECTION__GRIDSTATEXML",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};n[20]={id:20,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:15,gxgrid:this.GridgridstatecollectionsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUDELETE",fmt:1,gxz:"ZV13UDelete",gxold:"OV13UDelete",gxvar:"AV13UDelete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13UDelete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13UDelete=n)},v2c:function(n){gx.fn.setGridControlValue("vUDELETE",n||gx.fn.currentGridRowImpl(15),gx.O.AV13UDelete,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13UDelete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUDELETE",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn,evt:"e171a2_client"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTNENTER",grid:0,evt:"e111a2_client",std:"ENTER"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTNCANCEL",grid:0,evt:"e181a1_client"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"HTML_USERTABLE_UTPANELDUMMY",grid:0};n[31]={id:31,fld:"UTPANELDUMMY",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[39]={id:39,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOLLECTIONISEMPTY",fmt:0,gxz:"ZV5CollectionIsEmpty",gxold:"OV5CollectionIsEmpty",gxvar:"AV5CollectionIsEmpty",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV5CollectionIsEmpty=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5CollectionIsEmpty=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vCOLLECTIONISEMPTY",gx.O.AV5CollectionIsEmpty,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5CollectionIsEmpty=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vCOLLECTIONISEMPTY")},nac:gx.falseFn,values:["true","false"]};this.ZV12MoveUp="";this.OV12MoveUp="";this.ZV11MoveDown="";this.OV11MoveDown="";this.ZV18GXV2="";this.OV18GXV2="";this.ZV19GXV3="";this.OV19GXV3="";this.ZV13UDelete="";this.OV13UDelete="";this.AV5CollectionIsEmpty=!1;this.ZV5CollectionIsEmpty=!1;this.OV5CollectionIsEmpty=!1;this.AV5CollectionIsEmpty=!1;this.AV14UserKey="";this.AV12MoveUp="";this.AV11MoveDown="";this.GXV2="";this.GXV3="";this.AV13UDelete="";this.AV6GridStateCollection=[];this.Events={e111a2_client:["ENTER",!0],e151a2_client:["VMOVEUP.CLICK",!0],e161a2_client:["VMOVEDOWN.CLICK",!0],e171a2_client:["VUDELETE.CLICK",!0],e181a1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"GRIDGRIDSTATECOLLECTIONS_nEOF"},{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"Rows"},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"},{av:"AV14UserKey",fld:"vUSERKEY",hsh:!0}],[{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Title"},{ctrl:"FORM",prop:"Caption"},{ctrl:"GRIDSTATECOLLECTION__GRIDSTATEXML",prop:"Visible"},{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Class"}]];this.EvtParms["GRIDGRIDSTATECOLLECTIONS.LOAD"]=[[],[{av:"AV12MoveUp",fld:"vMOVEUP"},{av:"AV11MoveDown",fld:"vMOVEDOWN"},{av:"AV13UDelete",fld:"vUDELETE"}]];this.EvtParms.ENTER=[[{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"},{av:"AV14UserKey",fld:"vUSERKEY",hsh:!0},{av:"GRIDGRIDSTATECOLLECTIONS_nEOF"},{av:"",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"Rows"}],[{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15}]];this.EvtParms["VMOVEUP.CLICK"]=[[{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nEOF"},{av:"",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"Rows"},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"},{av:"AV14UserKey",fld:"vUSERKEY",hsh:!0}],[{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15}]];this.EvtParms["VMOVEDOWN.CLICK"]=[[{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nEOF"},{av:"",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"Rows"},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"},{av:"AV14UserKey",fld:"vUSERKEY",hsh:!0}],[{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15}]];this.EvtParms["VUDELETE.CLICK"]=[[{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nEOF"},{av:"",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"Rows"},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"},{av:"AV14UserKey",fld:"vUSERKEY",hsh:!0}],[{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"}]];this.EvtParms.GRIDGRIDSTATECOLLECTIONS_FIRSTPAGE=[[{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"GRIDGRIDSTATECOLLECTIONS_nEOF"},{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"Rows"},{av:"AV14UserKey",fld:"vUSERKEY",hsh:!0},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"}],[{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Title"},{ctrl:"FORM",prop:"Caption"},{ctrl:"GRIDSTATECOLLECTION__GRIDSTATEXML",prop:"Visible"},{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Class"}]];this.EvtParms.GRIDGRIDSTATECOLLECTIONS_PREVPAGE=[[{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"GRIDGRIDSTATECOLLECTIONS_nEOF"},{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"Rows"},{av:"AV14UserKey",fld:"vUSERKEY",hsh:!0},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"}],[{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Title"},{ctrl:"FORM",prop:"Caption"},{ctrl:"GRIDSTATECOLLECTION__GRIDSTATEXML",prop:"Visible"},{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Class"}]];this.EvtParms.GRIDGRIDSTATECOLLECTIONS_NEXTPAGE=[[{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"GRIDGRIDSTATECOLLECTIONS_nEOF"},{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"Rows"},{av:"AV14UserKey",fld:"vUSERKEY",hsh:!0},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"}],[{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Title"},{ctrl:"FORM",prop:"Caption"},{ctrl:"GRIDSTATECOLLECTION__GRIDSTATEXML",prop:"Visible"},{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Class"}]];this.EvtParms.GRIDGRIDSTATECOLLECTIONS_LASTPAGE=[[{av:"GRIDGRIDSTATECOLLECTIONS_nFirstRecordOnPage"},{av:"GRIDGRIDSTATECOLLECTIONS_nEOF"},{av:"AV6GridStateCollection",fld:"vGRIDSTATECOLLECTION",grid:15},{av:"nGXsfl_15_idx",ctrl:"GRID",prop:"GridCurrRow",grid:15},{av:"nRC_GXsfl_15",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"GridRC",grid:15},{av:"",ctrl:"GRIDGRIDSTATECOLLECTIONS",prop:"Rows"},{av:"AV14UserKey",fld:"vUSERKEY",hsh:!0},{av:"AV5CollectionIsEmpty",fld:"vCOLLECTIONISEMPTY"}],[{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Title"},{ctrl:"FORM",prop:"Caption"},{ctrl:"GRIDSTATECOLLECTION__GRIDSTATEXML",prop:"Visible"},{ctrl:"GRIDSTATECOLLECTION__TITLE",prop:"Class"}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV14UserKey","vUSERKEY",0,"svchar",100,0);this.setVCMap("AV6GridStateCollection","vGRIDSTATECOLLECTION",0,"CollWWPBaseObjectsGridStateCollection.Item",0,0);this.setVCMap("AV14UserKey","vUSERKEY",0,"svchar",100,0);this.setVCMap("AV14UserKey","vUSERKEY",0,"svchar",100,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Gridgridstatecollections"});r.addRefreshingVar({rfrVar:"AV14UserKey"});r.addRefreshingParm({rfrVar:"AV14UserKey"});r.addRefreshingParm(this.GXValidFnc[39]);this.addGridBCProperty("Gridstatecollection",["Title"],this.GXValidFnc[18],"AV6GridStateCollection");this.addGridBCProperty("Gridstatecollection",["GridStateXML"],this.GXValidFnc[19],"AV6GridStateCollection");this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwpbaseobjects.managefilters)})