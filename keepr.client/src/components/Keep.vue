<template>
    <div @click="setActiveKeep()" data-bs-toggle="modal" data-bs-target="#activeKeep">
        <div class="elevate ovC ">
            <img :src="keep.img" class=" img-fluid roundCard" alt="">
            <div class="d-flex justify-content-between p-2 ovBt">
                <h2 class="title text-light qfont ">{{ keep.name }}</h2>
                <img :src="keep.creator.picture" class="pfp floatImg " :title="keep.creator.name" alt="">
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
                props.keep.views++

            },
            async getMyVaults() {
                await accountService.getMyVaults()
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.elevate {
    position: relative;
}

.elevate img {
    display: block;
    max-width: 100%;
    height: auto;
}

.elevate .ovBt {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 8px;
    background-color: rgba(0, 0, 0, 0);
    color: #fff;
    font-size: 1.2rem;
    font-weight: bold;
}

.elevate .ovBt .title {
    margin: 0;
}

.elevate .ovBt .pfp {
    width: 40px;
    height: 40px;
    border-radius: 50%;
    object-fit: cover;
}

.pfp {
    border-radius: 50%;
    height: 50px;
}

.qfont {
    font-family: Quando;
}

// .floatImg {
//     padding-left: 140px;
// }

.title {
    text-shadow: 2px 2px 1px black;
    // transform: translateY(-60px);
}

// .ovBt {
//     position: absolute;
//     bottom: 0;
// }

// .ovC {
//     position: relative;
// }


// .elevate {
//     border-radius: 22px;
//     box-shadow: 2px 2px 2px rgba(32, 32, 32, 0.43);
// }
.roundCard {
    border-radius: 20px;
}

// .keepImg {
//     background-image: v-bind(keepImg);
//     background-position: center;
//     background-size: fit;
//     height: 20em;
//     width: 100%;
// }
</style>