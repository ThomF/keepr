import{_ as v,o as k,e as K,c as s,a as p,F as _,r as g,d as e,w as a,k as F,P as y,f as t,g as n,A as h}from"./index.5dd42013.js";const x={props:{vaults:{type:Array,required:!0}},setup(){async function r(){try{await F.getKeeps()}catch(c){y.error(c.message)}}return k(()=>{r()}),{keeps:K(()=>h.keeps)}}},A={class:"container"},P={class:"masonry"};function V(r,c,w,d,B,M){const l=t("Keep"),u=t("ActiveKeep"),o=t("Modal"),i=t("KeepForm"),m=t("VaultForm");return n(),s(_,null,[p("div",A,[p("section",P,[(n(!0),s(_,null,g(d.keeps,f=>(n(),s("div",null,[e(l,{keep:f},null,8,["keep"])]))),256))])]),e(o,{id:"activeKeep"},{default:a(()=>[e(u)]),_:1}),e(o,{id:"keepForm"},{default:a(()=>[e(i)]),_:1}),e(o,{id:"vaultForm"},{default:a(()=>[e(m)]),_:1})],64)}const C=v(x,[["render",V],["__scopeId","data-v-9df50120"]]);export{C as default};