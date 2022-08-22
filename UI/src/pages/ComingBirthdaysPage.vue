<template>
  <q-page v-if="isIndex" class="full-width row wrap justify-center items-center content-center q-px-md full-width">
    <ComingBirthdaysComponent class="col-12 col-md-6 q-ma-md" style="height:75vh"></ComingBirthdaysComponent>
  </q-page>
  <q-page v-else class="fit row justify-center items-start content-center items-stretch q-px-md full-width">
    <div class="col-12 col-md-2 q-ma-md" style="height:75vh">
      <q-page-container>
        <router-view></router-view>
      </q-page-container>
    </div>
    <ComingBirthdaysComponent class="col-12 col-md-6 q-ma-md" style="height:75vh"></ComingBirthdaysComponent>
  </q-page>
</template>

<script>
import ComingBirthdaysComponent from 'components/ComingBirthdaysComponent.vue'
import {defineComponent} from 'vue'
import {useRouter} from "vue-router";

export default defineComponent({
  components: { ComingBirthdaysComponent },
  name: 'ComingBirthdaysPage',

  setup() {
    const router = useRouter()
    return { router }
  },

  computed: {
    isIndex() {
      return this.$route.name === 'ComingBirthdaysIndex'
    }
  }
})
</script>
