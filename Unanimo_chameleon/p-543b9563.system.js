System.register([],(function(t){"use strict";return{execute:function(){t("default",a);function a(t){var a={match:[/^\s*(?=\S)/,/[^:]+/,/:\s*/,/$/],className:{2:"attribute",3:"punctuation"}},s={match:[/^\s*(?=\S)/,/[^:]*[^: ]/,/[ ]*:/,/[ ]/,/.*$/],className:{2:"attribute",3:"punctuation",5:"string"}},e={match:[/^\s*/,/>/,/[ ]/,/.*$/],className:{2:"punctuation",4:"string"}},n={variants:[{match:[/^\s*/,/-/,/[ ]/,/.*$/]},{match:[/^\s*/,/-$/]}],className:{2:"bullet",4:"string"}};return{name:"Nested Text",aliases:["nt"],contains:[t.inherit(t.HASH_COMMENT_MODE,{begin:/^\s*(?=#)/,excludeBegin:!0}),n,e,a,s]}}}}}));
//# sourceMappingURL=p-543b9563.system.js.map