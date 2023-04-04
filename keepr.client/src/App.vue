<template>
  <header class="sb">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-light text-dark">
    k e e p r
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}

@media screen and (max-width: 768px) {
  .sb {
    position: fixed;
    bottom: 0;
    z-index: 1;
    width: 100%;
  }


}
</style>
