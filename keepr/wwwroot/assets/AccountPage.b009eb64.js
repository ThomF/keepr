import{_ as C,c as _,a as t,t as v,F as f,r as y,b as A,d as c,w as i,o as B,e as a,u as E,f as o,g as l,h as m,A as n,l as k,p as N,i as D}from"./index.5dd42013.js";const h={setup(){async function s(){await m.getMyVaults()}async function d(){let e=n.account.id;k.log("ID",e),await m.getMyKeeps(e)}async function g(){try{await m.getAccount()}catch(e){k.log(e.message)}}return B(async()=>{await g(),s(),d()}),{account:a(()=>n.account),profile:a(()=>n.profile),vault:a(()=>n.vaults),keep:a(()=>n.keeps),coverImg:a(()=>`url("${n.account.coverImg}")`),vaultsAct:a(()=>n.vaultsAct),keepsAct:a(()=>n.keepsAct)}}},V=()=>{E(s=>({"4c5b40ec":s.coverImg}))},K=h.setup;h.setup=K?(s,d)=>(V(),K(s,d)):V;const P=h,u=s=>(N("data-v-c738312e"),s=s(),D(),s),j={key:0},L={class:"container pt-3"},T={class:"row"},W={class:"col-md-12"},q={class:"banner text-center"},z={class:"pt-md-3"},G={class:"vTitle text-light"},H={class:""},J=["src"],O=u(()=>t("div",{class:"pt-md-3"},[t("button",{class:"btn btn-success mdi mdi-pen","data-bs-toggle":"modal","data-bs-target":"#editAccount",title:"edit account"})],-1)),Q={class:"container"},R={class:"row"},U=u(()=>t("div",{class:"col-5"},null,-1)),X={class:"col-4"},Y={class:"fsm"},Z={class:"container pt-md-4"},$={class:"row"},tt=u(()=>t("div",null,[t("h1",null,"My Vaults")],-1)),et={key:0},st={class:"masonry"},ct=u(()=>t("div",null,[t("h1",null,"My Keeps")],-1)),ot={class:"masonry"};function nt(s,d,g,e,at,_t){const w=o("Vault"),M=o("Keep"),b=o("EditAccount"),F=o("modal"),I=o("ActiveKeep"),r=o("Modal"),S=o("KeepForm"),x=o("VaultForm");return e.account?(l(),_("div",j,[t("div",L,[t("div",T,[t("div",W,[t("div",q,[t("div",z,[t("h1",G,"Welcome "+v(e.account.name),1),t("div",H,[t("img",{class:"rounded",src:e.account.picture,alt:""},null,8,J)]),O])])])])]),t("div",Q,[t("div",R,[U,t("div",X,[t("h4",Y,"Keeps "+v(e.keepsAct)+" | Vaults "+v(e.vaultsAct),1)])])]),t("div",Z,[t("div",$,[tt,e.vault?(l(),_("div",et,[t("div",st,[(l(!0),_(f,null,y(e.vault,p=>(l(),_("div",null,[c(w,{vault:p},null,8,["vault"])]))),256))])])):A("",!0),ct,t("div",ot,[(l(!0),_(f,null,y(e.keep,p=>(l(),_("div",null,[c(M,{keep:p},null,8,["keep"])]))),256))])])]),c(F,{id:"editAccount"},{default:i(()=>[c(b)]),_:1}),c(r,{id:"activeKeep"},{default:i(()=>[c(I)]),_:1}),c(r,{id:"keepForm"},{default:i(()=>[c(S)]),_:1}),c(r,{id:"vaultForm"},{default:i(()=>[c(x)]),_:1})])):A("",!0)}const dt=C(P,[["render",nt],["__scopeId","data-v-c738312e"]]);export{dt as default};
