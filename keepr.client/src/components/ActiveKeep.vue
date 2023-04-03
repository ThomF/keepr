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
                        <div>

                            <!-- <form v-if="account.id" @submit.prevent="addToVault(editable.value, keep.id)" class="d-flex">
                                <button @click.stop type="submit"
                                    class="btn btn-outline-dark rounded-left d-flex flex-wrap m-auto">
                                    Add To Vault
                                </button>
                                <select placeholder="select a deck" @click.stop v-model="editable.value"
                                    class="form-select rounded-right w-75 m-auto " aria-label="Default select example">
                                    <option v-for="v in vault" :value="vault.id" selected>
                                        {{ vault.name }}</option>
                                </select>

                            </form> -->
                        </div>
                    </div>
                    <div class="row m-5 floatme">
                        <div class="d-flex justify-content-between">
                            <div v-if="account.id == keep.creatorId">
                                <button @click="deleteKeep(keep.id)" class="btn text-danger" title="delete this keep"><i
                                        class="mdi mdi-cancel"></i>Remove</button>
                            </div>
                            <router-link :to="{ name: 'Profile', params: { creatorId: keep.creatorId } }">
                                <img :src="keep.creator.picture" :title="keep.creatorId.name" class="pfp" alt="">
                            </router-link>
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
import { keepsService } from '../services/KeepsService';
import Pop from '../utils/Pop';

export default {
    props: {
        vault: {
            type: Array, required: true
        }
    },

    setup() {
        const editable = ref({})


        return {
            editable,
            account: computed(() => AppState.account),
            keep: computed(() => AppState.keep),

            async deleteKeep(keepId) {
                try {
                    if (await Pop.confirm("exiling this keep will send it off forever! Are you sure?")) {
                        await keepsService.deleteKeep(keepId)

                    }
                } catch (error) {
                    Pop.error(error.message)
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