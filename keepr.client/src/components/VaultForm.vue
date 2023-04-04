<template>
    <div class="container-fluid">
        <h3 class="my-2 border-bottom border-dark text-dark">Create a New Vault!</h3>
        <form class="row" @submit.prevent="createVault()">
            <div class="mb-3">
                <label for="" class="form-label">Name</label>
                <input type="text" class="form-control" v-model="editable.name" name="name" id="" aria-describedby="name"
                    placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Image</label>
                <input type="text" class="form-control" v-model="editable.img" name="img" id="" aria-describedby="helpId"
                    placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Description</label>
                <input type="text" class="form-control" v-model="editable.description" name="description" id=""
                    aria-describedby="helpId" placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Keep Private?</label>
                <i class="text-danger onhover">Warning! Cant Undo A Vault Set to
                    Private!</i><i class="ps-4 mdi mdi-arrow-right"></i>
                <input class="ms-3" type="checkbox" v-model="editable.isPrivate" name="isPrivate" id=""
                    aria-describedby="helpId" placeholder="">

            </div>
            <button class="btn btn-outline-success" data-bs-dismiss="modal" :disabled="!isFormComplete">Submit<i
                    class=" fs-2 mdi mdi-safe"></i></button>
        </form>
    </div>
</template>


<script>
import { ref, computed } from 'vue';
import Pop from '../utils/Pop';
import { vaultsService } from '../services/VaultsService';

export default {
    computed: {
        isFormComplete() {
            return this.editable.name && this.editable.img && this.editable.description;
        }
    },
    setup() {
        const editable = ref({})
        return {
            editable,
            async createVault() {
                try {
                    await vaultsService.createVault(editable.value)
                    Pop.success(`Created the ${editable.value.name} Vault`)
                    editable.value = {}
                } catch (error) {
                    Pop.error(error.message)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>