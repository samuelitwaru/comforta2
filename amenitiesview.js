gx.evt.autoSkip=!1;gx.define("amenitiesview",!1,function(){var t,n;this.ServerClass="amenitiesview";this.PackageName="GeneXus.Programs";this.ServerFullClass="amenitiesview.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV10AmenitiesId=gx.fn.getIntegerValue("vAMENITIESID",gx.thousandSeparator);this.AV8TabCode=gx.fn.getControlValue("vTABCODE")};this.s112_client=function(){return this.executeClientEvent(function(){this.createWebComponent("Webcomponent_general","AmenitiesGeneral",[this.AV10AmenitiesId])},arguments)};this.e13312_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14312_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,16,17,18];this.GXLastCtrlId=18;this.PANEL_GENERALContainer=gx.uc.getNew(this,14,0,"BootstrapPanel","PANEL_GENERALContainer","Panel_general","PANEL_GENERAL");n=this.PANEL_GENERALContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("Width","Width","100%","str");n.setProp("Height","Height","100","str");n.setProp("AutoWidth","Autowidth",!1,"bool");n.setProp("AutoHeight","Autoheight",!0,"bool");n.setProp("Cls","Cls","DVBootstrapResponsivePanel","str");n.setProp("ShowHeader","Showheader",!0,"bool");n.setProp("Title","Title",gx.getMessage("WWP_TemplateDataPanelTitle"),"str");n.setProp("Collapsible","Collapsible",!0,"bool");n.setProp("Collapsed","Collapsed",!1,"bool");n.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");n.setProp("IconPosition","Iconposition","Right","str");n.setProp("AutoScroll","Autoscroll",!1,"bool");n.setProp("Visible","Visible",!0,"bool");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLEVIEWRIGHTITEMS",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"WORKWITHLINK",format:0,grid:0,ctrltype:"textblock"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"AMENITIESGENERAL_CELL",grid:0};t[16]={id:16,fld:"TABLEPANEL_GENERAL",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};this.AV10AmenitiesId=0;this.AV8TabCode="";this.A98AmenitiesId=0;this.A101AmenitiesName="";this.Events={e13312_client:["ENTER",!0],e14312_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV10AmenitiesId",fld:"vAMENITIESID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV10AmenitiesId","vAMENITIESID",0,"int",4,0);this.setVCMap("AV8TabCode","vTABCODE",0,"char",50,0);this.Initialize();this.setComponent({id:"WEBCOMPONENT_GENERAL",GXClass:null,Prefix:"W0019",lvl:1})});gx.wi(function(){gx.createParentObj(this.amenitiesview)})