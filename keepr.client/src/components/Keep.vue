<template>
    <div @click="setActiveKeep()" data-bs-toggle="modal" data-bs-target="#activeKeep">
        <div class="elevate">
            <img :src="keep.img" class="img-fluid roundCard" alt="">
            <div class="d-flex justify-content-between p-2">
                <h2 class="title text-light ">{{ keep.name }}</h2>
                <img :src="account.picture" class="pfp floatImg " alt="">
            </div>
        </div>
    </div>
</template>


<script>
import { onMounted, computed } from 'vue';
import { keepsService } from '../services/KeepsService';
import { logger } from '../utils/Logger';
import { Keep } from '../models/Keep.js';
import { AppState } from '../AppState';

export default {
    props: {
        keep: {
            type: Keep, required: true
        }
    },
    setup(props) {
        return {
            account: computed(() => AppState.account),
            setActiveKeep() {
                keepsService.setActiveKeep(props.keep)
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.pfp {
    border-radius: 50%;
    height: 50px;
}

.floatImg {
    transform: translateY(-70px);
}

.title {
    text-shadow: 2px 2px 1px black;
    transform: translateY(-60px);
}

.roundCard {
    border-radius: 20px;
}

.elevate {
    border-radius: 22px;
    box-shadow: 2px 2px 2px rgba(32, 32, 32, 0.43);
}
</style>