<template>
    <div v-if="vault">

        <div class="container">
            <div class="row text-center">
                <div class="col-2"></div>
                <div class="col-8 pt-3">
                    <div class="card elevation-5 banner">
                        <img class="banner" :src="vault.img" alt="">
                    </div>
                    <div v-if="account.id == vault.creatorId">
                        <button @click="deleteVault(vault.id)" class="btn text-danger" title="delete this keep"><i
                                class="mdi mdi-cancel"></i>Delete this Vault</button>
                    </div>
                    <div>
                        <button class="btn btnPast rounded-pill">
                            <h5> Keeps {{ keepsAct }}</h5>
                        </button>
                    </div>
                    <div class="vTitle text-light gfont">
                        <h1>{{ vault.name }}</h1>
                    </div>

                </div>
                <div class="col-2"></div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <section class="masonry">
                        <div v-for="v in keep">
                            <Keep :keep="v" />
                            <div v-if="account.id == vault.creatorId">
                                <button title="Remove this Keep" @click="deleteVaultKeep(v.vaultKeepId)"
                                    class="btn btn-danger text-light flt">
                                    <i class="mdi mdi-delete"></i>
                                </button>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>


    <Modal id="activeKeep">
        <ActiveKeep />
    </Modal>
    <Modal id="keepForm">
        <KeepForm />
    </Modal>
    <Modal id="vaultForm">
        <VaultForm />
    </Modal>
</template>


<script>
import { computed, onMounted, onUnmounted, watchEffect } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { router } from '../router';
import { vaultsService } from '../services/VaultsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    setup() {
        const route = useRoute();

        async function getKeeps() {
            try {
                const id = route.params.vaultId
                await vaultsService.getKeepsByVault(id)
            } catch (error) {
                Pop.error(error.message)
            }
        }

        async function getVault() {
            try {
                const id = route.params.vaultId
                // logger.log("this is the vault id to get vk", id)
                await vaultsService.getVault(id)
            } catch (error) {
                Pop.error(error.message)
                router.push({ name: 'Home' })
            }
        }

        onMounted(() => {
            getKeeps()
            getVault()
        })
        onUnmounted(() => {
            AppState.vault = {}
        })
        return {
            vault: computed(() => AppState.vault),
            keep: computed(() => AppState.vaultKeeps),
            account: computed(() => AppState.account),
            coverImg: computed(() => `url("${AppState.vault?.img}")`),
            keepsAct: computed(() => AppState.vaultKeep),

            async deleteVault(vaultId) {
                try {
                    if (await Pop.confirm("exiling this Vault will send it off forever! Are you sure?")) {
                        await vaultsService.deleteVault(vaultId)
                        router.push({ name: 'Home' })
                        Pop.success(`The ${this.vault.name} was deleted`)
                        // NOTE look into pushing after delete
                    }
                } catch (error) {
                    Pop.error(error.message)
                }
            },
            async deleteVaultKeep(vkId) {
                try {
                    logger.log(vkId)

                    if (await Pop.confirm('This cant be undone! Are you sure?')) {
                        await vaultsService.deleteVaultKeep(vkId)
                        Pop.success(`Removed The Keep`)
                    }
                } catch (error) {
                    Pop.error('problem deleting this vault keep', error.message)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
$gap: 1em;

.flt {
    transform: translateY(-80px);
}

.masonry {
    columns: 300px;
    column-gap: $gap;

    &>div {
        margin-top: $gap;
        display: inline-block;
    }
}

.coverBanner {
    background-image: v-bind(coverImg);
    height: 20em;
    object-fit: cover;
}

.btnPast {
    background: rgba(192, 104, 53, 0.354);
}

.banner {
    object-fit: cover;
    height: 25em;
}

.vTitle {
    transform: translateY(-180px);
    text-shadow: 2px 3px 3px black;
    font-family: Quando;
}
</style>