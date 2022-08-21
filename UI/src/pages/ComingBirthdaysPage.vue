<template>
  <q-page class="fit row justify-center items-start content-center items-stretch q-px-md">
    <HumanCardComponent ref="humanCard" class="col-12 col-md-3 q-ma-md" style="height:75vh"></HumanCardComponent>
    <ComingBirthdaysComponent @getHuman="getHuman($event)" class="col-12 col-md-6 q-ma-md" style="height:75vh"></ComingBirthdaysComponent>
  </q-page>
</template>

<script>
import HumanCardComponent from 'components/HumanCardComponent.vue'
import ComingBirthdaysComponent from 'components/ComingBirthdaysComponent.vue'
import {defineComponent} from 'vue'
import {useRouter} from "vue-router";

export default defineComponent({
  components: { HumanCardComponent, ComingBirthdaysComponent },
  name: 'ComingBirthdaysPage',

  setup() {
    const router = useRouter()
    return { router }
  },

  methods: {
    getHuman(id){
      this.$refs.humanCard.getHuman(id);
    }
  }
})
</script>
