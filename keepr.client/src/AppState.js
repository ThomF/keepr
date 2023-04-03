import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  profile: null,
  keepsAct: null,
  vaultsAct: null,
  /** @type {import('./models/Keep.js').Keep} */
  keeps: {},
  /** @type {import('./models/Keep.js').Keep | null} */
  keep: null,
  /** @type {import('./models/Vault.js').Vault} */
  vaults: {},
  /** @type {import('./models/Vault.js').Vault | null} */
  vault: null,
})
