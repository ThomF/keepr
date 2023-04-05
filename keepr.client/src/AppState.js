import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  profile: null,
  keepsAct: null,
  vaultsAct: null,
  vaultKeep: null,
  /** @type {import('./models/Keep.js').Keep} */
  keeps: {},
  /** @type {import('./models/Keep.js').Keep | null} */
  keep: null,
  vaultKeeps: null,
  /** @type {import('./models/Vault.js').Vault} */
  vaults: {},
  actVaults: null,
  /** @type {import('./models/Vault.js').Vault | null} */
  vault: null,
})
