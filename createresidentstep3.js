gx.evt.autoSkip=!1;gx.define("createresidentstep3",!0,function(n){var t,u,i,r;this.ServerClass="createresidentstep3";this.PackageName="GeneXus.Programs";this.ServerFullClass="createresidentstep3.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV28CheckRequiredFieldsResult=gx.fn.getControlValue("vCHECKREQUIREDFIELDSRESULT");this.AV10HasValidationErrors=gx.fn.getControlValue("vHASVALIDATIONERRORS");this.AV21WebSessionKey=gx.fn.getControlValue("vWEBSESSIONKEY");this.AV19ResidentINCompanySDTs=gx.fn.getControlValue("vRESIDENTINCOMPANYSDTS");this.AV13PreviousStep=gx.fn.getControlValue("vPREVIOUSSTEP");this.AV6GoingBack=gx.fn.getControlValue("vGOINGBACK")};this.Validv_Residentincompanyemail=function(){return this.validCliEvt("Validv_Residentincompanyemail",0,function(){try{var n=gx.util.balloon.getNew("vRESIDENTINCOMPANYEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.AV14ResidentINCompanyEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError(gx.text.format(gx.getMessage("GXM_DoesNotMatchRegExp"),gx.getMessage("Resident INCompany Email"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Gxv4=function(){var n=gx.fn.currentGridRowImpl(43);return this.validCliEvt("Validv_Gxv4",43,function(){try{var n=gx.util.balloon.getNew("RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.GXV4,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError(gx.text.format(gx.getMessage("GXM_DoesNotMatchRegExp"),gx.getMessage("Resident INCompany Email"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s142_client=function(){return this.executeClientEvent(function(){this.AV16ResidentINCompanyKvkNumber="";this.AV17ResidentINCompanyName="";this.AV14ResidentINCompanyEmail="";this.AV18ResidentINCompanyPhone=""},arguments)};this.e112w2_client=function(){return this.executeServerEvent("GRIDSPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e122w2_client=function(){return this.executeServerEvent("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e192w2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e132w2_client=function(){return this.executeServerEvent("'WIZARDPREVIOUS'",!1,null,!1,!1)};this.e142w2_client=function(){return this.executeServerEvent("'DONEXT'",!1,null,!1,!1)};this.e152w2_client=function(){return this.executeServerEvent("'DOSAVECOMPANY'",!1,null,!1,!1)};this.e202w2_client=function(){return this.executeServerEvent("VDELETERECORD.CLICK",!0,arguments[0],!1,!1)};this.e212w2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,44,45,46,47,48,49,50,52,53,54,55,56,57,58,59,60,61,62,63,64];this.GXLastCtrlId=64;this.GridsContainer=new gx.grid.grid(this,2,"WbpLvl2",43,"Grids","Grids","GridsContainer",this.CmpContext,this.IsMasterPage,"createresidentstep3",[],!1,1,!1,!0,0,!1,!1,!1,"CollResidentINCompanySDT",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"AV19ResidentINCompanySDTs",!1,[1,1,1,1],!1,0,!0,!1);u=this.GridsContainer;u.addSingleLineEdit("GXV2",44,"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYKVKNUMBER",gx.getMessage("KVK Number"),"","ResidentINCompanyKvkNumber","svchar",0,"px",8,8,"start",null,[],"GXV2","GXV2",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV3",45,"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYNAME",gx.getMessage("Name"),"","ResidentINCompanyName","svchar",0,"px",40,40,"start",null,[],"GXV3","GXV3",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV4",46,"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYEMAIL",gx.getMessage("Email"),"","ResidentINCompanyEmail","svchar",0,"px",100,80,"start",null,[],"GXV4","GXV4",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("GXV5",47,"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYPHONE",gx.getMessage("Phone"),"","ResidentINCompanyPhone","char",0,"px",20,20,"start",null,[],"GXV5","GXV5",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit("Deleterecord",48,"vDELETERECORD","",gx.getMessage("Delete"),"DeleteRecord","char",0,"px",20,20,"start","e202w2_client",[],"Deleterecord","DeleteRecord",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");this.GridsContainer.emptyText=gx.getMessage("");this.setGrid(u);this.GRIDSPAGINATIONBARContainer=gx.uc.getNew(this,51,20,"DVelop_DVPaginationBar",this.CmpContext+"GRIDSPAGINATIONBARContainer","Gridspaginationbar","GRIDSPAGINATIONBAR");i=this.GRIDSPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption",gx.getMessage("WWP_PagingCaption"),"str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV8GridsCurrentPage","vGRIDSCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV8GridsCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDSCURRENTPAGE",n.ParentObject.AV8GridsCurrentPage)});i.addV2CFunction("AV9GridsPageCount","vGRIDSPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV9GridsPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDSPAGECOUNT",n.ParentObject.AV9GridsPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV7GridsAppliedFilters","vGRIDSAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV7GridsAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDSAPPLIEDFILTERS",n.ParentObject.AV7GridsAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e112w2_client);i.addEventHandler("ChangeRowsPerPage",this.e122w2_client);this.setUserControl(i);this.GRIDS_EMPOWERERContainer=gx.uc.getNew(this,65,20,"WWP_GridEmpowerer",this.CmpContext+"GRIDS_EMPOWERERContainer","Grids_empowerer","GRIDS_EMPOWERER");r=this.GRIDS_EMPOWERERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setDynProp("GridInternalName","Gridinternalname","","char");r.setProp("HasCategories","Hascategories",!1,"bool");r.setProp("InfiniteScrolling","Infinitescrolling","False","str");r.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");r.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");r.setProp("HasRowGroups","Hasrowgroups",!1,"bool");r.setProp("FixedColumns","Fixedcolumns","","str");r.setProp("PopoversInGrid","Popoversingrid","","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLECONTENT",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"TABLEATTRIBUTES",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTINCOMPANYNAME",fmt:0,gxz:"ZV17ResidentINCompanyName",gxold:"OV17ResidentINCompanyName",gxvar:"AV17ResidentINCompanyName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17ResidentINCompanyName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17ResidentINCompanyName=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTINCOMPANYNAME",gx.O.AV17ResidentINCompanyName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17ResidentINCompanyName=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTINCOMPANYNAME")},nac:gx.falseFn};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"svchar",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTINCOMPANYKVKNUMBER",fmt:0,gxz:"ZV16ResidentINCompanyKvkNumber",gxold:"OV16ResidentINCompanyKvkNumber",gxvar:"AV16ResidentINCompanyKvkNumber",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16ResidentINCompanyKvkNumber=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16ResidentINCompanyKvkNumber=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTINCOMPANYKVKNUMBER",gx.O.AV16ResidentINCompanyKvkNumber,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16ResidentINCompanyKvkNumber=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTINCOMPANYKVKNUMBER")},nac:gx.falseFn};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Residentincompanyemail,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTINCOMPANYEMAIL",fmt:0,gxz:"ZV14ResidentINCompanyEmail",gxold:"OV14ResidentINCompanyEmail",gxvar:"AV14ResidentINCompanyEmail",ucs:[],op:[],ip:[29],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14ResidentINCompanyEmail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14ResidentINCompanyEmail=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTINCOMPANYEMAIL",gx.O.AV14ResidentINCompanyEmail,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14ResidentINCompanyEmail=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTINCOMPANYEMAIL")},nac:gx.falseFn,hasRVFmt:!0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTINCOMPANYPHONE",fmt:0,gxz:"ZV18ResidentINCompanyPhone",gxold:"OV18ResidentINCompanyPhone",gxvar:"AV18ResidentINCompanyPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18ResidentINCompanyPhone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18ResidentINCompanyPhone=n)},v2c:function(){gx.fn.setControlValue("vRESIDENTINCOMPANYPHONE",gx.O.AV18ResidentINCompanyPhone,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV18ResidentINCompanyPhone=this.val())},val:function(){return gx.fn.getControlValue("vRESIDENTINCOMPANYPHONE")},nac:gx.falseFn};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"ACTIONBTNTABLE",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"BTNSAVECOMPANY",grid:0,evt:"e152w2_client"};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"GRIDSTABLEWITHPAGINATIONBAR",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"",grid:0};t[44]={id:44,lvl:2,type:"svchar",len:8,dec:0,sign:!1,ro:0,isacc:0,grid:43,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYKVKNUMBER",fmt:0,gxz:"ZV30GXV2",gxold:"OV30GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV30GXV2=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYKVKNUMBER",n||gx.fn.currentGridRowImpl(43),gx.O.GXV2,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYKVKNUMBER",n||gx.fn.currentGridRowImpl(43))},nac:gx.falseFn};t[45]={id:45,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:43,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYNAME",fmt:0,gxz:"ZV31GXV3",gxold:"OV31GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV31GXV3=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYNAME",n||gx.fn.currentGridRowImpl(43),gx.O.GXV3,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV3=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYNAME",n||gx.fn.currentGridRowImpl(43))},nac:gx.falseFn};t[46]={id:46,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:0,isacc:0,grid:43,gxgrid:this.GridsContainer,fnc:this.Validv_Gxv4,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYEMAIL",fmt:0,gxz:"ZV32GXV4",gxold:"OV32GXV4",gxvar:"GXV4",ucs:[],op:[],ip:[46],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV4=n)},v2z:function(n){n!==undefined&&(gx.O.ZV32GXV4=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYEMAIL",n||gx.fn.currentGridRowImpl(43),gx.O.GXV4,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV4=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYEMAIL",n||gx.fn.currentGridRowImpl(43))},nac:gx.falseFn};t[47]={id:47,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:43,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYPHONE",fmt:0,gxz:"ZV33GXV5",gxold:"OV33GXV5",gxvar:"GXV5",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.GXV5=n)},v2z:function(n){n!==undefined&&(gx.O.ZV33GXV5=n)},v2c:function(n){gx.fn.setGridControlValue("RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYPHONE",n||gx.fn.currentGridRowImpl(43),gx.O.GXV5,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV5=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYPHONE",n||gx.fn.currentGridRowImpl(43))},nac:gx.falseFn};t[48]={id:48,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:43,gxgrid:this.GridsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETERECORD",fmt:1,gxz:"ZV24DeleteRecord",gxold:"OV24DeleteRecord",gxvar:"AV24DeleteRecord",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV24DeleteRecord=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24DeleteRecord=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETERECORD",n||gx.fn.currentGridRowImpl(43),gx.O.AV24DeleteRecord,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV24DeleteRecord=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETERECORD",n||gx.fn.currentGridRowImpl(43))},nac:gx.falseFn,evt:"e202w2_client"};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};t[53]={id:53,fld:"",grid:0};t[54]={id:54,fld:"TABLEACTIONS",grid:0};t[55]={id:55,fld:"",grid:0};t[56]={id:56,fld:"",grid:0};t[57]={id:57,fld:"",grid:0};t[58]={id:58,fld:"BTNWIZARDPREVIOUS",grid:0,evt:"e132w2_client"};t[59]={id:59,fld:"",grid:0};t[60]={id:60,fld:"BTNNEXT",grid:0,evt:"e142w2_client"};t[61]={id:61,fld:"",grid:0};t[62]={id:62,fld:"",grid:0};t[63]={id:63,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[64]={id:64,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESIDENTINCOMPANYID",fmt:0,gxz:"ZV15ResidentINCompanyId",gxold:"OV15ResidentINCompanyId",gxvar:"AV15ResidentINCompanyId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15ResidentINCompanyId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV15ResidentINCompanyId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vRESIDENTINCOMPANYID",gx.O.AV15ResidentINCompanyId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15ResidentINCompanyId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vRESIDENTINCOMPANYID",gx.thousandSeparator)},nac:gx.falseFn};this.AV17ResidentINCompanyName="";this.ZV17ResidentINCompanyName="";this.OV17ResidentINCompanyName="";this.AV16ResidentINCompanyKvkNumber="";this.ZV16ResidentINCompanyKvkNumber="";this.OV16ResidentINCompanyKvkNumber="";this.AV14ResidentINCompanyEmail="";this.ZV14ResidentINCompanyEmail="";this.OV14ResidentINCompanyEmail="";this.AV18ResidentINCompanyPhone="";this.ZV18ResidentINCompanyPhone="";this.OV18ResidentINCompanyPhone="";this.ZV30GXV2="";this.OV30GXV2="";this.ZV31GXV3="";this.OV31GXV3="";this.ZV32GXV4="";this.OV32GXV4="";this.ZV33GXV5="";this.OV33GXV5="";this.ZV24DeleteRecord="";this.OV24DeleteRecord="";this.AV15ResidentINCompanyId=0;this.ZV15ResidentINCompanyId=0;this.OV15ResidentINCompanyId=0;this.AV17ResidentINCompanyName="";this.AV16ResidentINCompanyKvkNumber="";this.AV14ResidentINCompanyEmail="";this.AV18ResidentINCompanyPhone="";this.AV8GridsCurrentPage=0;this.AV15ResidentINCompanyId=0;this.AV21WebSessionKey="";this.AV13PreviousStep="";this.AV6GoingBack=!1;this.GXV2="";this.GXV3="";this.GXV4="";this.GXV5="";this.AV24DeleteRecord="";this.AV19ResidentINCompanySDTs=[];this.AV28CheckRequiredFieldsResult=!1;this.AV10HasValidationErrors=!1;this.Events={e112w2_client:["GRIDSPAGINATIONBAR.CHANGEPAGE",!0],e122w2_client:["GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e192w2_client:["ENTER",!0],e132w2_client:["'WIZARDPREVIOUS'",!0],e142w2_client:["'DONEXT'",!0],e152w2_client:["'DOSAVECOMPANY'",!0],e202w2_client:["VDELETERECORD.CLICK",!0],e212w2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43},{av:"",ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0}],[{av:"AV8GridsCurrentPage",fld:"vGRIDSCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV9GridsPageCount",fld:"vGRIDSPAGECOUNT",pic:"ZZZZZZZZZ9"}]];this.EvtParms["GRIDS.LOAD"]=[[],[{av:"AV24DeleteRecord",fld:"vDELETERECORD"}]];this.EvtParms["GRIDSPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43},{av:"",ctrl:"GRIDS",prop:"Rows"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"sPrefix"},{av:"this.GRIDSPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDSPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRIDS_nFirstRecordOnPage"},{av:"GRIDS_nEOF"},{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43},{av:"",ctrl:"GRIDS",prop:"Rows"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"sPrefix"},{av:"this.GRIDSPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDSPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{av:"",ctrl:"GRIDS",prop:"Rows"}]];this.EvtParms.ENTER=[[{av:"AV28CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"AV17ResidentINCompanyName",fld:"vRESIDENTINCOMPANYNAME"},{av:"AV16ResidentINCompanyKvkNumber",fld:"vRESIDENTINCOMPANYKVKNUMBER"},{av:"AV14ResidentINCompanyEmail",fld:"vRESIDENTINCOMPANYEMAIL"},{av:"AV21WebSessionKey",fld:"vWEBSESSIONKEY"},{av:"AV15ResidentINCompanyId",fld:"vRESIDENTINCOMPANYID",pic:"ZZZ9"},{av:"AV18ResidentINCompanyPhone",fld:"vRESIDENTINCOMPANYPHONE"},{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43}],[{av:"AV28CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"}]];this.EvtParms["'WIZARDPREVIOUS'"]=[[{av:"AV21WebSessionKey",fld:"vWEBSESSIONKEY"},{av:"AV15ResidentINCompanyId",fld:"vRESIDENTINCOMPANYID",pic:"ZZZ9"},{av:"AV17ResidentINCompanyName",fld:"vRESIDENTINCOMPANYNAME"},{av:"AV16ResidentINCompanyKvkNumber",fld:"vRESIDENTINCOMPANYKVKNUMBER"},{av:"AV14ResidentINCompanyEmail",fld:"vRESIDENTINCOMPANYEMAIL"},{av:"AV18ResidentINCompanyPhone",fld:"vRESIDENTINCOMPANYPHONE"},{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43}],[]];this.EvtParms["'DONEXT'"]=[[{av:"AV21WebSessionKey",fld:"vWEBSESSIONKEY"},{av:"AV15ResidentINCompanyId",fld:"vRESIDENTINCOMPANYID",pic:"ZZZ9"},{av:"AV17ResidentINCompanyName",fld:"vRESIDENTINCOMPANYNAME"},{av:"AV16ResidentINCompanyKvkNumber",fld:"vRESIDENTINCOMPANYKVKNUMBER"},{av:"AV14ResidentINCompanyEmail",fld:"vRESIDENTINCOMPANYEMAIL"},{av:"AV18ResidentINCompanyPhone",fld:"vRESIDENTINCOMPANYPHONE"},{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43}],[]];this.EvtParms["'DOSAVECOMPANY'"]=[[{av:"AV28CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43},{av:"AV16ResidentINCompanyKvkNumber",fld:"vRESIDENTINCOMPANYKVKNUMBER"},{av:"AV17ResidentINCompanyName",fld:"vRESIDENTINCOMPANYNAME"},{av:"AV14ResidentINCompanyEmail",fld:"vRESIDENTINCOMPANYEMAIL"},{av:"AV18ResidentINCompanyPhone",fld:"vRESIDENTINCOMPANYPHONE"},{av:"GRIDS_nEOF"},{av:"",ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"}],[{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43},{av:"AV28CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"},{av:"AV16ResidentINCompanyKvkNumber",fld:"vRESIDENTINCOMPANYKVKNUMBER"},{av:"AV17ResidentINCompanyName",fld:"vRESIDENTINCOMPANYNAME"},{av:"AV14ResidentINCompanyEmail",fld:"vRESIDENTINCOMPANYEMAIL"},{av:"AV18ResidentINCompanyPhone",fld:"vRESIDENTINCOMPANYPHONE"}]];this.EvtParms["VDELETERECORD.CLICK"]=[[{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43},{av:"GRIDS_nEOF"},{av:"",ctrl:"GRIDS",prop:"Rows"},{av:"sPrefix"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0}],[{av:"AV19ResidentINCompanySDTs",fld:"vRESIDENTINCOMPANYSDTS",grid:43},{av:"nGXsfl_43_idx",ctrl:"GRID",prop:"GridCurrRow",grid:43},{av:"GRIDS_nFirstRecordOnPage"},{av:"nRC_GXsfl_43",ctrl:"GRIDS",prop:"GridRC",grid:43}]];this.EvtParms.VALIDV_RESIDENTINCOMPANYEMAIL=[[],[]];this.EvtParms.VALIDV_GXV4=[[{av:"GXV4",fld:"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYEMAIL"}],[]];this.setVCMap("AV28CheckRequiredFieldsResult","vCHECKREQUIREDFIELDSRESULT",0,"boolean",4,0);this.setVCMap("AV10HasValidationErrors","vHASVALIDATIONERRORS",0,"boolean",4,0);this.setVCMap("AV21WebSessionKey","vWEBSESSIONKEY",0,"svchar",40,0);this.setVCMap("AV19ResidentINCompanySDTs","vRESIDENTINCOMPANYSDTS",0,"CollResidentINCompanySDT",0,0);this.setVCMap("AV13PreviousStep","vPREVIOUSSTEP",0,"svchar",40,0);this.setVCMap("AV6GoingBack","vGOINGBACK",0,"boolean",4,0);u.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grids"});u.addRefreshingVar({rfrVar:"AV10HasValidationErrors"});u.addRefreshingParm({rfrVar:"AV10HasValidationErrors"});this.addGridBCProperty("Residentincompanysdts",["ResidentINCompanyKvkNumber"],this.GXValidFnc[44],"AV19ResidentINCompanySDTs");this.addGridBCProperty("Residentincompanysdts",["ResidentINCompanyName"],this.GXValidFnc[45],"AV19ResidentINCompanySDTs");this.addGridBCProperty("Residentincompanysdts",["ResidentINCompanyEmail"],this.GXValidFnc[46],"AV19ResidentINCompanySDTs");this.addGridBCProperty("Residentincompanysdts",["ResidentINCompanyPhone"],this.GXValidFnc[47],"AV19ResidentINCompanySDTs");this.Initialize()})