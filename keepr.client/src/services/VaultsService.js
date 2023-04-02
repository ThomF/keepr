import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultsService {
    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log('[New Vault Created]', res.data)
    }

}
export const vaultsService = new VaultsService()