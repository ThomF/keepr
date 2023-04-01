import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService {

    async getKeeps() {
        const res = await api.get('api/keeps')
        logger.log("[keeps]", res.data)
        AppState.keeps = res.data.map(k => new Keep(k))
    }

    setActiveKeep(keep) {
        AppState.keep = keep
    }




}
export const keepsService = new KeepsService()