var __spreadArray=this&&this.__spreadArray||function(e,n,a){if(a||arguments.length===2)for(var r=0,t=n.length,s;r<t;r++){if(s||!(r in n)){if(!s)s=Array.prototype.slice.call(n,0,r);s[r]=n[r]}}return e.concat(s||Array.prototype.slice.call(n))};System.register([],(function(e){"use strict";return{execute:function(){e("default",d);var n="[A-Za-z$_][0-9A-Za-z$_]*",a=["as","in","of","if","for","while","finally","var","new","function","do","return","void","else","break","catch","instanceof","with","throw","case","default","try","switch","continue","typeof","delete","let","yield","const","class","debugger","async","await","static","import","from","export","extends"],r=["true","false","null","undefined","NaN","Infinity"],t=["Object","Function","Boolean","Symbol","Math","Date","Number","BigInt","String","RegExp","Array","Float32Array","Float64Array","Int8Array","Uint8Array","Uint8ClampedArray","Int16Array","Int32Array","Uint16Array","Uint32Array","BigInt64Array","BigUint64Array","Set","Map","WeakSet","WeakMap","ArrayBuffer","SharedArrayBuffer","Atomics","DataView","JSON","Promise","Generator","GeneratorFunction","AsyncFunction","Reflect","Proxy","Intl","WebAssembly"],s=["Error","EvalError","InternalError","RangeError","ReferenceError","SyntaxError","TypeError","URIError"],i=["setInterval","setTimeout","clearInterval","clearTimeout","require","exports","eval","isFinite","isNaN","parseFloat","parseInt","decodeURI","decodeURIComponent","encodeURI","encodeURIComponent","escape","unescape"],c=["arguments","this","super","console","window","document","localStorage","sessionStorage","module","global"],o=[].concat(i,t,s);function l(e){var l=e.regex,d=function(e,n){var a=n.after;var r="</"+e[0].slice(1);return e.input.indexOf(r,a)!==-1},b=n,u={begin:"<>",end:"</>"},g=/<[A-Za-z0-9\\._:-]+\s*\/>/,m={begin:/<[A-Za-z0-9\\._:-]+/,end:/\/[A-Za-z0-9\\._:-]+>|\/>/,isTrulyOpeningTag:function(e,n){var a=e[0].length+e.index,r=e.input[a];if(r==="<"||r===","){n.ignoreMatch();return}r===">"&&(d(e,{after:a})||n.ignoreMatch());var t;var s=e.input.substring(a);if(t=s.match(/^\s*=/)){n.ignoreMatch();return}if((t=s.match(/^\s+extends\s+/))&&t.index===0){n.ignoreMatch();return}}},y={$pattern:n,keyword:a,literal:r,built_in:o,"variable.language":c},f="[0-9](_?[0-9])*",v="\\.(".concat(f,")"),p="0|[1-9](_?[0-9])*|0[0-7]*[89][0-9]*",A={className:"number",variants:[{begin:"(\\b(".concat(p,")((").concat(v,")|\\.)?|(").concat(v,"))[eE][+-]?(").concat(f,")\\b")},{begin:"\\b(".concat(p,")\\b((").concat(v,")\\b|\\.)?|(").concat(v,")\\b")},{begin:"\\b(0|[1-9](_?[0-9])*)n\\b"},{begin:"\\b0[xX][0-9a-fA-F](_?[0-9a-fA-F])*n?\\b"},{begin:"\\b0[bB][0-1](_?[0-1])*n?\\b"},{begin:"\\b0[oO][0-7](_?[0-7])*n?\\b"},{begin:"\\b0[0-7]+n?\\b"}],relevance:0},w={className:"subst",begin:"\\$\\{",end:"\\}",keywords:y,contains:[]},h={begin:"html`",end:"",starts:{end:"`",returnEnd:!1,contains:[e.BACKSLASH_ESCAPE,w],subLanguage:"xml"}},N={begin:"css`",end:"",starts:{end:"`",returnEnd:!1,contains:[e.BACKSLASH_ESCAPE,w],subLanguage:"css"}},_={begin:"gql`",end:"",starts:{end:"`",returnEnd:!1,contains:[e.BACKSLASH_ESCAPE,w],subLanguage:"graphql"}},k={className:"string",begin:"`",end:"`",contains:[e.BACKSLASH_ESCAPE,w]},x={className:"comment",variants:[e.COMMENT(/\/\*\*(?!\/)/,"\\*/",{relevance:0,contains:[{begin:"(?=@[A-Za-z]+)",relevance:0,contains:[{className:"doctag",begin:"@[A-Za-z]+"},{className:"type",begin:"\\{",end:"\\}",excludeEnd:!0,excludeBegin:!0,relevance:0},{className:"variable",begin:b+"(?=\\s*(-)|$)",endsParent:!0,relevance:0},{begin:/(?=[^\n])\s/,relevance:0}]}]}),e.C_BLOCK_COMMENT_MODE,e.C_LINE_COMMENT_MODE]},E=[e.APOS_STRING_MODE,e.QUOTE_STRING_MODE,h,N,_,k,{match:/\$\d+/},A];w.contains=E.concat({begin:/\{/,end:/\}/,keywords:y,contains:["self"].concat(E)});var Z=[].concat(x,w.contains),I=Z.concat([{begin:/\(/,end:/\)/,keywords:y,contains:["self"].concat(Z)}]),S={className:"params",begin:/\(/,end:/\)/,excludeBegin:!0,excludeEnd:!0,keywords:y,contains:I},z={variants:[{match:[/class/,/\s+/,b,/\s+/,/extends/,/\s+/,l.concat(b,"(",l.concat(/\./,b),")*")],scope:{1:"keyword",3:"title.class",5:"keyword",7:"title.class.inherited"}},{match:[/class/,/\s+/,b],scope:{1:"keyword",3:"title.class"}}]},B={relevance:0,match:l.either(/\bJSON/,/\b[A-Z][a-z]+([A-Z][a-z]*|\d)*/,/\b[A-Z]{2,}([A-Z][a-z]+|\d)+([A-Z][a-z]*)*/,/\b[A-Z]{2,}[a-z]+([A-Z][a-z]+|\d)*([A-Z][a-z]*)*/),className:"title.class",keywords:{_:__spreadArray(__spreadArray([],t,true),s,true)}},R={label:"use_strict",className:"meta",relevance:10,begin:/^\s*['"]use (strict|asm)['"]/},$={variants:[{match:[/function/,/\s+/,b,/(?=\s*\()/]},{match:[/function/,/\s*(?=\()/]}],className:{1:"keyword",3:"title.function"},label:"func.def",contains:[S],illegal:/%/},F={relevance:0,match:/\b[A-Z][A-Z_0-9]+\b/,className:"variable.constant"};function U(e){return l.concat("(?!",e.join("|"),")")}var j={match:l.concat(/\b/,U(__spreadArray(__spreadArray([],i,true),["super","import"],false)),b,l.lookahead(/\(/)),className:"title.function",relevance:0},O={begin:l.concat(/\./,l.lookahead(l.concat(b,/(?![0-9A-Za-z$_(])/))),end:b,excludeBegin:!0,keywords:"prototype",className:"property",relevance:0},T={match:[/get|set/,/\s+/,b,/(?=\()/],className:{1:"keyword",3:"title.function"},contains:[{begin:/\(\)/},S]},C="(\\([^()]*(\\([^()]*(\\([^()]*\\)[^()]*)*\\)[^()]*)*\\)|"+e.UNDERSCORE_IDENT_RE+")\\s*=>",L={match:[/const|var|let/,/\s+/,b,/\s*/,/=\s*/,/(async\s*)?/,l.lookahead(C)],keywords:"async",className:{1:"keyword",3:"title.function"},contains:[S]};return{name:"JavaScript",aliases:["js","jsx","mjs","cjs"],keywords:y,exports:{PARAMS_CONTAINS:I,CLASS_REFERENCE:B},illegal:/#(?![$_A-z])/,contains:[e.SHEBANG({label:"shebang",binary:"node",relevance:5}),R,e.APOS_STRING_MODE,e.QUOTE_STRING_MODE,h,N,_,k,x,{match:/\$\d+/},A,B,{className:"attr",begin:b+l.lookahead(":"),relevance:0},L,{begin:"("+e.RE_STARTERS_RE+"|\\b(case|return|throw)\\b)\\s*",keywords:"return throw case",relevance:0,contains:[x,e.REGEXP_MODE,{className:"function",begin:C,returnBegin:!0,end:"\\s*=>",contains:[{className:"params",variants:[{begin:e.UNDERSCORE_IDENT_RE,relevance:0},{className:null,begin:/\(\s*\)/,skip:!0},{begin:/\(/,end:/\)/,excludeBegin:!0,excludeEnd:!0,keywords:y,contains:I}]}]},{begin:/,/,relevance:0},{match:/\s+/,relevance:0},{variants:[{begin:u.begin,end:u.end},{match:g},{begin:m.begin,"on:begin":m.isTrulyOpeningTag,end:m.end}],subLanguage:"xml",contains:[{begin:m.begin,end:m.end,skip:!0,contains:["self"]}]}]},$,{beginKeywords:"while if switch catch for"},{begin:"\\b(?!function)"+e.UNDERSCORE_IDENT_RE+"\\([^()]*(\\([^()]*(\\([^()]*\\)[^()]*)*\\)[^()]*)*\\)\\s*\\{",returnBegin:!0,label:"func.def",contains:[S,e.inherit(e.TITLE_MODE,{begin:b,className:"title.function"})]},{match:/\.\.\./,relevance:0},O,{match:"\\$"+b,relevance:0},{match:[/\bconstructor(?=\s*\()/],className:{1:"title.function"},contains:[S]},j,F,z,T,{match:/\$[(.]/}]}}function d(e){var t=l(e),s=n,i=["any","void","number","boolean","string","object","never","symbol","bigint","unknown"],d={beginKeywords:"namespace",end:/\{/,excludeEnd:!0,contains:[t.exports.CLASS_REFERENCE]},b={beginKeywords:"interface",end:/\{/,excludeEnd:!0,keywords:{keyword:"interface extends",built_in:i},contains:[t.exports.CLASS_REFERENCE]},u={className:"meta",relevance:10,begin:/^\s*['"]use strict['"]/},g=["type","namespace","interface","public","private","protected","implements","declare","abstract","readonly","enum","override"],m={$pattern:n,keyword:a.concat(g),literal:r,built_in:o.concat(i),"variable.language":c},y={className:"meta",begin:"@"+s},f=function(e,n,a){var r=e.contains.findIndex((function(e){return e.label===n}));if(r===-1)throw new Error("can not find mode to replace");e.contains.splice(r,1,a)};Object.assign(t.keywords,m),t.exports.PARAMS_CONTAINS.push(y),t.contains=t.contains.concat([y,d,b]),f(t,"shebang",e.SHEBANG()),f(t,"use_strict",u);var v=t.contains.find((function(e){return e.label==="func.def"}));return v.relevance=0,Object.assign(t,{name:"TypeScript",aliases:["ts","tsx","mts","cts"]}),t}}}}));
//# sourceMappingURL=p-dcd93f0c.system.js.map