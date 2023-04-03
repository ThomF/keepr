<template>
  <div class="container">
    <section class="masonry">
      <div v-for="k in keeps">
        <Keep :keep="k" />
      </div>
    </section>
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
import { onMounted, computed } from 'vue'
import { AppState } from '../AppState'
import { accountService } from '../services/AccountService'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'

export default {
  props: {
    vaults: {
      type: Array, required: true
    }
  },
  setup() {
    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        Pop.error(error.message)
      }
    }
    async function getVaults() {
      try {
        await vaultsService.getVaults()
      } catch (error) {
        Pop.error(message.error)
      }
    }
    async function getActVaults() {
      try {
        await accountService.getMyVaults()
      } catch (error) {
        Pop.error(error.message)
      }
    }
    onMounted(() => {
      getKeeps()
      // getActVaults()
    })
    return {
      keeps: computed(() => AppState.keeps)
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

.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
