<template>
  <div v-if="profile">
    <div class="container">
      <div class="row">
        <div class="col-12">
          <div class="card elevation-5 banner mt-4">
            <img class="banner" :src="profile.coverImg" alt="">
          </div>
        </div>
        <div class="row">
          <div class="col-md-4"></div>
          <div class="col-md-4">
            <section class="text-center elvt">
              <img class="pfp" :src="profile.picture" alt="">
              <h3>{{ profile.name }}</h3>
              <!-- NOTE add the keeps to appstate on load??? -->
              <h4>Keeps {{ keepsAct }} | Vaults {{ vaultsAct }}</h4>
            </section>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid">
      <div class="row mb-5">
        <div class="col-12">
          <div>
            <h1><b>Vaults</b></h1>
          </div>
          <!-- v-if="vault.isPrivate" -->
          <section class="masonry">
            <div v-for="v in vault">
              <Vault :vault="v" />
            </div>
          </section>
        </div>
      </div>
      <div class="row mt-5">
        <div class="col-12">
          <div>
            <h1><b>Keeps</b></h1>
          </div>
          <section class="masonry">
            <div v-for="k in keep">
              <Keep :keep="k" />
            </div>
          </section>
        </div>
      </div>
    </div>
  </div>
  <Modal id="activeKeep">
    <ActiveKeep />
  </Modal>
  <Modal id="keepForm">
    <KeepForm />
  </Modal>
  <Modal id="vaultForm">
    <VaultForm />
  </Modal>
</template>

<script>
import { onMounted, onUnmounted, computed } from 'vue';
import { useRoute } from 'vue-router';
import { profilesService } from '../services/ProfilesService';
import Pop from '../utils/Pop';
import { AppState } from '../AppState.js';
import { keepsService } from '../services/KeepsService';
import { vaultsService } from '../services/VaultsService';


export default {
  setup() {
    const route = useRoute();

    async function getUser() {
      try {
        const creatorId = route.params.creatorId
        await profilesService.getUser(creatorId)
      } catch (error) {
        Pop.error(error.message)
      }
    }

    async function getUserKeeps() {
      const user = route.params.creatorId
      await keepsService.getUserKeeps(user)
    }
    async function getUserVaults() {
      const user = route.params.creatorId
      await vaultsService.getUserVaults(user)
    }





    onMounted(() => {
      getUser()
      getUserKeeps()
      getUserVaults()
    })
    onUnmounted(() => {
      AppState.profile = []
    })
    return {
      profile: computed(() => AppState.profile),
      keep: computed(() => AppState.keeps),
      vault: computed(() => AppState.actVaults),
      vaultsAct: computed(() => AppState.vaultsAct),
      keepsAct: computed(() => AppState.keepsAct)
    }
  }
}
</script>

<style scoped lang="scss">
$gap: 1em;

.masonry {
  columns: 300px;
  column-gap: $gap;

  &>div {
    margin-top: $gap;
    display: inline-block;
  }
}

.banner {
  height: 300px;
  // width: 1000px;
  object-fit: cover;
}

.pfp {
  border-radius: 50%;
  height: 140px;
  border: 4px solid rgb(233, 232, 232);
  box-shadow: 2px 4px 2px rgb(178, 178, 178);
}

.elvt {
  transform: translateY(-90px);
}
</style>

