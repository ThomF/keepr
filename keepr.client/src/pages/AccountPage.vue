<template>
  <div v-if="account">
    <div class="container pt-3">
      <div class="row">
        <div class="col-md-12">
          <div class="card banner text-center">
            <!-- <img :src="account.coverImg" alt=""> -->
            <div class="pt-md-3">
              <h1 class="vTitle text-light">Welcome {{ account.name }}</h1>
              <div class="">
                <img class="rounded" :src="account.picture" alt="" />
              </div>
              <div class="pt-md-3">
                <button class="btn btn-success mdi mdi-pen" data-bs-toggle="modal" data-bs-target="#editAccount"
                  title="edit account"></button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container">
      <div class="row">
        <div class="col-5"></div>
        <div class="col-4 ">
          <h4 class="fsm">Keeps {{ keepsAct }} | Vaults {{ vaultsAct }}</h4>
        </div>
      </div>
    </div>

    <div class="container pt-md-4">
      <div class="row">
        <div>
          <h1>My Vaults</h1>
        </div>
        <div class="masonry">
          <div v-for="k in vault">
            <Vault :vault="k" />
          </div>
        </div>
        <div>
          <h1>My Keeps</h1>
        </div>
        <div class="masonry">
          <div v-for="k in keep">
            <Keep :keep="k" />
          </div>
        </div>

      </div>
    </div>
    <modal id="editAccount">
      <EditAccount />
    </modal>
    <Modal id="activeKeep">
      <ActiveKeep />
    </Modal>
    <Modal id="keepForm">
      <KeepForm />
    </Modal>
    <Modal id="vaultForm">
      <VaultForm />
    </Modal>
  </div>
</template>

<script>
import { computed, onMounted, watchEffect, ref } from 'vue'
import { AppState } from '../AppState'
import { accountService } from '../services/AccountService'
import { profilesService } from '../services/ProfilesService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {

  setup() {
    async function getMyVaults() {
      await accountService.getMyVaults()
    }
    async function getMyKeeps() {
      let id = AppState.account.id
      logger.log("ID", id)
      await accountService.getMyKeeps(id)
    }
    async function getAccount() {
      try {
        await accountService.getAccount()
      } catch (error) {
        logger.log(error.message)
      }
    }
    onMounted(async () => {
      await getAccount()
      getMyVaults()
      getMyKeeps()

    })

    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      vault: computed(() => AppState.vaults),
      keep: computed(() => AppState.keeps),
      coverImg: computed(() => `url("${AppState.account.coverImg}")`),
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

img {
  max-width: 100px;
}

.banner {
  object-fit: fill;
  height: 15em;
  background-image: v-bind(coverImg);
}

.vTitle {
  text-shadow: 2px 3px 3px black;
  font-family: Quando;
}

@media screen and (max-width: 768px) {
  .fsm {
    font-size: 20px;
    transform: translateX(-20px);
  }
}
</style>
