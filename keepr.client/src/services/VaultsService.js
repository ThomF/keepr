import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

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

}
export const vaultsService = new VaultsService()