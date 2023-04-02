<template>
    <div class="container-fluid">
        <h3 class="my-2 border-bottom border-dark text-danger">Create a New Keep!</h3>
        <form class="row" @submit.prevent="createKeep()">
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
            <button class="btn btn-success" data-bs-dismiss="modal"><i class=" fs-2 mdi mdi-shape-square-plus"></i></button>
        </form>
    </div>
</template>


<script>
import { ref } from 'vue';
import { keepsService } from '../services/KeepsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            async createKeep() {
                try {
                    // logger.log("[new keep data]", editable.value)
                    await keepsService.createKeep(editable.value)
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