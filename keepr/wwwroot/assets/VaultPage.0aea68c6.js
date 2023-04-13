import{_ as F,c,a as t,b as h,t as y,F as K,r as S,d as a,w as g,o as P,m as T,A as l,e as r,P as o,v as u,q as b,l as B,u as N,f as d,g as i,n as M,p as R,i as D,s as H}from"./index.5dd42013.js";const f={setup(){const s=M();async function n(){try{const e=s.params.vaultId;await u.getKeepsByVault(e)}catch(e){o.error(e.message)}}async function V(){try{const e=s.params.vaultId;await u.getVault(e)}catch(e){o.error(e.message),b.push({name:"Home"})}}return P(()=>{n(),V()}),T(()=>{l.vault={}}),{vault:r(()=>l.vault),keep:r(()=>l.vaultKeeps),account:r(()=>l.account),coverImg:r(()=>{var e;return`url("${(e=l.vault)==null?void 0:e.img}")`}),keepsAct:r(()=>l.vaultKeep),async deleteVault(e){try{await o.confirm("exiling this Vault will send it off forever! Are you sure?")&&(await u.deleteVault(e),b.push({name:"Home"}),o.success(`The ${this.vault.name} was deleted`))}catch(_){o.error(_.message)}},async deleteVaultKeep(e){try{B.log(e),await o.confirm("This cant be undone! Are you sure?")&&(await u.deleteVaultKeep(e),o.success("Removed The Keep"))}catch(_){o.error("problem deleting this vault keep",_.message)}}}}},k=()=>{N(s=>({a6d0dd2a:s.coverImg}))},w=f.setup;f.setup=w?(s,n)=>(k(),w(s,n)):k;const j=f,p=s=>(R("data-v-befcae49"),s=s(),D(),s),q={key:0},E={class:"container"},L={class:"row text-center"},U=p(()=>t("div",{class:"col-2"},null,-1)),z={class:"col-8 pt-3"},G={class:"card elevation-5 banner"},J=["src"],O={key:0},Q=p(()=>t("i",{class:"mdi mdi-cancel"},null,-1)),W=H("Delete this Vault"),X=[Q,W],Y={class:"btn btnPast rounded-pill"},Z={class:"vTitle text-light gfont"},$=p(()=>t("div",{class:"col-2"},null,-1)),ee={class:"container"},te={class:"row"},se={class:"col-12"},oe={class:"masonry"},ae={key:0},ne=["onClick"],ce=p(()=>t("i",{class:"mdi mdi-delete"},null,-1)),le=[ce];function ie(s,n,V,e,_,re){const x=d("Keep"),I=d("ActiveKeep"),v=d("Modal"),A=d("KeepForm"),C=d("VaultForm");return i(),c(K,null,[e.vault?(i(),c("div",q,[t("div",E,[t("div",L,[U,t("div",z,[t("div",G,[t("img",{class:"banner",src:e.vault.img,alt:""},null,8,J)]),e.account.id==e.vault.creatorId?(i(),c("div",O,[t("button",{onClick:n[0]||(n[0]=m=>e.deleteVault(e.vault.id)),class:"btn text-danger",title:"delete this keep"},X)])):h("",!0),t("div",null,[t("button",Y,[t("h5",null," Keeps "+y(e.keepsAct),1)])]),t("div",Z,[t("h1",null,y(e.vault.name),1)])]),$])]),t("div",ee,[t("div",te,[t("div",se,[t("section",oe,[(i(!0),c(K,null,S(e.keep,m=>(i(),c("div",null,[a(x,{keep:m},null,8,["keep"]),e.account.id==e.vault.creatorId?(i(),c("div",ae,[t("button",{title:"Remove this Keep",onClick:de=>e.deleteVaultKeep(m.vaultKeepId),class:"btn btn-danger text-light flt"},le,8,ne)])):h("",!0)]))),256))])])])])])):h("",!0),a(v,{id:"activeKeep"},{default:g(()=>[a(I)]),_:1}),a(v,{id:"keepForm"},{default:g(()=>[a(A)]),_:1}),a(v,{id:"vaultForm"},{default:g(()=>[a(C)]),_:1})],64)}const ue=F(j,[["render",ie],["__scopeId","data-v-befcae49"]]);export{ue as default};