gx.evt.autoSkip=!1;gx.define("amenitiestypeamenitieswc",!0,function(n){var i,u,f,r,t,e;this.ServerClass="amenitiestypeamenitieswc";this.PackageName="GeneXus.Programs";this.ServerFullClass="amenitiestypeamenitieswc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV20ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",gx.thousandSeparator);this.AV33Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV14OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",gx.thousandSeparator);this.AV15OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV28IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV30IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE");this.AV31IsAuthorized_AmenitiesName=gx.fn.getControlValue("vISAUTHORIZED_AMENITIESNAME");this.AV12GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV32IsAuthorized_Insert=gx.fn.getControlValue("vISAUTHORIZED_INSERT");this.AV8AmenitiesTypeId=gx.fn.getIntegerValue("vAMENITIESTYPEID",gx.thousandSeparator)};this.s142_client=function(){return this.executeClientEvent(function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV14OrderedBy,4,0))+":"+(this.AV15OrderedDsc?"DSC":"ASC")},arguments)};this.s172_client=function(){return this.executeClientEvent(function(){this.AV16FilterFullText=""},arguments)};this.e12352_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e13352_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e14352_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e11352_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e15352_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e19352_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e20352_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,25,26,27,28,29,30,31,32,33,34,36,37,38,39,40,41,43,44,45,47];this.GXLastCtrlId=47;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",35,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"amenitiestypeamenitieswc",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);u=this.GridContainer;u.addSingleLineEdit("Update",36,"vUPDATE","",gx.getMessage("GXM_update"),"Update","char",0,"px",20,20,"start",null,[],"Update","Update",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");u.addSingleLineEdit("Delete",37,"vDELETE","",gx.getMessage("GX_BtnDelete"),"Delete","char",0,"px",20,20,"start",null,[],"Delete","Delete",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");u.addSingleLineEdit(98,38,"AMENITIESID",gx.getMessage("Id"),"","AmenitiesId","int",0,"px",4,4,"end",null,[],98,"AmenitiesId",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");u.addSingleLineEdit(101,39,"AMENITIESNAME",gx.getMessage("Name"),"","AmenitiesName","svchar",0,"px",40,40,"start",null,[],101,"AmenitiesName",!0,0,!1,!1,"Attribute",0,"WWColumn");this.GridContainer.emptyText=gx.getMessage("");this.setGrid(u);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,24,0,"BootstrapDropDownOptions",this.CmpContext+"DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");f=this.DDO_MANAGEFILTERSContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("IconType","Icontype","FontIcon","str");f.setProp("Icon","Icon","fas fa-filter","str");f.setProp("Caption","Caption","","str");f.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");f.setProp("Cls","Cls","ManageFilters","str");f.setProp("ActiveEventKey","Activeeventkey","","char");f.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");f.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");f.setProp("Visible","Visible",!0,"bool");f.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");f.addV2CFunction("AV18ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");f.addC2VFunction(function(n){n.ParentObject.AV18ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV18ManageFiltersData)});f.setC2ShowFunction(function(n){n.show()});f.addEventHandler("OnOptionClicked",this.e11352_client);this.setUserControl(f);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,42,29,"DVelop_DVPaginationBar",this.CmpContext+"GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");r=this.GRIDPAGINATIONBARContainer;r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Class","Class","PaginationBar","str");r.setProp("ShowFirst","Showfirst",!1,"bool");r.setProp("ShowPrevious","Showprevious",!0,"bool");r.setProp("ShowNext","Shownext",!0,"bool");r.setProp("ShowLast","Showlast",!1,"bool");r.setProp("PagesToShow","Pagestoshow",5,"num");r.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");r.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");r.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");r.setProp("SelectedPage","Selectedpage","","char");r.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");r.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");r.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");r.setProp("First","First","First","str");r.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");r.setProp("Next","Next","WWP_PagingNextCaption","str");r.setProp("Last","Last","Last","str");r.setProp("Caption","Caption",gx.getMessage("WWP_PagingCaption"),"str");r.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");r.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");r.addV2CFunction("AV24GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");r.addC2VFunction(function(n){n.ParentObject.AV24GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV24GridCurrentPage)});r.addV2CFunction("AV25GridPageCount","vGRIDPAGECOUNT","SetPageCount");r.addC2VFunction(function(n){n.ParentObject.AV25GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV25GridPageCount)});r.setProp("RecordCount","Recordcount","","str");r.setProp("Page","Page","","str");r.addV2CFunction("AV26GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");r.addC2VFunction(function(n){n.ParentObject.AV26GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV26GridAppliedFilters)});r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("ChangePage",this.e12352_client);r.addEventHandler("ChangeRowsPerPage",this.e13352_client);this.setUserControl(r);this.DDO_GRIDContainer=gx.uc.getNew(this,46,29,"DDOGridTitleSettingsM",this.CmpContext+"DDO_GRIDContainer","Ddo_grid","DDO_GRID");t=this.DDO_GRIDContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","","str");t.setProp("ActiveEventKey","Activeeventkey","","char");t.setProp("FilteredText_set","Filteredtext_set","","char");t.setProp("FilteredText_get","Filteredtext_get","","char");t.setProp("FilteredTextTo_set","Filteredtextto_set","","char");t.setProp("FilteredTextTo_get","Filteredtextto_get","","char");t.setProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("SelectedColumn","Selectedcolumn","","char");t.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("TitleControlAlign","Titlecontrolalign","","str");t.setProp("Visible","Visible","","str");t.setDynProp("GridInternalName","Gridinternalname","","str");t.setProp("ColumnIds","Columnids","2:AmenitiesId|3:AmenitiesName","str");t.setProp("ColumnsSortValues","Columnssortvalues","2|1","str");t.setProp("IncludeSortASC","Includesortasc","T","str");t.setProp("IncludeSortDSC","Includesortdsc","","str");t.setProp("AllowGroup","Allowgroup","","str");t.setProp("Fixable","Fixable","","str");t.setDynProp("SortedStatus","Sortedstatus","","char");t.setProp("IncludeFilter","Includefilter","","str");t.setProp("FilterType","Filtertype","","str");t.setProp("FilterIsRange","Filterisrange","","str");t.setProp("IncludeDataList","Includedatalist","","str");t.setProp("DataListType","Datalisttype","","str");t.setProp("AllowMultipleSelection","Allowmultipleselection","","str");t.setProp("DataListFixedValues","Datalistfixedvalues","","str");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("FixedFilters","Fixedfilters","","str");t.setProp("Format","Format","","str");t.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");t.setProp("SortASC","Sortasc","","str");t.setProp("SortDSC","Sortdsc","","str");t.setProp("AllowGroupText","Allowgrouptext","","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("CleanFilter","Cleanfilter","","str");t.setProp("RangeFilterFrom","Rangefilterfrom","","str");t.setProp("RangeFilterTo","Rangefilterto","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("SearchButtonText","Searchbuttontext","","str");t.addV2CFunction("AV21DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV21DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV21DDO_TitleSettingsIcons)});t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e14352_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,48,29,"WWP_GridEmpowerer",this.CmpContext+"GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");e=this.GRID_EMPOWERERContainer;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setDynProp("GridInternalName","Gridinternalname","","char");e.setProp("HasCategories","Hascategories",!1,"bool");e.setProp("InfiniteScrolling","Infinitescrolling","False","str");e.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");e.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");e.setProp("HasRowGroups","Hasrowgroups",!1,"bool");e.setProp("FixedColumns","Fixedcolumns","","str");e.setProp("PopoversInGrid","Popoversingrid","","str");e.setProp("Visible","Visible",!0,"bool");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEGRIDHEADER",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[10]={id:10,fld:"",grid:0};i[11]={id:11,fld:"",grid:0};i[12]={id:12,fld:"TABLEHEADER",grid:0};i[13]={id:13,fld:"",grid:0};i[14]={id:14,fld:"TABLEHEADERCONTENT",grid:0};i[15]={id:15,fld:"",grid:0};i[16]={id:16,fld:"TABLEACTIONS",grid:0};i[17]={id:17,fld:"",grid:0};i[18]={id:18,fld:"",grid:0};i[19]={id:19,fld:"",grid:0};i[20]={id:20,fld:"BTNINSERT",grid:0,evt:"e15352_client"};i[21]={id:21,fld:"",grid:0};i[22]={id:22,fld:"TABLERIGHTHEADER",grid:0};i[23]={id:23,fld:"",grid:0};i[25]={id:25,fld:"",grid:0};i[26]={id:26,fld:"TABLEFILTERS",grid:0};i[27]={id:27,fld:"",grid:0};i[28]={id:28,fld:"",grid:0};i[29]={id:29,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",fmt:0,gxz:"ZV16FilterFullText",gxold:"OV16FilterFullText",gxvar:"AV16FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV16FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV16FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(29,function(){});i[30]={id:30,fld:"",grid:0};i[31]={id:31,fld:"",grid:0};i[32]={id:32,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};i[33]={id:33,fld:"",grid:0};i[34]={id:34,fld:"",grid:0};i[36]={id:36,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:35,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:1,gxz:"ZV27Update",gxold:"OV27Update",gxvar:"AV27Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV27Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV27Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(35),gx.O.AV27Update,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV27Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};i[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:35,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:1,gxz:"ZV29Delete",gxold:"OV29Delete",gxvar:"AV29Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV29Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(35),gx.O.AV29Delete,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV29Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};i[38]={id:38,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:35,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMENITIESID",fmt:0,gxz:"Z98AmenitiesId",gxold:"O98AmenitiesId",gxvar:"A98AmenitiesId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A98AmenitiesId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z98AmenitiesId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("AMENITIESID",n||gx.fn.currentGridRowImpl(35),gx.O.A98AmenitiesId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A98AmenitiesId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("AMENITIESID",n||gx.fn.currentGridRowImpl(35),gx.thousandSeparator)},nac:gx.falseFn};i[39]={id:39,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:35,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMENITIESNAME",fmt:0,gxz:"Z101AmenitiesName",gxold:"O101AmenitiesName",gxvar:"A101AmenitiesName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A101AmenitiesName=n)},v2z:function(n){n!==undefined&&(gx.O.Z101AmenitiesName=n)},v2c:function(n){gx.fn.setGridControlValue("AMENITIESNAME",n||gx.fn.currentGridRowImpl(35),gx.O.A101AmenitiesName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A101AmenitiesName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("AMENITIESNAME",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};i[40]={id:40,fld:"",grid:0};i[41]={id:41,fld:"",grid:0};i[43]={id:43,fld:"",grid:0};i[44]={id:44,fld:"",grid:0};i[45]={id:45,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};i[47]={id:47,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMENITIESTYPEID",fmt:0,gxz:"Z99AmenitiesTypeId",gxold:"O99AmenitiesTypeId",gxvar:"A99AmenitiesTypeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A99AmenitiesTypeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z99AmenitiesTypeId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("AMENITIESTYPEID",gx.O.A99AmenitiesTypeId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A99AmenitiesTypeId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("AMENITIESTYPEID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(47,function(){});this.AV16FilterFullText="";this.ZV16FilterFullText="";this.OV16FilterFullText="";this.ZV27Update="";this.OV27Update="";this.ZV29Delete="";this.OV29Delete="";this.Z98AmenitiesId=0;this.O98AmenitiesId=0;this.Z101AmenitiesName="";this.O101AmenitiesName="";this.A99AmenitiesTypeId=0;this.Z99AmenitiesTypeId=0;this.O99AmenitiesTypeId=0;this.AV18ManageFiltersData=[];this.AV16FilterFullText="";this.AV24GridCurrentPage=0;this.AV21DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.A99AmenitiesTypeId=0;this.AV8AmenitiesTypeId=0;this.AV27Update="";this.AV29Delete="";this.A98AmenitiesId=0;this.A101AmenitiesName="";this.AV20ManageFiltersExecutionStep=0;this.AV33Pgmname="";this.AV14OrderedBy=0;this.AV15OrderedDsc=!1;this.AV28IsAuthorized_Update=!1;this.AV30IsAuthorized_Delete=!1;this.AV31IsAuthorized_AmenitiesName=!1;this.AV12GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV32IsAuthorized_Insert=!1;this.Events={e12352_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e13352_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e14352_client:["DDO_GRID.ONOPTIONCLICKED",!0],e11352_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e15352_client:["'DOINSERT'",!0],e19352_client:["ENTER",!0],e20352_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV8AmenitiesTypeId",fld:"vAMENITIESTYPEID",pic:"ZZZ9"},{av:"sPrefix"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV33Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV31IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV32IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0}],[{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV24GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV25GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV26GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV32IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV18ManageFiltersData",fld:"vMANAGEFILTERSDATA"},{av:"AV12GridState",fld:"vGRIDSTATE"}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV8AmenitiesTypeId",fld:"vAMENITIESTYPEID",pic:"ZZZ9"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV33Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV31IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV32IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV8AmenitiesTypeId",fld:"vAMENITIESTYPEID",pic:"ZZZ9"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV33Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV31IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV32IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{av:"",ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV8AmenitiesTypeId",fld:"vAMENITIESTYPEID",pic:"ZZZ9"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV33Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV31IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV32IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"sPrefix"},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"}],[{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"A98AmenitiesId",fld:"AMENITIESID",pic:"ZZZ9",hsh:!0},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV31IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0}],[{av:"AV27Update",fld:"vUPDATE"},{av:"gx.fn.getCtrlProperty('vUPDATE','Link')",ctrl:"vUPDATE",prop:"Link"},{av:"AV29Delete",fld:"vDELETE"},{av:"gx.fn.getCtrlProperty('vDELETE','Link')",ctrl:"vDELETE",prop:"Link"},{av:"gx.fn.getCtrlProperty('AMENITIESNAME','Link')",ctrl:"AMENITIESNAME",prop:"Link"}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV8AmenitiesTypeId",fld:"vAMENITIESTYPEID",pic:"ZZZ9"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV33Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV31IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV32IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"sPrefix"},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV12GridState",fld:"vGRIDSTATE"}],[{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV12GridState",fld:"vGRIDSTATE"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"},{av:"AV24GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV25GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV26GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV32IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV18ManageFiltersData",fld:"vMANAGEFILTERSDATA"}]];this.EvtParms["'DOINSERT'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV8AmenitiesTypeId",fld:"vAMENITIESTYPEID",pic:"ZZZ9"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV33Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV31IsAuthorized_AmenitiesName",fld:"vISAUTHORIZED_AMENITIESNAME",hsh:!0},{av:"AV32IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"sPrefix"},{av:"A98AmenitiesId",fld:"AMENITIESID",pic:"ZZZ9",hsh:!0}],[{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV24GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV25GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV26GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV28IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV30IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV32IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV18ManageFiltersData",fld:"vMANAGEFILTERSDATA"},{av:"AV12GridState",fld:"vGRIDSTATE"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV20ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV33Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV28IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV30IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV31IsAuthorized_AmenitiesName","vISAUTHORIZED_AMENITIESNAME",0,"boolean",4,0);this.setVCMap("AV12GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV32IsAuthorized_Insert","vISAUTHORIZED_INSERT",0,"boolean",4,0);this.setVCMap("AV8AmenitiesTypeId","vAMENITIESTYPEID",0,"int",4,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8AmenitiesTypeId","vAMENITIESTYPEID",0,"int",4,0);this.setVCMap("AV20ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV33Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV28IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV30IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV31IsAuthorized_AmenitiesName","vISAUTHORIZED_AMENITIESNAME",0,"boolean",4,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8AmenitiesTypeId","vAMENITIESTYPEID",0,"int",4,0);this.setVCMap("AV20ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV33Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV28IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV30IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV31IsAuthorized_AmenitiesName","vISAUTHORIZED_AMENITIESNAME",0,"boolean",4,0);u.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});u.addRefreshingVar({rfrVar:"AV14OrderedBy"});u.addRefreshingVar({rfrVar:"AV15OrderedDsc"});u.addRefreshingVar(this.GXValidFnc[29]);u.addRefreshingVar({rfrVar:"AV8AmenitiesTypeId"});u.addRefreshingVar({rfrVar:"AV20ManageFiltersExecutionStep"});u.addRefreshingVar({rfrVar:"AV33Pgmname"});u.addRefreshingVar({rfrVar:"AV28IsAuthorized_Update"});u.addRefreshingVar({rfrVar:"AV30IsAuthorized_Delete"});u.addRefreshingVar({rfrVar:"AV31IsAuthorized_AmenitiesName"});u.addRefreshingVar({rfrVar:"AV32IsAuthorized_Insert"});u.addRefreshingParm({rfrVar:"AV14OrderedBy"});u.addRefreshingParm({rfrVar:"AV15OrderedDsc"});u.addRefreshingParm(this.GXValidFnc[29]);u.addRefreshingParm({rfrVar:"AV8AmenitiesTypeId"});u.addRefreshingParm({rfrVar:"AV20ManageFiltersExecutionStep"});u.addRefreshingParm({rfrVar:"AV33Pgmname"});u.addRefreshingParm({rfrVar:"AV28IsAuthorized_Update"});u.addRefreshingParm({rfrVar:"AV30IsAuthorized_Delete"});u.addRefreshingParm({rfrVar:"AV31IsAuthorized_AmenitiesName"});u.addRefreshingParm({rfrVar:"AV32IsAuthorized_Insert"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}})})