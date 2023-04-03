<template>
    <div v-if="keep">
        <div class="container">
            <div class="row">
                <div class="col-6 card">
                    <div class="thisKeepImg">
                        <img :src="keep.img" class="imgF" alt="">
                    </div>
                </div>
                <div class="col-6 card">
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4 d-flex">
                            <div class="d-flex ps-3 m-3">
                                <i class="mdi mdi-eye"></i>
                                <p>{{ keep.views }}</p>
                            </div>
                            <div class="d-flex m-3">
                                <i class="mdi mdi-pin"></i>
                                <p>{{ keep.kept }}</p>
                            </div>
                        </div>
                        <div class="col-4"></div>
                    </div>
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-8">
                            <h2>{{ keep.name }}</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2"></div>
                        <div class="col-8">
                            <b>{{ keep.description }}</b>
                        </div>

                    </div>
                    <div class="row m-5 floatme">
                        <div class="d-flex justify-content-between">
                            <div class="col-2">
                                <div v-if="account.id == keep.creatorId">
                                    <button @click="deleteKeep(keep.id)" class="btn text-danger" title="delete this keep"><i
                                            class="mdi mdi-cancel"></i>Remove</button>
                                </div>
                            </div>
                            <div class="col-6">

                                <div class="dropdown">
                                    <button class="btn text-dark lighten-30 selectable text-uppercase" type="button"
                                        id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true"
                                        aria-expanded="false">
                                        <b>Select A Vault</b><i class="mdi mdi-menu-down"></i>
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                        <div v-for="v in vaults">
                                            <a @click="addToVault(keep.id, v.id)" :vault="v" class="dropdown-item">{{ v.name
                                            }}</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-4">
                                <router-link :to="{ name: 'Profile', params: { creatorId: keep.creatorId } }">
                                    <img :src="keep.creator.picture" data-bs-dismiss="modal" :title="keep.creatorId.name"
                                        class="pfp" alt="">
                                </router-link>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState';
import { Vault } from '../models/Vault';
import { keepsService } from '../services/KeepsService';
import { vaultsService } from '../services/VaultsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    props: {
        vaultz: {
            type: Vault, required: true
        }
    },

    setup() {
        const editable = ref({})


        return {
            editable,
            account: computed(() => AppState.account),
            keep: computed(() => AppState.keep),
            vaults: computed(() => AppState.vaults),

            async deleteKeep(keepId) {
                try {
                    if (await Pop.confirm("exiling this keep will send it off forever! Are you sure?")) {
                        await keepsService.deleteKeep(keepId)

                    }
                } catch (error) {
                    Pop.error(error.message)
                }
            },

            async addToVault(keepId, vaultId) {
                logger.log('[KeepId]', keepId, '[VaultId]', vaultId)
                try {
                    const body = { keepId: keepId, vaultId: vaultId }
                    await vaultsService.createVaultKeep(body)
                } catch (error) {
                    Pop.error('error adding keep to vault')
                    logger.log(error)
                }
            }


        }
    }
}
</script>


<style lang="scss" scoped>
.pfp {
    border-radius: 50%;
    height: 80px;
}

// .floatme {
//     transform: translateY(320px);
// }
</style>