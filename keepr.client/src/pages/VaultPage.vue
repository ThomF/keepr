<template>
    <div v-if="vault">
        v
        <!-- <h1>{{ vault.title }}</h1> -->
        <div v-for="k in keeps">
            <Vault :vault="v" />
        </div>
    </div>
</template>


<script>
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
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

        onMounted(() => {
            getKeeps()
        })
        return {
            vault: computed(() => AppState.vault),
            keep: computed(() => AppState.keeps),

        }
    }
}
</script>


<style lang="scss" scoped></style>