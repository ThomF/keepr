<template>
    <div v-if="keep">
        <div class="container-fluid p-0 m-0">
            <div class="row m-0 p-0">
                <div class="col-6 m-0 p-0 nvb">
                    <img :src="keep.img" class="imgF" alt="">
                </div>
                <div class="col-6 ">
                    <div class="row justify-content-center ovTt p-1 m-0">
                        <div class="col-3"></div>
                        <div class="col-4 d-flex">
                            <div title="views" class="d-flex ps-3 m-3">
                                <i class="mdi mdi-eye"></i>
                                <p>{{ keep.views }}</p>
                            </div>
                            <div title="Kept" class="d-flex m-3">
                                <i class="mdi mdi-pin"></i>
                                <p>{{ keep.kept }}</p>
                            </div>
                        </div>
                        <div class="col-4"></div>
                    </div>
                    <div class="ovvT">
                        <div class="row text-center">
                            <div class="col-md-12">
                                <h2>{{ keep.name }}</h2>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-2"></div>
                            <div class="col-8">
                                <b>{{ keep.description }}</b>
                            </div>
                        </div>
                    </div>
                    <div class="row floatme ">
                        <div class="ovBt">
                            <div class="col-md-12 rmv p-0 m-0 d-flex justify-content-evenly ">
                                <div v-if="account.id == keep.creatorId" class="p-0 m-0">
                                    <button @click="deleteKeep(keep.id)" class="btn text-danger" title="delete this keep"><i
                                            class="mdi mdi-cancel"></i>Delete!</button>
                                </div>

                                <div v-if="account.id">
                                    <div class="dropdown p-0 m-0" title="Select a Vault">
                                        <button class="btn text-dark lighten-30 selectable text-uppercase" type="button"
                                            id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true"
                                            aria-expanded="false">
                                            <b>Select A Vault</b><i class="mdi mdi-menu-down"></i>
                                        </button>
                                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                            <div v-for="v in vaults">
                                                <a @click="addToVault(keep.id, v.id)" :vault="v" class="dropdown-item">{{
                                                    v.name
                                                }}</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <router-link :to="{ name: 'Profile', params: { creatorId: keep.creatorId } }">
                                    <img :src="keep.creator.picture" data-bs-dismiss="modal" :title="keep.creator.name"
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
import { computed, ref, onMounted } from 'vue';
import { AppState } from '../AppState';
import { Vault } from '../models/Vault';
import { accountService } from '../services/AccountService';
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
        // async function getAccount() {
        //     try {
        //         await accountService.getAccount()
        //         logger.log("getting account")
        //     } catch (error) {
        //         logger.log(error.message)
        //     }
        // }
        // onMounted(async () => {
        //     await getAccount()
        // })
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
                    this.keep.kept++
                    Pop.success(`Added ${this.keep.name} to vault`)
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

.imgF {
    width: 100%;
    object-fit: cover;
    object-position: center;
}


.dropdown-menu {
    max-height: 200px;
    overflow-y: auto;
}

.thisKeepImg {

    transform: translateX(-20px);
}

@media screen and (min-width: 769px) {
    // .ovBt {
    //     position: static;
    //     bottom: 50px;
    // }

    // .ovTt {
    //     height: 70%;
    // }

    .ovvT {
        height: 65%;
    }

    .ovRowName {
        padding-left: 80px;
    }

    // .ovC {
    //     position: relative;
    // }
}




// .floatme {
//     transform: translateY(320px);
// }

@media screen and (max-width: 768px) {

    .nvb,
    .navv {
        width: 100% !important;

    }

    .navv {
        max-height: 350px;
        overflow-y: auto;
    }

    .thisKeepImg {
        order: -1 !important;
        height: 40vh;
        transform: translateX(-20px);
        object-fit: cover;
    }

    .rmv {
        margin-right: 20px;
        transform: translateX(-20px);
    }


}
</style>