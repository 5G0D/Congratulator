<template>
  <q-page v-if="isIndex" class="full-width row wrap justify-center items-center content-center q-px-md full-width">
    <AllBirthdaysComponent class="col-12 col-md-6 q-ma-md" style="height:75vh"></AllBirthdaysComponent>
  </q-page>
  <q-page v-else class="fit row justify-center items-start content-center items-stretch q-px-md full-width">
    <div class="col-12 col-md-2 q-ma-md" style="height:75vh">
      <q-page-container>
        <router-view></router-view>
      </q-page-container>
    </div>
    <AllBirthdaysComponent class="col-12 col-md-6 q-ma-md" style="height:75vh"></AllBirthdaysComponent>
  </q-page>
</template>

<script>
import AllBirthdaysComponent from 'components/AllBirthdaysComponent.vue'
import {defineComponent} from 'vue'
import {useRouter} from "vue-router";

export default defineComponent({
  components: { AllBirthdaysComponent },
  name: 'AllBirthdaysPage',

  setup() {
    const router = useRouter()
    return { router }
  },

  computed: {
    isIndex() {
      return this.$route.name === 'AllBirthdaysIndex'
    }
  }
})
</script>
