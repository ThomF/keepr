<template>
  <div v-if="profile">
    <div class="container">
      <div class="row">
        <div class="col-12">
          <div class="card elevation-5 banner mt-4">
            <img class="banner"
              src="https://images.unsplash.com/photo-1680199693427-4a31f8ffc531?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1169&q=80"
              alt="">
          </div>
        </div>
        <div class="row">
          <div class="col-md-4"></div>
          <div class="col-md-4">
            <section class="text-center elvt">
              <img class="pfp" :src="profile.picture" alt="">
              <h3>{{ profile.name }}</h3>

              <h4>Keeps 0 | Vaults 0</h4>
            </section>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted, onUnmounted, computed } from 'vue';
import { useRoute } from 'vue-router';
import { profilesService } from '../services/ProfilesService';
import Pop from '../utils/Pop';
import { AppState } from '../AppState.js';


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

    onMounted(() => {
      getUser()
    })
    onUnmounted(() => {
      AppState.profile = []
    })
    return {
      profile: computed(() => AppState.profile)
    }
  }
}
</script>

<style scoped lang="scss">
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

