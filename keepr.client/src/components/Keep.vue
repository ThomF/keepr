<template>
    <div @click="setActiveKeep()" data-bs-toggle="modal" data-bs-target="#activeKeep">
        <h3>{{ keep.name }}</h3>
    </div>
</template>


<script>
import { onMounted } from 'vue';
import { keepsService } from '../services/KeepsService';
import { logger } from '../utils/Logger';
import { Keep } from '../models/Keep.js';

export default {
    props: {
        keep: {
            type: Keep, required: true
        }
    },
    setup(props) {
        return {
            setActiveKeep() {
                keepsService.setActiveKeep(props.keep)
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>