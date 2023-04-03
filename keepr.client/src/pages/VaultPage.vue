<template>
    <div v-if="vault">

        <h1>{{ vault.name }}</h1>
        <div v-if="account.id == vault.creatorId">
            <button @click="deleteVault(vault.id)" class="btn text-danger" title="delete this keep"><i
                    class="mdi mdi-cancel"></i>Delete this Vault</button>
        </div>
        <section class="masonry">
            <div v-for="v in keep">
                <Vault :vault="v" />
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
            keep: computed(() => AppState.keeps),
            account: computed(() => AppState.account),
            async deleteVault(vaultId) {
                try {
                    if (await Pop.confirm("exiling this Vault will send it off forever! Are you sure?")) {
                        await vaultsService.deleteVault(vaultId)
                        Pop.success(`The ${this.vault.name} was deleted`)
                        router.push('')
                    }
                } catch (error) {
                    Pop.error(error.message)
                }
            },

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