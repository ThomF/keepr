import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { Vault } from "../models/Vault"
import { Keep } from "../models/Keep"

class VaultsService {
    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log('[New Vault Created]', res.data)
        AppState.vaults.push(res.data)
    }

    async getVaults() {
        const res = await api.get('api/vaults')
        logger.log('[Vaults]', res.data)
        AppState.vaults = res.data.map(v => new Vault(v))
    }

    async getUserVaults(user) {
        const res = await api.get(`api/profiles/${user}/vaults`)
        logger.log(res.data)
        AppState.vaults = res.data.map(v => new Vault(v))
    }
    async getKeepsByVault(id) {
        const res = await api.get(`api/vaults/${id}/keeps`)
        AppState.keeps = res.data.map(v => new Keep(v))
    }

}
export const vaultsService = new VaultsService()