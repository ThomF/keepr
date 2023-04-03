<template>
    <div v-if="vault">

        <h1>{{ vault.name }}</h1>
        <div v-if="account.id == vault.creatorId">
            <button @click="deleteVault(vault.id)" class="btn text-danger" title="delete this keep"><i
                    class="mdi mdi-cancel"></i>Delete this Vault</button>
        </div>
        <section class="masonry">
            <div v-for="v in keep">
                <div v-if="account.id == vault.creatorId">
                    <button @click="deleteVaultKeep(v.vaultKeepId)" class="btn btn-outline text-danger">
                        <i class="mdi mdi-delete"></i>
                    </button>
                </div>
                <Keep :keep="v" />
            </div>
        </section>
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
import { computed, onMounted, onUnmounted } from 'vue';
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
            async deleteVault(vaultId) {
                try {
                    if (await Pop.confirm("exiling this Vault will send it off forever! Are you sure?")) {
                        await vaultsService.deleteVault(vaultId)
                        Pop.success(`The ${this.vault.name} was deleted`)
                        // NOTE look into pushing after delete
                        // router.push('account')
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

.masonry {
    columns: 300px;
    column-gap: $gap;

    &>div {
        margin-top: $gap;
        display: inline-block;
    }
}
</style>