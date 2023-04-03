import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { Vault } from "../models/Vault"
import { Keep } from "../models/Keep"

class VaultsService {
    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log('[New Vault Created]', res.data)
        AppState.vaults = res.data
    }

    async getVaults() {
        const res = await api.get('api/vaults')
        logger.log('[Vaults]', res.data)
        AppState.vaults = res.data.map(v => new Vault(v))
    }

    async getUserVaults(user) {
        const res = await api.get(`api/profiles/${user}/vaults`)
        // logger.log(res.data)
        AppState.vaults = res.data.map(v => new Vault(v))
        AppState.vaultsAct = AppState.vaults.length
    }
    async getVault(id) {
        const res = await api.get(`api/vaults/${id}`)
        AppState.vault = res.data
    }
    async getKeepsByVault(id) {
        const res = await api.get(`api/vaults/${id}/keeps`)
        logger.log('[Getting keeps in this vault]', res.data)
        AppState.vaultKeeps = res.data.map(v => new Keep(v))
        logger.log("AppstateKEEPS", AppState.vaultKeeps)
    }

    async createVaultKeep(body) {
        const res = await api.post('api/vaultkeeps', body)
        logger.log(res.data)
    }
    async deleteVault(vaultId) {
        const res = await api.delete(`api/vaults/${vaultId}`)
        logger.log('vault deleted!')
    }

}
export const vaultsService = new VaultsService()