function e(e){const n="[a-z'][a-zA-Z0-9_']*",r="("+n+":"+n+"|"+n+")",a={keyword:"after and andalso|10 band begin bnot bor bsl bzr bxor case catch cond div end fun if let not of orelse|10 query receive rem try when xor",literal:"false true"},i=e.COMMENT("%","$"),d={className:"number",begin:"\\b(\\d+(_\\d+)*#[a-fA-F0-9]+(_[a-fA-F0-9]+)*|\\d+(_\\d+)*(\\.\\d+(_\\d+)*)?([eE][-+]?\\d+)?)",relevance:0},c={begin:"fun\\s+"+n+"/\\d+"},s={begin:r+"\\(",end:"\\)",returnBegin:!0,relevance:0,contains:[{begin:r,relevance:0},{begin:"\\(",end:"\\)",endsWithParent:!0,returnEnd:!0,relevance:0}]},l={begin:/\{/,end:/\}/,relevance:0},o={begin:"\\b_([A-Z][A-Za-z0-9_]*)?",relevance:0},t={begin:"[A-Z][a-zA-Z0-9_]*",relevance:0},b={begin:"#"+e.UNDERSCORE_IDENT_RE,relevance:0,returnBegin:!0,contains:[{begin:"#"+e.UNDERSCORE_IDENT_RE,relevance:0},{begin:/\{/,end:/\}/,relevance:0}]},g={beginKeywords:"fun receive if try case",end:"end",keywords:a};g.contains=[i,c,e.inherit(e.APOS_STRING_MODE,{className:""}),g,s,e.QUOTE_STRING_MODE,d,l,o,t,b];const u=[i,c,g,s,e.QUOTE_STRING_MODE,d,l,o,t,b];s.contains[1].contains=u,l.contains=u,b.contains[1].contains=u;const f=["-module","-record","-undef","-export","-ifdef","-ifndef","-author","-copyright","-doc","-vsn","-import","-include","-include_lib","-compile","-define","-else","-endif","-file","-behaviour","-behavior","-spec"],v={className:"params",begin:"\\(",end:"\\)",contains:u};return{name:"Erlang",aliases:["erl"],keywords:a,illegal:"(</|\\*=|\\+=|-=|/\\*|\\*/|\\(\\*|\\*\\))",contains:[{className:"function",begin:"^"+n+"\\s*\\(",end:"->",returnBegin:!0,illegal:"\\(|#|//|/\\*|\\\\|:|;",contains:[v,e.inherit(e.TITLE_MODE,{begin:n})],starts:{end:";|\\.",keywords:a,contains:u}},i,{begin:"^-",end:"\\.",relevance:0,excludeEnd:!0,returnBegin:!0,keywords:{$pattern:"-"+e.IDENT_RE,keyword:f.map((e=>`${e}|1.5`)).join(" ")},contains:[v]},d,e.QUOTE_STRING_MODE,b,o,t,l,{begin:/\.$/}]}}export{e as default};
//# sourceMappingURL=p-755baa57.js.map