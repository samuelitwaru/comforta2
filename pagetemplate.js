gx.evt.autoSkip=!1;gx.define("pagetemplate",!1,function(){var n,i,t;this.ServerClass="pagetemplate";this.PackageName="GeneXus.Programs";this.ServerFullClass="pagetemplate.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7PageTemplateId=gx.fn.getIntegerValue("vPAGETEMPLATEID",gx.thousandSeparator);this.A40000PageTemplateImage_GXI=gx.fn.getControlValue("PAGETEMPLATEIMAGE_GXI");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV13DetailWCInfo=gx.fn.getControlValue("vDETAILWCINFO");this.AV14CurrentTab_ReturnUrl=gx.fn.getControlValue("vCURRENTTAB_RETURNURL")};this.Valid_Pagetemplateid=function(){return this.validCliEvt("Valid_Pagetemplateid",0,function(){try{var n=gx.util.balloon.getNew("PAGETEMPLATEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Pagetemplatename=function(){return this.validCliEvt("Valid_Pagetemplatename",0,function(){try{var n=gx.util.balloon.getNew("PAGETEMPLATENAME");if(this.AnyError=0,gx.text.compare("",this.A108PageTemplateName)==0)try{n.setError(gx.text.format(gx.getMessage("WWP_RequiredAttribute"),gx.getMessage("Page Template Name"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Pagetemplateimage=function(){return this.validCliEvt("Valid_Pagetemplateimage",0,function(){try{var n=gx.util.balloon.getNew("PAGETEMPLATEIMAGE");if(this.AnyError=0,gx.text.compare("",this.A110PageTemplateImage)==0&&gx.text.compare("",this.A40000PageTemplateImage_GXI)==0)try{n.setError(gx.text.format(gx.getMessage("WWP_RequiredAttribute"),gx.getMessage("Page Template Image"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Pagetemplatedescription=function(){return this.validCliEvt("Valid_Pagetemplatedescription",0,function(){try{var n=gx.util.balloon.getNew("PAGETEMPLATEDESCRIPTION");if(this.AnyError=0,gx.text.compare("",this.A111PageTemplateDescription)==0)try{n.setError(gx.text.format(gx.getMessage("WWP_RequiredAttribute"),gx.getMessage("Page Template Description"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110f25_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.WWPUTILITIESContainer.CurrentTab_Return();this.AV14CurrentTab_ReturnUrl=this.WWPUTILITIESContainer.CurrentTab_ReturnUrl;gx.text.compare("",this.AV14CurrentTab_ReturnUrl)==0||this.callUrl(this.AV14CurrentTab_ReturnUrl);gx.text.compare(this.Gx_mode,"INS")==0&&gx.fx.obs.notify("SplitScreenWithTabs_UpdateTab",[6,this.AV13DetailWCInfo,!1,"pagetemplate"]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e130f2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e140f25_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e150f25_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53];this.GXLastCtrlId=53;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");i=this.DVPANEL_TABLEATTRIBUTESContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelCard_GrayTitle","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title",gx.getMessage("WWP_TemplateDataPanelTitle"),"str");i.setProp("Collapsible","Collapsible",!1,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.WWPUTILITIESContainer=gx.uc.getNew(this,54,22,"DVelop_WorkWithPlusUtilities","WWPUTILITIESContainer","Wwputilities","WWPUTILITIES");t=this.WWPUTILITIESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("EnableAutoUpdateFromDocumentTitle","Enableautoupdatefromdocumenttitle",!1,"bool");t.setProp("EnableFixObjectFitCover","Enablefixobjectfitcover",!1,"bool");t.setProp("EnableFloatingLabels","Enablefloatinglabels",!1,"bool");t.setProp("EmpowerTabs","Empowertabs",!1,"bool");t.setProp("EnableUpdateRowSelectionStatus","Enableupdaterowselectionstatus",!1,"bool");t.setProp("CurrentTab_ReturnUrl","Currenttab_returnurl","","char");t.setProp("EnableConvertComboToBootstrapSelect","Enableconvertcombotobootstrapselect",!1,"bool");t.setProp("AllowColumnResizing","Allowcolumnresizing",!1,"bool");t.setProp("AllowColumnReordering","Allowcolumnreordering",!1,"bool");t.setProp("AllowColumnDragging","Allowcolumndragging",!1,"bool");t.setProp("AllowColumnsRestore","Allowcolumnsrestore",!1,"bool");t.setProp("RestoreColumnsIconClass","Restorecolumnsiconclass","fas fa-undo","str");t.setProp("PagBarIncludeGoTo","Pagbarincludegoto",!1,"bool");t.setProp("ComboLoadType","Comboloadtype","All","str");t.setProp("InfiniteScrollingPage","Infinitescrollingpage",10,"num");t.setProp("UpdateButtonText","Updatebuttontext","WWP_ColumnsSelectorButton","str");t.setProp("AddNewOption","Addnewoption","WWP_AddNewOption","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","WWP_OnlySelectedValues","str");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");t.setProp("SelectAll","Selectall","WWP_SelectAll","str");t.setProp("SortASC","Sortasc","WWP_TSSortASC","str");t.setProp("SortDSC","Sortdsc","WWP_TSSortDSC","str");t.setProp("AllowGroupText","Allowgrouptext","WWP_GroupByOption","str");t.setProp("FixLeftText","Fixlefttext","WWP_TSFixLeft","str");t.setProp("FixRightText","Fixrighttext","WWP_TSFixRight","str");t.setProp("LoadingData","Loadingdata","WWP_TSLoading","str");t.setProp("CleanFilter","Cleanfilter","WWP_TSCleanFilter","str");t.setProp("RangeFilterFrom","Rangefilterfrom","WWP_TSFrom","str");t.setProp("RangeFilterTo","Rangefilterto","WWP_TSTo","str");t.setProp("RangePickerInviteMessage","Rangepickerinvitemessage","WWP_TSRangePickerInviteMessage","str");t.setProp("NoResultsFound","Noresultsfound","WWP_TSNoResults","str");t.setProp("SearchButtonText","Searchbuttontext","WWP_TSSearchButtonCaption","str");t.setProp("SearchMultipleValuesButtonText","Searchmultiplevaluesbuttontext","WWP_FilterSelected","str");t.setProp("ColumnSelectorFixedLeftCategory","Columnselectorfixedleftcategory","WWP_ColumnSelectorFixedLeftCategory","str");t.setProp("ColumnSelectorFixedRightCategory","Columnselectorfixedrightcategory","WWP_ColumnSelectorFixedRightCategory","str");t.setProp("ColumnSelectorNotFixedCategory","Columnselectornotfixedcategory","WWP_ColumnSelectorNotFixedCategory","str");t.setProp("ColumnSelectorNoCategoryText","Columnselectornocategorytext","WWP_ColumnSelectorNoCategoryText","str");t.setProp("ColumnSelectorFixedEmpty","Columnselectorfixedempty","WWP_ColumnSelectorFixedEmpty","str");t.setProp("ColumnSelectorRestoreTooltip","Columnselectorrestoretooltip","WWP_SelectColumns_RestoreDefault","str");t.setProp("PagBarGoToCaption","Pagbargotocaption","WWP_PaginationBarGoToCaption","str");t.setProp("PagBarGoToIconClass","Pagbargotoiconclass","fas fa-redo","str");t.setProp("PagBarGoToTooltip","Pagbargototooltip","WWP_PaginationBarGoToTooltip","str");t.setProp("PagBarEmptyFilteredGridCaption","Pagbaremptyfilteredgridcaption","WWP_PaginationBarEmptyFilteredGridCaption","str");t.setProp("IncludeLineSeparator","Includelineseparator",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLECONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Pagetemplatename,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATENAME",fmt:0,gxz:"Z108PageTemplateName",gxold:"O108PageTemplateName",gxvar:"A108PageTemplateName",ucs:[],op:[22],ip:[22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A108PageTemplateName=n)},v2z:function(n){n!==undefined&&(gx.O.Z108PageTemplateName=n)},v2c:function(){gx.fn.setControlValue("PAGETEMPLATENAME",gx.O.A108PageTemplateName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A108PageTemplateName=this.val())},val:function(){return gx.fn.getControlValue("PAGETEMPLATENAME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Pagetemplateimage,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATEIMAGE",fmt:0,gxz:"Z110PageTemplateImage",gxold:"O110PageTemplateImage",gxvar:"A110PageTemplateImage",ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A110PageTemplateImage=n)},v2z:function(n){n!==undefined&&(gx.O.Z110PageTemplateImage=n)},v2c:function(){gx.fn.setMultimediaValue("PAGETEMPLATEIMAGE",gx.O.A110PageTemplateImage,gx.O.A40000PageTemplateImage_GXI)},c2v:function(){gx.O.A40000PageTemplateImage_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A110PageTemplateImage=this.val())},val:function(){return gx.fn.getBlobValue("PAGETEMPLATEIMAGE")},val_GXI:function(){return gx.fn.getControlValue("PAGETEMPLATEIMAGE_GXI")},gxvar_GXI:"A40000PageTemplateImage_GXI",nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:this.Valid_Pagetemplatedescription,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATEDESCRIPTION",fmt:0,gxz:"Z111PageTemplateDescription",gxold:"O111PageTemplateDescription",gxvar:"A111PageTemplateDescription",ucs:[],op:[31],ip:[31],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A111PageTemplateDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z111PageTemplateDescription=n)},v2c:function(){gx.fn.setControlValue("PAGETEMPLATEDESCRIPTION",gx.O.A111PageTemplateDescription,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A111PageTemplateDescription=this.val())},val:function(){return gx.fn.getControlValue("PAGETEMPLATEDESCRIPTION")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATEHTML",fmt:1,gxz:"Z114PageTemplateHtml",gxold:"O114PageTemplateHtml",gxvar:"A114PageTemplateHtml",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A114PageTemplateHtml=n)},v2z:function(n){n!==undefined&&(gx.O.Z114PageTemplateHtml=n)},v2c:function(){gx.fn.setControlValue("PAGETEMPLATEHTML",gx.O.A114PageTemplateHtml,1);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A114PageTemplateHtml=this.val())},val:function(){return gx.fn.getControlValue("PAGETEMPLATEHTML")},nac:gx.falseFn};this.declareDomainHdlr(35,function(){});n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATECSS",fmt:0,gxz:"Z113PageTemplateCSS",gxold:"O113PageTemplateCSS",gxvar:"A113PageTemplateCSS",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A113PageTemplateCSS=n)},v2z:function(n){n!==undefined&&(gx.O.Z113PageTemplateCSS=n)},v2c:function(){gx.fn.setControlValue("PAGETEMPLATECSS",gx.O.A113PageTemplateCSS,0)},c2v:function(){this.val()!==undefined&&(gx.O.A113PageTemplateCSS=this.val())},val:function(){return gx.fn.getControlValue("PAGETEMPLATECSS")},nac:gx.falseFn};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"BTNTRN_ENTER",grid:0,evt:"e140f25_client",std:"ENTER"};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"BTNTRN_CANCEL",grid:0,evt:"e110f25_client"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTNTRN_DELETE",grid:0,evt:"e160f25_client",std:"DELETE"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[53]={id:53,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Pagetemplateid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGETEMPLATEID",fmt:0,gxz:"Z107PageTemplateId",gxold:"O107PageTemplateId",gxvar:"A107PageTemplateId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A107PageTemplateId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z107PageTemplateId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PAGETEMPLATEID",gx.O.A107PageTemplateId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A107PageTemplateId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PAGETEMPLATEID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(53,function(){});this.A108PageTemplateName="";this.Z108PageTemplateName="";this.O108PageTemplateName="";this.A40000PageTemplateImage_GXI="";this.A110PageTemplateImage="";this.Z110PageTemplateImage="";this.O110PageTemplateImage="";this.A111PageTemplateDescription="";this.Z111PageTemplateDescription="";this.O111PageTemplateDescription="";this.A114PageTemplateHtml="";this.Z114PageTemplateHtml="";this.O114PageTemplateHtml="";this.A113PageTemplateCSS="";this.Z113PageTemplateCSS="";this.O113PageTemplateCSS="";this.A107PageTemplateId=0;this.Z107PageTemplateId=0;this.O107PageTemplateId=0;this.A40000PageTemplateImage_GXI="";this.AV8WWPContext={UserId:0,UserName:""};this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7PageTemplateId=0;this.AV12WebSession={};this.A107PageTemplateId=0;this.A108PageTemplateName="";this.A111PageTemplateDescription="";this.A114PageTemplateHtml="";this.A113PageTemplateCSS="";this.A110PageTemplateImage="";this.Gx_mode="";this.AV13DetailWCInfo={Link:"",Title:"",Keys:""};this.AV14CurrentTab_ReturnUrl="";this.Events={e130f2_client:["AFTER TRN",!0],e140f25_client:["ENTER",!0],e150f25_client:["CANCEL",!0],e110f25_client:["'CANCEL'",!1]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7PageTemplateId",fld:"vPAGETEMPLATEID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV13DetailWCInfo",fld:"vDETAILWCINFO",hsh:!0},{av:"AV7PageTemplateId",fld:"vPAGETEMPLATEID",pic:"ZZZ9",hsh:!0},{av:"A107PageTemplateId",fld:"PAGETEMPLATEID",pic:"ZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"A107PageTemplateId",fld:"PAGETEMPLATEID",pic:"ZZZ9"},{av:"AV13DetailWCInfo",fld:"vDETAILWCINFO",hsh:!0},{av:"A108PageTemplateName",fld:"PAGETEMPLATENAME"},{av:"this.WWPUTILITIESContainer.CurrentTab_ReturnUrl",ctrl:"WWPUTILITIES",prop:"CurrentTab_ReturnUrl"}],[{av:"AV13DetailWCInfo",fld:"vDETAILWCINFO",hsh:!0}]];this.EvtParms["'CANCEL'"]=[[{av:"this.WWPUTILITIESContainer.CurrentTab_ReturnUrl",ctrl:"WWPUTILITIES",prop:"CurrentTab_ReturnUrl"},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV13DetailWCInfo",fld:"vDETAILWCINFO",hsh:!0}],[]];this.EvtParms.VALID_PAGETEMPLATENAME=[[{av:"A108PageTemplateName",fld:"PAGETEMPLATENAME"}],[{av:"A108PageTemplateName",fld:"PAGETEMPLATENAME"}]];this.EvtParms.VALID_PAGETEMPLATEIMAGE=[[{av:"A110PageTemplateImage",fld:"PAGETEMPLATEIMAGE"}],[{av:"A110PageTemplateImage",fld:"PAGETEMPLATEIMAGE"}]];this.EvtParms.VALID_PAGETEMPLATEDESCRIPTION=[[{av:"A111PageTemplateDescription",fld:"PAGETEMPLATEDESCRIPTION"}],[{av:"A111PageTemplateDescription",fld:"PAGETEMPLATEDESCRIPTION"}]];this.EvtParms.VALID_PAGETEMPLATEID=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7PageTemplateId","vPAGETEMPLATEID",0,"int",4,0);this.setVCMap("A40000PageTemplateImage_GXI","PAGETEMPLATEIMAGE_GXI",0,"svchar",2048,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV13DetailWCInfo","vDETAILWCINFO",0,"WWPBaseObjectsSplitScreenDetailInfo",0,0);this.setVCMap("AV13DetailWCInfo","vDETAILWCINFO",0,"WWPBaseObjectsSplitScreenDetailInfo",0,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV14CurrentTab_ReturnUrl","vCURRENTTAB_RETURNURL",0,"svchar",200,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.pagetemplate)})