gx.evt.autoSkip=!1;gx.define("supplier_agbproductservicewc",!0,function(n){var r,u,i,t,f;this.ServerClass="supplier_agbproductservicewc";this.PackageName="GeneXus.Programs";this.ServerFullClass="supplier_agbproductservicewc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV25Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV14OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV15OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV23IsAuthorized_ProductServiceName=gx.fn.getControlValue("vISAUTHORIZED_PRODUCTSERVICENAME");this.AV24IsAuthorized_ProductServiceTypeName=gx.fn.getControlValue("vISAUTHORIZED_PRODUCTSERVICETYPENAME");this.AV8Supplier_AgbId=gx.fn.getIntegerValue("vSUPPLIER_AGBID",",")};this.Valid_Productserviceid=function(){var n=gx.fn.currentGridRowImpl(15);return this.validCliEvt("Valid_Productserviceid",15,function(){try{if(gx.fn.currentGridRowImpl(15)===0)return!0;var n=gx.util.balloon.getNew("PRODUCTSERVICEID",gx.fn.currentGridRowImpl(15));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Productservicetypeid=function(){var n=gx.fn.currentGridRowImpl(15);return this.validCliEvt("Valid_Productservicetypeid",15,function(){try{if(gx.fn.currentGridRowImpl(15)===0)return!0;var n=gx.util.balloon.getNew("PRODUCTSERVICETYPEID",gx.fn.currentGridRowImpl(15));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s132_client=function(){return this.executeClientEvent(function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV14OrderedBy,4,0))+":"+(this.AV15OrderedDsc?"DSC":"ASC")},arguments)};this.e11282_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e12282_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e13282_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e17282_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e18282_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];r=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,16,17,18,19,20,21,22,23,24,26,27,28,30];this.GXLastCtrlId=30;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",15,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"supplier_agbproductservicewc",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);u=this.GridContainer;u.addSingleLineEdit(73,16,"PRODUCTSERVICEID","Product Service Id","","ProductServiceId","int",0,"px",4,4,"end",null,[],73,"ProductServiceId",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit(74,17,"PRODUCTSERVICENAME","Product Service Name","","ProductServiceName","svchar",0,"px",40,40,"start",null,[],74,"ProductServiceName",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");u.addSingleLineEdit(75,18,"PRODUCTSERVICEDESCRIPTION","Product Service Description","","ProductServiceDescription","svchar",0,"px",200,80,"start",null,[],75,"ProductServiceDescription",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");u.addSingleLineEdit(76,19,"PRODUCTSERVICEQUANTITY","Product Service Quantity","","ProductServiceQuantity","int",0,"px",4,4,"end",null,[],76,"ProductServiceQuantity",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");u.addBitmap(77,"PRODUCTSERVICEPICTURE",20,0,"px",17,"px",null,"","Product Service Picture","Attribute","WWColumn hidden-xs");u.addSingleLineEdit(71,21,"PRODUCTSERVICETYPEID","Product Service Type Id","","ProductServiceTypeId","int",0,"px",4,4,"end",null,[],71,"ProductServiceTypeId",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");u.addSingleLineEdit(72,22,"PRODUCTSERVICETYPENAME","Product Service Type Name","","ProductServiceTypeName","svchar",0,"px",40,40,"start",null,[],72,"ProductServiceTypeName",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");this.GridContainer.emptyText="";this.setGrid(u);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,25,16,"DVelop_DVPaginationBar",this.CmpContext+"GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption","Page <CURRENT_PAGE> of <TOTAL_PAGES>","str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV20GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV20GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV20GridCurrentPage)});i.addV2CFunction("AV21GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV21GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV21GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV22GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV22GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV22GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e11282_client);i.addEventHandler("ChangeRowsPerPage",this.e12282_client);this.setUserControl(i);this.DDO_GRIDContainer=gx.uc.getNew(this,29,16,"DDOGridTitleSettingsM",this.CmpContext+"DDO_GRIDContainer","Ddo_grid","DDO_GRID");t=this.DDO_GRIDContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","","str");t.setProp("ActiveEventKey","Activeeventkey","","char");t.setProp("FilteredText_set","Filteredtext_set","","char");t.setProp("FilteredText_get","Filteredtext_get","","char");t.setProp("FilteredTextTo_set","Filteredtextto_set","","char");t.setProp("FilteredTextTo_get","Filteredtextto_get","","char");t.setProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("SelectedColumn","Selectedcolumn","","char");t.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("TitleControlAlign","Titlecontrolalign","","str");t.setProp("Visible","Visible","","str");t.setDynProp("GridInternalName","Gridinternalname","","str");t.setProp("ColumnIds","Columnids","0:ProductServiceId|1:ProductServiceName|2:ProductServiceDescription|3:ProductServiceQuantity|5:ProductServiceTypeId|6:ProductServiceTypeName","str");t.setProp("ColumnsSortValues","Columnssortvalues","1|2|3|4|5|6","str");t.setProp("IncludeSortASC","Includesortasc","T","str");t.setProp("IncludeSortDSC","Includesortdsc","","str");t.setProp("AllowGroup","Allowgroup","","str");t.setProp("Fixable","Fixable","","str");t.setDynProp("SortedStatus","Sortedstatus","","char");t.setProp("IncludeFilter","Includefilter","","str");t.setProp("FilterType","Filtertype","","str");t.setProp("FilterIsRange","Filterisrange","","str");t.setProp("IncludeDataList","Includedatalist","","str");t.setProp("DataListType","Datalisttype","","str");t.setProp("AllowMultipleSelection","Allowmultipleselection","","str");t.setProp("DataListFixedValues","Datalistfixedvalues","","str");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("FixedFilters","Fixedfilters","","str");t.setProp("Format","Format","","str");t.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");t.setProp("SortASC","Sortasc","","str");t.setProp("SortDSC","Sortdsc","","str");t.setProp("AllowGroupText","Allowgrouptext","","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("CleanFilter","Cleanfilter","","str");t.setProp("RangeFilterFrom","Rangefilterfrom","","str");t.setProp("RangeFilterTo","Rangefilterto","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("SearchButtonText","Searchbuttontext","","str");t.addV2CFunction("AV17DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV17DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV17DDO_TitleSettingsIcons)});t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e13282_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,31,30,"WWP_GridEmpowerer",this.CmpContext+"GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");f=this.GRID_EMPOWERERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setDynProp("GridInternalName","Gridinternalname","","char");f.setProp("HasCategories","Hascategories",!1,"bool");f.setProp("InfiniteScrolling","Infinitescrolling","False","str");f.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");f.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");f.setProp("HasRowGroups","Hasrowgroups",!1,"bool");f.setProp("FixedColumns","Fixedcolumns","","str");f.setProp("PopoversInGrid","Popoversingrid","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);r[2]={id:2,fld:"",grid:0};r[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};r[4]={id:4,fld:"",grid:0};r[5]={id:5,fld:"",grid:0};r[6]={id:6,fld:"TABLEGRIDHEADER",grid:0};r[7]={id:7,fld:"",grid:0};r[8]={id:8,fld:"",grid:0};r[10]={id:10,fld:"",grid:0};r[11]={id:11,fld:"",grid:0};r[12]={id:12,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};r[13]={id:13,fld:"",grid:0};r[14]={id:14,fld:"",grid:0};r[16]={id:16,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:this.Valid_Productserviceid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICEID",fmt:0,gxz:"Z73ProductServiceId",gxold:"O73ProductServiceId",gxvar:"A73ProductServiceId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A73ProductServiceId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z73ProductServiceId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICEID",n||gx.fn.currentGridRowImpl(15),gx.O.A73ProductServiceId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A73ProductServiceId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTSERVICEID",n||gx.fn.currentGridRowImpl(15),",")},nac:gx.falseFn};r[17]={id:17,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICENAME",fmt:0,gxz:"Z74ProductServiceName",gxold:"O74ProductServiceName",gxvar:"A74ProductServiceName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A74ProductServiceName=n)},v2z:function(n){n!==undefined&&(gx.O.Z74ProductServiceName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICENAME",n||gx.fn.currentGridRowImpl(15),gx.O.A74ProductServiceName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A74ProductServiceName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTSERVICENAME",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};r[18]={id:18,lvl:2,type:"svchar",len:200,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICEDESCRIPTION",fmt:0,gxz:"Z75ProductServiceDescription",gxold:"O75ProductServiceDescription",gxvar:"A75ProductServiceDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A75ProductServiceDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z75ProductServiceDescription=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICEDESCRIPTION",n||gx.fn.currentGridRowImpl(15),gx.O.A75ProductServiceDescription,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A75ProductServiceDescription=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTSERVICEDESCRIPTION",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};r[19]={id:19,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICEQUANTITY",fmt:0,gxz:"Z76ProductServiceQuantity",gxold:"O76ProductServiceQuantity",gxvar:"A76ProductServiceQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A76ProductServiceQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z76ProductServiceQuantity=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICEQUANTITY",n||gx.fn.currentGridRowImpl(15),gx.O.A76ProductServiceQuantity,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A76ProductServiceQuantity=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTSERVICEQUANTITY",n||gx.fn.currentGridRowImpl(15),",")},nac:gx.falseFn};r[20]={id:20,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICEPICTURE",fmt:0,gxz:"Z77ProductServicePicture",gxold:"O77ProductServicePicture",gxvar:"A77ProductServicePicture",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A77ProductServicePicture=n)},v2z:function(n){n!==undefined&&(gx.O.Z77ProductServicePicture=n)},v2c:function(n){gx.fn.setGridMultimediaValue("PRODUCTSERVICEPICTURE",n||gx.fn.currentGridRowImpl(15),gx.O.A77ProductServicePicture,gx.O.A40000ProductServicePicture_GXI)},c2v:function(n){gx.O.A40000ProductServicePicture_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A77ProductServicePicture=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTSERVICEPICTURE",n||gx.fn.currentGridRowImpl(15))},val_GXI:function(n){return gx.fn.getGridControlValue("PRODUCTSERVICEPICTURE_GXI",n||gx.fn.currentGridRowImpl(15))},gxvar_GXI:"A40000ProductServicePicture_GXI",nac:gx.falseFn};r[21]={id:21,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:this.Valid_Productservicetypeid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICETYPEID",fmt:0,gxz:"Z71ProductServiceTypeId",gxold:"O71ProductServiceTypeId",gxvar:"A71ProductServiceTypeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A71ProductServiceTypeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z71ProductServiceTypeId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICETYPEID",n||gx.fn.currentGridRowImpl(15),gx.O.A71ProductServiceTypeId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A71ProductServiceTypeId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTSERVICETYPEID",n||gx.fn.currentGridRowImpl(15),",")},nac:gx.falseFn};r[22]={id:22,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSERVICETYPENAME",fmt:0,gxz:"Z72ProductServiceTypeName",gxold:"O72ProductServiceTypeName",gxvar:"A72ProductServiceTypeName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A72ProductServiceTypeName=n)},v2z:function(n){n!==undefined&&(gx.O.Z72ProductServiceTypeName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSERVICETYPENAME",n||gx.fn.currentGridRowImpl(15),gx.O.A72ProductServiceTypeName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A72ProductServiceTypeName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTSERVICETYPENAME",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};r[23]={id:23,fld:"",grid:0};r[24]={id:24,fld:"",grid:0};r[26]={id:26,fld:"",grid:0};r[27]={id:27,fld:"",grid:0};r[28]={id:28,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};r[30]={id:30,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIER_AGBID",fmt:0,gxz:"Z55Supplier_AgbId",gxold:"O55Supplier_AgbId",gxvar:"A55Supplier_AgbId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A55Supplier_AgbId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z55Supplier_AgbId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SUPPLIER_AGBID",gx.O.A55Supplier_AgbId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A55Supplier_AgbId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SUPPLIER_AGBID",",")},nac:gx.falseFn};this.declareDomainHdlr(30,function(){});this.Z73ProductServiceId=0;this.O73ProductServiceId=0;this.Z74ProductServiceName="";this.O74ProductServiceName="";this.Z75ProductServiceDescription="";this.O75ProductServiceDescription="";this.Z76ProductServiceQuantity=0;this.O76ProductServiceQuantity=0;this.Z77ProductServicePicture="";this.O77ProductServicePicture="";this.Z71ProductServiceTypeId=0;this.O71ProductServiceTypeId=0;this.Z72ProductServiceTypeName="";this.O72ProductServiceTypeName="";this.A55Supplier_AgbId=0;this.Z55Supplier_AgbId=0;this.O55Supplier_AgbId=0;this.AV20GridCurrentPage=0;this.AV17DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.A55Supplier_AgbId=0;this.A40000ProductServicePicture_GXI="";this.AV8Supplier_AgbId=0;this.A73ProductServiceId=0;this.A74ProductServiceName="";this.A75ProductServiceDescription="";this.A76ProductServiceQuantity=0;this.A77ProductServicePicture="";this.A71ProductServiceTypeId=0;this.A72ProductServiceTypeName="";this.AV25Pgmname="";this.AV14OrderedBy=0;this.AV15OrderedDsc=!1;this.AV23IsAuthorized_ProductServiceName=!1;this.AV24IsAuthorized_ProductServiceTypeName=!1;this.Events={e11282_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e12282_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e13282_client:["DDO_GRID.ONOPTIONCLICKED",!0],e17282_client:["ENTER",!0],e18282_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV8Supplier_AgbId",fld:"vSUPPLIER_AGBID",pic:"ZZZ9"},{av:"sPrefix"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV25Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV23IsAuthorized_ProductServiceName",fld:"vISAUTHORIZED_PRODUCTSERVICENAME",hsh:!0},{av:"AV24IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",hsh:!0}],[{av:"AV20GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV21GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV22GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV8Supplier_AgbId",fld:"vSUPPLIER_AGBID",pic:"ZZZ9"},{av:"AV25Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV23IsAuthorized_ProductServiceName",fld:"vISAUTHORIZED_PRODUCTSERVICENAME",hsh:!0},{av:"AV24IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV8Supplier_AgbId",fld:"vSUPPLIER_AGBID",pic:"ZZZ9"},{av:"AV25Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV23IsAuthorized_ProductServiceName",fld:"vISAUTHORIZED_PRODUCTSERVICENAME",hsh:!0},{av:"AV24IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{av:"",ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV8Supplier_AgbId",fld:"vSUPPLIER_AGBID",pic:"ZZZ9"},{av:"AV25Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV23IsAuthorized_ProductServiceName",fld:"vISAUTHORIZED_PRODUCTSERVICENAME",hsh:!0},{av:"AV24IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",hsh:!0},{av:"sPrefix"},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"}],[{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV23IsAuthorized_ProductServiceName",fld:"vISAUTHORIZED_PRODUCTSERVICENAME",hsh:!0},{av:"A73ProductServiceId",fld:"PRODUCTSERVICEID",pic:"ZZZ9"},{av:"AV24IsAuthorized_ProductServiceTypeName",fld:"vISAUTHORIZED_PRODUCTSERVICETYPENAME",hsh:!0},{av:"A71ProductServiceTypeId",fld:"PRODUCTSERVICETYPEID",pic:"ZZZ9"}],[{av:"gx.fn.getCtrlProperty('PRODUCTSERVICENAME','Link')",ctrl:"PRODUCTSERVICENAME",prop:"Link"},{av:"gx.fn.getCtrlProperty('PRODUCTSERVICETYPENAME','Link')",ctrl:"PRODUCTSERVICETYPENAME",prop:"Link"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_PRODUCTSERVICEID=[[],[]];this.EvtParms.VALID_PRODUCTSERVICETYPEID=[[],[]];this.setVCMap("AV25Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV23IsAuthorized_ProductServiceName","vISAUTHORIZED_PRODUCTSERVICENAME",0,"boolean",4,0);this.setVCMap("AV24IsAuthorized_ProductServiceTypeName","vISAUTHORIZED_PRODUCTSERVICETYPENAME",0,"boolean",4,0);this.setVCMap("AV8Supplier_AgbId","vSUPPLIER_AGBID",0,"int",4,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8Supplier_AgbId","vSUPPLIER_AGBID",0,"int",4,0);this.setVCMap("AV25Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV23IsAuthorized_ProductServiceName","vISAUTHORIZED_PRODUCTSERVICENAME",0,"boolean",4,0);this.setVCMap("AV24IsAuthorized_ProductServiceTypeName","vISAUTHORIZED_PRODUCTSERVICETYPENAME",0,"boolean",4,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8Supplier_AgbId","vSUPPLIER_AGBID",0,"int",4,0);this.setVCMap("AV25Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV23IsAuthorized_ProductServiceName","vISAUTHORIZED_PRODUCTSERVICENAME",0,"boolean",4,0);this.setVCMap("AV24IsAuthorized_ProductServiceTypeName","vISAUTHORIZED_PRODUCTSERVICETYPENAME",0,"boolean",4,0);u.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});u.addRefreshingVar({rfrVar:"AV14OrderedBy"});u.addRefreshingVar({rfrVar:"AV15OrderedDsc"});u.addRefreshingVar({rfrVar:"AV8Supplier_AgbId"});u.addRefreshingVar({rfrVar:"AV25Pgmname"});u.addRefreshingVar({rfrVar:"AV23IsAuthorized_ProductServiceName"});u.addRefreshingVar({rfrVar:"AV24IsAuthorized_ProductServiceTypeName"});u.addRefreshingParm({rfrVar:"AV14OrderedBy"});u.addRefreshingParm({rfrVar:"AV15OrderedDsc"});u.addRefreshingParm({rfrVar:"AV8Supplier_AgbId"});u.addRefreshingParm({rfrVar:"AV25Pgmname"});u.addRefreshingParm({rfrVar:"AV23IsAuthorized_ProductServiceName"});u.addRefreshingParm({rfrVar:"AV24IsAuthorized_ProductServiceTypeName"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}})})