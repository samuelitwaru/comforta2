gx.evt.autoSkip=!1;gx.define("createlocationstep2",!0,function(n){var t,i,r;this.ServerClass="createlocationstep2";this.PackageName="GeneXus.Programs";this.ServerFullClass="createlocationstep2.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV11IsAuthorized_AmenitiesName=gx.fn.getControlValue("vISAUTHORIZED_AMENITIESNAME");this.AV15WizardData=gx.fn.getControlValue("vWIZARDDATA");this.AV10HasValidationErrors=gx.fn.getControlValue("vHASVALIDATIONERRORS");this.AV14WebSessionKey=gx.fn.getControlValue("vWEBSESSIONKEY");this.AV12PreviousStep=gx.fn.getControlValue("vPREVIOUSSTEP");this.AV7GoingBack=gx.fn.getControlValue("vGOINGBACK")};this.s132_client=function(){return this.executeClientEvent(function(){for(var n=1,i=gx.fn.currentGridRowImpl(18),r,t=gx.O.getGridById(18,0);n<=t.grid.rows.length;)r=gx.text.padl(gx.text.tostring(n),4,"0"),t.instanciateRow(t.grid.getRowById(n-1)),this.AV8GridSelected&&(this.AV9GridSelectedRow={AmenitiesId:0,AmenitiesName:""},this.AV9GridSelectedRow.AmenitiesId=gx.num.trunc(this.A98AmenitiesId,0),this.AV9GridSelectedRow.AmenitiesName=this.A101AmenitiesName,this.AV15WizardData.Step2.Grid.push(this.AV9GridSelectedRow)),n=gx.num.trunc(n+1,0);i&&t.instanciateRow(i)},arguments)};this.e11302_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e12302_client=function(){return this.executeServerEvent("'WIZARDPREVIOUS'",!1,null,!1,!1)};this.e15302_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33];this.GXLastCtrlId=33;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",18,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"createlocationstep2",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!0,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addCheckBox("Gridselected",19,"vGRIDSELECTED","","","GridSelected","boolean","true","false",null,!0,!1,0,"px","");i.addSingleLineEdit(98,20,"AMENITIESID",gx.getMessage("Id"),"","AmenitiesId","int",30,"px",4,4,"end",null,[],98,"AmenitiesId",!1,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit(101,21,"AMENITIESNAME","","","AmenitiesName","svchar",0,"px",40,40,"start",null,[],101,"AmenitiesName",!0,0,!1,!1,"Attribute",0,"WWColumn");this.GridContainer.emptyText=gx.getMessage("");this.setGrid(i);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,34,19,"WWP_GridEmpowerer",this.CmpContext+"GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");r=this.GRID_EMPOWERERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setDynProp("GridInternalName","Gridinternalname","","char");r.setProp("HasCategories","Hascategories",!1,"bool");r.setProp("InfiniteScrolling","Infinitescrolling","False","str");r.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");r.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");r.setProp("HasRowGroups","Hasrowgroups",!1,"bool");r.setProp("FixedColumns","Fixedcolumns","","str");r.setProp("PopoversInGrid","Popoversingrid","","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLEFILTERS",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"TABLEGRID",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[19]={id:19,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:0,isacc:0,grid:18,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGRIDSELECTED",fmt:0,gxz:"ZV8GridSelected",gxold:"OV8GridSelected",gxvar:"AV8GridSelected",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV8GridSelected=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8GridSelected=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("vGRIDSELECTED",n||gx.fn.currentGridRowImpl(18),gx.O.AV8GridSelected,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8GridSelected=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("vGRIDSELECTED",n||gx.fn.currentGridRowImpl(18))},nac:gx.falseFn,values:["true","false"]};t[20]={id:20,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:18,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMENITIESID",fmt:0,gxz:"Z98AmenitiesId",gxold:"O98AmenitiesId",gxvar:"A98AmenitiesId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A98AmenitiesId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z98AmenitiesId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("AMENITIESID",n||gx.fn.currentGridRowImpl(18),gx.O.A98AmenitiesId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A98AmenitiesId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("AMENITIESID",n||gx.fn.currentGridRowImpl(18),gx.thousandSeparator)},nac:gx.falseFn};t[21]={id:21,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:18,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMENITIESNAME",fmt:0,gxz:"Z101AmenitiesName",gxold:"O101AmenitiesName",gxvar:"A101AmenitiesName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A101AmenitiesName=n)},v2z:function(n){n!==undefined&&(gx.O.Z101AmenitiesName=n)},v2c:function(n){gx.fn.setGridControlValue("AMENITIESNAME",n||gx.fn.currentGridRowImpl(18),gx.O.A101AmenitiesName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A101AmenitiesName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("AMENITIESNAME",n||gx.fn.currentGridRowImpl(18))},nac:gx.falseFn};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"TABLEACTIONS",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"BTNWIZARDPREVIOUS",grid:0,evt:"e12302_client"};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"BTNWIZARDNEXT",grid:0,evt:"e11302_client",std:"ENTER"};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.ZV8GridSelected=!1;this.OV8GridSelected=!1;this.Z98AmenitiesId=0;this.O98AmenitiesId=0;this.Z101AmenitiesName="";this.O101AmenitiesName="";this.AV14WebSessionKey="";this.AV12PreviousStep="";this.AV7GoingBack=!1;this.AV8GridSelected=!1;this.A98AmenitiesId=0;this.A101AmenitiesName="";this.AV11IsAuthorized_AmenitiesName=!1;this.AV15WizardData={Step1:{CustomerLocationName:"",CustomerLocationId:0,CustomerLocationEmail:"",CustomerLocationPhone:"",CustomerLocationPostalAddress:"",CustomerLocationVisitingAddress:"",CustomerLocationDescription:""},Step2:{Grid:[]},Step3:{CustomerLocationReceptionistId:0,CustomerLocationReceptionistGivenName:"",CustomerLocationReceptionistLastName:"",CustomerLocationReceptionistInitials:"",CustomerLocationReceptionistEmail:"",CustomerLocationReceptionistPhone:"",CustomerLocationReceptionistAddress:"",LocationReceptionistSDTs:[]},AuxiliarData:[]};this.AV10HasValidationErrors=!1;this.AV9GridSelectedRow={AmenitiesId:0,AmenitiesName:""};this.Events={e11302_client:["ENTER",!0],e12302_client:["'WIZARDPREVIOUS'",!0],e15302_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"",ctrl:"vGRIDSELECTED",prop:"Titleformat"},{av:"gx.fn.getCtrlProperty('vGRIDSELECTED','Title')",ctrl:"vGRIDSELECTED",prop:"Title"},{av:"AV15WizardData",fld:"vWIZARDDATA"},{av:"sPrefix"},{av:"AV11IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"AV11IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"A98AmenitiesId",fld:"AMENITIESID",pic:"ZZZ9",hsh:!0},{av:"AV15WizardData",fld:"vWIZARDDATA"},{av:"A101AmenitiesName",fld:"AMENITIESNAME",hsh:!0}],[{av:"gx.fn.getCtrlProperty('AMENITIESNAME','Link')",ctrl:"AMENITIESNAME",prop:"Link"},{av:"AV8GridSelected",fld:"vGRIDSELECTED"}]];this.EvtParms.ENTER=[[{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"AV14WebSessionKey",fld:"vWEBSESSIONKEY"},{av:"AV15WizardData",fld:"vWIZARDDATA"},{av:"AV8GridSelected",fld:"vGRIDSELECTED",grid:18},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_18",ctrl:"GRID",grid:18,prop:"GridRC",grid:18},{av:"A98AmenitiesId",fld:"AMENITIESID",grid:18,pic:"ZZZ9",hsh:!0},{av:"A101AmenitiesName",fld:"AMENITIESNAME",grid:18,hsh:!0}],[{av:"AV15WizardData",fld:"vWIZARDDATA"}]];this.EvtParms["'WIZARDPREVIOUS'"]=[[{av:"AV14WebSessionKey",fld:"vWEBSESSIONKEY"},{av:"AV15WizardData",fld:"vWIZARDDATA"},{av:"AV8GridSelected",fld:"vGRIDSELECTED",grid:18},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_18",ctrl:"GRID",grid:18,prop:"GridRC",grid:18},{av:"A98AmenitiesId",fld:"AMENITIESID",grid:18,pic:"ZZZ9",hsh:!0},{av:"A101AmenitiesName",fld:"AMENITIESNAME",grid:18,hsh:!0}],[{av:"AV15WizardData",fld:"vWIZARDDATA"}]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"",ctrl:"vGRIDSELECTED",prop:"Titleformat"},{av:"gx.fn.getCtrlProperty('vGRIDSELECTED','Title')",ctrl:"vGRIDSELECTED",prop:"Title"},{av:"AV11IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV15WizardData",fld:"vWIZARDDATA"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"",ctrl:"vGRIDSELECTED",prop:"Titleformat"},{av:"gx.fn.getCtrlProperty('vGRIDSELECTED','Title')",ctrl:"vGRIDSELECTED",prop:"Title"},{av:"AV11IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV15WizardData",fld:"vWIZARDDATA"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"",ctrl:"vGRIDSELECTED",prop:"Titleformat"},{av:"gx.fn.getCtrlProperty('vGRIDSELECTED','Title')",ctrl:"vGRIDSELECTED",prop:"Title"},{av:"AV11IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV15WizardData",fld:"vWIZARDDATA"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"",ctrl:"vGRIDSELECTED",prop:"Titleformat"},{av:"gx.fn.getCtrlProperty('vGRIDSELECTED','Title')",ctrl:"vGRIDSELECTED",prop:"Title"},{av:"AV11IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV15WizardData",fld:"vWIZARDDATA"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"sPrefix"}],[]];this.EnterCtrl=["BTNWIZARDNEXT"];this.setVCMap("AV11IsAuthorized_AmenitiesName","vISAUTHORIZED_AMENITIESNAME",0,"boolean",4,0);this.setVCMap("AV15WizardData","vWIZARDDATA",0,"CreateLocationData",0,0);this.setVCMap("AV10HasValidationErrors","vHASVALIDATIONERRORS",0,"boolean",4,0);this.setVCMap("AV14WebSessionKey","vWEBSESSIONKEY",0,"svchar",40,0);this.setVCMap("AV12PreviousStep","vPREVIOUSSTEP",0,"svchar",40,0);this.setVCMap("AV7GoingBack","vGOINGBACK",0,"boolean",4,0);this.setVCMap("AV11IsAuthorized_AmenitiesName","vISAUTHORIZED_AMENITIESNAME",0,"boolean",4,0);this.setVCMap("AV15WizardData","vWIZARDDATA",0,"CreateLocationData",0,0);this.setVCMap("AV11IsAuthorized_AmenitiesName","vISAUTHORIZED_AMENITIESNAME",0,"boolean",4,0);this.setVCMap("AV15WizardData","vWIZARDDATA",0,"CreateLocationData",0,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV8GridSelected",rfrProp:"Titleformat",gxAttId:"Gridselected"});i.addRefreshingVar({rfrVar:"AV8GridSelected",rfrProp:"Title",gxAttId:"Gridselected"});i.addRefreshingVar({rfrVar:"AV11IsAuthorized_AmenitiesName"});i.addRefreshingVar({rfrVar:"AV15WizardData"});i.addRefreshingVar({rfrVar:"AV10HasValidationErrors"});i.addRefreshingParm({rfrVar:"AV8GridSelected",rfrProp:"Titleformat",gxAttId:"Gridselected"});i.addRefreshingParm({rfrVar:"AV8GridSelected",rfrProp:"Title",gxAttId:"Gridselected"});i.addRefreshingParm({rfrVar:"AV11IsAuthorized_AmenitiesName"});i.addRefreshingParm({rfrVar:"AV15WizardData"});i.addRefreshingParm({rfrVar:"AV10HasValidationErrors"});this.Initialize()})