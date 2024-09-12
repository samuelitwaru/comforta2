function UCAppToolBox($) {
	  
	  

	var template = '<style>.gjs-frame {  outline: medium none;  height: 100%;  width: 100%;  border: 10px solid #1E201E;  border-radius: 45px;  box-shadow: 0 10px 18px rgba(0, 0, 0, 0.6);  display: block;  transition: width 0.35s ease, height 0.35s ease;  position: absolute;  left: 0;  right: 0;  transform: translateY(5%);}*::-webkit-scrollbar {      width: 10px;    }.btn-custom {    color: #fff;    background-color: #28a745;    border-color: #28a745;    }</style><div id=\"gjs\"></div><script src=\"/Comforta2NETPostgreSQL/Resources/UCGrapes/plugins.js\"></script>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnOnSave = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnOnSave = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='OnSave']")
				.on('save', this.onOnSaveHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

			  	const UC = this
				const saveButton = document.getElementById('saveButton')
				
				var editor = grapesjs.init({
					container : '#gjs',
					fromElement: true,
					storageManager: false,
					//panels: { defaults: [] },
					deviceManager: {
						devices: [
						{
							name: 'Mobile',
							width: '360px', // Example width for mobile
							height: '800px', // Example height for mobile
							widthMedia: '480px', // Media query for mobile view
						},
						],
					},
					plugins: [myPlugin],
					pluginsOpts: {
						'grapesjs-blocks-bootstrap4': {
							blocks: {
								// ...
							},
							blockCategories: {
								// ...
							},
							labels: {
								// ...
							},
							// ...
						}
					},
					canvas: {
						styles: [
			            	"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css",
			//			'https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css',
						],
						scripts: [
						'https://code.jquery.com/jquery-3.3.1.slim.min.js',
						'https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js',
						'https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js'
						],
					}
				});
				
				
				editor.DomComponents.clear();
				
				const cssTag = this.PageTemplateCss
				
				const startTag = `<div id="status-bar" data-gjs-type="status-bar" style="
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
							`
				const endTag = ``
			    editor.setComponents(startTag + this.PageTemplateHtml + endTag);
			    editor.setStyle(cssTag)
				
				editor.Commands.add("save-page", {
					run(editor, sender) {
						sender.set("active", 0); // Turn off the button

						const html = editor.getHtml(); // Get the full HTML from the editor
						const css = editor.getCss();
						
						// Create a new DOM parser
						const parser = new DOMParser();
						const doc = parser.parseFromString(html, "text/html");
						
						// Find and remove the status bar element
						const statusBar = doc.querySelector('#status-bar');
						if (statusBar) {
							statusBar.remove();
						}
						
						// Extract only the content inside the <body> tag
						const body = doc.querySelector('body');
						const bodyContent = body ? body.innerHTML : '';
						
						// Create a new div element and set its content to the body content
						const resultDiv = document.createElement('div');
						resultDiv.innerHTML = bodyContent;
						
						// Get the outer HTML of the new div
						const cleanHtml = resultDiv.outerHTML;
						
						UC.PageTemplateHtml = cleanHtml
						UC.PageTemplateCss = css
						UC.OnSave();
					},
				});
				

		}


		this.onOnSaveHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
			}

			if (this.OnSave) {
				this.OnSave();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}