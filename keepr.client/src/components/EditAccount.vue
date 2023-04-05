<template>
    <div class="container-fluid">
        <h3 class="my-2 border-bottom border-dark text-danger">Edit Account</h3>
        <form class="row" @submit.prevent="editAccount()">
            <div class="mb-3">
                <label for="" class="form-label">Name</label>
                <input type="text" class="form-control" v-model="editable.name" name="name" id="" aria-describedby="name"
                    placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Account Picture</label>
                <input type="text" class="form-control" v-model="editable.picture" name="picture" id=""
                    aria-describedby="helpId" placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Cover Image</label>
                <input type="text" class="form-control" v-model="editable.coverImg" name="coverImg" id=""
                    aria-describedby="helpId" placeholder="">
            </div>

            <button class="btn btn-success" data-bs-dismiss="modal" :disabled="!isFormComplete"><i
                    class=" fs-2 mdi mdi-shape-square-plus"></i></button>
        </form>
    </div>
</template>


<script>
import { ref, computed } from 'vue';
import { keepsService } from '../services/KeepsService';
import { accountService } from '../services/AccountService'
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    computed: {
        isFormComplete() {
            return this.editable.name && this.editable.picture && this.editable.coverImg;
        }
    },
    setup() {
        const editable = ref({})
        return {
            editable,
            async editAccount() {
                try {
                    // logger.log("[new keep data]", editable.value)
                    await accountService.editAccount(editable.value)
                    Pop.success('edited account')
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