gx.evt.autoSkip=!1;gx.define("gamhome",!1,function(){this.ServerClass="gamhome";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamhome.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV22Id=gx.fn.getIntegerValue("vID",gx.thousandSeparator);this.AV16ApplicationHomeObject=gx.fn.getControlValue("vAPPLICATIONHOMEOBJECT");this.AV19isJavaEnvironment=gx.fn.getControlValue("vISJAVAENVIRONMENT")};this.e120n2_client=function(){return this.executeServerEvent("'CONFIRM'",!0,null,!1,!1)};this.e130n2_client=function(){return this.executeServerEvent("'GODEVMENU'",!0,null,!1,!1)};this.e140n2_client=function(){return this.executeServerEvent("'GOBACKEND'",!0,null,!1,!1)};this.e150n2_client=function(){return this.executeServerEvent("'GODOC'",!0,null,!1,!1)};this.e170n2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e180n2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6];this.GXLastCtrlId=6;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};this.AV22Id=0;this.AV16ApplicationHomeObject="";this.AV19isJavaEnvironment=!1;this.AV20HttpRequest={};this.Events={e120n2_client:["'CONFIRM'",!0],e130n2_client:["'GODEVMENU'",!0],e140n2_client:["'GOBACKEND'",!0],e150n2_client:["'GODOC'",!0],e170n2_client:["ENTER",!0],e180n2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV22Id",fld:"vID",pic:"ZZZ9",hsh:!0},{av:"AV16ApplicationHomeObject",fld:"vAPPLICATIONHOMEOBJECT",hsh:!0},{av:"AV19isJavaEnvironment",fld:"vISJAVAENVIRONMENT",hsh:!0}],[]];this.EvtParms["'CONFIRM'"]=[[{av:"AV22Id",fld:"vID",pic:"ZZZ9",hsh:!0},{av:"AV16ApplicationHomeObject",fld:"vAPPLICATIONHOMEOBJECT",hsh:!0}],[]];this.EvtParms["'GODEVMENU'"]=[[{av:"AV19isJavaEnvironment",fld:"vISJAVAENVIRONMENT",hsh:!0},{av:"this.AV20HttpRequest.Baseurl",ctrl:"vHTTPREQUEST",prop:"Baseurl"}],[]];this.EvtParms["'GOBACKEND'"]=[[{av:"AV19isJavaEnvironment",fld:"vISJAVAENVIRONMENT",hsh:!0}],[]];this.EvtParms["'GODOC'"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV22Id","vID",0,"int",4,0);this.setVCMap("AV16ApplicationHomeObject","vAPPLICATIONHOMEOBJECT",0,"char",100,0);this.setVCMap("AV19isJavaEnvironment","vISJAVAENVIRONMENT",0,"boolean",4,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamhome)})