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
        AppState.vaultKeeps = res.data.map(v => new Keep(v))
        logger.log("AppState VAULT KEEPS", AppState.vaultKeeps)
        AppState.vaultKeep = AppState.vaultKeeps.length
    }

    async createVaultKeep(body) {
        const res = await api.post('api/vaultkeeps', body)
        logger.log(res.data)
    }
    async deleteVault(vaultId) {
        const res = await api.delete(`api/vaults/${vaultId}`)
        logger.log('vault deleted!')
    }
    async deleteVaultKeep(vkId) {
        const res = await api.delete(`api/vaultkeeps/${vkId}`)
        logger.log('vaultKeep deleted', res.data)
        let i = AppState.vaultKeeps.findIndex(i => i.id == vkId)

        AppState.vaultKeeps.splice(i, 1)

    }

}
export const vaultsService = new VaultsService()