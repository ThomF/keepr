<template>
    <div @click="setActiveKeep()" data-bs-toggle="modal" data-bs-target="#activeKeep">
        <div class="elevate ">
            <img :src="keep.img" class="img-fluid roundCard" alt="">
            <div class="d-flex justify-content-between p-2 ">
                <h2 class="title text-light qfont ">{{ keep.name }}</h2>
                <img :src="keep.creator.picture" class="pfp floatImg " alt="">
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
import { Account } from '../models/Account';
import { profilesService } from '../services/ProfilesService';
import { accountService } from '../services/AccountService';

export default {
    props: {
        keep: {
            type: Keep, required: true
        },
        // account: {
        //     type: Account, required: true
        // },
    },
    setup(props) {
        return {
            account: computed(() => AppState.account),
            keepImg: computed(() => `url("${props.keep.img}")`),
            async setActiveKeep() {
                await keepsService.setActiveKeep(props.keep, props.keep.id)
                await accountService.getMyVaults()
            },
            async getMyVaults() {
                await accountService.getMyVaults()
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

.qfont {
    font-family: Quando;
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

// .keepImg {
//     background-image: v-bind(keepImg);
//     background-position: center;
//     background-size: fit;
//     height: 20em;
//     width: 100%;
// }
</style>