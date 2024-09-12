function UCPageTree($) {

	var template = '<script src=\"https://cdn.jsdelivr.net/npm/apextree\"></script><div id=\"svg-tree\"></div><script>	function doClick(content){			alert(\'You clicked on \' + content )		}</script>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();



			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

			  		
			      const data = {
			        id: 'ms',
			        data: {
			          imageURL: 'https://i.pravatar.cc/300?img=68',
			          name: 'Home',
					  link: 'google.com'
			        },
			        options: {
			          nodeBGColor: '#cdb4db',
			          nodeBGColorHover: '#cdb4db',
			        },
			        children: [
			          {
			            id: 'mh',
			            data: {
			              imageURL: 'https://i.pravatar.cc/300?img=69',
			              name: 'Shopping',
						  link: 'google.com'
			            },
			            options: {
			              nodeBGColor: '#ffafcc',
			              nodeBGColorHover: '#ffafcc',
			            },
			            children: [
			              {
			                id: 'kb',
			                data: {
			                  imageURL: 'https://i.pravatar.cc/300?img=65',
			                  name: 'Groceries',
							  link: 'google.com'
			                },
			                options: {
			                  nodeBGColor: '#f8ad9d',
			                  nodeBGColorHover: '#f8ad9d',
			                },
			              },
			              {
			                id: 'cr',
			                data: {
			                  imageURL: 'https://i.pravatar.cc/300?img=60',
			                  name: 'Furniture',
							  link: 'google.com'
			                },
			                options: {
			                  nodeBGColor: '#c9cba3',
			                  nodeBGColorHover: '#c9cba3',
			                },
			              },
			            ],
			          },
			          {
			            id: 'cs',
			            data: {
			              imageURL: 'https://i.pravatar.cc/300?img=59',
			              name: 'Medical Supples',
						  link: 'google.com'
			            },
			            options: {
			              nodeBGColor: '#00afb9',
			              nodeBGColorHover: '#00afb9',
			            },
			            children: [
			              {
			                id: 'Noah_Chandler',
			                data: {
			                  imageURL: 'https://i.pravatar.cc/300?img=57',
			                  name: 'Nursing Care',
							  link: 'google.com'
			                },
			                options: {
			                  nodeBGColor: '#84a59d',
			                  nodeBGColorHover: '#84a59d',
			                },
			              },
			              {
			                id: 'Felix_Wagner',
			                data: {
			                  imageURL: 'https://i.pravatar.cc/300?img=52',
			                  name: 'Medicines',
							  link: 'google.com'
			                },
			                options: {
			                  nodeBGColor: '#0081a7',
			                  nodeBGColorHover: '#0081a7',
			                },
			              },
			            ],
			          },
			        ],
			      };
			      const options = {
			        contentKey: 'data',
			        width: '100%',
			        height: 700,
			        nodeWidth: 80,
			        nodeHeight: 100,
			        fontColor: '#fff',
			        borderColor: '#333',
			        childrenSpacing: 50,
			        siblingSpacing: 20,
			        direction: 'left',
			        nodeTemplate: (content) => 
			          `<div onclick="doClick('${content.name}')" style="cursor:pointer;display: flex;flex-direction: column;gap: 10px;justify-content: center;align-items: center;height: 100%;"><div style="text-align:center">${content.name}</div></div>`,
			        canvasStyle: 'border: 1px solid black;background: #f6f6f6;',
			        enableToolbar: true,
			      };
			      const tree = new ApexTree(document.getElementById('svg-tree'), options);
			      tree.render(data);
				
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