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


    async createKeep(keepData) {
        const res = await api.post('api/keeps', keepData)
        logger.log("[Created Keep!]", res.data)
        AppState.keeps.push(res.data)
    }




}
export const keepsService = new KeepsService()