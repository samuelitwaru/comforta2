System.register(["./p-62fc4e49.system.js"],(function(t){"use strict";var i,e,a,n,o;return{setters:[function(t){i=t.r;e=t.c;a=t.g;n=t.h;o=t.H}],execute:function(){var r=":where(button){all:unset;display:-ms-flexbox;display:flex;height:100%;cursor:pointer}*,::before,::after{-webkit-box-sizing:border-box;box-sizing:border-box}:host{display:grid;grid-template-columns:1fr 48px;background-color:#fff;border-radius:5px;-webkit-box-shadow:0px 4px 25px rgba(0, 0, 0, 0.2509803922);box-shadow:0px 4px 25px rgba(0, 0, 0, 0.2509803922);overflow:hidden;white-space:break-spaces;opacity:0;-webkit-transform:translateX(calc(100% * var(--ch-notification-item-initial-X)));transform:translateX(calc(100% * var(--ch-notification-item-initial-X)));-webkit-animation:notification-added 250ms ease-in-out var(--delay-to-animate) forwards;animation:notification-added 250ms ease-in-out var(--delay-to-animate) forwards}.main{padding:12px}.close-image{background-color:currentColor;-webkit-mask:url(\"data:image/svg+xml,%3Csvg width='24' height='24' viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath d='M7.875 18L6.75 16.875L11.25 12.375L6.75 7.875L7.875 6.75L12.375 11.25L16.875 6.75L18 7.875L13.5 12.375L18 16.875L16.875 18L12.375 13.5L7.875 18Z'/%3E%3C/svg%3E\") 50% 50%/24px 24px no-repeat}@-webkit-keyframes notification-added{to{opacity:1;-webkit-transform:translateX(0);transform:translateX(0)}}@keyframes notification-added{to{opacity:1;-webkit-transform:translateX(0);transform:translateX(0)}}";var s=r;var c=t("ch_notifications_item",function(){function t(t){var a=this;this.handleNotificationDismiss=function(t){if(t===void 0){t=false}return function(){if(t){clearTimeout(a.timeout)}a.notificationDismiss.emit(Number(a.element.id))}};this.handleNotificationClick=function(t){if(t===void 0){t=false}return function(){if(t){clearTimeout(a.timeout)}a.notificationClick.emit(Number(a.element.id))}};i(this,t);this.notificationClick=e(this,"notificationClick",7);this.notificationDismiss=e(this,"notificationDismiss",7);this.buttonImgSrc=undefined;this.closeButtonLabel=undefined;this.leftImgSrc=undefined;this.showCloseButton=true;this.timeToDismiss=5e3}Object.defineProperty(t.prototype,"element",{get:function(){return a(this)},enumerable:false,configurable:true});t.prototype.componentDidLoad=function(){this.timeout=setTimeout(this.handleNotificationDismiss(false),this.timeToDismiss)};t.prototype.render=function(){return n(o,{key:"6b31270542a46e7afea2814c9cb20545527ec10f"},n("button",{key:"00b275fb5eddd49ab837f61ab25aa8340e1a333b",class:"main",part:"notification-item__main",type:"button",onClick:this.handleNotificationClick(true)},this.leftImgSrc&&n("img",{key:"e53ade2ac7da68dc84a83e72bc62fd7485ea3446","aria-hidden":"true",alt:"",src:this.leftImgSrc,loading:"lazy"}),n("slot",{key:"aa75df1d0596575f8d87f3e7979652d2a5f78934"})),this.showCloseButton&&n("button",{key:"c5556a7b3a54d6c639d0d2735352054ccbec0ecb","aria-label":this.closeButtonLabel,class:!this.buttonImgSrc?"close-image":undefined,part:"notification-item__close-button",type:"button",onClick:this.handleNotificationDismiss(true)},this.buttonImgSrc&&n("img",{key:"f76993ae2959da4b2588c5e6f3bf5eafb8d95d3f","aria-hidden":"true",alt:"",src:this.buttonImgSrc,loading:"lazy"})))};return t}());c.style=s}}}));
//# sourceMappingURL=p-0f3ec61a.system.entry.js.map