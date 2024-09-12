System.register(["./p-62fc4e49.system.js"],(function(t){"use strict";var i,n,e,s;return{setters:[function(t){i=t.r;n=t.c;e=t.g;s=t.h}],execute:function(){var r=":host{display:contents}";var h=r;var u=/%/g;var f=/^\d+(dip)?$/;var c=/^\d+(%)?$/;var o=t("ch_intersection_observer",function(){function t(t){this.defaultThreshold=[0];this.rootMarginString="";i(this,t);this.intersectionUpdate=n(this,"intersectionUpdate",7);this.bottomMargin=undefined;this.leftMargin=undefined;this.rightMargin=undefined;this.root=undefined;this.threshold=undefined;this.topMargin=undefined}Object.defineProperty(t.prototype,"element",{get:function(){return e(this)},enumerable:false,configurable:true});t.prototype.checkValidDipValue=function(t){return f.test(t)?this.convertDipToPxValue(t):"0px"};t.prototype.checkValidPercentValue=function(t){return c.test(t)?t:"0px"};t.prototype.convertDipToPxValue=function(t){var i=t.replace("dip","px");return i.split(" ").join("")};t.prototype.convertThresholdValueToNumber=function(t){if(c.test(t)){return Number(t.replace(u,""))/100}return 0};t.prototype.parseThreshold=function(t){var i=this;if(!t){return[0]}var n=[];var e=t.split(",");e.forEach((function(t){var e=i.convertThresholdValueToNumber(t);if(e<=1){n.push(e)}}));return n};t.prototype.setIntersectionObserver=function(){var t=this;var i={root:this.rootElement,rootMargin:this.rootMarginString,threshold:this.defaultThreshold};this.observer=new IntersectionObserver((function(i){t.intersectionUpdate.emit(i[0])}),i);var n=this.getChildElement();if(n){this.observer.observe(n)}};t.prototype.getChildElement=function(){var t=this.element.firstElementChild;while(t&&getComputedStyle(t).display==="contents"){t=t.firstElementChild}return t};t.prototype.setIntersectionObserverOptionsFromProperties=function(){if(this.root){this.rootElement=document.getElementById(this.root)}this.rootMarginString=[this.validatePosition(this.topMargin),this.validatePosition(this.leftMargin),this.validatePosition(this.bottomMargin),this.validatePosition(this.rightMargin)].join(" ");this.defaultThreshold=this.parseThreshold(this.threshold)};t.prototype.validatePosition=function(t){if(t&&t.endsWith("dip")){return this.checkValidDipValue(t)}return this.checkValidPercentValue(t)};t.prototype.componentDidLoad=function(){this.setIntersectionObserverOptionsFromProperties();this.setIntersectionObserver()};t.prototype.disconnectedCallback=function(){if(this.observer){this.observer.disconnect();this.observer=undefined}};t.prototype.render=function(){return s("slot",{key:"c1cc4ed4e7ef9537259ca9af42ce8e7549ed042e",name:"content"})};return t}());o.style=h}}}));
//# sourceMappingURL=p-448683f9.system.entry.js.map