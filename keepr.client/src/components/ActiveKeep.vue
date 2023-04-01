<template>
    <div v-if="keep">
        <p>{{ keep.description }}</p>
    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';

export default {
    setup() {
        return {
            keep: computed(() => AppState.keep)
        }
    }
}
</script>


<style lang="scss" scoped></style>