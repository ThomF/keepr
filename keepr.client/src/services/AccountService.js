import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Vault } from '../models/Vault'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { Keep } from "../models/Keep"


class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
      const v = await api.get('account/vaults')
      // logger.log('[Getting my Account Vaults]', v.data)
      AppState.vaults = v.data.map(v => new Vault(v))
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getMyVaults() {
    // const res = await api.get('account/vaults')
    // logger.log('[Getting my Account Vaults]', res.data)
    // AppState.vaults = res.data.map(v => new Vault(v))
    AppState.vaultsAct = AppState.vaults.length
  }

  async getMyKeeps(user) {
    const res = await api.get(`api/profiles/${user}/keeps`)
    AppState.keeps = res.data.map(v => new Keep(v))
    logger.log(res.data)
    AppState.keepsAct = AppState.keeps.length
  }

  async editAccount(edit) {
    const res = await api.put('account', edit)
    AppState.account = res.data
  }

}

export const accountService = new AccountService()
