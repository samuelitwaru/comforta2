function UCAppToolBox(n){var i='<style>.gjs-frame {  outline: medium none;  height: 100%;  width: 100%;  border: 10px solid #1E201E;  border-radius: 45px;  box-shadow: 0 10px 18px rgba(0, 0, 0, 0.6);  display: block;  transition: width 0.35s ease, height 0.35s ease;  position: absolute;  left: 0;  right: 0;  transform: translateY(5%);}*::-webkit-scrollbar {      width: 10px;    }.btn-custom {    color: #fff;    background-color: #28a745;    border-color: #28a745;    }<\/style><div id="gjs"><\/div><script src="/Resources/UCGrapes/plugins.js"><\/script>',f={},r,u,t;Mustache.parse(i);r=0;this.show=function(){u=n(this.getContainerControl());r=0;this.setHtml(Mustache.render(i,this,f));this.renderChildContainers();n(this.getContainerControl()).find("[data-event='OnSave']").on("save",this.onOnSaveHandler.closure(this)).each(function(n){this.setAttribute("data-items-index",n+1)});this.Start()};this.Scripts=[];this.Start=function(){const t=this,f=document.getElementById("saveButton");var n=grapesjs.init({container:"#gjs",fromElement:!0,storageManager:!1,deviceManager:{devices:[{name:"Mobile",width:"360px",height:"800px",widthMedia:"480px"},]},plugins:[myPlugin],pluginsOpts:{"grapesjs-blocks-bootstrap4":{blocks:{},blockCategories:{},labels:{}}},canvas:{styles:["https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css",],scripts:["https://code.jquery.com/jquery-3.3.1.slim.min.js","https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js","https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"]}});n.DomComponents.clear();const i=this.PageTemplateCss,r=`<div id="status-bar" data-gjs-type="status-bar" style="
								background-color: #000;
								position: fixed;
								top: 0;  /* Fix it to the top of the screen */
								left: 0; /* Align it to the left edge */
								width: 100%; /* Make it span the full width */
								color: #fff;
								font-size: 12px;
								padding: 5px 20px;
								display: flex;
								justify-content: space-between;
								align-items: center;
								height: 24px;
								z-index: 9999; /* Ensure it stays on top of other content */
								">
								<div style="display: flex; gap: 10px;">
									<span style="font-size: 10px;">12:34</span>
								</div>
								<div style="display: flex; gap: 5px;">
									<i class="fa fa-signal"></i>
									<i class="fa fa-wifi"></i>
									<i class="fa fa-battery-three-quarters"></i>
								</div>
							</div>
							`,u=``;n.setComponents(r+this.PageTemplateHtml+u);n.setStyle(i);n.Commands.add("save-page",{run(n,i){i.set("active",0);const o=n.getHtml(),s=n.getCss(),h=new DOMParser,r=h.parseFromString(o,"text/html"),u=r.querySelector("#status-bar");u&&u.remove();const f=r.querySelector("body"),c=f?f.innerHTML:"",e=document.createElement("div");e.innerHTML=c;const l=e.outerHTML;t.PageTemplateHtml=l;t.PageTemplateCss=s;t.OnSave()}})};this.onOnSaveHandler=function(n){if(n){var t=n.currentTarget;n.preventDefault()}this.OnSave&&this.OnSave()};this.autoToggleVisibility=!0;t={};this.renderChildContainers=function(){u.find("[data-slot][data-parent='"+this.ContainerName+"']").each(function(i,r){var e=n(r),f=e.attr("data-slot"),u;u=t[f];u||(u=this.getChildContainer(f),t[f]=u,u.parentNode.removeChild(u));e.append(u);n(u).show()}.closure(this))}}