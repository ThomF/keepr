import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Vault } from '../models/Vault'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getMyVaults() {
    const res = await api.get('account/vaults')
    logger.log('[Getting my Account Vaults]', res.data)
    AppState.vaults = res.data.map(v => new Vault(v))
  }

  async editAccount(edit) {
    const res = await api.post('account', edit)
    AppState.account.map(a => new Account(a))
  }

}

export const accountService = new AccountService()
