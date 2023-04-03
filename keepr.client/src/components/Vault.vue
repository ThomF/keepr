<template>
    <div>
        <div class="elevate ">
            <router-link :to="{ name: 'Vault', params: { vaultId: vault.id } }">
                <img :src="vault.img" class="img-fluid roundCard" alt="">
                <div class="d-flex justify-content-between p-2 ">
                    <h2 class="title text-light qfont ">{{ vault.name }}</h2>
                    <div v-if="vault.isPrivate">
                        <a class="mdi mdi-lock"></a>
                    </div>
                </div>
            </router-link>
        </div>
    </div>
</template>


<script>
import { Vault } from '../models/Vault';
import { AppState } from '../AppState';
import { vaultsService } from '../services/VaultsService';

export default {
    props: {
        vault: {
            type: Vault, required: true
        }
    },
    setup(props) {
        return {
            setActiveVault() {
                vaultsService.setActiveVault()
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.qfont {
    font-family: Quando;
}

.roundCard {
    border-radius: 20px;
}

.elevate {
    border-radius: 22px;
    box-shadow: 2px 2px 2px rgba(32, 32, 32, 0.43);
}

.title {
    text-shadow: 2px 2px 1px black;
    transform: translateY(-60px);
}
</style>