import { AppState } from "../AppState"
import { api } from "./AxiosService"

class ProfilesService {

    async getUser(creatorId) {
        AppState.profile = null
        const res = await api.get(`api/profiles/${creatorId}`)
        AppState.profile = res.data
    }


}
export const profilesService = new ProfilesService()