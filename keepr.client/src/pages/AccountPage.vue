<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
    <button class="btn btn-success mdi mdi-pen" data-bs-toggle="modal" data-bs-target="#editAccount"></button>
  </div>

  <div>
    <h1>My Vaults</h1>
  </div>
  <div class="masonry">
    <div v-for="k in vault">
      <Vault :vault="k" />
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
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { accountService } from '../services/AccountService'
import { profilesService } from '../services/ProfilesService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {

  setup() {
    async function getMyVaults() {
      try {
        await accountService.getMyVaults()
      } catch (error) {
        Pop.error(error.message)
      }
    }
    onMounted(() => {
      getMyVaults()
    })
    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      vault: computed(() => AppState.vaults)

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
</style>
