<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo"
          src="https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/85d209ef-682e-49a1-b63a-1a07012f9fe6/dftama1-016ec142-0989-4304-99e7-a070aabb967f.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzg1ZDIwOWVmLTY4MmUtNDlhMS1iNjNhLTFhMDcwMTJmOWZlNlwvZGZ0YW1hMS0wMTZlYzE0Mi0wOTg5LTQzMDQtOTllNy1hMDcwYWFiYjk2N2YucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.LN9CzqqGiCt68V9-Molr48GmRWTGE51StBv1zfQiYx4"
          height="45" />
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li class="m-3">
          <router-link :to="{ name: 'Home' }" class="btn text-dark lighten-30 selectable text-uppercase">
            <b>Home</b>
          </router-link>
        </li>
        <li class="m-3">
          <div class="dropdown">
            <button class="btn text-dark lighten-30 selectable text-uppercase" type="button" id="dropdownMenuButton"
              data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              CREATE <i class="mdi mdi-menu-down"></i>
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <a title="Create Keep" class="dropdown-item" data-bs-toggle="modal" data-bs-target="#keepForm">Keep <i
                  class="mdi mdi-human ms-3"></i></a>
              <a title="Create Vault" class="dropdown-item" data-bs-toggle="modal" data-bs-target="#vaultForm">Vault <i
                  class="mdi mdi-safe-square ms-3"></i></a>
            </div>
          </div>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
import Login from './Login.vue'
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
